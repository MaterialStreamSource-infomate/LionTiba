<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_100201
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblMsg = New System.Windows.Forms.Label
        Me.cboFREASON_CD = New MateCommon.cmpMComboBox
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(288, 136)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(32, 136)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 11
        Me.cmdZikkou.Text = "ＯＫ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(32, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 32)
        Me.Label9.TabIndex = 264
        Me.Label9.Text = "理由:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblMsg.ForeColor = System.Drawing.Color.Black
        Me.lblMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMsg.Location = New System.Drawing.Point(40, 0)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(480, 64)
        Me.lblMsg.TabIndex = 266
        Me.lblMsg.Text = "XXXXXXXXXXXXXXX"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFREASON_CD
        '
        Me.cboFREASON_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFREASON_CD.FormattingEnabled = True
        Me.cboFREASON_CD.Location = New System.Drawing.Point(112, 76)
        Me.cboFREASON_CD.Name = "cboFREASON_CD"
        Me.cboFREASON_CD.Size = New System.Drawing.Size(344, 27)
        Me.cboFREASON_CD.TabIndex = 10
        '
        'FRM_100201
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(534, 195)
        Me.Controls.Add(Me.cboFREASON_CD)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Name = "FRM_100201"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "確認"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents cboFREASON_CD As MateCommon.cmpMComboBox

End Class
