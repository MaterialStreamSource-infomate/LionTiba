<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_311090
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
        Me.grdList_Berth = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grdList_Loader = New GamenCommon.cmpMDataGrid(Me.components)
        Me.tmr311090 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.grdList_Bara_Wait = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdList_PL_Wait = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.grdList_Wait = New GamenCommon.cmpMDataGrid(Me.components)
        Me.chkDISP_FLG = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList_Berth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdList_Loader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grdList_Bara_Wait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdList_PL_Wait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.grdList_Wait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(1162, 626)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1138, 374)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdList_Berth)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(545, 102)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(721, 491)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "パレット積み＆バラ積みバース"
        '
        'grdList_Berth
        '
        Me.grdList_Berth.blnDBUpdate = False
        Me.grdList_Berth.blnSelectionChanged = False
        Me.grdList_Berth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList_Berth.Location = New System.Drawing.Point(6, 22)
        Me.grdList_Berth.MyBeseDoubleBuffered = False
        Me.grdList_Berth.Name = "grdList_Berth"
        Me.grdList_Berth.RowTemplate.Height = 21
        Me.grdList_Berth.Size = New System.Drawing.Size(708, 460)
        Me.grdList_Berth.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grdList_Loader)
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 102)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(521, 198)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ローダバース"
        '
        'grdList_Loader
        '
        Me.grdList_Loader.blnDBUpdate = False
        Me.grdList_Loader.blnSelectionChanged = False
        Me.grdList_Loader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList_Loader.Location = New System.Drawing.Point(6, 22)
        Me.grdList_Loader.MyBeseDoubleBuffered = False
        Me.grdList_Loader.Name = "grdList_Loader"
        Me.grdList_Loader.RowTemplate.Height = 21
        Me.grdList_Loader.Size = New System.Drawing.Size(508, 166)
        Me.grdList_Loader.TabIndex = 0
        '
        'tmr311090
        '
        Me.tmr311090.Interval = 5000
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.grdList_Bara_Wait)
        Me.GroupBox4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(12, 471)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(255, 219)
        Me.GroupBox4.TabIndex = 214
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "バラ積み待ち車輌"
        '
        'grdList_Bara_Wait
        '
        Me.grdList_Bara_Wait.blnDBUpdate = False
        Me.grdList_Bara_Wait.blnSelectionChanged = False
        Me.grdList_Bara_Wait.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList_Bara_Wait.Location = New System.Drawing.Point(6, 21)
        Me.grdList_Bara_Wait.MyBeseDoubleBuffered = False
        Me.grdList_Bara_Wait.Name = "grdList_Bara_Wait"
        Me.grdList_Bara_Wait.RowTemplate.Height = 21
        Me.grdList_Bara_Wait.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdList_Bara_Wait.Size = New System.Drawing.Size(233, 192)
        Me.grdList_Bara_Wait.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdList_PL_Wait)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(280, 306)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(253, 384)
        Me.GroupBox3.TabIndex = 213
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "パレット積み待ち車輌"
        '
        'grdList_PL_Wait
        '
        Me.grdList_PL_Wait.blnDBUpdate = False
        Me.grdList_PL_Wait.blnSelectionChanged = False
        Me.grdList_PL_Wait.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList_PL_Wait.Location = New System.Drawing.Point(6, 22)
        Me.grdList_PL_Wait.MyBeseDoubleBuffered = False
        Me.grdList_PL_Wait.Name = "grdList_PL_Wait"
        Me.grdList_PL_Wait.RowTemplate.Height = 21
        Me.grdList_PL_Wait.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdList_PL_Wait.Size = New System.Drawing.Size(233, 356)
        Me.grdList_PL_Wait.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.grdList_Wait)
        Me.GroupBox5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 306)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(255, 160)
        Me.GroupBox5.TabIndex = 215
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "ローダ積み待ち車輌"
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
        Me.grdList_Wait.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdList_Wait.Size = New System.Drawing.Size(233, 132)
        Me.grdList_Wait.TabIndex = 0
        '
        'chkDISP_FLG
        '
        Me.chkDISP_FLG.AutoSize = True
        Me.chkDISP_FLG.Checked = True
        Me.chkDISP_FLG.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDISP_FLG.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDISP_FLG.ForeColor = System.Drawing.Color.Black
        Me.chkDISP_FLG.Location = New System.Drawing.Point(1205, 599)
        Me.chkDISP_FLG.Name = "chkDISP_FLG"
        Me.chkDISP_FLG.Size = New System.Drawing.Size(61, 20)
        Me.chkDISP_FLG.TabIndex = 216
        Me.chkDISP_FLG.Text = "表示"
        Me.chkDISP_FLG.UseVisualStyleBackColor = True
        '
        'FRM_311090
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.chkDISP_FLG)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_311090"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox5, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.chkDISP_FLG, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdList_Berth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdList_Loader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grdList_Bara_Wait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdList_PL_Wait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.grdList_Wait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList_Berth As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList_Loader As GamenCommon.cmpMDataGrid
    Friend WithEvents tmr311090 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList_Bara_Wait As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList_PL_Wait As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList_Wait As GamenCommon.cmpMDataGrid
    Friend WithEvents chkDISP_FLG As System.Windows.Forms.CheckBox

End Class
