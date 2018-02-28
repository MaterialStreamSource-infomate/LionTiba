<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_305031
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.cboFHORYU_KUBUN = New MateCommon.cmpMComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtXHORYU_REASON = New MateCommon.cmpMTextBoxString
        Me.lblXHORYU_REASON = New System.Windows.Forms.Label
        Me.txtXHORYU_NO = New MateCommon.cmpMTextBoxString
        Me.lblXHORYU_NO = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(304, 184)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(16, 184)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 6
        Me.cmdZikkou.Text = "登録"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'cboFHORYU_KUBUN
        '
        Me.cboFHORYU_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFHORYU_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFHORYU_KUBUN.FormattingEnabled = True
        Me.cboFHORYU_KUBUN.IntegralHeight = False
        Me.cboFHORYU_KUBUN.Location = New System.Drawing.Point(168, 21)
        Me.cboFHORYU_KUBUN.Name = "cboFHORYU_KUBUN"
        Me.cboFHORYU_KUBUN.Size = New System.Drawing.Size(192, 28)
        Me.cboFHORYU_KUBUN.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(56, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "保留区分:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXHORYU_REASON
        '
        Me.txtXHORYU_REASON.BackColorMask = System.Drawing.Color.Empty
        Me.txtXHORYU_REASON.EnabledFull = True
        Me.txtXHORYU_REASON.EnabledFullAlphabetLower = True
        Me.txtXHORYU_REASON.EnabledFullAlphabetUpper = True
        Me.txtXHORYU_REASON.EnabledFullHiragana = True
        Me.txtXHORYU_REASON.EnabledFullKatakana = True
        Me.txtXHORYU_REASON.EnabledFullNumber = True
        Me.txtXHORYU_REASON.EnabledHalf = True
        Me.txtXHORYU_REASON.EnabledHalfAlphabetLower = True
        Me.txtXHORYU_REASON.EnabledHalfAlphabetUpper = True
        Me.txtXHORYU_REASON.EnabledHalfKatakana = True
        Me.txtXHORYU_REASON.EnabledHalfNumber = True
        Me.txtXHORYU_REASON.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXHORYU_REASON.Location = New System.Drawing.Point(168, 72)
        Me.txtXHORYU_REASON.MaxLength = 128
        Me.txtXHORYU_REASON.MaxLengthByte = 128
        Me.txtXHORYU_REASON.Name = "txtXHORYU_REASON"
        Me.txtXHORYU_REASON.RegexCustomFalse = Nothing
        Me.txtXHORYU_REASON.RegexCustomTrue = Nothing
        Me.txtXHORYU_REASON.Size = New System.Drawing.Size(296, 27)
        Me.txtXHORYU_REASON.TabIndex = 3
        '
        'lblXHORYU_REASON
        '
        Me.lblXHORYU_REASON.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXHORYU_REASON.ForeColor = System.Drawing.Color.Black
        Me.lblXHORYU_REASON.Location = New System.Drawing.Point(53, 69)
        Me.lblXHORYU_REASON.Name = "lblXHORYU_REASON"
        Me.lblXHORYU_REASON.Size = New System.Drawing.Size(115, 32)
        Me.lblXHORYU_REASON.TabIndex = 2
        Me.lblXHORYU_REASON.Text = "保留理由:"
        Me.lblXHORYU_REASON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXHORYU_NO
        '
        Me.txtXHORYU_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXHORYU_NO.EnabledFull = False
        Me.txtXHORYU_NO.EnabledFullAlphabetLower = False
        Me.txtXHORYU_NO.EnabledFullAlphabetUpper = False
        Me.txtXHORYU_NO.EnabledFullHiragana = False
        Me.txtXHORYU_NO.EnabledFullKatakana = False
        Me.txtXHORYU_NO.EnabledFullNumber = False
        Me.txtXHORYU_NO.EnabledHalf = True
        Me.txtXHORYU_NO.EnabledHalfAlphabetLower = True
        Me.txtXHORYU_NO.EnabledHalfAlphabetUpper = True
        Me.txtXHORYU_NO.EnabledHalfKatakana = False
        Me.txtXHORYU_NO.EnabledHalfNumber = True
        Me.txtXHORYU_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXHORYU_NO.Location = New System.Drawing.Point(168, 120)
        Me.txtXHORYU_NO.MaxLength = 3
        Me.txtXHORYU_NO.MaxLengthByte = 3
        Me.txtXHORYU_NO.Name = "txtXHORYU_NO"
        Me.txtXHORYU_NO.RegexCustomFalse = Nothing
        Me.txtXHORYU_NO.RegexCustomTrue = Nothing
        Me.txtXHORYU_NO.Size = New System.Drawing.Size(48, 27)
        Me.txtXHORYU_NO.TabIndex = 5
        '
        'lblXHORYU_NO
        '
        Me.lblXHORYU_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXHORYU_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXHORYU_NO.Location = New System.Drawing.Point(45, 117)
        Me.lblXHORYU_NO.Name = "lblXHORYU_NO"
        Me.lblXHORYU_NO.Size = New System.Drawing.Size(123, 32)
        Me.lblXHORYU_NO.TabIndex = 4
        Me.lblXHORYU_NO.Text = "保留№:"
        Me.lblXHORYU_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_305031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(537, 234)
        Me.Controls.Add(Me.txtXHORYU_REASON)
        Me.Controls.Add(Me.lblXHORYU_REASON)
        Me.Controls.Add(Me.txtXHORYU_NO)
        Me.Controls.Add(Me.lblXHORYU_NO)
        Me.Controls.Add(Me.cboFHORYU_KUBUN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Name = "FRM_305031"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "保留設定実施確認"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents cboFHORYU_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtXHORYU_REASON As MateCommon.cmpMTextBoxString
    Friend WithEvents lblXHORYU_REASON As System.Windows.Forms.Label
    Friend WithEvents txtXHORYU_NO As MateCommon.cmpMTextBoxString
    Friend WithEvents lblXHORYU_NO As System.Windows.Forms.Label

End Class
