'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���ђ萔����ݽ���
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_207061

#Region "  ���ʕϐ��@                           "
    '�����è
    Private mFHENSU_ID As String           '�ϐ�ID
    Private mFHENSU_NAME As String         '�ϐ����ږ���
    Private mFHENSU_FLAG As String         '�ϐ��敪
    Private mFHENSU_KIND As String         '�ް����
    Private mFHENSU_INT As String          '�����ް�
    Private mFHENSU_REAL As String         '�����ް�
    Private mFHENSU_CHAR As String         '�����ް�
    Private mFHENSU_DATE As Nullable(Of Date)           '�����ް�
    Private mobjOwner As FRM_207060      '��Ű̫��

#End Region
#Region "  �����è��`�@                        "
    Public Property userSTRHENSU_ID() As String
        Get
            Return mFHENSU_ID
        End Get
        Set(ByVal Value As String)
            mFHENSU_ID = Value
        End Set
    End Property
    Public Property userSTRHENSU_NAME() As String
        Get
            Return mFHENSU_NAME
        End Get
        Set(ByVal Value As String)
            mFHENSU_NAME = Value
        End Set
    End Property
    Public Property userINTHENSU_KBN() As String
        Get
            Return mFHENSU_FLAG
        End Get
        Set(ByVal Value As String)
            mFHENSU_FLAG = Value
        End Set
    End Property
    Public Property userINTHENSU_KIND() As String
        Get
            Return mFHENSU_KIND
        End Get
        Set(ByVal Value As String)
            mFHENSU_KIND = Value
        End Set
    End Property
    Public Property userINTHENSU_INT() As String
        Get
            Return mFHENSU_INT
        End Get
        Set(ByVal Value As String)
            mFHENSU_INT = Value
        End Set
    End Property
    Public Property userINTHENSU_REAL() As String
        Get
            Return mFHENSU_REAL
        End Get
        Set(ByVal Value As String)
            mFHENSU_REAL = Value
        End Set
    End Property
    Public Property userSTRHENSU_CHAR() As String
        Get
            Return mFHENSU_CHAR
        End Get
        Set(ByVal Value As String)
            mFHENSU_CHAR = Value
        End Set
    End Property
    Public Property userDTMHENSU_DATE() As Nullable(Of Date)
        Get
            Return mFHENSU_DATE
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFHENSU_DATE = Value
        End Set
    End Property
    Public Property userOWNER() As FRM_207060
        Get
            Return mobjOwner
        End Get
        Set(ByVal Value As FRM_207060)
            mobjOwner = Value
        End Set
    End Property
#End Region
#Region "�@̫�ѱ�è��                           "
    '*******************************************************************************************************************
    '�y�@�\�z̫�ѱ�è�ގ������
    '�y�����z
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub FRM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          '��̫��̫����̖�����

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#Region "  ̫��۰�ޏ����@                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_207061_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '-------------------------------------
        ' �ް��^�ڸ�
        '-------------------------------------
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboDataType, False, mFHENSU_KIND)            '�f�[�^�^


        '****************************************************
        ' ÷���ޯ�����          �i÷�āj
        '****************************************************

        '�萔ID
        If Not IsNull(mFHENSU_ID) Then
            txtTeisuID.Text = mFHENSU_ID
        End If

        '�萔���ږ���
        If Not IsNull(mFHENSU_NAME) Then
            txtTeisuName.Text = mFHENSU_NAME
        End If

        '�萔�����ް�
        If Not IsNull(mFHENSU_INT) Then
            txtDataSeisu.Text = mFHENSU_INT
        End If

        '�萔�����ް�
        If Not IsNull(mFHENSU_REAL) Then
            txtDataZissu.Text = mFHENSU_REAL
        End If

        '�萔�����ް�
        If Not IsNull(mFHENSU_CHAR) Then
            txtDataString.Text = TO_STRING(mFHENSU_CHAR)
        End If

        '�萔�����ް�
        If IsNull(mFHENSU_DATE) Then
            '(�ް����Ȃ��ꍇ)
            dtpDate.cmpMDateTimePicker_D.Value = Now
            dtpDate.cmpMDateTimePicker_T.Value = Now

        Else
            '(�ް�������ꍇ)
            dtpDate.cmpMDateTimePicker_D.Value = mFHENSU_DATE
            dtpDate.cmpMDateTimePicker_T.Value = mFHENSU_DATE

        End If


        '****************************************************
        ' ÷���ޯ�����          �iEnabled�AColor�j
        '****************************************************
        Select Case mFHENSU_KIND
            Case FHENSU_KIND_SINT
                txtDataSeisu.Enabled = True
                txtDataSeisu.BackColor = Color.White

            Case FHENSU_KIND_SREAL
                txtDataZissu.Enabled = True
                txtDataZissu.BackColor = Color.White

            Case FHENSU_KIND_SCHAR
                txtDataString.Enabled = True
                txtDataString.BackColor = Color.White

            Case FHENSU_KIND_SDATE
                dtpDate.Enabled = True

        End Select

    End Sub
#End Region
#Region "�@���s�@ �@ ���݉��������@             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���s   ��������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            '******************************************
            ' ���đ��M����
            '******************************************
            Call SendSocket01()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#Region "�@��ݾ�   �@���݉��������@             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ݾ� ��������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

#End Region
#Region "  ���đ��M                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���đ��M
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()


        '*******************************************************
        '�m�Fү����
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "�V�X�e���萔�@" & "�u" & cboDataType.Text & "�v" & "�@�f�[�^��" & vbCrLf
        strMessage &= "�ύX���������{���܂����H"
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        '���đ��M����
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200601    '̫�ϯĖ����

        objTelegram.SETIN_DATA("DSPHENSU_ID", txtTeisuID.Text)                                      '�萔ID
        Select Case TO_INTEGER(cboDataType.SelectedValue.ToString)
            Case FHENSU_KIND_SINT
                objTelegram.SETIN_DATA("DSPHENSU_DATA", txtDataSeisu.Text)                          '�萔�����ް�

            Case FHENSU_KIND_SREAL
                objTelegram.SETIN_DATA("DSPHENSU_DATA", txtDataZissu.Text)                          '�萔�����ް�

            Case FHENSU_KIND_SCHAR
                objTelegram.SETIN_DATA("DSPHENSU_DATA", txtDataString.Text)                         '�萔�����ް�

            Case FHENSU_KIND_SDATE
                objTelegram.SETIN_DATA("DSPHENSU_DATA", dtpDate.userDateTimeText)                   '�萔���t�ް�

        End Select

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    '���đ��M�߂�l
        Dim strErrMsg As String

        strErrMsg = FRM_MSG_FRM207061_01
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    '���đ��M
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(����I���̏ꍇ)
                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()
            End If
        End If


    End Sub

#End Region

    '**********************************************************************************************
    '���������ы���

    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class