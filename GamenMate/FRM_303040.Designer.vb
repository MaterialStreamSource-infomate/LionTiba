<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303040
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
        Me.tmr303040 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXCONVYOR_YOUTO = New MateCommon.cmpMComboBox
        Me.cmdModeChange = New System.Windows.Forms.Button
        Me.cboFTRK_BUF_NO = New MateCommon.cmpMComboBox
        Me.lblSTMode = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboXARTICLE_TYPE_CODE = New MateCommon.cmpMComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboFTRK_BUF_NO_ZAIKO = New MateCommon.cmpMComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPL_VOL = New MateCommon.cmpMTextBoxNumber
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpFrom = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpTo = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboXPROD_LINE = New MateCommon.cmpMComboBox
        Me.cboFHORYU_KUBUN = New MateCommon.cmpMComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboXKENSA_KUBUN = New MateCommon.cmpMComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.lblFHINMEI = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(583, 671)
        Me.cmdF6.TabIndex = 52
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(298, 671)
        Me.cmdF5.TabIndex = 51
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 671)
        Me.cmdF4.TabIndex = 50
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 350)
        Me.cmdF1.TabIndex = 2
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 401)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 259)
        Me.grdList.TabIndex = 3
        '
        'tmr303040
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboXCONVYOR_YOUTO)
        Me.GroupBox1.Controls.Add(Me.cmdModeChange)
        Me.GroupBox1.Controls.Add(Me.cboFTRK_BUF_NO)
        Me.GroupBox1.Controls.Add(Me.lblSTMode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(970, 94)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(14, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(158, 32)
        Me.Label7.TabIndex = 275
        Me.Label7.Text = "設定モード:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXCONVYOR_YOUTO
        '
        Me.cboXCONVYOR_YOUTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXCONVYOR_YOUTO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXCONVYOR_YOUTO.FormattingEnabled = True
        Me.cboXCONVYOR_YOUTO.IntegralHeight = False
        Me.cboXCONVYOR_YOUTO.Location = New System.Drawing.Point(172, 51)
        Me.cboXCONVYOR_YOUTO.Name = "cboXCONVYOR_YOUTO"
        Me.cboXCONVYOR_YOUTO.Size = New System.Drawing.Size(136, 28)
        Me.cboXCONVYOR_YOUTO.TabIndex = 1
        '
        'cmdModeChange
        '
        Me.cmdModeChange.BackColor = System.Drawing.Color.DarkGray
        Me.cmdModeChange.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdModeChange.ForeColor = System.Drawing.Color.Black
        Me.cmdModeChange.Location = New System.Drawing.Point(466, 50)
        Me.cmdModeChange.Name = "cmdModeChange"
        Me.cmdModeChange.Size = New System.Drawing.Size(174, 31)
        Me.cmdModeChange.TabIndex = 2
        Me.cmdModeChange.Text = "ｺﾝﾍﾞﾔ設定切替"
        Me.cmdModeChange.UseVisualStyleBackColor = False
        '
        'cboFTRK_BUF_NO
        '
        Me.cboFTRK_BUF_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO.IntegralHeight = False
        Me.cboFTRK_BUF_NO.Location = New System.Drawing.Point(172, 13)
        Me.cboFTRK_BUF_NO.Name = "cboFTRK_BUF_NO"
        Me.cboFTRK_BUF_NO.Size = New System.Drawing.Size(268, 28)
        Me.cboFTRK_BUF_NO.TabIndex = 0
        '
        'lblSTMode
        '
        Me.lblSTMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSTMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSTMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSTMode.ForeColor = System.Drawing.Color.Black
        Me.lblSTMode.Location = New System.Drawing.Point(466, 11)
        Me.lblSTMode.Name = "lblSTMode"
        Me.lblSTMode.Size = New System.Drawing.Size(174, 31)
        Me.lblSTMode.TabIndex = 216
        Me.lblSTMode.Text = "出庫モード"
        Me.lblSTMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(33, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "出庫ST:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboXARTICLE_TYPE_CODE)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboFTRK_BUF_NO_ZAIKO)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtPL_VOL)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtpFrom)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtpTo)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cboXPROD_LINE)
        Me.GroupBox2.Controls.Add(Me.cboFHORYU_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cboXKENSA_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 185)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(970, 210)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'cboXARTICLE_TYPE_CODE
        '
        Me.cboXARTICLE_TYPE_CODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXARTICLE_TYPE_CODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXARTICLE_TYPE_CODE.FormattingEnabled = True
        Me.cboXARTICLE_TYPE_CODE.IntegralHeight = False
        Me.cboXARTICLE_TYPE_CODE.Location = New System.Drawing.Point(172, 172)
        Me.cboXARTICLE_TYPE_CODE.Name = "cboXARTICLE_TYPE_CODE"
        Me.cboXARTICLE_TYPE_CODE.Size = New System.Drawing.Size(165, 28)
        Me.cboXARTICLE_TYPE_CODE.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(165, 32)
        Me.Label8.TabIndex = 224
        Me.Label8.Text = "商品区分:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFTRK_BUF_NO_ZAIKO
        '
        Me.cboFTRK_BUF_NO_ZAIKO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO_ZAIKO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO_ZAIKO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO_ZAIKO.IntegralHeight = False
        Me.cboFTRK_BUF_NO_ZAIKO.Location = New System.Drawing.Point(172, 19)
        Me.cboFTRK_BUF_NO_ZAIKO.Name = "cboFTRK_BUF_NO_ZAIKO"
        Me.cboFTRK_BUF_NO_ZAIKO.Size = New System.Drawing.Size(268, 28)
        Me.cboFTRK_BUF_NO_ZAIKO.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(6, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(165, 32)
        Me.Label20.TabIndex = 220
        Me.Label20.Text = "在庫ｴﾘｱ:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(649, 175)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 20)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "PL"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPL_VOL
        '
        Me.txtPL_VOL.BackColorMask = System.Drawing.Color.Empty
        Me.txtPL_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtPL_VOL.Format = ""
        Me.txtPL_VOL.Location = New System.Drawing.Point(493, 172)
        Me.txtPL_VOL.MaxLength = 6
        Me.txtPL_VOL.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.txtPL_VOL.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPL_VOL.Name = "txtPL_VOL"
        Me.txtPL_VOL.Nullable = True
        Me.txtPL_VOL.Size = New System.Drawing.Size(150, 27)
        Me.txtPL_VOL.TabIndex = 8
        Me.txtPL_VOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPL_VOL.Value = Nothing
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(387, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 32)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "数量:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFrom
        '
        Me.dtpFrom.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFrom.Location = New System.Drawing.Point(172, 92)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(299, 30)
        Me.dtpFrom.TabIndex = 2
        Me.dtpFrom.TimeComboDisp = True
        Me.dtpFrom.userChecked = True
        Me.dtpFrom.userShowCheckBox = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(477, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 20)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "～"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpTo
        '
        Me.dtpTo.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpTo.Location = New System.Drawing.Point(514, 92)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(300, 32)
        Me.dtpTo.TabIndex = 3
        Me.dtpTo.TimeComboDisp = True
        Me.dtpTo.userChecked = True
        Me.dtpTo.userShowCheckBox = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 32)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "在庫発生日時:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXPROD_LINE
        '
        Me.cboXPROD_LINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXPROD_LINE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXPROD_LINE.FormattingEnabled = True
        Me.cboXPROD_LINE.IntegralHeight = False
        Me.cboXPROD_LINE.Location = New System.Drawing.Point(172, 132)
        Me.cboXPROD_LINE.Name = "cboXPROD_LINE"
        Me.cboXPROD_LINE.Size = New System.Drawing.Size(165, 28)
        Me.cboXPROD_LINE.TabIndex = 4
        '
        'cboFHORYU_KUBUN
        '
        Me.cboFHORYU_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFHORYU_KUBUN.DropDownWidth = 150
        Me.cboFHORYU_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFHORYU_KUBUN.FormattingEnabled = True
        Me.cboFHORYU_KUBUN.IntegralHeight = False
        Me.cboFHORYU_KUBUN.Location = New System.Drawing.Point(804, 134)
        Me.cboFHORYU_KUBUN.Name = "cboFHORYU_KUBUN"
        Me.cboFHORYU_KUBUN.Size = New System.Drawing.Size(150, 27)
        Me.cboFHORYU_KUBUN.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(694, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 20)
        Me.Label10.TabIndex = 24
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
        Me.cboXKENSA_KUBUN.Location = New System.Drawing.Point(493, 133)
        Me.cboXKENSA_KUBUN.Name = "cboXKENSA_KUBUN"
        Me.cboXKENSA_KUBUN.Size = New System.Drawing.Size(150, 27)
        Me.cboXKENSA_KUBUN.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(383, 135)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "検査区分:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 32)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "生産ﾗｲﾝNo.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 32)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "品名ｺｰﾄﾞ/記号:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(172, 56)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(165, 28)
        Me.cboFHINMEI_CD.TabIndex = 1
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
        Me.lblFHINMEI.Location = New System.Drawing.Point(343, 53)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 18
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_303040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grdList)
        Me.Name = "FRM_303040"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents tmr303040 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboXCONVYOR_YOUTO As MateCommon.cmpMComboBox
    Friend WithEvents cmdModeChange As System.Windows.Forms.Button
    Friend WithEvents cboFTRK_BUF_NO As MateCommon.cmpMComboBox
    Friend WithEvents lblSTMode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFTRK_BUF_NO_ZAIKO As MateCommon.cmpMComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPL_VOL As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboXPROD_LINE As MateCommon.cmpMComboBox
    Friend WithEvents cboFHORYU_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboXKENSA_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents cboXARTICLE_TYPE_CODE As MateCommon.cmpMComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
