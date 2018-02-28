<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_305050
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
        Me.grdList02 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList01 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.txtList01 = New MateCommon.cmpMTextBoxString
        Me.txtList02 = New MateCommon.cmpMTextBoxString
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboXCONVYOR_YOUTO = New MateCommon.cmpMComboBox
        Me.tmr305050 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtXBERTH_GROUP = New MateCommon.cmpMTextBoxNumber
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(194, 656)
        Me.cmdF4.TabIndex = 6
        '
        'grdList02
        '
        Me.grdList02.blnDBUpdate = False
        Me.grdList02.blnSelectionChanged = False
        Me.grdList02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList02.Location = New System.Drawing.Point(744, 109)
        Me.grdList02.MyBeseDoubleBuffered = False
        Me.grdList02.Name = "grdList02"
        Me.grdList02.RowTemplate.Height = 21
        Me.grdList02.Size = New System.Drawing.Size(456, 397)
        Me.grdList02.TabIndex = 2
        '
        'grdList01
        '
        Me.grdList01.blnDBUpdate = False
        Me.grdList01.blnSelectionChanged = False
        Me.grdList01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList01.Location = New System.Drawing.Point(240, 109)
        Me.grdList01.MyBeseDoubleBuffered = False
        Me.grdList01.Name = "grdList01"
        Me.grdList01.RowTemplate.Height = 21
        Me.grdList01.Size = New System.Drawing.Size(456, 397)
        Me.grdList01.TabIndex = 0
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
        Me.txtList01.Location = New System.Drawing.Point(595, 536)
        Me.txtList01.MaxLength = 8
        Me.txtList01.MaxLengthByte = 0
        Me.txtList01.Name = "txtList01"
        Me.txtList01.RegexCustomFalse = Nothing
        Me.txtList01.RegexCustomTrue = Nothing
        Me.txtList01.Size = New System.Drawing.Size(101, 26)
        Me.txtList01.TabIndex = 1
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
        Me.txtList02.Location = New System.Drawing.Point(1099, 536)
        Me.txtList02.MaxLength = 8
        Me.txtList02.MaxLengthByte = 0
        Me.txtList02.Name = "txtList02"
        Me.txtList02.RegexCustomFalse = Nothing
        Me.txtList02.RegexCustomTrue = Nothing
        Me.txtList02.Size = New System.Drawing.Size(101, 26)
        Me.txtList02.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(369, 596)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 32)
        Me.Label5.TabIndex = 273
        Me.Label5.Text = "設定モード:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXCONVYOR_YOUTO
        '
        Me.cboXCONVYOR_YOUTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXCONVYOR_YOUTO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXCONVYOR_YOUTO.FormattingEnabled = True
        Me.cboXCONVYOR_YOUTO.IntegralHeight = False
        Me.cboXCONVYOR_YOUTO.Location = New System.Drawing.Point(527, 598)
        Me.cboXCONVYOR_YOUTO.Name = "cboXCONVYOR_YOUTO"
        Me.cboXCONVYOR_YOUTO.Size = New System.Drawing.Size(136, 28)
        Me.cboXCONVYOR_YOUTO.TabIndex = 4
        '
        'tmr305050
        '
        Me.tmr305050.Interval = 5000
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(765, 598)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 32)
        Me.Label1.TabIndex = 275
        Me.Label1.Text = "CVグループ:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXBERTH_GROUP
        '
        Me.txtXBERTH_GROUP.BackColorMask = System.Drawing.Color.Empty
        Me.txtXBERTH_GROUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXBERTH_GROUP.Format = ""
        Me.txtXBERTH_GROUP.Location = New System.Drawing.Point(920, 601)
        Me.txtXBERTH_GROUP.MaxLength = 2
        Me.txtXBERTH_GROUP.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtXBERTH_GROUP.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXBERTH_GROUP.Name = "txtXBERTH_GROUP"
        Me.txtXBERTH_GROUP.Nullable = True
        Me.txtXBERTH_GROUP.Size = New System.Drawing.Size(102, 27)
        Me.txtXBERTH_GROUP.TabIndex = 5
        Me.txtXBERTH_GROUP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXBERTH_GROUP.Value = Nothing
        '
        'FRM_305050
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.txtXBERTH_GROUP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboXCONVYOR_YOUTO)
        Me.Controls.Add(Me.txtList02)
        Me.Controls.Add(Me.txtList01)
        Me.Controls.Add(Me.grdList02)
        Me.Controls.Add(Me.grdList01)
        Me.Name = "FRM_305050"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList01, 0)
        Me.Controls.SetChildIndex(Me.grdList02, 0)
        Me.Controls.SetChildIndex(Me.txtList01, 0)
        Me.Controls.SetChildIndex(Me.txtList02, 0)
        Me.Controls.SetChildIndex(Me.cboXCONVYOR_YOUTO, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtXBERTH_GROUP, 0)
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdList02 As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList01 As GamenCommon.cmpMDataGrid
    Friend WithEvents txtList01 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtList02 As MateCommon.cmpMTextBoxString
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboXCONVYOR_YOUTO As MateCommon.cmpMComboBox
    Friend WithEvents tmr305050 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtXBERTH_GROUP As MateCommon.cmpMTextBoxNumber

End Class
