<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_306091
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
        Me.txtXDPL_PL_PTN_COMMENT = New MateCommon.cmpMTextBoxString
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboXDPL_PL_NO = New MateCommon.cmpMComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtXDPL_PL_PTN = New MateCommon.cmpMTextBoxString
        Me.SuspendLayout()
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFHINMEI.Location = New System.Drawing.Point(231, 124)
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
        Me.Label1.Location = New System.Drawing.Point(10, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 40)
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
        Me.cmdCancel.Location = New System.Drawing.Point(346, 274)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(216, 48)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdZikkou
        '
        Me.cmdZikkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdZikkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdZikkou.ForeColor = System.Drawing.Color.Black
        Me.cmdZikkou.Location = New System.Drawing.Point(74, 274)
        Me.cmdZikkou.Name = "cmdZikkou"
        Me.cmdZikkou.Size = New System.Drawing.Size(216, 48)
        Me.cmdZikkou.TabIndex = 5
        Me.cmdZikkou.Text = "ＸＸ"
        Me.cmdZikkou.UseVisualStyleBackColor = False
        '
        'txtXDPL_PL_PTN_COMMENT
        '
        Me.txtXDPL_PL_PTN_COMMENT.BackColorMask = System.Drawing.Color.Empty
        Me.txtXDPL_PL_PTN_COMMENT.EnabledFull = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledFullAlphabetLower = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledFullAlphabetUpper = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledFullHiragana = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledFullKatakana = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledFullNumber = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledHalf = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledHalfAlphabetLower = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledHalfAlphabetUpper = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledHalfKatakana = True
        Me.txtXDPL_PL_PTN_COMMENT.EnabledHalfNumber = True
        Me.txtXDPL_PL_PTN_COMMENT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXDPL_PL_PTN_COMMENT.Location = New System.Drawing.Point(235, 217)
        Me.txtXDPL_PL_PTN_COMMENT.MaxLength = 80
        Me.txtXDPL_PL_PTN_COMMENT.MaxLengthByte = 80
        Me.txtXDPL_PL_PTN_COMMENT.Name = "txtXDPL_PL_PTN_COMMENT"
        Me.txtXDPL_PL_PTN_COMMENT.RegexCustomFalse = Nothing
        Me.txtXDPL_PL_PTN_COMMENT.RegexCustomTrue = Nothing
        Me.txtXDPL_PL_PTN_COMMENT.Size = New System.Drawing.Size(373, 27)
        Me.txtXDPL_PL_PTN_COMMENT.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 40)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "ﾊﾟﾀｰﾝｺﾒﾝﾄ:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 32)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "設備名称:"
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(235, 87)
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
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(5, 164)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(224, 40)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXDPL_PL_NO
        '
        Me.cboXDPL_PL_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXDPL_PL_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXDPL_PL_NO.FormattingEnabled = True
        Me.cboXDPL_PL_NO.IntegralHeight = False
        Me.cboXDPL_PL_NO.Location = New System.Drawing.Point(235, 41)
        Me.cboXDPL_PL_NO.Name = "cboXDPL_PL_NO"
        Me.cboXDPL_PL_NO.Size = New System.Drawing.Size(192, 28)
        Me.cboXDPL_PL_NO.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(10, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(219, 40)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "品名:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXDPL_PL_PTN
        '
        Me.txtXDPL_PL_PTN.BackColorMask = System.Drawing.Color.Empty
        Me.txtXDPL_PL_PTN.EnabledFull = True
        Me.txtXDPL_PL_PTN.EnabledFullAlphabetLower = True
        Me.txtXDPL_PL_PTN.EnabledFullAlphabetUpper = True
        Me.txtXDPL_PL_PTN.EnabledFullHiragana = True
        Me.txtXDPL_PL_PTN.EnabledFullKatakana = True
        Me.txtXDPL_PL_PTN.EnabledFullNumber = True
        Me.txtXDPL_PL_PTN.EnabledHalf = True
        Me.txtXDPL_PL_PTN.EnabledHalfAlphabetLower = True
        Me.txtXDPL_PL_PTN.EnabledHalfAlphabetUpper = True
        Me.txtXDPL_PL_PTN.EnabledHalfKatakana = True
        Me.txtXDPL_PL_PTN.EnabledHalfNumber = True
        Me.txtXDPL_PL_PTN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtXDPL_PL_PTN.Location = New System.Drawing.Point(235, 171)
        Me.txtXDPL_PL_PTN.MaxLength = 80
        Me.txtXDPL_PL_PTN.MaxLengthByte = 80
        Me.txtXDPL_PL_PTN.Name = "txtXDPL_PL_PTN"
        Me.txtXDPL_PL_PTN.RegexCustomFalse = Nothing
        Me.txtXDPL_PL_PTN.RegexCustomTrue = Nothing
        Me.txtXDPL_PL_PTN.Size = New System.Drawing.Size(55, 27)
        Me.txtXDPL_PL_PTN.TabIndex = 81
        '
        'FRM_306091
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(620, 339)
        Me.Controls.Add(Me.txtXDPL_PL_PTN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboXDPL_PL_NO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdZikkou)
        Me.Controls.Add(Me.txtXDPL_PL_PTN_COMMENT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFHINMEI_CD)
        Me.Name = "FRM_306091"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdZikkou As System.Windows.Forms.Button
    Friend WithEvents txtXDPL_PL_PTN_COMMENT As MateCommon.cmpMTextBoxString
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboXDPL_PL_NO As MateCommon.cmpMComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtXDPL_PL_PTN As MateCommon.cmpMTextBoxString

End Class
