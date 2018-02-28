<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_305010
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
        Me.cboFTRK_BUF_NO = New MateCommon.cmpMComboBox
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.txtXPALLET_NO_TO = New MateCommon.cmpMTextBoxString
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtXPALLET_NO_FM = New MateCommon.cmpMTextBoxString
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtXLINE_NO = New MateCommon.cmpMTextBoxString
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboXSEIZOU_DT = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtFRAC_DAN_TO = New MateCommon.cmpMTextBoxString
        Me.txtFRAC_REN_TO = New MateCommon.cmpMTextBoxString
        Me.txtFRAC_RETU_TO = New MateCommon.cmpMTextBoxString
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtFRAC_DAN_FM = New MateCommon.cmpMTextBoxString
        Me.txtFRAC_REN_FM = New MateCommon.cmpMTextBoxString
        Me.txtFRAC_RETU_FM = New MateCommon.cmpMTextBoxString
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkHINMEI = New System.Windows.Forms.RadioButton
        Me.chkTANA = New System.Windows.Forms.RadioButton
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(280, 664)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(170, 664)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1136, 104)
        '
        'cboFTRK_BUF_NO
        '
        Me.cboFTRK_BUF_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO.IntegralHeight = False
        Me.cboFTRK_BUF_NO.Location = New System.Drawing.Point(257, 17)
        Me.cboFTRK_BUF_NO.Name = "cboFTRK_BUF_NO"
        Me.cboFTRK_BUF_NO.Size = New System.Drawing.Size(301, 28)
        Me.cboFTRK_BUF_NO.TabIndex = 1
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(1003, 679)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(239, 78)
        Me.grdList.TabIndex = 23
        Me.grdList.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFTRK_BUF_NO)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(192, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1056, 66)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(41, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(216, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "棚卸しST:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox2.Controls.Add(Me.txtXPALLET_NO_TO)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtXPALLET_NO_FM)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtXLINE_NO)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboXSEIZOU_DT)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(191, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1058, 280)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "品名指定"
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(258, 44)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(152, 28)
        Me.cboFHINMEI_CD.TabIndex = 1
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XKANRI_KUBUN = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
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
        Me.txtXPALLET_NO_TO.Location = New System.Drawing.Point(360, 182)
        Me.txtXPALLET_NO_TO.MaxLength = 4
        Me.txtXPALLET_NO_TO.MaxLengthByte = 4
        Me.txtXPALLET_NO_TO.Name = "txtXPALLET_NO_TO"
        Me.txtXPALLET_NO_TO.RegexCustomFalse = Nothing
        Me.txtXPALLET_NO_TO.RegexCustomTrue = Nothing
        Me.txtXPALLET_NO_TO.Size = New System.Drawing.Size(64, 27)
        Me.txtXPALLET_NO_TO.TabIndex = 352
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(322, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 32)
        Me.Label8.TabIndex = 351
        Me.Label8.Text = "～"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.txtXPALLET_NO_FM.Location = New System.Drawing.Point(258, 182)
        Me.txtXPALLET_NO_FM.MaxLength = 4
        Me.txtXPALLET_NO_FM.MaxLengthByte = 4
        Me.txtXPALLET_NO_FM.Name = "txtXPALLET_NO_FM"
        Me.txtXPALLET_NO_FM.RegexCustomFalse = Nothing
        Me.txtXPALLET_NO_FM.RegexCustomTrue = Nothing
        Me.txtXPALLET_NO_FM.Size = New System.Drawing.Size(62, 27)
        Me.txtXPALLET_NO_FM.TabIndex = 350
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(119, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 32)
        Me.Label7.TabIndex = 349
        Me.Label7.Text = "ﾊﾟﾚｯﾄ№:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXLINE_NO
        '
        Me.txtXLINE_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXLINE_NO.EnabledFull = False
        Me.txtXLINE_NO.EnabledFullAlphabetLower = False
        Me.txtXLINE_NO.EnabledFullAlphabetUpper = False
        Me.txtXLINE_NO.EnabledFullHiragana = False
        Me.txtXLINE_NO.EnabledFullKatakana = False
        Me.txtXLINE_NO.EnabledFullNumber = False
        Me.txtXLINE_NO.EnabledHalf = True
        Me.txtXLINE_NO.EnabledHalfAlphabetLower = True
        Me.txtXLINE_NO.EnabledHalfAlphabetUpper = True
        Me.txtXLINE_NO.EnabledHalfKatakana = False
        Me.txtXLINE_NO.EnabledHalfNumber = True
        Me.txtXLINE_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXLINE_NO.Location = New System.Drawing.Point(258, 140)
        Me.txtXLINE_NO.MaxLength = 6
        Me.txtXLINE_NO.MaxLengthByte = 6
        Me.txtXLINE_NO.Name = "txtXLINE_NO"
        Me.txtXLINE_NO.RegexCustomFalse = Nothing
        Me.txtXLINE_NO.RegexCustomTrue = Nothing
        Me.txtXLINE_NO.Size = New System.Drawing.Size(86, 27)
        Me.txtXLINE_NO.TabIndex = 348
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(119, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 32)
        Me.Label6.TabIndex = 347
        Me.Label6.Text = "ﾗｲﾝ№:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSEIZOU_DT
        '
        Me.cboXSEIZOU_DT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSEIZOU_DT.FormattingEnabled = True
        Me.cboXSEIZOU_DT.IntegralHeight = False
        Me.cboXSEIZOU_DT.Location = New System.Drawing.Point(258, 91)
        Me.cboXSEIZOU_DT.Name = "cboXSEIZOU_DT"
        Me.cboXSEIZOU_DT.Size = New System.Drawing.Size(158, 28)
        Me.cboXSEIZOU_DT.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(42, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(216, 32)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "製造年月日:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(408, 42)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(576, 32)
        Me.lblFHINMEI.TabIndex = 2
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(42, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "品名ｺｰﾄﾞ:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txtFRAC_DAN_TO)
        Me.GroupBox3.Controls.Add(Me.txtFRAC_REN_TO)
        Me.GroupBox3.Controls.Add(Me.txtFRAC_RETU_TO)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtFRAC_DAN_FM)
        Me.GroupBox3.Controls.Add(Me.txtFRAC_REN_FM)
        Me.GroupBox3.Controls.Add(Me.txtFRAC_RETU_FM)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(191, 451)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1058, 130)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "棚範囲指定"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(529, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 32)
        Me.Label13.TabIndex = 363
        Me.Label13.Text = "段"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(484, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 32)
        Me.Label14.TabIndex = 362
        Me.Label14.Text = "連"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(439, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 32)
        Me.Label15.TabIndex = 361
        Me.Label15.Text = "列"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFRAC_DAN_TO
        '
        Me.txtFRAC_DAN_TO.BackColorMask = System.Drawing.Color.Empty
        Me.txtFRAC_DAN_TO.EnabledFull = False
        Me.txtFRAC_DAN_TO.EnabledFullAlphabetLower = False
        Me.txtFRAC_DAN_TO.EnabledFullAlphabetUpper = False
        Me.txtFRAC_DAN_TO.EnabledFullHiragana = False
        Me.txtFRAC_DAN_TO.EnabledFullKatakana = False
        Me.txtFRAC_DAN_TO.EnabledFullNumber = False
        Me.txtFRAC_DAN_TO.EnabledHalf = True
        Me.txtFRAC_DAN_TO.EnabledHalfAlphabetLower = True
        Me.txtFRAC_DAN_TO.EnabledHalfAlphabetUpper = True
        Me.txtFRAC_DAN_TO.EnabledHalfKatakana = False
        Me.txtFRAC_DAN_TO.EnabledHalfNumber = True
        Me.txtFRAC_DAN_TO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFRAC_DAN_TO.Location = New System.Drawing.Point(529, 57)
        Me.txtFRAC_DAN_TO.MaxLength = 2
        Me.txtFRAC_DAN_TO.MaxLengthByte = 2
        Me.txtFRAC_DAN_TO.Name = "txtFRAC_DAN_TO"
        Me.txtFRAC_DAN_TO.RegexCustomFalse = Nothing
        Me.txtFRAC_DAN_TO.RegexCustomTrue = Nothing
        Me.txtFRAC_DAN_TO.Size = New System.Drawing.Size(39, 27)
        Me.txtFRAC_DAN_TO.TabIndex = 360
        '
        'txtFRAC_REN_TO
        '
        Me.txtFRAC_REN_TO.BackColorMask = System.Drawing.Color.Empty
        Me.txtFRAC_REN_TO.EnabledFull = False
        Me.txtFRAC_REN_TO.EnabledFullAlphabetLower = False
        Me.txtFRAC_REN_TO.EnabledFullAlphabetUpper = False
        Me.txtFRAC_REN_TO.EnabledFullHiragana = False
        Me.txtFRAC_REN_TO.EnabledFullKatakana = False
        Me.txtFRAC_REN_TO.EnabledFullNumber = False
        Me.txtFRAC_REN_TO.EnabledHalf = True
        Me.txtFRAC_REN_TO.EnabledHalfAlphabetLower = True
        Me.txtFRAC_REN_TO.EnabledHalfAlphabetUpper = True
        Me.txtFRAC_REN_TO.EnabledHalfKatakana = False
        Me.txtFRAC_REN_TO.EnabledHalfNumber = True
        Me.txtFRAC_REN_TO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFRAC_REN_TO.Location = New System.Drawing.Point(484, 57)
        Me.txtFRAC_REN_TO.MaxLength = 2
        Me.txtFRAC_REN_TO.MaxLengthByte = 2
        Me.txtFRAC_REN_TO.Name = "txtFRAC_REN_TO"
        Me.txtFRAC_REN_TO.RegexCustomFalse = Nothing
        Me.txtFRAC_REN_TO.RegexCustomTrue = Nothing
        Me.txtFRAC_REN_TO.Size = New System.Drawing.Size(39, 27)
        Me.txtFRAC_REN_TO.TabIndex = 359
        '
        'txtFRAC_RETU_TO
        '
        Me.txtFRAC_RETU_TO.BackColorMask = System.Drawing.Color.Empty
        Me.txtFRAC_RETU_TO.EnabledFull = False
        Me.txtFRAC_RETU_TO.EnabledFullAlphabetLower = False
        Me.txtFRAC_RETU_TO.EnabledFullAlphabetUpper = False
        Me.txtFRAC_RETU_TO.EnabledFullHiragana = False
        Me.txtFRAC_RETU_TO.EnabledFullKatakana = False
        Me.txtFRAC_RETU_TO.EnabledFullNumber = False
        Me.txtFRAC_RETU_TO.EnabledHalf = True
        Me.txtFRAC_RETU_TO.EnabledHalfAlphabetLower = True
        Me.txtFRAC_RETU_TO.EnabledHalfAlphabetUpper = True
        Me.txtFRAC_RETU_TO.EnabledHalfKatakana = False
        Me.txtFRAC_RETU_TO.EnabledHalfNumber = True
        Me.txtFRAC_RETU_TO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFRAC_RETU_TO.Location = New System.Drawing.Point(439, 57)
        Me.txtFRAC_RETU_TO.MaxLength = 2
        Me.txtFRAC_RETU_TO.MaxLengthByte = 2
        Me.txtFRAC_RETU_TO.Name = "txtFRAC_RETU_TO"
        Me.txtFRAC_RETU_TO.RegexCustomFalse = Nothing
        Me.txtFRAC_RETU_TO.RegexCustomTrue = Nothing
        Me.txtFRAC_RETU_TO.Size = New System.Drawing.Size(39, 27)
        Me.txtFRAC_RETU_TO.TabIndex = 358
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(393, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 32)
        Me.Label12.TabIndex = 357
        Me.Label12.Text = "～"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(348, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 32)
        Me.Label11.TabIndex = 356
        Me.Label11.Text = "段"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(303, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 32)
        Me.Label10.TabIndex = 355
        Me.Label10.Text = "連"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(258, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 32)
        Me.Label9.TabIndex = 354
        Me.Label9.Text = "列"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFRAC_DAN_FM
        '
        Me.txtFRAC_DAN_FM.BackColorMask = System.Drawing.Color.Empty
        Me.txtFRAC_DAN_FM.EnabledFull = False
        Me.txtFRAC_DAN_FM.EnabledFullAlphabetLower = False
        Me.txtFRAC_DAN_FM.EnabledFullAlphabetUpper = False
        Me.txtFRAC_DAN_FM.EnabledFullHiragana = False
        Me.txtFRAC_DAN_FM.EnabledFullKatakana = False
        Me.txtFRAC_DAN_FM.EnabledFullNumber = False
        Me.txtFRAC_DAN_FM.EnabledHalf = True
        Me.txtFRAC_DAN_FM.EnabledHalfAlphabetLower = True
        Me.txtFRAC_DAN_FM.EnabledHalfAlphabetUpper = True
        Me.txtFRAC_DAN_FM.EnabledHalfKatakana = False
        Me.txtFRAC_DAN_FM.EnabledHalfNumber = True
        Me.txtFRAC_DAN_FM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFRAC_DAN_FM.Location = New System.Drawing.Point(348, 57)
        Me.txtFRAC_DAN_FM.MaxLength = 2
        Me.txtFRAC_DAN_FM.MaxLengthByte = 2
        Me.txtFRAC_DAN_FM.Name = "txtFRAC_DAN_FM"
        Me.txtFRAC_DAN_FM.RegexCustomFalse = Nothing
        Me.txtFRAC_DAN_FM.RegexCustomTrue = Nothing
        Me.txtFRAC_DAN_FM.Size = New System.Drawing.Size(39, 27)
        Me.txtFRAC_DAN_FM.TabIndex = 353
        '
        'txtFRAC_REN_FM
        '
        Me.txtFRAC_REN_FM.BackColorMask = System.Drawing.Color.Empty
        Me.txtFRAC_REN_FM.EnabledFull = False
        Me.txtFRAC_REN_FM.EnabledFullAlphabetLower = False
        Me.txtFRAC_REN_FM.EnabledFullAlphabetUpper = False
        Me.txtFRAC_REN_FM.EnabledFullHiragana = False
        Me.txtFRAC_REN_FM.EnabledFullKatakana = False
        Me.txtFRAC_REN_FM.EnabledFullNumber = False
        Me.txtFRAC_REN_FM.EnabledHalf = True
        Me.txtFRAC_REN_FM.EnabledHalfAlphabetLower = True
        Me.txtFRAC_REN_FM.EnabledHalfAlphabetUpper = True
        Me.txtFRAC_REN_FM.EnabledHalfKatakana = False
        Me.txtFRAC_REN_FM.EnabledHalfNumber = True
        Me.txtFRAC_REN_FM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFRAC_REN_FM.Location = New System.Drawing.Point(303, 57)
        Me.txtFRAC_REN_FM.MaxLength = 2
        Me.txtFRAC_REN_FM.MaxLengthByte = 2
        Me.txtFRAC_REN_FM.Name = "txtFRAC_REN_FM"
        Me.txtFRAC_REN_FM.RegexCustomFalse = Nothing
        Me.txtFRAC_REN_FM.RegexCustomTrue = Nothing
        Me.txtFRAC_REN_FM.Size = New System.Drawing.Size(39, 27)
        Me.txtFRAC_REN_FM.TabIndex = 352
        '
        'txtFRAC_RETU_FM
        '
        Me.txtFRAC_RETU_FM.BackColorMask = System.Drawing.Color.Empty
        Me.txtFRAC_RETU_FM.EnabledFull = False
        Me.txtFRAC_RETU_FM.EnabledFullAlphabetLower = False
        Me.txtFRAC_RETU_FM.EnabledFullAlphabetUpper = False
        Me.txtFRAC_RETU_FM.EnabledFullHiragana = False
        Me.txtFRAC_RETU_FM.EnabledFullKatakana = False
        Me.txtFRAC_RETU_FM.EnabledFullNumber = False
        Me.txtFRAC_RETU_FM.EnabledHalf = True
        Me.txtFRAC_RETU_FM.EnabledHalfAlphabetLower = True
        Me.txtFRAC_RETU_FM.EnabledHalfAlphabetUpper = True
        Me.txtFRAC_RETU_FM.EnabledHalfKatakana = False
        Me.txtFRAC_RETU_FM.EnabledHalfNumber = True
        Me.txtFRAC_RETU_FM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFRAC_RETU_FM.Location = New System.Drawing.Point(258, 57)
        Me.txtFRAC_RETU_FM.MaxLength = 2
        Me.txtFRAC_RETU_FM.MaxLengthByte = 2
        Me.txtFRAC_RETU_FM.Name = "txtFRAC_RETU_FM"
        Me.txtFRAC_RETU_FM.RegexCustomFalse = Nothing
        Me.txtFRAC_RETU_FM.RegexCustomTrue = Nothing
        Me.txtFRAC_RETU_FM.Size = New System.Drawing.Size(39, 27)
        Me.txtFRAC_RETU_FM.TabIndex = 351
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(42, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 32)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "棚番号:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkHINMEI
        '
        Me.chkHINMEI.AutoSize = True
        Me.chkHINMEI.Location = New System.Drawing.Point(170, 180)
        Me.chkHINMEI.Name = "chkHINMEI"
        Me.chkHINMEI.Size = New System.Drawing.Size(14, 13)
        Me.chkHINMEI.TabIndex = 213
        Me.chkHINMEI.TabStop = True
        Me.chkHINMEI.UseVisualStyleBackColor = True
        '
        'chkTANA
        '
        Me.chkTANA.AutoSize = True
        Me.chkTANA.Location = New System.Drawing.Point(170, 470)
        Me.chkTANA.Name = "chkTANA"
        Me.chkTANA.Size = New System.Drawing.Size(14, 13)
        Me.chkTANA.TabIndex = 214
        Me.chkTANA.TabStop = True
        Me.chkTANA.UseVisualStyleBackColor = True
        '
        'FRM_305010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.chkTANA)
        Me.Controls.Add(Me.chkHINMEI)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_305010"
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
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.chkHINMEI, 0)
        Me.Controls.SetChildIndex(Me.chkTANA, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFTRK_BUF_NO As MateCommon.cmpMComboBox
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboXSEIZOU_DT As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtXPALLET_NO_FM As MateCommon.cmpMTextBoxString
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtXLINE_NO As MateCommon.cmpMTextBoxString
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtXPALLET_NO_TO As MateCommon.cmpMTextBoxString
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFRAC_DAN_TO As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFRAC_REN_TO As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFRAC_RETU_TO As MateCommon.cmpMTextBoxString
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFRAC_DAN_FM As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFRAC_REN_FM As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFRAC_RETU_FM As MateCommon.cmpMTextBoxString
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents chkHINMEI As System.Windows.Forms.RadioButton
    Friend WithEvents chkTANA As System.Windows.Forms.RadioButton

End Class
