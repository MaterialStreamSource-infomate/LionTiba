<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_304080
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboXARTICLE_TYPE_CODE = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblAll_SUM_VOL = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblKENPIN_SUM_VOL = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblHIRAOKI_SUM_VOL = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblSOUKO_SUM_VOL = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblSOUKOPL_SUM_VOL = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 671)
        Me.cmdF4.TabIndex = 3
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1127, 107)
        Me.cmdF1.TabIndex = 1
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(169, 163)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1070, 401)
        Me.grdList.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboXARTICLE_TYPE_CODE)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(169, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(952, 62)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'cboXARTICLE_TYPE_CODE
        '
        Me.cboXARTICLE_TYPE_CODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXARTICLE_TYPE_CODE.DropDownWidth = 150
        Me.cboXARTICLE_TYPE_CODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboXARTICLE_TYPE_CODE.FormattingEnabled = True
        Me.cboXARTICLE_TYPE_CODE.IntegralHeight = False
        Me.cboXARTICLE_TYPE_CODE.Location = New System.Drawing.Point(136, 20)
        Me.cboXARTICLE_TYPE_CODE.Name = "cboXARTICLE_TYPE_CODE"
        Me.cboXARTICLE_TYPE_CODE.Size = New System.Drawing.Size(150, 27)
        Me.cboXARTICLE_TYPE_CODE.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(26, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 32)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "商品区分:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAll_SUM_VOL
        '
        Me.lblAll_SUM_VOL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAll_SUM_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblAll_SUM_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblAll_SUM_VOL.Location = New System.Drawing.Point(1058, 628)
        Me.lblAll_SUM_VOL.Name = "lblAll_SUM_VOL"
        Me.lblAll_SUM_VOL.Size = New System.Drawing.Size(93, 32)
        Me.lblAll_SUM_VOL.TabIndex = 230
        Me.lblAll_SUM_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1080, 579)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 49)
        Me.Label2.TabIndex = 229
        Me.Label2.Text = "合計" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "梱数"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKENPIN_SUM_VOL
        '
        Me.lblKENPIN_SUM_VOL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKENPIN_SUM_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblKENPIN_SUM_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblKENPIN_SUM_VOL.Location = New System.Drawing.Point(957, 628)
        Me.lblKENPIN_SUM_VOL.Name = "lblKENPIN_SUM_VOL"
        Me.lblKENPIN_SUM_VOL.Size = New System.Drawing.Size(93, 32)
        Me.lblKENPIN_SUM_VOL.TabIndex = 232
        Me.lblKENPIN_SUM_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(957, 579)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 49)
        Me.Label3.TabIndex = 231
        Me.Label3.Text = "検品エリア" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "梱数"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHIRAOKI_SUM_VOL
        '
        Me.lblHIRAOKI_SUM_VOL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHIRAOKI_SUM_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblHIRAOKI_SUM_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblHIRAOKI_SUM_VOL.Location = New System.Drawing.Point(851, 628)
        Me.lblHIRAOKI_SUM_VOL.Name = "lblHIRAOKI_SUM_VOL"
        Me.lblHIRAOKI_SUM_VOL.Size = New System.Drawing.Size(93, 32)
        Me.lblHIRAOKI_SUM_VOL.TabIndex = 234
        Me.lblHIRAOKI_SUM_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(851, 579)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 49)
        Me.Label7.TabIndex = 233
        Me.Label7.Text = "平置き" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "梱数"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSOUKO_SUM_VOL
        '
        Me.lblSOUKO_SUM_VOL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSOUKO_SUM_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSOUKO_SUM_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblSOUKO_SUM_VOL.Location = New System.Drawing.Point(750, 628)
        Me.lblSOUKO_SUM_VOL.Name = "lblSOUKO_SUM_VOL"
        Me.lblSOUKO_SUM_VOL.Size = New System.Drawing.Size(93, 32)
        Me.lblSOUKO_SUM_VOL.TabIndex = 236
        Me.lblSOUKO_SUM_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(750, 579)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 49)
        Me.Label5.TabIndex = 235
        Me.Label5.Text = "自動倉庫" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "梱数"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSOUKOPL_SUM_VOL
        '
        Me.lblSOUKOPL_SUM_VOL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSOUKOPL_SUM_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblSOUKOPL_SUM_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblSOUKOPL_SUM_VOL.Location = New System.Drawing.Point(649, 628)
        Me.lblSOUKOPL_SUM_VOL.Name = "lblSOUKOPL_SUM_VOL"
        Me.lblSOUKOPL_SUM_VOL.Size = New System.Drawing.Size(93, 32)
        Me.lblSOUKOPL_SUM_VOL.TabIndex = 238
        Me.lblSOUKOPL_SUM_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(649, 579)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 49)
        Me.Label8.TabIndex = 237
        Me.Label8.Text = "自動倉庫" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PL数"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(587, 621)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 49)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "合計"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FRM_304080
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSOUKOPL_SUM_VOL)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblSOUKO_SUM_VOL)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblHIRAOKI_SUM_VOL)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblKENPIN_SUM_VOL)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblAll_SUM_VOL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FRM_304080"
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblAll_SUM_VOL, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lblKENPIN_SUM_VOL, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.lblHIRAOKI_SUM_VOL, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblSOUKO_SUM_VOL, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lblSOUKOPL_SUM_VOL, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAll_SUM_VOL As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblKENPIN_SUM_VOL As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblHIRAOKI_SUM_VOL As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSOUKO_SUM_VOL As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSOUKOPL_SUM_VOL As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboXARTICLE_TYPE_CODE As MateCommon.cmpMComboBox

End Class
