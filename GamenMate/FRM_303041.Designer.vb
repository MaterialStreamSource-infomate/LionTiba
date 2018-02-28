<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303041
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
        Me.cmdKurakaeSet = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblIN_ST = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboFTRK_BUF_NO_Kurakae = New MateCommon.cmpMComboBox
        Me.SuspendLayout()
        '
        'cmdKurakaeSet
        '
        Me.cmdKurakaeSet.BackColor = System.Drawing.Color.DarkGray
        Me.cmdKurakaeSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKurakaeSet.ForeColor = System.Drawing.Color.Black
        Me.cmdKurakaeSet.Location = New System.Drawing.Point(20, 120)
        Me.cmdKurakaeSet.Name = "cmdKurakaeSet"
        Me.cmdKurakaeSet.Size = New System.Drawing.Size(187, 40)
        Me.cmdKurakaeSet.TabIndex = 10
        Me.cmdKurakaeSet.Text = "倉替設定"
        Me.cmdKurakaeSet.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(466, 120)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lblIN_ST
        '
        Me.lblIN_ST.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblIN_ST.ForeColor = System.Drawing.Color.Black
        Me.lblIN_ST.Location = New System.Drawing.Point(205, 10)
        Me.lblIN_ST.Name = "lblIN_ST"
        Me.lblIN_ST.Size = New System.Drawing.Size(440, 32)
        Me.lblIN_ST.TabIndex = 39
        Me.lblIN_ST.Text = "ST名"
        Me.lblIN_ST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(34, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 32)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "出庫ST:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(34, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 32)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "倉替先:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFTRK_BUF_NO_Kurakae
        '
        Me.cboFTRK_BUF_NO_Kurakae.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO_Kurakae.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO_Kurakae.FormattingEnabled = True
        Me.cboFTRK_BUF_NO_Kurakae.IntegralHeight = False
        Me.cboFTRK_BUF_NO_Kurakae.Location = New System.Drawing.Point(205, 63)
        Me.cboFTRK_BUF_NO_Kurakae.Name = "cboFTRK_BUF_NO_Kurakae"
        Me.cboFTRK_BUF_NO_Kurakae.Size = New System.Drawing.Size(263, 28)
        Me.cboFTRK_BUF_NO_Kurakae.TabIndex = 0
        '
        'FRM_303041
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(676, 179)
        Me.Controls.Add(Me.cboFTRK_BUF_NO_Kurakae)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdKurakaeSet)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblIN_ST)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FRM_303041"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "倉替設定"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdKurakaeSet As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblIN_ST As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFTRK_BUF_NO_Kurakae As MateCommon.cmpMComboBox

End Class
