<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_204030
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtpTo = New GamenCommon.cmpMDateTimePicker_DT
        Me.dtpFrom = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboXPROD_LINE = New MateCommon.cmpMComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpFARRIVE_DT_To = New GamenCommon.cmpMDateTimePicker_DT
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.dtpFARRIVE_DT_From = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboTO = New MateCommon.cmpMComboBox
        Me.cboFROM = New MateCommon.cmpMComboBox
        Me.cboFINOUT_STS = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1160, 717)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1160, 668)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(169, 672)
        Me.cmdF6.TabIndex = 4
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 246)
        Me.cmdF1.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpTo)
        Me.GroupBox2.Controls.Add(Me.dtpFrom)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(960, 64)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'dtpTo
        '
        Me.dtpTo.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpTo.Location = New System.Drawing.Point(553, 21)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(299, 30)
        Me.dtpTo.TabIndex = 1
        Me.dtpTo.TimeComboDisp = True
        Me.dtpTo.userChecked = True
        Me.dtpTo.userShowCheckBox = True
        '
        'dtpFrom
        '
        Me.dtpFrom.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFrom.Location = New System.Drawing.Point(203, 21)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(299, 30)
        Me.dtpFrom.TabIndex = 0
        Me.dtpFrom.TimeComboDisp = True
        Me.dtpFrom.userChecked = True
        Me.dtpFrom.userShowCheckBox = True
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(496, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 32)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "～"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(80, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 32)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "期間:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboXPROD_LINE)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpFARRIVE_DT_To)
        Me.GroupBox1.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox1.Controls.Add(Me.dtpFARRIVE_DT_From)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboTO)
        Me.GroupBox1.Controls.Add(Me.cboFROM)
        Me.GroupBox1.Controls.Add(Me.cboFINOUT_STS)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 159)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 162)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cboXPROD_LINE
        '
        Me.cboXPROD_LINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXPROD_LINE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXPROD_LINE.FormattingEnabled = True
        Me.cboXPROD_LINE.IntegralHeight = False
        Me.cboXPROD_LINE.Location = New System.Drawing.Point(596, 128)
        Me.cboXPROD_LINE.Name = "cboXPROD_LINE"
        Me.cboXPROD_LINE.Size = New System.Drawing.Size(184, 28)
        Me.cboXPROD_LINE.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(456, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 32)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "生産ﾗｲﾝNo.:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFARRIVE_DT_To
        '
        Me.dtpFARRIVE_DT_To.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFARRIVE_DT_To.Location = New System.Drawing.Point(514, 50)
        Me.dtpFARRIVE_DT_To.Name = "dtpFARRIVE_DT_To"
        Me.dtpFARRIVE_DT_To.Size = New System.Drawing.Size(299, 30)
        Me.dtpFARRIVE_DT_To.TabIndex = 2
        Me.dtpFARRIVE_DT_To.TimeComboDisp = True
        Me.dtpFARRIVE_DT_To.userChecked = True
        Me.dtpFARRIVE_DT_To.userShowCheckBox = True
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(164, 16)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(184, 28)
        Me.cboFHINMEI_CD.TabIndex = 0
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XKANRI_KUBUN = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'dtpFARRIVE_DT_From
        '
        Me.dtpFARRIVE_DT_From.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFARRIVE_DT_From.Location = New System.Drawing.Point(164, 50)
        Me.dtpFARRIVE_DT_From.Name = "dtpFARRIVE_DT_From"
        Me.dtpFARRIVE_DT_From.Size = New System.Drawing.Size(299, 30)
        Me.dtpFARRIVE_DT_From.TabIndex = 1
        Me.dtpFARRIVE_DT_From.TimeComboDisp = True
        Me.dtpFARRIVE_DT_From.userChecked = True
        Me.dtpFARRIVE_DT_From.userShowCheckBox = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(457, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 32)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "～"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(360, 18)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(382, 32)
        Me.lblFHINMEI.TabIndex = 2
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(5, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "在庫発生日時:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(5, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "品名ｺｰﾄﾞ/記号:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTO
        '
        Me.cboTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboTO.FormattingEnabled = True
        Me.cboTO.IntegralHeight = False
        Me.cboTO.Location = New System.Drawing.Point(596, 89)
        Me.cboTO.Name = "cboTO"
        Me.cboTO.Size = New System.Drawing.Size(294, 28)
        Me.cboTO.TabIndex = 4
        '
        'cboFROM
        '
        Me.cboFROM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFROM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFROM.FormattingEnabled = True
        Me.cboFROM.IntegralHeight = False
        Me.cboFROM.Location = New System.Drawing.Point(164, 89)
        Me.cboFROM.Name = "cboFROM"
        Me.cboFROM.Size = New System.Drawing.Size(294, 28)
        Me.cboFROM.TabIndex = 3
        '
        'cboFINOUT_STS
        '
        Me.cboFINOUT_STS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFINOUT_STS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFINOUT_STS.FormattingEnabled = True
        Me.cboFINOUT_STS.IntegralHeight = False
        Me.cboFINOUT_STS.Location = New System.Drawing.Point(164, 128)
        Me.cboFINOUT_STS.Name = "cboFINOUT_STS"
        Me.cboFINOUT_STS.Size = New System.Drawing.Size(184, 28)
        Me.cboFINOUT_STS.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(473, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 32)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "TO ST:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(80, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 32)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "動作:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(48, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 32)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "FROM ST:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 327)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 328)
        Me.grdList.TabIndex = 3
        '
        'FRM_204030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_204030"
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents dtpTo As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents dtpFrom As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents cboFINOUT_STS As MateCommon.cmpMComboBox
    Friend WithEvents cboTO As MateCommon.cmpMComboBox
    Friend WithEvents cboFROM As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents dtpFARRIVE_DT_To As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents dtpFARRIVE_DT_From As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboXPROD_LINE As MateCommon.cmpMComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

    'Required by the Windows Form Designer

End Class
