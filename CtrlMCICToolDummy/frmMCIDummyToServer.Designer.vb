<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMCIDummyToServer
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMCIDummyToServer))
        Me.tmrDebug = New System.Windows.Forms.Timer(Me.components)
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdIcon = New System.Windows.Forms.Button
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmd01 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtSend002 = New System.Windows.Forms.TextBox
        Me.txtSend003 = New System.Windows.Forms.TextBox
        Me.txtSend001 = New System.Windows.Forms.TextBox
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrDebug
        '
        Me.tmrDebug.Enabled = True
        Me.tmrDebug.Interval = 2000
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(344, 272)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(64, 24)
        Me.cmdClose.TabIndex = 13
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdIcon
        '
        Me.cmdIcon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdIcon.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIcon.Location = New System.Drawing.Point(344, 240)
        Me.cmdIcon.Name = "cmdIcon"
        Me.cmdIcon.Size = New System.Drawing.Size(64, 24)
        Me.cmdIcon.TabIndex = 12
        Me.cmdIcon.Text = "ｱｲｺﾝ化"
        Me.cmdIcon.UseVisualStyleBackColor = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.cmd01)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.txtSend002)
        Me.GroupBox4.Controls.Add(Me.txtSend003)
        Me.GroupBox4.Controls.Add(Me.txtSend001)
        Me.GroupBox4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(400, 226)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ｶｰﾄﾞﾘｰﾀﾞ読取"
        '
        'cmd01
        '
        Me.cmd01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmd01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd01.Location = New System.Drawing.Point(316, 186)
        Me.cmd01.Name = "cmd01"
        Me.cmd01.Size = New System.Drawing.Size(64, 24)
        Me.cmd01.TabIndex = 548
        Me.cmd01.Text = "送信"
        Me.cmd01.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 543
        Me.Label1.Text = "ｶｰﾄﾞ№"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(9, 126)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 16)
        Me.Label28.TabIndex = 543
        Me.Label28.Text = "後半"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(7, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 16)
        Me.Label16.TabIndex = 368
        Me.Label16.Text = "前半"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSend002
        '
        Me.txtSend002.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSend002.Location = New System.Drawing.Point(66, 104)
        Me.txtSend002.MaxLength = 6
        Me.txtSend002.Name = "txtSend002"
        Me.txtSend002.Size = New System.Drawing.Size(69, 19)
        Me.txtSend002.TabIndex = 1
        Me.txtSend002.Text = "000000"
        '
        'txtSend003
        '
        Me.txtSend003.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSend003.Location = New System.Drawing.Point(66, 126)
        Me.txtSend003.Multiline = True
        Me.txtSend003.Name = "txtSend003"
        Me.txtSend003.Size = New System.Drawing.Size(299, 54)
        Me.txtSend003.TabIndex = 1
        Me.txtSend003.Text = "40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40," & _
            "40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40"
        '
        'txtSend001
        '
        Me.txtSend001.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSend001.Location = New System.Drawing.Point(66, 18)
        Me.txtSend001.Multiline = True
        Me.txtSend001.Name = "txtSend001"
        Me.txtSend001.Size = New System.Drawing.Size(299, 80)
        Me.txtSend001.TabIndex = 0
        Me.txtSend001.Text = "F0,F1,F0,F0,F0,F1"
        '
        'frmMCIDummyToServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(421, 311)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmdIcon)
        Me.Controls.Add(Me.cmdClose)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMCIDummyToServer"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "物流ｻｰﾊﾞへ送信"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrDebug As System.Windows.Forms.Timer
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdIcon As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSend001 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtSend003 As System.Windows.Forms.TextBox
    Friend WithEvents cmd01 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSend002 As System.Windows.Forms.TextBox
End Class
