<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_303011
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
        Me.lblST_VALUE = New System.Windows.Forms.Label
        Me.lblST_NAME = New System.Windows.Forms.Label
        Me.cmdNyuukoSet = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblFHINMEI_CD = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtHASUU_VOL = New MateCommon.cmpMTextBoxNumber
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtFULL_PL = New MateCommon.cmpMTextBoxNumber
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblPL_VOL = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblST_VALUE
        '
        Me.lblST_VALUE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblST_VALUE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblST_VALUE.ForeColor = System.Drawing.Color.Black
        Me.lblST_VALUE.Location = New System.Drawing.Point(205, 10)
        Me.lblST_VALUE.Name = "lblST_VALUE"
        Me.lblST_VALUE.Size = New System.Drawing.Size(475, 32)
        Me.lblST_VALUE.TabIndex = 0
        Me.lblST_VALUE.Text = "ST名"
        Me.lblST_VALUE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblST_NAME
        '
        Me.lblST_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblST_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblST_NAME.Location = New System.Drawing.Point(34, 10)
        Me.lblST_NAME.Name = "lblST_NAME"
        Me.lblST_NAME.Size = New System.Drawing.Size(165, 32)
        Me.lblST_NAME.TabIndex = 34
        Me.lblST_NAME.Text = "入庫ST:"
        Me.lblST_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdNyuukoSet
        '
        Me.cmdNyuukoSet.BackColor = System.Drawing.Color.DarkGray
        Me.cmdNyuukoSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdNyuukoSet.ForeColor = System.Drawing.Color.Black
        Me.cmdNyuukoSet.Location = New System.Drawing.Point(20, 241)
        Me.cmdNyuukoSet.Name = "cmdNyuukoSet"
        Me.cmdNyuukoSet.Size = New System.Drawing.Size(187, 40)
        Me.cmdNyuukoSet.TabIndex = 5
        Me.cmdNyuukoSet.Text = "入庫設定"
        Me.cmdNyuukoSet.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(493, 241)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(187, 40)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lblFHINMEI_CD
        '
        Me.lblFHINMEI_CD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI_CD.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI_CD.Location = New System.Drawing.Point(205, 63)
        Me.lblFHINMEI_CD.Name = "lblFHINMEI_CD"
        Me.lblFHINMEI_CD.Size = New System.Drawing.Size(475, 32)
        Me.lblFHINMEI_CD.TabIndex = 1
        Me.lblFHINMEI_CD.Text = "品名ｺｰﾄﾞ"
        Me.lblFHINMEI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(34, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 32)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "品名ｺｰﾄﾞ/記号:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(204, 116)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(476, 32)
        Me.lblFHINMEI.TabIndex = 2
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(33, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 32)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "品名:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(312, 177)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 20)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "梱"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHASUU_VOL
        '
        Me.txtHASUU_VOL.BackColorMask = System.Drawing.Color.Empty
        Me.txtHASUU_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtHASUU_VOL.Format = ""
        Me.txtHASUU_VOL.Location = New System.Drawing.Point(204, 174)
        Me.txtHASUU_VOL.MaxLength = 7
        Me.txtHASUU_VOL.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtHASUU_VOL.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtHASUU_VOL.Name = "txtHASUU_VOL"
        Me.txtHASUU_VOL.Nullable = True
        Me.txtHASUU_VOL.Size = New System.Drawing.Size(102, 27)
        Me.txtHASUU_VOL.TabIndex = 3
        Me.txtHASUU_VOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHASUU_VOL.Value = Nothing
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(30, 171)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(169, 32)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "端量梱数:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFULL_PL
        '
        Me.txtFULL_PL.BackColorMask = System.Drawing.Color.Empty
        Me.txtFULL_PL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFULL_PL.Format = ""
        Me.txtFULL_PL.Location = New System.Drawing.Point(542, 174)
        Me.txtFULL_PL.MaxLength = 7
        Me.txtFULL_PL.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtFULL_PL.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtFULL_PL.Name = "txtFULL_PL"
        Me.txtFULL_PL.Nullable = True
        Me.txtFULL_PL.Size = New System.Drawing.Size(102, 27)
        Me.txtFULL_PL.TabIndex = 4
        Me.txtFULL_PL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFULL_PL.Value = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(348, 177)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 20)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "＋"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(384, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 20)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "フルパレット："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPL_VOL
        '
        Me.lblPL_VOL.AutoSize = True
        Me.lblPL_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblPL_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblPL_VOL.Location = New System.Drawing.Point(650, 177)
        Me.lblPL_VOL.Name = "lblPL_VOL"
        Me.lblPL_VOL.Size = New System.Drawing.Size(31, 20)
        Me.lblPL_VOL.TabIndex = 50
        Me.lblPL_VOL.Text = "PL"
        Me.lblPL_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_303011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(708, 296)
        Me.Controls.Add(Me.lblPL_VOL)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFULL_PL)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtHASUU_VOL)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFHINMEI_CD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdNyuukoSet)
        Me.Controls.Add(Me.lblST_VALUE)
        Me.Controls.Add(Me.lblST_NAME)
        Me.Name = "FRM_303011"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "入庫設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblST_VALUE As System.Windows.Forms.Label
    Friend WithEvents lblST_NAME As System.Windows.Forms.Label
    Friend WithEvents cmdNyuukoSet As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblFHINMEI_CD As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtHASUU_VOL As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFULL_PL As MateCommon.cmpMTextBoxNumber
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblPL_VOL As System.Windows.Forms.Label

End Class
