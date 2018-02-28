<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_306081
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
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.txtXDPL_PL_NAME = New MateCommon.cmpMTextBoxString
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtXDPL_PL_NO = New MateCommon.cmpMTextBoxString
        Me.cboFTRK_BUF_NO = New MateCommon.cmpMComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXPROD_LINE = New MateCommon.cmpMComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(2, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 32)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "生産ﾗｲﾝ№:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(372, 238)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(100, 238)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 5
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'txtXDPL_PL_NAME
        '
        Me.txtXDPL_PL_NAME.BackColorMask = System.Drawing.Color.Empty
        Me.txtXDPL_PL_NAME.EnabledFull = True
        Me.txtXDPL_PL_NAME.EnabledFullAlphabetLower = True
        Me.txtXDPL_PL_NAME.EnabledFullAlphabetUpper = True
        Me.txtXDPL_PL_NAME.EnabledFullHiragana = True
        Me.txtXDPL_PL_NAME.EnabledFullKatakana = True
        Me.txtXDPL_PL_NAME.EnabledFullNumber = True
        Me.txtXDPL_PL_NAME.EnabledHalf = True
        Me.txtXDPL_PL_NAME.EnabledHalfAlphabetLower = True
        Me.txtXDPL_PL_NAME.EnabledHalfAlphabetUpper = True
        Me.txtXDPL_PL_NAME.EnabledHalfKatakana = True
        Me.txtXDPL_PL_NAME.EnabledHalfNumber = True
        Me.txtXDPL_PL_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXDPL_PL_NAME.Location = New System.Drawing.Point(227, 91)
        Me.txtXDPL_PL_NAME.MaxLength = 80
        Me.txtXDPL_PL_NAME.MaxLengthByte = 80
        Me.txtXDPL_PL_NAME.Name = "txtXDPL_PL_NAME"
        Me.txtXDPL_PL_NAME.RegexCustomFalse = Nothing
        Me.txtXDPL_PL_NAME.RegexCustomTrue = Nothing
        Me.txtXDPL_PL_NAME.Size = New System.Drawing.Size(361, 27)
        Me.txtXDPL_PL_NAME.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 32)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "設備名称:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 32)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXDPL_PL_NO
        '
        Me.txtXDPL_PL_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXDPL_PL_NO.EnabledFull = True
        Me.txtXDPL_PL_NO.EnabledFullAlphabetLower = True
        Me.txtXDPL_PL_NO.EnabledFullAlphabetUpper = True
        Me.txtXDPL_PL_NO.EnabledFullHiragana = True
        Me.txtXDPL_PL_NO.EnabledFullKatakana = True
        Me.txtXDPL_PL_NO.EnabledFullNumber = True
        Me.txtXDPL_PL_NO.EnabledHalf = True
        Me.txtXDPL_PL_NO.EnabledHalfAlphabetLower = True
        Me.txtXDPL_PL_NO.EnabledHalfAlphabetUpper = True
        Me.txtXDPL_PL_NO.EnabledHalfKatakana = True
        Me.txtXDPL_PL_NO.EnabledHalfNumber = True
        Me.txtXDPL_PL_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXDPL_PL_NO.Location = New System.Drawing.Point(227, 41)
        Me.txtXDPL_PL_NO.MaxLength = 16
        Me.txtXDPL_PL_NO.MaxLengthByte = 16
        Me.txtXDPL_PL_NO.Name = "txtXDPL_PL_NO"
        Me.txtXDPL_PL_NO.RegexCustomFalse = Nothing
        Me.txtXDPL_PL_NO.RegexCustomTrue = Nothing
        Me.txtXDPL_PL_NO.Size = New System.Drawing.Size(192, 27)
        Me.txtXDPL_PL_NO.TabIndex = 1
        '
        'cboFTRK_BUF_NO
        '
        Me.cboFTRK_BUF_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO.IntegralHeight = False
        Me.cboFTRK_BUF_NO.Location = New System.Drawing.Point(227, 182)
        Me.cboFTRK_BUF_NO.Name = "cboFTRK_BUF_NO"
        Me.cboFTRK_BUF_NO.Size = New System.Drawing.Size(263, 28)
        Me.cboFTRK_BUF_NO.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(12, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(209, 32)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "入出庫ST:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXPROD_LINE
        '
        Me.cboXPROD_LINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXPROD_LINE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXPROD_LINE.FormattingEnabled = True
        Me.cboXPROD_LINE.IntegralHeight = False
        Me.cboXPROD_LINE.Location = New System.Drawing.Point(227, 133)
        Me.cboXPROD_LINE.Name = "cboXPROD_LINE"
        Me.cboXPROD_LINE.Size = New System.Drawing.Size(192, 28)
        Me.cboXPROD_LINE.TabIndex = 77
        '
        'FRM_306081
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(652, 291)
        Me.Controls.Add(Me.cboXPROD_LINE)
        Me.Controls.Add(Me.cboFTRK_BUF_NO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtXDPL_PL_NO)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.txtXDPL_PL_NAME)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FRM_306081"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents txtXDPL_PL_NAME As MateCommon.cmpMTextBoxString
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtXDPL_PL_NO As MateCommon.cmpMTextBoxString
    Friend WithEvents cboFTRK_BUF_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboXPROD_LINE As MateCommon.cmpMComboBox

End Class
