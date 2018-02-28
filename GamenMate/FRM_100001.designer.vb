<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100001
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
        Me.cmdF8 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdF1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblFUSER_NAME = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdPassChng = New System.Windows.Forms.Button
        Me.txtFLOGIN_ID = New MateCommon.cmpMTextBoxString
        Me.txtFPASS_WORD = New MateCommon.cmpMTextBoxString
        Me.txtReFPASS_WORD = New MateCommon.cmpMTextBoxString
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.BackColor = System.Drawing.Color.DarkGray
        Me.cmdF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF8.ForeColor = System.Drawing.Color.Black
        Me.cmdF8.Location = New System.Drawing.Point(288, 296)
        Me.cmdF8.Name = "cmdF8"
        Me.cmdF8.Size = New System.Drawing.Size(104, 40)
        Me.cmdF8.TabIndex = 51
        Me.cmdF8.Text = "Close"
        Me.cmdF8.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(288, 264)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "F8"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdF1
        '
        Me.cmdF1.BackColor = System.Drawing.Color.DarkGray
        Me.cmdF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF1.ForeColor = System.Drawing.Color.Black
        Me.cmdF1.Location = New System.Drawing.Point(136, 296)
        Me.cmdF1.Name = "cmdF1"
        Me.cmdF1.Size = New System.Drawing.Size(104, 40)
        Me.cmdF1.TabIndex = 50
        Me.cmdF1.Text = "OK"
        Me.cmdF1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(136, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 23)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "F1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFUSER_NAME
        '
        Me.lblFUSER_NAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFUSER_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblFUSER_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblFUSER_NAME.Location = New System.Drawing.Point(200, 131)
        Me.lblFUSER_NAME.Name = "lblFUSER_NAME"
        Me.lblFUSER_NAME.Size = New System.Drawing.Size(328, 26)
        Me.lblFUSER_NAME.TabIndex = 55
        Me.lblFUSER_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 32)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "パスワード:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 32)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "ユーザー名:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 32)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "ユーザーID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.Location = New System.Drawing.Point(0, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(552, 40)
        Me.lblTitle.TabIndex = 51
        Me.lblTitle.Text = "◆ ログイン画面 ◆"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 32)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "パスワード再入力:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdPassChng
        '
        Me.cmdPassChng.BackColor = System.Drawing.Color.DarkGray
        Me.cmdPassChng.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdPassChng.ForeColor = System.Drawing.Color.Black
        Me.cmdPassChng.Location = New System.Drawing.Point(464, 168)
        Me.cmdPassChng.Name = "cmdPassChng"
        Me.cmdPassChng.Size = New System.Drawing.Size(64, 32)
        Me.cmdPassChng.TabIndex = 52
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
        Me.txtFLOGIN_ID.Location = New System.Drawing.Point(200, 92)
        Me.txtFLOGIN_ID.MaxLength = 8
        Me.txtFLOGIN_ID.MaxLengthByte = 0
        Me.txtFLOGIN_ID.Name = "txtFLOGIN_ID"
        Me.txtFLOGIN_ID.RegexCustomFalse = Nothing
        Me.txtFLOGIN_ID.RegexCustomTrue = Nothing
        Me.txtFLOGIN_ID.Size = New System.Drawing.Size(248, 26)
        Me.txtFLOGIN_ID.TabIndex = 10
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
        Me.txtFPASS_WORD.Location = New System.Drawing.Point(200, 172)
        Me.txtFPASS_WORD.MaxLength = 8
        Me.txtFPASS_WORD.MaxLengthByte = 0
        Me.txtFPASS_WORD.Name = "txtFPASS_WORD"
        Me.txtFPASS_WORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFPASS_WORD.RegexCustomFalse = Nothing
        Me.txtFPASS_WORD.RegexCustomTrue = Nothing
        Me.txtFPASS_WORD.Size = New System.Drawing.Size(248, 26)
        Me.txtFPASS_WORD.TabIndex = 11
        '
        'txtReFPASS_WORD
        '
        Me.txtReFPASS_WORD.BackColor = System.Drawing.Color.White
        Me.txtReFPASS_WORD.BackColorMask = System.Drawing.Color.Empty
        Me.txtReFPASS_WORD.EnabledFull = True
        Me.txtReFPASS_WORD.EnabledFullAlphabetLower = False
        Me.txtReFPASS_WORD.EnabledFullAlphabetUpper = False
        Me.txtReFPASS_WORD.EnabledFullHiragana = False
        Me.txtReFPASS_WORD.EnabledFullKatakana = False
        Me.txtReFPASS_WORD.EnabledFullNumber = False
        Me.txtReFPASS_WORD.EnabledHalf = True
        Me.txtReFPASS_WORD.EnabledHalfAlphabetLower = True
        Me.txtReFPASS_WORD.EnabledHalfAlphabetUpper = True
        Me.txtReFPASS_WORD.EnabledHalfKatakana = True
        Me.txtReFPASS_WORD.EnabledHalfNumber = True
        Me.txtReFPASS_WORD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReFPASS_WORD.Location = New System.Drawing.Point(200, 212)
        Me.txtReFPASS_WORD.MaxLength = 8
        Me.txtReFPASS_WORD.MaxLengthByte = 0
        Me.txtReFPASS_WORD.Name = "txtReFPASS_WORD"
        Me.txtReFPASS_WORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtReFPASS_WORD.RegexCustomFalse = Nothing
        Me.txtReFPASS_WORD.RegexCustomTrue = Nothing
        Me.txtReFPASS_WORD.Size = New System.Drawing.Size(248, 26)
        Me.txtReFPASS_WORD.TabIndex = 12
        '
        'FRM_100001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 373)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtReFPASS_WORD)
        Me.Controls.Add(Me.txtFPASS_WORD)
        Me.Controls.Add(Me.txtFLOGIN_ID)
        Me.Controls.Add(Me.cmdPassChng)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdF8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdF1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblFUSER_NAME)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitle)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(560, 400)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(560, 400)
        Me.Name = "FRM_100001"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ログイン画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdF8 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdF1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFUSER_NAME As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdPassChng As System.Windows.Forms.Button
    Friend WithEvents txtFLOGIN_ID As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFPASS_WORD As MateCommon.cmpMTextBoxString
    Friend WithEvents txtReFPASS_WORD As MateCommon.cmpMTextBoxString
End Class
