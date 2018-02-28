<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_299010
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdDisp = New System.Windows.Forms.Button
        Me.cboTableName = New System.Windows.Forms.ComboBox
        Me.grdTableData = New System.Windows.Forms.DataGridView
        Me.grdColumnData = New System.Windows.Forms.DataGridView
        Me.chkgrdColumnDataVisible = New System.Windows.Forms.CheckBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.tsmWindow = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSQL = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDataUpdate = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmInsert = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmUpdate = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmTrans = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmBeginTrans = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmRollBack = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmCommit = New System.Windows.Forms.ToolStripMenuItem
        Me.lblTrans = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.txtTitle = New System.Windows.Forms.TextBox
        CType(Me.grdTableData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdColumnData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 32)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "ﾃｰﾌﾞﾙ選択:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdDisp
        '
        Me.cmdDisp.BackColor = System.Drawing.Color.DarkGray
        Me.cmdDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdDisp.ForeColor = System.Drawing.Color.Black
        Me.cmdDisp.Location = New System.Drawing.Point(600, 32)
        Me.cmdDisp.Name = "cmdDisp"
        Me.cmdDisp.Size = New System.Drawing.Size(56, 24)
        Me.cmdDisp.TabIndex = 1
        Me.cmdDisp.Text = "表示"
        Me.cmdDisp.UseVisualStyleBackColor = False
        '
        'cboTableName
        '
        Me.cboTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTableName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.cboTableName.FormattingEnabled = True
        Me.cboTableName.Location = New System.Drawing.Point(128, 32)
        Me.cboTableName.MaxDropDownItems = 30
        Me.cboTableName.Name = "cboTableName"
        Me.cboTableName.Size = New System.Drawing.Size(472, 27)
        Me.cboTableName.TabIndex = 0
        '
        'grdTableData
        '
        Me.grdTableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTableData.Location = New System.Drawing.Point(8, 96)
        Me.grdTableData.Name = "grdTableData"
        Me.grdTableData.RowTemplate.Height = 21
        Me.grdTableData.Size = New System.Drawing.Size(576, 472)
        Me.grdTableData.TabIndex = 4
        '
        'grdColumnData
        '
        Me.grdColumnData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdColumnData.Location = New System.Drawing.Point(584, 96)
        Me.grdColumnData.Name = "grdColumnData"
        Me.grdColumnData.RowTemplate.Height = 21
        Me.grdColumnData.Size = New System.Drawing.Size(352, 472)
        Me.grdColumnData.TabIndex = 5
        '
        'chkgrdColumnDataVisible
        '
        Me.chkgrdColumnDataVisible.AutoSize = True
        Me.chkgrdColumnDataVisible.Location = New System.Drawing.Point(664, 48)
        Me.chkgrdColumnDataVisible.Name = "chkgrdColumnDataVisible"
        Me.chkgrdColumnDataVisible.Size = New System.Drawing.Size(84, 16)
        Me.chkgrdColumnDataVisible.TabIndex = 61
        Me.chkgrdColumnDataVisible.Text = "列ﾃﾞｰﾀ表示"
        Me.chkgrdColumnDataVisible.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmWindow, Me.tsmDataUpdate})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(942, 24)
        Me.MenuStrip1.TabIndex = 63
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmWindow
        '
        Me.tsmWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSQL})
        Me.tsmWindow.Name = "tsmWindow"
        Me.tsmWindow.Size = New System.Drawing.Size(54, 20)
        Me.tsmWindow.Text = "ｳｨﾝﾄﾞｳ"
        '
        'tsmSQL
        '
        Me.tsmSQL.Name = "tsmSQL"
        Me.tsmSQL.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.tsmSQL.Size = New System.Drawing.Size(185, 22)
        Me.tsmSQL.Text = "SQL文実行画面"
        '
        'tsmDataUpdate
        '
        Me.tsmDataUpdate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSelect, Me.tsmInsert, Me.tsmUpdate, Me.tsmDelete, Me.tsmTrans})
        Me.tsmDataUpdate.Name = "tsmDataUpdate"
        Me.tsmDataUpdate.Size = New System.Drawing.Size(65, 20)
        Me.tsmDataUpdate.Text = "ﾃﾞｰﾀ更新"
        '
        'tsmSelect
        '
        Me.tsmSelect.Name = "tsmSelect"
        Me.tsmSelect.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.tsmSelect.Size = New System.Drawing.Size(140, 22)
        Me.tsmSelect.Text = "Select"
        '
        'tsmInsert
        '
        Me.tsmInsert.Name = "tsmInsert"
        Me.tsmInsert.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.tsmInsert.Size = New System.Drawing.Size(140, 22)
        Me.tsmInsert.Text = "Insert"
        '
        'tsmUpdate
        '
        Me.tsmUpdate.Name = "tsmUpdate"
        Me.tsmUpdate.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.tsmUpdate.Size = New System.Drawing.Size(140, 22)
        Me.tsmUpdate.Text = "Update"
        '
        'tsmDelete
        '
        Me.tsmDelete.Name = "tsmDelete"
        Me.tsmDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.tsmDelete.Size = New System.Drawing.Size(140, 22)
        Me.tsmDelete.Text = "Delete"
        '
        'tsmTrans
        '
        Me.tsmTrans.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmBeginTrans, Me.tsmRollBack, Me.tsmCommit})
        Me.tsmTrans.Name = "tsmTrans"
        Me.tsmTrans.Size = New System.Drawing.Size(140, 22)
        Me.tsmTrans.Text = "ﾄﾗﾝｻﾞｸｼｮﾝ"
        '
        'tsmBeginTrans
        '
        Me.tsmBeginTrans.Name = "tsmBeginTrans"
        Me.tsmBeginTrans.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.tsmBeginTrans.Size = New System.Drawing.Size(183, 22)
        Me.tsmBeginTrans.Text = "ﾄﾗﾝｻﾞｸｼｮﾝ開始"
        '
        'tsmRollBack
        '
        Me.tsmRollBack.Name = "tsmRollBack"
        Me.tsmRollBack.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.tsmRollBack.Size = New System.Drawing.Size(183, 22)
        Me.tsmRollBack.Text = "ﾛｰﾙﾊﾞｯｸ"
        '
        'tsmCommit
        '
        Me.tsmCommit.Name = "tsmCommit"
        Me.tsmCommit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.tsmCommit.Size = New System.Drawing.Size(183, 22)
        Me.tsmCommit.Text = "ｺﾐｯﾄ"
        '
        'lblTrans
        '
        Me.lblTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTrans.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblTrans.ForeColor = System.Drawing.Color.Black
        Me.lblTrans.Location = New System.Drawing.Point(752, 24)
        Me.lblTrans.Name = "lblTrans"
        Me.lblTrans.Size = New System.Drawing.Size(144, 40)
        Me.lblTrans.TabIndex = 64
        Me.lblTrans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.DarkGray
        Me.cmdPrint.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdPrint.ForeColor = System.Drawing.Color.Black
        Me.cmdPrint.Location = New System.Drawing.Point(512, 64)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(56, 24)
        Me.cmdPrint.TabIndex = 3
        Me.cmdPrint.Text = "印字"
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(128, 64)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(376, 23)
        Me.txtTitle.TabIndex = 2
        '
        'FRM_299010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 574)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.lblTrans)
        Me.Controls.Add(Me.chkgrdColumnDataVisible)
        Me.Controls.Add(Me.grdColumnData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdDisp)
        Me.Controls.Add(Me.cboTableName)
        Me.Controls.Add(Me.grdTableData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRM_299010"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DBﾒﾝﾃﾅﾝｽﾂｰﾙ"
        CType(Me.grdTableData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdColumnData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdDisp As System.Windows.Forms.Button
    Friend WithEvents cboTableName As System.Windows.Forms.ComboBox
    Friend WithEvents grdTableData As System.Windows.Forms.DataGridView
    Friend WithEvents grdColumnData As System.Windows.Forms.DataGridView
    Friend WithEvents chkgrdColumnDataVisible As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmDataUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTrans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBeginTrans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRollBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCommit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTrans As System.Windows.Forms.Label
    Friend WithEvents tsmWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSQL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
End Class
