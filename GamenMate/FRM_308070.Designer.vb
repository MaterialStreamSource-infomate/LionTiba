<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308070
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboXSYUKKA_NO = New MateCommon.cmpMComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboXSYUKKA_DT = New MateCommon.cmpMComboBox
        Me.cboXGYOSHA_CD = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboXNYUKA_JIGYOU_CD = New MateCommon.cmpMComboBox
        Me.lblXNYUKA_JIGYOU_NM = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1150, 664)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(1152, 608)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(278, 664)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(168, 664)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1144, 240)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboXSYUKKA_NO)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboXSYUKKA_DT)
        Me.GroupBox1.Controls.Add(Me.cboXGYOSHA_CD)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboXNYUKA_JIGYOU_CD)
        Me.GroupBox1.Controls.Add(Me.lblXNYUKA_JIGYOU_NM)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1080, 140)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'cboXSYUKKA_NO
        '
        Me.cboXSYUKKA_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYUKKA_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYUKKA_NO.FormattingEnabled = True
        Me.cboXSYUKKA_NO.IntegralHeight = False
        Me.cboXSYUKKA_NO.Location = New System.Drawing.Point(168, 18)
        Me.cboXSYUKKA_NO.Name = "cboXSYUKKA_NO"
        Me.cboXSYUKKA_NO.Size = New System.Drawing.Size(192, 28)
        Me.cboXSYUKKA_NO.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(56, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "出荷№:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(416, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "出荷日:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXSYUKKA_DT
        '
        Me.cboXSYUKKA_DT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXSYUKKA_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXSYUKKA_DT.FormattingEnabled = True
        Me.cboXSYUKKA_DT.IntegralHeight = False
        Me.cboXSYUKKA_DT.Location = New System.Drawing.Point(519, 22)
        Me.cboXSYUKKA_DT.Name = "cboXSYUKKA_DT"
        Me.cboXSYUKKA_DT.Size = New System.Drawing.Size(192, 28)
        Me.cboXSYUKKA_DT.TabIndex = 3
        '
        'cboXGYOSHA_CD
        '
        Me.cboXGYOSHA_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXGYOSHA_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXGYOSHA_CD.FormattingEnabled = True
        Me.cboXGYOSHA_CD.IntegralHeight = False
        Me.cboXGYOSHA_CD.Location = New System.Drawing.Point(167, 92)
        Me.cboXGYOSHA_CD.Name = "cboXGYOSHA_CD"
        Me.cboXGYOSHA_CD.Size = New System.Drawing.Size(192, 28)
        Me.cboXGYOSHA_CD.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(49, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 32)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "業者ｺｰﾄﾞ:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(38, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 32)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "出荷先:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXNYUKA_JIGYOU_CD
        '
        Me.cboXNYUKA_JIGYOU_CD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXNYUKA_JIGYOU_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXNYUKA_JIGYOU_CD.FormattingEnabled = True
        Me.cboXNYUKA_JIGYOU_CD.IntegralHeight = False
        Me.cboXNYUKA_JIGYOU_CD.Location = New System.Drawing.Point(167, 54)
        Me.cboXNYUKA_JIGYOU_CD.Name = "cboXNYUKA_JIGYOU_CD"
        Me.cboXNYUKA_JIGYOU_CD.Size = New System.Drawing.Size(193, 28)
        Me.cboXNYUKA_JIGYOU_CD.TabIndex = 5
        '
        'lblXNYUKA_JIGYOU_NM
        '
        Me.lblXNYUKA_JIGYOU_NM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXNYUKA_JIGYOU_NM.ForeColor = System.Drawing.Color.Black
        Me.lblXNYUKA_JIGYOU_NM.Location = New System.Drawing.Point(363, 54)
        Me.lblXNYUKA_JIGYOU_NM.Name = "lblXNYUKA_JIGYOU_NM"
        Me.lblXNYUKA_JIGYOU_NM.Size = New System.Drawing.Size(302, 32)
        Me.lblXNYUKA_JIGYOU_NM.TabIndex = 6
        Me.lblXNYUKA_JIGYOU_NM.Text = "得意先１"
        Me.lblXNYUKA_JIGYOU_NM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 296)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 350)
        Me.grdList.TabIndex = 1
        '
        'FRM_308070
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_308070"
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboXSYUKKA_NO As MateCommon.cmpMComboBox
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents cboXSYUKKA_DT As MateCommon.cmpMComboBox
    Friend WithEvents lblXNYUKA_JIGYOU_NM As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboXNYUKA_JIGYOU_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboXGYOSHA_CD As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
