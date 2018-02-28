<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_304020
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkKENPIN_MIKAN = New System.Windows.Forms.CheckBox
        Me.cboXSYUKKA_DT_FM = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_DT_TO = New MateCommon.cmpMComboBox
        Me.cboXCAR_NO_EDA_WARITUKE = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboXORDER_NO = New MateCommon.cmpMComboBox
        Me.cboXCAR_NO_WARITUKE = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1160, 608)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1144, 664)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(392, 664)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(280, 664)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 664)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 150)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkKENPIN_MIKAN)
        Me.GroupBox1.Controls.Add(Me.cboXSYUKKA_DT_FM)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboXSYUKKA_DT_TO)
        Me.GroupBox1.Controls.Add(Me.cboXCAR_NO_EDA_WARITUKE)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboXORDER_NO)
        Me.GroupBox1.Controls.Add(Me.cboXCAR_NO_WARITUKE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(966, 100)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'chkKENPIN_MIKAN
        '
        Me.chkKENPIN_MIKAN.AutoSize = True
        Me.chkKENPIN_MIKAN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkKENPIN_MIKAN.ForeColor = System.Drawing.Color.Black
        Me.chkKENPIN_MIKAN.Location = New System.Drawing.Point(752, 58)
        Me.chkKENPIN_MIKAN.Name = "chkKENPIN_MIKAN"
        Me.chkKENPIN_MIKAN.Size = New System.Drawing.Size(133, 24)
        Me.chkKENPIN_MIKAN.TabIndex = 10
        Me.chkKENPIN_MIKAN.Text = "検品未完了"
        Me.chkKENPIN_MIKAN.UseVisualStyleBackColor = True
        '
        'cboXSYUKKA_DT_FM
        '
        Me.cboXSYUKKA_DT_FM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYUKKA_DT_FM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYUKKA_DT_FM.FormattingEnabled = True
        Me.cboXSYUKKA_DT_FM.IntegralHeight = False
        Me.cboXSYUKKA_DT_FM.Location = New System.Drawing.Point(112, 18)
        Me.cboXSYUKKA_DT_FM.Name = "cboXSYUKKA_DT_FM"
        Me.cboXSYUKKA_DT_FM.Size = New System.Drawing.Size(192, 28)
        Me.cboXSYUKKA_DT_FM.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "出荷日:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(312, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "～"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_DT_TO
        '
        Me.cboXSYUKKA_DT_TO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYUKKA_DT_TO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYUKKA_DT_TO.FormattingEnabled = True
        Me.cboXSYUKKA_DT_TO.IntegralHeight = False
        Me.cboXSYUKKA_DT_TO.Location = New System.Drawing.Point(352, 18)
        Me.cboXSYUKKA_DT_TO.Name = "cboXSYUKKA_DT_TO"
        Me.cboXSYUKKA_DT_TO.Size = New System.Drawing.Size(192, 28)
        Me.cboXSYUKKA_DT_TO.TabIndex = 3
        '
        'cboXCAR_NO_EDA_WARITUKE
        '
        Me.cboXCAR_NO_EDA_WARITUKE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXCAR_NO_EDA_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXCAR_NO_EDA_WARITUKE.FormattingEnabled = True
        Me.cboXCAR_NO_EDA_WARITUKE.IntegralHeight = False
        Me.cboXCAR_NO_EDA_WARITUKE.Location = New System.Drawing.Point(640, 56)
        Me.cboXCAR_NO_EDA_WARITUKE.Name = "cboXCAR_NO_EDA_WARITUKE"
        Me.cboXCAR_NO_EDA_WARITUKE.Size = New System.Drawing.Size(72, 28)
        Me.cboXCAR_NO_EDA_WARITUKE.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(568, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 32)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "枝番:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 32)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "発注№:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXORDER_NO
        '
        Me.cboXORDER_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXORDER_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXORDER_NO.FormattingEnabled = True
        Me.cboXORDER_NO.IntegralHeight = False
        Me.cboXORDER_NO.Location = New System.Drawing.Point(111, 56)
        Me.cboXORDER_NO.Name = "cboXORDER_NO"
        Me.cboXORDER_NO.Size = New System.Drawing.Size(193, 28)
        Me.cboXORDER_NO.TabIndex = 5
        '
        'cboXCAR_NO_WARITUKE
        '
        Me.cboXCAR_NO_WARITUKE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXCAR_NO_WARITUKE.FormattingEnabled = True
        Me.cboXCAR_NO_WARITUKE.IntegralHeight = False
        Me.cboXCAR_NO_WARITUKE.Location = New System.Drawing.Point(440, 58)
        Me.cboXCAR_NO_WARITUKE.Name = "cboXCAR_NO_WARITUKE"
        Me.cboXCAR_NO_WARITUKE.Size = New System.Drawing.Size(104, 28)
        Me.cboXCAR_NO_WARITUKE.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(320, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "受付車番:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 200)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 455)
        Me.grdList.TabIndex = 21
        '
        'FRM_304020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_304020"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboXSYUKKA_DT_FM As MateCommon.cmpMComboBox
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents cboXSYUKKA_DT_TO As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboXORDER_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboXCAR_NO_EDA_WARITUKE As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboXCAR_NO_WARITUKE As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkKENPIN_MIKAN As System.Windows.Forms.CheckBox

End Class
