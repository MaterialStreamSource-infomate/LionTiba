<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_310011
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
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboXPROD_LINE = New MateCommon.cmpMComboBox
        Me.cmdIN_Start = New System.Windows.Forms.Button
        Me.cmdIN_End = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblIN_ST = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpFARRIVE_DT = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboXKENPIN_KUBUN = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboFIN_KUBUN = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboFHORYU_KUBUN = New MateCommon.cmpMComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboXKENSA_KUBUN = New MateCommon.cmpMComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboXMAKER_CD = New MateCommon.cmpMComboBox
        Me.SuspendLayout()
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(179, 63)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(263, 28)
        Me.cboFHINMEI_CD.TabIndex = 1
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XKANRI_KUBUN = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(179, 110)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 18
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(8, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 32)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "品名ｺｰﾄﾞ/記号:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 32)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "品名:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 32)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "入庫ST:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 32)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "生産ﾗｲﾝNo.:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXPROD_LINE
        '
        Me.cboXPROD_LINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXPROD_LINE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXPROD_LINE.FormattingEnabled = True
        Me.cboXPROD_LINE.IntegralHeight = False
        Me.cboXPROD_LINE.Location = New System.Drawing.Point(179, 225)
        Me.cboXPROD_LINE.Name = "cboXPROD_LINE"
        Me.cboXPROD_LINE.Size = New System.Drawing.Size(263, 28)
        Me.cboXPROD_LINE.TabIndex = 3
        '
        'cmdIN_Start
        '
        Me.cmdIN_Start.BackColor = System.Drawing.Color.DarkGray
        Me.cmdIN_Start.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIN_Start.ForeColor = System.Drawing.Color.Black
        Me.cmdIN_Start.Location = New System.Drawing.Point(59, 410)
        Me.cmdIN_Start.Name = "cmdIN_Start"
        Me.cmdIN_Start.Size = New System.Drawing.Size(187, 40)
        Me.cmdIN_Start.TabIndex = 30
        Me.cmdIN_Start.Text = "生産開始"
        Me.cmdIN_Start.UseVisualStyleBackColor = False
        '
        'cmdIN_End
        '
        Me.cmdIN_End.BackColor = System.Drawing.Color.DarkGray
        Me.cmdIN_End.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIN_End.ForeColor = System.Drawing.Color.Black
        Me.cmdIN_End.Location = New System.Drawing.Point(363, 410)
        Me.cmdIN_End.Name = "cmdIN_End"
        Me.cmdIN_End.Size = New System.Drawing.Size(187, 40)
        Me.cmdIN_End.TabIndex = 31
        Me.cmdIN_End.Text = "生産終了"
        Me.cmdIN_End.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(695, 410)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdCancel.TabIndex = 32
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lblIN_ST
        '
        Me.lblIN_ST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIN_ST.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblIN_ST.ForeColor = System.Drawing.Color.Black
        Me.lblIN_ST.Location = New System.Drawing.Point(179, 10)
        Me.lblIN_ST.Name = "lblIN_ST"
        Me.lblIN_ST.Size = New System.Drawing.Size(440, 32)
        Me.lblIN_ST.TabIndex = 29
        Me.lblIN_ST.Text = "ST名"
        Me.lblIN_ST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(4, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(169, 32)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "在庫発生日時:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFARRIVE_DT
        '
        Me.dtpFARRIVE_DT.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFARRIVE_DT.Location = New System.Drawing.Point(179, 164)
        Me.dtpFARRIVE_DT.Name = "dtpFARRIVE_DT"
        Me.dtpFARRIVE_DT.Size = New System.Drawing.Size(299, 30)
        Me.dtpFARRIVE_DT.TabIndex = 2
        Me.dtpFARRIVE_DT.TimeComboDisp = True
        Me.dtpFARRIVE_DT.userChecked = True
        Me.dtpFARRIVE_DT.userShowCheckBox = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(460, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 32)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "メーカーコード:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXKENPIN_KUBUN
        '
        Me.cboXKENPIN_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXKENPIN_KUBUN.DropDownWidth = 150
        Me.cboXKENPIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboXKENPIN_KUBUN.FormattingEnabled = True
        Me.cboXKENPIN_KUBUN.IntegralHeight = False
        Me.cboXKENPIN_KUBUN.Location = New System.Drawing.Point(633, 339)
        Me.cboXKENPIN_KUBUN.Name = "cboXKENPIN_KUBUN"
        Me.cboXKENPIN_KUBUN.Size = New System.Drawing.Size(263, 27)
        Me.cboXKENPIN_KUBUN.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(525, 341)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "検品区分:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFIN_KUBUN
        '
        Me.cboFIN_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIN_KUBUN.DropDownWidth = 150
        Me.cboFIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFIN_KUBUN.FormattingEnabled = True
        Me.cboFIN_KUBUN.IntegralHeight = False
        Me.cboFIN_KUBUN.Location = New System.Drawing.Point(179, 339)
        Me.cboFIN_KUBUN.Name = "cboFIN_KUBUN"
        Me.cboFIN_KUBUN.Size = New System.Drawing.Size(263, 27)
        Me.cboFIN_KUBUN.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(69, 341)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "入庫区分:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFHORYU_KUBUN
        '
        Me.cboFHORYU_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFHORYU_KUBUN.DropDownWidth = 150
        Me.cboFHORYU_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFHORYU_KUBUN.FormattingEnabled = True
        Me.cboFHORYU_KUBUN.IntegralHeight = False
        Me.cboFHORYU_KUBUN.Location = New System.Drawing.Point(633, 281)
        Me.cboFHORYU_KUBUN.Name = "cboFHORYU_KUBUN"
        Me.cboFHORYU_KUBUN.Size = New System.Drawing.Size(263, 27)
        Me.cboFHORYU_KUBUN.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(525, 283)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 20)
        Me.Label10.TabIndex = 40
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
        Me.cboXKENSA_KUBUN.Location = New System.Drawing.Point(179, 281)
        Me.cboXKENSA_KUBUN.Name = "cboXKENSA_KUBUN"
        Me.cboXKENSA_KUBUN.Size = New System.Drawing.Size(263, 27)
        Me.cboXKENSA_KUBUN.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(69, 283)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "検査区分:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXMAKER_CD
        '
        Me.cboXMAKER_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXMAKER_CD.DropDownWidth = 150
        Me.cboXMAKER_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboXMAKER_CD.FormattingEnabled = True
        Me.cboXMAKER_CD.IntegralHeight = False
        Me.cboXMAKER_CD.Location = New System.Drawing.Point(633, 226)
        Me.cboXMAKER_CD.Name = "cboXMAKER_CD"
        Me.cboXMAKER_CD.Size = New System.Drawing.Size(263, 27)
        Me.cboXMAKER_CD.TabIndex = 6
        '
        'FRM_310011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(930, 475)
        Me.Controls.Add(Me.cboXMAKER_CD)
        Me.Controls.Add(Me.cboXKENPIN_KUBUN)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboFIN_KUBUN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboFHORYU_KUBUN)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboXKENSA_KUBUN)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dtpFARRIVE_DT)
        Me.Controls.Add(Me.lblIN_ST)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdIN_End)
        Me.Controls.Add(Me.cmdIN_Start)
        Me.Controls.Add(Me.cboXPROD_LINE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboFHINMEI_CD)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Name = "FRM_310011"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生産入庫開始/終了設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboXPROD_LINE As MateCommon.cmpMComboBox
    Friend WithEvents cmdIN_Start As System.Windows.Forms.Button
    Friend WithEvents cmdIN_End As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblIN_ST As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpFARRIVE_DT As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboXKENPIN_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboFIN_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFHORYU_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboXKENSA_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboXMAKER_CD As MateCommon.cmpMComboBox

End Class
