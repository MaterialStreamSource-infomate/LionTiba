<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_304010
    Inherits GamenMate.FRM_000002

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.dtpFARRIVE_DT_TO = New GamenCommon.cmpMDateTimePicker_DT
        Me.dtpFARRIVE_DT_FM = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.txtXPALLET_NO = New MateCommon.cmpMTextBoxString
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXLINE_NO = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 672)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 198)
        '
        'dtpFARRIVE_DT_TO
        '
        Me.dtpFARRIVE_DT_TO.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFARRIVE_DT_TO.Location = New System.Drawing.Point(542, 56)
        Me.dtpFARRIVE_DT_TO.Name = "dtpFARRIVE_DT_TO"
        Me.dtpFARRIVE_DT_TO.Size = New System.Drawing.Size(299, 30)
        Me.dtpFARRIVE_DT_TO.TabIndex = 6
        Me.dtpFARRIVE_DT_TO.TimeComboDisp = True
        Me.dtpFARRIVE_DT_TO.userChecked = True
        Me.dtpFARRIVE_DT_TO.userShowCheckBox = True
        '
        'dtpFARRIVE_DT_FM
        '
        Me.dtpFARRIVE_DT_FM.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFARRIVE_DT_FM.Location = New System.Drawing.Point(192, 56)
        Me.dtpFARRIVE_DT_FM.Name = "dtpFARRIVE_DT_FM"
        Me.dtpFARRIVE_DT_FM.Size = New System.Drawing.Size(299, 30)
        Me.dtpFARRIVE_DT_FM.TabIndex = 4
        Me.dtpFARRIVE_DT_FM.TimeComboDisp = True
        Me.dtpFARRIVE_DT_FM.userChecked = True
        Me.dtpFARRIVE_DT_FM.userShowCheckBox = True
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(485, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 32)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "～"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(24, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(168, 32)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "在庫発生日時:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox1.Controls.Add(Me.txtXPALLET_NO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboXLINE_NO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtpFARRIVE_DT_TO)
        Me.GroupBox1.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox1.Controls.Add(Me.dtpFARRIVE_DT_FM)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 144)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'cboFHINMEI_CD
        '
        Me.cboFHINMEI_CD.ArticleShortNameLabel = Nothing
        Me.cboFHINMEI_CD.ArticleTypeCode = Nothing
        Me.cboFHINMEI_CD.CboDispNameType = GamenCommon.cmpCboFHINMEI_CD.DispNameType.FullName
        Me.cboFHINMEI_CD.Col1Width = 150
        Me.cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedTableData
        Me.cboFHINMEI_CD.conn = Nothing
        Me.cboFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFHINMEI_CD.FormattingEnabled = True
        Me.cboFHINMEI_CD.FRES_KIND = ""
        Me.cboFHINMEI_CD.FTRK_BUF_NO = Nothing
        Me.cboFHINMEI_CD.HinmeiKind = Nothing
        Me.cboFHINMEI_CD.HinmeiLabel = Nothing
        Me.cboFHINMEI_CD.HinmeiVisible = True
        Me.cboFHINMEI_CD.IntegralHeight = False
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(195, 16)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(168, 28)
        Me.cboFHINMEI_CD.TabIndex = 1
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'txtXPALLET_NO
        '
        Me.txtXPALLET_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXPALLET_NO.EnabledFull = False
        Me.txtXPALLET_NO.EnabledFullAlphabetLower = False
        Me.txtXPALLET_NO.EnabledFullAlphabetUpper = False
        Me.txtXPALLET_NO.EnabledFullHiragana = False
        Me.txtXPALLET_NO.EnabledFullKatakana = False
        Me.txtXPALLET_NO.EnabledFullNumber = False
        Me.txtXPALLET_NO.EnabledHalf = True
        Me.txtXPALLET_NO.EnabledHalfAlphabetLower = False
        Me.txtXPALLET_NO.EnabledHalfAlphabetUpper = False
        Me.txtXPALLET_NO.EnabledHalfKatakana = False
        Me.txtXPALLET_NO.EnabledHalfNumber = True
        Me.txtXPALLET_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXPALLET_NO.Location = New System.Drawing.Point(520, 96)
        Me.txtXPALLET_NO.MaxLength = 4
        Me.txtXPALLET_NO.MaxLengthByte = 4
        Me.txtXPALLET_NO.Name = "txtXPALLET_NO"
        Me.txtXPALLET_NO.RegexCustomFalse = Nothing
        Me.txtXPALLET_NO.RegexCustomTrue = Nothing
        Me.txtXPALLET_NO.Size = New System.Drawing.Size(62, 27)
        Me.txtXPALLET_NO.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(376, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 32)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "ﾊﾟﾚｯﾄ№:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXLINE_NO
        '
        Me.cboXLINE_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXLINE_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXLINE_NO.FormattingEnabled = True
        Me.cboXLINE_NO.IntegralHeight = False
        Me.cboXLINE_NO.Location = New System.Drawing.Point(195, 96)
        Me.cboXLINE_NO.Name = "cboXLINE_NO"
        Me.cboXLINE_NO.Size = New System.Drawing.Size(144, 28)
        Me.cboXLINE_NO.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(60, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 32)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "ﾗｲﾝ№:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(368, 18)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(427, 32)
        Me.lblFHINMEI.TabIndex = 2
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(64, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "品名コード:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 248)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 413)
        Me.grdList.TabIndex = 21
        '
        'FRM_304010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_304010"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents dtpFARRIVE_DT_TO As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents dtpFARRIVE_DT_FM As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents cboXLINE_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtXPALLET_NO As MateCommon.cmpMTextBoxString
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD

    'Required by the Windows Form Designer

End Class
