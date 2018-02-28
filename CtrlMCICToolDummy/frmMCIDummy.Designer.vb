<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMCIDummy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMCIDummy))
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.txtResponsCode = New System.Windows.Forms.TextBox
        Me.chkResponsCode = New System.Windows.Forms.CheckBox
        Me.chkRespons = New System.Windows.Forms.CheckBox
        Me.txtBCCCode = New System.Windows.Forms.TextBox
        Me.chkBCCCode = New System.Windows.Forms.CheckBox
        Me.chkSTX = New System.Windows.Forms.CheckBox
        Me.chkETX = New System.Windows.Forms.CheckBox
        Me.chkBCC = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSendSEQNo = New System.Windows.Forms.TextBox
        Me.txtRecvSEQNo = New System.Windows.Forms.TextBox
        Me.cmdSendSEQNoSet = New System.Windows.Forms.Button
        Me.cmdRecvSEQNoSet = New System.Windows.Forms.Button
        Me.chkResponsTelegram = New System.Windows.Forms.CheckBox
        Me.txtResponsTelegram = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdSendToButuryu = New System.Windows.Forms.Button
        Me.txtSendTelegram = New System.Windows.Forms.TextBox
        Me.cmdSendTelegram = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdIcon = New System.Windows.Forms.Button
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.chkDebugFlag = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ListBox1.TabIndex = 1
        '
        'tmrMain
        '
        '
        'txtResponsCode
        '
        Me.txtResponsCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtResponsCode.Location = New System.Drawing.Point(112, 40)
        Me.txtResponsCode.MaxLength = 2
        Me.txtResponsCode.Name = "txtResponsCode"
        Me.txtResponsCode.Size = New System.Drawing.Size(48, 19)
        Me.txtResponsCode.TabIndex = 32
        Me.txtResponsCode.Text = "00"
        '
        'chkResponsCode
        '
        Me.chkResponsCode.AutoSize = True
        Me.chkResponsCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkResponsCode.Location = New System.Drawing.Point(16, 40)
        Me.chkResponsCode.Name = "chkResponsCode"
        Me.chkResponsCode.Size = New System.Drawing.Size(96, 16)
        Me.chkResponsCode.TabIndex = 33
        Me.chkResponsCode.Text = "応答ｺｰﾄﾞ固定"
        Me.chkResponsCode.UseVisualStyleBackColor = True
        '
        'chkRespons
        '
        Me.chkRespons.AutoSize = True
        Me.chkRespons.Checked = True
        Me.chkRespons.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRespons.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkRespons.Location = New System.Drawing.Point(16, 24)
        Me.chkRespons.Name = "chkRespons"
        Me.chkRespons.Size = New System.Drawing.Size(48, 16)
        Me.chkRespons.TabIndex = 34
        Me.chkRespons.Text = "応答"
        Me.chkRespons.UseVisualStyleBackColor = True
        '
        'txtBCCCode
        '
        Me.txtBCCCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBCCCode.Location = New System.Drawing.Point(112, 72)
        Me.txtBCCCode.MaxLength = 5
        Me.txtBCCCode.Name = "txtBCCCode"
        Me.txtBCCCode.Size = New System.Drawing.Size(48, 19)
        Me.txtBCCCode.TabIndex = 35
        Me.txtBCCCode.Text = "00"
        '
        'chkBCCCode
        '
        Me.chkBCCCode.AutoSize = True
        Me.chkBCCCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkBCCCode.Location = New System.Drawing.Point(16, 72)
        Me.chkBCCCode.Name = "chkBCCCode"
        Me.chkBCCCode.Size = New System.Drawing.Size(78, 16)
        Me.chkBCCCode.TabIndex = 36
        Me.chkBCCCode.Text = "BCC値固定"
        Me.chkBCCCode.UseVisualStyleBackColor = True
        '
        'chkSTX
        '
        Me.chkSTX.AutoSize = True
        Me.chkSTX.Checked = True
        Me.chkSTX.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSTX.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkSTX.Location = New System.Drawing.Point(16, 24)
        Me.chkSTX.Name = "chkSTX"
        Me.chkSTX.Size = New System.Drawing.Size(66, 16)
        Me.chkSTX.TabIndex = 38
        Me.chkSTX.Text = "STX付加"
        Me.chkSTX.UseVisualStyleBackColor = True
        '
        'chkETX
        '
        Me.chkETX.AutoSize = True
        Me.chkETX.Checked = True
        Me.chkETX.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkETX.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkETX.Location = New System.Drawing.Point(16, 40)
        Me.chkETX.Name = "chkETX"
        Me.chkETX.Size = New System.Drawing.Size(66, 16)
        Me.chkETX.TabIndex = 40
        Me.chkETX.Text = "ETX付加"
        Me.chkETX.UseVisualStyleBackColor = True
        '
        'chkBCC
        '
        Me.chkBCC.AutoSize = True
        Me.chkBCC.Checked = True
        Me.chkBCC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBCC.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkBCC.Location = New System.Drawing.Point(16, 56)
        Me.chkBCC.Name = "chkBCC"
        Me.chkBCC.Size = New System.Drawing.Size(66, 16)
        Me.chkBCC.TabIndex = 41
        Me.chkBCC.Text = "BCC付加"
        Me.chkBCC.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "送信SEQNO修正"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 12)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "受信SEQNO修正"
        '
        'txtSendSEQNo
        '
        Me.txtSendSEQNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSendSEQNo.Location = New System.Drawing.Point(112, 16)
        Me.txtSendSEQNo.MaxLength = 4
        Me.txtSendSEQNo.Name = "txtSendSEQNo"
        Me.txtSendSEQNo.Size = New System.Drawing.Size(48, 19)
        Me.txtSendSEQNo.TabIndex = 44
        Me.txtSendSEQNo.Text = "0000"
        '
        'txtRecvSEQNo
        '
        Me.txtRecvSEQNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtRecvSEQNo.Location = New System.Drawing.Point(112, 40)
        Me.txtRecvSEQNo.MaxLength = 4
        Me.txtRecvSEQNo.Name = "txtRecvSEQNo"
        Me.txtRecvSEQNo.Size = New System.Drawing.Size(48, 19)
        Me.txtRecvSEQNo.TabIndex = 45
        Me.txtRecvSEQNo.Text = "0000"
        '
        'cmdSendSEQNoSet
        '
        Me.cmdSendSEQNoSet.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSendSEQNoSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSendSEQNoSet.Location = New System.Drawing.Point(168, 16)
        Me.cmdSendSEQNoSet.Name = "cmdSendSEQNoSet"
        Me.cmdSendSEQNoSet.Size = New System.Drawing.Size(56, 20)
        Me.cmdSendSEQNoSet.TabIndex = 47
        Me.cmdSendSEQNoSet.Text = "修正"
        Me.cmdSendSEQNoSet.UseVisualStyleBackColor = False
        '
        'cmdRecvSEQNoSet
        '
        Me.cmdRecvSEQNoSet.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdRecvSEQNoSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdRecvSEQNoSet.Location = New System.Drawing.Point(168, 40)
        Me.cmdRecvSEQNoSet.Name = "cmdRecvSEQNoSet"
        Me.cmdRecvSEQNoSet.Size = New System.Drawing.Size(56, 20)
        Me.cmdRecvSEQNoSet.TabIndex = 48
        Me.cmdRecvSEQNoSet.Text = "修正"
        Me.cmdRecvSEQNoSet.UseVisualStyleBackColor = False
        '
        'chkResponsTelegram
        '
        Me.chkResponsTelegram.AutoSize = True
        Me.chkResponsTelegram.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkResponsTelegram.Location = New System.Drawing.Point(16, 64)
        Me.chkResponsTelegram.Name = "chkResponsTelegram"
        Me.chkResponsTelegram.Size = New System.Drawing.Size(96, 16)
        Me.chkResponsTelegram.TabIndex = 49
        Me.chkResponsTelegram.Text = "強制応答電文"
        Me.chkResponsTelegram.UseVisualStyleBackColor = True
        '
        'txtResponsTelegram
        '
        Me.txtResponsTelegram.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtResponsTelegram.Location = New System.Drawing.Point(112, 64)
        Me.txtResponsTelegram.MaxLength = 2000
        Me.txtResponsTelegram.Name = "txtResponsTelegram"
        Me.txtResponsTelegram.Size = New System.Drawing.Size(48, 19)
        Me.txtResponsTelegram.TabIndex = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.chkRespons)
        Me.GroupBox1.Controls.Add(Me.txtResponsTelegram)
        Me.GroupBox1.Controls.Add(Me.chkResponsCode)
        Me.GroupBox1.Controls.Add(Me.chkResponsTelegram)
        Me.GroupBox1.Controls.Add(Me.txtResponsCode)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 416)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 96)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "応答電文"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.chkSTX)
        Me.GroupBox2.Controls.Add(Me.chkBCCCode)
        Me.GroupBox2.Controls.Add(Me.txtBCCCode)
        Me.GroupBox2.Controls.Add(Me.chkETX)
        Me.GroupBox2.Controls.Add(Me.chkBCC)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(240, 104)
        Me.GroupBox2.TabIndex = 52
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ｼﾘｱﾙ通信電文形式"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtSendSEQNo)
        Me.GroupBox3.Controls.Add(Me.cmdRecvSEQNoSet)
        Me.GroupBox3.Controls.Add(Me.txtRecvSEQNo)
        Me.GroupBox3.Controls.Add(Me.cmdSendSEQNoSet)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(16, 336)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 72)
        Me.GroupBox3.TabIndex = 53
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ｼｰｹﾝｽNo"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.cmdSendToButuryu)
        Me.GroupBox4.Controls.Add(Me.txtSendTelegram)
        Me.GroupBox4.Controls.Add(Me.cmdSendTelegram)
        Me.GroupBox4.Location = New System.Drawing.Point(272, 224)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(656, 80)
        Me.GroupBox4.TabIndex = 54
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "とにかく電文送信"
        '
        'cmdSendToButuryu
        '
        Me.cmdSendToButuryu.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSendToButuryu.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSendToButuryu.Location = New System.Drawing.Point(552, 48)
        Me.cmdSendToButuryu.Name = "cmdSendToButuryu"
        Me.cmdSendToButuryu.Size = New System.Drawing.Size(96, 20)
        Me.cmdSendToButuryu.TabIndex = 48
        Me.cmdSendToButuryu.Text = "ﾀﾞﾐｰ → 物流"
        Me.cmdSendToButuryu.UseVisualStyleBackColor = False
        '
        'txtSendTelegram
        '
        Me.txtSendTelegram.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSendTelegram.Location = New System.Drawing.Point(8, 16)
        Me.txtSendTelegram.Name = "txtSendTelegram"
        Me.txtSendTelegram.Size = New System.Drawing.Size(576, 19)
        Me.txtSendTelegram.TabIndex = 44
        '
        'cmdSendTelegram
        '
        Me.cmdSendTelegram.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSendTelegram.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSendTelegram.Location = New System.Drawing.Point(592, 16)
        Me.cmdSendTelegram.Name = "cmdSendTelegram"
        Me.cmdSendTelegram.Size = New System.Drawing.Size(56, 20)
        Me.cmdSendTelegram.TabIndex = 47
        Me.cmdSendTelegram.Text = "送信"
        Me.cmdSendTelegram.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(864, 496)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(64, 24)
        Me.cmdClose.TabIndex = 523
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdIcon
        '
        Me.cmdIcon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdIcon.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIcon.Location = New System.Drawing.Point(864, 464)
        Me.cmdIcon.Name = "cmdIcon"
        Me.cmdIcon.Size = New System.Drawing.Size(64, 24)
        Me.cmdIcon.TabIndex = 524
        Me.cmdIcon.Text = "ｱｲｺﾝ化"
        Me.cmdIcon.UseVisualStyleBackColor = False
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
        Me.chkDebugFlag.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDebugFlag.Location = New System.Drawing.Point(272, 312)
        Me.chkDebugFlag.Name = "chkDebugFlag"
        Me.chkDebugFlag.Size = New System.Drawing.Size(90, 16)
        Me.chkDebugFlag.TabIndex = 525
        Me.chkDebugFlag.Text = "ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ"
        Me.chkDebugFlag.UseVisualStyleBackColor = True
        '
        'frmMCIDummy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(932, 525)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkDebugFlag)
        Me.Controls.Add(Me.cmdIcon)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(940, 552)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(940, 552)
        Me.Name = "frmMCIDummy"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMCIDummy"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents tmrMain As System.Windows.Forms.Timer
    Friend WithEvents txtResponsCode As System.Windows.Forms.TextBox
    Friend WithEvents chkResponsCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkRespons As System.Windows.Forms.CheckBox
    Friend WithEvents txtBCCCode As System.Windows.Forms.TextBox
    Friend WithEvents chkBCCCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkSTX As System.Windows.Forms.CheckBox
    Friend WithEvents chkETX As System.Windows.Forms.CheckBox
    Friend WithEvents chkBCC As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSendSEQNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRecvSEQNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdSendSEQNoSet As System.Windows.Forms.Button
    Friend WithEvents cmdRecvSEQNoSet As System.Windows.Forms.Button
    Friend WithEvents chkResponsTelegram As System.Windows.Forms.CheckBox
    Friend WithEvents txtResponsTelegram As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSendTelegram As System.Windows.Forms.TextBox
    Friend WithEvents cmdSendTelegram As System.Windows.Forms.Button
    Friend WithEvents cmdSendToButuryu As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdIcon As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents chkDebugFlag As System.Windows.Forms.CheckBox
End Class
