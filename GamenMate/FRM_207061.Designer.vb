<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_207061
    Inherits FRM_000001

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTeisuID = New System.Windows.Forms.Label
        Me.txtTeisuName = New System.Windows.Forms.Label
        Me.cboDataType = New MateCommon.cmpMComboBox
        Me.txtDataSeisu = New MateCommon.cmpMTextBoxNumber
        Me.txtDataZissu = New MateCommon.cmpMTextBoxNumber
        Me.txtDataString = New MateCommon.cmpMTextBoxString
        Me.dtpDate = New GamenCommon.cmpMDateTimePicker_DT
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 32)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "定数ID:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(280, 320)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(24, 320)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 7
        Me.cmdZikkou.Text = "実行"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "定数項目名称:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "データ型:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 32)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "整数データ:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 32)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "実数データ:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 32)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "文字データ:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 32)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "日時データ:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTeisuID
        '
        Me.txtTeisuID.BackColor = System.Drawing.SystemColors.Control
        Me.txtTeisuID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTeisuID.Enabled = False
        Me.txtTeisuID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtTeisuID.ForeColor = System.Drawing.Color.Black
        Me.txtTeisuID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txtTeisuID.Location = New System.Drawing.Point(160, 11)
        Me.txtTeisuID.Name = "txtTeisuID"
        Me.txtTeisuID.Size = New System.Drawing.Size(360, 27)
        Me.txtTeisuID.TabIndex = 0
        Me.txtTeisuID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTeisuName
        '
        Me.txtTeisuName.BackColor = System.Drawing.SystemColors.Control
        Me.txtTeisuName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTeisuName.Enabled = False
        Me.txtTeisuName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtTeisuName.ForeColor = System.Drawing.Color.Black
        Me.txtTeisuName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txtTeisuName.Location = New System.Drawing.Point(160, 51)
        Me.txtTeisuName.Name = "txtTeisuName"
        Me.txtTeisuName.Size = New System.Drawing.Size(360, 27)
        Me.txtTeisuName.TabIndex = 1
        Me.txtTeisuName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDataType
        '
        Me.cboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataType.Enabled = False
        Me.cboDataType.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboDataType.FormattingEnabled = True
        Me.cboDataType.IntegralHeight = False
        Me.cboDataType.Location = New System.Drawing.Point(160, 92)
        Me.cboDataType.Name = "cboDataType"
        Me.cboDataType.Size = New System.Drawing.Size(184, 27)
        Me.cboDataType.TabIndex = 2
        '
        'txtDataSeisu
        '
        Me.txtDataSeisu.BackColorMask = System.Drawing.Color.Empty
        Me.txtDataSeisu.Enabled = False
        Me.txtDataSeisu.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtDataSeisu.Format = ""
        Me.txtDataSeisu.Location = New System.Drawing.Point(160, 131)
        Me.txtDataSeisu.MaxLength = 6
        Me.txtDataSeisu.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.txtDataSeisu.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDataSeisu.Name = "txtDataSeisu"
        Me.txtDataSeisu.Nullable = True
        Me.txtDataSeisu.Size = New System.Drawing.Size(184, 27)
        Me.txtDataSeisu.TabIndex = 3
        Me.txtDataSeisu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDataSeisu.Value = Nothing
        '
        'txtDataZissu
        '
        Me.txtDataZissu.BackColorMask = System.Drawing.Color.Empty
        Me.txtDataZissu.Enabled = False
        Me.txtDataZissu.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtDataZissu.Format = "##.##"
        Me.txtDataZissu.Location = New System.Drawing.Point(160, 171)
        Me.txtDataZissu.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.txtDataZissu.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDataZissu.Name = "txtDataZissu"
        Me.txtDataZissu.Nullable = True
        Me.txtDataZissu.Size = New System.Drawing.Size(184, 27)
        Me.txtDataZissu.TabIndex = 4
        Me.txtDataZissu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDataZissu.Value = Nothing
        '
        'txtDataString
        '
        Me.txtDataString.BackColorMask = System.Drawing.Color.Empty
        Me.txtDataString.Enabled = False
        Me.txtDataString.EnabledFull = True
        Me.txtDataString.EnabledFullAlphabetLower = False
        Me.txtDataString.EnabledFullAlphabetUpper = False
        Me.txtDataString.EnabledFullHiragana = False
        Me.txtDataString.EnabledFullKatakana = False
        Me.txtDataString.EnabledFullNumber = False
        Me.txtDataString.EnabledHalf = True
        Me.txtDataString.EnabledHalfAlphabetLower = True
        Me.txtDataString.EnabledHalfAlphabetUpper = True
        Me.txtDataString.EnabledHalfKatakana = True
        Me.txtDataString.EnabledHalfNumber = True
        Me.txtDataString.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDataString.Location = New System.Drawing.Point(160, 212)
        Me.txtDataString.MaxLength = 256
        Me.txtDataString.MaxLengthByte = 256
        Me.txtDataString.Name = "txtDataString"
        Me.txtDataString.RegexCustomFalse = Nothing
        Me.txtDataString.RegexCustomTrue = Nothing
        Me.txtDataString.Size = New System.Drawing.Size(360, 26)
        Me.txtDataString.TabIndex = 5
        '
        'dtpDate
        '
        Me.dtpDate.BackColorMask = System.Drawing.SystemColors.Window
        Me.dtpDate.Enabled = False
        Me.dtpDate.Location = New System.Drawing.Point(160, 248)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(296, 30)
        Me.dtpDate.TabIndex = 6
        Me.dtpDate.TimeComboDisp = True
        Me.dtpDate.userChecked = True
        Me.dtpDate.userShowCheckBox = False
        '
        'FRM_207061
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 373)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.txtDataString)
        Me.Controls.Add(Me.txtDataZissu)
        Me.Controls.Add(Me.txtDataSeisu)
        Me.Controls.Add(Me.cboDataType)
        Me.Controls.Add(Me.txtTeisuName)
        Me.Controls.Add(Me.txtTeisuID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FRM_207061"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ｼｽﾃﾑ定数ﾒﾝﾃﾅﾝｽ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTeisuID As System.Windows.Forms.Label
    Friend WithEvents txtTeisuName As System.Windows.Forms.Label
    Friend WithEvents cboDataType As MateCommon.cmpMComboBox
    Friend WithEvents txtDataSeisu As MateCommon.cmpMTextBoxNumber
    Friend WithEvents txtDataZissu As MateCommon.cmpMTextBoxNumber
    Friend WithEvents txtDataString As MateCommon.cmpMTextBoxString
    Friend WithEvents dtpDate As GamenCommon.cmpMDateTimePicker_DT

End Class
