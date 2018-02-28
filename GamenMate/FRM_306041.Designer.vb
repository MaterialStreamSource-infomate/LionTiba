<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_306041
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
        Me.txtXSYASYU_NAME = New MateCommon.cmpMTextBoxString
        Me.txtXSYASYU_KBN = New MateCommon.cmpMTextBoxString
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(297, 153)
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
        Me.cmdZikkou.Location = New System.Drawing.Point(25, 153)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 3
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'txtXSYASYU_NAME
        '
        Me.txtXSYASYU_NAME.BackColorMask = System.Drawing.Color.Empty
        Me.txtXSYASYU_NAME.EnabledFull = True
        Me.txtXSYASYU_NAME.EnabledFullAlphabetLower = True
        Me.txtXSYASYU_NAME.EnabledFullAlphabetUpper = True
        Me.txtXSYASYU_NAME.EnabledFullHiragana = True
        Me.txtXSYASYU_NAME.EnabledFullKatakana = True
        Me.txtXSYASYU_NAME.EnabledFullNumber = True
        Me.txtXSYASYU_NAME.EnabledHalf = True
        Me.txtXSYASYU_NAME.EnabledHalfAlphabetLower = True
        Me.txtXSYASYU_NAME.EnabledHalfAlphabetUpper = True
        Me.txtXSYASYU_NAME.EnabledHalfKatakana = True
        Me.txtXSYASYU_NAME.EnabledHalfNumber = True
        Me.txtXSYASYU_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXSYASYU_NAME.Location = New System.Drawing.Point(173, 62)
        Me.txtXSYASYU_NAME.MaxLength = 40
        Me.txtXSYASYU_NAME.MaxLengthByte = 40
        Me.txtXSYASYU_NAME.Name = "txtXSYASYU_NAME"
        Me.txtXSYASYU_NAME.RegexCustomFalse = Nothing
        Me.txtXSYASYU_NAME.RegexCustomTrue = Nothing
        Me.txtXSYASYU_NAME.Size = New System.Drawing.Size(340, 27)
        Me.txtXSYASYU_NAME.TabIndex = 2
        '
        'txtXSYASYU_KBN
        '
        Me.txtXSYASYU_KBN.BackColorMask = System.Drawing.Color.Empty
        Me.txtXSYASYU_KBN.EnabledFull = False
        Me.txtXSYASYU_KBN.EnabledFullAlphabetLower = False
        Me.txtXSYASYU_KBN.EnabledFullAlphabetUpper = False
        Me.txtXSYASYU_KBN.EnabledFullHiragana = False
        Me.txtXSYASYU_KBN.EnabledFullKatakana = False
        Me.txtXSYASYU_KBN.EnabledFullNumber = False
        Me.txtXSYASYU_KBN.EnabledHalf = True
        Me.txtXSYASYU_KBN.EnabledHalfAlphabetLower = True
        Me.txtXSYASYU_KBN.EnabledHalfAlphabetUpper = True
        Me.txtXSYASYU_KBN.EnabledHalfKatakana = True
        Me.txtXSYASYU_KBN.EnabledHalfNumber = True
        Me.txtXSYASYU_KBN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXSYASYU_KBN.Location = New System.Drawing.Point(173, 22)
        Me.txtXSYASYU_KBN.MaxLength = 2
        Me.txtXSYASYU_KBN.MaxLengthByte = 2
        Me.txtXSYASYU_KBN.Name = "txtXSYASYU_KBN"
        Me.txtXSYASYU_KBN.RegexCustomFalse = Nothing
        Me.txtXSYASYU_KBN.RegexCustomTrue = Nothing
        Me.txtXSYASYU_KBN.Size = New System.Drawing.Size(48, 27)
        Me.txtXSYASYU_KBN.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(21, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "車種名称:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "車種区分:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_306041
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(554, 206)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.txtXSYASYU_NAME)
        Me.Controls.Add(Me.txtXSYASYU_KBN)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FRM_306041"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "輸送手段マスタ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents txtXSYASYU_NAME As MateCommon.cmpMTextBoxString
    Friend WithEvents txtXSYASYU_KBN As MateCommon.cmpMTextBoxString
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
