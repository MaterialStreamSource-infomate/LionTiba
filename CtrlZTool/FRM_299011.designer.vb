<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_299011
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_299011))
        Me.txtSQL = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.tsmAddFormat = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmUpdate = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmInsert = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSQLFilterWhere = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmZikkou = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmGetDisp = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmExecute = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdGetDisp = New System.Windows.Forms.Button
        Me.cmdExecute = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSQL
        '
        Me.txtSQL.AcceptsReturn = True
        Me.txtSQL.AcceptsTab = True
        Me.txtSQL.AllowDrop = True
        Me.txtSQL.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSQL.Location = New System.Drawing.Point(0, 48)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSQL.Size = New System.Drawing.Size(608, 344)
        Me.txtSQL.TabIndex = 0
        Me.txtSQL.WordWrap = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAddFormat, Me.tsmZikkou})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(610, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmAddFormat
        '
        Me.tsmAddFormat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSelect, Me.tsmUpdate, Me.tsmInsert, Me.tsmDelete, Me.tsmSQLFilterWhere})
        Me.tsmAddFormat.Name = "tsmAddFormat"
        Me.tsmAddFormat.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.tsmAddFormat.Size = New System.Drawing.Size(81, 20)
        Me.tsmAddFormat.Text = "ﾌｫｰﾏｯﾄ追加"
        '
        'tsmSelect
        '
        Me.tsmSelect.Name = "tsmSelect"
        Me.tsmSelect.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.tsmSelect.Size = New System.Drawing.Size(174, 22)
        Me.tsmSelect.Text = "Select文"
        '
        'tsmUpdate
        '
        Me.tsmUpdate.Name = "tsmUpdate"
        Me.tsmUpdate.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.tsmUpdate.Size = New System.Drawing.Size(174, 22)
        Me.tsmUpdate.Text = "Update文"
        '
        'tsmInsert
        '
        Me.tsmInsert.Name = "tsmInsert"
        Me.tsmInsert.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.tsmInsert.Size = New System.Drawing.Size(174, 22)
        Me.tsmInsert.Text = "Insert文"
        '
        'tsmDelete
        '
        Me.tsmDelete.Name = "tsmDelete"
        Me.tsmDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.tsmDelete.Size = New System.Drawing.Size(174, 22)
        Me.tsmDelete.Text = "Delete文"
        '
        'tsmSQLFilterWhere
        '
        Me.tsmSQLFilterWhere.Name = "tsmSQLFilterWhere"
        Me.tsmSQLFilterWhere.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.tsmSQLFilterWhere.Size = New System.Drawing.Size(174, 22)
        Me.tsmSQLFilterWhere.Text = "ﾌｨﾙﾀWhere句"
        '
        'tsmZikkou
        '
        Me.tsmZikkou.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmGetDisp, Me.tsmExecute})
        Me.tsmZikkou.Name = "tsmZikkou"
        Me.tsmZikkou.Size = New System.Drawing.Size(41, 20)
        Me.tsmZikkou.Text = "実行"
        '
        'tsmGetDisp
        '
        Me.tsmGetDisp.Name = "tsmGetDisp"
        Me.tsmGetDisp.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.tsmGetDisp.Size = New System.Drawing.Size(112, 22)
        Me.tsmGetDisp.Text = "取得"
        '
        'tsmExecute
        '
        Me.tsmExecute.Name = "tsmExecute"
        Me.tsmExecute.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.tsmExecute.Size = New System.Drawing.Size(112, 22)
        Me.tsmExecute.Text = "更新"
        '
        'cmdGetDisp
        '
        Me.cmdGetDisp.BackColor = System.Drawing.Color.DarkGray
        Me.cmdGetDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdGetDisp.ForeColor = System.Drawing.Color.Black
        Me.cmdGetDisp.Location = New System.Drawing.Point(496, 24)
        Me.cmdGetDisp.Name = "cmdGetDisp"
        Me.cmdGetDisp.Size = New System.Drawing.Size(56, 24)
        Me.cmdGetDisp.TabIndex = 56
        Me.cmdGetDisp.Text = "取得"
        Me.cmdGetDisp.UseVisualStyleBackColor = False
        '
        'cmdExecute
        '
        Me.cmdExecute.BackColor = System.Drawing.Color.DarkGray
        Me.cmdExecute.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdExecute.ForeColor = System.Drawing.Color.Black
        Me.cmdExecute.Location = New System.Drawing.Point(552, 24)
        Me.cmdExecute.Name = "cmdExecute"
        Me.cmdExecute.Size = New System.Drawing.Size(56, 24)
        Me.cmdExecute.TabIndex = 57
        Me.cmdExecute.Text = "更新"
        Me.cmdExecute.UseVisualStyleBackColor = False
        '
        'FRM_299011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 395)
        Me.Controls.Add(Me.cmdExecute)
        Me.Controls.Add(Me.cmdGetDisp)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRM_299011"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SQL文実行ｳｨﾝﾄﾞｳ"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmAddFormat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdGetDisp As System.Windows.Forms.Button
    Friend WithEvents cmdExecute As System.Windows.Forms.Button
    Friend WithEvents tsmZikkou As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmGetDisp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmExecute As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSQLFilterWhere As System.Windows.Forms.ToolStripMenuItem
End Class
