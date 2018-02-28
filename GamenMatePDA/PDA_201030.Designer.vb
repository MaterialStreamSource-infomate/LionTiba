<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA_201030
    Inherits GamenMatePDA.PDA_000002

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
        Me.lblMsg = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblXCAR_NO = New System.Windows.Forms.Label
        Me.lblXCAR_NO_EDA = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.txtBarcode = New GamenMatePDA.cmpMTextBoxBC
        Me.grdList2 = New GamenCommon.cmpMDataGrid(Me.components)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMsg.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblMsg.Location = New System.Drawing.Point(0, 40)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(480, 40)
        Me.lblMsg.TabIndex = 276
        Me.lblMsg.Text = "バーコードを読み取って下さい。"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(255, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 32)
        Me.Label3.TabIndex = 288
        Me.Label3.Text = "-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(44, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 32)
        Me.Label1.TabIndex = 287
        Me.Label1.Text = "車輌№:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXCAR_NO
        '
        Me.lblXCAR_NO.BackColor = System.Drawing.Color.Silver
        Me.lblXCAR_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXCAR_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXCAR_NO.Location = New System.Drawing.Point(172, 117)
        Me.lblXCAR_NO.Name = "lblXCAR_NO"
        Me.lblXCAR_NO.Size = New System.Drawing.Size(80, 32)
        Me.lblXCAR_NO.TabIndex = 289
        Me.lblXCAR_NO.Text = "9999"
        Me.lblXCAR_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXCAR_NO_EDA
        '
        Me.lblXCAR_NO_EDA.BackColor = System.Drawing.Color.Silver
        Me.lblXCAR_NO_EDA.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXCAR_NO_EDA.ForeColor = System.Drawing.Color.Black
        Me.lblXCAR_NO_EDA.Location = New System.Drawing.Point(292, 117)
        Me.lblXCAR_NO_EDA.Name = "lblXCAR_NO_EDA"
        Me.lblXCAR_NO_EDA.Size = New System.Drawing.Size(26, 32)
        Me.lblXCAR_NO_EDA.TabIndex = 290
        Me.lblXCAR_NO_EDA.Text = "9"
        Me.lblXCAR_NO_EDA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(25, 160)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(430, 360)
        Me.grdList.TabIndex = 291
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColorMask = System.Drawing.Color.Empty
        Me.txtBarcode.EnabledFull = False
        Me.txtBarcode.EnabledFullAlphabetLower = False
        Me.txtBarcode.EnabledFullAlphabetUpper = False
        Me.txtBarcode.EnabledFullHiragana = False
        Me.txtBarcode.EnabledFullKatakana = False
        Me.txtBarcode.EnabledFullNumber = False
        Me.txtBarcode.EnabledHalf = True
        Me.txtBarcode.EnabledHalfAlphabetLower = True
        Me.txtBarcode.EnabledHalfAlphabetUpper = True
        Me.txtBarcode.EnabledHalfKatakana = True
        Me.txtBarcode.EnabledHalfNumber = True
        Me.txtBarcode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBarcode.Location = New System.Drawing.Point(13, 530)
        Me.txtBarcode.MaxLengthByte = 0
        Me.txtBarcode.MojiCount = 0
        Me.txtBarcode.Multiline = True
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.RegexCustomFalse = Nothing
        Me.txtBarcode.RegexCustomTrue = Nothing
        Me.txtBarcode.Size = New System.Drawing.Size(450, 19)
        Me.txtBarcode.TabIndex = 292
        Me.txtBarcode.TimerBCCheckCount = 1
        '
        'grdList2
        '
        Me.grdList2.blnDBUpdate = False
        Me.grdList2.blnSelectionChanged = False
        Me.grdList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList2.Location = New System.Drawing.Point(8, 376)
        Me.grdList2.MyBeseDoubleBuffered = False
        Me.grdList2.Name = "grdList2"
        Me.grdList2.RowTemplate.Height = 21
        Me.grdList2.Size = New System.Drawing.Size(464, 144)
        Me.grdList2.TabIndex = 293
        Me.grdList2.Visible = False
        '
        'PDA_201030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(478, 638)
        Me.Controls.Add(Me.grdList2)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.lblXCAR_NO_EDA)
        Me.Controls.Add(Me.lblXCAR_NO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMsg)
        Me.Name = "PDA_201030"
        Me.Controls.SetChildIndex(Me.lblMsg, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lblXCAR_NO, 0)
        Me.Controls.SetChildIndex(Me.lblXCAR_NO_EDA, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.txtBarcode, 0)
        Me.Controls.SetChildIndex(Me.grdList2, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblXCAR_NO As System.Windows.Forms.Label
    Friend WithEvents lblXCAR_NO_EDA As System.Windows.Forms.Label
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents txtBarcode As GamenMatePDA.cmpMTextBoxBC
    Friend WithEvents grdList2 As GamenCommon.cmpMDataGrid

End Class
