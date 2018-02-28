<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307102
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
        Me.txtGENZAI_VOL = New MateCommon.cmpMTextBoxNumber
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdSend = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblNo = New System.Windows.Forms.Label
        Me.lblPLC_STNo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtGENZAI_VOL
        '
        Me.txtGENZAI_VOL.BackColorMask = System.Drawing.Color.Empty
        Me.txtGENZAI_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtGENZAI_VOL.Format = "##0"
        Me.txtGENZAI_VOL.Location = New System.Drawing.Point(202, 53)
        Me.txtGENZAI_VOL.MaxLength = 5
        Me.txtGENZAI_VOL.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtGENZAI_VOL.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGENZAI_VOL.Name = "txtGENZAI_VOL"
        Me.txtGENZAI_VOL.Nullable = True
        Me.txtGENZAI_VOL.Size = New System.Drawing.Size(87, 27)
        Me.txtGENZAI_VOL.TabIndex = 180
        Me.txtGENZAI_VOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGENZAI_VOL.Value = Nothing
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(198, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 32)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "現在数"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSend
        '
        Me.cmdSend.BackColor = System.Drawing.Color.DarkGray
        Me.cmdSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSend.ForeColor = System.Drawing.Color.Black
        Me.cmdSend.Location = New System.Drawing.Point(48, 141)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(187, 40)
        Me.cmdSend.TabIndex = 181
        Me.cmdSend.Text = "修正"
        Me.cmdSend.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(257, 141)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdCancel.TabIndex = 182
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lblNo
        '
        Me.lblNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.Location = New System.Drawing.Point(12, 18)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(87, 32)
        Me.lblNo.TabIndex = 183
        Me.lblNo.Text = "ST№"
        Me.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPLC_STNo
        '
        Me.lblPLC_STNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPLC_STNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblPLC_STNo.ForeColor = System.Drawing.Color.Black
        Me.lblPLC_STNo.Location = New System.Drawing.Point(12, 50)
        Me.lblPLC_STNo.Name = "lblPLC_STNo"
        Me.lblPLC_STNo.Size = New System.Drawing.Size(87, 32)
        Me.lblPLC_STNo.TabIndex = 184
        Me.lblPLC_STNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_307102
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(494, 195)
        Me.Controls.Add(Me.txtGENZAI_VOL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblNo)
        Me.Controls.Add(Me.lblPLC_STNo)
        Me.Name = "FRM_307102"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "出庫予定数ﾃﾞｰﾀﾒﾝﾃﾅﾝｽ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtGENZAI_VOL As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents lblPLC_STNo As System.Windows.Forms.Label

End Class
