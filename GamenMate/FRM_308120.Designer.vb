<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308120
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
        Me.cboFPLACE_CD = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.chkHINMOK_SUM = New System.Windows.Forms.CheckBox
        Me.cboXHINSHITU_STS = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboXSEIZOU_DT = New MateCommon.cmpMComboBox
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1160, 664)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(1160, 616)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(278, 672)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 672)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 246)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFPLACE_CD)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 64)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'cboFPLACE_CD
        '
        Me.cboFPLACE_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPLACE_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFPLACE_CD.FormattingEnabled = True
        Me.cboFPLACE_CD.IntegralHeight = False
        Me.cboFPLACE_CD.Location = New System.Drawing.Point(152, 18)
        Me.cboFPLACE_CD.Name = "cboFPLACE_CD"
        Me.cboFPLACE_CD.Size = New System.Drawing.Size(301, 28)
        Me.cboFPLACE_CD.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(40, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "保管場所:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 296)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 355)
        Me.grdList.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboFHINMEI_CD)
        Me.GroupBox2.Controls.Add(Me.chkHINMOK_SUM)
        Me.GroupBox2.Controls.Add(Me.cboXHINSHITU_STS)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboXSEIZOU_DT)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(167, 159)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(960, 130)
        Me.GroupBox2.TabIndex = 20
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(152, 16)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(192, 28)
        Me.cboFHINMEI_CD.TabIndex = 1
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'chkHINMOK_SUM
        '
        Me.chkHINMOK_SUM.AutoSize = True
        Me.chkHINMOK_SUM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkHINMOK_SUM.ForeColor = System.Drawing.Color.Black
        Me.chkHINMOK_SUM.Location = New System.Drawing.Point(576, 98)
        Me.chkHINMOK_SUM.Name = "chkHINMOK_SUM"
        Me.chkHINMOK_SUM.Size = New System.Drawing.Size(112, 24)
        Me.chkHINMOK_SUM.TabIndex = 7
        Me.chkHINMOK_SUM.Text = "品目集計"
        Me.chkHINMOK_SUM.UseVisualStyleBackColor = True
        '
        'cboXHINSHITU_STS
        '
        Me.cboXHINSHITU_STS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXHINSHITU_STS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXHINSHITU_STS.FormattingEnabled = True
        Me.cboXHINSHITU_STS.IntegralHeight = False
        Me.cboXHINSHITU_STS.Location = New System.Drawing.Point(152, 96)
        Me.cboXHINSHITU_STS.Name = "cboXHINSHITU_STS"
        Me.cboXHINSHITU_STS.Size = New System.Drawing.Size(192, 28)
        Me.cboXHINSHITU_STS.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(32, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 32)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "品質ｽﾃｰﾀｽ:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSEIZOU_DT
        '
        Me.cboXSEIZOU_DT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSEIZOU_DT.FormattingEnabled = True
        Me.cboXSEIZOU_DT.IntegralHeight = False
        Me.cboXSEIZOU_DT.Location = New System.Drawing.Point(152, 56)
        Me.cboXSEIZOU_DT.Name = "cboXSEIZOU_DT"
        Me.cboXSEIZOU_DT.Size = New System.Drawing.Size(192, 28)
        Me.cboXSEIZOU_DT.TabIndex = 4
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(348, 16)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(364, 32)
        Me.lblFHINMEI.TabIndex = 2
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "製造年月日:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(23, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 32)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "品名ｺｰﾄﾞ:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_308120
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_308120"
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboFPLACE_CD As MateCommon.cmpMComboBox
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboXSEIZOU_DT As MateCommon.cmpMComboBox
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboXHINSHITU_STS As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkHINMOK_SUM As System.Windows.Forms.CheckBox
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD

End Class
