<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_202000
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Kiri = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Hukki = New System.Windows.Forms.ToolStripMenuItem
        Me.tmr202000 = New System.Windows.Forms.Timer(Me.components)
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblDCV = New System.Windows.Forms.Label
        Me.lblTANA1F = New System.Windows.Forms.Label
        Me.lblGAIBU = New System.Windows.Forms.Label
        Me.lblTRUCK = New System.Windows.Forms.Label
        Me.lblRTN1F = New System.Windows.Forms.Label
        Me.lblSYUKKA1F = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblCRANE14 = New System.Windows.Forms.Label
        Me.lblCRANE13 = New System.Windows.Forms.Label
        Me.lblCRANE12 = New System.Windows.Forms.Label
        Me.lblCRANE7 = New System.Windows.Forms.Label
        Me.lblCRANE6 = New System.Windows.Forms.Label
        Me.lblSPURT = New System.Windows.Forms.Label
        Me.lblRTN2F = New System.Windows.Forms.Label
        Me.lblTANA2F = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.lblCRANE11 = New System.Windows.Forms.Label
        Me.lblCRANE10 = New System.Windows.Forms.Label
        Me.lblCRANE9 = New System.Windows.Forms.Label
        Me.lblCRANE8 = New System.Windows.Forms.Label
        Me.lblCRANE5 = New System.Windows.Forms.Label
        Me.lblCRANE4 = New System.Windows.Forms.Label
        Me.lblCRANE3 = New System.Windows.Forms.Label
        Me.lblCRANE2 = New System.Windows.Forms.Label
        Me.lblCRANE1 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.lblTAKATANA_NUM = New System.Windows.Forms.Label
        Me.lblKEI_NUM = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblServer = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblHIKUTANA_NUM = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(1064, 619)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(1064, 570)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(1064, 521)
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(1064, 472)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(766, 672)
        Me.cmdF2.Size = New System.Drawing.Size(160, 43)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(166, 672)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Kiri, Me.Menu_Hukki})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 48)
        '
        'Menu_Kiri
        '
        Me.Menu_Kiri.Name = "Menu_Kiri"
        Me.Menu_Kiri.Size = New System.Drawing.Size(103, 22)
        Me.Menu_Kiri.Text = "切離し"
        '
        'Menu_Hukki
        '
        Me.Menu_Hukki.Name = "Menu_Hukki"
        Me.Menu_Hukki.Size = New System.Drawing.Size(103, 22)
        Me.Menu_Hukki.Text = "復帰"
        '
        'tmr202000
        '
        Me.tmr202000.Interval = 10000
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.ContextMenuStrip = Me.ContextMenuStrip1
        Me.grdList.Location = New System.Drawing.Point(766, 96)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(498, 565)
        Me.grdList.TabIndex = 268
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDCV)
        Me.GroupBox1.Controls.Add(Me.lblTANA1F)
        Me.GroupBox1.Controls.Add(Me.lblGAIBU)
        Me.GroupBox1.Controls.Add(Me.lblTRUCK)
        Me.GroupBox1.Controls.Add(Me.lblRTN1F)
        Me.GroupBox1.Controls.Add(Me.lblSYUKKA1F)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblCRANE14)
        Me.GroupBox1.Controls.Add(Me.lblCRANE13)
        Me.GroupBox1.Controls.Add(Me.lblCRANE12)
        Me.GroupBox1.Controls.Add(Me.lblCRANE7)
        Me.GroupBox1.Controls.Add(Me.lblCRANE6)
        Me.GroupBox1.Controls.Add(Me.lblSPURT)
        Me.GroupBox1.Controls.Add(Me.lblRTN2F)
        Me.GroupBox1.Controls.Add(Me.lblTANA2F)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.lblCRANE11)
        Me.GroupBox1.Controls.Add(Me.lblCRANE10)
        Me.GroupBox1.Controls.Add(Me.lblCRANE9)
        Me.GroupBox1.Controls.Add(Me.lblCRANE8)
        Me.GroupBox1.Controls.Add(Me.lblCRANE5)
        Me.GroupBox1.Controls.Add(Me.lblCRANE4)
        Me.GroupBox1.Controls.Add(Me.lblCRANE3)
        Me.GroupBox1.Controls.Add(Me.lblCRANE2)
        Me.GroupBox1.Controls.Add(Me.lblCRANE1)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.lblTAKATANA_NUM)
        Me.GroupBox1.Controls.Add(Me.lblKEI_NUM)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblServer)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblHIKUTANA_NUM)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(160, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(600, 574)
        Me.GroupBox1.TabIndex = 269
        Me.GroupBox1.TabStop = False
        '
        'lblDCV
        '
        Me.lblDCV.BackColor = System.Drawing.Color.Salmon
        Me.lblDCV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDCV.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDCV.ForeColor = System.Drawing.Color.Black
        Me.lblDCV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDCV.Location = New System.Drawing.Point(395, 195)
        Me.lblDCV.Name = "lblDCV"
        Me.lblDCV.Size = New System.Drawing.Size(165, 25)
        Me.lblDCV.TabIndex = 444
        Me.lblDCV.Text = "Dコンベヤ"
        Me.lblDCV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTANA1F
        '
        Me.lblTANA1F.BackColor = System.Drawing.Color.Salmon
        Me.lblTANA1F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTANA1F.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTANA1F.ForeColor = System.Drawing.Color.Black
        Me.lblTANA1F.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTANA1F.Location = New System.Drawing.Point(220, 290)
        Me.lblTANA1F.Name = "lblTANA1F"
        Me.lblTANA1F.Size = New System.Drawing.Size(165, 25)
        Me.lblTANA1F.TabIndex = 443
        Me.lblTANA1F.Text = "入出棚コンベヤ"
        Me.lblTANA1F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGAIBU
        '
        Me.lblGAIBU.BackColor = System.Drawing.Color.Salmon
        Me.lblGAIBU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGAIBU.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGAIBU.ForeColor = System.Drawing.Color.Black
        Me.lblGAIBU.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblGAIBU.Location = New System.Drawing.Point(395, 290)
        Me.lblGAIBU.Name = "lblGAIBU"
        Me.lblGAIBU.Size = New System.Drawing.Size(165, 25)
        Me.lblGAIBU.TabIndex = 442
        Me.lblGAIBU.Text = "外部入出庫コンベヤ"
        Me.lblGAIBU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTRUCK
        '
        Me.lblTRUCK.BackColor = System.Drawing.Color.Salmon
        Me.lblTRUCK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTRUCK.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTRUCK.ForeColor = System.Drawing.Color.Black
        Me.lblTRUCK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTRUCK.Location = New System.Drawing.Point(395, 326)
        Me.lblTRUCK.Name = "lblTRUCK"
        Me.lblTRUCK.Size = New System.Drawing.Size(165, 25)
        Me.lblTRUCK.TabIndex = 439
        Me.lblTRUCK.Text = "トラックローダ"
        Me.lblTRUCK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRTN1F
        '
        Me.lblRTN1F.BackColor = System.Drawing.Color.Salmon
        Me.lblRTN1F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRTN1F.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblRTN1F.ForeColor = System.Drawing.Color.Black
        Me.lblRTN1F.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRTN1F.Location = New System.Drawing.Point(46, 290)
        Me.lblRTN1F.Name = "lblRTN1F"
        Me.lblRTN1F.Size = New System.Drawing.Size(165, 25)
        Me.lblRTN1F.TabIndex = 437
        Me.lblRTN1F.Text = "RTN"
        Me.lblRTN1F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSYUKKA1F
        '
        Me.lblSYUKKA1F.BackColor = System.Drawing.Color.Salmon
        Me.lblSYUKKA1F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSYUKKA1F.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSYUKKA1F.ForeColor = System.Drawing.Color.Black
        Me.lblSYUKKA1F.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSYUKKA1F.Location = New System.Drawing.Point(220, 326)
        Me.lblSYUKKA1F.Name = "lblSYUKKA1F"
        Me.lblSYUKKA1F.Size = New System.Drawing.Size(165, 25)
        Me.lblSYUKKA1F.TabIndex = 438
        Me.lblSYUKKA1F.Text = "出荷コンベヤ"
        Me.lblSYUKKA1F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(46, 250)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 32)
        Me.Label11.TabIndex = 441
        Me.Label11.Text = "１Ｆ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label12.Location = New System.Drawing.Point(21, 266)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(550, 96)
        Me.Label12.TabIndex = 440
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE14
        '
        Me.lblCRANE14.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE14.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE14.Location = New System.Drawing.Point(486, 465)
        Me.lblCRANE14.Name = "lblCRANE14"
        Me.lblCRANE14.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE14.TabIndex = 436
        Me.lblCRANE14.Text = "14号"
        Me.lblCRANE14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE13
        '
        Me.lblCRANE13.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE13.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE13.Location = New System.Drawing.Point(414, 465)
        Me.lblCRANE13.Name = "lblCRANE13"
        Me.lblCRANE13.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE13.TabIndex = 435
        Me.lblCRANE13.Text = "13号"
        Me.lblCRANE13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE12
        '
        Me.lblCRANE12.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE12.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE12.Location = New System.Drawing.Point(342, 465)
        Me.lblCRANE12.Name = "lblCRANE12"
        Me.lblCRANE12.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE12.TabIndex = 434
        Me.lblCRANE12.Text = "12号"
        Me.lblCRANE12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE7
        '
        Me.lblCRANE7.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE7.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE7.Location = New System.Drawing.Point(486, 417)
        Me.lblCRANE7.Name = "lblCRANE7"
        Me.lblCRANE7.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE7.TabIndex = 433
        Me.lblCRANE7.Text = "７号"
        Me.lblCRANE7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE6
        '
        Me.lblCRANE6.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE6.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE6.Location = New System.Drawing.Point(414, 417)
        Me.lblCRANE6.Name = "lblCRANE6"
        Me.lblCRANE6.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE6.TabIndex = 432
        Me.lblCRANE6.Text = "６号"
        Me.lblCRANE6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSPURT
        '
        Me.lblSPURT.BackColor = System.Drawing.Color.Salmon
        Me.lblSPURT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSPURT.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSPURT.ForeColor = System.Drawing.Color.Black
        Me.lblSPURT.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSPURT.Location = New System.Drawing.Point(21, 29)
        Me.lblSPURT.Name = "lblSPURT"
        Me.lblSPURT.Size = New System.Drawing.Size(314, 40)
        Me.lblSPURT.TabIndex = 399
        Me.lblSPURT.Text = "上位システム"
        Me.lblSPURT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRTN2F
        '
        Me.lblRTN2F.BackColor = System.Drawing.Color.Salmon
        Me.lblRTN2F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRTN2F.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblRTN2F.ForeColor = System.Drawing.Color.Black
        Me.lblRTN2F.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRTN2F.Location = New System.Drawing.Point(46, 195)
        Me.lblRTN2F.Name = "lblRTN2F"
        Me.lblRTN2F.Size = New System.Drawing.Size(165, 25)
        Me.lblRTN2F.TabIndex = 413
        Me.lblRTN2F.Text = "RTN"
        Me.lblRTN2F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTANA2F
        '
        Me.lblTANA2F.BackColor = System.Drawing.Color.Salmon
        Me.lblTANA2F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTANA2F.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTANA2F.ForeColor = System.Drawing.Color.Black
        Me.lblTANA2F.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTANA2F.Location = New System.Drawing.Point(220, 195)
        Me.lblTANA2F.Name = "lblTANA2F"
        Me.lblTANA2F.Size = New System.Drawing.Size(165, 25)
        Me.lblTANA2F.TabIndex = 414
        Me.lblTANA2F.Text = "入出棚コンベヤ"
        Me.lblTANA2F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(46, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 32)
        Me.Label10.TabIndex = 430
        Me.Label10.Text = "２Ｆ"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(21, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(550, 68)
        Me.Label9.TabIndex = 429
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Label30.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label30.Location = New System.Drawing.Point(46, 371)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(107, 32)
        Me.Label30.TabIndex = 427
        Me.Label30.Text = "自動倉庫"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE11
        '
        Me.lblCRANE11.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE11.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE11.Location = New System.Drawing.Point(270, 465)
        Me.lblCRANE11.Name = "lblCRANE11"
        Me.lblCRANE11.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE11.TabIndex = 411
        Me.lblCRANE11.Text = "11号"
        Me.lblCRANE11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE10
        '
        Me.lblCRANE10.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE10.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE10.Location = New System.Drawing.Point(198, 465)
        Me.lblCRANE10.Name = "lblCRANE10"
        Me.lblCRANE10.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE10.TabIndex = 410
        Me.lblCRANE10.Text = "10号"
        Me.lblCRANE10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE9
        '
        Me.lblCRANE9.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE9.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE9.Location = New System.Drawing.Point(126, 465)
        Me.lblCRANE9.Name = "lblCRANE9"
        Me.lblCRANE9.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE9.TabIndex = 409
        Me.lblCRANE9.Text = "９号"
        Me.lblCRANE9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE8
        '
        Me.lblCRANE8.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE8.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE8.Location = New System.Drawing.Point(54, 465)
        Me.lblCRANE8.Name = "lblCRANE8"
        Me.lblCRANE8.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE8.TabIndex = 408
        Me.lblCRANE8.Text = "８号"
        Me.lblCRANE8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE5
        '
        Me.lblCRANE5.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE5.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE5.Location = New System.Drawing.Point(342, 417)
        Me.lblCRANE5.Name = "lblCRANE5"
        Me.lblCRANE5.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE5.TabIndex = 407
        Me.lblCRANE5.Text = "５号"
        Me.lblCRANE5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE4
        '
        Me.lblCRANE4.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE4.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE4.Location = New System.Drawing.Point(270, 417)
        Me.lblCRANE4.Name = "lblCRANE4"
        Me.lblCRANE4.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE4.TabIndex = 406
        Me.lblCRANE4.Text = "４号"
        Me.lblCRANE4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE3
        '
        Me.lblCRANE3.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE3.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE3.Location = New System.Drawing.Point(198, 417)
        Me.lblCRANE3.Name = "lblCRANE3"
        Me.lblCRANE3.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE3.TabIndex = 405
        Me.lblCRANE3.Text = "３号"
        Me.lblCRANE3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE2
        '
        Me.lblCRANE2.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE2.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE2.Location = New System.Drawing.Point(126, 417)
        Me.lblCRANE2.Name = "lblCRANE2"
        Me.lblCRANE2.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE2.TabIndex = 404
        Me.lblCRANE2.Text = "２号"
        Me.lblCRANE2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRANE1
        '
        Me.lblCRANE1.BackColor = System.Drawing.Color.Salmon
        Me.lblCRANE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE1.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE1.Location = New System.Drawing.Point(54, 417)
        Me.lblCRANE1.Name = "lblCRANE1"
        Me.lblCRANE1.Size = New System.Drawing.Size(60, 40)
        Me.lblCRANE1.TabIndex = 402
        Me.lblCRANE1.Text = "１号"
        Me.lblCRANE1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label28.Location = New System.Drawing.Point(22, 387)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(549, 136)
        Me.Label28.TabIndex = 426
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTAKATANA_NUM
        '
        Me.lblTAKATANA_NUM.BackColor = System.Drawing.Color.White
        Me.lblTAKATANA_NUM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTAKATANA_NUM.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTAKATANA_NUM.ForeColor = System.Drawing.Color.Black
        Me.lblTAKATANA_NUM.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTAKATANA_NUM.Location = New System.Drawing.Point(451, 60)
        Me.lblTAKATANA_NUM.Name = "lblTAKATANA_NUM"
        Me.lblTAKATANA_NUM.Size = New System.Drawing.Size(114, 27)
        Me.lblTAKATANA_NUM.TabIndex = 422
        Me.lblTAKATANA_NUM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKEI_NUM
        '
        Me.lblKEI_NUM.BackColor = System.Drawing.Color.White
        Me.lblKEI_NUM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKEI_NUM.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKEI_NUM.ForeColor = System.Drawing.Color.Black
        Me.lblKEI_NUM.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblKEI_NUM.Location = New System.Drawing.Point(451, 109)
        Me.lblKEI_NUM.Name = "lblKEI_NUM"
        Me.lblKEI_NUM.Size = New System.Drawing.Size(114, 27)
        Me.lblKEI_NUM.TabIndex = 425
        Me.lblKEI_NUM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Location = New System.Drawing.Point(384, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 27)
        Me.Label8.TabIndex = 424
        Me.Label8.Text = "計"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblServer
        '
        Me.lblServer.BackColor = System.Drawing.Color.Salmon
        Me.lblServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblServer.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblServer.ForeColor = System.Drawing.Color.Black
        Me.lblServer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblServer.Location = New System.Drawing.Point(21, 87)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(314, 40)
        Me.lblServer.TabIndex = 397
        Me.lblServer.Text = "マテスト"
        Me.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(173, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 30)
        Me.Label4.TabIndex = 418
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(173, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 20)
        Me.Label2.TabIndex = 401
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHIKUTANA_NUM
        '
        Me.lblHIKUTANA_NUM.BackColor = System.Drawing.Color.White
        Me.lblHIKUTANA_NUM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHIKUTANA_NUM.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHIKUTANA_NUM.ForeColor = System.Drawing.Color.Black
        Me.lblHIKUTANA_NUM.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblHIKUTANA_NUM.Location = New System.Drawing.Point(451, 85)
        Me.lblHIKUTANA_NUM.Name = "lblHIKUTANA_NUM"
        Me.lblHIKUTANA_NUM.Size = New System.Drawing.Size(114, 27)
        Me.lblHIKUTANA_NUM.TabIndex = 423
        Me.lblHIKUTANA_NUM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Label19.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label19.Location = New System.Drawing.Point(384, 29)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 32)
        Me.Label19.TabIndex = 416
        Me.Label19.Text = "棚種別"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Label18.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label18.Location = New System.Drawing.Point(451, 29)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 32)
        Me.Label18.TabIndex = 417
        Me.Label18.Text = "空ブロック数"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label17.Location = New System.Drawing.Point(384, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 27)
        Me.Label17.TabIndex = 419
        Me.Label17.Text = "高棚"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label16.Location = New System.Drawing.Point(384, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 27)
        Me.Label16.TabIndex = 421
        Me.Label16.Text = "低棚"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(14, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(567, 413)
        Me.Label7.TabIndex = 428
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FRM_202000
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grdList)
        Me.Name = "FRM_202000"
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmr202000 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Menu_Kiri As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Hukki As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRTN2F As System.Windows.Forms.Label
    Friend WithEvents lblTANA2F As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE11 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE10 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE9 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE8 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE5 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE4 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE3 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE2 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE1 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblTAKATANA_NUM As System.Windows.Forms.Label
    Friend WithEvents lblKEI_NUM As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSPURT As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHIKUTANA_NUM As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE7 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE6 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE14 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE13 As System.Windows.Forms.Label
    Friend WithEvents lblCRANE12 As System.Windows.Forms.Label
    Friend WithEvents lblGAIBU As System.Windows.Forms.Label
    Friend WithEvents lblTRUCK As System.Windows.Forms.Label
    Friend WithEvents lblRTN1F As System.Windows.Forms.Label
    Friend WithEvents lblSYUKKA1F As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTANA1F As System.Windows.Forms.Label
    Friend WithEvents lblDCV As System.Windows.Forms.Label

End Class
