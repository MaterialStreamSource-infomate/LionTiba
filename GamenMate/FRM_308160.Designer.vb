<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308160
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblXSEIZOU_DT = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.lblFHINMEI_CD = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblXSYUKKA_NO = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblFBUF_NAME = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSYUKKA_SU = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblMIKENPIN_SU = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblSELGOUKEI_SU = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.grdList2 = New GamenCommon.cmpMDataGrid(Me.components)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1142, 672)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1152, 536)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(1030, 672)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(278, 672)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 672)
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(1152, 488)
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(1152, 440)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1152, 392)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdList.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdList.Location = New System.Drawing.Point(168, 328)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 334)
        Me.grdList.TabIndex = 22
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblXSEIZOU_DT)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox1.Controls.Add(Me.lblFHINMEI_CD)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblXSYUKKA_NO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblFBUF_NAME)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 89)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1080, 183)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'lblXSEIZOU_DT
        '
        Me.lblXSEIZOU_DT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXSEIZOU_DT.ForeColor = System.Drawing.Color.Black
        Me.lblXSEIZOU_DT.Location = New System.Drawing.Point(160, 136)
        Me.lblXSEIZOU_DT.Name = "lblXSEIZOU_DT"
        Me.lblXSEIZOU_DT.Size = New System.Drawing.Size(208, 32)
        Me.lblXSEIZOU_DT.TabIndex = 8
        Me.lblXSEIZOU_DT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(21, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 32)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "製造年月日:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(376, 96)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(544, 32)
        Me.lblFHINMEI.TabIndex = 6
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFHINMEI_CD
        '
        Me.lblFHINMEI_CD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI_CD.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI_CD.Location = New System.Drawing.Point(160, 96)
        Me.lblFHINMEI_CD.Name = "lblFHINMEI_CD"
        Me.lblFHINMEI_CD.Size = New System.Drawing.Size(208, 32)
        Me.lblFHINMEI_CD.TabIndex = 5
        Me.lblFHINMEI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(21, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 32)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "品名:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXSYUKKA_NO
        '
        Me.lblXSYUKKA_NO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSYUKKA_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXSYUKKA_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXSYUKKA_NO.Location = New System.Drawing.Point(160, 56)
        Me.lblXSYUKKA_NO.Name = "lblXSYUKKA_NO"
        Me.lblXSYUKKA_NO.Size = New System.Drawing.Size(208, 32)
        Me.lblXSYUKKA_NO.TabIndex = 3
        Me.lblXSYUKKA_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(21, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 32)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "出荷№:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFBUF_NAME
        '
        Me.lblFBUF_NAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFBUF_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFBUF_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblFBUF_NAME.Location = New System.Drawing.Point(160, 16)
        Me.lblFBUF_NAME.Name = "lblFBUF_NAME"
        Me.lblFBUF_NAME.Size = New System.Drawing.Size(208, 32)
        Me.lblFBUF_NAME.TabIndex = 1
        Me.lblFBUF_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "出庫場所:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSYUKKA_SU
        '
        Me.lblSYUKKA_SU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSYUKKA_SU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSYUKKA_SU.ForeColor = System.Drawing.Color.Black
        Me.lblSYUKKA_SU.Location = New System.Drawing.Point(329, 280)
        Me.lblSYUKKA_SU.Name = "lblSYUKKA_SU"
        Me.lblSYUKKA_SU.Size = New System.Drawing.Size(109, 32)
        Me.lblSYUKKA_SU.TabIndex = 17
        Me.lblSYUKKA_SU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(222, 280)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 32)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "出荷数:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMIKENPIN_SU
        '
        Me.lblMIKENPIN_SU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMIKENPIN_SU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblMIKENPIN_SU.ForeColor = System.Drawing.Color.Black
        Me.lblMIKENPIN_SU.Location = New System.Drawing.Point(599, 280)
        Me.lblMIKENPIN_SU.Name = "lblMIKENPIN_SU"
        Me.lblMIKENPIN_SU.Size = New System.Drawing.Size(109, 32)
        Me.lblMIKENPIN_SU.TabIndex = 19
        Me.lblMIKENPIN_SU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(478, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 32)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "未検品数:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSELGOUKEI_SU
        '
        Me.lblSELGOUKEI_SU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSELGOUKEI_SU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSELGOUKEI_SU.ForeColor = System.Drawing.Color.Black
        Me.lblSELGOUKEI_SU.Location = New System.Drawing.Point(934, 280)
        Me.lblSELGOUKEI_SU.Name = "lblSELGOUKEI_SU"
        Me.lblSELGOUKEI_SU.Size = New System.Drawing.Size(109, 32)
        Me.lblSELGOUKEI_SU.TabIndex = 21
        Me.lblSELGOUKEI_SU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(742, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(192, 32)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "検品数選択合計:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList2
        '
        Me.grdList2.blnDBUpdate = False
        Me.grdList2.blnSelectionChanged = False
        Me.grdList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdList2.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdList2.Location = New System.Drawing.Point(456, 568)
        Me.grdList2.MyBeseDoubleBuffered = False
        Me.grdList2.Name = "grdList2"
        Me.grdList2.RowTemplate.Height = 21
        Me.grdList2.Size = New System.Drawing.Size(792, 128)
        Me.grdList2.TabIndex = 213
        Me.grdList2.Visible = False
        '
        'FRM_308160
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList2)
        Me.Controls.Add(Me.lblSELGOUKEI_SU)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblMIKENPIN_SU)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblSYUKKA_SU)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_308160"
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lblSYUKKA_SU, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.lblMIKENPIN_SU, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lblSELGOUKEI_SU, 0)
        Me.Controls.SetChildIndex(Me.grdList2, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblXSYUKKA_NO As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFBUF_NAME As System.Windows.Forms.Label
    Friend WithEvents lblXSEIZOU_DT As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI_CD As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSYUKKA_SU As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblMIKENPIN_SU As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSELGOUKEI_SU As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grdList2 As GamenCommon.cmpMDataGrid

End Class
