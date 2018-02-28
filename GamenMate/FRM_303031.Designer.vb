<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303031
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
        Me.lblIN_ST = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.cboXKENPIN_KUBUN = New MateCommon.cmpMComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdKurakaeSet = New System.Windows.Forms.Button
        Me.cboFIN_KUBUN = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblIN_ST
        '
        Me.lblIN_ST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIN_ST.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblIN_ST.ForeColor = System.Drawing.Color.Black
        Me.lblIN_ST.Location = New System.Drawing.Point(205, 10)
        Me.lblIN_ST.Name = "lblIN_ST"
        Me.lblIN_ST.Size = New System.Drawing.Size(440, 32)
        Me.lblIN_ST.TabIndex = 0
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
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "入庫ST:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(34, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 32)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "品名:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(205, 60)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 1
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboXKENPIN_KUBUN
        '
        Me.cboXKENPIN_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXKENPIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXKENPIN_KUBUN.FormattingEnabled = True
        Me.cboXKENPIN_KUBUN.IntegralHeight = False
        Me.cboXKENPIN_KUBUN.Location = New System.Drawing.Point(205, 157)
        Me.cboXKENPIN_KUBUN.Name = "cboXKENPIN_KUBUN"
        Me.cboXKENPIN_KUBUN.Size = New System.Drawing.Size(263, 28)
        Me.cboXKENPIN_KUBUN.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(34, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 32)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "検品区分:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(466, 215)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdKurakaeSet
        '
        Me.cmdKurakaeSet.BackColor = System.Drawing.Color.DarkGray
        Me.cmdKurakaeSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKurakaeSet.ForeColor = System.Drawing.Color.Black
        Me.cmdKurakaeSet.Location = New System.Drawing.Point(20, 215)
        Me.cmdKurakaeSet.Name = "cmdKurakaeSet"
        Me.cmdKurakaeSet.Size = New System.Drawing.Size(187, 40)
        Me.cmdKurakaeSet.TabIndex = 10
        Me.cmdKurakaeSet.Text = "倉替設定"
        Me.cmdKurakaeSet.UseVisualStyleBackColor = False
        '
        'cboFIN_KUBUN
        '
        Me.cboFIN_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFIN_KUBUN.FormattingEnabled = True
        Me.cboFIN_KUBUN.IntegralHeight = False
        Me.cboFIN_KUBUN.Location = New System.Drawing.Point(205, 110)
        Me.cboFIN_KUBUN.Name = "cboFIN_KUBUN"
        Me.cboFIN_KUBUN.Size = New System.Drawing.Size(263, 28)
        Me.cboFIN_KUBUN.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(34, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 32)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "入庫区分:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_303031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(676, 271)
        Me.Controls.Add(Me.cboFIN_KUBUN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdKurakaeSet)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cboXKENPIN_KUBUN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblIN_ST)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Name = "FRM_303031"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "倉替設定"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblIN_ST As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents cboXKENPIN_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdKurakaeSet As System.Windows.Forms.Button
    Friend WithEvents cboFIN_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
