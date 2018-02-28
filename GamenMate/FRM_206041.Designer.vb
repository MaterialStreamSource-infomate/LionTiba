<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_206041
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.txtReasonCD = New MateCommon.cmpMTextBoxString
        Me.txtOperationCD = New MateCommon.cmpMTextBoxString
        Me.txtReason = New MateCommon.cmpMTextBoxString
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 32)
        Me.Label1.TabIndex = 232
        Me.Label1.Text = "理由:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(8, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 32)
        Me.Label12.TabIndex = 231
        Me.Label12.Text = "理由コード:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(336, 144)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(48, 144)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 3
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'txtReasonCD
        '
        Me.txtReasonCD.BackColorMask = System.Drawing.Color.Empty
        Me.txtReasonCD.EnabledFull = False
        Me.txtReasonCD.EnabledFullAlphabetLower = False
        Me.txtReasonCD.EnabledFullAlphabetUpper = False
        Me.txtReasonCD.EnabledFullHiragana = False
        Me.txtReasonCD.EnabledFullKatakana = False
        Me.txtReasonCD.EnabledFullNumber = False
        Me.txtReasonCD.EnabledHalf = True
        Me.txtReasonCD.EnabledHalfAlphabetLower = True
        Me.txtReasonCD.EnabledHalfAlphabetUpper = True
        Me.txtReasonCD.EnabledHalfKatakana = False
        Me.txtReasonCD.EnabledHalfNumber = True
        Me.txtReasonCD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtReasonCD.Location = New System.Drawing.Point(192, 27)
        Me.txtReasonCD.MaxLength = 6
        Me.txtReasonCD.MaxLengthByte = 6
        Me.txtReasonCD.Name = "txtReasonCD"
        Me.txtReasonCD.RegexCustomFalse = Nothing
        Me.txtReasonCD.RegexCustomTrue = Nothing
        Me.txtReasonCD.Size = New System.Drawing.Size(112, 27)
        Me.txtReasonCD.TabIndex = 1
        '
        'txtOperationCD
        '
        Me.txtOperationCD.BackColorMask = System.Drawing.Color.Empty
        Me.txtOperationCD.Enabled = False
        Me.txtOperationCD.EnabledFull = False
        Me.txtOperationCD.EnabledFullAlphabetLower = False
        Me.txtOperationCD.EnabledFullAlphabetUpper = False
        Me.txtOperationCD.EnabledFullHiragana = False
        Me.txtOperationCD.EnabledFullKatakana = False
        Me.txtOperationCD.EnabledFullNumber = False
        Me.txtOperationCD.EnabledHalf = True
        Me.txtOperationCD.EnabledHalfAlphabetLower = False
        Me.txtOperationCD.EnabledHalfAlphabetUpper = False
        Me.txtOperationCD.EnabledHalfKatakana = False
        Me.txtOperationCD.EnabledHalfNumber = True
        Me.txtOperationCD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtOperationCD.Location = New System.Drawing.Point(144, 27)
        Me.txtOperationCD.MaxLength = 8
        Me.txtOperationCD.MaxLengthByte = 8
        Me.txtOperationCD.Name = "txtOperationCD"
        Me.txtOperationCD.RegexCustomFalse = Nothing
        Me.txtOperationCD.RegexCustomTrue = Nothing
        Me.txtOperationCD.Size = New System.Drawing.Size(40, 27)
        Me.txtOperationCD.TabIndex = 0
        '
        'txtReason
        '
        Me.txtReason.BackColorMask = System.Drawing.Color.Empty
        Me.txtReason.EnabledFull = True
        Me.txtReason.EnabledFullAlphabetLower = True
        Me.txtReason.EnabledFullAlphabetUpper = True
        Me.txtReason.EnabledFullHiragana = True
        Me.txtReason.EnabledFullKatakana = True
        Me.txtReason.EnabledFullNumber = True
        Me.txtReason.EnabledHalf = True
        Me.txtReason.EnabledHalfAlphabetLower = True
        Me.txtReason.EnabledHalfAlphabetUpper = True
        Me.txtReason.EnabledHalfKatakana = True
        Me.txtReason.EnabledHalfNumber = True
        Me.txtReason.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtReason.Location = New System.Drawing.Point(144, 75)
        Me.txtReason.MaxLength = 32
        Me.txtReason.MaxLengthByte = 32
        Me.txtReason.Name = "txtReason"
        Me.txtReason.RegexCustomFalse = Nothing
        Me.txtReason.RegexCustomTrue = Nothing
        Me.txtReason.Size = New System.Drawing.Size(408, 27)
        Me.txtReason.TabIndex = 2
        '
        'FRM_206041
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(597, 209)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.txtReasonCD)
        Me.Controls.Add(Me.txtOperationCD)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Name = "FRM_206041"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "理由マスタメンテナンス"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents txtReasonCD As MateCommon.cmpMTextBoxString
    Friend WithEvents txtOperationCD As MateCommon.cmpMTextBoxString
    Friend WithEvents txtReason As MateCommon.cmpMTextBoxString
    
End Class
