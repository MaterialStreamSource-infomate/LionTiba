<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308150
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
        Me.lblXCAR_NO_WARITUKE = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(168, 672)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1032, 672)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(920, 672)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(808, 672)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(696, 672)
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(584, 672)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(472, 672)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(360, 672)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(170, 144)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 512)
        Me.grdList.TabIndex = 27
        '
        'lblXCAR_NO_WARITUKE
        '
        Me.lblXCAR_NO_WARITUKE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXCAR_NO_WARITUKE.ForeColor = System.Drawing.Color.Black
        Me.lblXCAR_NO_WARITUKE.Location = New System.Drawing.Point(288, 88)
        Me.lblXCAR_NO_WARITUKE.Name = "lblXCAR_NO_WARITUKE"
        Me.lblXCAR_NO_WARITUKE.Size = New System.Drawing.Size(64, 32)
        Me.lblXCAR_NO_WARITUKE.TabIndex = 26
        Me.lblXCAR_NO_WARITUKE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(176, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 32)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "受付車番:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_308150
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.lblXCAR_NO_WARITUKE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grdList)
        Me.Name = "FRM_308150"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lblXCAR_NO_WARITUKE, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents lblXCAR_NO_WARITUKE As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
