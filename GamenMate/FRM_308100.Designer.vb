<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308100
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
        Me.chkFTRK_BUF_NO_J8100 = New System.Windows.Forms.CheckBox
        Me.chkFTRK_BUF_NO_J8001 = New System.Windows.Forms.CheckBox
        Me.chkFTRK_BUF_NO_J8000 = New System.Windows.Forms.CheckBox
        Me.dtpXHATKOU_DT = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label4 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList2 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(286, 665)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 665)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 118)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFTRK_BUF_NO_J8100)
        Me.GroupBox1.Controls.Add(Me.chkFTRK_BUF_NO_J8001)
        Me.GroupBox1.Controls.Add(Me.chkFTRK_BUF_NO_J8000)
        Me.GroupBox1.Controls.Add(Me.dtpXHATKOU_DT)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 64)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'chkFTRK_BUF_NO_J8100
        '
        Me.chkFTRK_BUF_NO_J8100.AutoSize = True
        Me.chkFTRK_BUF_NO_J8100.Checked = True
        Me.chkFTRK_BUF_NO_J8100.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFTRK_BUF_NO_J8100.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkFTRK_BUF_NO_J8100.ForeColor = System.Drawing.Color.Black
        Me.chkFTRK_BUF_NO_J8100.Location = New System.Drawing.Point(696, 24)
        Me.chkFTRK_BUF_NO_J8100.Name = "chkFTRK_BUF_NO_J8100"
        Me.chkFTRK_BUF_NO_J8100.Size = New System.Drawing.Size(112, 24)
        Me.chkFTRK_BUF_NO_J8100.TabIndex = 4
        Me.chkFTRK_BUF_NO_J8100.Text = "外部倉庫"
        Me.chkFTRK_BUF_NO_J8100.UseVisualStyleBackColor = True
        '
        'chkFTRK_BUF_NO_J8001
        '
        Me.chkFTRK_BUF_NO_J8001.AutoSize = True
        Me.chkFTRK_BUF_NO_J8001.Checked = True
        Me.chkFTRK_BUF_NO_J8001.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFTRK_BUF_NO_J8001.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkFTRK_BUF_NO_J8001.ForeColor = System.Drawing.Color.Black
        Me.chkFTRK_BUF_NO_J8001.Location = New System.Drawing.Point(528, 24)
        Me.chkFTRK_BUF_NO_J8001.Name = "chkFTRK_BUF_NO_J8001"
        Me.chkFTRK_BUF_NO_J8001.Size = New System.Drawing.Size(133, 24)
        Me.chkFTRK_BUF_NO_J8001.TabIndex = 3
        Me.chkFTRK_BUF_NO_J8001.Text = "１Ｆ平置場"
        Me.chkFTRK_BUF_NO_J8001.UseVisualStyleBackColor = True
        '
        'chkFTRK_BUF_NO_J8000
        '
        Me.chkFTRK_BUF_NO_J8000.AutoSize = True
        Me.chkFTRK_BUF_NO_J8000.Checked = True
        Me.chkFTRK_BUF_NO_J8000.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFTRK_BUF_NO_J8000.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkFTRK_BUF_NO_J8000.ForeColor = System.Drawing.Color.Black
        Me.chkFTRK_BUF_NO_J8000.Location = New System.Drawing.Point(368, 24)
        Me.chkFTRK_BUF_NO_J8000.Name = "chkFTRK_BUF_NO_J8000"
        Me.chkFTRK_BUF_NO_J8000.Size = New System.Drawing.Size(124, 24)
        Me.chkFTRK_BUF_NO_J8000.TabIndex = 2
        Me.chkFTRK_BUF_NO_J8000.Text = "ﾊﾞﾗ平置場"
        Me.chkFTRK_BUF_NO_J8000.UseVisualStyleBackColor = True
        '
        'dtpXHATKOU_DT
        '
        Me.dtpXHATKOU_DT.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpXHATKOU_DT.Location = New System.Drawing.Point(152, 16)
        Me.dtpXHATKOU_DT.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpXHATKOU_DT.Name = "dtpXHATKOU_DT"
        Me.dtpXHATKOU_DT.Size = New System.Drawing.Size(168, 32)
        Me.dtpXHATKOU_DT.TabIndex = 1
        Me.dtpXHATKOU_DT.TimeComboDisp = False
        Me.dtpXHATKOU_DT.userChecked = True
        Me.dtpXHATKOU_DT.userShowCheckBox = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "発行日:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 168)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 481)
        Me.grdList.TabIndex = 21
        '
        'grdList2
        '
        Me.grdList2.blnDBUpdate = False
        Me.grdList2.blnSelectionChanged = False
        Me.grdList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList2.Location = New System.Drawing.Point(1120, 672)
        Me.grdList2.MyBeseDoubleBuffered = False
        Me.grdList2.Name = "grdList2"
        Me.grdList2.RowTemplate.Height = 21
        Me.grdList2.Size = New System.Drawing.Size(114, 39)
        Me.grdList2.TabIndex = 213
        Me.grdList2.Visible = False
        '
        'FRM_308100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_308100"
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList2, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkFTRK_BUF_NO_J8001 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFTRK_BUF_NO_J8000 As System.Windows.Forms.CheckBox
    Friend WithEvents dtpXHATKOU_DT As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents chkFTRK_BUF_NO_J8100 As System.Windows.Forms.CheckBox
    Friend WithEvents grdList2 As GamenCommon.cmpMDataGrid

    'Required by the Windows Form Designer

End Class
