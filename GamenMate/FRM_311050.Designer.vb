<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_311050
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
        Me.lblNo = New System.Windows.Forms.Label
        Me.lblBERTH_NO = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSYARYOU_NO = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tmr311050 = New System.Windows.Forms.Timer(Me.components)
        Me.lblSYUKKO = New System.Windows.Forms.Label
        Me.lblHANSOU = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(1162, 562)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(1120, 668)
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(948, 668)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(298, 671)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(168, 671)
        '
        'lblNo
        '
        Me.lblNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.Location = New System.Drawing.Point(327, 101)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(87, 32)
        Me.lblNo.TabIndex = 213
        Me.lblNo.Text = "バース:"
        Me.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBERTH_NO
        '
        Me.lblBERTH_NO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBERTH_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblBERTH_NO.ForeColor = System.Drawing.Color.Black
        Me.lblBERTH_NO.Location = New System.Drawing.Point(420, 101)
        Me.lblBERTH_NO.Name = "lblBERTH_NO"
        Me.lblBERTH_NO.Size = New System.Drawing.Size(170, 32)
        Me.lblBERTH_NO.TabIndex = 214
        Me.lblBERTH_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(747, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 32)
        Me.Label1.TabIndex = 215
        Me.Label1.Text = "車番:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSYARYOU_NO
        '
        Me.lblSYARYOU_NO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSYARYOU_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSYARYOU_NO.ForeColor = System.Drawing.Color.Black
        Me.lblSYARYOU_NO.Location = New System.Drawing.Point(840, 101)
        Me.lblSYARYOU_NO.Name = "lblSYARYOU_NO"
        Me.lblSYARYOU_NO.Size = New System.Drawing.Size(170, 32)
        Me.lblSYARYOU_NO.TabIndex = 216
        Me.lblSYARYOU_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(794, 531)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 20)
        Me.Label14.TabIndex = 221
        Me.Label14.Text = "PL"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(452, 525)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 32)
        Me.Label6.TabIndex = 219
        Me.Label6.Text = "出庫中:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(794, 589)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 20)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "PL"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(452, 583)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 32)
        Me.Label3.TabIndex = 222
        Me.Label3.Text = "搬送中:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmr311050
        '
        Me.tmr311050.Interval = 5000
        '
        'lblSYUKKO
        '
        Me.lblSYUKKO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSYUKKO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSYUKKO.ForeColor = System.Drawing.Color.Black
        Me.lblSYUKKO.Location = New System.Drawing.Point(618, 525)
        Me.lblSYUKKO.Name = "lblSYUKKO"
        Me.lblSYUKKO.Size = New System.Drawing.Size(170, 32)
        Me.lblSYUKKO.TabIndex = 225
        Me.lblSYUKKO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHANSOU
        '
        Me.lblHANSOU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHANSOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblHANSOU.ForeColor = System.Drawing.Color.Black
        Me.lblHANSOU.Location = New System.Drawing.Point(618, 583)
        Me.lblHANSOU.Name = "lblHANSOU"
        Me.lblHANSOU.Size = New System.Drawing.Size(170, 32)
        Me.lblHANSOU.TabIndex = 226
        Me.lblHANSOU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 153)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1056, 326)
        Me.grdList.TabIndex = 218
        '
        'FRM_311050
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.lblHANSOU)
        Me.Controls.Add(Me.lblSYUKKO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSYARYOU_NO)
        Me.Controls.Add(Me.lblNo)
        Me.Controls.Add(Me.lblBERTH_NO)
        Me.Name = "FRM_311050"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.lblBERTH_NO, 0)
        Me.Controls.SetChildIndex(Me.lblNo, 0)
        Me.Controls.SetChildIndex(Me.lblSYARYOU_NO, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblSYUKKO, 0)
        Me.Controls.SetChildIndex(Me.lblHANSOU, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents lblBERTH_NO As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSYARYOU_NO As System.Windows.Forms.Label
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tmr311050 As System.Windows.Forms.Timer
    Friend WithEvents lblSYUKKO As System.Windows.Forms.Label
    Friend WithEvents lblHANSOU As System.Windows.Forms.Label

End Class
