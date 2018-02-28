<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_311080
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdList_Wait = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grdList_Berth = New GamenCommon.cmpMDataGrid(Me.components)
        Me.tmr311080 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdList_Wait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList_Berth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(1034, 671)
        Me.cmdF4.Size = New System.Drawing.Size(124, 43)
        Me.cmdF4.TabIndex = 5
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(494, 671)
        Me.cmdF3.Size = New System.Drawing.Size(124, 43)
        Me.cmdF3.TabIndex = 4
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(329, 671)
        Me.cmdF2.Size = New System.Drawing.Size(124, 43)
        Me.cmdF2.TabIndex = 3
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(168, 671)
        Me.cmdF1.Size = New System.Drawing.Size(124, 43)
        Me.cmdF1.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdList_Wait)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(903, 178)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(253, 201)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "待ち車輌"
        '
        'grdList_Wait
        '
        Me.grdList_Wait.blnDBUpdate = False
        Me.grdList_Wait.blnSelectionChanged = False
        Me.grdList_Wait.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList_Wait.Location = New System.Drawing.Point(6, 22)
        Me.grdList_Wait.MyBeseDoubleBuffered = False
        Me.grdList_Wait.Name = "grdList_Wait"
        Me.grdList_Wait.RowTemplate.Height = 21
        Me.grdList_Wait.Size = New System.Drawing.Size(233, 166)
        Me.grdList_Wait.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdList_Berth)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(177, 178)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(676, 201)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ローダバース"
        '
        'grdList_Berth
        '
        Me.grdList_Berth.blnDBUpdate = False
        Me.grdList_Berth.blnSelectionChanged = False
        Me.grdList_Berth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList_Berth.Location = New System.Drawing.Point(8, 22)
        Me.grdList_Berth.MyBeseDoubleBuffered = False
        Me.grdList_Berth.Name = "grdList_Berth"
        Me.grdList_Berth.RowTemplate.Height = 21
        Me.grdList_Berth.Size = New System.Drawing.Size(658, 166)
        Me.grdList_Berth.TabIndex = 0
        '
        'tmr311080
        '
        Me.tmr311080.Interval = 5000
        '
        'FRM_311080
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_311080"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdList_Wait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdList_Berth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList_Wait As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList_Berth As GamenCommon.cmpMDataGrid
    Friend WithEvents tmr311080 As System.Windows.Forms.Timer

End Class
