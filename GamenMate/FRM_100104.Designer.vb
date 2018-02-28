<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100104
    Inherits GamenMate.FRM_100103

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
        Me.chkPrint = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkPrint.Location = New System.Drawing.Point(336, 72)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(133, 24)
        Me.chkPrint.TabIndex = 17
        Me.chkPrint.Text = "指図書発行"
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'FRM_100104
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(486, 161)
        Me.Controls.Add(Me.chkPrint)
        Me.Name = "FRM_100104"
        Me.Controls.SetChildIndex(Me.chkPrint, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox

End Class
