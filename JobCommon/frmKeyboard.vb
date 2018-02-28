'*******************************************************************************
'���Y�Ǘ�����
'�@�\��     �F������ް���ް����͉��
'�t�@�C���� �FfrmKeyboard.vb
'�v���Z�X�� �F������ٍ�Ƒ���n��۾��E�Ǘ�����n��۾�
'*******************************************************************************


' �ȉ��̖��O��Ԃ��C���|�[�g����
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class frmKeyboard
    Inherits System.Windows.Forms.Form


#Region "  �����è        "

#Region "  ÷���ޯ��"

    ''' =======================================
    ''' <summary></summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userTextBoxValue() As String
        '�l���擾����
        Get
            Return txtInputData.Text
        End Get
        '�l��ݒ肷��
        Set(ByVal Value As String)
            txtInputData.Text = Value
            mstrOldInputDate = Value
        End Set
    End Property
#End Region

#Region "  �߽ܰ���׸�"
    ''' =======================================
    ''' <summary>�߽ܰ���׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPasswordFlag() As Boolean
        '�l���擾����
        Get
            Return mblnPasswordFlg
        End Get
        '�l��ݒ肷��
        Set(ByVal Value As Boolean)
            mblnPasswordFlg = Value
        End Set
    End Property
#End Region

#Region "  ��ʌŒ��׸�"
    ''' =======================================
    ''' <summary>��ʌŒ��׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userMoveable() As Boolean
        Get
            Return Me._Moveable
        End Get

        Set(ByVal value As Boolean)
            Me._Moveable = value
        End Set
    End Property
#End Region

#Region "  �ő啶����"
    ''' =======================================
    ''' <summary>�ő啶����</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userMaxTextLength() As Integer
        '�l���擾����
        Get
            Return mintMaxTextLength
        End Get
        '�l��ݒ肷��
        Set(ByVal Value As Integer)
            mintMaxTextLength = Value
        End Set
    End Property
#End Region

#Region "  ��ʈʒu�Œ��׸�"
    ''' =======================================
    ''' <summary>��ʈʒu�Œ��׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFormLock() As enmFormLock
        '�l���擾����
        Get
            Return mudtFormLock
        End Get
        '�l��ݒ肷��
        Set(ByVal Value As enmFormLock)
            mudtFormLock = Value
        End Set
    End Property
#End Region

#Region "  ���͐����׸�"
    ''' =======================================
    ''' <summary>���͐����׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userButtonEnable() As enmButtonEnable
        '�l���擾����
        Get
            Return mudtButtonEnable
        End Get
        '�l��ݒ肷��
        Set(ByVal Value As enmButtonEnable)
            mudtButtonEnable = Value
        End Set
    End Property
#End Region

#End Region

#Region "  ���ʕϐ�         "

#Region "  �錾"
    '---------- <�萔�錾��> ----------
    Private Const VAL_BUTTON_NUM As Integer = 10        '���l���ݐ�
    Private Const ALPHA_BUTTON_NUM As Integer = 26      '�p�����ݐ�
    Private Const SIGN_BUTTON_NUM As Integer = 6       '�L������

    '---------- <�O���ϐ��錾��> ----------
    Private mintCursorPoint As Integer          '�����߲��
    Private mstrOldInputDate As String          '�ύX�O���ް�
    Private mintMaxTextLength As Integer        '�ő啶����


    '---------- <�����è�ϐ��錾��> ----------
    Private mblnPasswordFlg As Boolean              '�߽ܰ���׸�
    Private mudtButtonEnable As enmButtonEnable     '���ݐ���
    Private mudtFormLock As enmFormLock             '��ʈʒu�ݒ�
    Private _Moveable As Boolean = True             '��ʌŒ�

    '���۰ٔz��
    Private objInputNumBtn(VAL_BUTTON_NUM) As System.Windows.Forms.Button           '���l����
    Private objInputAlphaBtn(ALPHA_BUTTON_NUM) As System.Windows.Forms.Button
    '�p������
    Private objInputSignBtn(SIGN_BUTTON_NUM) As System.Windows.Forms.Button         '�L������


    ''' <summary>���ݐ���</summary>
    Enum enmButtonEnable
        All                 '�S��
        Number              '���l�̂�
    End Enum

    ''' <summary>��ʈʒu�ݒ�</summary>
    Enum enmFormLock
        lock                 '��ʌŒ�
        unlock               '�Œ����
    End Enum

#End Region

#End Region

#Region "  �����         "

#Region "  ̫��۰�ގ�����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�ގ�����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>���۰�ގ��̏����������s��</remarks>
    ''' *******************************************************************************************************************
    Private Sub frmKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim intCount As Integer   '�����l
        Dim intii As Integer

        Try
            'mnCursorPoint = 0               '�����߲�Ă̏�����
            mintCursorPoint = txtInputData.Text.Length        '�����߲�Ă𕶎��̍Ō�ɂ���

            '�߽ܰ���׸�����
            If mblnPasswordFlg Then
                Me.txtInputData.PasswordChar = "*"
            End If

            '���l���ݺ��۰ق̔z��ɂ��łɍ쐬����Ă���ݽ�ݽ����
            objInputNumBtn(0) = cmdNumBtn0  '0
            objInputNumBtn(1) = cmdNumBtn1  '1
            objInputNumBtn(2) = cmdNumBtn2  '2
            objInputNumBtn(3) = cmdNumBtn3  '3
            objInputNumBtn(4) = cmdNumBtn4  '4
            objInputNumBtn(5) = cmdNumBtn5  '5
            objInputNumBtn(6) = cmdNumBtn6  '6
            objInputNumBtn(7) = cmdNumBtn7  '7
            objInputNumBtn(8) = cmdNumBtn8  '8
            objInputNumBtn(9) = cmdNumBtn9  '9

            '���������ׂɊ֘A�t��
            For intCount = 0 To VAL_BUTTON_NUM - 1
                AddHandler objInputNumBtn(intCount).Click, AddressOf InputBtn_Click
            Next

            '�p�����ݺ��۰ق̔z��ɂ��łɍ쐬����Ă���ݽ�ݽ����
            objInputAlphaBtn(0) = cmdAlphaBtn0        'A
            objInputAlphaBtn(1) = cmdAlphaBtn1        'B
            objInputAlphaBtn(2) = cmdAlphaBtn2        'C
            objInputAlphaBtn(3) = cmdAlphaBtn3        'D
            objInputAlphaBtn(4) = cmdAlphaBtn4        'E
            objInputAlphaBtn(5) = cmdAlphaBtn5        'F
            objInputAlphaBtn(6) = cmdAlphaBtn6        'G
            objInputAlphaBtn(7) = cmdAlphaBtn7        'H
            objInputAlphaBtn(8) = cmdAlphaBtn8        'I
            objInputAlphaBtn(9) = cmdAlphaBtn9        'J
            objInputAlphaBtn(10) = cmdAlphaBtn10      'K
            objInputAlphaBtn(11) = cmdAlphaBtn11      'L
            objInputAlphaBtn(12) = cmdAlphaBtn12      'M
            objInputAlphaBtn(13) = cmdAlphaBtn13      'N
            objInputAlphaBtn(14) = cmdAlphaBtn14      'O
            objInputAlphaBtn(15) = cmdAlphaBtn15      'P
            objInputAlphaBtn(16) = cmdAlphaBtn16      'Q
            objInputAlphaBtn(17) = cmdAlphaBtn17      'R
            objInputAlphaBtn(18) = cmdAlphaBtn18      'S
            objInputAlphaBtn(19) = cmdAlphaBtn19      'T
            objInputAlphaBtn(20) = cmdAlphaBtn20      'U
            objInputAlphaBtn(21) = cmdAlphaBtn21      'V
            objInputAlphaBtn(22) = cmdAlphaBtn22      'W
            objInputAlphaBtn(23) = cmdAlphaBtn23      'X
            objInputAlphaBtn(24) = cmdAlphaBtn24      'Y
            objInputAlphaBtn(25) = cmdAlphaBtn25      'Z

            '���������ׂɊ֘A�t��
            For intCount = 0 To ALPHA_BUTTON_NUM - 1
                AddHandler objInputAlphaBtn(intCount).Click, AddressOf InputBtn_Click
            Next

            '�L�����ݺ��۰ق̔z��ɂ��łɍ쐬����Ă���ݽ�ݽ����
            objInputSignBtn(0) = cmdSignBtn0    '.
            objInputSignBtn(1) = cmdSignBtn1    '+
            objInputSignBtn(2) = cmdSignBtn2    '-(������)
            objInputSignBtn(3) = cmdSignBtn5    '$
            objInputSignBtn(4) = cmdSignBtn6    '\
            objInputSignBtn(5) = cmdSignBtn9    '-(�d�쑤)

            '���������ׂɊ֘A�t��
            For intCount = 0 To SIGN_BUTTON_NUM - 1
                AddHandler objInputSignBtn(intCount).Click, AddressOf InputBtn_Click
            Next

            '���͐���
            If mudtButtonEnable <> enmButtonEnable.All Then
                For intii = 0 To 25
                    objInputAlphaBtn(intii).Enabled = False
                Next
                For intii = 0 To 5
                    objInputSignBtn(intii).Enabled = False
                Next
            End If

            '��ʈʒu�ݒ�
            If mudtFormLock = enmFormLock.lock Then
                'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                Me.StartPosition = Windows.Forms.FormStartPosition.CenterParent
            End If

        Catch ex As Exception
            Call ComError(ex)

        Finally

        End Try
    End Sub
#End Region

#Region "  ���ݾ٣���݉���������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ݾ٣���݉���������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>���͓��e��j�����A����ʂ��I������</remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdBtnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBtnESC.Click
        Try
            txtInputData.Text = mstrOldInputDate
            '��ʸ۰��
            Me.Close()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#Region "  �uOK�v���݉���������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �uOK�v���݉���������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>���͓��e���m�肵�A����ʂ��I������</remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdBtnENT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBtnENT.Click
        Try
            '��ʸ۰��
            Me.Close()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#Region "  �uBS�v���݉���������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �uBS�v���݉���������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>���وʒu�̈�O�̕������폜����
    ''' ���وʒu���擪�������O�̏ꍇ�͍폜�s��</remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdBtnBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBtnBS.Click
        Try
            Call RemoveChar()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#Region "  �������݉���������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �������݉���������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>���p����"0"�`"9"�A���p�p����"A"�`"Z"�A"."�A"+"�A"-"�A"*"�A"/"�̓�د����ꂽ���݂̒l(Text�����è�l)����͂���
    ''' </remarks>
    ''' *******************************************************************************************************************
    Private Sub InputBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strInputChar As String    '���͕�����

        Try
            '�د����ꂽ���݂�Text�����è�l�擾
            strInputChar = CType(sender, System.Windows.Forms.Button).Text
            '�������͏���
            Call InsertChar(strInputChar)

        Catch ex As Exception
            Call ComError(ex)
        Finally

        End Try
    End Sub
#End Region

#Region "  �����ް��\�����د�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����ް��\�����د�������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>���ق�mnCursorPoint�ɍ��킹��</remarks>
    ''' *******************************************************************************************************************
    Private Sub txtInputData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInputData.Click
        Try

            '���ق𖖔��Ɉړ�
            txtInputData.SelectionStart = Len(txtInputData.Text)

            '̫����ړ�����
            Call MoveFocus()


        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#End Region

#Region "  �������͏���"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �������͏���
    ''' </summary>
    ''' <param name="strInputChar">���͕���</param>
    ''' <remarks>���͕����𶰿وʒu�ɑ}������</remarks>
    ''' *******************************************************************************************************************
    Private Sub InsertChar(ByVal strInputChar As String)
        Dim strCurrString As String   '���ݕ�����

        Try
            '���݂�÷���ޯ����������擾
            strCurrString = txtInputData.Text

            '����������
            If strCurrString.Length < mintMaxTextLength Then
                '�ő���͕����ȉ��̏ꍇ
                '���݂̕�������ɓ��͕�����}��
                txtInputData.Text = strCurrString.Insert(mintCursorPoint, strInputChar)

                '�����߲�Ĳ����ď���
                Call MoveIncCursorPoint()

            End If

            '̫����ړ�����
            Call MoveFocus()

        Catch ex As Exception
            Call ComError(ex)
        Finally

        End Try
    End Sub
#End Region

#Region "  �����폜����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����폜����
    ''' </summary>
    ''' <remarks>���وʒu�̕������폜����(BS��)</remarks>
    ''' *******************************************************************************************************************
    Private Sub RemoveChar()
        Dim strCurrString As String   '���ݕ�����

        Try
            '���݂�÷���ޯ����������擾
            strCurrString = txtInputData.Text

            If mintCursorPoint > 0 Then
                '���وʒu���擪�łȂ��ꍇ
                '�����ް��\��������̶��وʒu�̈�O�̕������ꕶ�����폜
                txtInputData.Text = strCurrString.Remove(mintCursorPoint - 1, 1)

                '�����߲���޸���ď���
                Call MoveDecCursorPoint()
            End If

            '̫����ړ�����
            Call MoveFocus()

        Catch ex As Exception
            Call ComError(ex)
        Finally

        End Try

    End Sub
#End Region

#Region "  �����߲�Ĳݸ���ď���"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����߲�Ĳݸ���ď���
    ''' </summary>
    ''' <remarks>�����߲�Ă���i�߂�
    ''' �������A���وʒu���ő啶����ȏ�A���邢�͍Ō���̏ꍇ�͂���ȏ�͐i�߂Ȃ�</remarks>
    ''' *******************************************************************************************************************
    Private Sub MoveIncCursorPoint()
        Try
            If mintCursorPoint < mintMaxTextLength And _
                mintCursorPoint < txtInputData.TextLength Then
                '�����߲�Ă��ő啶����ȉ������݂̍Ō���łȂ��ꍇ
                mintCursorPoint += 1      '�����߲�Ă̲ݸ����
            End If
        Catch ex As Exception
            Call ComError(ex)
        End Try

    End Sub
#End Region

#Region "  �����߲���޸���ď���"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����߲���޸���ď���
    ''' </summary>
    ''' <remarks>���وʒu����߂�
    ''' �������A���وʒu���ŏ��ɂ���ꍇ�͂���ȏ�߂�Ȃ�</remarks>
    ''' *******************************************************************************************************************
    Private Sub MoveDecCursorPoint()
        Try
            If mintCursorPoint > 0 Then
                '�����߲�Ă��擪�łȂ��ꍇ
                mintCursorPoint -= 1      '�����߲�Ă��޸����
            End If
        Catch ex As Exception
            Call ComError(ex)
        End Try

    End Sub
#End Region

#Region "  ÷���ޯ����̫����ړ�����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÷���ޯ����̫����ړ�����
    ''' </summary>
    ''' <remarks>�������͌�A̫�����÷���ޯ���֖߂�</remarks>
    ''' *******************************************************************************************************************
    Private Sub MoveFocus()
        Try
            '���وʒu��ݒ�
            txtInputData.SelectionStart = mintCursorPoint
            ' ''�I�𒷂�0�ɐݒ�
            ''txtInputData.SelectionLength = 0
            '̫������ڂ�
            txtInputData.Focus()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#Region "  WndProcҿ��ނ̵��ްײ��"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' WndProcҿ��ނ̵��ްײ��
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overrides Sub WndProc(ByRef m As Message)
        If Me.userMoveable = False Then
            Const WM_SYSCOMMAND As Integer = &H112
            Const SC_MOVE As Integer = &HF010
            Const SC_MASK As Integer = &HFFF0

            ' �t�H�[���̈ړ���ߑ�������ȍ~�̐�����J�b�g����
            If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt32() And SC_MASK) = SC_MOVE Then
                Return
            End If
        End If

        ' ��{�N���X�̃��\�b�h�����s����
        MyBase.WndProc(m)
    End Sub
#End Region

#Region "  �װ����    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="objException"></param>
    ''' <remarks>�װү���ނ�ү�����ޯ���ŕ\������</remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try

            '**************************************************
            '�װү���ޕ\��
            '**************************************************
            Dim strMsg As String = ""
            strMsg &= "�װ���������܂����B"
            strMsg &= vbCrLf & objException.Message
            MsgBox(strMsg)

        Catch ex As Exception
            '�������Ȃ�

        End Try
    End Sub
#End Region

End Class