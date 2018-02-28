<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA_100001
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
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFPASS_WORD = New MateCommon.cmpMTextBoxString
        Me.txtFLOGIN_ID = New MateCommon.cmpMTextBoxString
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdF4 = New System.Windows.Forms.Button
        Me.cmdF3 = New System.Windows.Forms.Button
        Me.cmdF2 = New System.Windows.Forms.Button
        Me.cmdF1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(480, 40)
        Me.lblTitle.TabIndex = 273
        Me.lblTitle.Text = "ログイン"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(0, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(480, 71)
        Me.Label2.TabIndex = 276
        Me.Label2.Text = "担当者コードとパスワードを" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "入力して下さい"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtFPASS_WORD.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtFPASS_WORD.Location = New System.Drawing.Point(197, 201)
        Me.txtFPASS_WORD.MaxLength = 8
        Me.txtFPASS_WORD.MaxLengthByte = 0
        Me.txtFPASS_WORD.Name = "txtFPASS_WORD"
        Me.txtFPASS_WORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFPASS_WORD.RegexCustomFalse = Nothing
        Me.txtFPASS_WORD.RegexCustomTrue = Nothing
        Me.txtFPASS_WORD.Size = New System.Drawing.Size(248, 31)
        Me.txtFPASS_WORD.TabIndex = 2
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
        Me.txtFLOGIN_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtFLOGIN_ID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtFLOGIN_ID.Location = New System.Drawing.Point(197, 150)
        Me.txtFLOGIN_ID.MaxLength = 8
        Me.txtFLOGIN_ID.MaxLengthByte = 0
        Me.txtFLOGIN_ID.Name = "txtFLOGIN_ID"
        Me.txtFLOGIN_ID.RegexCustomFalse = Nothing
        Me.txtFLOGIN_ID.RegexCustomTrue = Nothing
        Me.txtFLOGIN_ID.Size = New System.Drawing.Size(248, 31)
        Me.txtFLOGIN_ID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(13, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 32)
        Me.Label3.TabIndex = 284
        Me.Label3.Text = "パスワード:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 32)
        Me.Label1.TabIndex = 283
        Me.Label1.Text = "担当者コード:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdF4
        '
        Me.cmdF4.BackColor = System.Drawing.Color.OrangeRed
        Me.cmdF4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF4.ForeColor = System.Drawing.Color.White
        Me.cmdF4.Location = New System.Drawing.Point(367, 592)
        Me.cmdF4.Name = "cmdF4"
        Me.cmdF4.Size = New System.Drawing.Size(96, 40)
        Me.cmdF4.TabIndex = 104
        Me.cmdF4.Text = "入力確認"
        Me.cmdF4.UseVisualStyleBackColor = False
        '
        'cmdF3
        '
        Me.cmdF3.BackColor = System.Drawing.Color.DarkGreen
        Me.cmdF3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF3.ForeColor = System.Drawing.Color.White
        Me.cmdF3.Location = New System.Drawing.Point(260, 592)
        Me.cmdF3.Name = "cmdF3"
        Me.cmdF3.Size = New System.Drawing.Size(96, 40)
        Me.cmdF3.TabIndex = 103
        Me.cmdF3.TabStop = False
        Me.cmdF3.UseVisualStyleBackColor = False
        '
        'cmdF2
        '
        Me.cmdF2.BackColor = System.Drawing.Color.DarkBlue
        Me.cmdF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF2.ForeColor = System.Drawing.Color.White
        Me.cmdF2.Location = New System.Drawing.Point(117, 592)
        Me.cmdF2.Name = "cmdF2"
        Me.cmdF2.Size = New System.Drawing.Size(96, 40)
        Me.cmdF2.TabIndex = 102
        Me.cmdF2.TabStop = False
        Me.cmdF2.UseVisualStyleBackColor = False
        '
        'cmdF1
        '
        Me.cmdF1.BackColor = System.Drawing.Color.DarkRed
        Me.cmdF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF1.ForeColor = System.Drawing.Color.White
        Me.cmdF1.Location = New System.Drawing.Point(10, 592)
        Me.cmdF1.Name = "cmdF1"
        Me.cmdF1.Size = New System.Drawing.Size(96, 40)
        Me.cmdF1.TabIndex = 101
        Me.cmdF1.Text = "終了"
        Me.cmdF1.UseVisualStyleBackColor = False
        '
        'PDA_100001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(478, 638)
        Me.Controls.Add(Me.txtFPASS_WORD)
        Me.Controls.Add(Me.txtFLOGIN_ID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdF4)
        Me.Controls.Add(Me.cmdF3)
        Me.Controls.Add(Me.cmdF2)
        Me.Controls.Add(Me.cmdF1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "PDA_100001"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFPASS_WORD As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFLOGIN_ID As MateCommon.cmpMTextBoxString
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdF4 As System.Windows.Forms.Button
    Friend WithEvents cmdF3 As System.Windows.Forms.Button
    Friend WithEvents cmdF2 As System.Windows.Forms.Button
    Friend WithEvents cmdF1 As System.Windows.Forms.Button

End Class
