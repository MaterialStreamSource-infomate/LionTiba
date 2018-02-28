<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_310020
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboFTRK_BUF_NO_NYUUKO = New MateCommon.cmpMComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cboFULL_PL = New MateCommon.cmpMComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblXKENPIN_KUBUN = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblFIN_KUBUN = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblFHORYU_KUBUN = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblXKENSA_KUBUN = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblXMAKER_CD = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblFARRIVE_DT = New System.Windows.Forms.Label
        Me.lblXHINMEI_CD = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblXPROD_LINE = New System.Windows.Forms.Label
        Me.lblFHINMEI_CD = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtHasuu_VOL = New MateCommon.cmpMTextBoxNumber
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(1139, 671)
        Me.cmdF4.TabIndex = 21
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(168, 671)
        Me.cmdF1.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFTRK_BUF_NO_NYUUKO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(625, 70)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cboFTRK_BUF_NO_NYUUKO
        '
        Me.cboFTRK_BUF_NO_NYUUKO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFTRK_BUF_NO_NYUUKO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFTRK_BUF_NO_NYUUKO.FormattingEnabled = True
        Me.cboFTRK_BUF_NO_NYUUKO.IntegralHeight = False
        Me.cboFTRK_BUF_NO_NYUUKO.Location = New System.Drawing.Point(209, 22)
        Me.cboFTRK_BUF_NO_NYUUKO.Name = "cboFTRK_BUF_NO_NYUUKO"
        Me.cboFTRK_BUF_NO_NYUUKO.Size = New System.Drawing.Size(244, 28)
        Me.cboFTRK_BUF_NO_NYUUKO.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(60, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "入庫ST:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboFULL_PL)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.lblXKENPIN_KUBUN)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.lblFIN_KUBUN)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.lblFHORYU_KUBUN)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.lblXKENSA_KUBUN)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.lblXMAKER_CD)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.lblFARRIVE_DT)
        Me.GroupBox4.Controls.Add(Me.lblXHINMEI_CD)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.lblXPROD_LINE)
        Me.GroupBox4.Controls.Add(Me.lblFHINMEI_CD)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txtHasuu_VOL)
        Me.GroupBox4.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox4.Location = New System.Drawing.Point(169, 180)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1074, 420)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'cboFULL_PL
        '
        Me.cboFULL_PL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFULL_PL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFULL_PL.FormattingEnabled = True
        Me.cboFULL_PL.IntegralHeight = False
        Me.cboFULL_PL.Location = New System.Drawing.Point(718, 357)
        Me.cboFULL_PL.Name = "cboFULL_PL"
        Me.cboFULL_PL.Size = New System.Drawing.Size(96, 28)
        Me.cboFULL_PL.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(543, 354)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(165, 32)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "フルパレット:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(459, 360)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 20)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "＋"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXKENPIN_KUBUN
        '
        Me.lblXKENPIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXKENPIN_KUBUN.ForeColor = System.Drawing.Color.Black
        Me.lblXKENPIN_KUBUN.Location = New System.Drawing.Point(714, 303)
        Me.lblXKENPIN_KUBUN.Name = "lblXKENPIN_KUBUN"
        Me.lblXKENPIN_KUBUN.Size = New System.Drawing.Size(308, 32)
        Me.lblXKENPIN_KUBUN.TabIndex = 52
        Me.lblXKENPIN_KUBUN.Text = "検品区分"
        Me.lblXKENPIN_KUBUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(543, 303)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 32)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "検品区分:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFIN_KUBUN
        '
        Me.lblFIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFIN_KUBUN.ForeColor = System.Drawing.Color.Black
        Me.lblFIN_KUBUN.Location = New System.Drawing.Point(204, 303)
        Me.lblFIN_KUBUN.Name = "lblFIN_KUBUN"
        Me.lblFIN_KUBUN.Size = New System.Drawing.Size(308, 32)
        Me.lblFIN_KUBUN.TabIndex = 50
        Me.lblFIN_KUBUN.Text = "入庫区分"
        Me.lblFIN_KUBUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(33, 303)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(165, 32)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "入庫区分:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHORYU_KUBUN
        '
        Me.lblFHORYU_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHORYU_KUBUN.ForeColor = System.Drawing.Color.Black
        Me.lblFHORYU_KUBUN.Location = New System.Drawing.Point(714, 254)
        Me.lblFHORYU_KUBUN.Name = "lblFHORYU_KUBUN"
        Me.lblFHORYU_KUBUN.Size = New System.Drawing.Size(308, 32)
        Me.lblFHORYU_KUBUN.TabIndex = 48
        Me.lblFHORYU_KUBUN.Text = "保留区分"
        Me.lblFHORYU_KUBUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(543, 254)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(165, 32)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "保留区分:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXKENSA_KUBUN
        '
        Me.lblXKENSA_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXKENSA_KUBUN.ForeColor = System.Drawing.Color.Black
        Me.lblXKENSA_KUBUN.Location = New System.Drawing.Point(204, 254)
        Me.lblXKENSA_KUBUN.Name = "lblXKENSA_KUBUN"
        Me.lblXKENSA_KUBUN.Size = New System.Drawing.Size(308, 32)
        Me.lblXKENSA_KUBUN.TabIndex = 46
        Me.lblXKENSA_KUBUN.Text = "検査区分"
        Me.lblXKENSA_KUBUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(33, 254)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(165, 32)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "検査区分:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXMAKER_CD
        '
        Me.lblXMAKER_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXMAKER_CD.ForeColor = System.Drawing.Color.Black
        Me.lblXMAKER_CD.Location = New System.Drawing.Point(714, 205)
        Me.lblXMAKER_CD.Name = "lblXMAKER_CD"
        Me.lblXMAKER_CD.Size = New System.Drawing.Size(308, 32)
        Me.lblXMAKER_CD.TabIndex = 44
        Me.lblXMAKER_CD.Text = "ﾒｰｶｰｺｰﾄﾞ"
        Me.lblXMAKER_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(535, 205)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 32)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "メーカーコード:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFARRIVE_DT
        '
        Me.lblFARRIVE_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFARRIVE_DT.ForeColor = System.Drawing.Color.Black
        Me.lblFARRIVE_DT.Location = New System.Drawing.Point(204, 159)
        Me.lblFARRIVE_DT.Name = "lblFARRIVE_DT"
        Me.lblFARRIVE_DT.Size = New System.Drawing.Size(440, 32)
        Me.lblFARRIVE_DT.TabIndex = 42
        Me.lblFARRIVE_DT.Text = "2013/05/09 12:00:00"
        Me.lblFARRIVE_DT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXHINMEI_CD
        '
        Me.lblXHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXHINMEI_CD.ForeColor = System.Drawing.Color.Black
        Me.lblXHINMEI_CD.Location = New System.Drawing.Point(204, 71)
        Me.lblXHINMEI_CD.Name = "lblXHINMEI_CD"
        Me.lblXHINMEI_CD.Size = New System.Drawing.Size(440, 32)
        Me.lblXHINMEI_CD.TabIndex = 41
        Me.lblXHINMEI_CD.Text = "品名記号"
        Me.lblXHINMEI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(33, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(165, 32)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "品名記号:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXPROD_LINE
        '
        Me.lblXPROD_LINE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXPROD_LINE.ForeColor = System.Drawing.Color.Black
        Me.lblXPROD_LINE.Location = New System.Drawing.Point(204, 205)
        Me.lblXPROD_LINE.Name = "lblXPROD_LINE"
        Me.lblXPROD_LINE.Size = New System.Drawing.Size(308, 32)
        Me.lblXPROD_LINE.TabIndex = 39
        Me.lblXPROD_LINE.Text = "生産ﾗｲﾝNo."
        Me.lblXPROD_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFHINMEI_CD
        '
        Me.lblFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI_CD.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI_CD.Location = New System.Drawing.Point(204, 27)
        Me.lblFHINMEI_CD.Name = "lblFHINMEI_CD"
        Me.lblFHINMEI_CD.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI_CD.TabIndex = 38
        Me.lblFHINMEI_CD.Text = "品名ｺｰﾄﾞ"
        Me.lblFHINMEI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(33, 354)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 32)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "端量梱数:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(33, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 32)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "在庫発生日時:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(33, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 32)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "生産ﾗｲﾝNo.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(33, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 32)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "品名:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(33, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 32)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "品名ｺｰﾄﾞ:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHasuu_VOL
        '
        Me.txtHasuu_VOL.BackColorMask = System.Drawing.Color.Empty
        Me.txtHasuu_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtHasuu_VOL.Format = ""
        Me.txtHasuu_VOL.Location = New System.Drawing.Point(208, 357)
        Me.txtHasuu_VOL.MaxLength = 7
        Me.txtHasuu_VOL.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtHasuu_VOL.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtHasuu_VOL.Name = "txtHasuu_VOL"
        Me.txtHasuu_VOL.Nullable = True
        Me.txtHasuu_VOL.Size = New System.Drawing.Size(165, 27)
        Me.txtHasuu_VOL.TabIndex = 0
        Me.txtHasuu_VOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHasuu_VOL.Value = Nothing
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(204, 113)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 16
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_310020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_310020"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFTRK_BUF_NO_NYUUKO As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHasuu_VOL As MateCommon.cmpMTextBoxNumber
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI_CD As System.Windows.Forms.Label
    Friend WithEvents lblXPROD_LINE As System.Windows.Forms.Label
    Friend WithEvents lblFARRIVE_DT As System.Windows.Forms.Label
    Friend WithEvents lblXHINMEI_CD As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblXKENPIN_KUBUN As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblFIN_KUBUN As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblFHORYU_KUBUN As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblXKENSA_KUBUN As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblXMAKER_CD As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboFULL_PL As MateCommon.cmpMComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
