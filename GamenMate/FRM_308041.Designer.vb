<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308041
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
        Me.components = New System.ComponentModel.Container
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdKANRYOU = New System.Windows.Forms.Button
        Me.cboXGAIBU_SOUKO_FLAG = New MateCommon.cmpMComboBox
        Me.lblGAIBU_SOUKO_FLAG = New System.Windows.Forms.Label
        Me.lblXHORYU_REASON = New System.Windows.Forms.Label
        Me.cboXBERTH_SITEI = New MateCommon.cmpMComboBox
        Me.lblXBERTH_SITEI = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblXCAR_NO_WARITUKE = New System.Windows.Forms.Label
        Me.grdList2 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList3 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.txtXCAR_NO_EDA_WARITUKE = New MateCommon.cmpMTextBoxString
        Me.cmdKEIZOKU = New System.Windows.Forms.Button
        Me.cboXDSPCAR_NO_DAIHYOU = New MateCommon.cmpMComboBox
        Me.lblXDSPCAR_NO_DAIHYOU = New System.Windows.Forms.Label
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(464, 288)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdKANRYOU
        '
        Me.cmdKANRYOU.BackColor = System.Drawing.Color.DarkGray
        Me.cmdKANRYOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKANRYOU.ForeColor = System.Drawing.Color.Black
        Me.cmdKANRYOU.Location = New System.Drawing.Point(136, 288)
        Me.cmdKANRYOU.Name = "cmdKANRYOU"
        Me.cmdKANRYOU.Size = New System.Drawing.Size(216, 40)
        Me.cmdKANRYOU.TabIndex = 12
        Me.cmdKANRYOU.Text = "同一車輌受付完了"
        Me.cmdKANRYOU.UseVisualStyleBackColor = False
        '
        'cboXGAIBU_SOUKO_FLAG
        '
        Me.cboXGAIBU_SOUKO_FLAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXGAIBU_SOUKO_FLAG.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXGAIBU_SOUKO_FLAG.FormattingEnabled = True
        Me.cboXGAIBU_SOUKO_FLAG.IntegralHeight = False
        Me.cboXGAIBU_SOUKO_FLAG.Location = New System.Drawing.Point(384, 131)
        Me.cboXGAIBU_SOUKO_FLAG.Name = "cboXGAIBU_SOUKO_FLAG"
        Me.cboXGAIBU_SOUKO_FLAG.Size = New System.Drawing.Size(192, 28)
        Me.cboXGAIBU_SOUKO_FLAG.TabIndex = 6
        '
        'lblGAIBU_SOUKO_FLAG
        '
        Me.lblGAIBU_SOUKO_FLAG.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblGAIBU_SOUKO_FLAG.ForeColor = System.Drawing.Color.Black
        Me.lblGAIBU_SOUKO_FLAG.Location = New System.Drawing.Point(224, 128)
        Me.lblGAIBU_SOUKO_FLAG.Name = "lblGAIBU_SOUKO_FLAG"
        Me.lblGAIBU_SOUKO_FLAG.Size = New System.Drawing.Size(160, 32)
        Me.lblGAIBU_SOUKO_FLAG.TabIndex = 5
        Me.lblGAIBU_SOUKO_FLAG.Text = "外部倉庫先行:"
        Me.lblGAIBU_SOUKO_FLAG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXHORYU_REASON
        '
        Me.lblXHORYU_REASON.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXHORYU_REASON.ForeColor = System.Drawing.Color.Black
        Me.lblXHORYU_REASON.Location = New System.Drawing.Point(32, 16)
        Me.lblXHORYU_REASON.Name = "lblXHORYU_REASON"
        Me.lblXHORYU_REASON.Size = New System.Drawing.Size(512, 56)
        Me.lblXHORYU_REASON.TabIndex = 0
        Me.lblXHORYU_REASON.Text = "以下の内容で入門受付しますが、よろしいですか？"
        Me.lblXHORYU_REASON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboXBERTH_SITEI
        '
        Me.cboXBERTH_SITEI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXBERTH_SITEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXBERTH_SITEI.FormattingEnabled = True
        Me.cboXBERTH_SITEI.IntegralHeight = False
        Me.cboXBERTH_SITEI.Location = New System.Drawing.Point(384, 171)
        Me.cboXBERTH_SITEI.Name = "cboXBERTH_SITEI"
        Me.cboXBERTH_SITEI.Size = New System.Drawing.Size(192, 28)
        Me.cboXBERTH_SITEI.TabIndex = 8
        '
        'lblXBERTH_SITEI
        '
        Me.lblXBERTH_SITEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXBERTH_SITEI.ForeColor = System.Drawing.Color.Black
        Me.lblXBERTH_SITEI.Location = New System.Drawing.Point(224, 168)
        Me.lblXBERTH_SITEI.Name = "lblXBERTH_SITEI"
        Me.lblXBERTH_SITEI.Size = New System.Drawing.Size(160, 32)
        Me.lblXBERTH_SITEI.TabIndex = 7
        Me.lblXBERTH_SITEI.Text = "ﾊﾞｰｽ指定:"
        Me.lblXBERTH_SITEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(48, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 32)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "受付車番:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(48, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 32)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "枝番:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXCAR_NO_WARITUKE
        '
        Me.lblXCAR_NO_WARITUKE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXCAR_NO_WARITUKE.ForeColor = System.Drawing.Color.Black
        Me.lblXCAR_NO_WARITUKE.Location = New System.Drawing.Point(160, 88)
        Me.lblXCAR_NO_WARITUKE.Name = "lblXCAR_NO_WARITUKE"
        Me.lblXCAR_NO_WARITUKE.Size = New System.Drawing.Size(64, 32)
        Me.lblXCAR_NO_WARITUKE.TabIndex = 2
        Me.lblXCAR_NO_WARITUKE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdList2
        '
        Me.grdList2.blnDBUpdate = False
        Me.grdList2.blnSelectionChanged = False
        Me.grdList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList2.Location = New System.Drawing.Point(736, 16)
        Me.grdList2.MyBeseDoubleBuffered = False
        Me.grdList2.Name = "grdList2"
        Me.grdList2.RowTemplate.Height = 21
        Me.grdList2.Size = New System.Drawing.Size(72, 40)
        Me.grdList2.TabIndex = 14
        Me.grdList2.Visible = False
        '
        'grdList3
        '
        Me.grdList3.blnDBUpdate = False
        Me.grdList3.blnSelectionChanged = False
        Me.grdList3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList3.Location = New System.Drawing.Point(736, 64)
        Me.grdList3.MyBeseDoubleBuffered = False
        Me.grdList3.Name = "grdList3"
        Me.grdList3.RowTemplate.Height = 21
        Me.grdList3.Size = New System.Drawing.Size(72, 40)
        Me.grdList3.TabIndex = 15
        Me.grdList3.Visible = False
        '
        'txtXCAR_NO_EDA_WARITUKE
        '
        Me.txtXCAR_NO_EDA_WARITUKE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFull = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullAlphabetLower = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullAlphabetUpper = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullHiragana = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullKatakana = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledFullNumber = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalf = True
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfAlphabetLower = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfAlphabetUpper = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfKatakana = False
        Me.txtXCAR_NO_EDA_WARITUKE.EnabledHalfNumber = True
        Me.txtXCAR_NO_EDA_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXCAR_NO_EDA_WARITUKE.Location = New System.Drawing.Point(160, 128)
        Me.txtXCAR_NO_EDA_WARITUKE.MaxLength = 1
        Me.txtXCAR_NO_EDA_WARITUKE.MaxLengthByte = 1
        Me.txtXCAR_NO_EDA_WARITUKE.Name = "txtXCAR_NO_EDA_WARITUKE"
        Me.txtXCAR_NO_EDA_WARITUKE.RegexCustomFalse = Nothing
        Me.txtXCAR_NO_EDA_WARITUKE.RegexCustomTrue = Nothing
        Me.txtXCAR_NO_EDA_WARITUKE.Size = New System.Drawing.Size(24, 27)
        Me.txtXCAR_NO_EDA_WARITUKE.TabIndex = 4
        '
        'cmdKEIZOKU
        '
        Me.cmdKEIZOKU.BackColor = System.Drawing.Color.DarkGray
        Me.cmdKEIZOKU.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKEIZOKU.ForeColor = System.Drawing.Color.Black
        Me.cmdKEIZOKU.Location = New System.Drawing.Point(592, 208)
        Me.cmdKEIZOKU.Name = "cmdKEIZOKU"
        Me.cmdKEIZOKU.Size = New System.Drawing.Size(216, 40)
        Me.cmdKEIZOKU.TabIndex = 11
        Me.cmdKEIZOKU.Text = "同一車輌受付継続"
        Me.cmdKEIZOKU.UseVisualStyleBackColor = False
        '
        'cboXDSPCAR_NO_DAIHYOU
        '
        Me.cboXDSPCAR_NO_DAIHYOU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXDSPCAR_NO_DAIHYOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXDSPCAR_NO_DAIHYOU.FormattingEnabled = True
        Me.cboXDSPCAR_NO_DAIHYOU.IntegralHeight = False
        Me.cboXDSPCAR_NO_DAIHYOU.Location = New System.Drawing.Point(384, 216)
        Me.cboXDSPCAR_NO_DAIHYOU.Name = "cboXDSPCAR_NO_DAIHYOU"
        Me.cboXDSPCAR_NO_DAIHYOU.Size = New System.Drawing.Size(192, 28)
        Me.cboXDSPCAR_NO_DAIHYOU.TabIndex = 10
        '
        'lblXDSPCAR_NO_DAIHYOU
        '
        Me.lblXDSPCAR_NO_DAIHYOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXDSPCAR_NO_DAIHYOU.ForeColor = System.Drawing.Color.Black
        Me.lblXDSPCAR_NO_DAIHYOU.Location = New System.Drawing.Point(224, 213)
        Me.lblXDSPCAR_NO_DAIHYOU.Name = "lblXDSPCAR_NO_DAIHYOU"
        Me.lblXDSPCAR_NO_DAIHYOU.Size = New System.Drawing.Size(160, 32)
        Me.lblXDSPCAR_NO_DAIHYOU.TabIndex = 9
        Me.lblXDSPCAR_NO_DAIHYOU.Text = "代表車番選択:"
        Me.lblXDSPCAR_NO_DAIHYOU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_308041
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(832, 352)
        Me.Controls.Add(Me.cboXDSPCAR_NO_DAIHYOU)
        Me.Controls.Add(Me.lblXDSPCAR_NO_DAIHYOU)
        Me.Controls.Add(Me.cmdKEIZOKU)
        Me.Controls.Add(Me.txtXCAR_NO_EDA_WARITUKE)
        Me.Controls.Add(Me.grdList3)
        Me.Controls.Add(Me.grdList2)
        Me.Controls.Add(Me.lblXCAR_NO_WARITUKE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboXBERTH_SITEI)
        Me.Controls.Add(Me.lblXBERTH_SITEI)
        Me.Controls.Add(Me.lblXHORYU_REASON)
        Me.Controls.Add(Me.cboXGAIBU_SOUKO_FLAG)
        Me.Controls.Add(Me.lblGAIBU_SOUKO_FLAG)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdKANRYOU)
        Me.Name = "FRM_308041"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ﾄﾗｯｸ入門受付確認"
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdKANRYOU As System.Windows.Forms.Button
    Friend WithEvents cboXGAIBU_SOUKO_FLAG As MateCommon.cmpMComboBox
    Friend WithEvents lblGAIBU_SOUKO_FLAG As System.Windows.Forms.Label
    Friend WithEvents lblXHORYU_REASON As System.Windows.Forms.Label
    Friend WithEvents cboXBERTH_SITEI As MateCommon.cmpMComboBox
    Friend WithEvents lblXBERTH_SITEI As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblXCAR_NO_WARITUKE As System.Windows.Forms.Label
    Friend WithEvents grdList2 As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList3 As GamenCommon.cmpMDataGrid
    Friend WithEvents txtXCAR_NO_EDA_WARITUKE As MateCommon.cmpMTextBoxString
    Friend WithEvents cmdKEIZOKU As System.Windows.Forms.Button
    Friend WithEvents cboXDSPCAR_NO_DAIHYOU As MateCommon.cmpMComboBox
    Friend WithEvents lblXDSPCAR_NO_DAIHYOU As System.Windows.Forms.Label

End Class
