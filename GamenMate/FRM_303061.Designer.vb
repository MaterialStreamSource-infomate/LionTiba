<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303061
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
        Me.lblCOMMENT = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.cboFREASON = New MateCommon.cmpMComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSTMode = New System.Windows.Forms.Button
        Me.cboFTRK_BUF_NO = New MateCommon.cmpMComboBox
        Me.lblSyukoST = New System.Windows.Forms.Label
        Me.cmdList = New System.Windows.Forms.Button
        Me.tmr303061 = New System.Windows.Forms.Timer(Me.components)
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCOMMENT
        '
        Me.lblCOMMENT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblCOMMENT.ForeColor = System.Drawing.Color.Black
        Me.lblCOMMENT.Location = New System.Drawing.Point(64, 8)
        Me.lblCOMMENT.Name = "lblCOMMENT"
        Me.lblCOMMENT.Size = New System.Drawing.Size(528, 46)
        Me.lblCOMMENT.TabIndex = 0
        Me.lblCOMMENT.Text = "出庫STを指定して、倉替え設定して下さい。"
        Me.lblCOMMENT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(496, 232)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(16, 232)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 6
        Me.cmdZikkou.Text = "倉替え設定"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'cboFREASON
        '
        Me.cboFREASON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFREASON.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFREASON.FormattingEnabled = True
        Me.cboFREASON.IntegralHeight = False
        Me.cboFREASON.Location = New System.Drawing.Point(144, 152)
        Me.cboFREASON.Name = "cboFREASON"
        Me.cboFREASON.Size = New System.Drawing.Size(480, 28)
        Me.cboFREASON.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(32, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "理由:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSTMode
        '
        Me.btnSTMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSTMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSTMode.ForeColor = System.Drawing.Color.Black
        Me.btnSTMode.Location = New System.Drawing.Point(467, 88)
        Me.btnSTMode.Name = "btnSTMode"
        Me.btnSTMode.Size = New System.Drawing.Size(152, 31)
        Me.btnSTMode.TabIndex = 3
        Me.btnSTMode.Text = "出庫モード"
        Me.btnSTMode.UseVisualStyleBackColor = False
        '
        'cboFTRK_BUF_NO
        '
        Me.cboFTRK_BUF_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO.IntegralHeight = False
        Me.cboFTRK_BUF_NO.Location = New System.Drawing.Point(144, 88)
        Me.cboFTRK_BUF_NO.Name = "cboFTRK_BUF_NO"
        Me.cboFTRK_BUF_NO.Size = New System.Drawing.Size(301, 28)
        Me.cboFTRK_BUF_NO.TabIndex = 2
        '
        'lblSyukoST
        '
        Me.lblSyukoST.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSyukoST.ForeColor = System.Drawing.Color.Black
        Me.lblSyukoST.Location = New System.Drawing.Point(24, 85)
        Me.lblSyukoST.Name = "lblSyukoST"
        Me.lblSyukoST.Size = New System.Drawing.Size(120, 32)
        Me.lblSyukoST.TabIndex = 1
        Me.lblSyukoST.Text = "出庫ST:"
        Me.lblSyukoST.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdList
        '
        Me.cmdList.BackColor = System.Drawing.Color.DarkGray
        Me.cmdList.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdList.ForeColor = System.Drawing.Color.Black
        Me.cmdList.Location = New System.Drawing.Point(254, 232)
        Me.cmdList.Name = "cmdList"
        Me.cmdList.Size = New System.Drawing.Size(216, 40)
        Me.cmdList.TabIndex = 7
        Me.cmdList.Text = "リスト出力"
        Me.cmdList.UseVisualStyleBackColor = False
        '
        'tmr303061
        '
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(640, 16)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(72, 40)
        Me.grdList.TabIndex = 9
        Me.grdList.Visible = False
        '
        'FRM_303061
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(730, 291)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.cmdList)
        Me.Controls.Add(Me.btnSTMode)
        Me.Controls.Add(Me.cboFTRK_BUF_NO)
        Me.Controls.Add(Me.lblSyukoST)
        Me.Controls.Add(Me.cboFREASON)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCOMMENT)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Name = "FRM_303061"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "倉替え設定確認"
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCOMMENT As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents cboFREASON As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSTMode As System.Windows.Forms.Button
    Friend WithEvents cboFTRK_BUF_NO As MateCommon.cmpMComboBox
    Friend WithEvents lblSyukoST As System.Windows.Forms.Label
    Friend WithEvents cmdList As System.Windows.Forms.Button
    Friend WithEvents tmr303061 As System.Windows.Forms.Timer
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid

End Class
