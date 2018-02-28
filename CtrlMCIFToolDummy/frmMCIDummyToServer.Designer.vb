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
        Me.chkCraneStatusAutoUpdate = New System.Windows.Forms.CheckBox
        Me.cmd01 = New System.Windows.Forms.Button
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkResponseAuto = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtLCCRN0402_STATE = New System.Windows.Forms.TextBox
        Me.txtLCCRN0401_STATE = New System.Windows.Forms.TextBox
        Me.txtLCCRN0402_RES = New System.Windows.Forms.TextBox
        Me.txtLCCRN0401_RES = New System.Windows.Forms.TextBox
        Me.txtLCCRN03_UNU = New System.Windows.Forms.TextBox
        Me.txtLCCRN03_RES = New System.Windows.Forms.TextBox
        Me.txtLCCRN02_UNU = New System.Windows.Forms.TextBox
        Me.txtLCCRN02_RES = New System.Windows.Forms.TextBox
        Me.txtLCCRN01_UNU = New System.Windows.Forms.TextBox
        Me.txtLCCRN01_RES = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmd02 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkResponseAuto_02 = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtLCCRN0402_STATE_02 = New System.Windows.Forms.TextBox
        Me.txtLCCRN0401_STATE_02 = New System.Windows.Forms.TextBox
        Me.txtLCCRN0402_RES_02 = New System.Windows.Forms.TextBox
        Me.txtLCCRN0401_RES_02 = New System.Windows.Forms.TextBox
        Me.txtLCCRN03_UNU_02 = New System.Windows.Forms.TextBox
        Me.txtLCCRN03_RES_02 = New System.Windows.Forms.TextBox
        Me.txtLCCRN02_UNU_02 = New System.Windows.Forms.TextBox
        Me.txtLCCRN02_RES_02 = New System.Windows.Forms.TextBox
        Me.txtLCCRN01_UNU_02 = New System.Windows.Forms.TextBox
        Me.txtLCCRN01_RES_02 = New System.Windows.Forms.TextBox
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.cmdClose.Location = New System.Drawing.Point(672, 608)
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
        Me.cmdIcon.Location = New System.Drawing.Point(672, 576)
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
        Me.GroupBox4.Controls.Add(Me.chkCraneStatusAutoUpdate)
        Me.GroupBox4.Controls.Add(Me.cmd01)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.chkResponseAuto)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN0402_STATE)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN0401_STATE)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN0402_RES)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN0401_RES)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN03_UNU)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN03_RES)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN02_UNU)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN02_RES)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN01_UNU)
        Me.GroupBox4.Controls.Add(Me.txtLCCRN01_RES)
        Me.GroupBox4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(352, 240)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "問合せﾒｯｾｰｼﾞに対する応答"
        '
        'chkCraneStatusAutoUpdate
        '
        Me.chkCraneStatusAutoUpdate.AutoSize = True
        Me.chkCraneStatusAutoUpdate.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkCraneStatusAutoUpdate.Location = New System.Drawing.Point(216, 24)
        Me.chkCraneStatusAutoUpdate.Name = "chkCraneStatusAutoUpdate"
        Me.chkCraneStatusAutoUpdate.Size = New System.Drawing.Size(120, 16)
        Me.chkCraneStatusAutoUpdate.TabIndex = 549
        Me.chkCraneStatusAutoUpdate.Text = "ｸﾚｰﾝ状態自動更新"
        Me.chkCraneStatusAutoUpdate.UseVisualStyleBackColor = True
        '
        'cmd01
        '
        Me.cmd01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmd01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd01.Location = New System.Drawing.Point(152, 208)
        Me.cmd01.Name = "cmd01"
        Me.cmd01.Size = New System.Drawing.Size(64, 24)
        Me.cmd01.TabIndex = 548
        Me.cmd01.Text = "送信"
        Me.cmd01.UseVisualStyleBackColor = False
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(8, 152)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(128, 16)
        Me.Label29.TabIndex = 545
        Me.Label29.Text = "ｸﾚｰﾝ4台車2応答"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 56)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(128, 16)
        Me.Label28.TabIndex = 543
        Me.Label28.Text = "ｸﾚｰﾝ1異常ｺｰﾄﾞ"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.Location = New System.Drawing.Point(8, 184)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(128, 16)
        Me.Label27.TabIndex = 537
        Me.Label27.Text = "ｸﾚｰﾝ4台車2状態"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 168)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 16)
        Me.Label15.TabIndex = 535
        Me.Label15.Text = "ｸﾚｰﾝ4台車1状態"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 136)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(128, 16)
        Me.Label24.TabIndex = 534
        Me.Label24.Text = "ｸﾚｰﾝ4台車1応答"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 16)
        Me.Label12.TabIndex = 531
        Me.Label12.Text = "ｸﾚｰﾝ3異常ｺｰﾄﾞ"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 16)
        Me.Label13.TabIndex = 530
        Me.Label13.Text = "ｸﾚｰﾝ3応答"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkResponseAuto
        '
        Me.chkResponseAuto.AutoSize = True
        Me.chkResponseAuto.Checked = True
        Me.chkResponseAuto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkResponseAuto.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkResponseAuto.Location = New System.Drawing.Point(16, 24)
        Me.chkResponseAuto.Name = "chkResponseAuto"
        Me.chkResponseAuto.Size = New System.Drawing.Size(72, 16)
        Me.chkResponseAuto.TabIndex = 527
        Me.chkResponseAuto.Text = "自動応答"
        Me.chkResponseAuto.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 16)
        Me.Label14.TabIndex = 372
        Me.Label14.Text = "ｸﾚｰﾝ2異常ｺｰﾄﾞ"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(176, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(160, 16)
        Me.Label11.TabIndex = 368
        Me.Label11.Text = "91:二重格納　92:空出庫"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 16)
        Me.Label16.TabIndex = 368
        Me.Label16.Text = "ｸﾚｰﾝ1応答"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 72)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(128, 16)
        Me.Label23.TabIndex = 369
        Me.Label23.Text = "ｸﾚｰﾝ2応答"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLCCRN0402_STATE
        '
        Me.txtLCCRN0402_STATE.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN0402_STATE.Location = New System.Drawing.Point(136, 184)
        Me.txtLCCRN0402_STATE.MaxLength = 2
        Me.txtLCCRN0402_STATE.Name = "txtLCCRN0402_STATE"
        Me.txtLCCRN0402_STATE.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN0402_STATE.TabIndex = 9
        Me.txtLCCRN0402_STATE.Text = "00"
        '
        'txtLCCRN0401_STATE
        '
        Me.txtLCCRN0401_STATE.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN0401_STATE.Location = New System.Drawing.Point(136, 168)
        Me.txtLCCRN0401_STATE.MaxLength = 2
        Me.txtLCCRN0401_STATE.Name = "txtLCCRN0401_STATE"
        Me.txtLCCRN0401_STATE.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN0401_STATE.TabIndex = 8
        Me.txtLCCRN0401_STATE.Text = "00"
        '
        'txtLCCRN0402_RES
        '
        Me.txtLCCRN0402_RES.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN0402_RES.Location = New System.Drawing.Point(136, 152)
        Me.txtLCCRN0402_RES.MaxLength = 1
        Me.txtLCCRN0402_RES.Name = "txtLCCRN0402_RES"
        Me.txtLCCRN0402_RES.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN0402_RES.TabIndex = 7
        Me.txtLCCRN0402_RES.Text = "1"
        '
        'txtLCCRN0401_RES
        '
        Me.txtLCCRN0401_RES.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN0401_RES.Location = New System.Drawing.Point(136, 136)
        Me.txtLCCRN0401_RES.MaxLength = 1
        Me.txtLCCRN0401_RES.Name = "txtLCCRN0401_RES"
        Me.txtLCCRN0401_RES.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN0401_RES.TabIndex = 6
        Me.txtLCCRN0401_RES.Text = "1"
        '
        'txtLCCRN03_UNU
        '
        Me.txtLCCRN03_UNU.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN03_UNU.Location = New System.Drawing.Point(136, 120)
        Me.txtLCCRN03_UNU.MaxLength = 2
        Me.txtLCCRN03_UNU.Name = "txtLCCRN03_UNU"
        Me.txtLCCRN03_UNU.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN03_UNU.TabIndex = 5
        Me.txtLCCRN03_UNU.Text = "00"
        '
        'txtLCCRN03_RES
        '
        Me.txtLCCRN03_RES.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN03_RES.Location = New System.Drawing.Point(136, 104)
        Me.txtLCCRN03_RES.MaxLength = 1
        Me.txtLCCRN03_RES.Name = "txtLCCRN03_RES"
        Me.txtLCCRN03_RES.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN03_RES.TabIndex = 4
        Me.txtLCCRN03_RES.Text = "1"
        '
        'txtLCCRN02_UNU
        '
        Me.txtLCCRN02_UNU.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN02_UNU.Location = New System.Drawing.Point(136, 88)
        Me.txtLCCRN02_UNU.MaxLength = 2
        Me.txtLCCRN02_UNU.Name = "txtLCCRN02_UNU"
        Me.txtLCCRN02_UNU.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN02_UNU.TabIndex = 3
        Me.txtLCCRN02_UNU.Text = "00"
        '
        'txtLCCRN02_RES
        '
        Me.txtLCCRN02_RES.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN02_RES.Location = New System.Drawing.Point(136, 72)
        Me.txtLCCRN02_RES.MaxLength = 1
        Me.txtLCCRN02_RES.Name = "txtLCCRN02_RES"
        Me.txtLCCRN02_RES.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN02_RES.TabIndex = 2
        Me.txtLCCRN02_RES.Text = "1"
        '
        'txtLCCRN01_UNU
        '
        Me.txtLCCRN01_UNU.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN01_UNU.Location = New System.Drawing.Point(136, 56)
        Me.txtLCCRN01_UNU.MaxLength = 2
        Me.txtLCCRN01_UNU.Name = "txtLCCRN01_UNU"
        Me.txtLCCRN01_UNU.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN01_UNU.TabIndex = 1
        Me.txtLCCRN01_UNU.Text = "00"
        '
        'txtLCCRN01_RES
        '
        Me.txtLCCRN01_RES.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN01_RES.Location = New System.Drawing.Point(136, 40)
        Me.txtLCCRN01_RES.MaxLength = 1
        Me.txtLCCRN01_RES.Name = "txtLCCRN01_RES"
        Me.txtLCCRN01_RES.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN01_RES.TabIndex = 0
        Me.txtLCCRN01_RES.Text = "1"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.cmd02)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chkResponseAuto_02)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN0402_STATE_02)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN0401_STATE_02)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN0402_RES_02)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN0401_RES_02)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN03_UNU_02)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN03_RES_02)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN02_UNU_02)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN02_RES_02)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN01_UNU_02)
        Me.GroupBox1.Controls.Add(Me.txtLCCRN01_RES_02)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 240)
        Me.GroupBox1.TabIndex = 546
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "その他ﾒｯｾｰｼﾞに対する応答"
        '
        'cmd02
        '
        Me.cmd02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmd02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd02.Location = New System.Drawing.Point(152, 208)
        Me.cmd02.Name = "cmd02"
        Me.cmd02.Size = New System.Drawing.Size(64, 24)
        Me.cmd02.TabIndex = 547
        Me.cmd02.Text = "送信"
        Me.cmd02.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 16)
        Me.Label1.TabIndex = 545
        Me.Label1.Text = "ｸﾚｰﾝ4台車2応答"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 543
        Me.Label2.Text = "ｸﾚｰﾝ1異常ｺｰﾄﾞ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 537
        Me.Label3.Text = "ｸﾚｰﾝ4台車2状態"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 16)
        Me.Label4.TabIndex = 535
        Me.Label4.Text = "ｸﾚｰﾝ4台車1状態"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 16)
        Me.Label5.TabIndex = 534
        Me.Label5.Text = "ｸﾚｰﾝ4台車1応答"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 16)
        Me.Label6.TabIndex = 531
        Me.Label6.Text = "ｸﾚｰﾝ3異常ｺｰﾄﾞ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 16)
        Me.Label7.TabIndex = 530
        Me.Label7.Text = "ｸﾚｰﾝ3応答"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkResponseAuto_02
        '
        Me.chkResponseAuto_02.AutoSize = True
        Me.chkResponseAuto_02.Checked = True
        Me.chkResponseAuto_02.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkResponseAuto_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkResponseAuto_02.Location = New System.Drawing.Point(16, 24)
        Me.chkResponseAuto_02.Name = "chkResponseAuto_02"
        Me.chkResponseAuto_02.Size = New System.Drawing.Size(72, 16)
        Me.chkResponseAuto_02.TabIndex = 527
        Me.chkResponseAuto_02.Text = "自動応答"
        Me.chkResponseAuto_02.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 16)
        Me.Label8.TabIndex = 372
        Me.Label8.Text = "ｸﾚｰﾝ2異常ｺｰﾄﾞ"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 16)
        Me.Label9.TabIndex = 368
        Me.Label9.Text = "ｸﾚｰﾝ1応答"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 16)
        Me.Label10.TabIndex = 369
        Me.Label10.Text = "ｸﾚｰﾝ2応答"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLCCRN0402_STATE_02
        '
        Me.txtLCCRN0402_STATE_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN0402_STATE_02.Location = New System.Drawing.Point(136, 184)
        Me.txtLCCRN0402_STATE_02.MaxLength = 2
        Me.txtLCCRN0402_STATE_02.Name = "txtLCCRN0402_STATE_02"
        Me.txtLCCRN0402_STATE_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN0402_STATE_02.TabIndex = 9
        Me.txtLCCRN0402_STATE_02.Text = "00"
        '
        'txtLCCRN0401_STATE_02
        '
        Me.txtLCCRN0401_STATE_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN0401_STATE_02.Location = New System.Drawing.Point(136, 168)
        Me.txtLCCRN0401_STATE_02.MaxLength = 2
        Me.txtLCCRN0401_STATE_02.Name = "txtLCCRN0401_STATE_02"
        Me.txtLCCRN0401_STATE_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN0401_STATE_02.TabIndex = 8
        Me.txtLCCRN0401_STATE_02.Text = "00"
        '
        'txtLCCRN0402_RES_02
        '
        Me.txtLCCRN0402_RES_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN0402_RES_02.Location = New System.Drawing.Point(136, 152)
        Me.txtLCCRN0402_RES_02.MaxLength = 1
        Me.txtLCCRN0402_RES_02.Name = "txtLCCRN0402_RES_02"
        Me.txtLCCRN0402_RES_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN0402_RES_02.TabIndex = 7
        Me.txtLCCRN0402_RES_02.Text = "0"
        '
        'txtLCCRN0401_RES_02
        '
        Me.txtLCCRN0401_RES_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN0401_RES_02.Location = New System.Drawing.Point(136, 136)
        Me.txtLCCRN0401_RES_02.MaxLength = 1
        Me.txtLCCRN0401_RES_02.Name = "txtLCCRN0401_RES_02"
        Me.txtLCCRN0401_RES_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN0401_RES_02.TabIndex = 6
        Me.txtLCCRN0401_RES_02.Text = "0"
        '
        'txtLCCRN03_UNU_02
        '
        Me.txtLCCRN03_UNU_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN03_UNU_02.Location = New System.Drawing.Point(136, 120)
        Me.txtLCCRN03_UNU_02.MaxLength = 2
        Me.txtLCCRN03_UNU_02.Name = "txtLCCRN03_UNU_02"
        Me.txtLCCRN03_UNU_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN03_UNU_02.TabIndex = 5
        Me.txtLCCRN03_UNU_02.Text = "00"
        '
        'txtLCCRN03_RES_02
        '
        Me.txtLCCRN03_RES_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN03_RES_02.Location = New System.Drawing.Point(136, 104)
        Me.txtLCCRN03_RES_02.MaxLength = 1
        Me.txtLCCRN03_RES_02.Name = "txtLCCRN03_RES_02"
        Me.txtLCCRN03_RES_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN03_RES_02.TabIndex = 4
        Me.txtLCCRN03_RES_02.Text = "0"
        '
        'txtLCCRN02_UNU_02
        '
        Me.txtLCCRN02_UNU_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN02_UNU_02.Location = New System.Drawing.Point(136, 88)
        Me.txtLCCRN02_UNU_02.MaxLength = 2
        Me.txtLCCRN02_UNU_02.Name = "txtLCCRN02_UNU_02"
        Me.txtLCCRN02_UNU_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN02_UNU_02.TabIndex = 3
        Me.txtLCCRN02_UNU_02.Text = "00"
        '
        'txtLCCRN02_RES_02
        '
        Me.txtLCCRN02_RES_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN02_RES_02.Location = New System.Drawing.Point(136, 72)
        Me.txtLCCRN02_RES_02.MaxLength = 1
        Me.txtLCCRN02_RES_02.Name = "txtLCCRN02_RES_02"
        Me.txtLCCRN02_RES_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN02_RES_02.TabIndex = 2
        Me.txtLCCRN02_RES_02.Text = "0"
        '
        'txtLCCRN01_UNU_02
        '
        Me.txtLCCRN01_UNU_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN01_UNU_02.Location = New System.Drawing.Point(136, 56)
        Me.txtLCCRN01_UNU_02.MaxLength = 2
        Me.txtLCCRN01_UNU_02.Name = "txtLCCRN01_UNU_02"
        Me.txtLCCRN01_UNU_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN01_UNU_02.TabIndex = 1
        Me.txtLCCRN01_UNU_02.Text = "00"
        '
        'txtLCCRN01_RES_02
        '
        Me.txtLCCRN01_RES_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLCCRN01_RES_02.Location = New System.Drawing.Point(136, 40)
        Me.txtLCCRN01_RES_02.MaxLength = 1
        Me.txtLCCRN01_RES_02.Name = "txtLCCRN01_RES_02"
        Me.txtLCCRN01_RES_02.Size = New System.Drawing.Size(40, 19)
        Me.txtLCCRN01_RES_02.TabIndex = 0
        Me.txtLCCRN01_RES_02.Text = "0"
        '
        'frmMCIDummyToServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(877, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrDebug As System.Windows.Forms.Timer
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdIcon As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN02_UNU As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN01_RES As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN02_RES As System.Windows.Forms.TextBox
    Friend WithEvents chkResponseAuto As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN03_UNU As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN03_RES As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN0401_STATE As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN0401_RES As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN0402_STATE As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN0402_RES As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN01_UNU As System.Windows.Forms.TextBox
    Friend WithEvents cmd01 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd02 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkResponseAuto_02 As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLCCRN0402_STATE_02 As System.Windows.Forms.TextBox
    Friend WithEvents txtLCCRN0401_STATE_02 As System.Windows.Forms.TextBox
    Friend WithEvents txtLCCRN0402_RES_02 As System.Windows.Forms.TextBox
    Friend WithEvents txtLCCRN0401_RES_02 As System.Windows.Forms.TextBox
    Friend WithEvents txtLCCRN03_UNU_02 As System.Windows.Forms.TextBox
    Friend WithEvents txtLCCRN03_RES_02 As System.Windows.Forms.TextBox
    Friend WithEvents txtLCCRN02_UNU_02 As System.Windows.Forms.TextBox
    Friend WithEvents txtLCCRN02_RES_02 As System.Windows.Forms.TextBox
    Friend WithEvents txtLCCRN01_UNU_02 As System.Windows.Forms.TextBox
    Friend WithEvents txtLCCRN01_RES_02 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkCraneStatusAutoUpdate As System.Windows.Forms.CheckBox
End Class
