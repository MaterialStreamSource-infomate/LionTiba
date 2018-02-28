<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_306051
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
        Me.txtXMAKER_NAME = New MateCommon.cmpMTextBoxString
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtXMAKER_CD = New MateCommon.cmpMTextBoxString
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(352, 149)
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
        Me.cmdZikkou.Location = New System.Drawing.Point(80, 149)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 3
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'txtXMAKER_NAME
        '
        Me.txtXMAKER_NAME.BackColorMask = System.Drawing.Color.Empty
        Me.txtXMAKER_NAME.EnabledFull = True
        Me.txtXMAKER_NAME.EnabledFullAlphabetLower = True
        Me.txtXMAKER_NAME.EnabledFullAlphabetUpper = True
        Me.txtXMAKER_NAME.EnabledFullHiragana = True
        Me.txtXMAKER_NAME.EnabledFullKatakana = True
        Me.txtXMAKER_NAME.EnabledFullNumber = True
        Me.txtXMAKER_NAME.EnabledHalf = True
        Me.txtXMAKER_NAME.EnabledHalfAlphabetLower = True
        Me.txtXMAKER_NAME.EnabledHalfAlphabetUpper = True
        Me.txtXMAKER_NAME.EnabledHalfKatakana = True
        Me.txtXMAKER_NAME.EnabledHalfNumber = True
        Me.txtXMAKER_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXMAKER_NAME.Location = New System.Drawing.Point(199, 66)
        Me.txtXMAKER_NAME.MaxLength = 128
        Me.txtXMAKER_NAME.MaxLengthByte = 128
        Me.txtXMAKER_NAME.Name = "txtXMAKER_NAME"
        Me.txtXMAKER_NAME.RegexCustomFalse = Nothing
        Me.txtXMAKER_NAME.RegexCustomTrue = Nothing
        Me.txtXMAKER_NAME.Size = New System.Drawing.Size(467, 27)
        Me.txtXMAKER_NAME.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(47, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "メーカー名:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 32)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "メーカーコード:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXMAKER_CD
        '
        Me.txtXMAKER_CD.BackColorMask = System.Drawing.Color.Empty
        Me.txtXMAKER_CD.EnabledFull = True
        Me.txtXMAKER_CD.EnabledFullAlphabetLower = True
        Me.txtXMAKER_CD.EnabledFullAlphabetUpper = True
        Me.txtXMAKER_CD.EnabledFullHiragana = True
        Me.txtXMAKER_CD.EnabledFullKatakana = True
        Me.txtXMAKER_CD.EnabledFullNumber = True
        Me.txtXMAKER_CD.EnabledHalf = True
        Me.txtXMAKER_CD.EnabledHalfAlphabetLower = True
        Me.txtXMAKER_CD.EnabledHalfAlphabetUpper = True
        Me.txtXMAKER_CD.EnabledHalfKatakana = True
        Me.txtXMAKER_CD.EnabledHalfNumber = True
        Me.txtXMAKER_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXMAKER_CD.Location = New System.Drawing.Point(199, 26)
        Me.txtXMAKER_CD.MaxLength = 5
        Me.txtXMAKER_CD.MaxLengthByte = 5
        Me.txtXMAKER_CD.Name = "txtXMAKER_CD"
        Me.txtXMAKER_CD.RegexCustomFalse = Nothing
        Me.txtXMAKER_CD.RegexCustomTrue = Nothing
        Me.txtXMAKER_CD.Size = New System.Drawing.Size(107, 27)
        Me.txtXMAKER_CD.TabIndex = 1
        '
        'FRM_306051
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(698, 204)
        Me.Controls.Add(Me.txtXMAKER_CD)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.txtXMAKER_NAME)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FRM_306051"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "包装材料ﾒｰｶﾏｽﾀ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents txtXMAKER_NAME As MateCommon.cmpMTextBoxString
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtXMAKER_CD As MateCommon.cmpMTextBoxString

End Class
