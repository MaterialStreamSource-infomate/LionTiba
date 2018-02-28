<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRS232C
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
        Me.cmdSend = New System.Windows.Forms.Button
        Me.cmdPortClose = New System.Windows.Forms.Button
        Me.cmdPortOpen = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSend = New System.Windows.Forms.TextBox
        Me.txtStopBit = New System.Windows.Forms.TextBox
        Me.txtParity = New System.Windows.Forms.TextBox
        Me.txtDataLength = New System.Windows.Forms.TextBox
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtBaud = New System.Windows.Forms.TextBox
        Me.lstLog = New System.Windows.Forms.ListBox
        Me.txtRecvText = New System.Windows.Forms.TextBox
        Me.txtSendChr = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdSendChr = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdoASCII = New System.Windows.Forms.RadioButton
        Me.rdoNormal = New System.Windows.Forms.RadioButton
        Me.txtInterval = New System.Windows.Forms.TextBox
        Me.tmrReceive = New System.Windows.Forms.Timer(Me.components)
        Me.chkRTS = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkDTR = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkCD = New System.Windows.Forms.CheckBox
        Me.chkCTS = New System.Windows.Forms.CheckBox
        Me.chkDSR = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdAnalysis = New System.Windows.Forms.Button
        Me.cmdYasukawaSend = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSend
        '
        Me.cmdSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSend.Location = New System.Drawing.Point(560, 640)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(104, 24)
        Me.cmdSend.TabIndex = 20
        Me.cmdSend.Text = "ﾃｷｽﾄ送信"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'cmdPortClose
        '
        Me.cmdPortClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPortClose.Location = New System.Drawing.Point(664, 640)
        Me.cmdPortClose.Name = "cmdPortClose"
        Me.cmdPortClose.Size = New System.Drawing.Size(88, 48)
        Me.cmdPortClose.TabIndex = 18
        Me.cmdPortClose.Text = "ﾎﾟｰﾄｸﾛｰｽﾞ"
        Me.cmdPortClose.UseVisualStyleBackColor = True
        '
        'cmdPortOpen
        '
        Me.cmdPortOpen.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPortOpen.Location = New System.Drawing.Point(472, 640)
        Me.cmdPortOpen.Name = "cmdPortOpen"
        Me.cmdPortOpen.Size = New System.Drawing.Size(88, 48)
        Me.cmdPortOpen.TabIndex = 19
        Me.cmdPortOpen.Text = "ﾎﾟｰﾄｵｰﾌﾟﾝ"
        Me.cmdPortOpen.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(168, 456)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(248, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "(0:None 1:One 2:Two 3:OnePointFive)"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 496)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 56)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "送信ﾃｷｽﾄ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 448)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "ｽﾄｯﾌﾟﾋﾞｯﾄ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(168, 408)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(464, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "(0:None 1:Odd(奇数) 2:Even(偶数) 3:Mark(常に1) 4:Space(常に0))"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 400)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 19)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "ﾊﾟﾘﾃｨ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 424)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 19)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "ﾃﾞｰﾀ長"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 352)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 19)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "ﾎﾟｰﾄ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 376)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "ﾎﾞｰﾚｰﾄ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSend
        '
        Me.txtSend.AcceptsReturn = True
        Me.txtSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSend.Location = New System.Drawing.Point(96, 496)
        Me.txtSend.Multiline = True
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(656, 56)
        Me.txtSend.TabIndex = 6
        '
        'txtStopBit
        '
        Me.txtStopBit.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtStopBit.Location = New System.Drawing.Point(96, 448)
        Me.txtStopBit.Name = "txtStopBit"
        Me.txtStopBit.Size = New System.Drawing.Size(64, 19)
        Me.txtStopBit.TabIndex = 5
        Me.txtStopBit.Text = "2"
        '
        'txtParity
        '
        Me.txtParity.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtParity.Location = New System.Drawing.Point(96, 400)
        Me.txtParity.Name = "txtParity"
        Me.txtParity.Size = New System.Drawing.Size(64, 19)
        Me.txtParity.TabIndex = 4
        Me.txtParity.Text = "0"
        '
        'txtDataLength
        '
        Me.txtDataLength.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDataLength.Location = New System.Drawing.Point(96, 424)
        Me.txtDataLength.Name = "txtDataLength"
        Me.txtDataLength.Size = New System.Drawing.Size(64, 19)
        Me.txtDataLength.TabIndex = 9
        Me.txtDataLength.Text = "8"
        '
        'txtPort
        '
        Me.txtPort.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPort.Location = New System.Drawing.Point(96, 352)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(64, 19)
        Me.txtPort.TabIndex = 8
        Me.txtPort.Text = "COM4"
        '
        'txtBaud
        '
        Me.txtBaud.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBaud.Location = New System.Drawing.Point(96, 376)
        Me.txtBaud.Name = "txtBaud"
        Me.txtBaud.Size = New System.Drawing.Size(64, 19)
        Me.txtBaud.TabIndex = 7
        Me.txtBaud.Text = "9600"
        '
        'lstLog
        '
        Me.lstLog.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.HorizontalScrollbar = True
        Me.lstLog.ItemHeight = 12
        Me.lstLog.Location = New System.Drawing.Point(0, 8)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(752, 328)
        Me.lstLog.TabIndex = 23
        '
        'txtRecvText
        '
        Me.txtRecvText.AcceptsReturn = True
        Me.txtRecvText.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtRecvText.Location = New System.Drawing.Point(96, 588)
        Me.txtRecvText.Multiline = True
        Me.txtRecvText.Name = "txtRecvText"
        Me.txtRecvText.Size = New System.Drawing.Size(656, 48)
        Me.txtRecvText.TabIndex = 6
        '
        'txtSendChr
        '
        Me.txtSendChr.AcceptsReturn = True
        Me.txtSendChr.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSendChr.Location = New System.Drawing.Point(96, 552)
        Me.txtSendChr.Multiline = True
        Me.txtSendChr.Name = "txtSendChr"
        Me.txtSendChr.Size = New System.Drawing.Size(656, 36)
        Me.txtSendChr.TabIndex = 6
        Me.txtSendChr.Text = "04,03,21,06,00,01,6e,62"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 552)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 24)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "送信ﾃｷｽﾄ(Chr)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(34, 588)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 48)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "受信ﾃｷｽﾄ"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSendChr
        '
        Me.cmdSendChr.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSendChr.Location = New System.Drawing.Point(560, 664)
        Me.cmdSendChr.Name = "cmdSendChr"
        Me.cmdSendChr.Size = New System.Drawing.Size(104, 24)
        Me.cmdSendChr.TabIndex = 20
        Me.cmdSendChr.Text = "ﾃｷｽﾄ送信(Chr)"
        Me.cmdSendChr.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoASCII)
        Me.GroupBox1.Controls.Add(Me.rdoNormal)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(354, 640)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(112, 56)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "受信表示"
        '
        'rdoASCII
        '
        Me.rdoASCII.AutoSize = True
        Me.rdoASCII.Checked = True
        Me.rdoASCII.Location = New System.Drawing.Point(8, 32)
        Me.rdoASCII.Name = "rdoASCII"
        Me.rdoASCII.Size = New System.Drawing.Size(95, 16)
        Me.rdoASCII.TabIndex = 1
        Me.rdoASCII.TabStop = True
        Me.rdoASCII.Text = "制御文字表示"
        Me.rdoASCII.UseVisualStyleBackColor = True
        '
        'rdoNormal
        '
        Me.rdoNormal.AutoSize = True
        Me.rdoNormal.Location = New System.Drawing.Point(8, 16)
        Me.rdoNormal.Name = "rdoNormal"
        Me.rdoNormal.Size = New System.Drawing.Size(47, 16)
        Me.rdoNormal.TabIndex = 0
        Me.rdoNormal.Text = "ﾉｰﾏﾙ"
        Me.rdoNormal.UseVisualStyleBackColor = True
        '
        'txtInterval
        '
        Me.txtInterval.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInterval.Location = New System.Drawing.Point(96, 472)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(64, 19)
        Me.txtInterval.TabIndex = 27
        Me.txtInterval.Text = "100"
        '
        'tmrReceive
        '
        '
        'chkRTS
        '
        Me.chkRTS.AutoSize = True
        Me.chkRTS.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!)
        Me.chkRTS.Location = New System.Drawing.Point(6, 18)
        Me.chkRTS.Name = "chkRTS"
        Me.chkRTS.Size = New System.Drawing.Size(42, 16)
        Me.chkRTS.TabIndex = 29
        Me.chkRTS.Text = "RTS"
        Me.chkRTS.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkDTR)
        Me.GroupBox2.Controls.Add(Me.chkRTS)
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(187, 352)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 43)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ﾗｲﾝ状態(出力)"
        '
        'chkDTR
        '
        Me.chkDTR.AutoSize = True
        Me.chkDTR.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!)
        Me.chkDTR.Location = New System.Drawing.Point(63, 18)
        Me.chkDTR.Name = "chkDTR"
        Me.chkDTR.Size = New System.Drawing.Size(42, 16)
        Me.chkDTR.TabIndex = 30
        Me.chkDTR.Text = "DTR"
        Me.chkDTR.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkCD)
        Me.GroupBox3.Controls.Add(Me.chkCTS)
        Me.GroupBox3.Controls.Add(Me.chkDSR)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(329, 354)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(303, 43)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ﾗｲﾝ状態(入力)(表示のみ)"
        '
        'chkCD
        '
        Me.chkCD.AutoSize = True
        Me.chkCD.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!)
        Me.chkCD.Location = New System.Drawing.Point(234, 18)
        Me.chkCD.Name = "chkCD"
        Me.chkCD.Size = New System.Drawing.Size(36, 16)
        Me.chkCD.TabIndex = 30
        Me.chkCD.Text = "CD"
        Me.chkCD.UseVisualStyleBackColor = True
        '
        'chkCTS
        '
        Me.chkCTS.AutoSize = True
        Me.chkCTS.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!)
        Me.chkCTS.Location = New System.Drawing.Point(120, 18)
        Me.chkCTS.Name = "chkCTS"
        Me.chkCTS.Size = New System.Drawing.Size(108, 16)
        Me.chkCTS.TabIndex = 30
        Me.chkCTS.Text = "CTS(RTSと連動)"
        Me.chkCTS.UseVisualStyleBackColor = True
        '
        'chkDSR
        '
        Me.chkDSR.AutoSize = True
        Me.chkDSR.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!)
        Me.chkDSR.Location = New System.Drawing.Point(6, 18)
        Me.chkDSR.Name = "chkDSR"
        Me.chkDSR.Size = New System.Drawing.Size(108, 16)
        Me.chkDSR.TabIndex = 29
        Me.chkDSR.Text = "DSR(DTRと連動)"
        Me.chkDSR.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 472)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 19)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "ﾊﾞｯﾌｧ検索ﾀｲﾏｰ"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAnalysis
        '
        Me.cmdAnalysis.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdAnalysis.Location = New System.Drawing.Point(664, 456)
        Me.cmdAnalysis.Name = "cmdAnalysis"
        Me.cmdAnalysis.Size = New System.Drawing.Size(88, 35)
        Me.cmdAnalysis.TabIndex = 33
        Me.cmdAnalysis.Text = "解析"
        Me.cmdAnalysis.UseVisualStyleBackColor = True
        '
        'cmdYasukawaSend
        '
        Me.cmdYasukawaSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdYasukawaSend.Location = New System.Drawing.Point(664, 416)
        Me.cmdYasukawaSend.Name = "cmdYasukawaSend"
        Me.cmdYasukawaSend.Size = New System.Drawing.Size(88, 35)
        Me.cmdYasukawaSend.TabIndex = 34
        Me.cmdYasukawaSend.Text = "安川電文送信"
        Me.cmdYasukawaSend.UseVisualStyleBackColor = True
        '
        'frmRS232C
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 702)
        Me.Controls.Add(Me.cmdAnalysis)
        Me.Controls.Add(Me.cmdYasukawaSend)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtInterval)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstLog)
        Me.Controls.Add(Me.cmdSendChr)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.cmdPortClose)
        Me.Controls.Add(Me.cmdPortOpen)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSendChr)
        Me.Controls.Add(Me.txtRecvText)
        Me.Controls.Add(Me.txtSend)
        Me.Controls.Add(Me.txtStopBit)
        Me.Controls.Add(Me.txtParity)
        Me.Controls.Add(Me.txtDataLength)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtBaud)
        Me.Name = "frmRS232C"
        Me.Text = "frmRS232C"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents cmdPortClose As System.Windows.Forms.Button
    Friend WithEvents cmdPortOpen As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
    Friend WithEvents txtStopBit As System.Windows.Forms.TextBox
    Friend WithEvents txtParity As System.Windows.Forms.TextBox
    Friend WithEvents txtDataLength As System.Windows.Forms.TextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtBaud As System.Windows.Forms.TextBox
    Friend WithEvents lstLog As System.Windows.Forms.ListBox
    Friend WithEvents txtRecvText As System.Windows.Forms.TextBox
    Friend WithEvents txtSendChr As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdSendChr As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoASCII As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNormal As System.Windows.Forms.RadioButton
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents tmrReceive As System.Windows.Forms.Timer
    Friend WithEvents chkRTS As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDTR As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCD As System.Windows.Forms.CheckBox
    Friend WithEvents chkCTS As System.Windows.Forms.CheckBox
    Friend WithEvents chkDSR As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdAnalysis As System.Windows.Forms.Button
    Friend WithEvents cmdYasukawaSend As System.Windows.Forms.Button
End Class
