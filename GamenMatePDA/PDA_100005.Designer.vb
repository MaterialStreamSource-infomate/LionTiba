<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA_100005
    Inherits GamenMatePDA.PDA_000001

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
        Me.cmdLogoff = New System.Windows.Forms.Button
        Me.cmdLogin = New System.Windows.Forms.Button
        Me.txtPassCd = New MateCommon.cmpMTextBoxString
        Me.lblUserName = New System.Windows.Forms.Label
        Me.lblUserCd = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdLogoff
        '
        Me.cmdLogoff.BackColor = System.Drawing.Color.Navy
        Me.cmdLogoff.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdLogoff.ForeColor = System.Drawing.Color.White
        Me.cmdLogoff.Location = New System.Drawing.Point(304, 160)
        Me.cmdLogoff.Name = "cmdLogoff"
        Me.cmdLogoff.Size = New System.Drawing.Size(128, 40)
        Me.cmdLogoff.TabIndex = 54
        Me.cmdLogoff.Text = "強制ログオフ"
        Me.cmdLogoff.UseVisualStyleBackColor = False
        '
        'cmdLogin
        '
        Me.cmdLogin.BackColor = System.Drawing.Color.Navy
        Me.cmdLogin.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdLogin.ForeColor = System.Drawing.Color.White
        Me.cmdLogin.Location = New System.Drawing.Point(41, 160)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(128, 40)
        Me.cmdLogin.TabIndex = 53
        Me.cmdLogin.Text = "ログイン"
        Me.cmdLogin.UseVisualStyleBackColor = False
        '
        'txtPassCd
        '
        Me.txtPassCd.BackColor = System.Drawing.Color.White
        Me.txtPassCd.BackColorMask = System.Drawing.Color.Empty
        Me.txtPassCd.EnabledFull = True
        Me.txtPassCd.EnabledFullAlphabetLower = False
        Me.txtPassCd.EnabledFullAlphabetUpper = False
        Me.txtPassCd.EnabledFullHiragana = False
        Me.txtPassCd.EnabledFullKatakana = False
        Me.txtPassCd.EnabledFullNumber = False
        Me.txtPassCd.EnabledHalf = True
        Me.txtPassCd.EnabledHalfAlphabetLower = True
        Me.txtPassCd.EnabledHalfAlphabetUpper = True
        Me.txtPassCd.EnabledHalfKatakana = True
        Me.txtPassCd.EnabledHalfNumber = True
        Me.txtPassCd.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPassCd.Location = New System.Drawing.Point(164, 88)
        Me.txtPassCd.MaxLength = 8
        Me.txtPassCd.MaxLengthByte = 0
        Me.txtPassCd.Name = "txtPassCd"
        Me.txtPassCd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassCd.RegexCustomFalse = Nothing
        Me.txtPassCd.RegexCustomTrue = Nothing
        Me.txtPassCd.Size = New System.Drawing.Size(248, 31)
        Me.txtPassCd.TabIndex = 52
        '
        'lblUserName
        '
        Me.lblUserName.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Black
        Me.lblUserName.Location = New System.Drawing.Point(315, 48)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(163, 30)
        Me.lblUserName.TabIndex = 59
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserCd
        '
        Me.lblUserCd.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUserCd.ForeColor = System.Drawing.Color.Black
        Me.lblUserCd.Location = New System.Drawing.Point(159, 48)
        Me.lblUserCd.Name = "lblUserCd"
        Me.lblUserCd.Size = New System.Drawing.Size(157, 30)
        Me.lblUserCd.TabIndex = 58
        Me.lblUserCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(480, 32)
        Me.lblTitle.TabIndex = 57
        Me.lblTitle.Text = "離席ログイン設定"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(10, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 32)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "パスワード:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 30)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "担当者コード:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PDA_100005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(478, 208)
        Me.Controls.Add(Me.cmdLogoff)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.txtPassCd)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lblUserCd)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Location = New System.Drawing.Point(0, 200)
        Me.Name = "PDA_100005"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdLogoff As System.Windows.Forms.Button
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents txtPassCd As MateCommon.cmpMTextBoxString
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblUserCd As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
