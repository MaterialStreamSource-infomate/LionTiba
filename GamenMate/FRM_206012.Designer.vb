<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_206012
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdHenkou = New System.Windows.Forms.Button
        Me.cmdSakujo = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(12, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 32)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "品名ｺｰﾄﾞ/記号:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(183, 10)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(165, 28)
        Me.cboFHINMEI_CD.TabIndex = 21
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XKANRI_KUBUN = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(179, 50)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 22
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(479, 96)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(140, 40)
        Me.cmdCancel.TabIndex = 25
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdHenkou
        '
        Me.cmdHenkou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdHenkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdHenkou.ForeColor = System.Drawing.Color.Black
        Me.cmdHenkou.Location = New System.Drawing.Point(16, 96)
        Me.cmdHenkou.Name = "cmdHenkou"
        Me.cmdHenkou.Size = New System.Drawing.Size(140, 40)
        Me.cmdHenkou.TabIndex = 24
        Me.cmdHenkou.Text = "変更"
        Me.cmdHenkou.UseVisualStyleBackColor = False
        '
        'cmdSakujo
        '
        Me.cmdSakujo.BackColor = System.Drawing.Color.DarkGray
        Me.cmdSakujo.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSakujo.ForeColor = System.Drawing.Color.Black
        Me.cmdSakujo.Location = New System.Drawing.Point(183, 96)
        Me.cmdSakujo.Name = "cmdSakujo"
        Me.cmdSakujo.Size = New System.Drawing.Size(140, 40)
        Me.cmdSakujo.TabIndex = 26
        Me.cmdSakujo.Text = "削除"
        Me.cmdSakujo.UseVisualStyleBackColor = False
        '
        'FRM_206012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdSakujo)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdHenkou)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboFHINMEI_CD)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_206012"
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FRM_206012"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdHenkou As System.Windows.Forms.Button
    Friend WithEvents cmdSakujo As System.Windows.Forms.Button
End Class
