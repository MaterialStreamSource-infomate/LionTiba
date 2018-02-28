<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_302012
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
        Me.cmdNippouOut = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_D = New GamenCommon.cmpMDateTimePicker_DT
        Me.SuspendLayout()
        '
        'cmdNippouOut
        '
        Me.cmdNippouOut.BackColor = System.Drawing.Color.DarkGray
        Me.cmdNippouOut.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdNippouOut.ForeColor = System.Drawing.Color.Black
        Me.cmdNippouOut.Location = New System.Drawing.Point(8, 62)
        Me.cmdNippouOut.Name = "cmdNippouOut"
        Me.cmdNippouOut.Size = New System.Drawing.Size(187, 40)
        Me.cmdNippouOut.TabIndex = 30
        Me.cmdNippouOut.Text = "日報出力"
        Me.cmdNippouOut.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(232, 62)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdCancel.TabIndex = 32
        Me.cmdCancel.Text = "戻る"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(52, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 32)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "日付:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_D
        '
        Me.cboXSYUKKA_D.BackColorMask = System.Drawing.SystemColors.Control
        Me.cboXSYUKKA_D.Location = New System.Drawing.Point(139, 16)
        Me.cboXSYUKKA_D.Margin = New System.Windows.Forms.Padding(1)
        Me.cboXSYUKKA_D.Name = "cboXSYUKKA_D"
        Me.cboXSYUKKA_D.Size = New System.Drawing.Size(168, 32)
        Me.cboXSYUKKA_D.TabIndex = 45
        Me.cboXSYUKKA_D.TimeComboDisp = False
        Me.cboXSYUKKA_D.userChecked = True
        Me.cboXSYUKKA_D.userShowCheckBox = True
        '
        'FRM_302012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(427, 115)
        Me.Controls.Add(Me.cboXSYUKKA_D)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdNippouOut)
        Me.Name = "FRM_302012"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生産ﾗｲﾝ日報出力"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdNippouOut As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboXSYUKKA_D As GamenCommon.cmpMDateTimePicker_DT

End Class
