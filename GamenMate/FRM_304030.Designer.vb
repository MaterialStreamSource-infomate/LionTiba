<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_304030
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.cboXSEIZOU_DT = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtXPALLET_NO_TO = New MateCommon.cmpMTextBoxString
        Me.txtXPALLET_NO_FM = New MateCommon.cmpMTextBoxString
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
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1064, 717)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1064, 668)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 672)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 158)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox1.Controls.Add(Me.cboXSEIZOU_DT)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtXPALLET_NO_TO)
        Me.GroupBox1.Controls.Add(Me.txtXPALLET_NO_FM)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboXLINE_NO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 104)
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(147, 16)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(149, 28)
        Me.cboFHINMEI_CD.TabIndex = 1
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'cboXSEIZOU_DT
        '
        Me.cboXSEIZOU_DT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSEIZOU_DT.FormattingEnabled = True
        Me.cboXSEIZOU_DT.IntegralHeight = False
        Me.cboXSEIZOU_DT.Location = New System.Drawing.Point(795, 24)
        Me.cboXSEIZOU_DT.Name = "cboXSEIZOU_DT"
        Me.cboXSEIZOU_DT.Size = New System.Drawing.Size(149, 28)
        Me.cboXSEIZOU_DT.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(656, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "製造年月日:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(528, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 32)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "～"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXPALLET_NO_TO
        '
        Me.txtXPALLET_NO_TO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXPALLET_NO_TO.EnabledFull = False
        Me.txtXPALLET_NO_TO.EnabledFullAlphabetLower = False
        Me.txtXPALLET_NO_TO.EnabledFullAlphabetUpper = False
        Me.txtXPALLET_NO_TO.EnabledFullHiragana = False
        Me.txtXPALLET_NO_TO.EnabledFullKatakana = False
        Me.txtXPALLET_NO_TO.EnabledFullNumber = False
        Me.txtXPALLET_NO_TO.EnabledHalf = True
        Me.txtXPALLET_NO_TO.EnabledHalfAlphabetLower = False
        Me.txtXPALLET_NO_TO.EnabledHalfAlphabetUpper = False
        Me.txtXPALLET_NO_TO.EnabledHalfKatakana = False
        Me.txtXPALLET_NO_TO.EnabledHalfNumber = True
        Me.txtXPALLET_NO_TO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXPALLET_NO_TO.Location = New System.Drawing.Point(568, 64)
        Me.txtXPALLET_NO_TO.MaxLength = 4
        Me.txtXPALLET_NO_TO.MaxLengthByte = 4
        Me.txtXPALLET_NO_TO.Name = "txtXPALLET_NO_TO"
        Me.txtXPALLET_NO_TO.RegexCustomFalse = Nothing
        Me.txtXPALLET_NO_TO.RegexCustomTrue = Nothing
        Me.txtXPALLET_NO_TO.Size = New System.Drawing.Size(62, 27)
        Me.txtXPALLET_NO_TO.TabIndex = 10
        '
        'txtXPALLET_NO_FM
        '
        Me.txtXPALLET_NO_FM.BackColorMask = System.Drawing.Color.Empty
        Me.txtXPALLET_NO_FM.EnabledFull = False
        Me.txtXPALLET_NO_FM.EnabledFullAlphabetLower = False
        Me.txtXPALLET_NO_FM.EnabledFullAlphabetUpper = False
        Me.txtXPALLET_NO_FM.EnabledFullHiragana = False
        Me.txtXPALLET_NO_FM.EnabledFullKatakana = False
        Me.txtXPALLET_NO_FM.EnabledFullNumber = False
        Me.txtXPALLET_NO_FM.EnabledHalf = True
        Me.txtXPALLET_NO_FM.EnabledHalfAlphabetLower = False
        Me.txtXPALLET_NO_FM.EnabledHalfAlphabetUpper = False
        Me.txtXPALLET_NO_FM.EnabledHalfKatakana = False
        Me.txtXPALLET_NO_FM.EnabledHalfNumber = True
        Me.txtXPALLET_NO_FM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXPALLET_NO_FM.Location = New System.Drawing.Point(456, 64)
        Me.txtXPALLET_NO_FM.MaxLength = 4
        Me.txtXPALLET_NO_FM.MaxLengthByte = 4
        Me.txtXPALLET_NO_FM.Name = "txtXPALLET_NO_FM"
        Me.txtXPALLET_NO_FM.RegexCustomFalse = Nothing
        Me.txtXPALLET_NO_FM.RegexCustomTrue = Nothing
        Me.txtXPALLET_NO_FM.Size = New System.Drawing.Size(62, 27)
        Me.txtXPALLET_NO_FM.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(336, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 32)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "ﾊﾟﾚｯﾄ№:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXLINE_NO
        '
        Me.cboXLINE_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXLINE_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXLINE_NO.FormattingEnabled = True
        Me.cboXLINE_NO.IntegralHeight = False
        Me.cboXLINE_NO.Location = New System.Drawing.Point(147, 64)
        Me.cboXLINE_NO.Name = "cboXLINE_NO"
        Me.cboXLINE_NO.Size = New System.Drawing.Size(149, 28)
        Me.cboXLINE_NO.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 32)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "ﾗｲﾝ№:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(304, 18)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(328, 32)
        Me.lblFHINMEI.TabIndex = 2
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 16)
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
        Me.grdList.Location = New System.Drawing.Point(168, 208)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 452)
        Me.grdList.TabIndex = 21
        '
        'FRM_304030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_304030"
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents cboXLINE_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtXPALLET_NO_FM As MateCommon.cmpMTextBoxString
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtXPALLET_NO_TO As MateCommon.cmpMTextBoxString
    Friend WithEvents cboXSEIZOU_DT As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD

    'Required by the Windows Form Designer

End Class
