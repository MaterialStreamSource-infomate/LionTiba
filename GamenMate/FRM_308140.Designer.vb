<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308140
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
        Me.grdList3 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList2 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.lblXCAR_NO_WARITUKE = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboXBERTH_SITEI = New MateCommon.cmpMComboBox
        Me.lblXBERTH_SITEI = New System.Windows.Forms.Label
        Me.lblXHORYU_REASON = New System.Windows.Forms.Label
        Me.cboXGAIBU_SOUKO_FLAG = New MateCommon.cmpMComboBox
        Me.lblGAIBU_SOUKO_FLAG = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(280, 672)
        Me.cmdF8.TabIndex = 1
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1032, 672)
        Me.cmdF7.TabIndex = 0
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(920, 672)
        Me.cmdF6.TabIndex = 40
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(808, 672)
        Me.cmdF5.TabIndex = 39
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(696, 672)
        Me.cmdF4.TabIndex = 38
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(584, 672)
        Me.cmdF3.TabIndex = 37
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(472, 672)
        Me.cmdF2.TabIndex = 36
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(168, 672)
        Me.cmdF1.TabIndex = 35
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(170, 208)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 448)
        Me.grdList.TabIndex = 34
        '
        'grdList3
        '
        Me.grdList3.blnDBUpdate = False
        Me.grdList3.blnSelectionChanged = False
        Me.grdList3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList3.Location = New System.Drawing.Point(1168, 144)
        Me.grdList3.MyBeseDoubleBuffered = False
        Me.grdList3.Name = "grdList3"
        Me.grdList3.RowTemplate.Height = 21
        Me.grdList3.Size = New System.Drawing.Size(72, 40)
        Me.grdList3.TabIndex = 33
        Me.grdList3.Visible = False
        '
        'grdList2
        '
        Me.grdList2.blnDBUpdate = False
        Me.grdList2.blnSelectionChanged = False
        Me.grdList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList2.Location = New System.Drawing.Point(1168, 96)
        Me.grdList2.MyBeseDoubleBuffered = False
        Me.grdList2.Name = "grdList2"
        Me.grdList2.RowTemplate.Height = 21
        Me.grdList2.Size = New System.Drawing.Size(72, 40)
        Me.grdList2.TabIndex = 32
        Me.grdList2.Visible = False
        '
        'lblXCAR_NO_WARITUKE
        '
        Me.lblXCAR_NO_WARITUKE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXCAR_NO_WARITUKE.ForeColor = System.Drawing.Color.Black
        Me.lblXCAR_NO_WARITUKE.Location = New System.Drawing.Point(288, 88)
        Me.lblXCAR_NO_WARITUKE.Name = "lblXCAR_NO_WARITUKE"
        Me.lblXCAR_NO_WARITUKE.Size = New System.Drawing.Size(64, 32)
        Me.lblXCAR_NO_WARITUKE.TabIndex = 26
        Me.lblXCAR_NO_WARITUKE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(176, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 32)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "受付車番:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXBERTH_SITEI
        '
        Me.cboXBERTH_SITEI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXBERTH_SITEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXBERTH_SITEI.FormattingEnabled = True
        Me.cboXBERTH_SITEI.IntegralHeight = False
        Me.cboXBERTH_SITEI.Location = New System.Drawing.Point(424, 155)
        Me.cboXBERTH_SITEI.Name = "cboXBERTH_SITEI"
        Me.cboXBERTH_SITEI.Size = New System.Drawing.Size(192, 28)
        Me.cboXBERTH_SITEI.TabIndex = 29
        '
        'lblXBERTH_SITEI
        '
        Me.lblXBERTH_SITEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXBERTH_SITEI.ForeColor = System.Drawing.Color.Black
        Me.lblXBERTH_SITEI.Location = New System.Drawing.Point(264, 152)
        Me.lblXBERTH_SITEI.Name = "lblXBERTH_SITEI"
        Me.lblXBERTH_SITEI.Size = New System.Drawing.Size(160, 32)
        Me.lblXBERTH_SITEI.TabIndex = 28
        Me.lblXBERTH_SITEI.Text = "ﾊﾞｰｽ指定:"
        Me.lblXBERTH_SITEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXHORYU_REASON
        '
        Me.lblXHORYU_REASON.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXHORYU_REASON.ForeColor = System.Drawing.Color.Black
        Me.lblXHORYU_REASON.Location = New System.Drawing.Point(392, 88)
        Me.lblXHORYU_REASON.Name = "lblXHORYU_REASON"
        Me.lblXHORYU_REASON.Size = New System.Drawing.Size(512, 32)
        Me.lblXHORYU_REASON.TabIndex = 27
        Me.lblXHORYU_REASON.Text = "以下の内容で入門受付しますが、よろしいですか？"
        Me.lblXHORYU_REASON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboXGAIBU_SOUKO_FLAG
        '
        Me.cboXGAIBU_SOUKO_FLAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXGAIBU_SOUKO_FLAG.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXGAIBU_SOUKO_FLAG.FormattingEnabled = True
        Me.cboXGAIBU_SOUKO_FLAG.IntegralHeight = False
        Me.cboXGAIBU_SOUKO_FLAG.Location = New System.Drawing.Point(816, 155)
        Me.cboXGAIBU_SOUKO_FLAG.Name = "cboXGAIBU_SOUKO_FLAG"
        Me.cboXGAIBU_SOUKO_FLAG.Size = New System.Drawing.Size(192, 28)
        Me.cboXGAIBU_SOUKO_FLAG.TabIndex = 31
        '
        'lblGAIBU_SOUKO_FLAG
        '
        Me.lblGAIBU_SOUKO_FLAG.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblGAIBU_SOUKO_FLAG.ForeColor = System.Drawing.Color.Black
        Me.lblGAIBU_SOUKO_FLAG.Location = New System.Drawing.Point(656, 152)
        Me.lblGAIBU_SOUKO_FLAG.Name = "lblGAIBU_SOUKO_FLAG"
        Me.lblGAIBU_SOUKO_FLAG.Size = New System.Drawing.Size(160, 32)
        Me.lblGAIBU_SOUKO_FLAG.TabIndex = 30
        Me.lblGAIBU_SOUKO_FLAG.Text = "外部倉庫先行:"
        Me.lblGAIBU_SOUKO_FLAG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_308140
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList3)
        Me.Controls.Add(Me.grdList2)
        Me.Controls.Add(Me.lblXCAR_NO_WARITUKE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboXBERTH_SITEI)
        Me.Controls.Add(Me.lblXBERTH_SITEI)
        Me.Controls.Add(Me.lblXHORYU_REASON)
        Me.Controls.Add(Me.cboXGAIBU_SOUKO_FLAG)
        Me.Controls.Add(Me.lblGAIBU_SOUKO_FLAG)
        Me.Controls.Add(Me.grdList)
        Me.Name = "FRM_308140"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.lblGAIBU_SOUKO_FLAG, 0)
        Me.Controls.SetChildIndex(Me.cboXGAIBU_SOUKO_FLAG, 0)
        Me.Controls.SetChildIndex(Me.lblXHORYU_REASON, 0)
        Me.Controls.SetChildIndex(Me.lblXBERTH_SITEI, 0)
        Me.Controls.SetChildIndex(Me.cboXBERTH_SITEI, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lblXCAR_NO_WARITUKE, 0)
        Me.Controls.SetChildIndex(Me.grdList2, 0)
        Me.Controls.SetChildIndex(Me.grdList3, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList3 As GamenCommon.cmpMDataGrid
    Friend WithEvents grdList2 As GamenCommon.cmpMDataGrid
    Friend WithEvents lblXCAR_NO_WARITUKE As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboXBERTH_SITEI As MateCommon.cmpMComboBox
    Friend WithEvents lblXBERTH_SITEI As System.Windows.Forms.Label
    Friend WithEvents lblXHORYU_REASON As System.Windows.Forms.Label
    Friend WithEvents cboXGAIBU_SOUKO_FLAG As MateCommon.cmpMComboBox
    Friend WithEvents lblGAIBU_SOUKO_FLAG As System.Windows.Forms.Label

End Class
