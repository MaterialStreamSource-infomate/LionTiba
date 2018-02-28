<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_304040
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
        Me.cboXSYUKKA_D = New GamenCommon.cmpMDateTimePicker_DT
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.txtXHENSEI_NO = New MateCommon.cmpMTextBoxString
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(168, 668)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 113)
        Me.cmdF1.TabIndex = 1
        '
        'cboXSYUKKA_D
        '
        Me.cboXSYUKKA_D.BackColorMask = System.Drawing.SystemColors.Control
        Me.cboXSYUKKA_D.Location = New System.Drawing.Point(147, 15)
        Me.cboXSYUKKA_D.Margin = New System.Windows.Forms.Padding(1)
        Me.cboXSYUKKA_D.Name = "cboXSYUKKA_D"
        Me.cboXSYUKKA_D.Size = New System.Drawing.Size(168, 32)
        Me.cboXSYUKKA_D.TabIndex = 0
        Me.cboXSYUKKA_D.TimeComboDisp = False
        Me.cboXSYUKKA_D.userChecked = True
        Me.cboXSYUKKA_D.userShowCheckBox = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtXHENSEI_NO)
        Me.GroupBox1.Controls.Add(Me.cboXSYUKKA_D)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(617, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "出荷日付:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(341, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "編成No.:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 169)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 493)
        Me.grdList.TabIndex = 2
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
        Me.txtXHENSEI_NO.Location = New System.Drawing.Point(465, 18)
        Me.txtXHENSEI_NO.MaxLength = 4
        Me.txtXHENSEI_NO.MaxLengthByte = 0
        Me.txtXHENSEI_NO.Name = "txtXHENSEI_NO"
        Me.txtXHENSEI_NO.RegexCustomFalse = Nothing
        Me.txtXHENSEI_NO.RegexCustomTrue = Nothing
        Me.txtXHENSEI_NO.Size = New System.Drawing.Size(74, 27)
        Me.txtXHENSEI_NO.TabIndex = 7
        Me.txtXHENSEI_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FRM_304040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grdList)
        Me.Name = "FRM_304040"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboXSYUKKA_D As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents txtXHENSEI_NO As MateCommon.cmpMTextBoxString

End Class
