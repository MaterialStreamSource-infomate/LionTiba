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

Public Class FRM_000001

#Region "  API��`                              "

    '***************************************************************
    'API�錾
    '***************************************************************
    '�Ō�ɔ����������̓C�x���g�̎������擾����֐��̐錾
    Declare Function GetLastInputInfo Lib "user32.dll" (ByRef Plii As LASTINPUTINFO) As Integer
    '�V�X�e�����N��������̌o�ߎ��Ԃ��A�~���b�P�ʂŕԂ�֐��̐錾
    Declare Function GetTickCount Lib "kernel32" () As Integer


    '***************************************************************
    '�Ō�ɔ����������̓C�x���g�̎������`����\���̂̐錾
    '***************************************************************
    Structure LASTINPUTINFO
        Dim cbSize As UInteger
        Dim dwTime As UInteger
    End Structure

#End Region
#Region "  ����ā@�@�@�@�@�@�@�@                "
#Region "  Visible�ύX              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Visible�ύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_000001_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Me.DesignMode = True Then Exit Sub '�޻޲�Ӱ�ނ̎�����۸��т����s���Ȃ�
            If gcintAfkFlg = FLAG_OFF Then
                tmrTimeOutLogin.Enabled = False
            Else
                tmrTimeOutLogin.Enabled = True
            End If
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ۸޲ݏ����ѱ�ĊĎ���ϰ  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸޲ݏ����ѱ�ĊĎ���ϰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrTimeOutLogin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimeOutLogin.Tick
        Try

            If Me.DesignMode = True Then Exit Sub '�޻޲�Ӱ�ނ̎�����۸��т����s���Ȃ�
            tmrTimeOutLogin.Enabled = False
            Call TimeOutLoginProc()


        Catch ex As Exception
            ComError(ex)

        Finally
            tmrTimeOutLogin.Enabled = True

        End Try
    End Sub
#End Region
#End Region
#Region "  ۸޲ݏ����ѱ�ĊĎ���ϰ����          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸޲ݏ����ѱ�ĊĎ���ϰ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TimeOutLoginProc()

        '***************************************************************
        'Ӱ������
        '***************************************************************
        If gcintDSPLOGIN_FLG = FLAG_OFF Then Exit Sub

        '***************************************************************
        '����۸޵ݐݒ��ʵ�޼ު������
        '***************************************************************
        If IsNull(gobjFRM_100005) = False Then Exit Sub

        '***************************************************************
        '�Ō�ɓ��͂��s��ꂽ�������擾
        '***************************************************************
        Dim udtLastInputInfo As LASTINPUTINFO
        Dim blnRet As Boolean
        udtLastInputInfo.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(udtLastInputInfo)
        blnRet = GetLastInputInfo(udtLastInputInfo)
        If blnRet = False Then Throw New Exception("API�֐��uGetLastInputInfo�v�Ŵװ�����B")


        '***************************************************************
        '���ݎ������擾
        '***************************************************************
        Dim intNow As Integer        'OS���N�����Ă���̎���
        intNow = GetTickCount
        If (gcintDSPLOGOFF * 1000) <= intNow - udtLastInputInfo.dwTime Then
            '(��ѱ�Ĕ���)

            '***************************************************************
            '���ȉ�ʕ\��
            '***************************************************************
            If gblnLogoff = False Then
                Call gobjComFuncFRM.AfkProc(Me)

            End If

        End If

    End Sub
#End Region
#Region "  ��ʵ���ݏ���    (�e��ʏ���)        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʵ���ݏ���(�e��ʏ���)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub InitializeChild()



    End Sub
#End Region
#Region "  �װ����                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="ex">�װExceptio</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub ComError(ByVal ex As Exception)
        Try

            gobjComFuncFRM.ComError_frm(ex)

        Catch ex2 As Exception
            MsgBox("ComError�֐��Ŵװ����")

        End Try
    End Sub
#End Region

    '���̎�i(�����)
#Region "  Application.AddMessageFilter���g�p�����ꍇ"
    '    Private Const INPUT_TIMEOUT As Long = 10000
    '    Private Shared dtmInput As Date

    '    '�t�B���^��`
    '    Private Class TestFilter
    '        Implements IMessageFilter

    '        Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
    '            Try

    '                Const WM_MOUSEMOVE = &H200
    '                If m.Msg = WM_MOUSEMOVE Then
    '                    frmOya1.TextBox1.Text = Val(frmOya1.TextBox1.Text) + 1
    '                    dtmInput = Now
    '                End If
    '            Catch ex As Exception
    '                MsgBox(ex.Message)

    '            End Try
    '        End Function
    '    End Class

    '    Private Sub frmOya1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        '�t�B���^��o�^(�A�v�����ōŏ��ɋL�q)
    '        Application.AddMessageFilter(New TestFilter)
    '        dtmInput = Now
    '    End Sub

    '    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '        Try
    '            If DateAdd(DateInterval.Second, INPUT_TIMEOUT / 1000, dtmInput) <= Now Then
    '                Me.Close()
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)

    '        End Try
    '    End Sub
#End Region
#Region "  MouseMove���g�p�����ꍇ"
    '' ''Private Sub frmOya1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '' ''    Try
    '' ''        MsgBox("�L�[�_�E�������I")
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message)

    '' ''    End Try
    '' ''End Sub


    '' ''Private Sub frmOya1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '' ''    Try
    '' ''        Me.KeyPreview = True
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message)

    '' ''    End Try
    '' ''End Sub


    '' ''Private Sub frmOya1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
    '' ''    Try
    '' ''        MsgBox("�}�E�X�_�E�������I")
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message)

    '' ''    End Try
    '' ''End Sub

    '' ''Private Sub frmOya1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    '' ''    Try
    '' ''        TextBox1.Text = Val(TextBox1.Text) + 1
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message)

    '' ''    End Try
    '' ''End Sub
#End Region

End Class