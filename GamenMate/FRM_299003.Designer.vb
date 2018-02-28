<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_299003
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpKikanToTime = New System.Windows.Forms.DateTimePicker
        Me.dtpKikanToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpKikanFromTime = New System.Windows.Forms.DateTimePicker
        Me.dtpKikanFromDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboTO = New System.Windows.Forms.ComboBox
        Me.cboFROM = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFINOUT_STS = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPallet_ID = New System.Windows.Forms.TextBox
        Me.grdList = New System.Windows.Forms.DataGridView
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdDisp = New System.Windows.Forms.Button
        Me.cmdPalletID = New System.Windows.Forms.Button
        Me.chckLstColDsp = New System.Windows.Forms.CheckedListBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(360, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 24)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "～"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpKikanToTime
        '
        Me.dtpKikanToTime.CalendarFont = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtpKikanToTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtpKikanToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpKikanToTime.Location = New System.Drawing.Point(528, 24)
        Me.dtpKikanToTime.Name = "dtpKikanToTime"
        Me.dtpKikanToTime.ShowUpDown = True
        Me.dtpKikanToTime.Size = New System.Drawing.Size(104, 23)
        Me.dtpKikanToTime.TabIndex = 63
        '
        'dtpKikanToDate
        '
        Me.dtpKikanToDate.CalendarFont = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtpKikanToDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtpKikanToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpKikanToDate.Location = New System.Drawing.Point(392, 24)
        Me.dtpKikanToDate.Name = "dtpKikanToDate"
        Me.dtpKikanToDate.Size = New System.Drawing.Size(128, 23)
        Me.dtpKikanToDate.TabIndex = 62
        '
        'dtpKikanFromTime
        '
        Me.dtpKikanFromTime.CalendarFont = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtpKikanFromTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtpKikanFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpKikanFromTime.Location = New System.Drawing.Point(256, 24)
        Me.dtpKikanFromTime.Name = "dtpKikanFromTime"
        Me.dtpKikanFromTime.ShowUpDown = True
        Me.dtpKikanFromTime.Size = New System.Drawing.Size(104, 23)
        Me.dtpKikanFromTime.TabIndex = 61
        '
        'dtpKikanFromDate
        '
        Me.dtpKikanFromDate.CalendarFont = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtpKikanFromDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtpKikanFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpKikanFromDate.Location = New System.Drawing.Point(120, 24)
        Me.dtpKikanFromDate.Name = "dtpKikanFromDate"
        Me.dtpKikanFromDate.Size = New System.Drawing.Size(128, 23)
        Me.dtpKikanFromDate.TabIndex = 60
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "発生日時:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(32, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 24)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "入出庫実績"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.chckLstColDsp)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboTO)
        Me.GroupBox1.Controls.Add(Me.cboFROM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboFINOUT_STS)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtPallet_ID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpKikanFromDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpKikanFromTime)
        Me.GroupBox1.Controls.Add(Me.dtpKikanToTime)
        Me.GroupBox1.Controls.Add(Me.dtpKikanToDate)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1000, 128)
        Me.GroupBox1.TabIndex = 66
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(328, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 24)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "TO ST:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 24)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "FROM ST:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTO
        '
        Me.cboTO.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboTO.FormattingEnabled = True
        Me.cboTO.Location = New System.Drawing.Point(440, 88)
        Me.cboTO.MaxDropDownItems = 10
        Me.cboTO.Name = "cboTO"
        Me.cboTO.Size = New System.Drawing.Size(200, 24)
        Me.cboTO.TabIndex = 72
        '
        'cboFROM
        '
        Me.cboFROM.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFROM.FormattingEnabled = True
        Me.cboFROM.Location = New System.Drawing.Point(120, 88)
        Me.cboFROM.MaxDropDownItems = 10
        Me.cboFROM.Name = "cboFROM"
        Me.cboFROM.Size = New System.Drawing.Size(200, 24)
        Me.cboFROM.TabIndex = 71
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(352, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "動作:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFINOUT_STS
        '
        Me.cboFINOUT_STS.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFINOUT_STS.FormattingEnabled = True
        Me.cboFINOUT_STS.Location = New System.Drawing.Point(440, 56)
        Me.cboFINOUT_STS.MaxDropDownItems = 10
        Me.cboFINOUT_STS.Name = "cboFINOUT_STS"
        Me.cboFINOUT_STS.Size = New System.Drawing.Size(144, 24)
        Me.cboFINOUT_STS.TabIndex = 69
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 24)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "パレットID:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPallet_ID
        '
        Me.txtPallet_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPallet_ID.Location = New System.Drawing.Point(120, 56)
        Me.txtPallet_ID.MaxLength = 16
        Me.txtPallet_ID.Name = "txtPallet_ID"
        Me.txtPallet_ID.Size = New System.Drawing.Size(200, 23)
        Me.txtPallet_ID.TabIndex = 67
        Me.txtPallet_ID.Text = "XXXXXXXXXXXXXXXX"
        '
        'grdList
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdList.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdList.Location = New System.Drawing.Point(8, 168)
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1000, 392)
        Me.grdList.TabIndex = 67
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.DarkGray
        Me.cmdClose.Enabled = False
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdClose.ForeColor = System.Drawing.Color.Black
        Me.cmdClose.Location = New System.Drawing.Point(904, 568)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(104, 40)
        Me.cmdClose.TabIndex = 69
        Me.cmdClose.Text = "閉じる"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdDisp
        '
        Me.cmdDisp.BackColor = System.Drawing.Color.DarkGray
        Me.cmdDisp.Enabled = False
        Me.cmdDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdDisp.ForeColor = System.Drawing.Color.Black
        Me.cmdDisp.Location = New System.Drawing.Point(664, 568)
        Me.cmdDisp.Name = "cmdDisp"
        Me.cmdDisp.Size = New System.Drawing.Size(104, 40)
        Me.cmdDisp.TabIndex = 68
        Me.cmdDisp.Text = "表示"
        Me.cmdDisp.UseVisualStyleBackColor = False
        '
        'cmdPalletID
        '
        Me.cmdPalletID.BackColor = System.Drawing.Color.DarkGray
        Me.cmdPalletID.Enabled = False
        Me.cmdPalletID.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdPalletID.ForeColor = System.Drawing.Color.Black
        Me.cmdPalletID.Location = New System.Drawing.Point(784, 568)
        Me.cmdPalletID.Name = "cmdPalletID"
        Me.cmdPalletID.Size = New System.Drawing.Size(104, 40)
        Me.cmdPalletID.TabIndex = 70
        Me.cmdPalletID.Text = "パレットID"
        Me.cmdPalletID.UseVisualStyleBackColor = False
        '
        'chckLstColDsp
        '
        Me.chckLstColDsp.CheckOnClick = True
        Me.chckLstColDsp.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chckLstColDsp.FormattingEnabled = True
        Me.chckLstColDsp.Location = New System.Drawing.Point(744, 16)
        Me.chckLstColDsp.Name = "chckLstColDsp"
        Me.chckLstColDsp.Size = New System.Drawing.Size(232, 102)
        Me.chckLstColDsp.TabIndex = 75
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(640, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 24)
        Me.Label8.TabIndex = 76
        Me.Label8.Text = "列表示:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_299003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 617)
        Me.Controls.Add(Me.cmdPalletID)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdDisp)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Name = "FRM_299003"
        Me.Text = "FRM_299003"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpKikanToTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpKikanToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpKikanFromTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpKikanFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPallet_ID As System.Windows.Forms.TextBox
    Friend WithEvents grdList As System.Windows.Forms.DataGridView
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdDisp As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFINOUT_STS As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTO As System.Windows.Forms.ComboBox
    Friend WithEvents cboFROM As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdPalletID As System.Windows.Forms.Button
    Friend WithEvents chckLstColDsp As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
