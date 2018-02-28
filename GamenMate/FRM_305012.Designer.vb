<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_305012
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
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.chkAUTO_NYUKO_FLAG = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSYUKO_PALLET_SU = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(16, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(392, 46)
        Me.Label12.TabIndex = 241
        Me.Label12.Text = "棚卸し作業を開始してよろしいですか？"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(304, 200)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 240
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(16, 200)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 239
        Me.cmdZikkou.Text = "OK"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'chkAUTO_NYUKO_FLAG
        '
        Me.chkAUTO_NYUKO_FLAG.AutoSize = True
        Me.chkAUTO_NYUKO_FLAG.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkAUTO_NYUKO_FLAG.Location = New System.Drawing.Point(32, 144)
        Me.chkAUTO_NYUKO_FLAG.Name = "chkAUTO_NYUKO_FLAG"
        Me.chkAUTO_NYUKO_FLAG.Size = New System.Drawing.Size(112, 24)
        Me.chkAUTO_NYUKO_FLAG.TabIndex = 245
        Me.chkAUTO_NYUKO_FLAG.Text = "自動入庫"
        Me.chkAUTO_NYUKO_FLAG.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 46)
        Me.Label1.TabIndex = 246
        Me.Label1.Text = "出庫パレット数"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSYUKO_PALLET_SU
        '
        Me.lblSYUKO_PALLET_SU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSYUKO_PALLET_SU.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSYUKO_PALLET_SU.ForeColor = System.Drawing.Color.Black
        Me.lblSYUKO_PALLET_SU.Location = New System.Drawing.Point(240, 72)
        Me.lblSYUKO_PALLET_SU.Name = "lblSYUKO_PALLET_SU"
        Me.lblSYUKO_PALLET_SU.Size = New System.Drawing.Size(96, 46)
        Me.lblSYUKO_PALLET_SU.TabIndex = 247
        Me.lblSYUKO_PALLET_SU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_305012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(537, 257)
        Me.Controls.Add(Me.lblSYUKO_PALLET_SU)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkAUTO_NYUKO_FLAG)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Name = "FRM_305012"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "棚卸し作業実施確認"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents chkAUTO_NYUKO_FLAG As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSYUKO_PALLET_SU As System.Windows.Forms.Label

End Class
