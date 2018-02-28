<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_311031
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
        Me.components = New System.ComponentModel.Container
        Me.lblNo = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblYouki_UseCnt = New System.Windows.Forms.Label
        Me.cboXTUMI_HOUHOU = New MateCommon.cmpMComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboXBERTH_NO = New MateCommon.cmpMComboBox
        Me.cboXTUMI_HOUKOU = New MateCommon.cmpMComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboXKINKYU_KBN = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblXHENSEI_NO = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblXGYOUSYA_CD = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblXSEND_NAME = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblXSEND_ADDRESS = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblXBUNRUI_NO = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblXDENPYOU_NO = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.txtXSYARYOU_NO = New MateCommon.cmpMTextBoxNumber
        Me.chkALLSYUKKO = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblXSYUKKA_D = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNo
        '
        Me.lblNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.Location = New System.Drawing.Point(12, 9)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(152, 32)
        Me.lblNo.TabIndex = 0
        Me.lblNo.Text = "出荷日付:"
        Me.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(12, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 32)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "車輌№:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblYouki_UseCnt
        '
        Me.lblYouki_UseCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblYouki_UseCnt.ForeColor = System.Drawing.Color.Black
        Me.lblYouki_UseCnt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblYouki_UseCnt.Location = New System.Drawing.Point(12, 100)
        Me.lblYouki_UseCnt.Name = "lblYouki_UseCnt"
        Me.lblYouki_UseCnt.Size = New System.Drawing.Size(152, 32)
        Me.lblYouki_UseCnt.TabIndex = 4
        Me.lblYouki_UseCnt.Text = "積込方法:"
        Me.lblYouki_UseCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXTUMI_HOUHOU
        '
        Me.cboXTUMI_HOUHOU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXTUMI_HOUHOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXTUMI_HOUHOU.FormattingEnabled = True
        Me.cboXTUMI_HOUHOU.IntegralHeight = False
        Me.cboXTUMI_HOUHOU.Location = New System.Drawing.Point(164, 102)
        Me.cboXTUMI_HOUHOU.Name = "cboXTUMI_HOUHOU"
        Me.cboXTUMI_HOUHOU.Size = New System.Drawing.Size(192, 28)
        Me.cboXTUMI_HOUHOU.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "積込方向:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(12, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ﾊﾞｰｽNo.:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXBERTH_NO
        '
        Me.cboXBERTH_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXBERTH_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXBERTH_NO.FormattingEnabled = True
        Me.cboXBERTH_NO.IntegralHeight = False
        Me.cboXBERTH_NO.Location = New System.Drawing.Point(164, 176)
        Me.cboXBERTH_NO.Name = "cboXBERTH_NO"
        Me.cboXBERTH_NO.Size = New System.Drawing.Size(192, 28)
        Me.cboXBERTH_NO.TabIndex = 9
        '
        'cboXTUMI_HOUKOU
        '
        Me.cboXTUMI_HOUKOU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXTUMI_HOUKOU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXTUMI_HOUKOU.FormattingEnabled = True
        Me.cboXTUMI_HOUKOU.IntegralHeight = False
        Me.cboXTUMI_HOUKOU.Location = New System.Drawing.Point(164, 139)
        Me.cboXTUMI_HOUKOU.Name = "cboXTUMI_HOUKOU"
        Me.cboXTUMI_HOUKOU.Size = New System.Drawing.Size(192, 28)
        Me.cboXTUMI_HOUKOU.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(12, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 32)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "緊急出荷:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXKINKYU_KBN
        '
        Me.cboXKINKYU_KBN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXKINKYU_KBN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXKINKYU_KBN.FormattingEnabled = True
        Me.cboXKINKYU_KBN.IntegralHeight = False
        Me.cboXKINKYU_KBN.Location = New System.Drawing.Point(164, 213)
        Me.cboXKINKYU_KBN.Name = "cboXKINKYU_KBN"
        Me.cboXKINKYU_KBN.Size = New System.Drawing.Size(192, 28)
        Me.cboXKINKYU_KBN.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(362, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 32)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "編成№:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXHENSEI_NO
        '
        Me.lblXHENSEI_NO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXHENSEI_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXHENSEI_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXHENSEI_NO.Location = New System.Drawing.Point(514, 63)
        Me.lblXHENSEI_NO.Name = "lblXHENSEI_NO"
        Me.lblXHENSEI_NO.Size = New System.Drawing.Size(149, 32)
        Me.lblXHENSEI_NO.TabIndex = 13
        Me.lblXHENSEI_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(362, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 32)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "業者ｺｰﾄﾞ:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXGYOUSYA_CD
        '
        Me.lblXGYOUSYA_CD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXGYOUSYA_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXGYOUSYA_CD.ForeColor = System.Drawing.Color.Black
        Me.lblXGYOUSYA_CD.Location = New System.Drawing.Point(514, 100)
        Me.lblXGYOUSYA_CD.Name = "lblXGYOUSYA_CD"
        Me.lblXGYOUSYA_CD.Size = New System.Drawing.Size(149, 32)
        Me.lblXGYOUSYA_CD.TabIndex = 17
        Me.lblXGYOUSYA_CD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(362, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 32)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "届け先:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXSEND_NAME
        '
        Me.lblXSEND_NAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSEND_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXSEND_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblXSEND_NAME.Location = New System.Drawing.Point(514, 137)
        Me.lblXSEND_NAME.Name = "lblXSEND_NAME"
        Me.lblXSEND_NAME.Size = New System.Drawing.Size(456, 32)
        Me.lblXSEND_NAME.TabIndex = 21
        Me.lblXSEND_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(362, 174)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 32)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "住所:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXSEND_ADDRESS
        '
        Me.lblXSEND_ADDRESS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSEND_ADDRESS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXSEND_ADDRESS.ForeColor = System.Drawing.Color.Black
        Me.lblXSEND_ADDRESS.Location = New System.Drawing.Point(514, 174)
        Me.lblXSEND_ADDRESS.Name = "lblXSEND_ADDRESS"
        Me.lblXSEND_ADDRESS.Size = New System.Drawing.Size(456, 32)
        Me.lblXSEND_ADDRESS.TabIndex = 23
        Me.lblXSEND_ADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(669, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(152, 32)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "分類№:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXBUNRUI_NO
        '
        Me.lblXBUNRUI_NO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXBUNRUI_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXBUNRUI_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXBUNRUI_NO.Location = New System.Drawing.Point(821, 98)
        Me.lblXBUNRUI_NO.Name = "lblXBUNRUI_NO"
        Me.lblXBUNRUI_NO.Size = New System.Drawing.Size(149, 32)
        Me.lblXBUNRUI_NO.TabIndex = 19
        Me.lblXBUNRUI_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(669, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 32)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "伝票№:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXDENPYOU_NO
        '
        Me.lblXDENPYOU_NO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXDENPYOU_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXDENPYOU_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXDENPYOU_NO.Location = New System.Drawing.Point(821, 61)
        Me.lblXDENPYOU_NO.Name = "lblXDENPYOU_NO"
        Me.lblXDENPYOU_NO.Size = New System.Drawing.Size(149, 32)
        Me.lblXDENPYOU_NO.TabIndex = 15
        Me.lblXDENPYOU_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(16, 257)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(954, 230)
        Me.grdList.TabIndex = 24
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(525, 516)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 26
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(253, 516)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 25
        Me.cmdZikkou.Text = "出荷指示"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'txtXSYARYOU_NO
        '
        Me.txtXSYARYOU_NO.BackColorMask = System.Drawing.Color.Empty
        Me.txtXSYARYOU_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXSYARYOU_NO.Format = "###0"
        Me.txtXSYARYOU_NO.Location = New System.Drawing.Point(164, 66)
        Me.txtXSYARYOU_NO.MaxLength = 4
        Me.txtXSYARYOU_NO.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtXSYARYOU_NO.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtXSYARYOU_NO.Name = "txtXSYARYOU_NO"
        Me.txtXSYARYOU_NO.Nullable = True
        Me.txtXSYARYOU_NO.Size = New System.Drawing.Size(192, 27)
        Me.txtXSYARYOU_NO.TabIndex = 3
        Me.txtXSYARYOU_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtXSYARYOU_NO.Value = Nothing
        '
        'chkALLSYUKKO
        '
        Me.chkALLSYUKKO.AutoSize = True
        Me.chkALLSYUKKO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkALLSYUKKO.ForeColor = System.Drawing.Color.Black
        Me.chkALLSYUKKO.Location = New System.Drawing.Point(514, 219)
        Me.chkALLSYUKKO.Name = "chkALLSYUKKO"
        Me.chkALLSYUKKO.Size = New System.Drawing.Size(15, 14)
        Me.chkALLSYUKKO.TabIndex = 27
        Me.chkALLSYUKKO.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(362, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 32)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "一括出庫:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXSYUKKA_D
        '
        Me.lblXSYUKKA_D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSYUKKA_D.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXSYUKKA_D.ForeColor = System.Drawing.Color.Black
        Me.lblXSYUKKA_D.Location = New System.Drawing.Point(164, 9)
        Me.lblXSYUKKA_D.Name = "lblXSYUKKA_D"
        Me.lblXSYUKKA_D.Size = New System.Drawing.Size(192, 32)
        Me.lblXSYUKKA_D.TabIndex = 1
        Me.lblXSYUKKA_D.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FRM_311031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 575)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkALLSYUKKO)
        Me.Controls.Add(Me.txtXSYARYOU_NO)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblXBUNRUI_NO)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblXDENPYOU_NO)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblXSEND_ADDRESS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblXSEND_NAME)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblXGYOUSYA_CD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblXHENSEI_NO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboXKINKYU_KBN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboXBERTH_NO)
        Me.Controls.Add(Me.cboXTUMI_HOUKOU)
        Me.Controls.Add(Me.lblNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblYouki_UseCnt)
        Me.Controls.Add(Me.cboXTUMI_HOUHOU)
        Me.Controls.Add(Me.lblXSYUKKA_D)
        Me.Name = "FRM_311031"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "出荷指示"
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblYouki_UseCnt As System.Windows.Forms.Label
    Friend WithEvents cboXTUMI_HOUHOU As MateCommon.cmpMComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboXBERTH_NO As MateCommon.cmpMComboBox
    Friend WithEvents cboXTUMI_HOUKOU As MateCommon.cmpMComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboXKINKYU_KBN As MateCommon.cmpMComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblXHENSEI_NO As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblXGYOUSYA_CD As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblXSEND_NAME As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblXSEND_ADDRESS As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblXBUNRUI_NO As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblXDENPYOU_NO As System.Windows.Forms.Label
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents txtXSYARYOU_NO As MateCommon.cmpMTextBoxNumber
    Friend WithEvents chkALLSYUKKO As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblXSYUKKA_D As System.Windows.Forms.Label

End Class
