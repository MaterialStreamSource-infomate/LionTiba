<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307131
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblNo = New System.Windows.Forms.Label
        Me.lblPLC_STNo = New System.Windows.Forms.Label
        Me.cmdSend = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtSETTEI_VOL = New MateCommon.cmpMTextBoxNumber
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(357, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 32)
        Me.Label1.TabIndex = 174
        Me.Label1.Text = "フラグ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNo
        '
        Me.lblNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.Location = New System.Drawing.Point(12, 18)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(208, 32)
        Me.lblNo.TabIndex = 172
        Me.lblNo.Text = "生産ﾗｲﾝ/要求位置"
        Me.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPLC_STNo
        '
        Me.lblPLC_STNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPLC_STNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblPLC_STNo.ForeColor = System.Drawing.Color.Black
        Me.lblPLC_STNo.Location = New System.Drawing.Point(12, 50)
        Me.lblPLC_STNo.Name = "lblPLC_STNo"
        Me.lblPLC_STNo.Size = New System.Drawing.Size(339, 32)
        Me.lblPLC_STNo.TabIndex = 173
        Me.lblPLC_STNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSend
        '
        Me.cmdSend.BackColor = System.Drawing.Color.DarkGray
        Me.cmdSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSend.ForeColor = System.Drawing.Color.Black
        Me.cmdSend.Location = New System.Drawing.Point(48, 141)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(187, 40)
        Me.cmdSend.TabIndex = 3
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
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'txtSETTEI_VOL
        '
        Me.txtSETTEI_VOL.BackColorMask = System.Drawing.Color.Empty
        Me.txtSETTEI_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtSETTEI_VOL.Format = "##0"
        Me.txtSETTEI_VOL.Location = New System.Drawing.Point(357, 53)
        Me.txtSETTEI_VOL.MaxLength = 5
        Me.txtSETTEI_VOL.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtSETTEI_VOL.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSETTEI_VOL.Name = "txtSETTEI_VOL"
        Me.txtSETTEI_VOL.Nullable = True
        Me.txtSETTEI_VOL.Size = New System.Drawing.Size(87, 27)
        Me.txtSETTEI_VOL.TabIndex = 1
        Me.txtSETTEI_VOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSETTEI_VOL.Value = Nothing
        '
        'FRM_307131
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(494, 195)
        Me.Controls.Add(Me.txtSETTEI_VOL)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNo)
        Me.Controls.Add(Me.lblPLC_STNo)
        Me.Name = "FRM_307131"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "出庫予定数ﾃﾞｰﾀﾒﾝﾃﾅﾝｽ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents lblPLC_STNo As System.Windows.Forms.Label
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtSETTEI_VOL As MateCommon.cmpMTextBoxNumber

End Class
