<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303010
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblContinue = New System.Windows.Forms.Label
        Me.cboFTRK_BUF_NO_ZAIKO = New MateCommon.cmpMComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboFTRK_BUF_NO_NYUUKO = New MateCommon.cmpMComboBox
        Me.lblSTMode = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tmr303010 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbtnXDSPIN_SITEI_None = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboFRAC_DAN = New MateCommon.cmpMComboBox
        Me.cboFRAC_REN = New MateCommon.cmpMComboBox
        Me.cboFRAC_RETU = New MateCommon.cmpMComboBox
        Me.rbtnXDSPIN_SITEI_BLOCK = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cboXMAKER_CD = New MateCommon.cmpMComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpFARRIVE_DT = New GamenCommon.cmpMDateTimePicker_DT
        Me.cboXKENPIN_KUBUN = New MateCommon.cmpMComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFIN_KUBUN = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboXPROD_LINE = New MateCommon.cmpMComboBox
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.cboFHORYU_KUBUN = New MateCommon.cmpMComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboXKENSA_KUBUN = New MateCommon.cmpMComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(705, 672)
        Me.cmdF3.Size = New System.Drawing.Size(140, 43)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(427, 672)
        Me.cmdF2.Size = New System.Drawing.Size(124, 43)
        Me.cmdF2.TabIndex = 31
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(168, 672)
        Me.cmdF1.Size = New System.Drawing.Size(124, 43)
        Me.cmdF1.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblContinue)
        Me.GroupBox1.Controls.Add(Me.cboFTRK_BUF_NO_ZAIKO)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.cboFTRK_BUF_NO_NYUUKO)
        Me.GroupBox1.Controls.Add(Me.lblSTMode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1074, 106)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblContinue
        '
        Me.lblContinue.BackColor = System.Drawing.Color.Red
        Me.lblContinue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblContinue.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblContinue.ForeColor = System.Drawing.Color.White
        Me.lblContinue.Location = New System.Drawing.Point(647, 63)
        Me.lblContinue.Name = "lblContinue"
        Me.lblContinue.Size = New System.Drawing.Size(152, 31)
        Me.lblContinue.TabIndex = 219
        Me.lblContinue.Text = "連続入庫中"
        Me.lblContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblContinue.Visible = False
        '
        'cboFTRK_BUF_NO_ZAIKO
        '
        Me.cboFTRK_BUF_NO_ZAIKO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO_ZAIKO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO_ZAIKO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO_ZAIKO.IntegralHeight = False
        Me.cboFTRK_BUF_NO_ZAIKO.Location = New System.Drawing.Point(171, 17)
        Me.cboFTRK_BUF_NO_ZAIKO.Name = "cboFTRK_BUF_NO_ZAIKO"
        Me.cboFTRK_BUF_NO_ZAIKO.Size = New System.Drawing.Size(244, 28)
        Me.cboFTRK_BUF_NO_ZAIKO.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(32, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(139, 32)
        Me.Label20.TabIndex = 217
        Me.Label20.Text = "在庫エリア:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFTRK_BUF_NO_NYUUKO
        '
        Me.cboFTRK_BUF_NO_NYUUKO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO_NYUUKO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO_NYUUKO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO_NYUUKO.IntegralHeight = False
        Me.cboFTRK_BUF_NO_NYUUKO.Location = New System.Drawing.Point(171, 66)
        Me.cboFTRK_BUF_NO_NYUUKO.Name = "cboFTRK_BUF_NO_NYUUKO"
        Me.cboFTRK_BUF_NO_NYUUKO.Size = New System.Drawing.Size(244, 28)
        Me.cboFTRK_BUF_NO_NYUUKO.TabIndex = 1
        '
        'lblSTMode
        '
        Me.lblSTMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSTMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSTMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSTMode.ForeColor = System.Drawing.Color.Black
        Me.lblSTMode.Location = New System.Drawing.Point(456, 64)
        Me.lblSTMode.Name = "lblSTMode"
        Me.lblSTMode.Size = New System.Drawing.Size(152, 31)
        Me.lblSTMode.TabIndex = 216
        Me.lblSTMode.Text = "出庫モード"
        Me.lblSTMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(32, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "入庫ST:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmr303010
        '
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbtnXDSPIN_SITEI_None)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cboFRAC_DAN)
        Me.GroupBox3.Controls.Add(Me.cboFRAC_REN)
        Me.GroupBox3.Controls.Add(Me.cboFRAC_RETU)
        Me.GroupBox3.Controls.Add(Me.rbtnXDSPIN_SITEI_BLOCK)
        Me.GroupBox3.Location = New System.Drawing.Point(169, 204)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1073, 110)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'rbtnXDSPIN_SITEI_None
        '
        Me.rbtnXDSPIN_SITEI_None.AutoSize = True
        Me.rbtnXDSPIN_SITEI_None.Checked = True
        Me.rbtnXDSPIN_SITEI_None.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.rbtnXDSPIN_SITEI_None.ForeColor = System.Drawing.Color.Black
        Me.rbtnXDSPIN_SITEI_None.Location = New System.Drawing.Point(16, 25)
        Me.rbtnXDSPIN_SITEI_None.Name = "rbtnXDSPIN_SITEI_None"
        Me.rbtnXDSPIN_SITEI_None.Size = New System.Drawing.Size(198, 24)
        Me.rbtnXDSPIN_SITEI_None.TabIndex = 2
        Me.rbtnXDSPIN_SITEI_None.TabStop = True
        Me.rbtnXDSPIN_SITEI_None.Text = " 棚指定なし    :"
        Me.rbtnXDSPIN_SITEI_None.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(388, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 32)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(289, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 32)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFRAC_DAN
        '
        Me.cboFRAC_DAN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_DAN.Enabled = False
        Me.cboFRAC_DAN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_DAN.FormattingEnabled = True
        Me.cboFRAC_DAN.IntegralHeight = False
        Me.cboFRAC_DAN.Location = New System.Drawing.Point(416, 67)
        Me.cboFRAC_DAN.Name = "cboFRAC_DAN"
        Me.cboFRAC_DAN.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_DAN.TabIndex = 6
        '
        'cboFRAC_REN
        '
        Me.cboFRAC_REN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_REN.Enabled = False
        Me.cboFRAC_REN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_REN.FormattingEnabled = True
        Me.cboFRAC_REN.IntegralHeight = False
        Me.cboFRAC_REN.Location = New System.Drawing.Point(317, 67)
        Me.cboFRAC_REN.Name = "cboFRAC_REN"
        Me.cboFRAC_REN.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_REN.TabIndex = 5
        '
        'cboFRAC_RETU
        '
        Me.cboFRAC_RETU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_RETU.Enabled = False
        Me.cboFRAC_RETU.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_RETU.FormattingEnabled = True
        Me.cboFRAC_RETU.IntegralHeight = False
        Me.cboFRAC_RETU.Location = New System.Drawing.Point(218, 67)
        Me.cboFRAC_RETU.Name = "cboFRAC_RETU"
        Me.cboFRAC_RETU.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_RETU.TabIndex = 4
        '
        'rbtnXDSPIN_SITEI_BLOCK
        '
        Me.rbtnXDSPIN_SITEI_BLOCK.AutoSize = True
        Me.rbtnXDSPIN_SITEI_BLOCK.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.rbtnXDSPIN_SITEI_BLOCK.ForeColor = System.Drawing.Color.Black
        Me.rbtnXDSPIN_SITEI_BLOCK.Location = New System.Drawing.Point(16, 67)
        Me.rbtnXDSPIN_SITEI_BLOCK.Name = "rbtnXDSPIN_SITEI_BLOCK"
        Me.rbtnXDSPIN_SITEI_BLOCK.Size = New System.Drawing.Size(199, 24)
        Me.rbtnXDSPIN_SITEI_BLOCK.TabIndex = 3
        Me.rbtnXDSPIN_SITEI_BLOCK.Text = " 棚ﾌﾞﾛｯｸ指定 　:"
        Me.rbtnXDSPIN_SITEI_BLOCK.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboXMAKER_CD)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.dtpFARRIVE_DT)
        Me.GroupBox4.Controls.Add(Me.cboXKENPIN_KUBUN)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.cboFIN_KUBUN)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.cboXPROD_LINE)
        Me.GroupBox4.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox4.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox4.Controls.Add(Me.cboFHORYU_KUBUN)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.cboXKENSA_KUBUN)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(168, 320)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1074, 263)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'cboXMAKER_CD
        '
        Me.cboXMAKER_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXMAKER_CD.DropDownWidth = 150
        Me.cboXMAKER_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboXMAKER_CD.FormattingEnabled = True
        Me.cboXMAKER_CD.IntegralHeight = False
        Me.cboXMAKER_CD.Location = New System.Drawing.Point(692, 112)
        Me.cboXMAKER_CD.Name = "cboXMAKER_CD"
        Me.cboXMAKER_CD.Size = New System.Drawing.Size(225, 27)
        Me.cboXMAKER_CD.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(35, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(169, 32)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "在庫発生日時:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFARRIVE_DT
        '
        Me.dtpFARRIVE_DT.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFARRIVE_DT.Location = New System.Drawing.Point(210, 63)
        Me.dtpFARRIVE_DT.Name = "dtpFARRIVE_DT"
        Me.dtpFARRIVE_DT.Size = New System.Drawing.Size(299, 30)
        Me.dtpFARRIVE_DT.TabIndex = 11
        Me.dtpFARRIVE_DT.TimeComboDisp = True
        Me.dtpFARRIVE_DT.userChecked = True
        Me.dtpFARRIVE_DT.userShowCheckBox = True
        '
        'cboXKENPIN_KUBUN
        '
        Me.cboXKENPIN_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXKENPIN_KUBUN.DropDownWidth = 150
        Me.cboXKENPIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboXKENPIN_KUBUN.FormattingEnabled = True
        Me.cboXKENPIN_KUBUN.IntegralHeight = False
        Me.cboXKENPIN_KUBUN.Location = New System.Drawing.Point(692, 210)
        Me.cboXKENPIN_KUBUN.Name = "cboXKENPIN_KUBUN"
        Me.cboXKENPIN_KUBUN.Size = New System.Drawing.Size(225, 27)
        Me.cboXKENPIN_KUBUN.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(582, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 20)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "検品区分:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFIN_KUBUN
        '
        Me.cboFIN_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIN_KUBUN.DropDownWidth = 150
        Me.cboFIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFIN_KUBUN.FormattingEnabled = True
        Me.cboFIN_KUBUN.IntegralHeight = False
        Me.cboFIN_KUBUN.Location = New System.Drawing.Point(210, 209)
        Me.cboFIN_KUBUN.Name = "cboFIN_KUBUN"
        Me.cboFIN_KUBUN.Size = New System.Drawing.Size(225, 27)
        Me.cboFIN_KUBUN.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(100, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "入庫区分:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(517, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 32)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "メーカーコード:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(39, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 32)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "品名ｺｰﾄﾞ/記号:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXPROD_LINE
        '
        Me.cboXPROD_LINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXPROD_LINE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXPROD_LINE.FormattingEnabled = True
        Me.cboXPROD_LINE.IntegralHeight = False
        Me.cboXPROD_LINE.Location = New System.Drawing.Point(210, 110)
        Me.cboXPROD_LINE.Name = "cboXPROD_LINE"
        Me.cboXPROD_LINE.Size = New System.Drawing.Size(225, 28)
        Me.cboXPROD_LINE.TabIndex = 12
        '
        'cboFHINMEI_CD
        '
        Me.cboFHINMEI_CD.ArticleShortNameLabel = Nothing
        Me.cboFHINMEI_CD.ArticleTypeCode = Nothing
        Me.cboFHINMEI_CD.CboDispNameType = GamenCommon.cmpCboFHINMEI_CD.DispNameType.FullName
        Me.cboFHINMEI_CD.Col1Width = 150
        Me.cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedTableData
        Me.cboFHINMEI_CD.conn = Nothing
        Me.cboFHINMEI_CD.FIND_FLAG = False
        Me.cboFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFHINMEI_CD.FormattingEnabled = True
        Me.cboFHINMEI_CD.FRES_KIND = ""
        Me.cboFHINMEI_CD.FTRK_BUF_NO = Nothing
        Me.cboFHINMEI_CD.HinmeiKind = Nothing
        Me.cboFHINMEI_CD.HinmeiLabel = Nothing
        Me.cboFHINMEI_CD.HinmeiVisible = True
        Me.cboFHINMEI_CD.IntegralHeight = False
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(210, 18)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(165, 28)
        Me.cboFHINMEI_CD.TabIndex = 10
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XKANRI_KUBUN = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(383, 18)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 16
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFHORYU_KUBUN
        '
        Me.cboFHORYU_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFHORYU_KUBUN.DropDownWidth = 150
        Me.cboFHORYU_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFHORYU_KUBUN.FormattingEnabled = True
        Me.cboFHORYU_KUBUN.IntegralHeight = False
        Me.cboFHORYU_KUBUN.Location = New System.Drawing.Point(692, 161)
        Me.cboFHORYU_KUBUN.Name = "cboFHORYU_KUBUN"
        Me.cboFHORYU_KUBUN.Size = New System.Drawing.Size(225, 27)
        Me.cboFHORYU_KUBUN.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(582, 163)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 20)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "保留区分:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXKENSA_KUBUN
        '
        Me.cboXKENSA_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXKENSA_KUBUN.DropDownWidth = 150
        Me.cboXKENSA_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboXKENSA_KUBUN.FormattingEnabled = True
        Me.cboXKENSA_KUBUN.IntegralHeight = False
        Me.cboXKENSA_KUBUN.Location = New System.Drawing.Point(210, 160)
        Me.cboXKENSA_KUBUN.Name = "cboXKENSA_KUBUN"
        Me.cboXKENSA_KUBUN.Size = New System.Drawing.Size(225, 27)
        Me.cboXKENSA_KUBUN.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(100, 163)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "検査区分:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(35, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 32)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "生産ﾗｲﾝNo.:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_303010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_303010"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFTRK_BUF_NO_NYUUKO As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tmr303010 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSTMode As System.Windows.Forms.Label
    Friend WithEvents rbtnXDSPIN_SITEI_BLOCK As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboFRAC_DAN As MateCommon.cmpMComboBox
    Friend WithEvents cboFRAC_REN As MateCommon.cmpMComboBox
    Friend WithEvents cboFRAC_RETU As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboFHORYU_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboXKENSA_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents rbtnXDSPIN_SITEI_None As System.Windows.Forms.RadioButton
    Friend WithEvents cboXPROD_LINE As MateCommon.cmpMComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboFTRK_BUF_NO_ZAIKO As MateCommon.cmpMComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboXKENPIN_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFIN_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFARRIVE_DT As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblContinue As System.Windows.Forms.Label
    Friend WithEvents cboXMAKER_CD As MateCommon.cmpMComboBox

End Class
