<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA_100101
    Inherits GamenMatePDA.PDA_000001

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
        Me.pctIcon = New System.Windows.Forms.PictureBox
        Me.lblMsg = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pctIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pctIcon
        '
        Me.pctIcon.Location = New System.Drawing.Point(12, 86)
        Me.pctIcon.Name = "pctIcon"
        Me.pctIcon.Size = New System.Drawing.Size(48, 48)
        Me.pctIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctIcon.TabIndex = 58
        Me.pctIcon.TabStop = False
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Black
        Me.lblMsg.Location = New System.Drawing.Point(86, 40)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(378, 136)
        Me.lblMsg.TabIndex = 57
        Me.lblMsg.Text = "XXXXXXXXXXXXXXXXX"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(474, 32)
        Me.lblTitle.TabIndex = 56
        Me.lblTitle.Text = "XXXX"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'PDA_100101
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(468, 233)
        Me.Controls.Add(Me.pctIcon)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.lblTitle)
        Me.Location = New System.Drawing.Point(5, 220)
        Me.Name = "PDA_100101"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pctIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pctIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
