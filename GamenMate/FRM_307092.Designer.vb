<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307092
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
        Me.cboXMAINTE_KUBUN = New MateCommon.cmpMComboBox
        Me.lblMsg = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cboXMAINTE_KUBUN
        '
        Me.cboXMAINTE_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXMAINTE_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboXMAINTE_KUBUN.FormattingEnabled = True
        Me.cboXMAINTE_KUBUN.Location = New System.Drawing.Point(103, 82)
        Me.cboXMAINTE_KUBUN.Name = "cboXMAINTE_KUBUN"
        Me.cboXMAINTE_KUBUN.Size = New System.Drawing.Size(344, 27)
        Me.cboXMAINTE_KUBUN.TabIndex = 1
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblMsg.ForeColor = System.Drawing.Color.Black
        Me.lblMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMsg.Location = New System.Drawing.Point(31, 6)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(480, 64)
        Me.lblMsg.TabIndex = 271
        Me.lblMsg.Text = "ステーションを選択して下さい"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(23, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 32)
        Me.Label9.TabIndex = 270
        Me.Label9.Text = "ST:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(279, 142)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkGray
        Me.cmdOK.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.Black
        Me.cmdOK.Location = New System.Drawing.Point(23, 142)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(216, 40)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "ＯＫ"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'FRM_307092
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(534, 195)
        Me.Controls.Add(Me.cboXMAINTE_KUBUN)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Name = "FRM_307092"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ST選択"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboXMAINTE_KUBUN As MateCommon.cmpMComboBox
    Public WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button

End Class
