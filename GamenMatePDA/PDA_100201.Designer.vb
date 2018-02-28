<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA_100201
    Inherits GamenMatePDA.PDA_000001

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
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblMsg = New System.Windows.Forms.Label
        Me.lblXCAR_NO_EDA = New System.Windows.Forms.Label
        Me.lblXCAR_NO = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblXBC_DATA = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblFHINEMI_CD = New System.Windows.Forms.Label
        Me.lblXSEIZOU_DT = New System.Windows.Forms.Label
        Me.lblXLINE_NO = New System.Windows.Forms.Label
        Me.lblXPALLET_NO = New System.Windows.Forms.Label
        Me.lblFTR_VOL = New System.Windows.Forms.Label
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(474, 32)
        Me.lblTitle.TabIndex = 57
        Me.lblTitle.Text = "ﾊﾞｰｺｰﾄﾞｴﾗｰ"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("ＭＳ ゴシック", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMsg.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblMsg.Location = New System.Drawing.Point(0, 33)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(439, 41)
        Me.lblMsg.TabIndex = 277
        Me.lblMsg.Text = "検品NGです。"
        '
        'lblXCAR_NO_EDA
        '
        Me.lblXCAR_NO_EDA.BackColor = System.Drawing.Color.Transparent
        Me.lblXCAR_NO_EDA.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXCAR_NO_EDA.ForeColor = System.Drawing.Color.Black
        Me.lblXCAR_NO_EDA.Location = New System.Drawing.Point(246, 71)
        Me.lblXCAR_NO_EDA.Name = "lblXCAR_NO_EDA"
        Me.lblXCAR_NO_EDA.Size = New System.Drawing.Size(26, 32)
        Me.lblXCAR_NO_EDA.TabIndex = 294
        Me.lblXCAR_NO_EDA.Text = "9"
        Me.lblXCAR_NO_EDA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXCAR_NO
        '
        Me.lblXCAR_NO.BackColor = System.Drawing.Color.Transparent
        Me.lblXCAR_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXCAR_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXCAR_NO.Location = New System.Drawing.Point(167, 71)
        Me.lblXCAR_NO.Name = "lblXCAR_NO"
        Me.lblXCAR_NO.Size = New System.Drawing.Size(64, 32)
        Me.lblXCAR_NO.TabIndex = 293
        Me.lblXCAR_NO.Text = "9999"
        Me.lblXCAR_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(217, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 32)
        Me.Label3.TabIndex = 292
        Me.Label3.Text = "-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(39, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 32)
        Me.Label1.TabIndex = 291
        Me.Label1.Text = "車輌№:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1, 341)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(341, 32)
        Me.Label2.TabIndex = 295
        Me.Label2.Text = "【ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ】"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXBC_DATA
        '
        Me.lblXBC_DATA.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXBC_DATA.ForeColor = System.Drawing.Color.Black
        Me.lblXBC_DATA.Location = New System.Drawing.Point(12, 377)
        Me.lblXBC_DATA.Name = "lblXBC_DATA"
        Me.lblXBC_DATA.Size = New System.Drawing.Size(400, 32)
        Me.lblXBC_DATA.TabIndex = 296
        Me.lblXBC_DATA.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Me.lblXBC_DATA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 32)
        Me.Label5.TabIndex = 297
        Me.Label5.Text = "品名ｺｰﾄﾞ:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(27, 161)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(412, 32)
        Me.lblFHINMEI.TabIndex = 298
        Me.lblFHINMEI.Text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 32)
        Me.Label7.TabIndex = 299
        Me.Label7.Text = "製造年月日:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 233)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(169, 32)
        Me.Label8.TabIndex = 300
        Me.Label8.Text = "ﾗｲﾝ№:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 269)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 32)
        Me.Label9.TabIndex = 301
        Me.Label9.Text = "ﾊﾟﾚｯﾄ№:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(6, 305)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(169, 32)
        Me.Label10.TabIndex = 302
        Me.Label10.Text = "積み数:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINEMI_CD
        '
        Me.lblFHINEMI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINEMI_CD.ForeColor = System.Drawing.Color.Black
        Me.lblFHINEMI_CD.Location = New System.Drawing.Point(181, 125)
        Me.lblFHINEMI_CD.Name = "lblFHINEMI_CD"
        Me.lblFHINEMI_CD.Size = New System.Drawing.Size(245, 32)
        Me.lblFHINEMI_CD.TabIndex = 303
        Me.lblFHINEMI_CD.Text = "999999"
        Me.lblFHINEMI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXSEIZOU_DT
        '
        Me.lblXSEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXSEIZOU_DT.ForeColor = System.Drawing.Color.Black
        Me.lblXSEIZOU_DT.Location = New System.Drawing.Point(181, 197)
        Me.lblXSEIZOU_DT.Name = "lblXSEIZOU_DT"
        Me.lblXSEIZOU_DT.Size = New System.Drawing.Size(140, 32)
        Me.lblXSEIZOU_DT.TabIndex = 304
        Me.lblXSEIZOU_DT.Text = "2012/08/01"
        Me.lblXSEIZOU_DT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXLINE_NO
        '
        Me.lblXLINE_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXLINE_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXLINE_NO.Location = New System.Drawing.Point(181, 233)
        Me.lblXLINE_NO.Name = "lblXLINE_NO"
        Me.lblXLINE_NO.Size = New System.Drawing.Size(91, 32)
        Me.lblXLINE_NO.TabIndex = 305
        Me.lblXLINE_NO.Text = "999999"
        Me.lblXLINE_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXPALLET_NO
        '
        Me.lblXPALLET_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXPALLET_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXPALLET_NO.Location = New System.Drawing.Point(181, 269)
        Me.lblXPALLET_NO.Name = "lblXPALLET_NO"
        Me.lblXPALLET_NO.Size = New System.Drawing.Size(91, 32)
        Me.lblXPALLET_NO.TabIndex = 306
        Me.lblXPALLET_NO.Text = "9999"
        Me.lblXPALLET_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFTR_VOL
        '
        Me.lblFTR_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFTR_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblFTR_VOL.Location = New System.Drawing.Point(181, 305)
        Me.lblFTR_VOL.Name = "lblFTR_VOL"
        Me.lblFTR_VOL.Size = New System.Drawing.Size(91, 32)
        Me.lblFTR_VOL.TabIndex = 307
        Me.lblFTR_VOL.Text = "9999"
        Me.lblFTR_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.Navy
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmdZikkou.ForeColor = System.Drawing.Color.White
        Me.cmdZikkou.Location = New System.Drawing.Point(298, 412)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(128, 40)
        Me.cmdZikkou.TabIndex = 308
        Me.cmdZikkou.Text = "確認"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'PDA_100201
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(438, 462)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.lblFTR_VOL)
        Me.Controls.Add(Me.lblXPALLET_NO)
        Me.Controls.Add(Me.lblXLINE_NO)
        Me.Controls.Add(Me.lblXSEIZOU_DT)
        Me.Controls.Add(Me.lblFHINEMI_CD)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblXBC_DATA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblXCAR_NO_EDA)
        Me.Controls.Add(Me.lblXCAR_NO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "PDA_100201"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lblXCAR_NO_EDA As System.Windows.Forms.Label
    Friend WithEvents lblXCAR_NO As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblXBC_DATA As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblFHINEMI_CD As System.Windows.Forms.Label
    Friend WithEvents lblXSEIZOU_DT As System.Windows.Forms.Label
    Friend WithEvents lblXLINE_NO As System.Windows.Forms.Label
    Friend WithEvents lblXPALLET_NO As System.Windows.Forms.Label
    Friend WithEvents lblFTR_VOL As System.Windows.Forms.Label
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button

End Class
