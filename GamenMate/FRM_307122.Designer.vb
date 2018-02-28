<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307122
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
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboPLC_RETU = New MateCommon.cmpMComboBox
        Me.cboPLC_DAN = New MateCommon.cmpMComboBox
        Me.cboPLC_REN = New MateCommon.cmpMComboBox
        Me.cboPLC_OYAKO = New MateCommon.cmpMComboBox
        Me.cboPLC_GOTO = New MateCommon.cmpMComboBox
        Me.cboPLC_END = New MateCommon.cmpMComboBox
        Me.cboPLC_GOUKI = New MateCommon.cmpMComboBox
        Me.cboPLC_SAYU = New MateCommon.cmpMComboBox
        Me.cboPLC_W = New MateCommon.cmpMComboBox
        Me.cboPLC_LS = New MateCommon.cmpMComboBox
        Me.cboPLC_FORK = New MateCommon.cmpMComboBox
        Me.cboPLC_PARE = New MateCommon.cmpMComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboPLC_MODE = New MateCommon.cmpMComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblNo = New System.Windows.Forms.Label
        Me.lblPLC_STNo = New System.Windows.Forms.Label
        Me.cmdSend = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.DarkGray
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClear.ForeColor = System.Drawing.Color.Black
        Me.cmdClear.Location = New System.Drawing.Point(22, 143)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(187, 40)
        Me.cmdClear.TabIndex = 198
        Me.cmdClear.Text = "クリア"
        Me.cmdClear.UseVisualStyleBackColor = False
        '
        'cboPLC_RETU
        '
        Me.cboPLC_RETU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_RETU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboPLC_RETU.FormattingEnabled = True
        Me.cboPLC_RETU.IntegralHeight = False
        Me.cboPLC_RETU.Location = New System.Drawing.Point(520, 152)
        Me.cboPLC_RETU.Name = "cboPLC_RETU"
        Me.cboPLC_RETU.Size = New System.Drawing.Size(65, 28)
        Me.cboPLC_RETU.TabIndex = 215
        Me.cboPLC_RETU.TabStop = False
        Me.cboPLC_RETU.Visible = False
        '
        'cboPLC_DAN
        '
        Me.cboPLC_DAN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_DAN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboPLC_DAN.FormattingEnabled = True
        Me.cboPLC_DAN.IntegralHeight = False
        Me.cboPLC_DAN.Location = New System.Drawing.Point(730, 92)
        Me.cboPLC_DAN.Name = "cboPLC_DAN"
        Me.cboPLC_DAN.Size = New System.Drawing.Size(67, 28)
        Me.cboPLC_DAN.TabIndex = 195
        '
        'cboPLC_REN
        '
        Me.cboPLC_REN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_REN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboPLC_REN.FormattingEnabled = True
        Me.cboPLC_REN.IntegralHeight = False
        Me.cboPLC_REN.Location = New System.Drawing.Point(584, 92)
        Me.cboPLC_REN.Name = "cboPLC_REN"
        Me.cboPLC_REN.Size = New System.Drawing.Size(67, 28)
        Me.cboPLC_REN.TabIndex = 193
        '
        'cboPLC_OYAKO
        '
        Me.cboPLC_OYAKO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_OYAKO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_OYAKO.FormattingEnabled = True
        Me.cboPLC_OYAKO.IntegralHeight = False
        Me.cboPLC_OYAKO.Location = New System.Drawing.Point(1102, 92)
        Me.cboPLC_OYAKO.Name = "cboPLC_OYAKO"
        Me.cboPLC_OYAKO.Size = New System.Drawing.Size(67, 28)
        Me.cboPLC_OYAKO.TabIndex = 197
        '
        'cboPLC_GOTO
        '
        Me.cboPLC_GOTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_GOTO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_GOTO.FormattingEnabled = True
        Me.cboPLC_GOTO.IntegralHeight = False
        Me.cboPLC_GOTO.Location = New System.Drawing.Point(803, 92)
        Me.cboPLC_GOTO.Name = "cboPLC_GOTO"
        Me.cboPLC_GOTO.Size = New System.Drawing.Size(293, 28)
        Me.cboPLC_GOTO.TabIndex = 196
        '
        'cboPLC_END
        '
        Me.cboPLC_END.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_END.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_END.FormattingEnabled = True
        Me.cboPLC_END.IntegralHeight = False
        Me.cboPLC_END.Location = New System.Drawing.Point(657, 92)
        Me.cboPLC_END.Name = "cboPLC_END"
        Me.cboPLC_END.Size = New System.Drawing.Size(67, 28)
        Me.cboPLC_END.TabIndex = 194
        '
        'cboPLC_GOUKI
        '
        Me.cboPLC_GOUKI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_GOUKI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_GOUKI.FormattingEnabled = True
        Me.cboPLC_GOUKI.IntegralHeight = False
        Me.cboPLC_GOUKI.Location = New System.Drawing.Point(480, 92)
        Me.cboPLC_GOUKI.Name = "cboPLC_GOUKI"
        Me.cboPLC_GOUKI.Size = New System.Drawing.Size(98, 28)
        Me.cboPLC_GOUKI.TabIndex = 192
        '
        'cboPLC_SAYU
        '
        Me.cboPLC_SAYU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_SAYU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_SAYU.FormattingEnabled = True
        Me.cboPLC_SAYU.IntegralHeight = False
        Me.cboPLC_SAYU.Location = New System.Drawing.Point(407, 92)
        Me.cboPLC_SAYU.Name = "cboPLC_SAYU"
        Me.cboPLC_SAYU.Size = New System.Drawing.Size(67, 28)
        Me.cboPLC_SAYU.TabIndex = 191
        '
        'cboPLC_W
        '
        Me.cboPLC_W.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_W.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_W.FormattingEnabled = True
        Me.cboPLC_W.IntegralHeight = False
        Me.cboPLC_W.Location = New System.Drawing.Point(334, 92)
        Me.cboPLC_W.Name = "cboPLC_W"
        Me.cboPLC_W.Size = New System.Drawing.Size(67, 28)
        Me.cboPLC_W.TabIndex = 190
        '
        'cboPLC_LS
        '
        Me.cboPLC_LS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_LS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_LS.FormattingEnabled = True
        Me.cboPLC_LS.IntegralHeight = False
        Me.cboPLC_LS.Location = New System.Drawing.Point(261, 92)
        Me.cboPLC_LS.Name = "cboPLC_LS"
        Me.cboPLC_LS.Size = New System.Drawing.Size(67, 28)
        Me.cboPLC_LS.TabIndex = 189
        '
        'cboPLC_FORK
        '
        Me.cboPLC_FORK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_FORK.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_FORK.FormattingEnabled = True
        Me.cboPLC_FORK.IntegralHeight = False
        Me.cboPLC_FORK.Location = New System.Drawing.Point(188, 92)
        Me.cboPLC_FORK.Name = "cboPLC_FORK"
        Me.cboPLC_FORK.Size = New System.Drawing.Size(67, 28)
        Me.cboPLC_FORK.TabIndex = 188
        '
        'cboPLC_PARE
        '
        Me.cboPLC_PARE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_PARE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_PARE.FormattingEnabled = True
        Me.cboPLC_PARE.IntegralHeight = False
        Me.cboPLC_PARE.Location = New System.Drawing.Point(95, 92)
        Me.cboPLC_PARE.Name = "cboPLC_PARE"
        Me.cboPLC_PARE.Size = New System.Drawing.Size(87, 28)
        Me.cboPLC_PARE.TabIndex = 187
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(1098, 57)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(87, 32)
        Me.Label23.TabIndex = 214
        Me.Label23.Text = "親子"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(799, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(275, 32)
        Me.Label21.TabIndex = 213
        Me.Label21.Text = "行先"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboPLC_MODE
        '
        Me.cboPLC_MODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLC_MODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboPLC_MODE.FormattingEnabled = True
        Me.cboPLC_MODE.IntegralHeight = False
        Me.cboPLC_MODE.Location = New System.Drawing.Point(22, 92)
        Me.cboPLC_MODE.Name = "cboPLC_MODE"
        Me.cboPLC_MODE.Size = New System.Drawing.Size(67, 28)
        Me.cboPLC_MODE.TabIndex = 186
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(726, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 32)
        Me.Label19.TabIndex = 212
        Me.Label19.Text = "段"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(657, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 32)
        Me.Label17.TabIndex = 211
        Me.Label17.Text = "END"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(584, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 32)
        Me.Label15.TabIndex = 210
        Me.Label15.Text = "連"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(486, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 32)
        Me.Label13.TabIndex = 209
        Me.Label13.Text = "号機"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(407, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 32)
        Me.Label11.TabIndex = 208
        Me.Label11.Text = "左右"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(334, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 32)
        Me.Label9.TabIndex = 207
        Me.Label9.Text = "Wﾘｰﾁ"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(261, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 32)
        Me.Label7.TabIndex = 206
        Me.Label7.Text = "L/S"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(178, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 32)
        Me.Label5.TabIndex = 205
        Me.Label5.Text = "ﾌｫｰｸ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(95, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 32)
        Me.Label3.TabIndex = 204
        Me.Label3.Text = "ﾍﾟｱ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 32)
        Me.Label1.TabIndex = 203
        Me.Label1.Text = "ﾓｰﾄﾞ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNo
        '
        Me.lblNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.Location = New System.Drawing.Point(4, 9)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(95, 32)
        Me.lblNo.TabIndex = 201
        Me.lblNo.Text = "CV№:"
        Me.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPLC_STNo
        '
        Me.lblPLC_STNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPLC_STNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblPLC_STNo.ForeColor = System.Drawing.Color.Black
        Me.lblPLC_STNo.Location = New System.Drawing.Point(105, 9)
        Me.lblPLC_STNo.Name = "lblPLC_STNo"
        Me.lblPLC_STNo.Size = New System.Drawing.Size(170, 32)
        Me.lblPLC_STNo.TabIndex = 202
        Me.lblPLC_STNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSend
        '
        Me.cmdSend.BackColor = System.Drawing.Color.DarkGray
        Me.cmdSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSend.ForeColor = System.Drawing.Color.Black
        Me.cmdSend.Location = New System.Drawing.Point(816, 143)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(187, 40)
        Me.cmdSend.TabIndex = 199
        Me.cmdSend.Text = "修正"
        Me.cmdSend.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(1025, 143)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdCancel.TabIndex = 200
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'FRM_307122
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 195)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cboPLC_RETU)
        Me.Controls.Add(Me.cboPLC_DAN)
        Me.Controls.Add(Me.cboPLC_REN)
        Me.Controls.Add(Me.cboPLC_OYAKO)
        Me.Controls.Add(Me.cboPLC_GOTO)
        Me.Controls.Add(Me.cboPLC_END)
        Me.Controls.Add(Me.cboPLC_GOUKI)
        Me.Controls.Add(Me.cboPLC_SAYU)
        Me.Controls.Add(Me.cboPLC_W)
        Me.Controls.Add(Me.cboPLC_LS)
        Me.Controls.Add(Me.cboPLC_FORK)
        Me.Controls.Add(Me.cboPLC_PARE)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cboPLC_MODE)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNo)
        Me.Controls.Add(Me.lblPLC_STNo)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "FRM_307122"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "入出棚CVﾃﾞｰﾀﾒﾝﾃﾅﾝｽ"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboPLC_RETU As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_DAN As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_REN As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_OYAKO As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_GOTO As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_END As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_GOUKI As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_SAYU As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_W As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_LS As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_FORK As MateCommon.cmpMComboBox
    Friend WithEvents cboPLC_PARE As MateCommon.cmpMComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboPLC_MODE As MateCommon.cmpMComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents lblPLC_STNo As System.Windows.Forms.Label
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button

End Class
