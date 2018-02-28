<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA_100004
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
        Me.lblUserCd = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(442, 32)
        Me.lblTitle.TabIndex = 50
        Me.lblTitle.Text = "メッセージ"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserCd
        '
        Me.lblUserCd.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUserCd.ForeColor = System.Drawing.Color.Black
        Me.lblUserCd.Location = New System.Drawing.Point(0, 34)
        Me.lblUserCd.Name = "lblUserCd"
        Me.lblUserCd.Size = New System.Drawing.Size(442, 164)
        Me.lblUserCd.TabIndex = 52
        Me.lblUserCd.Text = "しばらくお待ち下さい"
        Me.lblUserCd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PDA_100004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(438, 198)
        Me.Controls.Add(Me.lblUserCd)
        Me.Controls.Add(Me.lblTitle)
        Me.Location = New System.Drawing.Point(10, 100)
        Me.Name = "PDA_100004"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblUserCd As System.Windows.Forms.Label

End Class
