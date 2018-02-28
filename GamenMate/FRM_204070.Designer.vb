<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_204070
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFSYORI_ID = New MateCommon.cmpMComboBox
        Me.cboFUSER_ID = New MateCommon.cmpMComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblFUSER_NAME_DSP = New System.Windows.Forms.Label
        Me.dtpTo = New GamenCommon.cmpMDateTimePicker_DT
        Me.dtpFrom = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList2 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.lblLst = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 259)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cboFSYORI_ID)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1080, 57)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 32)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "変更履歴情報:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFSYORI_ID
        '
        Me.cboFSYORI_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFSYORI_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFSYORI_ID.FormattingEnabled = True
        Me.cboFSYORI_ID.IntegralHeight = False
        Me.cboFSYORI_ID.Location = New System.Drawing.Point(192, 19)
        Me.cboFSYORI_ID.Name = "cboFSYORI_ID"
        Me.cboFSYORI_ID.Size = New System.Drawing.Size(344, 27)
        Me.cboFSYORI_ID.TabIndex = 0
        '
        'cboFUSER_ID
        '
        Me.cboFUSER_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFUSER_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFUSER_ID.FormattingEnabled = True
        Me.cboFUSER_ID.IntegralHeight = False
        Me.cboFUSER_ID.Location = New System.Drawing.Point(192, 19)
        Me.cboFUSER_ID.Name = "cboFUSER_ID"
        Me.cboFUSER_ID.Size = New System.Drawing.Size(192, 27)
        Me.cboFUSER_ID.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblFUSER_NAME_DSP)
        Me.GroupBox1.Controls.Add(Me.cboFUSER_ID)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 155)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1080, 99)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lblFUSER_NAME_DSP
        '
        Me.lblFUSER_NAME_DSP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFUSER_NAME_DSP.ForeColor = System.Drawing.Color.Black
        Me.lblFUSER_NAME_DSP.Location = New System.Drawing.Point(390, 16)
        Me.lblFUSER_NAME_DSP.Name = "lblFUSER_NAME_DSP"
        Me.lblFUSER_NAME_DSP.Size = New System.Drawing.Size(199, 32)
        Me.lblFUSER_NAME_DSP.TabIndex = 244
        Me.lblFUSER_NAME_DSP.Text = "作業者名"
        Me.lblFUSER_NAME_DSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTo
        '
        Me.dtpTo.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpTo.Location = New System.Drawing.Point(539, 57)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(299, 30)
        Me.dtpTo.TabIndex = 2
        Me.dtpTo.TimeComboDisp = True
        Me.dtpTo.userChecked = True
        Me.dtpTo.userShowCheckBox = True
        '
        'dtpFrom
        '
        Me.dtpFrom.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFrom.Location = New System.Drawing.Point(189, 57)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(299, 30)
        Me.dtpFrom.TabIndex = 1
        Me.dtpFrom.TimeComboDisp = True
        Me.dtpFrom.userChecked = True
        Me.dtpFrom.userShowCheckBox = True
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(480, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 32)
        Me.Label18.TabIndex = 243
        Me.Label18.Text = "～"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(72, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 32)
        Me.Label14.TabIndex = 240
        Me.Label14.Text = "期間:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(32, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 32)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "変更者:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 306)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 271)
        Me.grdList.TabIndex = 2
        '
        'grdList2
        '
        Me.grdList2.blnDBUpdate = False
        Me.grdList2.blnSelectionChanged = False
        Me.grdList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList2.Location = New System.Drawing.Point(168, 582)
        Me.grdList2.MyBeseDoubleBuffered = False
        Me.grdList2.Name = "grdList2"
        Me.grdList2.RowTemplate.Height = 21
        Me.grdList2.Size = New System.Drawing.Size(1080, 98)
        Me.grdList2.TabIndex = 3
        '
        'lblLst
        '
        Me.lblLst.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLst.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLst.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.lblLst.Location = New System.Drawing.Point(173, 587)
        Me.lblLst.Name = "lblLst"
        Me.lblLst.Size = New System.Drawing.Size(72, 24)
        Me.lblLst.TabIndex = 246
        Me.lblLst.Text = "項目名"
        Me.lblLst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FRM_204070
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.lblLst)
        Me.Controls.Add(Me.grdList2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_204070"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.grdList2, 0)
        Me.Controls.SetChildIndex(Me.lblLst, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList2 As GamenCommon.cmpMDataGrid
    Friend WithEvents cboFUSER_ID As MateCommon.cmpMComboBox
    Friend WithEvents cboFSYORI_ID As MateCommon.cmpMComboBox
    Friend WithEvents dtpTo As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents dtpFrom As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblLst As System.Windows.Forms.Label
    Friend WithEvents lblFUSER_NAME_DSP As System.Windows.Forms.Label

End Class
