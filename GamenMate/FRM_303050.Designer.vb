<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303050
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
        Me.cboFTRK_BUF_NO = New MateCommon.cmpMComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSTMode = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.cboFHORYU_KUBUN = New MateCommon.cmpMComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboXHINSHITU_STS = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_KAHI = New MateCommon.cmpMComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXLINE_NO = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboXSEIZOU_DT = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tmr303050 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1152, 717)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1150, 664)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(502, 664)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(278, 664)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 664)
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(1038, 664)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(926, 664)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 248)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 304)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 355)
        Me.grdList.TabIndex = 22
        '
        'cboFTRK_BUF_NO
        '
        Me.cboFTRK_BUF_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO.IntegralHeight = False
        Me.cboFTRK_BUF_NO.Location = New System.Drawing.Point(160, 19)
        Me.cboFTRK_BUF_NO.Name = "cboFTRK_BUF_NO"
        Me.cboFTRK_BUF_NO.Size = New System.Drawing.Size(301, 28)
        Me.cboFTRK_BUF_NO.TabIndex = 338
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSTMode)
        Me.GroupBox1.Controls.Add(Me.cboFTRK_BUF_NO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 89)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 63)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'btnSTMode
        '
        Me.btnSTMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSTMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSTMode.ForeColor = System.Drawing.Color.Black
        Me.btnSTMode.Location = New System.Drawing.Point(480, 16)
        Me.btnSTMode.Name = "btnSTMode"
        Me.btnSTMode.Size = New System.Drawing.Size(152, 31)
        Me.btnSTMode.TabIndex = 341
        Me.btnSTMode.Text = "出庫モード"
        Me.btnSTMode.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 32)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "出庫ST:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox2.Controls.Add(Me.cboFHORYU_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboXHINSHITU_STS)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboXSYUKKA_KAHI)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cboXLINE_NO)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cboXSEIZOU_DT)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 152)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(960, 144)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(160, 16)
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
        'cboFHORYU_KUBUN
        '
        Me.cboFHORYU_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFHORYU_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFHORYU_KUBUN.FormattingEnabled = True
        Me.cboFHORYU_KUBUN.IntegralHeight = False
        Me.cboFHORYU_KUBUN.Location = New System.Drawing.Point(776, 96)
        Me.cboFHORYU_KUBUN.Name = "cboFHORYU_KUBUN"
        Me.cboFHORYU_KUBUN.Size = New System.Drawing.Size(144, 28)
        Me.cboFHORYU_KUBUN.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(637, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 32)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "保留区分:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXHINSHITU_STS
        '
        Me.cboXHINSHITU_STS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXHINSHITU_STS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXHINSHITU_STS.FormattingEnabled = True
        Me.cboXHINSHITU_STS.IntegralHeight = False
        Me.cboXHINSHITU_STS.Location = New System.Drawing.Point(472, 96)
        Me.cboXHINSHITU_STS.Name = "cboXHINSHITU_STS"
        Me.cboXHINSHITU_STS.Size = New System.Drawing.Size(144, 28)
        Me.cboXHINSHITU_STS.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(333, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 32)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "品質ｽﾃｰﾀｽ:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_KAHI
        '
        Me.cboXSYUKKA_KAHI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYUKKA_KAHI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYUKKA_KAHI.FormattingEnabled = True
        Me.cboXSYUKKA_KAHI.IntegralHeight = False
        Me.cboXSYUKKA_KAHI.Location = New System.Drawing.Point(160, 96)
        Me.cboXSYUKKA_KAHI.Name = "cboXSYUKKA_KAHI"
        Me.cboXSYUKKA_KAHI.Size = New System.Drawing.Size(144, 28)
        Me.cboXSYUKKA_KAHI.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(21, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 32)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "出荷可否:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXLINE_NO
        '
        Me.cboXLINE_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXLINE_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXLINE_NO.FormattingEnabled = True
        Me.cboXLINE_NO.IntegralHeight = False
        Me.cboXLINE_NO.Location = New System.Drawing.Point(472, 56)
        Me.cboXLINE_NO.Name = "cboXLINE_NO"
        Me.cboXLINE_NO.Size = New System.Drawing.Size(144, 28)
        Me.cboXLINE_NO.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(333, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 32)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "ﾗｲﾝ№:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSEIZOU_DT
        '
        Me.cboXSEIZOU_DT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSEIZOU_DT.FormattingEnabled = True
        Me.cboXSEIZOU_DT.IntegralHeight = False
        Me.cboXSEIZOU_DT.Location = New System.Drawing.Point(160, 56)
        Me.cboXSEIZOU_DT.Name = "cboXSEIZOU_DT"
        Me.cboXSEIZOU_DT.Size = New System.Drawing.Size(144, 28)
        Me.cboXSEIZOU_DT.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(21, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "製造年月日:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(312, 16)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(592, 32)
        Me.lblFHINMEI.TabIndex = 2
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(21, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "品名ｺｰﾄﾞ:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmr303050
        '
        '
        'FRM_303050
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_303050"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents cboFTRK_BUF_NO As MateCommon.cmpMComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboXLINE_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboXSEIZOU_DT As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFHORYU_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboXHINSHITU_STS As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboXSYUKKA_KAHI As MateCommon.cmpMComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tmr303050 As System.Windows.Forms.Timer
    Friend WithEvents btnSTMode As System.Windows.Forms.Button
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD

End Class
