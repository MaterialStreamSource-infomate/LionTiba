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
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtBCR01AB_KUBUN = New System.Windows.Forms.TextBox
        Me.txtBCR01KENSA_KUBUN = New System.Windows.Forms.TextBox
        Me.txtBCR01VOL = New System.Windows.Forms.TextBox
        Me.txtBCR01PALLET_NO = New System.Windows.Forms.TextBox
        Me.txtBCR01LINE_CD = New System.Windows.Forms.TextBox
        Me.txtBCR01KOUJYO_NO = New System.Windows.Forms.TextBox
        Me.txtBCR01SEIZOU_DT = New System.Windows.Forms.TextBox
        Me.txtBCR01HINMEI_CD = New System.Windows.Forms.TextBox
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
        Me.GroupBox4.Controls.Add(Me.cmd01)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.txtBCR01AB_KUBUN)
        Me.GroupBox4.Controls.Add(Me.txtBCR01KENSA_KUBUN)
        Me.GroupBox4.Controls.Add(Me.txtBCR01VOL)
        Me.GroupBox4.Controls.Add(Me.txtBCR01PALLET_NO)
        Me.GroupBox4.Controls.Add(Me.txtBCR01LINE_CD)
        Me.GroupBox4.Controls.Add(Me.txtBCR01KOUJYO_NO)
        Me.GroupBox4.Controls.Add(Me.txtBCR01SEIZOU_DT)
        Me.GroupBox4.Controls.Add(Me.txtBCR01HINMEI_CD)
        Me.GroupBox4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(616, 216)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ﾊﾞｰｺｰﾄﾞ情報"
        '
        'cmd01
        '
        Me.cmd01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmd01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd01.Location = New System.Drawing.Point(112, 176)
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
        Me.Label29.Text = "AB区分"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 56)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(128, 16)
        Me.Label28.TabIndex = 543
        Me.Label28.Text = "製造年月日"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 136)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(128, 16)
        Me.Label24.TabIndex = 534
        Me.Label24.Text = "検査区分"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 16)
        Me.Label12.TabIndex = 531
        Me.Label12.Text = "積み数"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 16)
        Me.Label13.TabIndex = 530
        Me.Label13.Text = "ﾊﾟﾚｯﾄ№"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 16)
        Me.Label14.TabIndex = 372
        Me.Label14.Text = "ﾗｲﾝｺｰﾄﾞ"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(184, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(336, 16)
        Me.Label3.TabIndex = 368
        Me.Label3.Text = "【T】一定時間毎にﾊﾟﾚｯﾄ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(184, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(336, 16)
        Me.Label2.TabIndex = 368
        Me.Label2.Text = "【S】品目、ﾗｲﾝ№毎の製造年月日での最初のﾊﾟﾚｯﾄ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(184, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 16)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "【H】S,T,E以外の半製品のﾊﾟﾚｯﾄ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(184, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(336, 16)
        Me.Label11.TabIndex = 368
        Me.Label11.Text = "【E】品目、ﾗｲﾝ№毎の製造年月日での最後のﾊﾟﾚｯﾄ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 16)
        Me.Label16.TabIndex = 368
        Me.Label16.Text = "品名ｺｰﾄﾞ"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 72)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(128, 16)
        Me.Label23.TabIndex = 369
        Me.Label23.Text = "工場№"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBCR01AB_KUBUN
        '
        Me.txtBCR01AB_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBCR01AB_KUBUN.Location = New System.Drawing.Point(136, 152)
        Me.txtBCR01AB_KUBUN.MaxLength = 1
        Me.txtBCR01AB_KUBUN.Name = "txtBCR01AB_KUBUN"
        Me.txtBCR01AB_KUBUN.Size = New System.Drawing.Size(40, 19)
        Me.txtBCR01AB_KUBUN.TabIndex = 7
        Me.txtBCR01AB_KUBUN.Text = "0"
        '
        'txtBCR01KENSA_KUBUN
        '
        Me.txtBCR01KENSA_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBCR01KENSA_KUBUN.Location = New System.Drawing.Point(136, 136)
        Me.txtBCR01KENSA_KUBUN.MaxLength = 1
        Me.txtBCR01KENSA_KUBUN.Name = "txtBCR01KENSA_KUBUN"
        Me.txtBCR01KENSA_KUBUN.Size = New System.Drawing.Size(40, 19)
        Me.txtBCR01KENSA_KUBUN.TabIndex = 6
        Me.txtBCR01KENSA_KUBUN.Text = "T"
        '
        'txtBCR01VOL
        '
        Me.txtBCR01VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBCR01VOL.Location = New System.Drawing.Point(136, 120)
        Me.txtBCR01VOL.MaxLength = 4
        Me.txtBCR01VOL.Name = "txtBCR01VOL"
        Me.txtBCR01VOL.Size = New System.Drawing.Size(40, 19)
        Me.txtBCR01VOL.TabIndex = 5
        Me.txtBCR01VOL.Text = "0010"
        '
        'txtBCR01PALLET_NO
        '
        Me.txtBCR01PALLET_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBCR01PALLET_NO.Location = New System.Drawing.Point(136, 104)
        Me.txtBCR01PALLET_NO.MaxLength = 4
        Me.txtBCR01PALLET_NO.Name = "txtBCR01PALLET_NO"
        Me.txtBCR01PALLET_NO.Size = New System.Drawing.Size(40, 19)
        Me.txtBCR01PALLET_NO.TabIndex = 4
        Me.txtBCR01PALLET_NO.Text = "0000"
        '
        'txtBCR01LINE_CD
        '
        Me.txtBCR01LINE_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBCR01LINE_CD.Location = New System.Drawing.Point(136, 88)
        Me.txtBCR01LINE_CD.MaxLength = 3
        Me.txtBCR01LINE_CD.Name = "txtBCR01LINE_CD"
        Me.txtBCR01LINE_CD.Size = New System.Drawing.Size(40, 19)
        Me.txtBCR01LINE_CD.TabIndex = 3
        Me.txtBCR01LINE_CD.Text = "000"
        '
        'txtBCR01KOUJYO_NO
        '
        Me.txtBCR01KOUJYO_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBCR01KOUJYO_NO.Location = New System.Drawing.Point(136, 72)
        Me.txtBCR01KOUJYO_NO.MaxLength = 3
        Me.txtBCR01KOUJYO_NO.Name = "txtBCR01KOUJYO_NO"
        Me.txtBCR01KOUJYO_NO.Size = New System.Drawing.Size(40, 19)
        Me.txtBCR01KOUJYO_NO.TabIndex = 2
        Me.txtBCR01KOUJYO_NO.Text = "000"
        '
        'txtBCR01SEIZOU_DT
        '
        Me.txtBCR01SEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBCR01SEIZOU_DT.Location = New System.Drawing.Point(136, 56)
        Me.txtBCR01SEIZOU_DT.MaxLength = 8
        Me.txtBCR01SEIZOU_DT.Name = "txtBCR01SEIZOU_DT"
        Me.txtBCR01SEIZOU_DT.Size = New System.Drawing.Size(64, 19)
        Me.txtBCR01SEIZOU_DT.TabIndex = 1
        Me.txtBCR01SEIZOU_DT.Text = "00000000"
        '
        'txtBCR01HINMEI_CD
        '
        Me.txtBCR01HINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBCR01HINMEI_CD.Location = New System.Drawing.Point(136, 40)
        Me.txtBCR01HINMEI_CD.MaxLength = 6
        Me.txtBCR01HINMEI_CD.Name = "txtBCR01HINMEI_CD"
        Me.txtBCR01HINMEI_CD.Size = New System.Drawing.Size(64, 19)
        Me.txtBCR01HINMEI_CD.TabIndex = 0
        Me.txtBCR01HINMEI_CD.Text = "000000"
        '
        'frmMCIDummyToServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(877, 661)
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
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBCR01LINE_CD As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBCR01HINMEI_CD As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtBCR01KOUJYO_NO As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBCR01VOL As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBCR01PALLET_NO As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtBCR01KENSA_KUBUN As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtBCR01AB_KUBUN As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtBCR01SEIZOU_DT As System.Windows.Forms.TextBox
    Friend WithEvents cmd01 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
