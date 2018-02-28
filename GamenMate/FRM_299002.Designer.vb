<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_299002
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
        Me.grdSockData = New System.Windows.Forms.DataGridView
        Me.cboCommandID = New System.Windows.Forms.ComboBox
        Me.cmdDisp = New System.Windows.Forms.Button
        Me.cboFile = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdSockHeader = New System.Windows.Forms.DataGridView
        Me.cmdSendFormatSock = New System.Windows.Forms.Button
        Me.grdSockConfig = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSendText = New System.Windows.Forms.TextBox
        Me.txtASCII = New System.Windows.Forms.TextBox
        Me.cmdASCII = New System.Windows.Forms.Button
        CType(Me.grdSockData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSockHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSockConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdSockData
        '
        Me.grdSockData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSockData.Location = New System.Drawing.Point(8, 136)
        Me.grdSockData.Name = "grdSockData"
        Me.grdSockData.RowTemplate.Height = 21
        Me.grdSockData.Size = New System.Drawing.Size(304, 368)
        Me.grdSockData.TabIndex = 0
        '
        'cboCommandID
        '
        Me.cboCommandID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommandID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.cboCommandID.FormattingEnabled = True
        Me.cboCommandID.Location = New System.Drawing.Point(128, 48)
        Me.cboCommandID.MaxDropDownItems = 20
        Me.cboCommandID.Name = "cboCommandID"
        Me.cboCommandID.Size = New System.Drawing.Size(280, 27)
        Me.cboCommandID.TabIndex = 1
        '
        'cmdDisp
        '
        Me.cmdDisp.BackColor = System.Drawing.Color.DarkGray
        Me.cmdDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdDisp.ForeColor = System.Drawing.Color.Black
        Me.cmdDisp.Location = New System.Drawing.Point(424, 40)
        Me.cmdDisp.Name = "cmdDisp"
        Me.cmdDisp.Size = New System.Drawing.Size(104, 40)
        Me.cmdDisp.TabIndex = 34
        Me.cmdDisp.Text = "表示"
        Me.cmdDisp.UseVisualStyleBackColor = False
        '
        'cboFile
        '
        Me.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFile.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.cboFile.FormattingEnabled = True
        Me.cboFile.Location = New System.Drawing.Point(128, 8)
        Me.cboFile.MaxDropDownItems = 20
        Me.cboFile.Name = "cboFile"
        Me.cboFile.Size = New System.Drawing.Size(280, 27)
        Me.cboFile.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 32)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "読込ﾌｧｲﾙ:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 32)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "ｺﾏﾝﾄﾞ選択:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdSockHeader
        '
        Me.grdSockHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSockHeader.Location = New System.Drawing.Point(320, 136)
        Me.grdSockHeader.Name = "grdSockHeader"
        Me.grdSockHeader.RowTemplate.Height = 21
        Me.grdSockHeader.Size = New System.Drawing.Size(304, 368)
        Me.grdSockHeader.TabIndex = 53
        '
        'cmdSendFormatSock
        '
        Me.cmdSendFormatSock.BackColor = System.Drawing.Color.DarkGray
        Me.cmdSendFormatSock.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdSendFormatSock.ForeColor = System.Drawing.Color.Black
        Me.cmdSendFormatSock.Location = New System.Drawing.Point(424, 88)
        Me.cmdSendFormatSock.Name = "cmdSendFormatSock"
        Me.cmdSendFormatSock.Size = New System.Drawing.Size(104, 40)
        Me.cmdSendFormatSock.TabIndex = 34
        Me.cmdSendFormatSock.Text = "送信"
        Me.cmdSendFormatSock.UseVisualStyleBackColor = False
        '
        'grdSockConfig
        '
        Me.grdSockConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSockConfig.Location = New System.Drawing.Point(632, 136)
        Me.grdSockConfig.Name = "grdSockConfig"
        Me.grdSockConfig.RowTemplate.Height = 21
        Me.grdSockConfig.Size = New System.Drawing.Size(224, 368)
        Me.grdSockConfig.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 32)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "送信ﾃｷｽﾄ:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSendText
        '
        Me.txtSendText.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtSendText.Location = New System.Drawing.Point(128, 96)
        Me.txtSendText.Name = "txtSendText"
        Me.txtSendText.Size = New System.Drawing.Size(280, 26)
        Me.txtSendText.TabIndex = 55
        '
        'txtASCII
        '
        Me.txtASCII.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtASCII.Location = New System.Drawing.Point(616, 96)
        Me.txtASCII.MaxLength = 3
        Me.txtASCII.Name = "txtASCII"
        Me.txtASCII.Size = New System.Drawing.Size(64, 26)
        Me.txtASCII.TabIndex = 55
        '
        'cmdASCII
        '
        Me.cmdASCII.BackColor = System.Drawing.Color.DarkGray
        Me.cmdASCII.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdASCII.ForeColor = System.Drawing.Color.Black
        Me.cmdASCII.Location = New System.Drawing.Point(688, 88)
        Me.cmdASCII.Name = "cmdASCII"
        Me.cmdASCII.Size = New System.Drawing.Size(104, 40)
        Me.cmdASCII.TabIndex = 34
        Me.cmdASCII.Text = "ASCII追加"
        Me.cmdASCII.UseVisualStyleBackColor = False
        '
        'FRM_299002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 518)
        Me.Controls.Add(Me.txtASCII)
        Me.Controls.Add(Me.txtSendText)
        Me.Controls.Add(Me.grdSockConfig)
        Me.Controls.Add(Me.grdSockHeader)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboFile)
        Me.Controls.Add(Me.cmdASCII)
        Me.Controls.Add(Me.cmdSendFormatSock)
        Me.Controls.Add(Me.cmdDisp)
        Me.Controls.Add(Me.cboCommandID)
        Me.Controls.Add(Me.grdSockData)
        Me.Name = "FRM_299002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ｿｹｯﾄ送信ﾂｰﾙ"
        CType(Me.grdSockData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSockHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSockConfig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdSockData As System.Windows.Forms.DataGridView
    Friend WithEvents cboCommandID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDisp As System.Windows.Forms.Button
    Friend WithEvents cboFile As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdSockHeader As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSendFormatSock As System.Windows.Forms.Button
    Friend WithEvents grdSockConfig As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSendText As System.Windows.Forms.TextBox
    Friend WithEvents txtASCII As System.Windows.Forms.TextBox
    Friend WithEvents cmdASCII As System.Windows.Forms.Button
End Class
