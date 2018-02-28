<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303070
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtBC = New MateCommon.cmpMTextBoxString
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.txtXLINE_NO = New MateCommon.cmpMTextBoxString
        Me.btnBC = New System.Windows.Forms.Button
        Me.txtFTR_VOL = New MateCommon.cmpMTextBoxNumber
        Me.dtpXSEIZOU_DT = New GamenCommon.cmpMDateTimePicker_DT
        Me.txtXAB_KUBUN = New MateCommon.cmpMTextBoxString
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboXKENSA_KUBUN = New MateCommon.cmpMComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtXPALLET_NO = New MateCommon.cmpMTextBoxString
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblINPUT_MODE = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSTMode = New System.Windows.Forms.Button
        Me.cboFTRK_BUF_NO = New MateCommon.cmpMComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tmr303070 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1152, 720)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1152, 672)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(608, 672)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(498, 672)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(1040, 672)
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(928, 672)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(816, 672)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(168, 672)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtBC)
        Me.GroupBox2.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox2.Controls.Add(Me.txtXLINE_NO)
        Me.GroupBox2.Controls.Add(Me.btnBC)
        Me.GroupBox2.Controls.Add(Me.txtFTR_VOL)
        Me.GroupBox2.Controls.Add(Me.dtpXSEIZOU_DT)
        Me.GroupBox2.Controls.Add(Me.txtXAB_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cboXKENSA_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtXPALLET_NO)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblINPUT_MODE)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 165)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1080, 495)
        Me.GroupBox2.TabIndex = 214
        Me.GroupBox2.TabStop = False
        '
        'txtBC
        '
        Me.txtBC.BackColorMask = System.Drawing.Color.Empty
        Me.txtBC.EnabledFull = False
        Me.txtBC.EnabledFullAlphabetLower = False
        Me.txtBC.EnabledFullAlphabetUpper = False
        Me.txtBC.EnabledFullHiragana = False
        Me.txtBC.EnabledFullKatakana = False
        Me.txtBC.EnabledFullNumber = False
        Me.txtBC.EnabledHalf = True
        Me.txtBC.EnabledHalfAlphabetLower = False
        Me.txtBC.EnabledHalfAlphabetUpper = True
        Me.txtBC.EnabledHalfKatakana = False
        Me.txtBC.EnabledHalfNumber = True
        Me.txtBC.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtBC.Location = New System.Drawing.Point(958, 51)
        Me.txtBC.MaxLength = 32768
        Me.txtBC.MaxLengthByte = 32768
        Me.txtBC.Name = "txtBC"
        Me.txtBC.RegexCustomFalse = Nothing
        Me.txtBC.RegexCustomTrue = Nothing
        Me.txtBC.Size = New System.Drawing.Size(56, 27)
        Me.txtBC.TabIndex = 18
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(171, 16)
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
        Me.txtXLINE_NO.EnabledHalfAlphabetLower = False
        Me.txtXLINE_NO.EnabledHalfAlphabetUpper = False
        Me.txtXLINE_NO.EnabledHalfKatakana = False
        Me.txtXLINE_NO.EnabledHalfNumber = True
        Me.txtXLINE_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXLINE_NO.Location = New System.Drawing.Point(171, 96)
        Me.txtXLINE_NO.MaxLength = 6
        Me.txtXLINE_NO.MaxLengthByte = 6
        Me.txtXLINE_NO.Name = "txtXLINE_NO"
        Me.txtXLINE_NO.RegexCustomFalse = Nothing
        Me.txtXLINE_NO.RegexCustomTrue = Nothing
        Me.txtXLINE_NO.Size = New System.Drawing.Size(152, 27)
        Me.txtXLINE_NO.TabIndex = 6
        '
        'btnBC
        '
        Me.btnBC.Location = New System.Drawing.Point(920, 56)
        Me.btnBC.Name = "btnBC"
        Me.btnBC.Size = New System.Drawing.Size(32, 24)
        Me.btnBC.TabIndex = 16
        Me.btnBC.Text = "BarCode"
        Me.btnBC.UseVisualStyleBackColor = True
        '
        'txtFTR_VOL
        '
        Me.txtFTR_VOL.BackColorMask = System.Drawing.Color.Empty
        Me.txtFTR_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFTR_VOL.Format = "######0"
        Me.txtFTR_VOL.Location = New System.Drawing.Point(171, 176)
        Me.txtFTR_VOL.MaxLength = 7
        Me.txtFTR_VOL.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtFTR_VOL.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtFTR_VOL.Name = "txtFTR_VOL"
        Me.txtFTR_VOL.Nullable = True
        Me.txtFTR_VOL.Size = New System.Drawing.Size(152, 27)
        Me.txtFTR_VOL.TabIndex = 10
        Me.txtFTR_VOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFTR_VOL.Value = Nothing
        '
        'dtpXSEIZOU_DT
        '
        Me.dtpXSEIZOU_DT.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpXSEIZOU_DT.Location = New System.Drawing.Point(168, 56)
        Me.dtpXSEIZOU_DT.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpXSEIZOU_DT.Name = "dtpXSEIZOU_DT"
        Me.dtpXSEIZOU_DT.Size = New System.Drawing.Size(168, 32)
        Me.dtpXSEIZOU_DT.TabIndex = 4
        Me.dtpXSEIZOU_DT.TimeComboDisp = False
        Me.dtpXSEIZOU_DT.userChecked = True
        Me.dtpXSEIZOU_DT.userShowCheckBox = False
        '
        'txtXAB_KUBUN
        '
        Me.txtXAB_KUBUN.BackColorMask = System.Drawing.Color.Empty
        Me.txtXAB_KUBUN.EnabledFull = False
        Me.txtXAB_KUBUN.EnabledFullAlphabetLower = False
        Me.txtXAB_KUBUN.EnabledFullAlphabetUpper = False
        Me.txtXAB_KUBUN.EnabledFullHiragana = False
        Me.txtXAB_KUBUN.EnabledFullKatakana = False
        Me.txtXAB_KUBUN.EnabledFullNumber = False
        Me.txtXAB_KUBUN.EnabledHalf = True
        Me.txtXAB_KUBUN.EnabledHalfAlphabetLower = True
        Me.txtXAB_KUBUN.EnabledHalfAlphabetUpper = True
        Me.txtXAB_KUBUN.EnabledHalfKatakana = False
        Me.txtXAB_KUBUN.EnabledHalfNumber = True
        Me.txtXAB_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXAB_KUBUN.Location = New System.Drawing.Point(171, 256)
        Me.txtXAB_KUBUN.MaxLength = 1
        Me.txtXAB_KUBUN.MaxLengthByte = 1
        Me.txtXAB_KUBUN.Name = "txtXAB_KUBUN"
        Me.txtXAB_KUBUN.RegexCustomFalse = Nothing
        Me.txtXAB_KUBUN.RegexCustomTrue = Nothing
        Me.txtXAB_KUBUN.Size = New System.Drawing.Size(52, 27)
        Me.txtXAB_KUBUN.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(32, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 32)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "AB区分:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXKENSA_KUBUN
        '
        Me.cboXKENSA_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXKENSA_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXKENSA_KUBUN.FormattingEnabled = True
        Me.cboXKENSA_KUBUN.IntegralHeight = False
        Me.cboXKENSA_KUBUN.Location = New System.Drawing.Point(171, 216)
        Me.cboXKENSA_KUBUN.Name = "cboXKENSA_KUBUN"
        Me.cboXKENSA_KUBUN.Size = New System.Drawing.Size(52, 28)
        Me.cboXKENSA_KUBUN.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(32, 213)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 32)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "検査区分:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(32, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 32)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "積数:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.txtXPALLET_NO.Location = New System.Drawing.Point(171, 136)
        Me.txtXPALLET_NO.MaxLength = 4
        Me.txtXPALLET_NO.MaxLengthByte = 4
        Me.txtXPALLET_NO.Name = "txtXPALLET_NO"
        Me.txtXPALLET_NO.RegexCustomFalse = Nothing
        Me.txtXPALLET_NO.RegexCustomTrue = Nothing
        Me.txtXPALLET_NO.Size = New System.Drawing.Size(152, 27)
        Me.txtXPALLET_NO.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(32, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 32)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "ﾊﾟﾚｯﾄ№:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(32, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 32)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "ﾗｲﾝ№:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(344, 16)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 2
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(32, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 32)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "製造年月日:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(32, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "品名ｺｰﾄﾞ:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblINPUT_MODE
        '
        Me.lblINPUT_MODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblINPUT_MODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblINPUT_MODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblINPUT_MODE.ForeColor = System.Drawing.Color.Black
        Me.lblINPUT_MODE.Location = New System.Drawing.Point(907, 16)
        Me.lblINPUT_MODE.Name = "lblINPUT_MODE"
        Me.lblINPUT_MODE.Size = New System.Drawing.Size(139, 32)
        Me.lblINPUT_MODE.TabIndex = 15
        Me.lblINPUT_MODE.Text = "手入力"
        Me.lblINPUT_MODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSTMode)
        Me.GroupBox1.Controls.Add(Me.cboFTRK_BUF_NO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(631, 67)
        Me.GroupBox1.TabIndex = 213
        Me.GroupBox1.TabStop = False
        '
        'btnSTMode
        '
        Me.btnSTMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSTMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSTMode.ForeColor = System.Drawing.Color.Black
        Me.btnSTMode.Location = New System.Drawing.Point(448, 16)
        Me.btnSTMode.Name = "btnSTMode"
        Me.btnSTMode.Size = New System.Drawing.Size(152, 31)
        Me.btnSTMode.TabIndex = 2
        Me.btnSTMode.Text = "出庫モード"
        Me.btnSTMode.UseVisualStyleBackColor = False
        '
        'cboFTRK_BUF_NO
        '
        Me.cboFTRK_BUF_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO.IntegralHeight = False
        Me.cboFTRK_BUF_NO.Location = New System.Drawing.Point(171, 19)
        Me.cboFTRK_BUF_NO.Name = "cboFTRK_BUF_NO"
        Me.cboFTRK_BUF_NO.Size = New System.Drawing.Size(244, 28)
        Me.cboFTRK_BUF_NO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(32, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "入庫ST:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmr303070
        '
        '
        'FRM_303070
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_303070"
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBC As MateCommon.cmpMTextBoxString
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents txtXLINE_NO As MateCommon.cmpMTextBoxString
    Friend WithEvents btnBC As System.Windows.Forms.Button
    Friend WithEvents txtFTR_VOL As MateCommon.cmpMTextBoxNumber
    Friend WithEvents dtpXSEIZOU_DT As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents txtXAB_KUBUN As MateCommon.cmpMTextBoxString
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboXKENSA_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtXPALLET_NO As MateCommon.cmpMTextBoxString
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblINPUT_MODE As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSTMode As System.Windows.Forms.Button
    Friend WithEvents cboFTRK_BUF_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tmr303070 As System.Windows.Forms.Timer

End Class
