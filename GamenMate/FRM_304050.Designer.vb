<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_304050
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
        Me.dtpFrom = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpTo = New GamenCommon.cmpMDateTimePicker_DT
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboXPROD_LINE = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboFRAC_EDA = New MateCommon.cmpMComboBox
        Me.cboFRAC_DAN = New MateCommon.cmpMComboBox
        Me.cboFRAC_REN = New MateCommon.cmpMComboBox
        Me.cboFRAC_RETU = New MateCommon.cmpMComboBox
        Me.lblFHINMEI = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(168, 668)
        Me.cmdF6.TabIndex = 3
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 185)
        Me.cmdF1.TabIndex = 1
        '
        'dtpFrom
        '
        Me.dtpFrom.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpFrom.Location = New System.Drawing.Point(177, 52)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(299, 30)
        Me.dtpFrom.TabIndex = 1
        Me.dtpFrom.TimeComboDisp = True
        Me.dtpFrom.userChecked = True
        Me.dtpFrom.userShowCheckBox = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(482, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 20)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "～"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpTo
        '
        Me.dtpTo.BackColorMask = System.Drawing.SystemColors.Control
        Me.dtpTo.Location = New System.Drawing.Point(519, 52)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(300, 32)
        Me.dtpTo.TabIndex = 2
        Me.dtpTo.TimeComboDisp = True
        Me.dtpTo.userChecked = True
        Me.dtpTo.userShowCheckBox = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 51)
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
        Me.cboXPROD_LINE.Location = New System.Drawing.Point(177, 91)
        Me.cboXPROD_LINE.Name = "cboXPROD_LINE"
        Me.cboXPROD_LINE.Size = New System.Drawing.Size(165, 28)
        Me.cboXPROD_LINE.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(9, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 32)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "生産ﾗｲﾝNo.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 234)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 428)
        Me.grdList.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 15)
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
        Me.cboFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFHINMEI_CD.FormattingEnabled = True
        Me.cboFHINMEI_CD.FRES_KIND = ""
        Me.cboFHINMEI_CD.FTRK_BUF_NO = Nothing
        Me.cboFHINMEI_CD.HinmeiKind = Nothing
        Me.cboFHINMEI_CD.HinmeiLabel = Nothing
        Me.cboFHINMEI_CD.HinmeiVisible = True
        Me.cboFHINMEI_CD.IntegralHeight = False
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(177, 16)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(165, 28)
        Me.cboFHINMEI_CD.TabIndex = 0
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XKANRI_KUBUN = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboFRAC_EDA)
        Me.GroupBox2.Controls.Add(Me.cboFRAC_DAN)
        Me.GroupBox2.Controls.Add(Me.cboFRAC_REN)
        Me.GroupBox2.Controls.Add(Me.cboFRAC_RETU)
        Me.GroupBox2.Controls.Add(Me.dtpFrom)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtpTo)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cboXPROD_LINE)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(970, 136)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(784, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 32)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "枝:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(646, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 32)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "段:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(505, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 32)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "連:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(370, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 32)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "列:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFRAC_EDA
        '
        Me.cboFRAC_EDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_EDA.Enabled = False
        Me.cboFRAC_EDA.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_EDA.FormattingEnabled = True
        Me.cboFRAC_EDA.IntegralHeight = False
        Me.cboFRAC_EDA.Location = New System.Drawing.Point(836, 91)
        Me.cboFRAC_EDA.Name = "cboFRAC_EDA"
        Me.cboFRAC_EDA.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_EDA.TabIndex = 7
        '
        'cboFRAC_DAN
        '
        Me.cboFRAC_DAN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_DAN.Enabled = False
        Me.cboFRAC_DAN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_DAN.FormattingEnabled = True
        Me.cboFRAC_DAN.IntegralHeight = False
        Me.cboFRAC_DAN.Location = New System.Drawing.Point(700, 91)
        Me.cboFRAC_DAN.Name = "cboFRAC_DAN"
        Me.cboFRAC_DAN.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_DAN.TabIndex = 6
        '
        'cboFRAC_REN
        '
        Me.cboFRAC_REN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_REN.Enabled = False
        Me.cboFRAC_REN.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_REN.FormattingEnabled = True
        Me.cboFRAC_REN.IntegralHeight = False
        Me.cboFRAC_REN.Location = New System.Drawing.Point(560, 91)
        Me.cboFRAC_REN.Name = "cboFRAC_REN"
        Me.cboFRAC_REN.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_REN.TabIndex = 5
        '
        'cboFRAC_RETU
        '
        Me.cboFRAC_RETU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFRAC_RETU.Enabled = False
        Me.cboFRAC_RETU.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFRAC_RETU.FormattingEnabled = True
        Me.cboFRAC_RETU.IntegralHeight = False
        Me.cboFRAC_RETU.Location = New System.Drawing.Point(423, 91)
        Me.cboFRAC_RETU.Name = "cboFRAC_RETU"
        Me.cboFRAC_RETU.Size = New System.Drawing.Size(65, 27)
        Me.cboFRAC_RETU.TabIndex = 4
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(348, 13)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 18
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_304050
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FRM_304050"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpFrom As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As GamenCommon.cmpMDateTimePicker_DT
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboXPROD_LINE As MateCommon.cmpMComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents cboFRAC_EDA As MateCommon.cmpMComboBox
    Friend WithEvents cboFRAC_DAN As MateCommon.cmpMComboBox
    Friend WithEvents cboFRAC_REN As MateCommon.cmpMComboBox
    Friend WithEvents cboFRAC_RETU As MateCommon.cmpMComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
