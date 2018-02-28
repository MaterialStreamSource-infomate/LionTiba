<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303025
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboFPALLET_ID_OYA = New MateCommon.cmpMComboBox
        Me.cboFTRK_BUF_NO = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboFPALLET_ID_KO = New MateCommon.cmpMComboBox
        Me.CmpMComboBox2 = New MateCommon.cmpMComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdADD = New System.Windows.Forms.Button
        Me.cmdSend = New System.Windows.Forms.Button
        Me.cmdReturn = New System.Windows.Forms.Button
        Me.txtTelegram = New System.Windows.Forms.TextBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFPALLET_ID_OYA)
        Me.GroupBox1.Controls.Add(Me.cboFTRK_BUF_NO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 108)
        Me.GroupBox1.TabIndex = 223
        Me.GroupBox1.TabStop = False
        '
        'cboFPALLET_ID_OYA
        '
        Me.cboFPALLET_ID_OYA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPALLET_ID_OYA.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFPALLET_ID_OYA.FormattingEnabled = True
        Me.cboFPALLET_ID_OYA.IntegralHeight = False
        Me.cboFPALLET_ID_OYA.Location = New System.Drawing.Point(162, 19)
        Me.cboFPALLET_ID_OYA.Name = "cboFPALLET_ID_OYA"
        Me.cboFPALLET_ID_OYA.Size = New System.Drawing.Size(268, 28)
        Me.cboFPALLET_ID_OYA.TabIndex = 0
        '
        'cboFTRK_BUF_NO
        '
        Me.cboFTRK_BUF_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO.IntegralHeight = False
        Me.cboFTRK_BUF_NO.Location = New System.Drawing.Point(162, 63)
        Me.cboFTRK_BUF_NO.Name = "cboFTRK_BUF_NO"
        Me.cboFTRK_BUF_NO.Size = New System.Drawing.Size(268, 28)
        Me.cboFTRK_BUF_NO.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(51, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 32)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "出庫ST:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 32)
        Me.Label1.TabIndex = 218
        Me.Label1.Text = "親"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(47, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(109, 32)
        Me.Label20.TabIndex = 217
        Me.Label20.Text = "ﾊﾟﾚｯﾄID:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboFPALLET_ID_KO)
        Me.GroupBox2.Controls.Add(Me.CmpMComboBox2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(490, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(460, 108)
        Me.GroupBox2.TabIndex = 224
        Me.GroupBox2.TabStop = False
        '
        'cboFPALLET_ID_KO
        '
        Me.cboFPALLET_ID_KO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPALLET_ID_KO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFPALLET_ID_KO.FormattingEnabled = True
        Me.cboFPALLET_ID_KO.IntegralHeight = False
        Me.cboFPALLET_ID_KO.Location = New System.Drawing.Point(162, 19)
        Me.cboFPALLET_ID_KO.Name = "cboFPALLET_ID_KO"
        Me.cboFPALLET_ID_KO.Size = New System.Drawing.Size(268, 28)
        Me.cboFPALLET_ID_KO.TabIndex = 2
        '
        'CmpMComboBox2
        '
        Me.CmpMComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmpMComboBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.CmpMComboBox2.FormattingEnabled = True
        Me.CmpMComboBox2.IntegralHeight = False
        Me.CmpMComboBox2.Location = New System.Drawing.Point(162, 63)
        Me.CmpMComboBox2.Name = "CmpMComboBox2"
        Me.CmpMComboBox2.Size = New System.Drawing.Size(268, 28)
        Me.CmpMComboBox2.TabIndex = 3
        Me.CmpMComboBox2.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(51, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 32)
        Me.Label3.TabIndex = 219
        Me.Label3.Text = "出庫ST:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 32)
        Me.Label4.TabIndex = 218
        Me.Label4.Text = "子"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(47, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 32)
        Me.Label5.TabIndex = 217
        Me.Label5.Text = "ﾊﾟﾚｯﾄID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdADD
        '
        Me.cmdADD.BackColor = System.Drawing.Color.DarkGray
        Me.cmdADD.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdADD.ForeColor = System.Drawing.Color.Black
        Me.cmdADD.Location = New System.Drawing.Point(595, 137)
        Me.cmdADD.Name = "cmdADD"
        Me.cmdADD.Size = New System.Drawing.Size(104, 43)
        Me.cmdADD.TabIndex = 10
        Me.cmdADD.Text = "追加"
        Me.cmdADD.UseVisualStyleBackColor = False
        '
        'cmdSend
        '
        Me.cmdSend.BackColor = System.Drawing.Color.DarkGray
        Me.cmdSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdSend.ForeColor = System.Drawing.Color.Black
        Me.cmdSend.Location = New System.Drawing.Point(595, 201)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(104, 43)
        Me.cmdSend.TabIndex = 21
        Me.cmdSend.Text = "送信"
        Me.cmdSend.UseVisualStyleBackColor = False
        '
        'cmdReturn
        '
        Me.cmdReturn.BackColor = System.Drawing.Color.DarkGray
        Me.cmdReturn.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdReturn.ForeColor = System.Drawing.Color.Black
        Me.cmdReturn.Location = New System.Drawing.Point(846, 201)
        Me.cmdReturn.Name = "cmdReturn"
        Me.cmdReturn.Size = New System.Drawing.Size(104, 43)
        Me.cmdReturn.TabIndex = 22
        Me.cmdReturn.Text = "閉じる"
        Me.cmdReturn.UseVisualStyleBackColor = False
        '
        'txtTelegram
        '
        Me.txtTelegram.Location = New System.Drawing.Point(22, 137)
        Me.txtTelegram.Multiline = True
        Me.txtTelegram.Name = "txtTelegram"
        Me.txtTelegram.ReadOnly = True
        Me.txtTelegram.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTelegram.Size = New System.Drawing.Size(555, 107)
        Me.txtTelegram.TabIndex = 225
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.DarkGray
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdClear.ForeColor = System.Drawing.Color.Black
        Me.cmdClear.Location = New System.Drawing.Point(725, 137)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(104, 43)
        Me.cmdClear.TabIndex = 226
        Me.cmdClear.Text = "ｸﾘｱ"
        Me.cmdClear.UseVisualStyleBackColor = False
        '
        'FRM_303025
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(963, 277)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.txtTelegram)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.cmdReturn)
        Me.Controls.Add(Me.cmdADD)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_303025"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "問合せ出庫 テスト"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFPALLET_ID_OYA As MateCommon.cmpMComboBox
    Friend WithEvents cboFTRK_BUF_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFPALLET_ID_KO As MateCommon.cmpMComboBox
    Friend WithEvents CmpMComboBox2 As MateCommon.cmpMComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdADD As System.Windows.Forms.Button
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents cmdReturn As System.Windows.Forms.Button
    Friend WithEvents txtTelegram As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button

End Class
