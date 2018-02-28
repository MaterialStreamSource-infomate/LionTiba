<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_311055
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
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_D = New GamenCommon.cmpMDateTimePicker_DT
        Me.txtXHENSEI_NO_OYA = New MateCommon.cmpMTextBoxString
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!)
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(286, 159)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 23
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.DarkGray
        Me.cmdPrint.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!)
        Me.cmdPrint.ForeColor = System.Drawing.Color.Black
        Me.cmdPrint.Location = New System.Drawing.Point(25, 159)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(216, 40)
        Me.cmdPrint.TabIndex = 24
        Me.cmdPrint.Text = "印刷"
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(63, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 32)
        Me.Label2.TabIndex = 221
        Me.Label2.Text = "出荷日:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(59, 34)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(147, 32)
        Me.Label20.TabIndex = 220
        Me.Label20.Text = "編成No.:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_D
        '
        Me.cboXSYUKKA_D.BackColorMask = System.Drawing.SystemColors.Control
        Me.cboXSYUKKA_D.Location = New System.Drawing.Point(210, 94)
        Me.cboXSYUKKA_D.Margin = New System.Windows.Forms.Padding(1)
        Me.cboXSYUKKA_D.Name = "cboXSYUKKA_D"
        Me.cboXSYUKKA_D.Size = New System.Drawing.Size(173, 32)
        Me.cboXSYUKKA_D.TabIndex = 222
        Me.cboXSYUKKA_D.TimeComboDisp = False
        Me.cboXSYUKKA_D.userChecked = True
        Me.cboXSYUKKA_D.userShowCheckBox = False
        '
        'txtXHENSEI_NO_OYA
        '
        Me.txtXHENSEI_NO_OYA.BackColorMask = System.Drawing.Color.Empty
        Me.txtXHENSEI_NO_OYA.EnabledFull = False
        Me.txtXHENSEI_NO_OYA.EnabledFullAlphabetLower = False
        Me.txtXHENSEI_NO_OYA.EnabledFullAlphabetUpper = False
        Me.txtXHENSEI_NO_OYA.EnabledFullHiragana = False
        Me.txtXHENSEI_NO_OYA.EnabledFullKatakana = False
        Me.txtXHENSEI_NO_OYA.EnabledFullNumber = False
        Me.txtXHENSEI_NO_OYA.EnabledHalf = True
        Me.txtXHENSEI_NO_OYA.EnabledHalfAlphabetLower = True
        Me.txtXHENSEI_NO_OYA.EnabledHalfAlphabetUpper = True
        Me.txtXHENSEI_NO_OYA.EnabledHalfKatakana = True
        Me.txtXHENSEI_NO_OYA.EnabledHalfNumber = True
        Me.txtXHENSEI_NO_OYA.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXHENSEI_NO_OYA.Location = New System.Drawing.Point(212, 37)
        Me.txtXHENSEI_NO_OYA.MaxLength = 4
        Me.txtXHENSEI_NO_OYA.MaxLengthByte = 4
        Me.txtXHENSEI_NO_OYA.Name = "txtXHENSEI_NO_OYA"
        Me.txtXHENSEI_NO_OYA.RegexCustomFalse = Nothing
        Me.txtXHENSEI_NO_OYA.RegexCustomTrue = Nothing
        Me.txtXHENSEI_NO_OYA.Size = New System.Drawing.Size(157, 27)
        Me.txtXHENSEI_NO_OYA.TabIndex = 223
        '
        'FRM_311055
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(529, 224)
        Me.Controls.Add(Me.txtXHENSEI_NO_OYA)
        Me.Controls.Add(Me.cboXSYUKKA_D)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "FRM_311055"
        Me.Text = "ﾋﾟｯｷﾝｸﾞﾘｽﾄ　印刷"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboXSYUKKA_D As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents txtXHENSEI_NO_OYA As MateCommon.cmpMTextBoxString

End Class
