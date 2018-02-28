<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308110
    Inherits GamenMate.FRM_000002

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboXORDER_NO = New MateCommon.cmpMComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpXSYUKKA_DT = New GamenCommon.cmpMDateTimePicker_DT
        Me.cboXGYOSHA_CD = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtXCAR_NO_EDA_WARITUKE = New MateCommon.cmpMTextBoxString
        Me.txtXCAR_NO_WARITUKE = New MateCommon.cmpMTextBoxString
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXIDOU_CD = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblXNYUKA_JIGYOU_NM = New System.Windows.Forms.Label
        Me.cboXNYUKA_JIGYOU_CD = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList2 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList3 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 664)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 190)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cboXORDER_NO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpXSYUKKA_DT)
        Me.GroupBox1.Controls.Add(Me.cboXGYOSHA_CD)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtXCAR_NO_EDA_WARITUKE)
        Me.GroupBox1.Controls.Add(Me.txtXCAR_NO_WARITUKE)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboXIDOU_CD)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblXNYUKA_JIGYOU_NM)
        Me.GroupBox1.Controls.Add(Me.cboXNYUKA_JIGYOU_CD)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 144)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 32)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "移動手段ｺｰﾄﾞ:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXORDER_NO
        '
        Me.cboXORDER_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXORDER_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXORDER_NO.FormattingEnabled = True
        Me.cboXORDER_NO.IntegralHeight = False
        Me.cboXORDER_NO.Location = New System.Drawing.Point(464, 16)
        Me.cboXORDER_NO.Name = "cboXORDER_NO"
        Me.cboXORDER_NO.Size = New System.Drawing.Size(149, 28)
        Me.cboXORDER_NO.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(360, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 32)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "発注№:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpXSYUKKA_DT
        '
        Me.dtpXSYUKKA_DT.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpXSYUKKA_DT.Location = New System.Drawing.Point(165, 16)
        Me.dtpXSYUKKA_DT.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpXSYUKKA_DT.Name = "dtpXSYUKKA_DT"
        Me.dtpXSYUKKA_DT.Size = New System.Drawing.Size(168, 32)
        Me.dtpXSYUKKA_DT.TabIndex = 1
        Me.dtpXSYUKKA_DT.TimeComboDisp = False
        Me.dtpXSYUKKA_DT.userChecked = True
        Me.dtpXSYUKKA_DT.userShowCheckBox = False
        '
        'cboXGYOSHA_CD
        '
        Me.cboXGYOSHA_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXGYOSHA_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXGYOSHA_CD.FormattingEnabled = True
        Me.cboXGYOSHA_CD.IntegralHeight = False
        Me.cboXGYOSHA_CD.Location = New System.Drawing.Point(464, 99)
        Me.cboXGYOSHA_CD.Name = "cboXGYOSHA_CD"
        Me.cboXGYOSHA_CD.Size = New System.Drawing.Size(101, 28)
        Me.cboXGYOSHA_CD.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(320, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 32)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "業者ｺｰﾄﾞ:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(840, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 32)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "－"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXCAR_NO_EDA_WARITUKE
        '
        Me.txtXCAR_NO_EDA_WARITUKE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFull = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullAlphabetLower = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullAlphabetUpper = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullHiragana = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullKatakana = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullNumber = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalf = True
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfAlphabetLower = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfAlphabetUpper = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfKatakana = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfNumber = True
        Me.txtXCAR_NO_EDA_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXCAR_NO_EDA_WARITUKE.Location = New System.Drawing.Point(872, 16)
        Me.txtXCAR_NO_EDA_WARITUKE.MaxLength = 1
        Me.txtXCAR_NO_EDA_WARITUKE.MaxLengthByte = 1
        Me.txtXCAR_NO_EDA_WARITUKE.Name = "txtXCAR_NO_EDA_WARITUKE"
        Me.txtXCAR_NO_EDA_WARITUKE.RegexCustomFalse = Nothing
        Me.txtXCAR_NO_EDA_WARITUKE.RegexCustomTrue = Nothing
        Me.txtXCAR_NO_EDA_WARITUKE.Size = New System.Drawing.Size(24, 27)
        Me.txtXCAR_NO_EDA_WARITUKE.TabIndex = 7
        '
        'txtXCAR_NO_WARITUKE
        '
        Me.txtXCAR_NO_WARITUKE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXCAR_NO_WARITUKE.EnabledFull = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullAlphabetLower = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullAlphabetUpper = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullHiragana = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullKatakana = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullNumber = False
        Me.txtXCAR_NO_WARITUKE.EnabledHalf = True
        Me.txtXCAR_NO_WARITUKE.EnabledHalfAlphabetLower = False
        Me.txtXCAR_NO_WARITUKE.EnabledHalfAlphabetUpper = False
        Me.txtXCAR_NO_WARITUKE.EnabledHalfKatakana = False
        Me.txtXCAR_NO_WARITUKE.EnabledHalfNumber = True
        Me.txtXCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXCAR_NO_WARITUKE.Location = New System.Drawing.Point(776, 16)
        Me.txtXCAR_NO_WARITUKE.MaxLength = 4
        Me.txtXCAR_NO_WARITUKE.MaxLengthByte = 4
        Me.txtXCAR_NO_WARITUKE.Name = "txtXCAR_NO_WARITUKE"
        Me.txtXCAR_NO_WARITUKE.RegexCustomFalse = Nothing
        Me.txtXCAR_NO_WARITUKE.RegexCustomTrue = Nothing
        Me.txtXCAR_NO_WARITUKE.Size = New System.Drawing.Size(62, 27)
        Me.txtXCAR_NO_WARITUKE.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(656, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 32)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "受付車番:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXIDOU_CD
        '
        Me.cboXIDOU_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXIDOU_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXIDOU_CD.FormattingEnabled = True
        Me.cboXIDOU_CD.IntegralHeight = False
        Me.cboXIDOU_CD.Location = New System.Drawing.Point(168, 96)
        Me.cboXIDOU_CD.Name = "cboXIDOU_CD"
        Me.cboXIDOU_CD.Size = New System.Drawing.Size(96, 28)
        Me.cboXIDOU_CD.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(29, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 32)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "配送先ｺｰﾄﾞ:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXNYUKA_JIGYOU_NM
        '
        Me.lblXNYUKA_JIGYOU_NM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXNYUKA_JIGYOU_NM.ForeColor = System.Drawing.Color.Black
        Me.lblXNYUKA_JIGYOU_NM.Location = New System.Drawing.Point(288, 56)
        Me.lblXNYUKA_JIGYOU_NM.Name = "lblXNYUKA_JIGYOU_NM"
        Me.lblXNYUKA_JIGYOU_NM.Size = New System.Drawing.Size(448, 32)
        Me.lblXNYUKA_JIGYOU_NM.TabIndex = 10
        Me.lblXNYUKA_JIGYOU_NM.Text = "配送先"
        Me.lblXNYUKA_JIGYOU_NM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboXNYUKA_JIGYOU_CD
        '
        Me.cboXNYUKA_JIGYOU_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXNYUKA_JIGYOU_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXNYUKA_JIGYOU_CD.FormattingEnabled = True
        Me.cboXNYUKA_JIGYOU_CD.IntegralHeight = False
        Me.cboXNYUKA_JIGYOU_CD.Location = New System.Drawing.Point(168, 56)
        Me.cboXNYUKA_JIGYOU_CD.Name = "cboXNYUKA_JIGYOU_CD"
        Me.cboXNYUKA_JIGYOU_CD.Size = New System.Drawing.Size(109, 28)
        Me.cboXNYUKA_JIGYOU_CD.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(37, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "出荷日:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 240)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 418)
        Me.grdList.TabIndex = 21
        '
        'grdList2
        '
        Me.grdList2.blnDBUpdate = False
        Me.grdList2.blnSelectionChanged = False
        Me.grdList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList2.Location = New System.Drawing.Point(1000, 672)
        Me.grdList2.MyBeseDoubleBuffered = False
        Me.grdList2.Name = "grdList2"
        Me.grdList2.RowTemplate.Height = 21
        Me.grdList2.Size = New System.Drawing.Size(104, 48)
        Me.grdList2.TabIndex = 213
        Me.grdList2.Visible = False
        '
        'grdList3
        '
        Me.grdList3.blnDBUpdate = False
        Me.grdList3.blnSelectionChanged = False
        Me.grdList3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList3.Location = New System.Drawing.Point(1120, 672)
        Me.grdList3.MyBeseDoubleBuffered = False
        Me.grdList3.Name = "grdList3"
        Me.grdList3.RowTemplate.Height = 21
        Me.grdList3.Size = New System.Drawing.Size(104, 48)
        Me.grdList3.TabIndex = 214
        Me.grdList3.Visible = False
        '
        'FRM_308110
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList3)
        Me.Controls.Add(Me.grdList2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_308110"
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList2, 0)
        Me.Controls.SetChildIndex(Me.grdList3, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents cboXNYUKA_JIGYOU_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblXNYUKA_JIGYOU_NM As System.Windows.Forms.Label
    Friend WithEvents cboXIDOU_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtXCAR_NO_WARITUKE As MateCommon.cmpMTextBoxString
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtXCAR_NO_EDA_WARITUKE As MateCommon.cmpMTextBoxString
    Friend WithEvents cboXGYOSHA_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpXSYUKKA_DT As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboXORDER_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdList2 As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList3 As GamenCommon.cmpMDataGrid

    'Required by the Windows Form Designer

End Class
