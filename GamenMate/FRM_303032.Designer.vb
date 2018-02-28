<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303032
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lblIN_ST = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.grdList01 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.cmdClose = New System.Windows.Forms.Button
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblIN_ST
        '
        Me.lblIN_ST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIN_ST.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblIN_ST.ForeColor = System.Drawing.Color.Black
        Me.lblIN_ST.Location = New System.Drawing.Point(179, 9)
        Me.lblIN_ST.Name = "lblIN_ST"
        Me.lblIN_ST.Size = New System.Drawing.Size(440, 33)
        Me.lblIN_ST.TabIndex = 37
        Me.lblIN_ST.Text = "ST名"
        Me.lblIN_ST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 33)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "入庫ST:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList01
        '
        Me.grdList01.blnDBUpdate = False
        Me.grdList01.blnSelectionChanged = False
        Me.grdList01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList01.Location = New System.Drawing.Point(12, 56)
        Me.grdList01.MyBeseDoubleBuffered = False
        Me.grdList01.Name = "grdList01"
        Me.grdList01.RowTemplate.Height = 21
        Me.grdList01.Size = New System.Drawing.Size(1260, 189)
        Me.grdList01.TabIndex = 35
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.DarkGray
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClose.ForeColor = System.Drawing.Color.Black
        Me.cmdClose.Location = New System.Drawing.Point(1056, 251)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(216, 41)
        Me.cmdClose.TabIndex = 34
        Me.cmdClose.Text = "閉じる"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'FRM_303032
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1282, 296)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblIN_ST)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grdList01)
        Me.Controls.Add(Me.cmdClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_303032"
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FRM_303032"
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblIN_ST As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdList01 As GamenCommon.cmpMDataGrid
    Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class
