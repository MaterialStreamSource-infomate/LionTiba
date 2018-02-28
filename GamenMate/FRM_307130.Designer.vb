<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307130
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
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblGET_Time = New System.Windows.Forms.Label
        Me.tmr307130 = New System.Windows.Forms.Timer(Me.components)
        Me.grdList02 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList01 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.txtList02 = New MateCommon.cmpMTextBoxString
        Me.txtList01 = New MateCommon.cmpMTextBoxString
        Me.cboGRD_CH = New MateCommon.cmpMComboBox
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1162, 664)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(563, 664)
        Me.cmdF6.Size = New System.Drawing.Size(120, 43)
        Me.cmdF6.TabIndex = 4
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(432, 664)
        Me.cmdF5.Size = New System.Drawing.Size(120, 43)
        Me.cmdF5.TabIndex = 3
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(299, 664)
        Me.cmdF4.Size = New System.Drawing.Size(120, 43)
        Me.cmdF4.TabIndex = 2
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(786, 664)
        Me.cmdF2.Size = New System.Drawing.Size(120, 43)
        Me.cmdF2.TabIndex = 1
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1036, 717)
        Me.cmdF1.Size = New System.Drawing.Size(120, 43)
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(164, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 32)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "データ取得日時:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGET_Time
        '
        Me.lblGET_Time.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGET_Time.ForeColor = System.Drawing.Color.Black
        Me.lblGET_Time.Location = New System.Drawing.Point(339, 65)
        Me.lblGET_Time.Name = "lblGET_Time"
        Me.lblGET_Time.Size = New System.Drawing.Size(305, 32)
        Me.lblGET_Time.TabIndex = 30
        Me.lblGET_Time.Text = "2013/01/01 00:00:00"
        Me.lblGET_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmr307130
        '
        Me.tmr307130.Interval = 5000
        '
        'grdList02
        '
        Me.grdList02.blnDBUpdate = False
        Me.grdList02.blnSelectionChanged = False
        Me.grdList02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList02.Location = New System.Drawing.Point(786, 129)
        Me.grdList02.MyBeseDoubleBuffered = False
        Me.grdList02.Name = "grdList02"
        Me.grdList02.RowTemplate.Height = 21
        Me.grdList02.Size = New System.Drawing.Size(334, 497)
        Me.grdList02.TabIndex = 214
        '
        'grdList01
        '
        Me.grdList01.blnDBUpdate = False
        Me.grdList01.blnSelectionChanged = False
        Me.grdList01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList01.Location = New System.Drawing.Point(367, 129)
        Me.grdList01.MyBeseDoubleBuffered = False
        Me.grdList01.Name = "grdList01"
        Me.grdList01.RowTemplate.Height = 21
        Me.grdList01.Size = New System.Drawing.Size(340, 497)
        Me.grdList01.TabIndex = 213
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
        Me.txtList02.Location = New System.Drawing.Point(831, 562)
        Me.txtList02.MaxLength = 8
        Me.txtList02.MaxLengthByte = 0
        Me.txtList02.Name = "txtList02"
        Me.txtList02.RegexCustomFalse = Nothing
        Me.txtList02.RegexCustomTrue = Nothing
        Me.txtList02.Size = New System.Drawing.Size(101, 26)
        Me.txtList02.TabIndex = 216
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
        Me.txtList01.Location = New System.Drawing.Point(555, 562)
        Me.txtList01.MaxLength = 8
        Me.txtList01.MaxLengthByte = 0
        Me.txtList01.Name = "txtList01"
        Me.txtList01.RegexCustomFalse = Nothing
        Me.txtList01.RegexCustomTrue = Nothing
        Me.txtList01.Size = New System.Drawing.Size(101, 26)
        Me.txtList01.TabIndex = 215
        '
        'cboGRD_CH
        '
        Me.cboGRD_CH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGRD_CH.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboGRD_CH.FormattingEnabled = True
        Me.cboGRD_CH.Location = New System.Drawing.Point(367, 91)
        Me.cboGRD_CH.Name = "cboGRD_CH"
        Me.cboGRD_CH.Size = New System.Drawing.Size(193, 27)
        Me.cboGRD_CH.TabIndex = 217
        '
        'FRM_307130
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.cboGRD_CH)
        Me.Controls.Add(Me.txtList02)
        Me.Controls.Add(Me.txtList01)
        Me.Controls.Add(Me.grdList02)
        Me.Controls.Add(Me.grdList01)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblGET_Time)
        Me.Name = "FRM_307130"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.lblGET_Time, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
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
        Me.Controls.SetChildIndex(Me.cboGRD_CH, 0)
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblGET_Time As System.Windows.Forms.Label
    Friend WithEvents tmr307130 As System.Windows.Forms.Timer
    Friend WithEvents grdList02 As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList01 As GamenCommon.cmpMDataGrid
    Friend WithEvents txtList02 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtList01 As MateCommon.cmpMTextBoxString
    Friend WithEvents cboGRD_CH As MateCommon.cmpMComboBox

End Class
