<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_205042
    Inherits GamenMate.FRM_000001

    'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
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
        Me.cmdSetutei = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtREN_S = New MateCommon.cmpMTextBoxNumber
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtREN_E = New MateCommon.cmpMTextBoxNumber
        Me.chkREN = New System.Windows.Forms.CheckBox
        Me.chkRETU = New System.Windows.Forms.CheckBox
        Me.txtRETU_E = New MateCommon.cmpMTextBoxNumber
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRETU_S = New MateCommon.cmpMTextBoxNumber
        Me.chkDAN = New System.Windows.Forms.CheckBox
        Me.txtDAN_E = New MateCommon.cmpMTextBoxNumber
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDAN_S = New MateCommon.cmpMTextBoxNumber
        Me.cmdKaijyo = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdSetutei
        '
        Me.cmdSetutei.BackColor = System.Drawing.Color.DarkGray
        Me.cmdSetutei.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSetutei.ForeColor = System.Drawing.Color.Black
        Me.cmdSetutei.Location = New System.Drawing.Point(16, 240)
        Me.cmdSetutei.Name = "cmdSetutei"
        Me.cmdSetutei.Size = New System.Drawing.Size(216, 40)
        Me.cmdSetutei.TabIndex = 15
        Me.cmdSetutei.Text = "禁止設定"
        Me.cmdSetutei.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label16.Location = New System.Drawing.Point(240, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 32)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "連範囲:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtREN_S
        '
        Me.txtREN_S.BackColorMask = System.Drawing.Color.Empty
        Me.txtREN_S.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtREN_S.Format = "##0"
        Me.txtREN_S.Location = New System.Drawing.Point(336, 96)
        Me.txtREN_S.MaxLength = 3
        Me.txtREN_S.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtREN_S.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtREN_S.Name = "txtREN_S"
        Me.txtREN_S.Nullable = True
        Me.txtREN_S.Size = New System.Drawing.Size(56, 27)
        Me.txtREN_S.TabIndex = 7
        Me.txtREN_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtREN_S.Value = ""
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(496, 240)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(408, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 32)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "～"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtREN_E
        '
        Me.txtREN_E.BackColorMask = System.Drawing.Color.Empty
        Me.txtREN_E.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtREN_E.Format = "##0"
        Me.txtREN_E.Location = New System.Drawing.Point(440, 96)
        Me.txtREN_E.MaxLength = 3
        Me.txtREN_E.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtREN_E.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtREN_E.Name = "txtREN_E"
        Me.txtREN_E.Nullable = True
        Me.txtREN_E.Size = New System.Drawing.Size(56, 27)
        Me.txtREN_E.TabIndex = 9
        Me.txtREN_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtREN_E.Value = ""
        '
        'chkREN
        '
        Me.chkREN.AutoSize = True
        Me.chkREN.Location = New System.Drawing.Point(216, 104)
        Me.chkREN.Name = "chkREN"
        Me.chkREN.Size = New System.Drawing.Size(15, 14)
        Me.chkREN.TabIndex = 5
        Me.chkREN.UseVisualStyleBackColor = True
        '
        'chkRETU
        '
        Me.chkRETU.AutoSize = True
        Me.chkRETU.Location = New System.Drawing.Point(216, 48)
        Me.chkRETU.Name = "chkRETU"
        Me.chkRETU.Size = New System.Drawing.Size(15, 14)
        Me.chkRETU.TabIndex = 0
        Me.chkRETU.UseVisualStyleBackColor = True
        '
        'txtRETU_E
        '
        Me.txtRETU_E.BackColorMask = System.Drawing.Color.Empty
        Me.txtRETU_E.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtRETU_E.Format = "#0"
        Me.txtRETU_E.Location = New System.Drawing.Point(440, 40)
        Me.txtRETU_E.MaxLength = 2
        Me.txtRETU_E.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtRETU_E.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtRETU_E.Name = "txtRETU_E"
        Me.txtRETU_E.Nullable = True
        Me.txtRETU_E.Size = New System.Drawing.Size(56, 27)
        Me.txtRETU_E.TabIndex = 4
        Me.txtRETU_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRETU_E.Value = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(408, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "～"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(240, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "列範囲:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRETU_S
        '
        Me.txtRETU_S.BackColorMask = System.Drawing.Color.Empty
        Me.txtRETU_S.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtRETU_S.Format = "#0"
        Me.txtRETU_S.Location = New System.Drawing.Point(336, 40)
        Me.txtRETU_S.MaxLength = 2
        Me.txtRETU_S.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtRETU_S.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtRETU_S.Name = "txtRETU_S"
        Me.txtRETU_S.Nullable = True
        Me.txtRETU_S.Size = New System.Drawing.Size(56, 27)
        Me.txtRETU_S.TabIndex = 2
        Me.txtRETU_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRETU_S.Value = ""
        '
        'chkDAN
        '
        Me.chkDAN.AutoSize = True
        Me.chkDAN.Location = New System.Drawing.Point(216, 160)
        Me.chkDAN.Name = "chkDAN"
        Me.chkDAN.Size = New System.Drawing.Size(15, 14)
        Me.chkDAN.TabIndex = 10
        Me.chkDAN.UseVisualStyleBackColor = True
        '
        'txtDAN_E
        '
        Me.txtDAN_E.BackColorMask = System.Drawing.Color.Empty
        Me.txtDAN_E.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtDAN_E.Format = "#0"
        Me.txtDAN_E.Location = New System.Drawing.Point(440, 152)
        Me.txtDAN_E.MaxLength = 2
        Me.txtDAN_E.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtDAN_E.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDAN_E.Name = "txtDAN_E"
        Me.txtDAN_E.Nullable = True
        Me.txtDAN_E.Size = New System.Drawing.Size(56, 27)
        Me.txtDAN_E.TabIndex = 14
        Me.txtDAN_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDAN_E.Value = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(408, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 32)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "～"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(240, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 32)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "段範囲:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDAN_S
        '
        Me.txtDAN_S.BackColorMask = System.Drawing.Color.Empty
        Me.txtDAN_S.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtDAN_S.Format = "#0"
        Me.txtDAN_S.Location = New System.Drawing.Point(336, 152)
        Me.txtDAN_S.MaxLength = 2
        Me.txtDAN_S.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtDAN_S.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDAN_S.Name = "txtDAN_S"
        Me.txtDAN_S.Nullable = True
        Me.txtDAN_S.Size = New System.Drawing.Size(56, 27)
        Me.txtDAN_S.TabIndex = 12
        Me.txtDAN_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDAN_S.Value = ""
        '
        'cmdKaijyo
        '
        Me.cmdKaijyo.BackColor = System.Drawing.Color.DarkGray
        Me.cmdKaijyo.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKaijyo.ForeColor = System.Drawing.Color.Black
        Me.cmdKaijyo.Location = New System.Drawing.Point(256, 240)
        Me.cmdKaijyo.Name = "cmdKaijyo"
        Me.cmdKaijyo.Size = New System.Drawing.Size(216, 40)
        Me.cmdKaijyo.TabIndex = 16
        Me.cmdKaijyo.Text = "禁止解除"
        Me.cmdKaijyo.UseVisualStyleBackColor = False
        '
        'FRM_205042
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(737, 301)
        Me.Controls.Add(Me.cmdKaijyo)
        Me.Controls.Add(Me.chkDAN)
        Me.Controls.Add(Me.txtDAN_E)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDAN_S)
        Me.Controls.Add(Me.chkRETU)
        Me.Controls.Add(Me.txtRETU_E)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRETU_S)
        Me.Controls.Add(Me.chkREN)
        Me.Controls.Add(Me.txtREN_E)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSetutei)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtREN_S)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FRM_205042"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "禁止棚一括設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSetutei As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtREN_S As MateCommon.cmpMTextBoxNumber
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtREN_E As MateCommon.cmpMTextBoxNumber
    Friend WithEvents chkREN As System.Windows.Forms.CheckBox
    Friend WithEvents chkRETU As System.Windows.Forms.CheckBox
    Friend WithEvents txtRETU_E As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRETU_S As MateCommon.cmpMTextBoxNumber
    Friend WithEvents chkDAN As System.Windows.Forms.CheckBox
    Friend WithEvents txtDAN_E As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDAN_S As MateCommon.cmpMTextBoxNumber
    Friend WithEvents cmdKaijyo As System.Windows.Forms.Button


End Class
