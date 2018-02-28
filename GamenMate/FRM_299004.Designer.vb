<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_299004
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
        Me.lstLog = New System.Windows.Forms.ListBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdoListenerASCII = New System.Windows.Forms.RadioButton
        Me.rdoListenerNormal = New System.Windows.Forms.RadioButton
        Me.cmdListenerShutdown = New System.Windows.Forms.Button
        Me.txtListenerSendChr = New System.Windows.Forms.TextBox
        Me.txtListenerSendText = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtListenerRecvText = New System.Windows.Forms.TextBox
        Me.txtListenerInterval = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.txtListenerPortNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdListenerSendChr = New System.Windows.Forms.Button
        Me.cmdListenerSend = New System.Windows.Forms.Button
        Me.cmdListenerListen = New System.Windows.Forms.Button
        Me.tmrListenTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdoReturnNG = New System.Windows.Forms.RadioButton
        Me.rdoReturnOK = New System.Windows.Forms.RadioButton
        Me.rdoReturnMessage = New System.Windows.Forms.RadioButton
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstLog
        '
        Me.lstLog.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.HorizontalScrollbar = True
        Me.lstLog.ItemHeight = 12
        Me.lstLog.Location = New System.Drawing.Point(0, 0)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(744, 208)
        Me.lstLog.TabIndex = 27
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoListenerASCII)
        Me.GroupBox2.Controls.Add(Me.rdoListenerNormal)
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(344, 552)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(112, 56)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "受信表示"
        '
        'rdoListenerASCII
        '
        Me.rdoListenerASCII.AutoSize = True
        Me.rdoListenerASCII.Location = New System.Drawing.Point(8, 32)
        Me.rdoListenerASCII.Name = "rdoListenerASCII"
        Me.rdoListenerASCII.Size = New System.Drawing.Size(95, 16)
        Me.rdoListenerASCII.TabIndex = 1
        Me.rdoListenerASCII.Text = "制御文字表示"
        Me.rdoListenerASCII.UseVisualStyleBackColor = True
        '
        'rdoListenerNormal
        '
        Me.rdoListenerNormal.AutoSize = True
        Me.rdoListenerNormal.Checked = True
        Me.rdoListenerNormal.Location = New System.Drawing.Point(8, 16)
        Me.rdoListenerNormal.Name = "rdoListenerNormal"
        Me.rdoListenerNormal.Size = New System.Drawing.Size(47, 16)
        Me.rdoListenerNormal.TabIndex = 0
        Me.rdoListenerNormal.TabStop = True
        Me.rdoListenerNormal.Text = "ﾉｰﾏﾙ"
        Me.rdoListenerNormal.UseVisualStyleBackColor = True
        '
        'cmdListenerShutdown
        '
        Me.cmdListenerShutdown.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdListenerShutdown.Location = New System.Drawing.Point(656, 552)
        Me.cmdListenerShutdown.Name = "cmdListenerShutdown"
        Me.cmdListenerShutdown.Size = New System.Drawing.Size(88, 48)
        Me.cmdListenerShutdown.TabIndex = 43
        Me.cmdListenerShutdown.Text = "受信終了"
        Me.cmdListenerShutdown.UseVisualStyleBackColor = True
        '
        'txtListenerSendChr
        '
        Me.txtListenerSendChr.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtListenerSendChr.Location = New System.Drawing.Point(96, 328)
        Me.txtListenerSendChr.Name = "txtListenerSendChr"
        Me.txtListenerSendChr.Size = New System.Drawing.Size(648, 19)
        Me.txtListenerSendChr.TabIndex = 35
        '
        'txtListenerSendText
        '
        Me.txtListenerSendText.AcceptsReturn = True
        Me.txtListenerSendText.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtListenerSendText.Location = New System.Drawing.Point(96, 296)
        Me.txtListenerSendText.Multiline = True
        Me.txtListenerSendText.Name = "txtListenerSendText"
        Me.txtListenerSendText.Size = New System.Drawing.Size(648, 32)
        Me.txtListenerSendText.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 304)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 12)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "送信ﾃｷｽﾄ"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtListenerRecvText
        '
        Me.txtListenerRecvText.AcceptsReturn = True
        Me.txtListenerRecvText.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtListenerRecvText.Location = New System.Drawing.Point(96, 352)
        Me.txtListenerRecvText.Multiline = True
        Me.txtListenerRecvText.Name = "txtListenerRecvText"
        Me.txtListenerRecvText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtListenerRecvText.Size = New System.Drawing.Size(648, 192)
        Me.txtListenerRecvText.TabIndex = 36
        Me.txtListenerRecvText.WordWrap = False
        '
        'txtListenerInterval
        '
        Me.txtListenerInterval.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtListenerInterval.Location = New System.Drawing.Point(96, 272)
        Me.txtListenerInterval.Name = "txtListenerInterval"
        Me.txtListenerInterval.Size = New System.Drawing.Size(120, 19)
        Me.txtListenerInterval.TabIndex = 31
        Me.txtListenerInterval.Text = "100"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 360)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 12)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "受信ﾃｷｽﾄ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 12)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "ﾊﾞｯﾌｧ検索ﾀｲﾏｰ"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(96, 248)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(120, 19)
        Me.TextBox4.TabIndex = 30
        Me.TextBox4.Text = "10"
        '
        'txtListenerPortNo
        '
        Me.txtListenerPortNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtListenerPortNo.Location = New System.Drawing.Point(96, 224)
        Me.txtListenerPortNo.Name = "txtListenerPortNo"
        Me.txtListenerPortNo.Size = New System.Drawing.Size(120, 19)
        Me.txtListenerPortNo.TabIndex = 29
        Me.txtListenerPortNo.Text = "10001"
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 12)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "最大受信接続数"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 12)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "受信ﾎﾟｰﾄ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 336)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 12)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "送信ﾃｷｽﾄ(Chr)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdListenerSendChr
        '
        Me.cmdListenerSendChr.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdListenerSendChr.Location = New System.Drawing.Point(552, 576)
        Me.cmdListenerSendChr.Name = "cmdListenerSendChr"
        Me.cmdListenerSendChr.Size = New System.Drawing.Size(104, 24)
        Me.cmdListenerSendChr.TabIndex = 42
        Me.cmdListenerSendChr.Text = "ﾃﾞｰﾀ送信(Chr)"
        Me.cmdListenerSendChr.UseVisualStyleBackColor = True
        '
        'cmdListenerSend
        '
        Me.cmdListenerSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdListenerSend.Location = New System.Drawing.Point(552, 552)
        Me.cmdListenerSend.Name = "cmdListenerSend"
        Me.cmdListenerSend.Size = New System.Drawing.Size(104, 24)
        Me.cmdListenerSend.TabIndex = 41
        Me.cmdListenerSend.Text = "ﾃﾞｰﾀ送信"
        Me.cmdListenerSend.UseVisualStyleBackColor = True
        '
        'cmdListenerListen
        '
        Me.cmdListenerListen.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdListenerListen.Location = New System.Drawing.Point(464, 552)
        Me.cmdListenerListen.Name = "cmdListenerListen"
        Me.cmdListenerListen.Size = New System.Drawing.Size(88, 48)
        Me.cmdListenerListen.TabIndex = 39
        Me.cmdListenerListen.Text = "受信開始"
        Me.cmdListenerListen.UseVisualStyleBackColor = True
        '
        'tmrListenTimer
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMessage)
        Me.GroupBox1.Controls.Add(Me.rdoReturnMessage)
        Me.GroupBox1.Controls.Add(Me.rdoReturnNG)
        Me.GroupBox1.Controls.Add(Me.rdoReturnOK)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(248, 216)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 72)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "受信表示"
        '
        'rdoReturnNG
        '
        Me.rdoReturnNG.AutoSize = True
        Me.rdoReturnNG.Location = New System.Drawing.Point(8, 32)
        Me.rdoReturnNG.Name = "rdoReturnNG"
        Me.rdoReturnNG.Size = New System.Drawing.Size(59, 16)
        Me.rdoReturnNG.TabIndex = 1
        Me.rdoReturnNG.Text = "NG応答"
        Me.rdoReturnNG.UseVisualStyleBackColor = True
        '
        'rdoReturnOK
        '
        Me.rdoReturnOK.AutoSize = True
        Me.rdoReturnOK.Checked = True
        Me.rdoReturnOK.Location = New System.Drawing.Point(8, 16)
        Me.rdoReturnOK.Name = "rdoReturnOK"
        Me.rdoReturnOK.Size = New System.Drawing.Size(71, 16)
        Me.rdoReturnOK.TabIndex = 0
        Me.rdoReturnOK.TabStop = True
        Me.rdoReturnOK.Text = "正常応答"
        Me.rdoReturnOK.UseVisualStyleBackColor = True
        '
        'rdoReturnMessage
        '
        Me.rdoReturnMessage.AutoSize = True
        Me.rdoReturnMessage.Location = New System.Drawing.Point(8, 48)
        Me.rdoReturnMessage.Name = "rdoReturnMessage"
        Me.rdoReturnMessage.Size = New System.Drawing.Size(83, 16)
        Me.rdoReturnMessage.TabIndex = 2
        Me.rdoReturnMessage.Text = "ﾒｯｾｰｼﾞ応答"
        Me.rdoReturnMessage.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(104, 16)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(288, 19)
        Me.txtMessage.TabIndex = 46
        Me.txtMessage.Text = "ほほほい"
        '
        'FRM_299004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 604)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdListenerShutdown)
        Me.Controls.Add(Me.txtListenerSendChr)
        Me.Controls.Add(Me.txtListenerSendText)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtListenerRecvText)
        Me.Controls.Add(Me.txtListenerInterval)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.txtListenerPortNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdListenerSendChr)
        Me.Controls.Add(Me.cmdListenerSend)
        Me.Controls.Add(Me.cmdListenerListen)
        Me.Controls.Add(Me.lstLog)
        Me.Name = "FRM_299004"
        Me.Text = "ｿｹｯﾄ受信ﾂｰﾙ"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstLog As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoListenerASCII As System.Windows.Forms.RadioButton
    Friend WithEvents rdoListenerNormal As System.Windows.Forms.RadioButton
    Friend WithEvents cmdListenerShutdown As System.Windows.Forms.Button
    Friend WithEvents txtListenerSendChr As System.Windows.Forms.TextBox
    Friend WithEvents txtListenerSendText As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtListenerRecvText As System.Windows.Forms.TextBox
    Friend WithEvents txtListenerInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txtListenerPortNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdListenerSendChr As System.Windows.Forms.Button
    Friend WithEvents cmdListenerSend As System.Windows.Forms.Button
    Friend WithEvents cmdListenerListen As System.Windows.Forms.Button
    Friend WithEvents tmrListenTimer As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoReturnMessage As System.Windows.Forms.RadioButton
    Friend WithEvents rdoReturnNG As System.Windows.Forms.RadioButton
    Friend WithEvents rdoReturnOK As System.Windows.Forms.RadioButton
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
End Class
