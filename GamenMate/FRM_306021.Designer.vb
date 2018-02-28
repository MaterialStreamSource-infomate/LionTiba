<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_306021
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboXTUMI_HOUKOU = New MateCommon.cmpMComboBox
        Me.cboXTUMI_HOUHOU = New MateCommon.cmpMComboBox
        Me.cboXNOT_USER = New MateCommon.cmpMComboBox
        Me.txtXSYARYOU_NO = New MateCommon.cmpMTextBoxNumber
        Me.txtXSYASYU_COMMENT = New MateCommon.cmpMTextBoxString
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboXSYASYU_KBN = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboXGYOUSYA_CD = New MateCommon.cmpMComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXLOADER_POSSIBLE = New MateCommon.cmpMComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtXSYARYOU_MODE = New MateCommon.cmpMTextBoxNumber
        Me.txtXCARD_NO = New MateCommon.cmpMTextBoxString
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(443, 472)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(171, 472)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 10
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "積込方向:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "車輌番号:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 32)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "積込方法:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 32)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "未使用区分:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXTUMI_HOUKOU
        '
        Me.cboXTUMI_HOUKOU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXTUMI_HOUKOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXTUMI_HOUKOU.FormattingEnabled = True
        Me.cboXTUMI_HOUKOU.IntegralHeight = False
        Me.cboXTUMI_HOUKOU.Location = New System.Drawing.Point(171, 68)
        Me.cboXTUMI_HOUKOU.Name = "cboXTUMI_HOUKOU"
        Me.cboXTUMI_HOUKOU.Size = New System.Drawing.Size(168, 28)
        Me.cboXTUMI_HOUKOU.TabIndex = 1
        '
        'cboXTUMI_HOUHOU
        '
        Me.cboXTUMI_HOUHOU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXTUMI_HOUHOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXTUMI_HOUHOU.FormattingEnabled = True
        Me.cboXTUMI_HOUHOU.IntegralHeight = False
        Me.cboXTUMI_HOUHOU.Location = New System.Drawing.Point(171, 111)
        Me.cboXTUMI_HOUHOU.Name = "cboXTUMI_HOUHOU"
        Me.cboXTUMI_HOUHOU.Size = New System.Drawing.Size(168, 28)
        Me.cboXTUMI_HOUHOU.TabIndex = 2
        '
        'cboXNOT_USER
        '
        Me.cboXNOT_USER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXNOT_USER.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXNOT_USER.FormattingEnabled = True
        Me.cboXNOT_USER.IntegralHeight = False
        Me.cboXNOT_USER.Location = New System.Drawing.Point(171, 154)
        Me.cboXNOT_USER.Name = "cboXNOT_USER"
        Me.cboXNOT_USER.Size = New System.Drawing.Size(168, 28)
        Me.cboXNOT_USER.TabIndex = 3
        '
        'txtXSYARYOU_NO
        '
        Me.txtXSYARYOU_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXSYARYOU_NO.Enabled = False
        Me.txtXSYARYOU_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXSYARYOU_NO.Format = "###0"
        Me.txtXSYARYOU_NO.Location = New System.Drawing.Point(171, 28)
        Me.txtXSYARYOU_NO.MaxLength = 4
        Me.txtXSYARYOU_NO.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtXSYARYOU_NO.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXSYARYOU_NO.Name = "txtXSYARYOU_NO"
        Me.txtXSYARYOU_NO.Nullable = True
        Me.txtXSYARYOU_NO.Size = New System.Drawing.Size(169, 27)
        Me.txtXSYARYOU_NO.TabIndex = 0
        Me.txtXSYARYOU_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXSYARYOU_NO.Value = Nothing
        '
        'txtXSYASYU_COMMENT
        '
        Me.txtXSYASYU_COMMENT.BackColorMask = System.Drawing.Color.Empty
        Me.txtXSYASYU_COMMENT.EnabledFull = True
        Me.txtXSYASYU_COMMENT.EnabledFullAlphabetLower = True
        Me.txtXSYASYU_COMMENT.EnabledFullAlphabetUpper = True
        Me.txtXSYASYU_COMMENT.EnabledFullHiragana = True
        Me.txtXSYASYU_COMMENT.EnabledFullKatakana = True
        Me.txtXSYASYU_COMMENT.EnabledFullNumber = True
        Me.txtXSYASYU_COMMENT.EnabledHalf = True
        Me.txtXSYASYU_COMMENT.EnabledHalfAlphabetLower = True
        Me.txtXSYASYU_COMMENT.EnabledHalfAlphabetUpper = True
        Me.txtXSYASYU_COMMENT.EnabledHalfKatakana = True
        Me.txtXSYASYU_COMMENT.EnabledHalfNumber = True
        Me.txtXSYASYU_COMMENT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXSYASYU_COMMENT.Location = New System.Drawing.Point(171, 292)
        Me.txtXSYASYU_COMMENT.MaxLength = 40
        Me.txtXSYASYU_COMMENT.MaxLengthByte = 40
        Me.txtXSYASYU_COMMENT.Name = "txtXSYASYU_COMMENT"
        Me.txtXSYASYU_COMMENT.RegexCustomFalse = Nothing
        Me.txtXSYASYU_COMMENT.RegexCustomTrue = Nothing
        Me.txtXSYASYU_COMMENT.Size = New System.Drawing.Size(582, 27)
        Me.txtXSYASYU_COMMENT.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 289)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 32)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "車種ｺﾒﾝﾄ:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 32)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "ｶｰﾄﾞNo.:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYASYU_KBN
        '
        Me.cboXSYASYU_KBN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYASYU_KBN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYASYU_KBN.FormattingEnabled = True
        Me.cboXSYASYU_KBN.IntegralHeight = False
        Me.cboXSYASYU_KBN.Location = New System.Drawing.Point(171, 244)
        Me.cboXSYASYU_KBN.Name = "cboXSYASYU_KBN"
        Me.cboXSYASYU_KBN.Size = New System.Drawing.Size(320, 28)
        Me.cboXSYASYU_KBN.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 32)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "車種区分:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXGYOUSYA_CD
        '
        Me.cboXGYOUSYA_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXGYOUSYA_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXGYOUSYA_CD.FormattingEnabled = True
        Me.cboXGYOUSYA_CD.IntegralHeight = False
        Me.cboXGYOUSYA_CD.Location = New System.Drawing.Point(171, 335)
        Me.cboXGYOUSYA_CD.Name = "cboXGYOUSYA_CD"
        Me.cboXGYOUSYA_CD.Size = New System.Drawing.Size(582, 28)
        Me.cboXGYOUSYA_CD.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 332)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 32)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "業者:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXLOADER_POSSIBLE
        '
        Me.cboXLOADER_POSSIBLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXLOADER_POSSIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXLOADER_POSSIBLE.FormattingEnabled = True
        Me.cboXLOADER_POSSIBLE.IntegralHeight = False
        Me.cboXLOADER_POSSIBLE.Location = New System.Drawing.Point(171, 378)
        Me.cboXLOADER_POSSIBLE.Name = "cboXLOADER_POSSIBLE"
        Me.cboXLOADER_POSSIBLE.Size = New System.Drawing.Size(156, 28)
        Me.cboXLOADER_POSSIBLE.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 375)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 32)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "ﾛｰﾀﾞ対応:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 418)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 32)
        Me.Label10.TabIndex = 77
        Me.Label10.Text = "ﾛｰﾀﾞﾓｰﾄﾞ:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXSYARYOU_MODE
        '
        Me.txtXSYARYOU_MODE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXSYARYOU_MODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXSYARYOU_MODE.Format = "#0"
        Me.txtXSYARYOU_MODE.Location = New System.Drawing.Point(171, 421)
        Me.txtXSYARYOU_MODE.MaxLength = 2
        Me.txtXSYARYOU_MODE.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtXSYARYOU_MODE.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXSYARYOU_MODE.Name = "txtXSYARYOU_MODE"
        Me.txtXSYARYOU_MODE.Nullable = True
        Me.txtXSYARYOU_MODE.Size = New System.Drawing.Size(78, 27)
        Me.txtXSYARYOU_MODE.TabIndex = 9
        Me.txtXSYARYOU_MODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXSYARYOU_MODE.Value = Nothing
        '
        'txtXCARD_NO
        '
        Me.txtXCARD_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXCARD_NO.EnabledFull = False
        Me.txtXCARD_NO.EnabledFullAlphabetLower = False
        Me.txtXCARD_NO.EnabledFullAlphabetUpper = False
        Me.txtXCARD_NO.EnabledFullHiragana = True
        Me.txtXCARD_NO.EnabledFullKatakana = False
        Me.txtXCARD_NO.EnabledFullNumber = False
        Me.txtXCARD_NO.EnabledHalf = True
        Me.txtXCARD_NO.EnabledHalfAlphabetLower = True
        Me.txtXCARD_NO.EnabledHalfAlphabetUpper = True
        Me.txtXCARD_NO.EnabledHalfKatakana = True
        Me.txtXCARD_NO.EnabledHalfNumber = True
        Me.txtXCARD_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXCARD_NO.Location = New System.Drawing.Point(171, 199)
        Me.txtXCARD_NO.MaxLength = 6
        Me.txtXCARD_NO.MaxLengthByte = 6
        Me.txtXCARD_NO.Name = "txtXCARD_NO"
        Me.txtXCARD_NO.RegexCustomFalse = Nothing
        Me.txtXCARD_NO.RegexCustomTrue = Nothing
        Me.txtXCARD_NO.Size = New System.Drawing.Size(169, 27)
        Me.txtXCARD_NO.TabIndex = 4
        '
        'FRM_306021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(835, 527)
        Me.Controls.Add(Me.txtXCARD_NO)
        Me.Controls.Add(Me.txtXSYARYOU_MODE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboXLOADER_POSSIBLE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboXGYOUSYA_CD)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboXSYASYU_KBN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtXSYASYU_COMMENT)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtXSYARYOU_NO)
        Me.Controls.Add(Me.cboXNOT_USER)
        Me.Controls.Add(Me.cboXTUMI_HOUHOU)
        Me.Controls.Add(Me.cboXTUMI_HOUKOU)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FRM_306021"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "車輌ﾏｽﾀ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboXTUMI_HOUKOU As MateCommon.cmpMComboBox
    Friend WithEvents cboXTUMI_HOUHOU As MateCommon.cmpMComboBox
    Friend WithEvents cboXNOT_USER As MateCommon.cmpMComboBox
    Friend WithEvents txtXSYARYOU_NO As MateCommon.cmpMTextBoxNumber
    Friend WithEvents txtXSYASYU_COMMENT As MateCommon.cmpMTextBoxString
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboXSYASYU_KBN As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboXGYOUSYA_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboXLOADER_POSSIBLE As MateCommon.cmpMComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtXSYARYOU_MODE As MateCommon.cmpMTextBoxNumber
    Friend WithEvents txtXCARD_NO As MateCommon.cmpMTextBoxString

End Class
