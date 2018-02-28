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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_299010))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdDisp = New System.Windows.Forms.Button
        Me.cboTableName = New System.Windows.Forms.ComboBox
        Me.grdTableData = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.指定の値に等しいToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Sitei_TextBox = New System.Windows.Forms.ToolStripTextBox
        Me.Menu_Sitei_Equal = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Sitei_NotEqual = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Sitei_Contain = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Sitei_NotContain = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Sitei_Over = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Sitei_Under = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Equal = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_NotEqual = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Contain = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_NotContain = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Over = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Under = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Asc = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Desc = New System.Windows.Forms.ToolStripMenuItem
        Me.grdColumnData = New System.Windows.Forms.DataGridView
        Me.chkgrdColumnDataVisible = New System.Windows.Forms.CheckBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.tsmWindow = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSQL = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmNewMake = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDataUpdate = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmRefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmTrans = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmBeginTrans = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmRollBack = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmCommit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDB = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmConnect = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDisConnect = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEtc = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmTableNameSelectAutoCansel = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmTableNameDropDownStyle = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmTableNameDropDownStyle01 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmTableNameDropDownStyle02 = New System.Windows.Forms.ToolStripMenuItem
        Me.lblTrans = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.cmdSQLFile = New System.Windows.Forms.Button
        Me.cmdLogDisp = New System.Windows.Forms.Button
        Me.cmdColInitialize = New System.Windows.Forms.Button
        CType(Me.grdTableData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.grdColumnData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 24)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "ﾃｰﾌﾞﾙ選択:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdDisp
        '
        Me.cmdDisp.BackColor = System.Drawing.Color.DarkGray
        Me.cmdDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDisp.ForeColor = System.Drawing.Color.Black
        Me.cmdDisp.Location = New System.Drawing.Point(560, 24)
        Me.cmdDisp.Name = "cmdDisp"
        Me.cmdDisp.Size = New System.Drawing.Size(56, 24)
        Me.cmdDisp.TabIndex = 0
        Me.cmdDisp.Text = "表示"
        Me.cmdDisp.UseVisualStyleBackColor = False
        '
        'cboTableName
        '
        Me.cboTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTableName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboTableName.FormattingEnabled = True
        Me.cboTableName.Location = New System.Drawing.Point(88, 24)
        Me.cboTableName.MaxDropDownItems = 30
        Me.cboTableName.Name = "cboTableName"
        Me.cboTableName.Size = New System.Drawing.Size(472, 23)
        Me.cboTableName.TabIndex = 7
        '
        'grdTableData
        '
        Me.grdTableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTableData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.grdTableData.Location = New System.Drawing.Point(8, 96)
        Me.grdTableData.Name = "grdTableData"
        Me.grdTableData.RowTemplate.Height = 21
        Me.grdTableData.Size = New System.Drawing.Size(480, 472)
        Me.grdTableData.TabIndex = 4
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.指定の値に等しいToolStripMenuItem, Me.Menu_Equal, Me.Menu_NotEqual, Me.Menu_Contain, Me.Menu_NotContain, Me.Menu_Over, Me.Menu_Under, Me.Menu_Asc, Me.Menu_Desc})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(140, 202)
        '
        '指定の値に等しいToolStripMenuItem
        '
        Me.指定の値に等しいToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Sitei_TextBox, Me.Menu_Sitei_Equal, Me.Menu_Sitei_NotEqual, Me.Menu_Sitei_Contain, Me.Menu_Sitei_NotContain, Me.Menu_Sitei_Over, Me.Menu_Sitei_Under})
        Me.指定の値に等しいToolStripMenuItem.Name = "指定の値に等しいToolStripMenuItem"
        Me.指定の値に等しいToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.指定の値に等しいToolStripMenuItem.Text = "テキストフィルタ"
        '
        'Menu_Sitei_TextBox
        '
        Me.Menu_Sitei_TextBox.Name = "Menu_Sitei_TextBox"
        Me.Menu_Sitei_TextBox.Size = New System.Drawing.Size(152, 19)
        '
        'Menu_Sitei_Equal
        '
        Me.Menu_Sitei_Equal.Name = "Menu_Sitei_Equal"
        Me.Menu_Sitei_Equal.Size = New System.Drawing.Size(212, 22)
        Me.Menu_Sitei_Equal.Text = "指定の値に等しい"
        '
        'Menu_Sitei_NotEqual
        '
        Me.Menu_Sitei_NotEqual.Name = "Menu_Sitei_NotEqual"
        Me.Menu_Sitei_NotEqual.Size = New System.Drawing.Size(212, 22)
        Me.Menu_Sitei_NotEqual.Text = "指定の値に等しくない"
        '
        'Menu_Sitei_Contain
        '
        Me.Menu_Sitei_Contain.Name = "Menu_Sitei_Contain"
        Me.Menu_Sitei_Contain.Size = New System.Drawing.Size(212, 22)
        Me.Menu_Sitei_Contain.Text = "指定の値を含む"
        '
        'Menu_Sitei_NotContain
        '
        Me.Menu_Sitei_NotContain.Name = "Menu_Sitei_NotContain"
        Me.Menu_Sitei_NotContain.Size = New System.Drawing.Size(212, 22)
        Me.Menu_Sitei_NotContain.Text = "指定の値を含まない"
        '
        'Menu_Sitei_Over
        '
        Me.Menu_Sitei_Over.Name = "Menu_Sitei_Over"
        Me.Menu_Sitei_Over.Size = New System.Drawing.Size(212, 22)
        Me.Menu_Sitei_Over.Text = "以上"
        '
        'Menu_Sitei_Under
        '
        Me.Menu_Sitei_Under.Name = "Menu_Sitei_Under"
        Me.Menu_Sitei_Under.Size = New System.Drawing.Size(212, 22)
        Me.Menu_Sitei_Under.Text = "以下"
        '
        'Menu_Equal
        '
        Me.Menu_Equal.Name = "Menu_Equal"
        Me.Menu_Equal.Size = New System.Drawing.Size(139, 22)
        Me.Menu_Equal.Text = "に等しい"
        '
        'Menu_NotEqual
        '
        Me.Menu_NotEqual.Name = "Menu_NotEqual"
        Me.Menu_NotEqual.Size = New System.Drawing.Size(139, 22)
        Me.Menu_NotEqual.Text = "に等しくない"
        '
        'Menu_Contain
        '
        Me.Menu_Contain.Name = "Menu_Contain"
        Me.Menu_Contain.Size = New System.Drawing.Size(139, 22)
        Me.Menu_Contain.Text = "を含む"
        '
        'Menu_NotContain
        '
        Me.Menu_NotContain.Name = "Menu_NotContain"
        Me.Menu_NotContain.Size = New System.Drawing.Size(139, 22)
        Me.Menu_NotContain.Text = "を含まない"
        '
        'Menu_Over
        '
        Me.Menu_Over.Name = "Menu_Over"
        Me.Menu_Over.Size = New System.Drawing.Size(139, 22)
        Me.Menu_Over.Text = "以上"
        '
        'Menu_Under
        '
        Me.Menu_Under.Name = "Menu_Under"
        Me.Menu_Under.Size = New System.Drawing.Size(139, 22)
        Me.Menu_Under.Text = "以下"
        '
        'Menu_Asc
        '
        Me.Menu_Asc.Name = "Menu_Asc"
        Me.Menu_Asc.Size = New System.Drawing.Size(139, 22)
        Me.Menu_Asc.Text = "昇順"
        '
        'Menu_Desc
        '
        Me.Menu_Desc.Name = "Menu_Desc"
        Me.Menu_Desc.Size = New System.Drawing.Size(139, 22)
        Me.Menu_Desc.Text = "降順"
        '
        'grdColumnData
        '
        Me.grdColumnData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdColumnData.Location = New System.Drawing.Point(488, 96)
        Me.grdColumnData.Name = "grdColumnData"
        Me.grdColumnData.RowTemplate.Height = 21
        Me.grdColumnData.Size = New System.Drawing.Size(448, 472)
        Me.grdColumnData.TabIndex = 5
        '
        'chkgrdColumnDataVisible
        '
        Me.chkgrdColumnDataVisible.AutoSize = True
        Me.chkgrdColumnDataVisible.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkgrdColumnDataVisible.Location = New System.Drawing.Point(792, 64)
        Me.chkgrdColumnDataVisible.Name = "chkgrdColumnDataVisible"
        Me.chkgrdColumnDataVisible.Size = New System.Drawing.Size(106, 19)
        Me.chkgrdColumnDataVisible.TabIndex = 61
        Me.chkgrdColumnDataVisible.Text = "列ﾃﾞｰﾀ表示"
        Me.chkgrdColumnDataVisible.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmWindow, Me.tsmDataUpdate, Me.tsmDB, Me.tsmEtc})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(942, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmWindow
        '
        Me.tsmWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSQL, Me.tsmNewMake})
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
        'tsmNewMake
        '
        Me.tsmNewMake.Name = "tsmNewMake"
        Me.tsmNewMake.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.tsmNewMake.Size = New System.Drawing.Size(185, 22)
        Me.tsmNewMake.Text = "新規作成"
        '
        'tsmDataUpdate
        '
        Me.tsmDataUpdate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmRefresh, Me.tsmSelect, Me.tsmTrans})
        Me.tsmDataUpdate.Name = "tsmDataUpdate"
        Me.tsmDataUpdate.Size = New System.Drawing.Size(65, 20)
        Me.tsmDataUpdate.Text = "ﾃﾞｰﾀ更新"
        '
        'tsmRefresh
        '
        Me.tsmRefresh.Name = "tsmRefresh"
        Me.tsmRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.tsmRefresh.Size = New System.Drawing.Size(136, 22)
        Me.tsmRefresh.Text = "表示更新"
        '
        'tsmSelect
        '
        Me.tsmSelect.Name = "tsmSelect"
        Me.tsmSelect.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.tsmSelect.Size = New System.Drawing.Size(136, 22)
        Me.tsmSelect.Text = "Select"
        '
        'tsmTrans
        '
        Me.tsmTrans.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmBeginTrans, Me.tsmRollBack, Me.tsmCommit})
        Me.tsmTrans.Name = "tsmTrans"
        Me.tsmTrans.Size = New System.Drawing.Size(136, 22)
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
        'tsmDB
        '
        Me.tsmDB.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmConnect, Me.tsmDisConnect})
        Me.tsmDB.Name = "tsmDB"
        Me.tsmDB.Size = New System.Drawing.Size(57, 20)
        Me.tsmDB.Text = "DB接続"
        '
        'tsmConnect
        '
        Me.tsmConnect.Name = "tsmConnect"
        Me.tsmConnect.Size = New System.Drawing.Size(94, 22)
        Me.tsmConnect.Text = "接続"
        '
        'tsmDisConnect
        '
        Me.tsmDisConnect.Name = "tsmDisConnect"
        Me.tsmDisConnect.Size = New System.Drawing.Size(94, 22)
        Me.tsmDisConnect.Text = "切断"
        '
        'tsmEtc
        '
        Me.tsmEtc.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmTableNameSelectAutoCansel, Me.tsmTableNameDropDownStyle})
        Me.tsmEtc.Name = "tsmEtc"
        Me.tsmEtc.Size = New System.Drawing.Size(48, 20)
        Me.tsmEtc.Text = "その他"
        '
        'tsmTableNameSelectAutoCansel
        '
        Me.tsmTableNameSelectAutoCansel.Checked = True
        Me.tsmTableNameSelectAutoCansel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmTableNameSelectAutoCansel.Name = "tsmTableNameSelectAutoCansel"
        Me.tsmTableNameSelectAutoCansel.Size = New System.Drawing.Size(266, 22)
        Me.tsmTableNameSelectAutoCansel.Text = "ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ　自動解除"
        '
        'tsmTableNameDropDownStyle
        '
        Me.tsmTableNameDropDownStyle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmTableNameDropDownStyle01, Me.tsmTableNameDropDownStyle02})
        Me.tsmTableNameDropDownStyle.Name = "tsmTableNameDropDownStyle"
        Me.tsmTableNameDropDownStyle.Size = New System.Drawing.Size(266, 22)
        Me.tsmTableNameDropDownStyle.Text = "ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ　ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ"
        '
        'tsmTableNameDropDownStyle01
        '
        Me.tsmTableNameDropDownStyle01.Checked = True
        Me.tsmTableNameDropDownStyle01.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmTableNameDropDownStyle01.Name = "tsmTableNameDropDownStyle01"
        Me.tsmTableNameDropDownStyle01.Size = New System.Drawing.Size(146, 22)
        Me.tsmTableNameDropDownStyle01.Text = "ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ"
        '
        'tsmTableNameDropDownStyle02
        '
        Me.tsmTableNameDropDownStyle02.Name = "tsmTableNameDropDownStyle02"
        Me.tsmTableNameDropDownStyle02.Size = New System.Drawing.Size(146, 22)
        Me.tsmTableNameDropDownStyle02.Text = "ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ"
        '
        'lblTrans
        '
        Me.lblTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTrans.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTrans.ForeColor = System.Drawing.Color.Black
        Me.lblTrans.Location = New System.Drawing.Point(792, 24)
        Me.lblTrans.Name = "lblTrans"
        Me.lblTrans.Size = New System.Drawing.Size(144, 40)
        Me.lblTrans.TabIndex = 64
        Me.lblTrans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.DarkGray
        Me.cmdPrint.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPrint.ForeColor = System.Drawing.Color.Black
        Me.cmdPrint.Location = New System.Drawing.Point(296, 48)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(56, 24)
        Me.cmdPrint.TabIndex = 3
        Me.cmdPrint.Text = "印字"
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(88, 48)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(208, 22)
        Me.txtTitle.TabIndex = 8
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.Color.DarkGray
        Me.cmdRefresh.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.Color.Black
        Me.cmdRefresh.Location = New System.Drawing.Point(616, 24)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(56, 24)
        Me.cmdRefresh.TabIndex = 1
        Me.cmdRefresh.Text = "更新"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'cmdSQLFile
        '
        Me.cmdSQLFile.BackColor = System.Drawing.Color.DarkGray
        Me.cmdSQLFile.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSQLFile.ForeColor = System.Drawing.Color.Black
        Me.cmdSQLFile.Location = New System.Drawing.Point(560, 48)
        Me.cmdSQLFile.Name = "cmdSQLFile"
        Me.cmdSQLFile.Size = New System.Drawing.Size(56, 24)
        Me.cmdSQLFile.TabIndex = 3
        Me.cmdSQLFile.Text = "SQL"
        Me.cmdSQLFile.UseVisualStyleBackColor = False
        '
        'cmdLogDisp
        '
        Me.cmdLogDisp.BackColor = System.Drawing.Color.DarkGray
        Me.cmdLogDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdLogDisp.ForeColor = System.Drawing.Color.Black
        Me.cmdLogDisp.Location = New System.Drawing.Point(672, 24)
        Me.cmdLogDisp.Name = "cmdLogDisp"
        Me.cmdLogDisp.Size = New System.Drawing.Size(56, 24)
        Me.cmdLogDisp.TabIndex = 2
        Me.cmdLogDisp.Text = "ﾛｸﾞ表示"
        Me.cmdLogDisp.UseVisualStyleBackColor = False
        '
        'cmdColInitialize
        '
        Me.cmdColInitialize.BackColor = System.Drawing.Color.DarkGray
        Me.cmdColInitialize.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdColInitialize.ForeColor = System.Drawing.Color.Black
        Me.cmdColInitialize.Location = New System.Drawing.Point(728, 24)
        Me.cmdColInitialize.Name = "cmdColInitialize"
        Me.cmdColInitialize.Size = New System.Drawing.Size(56, 24)
        Me.cmdColInitialize.TabIndex = 65
        Me.cmdColInitialize.Text = "列縮"
        Me.cmdColInitialize.UseVisualStyleBackColor = False
        '
        'FRM_299010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 574)
        Me.Controls.Add(Me.cmdColInitialize)
        Me.Controls.Add(Me.cmdLogDisp)
        Me.Controls.Add(Me.cmdSQLFile)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.lblTrans)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.chkgrdColumnDataVisible)
        Me.Controls.Add(Me.grdColumnData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdDisp)
        Me.Controls.Add(Me.cboTableName)
        Me.Controls.Add(Me.grdTableData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRM_299010"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DBﾒﾝﾃﾅﾝｽﾂｰﾙ"
        CType(Me.grdTableData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
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
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Menu_Equal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_NotEqual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Contain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_NotContain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 指定の値に等しいToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Sitei_Equal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Sitei_NotEqual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Sitei_Contain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Sitei_NotContain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Sitei_TextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Menu_Sitei_Over As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Sitei_Under As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Over As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Under As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDisConnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmConnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents tsmNewMake As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Asc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Desc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSQLFile As System.Windows.Forms.Button
    Friend WithEvents cmdLogDisp As System.Windows.Forms.Button
    Friend WithEvents tsmEtc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTableNameSelectAutoCansel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTableNameDropDownStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTableNameDropDownStyle01 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTableNameDropDownStyle02 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdColInitialize As System.Windows.Forms.Button
End Class
