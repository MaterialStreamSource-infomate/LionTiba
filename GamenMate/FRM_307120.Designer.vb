<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307120
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
        Me.lblGET_Time = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.tmr307120 = New System.Windows.Forms.Timer(Me.components)
        Me.lblPlace = New System.Windows.Forms.Label
        Me.lblCRANE7 = New System.Windows.Forms.Label
        Me.lblCV5 = New System.Windows.Forms.Label
        Me.lblCV4 = New System.Windows.Forms.Label
        Me.lblCV3 = New System.Windows.Forms.Label
        Me.lblCVdown2 = New System.Windows.Forms.Label
        Me.lblCVdown1 = New System.Windows.Forms.Label
        Me.lblCVup2 = New System.Windows.Forms.Label
        Me.lblCVup1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblDirection3 = New System.Windows.Forms.Label
        Me.lblDirection1 = New System.Windows.Forms.Label
        Me.lblDirection2 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(696, 664)
        Me.cmdF6.Size = New System.Drawing.Size(120, 43)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(563, 664)
        Me.cmdF5.Size = New System.Drawing.Size(120, 43)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(432, 664)
        Me.cmdF4.Size = New System.Drawing.Size(120, 43)
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(299, 664)
        Me.cmdF3.Size = New System.Drawing.Size(120, 43)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(168, 664)
        Me.cmdF2.Size = New System.Drawing.Size(120, 43)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(971, 664)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 100)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 166)
        Me.grdList.TabIndex = 213
        '
        'lblGET_Time
        '
        Me.lblGET_Time.BackColor = System.Drawing.Color.Transparent
        Me.lblGET_Time.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGET_Time.ForeColor = System.Drawing.Color.Black
        Me.lblGET_Time.Location = New System.Drawing.Point(339, 65)
        Me.lblGET_Time.Name = "lblGET_Time"
        Me.lblGET_Time.Size = New System.Drawing.Size(305, 32)
        Me.lblGET_Time.TabIndex = 215
        Me.lblGET_Time.Text = "2013/01/01 00:00:00"
        Me.lblGET_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(164, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 32)
        Me.Label14.TabIndex = 214
        Me.Label14.Text = "データ取得日時:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmr307120
        '
        Me.tmr307120.Interval = 5000
        '
        'lblPlace
        '
        Me.lblPlace.BackColor = System.Drawing.Color.Transparent
        Me.lblPlace.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblPlace.ForeColor = System.Drawing.Color.Black
        Me.lblPlace.Location = New System.Drawing.Point(808, 65)
        Me.lblPlace.Name = "lblPlace"
        Me.lblPlace.Size = New System.Drawing.Size(321, 32)
        Me.lblPlace.TabIndex = 216
        Me.lblPlace.Text = "1F 2号クレーン入棚"
        Me.lblPlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCRANE7
        '
        Me.lblCRANE7.BackColor = System.Drawing.Color.White
        Me.lblCRANE7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCRANE7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCRANE7.ForeColor = System.Drawing.Color.Black
        Me.lblCRANE7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCRANE7.Location = New System.Drawing.Point(977, 498)
        Me.lblCRANE7.Name = "lblCRANE7"
        Me.lblCRANE7.Size = New System.Drawing.Size(65, 60)
        Me.lblCRANE7.TabIndex = 434
        Me.lblCRANE7.Text = "RTN"
        Me.lblCRANE7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCV5
        '
        Me.lblCV5.BackColor = System.Drawing.Color.White
        Me.lblCV5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCV5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCV5.ForeColor = System.Drawing.Color.Black
        Me.lblCV5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCV5.Location = New System.Drawing.Point(877, 460)
        Me.lblCV5.Name = "lblCV5"
        Me.lblCV5.Size = New System.Drawing.Size(65, 60)
        Me.lblCV5.TabIndex = 435
        Me.lblCV5.Text = "CVNo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1"
        Me.lblCV5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCV4
        '
        Me.lblCV4.BackColor = System.Drawing.Color.White
        Me.lblCV4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCV4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCV4.ForeColor = System.Drawing.Color.Black
        Me.lblCV4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCV4.Location = New System.Drawing.Point(789, 460)
        Me.lblCV4.Name = "lblCV4"
        Me.lblCV4.Size = New System.Drawing.Size(65, 60)
        Me.lblCV4.TabIndex = 436
        Me.lblCV4.Text = "CVNo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2"
        Me.lblCV4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCV3
        '
        Me.lblCV3.BackColor = System.Drawing.Color.White
        Me.lblCV3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCV3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCV3.ForeColor = System.Drawing.Color.Black
        Me.lblCV3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCV3.Location = New System.Drawing.Point(699, 460)
        Me.lblCV3.Name = "lblCV3"
        Me.lblCV3.Size = New System.Drawing.Size(65, 60)
        Me.lblCV3.TabIndex = 437
        Me.lblCV3.Text = "CVNo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3"
        Me.lblCV3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCVdown2
        '
        Me.lblCVdown2.BackColor = System.Drawing.Color.White
        Me.lblCVdown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCVdown2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCVdown2.ForeColor = System.Drawing.Color.Black
        Me.lblCVdown2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCVdown2.Location = New System.Drawing.Point(563, 460)
        Me.lblCVdown2.Name = "lblCVdown2"
        Me.lblCVdown2.Size = New System.Drawing.Size(100, 60)
        Me.lblCVdown2.TabIndex = 438
        Me.lblCVdown2.Text = "CVNo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4下"
        Me.lblCVdown2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCVdown1
        '
        Me.lblCVdown1.BackColor = System.Drawing.Color.White
        Me.lblCVdown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCVdown1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCVdown1.ForeColor = System.Drawing.Color.Black
        Me.lblCVdown1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCVdown1.Location = New System.Drawing.Point(457, 460)
        Me.lblCVdown1.Name = "lblCVdown1"
        Me.lblCVdown1.Size = New System.Drawing.Size(100, 60)
        Me.lblCVdown1.TabIndex = 439
        Me.lblCVdown1.Text = "CVNo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5下"
        Me.lblCVdown1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCVup2
        '
        Me.lblCVup2.BackColor = System.Drawing.Color.White
        Me.lblCVup2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCVup2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCVup2.ForeColor = System.Drawing.Color.Black
        Me.lblCVup2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCVup2.Location = New System.Drawing.Point(563, 318)
        Me.lblCVup2.Name = "lblCVup2"
        Me.lblCVup2.Size = New System.Drawing.Size(100, 60)
        Me.lblCVup2.TabIndex = 440
        Me.lblCVup2.Text = "CVNo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4上(指示)"
        Me.lblCVup2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCVup1
        '
        Me.lblCVup1.BackColor = System.Drawing.Color.White
        Me.lblCVup1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCVup1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCVup1.ForeColor = System.Drawing.Color.Black
        Me.lblCVup1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCVup1.Location = New System.Drawing.Point(457, 318)
        Me.lblCVup1.Name = "lblCVup1"
        Me.lblCVup1.Size = New System.Drawing.Size(100, 60)
        Me.lblCVup1.TabIndex = 441
        Me.lblCVup1.Text = "CVNo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5上(指示)"
        Me.lblCVup1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(448, 454)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(224, 73)
        Me.Label8.TabIndex = 442
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Location = New System.Drawing.Point(448, 312)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(224, 73)
        Me.Label9.TabIndex = 443
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(339, 318)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 32)
        Me.Label10.TabIndex = 444
        Me.Label10.Text = "ﾘﾌﾀｰ上昇後" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "指示ﾃﾞｰﾀ"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(339, 460)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 32)
        Me.Label11.TabIndex = 445
        Me.Label11.Text = "ﾘﾌﾀｰ下降時" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CVﾃﾞｰﾀ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label12.Location = New System.Drawing.Point(241, 418)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 16)
        Me.Label12.TabIndex = 446
        Me.Label12.Text = "<<棚側>>"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(1008, 460)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(2, 166)
        Me.Label13.TabIndex = 447
        '
        'lblDirection3
        '
        Me.lblDirection3.BackColor = System.Drawing.Color.Transparent
        Me.lblDirection3.Font = New System.Drawing.Font("ＭＳ ゴシック", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDirection3.ForeColor = System.Drawing.Color.Red
        Me.lblDirection3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDirection3.Location = New System.Drawing.Point(995, 423)
        Me.lblDirection3.Name = "lblDirection3"
        Me.lblDirection3.Size = New System.Drawing.Size(34, 59)
        Me.lblDirection3.TabIndex = 448
        Me.lblDirection3.Text = "↑"
        Me.lblDirection3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDirection1
        '
        Me.lblDirection1.BackColor = System.Drawing.Color.Transparent
        Me.lblDirection1.Font = New System.Drawing.Font("ＭＳ ゴシック", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDirection1.ForeColor = System.Drawing.Color.Red
        Me.lblDirection1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDirection1.Location = New System.Drawing.Point(524, 389)
        Me.lblDirection1.Name = "lblDirection1"
        Me.lblDirection1.Size = New System.Drawing.Size(78, 62)
        Me.lblDirection1.TabIndex = 449
        Me.lblDirection1.Text = "↑"
        Me.lblDirection1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDirection2
        '
        Me.lblDirection2.BackColor = System.Drawing.Color.Transparent
        Me.lblDirection2.Font = New System.Drawing.Font("ＭＳ ゴシック", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDirection2.ForeColor = System.Drawing.Color.Red
        Me.lblDirection2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDirection2.Location = New System.Drawing.Point(751, 520)
        Me.lblDirection2.Name = "lblDirection2"
        Me.lblDirection2.Size = New System.Drawing.Size(137, 95)
        Me.lblDirection2.TabIndex = 450
        Me.lblDirection2.Text = "←"
        Me.lblDirection2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(1008, 396)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(2, 30)
        Me.Label15.TabIndex = 451
        '
        'FRM_307120
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblDirection2)
        Me.Controls.Add(Me.lblDirection1)
        Me.Controls.Add(Me.lblDirection3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblCVup1)
        Me.Controls.Add(Me.lblCVup2)
        Me.Controls.Add(Me.lblCVdown1)
        Me.Controls.Add(Me.lblCVdown2)
        Me.Controls.Add(Me.lblCV3)
        Me.Controls.Add(Me.lblCV4)
        Me.Controls.Add(Me.lblCV5)
        Me.Controls.Add(Me.lblCRANE7)
        Me.Controls.Add(Me.lblPlace)
        Me.Controls.Add(Me.lblGET_Time)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label13)
        Me.Name = "FRM_307120"
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.lblGET_Time, 0)
        Me.Controls.SetChildIndex(Me.lblPlace, 0)
        Me.Controls.SetChildIndex(Me.lblCRANE7, 0)
        Me.Controls.SetChildIndex(Me.lblCV5, 0)
        Me.Controls.SetChildIndex(Me.lblCV4, 0)
        Me.Controls.SetChildIndex(Me.lblCV3, 0)
        Me.Controls.SetChildIndex(Me.lblCVdown2, 0)
        Me.Controls.SetChildIndex(Me.lblCVdown1, 0)
        Me.Controls.SetChildIndex(Me.lblCVup2, 0)
        Me.Controls.SetChildIndex(Me.lblCVup1, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.lblDirection3, 0)
        Me.Controls.SetChildIndex(Me.lblDirection1, 0)
        Me.Controls.SetChildIndex(Me.lblDirection2, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents lblGET_Time As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tmr307120 As System.Windows.Forms.Timer
    Friend WithEvents lblPlace As System.Windows.Forms.Label
    Friend WithEvents lblCRANE7 As System.Windows.Forms.Label
    Friend WithEvents lblCV5 As System.Windows.Forms.Label
    Friend WithEvents lblCV4 As System.Windows.Forms.Label
    Friend WithEvents lblCV3 As System.Windows.Forms.Label
    Friend WithEvents lblCVdown2 As System.Windows.Forms.Label
    Friend WithEvents lblCVdown1 As System.Windows.Forms.Label
    Friend WithEvents lblCVup2 As System.Windows.Forms.Label
    Friend WithEvents lblCVup1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblDirection3 As System.Windows.Forms.Label
    Friend WithEvents lblDirection1 As System.Windows.Forms.Label
    Friend WithEvents lblDirection2 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label

End Class
