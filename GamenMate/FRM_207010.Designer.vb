<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_207010
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
        Me.lblFUSER_NAME_DSP = New System.Windows.Forms.Label
        Me.dtpTo = New GamenCommon.cmpMDateTimePicker_DT
        Me.dtpFrom = New GamenCommon.cmpMDateTimePicker_DT
        Me.cboContent = New MateCommon.cmpMComboBox
        Me.cboFTERM_ID = New MateCommon.cmpMComboBox
        Me.cboFUSER_ID = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1136, 672)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1138, 715)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(1028, 715)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(918, 715)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 664)
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(808, 715)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(698, 715)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 188)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 240)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 413)
        Me.grdList.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblFUSER_NAME_DSP)
        Me.GroupBox2.Controls.Add(Me.dtpTo)
        Me.GroupBox2.Controls.Add(Me.dtpFrom)
        Me.GroupBox2.Controls.Add(Me.cboContent)
        Me.GroupBox2.Controls.Add(Me.cboFTERM_ID)
        Me.GroupBox2.Controls.Add(Me.cboFUSER_ID)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(960, 140)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'lblFUSER_NAME_DSP
        '
        Me.lblFUSER_NAME_DSP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFUSER_NAME_DSP.ForeColor = System.Drawing.Color.Black
        Me.lblFUSER_NAME_DSP.Location = New System.Drawing.Point(296, 16)
        Me.lblFUSER_NAME_DSP.Name = "lblFUSER_NAME_DSP"
        Me.lblFUSER_NAME_DSP.Size = New System.Drawing.Size(199, 32)
        Me.lblFUSER_NAME_DSP.TabIndex = 2
        Me.lblFUSER_NAME_DSP.Text = "作業者名"
        Me.lblFUSER_NAME_DSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTo
        '
        Me.dtpTo.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpTo.Location = New System.Drawing.Point(468, 96)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(299, 30)
        Me.dtpTo.TabIndex = 10
        Me.dtpTo.TimeComboDisp = True
        Me.dtpTo.userChecked = True
        Me.dtpTo.userShowCheckBox = True
        '
        'dtpFrom
        '
        Me.dtpFrom.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFrom.Location = New System.Drawing.Point(118, 96)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(299, 30)
        Me.dtpFrom.TabIndex = 8
        Me.dtpFrom.TimeComboDisp = True
        Me.dtpFrom.userChecked = True
        Me.dtpFrom.userShowCheckBox = True
        '
        'cboContent
        '
        Me.cboContent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContent.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboContent.FormattingEnabled = True
        Me.cboContent.IntegralHeight = False
        Me.cboContent.Location = New System.Drawing.Point(624, 20)
        Me.cboContent.Name = "cboContent"
        Me.cboContent.Size = New System.Drawing.Size(328, 27)
        Me.cboContent.TabIndex = 4
        '
        'cboFTERM_ID
        '
        Me.cboFTERM_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTERM_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFTERM_ID.FormattingEnabled = True
        Me.cboFTERM_ID.IntegralHeight = False
        Me.cboFTERM_ID.Location = New System.Drawing.Point(118, 60)
        Me.cboFTERM_ID.Name = "cboFTERM_ID"
        Me.cboFTERM_ID.Size = New System.Drawing.Size(170, 27)
        Me.cboFTERM_ID.TabIndex = 6
        '
        'cboFUSER_ID
        '
        Me.cboFUSER_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFUSER_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFUSER_ID.FormattingEnabled = True
        Me.cboFUSER_ID.IntegralHeight = False
        Me.cboFUSER_ID.Location = New System.Drawing.Point(118, 20)
        Me.cboFUSER_ID.Name = "cboFUSER_ID"
        Me.cboFUSER_ID.Size = New System.Drawing.Size(170, 27)
        Me.cboFUSER_ID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(506, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "作業内容:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 32)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "操作端末:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "作業者:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(409, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 32)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "～"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(24, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 32)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "期間:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_207010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FRM_207010"
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
    Friend WithEvents dtpTo As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents dtpFrom As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents cboContent As MateCommon.cmpMComboBox
    Friend WithEvents cboFTERM_ID As MateCommon.cmpMComboBox
    Friend WithEvents cboFUSER_ID As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblFUSER_NAME_DSP As System.Windows.Forms.Label

End Class
