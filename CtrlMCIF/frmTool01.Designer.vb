<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTool01
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtWriteSend01_02 = New System.Windows.Forms.TextBox
        Me.cmdWrite01 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtWriteSend01_06 = New System.Windows.Forms.TextBox
        Me.txtDelimiter = New System.Windows.Forms.TextBox
        Me.txtWriteSend01_01 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtWriteSend01_03 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdRead01 = New System.Windows.Forms.Button
        Me.txtReadRecv01_04 = New System.Windows.Forms.TextBox
        Me.txtReadSend01_02 = New System.Windows.Forms.TextBox
        Me.txtReadSend01_01 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtReadSend01_04 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtReadSend01_03 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_02)
        Me.GroupBox3.Controls.Add(Me.cmdWrite01)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_06)
        Me.GroupBox3.Controls.Add(Me.txtDelimiter)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_01)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_03)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(305, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(287, 303)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "書込"
        '
        'txtWriteSend01_02
        '
        Me.txtWriteSend01_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_02.Location = New System.Drawing.Point(86, 34)
        Me.txtWriteSend01_02.Name = "txtWriteSend01_02"
        Me.txtWriteSend01_02.Size = New System.Drawing.Size(64, 19)
        Me.txtWriteSend01_02.TabIndex = 50
        Me.txtWriteSend01_02.Text = "1"
        '
        'cmdWrite01
        '
        Me.cmdWrite01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdWrite01.Location = New System.Drawing.Point(198, 15)
        Me.cmdWrite01.Name = "cmdWrite01"
        Me.cmdWrite01.Size = New System.Drawing.Size(82, 34)
        Me.cmdWrite01.TabIndex = 50
        Me.cmdWrite01.Text = "書込"
        Me.cmdWrite01.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 19)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "ACPU監視ﾀｲﾏ"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(142, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 30)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "ﾃﾞﾘﾐﾀなしの場合は、" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "改行区切り"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(78, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(204, 19)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "0～65535のﾃﾞｰﾀを1～256個定義可能"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(156, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 19)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "100～"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 19)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "書込ﾃﾞｰﾀ"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWriteSend01_06
        '
        Me.txtWriteSend01_06.AcceptsReturn = True
        Me.txtWriteSend01_06.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_06.Location = New System.Drawing.Point(10, 97)
        Me.txtWriteSend01_06.Multiline = True
        Me.txtWriteSend01_06.Name = "txtWriteSend01_06"
        Me.txtWriteSend01_06.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtWriteSend01_06.Size = New System.Drawing.Size(256, 164)
        Me.txtWriteSend01_06.TabIndex = 49
        Me.txtWriteSend01_06.Text = "65535"
        '
        'txtDelimiter
        '
        Me.txtDelimiter.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDelimiter.Location = New System.Drawing.Point(72, 263)
        Me.txtDelimiter.Name = "txtDelimiter"
        Me.txtDelimiter.Size = New System.Drawing.Size(64, 19)
        Me.txtDelimiter.TabIndex = 40
        '
        'txtWriteSend01_01
        '
        Me.txtWriteSend01_01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_01.Location = New System.Drawing.Point(86, 15)
        Me.txtWriteSend01_01.Name = "txtWriteSend01_01"
        Me.txtWriteSend01_01.Size = New System.Drawing.Size(64, 19)
        Me.txtWriteSend01_01.TabIndex = 40
        Me.txtWriteSend01_01.Text = "1"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(22, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 19)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "開始番号"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 263)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 19)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "ﾃﾞﾘﾐﾀ"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWriteSend01_03
        '
        Me.txtWriteSend01_03.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_03.Location = New System.Drawing.Point(86, 53)
        Me.txtWriteSend01_03.Name = "txtWriteSend01_03"
        Me.txtWriteSend01_03.Size = New System.Drawing.Size(64, 19)
        Me.txtWriteSend01_03.TabIndex = 37
        Me.txtWriteSend01_03.Text = "100"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 19)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "PC番号"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdRead01)
        Me.GroupBox1.Controls.Add(Me.txtReadRecv01_04)
        Me.GroupBox1.Controls.Add(Me.txtReadSend01_02)
        Me.GroupBox1.Controls.Add(Me.txtReadSend01_01)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtReadSend01_04)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtReadSend01_03)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(287, 303)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "読出要求"
        '
        'cmdRead01
        '
        Me.cmdRead01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdRead01.Location = New System.Drawing.Point(199, 15)
        Me.cmdRead01.Name = "cmdRead01"
        Me.cmdRead01.Size = New System.Drawing.Size(82, 34)
        Me.cmdRead01.TabIndex = 49
        Me.cmdRead01.Text = "読込"
        Me.cmdRead01.UseVisualStyleBackColor = True
        '
        'txtReadRecv01_04
        '
        Me.txtReadRecv01_04.AcceptsReturn = True
        Me.txtReadRecv01_04.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadRecv01_04.Location = New System.Drawing.Point(8, 97)
        Me.txtReadRecv01_04.Multiline = True
        Me.txtReadRecv01_04.Name = "txtReadRecv01_04"
        Me.txtReadRecv01_04.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReadRecv01_04.Size = New System.Drawing.Size(256, 187)
        Me.txtReadRecv01_04.TabIndex = 49
        '
        'txtReadSend01_02
        '
        Me.txtReadSend01_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadSend01_02.Location = New System.Drawing.Point(86, 34)
        Me.txtReadSend01_02.Name = "txtReadSend01_02"
        Me.txtReadSend01_02.Size = New System.Drawing.Size(64, 19)
        Me.txtReadSend01_02.TabIndex = 40
        Me.txtReadSend01_02.Text = "1"
        '
        'txtReadSend01_01
        '
        Me.txtReadSend01_01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadSend01_01.Location = New System.Drawing.Point(86, 15)
        Me.txtReadSend01_01.Name = "txtReadSend01_01"
        Me.txtReadSend01_01.Size = New System.Drawing.Size(64, 19)
        Me.txtReadSend01_01.TabIndex = 40
        Me.txtReadSend01_01.Text = "1"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 19)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "開始番号"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReadSend01_04
        '
        Me.txtReadSend01_04.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadSend01_04.Location = New System.Drawing.Point(86, 72)
        Me.txtReadSend01_04.Name = "txtReadSend01_04"
        Me.txtReadSend01_04.Size = New System.Drawing.Size(64, 19)
        Me.txtReadSend01_04.TabIndex = 41
        Me.txtReadSend01_04.Text = "255"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(156, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "2～33"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(156, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 19)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "1～256"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "個数"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 19)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "ACPU監視ﾀｲﾏ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReadSend01_03
        '
        Me.txtReadSend01_03.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadSend01_03.Location = New System.Drawing.Point(86, 53)
        Me.txtReadSend01_03.Name = "txtReadSend01_03"
        Me.txtReadSend01_03.Size = New System.Drawing.Size(64, 19)
        Me.txtReadSend01_03.TabIndex = 37
        Me.txtReadSend01_03.Text = "2"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 19)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "PC番号"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmTool01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 324)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmTool01"
        Me.Text = "Melsecﾂｰﾙ01"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_06 As System.Windows.Forms.TextBox
    Friend WithEvents txtWriteSend01_01 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_03 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReadRecv01_04 As System.Windows.Forms.TextBox
    Friend WithEvents txtReadSend01_01 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReadSend01_04 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReadSend01_03 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdRead01 As System.Windows.Forms.Button
    Friend WithEvents cmdWrite01 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDelimiter As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtReadSend01_02 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_02 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
