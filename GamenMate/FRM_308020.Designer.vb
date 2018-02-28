<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308020
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblXBERTH_NO = New System.Windows.Forms.Label
        Me.lblXCAR_NO_WARITUKE = New System.Windows.Forms.Label
        Me.tmr308020 = New System.Windows.Forms.Timer(Me.components)
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1160, 608)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1160, 552)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(1142, 673)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(278, 673)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 673)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1160, 368)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(176, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 32)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "バース:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(366, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 32)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "受付車番:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXBERTH_NO
        '
        Me.lblXBERTH_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXBERTH_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXBERTH_NO.Location = New System.Drawing.Point(294, 88)
        Me.lblXBERTH_NO.Name = "lblXBERTH_NO"
        Me.lblXBERTH_NO.Size = New System.Drawing.Size(40, 32)
        Me.lblXBERTH_NO.TabIndex = 16
        Me.lblXBERTH_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXCAR_NO_WARITUKE
        '
        Me.lblXCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXCAR_NO_WARITUKE.ForeColor = System.Drawing.Color.Black
        Me.lblXCAR_NO_WARITUKE.Location = New System.Drawing.Point(494, 88)
        Me.lblXCAR_NO_WARITUKE.Name = "lblXCAR_NO_WARITUKE"
        Me.lblXCAR_NO_WARITUKE.Size = New System.Drawing.Size(96, 32)
        Me.lblXCAR_NO_WARITUKE.TabIndex = 18
        Me.lblXCAR_NO_WARITUKE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmr308020
        '
        Me.tmr308020.Interval = 3000
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 136)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1084, 524)
        Me.grdList.TabIndex = 21
        '
        'FRM_308020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.lblXCAR_NO_WARITUKE)
        Me.Controls.Add(Me.lblXBERTH_NO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FRM_308020"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblXBERTH_NO, 0)
        Me.Controls.SetChildIndex(Me.lblXCAR_NO_WARITUKE, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblXBERTH_NO As System.Windows.Forms.Label
    Friend WithEvents lblXCAR_NO_WARITUKE As System.Windows.Forms.Label
    Friend WithEvents tmr308020 As System.Windows.Forms.Timer
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid

End Class
