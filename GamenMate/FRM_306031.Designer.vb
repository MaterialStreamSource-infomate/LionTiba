<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_306031
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.txtXGYOUSYA_NAME = New MateCommon.cmpMTextBoxString
        Me.txtXGYOUSYA_CD = New MateCommon.cmpMTextBoxString
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtXGYOUSYA_RYAKU = New MateCommon.cmpMTextBoxString
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtXADDRESS = New MateCommon.cmpMTextBoxString
        Me.txtXTELEPHONE = New MateCommon.cmpMTextBoxString
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtXPOSTAL_CODE = New MateCommon.cmpMTextBoxString
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(375, 284)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(103, 284)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 20
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'txtXGYOUSYA_NAME
        '
        Me.txtXGYOUSYA_NAME.BackColorMask = System.Drawing.Color.Empty
        Me.txtXGYOUSYA_NAME.EnabledFull = True
        Me.txtXGYOUSYA_NAME.EnabledFullAlphabetLower = True
        Me.txtXGYOUSYA_NAME.EnabledFullAlphabetUpper = True
        Me.txtXGYOUSYA_NAME.EnabledFullHiragana = True
        Me.txtXGYOUSYA_NAME.EnabledFullKatakana = True
        Me.txtXGYOUSYA_NAME.EnabledFullNumber = True
        Me.txtXGYOUSYA_NAME.EnabledHalf = True
        Me.txtXGYOUSYA_NAME.EnabledHalfAlphabetLower = True
        Me.txtXGYOUSYA_NAME.EnabledHalfAlphabetUpper = True
        Me.txtXGYOUSYA_NAME.EnabledHalfKatakana = True
        Me.txtXGYOUSYA_NAME.EnabledHalfNumber = True
        Me.txtXGYOUSYA_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXGYOUSYA_NAME.Location = New System.Drawing.Point(174, 62)
        Me.txtXGYOUSYA_NAME.MaxLength = 128
        Me.txtXGYOUSYA_NAME.MaxLengthByte = 128
        Me.txtXGYOUSYA_NAME.Name = "txtXGYOUSYA_NAME"
        Me.txtXGYOUSYA_NAME.RegexCustomFalse = Nothing
        Me.txtXGYOUSYA_NAME.RegexCustomTrue = Nothing
        Me.txtXGYOUSYA_NAME.Size = New System.Drawing.Size(493, 27)
        Me.txtXGYOUSYA_NAME.TabIndex = 2
        '
        'txtXGYOUSYA_CD
        '
        Me.txtXGYOUSYA_CD.BackColorMask = System.Drawing.Color.Empty
        Me.txtXGYOUSYA_CD.EnabledFull = False
        Me.txtXGYOUSYA_CD.EnabledFullAlphabetLower = False
        Me.txtXGYOUSYA_CD.EnabledFullAlphabetUpper = False
        Me.txtXGYOUSYA_CD.EnabledFullHiragana = False
        Me.txtXGYOUSYA_CD.EnabledFullKatakana = False
        Me.txtXGYOUSYA_CD.EnabledFullNumber = False
        Me.txtXGYOUSYA_CD.EnabledHalf = True
        Me.txtXGYOUSYA_CD.EnabledHalfAlphabetLower = True
        Me.txtXGYOUSYA_CD.EnabledHalfAlphabetUpper = True
        Me.txtXGYOUSYA_CD.EnabledHalfKatakana = True
        Me.txtXGYOUSYA_CD.EnabledHalfNumber = True
        Me.txtXGYOUSYA_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXGYOUSYA_CD.Location = New System.Drawing.Point(174, 22)
        Me.txtXGYOUSYA_CD.MaxLength = 4
        Me.txtXGYOUSYA_CD.MaxLengthByte = 4
        Me.txtXGYOUSYA_CD.Name = "txtXGYOUSYA_CD"
        Me.txtXGYOUSYA_CD.RegexCustomFalse = Nothing
        Me.txtXGYOUSYA_CD.RegexCustomTrue = Nothing
        Me.txtXGYOUSYA_CD.Size = New System.Drawing.Size(94, 27)
        Me.txtXGYOUSYA_CD.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "業者名称:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(22, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "業者コード:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXGYOUSYA_RYAKU
        '
        Me.txtXGYOUSYA_RYAKU.BackColorMask = System.Drawing.Color.Empty
        Me.txtXGYOUSYA_RYAKU.EnabledFull = True
        Me.txtXGYOUSYA_RYAKU.EnabledFullAlphabetLower = True
        Me.txtXGYOUSYA_RYAKU.EnabledFullAlphabetUpper = True
        Me.txtXGYOUSYA_RYAKU.EnabledFullHiragana = True
        Me.txtXGYOUSYA_RYAKU.EnabledFullKatakana = True
        Me.txtXGYOUSYA_RYAKU.EnabledFullNumber = True
        Me.txtXGYOUSYA_RYAKU.EnabledHalf = True
        Me.txtXGYOUSYA_RYAKU.EnabledHalfAlphabetLower = True
        Me.txtXGYOUSYA_RYAKU.EnabledHalfAlphabetUpper = True
        Me.txtXGYOUSYA_RYAKU.EnabledHalfKatakana = True
        Me.txtXGYOUSYA_RYAKU.EnabledHalfNumber = True
        Me.txtXGYOUSYA_RYAKU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXGYOUSYA_RYAKU.Location = New System.Drawing.Point(174, 103)
        Me.txtXGYOUSYA_RYAKU.MaxLength = 128
        Me.txtXGYOUSYA_RYAKU.MaxLengthByte = 128
        Me.txtXGYOUSYA_RYAKU.Name = "txtXGYOUSYA_RYAKU"
        Me.txtXGYOUSYA_RYAKU.RegexCustomFalse = Nothing
        Me.txtXGYOUSYA_RYAKU.RegexCustomTrue = Nothing
        Me.txtXGYOUSYA_RYAKU.Size = New System.Drawing.Size(493, 27)
        Me.txtXGYOUSYA_RYAKU.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(22, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 32)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "略称:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(22, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 32)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "住所:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXADDRESS
        '
        Me.txtXADDRESS.BackColorMask = System.Drawing.Color.Empty
        Me.txtXADDRESS.EnabledFull = True
        Me.txtXADDRESS.EnabledFullAlphabetLower = True
        Me.txtXADDRESS.EnabledFullAlphabetUpper = True
        Me.txtXADDRESS.EnabledFullHiragana = True
        Me.txtXADDRESS.EnabledFullKatakana = True
        Me.txtXADDRESS.EnabledFullNumber = True
        Me.txtXADDRESS.EnabledHalf = True
        Me.txtXADDRESS.EnabledHalfAlphabetLower = True
        Me.txtXADDRESS.EnabledHalfAlphabetUpper = True
        Me.txtXADDRESS.EnabledHalfKatakana = True
        Me.txtXADDRESS.EnabledHalfNumber = True
        Me.txtXADDRESS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXADDRESS.Location = New System.Drawing.Point(174, 145)
        Me.txtXADDRESS.MaxLength = 72
        Me.txtXADDRESS.MaxLengthByte = 72
        Me.txtXADDRESS.Name = "txtXADDRESS"
        Me.txtXADDRESS.RegexCustomFalse = Nothing
        Me.txtXADDRESS.RegexCustomTrue = Nothing
        Me.txtXADDRESS.Size = New System.Drawing.Size(493, 27)
        Me.txtXADDRESS.TabIndex = 4
        '
        'txtXTELEPHONE
        '
        Me.txtXTELEPHONE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXTELEPHONE.EnabledFull = False
        Me.txtXTELEPHONE.EnabledFullAlphabetLower = False
        Me.txtXTELEPHONE.EnabledFullAlphabetUpper = False
        Me.txtXTELEPHONE.EnabledFullHiragana = True
        Me.txtXTELEPHONE.EnabledFullKatakana = False
        Me.txtXTELEPHONE.EnabledFullNumber = False
        Me.txtXTELEPHONE.EnabledHalf = True
        Me.txtXTELEPHONE.EnabledHalfAlphabetLower = False
        Me.txtXTELEPHONE.EnabledHalfAlphabetUpper = False
        Me.txtXTELEPHONE.EnabledHalfKatakana = False
        Me.txtXTELEPHONE.EnabledHalfNumber = True
        Me.txtXTELEPHONE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXTELEPHONE.Location = New System.Drawing.Point(174, 188)
        Me.txtXTELEPHONE.MaxLength = 15
        Me.txtXTELEPHONE.MaxLengthByte = 15
        Me.txtXTELEPHONE.Name = "txtXTELEPHONE"
        Me.txtXTELEPHONE.RegexCustomFalse = Nothing
        Me.txtXTELEPHONE.RegexCustomTrue = Nothing
        Me.txtXTELEPHONE.Size = New System.Drawing.Size(243, 27)
        Me.txtXTELEPHONE.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(22, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 32)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "電話番号:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXPOSTAL_CODE
        '
        Me.txtXPOSTAL_CODE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXPOSTAL_CODE.EnabledFull = False
        Me.txtXPOSTAL_CODE.EnabledFullAlphabetLower = False
        Me.txtXPOSTAL_CODE.EnabledFullAlphabetUpper = False
        Me.txtXPOSTAL_CODE.EnabledFullHiragana = True
        Me.txtXPOSTAL_CODE.EnabledFullKatakana = False
        Me.txtXPOSTAL_CODE.EnabledFullNumber = False
        Me.txtXPOSTAL_CODE.EnabledHalf = True
        Me.txtXPOSTAL_CODE.EnabledHalfAlphabetLower = False
        Me.txtXPOSTAL_CODE.EnabledHalfAlphabetUpper = False
        Me.txtXPOSTAL_CODE.EnabledHalfKatakana = False
        Me.txtXPOSTAL_CODE.EnabledHalfNumber = True
        Me.txtXPOSTAL_CODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXPOSTAL_CODE.Location = New System.Drawing.Point(174, 231)
        Me.txtXPOSTAL_CODE.MaxLength = 15
        Me.txtXPOSTAL_CODE.MaxLengthByte = 15
        Me.txtXPOSTAL_CODE.Name = "txtXPOSTAL_CODE"
        Me.txtXPOSTAL_CODE.RegexCustomFalse = Nothing
        Me.txtXPOSTAL_CODE.RegexCustomTrue = Nothing
        Me.txtXPOSTAL_CODE.Size = New System.Drawing.Size(243, 27)
        Me.txtXPOSTAL_CODE.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(22, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 32)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "郵便番号:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_306031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(699, 338)
        Me.Controls.Add(Me.txtXPOSTAL_CODE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtXTELEPHONE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtXADDRESS)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtXGYOUSYA_RYAKU)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.txtXGYOUSYA_NAME)
        Me.Controls.Add(Me.txtXGYOUSYA_CD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FRM_306031"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "物流業者ﾏｽﾀ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents txtXGYOUSYA_NAME As MateCommon.cmpMTextBoxString
    Friend WithEvents txtXGYOUSYA_CD As MateCommon.cmpMTextBoxString
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtXGYOUSYA_RYAKU As MateCommon.cmpMTextBoxString
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtXADDRESS As MateCommon.cmpMTextBoxString
    Friend WithEvents txtXTELEPHONE As MateCommon.cmpMTextBoxString
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtXPOSTAL_CODE As MateCommon.cmpMTextBoxString
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
