<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA_100007
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
        Me.txtFPASS_WORD = New MateCommon.cmpMTextBoxString
        Me.txtFLOGIN_ID = New MateCommon.cmpMTextBoxString
        Me.lblFUSER_NAME = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(480, 32)
        Me.lblTitle.TabIndex = 287
        Me.lblTitle.Text = "パスワード確認"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtFPASS_WORD.Location = New System.Drawing.Point(164, 135)
        Me.txtFPASS_WORD.MaxLength = 8
        Me.txtFPASS_WORD.MaxLengthByte = 0
        Me.txtFPASS_WORD.Name = "txtFPASS_WORD"
        Me.txtFPASS_WORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFPASS_WORD.RegexCustomFalse = Nothing
        Me.txtFPASS_WORD.RegexCustomTrue = Nothing
        Me.txtFPASS_WORD.Size = New System.Drawing.Size(248, 26)
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
        Me.txtFLOGIN_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtFLOGIN_ID.Location = New System.Drawing.Point(164, 55)
        Me.txtFLOGIN_ID.MaxLength = 8
        Me.txtFLOGIN_ID.MaxLengthByte = 0
        Me.txtFLOGIN_ID.Name = "txtFLOGIN_ID"
        Me.txtFLOGIN_ID.RegexCustomFalse = Nothing
        Me.txtFLOGIN_ID.RegexCustomTrue = Nothing
        Me.txtFLOGIN_ID.Size = New System.Drawing.Size(248, 26)
        Me.txtFLOGIN_ID.TabIndex = 1
        '
        'lblFUSER_NAME
        '
        Me.lblFUSER_NAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFUSER_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblFUSER_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblFUSER_NAME.Location = New System.Drawing.Point(164, 94)
        Me.lblFUSER_NAME.Name = "lblFUSER_NAME"
        Me.lblFUSER_NAME.Size = New System.Drawing.Size(248, 26)
        Me.lblFUSER_NAME.TabIndex = 284
        Me.lblFUSER_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.Navy
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(313, 184)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(128, 40)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.Navy
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdZikkou.ForeColor = System.Drawing.Color.White
        Me.cmdZikkou.Location = New System.Drawing.Point(37, 184)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(128, 40)
        Me.cmdZikkou.TabIndex = 11
        Me.cmdZikkou.Text = "確認"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 32)
        Me.Label3.TabIndex = 281
        Me.Label3.Text = "パスワード:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "ユーザー名:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 279
        Me.Label1.Text = "ユーザーID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PDA_100007
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(478, 243)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtFPASS_WORD)
        Me.Controls.Add(Me.txtFLOGIN_ID)
        Me.Controls.Add(Me.lblFUSER_NAME)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Location = New System.Drawing.Point(0, 150)
        Me.Name = "PDA_100007"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtFPASS_WORD As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFLOGIN_ID As MateCommon.cmpMTextBoxString
    Friend WithEvents lblFUSER_NAME As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
