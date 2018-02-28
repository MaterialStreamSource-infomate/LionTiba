<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_308050
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblHIKIATE_ORDER_SU = New System.Windows.Forms.Label
        Me.grdList = New GamenCommon.cmpMDataGrid(Me.components)
        Me.grdList2 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.lblKARICHU = New System.Windows.Forms.Label
        Me.tmr308050 = New System.Windows.Forms.Timer(Me.components)
        Me.tmr308050_2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF8
        '
        Me.cmdF8.Location = New System.Drawing.Point(1064, 717)
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1150, 664)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(838, 664)
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
        Me.cmdF1.Location = New System.Drawing.Point(1144, 92)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblHIKIATE_ORDER_SU)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1080, 64)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(48, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "引当出荷ｵｰﾀﾞ数:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHIKIATE_ORDER_SU
        '
        Me.lblHIKIATE_ORDER_SU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHIKIATE_ORDER_SU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblHIKIATE_ORDER_SU.ForeColor = System.Drawing.Color.Black
        Me.lblHIKIATE_ORDER_SU.Location = New System.Drawing.Point(240, 19)
        Me.lblHIKIATE_ORDER_SU.Name = "lblHIKIATE_ORDER_SU"
        Me.lblHIKIATE_ORDER_SU.Size = New System.Drawing.Size(103, 32)
        Me.lblHIKIATE_ORDER_SU.TabIndex = 2
        Me.lblHIKIATE_ORDER_SU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(168, 216)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(1080, 439)
        Me.grdList.TabIndex = 1
        '
        'grdList2
        '
        Me.grdList2.blnDBUpdate = False
        Me.grdList2.blnSelectionChanged = False
        Me.grdList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList2.Location = New System.Drawing.Point(982, 656)
        Me.grdList2.MyBeseDoubleBuffered = False
        Me.grdList2.Name = "grdList2"
        Me.grdList2.RowTemplate.Height = 21
        Me.grdList2.Size = New System.Drawing.Size(160, 56)
        Me.grdList2.TabIndex = 213
        Me.grdList2.Visible = False
        '
        'lblKARICHU
        '
        Me.lblKARICHU.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblKARICHU.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKARICHU.ForeColor = System.Drawing.Color.Black
        Me.lblKARICHU.Location = New System.Drawing.Point(984, 98)
        Me.lblKARICHU.Name = "lblKARICHU"
        Me.lblKARICHU.Size = New System.Drawing.Size(144, 32)
        Me.lblKARICHU.TabIndex = 214
        Me.lblKARICHU.Text = "仮引当処理中"
        Me.lblKARICHU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmr308050
        '
        Me.tmr308050.Interval = 3000
        '
        'tmr308050_2
        '
        Me.tmr308050_2.Interval = 3000
        '
        'FRM_308050
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.lblKARICHU)
        Me.Controls.Add(Me.grdList2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_308050"
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
        Me.Controls.SetChildIndex(Me.grdList2, 0)
        Me.Controls.SetChildIndex(Me.lblKARICHU, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents lblHIKIATE_ORDER_SU As System.Windows.Forms.Label
    Friend WithEvents grdList2 As GamenCommon.cmpMDataGrid
    Friend WithEvents lblKARICHU As System.Windows.Forms.Label
    Friend WithEvents tmr308050 As System.Windows.Forms.Timer
    Friend WithEvents tmr308050_2 As System.Windows.Forms.Timer

End Class
