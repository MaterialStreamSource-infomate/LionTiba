<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMelsecTool
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnConnect = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnSlct = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnConn = New System.Windows.Forms.Button
        Me.lblAdrs = New System.Windows.Forms.Label
        Me.lblPort = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtAdrs = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblKyok = New System.Windows.Forms.Label
        Me.txtKyok = New System.Windows.Forms.TextBox
        Me.cboDevi = New System.Windows.Forms.ComboBox
        Me.lblDevi = New System.Windows.Forms.Label
        Me.txtDevN = New System.Windows.Forms.TextBox
        Me.lblCpuN = New System.Windows.Forms.Label
        Me.txtCpuN = New System.Windows.Forms.TextBox
        Me.lblDevC = New System.Windows.Forms.Label
        Me.txtDevC = New System.Windows.Forms.TextBox
        Me.btnWrite = New System.Windows.Forms.Button
        Me.btnRead = New System.Windows.Forms.Button
        Me.objGrid = New System.Windows.Forms.DataGrid
        Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.objGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConnect)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 64)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(112, 40)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(40, 20)
        Me.btnConnect.TabIndex = 18
        Me.btnConnect.Text = "接続"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(0, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(160, 88)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'btnSlct
        '
        Me.btnSlct.Location = New System.Drawing.Point(112, 64)
        Me.btnSlct.Name = "btnSlct"
        Me.btnSlct.Size = New System.Drawing.Size(40, 20)
        Me.btnSlct.TabIndex = 19
        Me.btnSlct.Text = "確定"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.btnWrite)
        Me.Panel1.Controls.Add(Me.btnRead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 192)
        Me.Panel1.TabIndex = 22
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnConn)
        Me.GroupBox3.Controls.Add(Me.lblAdrs)
        Me.GroupBox3.Controls.Add(Me.lblPort)
        Me.GroupBox3.Controls.Add(Me.txtPort)
        Me.GroupBox3.Controls.Add(Me.txtAdrs)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(160, 64)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        '
        'btnConn
        '
        Me.btnConn.Location = New System.Drawing.Point(112, 40)
        Me.btnConn.Name = "btnConn"
        Me.btnConn.Size = New System.Drawing.Size(40, 20)
        Me.btnConn.TabIndex = 18
        Me.btnConn.Text = "接続"
        '
        'lblAdrs
        '
        Me.lblAdrs.Location = New System.Drawing.Point(8, 16)
        Me.lblAdrs.Name = "lblAdrs"
        Me.lblAdrs.Size = New System.Drawing.Size(56, 16)
        Me.lblAdrs.TabIndex = 1
        Me.lblAdrs.Text = "IPｱﾄﾞﾚｽ"
        '
        'lblPort
        '
        Me.lblPort.Location = New System.Drawing.Point(8, 40)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(56, 16)
        Me.lblPort.TabIndex = 3
        Me.lblPort.Text = "ﾎﾟｰﾄ番号"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(64, 40)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(40, 19)
        Me.txtPort.TabIndex = 2
        Me.txtPort.Text = "30001"
        '
        'txtAdrs
        '
        Me.txtAdrs.Location = New System.Drawing.Point(64, 16)
        Me.txtAdrs.Name = "txtAdrs"
        Me.txtAdrs.Size = New System.Drawing.Size(88, 19)
        Me.txtAdrs.TabIndex = 0
        Me.txtAdrs.Text = "157.11.144.71"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblKyok)
        Me.GroupBox4.Controls.Add(Me.txtKyok)
        Me.GroupBox4.Controls.Add(Me.btnSlct)
        Me.GroupBox4.Controls.Add(Me.cboDevi)
        Me.GroupBox4.Controls.Add(Me.lblDevi)
        Me.GroupBox4.Controls.Add(Me.txtDevN)
        Me.GroupBox4.Controls.Add(Me.lblCpuN)
        Me.GroupBox4.Controls.Add(Me.txtCpuN)
        Me.GroupBox4.Controls.Add(Me.lblDevC)
        Me.GroupBox4.Controls.Add(Me.txtDevC)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 66)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(160, 88)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        '
        'lblKyok
        '
        Me.lblKyok.Location = New System.Drawing.Point(94, 19)
        Me.lblKyok.Name = "lblKyok"
        Me.lblKyok.Size = New System.Drawing.Size(32, 16)
        Me.lblKyok.TabIndex = 21
        Me.lblKyok.Text = "局番"
        '
        'txtKyok
        '
        Me.txtKyok.Location = New System.Drawing.Point(128, 16)
        Me.txtKyok.Name = "txtKyok"
        Me.txtKyok.Size = New System.Drawing.Size(24, 19)
        Me.txtKyok.TabIndex = 20
        Me.txtKyok.Text = "1"
        '
        'cboDevi
        '
        Me.cboDevi.Location = New System.Drawing.Point(64, 40)
        Me.cboDevi.Name = "cboDevi"
        Me.cboDevi.Size = New System.Drawing.Size(40, 20)
        Me.cboDevi.TabIndex = 14
        Me.cboDevi.Text = "D"
        '
        'lblDevi
        '
        Me.lblDevi.Location = New System.Drawing.Point(8, 40)
        Me.lblDevi.Name = "lblDevi"
        Me.lblDevi.Size = New System.Drawing.Size(56, 16)
        Me.lblDevi.TabIndex = 7
        Me.lblDevi.Text = "ﾃﾞﾊﾞｲｽ"
        '
        'txtDevN
        '
        Me.txtDevN.Location = New System.Drawing.Point(104, 40)
        Me.txtDevN.Name = "txtDevN"
        Me.txtDevN.Size = New System.Drawing.Size(48, 19)
        Me.txtDevN.TabIndex = 6
        Me.txtDevN.Text = "0000"
        '
        'lblCpuN
        '
        Me.lblCpuN.Location = New System.Drawing.Point(8, 19)
        Me.lblCpuN.Name = "lblCpuN"
        Me.lblCpuN.Size = New System.Drawing.Size(56, 16)
        Me.lblCpuN.TabIndex = 5
        Me.lblCpuN.Text = "CPU番号"
        '
        'txtCpuN
        '
        Me.txtCpuN.Location = New System.Drawing.Point(64, 16)
        Me.txtCpuN.Name = "txtCpuN"
        Me.txtCpuN.Size = New System.Drawing.Size(24, 19)
        Me.txtCpuN.TabIndex = 4
        Me.txtCpuN.Text = "1"
        '
        'lblDevC
        '
        Me.lblDevC.Location = New System.Drawing.Point(8, 64)
        Me.lblDevC.Name = "lblDevC"
        Me.lblDevC.Size = New System.Drawing.Size(56, 16)
        Me.lblDevC.TabIndex = 10
        Me.lblDevC.Text = "点数"
        '
        'txtDevC
        '
        Me.txtDevC.Location = New System.Drawing.Point(64, 64)
        Me.txtDevC.Name = "txtDevC"
        Me.txtDevC.Size = New System.Drawing.Size(24, 19)
        Me.txtDevC.TabIndex = 13
        Me.txtDevC.Text = "16"
        '
        'btnWrite
        '
        Me.btnWrite.Location = New System.Drawing.Point(88, 160)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(64, 24)
        Me.btnWrite.TabIndex = 19
        Me.btnWrite.Text = "Write"
        '
        'btnRead
        '
        Me.btnRead.Location = New System.Drawing.Point(8, 160)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(64, 24)
        Me.btnRead.TabIndex = 17
        Me.btnRead.Text = "Read"
        '
        'objGrid
        '
        Me.objGrid.DataMember = ""
        Me.objGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.objGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.objGrid.Location = New System.Drawing.Point(0, 192)
        Me.objGrid.Name = "objGrid"
        Me.objGrid.Size = New System.Drawing.Size(160, 261)
        Me.objGrid.TabIndex = 23
        '
        'tmrTimer
        '
        '
        'frmMelsecTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(160, 453)
        Me.Controls.Add(Me.objGrid)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMelsecTool"
        Me.Text = "frmMelsecTool"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.objGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSlct As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConn As System.Windows.Forms.Button
    Friend WithEvents lblAdrs As System.Windows.Forms.Label
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrs As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblKyok As System.Windows.Forms.Label
    Friend WithEvents txtKyok As System.Windows.Forms.TextBox
    Friend WithEvents cboDevi As System.Windows.Forms.ComboBox
    Friend WithEvents lblDevi As System.Windows.Forms.Label
    Friend WithEvents txtDevN As System.Windows.Forms.TextBox
    Friend WithEvents lblCpuN As System.Windows.Forms.Label
    Friend WithEvents txtCpuN As System.Windows.Forms.TextBox
    Friend WithEvents lblDevC As System.Windows.Forms.Label
    Friend WithEvents txtDevC As System.Windows.Forms.TextBox
    Friend WithEvents btnWrite As System.Windows.Forms.Button
    Friend WithEvents btnRead As System.Windows.Forms.Button
    Friend WithEvents objGrid As System.Windows.Forms.DataGrid
    Friend WithEvents tmrTimer As System.Windows.Forms.Timer
End Class
