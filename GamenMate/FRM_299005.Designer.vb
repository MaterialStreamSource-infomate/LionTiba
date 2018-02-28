<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_299005
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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
        Me.cmd001 = New System.Windows.Forms.Button
        Me.cmd002 = New System.Windows.Forms.Button
        Me.cmd003 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtReadFile01 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblProgress = New System.Windows.Forms.Label
        Me.txtReadFile02 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmd004 = New System.Windows.Forms.Button
        Me.cmd005 = New System.Windows.Forms.Button
        Me.txtFRAC_RETU = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtTest = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'cmd001
        '
        Me.cmd001.BackColor = System.Drawing.Color.DarkGray
        Me.cmd001.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmd001.ForeColor = System.Drawing.Color.Black
        Me.cmd001.Location = New System.Drawing.Point(16, 16)
        Me.cmd001.Name = "cmd001"
        Me.cmd001.Size = New System.Drawing.Size(392, 40)
        Me.cmd001.TabIndex = 0
        Me.cmd001.Text = "全在庫削除"
        Me.cmd001.UseVisualStyleBackColor = False
        '
        'cmd002
        '
        Me.cmd002.BackColor = System.Drawing.Color.DarkGray
        Me.cmd002.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmd002.ForeColor = System.Drawing.Color.Black
        Me.cmd002.Location = New System.Drawing.Point(16, 224)
        Me.cmd002.Name = "cmd002"
        Me.cmd002.Size = New System.Drawing.Size(392, 40)
        Me.cmd002.TabIndex = 2
        Me.cmd002.Text = "在庫移行前ﾁｪｯｸ"
        Me.cmd002.UseVisualStyleBackColor = False
        '
        'cmd003
        '
        Me.cmd003.BackColor = System.Drawing.Color.DarkGray
        Me.cmd003.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmd003.ForeColor = System.Drawing.Color.Black
        Me.cmd003.Location = New System.Drawing.Point(16, 272)
        Me.cmd003.Name = "cmd003"
        Me.cmd003.Size = New System.Drawing.Size(392, 40)
        Me.cmd003.TabIndex = 3
        Me.cmd003.Text = "在庫移行"
        Me.cmd003.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 328)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "読込ﾌｧｲﾙ01"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReadFile01
        '
        Me.txtReadFile01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadFile01.Location = New System.Drawing.Point(104, 328)
        Me.txtReadFile01.Name = "txtReadFile01"
        Me.txtReadFile01.Size = New System.Drawing.Size(296, 19)
        Me.txtReadFile01.TabIndex = 5
        Me.txtReadFile01.Text = "C:\zaiko\zaiko.txt"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 472)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 40)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "進捗"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProgress
        '
        Me.lblProgress.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblProgress.Location = New System.Drawing.Point(112, 472)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(288, 40)
        Me.lblProgress.TabIndex = 9
        Me.lblProgress.Text = "/"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtReadFile02
        '
        Me.txtReadFile02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadFile02.Location = New System.Drawing.Point(104, 424)
        Me.txtReadFile02.Name = "txtReadFile02"
        Me.txtReadFile02.Size = New System.Drawing.Size(296, 19)
        Me.txtReadFile02.TabIndex = 12
        Me.txtReadFile02.Text = "C:\Users\005\Documents\Ship.csv"
        Me.txtReadFile02.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 424)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "読込ﾌｧｲﾙ02"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Visible = False
        '
        'cmd004
        '
        Me.cmd004.BackColor = System.Drawing.Color.DarkGray
        Me.cmd004.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmd004.ForeColor = System.Drawing.Color.Black
        Me.cmd004.Location = New System.Drawing.Point(16, 368)
        Me.cmd004.Name = "cmd004"
        Me.cmd004.Size = New System.Drawing.Size(392, 40)
        Me.cmd004.TabIndex = 10
        Me.cmd004.Text = "SHIP在庫ﾃﾞｰﾀ更新"
        Me.cmd004.UseVisualStyleBackColor = False
        Me.cmd004.Visible = False
        '
        'cmd005
        '
        Me.cmd005.BackColor = System.Drawing.Color.DarkGray
        Me.cmd005.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmd005.ForeColor = System.Drawing.Color.Black
        Me.cmd005.Location = New System.Drawing.Point(16, 102)
        Me.cmd005.Name = "cmd005"
        Me.cmd005.Size = New System.Drawing.Size(392, 40)
        Me.cmd005.TabIndex = 13
        Me.cmd005.Text = "指定列　在庫削除"
        Me.cmd005.UseVisualStyleBackColor = False
        '
        'txtFRAC_RETU
        '
        Me.txtFRAC_RETU.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtFRAC_RETU.Location = New System.Drawing.Point(104, 157)
        Me.txtFRAC_RETU.Name = "txtFRAC_RETU"
        Me.txtFRAC_RETU.Size = New System.Drawing.Size(296, 19)
        Me.txtFRAC_RETU.TabIndex = 14
        Me.txtFRAC_RETU.Text = "27,28"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "列"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkGray
        Me.Button1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(16, 368)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(392, 40)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "test"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtTest
        '
        Me.txtTest.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTest.Location = New System.Drawing.Point(104, 423)
        Me.txtTest.Name = "txtTest"
        Me.txtTest.Size = New System.Drawing.Size(296, 19)
        Me.txtTest.TabIndex = 17
        Me.txtTest.Text = "10000"
        '
        'FRM_299005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 531)
        Me.Controls.Add(Me.txtTest)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFRAC_RETU)
        Me.Controls.Add(Me.cmd005)
        Me.Controls.Add(Me.txtReadFile02)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmd004)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtReadFile01)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmd003)
        Me.Controls.Add(Me.cmd001)
        Me.Controls.Add(Me.cmd002)
        Me.Name = "FRM_299005"
        Me.Text = "FRM_299005"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd001 As System.Windows.Forms.Button
    Friend WithEvents cmd002 As System.Windows.Forms.Button
    Friend WithEvents cmd003 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReadFile01 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents txtReadFile02 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmd004 As System.Windows.Forms.Button
    Friend WithEvents cmd005 As System.Windows.Forms.Button
    Friend WithEvents txtFRAC_RETU As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtTest As System.Windows.Forms.TextBox
End Class
