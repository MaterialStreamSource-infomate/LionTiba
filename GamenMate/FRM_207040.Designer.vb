<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_207040
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
        Me.components = New System.ComponentModel.Container
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboFEQ_NAME = New MateCommon.cmpMComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFTEXT_ID = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFDIRECTION = New MateCommon.cmpMComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboFEQ_ID = New MateCommon.cmpMComboBox
        Me.dtpTo = New GamenCommon.cmpMDateTimePicker_DT
        Me.dtpFrom = New GamenCommon.cmpMDateTimePicker_DT
        Me.chkStateFlg = New System.Windows.Forms.CheckBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1152, 152)
        Me.cmdF1.TabIndex = 1
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(176, 289)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 410)
        Me.grdList.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboFEQ_NAME)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cboFTEXT_ID)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboFDIRECTION)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboFEQ_ID)
        Me.GroupBox2.Controls.Add(Me.dtpTo)
        Me.GroupBox2.Controls.Add(Me.dtpFrom)
        Me.GroupBox2.Controls.Add(Me.chkStateFlg)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(176, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(960, 180)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'cboFEQ_NAME
        '
        Me.cboFEQ_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFEQ_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFEQ_NAME.FormattingEnabled = True
        Me.cboFEQ_NAME.IntegralHeight = False
        Me.cboFEQ_NAME.Location = New System.Drawing.Point(200, 140)
        Me.cboFEQ_NAME.Name = "cboFEQ_NAME"
        Me.cboFEQ_NAME.Size = New System.Drawing.Size(522, 27)
        Me.cboFEQ_NAME.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(87, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 32)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "設備名称:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFTEXT_ID
        '
        Me.cboFTEXT_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTEXT_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFTEXT_ID.FormattingEnabled = True
        Me.cboFTEXT_ID.IntegralHeight = False
        Me.cboFTEXT_ID.Location = New System.Drawing.Point(439, 100)
        Me.cboFTEXT_ID.Name = "cboFTEXT_ID"
        Me.cboFTEXT_ID.Size = New System.Drawing.Size(283, 27)
        Me.cboFTEXT_ID.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(344, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 32)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "ﾃｷｽﾄID:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFDIRECTION
        '
        Me.cboFDIRECTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFDIRECTION.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFDIRECTION.FormattingEnabled = True
        Me.cboFDIRECTION.IntegralHeight = False
        Me.cboFDIRECTION.Location = New System.Drawing.Point(200, 100)
        Me.cboFDIRECTION.Name = "cboFDIRECTION"
        Me.cboFDIRECTION.Size = New System.Drawing.Size(128, 27)
        Me.cboFDIRECTION.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(80, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 32)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "方向:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFEQ_ID
        '
        Me.cboFEQ_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFEQ_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFEQ_ID.FormattingEnabled = True
        Me.cboFEQ_ID.IntegralHeight = False
        Me.cboFEQ_ID.Location = New System.Drawing.Point(200, 16)
        Me.cboFEQ_ID.Name = "cboFEQ_ID"
        Me.cboFEQ_ID.Size = New System.Drawing.Size(192, 27)
        Me.cboFEQ_ID.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.BackColorMask = System.Drawing.Color.Empty
        Me.dtpTo.Location = New System.Drawing.Point(553, 58)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(299, 30)
        Me.dtpTo.TabIndex = 3
        Me.dtpTo.TimeComboDisp = True
        Me.dtpTo.userChecked = True
        Me.dtpTo.userShowCheckBox = True
        '
        'dtpFrom
        '
        Me.dtpFrom.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFrom.Location = New System.Drawing.Point(197, 58)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(299, 30)
        Me.dtpFrom.TabIndex = 2
        Me.dtpFrom.TimeComboDisp = True
        Me.dtpFrom.userChecked = True
        Me.dtpFrom.userShowCheckBox = True
        '
        'chkStateFlg
        '
        Me.chkStateFlg.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkStateFlg.ForeColor = System.Drawing.Color.Black
        Me.chkStateFlg.Location = New System.Drawing.Point(592, 16)
        Me.chkStateFlg.Name = "chkStateFlg"
        Me.chkStateFlg.Size = New System.Drawing.Size(344, 32)
        Me.chkStateFlg.TabIndex = 1
        Me.chkStateFlg.Text = "：状態報告要求を表示する"
        Me.chkStateFlg.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(491, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 32)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "～"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(96, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 32)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "通信対象:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(80, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 32)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "期間:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_207040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FRM_207040"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFEQ_ID As MateCommon.cmpMComboBox
    Friend WithEvents dtpTo As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents dtpFrom As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents chkStateFlg As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboFDIRECTION As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFTEXT_ID As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFEQ_NAME As MateCommon.cmpMComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
