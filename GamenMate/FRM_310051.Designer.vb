<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_310051
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
        Me.cmdOUT_Set = New System.Windows.Forms.Button
        Me.cmdOUT_Cancel = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblMAKER_NAME = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.lblPROD_LINE_NAME = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboXMAKER_CD = New MateCommon.cmpMComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblSTOCK_VOL = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbOUT_ST = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtXOUT_PALLET_NUM = New MateCommon.cmpMTextBoxString
        Me.SuspendLayout()
        '
        'cmdOUT_Set
        '
        Me.cmdOUT_Set.BackColor = System.Drawing.Color.DarkGray
        Me.cmdOUT_Set.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdOUT_Set.ForeColor = System.Drawing.Color.Black
        Me.cmdOUT_Set.Location = New System.Drawing.Point(20, 437)
        Me.cmdOUT_Set.Name = "cmdOUT_Set"
        Me.cmdOUT_Set.Size = New System.Drawing.Size(187, 40)
        Me.cmdOUT_Set.TabIndex = 3
        Me.cmdOUT_Set.Text = "出庫登録"
        Me.cmdOUT_Set.UseVisualStyleBackColor = False
        '
        'cmdOUT_Cancel
        '
        Me.cmdOUT_Cancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdOUT_Cancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdOUT_Cancel.ForeColor = System.Drawing.Color.Black
        Me.cmdOUT_Cancel.Location = New System.Drawing.Point(250, 437)
        Me.cmdOUT_Cancel.Name = "cmdOUT_Cancel"
        Me.cmdOUT_Cancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdOUT_Cancel.TabIndex = 4
        Me.cmdOUT_Cancel.Text = "登録解除"
        Me.cmdOUT_Cancel.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(480, 437)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lblMAKER_NAME
        '
        Me.lblMAKER_NAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMAKER_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblMAKER_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblMAKER_NAME.Location = New System.Drawing.Point(205, 215)
        Me.lblMAKER_NAME.Name = "lblMAKER_NAME"
        Me.lblMAKER_NAME.Size = New System.Drawing.Size(440, 32)
        Me.lblMAKER_NAME.TabIndex = 44
        Me.lblMAKER_NAME.Text = "メーカー名"
        Me.lblMAKER_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(34, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 32)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "メーカー名:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(205, 110)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 42
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(34, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 32)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "品名:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(34, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 32)
        Me.Label2.TabIndex = 40
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(205, 63)
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
        'lblPROD_LINE_NAME
        '
        Me.lblPROD_LINE_NAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPROD_LINE_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblPROD_LINE_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblPROD_LINE_NAME.Location = New System.Drawing.Point(205, 10)
        Me.lblPROD_LINE_NAME.Name = "lblPROD_LINE_NAME"
        Me.lblPROD_LINE_NAME.Size = New System.Drawing.Size(440, 32)
        Me.lblPROD_LINE_NAME.TabIndex = 46
        Me.lblPROD_LINE_NAME.Text = "生産ﾗｲﾝ名"
        Me.lblPROD_LINE_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(34, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 32)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "生産ﾗｲﾝ:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXMAKER_CD
        '
        Me.cboXMAKER_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXMAKER_CD.DropDownWidth = 150
        Me.cboXMAKER_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboXMAKER_CD.FormattingEnabled = True
        Me.cboXMAKER_CD.IntegralHeight = False
        Me.cboXMAKER_CD.Location = New System.Drawing.Point(205, 166)
        Me.cboXMAKER_CD.Name = "cboXMAKER_CD"
        Me.cboXMAKER_CD.Size = New System.Drawing.Size(165, 27)
        Me.cboXMAKER_CD.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(30, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 32)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "メーカーコード:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTOCK_VOL
        '
        Me.lblSTOCK_VOL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSTOCK_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSTOCK_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblSTOCK_VOL.Location = New System.Drawing.Point(205, 315)
        Me.lblSTOCK_VOL.Name = "lblSTOCK_VOL"
        Me.lblSTOCK_VOL.Size = New System.Drawing.Size(127, 32)
        Me.lblSTOCK_VOL.TabIndex = 52
        Me.lblSTOCK_VOL.Text = "0"
        Me.lblSTOCK_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(84, 315)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 32)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "在庫PL数:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbOUT_ST
        '
        Me.cmbOUT_ST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOUT_ST.DropDownWidth = 150
        Me.cmbOUT_ST.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbOUT_ST.FormattingEnabled = True
        Me.cmbOUT_ST.IntegralHeight = False
        Me.cmbOUT_ST.Location = New System.Drawing.Point(205, 374)
        Me.cmbOUT_ST.Name = "cmbOUT_ST"
        Me.cmbOUT_ST.Size = New System.Drawing.Size(165, 27)
        Me.cmbOUT_ST.TabIndex = 53
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(34, 374)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 32)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "出庫ST:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 267)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(191, 32)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "出庫PL設定枚数:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXOUT_PALLET_NUM
        '
        Me.txtXOUT_PALLET_NUM.BackColorMask = System.Drawing.Color.Empty
        Me.txtXOUT_PALLET_NUM.EnabledFull = True
        Me.txtXOUT_PALLET_NUM.EnabledFullAlphabetLower = True
        Me.txtXOUT_PALLET_NUM.EnabledFullAlphabetUpper = True
        Me.txtXOUT_PALLET_NUM.EnabledFullHiragana = True
        Me.txtXOUT_PALLET_NUM.EnabledFullKatakana = True
        Me.txtXOUT_PALLET_NUM.EnabledFullNumber = True
        Me.txtXOUT_PALLET_NUM.EnabledHalf = True
        Me.txtXOUT_PALLET_NUM.EnabledHalfAlphabetLower = True
        Me.txtXOUT_PALLET_NUM.EnabledHalfAlphabetUpper = True
        Me.txtXOUT_PALLET_NUM.EnabledHalfKatakana = True
        Me.txtXOUT_PALLET_NUM.EnabledHalfNumber = True
        Me.txtXOUT_PALLET_NUM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXOUT_PALLET_NUM.Location = New System.Drawing.Point(205, 270)
        Me.txtXOUT_PALLET_NUM.MaxLength = 16
        Me.txtXOUT_PALLET_NUM.MaxLengthByte = 16
        Me.txtXOUT_PALLET_NUM.Name = "txtXOUT_PALLET_NUM"
        Me.txtXOUT_PALLET_NUM.RegexCustomFalse = Nothing
        Me.txtXOUT_PALLET_NUM.RegexCustomTrue = Nothing
        Me.txtXOUT_PALLET_NUM.Size = New System.Drawing.Size(127, 27)
        Me.txtXOUT_PALLET_NUM.TabIndex = 56
        Me.txtXOUT_PALLET_NUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FRM_310051
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(694, 491)
        Me.Controls.Add(Me.txtXOUT_PALLET_NUM)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbOUT_ST)
        Me.Controls.Add(Me.lblSTOCK_VOL)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboXMAKER_CD)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblPROD_LINE_NAME)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMAKER_NAME)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFHINMEI_CD)
        Me.Controls.Add(Me.cmdOUT_Set)
        Me.Controls.Add(Me.cmdOUT_Cancel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "FRM_310051"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "1F包材出庫登録"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOUT_Set As System.Windows.Forms.Button
    Friend WithEvents cmdOUT_Cancel As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblMAKER_NAME As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents lblPROD_LINE_NAME As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboXMAKER_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSTOCK_VOL As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbOUT_ST As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtXOUT_PALLET_NUM As MateCommon.cmpMTextBoxString

End Class
