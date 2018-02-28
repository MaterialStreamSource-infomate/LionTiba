<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100105
    Inherits GamenMate.FRM_100101

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
        Me.cmdNO = New System.Windows.Forms.Button
        Me.cmdYES = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdNO
        '
        Me.cmdNO.BackColor = System.Drawing.Color.DarkGray
        Me.cmdNO.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdNO.ForeColor = System.Drawing.Color.Black
        Me.cmdNO.Location = New System.Drawing.Point(272, 112)
        Me.cmdNO.Name = "cmdNO"
        Me.cmdNO.Size = New System.Drawing.Size(104, 40)
        Me.cmdNO.TabIndex = 18
        Me.cmdNO.Text = "いいえ"
        Me.cmdNO.UseVisualStyleBackColor = False
        '
        'cmdYES
        '
        Me.cmdYES.BackColor = System.Drawing.Color.DarkGray
        Me.cmdYES.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdYES.ForeColor = System.Drawing.Color.Black
        Me.cmdYES.Location = New System.Drawing.Point(112, 112)
        Me.cmdYES.Name = "cmdYES"
        Me.cmdYES.Size = New System.Drawing.Size(104, 40)
        Me.cmdYES.TabIndex = 17
        Me.cmdYES.Text = "はい"
        Me.cmdYES.UseVisualStyleBackColor = False
        '
        'FRM_100105
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(490, 165)
        Me.Controls.Add(Me.cmdNO)
        Me.Controls.Add(Me.cmdYES)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "FRM_100105"
        Me.Controls.SetChildIndex(Me.cmdYES, 0)
        Me.Controls.SetChildIndex(Me.cmdNO, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdNO As System.Windows.Forms.Button
    Friend WithEvents cmdYES As System.Windows.Forms.Button

End Class
