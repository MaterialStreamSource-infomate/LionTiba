<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307151
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdCorrection = New System.Windows.Forms.Button
        Me.txtSTNo = New MateCommon.cmpMTextBoxString
        Me.txtITF = New MateCommon.cmpMTextBoxString
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 32)
        Me.Label1.TabIndex = 270
        Me.Label1.Text = "ST№"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(279, 124)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdCorrection
        '
        Me.cmdCorrection.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCorrection.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCorrection.ForeColor = System.Drawing.Color.Black
        Me.cmdCorrection.Location = New System.Drawing.Point(23, 124)
        Me.cmdCorrection.Name = "cmdCorrection"
        Me.cmdCorrection.Size = New System.Drawing.Size(216, 40)
        Me.cmdCorrection.TabIndex = 2
        Me.cmdCorrection.Text = "修正"
        Me.cmdCorrection.UseVisualStyleBackColor = False
        '
        'txtSTNo
        '
        Me.txtSTNo.BackColor = System.Drawing.Color.LightGray
        Me.txtSTNo.BackColorMask = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSTNo.EnabledFull = True
        Me.txtSTNo.EnabledFullAlphabetLower = False
        Me.txtSTNo.EnabledFullAlphabetUpper = False
        Me.txtSTNo.EnabledFullHiragana = False
        Me.txtSTNo.EnabledFullKatakana = False
        Me.txtSTNo.EnabledFullNumber = False
        Me.txtSTNo.EnabledHalf = True
        Me.txtSTNo.EnabledHalfAlphabetLower = True
        Me.txtSTNo.EnabledHalfAlphabetUpper = True
        Me.txtSTNo.EnabledHalfKatakana = True
        Me.txtSTNo.EnabledHalfNumber = True
        Me.txtSTNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSTNo.Location = New System.Drawing.Point(23, 58)
        Me.txtSTNo.MaxLength = 8
        Me.txtSTNo.MaxLengthByte = 0
        Me.txtSTNo.Name = "txtSTNo"
        Me.txtSTNo.ReadOnly = True
        Me.txtSTNo.RegexCustomFalse = Nothing
        Me.txtSTNo.RegexCustomTrue = Nothing
        Me.txtSTNo.Size = New System.Drawing.Size(91, 26)
        Me.txtSTNo.TabIndex = 271
        '
        'txtITF
        '
        Me.txtITF.BackColor = System.Drawing.Color.White
        Me.txtITF.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF.EnabledFull = True
        Me.txtITF.EnabledFullAlphabetLower = False
        Me.txtITF.EnabledFullAlphabetUpper = False
        Me.txtITF.EnabledFullHiragana = False
        Me.txtITF.EnabledFullKatakana = False
        Me.txtITF.EnabledFullNumber = False
        Me.txtITF.EnabledHalf = True
        Me.txtITF.EnabledHalfAlphabetLower = True
        Me.txtITF.EnabledHalfAlphabetUpper = True
        Me.txtITF.EnabledHalfKatakana = True
        Me.txtITF.EnabledHalfNumber = True
        Me.txtITF.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF.Location = New System.Drawing.Point(120, 58)
        Me.txtITF.MaxLength = 14
        Me.txtITF.MaxLengthByte = 0
        Me.txtITF.Name = "txtITF"
        Me.txtITF.RegexCustomFalse = Nothing
        Me.txtITF.RegexCustomTrue = Nothing
        Me.txtITF.Size = New System.Drawing.Size(358, 26)
        Me.txtITF.TabIndex = 272
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(120, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 32)
        Me.Label2.TabIndex = 273
        Me.Label2.Text = "ITF"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_307151
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(534, 182)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtITF)
        Me.Controls.Add(Me.txtSTNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdCorrection)
        Me.Name = "FRM_307151"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PLCメンテナンス(BCR)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdCorrection As System.Windows.Forms.Button
    Friend WithEvents txtSTNo As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF As MateCommon.cmpMTextBoxString
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
