<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_299007
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
        Me.cmd001 = New System.Windows.Forms.Button
        Me.cmd003 = New System.Windows.Forms.Button
        Me.cmd004 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtReadFile01 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblProgress = New System.Windows.Forms.Label
        Me.cmd002 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmd001
        '
        Me.cmd001.BackColor = System.Drawing.Color.DarkGray
        Me.cmd001.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmd001.ForeColor = System.Drawing.Color.Black
        Me.cmd001.Location = New System.Drawing.Point(16, 16)
        Me.cmd001.Name = "cmd001"
        Me.cmd001.Size = New System.Drawing.Size(392, 40)
        Me.cmd001.TabIndex = 0
        Me.cmd001.Text = "平置き在庫削除"
        Me.cmd001.UseVisualStyleBackColor = False
        '
        'cmd003
        '
        Me.cmd003.BackColor = System.Drawing.Color.DarkGray
        Me.cmd003.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmd003.ForeColor = System.Drawing.Color.Black
        Me.cmd003.Location = New System.Drawing.Point(16, 224)
        Me.cmd003.Name = "cmd003"
        Me.cmd003.Size = New System.Drawing.Size(392, 40)
        Me.cmd003.TabIndex = 2
        Me.cmd003.Text = "在庫移行前ﾁｪｯｸ"
        Me.cmd003.UseVisualStyleBackColor = False
        '
        'cmd004
        '
        Me.cmd004.BackColor = System.Drawing.Color.DarkGray
        Me.cmd004.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmd004.ForeColor = System.Drawing.Color.Black
        Me.cmd004.Location = New System.Drawing.Point(16, 272)
        Me.cmd004.Name = "cmd004"
        Me.cmd004.Size = New System.Drawing.Size(392, 40)
        Me.cmd004.TabIndex = 3
        Me.cmd004.Text = "在庫移行"
        Me.cmd004.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 328)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "読込ﾌｧｲﾙ01"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReadFile01
        '
        Me.txtReadFile01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadFile01.Location = New System.Drawing.Point(104, 328)
        Me.txtReadFile01.Name = "txtReadFile01"
        Me.txtReadFile01.Size = New System.Drawing.Size(296, 19)
        Me.txtReadFile01.TabIndex = 5
        Me.txtReadFile01.Text = "C:\zaiko\hiraoki.txt"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 472)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 40)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "進捗"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProgress
        '
        Me.lblProgress.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblProgress.Location = New System.Drawing.Point(112, 472)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(288, 40)
        Me.lblProgress.TabIndex = 9
        Me.lblProgress.Text = "/"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd002
        '
        Me.cmd002.BackColor = System.Drawing.Color.DarkGray
        Me.cmd002.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmd002.ForeColor = System.Drawing.Color.Black
        Me.cmd002.Location = New System.Drawing.Point(16, 106)
        Me.cmd002.Name = "cmd002"
        Me.cmd002.Size = New System.Drawing.Size(392, 40)
        Me.cmd002.TabIndex = 10
        Me.cmd002.Text = "検品ｴﾘｱ在庫削除"
        Me.cmd002.UseVisualStyleBackColor = False
        '
        'FRM_299007
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 531)
        Me.Controls.Add(Me.cmd002)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtReadFile01)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmd004)
        Me.Controls.Add(Me.cmd001)
        Me.Controls.Add(Me.cmd003)
        Me.Name = "FRM_299007"
        Me.Text = "FRM_299005"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd001 As System.Windows.Forms.Button
    Friend WithEvents cmd003 As System.Windows.Forms.Button
    Friend WithEvents cmd004 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReadFile01 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents cmd002 As System.Windows.Forms.Button
End Class
