<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100006
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdChange = New System.Windows.Forms.Button
        Me.txtReFPASS_WORD = New MateCommon.cmpMTextBoxString
        Me.txtFPASS_WORD = New MateCommon.cmpMTextBoxString
        Me.txtFLOGIN_ID = New MateCommon.cmpMTextBoxString
        Me.lblFUSER_NAME = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 32)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "パスワード再入力:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 32)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "パスワード:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 32)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "ユーザー名:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 32)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "ユーザーID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(344, 248)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(208, 40)
        Me.cmdCancel.TabIndex = 71
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdChange
        '
        Me.cmdChange.BackColor = System.Drawing.Color.DarkGray
        Me.cmdChange.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdChange.ForeColor = System.Drawing.Color.Black
        Me.cmdChange.Location = New System.Drawing.Point(40, 248)
        Me.cmdChange.Name = "cmdChange"
        Me.cmdChange.Size = New System.Drawing.Size(208, 40)
        Me.cmdChange.TabIndex = 70
        Me.cmdChange.Text = "変更"
        Me.cmdChange.UseVisualStyleBackColor = False
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
        Me.txtReFPASS_WORD.Location = New System.Drawing.Point(206, 172)
        Me.txtReFPASS_WORD.MaxLength = 8
        Me.txtReFPASS_WORD.MaxLengthByte = 0
        Me.txtReFPASS_WORD.Name = "txtReFPASS_WORD"
        Me.txtReFPASS_WORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtReFPASS_WORD.RegexCustomFalse = Nothing
        Me.txtReFPASS_WORD.RegexCustomTrue = Nothing
        Me.txtReFPASS_WORD.Size = New System.Drawing.Size(248, 26)
        Me.txtReFPASS_WORD.TabIndex = 62
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
        Me.txtFPASS_WORD.Location = New System.Drawing.Point(206, 124)
        Me.txtFPASS_WORD.MaxLength = 8
        Me.txtFPASS_WORD.MaxLengthByte = 0
        Me.txtFPASS_WORD.Name = "txtFPASS_WORD"
        Me.txtFPASS_WORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFPASS_WORD.RegexCustomFalse = Nothing
        Me.txtFPASS_WORD.RegexCustomTrue = Nothing
        Me.txtFPASS_WORD.Size = New System.Drawing.Size(248, 26)
        Me.txtFPASS_WORD.TabIndex = 61
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
        Me.txtFLOGIN_ID.Location = New System.Drawing.Point(206, 20)
        Me.txtFLOGIN_ID.MaxLength = 8
        Me.txtFLOGIN_ID.MaxLengthByte = 0
        Me.txtFLOGIN_ID.Name = "txtFLOGIN_ID"
        Me.txtFLOGIN_ID.RegexCustomFalse = Nothing
        Me.txtFLOGIN_ID.RegexCustomTrue = Nothing
        Me.txtFLOGIN_ID.Size = New System.Drawing.Size(248, 26)
        Me.txtFLOGIN_ID.TabIndex = 60
        '
        'lblFUSER_NAME
        '
        Me.lblFUSER_NAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFUSER_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblFUSER_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblFUSER_NAME.Location = New System.Drawing.Point(206, 59)
        Me.lblFUSER_NAME.Name = "lblFUSER_NAME"
        Me.lblFUSER_NAME.Size = New System.Drawing.Size(328, 26)
        Me.lblFUSER_NAME.TabIndex = 264
        Me.lblFUSER_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_100006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(601, 305)
        Me.Controls.Add(Me.txtReFPASS_WORD)
        Me.Controls.Add(Me.txtFPASS_WORD)
        Me.Controls.Add(Me.txtFLOGIN_ID)
        Me.Controls.Add(Me.lblFUSER_NAME)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdChange)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FRM_100006"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "パスワード変更"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdChange As System.Windows.Forms.Button
    Friend WithEvents txtReFPASS_WORD As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFPASS_WORD As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFLOGIN_ID As MateCommon.cmpMTextBoxString
    Friend WithEvents lblFUSER_NAME As System.Windows.Forms.Label

End Class
