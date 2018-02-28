<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_206011
    Inherits GamenMate.FRM_000001

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
        Me.txtFHINMEI = New MateCommon.cmpMTextBoxString
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboFRAC_FORM = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboXARTICLE_TYPE_CODE = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFNUM_IN_PALLET = New MateCommon.cmpMTextBoxNumber
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.txtFHINMEI_CD = New MateCommon.cmpMTextBoxString
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtXPLANE_PACK_NUMBER = New MateCommon.cmpMTextBoxNumber
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtXWEIGHT_IN_CASE = New MateCommon.cmpMTextBoxNumber
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtXHEIGHT_IN_CASE = New MateCommon.cmpMTextBoxNumber
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtXWEIGHT_IN_PALLET = New MateCommon.cmpMTextBoxNumber
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtXDAN_IN_PALLET = New MateCommon.cmpMTextBoxNumber
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtXHEIGHT_IN_PALLET = New MateCommon.cmpMTextBoxNumber
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtXITF_CD = New MateCommon.cmpMTextBoxString
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtXJAN_CD = New MateCommon.cmpMTextBoxString
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboXIN_RES_TYPE = New MateCommon.cmpMComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtXMAKER_CD = New MateCommon.cmpMTextBoxString
        Me.txtXSUB_CD = New MateCommon.cmpMTextBoxNumber
        Me.txtXHINMEI_CD = New MateCommon.cmpMTextBoxString
        Me.SuspendLayout()
        '
        'txtFHINMEI
        '
        Me.txtFHINMEI.BackColorMask = System.Drawing.Color.Empty
        Me.txtFHINMEI.EnabledFull = True
        Me.txtFHINMEI.EnabledFullAlphabetLower = True
        Me.txtFHINMEI.EnabledFullAlphabetUpper = True
        Me.txtFHINMEI.EnabledFullHiragana = True
        Me.txtFHINMEI.EnabledFullKatakana = True
        Me.txtFHINMEI.EnabledFullNumber = True
        Me.txtFHINMEI.EnabledHalf = True
        Me.txtFHINMEI.EnabledHalfAlphabetLower = True
        Me.txtFHINMEI.EnabledHalfAlphabetUpper = True
        Me.txtFHINMEI.EnabledHalfKatakana = True
        Me.txtFHINMEI.EnabledHalfNumber = True
        Me.txtFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFHINMEI.Location = New System.Drawing.Point(170, 87)
        Me.txtFHINMEI.MaxLength = 50
        Me.txtFHINMEI.MaxLengthByte = 50
        Me.txtFHINMEI.Name = "txtFHINMEI"
        Me.txtFHINMEI.RegexCustomFalse = Nothing
        Me.txtFHINMEI.RegexCustomTrue = Nothing
        Me.txtFHINMEI.Size = New System.Drawing.Size(584, 27)
        Me.txtFHINMEI.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(17, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 32)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "品名:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(17, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 32)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "品名記号:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFRAC_FORM
        '
        Me.cboFRAC_FORM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_FORM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFRAC_FORM.FormattingEnabled = True
        Me.cboFRAC_FORM.IntegralHeight = False
        Me.cboFRAC_FORM.Location = New System.Drawing.Point(170, 153)
        Me.cboFRAC_FORM.Name = "cboFRAC_FORM"
        Me.cboFRAC_FORM.Size = New System.Drawing.Size(168, 28)
        Me.cboFRAC_FORM.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(17, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "棚形状種別:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXARTICLE_TYPE_CODE
        '
        Me.cboXARTICLE_TYPE_CODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXARTICLE_TYPE_CODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXARTICLE_TYPE_CODE.FormattingEnabled = True
        Me.cboXARTICLE_TYPE_CODE.IntegralHeight = False
        Me.cboXARTICLE_TYPE_CODE.Location = New System.Drawing.Point(171, 385)
        Me.cboXARTICLE_TYPE_CODE.Name = "cboXARTICLE_TYPE_CODE"
        Me.cboXARTICLE_TYPE_CODE.Size = New System.Drawing.Size(168, 28)
        Me.cboXARTICLE_TYPE_CODE.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(17, 382)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 32)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "商品区分:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFNUM_IN_PALLET
        '
        Me.txtFNUM_IN_PALLET.BackColorMask = System.Drawing.Color.Empty
        Me.txtFNUM_IN_PALLET.Enabled = False
        Me.txtFNUM_IN_PALLET.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFNUM_IN_PALLET.Format = "######0"
        Me.txtFNUM_IN_PALLET.Location = New System.Drawing.Point(170, 120)
        Me.txtFNUM_IN_PALLET.MaxLength = 15
        Me.txtFNUM_IN_PALLET.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtFNUM_IN_PALLET.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtFNUM_IN_PALLET.Name = "txtFNUM_IN_PALLET"
        Me.txtFNUM_IN_PALLET.Nullable = True
        Me.txtFNUM_IN_PALLET.Size = New System.Drawing.Size(169, 27)
        Me.txtFNUM_IN_PALLET.TabIndex = 3
        Me.txtFNUM_IN_PALLET.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFNUM_IN_PALLET.Value = Nothing
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(17, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 32)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "ﾊﾟﾚｯﾄ積付数:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(404, 448)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 18
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(132, 448)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 17
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'txtFHINMEI_CD
        '
        Me.txtFHINMEI_CD.BackColorMask = System.Drawing.Color.Empty
        Me.txtFHINMEI_CD.EnabledFull = False
        Me.txtFHINMEI_CD.EnabledFullAlphabetLower = False
        Me.txtFHINMEI_CD.EnabledFullAlphabetUpper = False
        Me.txtFHINMEI_CD.EnabledFullHiragana = False
        Me.txtFHINMEI_CD.EnabledFullKatakana = False
        Me.txtFHINMEI_CD.EnabledFullNumber = False
        Me.txtFHINMEI_CD.EnabledHalf = True
        Me.txtFHINMEI_CD.EnabledHalfAlphabetLower = True
        Me.txtFHINMEI_CD.EnabledHalfAlphabetUpper = True
        Me.txtFHINMEI_CD.EnabledHalfKatakana = True
        Me.txtFHINMEI_CD.EnabledHalfNumber = True
        Me.txtFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFHINMEI_CD.Location = New System.Drawing.Point(170, 54)
        Me.txtFHINMEI_CD.MaxLength = 14
        Me.txtFHINMEI_CD.MaxLengthByte = 14
        Me.txtFHINMEI_CD.Name = "txtFHINMEI_CD"
        Me.txtFHINMEI_CD.RegexCustomFalse = Nothing
        Me.txtFHINMEI_CD.RegexCustomTrue = Nothing
        Me.txtFHINMEI_CD.Size = New System.Drawing.Size(168, 27)
        Me.txtFHINMEI_CD.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "品名ｺｰﾄﾞ:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXPLANE_PACK_NUMBER
        '
        Me.txtXPLANE_PACK_NUMBER.BackColorMask = System.Drawing.Color.Empty
        Me.txtXPLANE_PACK_NUMBER.Enabled = False
        Me.txtXPLANE_PACK_NUMBER.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXPLANE_PACK_NUMBER.Format = "##0"
        Me.txtXPLANE_PACK_NUMBER.Location = New System.Drawing.Point(170, 187)
        Me.txtXPLANE_PACK_NUMBER.MaxLength = 3
        Me.txtXPLANE_PACK_NUMBER.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtXPLANE_PACK_NUMBER.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXPLANE_PACK_NUMBER.Name = "txtXPLANE_PACK_NUMBER"
        Me.txtXPLANE_PACK_NUMBER.Nullable = True
        Me.txtXPLANE_PACK_NUMBER.Size = New System.Drawing.Size(169, 27)
        Me.txtXPLANE_PACK_NUMBER.TabIndex = 5
        Me.txtXPLANE_PACK_NUMBER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXPLANE_PACK_NUMBER.Value = Nothing
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(17, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 32)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "平面梱数:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXWEIGHT_IN_CASE
        '
        Me.txtXWEIGHT_IN_CASE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXWEIGHT_IN_CASE.Enabled = False
        Me.txtXWEIGHT_IN_CASE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXWEIGHT_IN_CASE.Format = "###########0.0####"
        Me.txtXWEIGHT_IN_CASE.Location = New System.Drawing.Point(170, 220)
        Me.txtXWEIGHT_IN_CASE.MaxLength = 17
        Me.txtXWEIGHT_IN_CASE.MaxValue = New Decimal(New Integer() {1569325055, 23283064, 0, 327680})
        Me.txtXWEIGHT_IN_CASE.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXWEIGHT_IN_CASE.Name = "txtXWEIGHT_IN_CASE"
        Me.txtXWEIGHT_IN_CASE.Nullable = True
        Me.txtXWEIGHT_IN_CASE.Size = New System.Drawing.Size(169, 27)
        Me.txtXWEIGHT_IN_CASE.TabIndex = 6
        Me.txtXWEIGHT_IN_CASE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXWEIGHT_IN_CASE.Value = Nothing
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(17, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 32)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "梱重量:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXHEIGHT_IN_CASE
        '
        Me.txtXHEIGHT_IN_CASE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXHEIGHT_IN_CASE.Enabled = False
        Me.txtXHEIGHT_IN_CASE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXHEIGHT_IN_CASE.Format = "###0"
        Me.txtXHEIGHT_IN_CASE.Location = New System.Drawing.Point(170, 253)
        Me.txtXHEIGHT_IN_CASE.MaxLength = 4
        Me.txtXHEIGHT_IN_CASE.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtXHEIGHT_IN_CASE.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXHEIGHT_IN_CASE.Name = "txtXHEIGHT_IN_CASE"
        Me.txtXHEIGHT_IN_CASE.Nullable = True
        Me.txtXHEIGHT_IN_CASE.Size = New System.Drawing.Size(169, 27)
        Me.txtXHEIGHT_IN_CASE.TabIndex = 7
        Me.txtXHEIGHT_IN_CASE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXHEIGHT_IN_CASE.Value = Nothing
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(17, 250)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 32)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "梱高さ:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXWEIGHT_IN_PALLET
        '
        Me.txtXWEIGHT_IN_PALLET.BackColorMask = System.Drawing.Color.Empty
        Me.txtXWEIGHT_IN_PALLET.Enabled = False
        Me.txtXWEIGHT_IN_PALLET.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXWEIGHT_IN_PALLET.Format = "###########0.0####"
        Me.txtXWEIGHT_IN_PALLET.Location = New System.Drawing.Point(170, 286)
        Me.txtXWEIGHT_IN_PALLET.MaxLength = 17
        Me.txtXWEIGHT_IN_PALLET.MaxValue = New Decimal(New Integer() {1569325055, 23283064, 0, 327680})
        Me.txtXWEIGHT_IN_PALLET.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXWEIGHT_IN_PALLET.Name = "txtXWEIGHT_IN_PALLET"
        Me.txtXWEIGHT_IN_PALLET.Nullable = True
        Me.txtXWEIGHT_IN_PALLET.Size = New System.Drawing.Size(169, 27)
        Me.txtXWEIGHT_IN_PALLET.TabIndex = 8
        Me.txtXWEIGHT_IN_PALLET.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXWEIGHT_IN_PALLET.Value = Nothing
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Location = New System.Drawing.Point(17, 283)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 32)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "1PL当重量:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXDAN_IN_PALLET
        '
        Me.txtXDAN_IN_PALLET.BackColorMask = System.Drawing.Color.Empty
        Me.txtXDAN_IN_PALLET.Enabled = False
        Me.txtXDAN_IN_PALLET.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXDAN_IN_PALLET.Format = "#0"
        Me.txtXDAN_IN_PALLET.Location = New System.Drawing.Point(170, 319)
        Me.txtXDAN_IN_PALLET.MaxLength = 2
        Me.txtXDAN_IN_PALLET.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtXDAN_IN_PALLET.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXDAN_IN_PALLET.Name = "txtXDAN_IN_PALLET"
        Me.txtXDAN_IN_PALLET.Nullable = True
        Me.txtXDAN_IN_PALLET.Size = New System.Drawing.Size(169, 27)
        Me.txtXDAN_IN_PALLET.TabIndex = 9
        Me.txtXDAN_IN_PALLET.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXDAN_IN_PALLET.Value = Nothing
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(17, 316)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 32)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "1PL当段数:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXHEIGHT_IN_PALLET
        '
        Me.txtXHEIGHT_IN_PALLET.BackColorMask = System.Drawing.Color.Empty
        Me.txtXHEIGHT_IN_PALLET.Enabled = False
        Me.txtXHEIGHT_IN_PALLET.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXHEIGHT_IN_PALLET.Format = "###0"
        Me.txtXHEIGHT_IN_PALLET.Location = New System.Drawing.Point(170, 352)
        Me.txtXHEIGHT_IN_PALLET.MaxLength = 4
        Me.txtXHEIGHT_IN_PALLET.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtXHEIGHT_IN_PALLET.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXHEIGHT_IN_PALLET.Name = "txtXHEIGHT_IN_PALLET"
        Me.txtXHEIGHT_IN_PALLET.Nullable = True
        Me.txtXHEIGHT_IN_PALLET.Size = New System.Drawing.Size(169, 27)
        Me.txtXHEIGHT_IN_PALLET.TabIndex = 10
        Me.txtXHEIGHT_IN_PALLET.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXHEIGHT_IN_PALLET.Value = Nothing
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(17, 349)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 32)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "1PL当高さ:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(368, 119)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(152, 32)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "ｻﾌﾞｺｰﾄﾞ:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXITF_CD
        '
        Me.txtXITF_CD.BackColorMask = System.Drawing.Color.Empty
        Me.txtXITF_CD.EnabledFull = False
        Me.txtXITF_CD.EnabledFullAlphabetLower = False
        Me.txtXITF_CD.EnabledFullAlphabetUpper = False
        Me.txtXITF_CD.EnabledFullHiragana = False
        Me.txtXITF_CD.EnabledFullKatakana = False
        Me.txtXITF_CD.EnabledFullNumber = False
        Me.txtXITF_CD.EnabledHalf = True
        Me.txtXITF_CD.EnabledHalfAlphabetLower = True
        Me.txtXITF_CD.EnabledHalfAlphabetUpper = True
        Me.txtXITF_CD.EnabledHalfKatakana = True
        Me.txtXITF_CD.EnabledHalfNumber = True
        Me.txtXITF_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXITF_CD.Location = New System.Drawing.Point(521, 153)
        Me.txtXITF_CD.MaxLength = 16
        Me.txtXITF_CD.MaxLengthByte = 16
        Me.txtXITF_CD.Name = "txtXITF_CD"
        Me.txtXITF_CD.RegexCustomFalse = Nothing
        Me.txtXITF_CD.RegexCustomTrue = Nothing
        Me.txtXITF_CD.Size = New System.Drawing.Size(233, 27)
        Me.txtXITF_CD.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(368, 153)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(152, 32)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "ITFｺｰﾄﾞ:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXJAN_CD
        '
        Me.txtXJAN_CD.BackColorMask = System.Drawing.Color.Empty
        Me.txtXJAN_CD.EnabledFull = False
        Me.txtXJAN_CD.EnabledFullAlphabetLower = False
        Me.txtXJAN_CD.EnabledFullAlphabetUpper = False
        Me.txtXJAN_CD.EnabledFullHiragana = False
        Me.txtXJAN_CD.EnabledFullKatakana = False
        Me.txtXJAN_CD.EnabledFullNumber = False
        Me.txtXJAN_CD.EnabledHalf = True
        Me.txtXJAN_CD.EnabledHalfAlphabetLower = True
        Me.txtXJAN_CD.EnabledHalfAlphabetUpper = True
        Me.txtXJAN_CD.EnabledHalfKatakana = True
        Me.txtXJAN_CD.EnabledHalfNumber = True
        Me.txtXJAN_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXJAN_CD.Location = New System.Drawing.Point(521, 187)
        Me.txtXJAN_CD.MaxLength = 16
        Me.txtXJAN_CD.MaxLengthByte = 16
        Me.txtXJAN_CD.Name = "txtXJAN_CD"
        Me.txtXJAN_CD.RegexCustomFalse = Nothing
        Me.txtXJAN_CD.RegexCustomTrue = Nothing
        Me.txtXJAN_CD.Size = New System.Drawing.Size(233, 27)
        Me.txtXJAN_CD.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(368, 186)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 32)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "JANｺｰﾄﾞ:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label16.Location = New System.Drawing.Point(369, 316)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(152, 32)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "ﾒｰｶｰｺｰﾄﾞ:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label16.Visible = False
        '
        'cboXIN_RES_TYPE
        '
        Me.cboXIN_RES_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXIN_RES_TYPE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXIN_RES_TYPE.FormattingEnabled = True
        Me.cboXIN_RES_TYPE.IntegralHeight = False
        Me.cboXIN_RES_TYPE.Location = New System.Drawing.Point(521, 220)
        Me.cboXIN_RES_TYPE.Name = "cboXIN_RES_TYPE"
        Me.cboXIN_RES_TYPE.Size = New System.Drawing.Size(168, 28)
        Me.cboXIN_RES_TYPE.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label17.Location = New System.Drawing.Point(368, 217)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(152, 32)
        Me.Label17.TabIndex = 76
        Me.Label17.Text = "空棚引当ﾀｲﾌﾟ:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXMAKER_CD
        '
        Me.txtXMAKER_CD.BackColorMask = System.Drawing.Color.Empty
        Me.txtXMAKER_CD.EnabledFull = True
        Me.txtXMAKER_CD.EnabledFullAlphabetLower = True
        Me.txtXMAKER_CD.EnabledFullAlphabetUpper = True
        Me.txtXMAKER_CD.EnabledFullHiragana = True
        Me.txtXMAKER_CD.EnabledFullKatakana = True
        Me.txtXMAKER_CD.EnabledFullNumber = True
        Me.txtXMAKER_CD.EnabledHalf = True
        Me.txtXMAKER_CD.EnabledHalfAlphabetLower = True
        Me.txtXMAKER_CD.EnabledHalfAlphabetUpper = True
        Me.txtXMAKER_CD.EnabledHalfKatakana = True
        Me.txtXMAKER_CD.EnabledHalfNumber = True
        Me.txtXMAKER_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXMAKER_CD.Location = New System.Drawing.Point(521, 319)
        Me.txtXMAKER_CD.MaxLength = 5
        Me.txtXMAKER_CD.MaxLengthByte = 5
        Me.txtXMAKER_CD.Name = "txtXMAKER_CD"
        Me.txtXMAKER_CD.RegexCustomFalse = Nothing
        Me.txtXMAKER_CD.RegexCustomTrue = Nothing
        Me.txtXMAKER_CD.Size = New System.Drawing.Size(168, 27)
        Me.txtXMAKER_CD.TabIndex = 16
        Me.txtXMAKER_CD.Visible = False
        '
        'txtXSUB_CD
        '
        Me.txtXSUB_CD.BackColorMask = System.Drawing.Color.Empty
        Me.txtXSUB_CD.Enabled = False
        Me.txtXSUB_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXSUB_CD.Format = "#0"
        Me.txtXSUB_CD.Location = New System.Drawing.Point(521, 120)
        Me.txtXSUB_CD.MaxLength = 2
        Me.txtXSUB_CD.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtXSUB_CD.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXSUB_CD.Name = "txtXSUB_CD"
        Me.txtXSUB_CD.Nullable = True
        Me.txtXSUB_CD.Size = New System.Drawing.Size(56, 27)
        Me.txtXSUB_CD.TabIndex = 12
        Me.txtXSUB_CD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXSUB_CD.Value = Nothing
        '
        'txtXHINMEI_CD
        '
        Me.txtXHINMEI_CD.BackColorMask = System.Drawing.Color.Empty
        Me.txtXHINMEI_CD.EnabledFull = False
        Me.txtXHINMEI_CD.EnabledFullAlphabetLower = False
        Me.txtXHINMEI_CD.EnabledFullAlphabetUpper = False
        Me.txtXHINMEI_CD.EnabledFullHiragana = False
        Me.txtXHINMEI_CD.EnabledFullKatakana = False
        Me.txtXHINMEI_CD.EnabledFullNumber = False
        Me.txtXHINMEI_CD.EnabledHalf = True
        Me.txtXHINMEI_CD.EnabledHalfAlphabetLower = False
        Me.txtXHINMEI_CD.EnabledHalfAlphabetUpper = True
        Me.txtXHINMEI_CD.EnabledHalfKatakana = False
        Me.txtXHINMEI_CD.EnabledHalfNumber = True
        Me.txtXHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXHINMEI_CD.Location = New System.Drawing.Point(170, 21)
        Me.txtXHINMEI_CD.MaxLength = 6
        Me.txtXHINMEI_CD.MaxLengthByte = 6
        Me.txtXHINMEI_CD.Name = "txtXHINMEI_CD"
        Me.txtXHINMEI_CD.RegexCustomFalse = Nothing
        Me.txtXHINMEI_CD.RegexCustomTrue = Nothing
        Me.txtXHINMEI_CD.Size = New System.Drawing.Size(135, 27)
        Me.txtXHINMEI_CD.TabIndex = 0
        '
        'FRM_206011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(789, 500)
        Me.Controls.Add(Me.txtXHINMEI_CD)
        Me.Controls.Add(Me.txtXSUB_CD)
        Me.Controls.Add(Me.txtXMAKER_CD)
        Me.Controls.Add(Me.cboXIN_RES_TYPE)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtXJAN_CD)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtXITF_CD)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtXHEIGHT_IN_PALLET)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtXDAN_IN_PALLET)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtXWEIGHT_IN_PALLET)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtXHEIGHT_IN_CASE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtXWEIGHT_IN_CASE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtXPLANE_PACK_NUMBER)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFHINMEI_CD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.txtFNUM_IN_PALLET)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboXARTICLE_TYPE_CODE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboFRAC_FORM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFHINMEI)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label12)
        Me.Name = "FRM_206011"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "品名マスタメンテナンス"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFHINMEI As MateCommon.cmpMTextBoxString
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboFRAC_FORM As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboXARTICLE_TYPE_CODE As MateCommon.cmpMComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFNUM_IN_PALLET As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents txtFHINMEI_CD As MateCommon.cmpMTextBoxString
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtXPLANE_PACK_NUMBER As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtXWEIGHT_IN_CASE As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtXHEIGHT_IN_CASE As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtXWEIGHT_IN_PALLET As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtXDAN_IN_PALLET As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtXHEIGHT_IN_PALLET As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtXITF_CD As MateCommon.cmpMTextBoxString
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtXJAN_CD As MateCommon.cmpMTextBoxString
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboXIN_RES_TYPE As MateCommon.cmpMComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtXMAKER_CD As MateCommon.cmpMTextBoxString
    Friend WithEvents txtXSUB_CD As MateCommon.cmpMTextBoxNumber
    Friend WithEvents txtXHINMEI_CD As MateCommon.cmpMTextBoxString

End Class
