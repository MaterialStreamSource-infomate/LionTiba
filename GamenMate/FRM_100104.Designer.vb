<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100104
    Inherits GamenMate.FRM_100103

    'Form �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂� dispose ���I�[�o�[���C�h���܂��B
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
        Me.chkPrint = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Font = New System.Drawing.Font("�l�r �S�V�b�N", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkPrint.Location = New System.Drawing.Point(336, 72)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(133, 24)
        Me.chkPrint.TabIndex = 17
        Me.chkPrint.Text = "�w�}�����s"
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'FRM_100104
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(486, 161)
        Me.Controls.Add(Me.chkPrint)
        Me.Name = "FRM_100104"
        Me.Controls.SetChildIndex(Me.chkPrint, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox

End Class
