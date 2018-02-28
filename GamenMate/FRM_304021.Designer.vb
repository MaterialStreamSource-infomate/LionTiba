<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_304021
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblXSEIZOU_DT = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblFBUF_NAME = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.lblFHINMEI_CD = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblXORDER_NO = New System.Windows.Forms.Label
        Me.lblXNYUKA_JIGYOU_NM = New System.Windows.Forms.Label
        Me.lblCAR_NO_WARITUKE = New System.Windows.Forms.Label
        Me.lblXSYUKKA_DT = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1144, 664)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(278, 664)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(168, 664)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 248)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 397)
        Me.grdList.TabIndex = 21
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblXSEIZOU_DT)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblFBUF_NAME)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox1.Controls.Add(Me.lblFHINMEI_CD)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblXORDER_NO)
        Me.GroupBox1.Controls.Add(Me.lblXNYUKA_JIGYOU_NM)
        Me.GroupBox1.Controls.Add(Me.lblCAR_NO_WARITUKE)
        Me.GroupBox1.Controls.Add(Me.lblXSYUKKA_DT)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1080, 148)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'lblXSEIZOU_DT
        '
        Me.lblXSEIZOU_DT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXSEIZOU_DT.ForeColor = System.Drawing.Color.Black
        Me.lblXSEIZOU_DT.Location = New System.Drawing.Point(512, 96)
        Me.lblXSEIZOU_DT.Name = "lblXSEIZOU_DT"
        Me.lblXSEIZOU_DT.Size = New System.Drawing.Size(136, 32)
        Me.lblXSEIZOU_DT.TabIndex = 14
        Me.lblXSEIZOU_DT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(360, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(151, 32)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "製造年月日:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFBUF_NAME
        '
        Me.lblFBUF_NAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFBUF_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFBUF_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblFBUF_NAME.Location = New System.Drawing.Point(144, 96)
        Me.lblFBUF_NAME.Name = "lblFBUF_NAME"
        Me.lblFBUF_NAME.Size = New System.Drawing.Size(192, 32)
        Me.lblFBUF_NAME.TabIndex = 12
        Me.lblFBUF_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(24, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 32)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "出荷場所:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(552, 56)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(384, 32)
        Me.lblFHINMEI.TabIndex = 10
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFHINMEI_CD
        '
        Me.lblFHINMEI_CD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI_CD.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI_CD.Location = New System.Drawing.Point(424, 56)
        Me.lblFHINMEI_CD.Name = "lblFHINMEI_CD"
        Me.lblFHINMEI_CD.Size = New System.Drawing.Size(120, 32)
        Me.lblFHINMEI_CD.TabIndex = 9
        Me.lblFHINMEI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(296, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 32)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "品名ｺｰﾄﾞ:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXORDER_NO
        '
        Me.lblXORDER_NO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXORDER_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXORDER_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXORDER_NO.Location = New System.Drawing.Point(144, 56)
        Me.lblXORDER_NO.Name = "lblXORDER_NO"
        Me.lblXORDER_NO.Size = New System.Drawing.Size(136, 32)
        Me.lblXORDER_NO.TabIndex = 7
        Me.lblXORDER_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXNYUKA_JIGYOU_NM
        '
        Me.lblXNYUKA_JIGYOU_NM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXNYUKA_JIGYOU_NM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXNYUKA_JIGYOU_NM.ForeColor = System.Drawing.Color.Black
        Me.lblXNYUKA_JIGYOU_NM.Location = New System.Drawing.Point(664, 16)
        Me.lblXNYUKA_JIGYOU_NM.Name = "lblXNYUKA_JIGYOU_NM"
        Me.lblXNYUKA_JIGYOU_NM.Size = New System.Drawing.Size(328, 32)
        Me.lblXNYUKA_JIGYOU_NM.TabIndex = 5
        Me.lblXNYUKA_JIGYOU_NM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCAR_NO_WARITUKE
        '
        Me.lblCAR_NO_WARITUKE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblCAR_NO_WARITUKE.ForeColor = System.Drawing.Color.Black
        Me.lblCAR_NO_WARITUKE.Location = New System.Drawing.Point(424, 16)
        Me.lblCAR_NO_WARITUKE.Name = "lblCAR_NO_WARITUKE"
        Me.lblCAR_NO_WARITUKE.Size = New System.Drawing.Size(118, 32)
        Me.lblCAR_NO_WARITUKE.TabIndex = 3
        Me.lblCAR_NO_WARITUKE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXSYUKKA_DT
        '
        Me.lblXSYUKKA_DT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSYUKKA_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXSYUKKA_DT.ForeColor = System.Drawing.Color.Black
        Me.lblXSYUKKA_DT.Location = New System.Drawing.Point(144, 16)
        Me.lblXSYUKKA_DT.Name = "lblXSYUKKA_DT"
        Me.lblXSYUKKA_DT.Size = New System.Drawing.Size(136, 32)
        Me.lblXSYUKKA_DT.TabIndex = 1
        Me.lblXSYUKKA_DT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(40, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "出荷日:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(568, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 32)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "配送先:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(40, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 32)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "発注№:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(304, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 32)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "受付車番:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_304021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grdList)
        Me.Name = "FRM_304021"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblXSYUKKA_DT As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI_CD As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblXORDER_NO As System.Windows.Forms.Label
    Friend WithEvents lblXNYUKA_JIGYOU_NM As System.Windows.Forms.Label
    Friend WithEvents lblCAR_NO_WARITUKE As System.Windows.Forms.Label
    Friend WithEvents lblXSEIZOU_DT As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblFBUF_NAME As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label

End Class
