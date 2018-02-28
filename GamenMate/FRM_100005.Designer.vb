<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100005
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblEmpName = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdLogoff = New System.Windows.Forms.Button
        Me.cmdLogin = New System.Windows.Forms.Button
        Me.cmdPassChng = New System.Windows.Forms.Button
        Me.txtFLOGIN_ID = New MateCommon.cmpMTextBoxString
        Me.txtFPASS_WORD = New MateCommon.cmpMTextBoxString
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 32)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ユーザーID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEmpName
        '
        Me.lblEmpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblEmpName.ForeColor = System.Drawing.Color.Black
        Me.lblEmpName.Location = New System.Drawing.Point(432, 24)
        Me.lblEmpName.Name = "lblEmpName"
        Me.lblEmpName.Size = New System.Drawing.Size(224, 32)
        Me.lblEmpName.TabIndex = 44
        Me.lblEmpName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(0, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 32)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "パスワード:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdLogoff
        '
        Me.cmdLogoff.BackColor = System.Drawing.Color.DarkGray
        Me.cmdLogoff.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdLogoff.ForeColor = System.Drawing.Color.Black
        Me.cmdLogoff.Location = New System.Drawing.Point(432, 136)
        Me.cmdLogoff.Name = "cmdLogoff"
        Me.cmdLogoff.Size = New System.Drawing.Size(208, 40)
        Me.cmdLogoff.TabIndex = 48
        Me.cmdLogoff.Text = "強制ログオフ"
        Me.cmdLogoff.UseVisualStyleBackColor = False
        '
        'cmdLogin
        '
        Me.cmdLogin.BackColor = System.Drawing.Color.DarkGray
        Me.cmdLogin.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdLogin.ForeColor = System.Drawing.Color.Black
        Me.cmdLogin.Location = New System.Drawing.Point(24, 136)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(208, 40)
        Me.cmdLogin.TabIndex = 47
        Me.cmdLogin.Text = "ログイン"
        Me.cmdLogin.UseVisualStyleBackColor = False
        '
        'cmdPassChng
        '
        Me.cmdPassChng.BackColor = System.Drawing.Color.DarkGray
        Me.cmdPassChng.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdPassChng.ForeColor = System.Drawing.Color.Black
        Me.cmdPassChng.Location = New System.Drawing.Point(440, 72)
        Me.cmdPassChng.Name = "cmdPassChng"
        Me.cmdPassChng.Size = New System.Drawing.Size(64, 32)
        Me.cmdPassChng.TabIndex = 49
        Me.cmdPassChng.Text = "変更"
        Me.cmdPassChng.UseVisualStyleBackColor = False
        '
        'txtFLOGIN_ID
        '
        Me.txtFLOGIN_ID.BackColor = System.Drawing.Color.White
        Me.txtFLOGIN_ID.BackColorMask = System.Drawing.Color.Empty
        Me.txtFLOGIN_ID.EnabledFull = True
        Me.txtFLOGIN_ID.EnabledFullAlphabetLower = False
        Me.txtFLOGIN_ID.EnabledFullAlphabetUpper = False
        Me.txtFLOGIN_ID.EnabledFullHiragana = False
        Me.txtFLOGIN_ID.EnabledFullKatakana = False
        Me.txtFLOGIN_ID.EnabledFullNumber = False
        Me.txtFLOGIN_ID.EnabledHalf = True
        Me.txtFLOGIN_ID.EnabledHalfAlphabetLower = True
        Me.txtFLOGIN_ID.EnabledHalfAlphabetUpper = True
        Me.txtFLOGIN_ID.EnabledHalfKatakana = True
        Me.txtFLOGIN_ID.EnabledHalfNumber = True
        Me.txtFLOGIN_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtFLOGIN_ID.Location = New System.Drawing.Point(168, 28)
        Me.txtFLOGIN_ID.MaxLength = 8
        Me.txtFLOGIN_ID.MaxLengthByte = 0
        Me.txtFLOGIN_ID.Name = "txtFLOGIN_ID"
        Me.txtFLOGIN_ID.RegexCustomFalse = Nothing
        Me.txtFLOGIN_ID.RegexCustomTrue = Nothing
        Me.txtFLOGIN_ID.Size = New System.Drawing.Size(248, 26)
        Me.txtFLOGIN_ID.TabIndex = 40
        '
        'txtFPASS_WORD
        '
        Me.txtFPASS_WORD.BackColor = System.Drawing.Color.White
        Me.txtFPASS_WORD.BackColorMask = System.Drawing.Color.Empty
        Me.txtFPASS_WORD.EnabledFull = True
        Me.txtFPASS_WORD.EnabledFullAlphabetLower = False
        Me.txtFPASS_WORD.EnabledFullAlphabetUpper = False
        Me.txtFPASS_WORD.EnabledFullHiragana = False
        Me.txtFPASS_WORD.EnabledFullKatakana = False
        Me.txtFPASS_WORD.EnabledFullNumber = False
        Me.txtFPASS_WORD.EnabledHalf = True
        Me.txtFPASS_WORD.EnabledHalfAlphabetLower = True
        Me.txtFPASS_WORD.EnabledHalfAlphabetUpper = True
        Me.txtFPASS_WORD.EnabledHalfKatakana = True
        Me.txtFPASS_WORD.EnabledHalfNumber = True
        Me.txtFPASS_WORD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtFPASS_WORD.Location = New System.Drawing.Point(168, 75)
        Me.txtFPASS_WORD.MaxLength = 8
        Me.txtFPASS_WORD.MaxLengthByte = 0
        Me.txtFPASS_WORD.Name = "txtFPASS_WORD"
        Me.txtFPASS_WORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFPASS_WORD.RegexCustomFalse = Nothing
        Me.txtFPASS_WORD.RegexCustomTrue = Nothing
        Me.txtFPASS_WORD.Size = New System.Drawing.Size(248, 26)
        Me.txtFPASS_WORD.TabIndex = 41
        '
        'FRM_100005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 195)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtFPASS_WORD)
        Me.Controls.Add(Me.txtFLOGIN_ID)
        Me.Controls.Add(Me.cmdPassChng)
        Me.Controls.Add(Me.cmdLogoff)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblEmpName)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_100005"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "離席ログイン設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEmpName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdLogoff As System.Windows.Forms.Button
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents cmdPassChng As System.Windows.Forms.Button
    Friend WithEvents txtFLOGIN_ID As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFPASS_WORD As MateCommon.cmpMTextBoxString
End Class
