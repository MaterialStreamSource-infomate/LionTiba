<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_205040
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkFRES_KIND_AKI = New System.Windows.Forms.CheckBox
        Me.cboFRAC_EDA = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFRAC_DAN = New MateCommon.cmpMComboBox
        Me.cboFPLACE_CD = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboFRAC_REN = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboFRAC_RETU = New MateCommon.cmpMComboBox
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1144, 672)
        Me.cmdF8.TabIndex = 8
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1162, 613)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(718, 672)
        Me.cmdF6.TabIndex = 7
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(608, 672)
        Me.cmdF5.TabIndex = 6
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(498, 672)
        Me.cmdF4.TabIndex = 5
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(278, 672)
        Me.cmdF3.TabIndex = 4
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(168, 672)
        Me.cmdF2.TabIndex = 3
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 152)
        Me.cmdF1.TabIndex = 1
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 201)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 455)
        Me.grdList.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFRES_KIND_AKI)
        Me.GroupBox1.Controls.Add(Me.cboFRAC_EDA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboFRAC_DAN)
        Me.GroupBox1.Controls.Add(Me.cboFPLACE_CD)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboFRAC_REN)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboFRAC_RETU)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 89)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 106)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkFRES_KIND_AKI
        '
        Me.chkFRES_KIND_AKI.AutoSize = True
        Me.chkFRES_KIND_AKI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.chkFRES_KIND_AKI.ForeColor = System.Drawing.Color.Black
        Me.chkFRES_KIND_AKI.Location = New System.Drawing.Point(733, 21)
        Me.chkFRES_KIND_AKI.Name = "chkFRES_KIND_AKI"
        Me.chkFRES_KIND_AKI.Size = New System.Drawing.Size(154, 24)
        Me.chkFRES_KIND_AKI.TabIndex = 5
        Me.chkFRES_KIND_AKI.Text = "空棚のみ表示"
        Me.chkFRES_KIND_AKI.UseVisualStyleBackColor = True
        '
        'cboFRAC_EDA
        '
        Me.cboFRAC_EDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_EDA.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_EDA.FormattingEnabled = True
        Me.cboFRAC_EDA.IntegralHeight = False
        Me.cboFRAC_EDA.Location = New System.Drawing.Point(627, 65)
        Me.cboFRAC_EDA.Name = "cboFRAC_EDA"
        Me.cboFRAC_EDA.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_EDA.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(538, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 32)
        Me.Label2.TabIndex = 267
        Me.Label2.Text = "枝:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFRAC_DAN
        '
        Me.cboFRAC_DAN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_DAN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_DAN.FormattingEnabled = True
        Me.cboFRAC_DAN.IntegralHeight = False
        Me.cboFRAC_DAN.Location = New System.Drawing.Point(473, 65)
        Me.cboFRAC_DAN.Name = "cboFRAC_DAN"
        Me.cboFRAC_DAN.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_DAN.TabIndex = 3
        '
        'cboFPLACE_CD
        '
        Me.cboFPLACE_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPLACE_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFPLACE_CD.FormattingEnabled = True
        Me.cboFPLACE_CD.IntegralHeight = False
        Me.cboFPLACE_CD.Location = New System.Drawing.Point(168, 18)
        Me.cboFPLACE_CD.Name = "cboFPLACE_CD"
        Me.cboFPLACE_CD.Size = New System.Drawing.Size(264, 27)
        Me.cboFPLACE_CD.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(80, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 32)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "列:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(48, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 32)
        Me.Label1.TabIndex = 265
        Me.Label1.Text = "保管場所:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFRAC_REN
        '
        Me.cboFRAC_REN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_REN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_REN.FormattingEnabled = True
        Me.cboFRAC_REN.IntegralHeight = False
        Me.cboFRAC_REN.Location = New System.Drawing.Point(321, 65)
        Me.cboFRAC_REN.Name = "cboFRAC_REN"
        Me.cboFRAC_REN.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_REN.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(232, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 32)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "連:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(384, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 32)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "段:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFRAC_RETU
        '
        Me.cboFRAC_RETU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_RETU.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_RETU.FormattingEnabled = True
        Me.cboFRAC_RETU.IntegralHeight = False
        Me.cboFRAC_RETU.Location = New System.Drawing.Point(168, 64)
        Me.cboFRAC_RETU.Name = "cboFRAC_RETU"
        Me.cboFRAC_RETU.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_RETU.TabIndex = 1
        '
        'FRM_205040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_205040"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFRAC_DAN As MateCommon.cmpMComboBox
    Friend WithEvents cboFRAC_REN As MateCommon.cmpMComboBox
    Friend WithEvents cboFRAC_RETU As MateCommon.cmpMComboBox
    Friend WithEvents cboFPLACE_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFRAC_EDA As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkFRES_KIND_AKI As System.Windows.Forms.CheckBox

End Class
