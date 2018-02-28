<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnalysis
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
        Me.txtLineEyeTextFile = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdAnalysis = New System.Windows.Forms.Button
        Me.lblProgress = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtReadSend01_99 = New System.Windows.Forms.TextBox
        Me.txtReadSend01_03 = New System.Windows.Forms.TextBox
        Me.txtReadSend01_04 = New System.Windows.Forms.TextBox
        Me.txtReadSend01_01 = New System.Windows.Forms.TextBox
        Me.txtReadSend01_02 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.cmdDBInsert = New System.Windows.Forms.Button
        Me.chkCheckSame = New System.Windows.Forms.CheckBox
        Me.txtInsertDate = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.rdoMakeFileNon = New System.Windows.Forms.RadioButton
        Me.rdoMakeFileRecv = New System.Windows.Forms.RadioButton
        Me.rdoMakeFileSend = New System.Windows.Forms.RadioButton
        Me.chkAscii = New System.Windows.Forms.CheckBox
        Me.chkSJIS = New System.Windows.Forms.CheckBox
        Me.chkBinary = New System.Windows.Forms.CheckBox
        Me.txtTelegramAnalysis01 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtWriteSend01_82 = New System.Windows.Forms.TextBox
        Me.txtWriteSend01_81 = New System.Windows.Forms.TextBox
        Me.rdoWriteRecv = New System.Windows.Forms.RadioButton
        Me.rdoWriteSend = New System.Windows.Forms.RadioButton
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtWriteSend01_06 = New System.Windows.Forms.TextBox
        Me.txtWriteSend01_05 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtWriteSend01_01 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtWriteSend01_02 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtWriteSend01_04 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtWriteSend01_03 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtWriteSend01_99 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtReadRecv01_04 = New System.Windows.Forms.TextBox
        Me.txtReadRecv01_01 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtReadRecv01_02 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtReadRecv01_03 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtReadRecv01_99 = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtTelegramAnalysis02 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdMelsecAnalysis = New System.Windows.Forms.Button
        Me.cmdInsertXMST_EQ_NAME = New System.Windows.Forms.Button
        Me.txtTextFile02 = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLineEyeTextFile
        '
        Me.txtLineEyeTextFile.AcceptsReturn = True
        Me.txtLineEyeTextFile.Font = New System.Drawing.Font("ＭＳ ゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLineEyeTextFile.Location = New System.Drawing.Point(58, 18)
        Me.txtLineEyeTextFile.Multiline = True
        Me.txtLineEyeTextFile.Name = "txtLineEyeTextFile"
        Me.txtLineEyeTextFile.Size = New System.Drawing.Size(515, 41)
        Me.txtLineEyeTextFile.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 19)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "ﾌｧｲﾙﾊﾟｽ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAnalysis
        '
        Me.cmdAnalysis.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdAnalysis.Location = New System.Drawing.Point(491, 68)
        Me.cmdAnalysis.Name = "cmdAnalysis"
        Me.cmdAnalysis.Size = New System.Drawing.Size(82, 34)
        Me.cmdAnalysis.TabIndex = 34
        Me.cmdAnalysis.Text = "時系列に" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ﾌｧｲﾙ出力"
        Me.cmdAnalysis.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblProgress.Location = New System.Drawing.Point(429, 68)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(58, 19)
        Me.lblProgress.TabIndex = 35
        Me.lblProgress.Text = "0.00%"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(378, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 19)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "進捗状況"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "CRC"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 19)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "開始番号"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "個数"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 19)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "ｱﾄﾞﾚｽ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 19)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "ﾌｧﾝｸｼｮﾝ"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReadSend01_99
        '
        Me.txtReadSend01_99.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadSend01_99.Location = New System.Drawing.Point(70, 91)
        Me.txtReadSend01_99.Name = "txtReadSend01_99"
        Me.txtReadSend01_99.Size = New System.Drawing.Size(64, 19)
        Me.txtReadSend01_99.TabIndex = 38
        '
        'txtReadSend01_03
        '
        Me.txtReadSend01_03.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadSend01_03.Location = New System.Drawing.Point(70, 53)
        Me.txtReadSend01_03.Name = "txtReadSend01_03"
        Me.txtReadSend01_03.Size = New System.Drawing.Size(64, 19)
        Me.txtReadSend01_03.TabIndex = 37
        '
        'txtReadSend01_04
        '
        Me.txtReadSend01_04.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadSend01_04.Location = New System.Drawing.Point(70, 72)
        Me.txtReadSend01_04.Name = "txtReadSend01_04"
        Me.txtReadSend01_04.Size = New System.Drawing.Size(64, 19)
        Me.txtReadSend01_04.TabIndex = 41
        '
        'txtReadSend01_01
        '
        Me.txtReadSend01_01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadSend01_01.Location = New System.Drawing.Point(70, 15)
        Me.txtReadSend01_01.Name = "txtReadSend01_01"
        Me.txtReadSend01_01.Size = New System.Drawing.Size(64, 19)
        Me.txtReadSend01_01.TabIndex = 40
        '
        'txtReadSend01_02
        '
        Me.txtReadSend01_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadSend01_02.Location = New System.Drawing.Point(70, 34)
        Me.txtReadSend01_02.Name = "txtReadSend01_02"
        Me.txtReadSend01_02.Size = New System.Drawing.Size(64, 19)
        Me.txtReadSend01_02.TabIndex = 39
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtReadSend01_01)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtReadSend01_02)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtReadSend01_04)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtReadSend01_03)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtReadSend01_99)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(276, 117)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "読出要求"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox6)
        Me.GroupBox2.Controls.Add(Me.rdoMakeFileNon)
        Me.GroupBox2.Controls.Add(Me.rdoMakeFileRecv)
        Me.GroupBox2.Controls.Add(Me.rdoMakeFileSend)
        Me.GroupBox2.Controls.Add(Me.chkAscii)
        Me.GroupBox2.Controls.Add(Me.chkSJIS)
        Me.GroupBox2.Controls.Add(Me.chkBinary)
        Me.GroupBox2.Controls.Add(Me.txtLineEyeTextFile)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblProgress)
        Me.GroupBox2.Controls.Add(Me.cmdAnalysis)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(794, 107)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "LINE EYE 出力ﾃｷｽﾄﾌｧｲﾙ変換"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmdDBInsert)
        Me.GroupBox6.Controls.Add(Me.chkCheckSame)
        Me.GroupBox6.Controls.Add(Me.txtInsertDate)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Location = New System.Drawing.Point(579, 9)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(208, 93)
        Me.GroupBox6.TabIndex = 58
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ﾃｰﾌﾞﾙに追加"
        '
        'cmdDBInsert
        '
        Me.cmdDBInsert.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDBInsert.Location = New System.Drawing.Point(97, 48)
        Me.cmdDBInsert.Name = "cmdDBInsert"
        Me.cmdDBInsert.Size = New System.Drawing.Size(82, 34)
        Me.cmdDBInsert.TabIndex = 55
        Me.cmdDBInsert.Text = "ﾃｰﾌﾞﾙに追加"
        Me.cmdDBInsert.UseVisualStyleBackColor = True
        '
        'chkCheckSame
        '
        Me.chkCheckSame.AutoSize = True
        Me.chkCheckSame.Checked = True
        Me.chkCheckSame.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCheckSame.Font = New System.Drawing.Font("ＭＳ ゴシック", 8.0!)
        Me.chkCheckSame.Location = New System.Drawing.Point(9, 53)
        Me.chkCheckSame.Name = "chkCheckSame"
        Me.chkCheckSame.Size = New System.Drawing.Size(90, 26)
        Me.chkCheckSame.TabIndex = 59
        Me.chkCheckSame.Text = "同一ﾚｺｰﾄﾞは" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "追加しない"
        Me.chkCheckSame.UseVisualStyleBackColor = True
        '
        'txtInsertDate
        '
        Me.txtInsertDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInsertDate.Location = New System.Drawing.Point(59, 15)
        Me.txtInsertDate.Name = "txtInsertDate"
        Me.txtInsertDate.Size = New System.Drawing.Size(120, 19)
        Me.txtInsertDate.TabIndex = 56
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("ＭＳ ゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(7, 23)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(182, 27)
        Me.Label24.TabIndex = 57
        Me.Label24.Text = "日付設定" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(ﾃｰﾌﾞﾙに追加する際の発生日時)"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoMakeFileNon
        '
        Me.rdoMakeFileNon.AutoSize = True
        Me.rdoMakeFileNon.Location = New System.Drawing.Point(225, 68)
        Me.rdoMakeFileNon.Name = "rdoMakeFileNon"
        Me.rdoMakeFileNon.Size = New System.Drawing.Size(47, 16)
        Me.rdoMakeFileNon.TabIndex = 54
        Me.rdoMakeFileNon.Text = "独立"
        Me.rdoMakeFileNon.UseVisualStyleBackColor = True
        '
        'rdoMakeFileRecv
        '
        Me.rdoMakeFileRecv.AutoSize = True
        Me.rdoMakeFileRecv.Location = New System.Drawing.Point(282, 84)
        Me.rdoMakeFileRecv.Name = "rdoMakeFileRecv"
        Me.rdoMakeFileRecv.Size = New System.Drawing.Size(71, 16)
        Me.rdoMakeFileRecv.TabIndex = 53
        Me.rdoMakeFileRecv.Text = "受信区切"
        Me.rdoMakeFileRecv.UseVisualStyleBackColor = True
        '
        'rdoMakeFileSend
        '
        Me.rdoMakeFileSend.AutoSize = True
        Me.rdoMakeFileSend.Checked = True
        Me.rdoMakeFileSend.Location = New System.Drawing.Point(282, 69)
        Me.rdoMakeFileSend.Name = "rdoMakeFileSend"
        Me.rdoMakeFileSend.Size = New System.Drawing.Size(71, 16)
        Me.rdoMakeFileSend.TabIndex = 53
        Me.rdoMakeFileSend.TabStop = True
        Me.rdoMakeFileSend.Text = "送信区切"
        Me.rdoMakeFileSend.UseVisualStyleBackColor = True
        '
        'chkAscii
        '
        Me.chkAscii.AutoSize = True
        Me.chkAscii.Location = New System.Drawing.Point(9, 86)
        Me.chkAscii.Name = "chkAscii"
        Me.chkAscii.Size = New System.Drawing.Size(54, 16)
        Me.chkAscii.TabIndex = 37
        Me.chkAscii.Text = "ASCII"
        Me.chkAscii.UseVisualStyleBackColor = True
        '
        'chkSJIS
        '
        Me.chkSJIS.AutoSize = True
        Me.chkSJIS.Location = New System.Drawing.Point(69, 70)
        Me.chkSJIS.Name = "chkSJIS"
        Me.chkSJIS.Size = New System.Drawing.Size(108, 16)
        Me.chkSJIS.TabIndex = 37
        Me.chkSJIS.Text = "SJIS(全角)対応"
        Me.chkSJIS.UseVisualStyleBackColor = True
        '
        'chkBinary
        '
        Me.chkBinary.AutoSize = True
        Me.chkBinary.Checked = True
        Me.chkBinary.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBinary.Location = New System.Drawing.Point(9, 70)
        Me.chkBinary.Name = "chkBinary"
        Me.chkBinary.Size = New System.Drawing.Size(54, 16)
        Me.chkBinary.TabIndex = 37
        Me.chkBinary.Text = "ﾊﾞｲﾅﾘ"
        Me.chkBinary.UseVisualStyleBackColor = True
        '
        'txtTelegramAnalysis01
        '
        Me.txtTelegramAnalysis01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTelegramAnalysis01.Location = New System.Drawing.Point(72, 15)
        Me.txtTelegramAnalysis01.Name = "txtTelegramAnalysis01"
        Me.txtTelegramAnalysis01.Size = New System.Drawing.Size(503, 19)
        Me.txtTelegramAnalysis01.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 19)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "分解電文01"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_82)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_81)
        Me.GroupBox3.Controls.Add(Me.rdoWriteRecv)
        Me.GroupBox3.Controls.Add(Me.rdoWriteSend)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_06)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_05)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_01)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_02)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_04)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_03)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtWriteSend01_99)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(294, 62)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(399, 364)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "書込"
        '
        'txtWriteSend01_82
        '
        Me.txtWriteSend01_82.AcceptsReturn = True
        Me.txtWriteSend01_82.Font = New System.Drawing.Font("ＭＳ ゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_82.Location = New System.Drawing.Point(270, 54)
        Me.txtWriteSend01_82.Multiline = True
        Me.txtWriteSend01_82.Name = "txtWriteSend01_82"
        Me.txtWriteSend01_82.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtWriteSend01_82.Size = New System.Drawing.Size(116, 303)
        Me.txtWriteSend01_82.TabIndex = 53
        '
        'txtWriteSend01_81
        '
        Me.txtWriteSend01_81.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_81.Location = New System.Drawing.Point(200, 35)
        Me.txtWriteSend01_81.Name = "txtWriteSend01_81"
        Me.txtWriteSend01_81.Size = New System.Drawing.Size(186, 19)
        Me.txtWriteSend01_81.TabIndex = 54
        '
        'rdoWriteRecv
        '
        Me.rdoWriteRecv.AutoSize = True
        Me.rdoWriteRecv.Location = New System.Drawing.Point(270, 15)
        Me.rdoWriteRecv.Name = "rdoWriteRecv"
        Me.rdoWriteRecv.Size = New System.Drawing.Size(47, 16)
        Me.rdoWriteRecv.TabIndex = 52
        Me.rdoWriteRecv.Text = "応答"
        Me.rdoWriteRecv.UseVisualStyleBackColor = True
        '
        'rdoWriteSend
        '
        Me.rdoWriteSend.AutoSize = True
        Me.rdoWriteSend.Checked = True
        Me.rdoWriteSend.Location = New System.Drawing.Point(213, 15)
        Me.rdoWriteSend.Name = "rdoWriteSend"
        Me.rdoWriteSend.Size = New System.Drawing.Size(47, 16)
        Me.rdoWriteSend.TabIndex = 51
        Me.rdoWriteSend.TabStop = True
        Me.rdoWriteSend.Text = "要求"
        Me.rdoWriteSend.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(155, 35)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(45, 19)
        Me.Label23.TabIndex = 50
        Me.Label23.Text = "入出庫"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 113)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 19)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "書込ﾃﾞｰﾀ"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWriteSend01_06
        '
        Me.txtWriteSend01_06.AcceptsReturn = True
        Me.txtWriteSend01_06.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_06.Location = New System.Drawing.Point(8, 132)
        Me.txtWriteSend01_06.Multiline = True
        Me.txtWriteSend01_06.Name = "txtWriteSend01_06"
        Me.txtWriteSend01_06.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtWriteSend01_06.Size = New System.Drawing.Size(256, 221)
        Me.txtWriteSend01_06.TabIndex = 49
        '
        'txtWriteSend01_05
        '
        Me.txtWriteSend01_05.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_05.Location = New System.Drawing.Point(70, 91)
        Me.txtWriteSend01_05.Name = "txtWriteSend01_05"
        Me.txtWriteSend01_05.Size = New System.Drawing.Size(64, 19)
        Me.txtWriteSend01_05.TabIndex = 47
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 91)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 19)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "ﾃﾞｰﾀ数"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWriteSend01_01
        '
        Me.txtWriteSend01_01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_01.Location = New System.Drawing.Point(70, 15)
        Me.txtWriteSend01_01.Name = "txtWriteSend01_01"
        Me.txtWriteSend01_01.Size = New System.Drawing.Size(64, 19)
        Me.txtWriteSend01_01.TabIndex = 40
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(157, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 19)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "CRC"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWriteSend01_02
        '
        Me.txtWriteSend01_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_02.Location = New System.Drawing.Point(70, 34)
        Me.txtWriteSend01_02.Name = "txtWriteSend01_02"
        Me.txtWriteSend01_02.Size = New System.Drawing.Size(64, 19)
        Me.txtWriteSend01_02.TabIndex = 39
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 19)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "開始番号"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWriteSend01_04
        '
        Me.txtWriteSend01_04.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_04.Location = New System.Drawing.Point(70, 72)
        Me.txtWriteSend01_04.Name = "txtWriteSend01_04"
        Me.txtWriteSend01_04.Size = New System.Drawing.Size(64, 19)
        Me.txtWriteSend01_04.TabIndex = 41
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 19)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "個数"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWriteSend01_03
        '
        Me.txtWriteSend01_03.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_03.Location = New System.Drawing.Point(70, 53)
        Me.txtWriteSend01_03.Name = "txtWriteSend01_03"
        Me.txtWriteSend01_03.Size = New System.Drawing.Size(64, 19)
        Me.txtWriteSend01_03.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 19)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "ｱﾄﾞﾚｽ"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWriteSend01_99
        '
        Me.txtWriteSend01_99.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtWriteSend01_99.Location = New System.Drawing.Point(200, 91)
        Me.txtWriteSend01_99.Name = "txtWriteSend01_99"
        Me.txtWriteSend01_99.Size = New System.Drawing.Size(64, 19)
        Me.txtWriteSend01_99.TabIndex = 38
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 19)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "ﾌｧﾝｸｼｮﾝ"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtReadRecv01_04)
        Me.GroupBox4.Controls.Add(Me.txtReadRecv01_01)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.txtReadRecv01_02)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.txtReadRecv01_03)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.txtReadRecv01_99)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 185)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(276, 239)
        Me.GroupBox4.TabIndex = 53
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "読込応答"
        '
        'txtReadRecv01_04
        '
        Me.txtReadRecv01_04.AcceptsReturn = True
        Me.txtReadRecv01_04.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadRecv01_04.Location = New System.Drawing.Point(8, 91)
        Me.txtReadRecv01_04.Multiline = True
        Me.txtReadRecv01_04.Name = "txtReadRecv01_04"
        Me.txtReadRecv01_04.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReadRecv01_04.Size = New System.Drawing.Size(256, 139)
        Me.txtReadRecv01_04.TabIndex = 49
        '
        'txtReadRecv01_01
        '
        Me.txtReadRecv01_01.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadRecv01_01.Location = New System.Drawing.Point(70, 15)
        Me.txtReadRecv01_01.Name = "txtReadRecv01_01"
        Me.txtReadRecv01_01.Size = New System.Drawing.Size(64, 19)
        Me.txtReadRecv01_01.TabIndex = 40
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(136, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 19)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "CRC"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReadRecv01_02
        '
        Me.txtReadRecv01_02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadRecv01_02.Location = New System.Drawing.Point(70, 34)
        Me.txtReadRecv01_02.Name = "txtReadRecv01_02"
        Me.txtReadRecv01_02.Size = New System.Drawing.Size(64, 19)
        Me.txtReadRecv01_02.TabIndex = 39
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 19)
        Me.Label19.TabIndex = 46
        Me.Label19.Text = "ﾃﾞｰﾀ数"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 19)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "保持ﾚｼﾞｽﾀ内容"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReadRecv01_03
        '
        Me.txtReadRecv01_03.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadRecv01_03.Location = New System.Drawing.Point(70, 53)
        Me.txtReadRecv01_03.Name = "txtReadRecv01_03"
        Me.txtReadRecv01_03.Size = New System.Drawing.Size(64, 19)
        Me.txtReadRecv01_03.TabIndex = 37
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 19)
        Me.Label21.TabIndex = 42
        Me.Label21.Text = "ｱﾄﾞﾚｽ"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReadRecv01_99
        '
        Me.txtReadRecv01_99.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtReadRecv01_99.Location = New System.Drawing.Point(200, 72)
        Me.txtReadRecv01_99.Name = "txtReadRecv01_99"
        Me.txtReadRecv01_99.Size = New System.Drawing.Size(64, 19)
        Me.txtReadRecv01_99.TabIndex = 38
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 34)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 19)
        Me.Label22.TabIndex = 43
        Me.Label22.Text = "ﾌｧﾝｸｼｮﾝ"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTelegramAnalysis02
        '
        Me.txtTelegramAnalysis02.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTelegramAnalysis02.Location = New System.Drawing.Point(72, 37)
        Me.txtTelegramAnalysis02.Name = "txtTelegramAnalysis02"
        Me.txtTelegramAnalysis02.Size = New System.Drawing.Size(503, 19)
        Me.txtTelegramAnalysis02.TabIndex = 54
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 19)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "分解電文02"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.txtTelegramAnalysis01)
        Me.GroupBox5.Controls.Add(Me.GroupBox3)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.txtTelegramAnalysis02)
        Me.GroupBox5.Controls.Add(Me.GroupBox1)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 116)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(724, 432)
        Me.GroupBox5.TabIndex = 56
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "安川PLC機能"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("ＭＳ ゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(581, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(137, 41)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "※分解電文02は読込" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　応答でのみ使用。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　分解電文01とﾜﾝｾｯﾄ。"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdMelsecAnalysis
        '
        Me.cmdMelsecAnalysis.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdMelsecAnalysis.Location = New System.Drawing.Point(733, 116)
        Me.cmdMelsecAnalysis.Name = "cmdMelsecAnalysis"
        Me.cmdMelsecAnalysis.Size = New System.Drawing.Size(82, 34)
        Me.cmdMelsecAnalysis.TabIndex = 60
        Me.cmdMelsecAnalysis.Text = "Melsec" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "電文解析"
        Me.cmdMelsecAnalysis.UseVisualStyleBackColor = True
        '
        'cmdInsertXMST_EQ_NAME
        '
        Me.cmdInsertXMST_EQ_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdInsertXMST_EQ_NAME.Location = New System.Drawing.Point(733, 156)
        Me.cmdInsertXMST_EQ_NAME.Name = "cmdInsertXMST_EQ_NAME"
        Me.cmdInsertXMST_EQ_NAME.Size = New System.Drawing.Size(82, 34)
        Me.cmdInsertXMST_EQ_NAME.TabIndex = 61
        Me.cmdInsertXMST_EQ_NAME.Text = "XMST_EQ_NAME追加"
        Me.cmdInsertXMST_EQ_NAME.UseVisualStyleBackColor = True
        '
        'txtTextFile02
        '
        Me.txtTextFile02.AcceptsReturn = True
        Me.txtTextFile02.Font = New System.Drawing.Font("ＭＳ ゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTextFile02.Location = New System.Drawing.Point(61, 554)
        Me.txtTextFile02.Multiline = True
        Me.txtTextFile02.Name = "txtTextFile02"
        Me.txtTextFile02.Size = New System.Drawing.Size(515, 41)
        Me.txtTextFile02.TabIndex = 59
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 554)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 19)
        Me.Label25.TabIndex = 60
        Me.Label25.Text = "ﾌｧｲﾙﾊﾟｽ2"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 673)
        Me.Controls.Add(Me.txtTextFile02)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cmdInsertXMST_EQ_NAME)
        Me.Controls.Add(Me.cmdMelsecAnalysis)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmAnalysis"
        Me.Text = "frmAnalysis"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLineEyeTextFile As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdAnalysis As System.Windows.Forms.Button
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReadSend01_99 As System.Windows.Forms.TextBox
    Friend WithEvents txtReadSend01_03 As System.Windows.Forms.TextBox
    Friend WithEvents txtReadSend01_04 As System.Windows.Forms.TextBox
    Friend WithEvents txtReadSend01_01 As System.Windows.Forms.TextBox
    Friend WithEvents txtReadSend01_02 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTelegramAnalysis01 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtWriteSend01_01 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_02 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_04 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_03 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_99 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_05 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_06 As System.Windows.Forms.TextBox
    Friend WithEvents rdoWriteSend As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWriteRecv As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReadRecv01_04 As System.Windows.Forms.TextBox
    Friend WithEvents txtReadRecv01_01 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtReadRecv01_02 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtReadRecv01_03 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtReadRecv01_99 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTelegramAnalysis02 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkAscii As System.Windows.Forms.CheckBox
    Friend WithEvents chkBinary As System.Windows.Forms.CheckBox
    Friend WithEvents rdoMakeFileNon As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMakeFileRecv As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMakeFileSend As System.Windows.Forms.RadioButton
    Friend WithEvents chkSJIS As System.Windows.Forms.CheckBox
    Friend WithEvents txtWriteSend01_82 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtWriteSend01_81 As System.Windows.Forms.TextBox
    Friend WithEvents cmdDBInsert As System.Windows.Forms.Button
    Friend WithEvents txtInsertDate As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCheckSame As System.Windows.Forms.CheckBox
    Friend WithEvents cmdMelsecAnalysis As System.Windows.Forms.Button
    Friend WithEvents cmdInsertXMST_EQ_NAME As System.Windows.Forms.Button
    Friend WithEvents txtTextFile02 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
End Class
