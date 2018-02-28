<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_205020
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
        Me.tmr205020 = New System.Windows.Forms.Timer(Me.components)
        Me.grdList01 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList02 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.txtList01 = New MateCommon.cmpMTextBoxString
        Me.txtList02 = New MateCommon.cmpMTextBoxString
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(304, 656)
        Me.cmdF5.TabIndex = 3
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(194, 656)
        Me.cmdF4.TabIndex = 2
        '
        'tmr205020
        '
        Me.tmr205020.Interval = 5000
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
        Me.grdList01.Size = New System.Drawing.Size(456, 534)
        Me.grdList01.TabIndex = 0
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
        Me.grdList02.Size = New System.Drawing.Size(456, 534)
        Me.grdList02.TabIndex = 1
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
        Me.txtList01.Location = New System.Drawing.Point(584, 608)
        Me.txtList01.MaxLength = 8
        Me.txtList01.MaxLengthByte = 0
        Me.txtList01.Name = "txtList01"
        Me.txtList01.RegexCustomFalse = Nothing
        Me.txtList01.RegexCustomTrue = Nothing
        Me.txtList01.Size = New System.Drawing.Size(101, 26)
        Me.txtList01.TabIndex = 269
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
        Me.txtList02.Location = New System.Drawing.Point(1088, 609)
        Me.txtList02.MaxLength = 8
        Me.txtList02.MaxLengthByte = 0
        Me.txtList02.Name = "txtList02"
        Me.txtList02.RegexCustomFalse = Nothing
        Me.txtList02.RegexCustomTrue = Nothing
        Me.txtList02.Size = New System.Drawing.Size(101, 26)
        Me.txtList02.TabIndex = 270
        '
        'FRM_205020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList02)
        Me.Controls.Add(Me.grdList01)
        Me.Controls.Add(Me.txtList01)
        Me.Controls.Add(Me.txtList02)
        Me.Name = "FRM_205020"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.txtList02, 0)
        Me.Controls.SetChildIndex(Me.txtList01, 0)
        Me.Controls.SetChildIndex(Me.grdList01, 0)
        Me.Controls.SetChildIndex(Me.grdList02, 0)
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmr205020 As System.Windows.Forms.Timer
    Friend WithEvents grdList01 As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList02 As GamenCommon.cmpMDataGrid
    Friend WithEvents txtList01 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtList02 As MateCommon.cmpMTextBoxString

End Class
