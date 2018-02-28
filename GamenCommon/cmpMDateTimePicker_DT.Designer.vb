<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cmpMDateTimePicker_DT
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblMsk = New System.Windows.Forms.Label
        Me.cmpMDateTimePicker_T = New GamenCommon.cmpMDateTimePicker
        Me.cmpMDateTimePicker_D = New GamenCommon.cmpMDateTimePicker
        Me.SuspendLayout()
        '
        'lblMsk
        '
        Me.lblMsk.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblMsk.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblMsk.Location = New System.Drawing.Point(25, 4)
        Me.lblMsk.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMsk.Name = "lblMsk"
        Me.lblMsk.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.lblMsk.Size = New System.Drawing.Size(126, 23)
        Me.lblMsk.TabIndex = 2
        Me.lblMsk.Text = "2011/10/13"
        Me.lblMsk.Visible = False
        '
        'cmpMDateTimePicker_T
        '
        Me.cmpMDateTimePicker_T.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cmpMDateTimePicker_T.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmpMDateTimePicker_T.Location = New System.Drawing.Point(175, 2)
        Me.cmpMDateTimePicker_T.Name = "cmpMDateTimePicker_T"
        Me.cmpMDateTimePicker_T.ShowUpDown = True
        Me.cmpMDateTimePicker_T.Size = New System.Drawing.Size(118, 27)
        Me.cmpMDateTimePicker_T.TabIndex = 1
        '
        'cmpMDateTimePicker_D
        '
        Me.cmpMDateTimePicker_D.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cmpMDateTimePicker_D.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmpMDateTimePicker_D.Location = New System.Drawing.Point(3, 2)
        Me.cmpMDateTimePicker_D.Name = "cmpMDateTimePicker_D"
        Me.cmpMDateTimePicker_D.ShowCheckBox = True
        Me.cmpMDateTimePicker_D.Size = New System.Drawing.Size(166, 27)
        Me.cmpMDateTimePicker_D.TabIndex = 0
        '
        'cmpMDateTimePicker_DT
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lblMsk)
        Me.Controls.Add(Me.cmpMDateTimePicker_T)
        Me.Controls.Add(Me.cmpMDateTimePicker_D)
        Me.Name = "cmpMDateTimePicker_DT"
        Me.Size = New System.Drawing.Size(294, 30)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMsk As System.Windows.Forms.Label
    Public WithEvents cmpMDateTimePicker_D As GamenCommon.cmpMDateTimePicker
    Public WithEvents cmpMDateTimePicker_T As GamenCommon.cmpMDateTimePicker

End Class
