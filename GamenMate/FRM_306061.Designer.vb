<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_306061
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
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdZikkou = New System.Windows.Forms.Button
        Me.txtXPROD_LINE_NAME = New MateCommon.cmpMTextBoxString
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.txtXPROD_LINE = New MateCommon.cmpMTextBoxString
        Me.cboFIN_KUBUN = New MateCommon.cmpMComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFHINMEI.Location = New System.Drawing.Point(368, 133)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(346, 32)
        Me.lblFHINMEI.TabIndex = 4
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(2, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 32)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "品名ｺｰﾄﾞ/記号:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(372, 238)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 40)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(100, 238)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 40)
        Me.cmdZikkou.TabIndex = 5
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'txtXPROD_LINE_NAME
        '
        Me.txtXPROD_LINE_NAME.BackColorMask = System.Drawing.Color.Empty
        Me.txtXPROD_LINE_NAME.EnabledFull = True
        Me.txtXPROD_LINE_NAME.EnabledFullAlphabetLower = True
        Me.txtXPROD_LINE_NAME.EnabledFullAlphabetUpper = True
        Me.txtXPROD_LINE_NAME.EnabledFullHiragana = True
        Me.txtXPROD_LINE_NAME.EnabledFullKatakana = True
        Me.txtXPROD_LINE_NAME.EnabledFullNumber = True
        Me.txtXPROD_LINE_NAME.EnabledHalf = True
        Me.txtXPROD_LINE_NAME.EnabledHalfAlphabetLower = True
        Me.txtXPROD_LINE_NAME.EnabledHalfAlphabetUpper = True
        Me.txtXPROD_LINE_NAME.EnabledHalfKatakana = True
        Me.txtXPROD_LINE_NAME.EnabledHalfNumber = True
        Me.txtXPROD_LINE_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXPROD_LINE_NAME.Location = New System.Drawing.Point(170, 91)
        Me.txtXPROD_LINE_NAME.MaxLength = 80
        Me.txtXPROD_LINE_NAME.MaxLengthByte = 80
        Me.txtXPROD_LINE_NAME.Name = "txtXPROD_LINE_NAME"
        Me.txtXPROD_LINE_NAME.RegexCustomFalse = Nothing
        Me.txtXPROD_LINE_NAME.RegexCustomTrue = Nothing
        Me.txtXPROD_LINE_NAME.Size = New System.Drawing.Size(544, 27)
        Me.txtXPROD_LINE_NAME.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 32)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "生産ﾗｲﾝ名称:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 32)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "生産ライン№:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFHINMEI_CD
        '
        Me.cboFHINMEI_CD.ArticleShortNameLabel = Nothing
        Me.cboFHINMEI_CD.ArticleTypeCode = Nothing
        Me.cboFHINMEI_CD.CboDispNameType = GamenCommon.cmpCboFHINMEI_CD.DispNameType.FullName
        Me.cboFHINMEI_CD.Col1Width = 150
        Me.cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedTableData
        Me.cboFHINMEI_CD.conn = Nothing
        Me.cboFHINMEI_CD.FIND_FLAG = False
        Me.cboFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboFHINMEI_CD.FormattingEnabled = True
        Me.cboFHINMEI_CD.FRES_KIND = ""
        Me.cboFHINMEI_CD.FTRK_BUF_NO = Nothing
        Me.cboFHINMEI_CD.HinmeiKind = Nothing
        Me.cboFHINMEI_CD.HinmeiLabel = Nothing
        Me.cboFHINMEI_CD.HinmeiVisible = True
        Me.cboFHINMEI_CD.IntegralHeight = False
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(170, 136)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(192, 28)
        Me.cboFHINMEI_CD.TabIndex = 3
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XKANRI_KUBUN = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'txtXPROD_LINE
        '
        Me.txtXPROD_LINE.BackColorMask = System.Drawing.Color.Empty
        Me.txtXPROD_LINE.EnabledFull = True
        Me.txtXPROD_LINE.EnabledFullAlphabetLower = True
        Me.txtXPROD_LINE.EnabledFullAlphabetUpper = True
        Me.txtXPROD_LINE.EnabledFullHiragana = True
        Me.txtXPROD_LINE.EnabledFullKatakana = True
        Me.txtXPROD_LINE.EnabledFullNumber = True
        Me.txtXPROD_LINE.EnabledHalf = True
        Me.txtXPROD_LINE.EnabledHalfAlphabetLower = True
        Me.txtXPROD_LINE.EnabledHalfAlphabetUpper = True
        Me.txtXPROD_LINE.EnabledHalfKatakana = True
        Me.txtXPROD_LINE.EnabledHalfNumber = True
        Me.txtXPROD_LINE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXPROD_LINE.Location = New System.Drawing.Point(170, 41)
        Me.txtXPROD_LINE.MaxLength = 16
        Me.txtXPROD_LINE.MaxLengthByte = 16
        Me.txtXPROD_LINE.Name = "txtXPROD_LINE"
        Me.txtXPROD_LINE.RegexCustomFalse = Nothing
        Me.txtXPROD_LINE.RegexCustomTrue = Nothing
        Me.txtXPROD_LINE.Size = New System.Drawing.Size(192, 27)
        Me.txtXPROD_LINE.TabIndex = 1
        '
        'cboFIN_KUBUN
        '
        Me.cboFIN_KUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIN_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboFIN_KUBUN.FormattingEnabled = True
        Me.cboFIN_KUBUN.IntegralHeight = False
        Me.cboFIN_KUBUN.Location = New System.Drawing.Point(170, 182)
        Me.cboFIN_KUBUN.Name = "cboFIN_KUBUN"
        Me.cboFIN_KUBUN.Size = New System.Drawing.Size(263, 28)
        Me.cboFIN_KUBUN.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(12, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 32)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "入庫区分:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_306061
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(739, 291)
        Me.Controls.Add(Me.cboFIN_KUBUN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtXPROD_LINE)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.txtXPROD_LINE_NAME)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFHINMEI_CD)
        Me.Name = "FRM_306061"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生産ﾗｲﾝﾏｽﾀ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents txtXPROD_LINE_NAME As MateCommon.cmpMTextBoxString
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents txtXPROD_LINE As MateCommon.cmpMTextBoxString
    Friend WithEvents cboFIN_KUBUN As MateCommon.cmpMComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
