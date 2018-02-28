<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100101
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
        Me.lblMsg = New System.Windows.Forms.Label
        Me.pctIcon = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pctIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblMsg.ForeColor = System.Drawing.Color.Black
        Me.lblMsg.Location = New System.Drawing.Point(104, 8)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(368, 96)
        Me.lblMsg.TabIndex = 11
        Me.lblMsg.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸ"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pctIcon
        '
        Me.pctIcon.Location = New System.Drawing.Point(24, 32)
        Me.pctIcon.Name = "pctIcon"
        Me.pctIcon.Size = New System.Drawing.Size(48, 48)
        Me.pctIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctIcon.TabIndex = 12
        Me.pctIcon.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'FRM_100101
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 165)
        Me.Controls.Add(Me.pctIcon)
        Me.Controls.Add(Me.lblMsg)
        Me.Location = New System.Drawing.Point(1, 1)
        Me.MaximumSize = New System.Drawing.Size(496, 190)
        Me.MinimumSize = New System.Drawing.Size(496, 190)
        Me.Name = "FRM_100101"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "XXXXXX"
        CType(Me.pctIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents pctIcon As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
