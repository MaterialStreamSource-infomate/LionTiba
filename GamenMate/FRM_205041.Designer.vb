<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_205041
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
        Me.lblYouki_UseCnt = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.lblFARRIVE_DT = New System.Windows.Forms.Label
        Me.lblNo = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboFRES_KIND = New MateCommon.cmpMComboBox
        Me.dtpFARRIVE_DT = New GamenCommon.cmpMDateTimePicker_DT
        Me.cboFREMOVE_KIND = New MateCommon.cmpMComboBox
        Me.lblFRAC_RETU = New System.Windows.Forms.Label
        Me.lblFRAC_REN = New System.Windows.Forms.Label
        Me.lblFRAC_DAN = New System.Windows.Forms.Label
        Me.txtFTR_VOL = New MateCommon.cmpMTextBoxNumber
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFHORYU_KUBUN = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboXKENSA_KUBUN = New MateCommon.cmpMComboBox
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.Label18 = New System.Windows.Forms.Label
        Me.dtpXRAC_IN_DT = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboFRAC_FORM = New MateCommon.cmpMComboBox
        Me.lblFTR_VOL_VISIBLE = New System.Windows.Forms.Label
        Me.lblFARRIVE_DT_VISIBLE = New System.Windows.Forms.Label
        Me.lblFHORYU_KUBUN_VISIBLE = New System.Windows.Forms.Label
        Me.lblXPROD_LINE_VISIBLE = New System.Windows.Forms.Label
        Me.lblXKENSA_KUBUN_VISIBLE = New System.Windows.Forms.Label
        Me.lblFBUF_IN_DT_VISIBLE = New System.Windows.Forms.Label
        Me.lblFHINMEI_CD_VISIBLE = New System.Windows.Forms.Label
        Me.lblFARRIVE_TM_VISIBLE = New System.Windows.Forms.Label
        Me.lblFBUF_IN_TM_VISIBLE = New System.Windows.Forms.Label
        Me.txtFRAC_BUNRUI = New MateCommon.cmpMTextBoxString
        Me.lblFRAC_BUNRUI_VISIBLE = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboFST_FM = New MateCommon.cmpMComboBox
        Me.lblFST_FM_VISIBLE = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboXKENPIN_KUBUN = New MateCommon.cmpMComboBox
        Me.lblXKENPIN_KUBUN_VISIBLE = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtXTANA_BLOCK_DTL = New MateCommon.cmpMTextBoxString
        Me.lblXTANA_BLOCK_DTL_VISIBLE = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtXTANA_BLOCK = New MateCommon.cmpMTextBoxString
        Me.lblXTANA_BLOCK_VISIBLE = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFLOT_NO = New MateCommon.cmpMTextBoxString
        Me.lblFLOT_NO_VISIBL = New System.Windows.Forms.Label
        Me.lblFIN_KUBUN_VISIBLE = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboFIN_KUBUN = New MateCommon.cmpMComboBox
        Me.lblXTANA_BLOCK_STS_VISIBL = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboXTANA_BLOCK_STS = New MateCommon.cmpMComboBox
        Me.cboXPROD_LINE = New MateCommon.cmpMComboBox
        Me.lblFRAC_EDA = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboXMAKER_CD = New MateCommon.cmpMComboBox
        Me.lblXMAKER_CD_VISIBLE = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblYouki_UseCnt
        '
        Me.lblYouki_UseCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblYouki_UseCnt.ForeColor = System.Drawing.Color.Black
        Me.lblYouki_UseCnt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblYouki_UseCnt.Location = New System.Drawing.Point(16, 86)
        Me.lblYouki_UseCnt.Name = "lblYouki_UseCnt"
        Me.lblYouki_UseCnt.Size = New System.Drawing.Size(152, 32)
        Me.lblYouki_UseCnt.TabIndex = 8
        Me.lblYouki_UseCnt.Text = "禁止設定:"
        Me.lblYouki_UseCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(499, 591)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 40
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(227, 591)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 39
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'lblFARRIVE_DT
        '
        Me.lblFARRIVE_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFARRIVE_DT.ForeColor = System.Drawing.Color.Black
        Me.lblFARRIVE_DT.Location = New System.Drawing.Point(16, 400)
        Me.lblFARRIVE_DT.Name = "lblFARRIVE_DT"
        Me.lblFARRIVE_DT.Size = New System.Drawing.Size(152, 32)
        Me.lblFARRIVE_DT.TabIndex = 19
        Me.lblFARRIVE_DT.Text = "在庫発生日時:"
        Me.lblFARRIVE_DT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNo
        '
        Me.lblNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.Location = New System.Drawing.Point(16, 9)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(152, 32)
        Me.lblNo.TabIndex = 0
        Me.lblNo.Text = "ﾛｹｰｼｮﾝ:"
        Me.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 32)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "引当状態:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(208, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 32)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "-"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label12.Location = New System.Drawing.Point(264, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 32)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "-"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboFRES_KIND
        '
        Me.cboFRES_KIND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRES_KIND.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFRES_KIND.FormattingEnabled = True
        Me.cboFRES_KIND.IntegralHeight = False
        Me.cboFRES_KIND.Location = New System.Drawing.Point(168, 51)
        Me.cboFRES_KIND.Name = "cboFRES_KIND"
        Me.cboFRES_KIND.Size = New System.Drawing.Size(192, 28)
        Me.cboFRES_KIND.TabIndex = 4
        '
        'dtpFARRIVE_DT
        '
        Me.dtpFARRIVE_DT.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFARRIVE_DT.Location = New System.Drawing.Point(168, 403)
        Me.dtpFARRIVE_DT.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpFARRIVE_DT.Name = "dtpFARRIVE_DT"
        Me.dtpFARRIVE_DT.Size = New System.Drawing.Size(296, 32)
        Me.dtpFARRIVE_DT.TabIndex = 24
        Me.dtpFARRIVE_DT.TimeComboDisp = True
        Me.dtpFARRIVE_DT.userChecked = True
        Me.dtpFARRIVE_DT.userShowCheckBox = False
        '
        'cboFREMOVE_KIND
        '
        Me.cboFREMOVE_KIND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFREMOVE_KIND.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFREMOVE_KIND.FormattingEnabled = True
        Me.cboFREMOVE_KIND.IntegralHeight = False
        Me.cboFREMOVE_KIND.Location = New System.Drawing.Point(168, 88)
        Me.cboFREMOVE_KIND.Name = "cboFREMOVE_KIND"
        Me.cboFREMOVE_KIND.Size = New System.Drawing.Size(192, 28)
        Me.cboFREMOVE_KIND.TabIndex = 5
        '
        'lblFRAC_RETU
        '
        Me.lblFRAC_RETU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFRAC_RETU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFRAC_RETU.ForeColor = System.Drawing.Color.Black
        Me.lblFRAC_RETU.Location = New System.Drawing.Point(168, 9)
        Me.lblFRAC_RETU.Name = "lblFRAC_RETU"
        Me.lblFRAC_RETU.Size = New System.Drawing.Size(40, 32)
        Me.lblFRAC_RETU.TabIndex = 0
        Me.lblFRAC_RETU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFRAC_REN
        '
        Me.lblFRAC_REN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFRAC_REN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFRAC_REN.ForeColor = System.Drawing.Color.Black
        Me.lblFRAC_REN.Location = New System.Drawing.Point(224, 9)
        Me.lblFRAC_REN.Name = "lblFRAC_REN"
        Me.lblFRAC_REN.Size = New System.Drawing.Size(40, 32)
        Me.lblFRAC_REN.TabIndex = 1
        Me.lblFRAC_REN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFRAC_DAN
        '
        Me.lblFRAC_DAN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFRAC_DAN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFRAC_DAN.ForeColor = System.Drawing.Color.Black
        Me.lblFRAC_DAN.Location = New System.Drawing.Point(280, 9)
        Me.lblFRAC_DAN.Name = "lblFRAC_DAN"
        Me.lblFRAC_DAN.Size = New System.Drawing.Size(40, 32)
        Me.lblFRAC_DAN.TabIndex = 2
        Me.lblFRAC_DAN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFTR_VOL
        '
        Me.txtFTR_VOL.BackColorMask = System.Drawing.Color.Empty
        Me.txtFTR_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFTR_VOL.Format = "######0"
        Me.txtFTR_VOL.Location = New System.Drawing.Point(168, 363)
        Me.txtFTR_VOL.MaxLength = 7
        Me.txtFTR_VOL.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtFTR_VOL.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtFTR_VOL.Name = "txtFTR_VOL"
        Me.txtFTR_VOL.Nullable = True
        Me.txtFTR_VOL.Size = New System.Drawing.Size(152, 27)
        Me.txtFTR_VOL.TabIndex = 22
        Me.txtFTR_VOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFTR_VOL.Value = Nothing
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label16.Location = New System.Drawing.Point(24, 360)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(144, 32)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "数量:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(1, 280)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 32)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "品名記号/ｺｰﾄﾞ:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFHINMEI.Location = New System.Drawing.Point(368, 279)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(541, 32)
        Me.lblFHINMEI.TabIndex = 14
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(16, 320)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 32)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "ﾛｯﾄ№:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(16, 441)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "保留区分:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFHORYU_KUBUN
        '
        Me.cboFHORYU_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFHORYU_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFHORYU_KUBUN.FormattingEnabled = True
        Me.cboFHORYU_KUBUN.IntegralHeight = False
        Me.cboFHORYU_KUBUN.Location = New System.Drawing.Point(168, 443)
        Me.cboFHORYU_KUBUN.Name = "cboFHORYU_KUBUN"
        Me.cboFHORYU_KUBUN.Size = New System.Drawing.Size(136, 28)
        Me.cboFHORYU_KUBUN.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(24, 480)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 32)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "生産ﾗｲﾝ№:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(48, 520)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 32)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "検査区分:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXKENSA_KUBUN
        '
        Me.cboXKENSA_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXKENSA_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXKENSA_KUBUN.FormattingEnabled = True
        Me.cboXKENSA_KUBUN.IntegralHeight = False
        Me.cboXKENSA_KUBUN.Location = New System.Drawing.Point(168, 522)
        Me.cboXKENSA_KUBUN.Name = "cboXKENSA_KUBUN"
        Me.cboXKENSA_KUBUN.Size = New System.Drawing.Size(136, 28)
        Me.cboXKENSA_KUBUN.TabIndex = 35
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(168, 282)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(192, 28)
        Me.cboFHINMEI_CD.TabIndex = 18
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XKANRI_KUBUN = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(17, 123)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(151, 32)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "入庫日時:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpXRAC_IN_DT
        '
        Me.dtpXRAC_IN_DT.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpXRAC_IN_DT.Location = New System.Drawing.Point(165, 126)
        Me.dtpXRAC_IN_DT.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpXRAC_IN_DT.Name = "dtpXRAC_IN_DT"
        Me.dtpXRAC_IN_DT.Size = New System.Drawing.Size(296, 32)
        Me.dtpXRAC_IN_DT.TabIndex = 7
        Me.dtpXRAC_IN_DT.TimeComboDisp = True
        Me.dtpXRAC_IN_DT.userChecked = True
        Me.dtpXRAC_IN_DT.userShowCheckBox = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label20.Location = New System.Drawing.Point(516, 86)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(152, 32)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "棚形状種別:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFRAC_FORM
        '
        Me.cboFRAC_FORM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_FORM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFRAC_FORM.FormattingEnabled = True
        Me.cboFRAC_FORM.IntegralHeight = False
        Me.cboFRAC_FORM.Location = New System.Drawing.Point(668, 88)
        Me.cboFRAC_FORM.Name = "cboFRAC_FORM"
        Me.cboFRAC_FORM.Size = New System.Drawing.Size(192, 28)
        Me.cboFRAC_FORM.TabIndex = 6
        '
        'lblFTR_VOL_VISIBLE
        '
        Me.lblFTR_VOL_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFTR_VOL_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFTR_VOL_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFTR_VOL_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFTR_VOL_VISIBLE.Location = New System.Drawing.Point(168, 363)
        Me.lblFTR_VOL_VISIBLE.Name = "lblFTR_VOL_VISIBLE"
        Me.lblFTR_VOL_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFTR_VOL_VISIBLE.Size = New System.Drawing.Size(152, 27)
        Me.lblFTR_VOL_VISIBLE.TabIndex = 23
        Me.lblFTR_VOL_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFARRIVE_DT_VISIBLE
        '
        Me.lblFARRIVE_DT_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFARRIVE_DT_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFARRIVE_DT_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFARRIVE_DT_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFARRIVE_DT_VISIBLE.Location = New System.Drawing.Point(168, 405)
        Me.lblFARRIVE_DT_VISIBLE.Name = "lblFARRIVE_DT_VISIBLE"
        Me.lblFARRIVE_DT_VISIBLE.Size = New System.Drawing.Size(169, 27)
        Me.lblFARRIVE_DT_VISIBLE.TabIndex = 25
        Me.lblFARRIVE_DT_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFHORYU_KUBUN_VISIBLE
        '
        Me.lblFHORYU_KUBUN_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHORYU_KUBUN_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHORYU_KUBUN_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFHORYU_KUBUN_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFHORYU_KUBUN_VISIBLE.Location = New System.Drawing.Point(168, 443)
        Me.lblFHORYU_KUBUN_VISIBLE.Name = "lblFHORYU_KUBUN_VISIBLE"
        Me.lblFHORYU_KUBUN_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFHORYU_KUBUN_VISIBLE.Size = New System.Drawing.Size(136, 28)
        Me.lblFHORYU_KUBUN_VISIBLE.TabIndex = 30
        Me.lblFHORYU_KUBUN_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblXPROD_LINE_VISIBLE
        '
        Me.lblXPROD_LINE_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXPROD_LINE_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXPROD_LINE_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblXPROD_LINE_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblXPROD_LINE_VISIBLE.Location = New System.Drawing.Point(168, 483)
        Me.lblXPROD_LINE_VISIBLE.Name = "lblXPROD_LINE_VISIBLE"
        Me.lblXPROD_LINE_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXPROD_LINE_VISIBLE.Size = New System.Drawing.Size(259, 27)
        Me.lblXPROD_LINE_VISIBLE.TabIndex = 34
        Me.lblXPROD_LINE_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblXKENSA_KUBUN_VISIBLE
        '
        Me.lblXKENSA_KUBUN_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXKENSA_KUBUN_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXKENSA_KUBUN_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblXKENSA_KUBUN_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblXKENSA_KUBUN_VISIBLE.Location = New System.Drawing.Point(168, 522)
        Me.lblXKENSA_KUBUN_VISIBLE.Name = "lblXKENSA_KUBUN_VISIBLE"
        Me.lblXKENSA_KUBUN_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXKENSA_KUBUN_VISIBLE.Size = New System.Drawing.Size(136, 28)
        Me.lblXKENSA_KUBUN_VISIBLE.TabIndex = 36
        Me.lblXKENSA_KUBUN_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFBUF_IN_DT_VISIBLE
        '
        Me.lblFBUF_IN_DT_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFBUF_IN_DT_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFBUF_IN_DT_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFBUF_IN_DT_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFBUF_IN_DT_VISIBLE.Location = New System.Drawing.Point(168, 128)
        Me.lblFBUF_IN_DT_VISIBLE.Name = "lblFBUF_IN_DT_VISIBLE"
        Me.lblFBUF_IN_DT_VISIBLE.Size = New System.Drawing.Size(165, 27)
        Me.lblFBUF_IN_DT_VISIBLE.TabIndex = 8
        Me.lblFBUF_IN_DT_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFHINMEI_CD_VISIBLE
        '
        Me.lblFHINMEI_CD_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI_CD_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI_CD_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI_CD_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFHINMEI_CD_VISIBLE.Location = New System.Drawing.Point(168, 282)
        Me.lblFHINMEI_CD_VISIBLE.Name = "lblFHINMEI_CD_VISIBLE"
        Me.lblFHINMEI_CD_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFHINMEI_CD_VISIBLE.Size = New System.Drawing.Size(192, 28)
        Me.lblFHINMEI_CD_VISIBLE.TabIndex = 19
        Me.lblFHINMEI_CD_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFARRIVE_TM_VISIBLE
        '
        Me.lblFARRIVE_TM_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFARRIVE_TM_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFARRIVE_TM_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFARRIVE_TM_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFARRIVE_TM_VISIBLE.Location = New System.Drawing.Point(343, 405)
        Me.lblFARRIVE_TM_VISIBLE.Name = "lblFARRIVE_TM_VISIBLE"
        Me.lblFARRIVE_TM_VISIBLE.Size = New System.Drawing.Size(120, 27)
        Me.lblFARRIVE_TM_VISIBLE.TabIndex = 26
        Me.lblFARRIVE_TM_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFBUF_IN_TM_VISIBLE
        '
        Me.lblFBUF_IN_TM_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFBUF_IN_TM_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFBUF_IN_TM_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFBUF_IN_TM_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFBUF_IN_TM_VISIBLE.Location = New System.Drawing.Point(340, 128)
        Me.lblFBUF_IN_TM_VISIBLE.Name = "lblFBUF_IN_TM_VISIBLE"
        Me.lblFBUF_IN_TM_VISIBLE.Size = New System.Drawing.Size(120, 27)
        Me.lblFBUF_IN_TM_VISIBLE.TabIndex = 9
        Me.lblFBUF_IN_TM_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFRAC_BUNRUI
        '
        Me.txtFRAC_BUNRUI.BackColorMask = System.Drawing.Color.Empty
        Me.txtFRAC_BUNRUI.EnabledFull = True
        Me.txtFRAC_BUNRUI.EnabledFullAlphabetLower = True
        Me.txtFRAC_BUNRUI.EnabledFullAlphabetUpper = True
        Me.txtFRAC_BUNRUI.EnabledFullHiragana = True
        Me.txtFRAC_BUNRUI.EnabledFullKatakana = True
        Me.txtFRAC_BUNRUI.EnabledFullNumber = True
        Me.txtFRAC_BUNRUI.EnabledHalf = True
        Me.txtFRAC_BUNRUI.EnabledHalfAlphabetLower = True
        Me.txtFRAC_BUNRUI.EnabledHalfAlphabetUpper = True
        Me.txtFRAC_BUNRUI.EnabledHalfKatakana = True
        Me.txtFRAC_BUNRUI.EnabledHalfNumber = True
        Me.txtFRAC_BUNRUI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFRAC_BUNRUI.Location = New System.Drawing.Point(168, 168)
        Me.txtFRAC_BUNRUI.MaxLength = 10
        Me.txtFRAC_BUNRUI.MaxLengthByte = 10
        Me.txtFRAC_BUNRUI.Name = "txtFRAC_BUNRUI"
        Me.txtFRAC_BUNRUI.RegexCustomFalse = Nothing
        Me.txtFRAC_BUNRUI.RegexCustomTrue = Nothing
        Me.txtFRAC_BUNRUI.Size = New System.Drawing.Size(136, 27)
        Me.txtFRAC_BUNRUI.TabIndex = 10
        '
        'lblFRAC_BUNRUI_VISIBLE
        '
        Me.lblFRAC_BUNRUI_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFRAC_BUNRUI_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFRAC_BUNRUI_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFRAC_BUNRUI_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFRAC_BUNRUI_VISIBLE.Location = New System.Drawing.Point(168, 168)
        Me.lblFRAC_BUNRUI_VISIBLE.Name = "lblFRAC_BUNRUI_VISIBLE"
        Me.lblFRAC_BUNRUI_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFRAC_BUNRUI_VISIBLE.Size = New System.Drawing.Size(136, 27)
        Me.lblFRAC_BUNRUI_VISIBLE.TabIndex = 11
        Me.lblFRAC_BUNRUI_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(53, 165)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(115, 32)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "棚分類:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFST_FM
        '
        Me.cboFST_FM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFST_FM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFST_FM.FormattingEnabled = True
        Me.cboFST_FM.IntegralHeight = False
        Me.cboFST_FM.Location = New System.Drawing.Point(658, 443)
        Me.cboFST_FM.Name = "cboFST_FM"
        Me.cboFST_FM.Size = New System.Drawing.Size(291, 28)
        Me.cboFST_FM.TabIndex = 31
        '
        'lblFST_FM_VISIBLE
        '
        Me.lblFST_FM_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFST_FM_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFST_FM_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFST_FM_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFST_FM_VISIBLE.Location = New System.Drawing.Point(658, 443)
        Me.lblFST_FM_VISIBLE.Name = "lblFST_FM_VISIBLE"
        Me.lblFST_FM_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFST_FM_VISIBLE.Size = New System.Drawing.Size(291, 28)
        Me.lblFST_FM_VISIBLE.TabIndex = 32
        Me.lblFST_FM_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(394, 441)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(264, 32)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXKENPIN_KUBUN
        '
        Me.cboXKENPIN_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXKENPIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXKENPIN_KUBUN.FormattingEnabled = True
        Me.cboXKENPIN_KUBUN.IntegralHeight = False
        Me.cboXKENPIN_KUBUN.Location = New System.Drawing.Point(658, 522)
        Me.cboXKENPIN_KUBUN.Name = "cboXKENPIN_KUBUN"
        Me.cboXKENPIN_KUBUN.Size = New System.Drawing.Size(136, 28)
        Me.cboXKENPIN_KUBUN.TabIndex = 37
        '
        'lblXKENPIN_KUBUN_VISIBLE
        '
        Me.lblXKENPIN_KUBUN_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXKENPIN_KUBUN_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXKENPIN_KUBUN_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblXKENPIN_KUBUN_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblXKENPIN_KUBUN_VISIBLE.Location = New System.Drawing.Point(658, 522)
        Me.lblXKENPIN_KUBUN_VISIBLE.Name = "lblXKENPIN_KUBUN_VISIBLE"
        Me.lblXKENPIN_KUBUN_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXKENPIN_KUBUN_VISIBLE.Size = New System.Drawing.Size(136, 28)
        Me.lblXKENPIN_KUBUN_VISIBLE.TabIndex = 38
        Me.lblXKENPIN_KUBUN_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(535, 520)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 32)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "検品区分:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXTANA_BLOCK_DTL
        '
        Me.txtXTANA_BLOCK_DTL.BackColorMask = System.Drawing.Color.Empty
        Me.txtXTANA_BLOCK_DTL.EnabledFull = False
        Me.txtXTANA_BLOCK_DTL.EnabledFullAlphabetLower = False
        Me.txtXTANA_BLOCK_DTL.EnabledFullAlphabetUpper = False
        Me.txtXTANA_BLOCK_DTL.EnabledFullHiragana = False
        Me.txtXTANA_BLOCK_DTL.EnabledFullKatakana = False
        Me.txtXTANA_BLOCK_DTL.EnabledFullNumber = False
        Me.txtXTANA_BLOCK_DTL.EnabledHalf = True
        Me.txtXTANA_BLOCK_DTL.EnabledHalfAlphabetLower = False
        Me.txtXTANA_BLOCK_DTL.EnabledHalfAlphabetUpper = False
        Me.txtXTANA_BLOCK_DTL.EnabledHalfKatakana = False
        Me.txtXTANA_BLOCK_DTL.EnabledHalfNumber = True
        Me.txtXTANA_BLOCK_DTL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXTANA_BLOCK_DTL.Location = New System.Drawing.Point(168, 208)
        Me.txtXTANA_BLOCK_DTL.MaxLength = 1
        Me.txtXTANA_BLOCK_DTL.MaxLengthByte = 1
        Me.txtXTANA_BLOCK_DTL.Name = "txtXTANA_BLOCK_DTL"
        Me.txtXTANA_BLOCK_DTL.RegexCustomFalse = Nothing
        Me.txtXTANA_BLOCK_DTL.RegexCustomTrue = Nothing
        Me.txtXTANA_BLOCK_DTL.Size = New System.Drawing.Size(32, 27)
        Me.txtXTANA_BLOCK_DTL.TabIndex = 14
        '
        'lblXTANA_BLOCK_DTL_VISIBLE
        '
        Me.lblXTANA_BLOCK_DTL_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXTANA_BLOCK_DTL_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXTANA_BLOCK_DTL_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblXTANA_BLOCK_DTL_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblXTANA_BLOCK_DTL_VISIBLE.Location = New System.Drawing.Point(168, 208)
        Me.lblXTANA_BLOCK_DTL_VISIBLE.Name = "lblXTANA_BLOCK_DTL_VISIBLE"
        Me.lblXTANA_BLOCK_DTL_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXTANA_BLOCK_DTL_VISIBLE.Size = New System.Drawing.Size(32, 27)
        Me.lblXTANA_BLOCK_DTL_VISIBLE.TabIndex = 15
        Me.lblXTANA_BLOCK_DTL_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(19, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 32)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "棚ﾌﾞﾛｯｸ詳細:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXTANA_BLOCK
        '
        Me.txtXTANA_BLOCK.BackColorMask = System.Drawing.Color.Empty
        Me.txtXTANA_BLOCK.EnabledFull = False
        Me.txtXTANA_BLOCK.EnabledFullAlphabetLower = False
        Me.txtXTANA_BLOCK.EnabledFullAlphabetUpper = False
        Me.txtXTANA_BLOCK.EnabledFullHiragana = False
        Me.txtXTANA_BLOCK.EnabledFullKatakana = False
        Me.txtXTANA_BLOCK.EnabledFullNumber = False
        Me.txtXTANA_BLOCK.EnabledHalf = True
        Me.txtXTANA_BLOCK.EnabledHalfAlphabetLower = False
        Me.txtXTANA_BLOCK.EnabledHalfAlphabetUpper = False
        Me.txtXTANA_BLOCK.EnabledHalfKatakana = False
        Me.txtXTANA_BLOCK.EnabledHalfNumber = True
        Me.txtXTANA_BLOCK.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXTANA_BLOCK.Location = New System.Drawing.Point(668, 170)
        Me.txtXTANA_BLOCK.MaxLength = 4
        Me.txtXTANA_BLOCK.MaxLengthByte = 4
        Me.txtXTANA_BLOCK.Name = "txtXTANA_BLOCK"
        Me.txtXTANA_BLOCK.RegexCustomFalse = Nothing
        Me.txtXTANA_BLOCK.RegexCustomTrue = Nothing
        Me.txtXTANA_BLOCK.Size = New System.Drawing.Size(72, 27)
        Me.txtXTANA_BLOCK.TabIndex = 12
        '
        'lblXTANA_BLOCK_VISIBLE
        '
        Me.lblXTANA_BLOCK_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXTANA_BLOCK_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXTANA_BLOCK_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblXTANA_BLOCK_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblXTANA_BLOCK_VISIBLE.Location = New System.Drawing.Point(668, 170)
        Me.lblXTANA_BLOCK_VISIBLE.Name = "lblXTANA_BLOCK_VISIBLE"
        Me.lblXTANA_BLOCK_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXTANA_BLOCK_VISIBLE.Size = New System.Drawing.Size(72, 27)
        Me.lblXTANA_BLOCK_VISIBLE.TabIndex = 13
        Me.lblXTANA_BLOCK_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(529, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 32)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "棚ﾌﾞﾛｯｸ:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFLOT_NO
        '
        Me.txtFLOT_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtFLOT_NO.EnabledFull = True
        Me.txtFLOT_NO.EnabledFullAlphabetLower = True
        Me.txtFLOT_NO.EnabledFullAlphabetUpper = True
        Me.txtFLOT_NO.EnabledFullHiragana = True
        Me.txtFLOT_NO.EnabledFullKatakana = True
        Me.txtFLOT_NO.EnabledFullNumber = True
        Me.txtFLOT_NO.EnabledHalf = True
        Me.txtFLOT_NO.EnabledHalfAlphabetLower = True
        Me.txtFLOT_NO.EnabledHalfAlphabetUpper = True
        Me.txtFLOT_NO.EnabledHalfKatakana = True
        Me.txtFLOT_NO.EnabledHalfNumber = True
        Me.txtFLOT_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFLOT_NO.Location = New System.Drawing.Point(168, 323)
        Me.txtFLOT_NO.MaxLength = 40
        Me.txtFLOT_NO.MaxLengthByte = 40
        Me.txtFLOT_NO.Name = "txtFLOT_NO"
        Me.txtFLOT_NO.RegexCustomFalse = Nothing
        Me.txtFLOT_NO.RegexCustomTrue = Nothing
        Me.txtFLOT_NO.Size = New System.Drawing.Size(461, 27)
        Me.txtFLOT_NO.TabIndex = 20
        '
        'lblFLOT_NO_VISIBL
        '
        Me.lblFLOT_NO_VISIBL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFLOT_NO_VISIBL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFLOT_NO_VISIBL.ForeColor = System.Drawing.Color.Black
        Me.lblFLOT_NO_VISIBL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFLOT_NO_VISIBL.Location = New System.Drawing.Point(168, 323)
        Me.lblFLOT_NO_VISIBL.Name = "lblFLOT_NO_VISIBL"
        Me.lblFLOT_NO_VISIBL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFLOT_NO_VISIBL.Size = New System.Drawing.Size(461, 27)
        Me.lblFLOT_NO_VISIBL.TabIndex = 21
        Me.lblFLOT_NO_VISIBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFIN_KUBUN_VISIBLE
        '
        Me.lblFIN_KUBUN_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFIN_KUBUN_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFIN_KUBUN_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblFIN_KUBUN_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFIN_KUBUN_VISIBLE.Location = New System.Drawing.Point(658, 402)
        Me.lblFIN_KUBUN_VISIBLE.Name = "lblFIN_KUBUN_VISIBLE"
        Me.lblFIN_KUBUN_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFIN_KUBUN_VISIBLE.Size = New System.Drawing.Size(229, 28)
        Me.lblFIN_KUBUN_VISIBLE.TabIndex = 28
        Me.lblFIN_KUBUN_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label14.Location = New System.Drawing.Point(506, 400)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(152, 32)
        Me.Label14.TabIndex = 71
        Me.Label14.Text = "入庫区分:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFIN_KUBUN
        '
        Me.cboFIN_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFIN_KUBUN.FormattingEnabled = True
        Me.cboFIN_KUBUN.IntegralHeight = False
        Me.cboFIN_KUBUN.Location = New System.Drawing.Point(658, 402)
        Me.cboFIN_KUBUN.Name = "cboFIN_KUBUN"
        Me.cboFIN_KUBUN.Size = New System.Drawing.Size(229, 28)
        Me.cboFIN_KUBUN.TabIndex = 27
        '
        'lblXTANA_BLOCK_STS_VISIBL
        '
        Me.lblXTANA_BLOCK_STS_VISIBL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXTANA_BLOCK_STS_VISIBL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXTANA_BLOCK_STS_VISIBL.ForeColor = System.Drawing.Color.Black
        Me.lblXTANA_BLOCK_STS_VISIBL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblXTANA_BLOCK_STS_VISIBL.Location = New System.Drawing.Point(668, 210)
        Me.lblXTANA_BLOCK_STS_VISIBL.Name = "lblXTANA_BLOCK_STS_VISIBL"
        Me.lblXTANA_BLOCK_STS_VISIBL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXTANA_BLOCK_STS_VISIBL.Size = New System.Drawing.Size(136, 28)
        Me.lblXTANA_BLOCK_STS_VISIBL.TabIndex = 17
        Me.lblXTANA_BLOCK_STS_VISIBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label15.Location = New System.Drawing.Point(516, 208)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 32)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "棚ﾌﾞﾛｯｸ状態:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXTANA_BLOCK_STS
        '
        Me.cboXTANA_BLOCK_STS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXTANA_BLOCK_STS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXTANA_BLOCK_STS.FormattingEnabled = True
        Me.cboXTANA_BLOCK_STS.IntegralHeight = False
        Me.cboXTANA_BLOCK_STS.Location = New System.Drawing.Point(668, 210)
        Me.cboXTANA_BLOCK_STS.Name = "cboXTANA_BLOCK_STS"
        Me.cboXTANA_BLOCK_STS.Size = New System.Drawing.Size(136, 28)
        Me.cboXTANA_BLOCK_STS.TabIndex = 16
        '
        'cboXPROD_LINE
        '
        Me.cboXPROD_LINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXPROD_LINE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXPROD_LINE.FormattingEnabled = True
        Me.cboXPROD_LINE.IntegralHeight = False
        Me.cboXPROD_LINE.Location = New System.Drawing.Point(168, 483)
        Me.cboXPROD_LINE.Name = "cboXPROD_LINE"
        Me.cboXPROD_LINE.Size = New System.Drawing.Size(259, 28)
        Me.cboXPROD_LINE.TabIndex = 33
        '
        'lblFRAC_EDA
        '
        Me.lblFRAC_EDA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFRAC_EDA.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFRAC_EDA.ForeColor = System.Drawing.Color.Black
        Me.lblFRAC_EDA.Location = New System.Drawing.Point(337, 9)
        Me.lblFRAC_EDA.Name = "lblFRAC_EDA"
        Me.lblFRAC_EDA.Size = New System.Drawing.Size(40, 32)
        Me.lblFRAC_EDA.TabIndex = 3
        Me.lblFRAC_EDA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label19.Location = New System.Drawing.Point(321, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(16, 32)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "-"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label13.Location = New System.Drawing.Point(535, 480)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(123, 32)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "ﾒｰｶｰｺｰﾄﾞ:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXMAKER_CD
        '
        Me.cboXMAKER_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXMAKER_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXMAKER_CD.FormattingEnabled = True
        Me.cboXMAKER_CD.IntegralHeight = False
        Me.cboXMAKER_CD.Location = New System.Drawing.Point(658, 484)
        Me.cboXMAKER_CD.Name = "cboXMAKER_CD"
        Me.cboXMAKER_CD.Size = New System.Drawing.Size(229, 28)
        Me.cboXMAKER_CD.TabIndex = 77
        '
        'lblXMAKER_CD_VISIBLE
        '
        Me.lblXMAKER_CD_VISIBLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXMAKER_CD_VISIBLE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXMAKER_CD_VISIBLE.ForeColor = System.Drawing.Color.Black
        Me.lblXMAKER_CD_VISIBLE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblXMAKER_CD_VISIBLE.Location = New System.Drawing.Point(658, 484)
        Me.lblXMAKER_CD_VISIBLE.Name = "lblXMAKER_CD_VISIBLE"
        Me.lblXMAKER_CD_VISIBLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXMAKER_CD_VISIBLE.Size = New System.Drawing.Size(229, 28)
        Me.lblXMAKER_CD_VISIBLE.TabIndex = 78
        Me.lblXMAKER_CD_VISIBLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FRM_205041
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(961, 653)
        Me.Controls.Add(Me.lblXMAKER_CD_VISIBLE)
        Me.Controls.Add(Me.cboXMAKER_CD)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblFRAC_EDA)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblXPROD_LINE_VISIBLE)
        Me.Controls.Add(Me.cboXPROD_LINE)
        Me.Controls.Add(Me.lblXTANA_BLOCK_STS_VISIBL)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboXTANA_BLOCK_STS)
        Me.Controls.Add(Me.lblFIN_KUBUN_VISIBLE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboFIN_KUBUN)
        Me.Controls.Add(Me.lblFLOT_NO_VISIBL)
        Me.Controls.Add(Me.txtFLOT_NO)
        Me.Controls.Add(Me.lblFBUF_IN_TM_VISIBLE)
        Me.Controls.Add(Me.lblFARRIVE_TM_VISIBLE)
        Me.Controls.Add(Me.lblFHINMEI_CD_VISIBLE)
        Me.Controls.Add(Me.lblFBUF_IN_DT_VISIBLE)
        Me.Controls.Add(Me.lblFRAC_BUNRUI_VISIBLE)
        Me.Controls.Add(Me.lblFST_FM_VISIBLE)
        Me.Controls.Add(Me.lblXKENPIN_KUBUN_VISIBLE)
        Me.Controls.Add(Me.lblXTANA_BLOCK_DTL_VISIBLE)
        Me.Controls.Add(Me.lblXKENSA_KUBUN_VISIBLE)
        Me.Controls.Add(Me.lblXTANA_BLOCK_VISIBLE)
        Me.Controls.Add(Me.lblFHORYU_KUBUN_VISIBLE)
        Me.Controls.Add(Me.lblFARRIVE_DT_VISIBLE)
        Me.Controls.Add(Me.lblFTR_VOL_VISIBLE)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cboFRAC_FORM)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dtpXRAC_IN_DT)
        Me.Controls.Add(Me.cboFHINMEI_CD)
        Me.Controls.Add(Me.txtXTANA_BLOCK_DTL)
        Me.Controls.Add(Me.txtFRAC_BUNRUI)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboFST_FM)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboXKENPIN_KUBUN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboXKENSA_KUBUN)
        Me.Controls.Add(Me.txtXTANA_BLOCK)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFHORYU_KUBUN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFRAC_DAN)
        Me.Controls.Add(Me.lblNo)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblYouki_UseCnt)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboFREMOVE_KIND)
        Me.Controls.Add(Me.cboFRES_KIND)
        Me.Controls.Add(Me.lblFRAC_RETU)
        Me.Controls.Add(Me.lblFRAC_REN)
        Me.Controls.Add(Me.lblFARRIVE_DT)
        Me.Controls.Add(Me.dtpFARRIVE_DT)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtFTR_VOL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FRM_205041"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "在庫メンテナンス"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblYouki_UseCnt As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents lblFARRIVE_DT As System.Windows.Forms.Label
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboFRES_KIND As MateCommon.cmpMComboBox
    Friend WithEvents dtpFARRIVE_DT As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents cboFREMOVE_KIND As MateCommon.cmpMComboBox
    Friend WithEvents lblFRAC_RETU As System.Windows.Forms.Label
    Friend WithEvents lblFRAC_REN As System.Windows.Forms.Label
    Friend WithEvents lblFRAC_DAN As System.Windows.Forms.Label
    Friend WithEvents txtFTR_VOL As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFHORYU_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboXKENSA_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpXRAC_IN_DT As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboFRAC_FORM As MateCommon.cmpMComboBox
    Friend WithEvents lblFTR_VOL_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents lblFARRIVE_DT_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents lblFHORYU_KUBUN_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents lblXPROD_LINE_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents lblXKENSA_KUBUN_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents lblFBUF_IN_DT_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI_CD_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents lblFARRIVE_TM_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents lblFBUF_IN_TM_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents txtFRAC_BUNRUI As MateCommon.cmpMTextBoxString
    Friend WithEvents lblFRAC_BUNRUI_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboFST_FM As MateCommon.cmpMComboBox
    Friend WithEvents lblFST_FM_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboXKENPIN_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents lblXKENPIN_KUBUN_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtXTANA_BLOCK_DTL As MateCommon.cmpMTextBoxString
    Friend WithEvents lblXTANA_BLOCK_DTL_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtXTANA_BLOCK As MateCommon.cmpMTextBoxString
    Friend WithEvents lblXTANA_BLOCK_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFLOT_NO As MateCommon.cmpMTextBoxString
    Friend WithEvents lblFLOT_NO_VISIBL As System.Windows.Forms.Label
    Friend WithEvents lblFIN_KUBUN_VISIBLE As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboFIN_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents lblXTANA_BLOCK_STS_VISIBL As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboXTANA_BLOCK_STS As MateCommon.cmpMComboBox
    Friend WithEvents cboXPROD_LINE As MateCommon.cmpMComboBox
    Friend WithEvents lblFRAC_EDA As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboXMAKER_CD As MateCommon.cmpMComboBox
    Friend WithEvents lblXMAKER_CD_VISIBLE As System.Windows.Forms.Label


End Class
