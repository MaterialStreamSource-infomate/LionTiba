<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_202001
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
        Me.txtRAC_DAN_TO = New MateCommon.cmpMTextBoxString
        Me.txtRAC_REN_TO = New MateCommon.cmpMTextBoxString
        Me.txtRAC_RETU_TO = New MateCommon.cmpMTextBoxString
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdManual = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdToChange = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtRAC_DAN_TO
        '
        Me.txtRAC_DAN_TO.BackColorMask = System.Drawing.Color.Empty
        Me.txtRAC_DAN_TO.EnabledFull = False
        Me.txtRAC_DAN_TO.EnabledFullAlphabetLower = False
        Me.txtRAC_DAN_TO.EnabledFullAlphabetUpper = False
        Me.txtRAC_DAN_TO.EnabledFullHiragana = False
        Me.txtRAC_DAN_TO.EnabledFullKatakana = False
        Me.txtRAC_DAN_TO.EnabledFullNumber = False
        Me.txtRAC_DAN_TO.EnabledHalf = True
        Me.txtRAC_DAN_TO.EnabledHalfAlphabetLower = False
        Me.txtRAC_DAN_TO.EnabledHalfAlphabetUpper = False
        Me.txtRAC_DAN_TO.EnabledHalfKatakana = False
        Me.txtRAC_DAN_TO.EnabledHalfNumber = True
        Me.txtRAC_DAN_TO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtRAC_DAN_TO.Location = New System.Drawing.Point(371, 61)
        Me.txtRAC_DAN_TO.MaxLength = 2
        Me.txtRAC_DAN_TO.MaxLengthByte = 2
        Me.txtRAC_DAN_TO.Name = "txtRAC_DAN_TO"
        Me.txtRAC_DAN_TO.RegexCustomFalse = Nothing
        Me.txtRAC_DAN_TO.RegexCustomTrue = Nothing
        Me.txtRAC_DAN_TO.Size = New System.Drawing.Size(50, 27)
        Me.txtRAC_DAN_TO.TabIndex = 298
        '
        'txtRAC_REN_TO
        '
        Me.txtRAC_REN_TO.BackColorMask = System.Drawing.Color.Empty
        Me.txtRAC_REN_TO.EnabledFull = False
        Me.txtRAC_REN_TO.EnabledFullAlphabetLower = False
        Me.txtRAC_REN_TO.EnabledFullAlphabetUpper = False
        Me.txtRAC_REN_TO.EnabledFullHiragana = False
        Me.txtRAC_REN_TO.EnabledFullKatakana = False
        Me.txtRAC_REN_TO.EnabledFullNumber = False
        Me.txtRAC_REN_TO.EnabledHalf = True
        Me.txtRAC_REN_TO.EnabledHalfAlphabetLower = False
        Me.txtRAC_REN_TO.EnabledHalfAlphabetUpper = False
        Me.txtRAC_REN_TO.EnabledHalfKatakana = False
        Me.txtRAC_REN_TO.EnabledHalfNumber = True
        Me.txtRAC_REN_TO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtRAC_REN_TO.Location = New System.Drawing.Point(287, 61)
        Me.txtRAC_REN_TO.MaxLength = 2
        Me.txtRAC_REN_TO.MaxLengthByte = 2
        Me.txtRAC_REN_TO.Name = "txtRAC_REN_TO"
        Me.txtRAC_REN_TO.RegexCustomFalse = Nothing
        Me.txtRAC_REN_TO.RegexCustomTrue = Nothing
        Me.txtRAC_REN_TO.Size = New System.Drawing.Size(50, 27)
        Me.txtRAC_REN_TO.TabIndex = 297
        '
        'txtRAC_RETU_TO
        '
        Me.txtRAC_RETU_TO.BackColorMask = System.Drawing.Color.Empty
        Me.txtRAC_RETU_TO.EnabledFull = False
        Me.txtRAC_RETU_TO.EnabledFullAlphabetLower = False
        Me.txtRAC_RETU_TO.EnabledFullAlphabetUpper = False
        Me.txtRAC_RETU_TO.EnabledFullHiragana = False
        Me.txtRAC_RETU_TO.EnabledFullKatakana = False
        Me.txtRAC_RETU_TO.EnabledFullNumber = False
        Me.txtRAC_RETU_TO.EnabledHalf = True
        Me.txtRAC_RETU_TO.EnabledHalfAlphabetLower = False
        Me.txtRAC_RETU_TO.EnabledHalfAlphabetUpper = False
        Me.txtRAC_RETU_TO.EnabledHalfKatakana = False
        Me.txtRAC_RETU_TO.EnabledHalfNumber = True
        Me.txtRAC_RETU_TO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtRAC_RETU_TO.Location = New System.Drawing.Point(204, 61)
        Me.txtRAC_RETU_TO.MaxLength = 2
        Me.txtRAC_RETU_TO.MaxLengthByte = 2
        Me.txtRAC_RETU_TO.Name = "txtRAC_RETU_TO"
        Me.txtRAC_RETU_TO.RegexCustomFalse = Nothing
        Me.txtRAC_RETU_TO.RegexCustomTrue = Nothing
        Me.txtRAC_RETU_TO.Size = New System.Drawing.Size(50, 27)
        Me.txtRAC_RETU_TO.TabIndex = 296
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(339, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 32)
        Me.Label4.TabIndex = 306
        Me.Label4.Text = "-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(255, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 32)
        Me.Label3.TabIndex = 305
        Me.Label3.Text = "-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(16, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(368, 32)
        Me.Label2.TabIndex = 304
        Me.Label2.Text = "手動での払い出しを行いますか？"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(38, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 32)
        Me.Label1.TabIndex = 303
        Me.Label1.Text = "変更棚アドレス"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Location = New System.Drawing.Point(16, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(368, 32)
        Me.Label8.TabIndex = 302
        Me.Label8.Text = "下記の棚へ行先変更しますか？"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdManual
        '
        Me.cmdManual.BackColor = System.Drawing.Color.DarkGray
        Me.cmdManual.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdManual.ForeColor = System.Drawing.Color.Black
        Me.cmdManual.Location = New System.Drawing.Point(489, 116)
        Me.cmdManual.Name = "cmdManual"
        Me.cmdManual.Size = New System.Drawing.Size(216, 40)
        Me.cmdManual.TabIndex = 300
        Me.cmdManual.Text = "手動払出"
        Me.cmdManual.UseVisualStyleBackColor = False
        Me.cmdManual.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(489, 184)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 301
        Me.cmdCancel.Text = "戻る"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdToChange
        '
        Me.cmdToChange.BackColor = System.Drawing.Color.DarkGray
        Me.cmdToChange.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdToChange.ForeColor = System.Drawing.Color.Black
        Me.cmdToChange.Location = New System.Drawing.Point(489, 52)
        Me.cmdToChange.Name = "cmdToChange"
        Me.cmdToChange.Size = New System.Drawing.Size(216, 40)
        Me.cmdToChange.TabIndex = 299
        Me.cmdToChange.Text = "行先変更指令"
        Me.cmdToChange.UseVisualStyleBackColor = False
        '
        'FRM_202001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(734, 249)
        Me.Controls.Add(Me.txtRAC_DAN_TO)
        Me.Controls.Add(Me.txtRAC_REN_TO)
        Me.Controls.Add(Me.txtRAC_RETU_TO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdManual)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdToChange)
        Me.Name = "FRM_202001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "二重格納対応操作"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRAC_DAN_TO As MateCommon.cmpMTextBoxString
    Friend WithEvents txtRAC_REN_TO As MateCommon.cmpMTextBoxString
    Friend WithEvents txtRAC_RETU_TO As MateCommon.cmpMTextBoxString
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdManual As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdToChange As System.Windows.Forms.Button

End Class
