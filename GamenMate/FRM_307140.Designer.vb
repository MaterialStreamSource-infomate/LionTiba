<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307140
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
        Me.tmr307130 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdRedisplay = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblGET_Time = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdF1.Location = New System.Drawing.Point(169, 664)
        Me.cmdF1.Size = New System.Drawing.Size(120, 43)
        '
        'tmr307130
        '
        Me.tmr307130.Interval = 5000
        '
        'cmdRedisplay
        '
        Me.cmdRedisplay.BackColor = System.Drawing.Color.DarkGray
        Me.cmdRedisplay.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdRedisplay.ForeColor = System.Drawing.Color.Black
        Me.cmdRedisplay.Location = New System.Drawing.Point(231, 586)
        Me.cmdRedisplay.Name = "cmdRedisplay"
        Me.cmdRedisplay.Size = New System.Drawing.Size(187, 40)
        Me.cmdRedisplay.TabIndex = 220
        Me.cmdRedisplay.Text = "再表示"
        Me.cmdRedisplay.UseVisualStyleBackColor = False
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.DarkGray
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClear.ForeColor = System.Drawing.Color.Black
        Me.cmdClear.Location = New System.Drawing.Point(496, 586)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(187, 40)
        Me.cmdClear.TabIndex = 221
        Me.cmdClear.Text = "クリア"
        Me.cmdClear.UseVisualStyleBackColor = False
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.Color.DarkGray
        Me.cmdDelete.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDelete.ForeColor = System.Drawing.Color.Black
        Me.cmdDelete.Location = New System.Drawing.Point(700, 586)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(187, 40)
        Me.cmdDelete.TabIndex = 222
        Me.cmdDelete.Text = "削除"
        Me.cmdDelete.UseVisualStyleBackColor = False
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 100)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 545)
        Me.grdList.TabIndex = 223
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(164, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 32)
        Me.Label14.TabIndex = 224
        Me.Label14.Text = "データ取得日時:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label14.Visible = False
        '
        'lblGET_Time
        '
        Me.lblGET_Time.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGET_Time.ForeColor = System.Drawing.Color.Black
        Me.lblGET_Time.Location = New System.Drawing.Point(339, 65)
        Me.lblGET_Time.Name = "lblGET_Time"
        Me.lblGET_Time.Size = New System.Drawing.Size(305, 32)
        Me.lblGET_Time.TabIndex = 225
        Me.lblGET_Time.Text = "2013/01/01 00:00:00"
        Me.lblGET_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblGET_Time.Visible = False
        '
        'FRM_307140
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblGET_Time)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdRedisplay)
        Me.Name = "FRM_307140"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.cmdRedisplay, 0)
        Me.Controls.SetChildIndex(Me.cmdClear, 0)
        Me.Controls.SetChildIndex(Me.cmdDelete, 0)
        Me.Controls.SetChildIndex(Me.lblGET_Time, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmr307130 As System.Windows.Forms.Timer
    Friend WithEvents cmdRedisplay As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblGET_Time As System.Windows.Forms.Label

End Class
