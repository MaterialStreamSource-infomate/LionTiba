<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100004
    Inherits FRM_000001

    '�t�H�[�����R���|�[�l���g�̈ꗗ���N���[���A�b�v���邽�߂� dispose ���I�[�o�[���C�h���܂��B
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    '����: �ȉ��̃v���V�[�W���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    'Windows �t�H�[�� �f�U�C�i���g�p���ĕύX�ł��܂��B  
    '�R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblMsg = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("�l�r �S�V�b�N", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblMsg.ForeColor = System.Drawing.Color.Black
        Me.lblMsg.Location = New System.Drawing.Point(8, 8)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(472, 152)
        Me.lblMsg.TabIndex = 12
        Me.lblMsg.Text = "���΂炭���҂�������"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FRM_100004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 163)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblMsg)
        Me.Location = New System.Drawing.Point(1, 1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(496, 190)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(496, 190)
        Me.Name = "FRM_100004"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���b�Z�[�W"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMsg As System.Windows.Forms.Label
End Class
