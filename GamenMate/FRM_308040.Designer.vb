<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308040
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboXORDER_NO = New MateCommon.cmpMComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboXCAR_NO = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_DT = New MateCommon.cmpMComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXGYOSHA_CD = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboXIDOU_CD = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblXNYUKA_JIGYOU_NM = New System.Windows.Forms.Label
        Me.cboXNYUKA_JIGYOU_CD = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtXCAR_NO_WARITUKE = New MateCommon.cmpMTextBoxString
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtXCAR_NO_EDA_WARITUKE = New MateCommon.cmpMTextBoxString
        Me.Label10 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1144, 672)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1032, 672)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(920, 672)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(808, 672)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(696, 672)
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(584, 672)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(168, 672)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1146, 228)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(170, 280)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 376)
        Me.grdList.TabIndex = 21
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboXORDER_NO)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cboXCAR_NO)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboXSYUKKA_DT)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cboXGYOSHA_CD)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cboXIDOU_CD)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblXNYUKA_JIGYOU_NM)
        Me.GroupBox2.Controls.Add(Me.cboXNYUKA_JIGYOU_CD)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(170, 136)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(960, 135)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        '
        'cboXORDER_NO
        '
        Me.cboXORDER_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXORDER_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXORDER_NO.FormattingEnabled = True
        Me.cboXORDER_NO.IntegralHeight = False
        Me.cboXORDER_NO.Location = New System.Drawing.Point(699, 19)
        Me.cboXORDER_NO.Name = "cboXORDER_NO"
        Me.cboXORDER_NO.Size = New System.Drawing.Size(176, 28)
        Me.cboXORDER_NO.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(600, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 32)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "発注№:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXCAR_NO
        '
        Me.cboXCAR_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXCAR_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXCAR_NO.FormattingEnabled = True
        Me.cboXCAR_NO.IntegralHeight = False
        Me.cboXCAR_NO.Location = New System.Drawing.Point(160, 19)
        Me.cboXCAR_NO.Name = "cboXCAR_NO"
        Me.cboXCAR_NO.Size = New System.Drawing.Size(80, 28)
        Me.cboXCAR_NO.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 32)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "車番:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_DT
        '
        Me.cboXSYUKKA_DT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYUKKA_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYUKKA_DT.FormattingEnabled = True
        Me.cboXSYUKKA_DT.IntegralHeight = False
        Me.cboXSYUKKA_DT.Location = New System.Drawing.Point(395, 19)
        Me.cboXSYUKKA_DT.Name = "cboXSYUKKA_DT"
        Me.cboXSYUKKA_DT.Size = New System.Drawing.Size(176, 28)
        Me.cboXSYUKKA_DT.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(296, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 32)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "出荷日:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXGYOSHA_CD
        '
        Me.cboXGYOSHA_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXGYOSHA_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXGYOSHA_CD.FormattingEnabled = True
        Me.cboXGYOSHA_CD.IntegralHeight = False
        Me.cboXGYOSHA_CD.Location = New System.Drawing.Point(395, 91)
        Me.cboXGYOSHA_CD.Name = "cboXGYOSHA_CD"
        Me.cboXGYOSHA_CD.Size = New System.Drawing.Size(104, 28)
        Me.cboXGYOSHA_CD.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(274, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 32)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "業者ｺｰﾄﾞ:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXIDOU_CD
        '
        Me.cboXIDOU_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXIDOU_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXIDOU_CD.FormattingEnabled = True
        Me.cboXIDOU_CD.IntegralHeight = False
        Me.cboXIDOU_CD.Location = New System.Drawing.Point(160, 91)
        Me.cboXIDOU_CD.Name = "cboXIDOU_CD"
        Me.cboXIDOU_CD.Size = New System.Drawing.Size(96, 28)
        Me.cboXIDOU_CD.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "移動手段ｺｰﾄﾞ:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXNYUKA_JIGYOU_NM
        '
        Me.lblXNYUKA_JIGYOU_NM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXNYUKA_JIGYOU_NM.ForeColor = System.Drawing.Color.Black
        Me.lblXNYUKA_JIGYOU_NM.Location = New System.Drawing.Point(272, 51)
        Me.lblXNYUKA_JIGYOU_NM.Name = "lblXNYUKA_JIGYOU_NM"
        Me.lblXNYUKA_JIGYOU_NM.Size = New System.Drawing.Size(592, 32)
        Me.lblXNYUKA_JIGYOU_NM.TabIndex = 8
        Me.lblXNYUKA_JIGYOU_NM.Text = "配送先名"
        Me.lblXNYUKA_JIGYOU_NM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboXNYUKA_JIGYOU_CD
        '
        Me.cboXNYUKA_JIGYOU_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXNYUKA_JIGYOU_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXNYUKA_JIGYOU_CD.FormattingEnabled = True
        Me.cboXNYUKA_JIGYOU_CD.IntegralHeight = False
        Me.cboXNYUKA_JIGYOU_CD.Location = New System.Drawing.Point(160, 54)
        Me.cboXNYUKA_JIGYOU_CD.Name = "cboXNYUKA_JIGYOU_CD"
        Me.cboXNYUKA_JIGYOU_CD.Size = New System.Drawing.Size(96, 28)
        Me.cboXNYUKA_JIGYOU_CD.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(21, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 32)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "配送先ｺｰﾄﾞ:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(200, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 32)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "受付車番:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.txtXCAR_NO_WARITUKE.Location = New System.Drawing.Point(328, 100)
        Me.txtXCAR_NO_WARITUKE.MaxLength = 4
        Me.txtXCAR_NO_WARITUKE.MaxLengthByte = 4
        Me.txtXCAR_NO_WARITUKE.Name = "txtXCAR_NO_WARITUKE"
        Me.txtXCAR_NO_WARITUKE.RegexCustomFalse = Nothing
        Me.txtXCAR_NO_WARITUKE.RegexCustomTrue = Nothing
        Me.txtXCAR_NO_WARITUKE.Size = New System.Drawing.Size(56, 27)
        Me.txtXCAR_NO_WARITUKE.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(384, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 32)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.txtXCAR_NO_EDA_WARITUKE.Location = New System.Drawing.Point(408, 100)
        Me.txtXCAR_NO_EDA_WARITUKE.MaxLength = 1
        Me.txtXCAR_NO_EDA_WARITUKE.MaxLengthByte = 1
        Me.txtXCAR_NO_EDA_WARITUKE.Name = "txtXCAR_NO_EDA_WARITUKE"
        Me.txtXCAR_NO_EDA_WARITUKE.RegexCustomFalse = Nothing
        Me.txtXCAR_NO_EDA_WARITUKE.RegexCustomTrue = Nothing
        Me.txtXCAR_NO_EDA_WARITUKE.Size = New System.Drawing.Size(24, 27)
        Me.txtXCAR_NO_EDA_WARITUKE.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(440, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(408, 32)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "(枝番は再入門時に設定して下さい。)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_308040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtXCAR_NO_EDA_WARITUKE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtXCAR_NO_WARITUKE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grdList)
        Me.Name = "FRM_308040"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtXCAR_NO_WARITUKE, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtXCAR_NO_EDA_WARITUKE, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblXNYUKA_JIGYOU_NM As System.Windows.Forms.Label
    Friend WithEvents cboXNYUKA_JIGYOU_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboXGYOSHA_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboXIDOU_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboXCAR_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboXSYUKKA_DT As MateCommon.cmpMComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtXCAR_NO_WARITUKE As MateCommon.cmpMTextBoxString
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtXCAR_NO_EDA_WARITUKE As MateCommon.cmpMTextBoxString
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboXORDER_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
