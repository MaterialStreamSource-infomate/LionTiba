<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_311010
    Inherits GamenMate.FRM_000002

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
        Me.components = New System.ComponentModel.Container
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtXDENPYOU_NO = New MateCommon.cmpMTextBoxString
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_D = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_STS = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtXHENSEI_NO = New MateCommon.cmpMTextBoxString
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblXDAISU = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1144, 672)
        Me.cmdF7.TabIndex = 6
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(388, 672)
        Me.cmdF6.TabIndex = 5
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(278, 672)
        Me.cmdF5.TabIndex = 4
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 672)
        Me.cmdF4.TabIndex = 3
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 104)
        Me.cmdF1.TabIndex = 1
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 162)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 493)
        Me.grdList.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtXDENPYOU_NO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboXSYUKKA_D)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboXSYUKKA_STS)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtXHENSEI_NO)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtXDENPYOU_NO
        '
        Me.txtXDENPYOU_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXDENPYOU_NO.EnabledFull = False
        Me.txtXDENPYOU_NO.EnabledFullAlphabetLower = False
        Me.txtXDENPYOU_NO.EnabledFullAlphabetUpper = False
        Me.txtXDENPYOU_NO.EnabledFullHiragana = False
        Me.txtXDENPYOU_NO.EnabledFullKatakana = False
        Me.txtXDENPYOU_NO.EnabledFullNumber = False
        Me.txtXDENPYOU_NO.EnabledHalf = True
        Me.txtXDENPYOU_NO.EnabledHalfAlphabetLower = False
        Me.txtXDENPYOU_NO.EnabledHalfAlphabetUpper = False
        Me.txtXDENPYOU_NO.EnabledHalfKatakana = False
        Me.txtXDENPYOU_NO.EnabledHalfNumber = True
        Me.txtXDENPYOU_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXDENPYOU_NO.Location = New System.Drawing.Point(563, 20)
        Me.txtXDENPYOU_NO.MaxLength = 7
        Me.txtXDENPYOU_NO.MaxLengthByte = 0
        Me.txtXDENPYOU_NO.Name = "txtXDENPYOU_NO"
        Me.txtXDENPYOU_NO.RegexCustomFalse = Nothing
        Me.txtXDENPYOU_NO.RegexCustomTrue = Nothing
        Me.txtXDENPYOU_NO.Size = New System.Drawing.Size(91, 27)
        Me.txtXDENPYOU_NO.TabIndex = 2
        Me.txtXDENPYOU_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(473, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 32)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "伝票№:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_D
        '
        Me.cboXSYUKKA_D.BackColorMask = System.Drawing.SystemColors.Control
        Me.cboXSYUKKA_D.Location = New System.Drawing.Point(128, 17)
        Me.cboXSYUKKA_D.Margin = New System.Windows.Forms.Padding(1)
        Me.cboXSYUKKA_D.Name = "cboXSYUKKA_D"
        Me.cboXSYUKKA_D.Size = New System.Drawing.Size(168, 32)
        Me.cboXSYUKKA_D.TabIndex = 0
        Me.cboXSYUKKA_D.TimeComboDisp = False
        Me.cboXSYUKKA_D.userChecked = True
        Me.cboXSYUKKA_D.userShowCheckBox = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "出荷日付:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(653, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 32)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "進捗状況:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_STS
        '
        Me.cboXSYUKKA_STS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYUKKA_STS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYUKKA_STS.FormattingEnabled = True
        Me.cboXSYUKKA_STS.IntegralHeight = False
        Me.cboXSYUKKA_STS.Location = New System.Drawing.Point(779, 20)
        Me.cboXSYUKKA_STS.Name = "cboXSYUKKA_STS"
        Me.cboXSYUKKA_STS.Size = New System.Drawing.Size(160, 28)
        Me.cboXSYUKKA_STS.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(300, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "編成№:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXHENSEI_NO
        '
        Me.txtXHENSEI_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXHENSEI_NO.EnabledFull = False
        Me.txtXHENSEI_NO.EnabledFullAlphabetLower = False
        Me.txtXHENSEI_NO.EnabledFullAlphabetUpper = False
        Me.txtXHENSEI_NO.EnabledFullHiragana = False
        Me.txtXHENSEI_NO.EnabledFullKatakana = False
        Me.txtXHENSEI_NO.EnabledFullNumber = False
        Me.txtXHENSEI_NO.EnabledHalf = True
        Me.txtXHENSEI_NO.EnabledHalfAlphabetLower = False
        Me.txtXHENSEI_NO.EnabledHalfAlphabetUpper = False
        Me.txtXHENSEI_NO.EnabledHalfKatakana = False
        Me.txtXHENSEI_NO.EnabledHalfNumber = True
        Me.txtXHENSEI_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXHENSEI_NO.Location = New System.Drawing.Point(395, 20)
        Me.txtXHENSEI_NO.MaxLength = 4
        Me.txtXHENSEI_NO.MaxLengthByte = 0
        Me.txtXHENSEI_NO.Name = "txtXHENSEI_NO"
        Me.txtXHENSEI_NO.RegexCustomFalse = Nothing
        Me.txtXHENSEI_NO.RegexCustomTrue = Nothing
        Me.txtXHENSEI_NO.Size = New System.Drawing.Size(74, 27)
        Me.txtXHENSEI_NO.TabIndex = 1
        Me.txtXHENSEI_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(684, 679)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 32)
        Me.Label5.TabIndex = 214
        Me.Label5.Text = "合計台数:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(878, 679)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 32)
        Me.Label6.TabIndex = 215
        Me.Label6.Text = "台"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXDAISU
        '
        Me.lblXDAISU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXDAISU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXDAISU.ForeColor = System.Drawing.Color.Black
        Me.lblXDAISU.Location = New System.Drawing.Point(798, 679)
        Me.lblXDAISU.Name = "lblXDAISU"
        Me.lblXDAISU.Size = New System.Drawing.Size(74, 32)
        Me.lblXDAISU.TabIndex = 216
        Me.lblXDAISU.Text = "0"
        Me.lblXDAISU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_311010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.lblXDAISU)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_311010"
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lblXDAISU, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboXSYUKKA_STS As MateCommon.cmpMComboBox
    Friend WithEvents cboXSYUKKA_D As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtXHENSEI_NO As MateCommon.cmpMTextBoxString
    Friend WithEvents txtXDENPYOU_NO As MateCommon.cmpMTextBoxString
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblXDAISU As System.Windows.Forms.Label

End Class
