<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308081
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.cboXHINSHITU_STS = New MateCommon.cmpMComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblXHORYU_REASON = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(304, 184)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(16, 184)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 6
        Me.cmdZikkou.Text = "登録"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'cboXHINSHITU_STS
        '
        Me.cboXHINSHITU_STS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXHINSHITU_STS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXHINSHITU_STS.FormattingEnabled = True
        Me.cboXHINSHITU_STS.IntegralHeight = False
        Me.cboXHINSHITU_STS.Location = New System.Drawing.Point(232, 104)
        Me.cboXHINSHITU_STS.Name = "cboXHINSHITU_STS"
        Me.cboXHINSHITU_STS.Size = New System.Drawing.Size(192, 28)
        Me.cboXHINSHITU_STS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(56, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "品質ステータス:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXHORYU_REASON
        '
        Me.lblXHORYU_REASON.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXHORYU_REASON.ForeColor = System.Drawing.Color.Black
        Me.lblXHORYU_REASON.Location = New System.Drawing.Point(32, 16)
        Me.lblXHORYU_REASON.Name = "lblXHORYU_REASON"
        Me.lblXHORYU_REASON.Size = New System.Drawing.Size(387, 56)
        Me.lblXHORYU_REASON.TabIndex = 2
        Me.lblXHORYU_REASON.Text = "品質ステータスを設定後、実行ボタンを押下して下さい。"
        Me.lblXHORYU_REASON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_308081
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(537, 234)
        Me.Controls.Add(Me.lblXHORYU_REASON)
        Me.Controls.Add(Me.cboXHINSHITU_STS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Name = "FRM_308081"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "品質ｽﾃｰﾀｽ登録確認"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents cboXHINSHITU_STS As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblXHORYU_REASON As System.Windows.Forms.Label

End Class
