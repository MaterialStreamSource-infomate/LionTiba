'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z��ʐe�׽
' �y�쐬�zSIT
'**********************************************************************************************


#Region "  Imports      "

Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMate.clsComFuncFRM

#End Region

Public Class FRM_000002

#Region "�@���ʕϐ��A���ʒ萔"
    '***********************************************************************************************
    ' ���ʕϐ�
    '***********************************************************************************************
    Private mblnFKey(12) As Boolean     '(1): F1 �`�@(11): F12
    Private mintBlink As Integer        '�_�ŗp�����
    Protected mblnClose As Boolean      '�۰�ދ����׸�
    Private mobjMsgColor As Color       'ү���ފm�F�_�ŕ\���F

    '�\���F
    Private mobjMsgColorLevel00 As Color = Color.DarkGray  '�_�łȂ�
    Private mobjMsgColorLevel01 As Color = Color.Green     '����1�F
    Private mobjMsgColorLevel02 As Color = Color.Blue      '����2�F
    Private mobjMsgColorLevel03 As Color = Color.Red       '����3�F


    '-------------------------------------------------------
    ' �񋓑�
    '-------------------------------------------------------
    Enum cmd
        F1
        F2
        F3
        F4
        F5
        F6
        F7
        F8
        F10
        F11
    End Enum

#End Region


    '************************************************************************************************************************
    '************************************************************************************************************************
    '
    '���ްײ��  ��
    '
    '************************************************************************************************************************
    '************************************************************************************************************************
#Region "  F1  ���݉�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F1Process()



    End Sub
#End Region
#Region "  F2  ���݉�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2  ���݉�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F2Process()



    End Sub
#End Region
#Region "  F3  ���݉�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F3Process()



    End Sub
#End Region
#Region "  F4  ���݉�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F4Process()



    End Sub
#End Region
#Region "  F5  ���݉�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F5Process()



    End Sub
#End Region
#Region "  F6  ���݉�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F6Process()



    End Sub
#End Region
#Region "  F7  ���݉�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F7  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F7Process()



    End Sub
#End Region
#Region "  F8  ���݉�������"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z
    '*******************************************************************************************************************
    Public Overridable Sub F8Process()



    End Sub
#End Region
#Region "  ��ʵ���ݏ���    (�e��ʏ���)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʵ���ݏ���(�e��ʏ���)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()



    End Sub
#End Region
#Region "  ��ʸ۰�ޏ���    (�e��ʏ���)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʸ۰�ޏ���(�e��ʏ���)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub CloseChild()



    End Sub
#End Region
#Region "  ��ʑJ��ý�      ��ϰ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ��ʑJ��ý� ��ϰ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub FormMoveTest()



    End Sub
#End Region
#Region "  ��د�ޕ\������1          "
    '''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\������1
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub grdListDisplayChild()



    End Sub
#End Region
#Region "  ��د�ޕ\������2          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\������2
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub grdListDisplayChild2()



    End Sub
#End Region
#Region "  ��د�ޕ\������3          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\������3
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub grdListDisplayChild3()



    End Sub
#End Region

    '************************************************************************************************************************
    '************************************************************************************************************************
    '
    '���ްײ��  �s��
    '
    '************************************************************************************************************************
    '************************************************************************************************************************
#Region "  ��ʏ�����                   (�S��ʋ���)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʏ�����(�S��ʋ���)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Initialize_Template()
        Dim intRet As Integer                   '�߂�l

        '**********************************************************
        '�޻޲�Ӱ�ގ��͏������
        '**********************************************************
        If Me.DesignMode = True Then Exit Sub '�޻޲�Ӱ�ނ̎�����۸��т����s���Ȃ�
        If IsNull(gobjDb) Then Exit Sub '�׸ِڑ���޼ު�Ă��Ȃ����́A��۸��т����s���Ȃ�


        '**********************************************************
        '���ʕϐ�������
        '**********************************************************
        mblnClose = False                        ' �۰�ދ����׸�


        '**********************************************************
        '���ُ�����
        '**********************************************************
        lblErrMsg.Text = ""                         ' �װү���ޏ�����
        lblTermName.Text = gcstrFTERM_NAME          ' �[�����\��
        lblUserName.Text = gcstrFUSER_NAME           ' ���[�U���\��
        Call Set_Time()                             ' �����\��


        '**********************************************************
        ' ���ݏ�����
        '**********************************************************
        ' ̧ݸ��ݷ�
        For ii As cmd = cmd.F1 To cmd.F11
            mblnFKey(ii) = False
        Next
        mblnFKey(cmd.F10) = True        'F10
        mblnFKey(cmd.F11) = True        'F11�����L���ɂ���

        '**********************************************************
        ' ���ڰ���ү���ޏ�����
        '**********************************************************
        '������������************************************************************************************************************
        'SystemMate:A.Noto 2012/09/19 �ż������ݕ\���ύX
        'cmdMsgChk.ForeColor = Color.DarkGray
        cmdMsgChk.BackgroundImage = Nothing
        '������������************************************************************************************************************

        '**********************************************************
        ' ��ϰ�l�擾�E�ݒ�
        '**********************************************************
        tmrTime.Interval = gcinttmrTime_Interval
        tmrBlink.Interval = gcinttmrBlink_Interval
        tmrOpeMsg.Interval = gcinttmrOpeMsg_Interval
        tmrTest_1.Interval = gcinttmrTest_1_Interval
        tmrTime.Enabled = True
        tmrOpeMsg.Enabled = True
        tmrTest_1.Enabled = True


        '**********************************************************
        ' �ƭ����ݖ��擾
        '**********************************************************
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd01)      '�������
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd02)      '���o�ɋƖ��ƭ�
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd03)      '���Y�����ƭ�
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd04)      '�������ʓo�^
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd05)      '�o�׋Ɩ��ƭ�
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd06)      '�⍇���ƭ�
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd08)      '����ݽ�ƭ�
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd09)      'Ͻ�����ݽ�ƭ�
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd10)      '��������ݽ�ƭ�

        '**********************************************************
        ' �ƭ����ݖ��擾
        '**********************************************************
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu02_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu02_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu02_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu02_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_03)
        'Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_04)

        '������������************************************************************************************************************
        'JobMate:YAMAMOTO 2017/04/01 1F��ޏo�ɓo�^ 
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_05)
        '������������************************************************************************************************************

        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_06)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_07)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_08)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_09)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_06)
        '������������************************************************************************************************************
        'JobMate:N.Nakada 2013/11/01 �I�����X�g
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_07)
        '������������************************************************************************************************************
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_06)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_07)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_06)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_07)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_06)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_07)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_08)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_09)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_10)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_11)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_12)

        '������������************************************************************************************************************
        'JobMate:YAMAMOTO 2017/04/01 1F��ޏo�ɓo�^ 
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_13)
        '������������************************************************************************************************************


        '**********************************************************
        ' ̫�і��擾
        '**********************************************************
        Dim objTDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)

        objTDSP_NAME.FDISP_ID = Me.Name                 '���ID     ���
        objTDSP_NAME.FCTRL_ID = FCTRL_ID_SKOTEI          '���۰�ID     ���
        intRet = objTDSP_NAME.GET_TDSP_NAME(False)      '���擾
        If intRet <> RetCode.OK Then
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_BUTTONTEXTSET_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Err, _
                              "ID�@�F" & objTDSP_NAME.FDISP_ID)
            Exit Sub
        End If

        '###�Ɖ��s������
        Dim strTitle As String
        strTitle = Replace(objTDSP_NAME.FOBJECT_NAME, REPLACE_STRING_01, "")
        strTitle = Replace(strTitle, vbCrLf, "")

        lblTitle.Text = " " & strTitle          '����   ��\��
        Call gobjComFuncFRM.AddToLog_frm(lblTitle.Text & "�ɓW�J")


        '**********************************************************
        ' ���ݐݒ�
        '**********************************************************
        Call CmdEnabledChangeButton(cmdF1, Me.Name, True)                  'F1����
        Call CmdEnabledChangeButton(cmdF2, Me.Name, True)                  'F2����
        Call CmdEnabledChangeButton(cmdF3, Me.Name, True)                  'F3����
        Call CmdEnabledChangeButton(cmdF4, Me.Name, True)                  'F4����
        Call CmdEnabledChangeButton(cmdF5, Me.Name, True)                  'F5����
        Call CmdEnabledChangeButton(cmdF6, Me.Name, True)                  'F6����
        Call CmdEnabledChangeButton(cmdF7, Me.Name, True)                  'F7����
        Call CmdEnabledChangeButton(cmdF8, Me.Name, True)                  'F8����

        ' ''**********************************************************
        ' '' �ƭ����ݐݒ�
        ' ''**********************************************************
        ''Call CmdEnabledChangeMenu()


        '**********************************************************
        ' ү����۸ތ���
        '**********************************************************
        Call GetLogMessage()
        tmrOpeMsg.Enabled = True


        '**********************************************************
        ' ���ޯ���׸�����
        '**********************************************************
        If TO_NUMBER(gcstrDEGUB_FLG) = FLAG_ON Then
            '=================================================
            '���ޯ��Ӱ��
            '=================================================
            'Me.Text = "���ޯ��Ӱ��"                     '����ް���o����
            Me.Text = "MaterialStream"                  '����ް���o����
            Me.ControlBox = True                        '�ŏ������ݗL��
            Me.MinimizeBox = True                       '�ŏ������ݗL��
            Me.MaximizeBox = True                       '�ő剻���ݗL��
            Me.WindowState = FormWindowState.Normal     '��ʻ���
            Me.Size = New Size(1366, 768)               '��ʻ���
            Me.MaximumSize = New Size(1366, 768)        '��ʻ���
            Me.MinimumSize = New Size(1366, 768)        '��ʻ���
            'Me.ShowInTaskbar = True                     '����ް�\��(�����L���ɂ���Ɖ�ʂ�������)
            Me.Location = gobjLocation                  '��ʈʒu


        Else
            '=================================================
            '����Ӱ��
            '=================================================
            '�������Ȃ�

        End If


        '**********************************************************
        ' ��ʑJ��ý���ϰ�׸�����
        '**********************************************************
        Select Case gcstrTMRTEST_1
            Case FLAG_ON
                tmrTest_1.Enabled = True
            Case Else
                tmrTest_1.Enabled = False
        End Select

        '*************************************************
        ' �������ݐݒ�
        '*************************************************
        If gcintAfkFlg = FLAG_OFF Then
            Me.btnAFK.Text = ""
            Me.btnAFK.Visible = False
        End If


        '**********************************************************
        ' �J���җp���ݐݒ�
        '**********************************************************
        If TO_NUMBER(gcstrDEGUB_FLG) = 9 Then
            cmdDevelopment.Visible = True
        Else
            cmdDevelopment.Visible = False
        End If


    End Sub
#End Region
#Region "�@ү���ގ擾����               (�����)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ү���ގ擾����(�����)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub GetLogMessage()

        Dim strSQL As String                'SQL��
        Dim objRow As DataRow               '1ں��ޕ����ް�
        Dim objDataSet As New DataSet       '�ް����
        Dim strDataSetName As String        '�ް���Ė�
        Dim udtRet As RetCode


        '****************************************************************
        ' ���m�F�̍ŐV۸�ү���ނ��擾
        '       �yTLOG_MESSAGE�z
        '       �yTMST_MESSAGE�z
        '       �yTDSP_TERM_MSG�z
        '****************************************************************
        Dim strMSG_ID As String = ""        'ү����۸�. ү����ID
        Dim intMSG_LEVEL As Integer         'ү����Ͻ�. ү��������
        Dim strMSG_NAIYOU As String = ""    'ү����Ͻ�. ү���ޓ��e

        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TLOG_MESSAGE.FLOG_CHECK_FLAG FLOG_CHECK_FLAG "      'ү����۸�. �m�F�ς��׸�
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FHASSEI_DT FHASSEI_DT "                'ү����۸�. ��������
        strSQL &= vbCrLf & "  , TMST_MESSAGE.FMSG_NAIYOU FMSG_NAIYOU "              'ү����Ͻ�. ү����Ͻ�. ����
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM1 FMSG_PRM1 "                  'ү����۸�. ���Ұ�1
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM2 FMSG_PRM2 "                  'ү����۸�. ���Ұ�2
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM3 FMSG_PRM3 "                  'ү����۸�. ���Ұ�3
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM4 FMSG_PRM4 "                  'ү����۸�. ���Ұ�4
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM5 FMSG_PRM5 "                  'ү����۸�. ���Ұ�5
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FLOG_NO FLOG_NO "                      'ү����۸�. ۸�No
        strSQL &= vbCrLf & "  , TMST_MESSAGE.FMSG_LEVEL FMSG_LEVEL "                'ү����Ͻ�. ү��������
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_ID FMSG_ID "                      'ү����۸�.ү����ID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TLOG_MESSAGE TLOG_MESSAGE LEFT OUTER JOIN"          'ү����۸�     (�O������)
        strSQL &= vbCrLf & "    TMST_MESSAGE TMST_MESSAGE ON "                      'ү����Ͻ�     (�O������)
        strSQL &= vbCrLf & "       TLOG_MESSAGE.FMSG_ID = TMST_MESSAGE.FMSG_ID "    'ү����۸ނ�ү����Ͻ����O������
        strSQL &= vbCrLf & "  , TDSP_TERM_MSG "                                     '�[����ү���ޏo��Ͻ�
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        TLOG_MESSAGE.FLOG_CHECK_FLAG = " & TO_STRING(FLAG_OFF)              '�m�F�ς��׸�
        strSQL &= vbCrLf & "    AND TMST_MESSAGE.FMSG_LEVEL >= " & TO_STRING(gcintDisp_INTMSG_LEVEL)    'ү��������
        strSQL &= vbCrLf & "    AND TMST_MESSAGE.FMSG_ID = TDSP_TERM_MSG.FMSG_ID"                       '����
        strSQL &= vbCrLf & "    AND (TDSP_TERM_MSG.FTERM_ID = '" & gcstrFTERM_ID & "'"                  '�[��ID
        strSQL &= vbCrLf & "     OR  TDSP_TERM_MSG.FTERM_ID = '" & FTERM_ID_SKOTEI & "')"
        strSQL &= vbCrLf & "    AND TDSP_TERM_MSG.FMSG_OUT_FLAG = " & FLAG_ON                           'ү���ޏo�͗L��
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    TMST_MESSAGE.FMSG_LEVEL DESC"          'ү����Ͻ�. ү��������   (�~��)
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FLOG_NO DESC"             'ү����۸�. ۸�No        (�~��)
        strSQL &= vbCrLf

        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TLOG_MESSAGE"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            strMSG_ID = TO_STRING(objRow("FMSG_ID"))            'ү����۸�. ү����ID
            intMSG_LEVEL = TO_NUMBER(objRow("FMSG_LEVEL"))      'ү����Ͻ�. ү��������
            strMSG_NAIYOU = TO_STRING(objRow("FMSG_NAIYOU"))    'ү����Ͻ�. ү���ޓ��e

            udtRet = RetCode.OK
        Else
            udtRet = RetCode.NotFound
        End If


        '****************************************************************
        ' ��ʂɕ\��
        '****************************************************************
        If udtRet = RetCode.NotFound Then
            '======================================
            ' ���m�Fү���ނ����݂��Ȃ���
            '======================================
            tmrBlink.Enabled = False                    '�_�łȂ�
            '������������************************************************************************************************************
            'SystemMate:A.Noto 2012/09/19 �ż������ݕ\���ύX
            'Me.cmdMsgChk.ForeColor = Color.DarkGray     '�_�łȂ�
            cmdMsgChk.BackgroundImage = Nothing
            '������������************************************************************************************************************

        ElseIf udtRet = RetCode.OK Then
            '======================================
            ' ���m�Fү���ނ����݂��鎞
            '======================================
            Dim objTTMST_MESSAGE As TBL_TMST_MESSAGE
            objTTMST_MESSAGE = New TBL_TMST_MESSAGE(gobjOwner, gobjDb, Nothing)

            objTTMST_MESSAGE.FMSG_ID = strMSG_ID         'ү����ID   ���
            objTTMST_MESSAGE.GET_TMST_MESSAGE(False)     '���擾

            '���ݓ_�ŐF�w��
            Select Case intMSG_LEVEL
                Case 1
                    mobjMsgColor = mobjMsgColorLevel01
                Case 2
                    mobjMsgColor = mobjMsgColorLevel02
                Case 3
                    mobjMsgColor = mobjMsgColorLevel03
                Case Else
                    mobjMsgColor = mobjMsgColorLevel01
            End Select

            tmrBlink.Enabled = True                     '�_��

        End If

    End Sub
#End Region
#Region "�@���ݓ_�ŏ���                 (�����)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ݓ_�ŏ���(�����)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Blink_Proc()

        '������������************************************************************************************************************
        'SystemMate:A.Noto 2012/09/19 �ż������ݕ\���ύX
        If cmdMsgChk.Enabled = True Then
            If mintBlink = 0 Then
                '----------------------------------------------
                ' �\���@�o
                '----------------------------------------------
                cmdMsgChk.BackgroundImageLayout = ImageLayout.Center
                cmdMsgChk.BackgroundImage = System.Drawing.Image.FromFile("..\JPEG\warning.gif")
                mintBlink = 1
            ElseIf mintBlink = 1 Then
                '----------------------------------------------
                ' �\���@��
                '----------------------------------------------
                cmdMsgChk.BackgroundImage = Nothing
                mintBlink = 0
            End If
        End If


        'If mintBlink = 0 Then
        '    '----------------------------------------------
        '    ' �ԐF�\��
        '    '----------------------------------------------
        '    Me.cmdMsgChk.ForeColor = mobjMsgColor
        '    mintBlink = 1

        'ElseIf mintBlink = 1 Then
        '    '----------------------------------------------
        '    ' �D�F�\���i�����j
        '    '----------------------------------------------
        '    Me.cmdMsgChk.ForeColor = mobjMsgColorLevel00
        '    mintBlink = 0

        'End If
        '������������************************************************************************************************************


    End Sub
#End Region
#Region "  �����\������                 (�����)"
    ''' <summary>
    ''' �����\������(�����)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Set_Time()

        Me.lblTime.Text = Format(Now, GAMEN_DATE_FORMAT_01)

    End Sub
#End Region
#Region "  ۺ�����                      ��������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۺ����݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub F11Process()

        '*****************************************
        ' �ذ��ʕ\������
        '*****************************************
        'Call ShowfrmTree()

    End Sub
#End Region
#Region "�@�ż��������                  ��������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ż�������� ��������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub btnMsgChkProc()
        '*************************************************
        'ү���ޏ�����
        '*************************************************
        tmrOpeMsg.Enabled = False               '�擾�p�p��ϰ�J�n
        '������������************************************************************************************************************
        'SystemMate:A.Noto 2012/09/19 �ż������ݕ\���ύX
        'cmdMsgChk.ForeColor = Color.DarkGray    '���ڰ���ү���ޏ�����
        cmdMsgChk.BackgroundImage = Nothing
        '������������************************************************************************************************************

        '*************************************************
        '̫�т̑J��
        '*************************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_209000, Me)


        '*************************************************
        '���ڰ���ү���ގ擾
        '*************************************************
        tmrOpeMsg.Enabled = True       '�擾�p�p��ϰ�J�n
        Call GetLogMessage()


    End Sub
#End Region
#Region "�@��������                     ��������"
    Protected Sub btnAFKProc()

        '***************************************************************
        '���ȏ���
        '***************************************************************
        Call gobjComFuncFRM.AfkProc(Me)

    End Sub
#End Region
#Region "  ̧ݸ��ݷ�                    ��������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̧ݸ��ݷ�                    ��������
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub KeyDownProc(ByVal e As System.Windows.Forms.KeyEventArgs)

        '**************************************************
        'Alt �����������ꂽ�����f
        '**************************************************
        If e.Alt = True Then Exit Sub
        If e.Shift = True Then Exit Sub
        If e.Control = True Then Exit Sub


        '������������************************************************************************************************************
        'SystemMate:A.Noto 2012/09/13 ̧ݸ��ݷ��𖳌��ɂ��� 

        '������������************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/29 ��ޏo�ɓo�^ ̧ݸ��ݷ��̖�����
        ' '' ''������������************************************************************************************************************
        ' '' ''JobMate:H.Okumura 2013/04/17 ����̉�ʂ̂Ƃ�̧ݸ��ݷ���L���ɂ��� 
        '' ''Select Case Me.Name
        '' ''    Case FDISP_ID_JFRM_310030
        '' ''        '(��ޏo�ɓo�^�̂Ƃ�)

        '' ''        ''**************************************************
        '' ''        ''�������ꂽ���ް�ޔ��f
        '' ''        ''**************************************************
        '' ''        Select Case e.KeyCode
        '' ''            Case Windows.Forms.Keys.F1
        '' ''                If cmdF1.Enabled = True And _
        '' ''                   mblnFKey(cmd.F1) = True Then
        '' ''                    Call cmdF1_Click(Nothing, Nothing)
        '' ''                End If

        '' ''            Case Windows.Forms.Keys.F2
        '' ''                If cmdF2.Enabled = True And _
        '' ''                   mblnFKey(cmd.F2) = True Then
        '' ''                    Call cmdF2_Click(Nothing, Nothing)
        '' ''                End If
        '' ''        End Select

        '' ''    Case FDISP_ID_JFRM_310040
        '' ''        '(��ޏo�ɓo�^(D45)�̂Ƃ�)

        '' ''        ''**************************************************
        '' ''        ''�������ꂽ���ް�ޔ��f
        '' ''        ''**************************************************
        '' ''        Select Case e.KeyCode
        '' ''            Case Windows.Forms.Keys.F1
        '' ''                If cmdF1.Enabled = True And _
        '' ''                   mblnFKey(cmd.F1) = True Then
        '' ''                    Call cmdF1_Click(Nothing, Nothing)
        '' ''                End If

        '' ''            Case Windows.Forms.Keys.F2
        '' ''                If cmdF2.Enabled = True And _
        '' ''                   mblnFKey(cmd.F2) = True Then
        '' ''                    Call cmdF2_Click(Nothing, Nothing)
        '' ''                End If
        '' ''        End Select

        '' ''    Case Else

        '' ''End Select
        'JobMate:S.Ouchi 2013/10/29 ��ޏo�ɓo�^ ̧ݸ��ݷ��̖�����
        '������������************************************************************************************************************


        ' ''**************************************************
        ' ''�������ꂽ���ް�ޔ��f
        ' ''**************************************************
        'Select e.KeyCode
        '    Case Windows.Forms.Keys.F1
        '        If cmdF1.Enabled = True And _
        '           mblnFKey(cmd.F1) = True Then
        '            Call cmdF1_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F2
        '        If cmdF2.Enabled = True And _
        '           mblnFKey(cmd.F2) = True Then
        '            Call cmdF2_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F3
        '        If cmdF3.Enabled = True And _
        '           mblnFKey(cmd.F3) = True Then
        '            Call cmdF3_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F4
        '        If cmdF4.Enabled = True And _
        '           mblnFKey(cmd.F4) = True Then
        '            Call cmdF4_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F5
        '        If cmdF5.Enabled = True And _
        '           mblnFKey(cmd.F5) = True Then
        '            Call cmdF5_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F6
        '        If cmdF6.Enabled = True And _
        '           mblnFKey(cmd.F6) = True Then
        '            Call cmdF6_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F7
        '        If cmdF7.Enabled = True And _
        '           mblnFKey(cmd.F7) = True Then
        '            Call cmdF7_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F8
        '        If cmdF8.Enabled = True And _
        '           mblnFKey(cmd.F8) = True Then
        '            Call cmdF8_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F10
        '        If mblnFKey(cmd.F10) = True Then
        '            Call btnMsgChkProc()
        '        End If

        '    Case Windows.Forms.Keys.F11
        '        If mblnFKey(cmd.F11) = True Then
        '            Call F11Process()
        '        End If

        'End Select
        '������������************************************************************************************************************

    End Sub
#End Region
#Region "  ����ā@�@�@�@�@�@�@�@                "
#Region "  Visible          �ύX"
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  Visible �ύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmTemplate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        Try
            '***********************************************************
            '����������
            '***********************************************************
            If Me.Visible = False Then Exit Sub


            '***********************************************************
            '��ʏ������i�S��ʋ��ʏ����j
            '***********************************************************
            Call Initialize_Template()


            '***********************************************************
            '��ʏ������i�e��ʏ����j
            '***********************************************************
            Call InitializeChild()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  Menu01  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu01  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd01.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
            '' ''Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_202000, Me)
            Me.cmsMenu01.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu01.Show(Me, cmsMenu01.Location)
            'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
            '������������************************************************************************************************************

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd02.Click
        Try
            Me.cmsMenu02.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu02.Show(Me, cmsMenu02.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd03.Click
        Try
            Me.cmsMenu03.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu03.Show(Me, cmsMenu03.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd04.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd05.Click
        Try

            '������������************************************************************************************************************
            'JobMate:A.Noto 2012/12/04 �I�����ƭ��ǉ�
            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305010, Me)

            Me.cmsMenu05.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu05.Show(Me, cmsMenu05.Location)
            '������������************************************************************************************************************

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd06.Click
        Try
            Me.cmsMenu06.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu06.Show(Me, cmsMenu06.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu07  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu07  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd07.Click
        Try

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd08.Click
        Try
            Me.cmsMenu08.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu08.Show(Me, cmsMenu08.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd09.Click
        Try
            Me.cmsMenu09.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu09.Show(Me, cmsMenu09.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10  ����     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd10.Click
        Try
            '������������************************************************************************************************************
            'JobMate:H.Okumura 2013/04/05 �ƭ�����ʊO�œW�J����Ȃ��悤�C��
            If (sender.Location.Y + cmsMenu10.Height) > Me.Height Then
                Me.cmsMenu10.Location = New Point(sender.Location.X + sender.Size.Width, (Me.Height - cmsMenu10.Height - 1))
            Else
                Me.cmsMenu10.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            End If

            'Me.cmsMenu10.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu10.Show(Me, cmsMenu10.Location)
            '������������************************************************************************************************************
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
#Region "  Menu01_01        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu01_01     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu01_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu01_01.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_202000, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu01_02        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu01_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu01_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu01_02.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_302010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
    '������������************************************************************************************************************

#Region "  Menu02_01        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_01     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu02_01.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_02        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu02_02.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_03        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_03     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu02_03.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_04        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_04     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu02_04.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_05        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_05     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_06        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_06     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_07        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_07     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308110, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_08        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_08     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308100, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_01        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_01     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_01.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_02        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_02.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_03        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_03     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_03.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_04        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_04     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_05        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_05     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_05.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310050, Me)


        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_06        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_06     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_06.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303060, Me)

            '������������************************************************************************************************************
            'JobMate:IKEDA 2017/07/06 ���Y���ɓo�^(BCR)�Ή� ������������
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307140, Me)
            'JobMate:IKEDA 2017/07/06 ���Y���ɓo�^(BCR)�Ή� ������������
            '������������************************************************************************************************************

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_07        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_07     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_07        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_07     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_01        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_01     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_02        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_03        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_03     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_04        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_04     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_05        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_05     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_06        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_06     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_07        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_07     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_08        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_08     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_09        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_09     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308120, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_01        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_01     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_01.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_02        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_02.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311015, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_03        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_03     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_03.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_04        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_04     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_04.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_05        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_05     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_05.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_06        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_06     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_06.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_07        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_07     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_07.Click
        Try

            '������������************************************************************************************************************
            'JobMate:H.Okumura 2013/07/25 �ް�������̂ݑJ�ڂł͂Ȃ��V�K�\��

            gobjFRM_311090 = New FRM_311090
            gobjFRM_311090.ShowDialog()            '�W�J

            ' '' ''******************************************
            ' '' '' ��ʑJ��
            ' '' ''******************************************
            ' ''Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311090, Me)
            '������������************************************************************************************************************

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_08        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_08     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_08.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_09        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_09     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_09.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  Menu06_01        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_01     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_01.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_02        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_02.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_03        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_03     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_03.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_04        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_04     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_04.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_05        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_05     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_05.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_06        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_06     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_06.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    '������������************************************************************************************************************
    'JobMate:N.Nakada 2013/11/01 �I�����X�g
#Region "  Menu06_07        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_07     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_07.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    '������������************************************************************************************************************

#Region "  Menu08_01        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_01     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_01.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_02        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_02.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_03        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_03     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_03.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_04        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_04     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_04.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_05        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_05     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_05.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_06        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_06     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_06.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_07        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_07     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_07.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_01        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_01     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_01.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_206010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_02        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_02.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_03        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_03     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_03.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_04        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_04     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_04.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_05        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_05     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_05.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_06        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_06     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_06.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_07        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_07     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_07.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
#Region "  Menu09_08        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_08     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_08.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_09        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_09     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_09.Click
        Try

            ''******************************************
            '' ��ʑJ��
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306090, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
    '������������************************************************************************************************************

#Region "  Menu10_01        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_01     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_01.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_02        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_02.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_03        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_02     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_03.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_04        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_04     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_04.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_05        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_05     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_05.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_06        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_06     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_06.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_07        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_07     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_07.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_08        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_08     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_08.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_09        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_09     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_09.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307090, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_10        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_10     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_10.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307100, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_11        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_11     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_11.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307120, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_12        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_12     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_12.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307110, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_13        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_13     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_13.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307130, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    '������������************************************************************************************************************
    'JobMate:IKEDA 2017/07/06 PLC�����e�i���X(BCR)�Ή� ������������
#Region "  Menu10_14        �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_14     �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_14.Click
        Try

            '******************************************
            ' ��ʑJ��
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307150, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    'JobMate:IKEDA 2017/07/06 PLC�����e�i���X(BCR)�Ή� ������������
    '������������************************************************************************************************************
#Region "  F1  ����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF1.Click
        Try
            lblErrMsg.Text = ""


            '********************************************
            '�߽ܰ������
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF1.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '�������s
            '********************************************
            Call F1Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F2  ����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF2.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            '�߽ܰ������
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF2.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '�������s
            '********************************************
            Call F2Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F3  ����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF3.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            '�߽ܰ������
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF3.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '�������s
            '********************************************
            Call F3Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F4  ����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF4.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            '�߽ܰ������
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF4.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '�������s
            '********************************************
            Call F4Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F5  ����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF5.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            '�߽ܰ������
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF5.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '�������s
            '********************************************
            Call F5Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F6  ����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF6.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            '�߽ܰ������
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF6.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '�������s
            '********************************************
            Call F6Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F7  ����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F7  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF7.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            '�߽ܰ������
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF7.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '�������s
            '********************************************
            Call F7Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F8  ����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8  ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF8.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            '�߽ܰ������
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF8.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '�������s
            '********************************************
            Call F8Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region " �u�ż�����v����   �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �u�ż�����v����   �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub btnMsgChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMsgChk.Click
        Try

            btnMsgChkProc()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region " �u���ȁv����      �د�"
    Private Sub btnAFK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFK.Click
        Try

            btnAFKProc()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region " �u۸޵́v����      �د�"
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Call cmdClose_ClickProccess()

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �����\��                 ��ϰ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����\�� ��ϰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTime.Tick
        Try
            tmrTime.Enabled = False

            Call Set_Time()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmrTime.Enabled = True

        End Try
    End Sub
#End Region
#Region "  ���ݓ_�ŗp               ��ϰ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ݓ_�ŗp ��ϰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlink.Tick
        Try

            Call Blink_Proc()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ���ڰ���ү���ގ擾       ��ϰ"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub tmrOpeMsg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrOpeMsg.Tick
        Try
            tmrOpeMsg.Enabled = False

            Call GetLogMessage()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmrOpeMsg.Enabled = True

        End Try
    End Sub
#End Region
#Region "  ��ʑJ��ý�              ��ϰ"
    Private Sub tmrTest_1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTest_1.Tick
        Try

            Call FormMoveTest()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "�@���ް�މ���              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ް�މ���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmTemplate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try

            Call KeyDownProc(e)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ̫�Ѹ۰��        �����"
    Private Sub FRM_000002_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            '****************************************
            '�۰�ދ����׸� = ON
            '****************************************
            If FLAG_ON = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_001) Then
                mblnClose = True
            End If


            '****************************************
            '�۰�ޏ���
            '****************************************
            If mblnClose = False Then
                '=================================
                '�۰�ނ��Ȃ�
                '=================================
                e.Cancel = True

            Else
                '=================================
                '�۰�ޏ���
                '=================================
                Call MeClose()


            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ۹������ݼ�      �����"
    Private Sub FRM_000002_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        Try

            '*************************************************
            ' �F�X���f
            '*************************************************
            If Me.Name = "FRM_000002" Then Exit Sub


            '*************************************************
            ' ۹���݋L��
            '*************************************************
            Dim intX = Me.Location.X                '�\���ʒuX
            Dim intY = Me.Location.Y                '�\���ʒuY
            If 1 <= intX And 1 <= intX Then
                gobjLocation = Nothing                  '�\���ʒu������
                gobjLocation = New Point(intX, intY)    '�\���ʒu�L��
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  �ݽ�׸�                              "
    Public Sub New()

        '************************************************************************************************************************
        ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        '************************************************************************************************************************
        ' InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B
        '************************************************************************************************************************


        Try

            '***********************************************************
            ' ��ʈʒu�ݒ�
            '***********************************************************
            Me.Location = gobjLocation                  '��ʈʒu


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �ذ���                      �\������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ذ��� �\������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ShowfrmTree()
        '****************************************************
        ' �ذ�\��
        '****************************************************
        If IsNull(gobjFRM_100002) = False Then
            gobjFRM_100002.Close()
            gobjFRM_100002.Dispose()
            gobjFRM_100002 = Nothing
        End If
        gobjFRM_100002 = New FRM_100002
        gobjFRM_100002.NowDispID = Me.Name                                             '���ID         ���
        gobjFRM_100002.Location = New Point(Me.Location.X + 3, Me.Location.Y + 50)     '۹����         ���
        gobjFRM_100002.ShowDialog()                                                    '�\��

        '----------------------------------
        ' �u�߂�v���ݸد����ꂽ��
        '----------------------------------
        If gobjFRM_100002.CANCEL = True Then

            '�������Ȃ�

        Else

            '****************************************************
            ' ��ʑJ��
            '****************************************************
            Call gobjComFuncFRM.FormMoveSelect(gobjFRM_100002.NextDISP_ID, Me)

        End If

        '�ذ��޼ު�č폜
        gobjFRM_100002.Close()
        gobjFRM_100002.Dispose()
        gobjFRM_100002 = Nothing

    End Sub
#End Region

    '************************************************************************************************************************
    '************************************************************************************************************************
    '
    '̫�їp���ʊ֐�
    '
    '************************************************************************************************************************
    '************************************************************************************************************************
#Region "  �װ����                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub ComError(ByVal ex As Exception)
        Try

            gobjComFuncFRM.ComError_frm(ex, lblErrMsg)

        Catch ex2 As Exception
            MsgBox("ComError�֐��Ŵװ����")

        End Try
    End Sub
#End Region
#Region "  ����         ��Enabled�AText "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���݂́uEnabled�v�A�uText�v��ύX����
    ''' </summary>
    ''' <param name="cmdButton">�ύX�������ݵ�޼ު��</param>
    ''' <param name="blnEnabled">���݂́uEnabled�v�̐ݒ�</param>
    ''' <param name="strText">���݂́uText�v�̐ݒ�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub CmdEnabledChange(ByVal cmdButton As System.Windows.Forms.Button, _
                                   Optional ByVal blnEnabled As Boolean = False, _
                                   Optional ByVal strText As String = Nothing)
        Dim intRet As RetCode                   '�߂�l
        Dim blnResult As Boolean


        '**********************************************************
        ' ����Ͻ�
        '**********************************************************
        '==================================
        '�y�[���ʋ���Ͻ��z
        '==================================
        Dim intFOPE_FLAG_Term As Integer = 0        '�����׸�(�[���ʋ���Ͻ��p)
        Dim objTDSP_PMT_TERM As New TBL_TDSP_PMT_TERM(gobjOwner, gobjDb, Nothing)
        objTDSP_PMT_TERM.FTERM_KUBUN = gcintFTERM_KBN               '�[���敪   ���
        objTDSP_PMT_TERM.FDISP_ID = Me.Name                         '���ID     ���
        objTDSP_PMT_TERM.FCTRL_ID = cmdButton.Name                  '���۰�ID   ���
        intRet = objTDSP_PMT_TERM.GET_TDSP_PMT_TERM(False)          '���擾
        If intRet = RetCode.OK Then
            intFOPE_FLAG_Term = objTDSP_PMT_TERM.FOPE_FLAG
        Else
            intFOPE_FLAG_Term = gcintOPE_FLG
        End If

        '==================================
        '�yհ�ޕʋ���Ͻ��z
        '==================================
        Dim intFOPE_FLAG_User As Integer = 0        '�����׸�(հ�ޕʋ���Ͻ��p)
        For jj As Integer = LBound(gcintFUSER_LEVEL) To UBound(gcintFUSER_LEVEL)
            '(ٰ��:�^����ꂽհ�����ِ�)

            Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)
            objTDSP_PMT_USER.FUSER_DSP_LEVEL = gcintFUSER_LEVEL(jj)     'հ�ް��������
            objTDSP_PMT_USER.FDISP_ID = Me.Name                         '���ID
            objTDSP_PMT_USER.FCTRL_ID = cmdButton.Name                  '���۰�ID
            intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)          '�擾
            If intRet = RetCode.OK Then
                intFOPE_FLAG_User = objTDSP_PMT_USER.FOPE_FLAG
            Else
                intFOPE_FLAG_User = gcintOPE_FLG
            End If
            If intFOPE_FLAG_User = FOPE_FLAG_SON Then Exit For

        Next

        '==================================
        '����Ͻ�
        '==================================
        If intFOPE_FLAG_Term = FOPE_FLAG_SON And intFOPE_FLAG_User = FOPE_FLAG_SON And blnEnabled = True Then
            blnResult = True
        Else
            blnResult = False
        End If


        '**********************************************
        '̧ݸ��ݷ���Enabled
        '**********************************************
        Select Case cmdButton.Name
            Case Me.cmdF1.Name
                mblnFKey(cmd.F1) = blnResult
            Case Me.cmdF2.Name
                mblnFKey(cmd.F2) = blnResult
            Case Me.cmdF3.Name
                mblnFKey(cmd.F3) = blnResult
            Case Me.cmdF4.Name
                mblnFKey(cmd.F4) = blnResult
            Case Me.cmdF5.Name
                mblnFKey(cmd.F5) = blnResult
            Case Me.cmdF6.Name
                mblnFKey(cmd.F6) = blnResult
            Case Me.cmdF7.Name
                mblnFKey(cmd.F7) = blnResult
            Case Me.cmdF8.Name
                mblnFKey(cmd.F8) = blnResult
            Case Me.cmdMsgChk.Name
                mblnFKey(cmd.F10) = blnResult
        End Select


        '**********************************************
        '���۰����݂�Enabled
        '**********************************************
        cmdButton.Enabled = blnResult                   '���۰�����         ��Enabled
        If Not IsNull(strText) Then
            cmdButton.Text = strText                    '���۰�����         ��Text
        End If


    End Sub
#End Region
#Region "  Menu���ݑS��Enabled False "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu���ݑS��Enabled False�ɂ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub CmdEnabledChangeMenu()
 
        Call CmdEnabledChange(cmd01, False)         'Menu01����
        Call CmdEnabledChange(cmd02, False)         'Menu02����
        Call CmdEnabledChange(cmd03, False)         'Menu03����
        Call CmdEnabledChange(cmd04, False)         'Menu04����
        Call CmdEnabledChange(cmd05, False)         'Menu05����
        Call CmdEnabledChange(cmd06, False)         'Menu06����
        Call CmdEnabledChange(cmd07, False)         'Menu07����
        Call CmdEnabledChange(cmd08, False)         'Menu08����
        Call CmdEnabledChange(cmd09, False)         'Menu09����
        Call CmdEnabledChange(cmd10, False)         'Menu10����

    End Sub
#End Region
#Region "  ����         ��Enabled�AText "

    '*******************************************************************************************************************
    ''' <summary>
    ''' ���݂́uEnabled�v�A�uText�v��ύX����
    ''' </summary>
    ''' <param name="cmdButton">�ύX�������ݵ�޼ު��</param>
    ''' <param name="strDisp_ID">��ʖ�</param>
    ''' <param name="blnEnabled">���݂́uEnabled�v�̐ݒ�</param>
    ''' <remarks>����blnEnabled��true�̏ꍇ�ADB��False��������\�����Ȃ�����blnEnabled��False�̏ꍇ�ADB��true��������\�����Ȃ�</remarks>
    ''' *******************************************************************************************************************
    Protected Sub CmdEnabledChangeButton(ByVal cmdButton As System.Windows.Forms.Button, _
                                         ByVal strDisp_ID As String, _
                                         ByVal blnEnabled As Boolean _
                                         )
        Dim intRet As RetCode                   '�߂�l
        Dim blnResult As Boolean
        Dim strText As String



        '**********************************************************
        ' ���ݖ��擾
        '   �y��ʕ\��Ͻ��z
        '**********************************************************
        Dim objDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)
        objDSP_NAME.FDISP_ID = strDisp_ID               '���ID     ���
        objDSP_NAME.FCTRL_ID = cmdButton.Name           '���۰�ID   ���
        intRet = objDSP_NAME.GET_TDSP_NAME(False)       '���擾
        If intRet <> RetCode.OK Then
            'Call DisplayPopup(FRM_MSG_gobjComFuncFRM.ButtonTextSet_01, _
            '                  PopupFormType.Ok, _
            '                  PopupIconType.Err, _
            '                  "ID�@�F" & objDSP_NAME.FDISP_ID)
            Exit Sub
        End If
        strText = gobjComFuncFRM.StrIsChanged(objDSP_NAME.FOBJECT_NAME)        '���ݖ�


        '**********************************************************
        ' ����Ͻ�
        '**********************************************************
        '==================================
        '�y�[���ʋ���Ͻ��z
        '==================================
        Dim intFOPE_FLAG_Term As Integer = 0        '�����׸�(�[���ʋ���Ͻ��p)
        Dim objTDSP_PMT_TERM As New TBL_TDSP_PMT_TERM(gobjOwner, gobjDb, Nothing)
        objTDSP_PMT_TERM.FTERM_KUBUN = gcintFTERM_KBN               '�[���敪   ���
        objTDSP_PMT_TERM.FDISP_ID = Me.Name                         '���ID     ���
        objTDSP_PMT_TERM.FCTRL_ID = cmdButton.Name                  '���۰�ID   ���
        intRet = objTDSP_PMT_TERM.GET_TDSP_PMT_TERM(False)          '���擾
        If intRet = RetCode.OK Then
            intFOPE_FLAG_Term = objTDSP_PMT_TERM.FOPE_FLAG
        Else
            intFOPE_FLAG_Term = gcintOPE_FLG
        End If

        '==================================
        '�yհ�ޕʋ���Ͻ��z
        '==================================
        Dim intFOPE_FLAG_User As Integer = 0        '�����׸�(հ�ޕʋ���Ͻ��p)
        For jj As Integer = LBound(gcintFUSER_LEVEL) To UBound(gcintFUSER_LEVEL)
            '(ٰ��:�^����ꂽհ�����ِ�)

            Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)
            objTDSP_PMT_USER.FUSER_DSP_LEVEL = gcintFUSER_LEVEL(jj)     'հ�ް��������
            objTDSP_PMT_USER.FDISP_ID = Me.Name                         '���ID
            objTDSP_PMT_USER.FCTRL_ID = cmdButton.Name                  '���۰�ID
            intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)          '�擾
            If intRet = RetCode.OK Then
                intFOPE_FLAG_User = objTDSP_PMT_USER.FOPE_FLAG
            Else
                intFOPE_FLAG_User = gcintOPE_FLG
            End If
            If intFOPE_FLAG_User = FOPE_FLAG_SON Then Exit For

        Next

        '==================================
        '����Ͻ�
        '==================================
        If intFOPE_FLAG_Term = FOPE_FLAG_SON And intFOPE_FLAG_User = FOPE_FLAG_SON And blnEnabled = True Then
            blnResult = True
        Else
            blnResult = False
        End If


        '**********************************************
        '̧ݸ��ݷ���Enabled
        '**********************************************
        Select Case cmdButton.Name
            Case Me.cmdF1.Name
                mblnFKey(cmd.F1) = blnResult
            Case Me.cmdF2.Name
                mblnFKey(cmd.F2) = blnResult
            Case Me.cmdF3.Name
                mblnFKey(cmd.F3) = blnResult
            Case Me.cmdF4.Name
                mblnFKey(cmd.F4) = blnResult
            Case Me.cmdF5.Name
                mblnFKey(cmd.F5) = blnResult
            Case Me.cmdF6.Name
                mblnFKey(cmd.F6) = blnResult
            Case Me.cmdF7.Name
                mblnFKey(cmd.F7) = blnResult
            Case Me.cmdF8.Name
                mblnFKey(cmd.F8) = blnResult
            Case Me.cmdMsgChk.Name
                mblnFKey(cmd.F10) = blnResult
        End Select


        '**********************************************
        '���۰����݂�Visible
        '**********************************************
        cmdButton.Visible = blnResult                       '���۰�����         ��Visible
        If Not IsNull(strText) Then
            cmdButton.Text = strText                        '���۰�����         ��Text
        End If


    End Sub
#End Region
#Region "  ���g����ݏ���                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���g����ݏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeShow()


        '*************************************************
        ' ��ϰ�L��
        '*************************************************
        tmrTime.Enabled = True
        tmrOpeMsg.Enabled = True
        tmrTest_1.Enabled = True

        '*************************************************
        ' ������
        '*************************************************
        Me.Visible = True


    End Sub
#End Region
#Region "  ���g�۰�ޏ���                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���g�۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeClose()


        '*************************************************
        ' ��ϰ����
        '*************************************************
        tmrTime.Enabled = False
        tmrOpeMsg.Enabled = False
        tmrBlink.Enabled = False
        tmrTest_1.Enabled = False


        '*************************************************
        ' �e��ʸ۰�ޏ���
        '*************************************************
        Call CloseChild()


    End Sub
#End Region
#Region "  �����޳�  ���݉��������@             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����޳�  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProccess()

        Dim udeRet As RetPopup

        '*******************************************************
        '�m�Fү����
        '*******************************************************
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_SHUTDOWN, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*******************************************************
        '���đ��M����
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200004           '̫�ϯĖ����
        Call gobjComFuncFRM.SockSendServer01(objTelegram)                                  '���đ��M


        If gcintDSPLOGIN_FLG = FLAG_OFF Then
            '(۸޲݉�ʕs�v�̏ꍇ)
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
                Me.Close()
                Me.Dispose()
            End If


        Else
            '(۸޲݉�ʗv�̏ꍇ)
            '*******************************************************
            '�����޳�or��ʸ۰�ޏ���
            '*******************************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_100001, Me)

        End If

    End Sub
#End Region

    '**********************************************************************************************
    '������FlexGrid��DataGridView�ڍs

#Region "  ��د�ޕ\������1                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\������1
    ''' </summary>
    ''' <param name="objGrid"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub grdListDisplaySub(ByRef objGrid As GamenCommon.cmpMDataGrid)

        Call grdListDisplayChild()

    End Sub
#End Region
#Region "  ��د�ޕ\������2                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\������2
    ''' </summary>
    ''' <param name="objGrid"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub grdListDisplaySub2(ByRef objGrid As GamenCommon.cmpMDataGrid)

        Call grdListDisplayChild2()

    End Sub
#End Region
#Region "  ��د�ޕ\������3                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\������3
    ''' </summary>
    ''' <param name="objGrid"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub grdListDisplaySub3(ByRef objGrid As GamenCommon.cmpMDataGrid)

        Call grdListDisplayChild3()

    End Sub
#End Region

    '������FlexGrid��DataGridView�ڍs
    '**********************************************************************************************
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
#Region "�@�J����°ٸد�                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �J����°ٸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDevelopment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDevelopment.Click
        Try
            Dim objFRM_299000 As FRM_299000
            objFRM_299000 = New FRM_299000
            objFRM_299000.Show()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region


End Class