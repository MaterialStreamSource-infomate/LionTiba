<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307100
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
        Me.grdList01 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.lblGET_Time = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.grdList02 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList03 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList04 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.txtList01 = New MateCommon.cmpMTextBoxString
        Me.txtList02 = New MateCommon.cmpMTextBoxString
        Me.txtList03 = New MateCommon.cmpMTextBoxString
        Me.txtList04 = New MateCommon.cmpMTextBoxString
        Me.tmr307100 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList04, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1116, 484)
        Me.cmdF7.Size = New System.Drawing.Size(120, 43)
        Me.cmdF7.TabIndex = 9
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(563, 484)
        Me.cmdF6.Size = New System.Drawing.Size(120, 43)
        Me.cmdF6.TabIndex = 8
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1036, 717)
        Me.cmdF1.Size = New System.Drawing.Size(120, 43)
        '
        'grdList01
        '
        Me.grdList01.blnDBUpdate = False
        Me.grdList01.blnSelectionChanged = False
        Me.grdList01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList01.Location = New System.Drawing.Point(168, 100)
        Me.grdList01.MyBeseDoubleBuffered = False
        Me.grdList01.Name = "grdList01"
        Me.grdList01.RowTemplate.Height = 21
        Me.grdList01.Size = New System.Drawing.Size(260, 310)
        Me.grdList01.TabIndex = 0
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
        'grdList02
        '
        Me.grdList02.blnDBUpdate = False
        Me.grdList02.blnSelectionChanged = False
        Me.grdList02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList02.Location = New System.Drawing.Point(444, 100)
        Me.grdList02.MyBeseDoubleBuffered = False
        Me.grdList02.Name = "grdList02"
        Me.grdList02.RowTemplate.Height = 21
        Me.grdList02.Size = New System.Drawing.Size(260, 310)
        Me.grdList02.TabIndex = 2
        '
        'grdList03
        '
        Me.grdList03.blnDBUpdate = False
        Me.grdList03.blnSelectionChanged = False
        Me.grdList03.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList03.Location = New System.Drawing.Point(720, 100)
        Me.grdList03.MyBeseDoubleBuffered = False
        Me.grdList03.Name = "grdList03"
        Me.grdList03.RowTemplate.Height = 21
        Me.grdList03.Size = New System.Drawing.Size(260, 310)
        Me.grdList03.TabIndex = 4
        '
        'grdList04
        '
        Me.grdList04.blnDBUpdate = False
        Me.grdList04.blnSelectionChanged = False
        Me.grdList04.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList04.Location = New System.Drawing.Point(994, 100)
        Me.grdList04.MyBeseDoubleBuffered = False
        Me.grdList04.Name = "grdList04"
        Me.grdList04.RowTemplate.Height = 21
        Me.grdList04.Size = New System.Drawing.Size(260, 366)
        Me.grdList04.TabIndex = 6
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
        Me.txtList01.Location = New System.Drawing.Point(327, 619)
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
        Me.txtList02.Location = New System.Drawing.Point(603, 619)
        Me.txtList02.MaxLength = 8
        Me.txtList02.MaxLengthByte = 0
        Me.txtList02.Name = "txtList02"
        Me.txtList02.RegexCustomFalse = Nothing
        Me.txtList02.RegexCustomTrue = Nothing
        Me.txtList02.Size = New System.Drawing.Size(101, 26)
        Me.txtList02.TabIndex = 3
        '
        'txtList03
        '
        Me.txtList03.BackColor = System.Drawing.Color.White
        Me.txtList03.BackColorMask = System.Drawing.Color.Empty
        Me.txtList03.EnabledFull = True
        Me.txtList03.EnabledFullAlphabetLower = False
        Me.txtList03.EnabledFullAlphabetUpper = False
        Me.txtList03.EnabledFullHiragana = False
        Me.txtList03.EnabledFullKatakana = False
        Me.txtList03.EnabledFullNumber = False
        Me.txtList03.EnabledHalf = True
        Me.txtList03.EnabledHalfAlphabetLower = True
        Me.txtList03.EnabledHalfAlphabetUpper = True
        Me.txtList03.EnabledHalfKatakana = True
        Me.txtList03.EnabledHalfNumber = True
        Me.txtList03.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtList03.Location = New System.Drawing.Point(879, 619)
        Me.txtList03.MaxLength = 8
        Me.txtList03.MaxLengthByte = 0
        Me.txtList03.Name = "txtList03"
        Me.txtList03.RegexCustomFalse = Nothing
        Me.txtList03.RegexCustomTrue = Nothing
        Me.txtList03.Size = New System.Drawing.Size(101, 26)
        Me.txtList03.TabIndex = 5
        '
        'txtList04
        '
        Me.txtList04.BackColor = System.Drawing.Color.White
        Me.txtList04.BackColorMask = System.Drawing.Color.Empty
        Me.txtList04.EnabledFull = True
        Me.txtList04.EnabledFullAlphabetLower = False
        Me.txtList04.EnabledFullAlphabetUpper = False
        Me.txtList04.EnabledFullHiragana = False
        Me.txtList04.EnabledFullKatakana = False
        Me.txtList04.EnabledFullNumber = False
        Me.txtList04.EnabledHalf = True
        Me.txtList04.EnabledHalfAlphabetLower = True
        Me.txtList04.EnabledHalfAlphabetUpper = True
        Me.txtList04.EnabledHalfKatakana = True
        Me.txtList04.EnabledHalfNumber = True
        Me.txtList04.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtList04.Location = New System.Drawing.Point(1153, 619)
        Me.txtList04.MaxLength = 8
        Me.txtList04.MaxLengthByte = 0
        Me.txtList04.Name = "txtList04"
        Me.txtList04.RegexCustomFalse = Nothing
        Me.txtList04.RegexCustomTrue = Nothing
        Me.txtList04.Size = New System.Drawing.Size(101, 26)
        Me.txtList04.TabIndex = 7
        '
        'tmr307100
        '
        Me.tmr307100.Interval = 5000
        '
        'FRM_307100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.lblGET_Time)
        Me.Controls.Add(Me.txtList04)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtList03)
        Me.Controls.Add(Me.txtList02)
        Me.Controls.Add(Me.txtList01)
        Me.Controls.Add(Me.grdList04)
        Me.Controls.Add(Me.grdList03)
        Me.Controls.Add(Me.grdList02)
        Me.Controls.Add(Me.grdList01)
        Me.Name = "FRM_307100"
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
        Me.Controls.SetChildIndex(Me.grdList03, 0)
        Me.Controls.SetChildIndex(Me.grdList04, 0)
        Me.Controls.SetChildIndex(Me.txtList01, 0)
        Me.Controls.SetChildIndex(Me.txtList02, 0)
        Me.Controls.SetChildIndex(Me.txtList03, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.txtList04, 0)
        Me.Controls.SetChildIndex(Me.lblGET_Time, 0)
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList04, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdList01 As GamenCommon.cmpMDataGrid
    Friend WithEvents lblGET_Time As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents grdList02 As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList03 As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList04 As GamenCommon.cmpMDataGrid
    Friend WithEvents txtList01 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtList02 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtList03 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtList04 As MateCommon.cmpMTextBoxString
    Friend WithEvents tmr307100 As System.Windows.Forms.Timer

End Class
