<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_305080
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
        Me.txtList01 = New MateCommon.cmpMTextBoxString
        Me.grdList01 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.txtList02 = New MateCommon.cmpMTextBoxString
        Me.grdList02 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboXBERTH_GROUP = New MateCommon.cmpMComboBox
        Me.tmr305080 = New System.Windows.Forms.Timer(Me.components)
        Me.cboXTUMI_HOUKOU = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(194, 656)
        Me.cmdF4.TabIndex = 6
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1151, 374)
        '
        'txtList01
        '
        Me.txtList01.BackColor = System.Drawing.Color.White
        Me.txtList01.BackColorMask = System.Drawing.Color.Empty
        Me.txtList01.EnabledFull = True
        Me.txtList01.EnabledFullAlphabetLower = False
        Me.txtList01.EnabledFullAlphabetUpper = False
        Me.txtList01.EnabledFullHiragana = False
        Me.txtList01.EnabledFullKatakana = False
        Me.txtList01.EnabledFullNumber = False
        Me.txtList01.EnabledHalf = True
        Me.txtList01.EnabledHalfAlphabetLower = True
        Me.txtList01.EnabledHalfAlphabetUpper = True
        Me.txtList01.EnabledHalfKatakana = True
        Me.txtList01.EnabledHalfNumber = True
        Me.txtList01.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtList01.Location = New System.Drawing.Point(586, 405)
        Me.txtList01.MaxLength = 8
        Me.txtList01.MaxLengthByte = 0
        Me.txtList01.Name = "txtList01"
        Me.txtList01.RegexCustomFalse = Nothing
        Me.txtList01.RegexCustomTrue = Nothing
        Me.txtList01.Size = New System.Drawing.Size(101, 26)
        Me.txtList01.TabIndex = 1
        '
        'grdList01
        '
        Me.grdList01.blnDBUpdate = False
        Me.grdList01.blnSelectionChanged = False
        Me.grdList01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList01.Location = New System.Drawing.Point(231, 139)
        Me.grdList01.MyBeseDoubleBuffered = False
        Me.grdList01.Name = "grdList01"
        Me.grdList01.RowTemplate.Height = 21
        Me.grdList01.Size = New System.Drawing.Size(456, 292)
        Me.grdList01.TabIndex = 0
        '
        'txtList02
        '
        Me.txtList02.BackColor = System.Drawing.Color.White
        Me.txtList02.BackColorMask = System.Drawing.Color.Empty
        Me.txtList02.EnabledFull = True
        Me.txtList02.EnabledFullAlphabetLower = False
        Me.txtList02.EnabledFullAlphabetUpper = False
        Me.txtList02.EnabledFullHiragana = False
        Me.txtList02.EnabledFullKatakana = False
        Me.txtList02.EnabledFullNumber = False
        Me.txtList02.EnabledHalf = True
        Me.txtList02.EnabledHalfAlphabetLower = True
        Me.txtList02.EnabledHalfAlphabetUpper = True
        Me.txtList02.EnabledHalfKatakana = True
        Me.txtList02.EnabledHalfNumber = True
        Me.txtList02.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtList02.Location = New System.Drawing.Point(1090, 408)
        Me.txtList02.MaxLength = 8
        Me.txtList02.MaxLengthByte = 0
        Me.txtList02.Name = "txtList02"
        Me.txtList02.RegexCustomFalse = Nothing
        Me.txtList02.RegexCustomTrue = Nothing
        Me.txtList02.Size = New System.Drawing.Size(101, 26)
        Me.txtList02.TabIndex = 3
        '
        'grdList02
        '
        Me.grdList02.blnDBUpdate = False
        Me.grdList02.blnSelectionChanged = False
        Me.grdList02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList02.Location = New System.Drawing.Point(735, 139)
        Me.grdList02.MyBeseDoubleBuffered = False
        Me.grdList02.Name = "grdList02"
        Me.grdList02.RowTemplate.Height = 21
        Me.grdList02.Size = New System.Drawing.Size(456, 292)
        Me.grdList02.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(753, 479)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 32)
        Me.Label1.TabIndex = 277
        Me.Label1.Text = "CVグループ:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXBERTH_GROUP
        '
        Me.cboXBERTH_GROUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXBERTH_GROUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXBERTH_GROUP.FormattingEnabled = True
        Me.cboXBERTH_GROUP.IntegralHeight = False
        Me.cboXBERTH_GROUP.Location = New System.Drawing.Point(917, 482)
        Me.cboXBERTH_GROUP.Name = "cboXBERTH_GROUP"
        Me.cboXBERTH_GROUP.Size = New System.Drawing.Size(136, 28)
        Me.cboXBERTH_GROUP.TabIndex = 4
        '
        'tmr305080
        '
        Me.tmr305080.Interval = 5000
        '
        'cboXTUMI_HOUKOU
        '
        Me.cboXTUMI_HOUKOU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXTUMI_HOUKOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXTUMI_HOUKOU.FormattingEnabled = True
        Me.cboXTUMI_HOUKOU.IntegralHeight = False
        Me.cboXTUMI_HOUKOU.Location = New System.Drawing.Point(917, 546)
        Me.cboXTUMI_HOUKOU.Name = "cboXTUMI_HOUKOU"
        Me.cboXTUMI_HOUKOU.Size = New System.Drawing.Size(136, 28)
        Me.cboXTUMI_HOUKOU.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(753, 543)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 32)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "積込方向:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_305080
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.cboXTUMI_HOUKOU)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboXBERTH_GROUP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtList02)
        Me.Controls.Add(Me.grdList02)
        Me.Controls.Add(Me.txtList01)
        Me.Controls.Add(Me.grdList01)
        Me.Name = "FRM_305080"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList01, 0)
        Me.Controls.SetChildIndex(Me.txtList01, 0)
        Me.Controls.SetChildIndex(Me.grdList02, 0)
        Me.Controls.SetChildIndex(Me.txtList02, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cboXBERTH_GROUP, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cboXTUMI_HOUKOU, 0)
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtList01 As MateCommon.cmpMTextBoxString
    Friend WithEvents grdList01 As GamenCommon.cmpMDataGrid
    Friend WithEvents txtList02 As MateCommon.cmpMTextBoxString
    Friend WithEvents grdList02 As GamenCommon.cmpMDataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboXBERTH_GROUP As MateCommon.cmpMComboBox
    Friend WithEvents tmr305080 As System.Windows.Forms.Timer
    Friend WithEvents cboXTUMI_HOUKOU As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
