<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303012
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
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.lblFHINMEI_CD = New System.Windows.Forms.Label
        Me.cmdIN_Start = New System.Windows.Forms.Button
        Me.cmdIN_End = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblIN_ST
        '
        Me.lblIN_ST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIN_ST.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblIN_ST.ForeColor = System.Drawing.Color.Black
        Me.lblIN_ST.Location = New System.Drawing.Point(182, 14)
        Me.lblIN_ST.Name = "lblIN_ST"
        Me.lblIN_ST.Size = New System.Drawing.Size(440, 32)
        Me.lblIN_ST.TabIndex = 31
        Me.lblIN_ST.Text = "ST名"
        Me.lblIN_ST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 32)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "入庫ST:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 32)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "品名:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(11, 68)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 32)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "品名ｺｰﾄﾞ/記号:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(182, 118)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 32
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFHINMEI_CD
        '
        Me.lblFHINMEI_CD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI_CD.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI_CD.Location = New System.Drawing.Point(182, 68)
        Me.lblFHINMEI_CD.Name = "lblFHINMEI_CD"
        Me.lblFHINMEI_CD.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI_CD.TabIndex = 35
        Me.lblFHINMEI_CD.Text = "品名記号"
        Me.lblFHINMEI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdIN_Start
        '
        Me.cmdIN_Start.BackColor = System.Drawing.Color.DarkGray
        Me.cmdIN_Start.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIN_Start.ForeColor = System.Drawing.Color.Black
        Me.cmdIN_Start.Location = New System.Drawing.Point(37, 188)
        Me.cmdIN_Start.Name = "cmdIN_Start"
        Me.cmdIN_Start.Size = New System.Drawing.Size(187, 40)
        Me.cmdIN_Start.TabIndex = 36
        Me.cmdIN_Start.Text = "連続入庫開始"
        Me.cmdIN_Start.UseVisualStyleBackColor = False
        '
        'cmdIN_End
        '
        Me.cmdIN_End.BackColor = System.Drawing.Color.DarkGray
        Me.cmdIN_End.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIN_End.ForeColor = System.Drawing.Color.Black
        Me.cmdIN_End.Location = New System.Drawing.Point(286, 188)
        Me.cmdIN_End.Name = "cmdIN_End"
        Me.cmdIN_End.Size = New System.Drawing.Size(187, 40)
        Me.cmdIN_End.TabIndex = 37
        Me.cmdIN_End.Text = "連続入庫終了"
        Me.cmdIN_End.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(538, 188)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdCancel.TabIndex = 38
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'FRM_303012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(759, 251)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdIN_End)
        Me.Controls.Add(Me.cmdIN_Start)
        Me.Controls.Add(Me.lblFHINMEI_CD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Controls.Add(Me.lblIN_ST)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FRM_303012"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "連続入庫開始/終了設定"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblIN_ST As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI_CD As System.Windows.Forms.Label
    Friend WithEvents cmdIN_Start As System.Windows.Forms.Button
    Friend WithEvents cmdIN_End As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button

End Class
