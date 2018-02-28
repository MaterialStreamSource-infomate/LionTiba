<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMCI
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMCI))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cmdFormClose = New System.Windows.Forms.Button
        Me.cmdIcon = New System.Windows.Forms.Button
        Me.cmdShowSend = New System.Windows.Forms.Button
        Me.cmdCOMClose = New System.Windows.Forms.Button
        Me.cmdCOMOpen = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.chkDebugFlag = New System.Windows.Forms.CheckBox
        Me.cmdTool01 = New System.Windows.Forms.Button
        Me.chkGridDisp = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(128, 224)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(568, 24)
        Me.TextBox1.TabIndex = 32
        '
        'cmdFormClose
        '
        Me.cmdFormClose.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFormClose.Location = New System.Drawing.Point(824, 256)
        Me.cmdFormClose.Name = "cmdFormClose"
        Me.cmdFormClose.Size = New System.Drawing.Size(104, 24)
        Me.cmdFormClose.TabIndex = 31
        Me.cmdFormClose.Text = "閉じる"
        Me.cmdFormClose.UseVisualStyleBackColor = True
        '
        'cmdIcon
        '
        Me.cmdIcon.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIcon.Location = New System.Drawing.Point(824, 224)
        Me.cmdIcon.Name = "cmdIcon"
        Me.cmdIcon.Size = New System.Drawing.Size(104, 24)
        Me.cmdIcon.TabIndex = 30
        Me.cmdIcon.Text = "ｱｲｺﾝ化"
        Me.cmdIcon.UseVisualStyleBackColor = True
        '
        'cmdShowSend
        '
        Me.cmdShowSend.Location = New System.Drawing.Point(704, 224)
        Me.cmdShowSend.Name = "cmdShowSend"
        Me.cmdShowSend.Size = New System.Drawing.Size(104, 24)
        Me.cmdShowSend.TabIndex = 29
        Me.cmdShowSend.Text = "ﾃｽﾄ送信"
        Me.cmdShowSend.UseVisualStyleBackColor = True
        '
        'cmdCOMClose
        '
        Me.cmdCOMClose.Location = New System.Drawing.Point(8, 256)
        Me.cmdCOMClose.Name = "cmdCOMClose"
        Me.cmdCOMClose.Size = New System.Drawing.Size(112, 24)
        Me.cmdCOMClose.TabIndex = 28
        Me.cmdCOMClose.Text = "通信切断"
        Me.cmdCOMClose.UseVisualStyleBackColor = True
        '
        'cmdCOMOpen
        '
        Me.cmdCOMOpen.Location = New System.Drawing.Point(8, 224)
        Me.cmdCOMOpen.Name = "cmdCOMOpen"
        Me.cmdCOMOpen.Size = New System.Drawing.Size(112, 24)
        Me.cmdCOMOpen.TabIndex = 27
        Me.cmdCOMOpen.Text = "通信初期化開始"
        Me.cmdCOMOpen.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(8, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(920, 208)
        Me.ListBox1.TabIndex = 26
        '
        'tmrMain
        '
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'chkDebugFlag
        '
        Me.chkDebugFlag.AutoSize = True
        Me.chkDebugFlag.Location = New System.Drawing.Point(128, 256)
        Me.chkDebugFlag.Name = "chkDebugFlag"
        Me.chkDebugFlag.Size = New System.Drawing.Size(83, 16)
        Me.chkDebugFlag.TabIndex = 33
        Me.chkDebugFlag.Text = "ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ"
        Me.chkDebugFlag.UseVisualStyleBackColor = True
        '
        'cmdTool01
        '
        Me.cmdTool01.Location = New System.Drawing.Point(704, 256)
        Me.cmdTool01.Name = "cmdTool01"
        Me.cmdTool01.Size = New System.Drawing.Size(104, 24)
        Me.cmdTool01.TabIndex = 34
        Me.cmdTool01.Text = "安川PLCﾂｰﾙ"
        Me.cmdTool01.UseVisualStyleBackColor = True
        '
        'chkGridDisp
        '
        Me.chkGridDisp.AutoSize = True
        Me.chkGridDisp.Location = New System.Drawing.Point(231, 256)
        Me.chkGridDisp.Name = "chkGridDisp"
        Me.chkGridDisp.Size = New System.Drawing.Size(78, 16)
        Me.chkGridDisp.TabIndex = 35
        Me.chkGridDisp.Text = "ｸﾞﾘｯﾄﾞ表示"
        Me.chkGridDisp.UseVisualStyleBackColor = True
        '
        'frmMCI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 276)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkGridDisp)
        Me.Controls.Add(Me.cmdTool01)
        Me.Controls.Add(Me.chkDebugFlag)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmdFormClose)
        Me.Controls.Add(Me.cmdIcon)
        Me.Controls.Add(Me.cmdShowSend)
        Me.Controls.Add(Me.cmdCOMClose)
        Me.Controls.Add(Me.cmdCOMOpen)
        Me.Controls.Add(Me.ListBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(944, 315)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(944, 315)
        Me.Name = "frmMCI"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMCI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdFormClose As System.Windows.Forms.Button
    Friend WithEvents cmdIcon As System.Windows.Forms.Button
    Friend WithEvents cmdShowSend As System.Windows.Forms.Button
    Friend WithEvents cmdCOMClose As System.Windows.Forms.Button
    Friend WithEvents cmdCOMOpen As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents tmrMain As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents chkDebugFlag As System.Windows.Forms.CheckBox
    Friend WithEvents cmdTool01 As System.Windows.Forms.Button
    Friend WithEvents chkGridDisp As System.Windows.Forms.CheckBox
End Class
