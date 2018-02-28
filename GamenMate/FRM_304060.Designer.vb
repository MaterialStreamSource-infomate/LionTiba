<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_304060
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
        Me.cboFRESULT_DT = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblJISSEKI_VOL = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblPL_VOL = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 671)
        Me.cmdF4.TabIndex = 3
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(868, 114)
        Me.cmdF1.TabIndex = 1
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(252, 166)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(869, 336)
        Me.grdList.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboFRESULT_DT)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(369, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(486, 62)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'cboFRESULT_DT
        '
        Me.cboFRESULT_DT.BackColorMask = System.Drawing.SystemColors.Control
        Me.cboFRESULT_DT.Location = New System.Drawing.Point(164, 16)
        Me.cboFRESULT_DT.Margin = New System.Windows.Forms.Padding(1)
        Me.cboFRESULT_DT.Name = "cboFRESULT_DT"
        Me.cboFRESULT_DT.Size = New System.Drawing.Size(168, 32)
        Me.cboFRESULT_DT.TabIndex = 1
        Me.cboFRESULT_DT.TimeComboDisp = False
        Me.cboFRESULT_DT.userChecked = True
        Me.cboFRESULT_DT.userShowCheckBox = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(23, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 32)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "生産日:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblJISSEKI_VOL
        '
        Me.lblJISSEKI_VOL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblJISSEKI_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblJISSEKI_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblJISSEKI_VOL.Location = New System.Drawing.Point(592, 530)
        Me.lblJISSEKI_VOL.Name = "lblJISSEKI_VOL"
        Me.lblJISSEKI_VOL.Size = New System.Drawing.Size(170, 32)
        Me.lblJISSEKI_VOL.TabIndex = 228
        Me.lblJISSEKI_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(426, 530)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 32)
        Me.Label6.TabIndex = 226
        Me.Label6.Text = "合計実績数:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPL_VOL
        '
        Me.lblPL_VOL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPL_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblPL_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblPL_VOL.Location = New System.Drawing.Point(951, 530)
        Me.lblPL_VOL.Name = "lblPL_VOL"
        Me.lblPL_VOL.Size = New System.Drawing.Size(170, 32)
        Me.lblPL_VOL.TabIndex = 230
        Me.lblPL_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(785, 530)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 32)
        Me.Label2.TabIndex = 229
        Me.Label2.Text = "合計PL数:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_304060
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.lblPL_VOL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblJISSEKI_VOL)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FRM_304060"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lblJISSEKI_VOL, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblPL_VOL, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFRESULT_DT As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblJISSEKI_VOL As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPL_VOL As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
