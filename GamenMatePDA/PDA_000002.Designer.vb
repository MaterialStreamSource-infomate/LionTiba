<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA_000002
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
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblPlaceName = New System.Windows.Forms.Label
        Me.lblUserName = New System.Windows.Forms.Label
        Me.cmdF4 = New System.Windows.Forms.Button
        Me.cmdF3 = New System.Windows.Forms.Button
        Me.cmdF2 = New System.Windows.Forms.Button
        Me.cmdF1 = New System.Windows.Forms.Button
        Me.btnAFK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(480, 40)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "◆　◆"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPlaceName
        '
        Me.lblPlaceName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblPlaceName.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblPlaceName.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblPlaceName.Location = New System.Drawing.Point(235, 552)
        Me.lblPlaceName.Name = "lblPlaceName"
        Me.lblPlaceName.Size = New System.Drawing.Size(228, 32)
        Me.lblPlaceName.TabIndex = 116
        Me.lblPlaceName.Text = "< 作業場所 >"
        Me.lblPlaceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUserName
        '
        Me.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblUserName.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUserName.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblUserName.Location = New System.Drawing.Point(8, 552)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(228, 32)
        Me.lblUserName.TabIndex = 115
        Me.lblUserName.Text = "< ユーザ名 >"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdF4
        '
        Me.cmdF4.BackColor = System.Drawing.Color.OrangeRed
        Me.cmdF4.Enabled = False
        Me.cmdF4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF4.ForeColor = System.Drawing.Color.White
        Me.cmdF4.Location = New System.Drawing.Point(367, 592)
        Me.cmdF4.Name = "cmdF4"
        Me.cmdF4.Size = New System.Drawing.Size(96, 40)
        Me.cmdF4.TabIndex = 114
        Me.cmdF4.UseVisualStyleBackColor = False
        '
        'cmdF3
        '
        Me.cmdF3.BackColor = System.Drawing.Color.DarkGreen
        Me.cmdF3.Enabled = False
        Me.cmdF3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF3.ForeColor = System.Drawing.Color.White
        Me.cmdF3.Location = New System.Drawing.Point(260, 592)
        Me.cmdF3.Name = "cmdF3"
        Me.cmdF3.Size = New System.Drawing.Size(96, 40)
        Me.cmdF3.TabIndex = 113
        Me.cmdF3.UseVisualStyleBackColor = False
        '
        'cmdF2
        '
        Me.cmdF2.BackColor = System.Drawing.Color.DarkBlue
        Me.cmdF2.Enabled = False
        Me.cmdF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF2.ForeColor = System.Drawing.Color.White
        Me.cmdF2.Location = New System.Drawing.Point(117, 592)
        Me.cmdF2.Name = "cmdF2"
        Me.cmdF2.Size = New System.Drawing.Size(96, 40)
        Me.cmdF2.TabIndex = 112
        Me.cmdF2.UseVisualStyleBackColor = False
        '
        'cmdF1
        '
        Me.cmdF1.BackColor = System.Drawing.Color.DarkRed
        Me.cmdF1.Enabled = False
        Me.cmdF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdF1.ForeColor = System.Drawing.Color.White
        Me.cmdF1.Location = New System.Drawing.Point(10, 592)
        Me.cmdF1.Name = "cmdF1"
        Me.cmdF1.Size = New System.Drawing.Size(96, 40)
        Me.cmdF1.TabIndex = 111
        Me.cmdF1.UseVisualStyleBackColor = False
        '
        'btnAFK
        '
        Me.btnAFK.BackColor = System.Drawing.SystemColors.Control
        Me.btnAFK.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAFK.ForeColor = System.Drawing.Color.Black
        Me.btnAFK.Location = New System.Drawing.Point(390, 0)
        Me.btnAFK.Name = "btnAFK"
        Me.btnAFK.Size = New System.Drawing.Size(90, 40)
        Me.btnAFK.TabIndex = 110
        Me.btnAFK.Text = "離席"
        Me.btnAFK.UseVisualStyleBackColor = False
        '
        'PDA_000002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(478, 638)
        Me.Controls.Add(Me.lblPlaceName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.cmdF4)
        Me.Controls.Add(Me.cmdF3)
        Me.Controls.Add(Me.cmdF2)
        Me.Controls.Add(Me.cmdF1)
        Me.Controls.Add(Me.btnAFK)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "PDA_000002"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblPlaceName As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents cmdF4 As System.Windows.Forms.Button
    Friend WithEvents cmdF3 As System.Windows.Forms.Button
    Friend WithEvents cmdF2 As System.Windows.Forms.Button
    Friend WithEvents cmdF1 As System.Windows.Forms.Button
    Friend WithEvents btnAFK As System.Windows.Forms.Button

End Class
