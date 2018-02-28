<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_206021
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.txtFUSER_ID = New MateCommon.cmpMTextBoxString
        Me.txtFUSER_NAME = New MateCommon.cmpMTextBoxString
        Me.cboFREASON = New MateCommon.cmpMComboBox
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 228
        Me.Label1.Text = "担当者名:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(8, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 32)
        Me.Label12.TabIndex = 227
        Me.Label12.Text = "担当者コード:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(8, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 32)
        Me.Label9.TabIndex = 257
        Me.Label9.Text = "理由:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(472, 176)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(184, 176)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 4
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(520, 8)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(320, 145)
        Me.grdList.TabIndex = 3
        '
        'txtFUSER_ID
        '
        Me.txtFUSER_ID.BackColorMask = System.Drawing.Color.Empty
        Me.txtFUSER_ID.EnabledFull = False
        Me.txtFUSER_ID.EnabledFullAlphabetLower = False
        Me.txtFUSER_ID.EnabledFullAlphabetUpper = False
        Me.txtFUSER_ID.EnabledFullHiragana = False
        Me.txtFUSER_ID.EnabledFullKatakana = False
        Me.txtFUSER_ID.EnabledFullNumber = False
        Me.txtFUSER_ID.EnabledHalf = True
        Me.txtFUSER_ID.EnabledHalfAlphabetLower = False
        Me.txtFUSER_ID.EnabledHalfAlphabetUpper = False
        Me.txtFUSER_ID.EnabledHalfKatakana = False
        Me.txtFUSER_ID.EnabledHalfNumber = True
        Me.txtFUSER_ID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFUSER_ID.Location = New System.Drawing.Point(160, 11)
        Me.txtFUSER_ID.MaxLength = 8
        Me.txtFUSER_ID.MaxLengthByte = 8
        Me.txtFUSER_ID.Name = "txtFUSER_ID"
        Me.txtFUSER_ID.RegexCustomFalse = Nothing
        Me.txtFUSER_ID.RegexCustomTrue = Nothing
        Me.txtFUSER_ID.Size = New System.Drawing.Size(152, 27)
        Me.txtFUSER_ID.TabIndex = 0
        '
        'txtFUSER_NAME
        '
        Me.txtFUSER_NAME.BackColorMask = System.Drawing.Color.Empty
        Me.txtFUSER_NAME.EnabledFull = True
        Me.txtFUSER_NAME.EnabledFullAlphabetLower = True
        Me.txtFUSER_NAME.EnabledFullAlphabetUpper = True
        Me.txtFUSER_NAME.EnabledFullHiragana = True
        Me.txtFUSER_NAME.EnabledFullKatakana = True
        Me.txtFUSER_NAME.EnabledFullNumber = True
        Me.txtFUSER_NAME.EnabledHalf = True
        Me.txtFUSER_NAME.EnabledHalfAlphabetLower = True
        Me.txtFUSER_NAME.EnabledHalfAlphabetUpper = True
        Me.txtFUSER_NAME.EnabledHalfKatakana = True
        Me.txtFUSER_NAME.EnabledHalfNumber = True
        Me.txtFUSER_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtFUSER_NAME.Location = New System.Drawing.Point(160, 51)
        Me.txtFUSER_NAME.MaxLength = 20
        Me.txtFUSER_NAME.MaxLengthByte = 20
        Me.txtFUSER_NAME.Name = "txtFUSER_NAME"
        Me.txtFUSER_NAME.RegexCustomFalse = Nothing
        Me.txtFUSER_NAME.RegexCustomTrue = Nothing
        Me.txtFUSER_NAME.Size = New System.Drawing.Size(272, 27)
        Me.txtFUSER_NAME.TabIndex = 1
        '
        'cboFREASON
        '
        Me.cboFREASON.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFREASON.FormattingEnabled = True
        Me.cboFREASON.IntegralHeight = False
        Me.cboFREASON.Location = New System.Drawing.Point(160, 90)
        Me.cboFREASON.Name = "cboFREASON"
        Me.cboFREASON.Size = New System.Drawing.Size(344, 28)
        Me.cboFREASON.TabIndex = 2
        '
        'FRM_206021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(868, 231)
        Me.Controls.Add(Me.cboFREASON)
        Me.Controls.Add(Me.txtFUSER_NAME)
        Me.Controls.Add(Me.txtFUSER_ID)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Name = "FRM_206021"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "担当者マスタメンテナンス"
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents txtFUSER_ID As MateCommon.cmpMTextBoxString
    Friend WithEvents txtFUSER_NAME As MateCommon.cmpMTextBoxString
    Friend WithEvents cboFREASON As MateCommon.cmpMComboBox

End Class
