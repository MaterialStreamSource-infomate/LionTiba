<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308012
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
        Me.lblXHORYU_REASON = New System.Windows.Forms.Label
        Me.cboXBERTH_SITEI = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblXCAR_NO_WARITUKE = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(288, 192)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(32, 192)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 5
        Me.cmdZikkou.Text = "ＯＫ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'lblXHORYU_REASON
        '
        Me.lblXHORYU_REASON.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXHORYU_REASON.ForeColor = System.Drawing.Color.Black
        Me.lblXHORYU_REASON.Location = New System.Drawing.Point(32, 16)
        Me.lblXHORYU_REASON.Name = "lblXHORYU_REASON"
        Me.lblXHORYU_REASON.Size = New System.Drawing.Size(304, 56)
        Me.lblXHORYU_REASON.TabIndex = 0
        Me.lblXHORYU_REASON.Text = "バースを選択して下さい"
        Me.lblXHORYU_REASON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboXBERTH_SITEI
        '
        Me.cboXBERTH_SITEI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXBERTH_SITEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXBERTH_SITEI.FormattingEnabled = True
        Me.cboXBERTH_SITEI.IntegralHeight = False
        Me.cboXBERTH_SITEI.Location = New System.Drawing.Point(160, 136)
        Me.cboXBERTH_SITEI.Name = "cboXBERTH_SITEI"
        Me.cboXBERTH_SITEI.Size = New System.Drawing.Size(192, 28)
        Me.cboXBERTH_SITEI.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(40, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "バース:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(48, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 32)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "受付車番:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXCAR_NO_WARITUKE
        '
        Me.lblXCAR_NO_WARITUKE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXCAR_NO_WARITUKE.ForeColor = System.Drawing.Color.Black
        Me.lblXCAR_NO_WARITUKE.Location = New System.Drawing.Point(160, 88)
        Me.lblXCAR_NO_WARITUKE.Name = "lblXCAR_NO_WARITUKE"
        Me.lblXCAR_NO_WARITUKE.Size = New System.Drawing.Size(88, 32)
        Me.lblXCAR_NO_WARITUKE.TabIndex = 2
        Me.lblXCAR_NO_WARITUKE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_308012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(535, 243)
        Me.Controls.Add(Me.lblXCAR_NO_WARITUKE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboXBERTH_SITEI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblXHORYU_REASON)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Name = "FRM_308012"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "バース指定"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents lblXHORYU_REASON As System.Windows.Forms.Label
    Friend WithEvents cboXBERTH_SITEI As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblXCAR_NO_WARITUKE As System.Windows.Forms.Label

End Class
