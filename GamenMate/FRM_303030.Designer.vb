<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303030
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
        Me.cboFTRK_BUF_NO_NYUUKO = New MateCommon.cmpMComboBox
        Me.lblSTMode = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboXARTICLE_TYPE_CODE = New MateCommon.cmpMComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpFrom = New GamenCommon.cmpMDateTimePicker_DT
        Me.cboFTRK_BUF_NO_ZAIKO = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboXPROD_LINE = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpTo = New GamenCommon.cmpMDateTimePicker_DT
        Me.cboFHORYU_KUBUN = New MateCommon.cmpMComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboXKENSA_KUBUN = New MateCommon.cmpMComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.tmr303030 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(516, 671)
        Me.cmdF5.Size = New System.Drawing.Size(140, 43)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 671)
        Me.cmdF4.Size = New System.Drawing.Size(120, 43)
        Me.cmdF4.TabIndex = 30
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 317)
        Me.cmdF1.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFTRK_BUF_NO_NYUUKO)
        Me.GroupBox1.Controls.Add(Me.lblSTMode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(631, 60)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cboFTRK_BUF_NO_NYUUKO
        '
        Me.cboFTRK_BUF_NO_NYUUKO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO_NYUUKO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO_NYUUKO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO_NYUUKO.IntegralHeight = False
        Me.cboFTRK_BUF_NO_NYUUKO.Location = New System.Drawing.Point(171, 18)
        Me.cboFTRK_BUF_NO_NYUUKO.Name = "cboFTRK_BUF_NO_NYUUKO"
        Me.cboFTRK_BUF_NO_NYUUKO.Size = New System.Drawing.Size(244, 28)
        Me.cboFTRK_BUF_NO_NYUUKO.TabIndex = 0
        '
        'lblSTMode
        '
        Me.lblSTMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSTMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSTMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSTMode.ForeColor = System.Drawing.Color.Black
        Me.lblSTMode.Location = New System.Drawing.Point(452, 16)
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
        Me.Label1.Location = New System.Drawing.Point(32, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "入庫ST:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 367)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 298)
        Me.grdList.TabIndex = 20
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboXARTICLE_TYPE_CODE)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.dtpFrom)
        Me.GroupBox2.Controls.Add(Me.cboFTRK_BUF_NO_ZAIKO)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboXPROD_LINE)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtpTo)
        Me.GroupBox2.Controls.Add(Me.cboFHORYU_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cboXKENSA_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 151)
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
        Me.cboXARTICLE_TYPE_CODE.Location = New System.Drawing.Point(171, 169)
        Me.cboXARTICLE_TYPE_CODE.Name = "cboXARTICLE_TYPE_CODE"
        Me.cboXARTICLE_TYPE_CODE.Size = New System.Drawing.Size(165, 28)
        Me.cboXARTICLE_TYPE_CODE.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(5, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(165, 32)
        Me.Label8.TabIndex = 224
        Me.Label8.Text = "商品区分:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFrom
        '
        Me.dtpFrom.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFrom.Location = New System.Drawing.Point(171, 90)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(299, 30)
        Me.dtpFrom.TabIndex = 12
        Me.dtpFrom.TimeComboDisp = True
        Me.dtpFrom.userChecked = True
        Me.dtpFrom.userShowCheckBox = True
        '
        'cboFTRK_BUF_NO_ZAIKO
        '
        Me.cboFTRK_BUF_NO_ZAIKO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO_ZAIKO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO_ZAIKO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO_ZAIKO.IntegralHeight = False
        Me.cboFTRK_BUF_NO_ZAIKO.Location = New System.Drawing.Point(171, 15)
        Me.cboFTRK_BUF_NO_ZAIKO.Name = "cboFTRK_BUF_NO_ZAIKO"
        Me.cboFTRK_BUF_NO_ZAIKO.Size = New System.Drawing.Size(244, 28)
        Me.cboFTRK_BUF_NO_ZAIKO.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 32)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "在庫ｴﾘｱ:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXPROD_LINE
        '
        Me.cboXPROD_LINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXPROD_LINE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXPROD_LINE.FormattingEnabled = True
        Me.cboXPROD_LINE.IntegralHeight = False
        Me.cboXPROD_LINE.Location = New System.Drawing.Point(171, 130)
        Me.cboXPROD_LINE.Name = "cboXPROD_LINE"
        Me.cboXPROD_LINE.Size = New System.Drawing.Size(165, 28)
        Me.cboXPROD_LINE.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(476, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 20)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "～"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpTo
        '
        Me.dtpTo.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpTo.Location = New System.Drawing.Point(510, 90)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(300, 32)
        Me.dtpTo.TabIndex = 13
        Me.dtpTo.TimeComboDisp = True
        Me.dtpTo.userChecked = True
        Me.dtpTo.userShowCheckBox = True
        '
        'cboFHORYU_KUBUN
        '
        Me.cboFHORYU_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFHORYU_KUBUN.DropDownWidth = 150
        Me.cboFHORYU_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFHORYU_KUBUN.FormattingEnabled = True
        Me.cboFHORYU_KUBUN.IntegralHeight = False
        Me.cboFHORYU_KUBUN.Location = New System.Drawing.Point(803, 130)
        Me.cboFHORYU_KUBUN.Name = "cboFHORYU_KUBUN"
        Me.cboFHORYU_KUBUN.Size = New System.Drawing.Size(150, 27)
        Me.cboFHORYU_KUBUN.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(693, 133)
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
        Me.cboXKENSA_KUBUN.Location = New System.Drawing.Point(494, 129)
        Me.cboXKENSA_KUBUN.Name = "cboXKENSA_KUBUN"
        Me.cboXKENSA_KUBUN.Size = New System.Drawing.Size(150, 27)
        Me.cboXKENSA_KUBUN.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(384, 133)
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
        Me.Label4.Location = New System.Drawing.Point(6, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 32)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "生産ﾗｲﾝNo.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 32)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "在庫発生日時:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 50)
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(171, 53)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(165, 28)
        Me.cboFHINMEI_CD.TabIndex = 11
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
        Me.lblFHINMEI.Location = New System.Drawing.Point(344, 53)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 18
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmr303030
        '
        '
        'FRM_303030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_303030"
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
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFTRK_BUF_NO_NYUUKO As MateCommon.cmpMComboBox
    Friend WithEvents lblSTMode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboXPROD_LINE As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents cboFHORYU_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboXKENSA_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFTRK_BUF_NO_ZAIKO As MateCommon.cmpMComboBox
    Friend WithEvents dtpFrom As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents tmr303030 As System.Windows.Forms.Timer
    Friend WithEvents cboXARTICLE_TYPE_CODE As MateCommon.cmpMComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
