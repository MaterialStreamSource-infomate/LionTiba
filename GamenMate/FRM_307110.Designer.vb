<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307110
    Inherits GamenMate.FRM_000002

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpNIPPO_D = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboMONTH = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboYEAR = New MateCommon.cmpMComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(813, 615)
        Me.cmdF7.TabIndex = 6
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(813, 423)
        Me.cmdF6.TabIndex = 4
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(274, 214)
        Me.cmdF2.Size = New System.Drawing.Size(278, 74)
        Me.cmdF2.TabIndex = 2
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(274, 104)
        Me.cmdF1.Size = New System.Drawing.Size(278, 74)
        Me.cmdF1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpNIPPO_D)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(274, 318)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(533, 148)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "日報"
        '
        'dtpNIPPO_D
        '
        Me.dtpNIPPO_D.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpNIPPO_D.Location = New System.Drawing.Point(147, 52)
        Me.dtpNIPPO_D.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpNIPPO_D.Name = "dtpNIPPO_D"
        Me.dtpNIPPO_D.Size = New System.Drawing.Size(168, 32)
        Me.dtpNIPPO_D.TabIndex = 0
        Me.dtpNIPPO_D.TimeComboDisp = False
        Me.dtpNIPPO_D.userChecked = True
        Me.dtpNIPPO_D.userShowCheckBox = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "日付:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboMONTH)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboYEAR)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(274, 510)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(533, 148)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "月報"
        '
        'cboMONTH
        '
        Me.cboMONTH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMONTH.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboMONTH.FormattingEnabled = True
        Me.cboMONTH.IntegralHeight = False
        Me.cboMONTH.Location = New System.Drawing.Point(386, 51)
        Me.cboMONTH.Name = "cboMONTH"
        Me.cboMONTH.Size = New System.Drawing.Size(92, 28)
        Me.cboMONTH.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(245, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 32)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "月:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboYEAR
        '
        Me.cboYEAR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYEAR.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboYEAR.FormattingEnabled = True
        Me.cboYEAR.IntegralHeight = False
        Me.cboYEAR.Location = New System.Drawing.Point(147, 51)
        Me.cboYEAR.Name = "cboYEAR"
        Me.cboYEAR.Size = New System.Drawing.Size(92, 28)
        Me.cboYEAR.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "年:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_307110
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_307110"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpNIPPO_D As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboYEAR As MateCommon.cmpMComboBox
    Friend WithEvents cboMONTH As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
