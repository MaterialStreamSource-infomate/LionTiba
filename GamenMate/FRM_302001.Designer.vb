<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_302001
    Inherits GamenMate.FRM_000001

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
        Me.grdList01 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.cmdClose = New System.Windows.Forms.Button
        Me.grdList02 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.lblgrid01 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdList01
        '
        Me.grdList01.blnDBUpdate = False
        Me.grdList01.blnSelectionChanged = False
        Me.grdList01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList01.Location = New System.Drawing.Point(12, 34)
        Me.grdList01.MyBeseDoubleBuffered = False
        Me.grdList01.Name = "grdList01"
        Me.grdList01.RowTemplate.Height = 21
        Me.grdList01.Size = New System.Drawing.Size(479, 82)
        Me.grdList01.TabIndex = 0
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.DarkGray
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClose.ForeColor = System.Drawing.Color.Black
        Me.cmdClose.Location = New System.Drawing.Point(149, 508)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(216, 40)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'grdList02
        '
        Me.grdList02.blnDBUpdate = False
        Me.grdList02.blnSelectionChanged = False
        Me.grdList02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList02.Location = New System.Drawing.Point(12, 153)
        Me.grdList02.MyBeseDoubleBuffered = False
        Me.grdList02.Name = "grdList02"
        Me.grdList02.RowTemplate.Height = 21
        Me.grdList02.Size = New System.Drawing.Size(479, 334)
        Me.grdList02.TabIndex = 1
        '
        'lblgrid01
        '
        Me.lblgrid01.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblgrid01.ForeColor = System.Drawing.Color.Black
        Me.lblgrid01.Location = New System.Drawing.Point(12, 9)
        Me.lblgrid01.Name = "lblgrid01"
        Me.lblgrid01.Size = New System.Drawing.Size(305, 22)
        Me.lblgrid01.TabIndex = 275
        Me.lblgrid01.Text = "総合計"
        Me.lblgrid01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 22)
        Me.Label1.TabIndex = 276
        Me.Label1.Text = "各クレーン合計"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_302001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(508, 563)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblgrid01)
        Me.Controls.Add(Me.grdList02)
        Me.Controls.Add(Me.grdList01)
        Me.Controls.Add(Me.cmdClose)
        Me.Name = "FRM_302001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "空棚詳細"
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList01 As GamenCommon.cmpMDataGrid
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents grdList02 As GamenCommon.cmpMDataGrid
    Friend WithEvents lblgrid01 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
