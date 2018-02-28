<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_302011
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
        Me.cboFHINMEI_CD = New GamenCommon.cmpCboFHINMEI_CD
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboXDPL_PL_PTN = New MateCommon.cmpMComboBox
        Me.cmdUnten = New System.Windows.Forms.Button
        Me.cmdTeisi = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblXDPL_PL_NAME = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdSyuryou = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPTN_COMMENT = New System.Windows.Forms.Label
        Me.cmdHinsyu = New System.Windows.Forms.Button
        Me.SuspendLayout()
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
        Me.cboFHINMEI_CD.Location = New System.Drawing.Point(179, 63)
        Me.cboFHINMEI_CD.MaterTableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.Name = "cboFHINMEI_CD"
        Me.cboFHINMEI_CD.PlaceDetailCode = Nothing
        Me.cboFHINMEI_CD.SeihinKubun = ""
        Me.cboFHINMEI_CD.Size = New System.Drawing.Size(263, 28)
        Me.cboFHINMEI_CD.TabIndex = 1
        Me.cboFHINMEI_CD.TableName = "TMST_ITEM"
        Me.cboFHINMEI_CD.TaniLabel = Nothing
        Me.cboFHINMEI_CD.XKANRI_KUBUN = Nothing
        Me.cboFHINMEI_CD.XLINE_NO = Nothing
        Me.cboFHINMEI_CD.ZaikoKubun = Nothing
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(179, 110)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(440, 32)
        Me.lblFHINMEI.TabIndex = 18
        Me.lblFHINMEI.Text = "品名"
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(8, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 32)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "品名ｺｰﾄﾞ/記号:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 32)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "品名:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 32)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "設備名称:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXDPL_PL_PTN
        '
        Me.cboXDPL_PL_PTN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXDPL_PL_PTN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboXDPL_PL_PTN.FormattingEnabled = True
        Me.cboXDPL_PL_PTN.IntegralHeight = False
        Me.cboXDPL_PL_PTN.Location = New System.Drawing.Point(179, 168)
        Me.cboXDPL_PL_PTN.Name = "cboXDPL_PL_PTN"
        Me.cboXDPL_PL_PTN.Size = New System.Drawing.Size(100, 28)
        Me.cboXDPL_PL_PTN.TabIndex = 3
        '
        'cmdUnten
        '
        Me.cmdUnten.BackColor = System.Drawing.Color.DarkGray
        Me.cmdUnten.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdUnten.ForeColor = System.Drawing.Color.Black
        Me.cmdUnten.Location = New System.Drawing.Point(59, 293)
        Me.cmdUnten.Name = "cmdUnten"
        Me.cmdUnten.Size = New System.Drawing.Size(120, 40)
        Me.cmdUnten.TabIndex = 30
        Me.cmdUnten.Text = "運転"
        Me.cmdUnten.UseVisualStyleBackColor = False
        '
        'cmdTeisi
        '
        Me.cmdTeisi.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTeisi.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTeisi.ForeColor = System.Drawing.Color.Black
        Me.cmdTeisi.Location = New System.Drawing.Point(231, 293)
        Me.cmdTeisi.Name = "cmdTeisi"
        Me.cmdTeisi.Size = New System.Drawing.Size(120, 40)
        Me.cmdTeisi.TabIndex = 31
        Me.cmdTeisi.Text = "停止"
        Me.cmdTeisi.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(747, 293)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(120, 40)
        Me.cmdCancel.TabIndex = 32
        Me.cmdCancel.Text = "戻る"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lblXDPL_PL_NAME
        '
        Me.lblXDPL_PL_NAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXDPL_PL_NAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXDPL_PL_NAME.ForeColor = System.Drawing.Color.Black
        Me.lblXDPL_PL_NAME.Location = New System.Drawing.Point(179, 10)
        Me.lblXDPL_PL_NAME.Name = "lblXDPL_PL_NAME"
        Me.lblXDPL_PL_NAME.Size = New System.Drawing.Size(440, 32)
        Me.lblXDPL_PL_NAME.TabIndex = 29
        Me.lblXDPL_PL_NAME.Text = "設備名"
        Me.lblXDPL_PL_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(4, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(169, 32)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "ﾊﾟﾀｰﾝ:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.DarkGray
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClear.ForeColor = System.Drawing.Color.Black
        Me.cmdClear.Location = New System.Drawing.Point(403, 293)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(120, 40)
        Me.cmdClear.TabIndex = 46
        Me.cmdClear.Text = "ﾃﾞｰﾀｸﾘｱ"
        Me.cmdClear.UseVisualStyleBackColor = False
        '
        'cmdSyuryou
        '
        Me.cmdSyuryou.BackColor = System.Drawing.Color.DarkGray
        Me.cmdSyuryou.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSyuryou.ForeColor = System.Drawing.Color.Black
        Me.cmdSyuryou.Location = New System.Drawing.Point(575, 293)
        Me.cmdSyuryou.Name = "cmdSyuryou"
        Me.cmdSyuryou.Size = New System.Drawing.Size(120, 40)
        Me.cmdSyuryou.TabIndex = 47
        Me.cmdSyuryou.Text = "生産終了"
        Me.cmdSyuryou.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 32)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "ﾊﾟﾀｰﾝｺﾒﾝﾄ:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPTN_COMMENT
        '
        Me.lblPTN_COMMENT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPTN_COMMENT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblPTN_COMMENT.ForeColor = System.Drawing.Color.Black
        Me.lblPTN_COMMENT.Location = New System.Drawing.Point(179, 222)
        Me.lblPTN_COMMENT.Name = "lblPTN_COMMENT"
        Me.lblPTN_COMMENT.Size = New System.Drawing.Size(440, 32)
        Me.lblPTN_COMMENT.TabIndex = 48
        Me.lblPTN_COMMENT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdHinsyu
        '
        Me.cmdHinsyu.BackColor = System.Drawing.Color.DarkGray
        Me.cmdHinsyu.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdHinsyu.ForeColor = System.Drawing.Color.Black
        Me.cmdHinsyu.Location = New System.Drawing.Point(747, 104)
        Me.cmdHinsyu.Name = "cmdHinsyu"
        Me.cmdHinsyu.Size = New System.Drawing.Size(120, 40)
        Me.cmdHinsyu.TabIndex = 49
        Me.cmdHinsyu.Text = "品種設定"
        Me.cmdHinsyu.UseVisualStyleBackColor = False
        '
        'FRM_302011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(930, 370)
        Me.Controls.Add(Me.cmdHinsyu)
        Me.Controls.Add(Me.lblPTN_COMMENT)
        Me.Controls.Add(Me.cmdSyuryou)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblXDPL_PL_NAME)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdTeisi)
        Me.Controls.Add(Me.cmdUnten)
        Me.Controls.Add(Me.cboXDPL_PL_PTN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboFHINMEI_CD)
        Me.Controls.Add(Me.lblFHINMEI)
        Me.Name = "FRM_302011"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "運転設定"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboXDPL_PL_PTN As MateCommon.cmpMComboBox
    Friend WithEvents cmdUnten As System.Windows.Forms.Button
    Friend WithEvents cmdTeisi As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblXDPL_PL_NAME As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdSyuryou As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPTN_COMMENT As System.Windows.Forms.Label
    Friend WithEvents cmdHinsyu As System.Windows.Forms.Button

End Class
