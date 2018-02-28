<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308021
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblXBERTH_NO = New System.Windows.Forms.Label
        Me.lblCAR_NO_WARITUKE = New System.Windows.Forms.Label
        Me.lblXNYUKA_JIGYOU_NM = New System.Windows.Forms.Label
        Me.tmr308021 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1144, 664)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(278, 664)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(168, 664)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 144)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 502)
        Me.grdList.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(390, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 32)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "受付車番:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(654, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 32)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "配送先/出荷先:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(208, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "バース:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXBERTH_NO
        '
        Me.lblXBERTH_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXBERTH_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXBERTH_NO.Location = New System.Drawing.Point(318, 96)
        Me.lblXBERTH_NO.Name = "lblXBERTH_NO"
        Me.lblXBERTH_NO.Size = New System.Drawing.Size(48, 32)
        Me.lblXBERTH_NO.TabIndex = 1
        Me.lblXBERTH_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCAR_NO_WARITUKE
        '
        Me.lblCAR_NO_WARITUKE.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblCAR_NO_WARITUKE.ForeColor = System.Drawing.Color.Black
        Me.lblCAR_NO_WARITUKE.Location = New System.Drawing.Point(510, 96)
        Me.lblCAR_NO_WARITUKE.Name = "lblCAR_NO_WARITUKE"
        Me.lblCAR_NO_WARITUKE.Size = New System.Drawing.Size(118, 32)
        Me.lblCAR_NO_WARITUKE.TabIndex = 3
        Me.lblCAR_NO_WARITUKE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXNYUKA_JIGYOU_NM
        '
        Me.lblXNYUKA_JIGYOU_NM.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblXNYUKA_JIGYOU_NM.ForeColor = System.Drawing.Color.Black
        Me.lblXNYUKA_JIGYOU_NM.Location = New System.Drawing.Point(832, 96)
        Me.lblXNYUKA_JIGYOU_NM.Name = "lblXNYUKA_JIGYOU_NM"
        Me.lblXNYUKA_JIGYOU_NM.Size = New System.Drawing.Size(350, 32)
        Me.lblXNYUKA_JIGYOU_NM.TabIndex = 5
        Me.lblXNYUKA_JIGYOU_NM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmr308021
        '
        Me.tmr308021.Interval = 3000
        '
        'FRM_308021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.lblXNYUKA_JIGYOU_NM)
        Me.Controls.Add(Me.lblCAR_NO_WARITUKE)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.lblXBERTH_NO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Name = "FRM_308021"
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lblXBERTH_NO, 0)
        Me.Controls.SetChildIndex(Me.grdList, 0)
        Me.Controls.SetChildIndex(Me.lblCAR_NO_WARITUKE, 0)
        Me.Controls.SetChildIndex(Me.lblXNYUKA_JIGYOU_NM, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblXBERTH_NO As System.Windows.Forms.Label
    Friend WithEvents lblCAR_NO_WARITUKE As System.Windows.Forms.Label
    Friend WithEvents lblXNYUKA_JIGYOU_NM As System.Windows.Forms.Label
    Friend WithEvents tmr308021 As System.Windows.Forms.Timer

End Class
