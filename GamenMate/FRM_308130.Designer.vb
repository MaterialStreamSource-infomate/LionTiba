<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308130
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
        Me.cboXORDER_NO = New MateCommon.cmpMComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboXCAR_NO = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_DT = New MateCommon.cmpMComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXGYOSHA_CD = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboXIDOU_CD = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblXNYUKA_JIGYOU_NM = New System.Windows.Forms.Label
        Me.cboXNYUKA_JIGYOU_CD = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtXCAR_NO_WARITUKE = New MateCommon.cmpMTextBoxString
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtXCAR_NO_EDA_WARITUKE = New MateCommon.cmpMTextBoxString
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkContainer3 = New System.Windows.Forms.RadioButton
        Me.chkContainer2 = New System.Windows.Forms.RadioButton
        Me.chkContainer1 = New System.Windows.Forms.RadioButton
        Me.chkTrack = New System.Windows.Forms.RadioButton
        Me.lblTrackSyu = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblTouroku_Su = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1160, 440)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1160, 392)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(1160, 344)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(1160, 296)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(1146, 672)
        Me.cmdF4.TabIndex = 30
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(280, 672)
        Me.cmdF3.TabIndex = 29
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(168, 672)
        Me.cmdF2.TabIndex = 28
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1146, 228)
        Me.cmdF1.TabIndex = 23
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(170, 280)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 334)
        Me.grdList.TabIndex = 22
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboXORDER_NO)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cboXCAR_NO)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboXSYUKKA_DT)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cboXGYOSHA_CD)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cboXIDOU_CD)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblXNYUKA_JIGYOU_NM)
        Me.GroupBox2.Controls.Add(Me.cboXNYUKA_JIGYOU_CD)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(170, 136)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(960, 135)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'cboXORDER_NO
        '
        Me.cboXORDER_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXORDER_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXORDER_NO.FormattingEnabled = True
        Me.cboXORDER_NO.IntegralHeight = False
        Me.cboXORDER_NO.Location = New System.Drawing.Point(699, 19)
        Me.cboXORDER_NO.Name = "cboXORDER_NO"
        Me.cboXORDER_NO.Size = New System.Drawing.Size(176, 28)
        Me.cboXORDER_NO.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(600, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 32)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "発注№:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXCAR_NO
        '
        Me.cboXCAR_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXCAR_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXCAR_NO.FormattingEnabled = True
        Me.cboXCAR_NO.IntegralHeight = False
        Me.cboXCAR_NO.Location = New System.Drawing.Point(160, 19)
        Me.cboXCAR_NO.Name = "cboXCAR_NO"
        Me.cboXCAR_NO.Size = New System.Drawing.Size(80, 28)
        Me.cboXCAR_NO.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 32)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "車番:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_DT
        '
        Me.cboXSYUKKA_DT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYUKKA_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYUKKA_DT.FormattingEnabled = True
        Me.cboXSYUKKA_DT.IntegralHeight = False
        Me.cboXSYUKKA_DT.Location = New System.Drawing.Point(395, 19)
        Me.cboXSYUKKA_DT.Name = "cboXSYUKKA_DT"
        Me.cboXSYUKKA_DT.Size = New System.Drawing.Size(176, 28)
        Me.cboXSYUKKA_DT.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(296, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 32)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "出荷日:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXGYOSHA_CD
        '
        Me.cboXGYOSHA_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXGYOSHA_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXGYOSHA_CD.FormattingEnabled = True
        Me.cboXGYOSHA_CD.IntegralHeight = False
        Me.cboXGYOSHA_CD.Location = New System.Drawing.Point(395, 91)
        Me.cboXGYOSHA_CD.Name = "cboXGYOSHA_CD"
        Me.cboXGYOSHA_CD.Size = New System.Drawing.Size(104, 28)
        Me.cboXGYOSHA_CD.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(274, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 32)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "業者ｺｰﾄﾞ:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXIDOU_CD
        '
        Me.cboXIDOU_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXIDOU_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXIDOU_CD.FormattingEnabled = True
        Me.cboXIDOU_CD.IntegralHeight = False
        Me.cboXIDOU_CD.Location = New System.Drawing.Point(160, 91)
        Me.cboXIDOU_CD.Name = "cboXIDOU_CD"
        Me.cboXIDOU_CD.Size = New System.Drawing.Size(96, 28)
        Me.cboXIDOU_CD.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "移動手段ｺｰﾄﾞ:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXNYUKA_JIGYOU_NM
        '
        Me.lblXNYUKA_JIGYOU_NM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXNYUKA_JIGYOU_NM.ForeColor = System.Drawing.Color.Black
        Me.lblXNYUKA_JIGYOU_NM.Location = New System.Drawing.Point(272, 51)
        Me.lblXNYUKA_JIGYOU_NM.Name = "lblXNYUKA_JIGYOU_NM"
        Me.lblXNYUKA_JIGYOU_NM.Size = New System.Drawing.Size(592, 32)
        Me.lblXNYUKA_JIGYOU_NM.TabIndex = 8
        Me.lblXNYUKA_JIGYOU_NM.Text = "配送先名"
        Me.lblXNYUKA_JIGYOU_NM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboXNYUKA_JIGYOU_CD
        '
        Me.cboXNYUKA_JIGYOU_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXNYUKA_JIGYOU_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXNYUKA_JIGYOU_CD.FormattingEnabled = True
        Me.cboXNYUKA_JIGYOU_CD.IntegralHeight = False
        Me.cboXNYUKA_JIGYOU_CD.Location = New System.Drawing.Point(160, 54)
        Me.cboXNYUKA_JIGYOU_CD.Name = "cboXNYUKA_JIGYOU_CD"
        Me.cboXNYUKA_JIGYOU_CD.Size = New System.Drawing.Size(96, 28)
        Me.cboXNYUKA_JIGYOU_CD.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(21, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 32)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "配送先ｺｰﾄﾞ:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(168, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 32)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "受付車番:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXCAR_NO_WARITUKE
        '
        Me.txtXCAR_NO_WARITUKE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXCAR_NO_WARITUKE.EnabledFull = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullAlphabetLower = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullAlphabetUpper = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullHiragana = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullKatakana = False
        Me.txtXCAR_NO_WARITUKE.EnabledFullNumber = False
        Me.txtXCAR_NO_WARITUKE.EnabledHalf = True
        Me.txtXCAR_NO_WARITUKE.EnabledHalfAlphabetLower = False
        Me.txtXCAR_NO_WARITUKE.EnabledHalfAlphabetUpper = False
        Me.txtXCAR_NO_WARITUKE.EnabledHalfKatakana = False
        Me.txtXCAR_NO_WARITUKE.EnabledHalfNumber = True
        Me.txtXCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXCAR_NO_WARITUKE.Location = New System.Drawing.Point(280, 100)
        Me.txtXCAR_NO_WARITUKE.MaxLength = 4
        Me.txtXCAR_NO_WARITUKE.MaxLengthByte = 4
        Me.txtXCAR_NO_WARITUKE.Name = "txtXCAR_NO_WARITUKE"
        Me.txtXCAR_NO_WARITUKE.RegexCustomFalse = Nothing
        Me.txtXCAR_NO_WARITUKE.RegexCustomTrue = Nothing
        Me.txtXCAR_NO_WARITUKE.Size = New System.Drawing.Size(56, 27)
        Me.txtXCAR_NO_WARITUKE.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(336, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 32)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtXCAR_NO_EDA_WARITUKE
        '
        Me.txtXCAR_NO_EDA_WARITUKE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFull = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullAlphabetLower = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullAlphabetUpper = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullHiragana = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullKatakana = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullNumber = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalf = True
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfAlphabetLower = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfAlphabetUpper = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfKatakana = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfNumber = True
        Me.txtXCAR_NO_EDA_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXCAR_NO_EDA_WARITUKE.Location = New System.Drawing.Point(360, 100)
        Me.txtXCAR_NO_EDA_WARITUKE.MaxLength = 1
        Me.txtXCAR_NO_EDA_WARITUKE.MaxLengthByte = 1
        Me.txtXCAR_NO_EDA_WARITUKE.Name = "txtXCAR_NO_EDA_WARITUKE"
        Me.txtXCAR_NO_EDA_WARITUKE.RegexCustomFalse = Nothing
        Me.txtXCAR_NO_EDA_WARITUKE.RegexCustomTrue = Nothing
        Me.txtXCAR_NO_EDA_WARITUKE.Size = New System.Drawing.Size(24, 27)
        Me.txtXCAR_NO_EDA_WARITUKE.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(392, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(408, 32)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "(枝番は再入門時に設定して下さい。)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkContainer3)
        Me.GroupBox1.Controls.Add(Me.chkContainer2)
        Me.GroupBox1.Controls.Add(Me.chkContainer1)
        Me.GroupBox1.Controls.Add(Me.chkTrack)
        Me.GroupBox1.Location = New System.Drawing.Point(810, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 48)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'chkContainer3
        '
        Me.chkContainer3.AutoSize = True
        Me.chkContainer3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkContainer3.ForeColor = System.Drawing.Color.Black
        Me.chkContainer3.Location = New System.Drawing.Point(240, 18)
        Me.chkContainer3.Name = "chkContainer3"
        Me.chkContainer3.Size = New System.Drawing.Size(71, 20)
        Me.chkContainer3.TabIndex = 3
        Me.chkContainer3.Text = "3ｺﾝﾃﾅ"
        Me.chkContainer3.UseVisualStyleBackColor = True
        '
        'chkContainer2
        '
        Me.chkContainer2.AutoSize = True
        Me.chkContainer2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkContainer2.ForeColor = System.Drawing.Color.Black
        Me.chkContainer2.Location = New System.Drawing.Point(160, 18)
        Me.chkContainer2.Name = "chkContainer2"
        Me.chkContainer2.Size = New System.Drawing.Size(71, 20)
        Me.chkContainer2.TabIndex = 2
        Me.chkContainer2.Text = "2ｺﾝﾃﾅ"
        Me.chkContainer2.UseVisualStyleBackColor = True
        '
        'chkContainer1
        '
        Me.chkContainer1.AutoSize = True
        Me.chkContainer1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkContainer1.ForeColor = System.Drawing.Color.Black
        Me.chkContainer1.Location = New System.Drawing.Point(80, 18)
        Me.chkContainer1.Name = "chkContainer1"
        Me.chkContainer1.Size = New System.Drawing.Size(71, 20)
        Me.chkContainer1.TabIndex = 1
        Me.chkContainer1.Text = "1ｺﾝﾃﾅ"
        Me.chkContainer1.UseVisualStyleBackColor = True
        '
        'chkTrack
        '
        Me.chkTrack.AutoSize = True
        Me.chkTrack.Checked = True
        Me.chkTrack.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkTrack.ForeColor = System.Drawing.Color.Black
        Me.chkTrack.Location = New System.Drawing.Point(8, 18)
        Me.chkTrack.Name = "chkTrack"
        Me.chkTrack.Size = New System.Drawing.Size(62, 20)
        Me.chkTrack.TabIndex = 0
        Me.chkTrack.TabStop = True
        Me.chkTrack.Text = "ﾄﾗｯｸ"
        Me.chkTrack.UseVisualStyleBackColor = True
        '
        'lblTrackSyu
        '
        Me.lblTrackSyu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTrackSyu.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblTrackSyu.ForeColor = System.Drawing.Color.Black
        Me.lblTrackSyu.Location = New System.Drawing.Point(856, 624)
        Me.lblTrackSyu.Name = "lblTrackSyu"
        Me.lblTrackSyu.Size = New System.Drawing.Size(131, 32)
        Me.lblTrackSyu.TabIndex = 24
        Me.lblTrackSyu.Text = "トラック"
        Me.lblTrackSyu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1000, 624)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 32)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "登録明細件数"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTouroku_Su
        '
        Me.lblTouroku_Su.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTouroku_Su.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblTouroku_Su.ForeColor = System.Drawing.Color.Black
        Me.lblTouroku_Su.Location = New System.Drawing.Point(1144, 624)
        Me.lblTouroku_Su.Name = "lblTouroku_Su"
        Me.lblTouroku_Su.Size = New System.Drawing.Size(72, 32)
        Me.lblTouroku_Su.TabIndex = 26
        Me.lblTouroku_Su.Text = "999"
        Me.lblTouroku_Su.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(1216, 624)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 32)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "件"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_308130
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblTouroku_Su)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblTrackSyu)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtXCAR_NO_EDA_WARITUKE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtXCAR_NO_WARITUKE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grdList)
        Me.Name = "FRM_308130"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtXCAR_NO_WARITUKE, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtXCAR_NO_EDA_WARITUKE, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblTrackSyu, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lblTouroku_Su, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblXNYUKA_JIGYOU_NM As System.Windows.Forms.Label
    Friend WithEvents cboXNYUKA_JIGYOU_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboXGYOSHA_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboXIDOU_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboXCAR_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboXSYUKKA_DT As MateCommon.cmpMComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtXCAR_NO_WARITUKE As MateCommon.cmpMTextBoxString
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtXCAR_NO_EDA_WARITUKE As MateCommon.cmpMTextBoxString
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboXORDER_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkContainer3 As System.Windows.Forms.RadioButton
    Friend WithEvents chkContainer2 As System.Windows.Forms.RadioButton
    Friend WithEvents chkContainer1 As System.Windows.Forms.RadioButton
    Friend WithEvents chkTrack As System.Windows.Forms.RadioButton
    Friend WithEvents lblTrackSyu As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTouroku_Su As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label

End Class
