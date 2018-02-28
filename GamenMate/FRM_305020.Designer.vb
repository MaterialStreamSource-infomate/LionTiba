<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_305020
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
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboXPALLET_NO_TO = New MateCommon.cmpMComboBox
        Me.cboXPALLET_NO_FROM = New MateCommon.cmpMComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboFPLACE_CD = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_KAHI = New MateCommon.cmpMComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXLINE_NO = New MateCommon.cmpMComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboXSEIZOU_DT = New MateCommon.cmpMComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1064, 717)
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
        Me.cmdF1.Location = New System.Drawing.Point(1144, 220)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 272)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 376)
        Me.grdList.TabIndex = 204
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboXPALLET_NO_TO)
        Me.GroupBox2.Controls.Add(Me.cboXPALLET_NO_FROM)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboFPLACE_CD)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboXSYUKKA_KAHI)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cboXLINE_NO)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cboXSEIZOU_DT)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(960, 175)
        Me.GroupBox2.TabIndex = 213
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(160, 54)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(144, 28)
        Me.cboFHINMEI_CD.TabIndex = 3
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(624, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 32)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "～"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboXPALLET_NO_TO
        '
        Me.cboXPALLET_NO_TO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXPALLET_NO_TO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXPALLET_NO_TO.FormattingEnabled = True
        Me.cboXPALLET_NO_TO.IntegralHeight = False
        Me.cboXPALLET_NO_TO.Location = New System.Drawing.Point(664, 91)
        Me.cboXPALLET_NO_TO.Name = "cboXPALLET_NO_TO"
        Me.cboXPALLET_NO_TO.Size = New System.Drawing.Size(144, 28)
        Me.cboXPALLET_NO_TO.TabIndex = 10
        '
        'cboXPALLET_NO_FROM
        '
        Me.cboXPALLET_NO_FROM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXPALLET_NO_FROM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXPALLET_NO_FROM.FormattingEnabled = True
        Me.cboXPALLET_NO_FROM.IntegralHeight = False
        Me.cboXPALLET_NO_FROM.Location = New System.Drawing.Point(472, 91)
        Me.cboXPALLET_NO_FROM.Name = "cboXPALLET_NO_FROM"
        Me.cboXPALLET_NO_FROM.Size = New System.Drawing.Size(144, 28)
        Me.cboXPALLET_NO_FROM.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(333, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 32)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "ﾊﾟﾚｯﾄ№:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFPLACE_CD
        '
        Me.cboFPLACE_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPLACE_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFPLACE_CD.FormattingEnabled = True
        Me.cboFPLACE_CD.IntegralHeight = False
        Me.cboFPLACE_CD.Location = New System.Drawing.Point(472, 131)
        Me.cboFPLACE_CD.Name = "cboFPLACE_CD"
        Me.cboFPLACE_CD.Size = New System.Drawing.Size(192, 28)
        Me.cboFPLACE_CD.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(333, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 32)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "保管場所:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_KAHI
        '
        Me.cboXSYUKKA_KAHI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYUKKA_KAHI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYUKKA_KAHI.FormattingEnabled = True
        Me.cboXSYUKKA_KAHI.IntegralHeight = False
        Me.cboXSYUKKA_KAHI.Location = New System.Drawing.Point(160, 131)
        Me.cboXSYUKKA_KAHI.Name = "cboXSYUKKA_KAHI"
        Me.cboXSYUKKA_KAHI.Size = New System.Drawing.Size(144, 28)
        Me.cboXSYUKKA_KAHI.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(21, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 32)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "出荷可否:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXLINE_NO
        '
        Me.cboXLINE_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXLINE_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXLINE_NO.FormattingEnabled = True
        Me.cboXLINE_NO.IntegralHeight = False
        Me.cboXLINE_NO.Location = New System.Drawing.Point(160, 19)
        Me.cboXLINE_NO.Name = "cboXLINE_NO"
        Me.cboXLINE_NO.Size = New System.Drawing.Size(144, 28)
        Me.cboXLINE_NO.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(21, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 32)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "ﾗｲﾝ№:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSEIZOU_DT
        '
        Me.cboXSEIZOU_DT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSEIZOU_DT.FormattingEnabled = True
        Me.cboXSEIZOU_DT.IntegralHeight = False
        Me.cboXSEIZOU_DT.Location = New System.Drawing.Point(160, 91)
        Me.cboXSEIZOU_DT.Name = "cboXSEIZOU_DT"
        Me.cboXSEIZOU_DT.Size = New System.Drawing.Size(144, 28)
        Me.cboXSEIZOU_DT.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(21, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 32)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "製造年月日:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(312, 51)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(592, 32)
        Me.lblFHINMEI.TabIndex = 4
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(21, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 32)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "品名ｺｰﾄﾞ:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_305020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grdList)
        Me.Name = "FRM_305020"
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
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboXLINE_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboXSEIZOU_DT As MateCommon.cmpMComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboXPALLET_NO_FROM As MateCommon.cmpMComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboFPLACE_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboXSYUKKA_KAHI As MateCommon.cmpMComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboXPALLET_NO_TO As MateCommon.cmpMComboBox
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD

End Class
