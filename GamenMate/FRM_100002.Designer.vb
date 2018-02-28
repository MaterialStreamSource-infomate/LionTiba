<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100002
    Inherits FRM_000001

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。

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
        Me.trvTree = New System.Windows.Forms.TreeView
        Me.cmdF8 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.tmrTest_1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'trvTree
        '
        Me.trvTree.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.trvTree.Location = New System.Drawing.Point(0, 0)
        Me.trvTree.Name = "trvTree"
        Me.trvTree.Size = New System.Drawing.Size(304, 600)
        Me.trvTree.TabIndex = 0
        '
        'cmdF8
        '
        Me.cmdF8.BackColor = System.Drawing.Color.DarkGray
        Me.cmdF8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF8.ForeColor = System.Drawing.Color.Black
        Me.cmdF8.Location = New System.Drawing.Point(96, 648)
        Me.cmdF8.Name = "cmdF8"
        Me.cmdF8.Size = New System.Drawing.Size(104, 40)
        Me.cmdF8.TabIndex = 11
        Me.cmdF8.Text = "戻る"
        Me.cmdF8.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(96, 616)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "F8"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrTest_1
        '
        '
        'FRM_100002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdF8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.trvTree)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(0, 50)
        Me.MaximumSize = New System.Drawing.Size(310, 708)
        Me.MinimumSize = New System.Drawing.Size(310, 708)
        Me.Name = "FRM_100002"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents trvTree As System.Windows.Forms.TreeView
    Friend WithEvents cmdF8 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tmrTest_1 As System.Windows.Forms.Timer
End Class
