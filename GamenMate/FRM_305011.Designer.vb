<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_305011
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblFDISP_ADDRESS = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblXAB_KUBUN = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.lblXKENSA_KUBUN = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.lblXSTRETCH_STS = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblFHASU_FLAG = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.lblXASRS_IN_DT = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblFARRIVE_DT = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblFHORYU_KUBUN = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblXHINSHITU_STS = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblXSYUKKA_KAHI = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblFTR_VOL = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblXPALLET_NO = New System.Windows.Forms.Label
        Me.lblXLINE_NO = New System.Windows.Forms.Label
        Me.lblXSEIZOU_DT = New System.Windows.Forms.Label
        Me.lblFHINMEI_CD = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblFHINMEI = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tmr305011 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(280, 664)
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(168, 664)
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(1160, 664)
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1160, 368)
        '
        'grdList
        '
        Me.grdList.blnDBUpdate = False
        Me.grdList.blnSelectionChanged = False
        Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList.Location = New System.Drawing.Point(1003, 679)
        Me.grdList.MyBeseDoubleBuffered = False
        Me.grdList.Name = "grdList"
        Me.grdList.RowTemplate.Height = 21
        Me.grdList.Size = New System.Drawing.Size(239, 78)
        Me.grdList.TabIndex = 23
        Me.grdList.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblFDISP_ADDRESS)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(170, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1080, 66)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'lblFDISP_ADDRESS
        '
        Me.lblFDISP_ADDRESS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFDISP_ADDRESS.ForeColor = System.Drawing.Color.Black
        Me.lblFDISP_ADDRESS.Location = New System.Drawing.Point(256, 17)
        Me.lblFDISP_ADDRESS.Name = "lblFDISP_ADDRESS"
        Me.lblFDISP_ADDRESS.Size = New System.Drawing.Size(144, 32)
        Me.lblFDISP_ADDRESS.TabIndex = 1
        Me.lblFDISP_ADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(80, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ロケーション:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblXAB_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.lblXKENSA_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.lblXSTRETCH_STS)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.lblFHASU_FLAG)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.lblXASRS_IN_DT)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.lblFARRIVE_DT)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.lblFHORYU_KUBUN)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lblXHINSHITU_STS)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lblXSYUKKA_KAHI)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblFTR_VOL)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblXPALLET_NO)
        Me.GroupBox2.Controls.Add(Me.lblXLINE_NO)
        Me.GroupBox2.Controls.Add(Me.lblXSEIZOU_DT)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI_CD)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lblFHINMEI)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(170, 160)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1080, 488)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'lblXAB_KUBUN
        '
        Me.lblXAB_KUBUN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXAB_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXAB_KUBUN.ForeColor = System.Drawing.Color.Black
        Me.lblXAB_KUBUN.Location = New System.Drawing.Point(633, 96)
        Me.lblXAB_KUBUN.Name = "lblXAB_KUBUN"
        Me.lblXAB_KUBUN.Size = New System.Drawing.Size(31, 32)
        Me.lblXAB_KUBUN.TabIndex = 28
        Me.lblXAB_KUBUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(488, 96)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(139, 32)
        Me.Label26.TabIndex = 27
        Me.Label26.Text = "AB区分:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXKENSA_KUBUN
        '
        Me.lblXKENSA_KUBUN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXKENSA_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXKENSA_KUBUN.ForeColor = System.Drawing.Color.Black
        Me.lblXKENSA_KUBUN.Location = New System.Drawing.Point(633, 64)
        Me.lblXKENSA_KUBUN.Name = "lblXKENSA_KUBUN"
        Me.lblXKENSA_KUBUN.Size = New System.Drawing.Size(31, 32)
        Me.lblXKENSA_KUBUN.TabIndex = 26
        Me.lblXKENSA_KUBUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(488, 64)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(139, 32)
        Me.Label24.TabIndex = 25
        Me.Label24.Text = "検査区分:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXSTRETCH_STS
        '
        Me.lblXSTRETCH_STS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSTRETCH_STS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXSTRETCH_STS.ForeColor = System.Drawing.Color.Black
        Me.lblXSTRETCH_STS.Location = New System.Drawing.Point(264, 408)
        Me.lblXSTRETCH_STS.Name = "lblXSTRETCH_STS"
        Me.lblXSTRETCH_STS.Size = New System.Drawing.Size(111, 32)
        Me.lblXSTRETCH_STS.TabIndex = 24
        Me.lblXSTRETCH_STS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(119, 408)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(139, 32)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "ｽﾄﾚｯﾁｽﾃｰﾀｽ:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHASU_FLAG
        '
        Me.lblFHASU_FLAG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHASU_FLAG.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHASU_FLAG.ForeColor = System.Drawing.Color.Black
        Me.lblFHASU_FLAG.Location = New System.Drawing.Point(264, 376)
        Me.lblFHASU_FLAG.Name = "lblFHASU_FLAG"
        Me.lblFHASU_FLAG.Size = New System.Drawing.Size(111, 32)
        Me.lblFHASU_FLAG.TabIndex = 22
        Me.lblFHASU_FLAG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(119, 376)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(139, 32)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "端数区分:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXASRS_IN_DT
        '
        Me.lblXASRS_IN_DT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXASRS_IN_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXASRS_IN_DT.ForeColor = System.Drawing.Color.Black
        Me.lblXASRS_IN_DT.Location = New System.Drawing.Point(264, 344)
        Me.lblXASRS_IN_DT.Name = "lblXASRS_IN_DT"
        Me.lblXASRS_IN_DT.Size = New System.Drawing.Size(232, 32)
        Me.lblXASRS_IN_DT.TabIndex = 20
        Me.lblXASRS_IN_DT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(56, 344)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(202, 32)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "入庫日時:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFARRIVE_DT
        '
        Me.lblFARRIVE_DT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFARRIVE_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFARRIVE_DT.ForeColor = System.Drawing.Color.Black
        Me.lblFARRIVE_DT.Location = New System.Drawing.Point(264, 312)
        Me.lblFARRIVE_DT.Name = "lblFARRIVE_DT"
        Me.lblFARRIVE_DT.Size = New System.Drawing.Size(232, 32)
        Me.lblFARRIVE_DT.TabIndex = 18
        Me.lblFARRIVE_DT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(56, 312)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(202, 32)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "在庫発生日時:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHORYU_KUBUN
        '
        Me.lblFHORYU_KUBUN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHORYU_KUBUN.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHORYU_KUBUN.ForeColor = System.Drawing.Color.Black
        Me.lblFHORYU_KUBUN.Location = New System.Drawing.Point(264, 256)
        Me.lblFHORYU_KUBUN.Name = "lblFHORYU_KUBUN"
        Me.lblFHORYU_KUBUN.Size = New System.Drawing.Size(111, 32)
        Me.lblFHORYU_KUBUN.TabIndex = 16
        Me.lblFHORYU_KUBUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(120, 256)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(139, 32)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "保留区分:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXHINSHITU_STS
        '
        Me.lblXHINSHITU_STS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXHINSHITU_STS.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXHINSHITU_STS.ForeColor = System.Drawing.Color.Black
        Me.lblXHINSHITU_STS.Location = New System.Drawing.Point(264, 224)
        Me.lblXHINSHITU_STS.Name = "lblXHINSHITU_STS"
        Me.lblXHINSHITU_STS.Size = New System.Drawing.Size(160, 32)
        Me.lblXHINSHITU_STS.TabIndex = 14
        Me.lblXHINSHITU_STS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(120, 224)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(139, 32)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "品質ｽﾃｰﾀｽ:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXSYUKKA_KAHI
        '
        Me.lblXSYUKKA_KAHI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSYUKKA_KAHI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXSYUKKA_KAHI.ForeColor = System.Drawing.Color.Black
        Me.lblXSYUKKA_KAHI.Location = New System.Drawing.Point(264, 192)
        Me.lblXSYUKKA_KAHI.Name = "lblXSYUKKA_KAHI"
        Me.lblXSYUKKA_KAHI.Size = New System.Drawing.Size(111, 32)
        Me.lblXSYUKKA_KAHI.TabIndex = 12
        Me.lblXSYUKKA_KAHI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(120, 192)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 32)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "出荷可否:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFTR_VOL
        '
        Me.lblFTR_VOL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFTR_VOL.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFTR_VOL.ForeColor = System.Drawing.Color.Black
        Me.lblFTR_VOL.Location = New System.Drawing.Point(264, 160)
        Me.lblFTR_VOL.Name = "lblFTR_VOL"
        Me.lblFTR_VOL.Size = New System.Drawing.Size(111, 32)
        Me.lblFTR_VOL.TabIndex = 10
        Me.lblFTR_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(120, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 32)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "積込数:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXPALLET_NO
        '
        Me.lblXPALLET_NO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXPALLET_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXPALLET_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXPALLET_NO.Location = New System.Drawing.Point(264, 128)
        Me.lblXPALLET_NO.Name = "lblXPALLET_NO"
        Me.lblXPALLET_NO.Size = New System.Drawing.Size(64, 32)
        Me.lblXPALLET_NO.TabIndex = 8
        Me.lblXPALLET_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXLINE_NO
        '
        Me.lblXLINE_NO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXLINE_NO.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXLINE_NO.ForeColor = System.Drawing.Color.Black
        Me.lblXLINE_NO.Location = New System.Drawing.Point(264, 96)
        Me.lblXLINE_NO.Name = "lblXLINE_NO"
        Me.lblXLINE_NO.Size = New System.Drawing.Size(96, 32)
        Me.lblXLINE_NO.TabIndex = 6
        Me.lblXLINE_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXSEIZOU_DT
        '
        Me.lblXSEIZOU_DT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXSEIZOU_DT.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblXSEIZOU_DT.ForeColor = System.Drawing.Color.Black
        Me.lblXSEIZOU_DT.Location = New System.Drawing.Point(264, 64)
        Me.lblXSEIZOU_DT.Name = "lblXSEIZOU_DT"
        Me.lblXSEIZOU_DT.Size = New System.Drawing.Size(160, 32)
        Me.lblXSEIZOU_DT.TabIndex = 4
        Me.lblXSEIZOU_DT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFHINMEI_CD
        '
        Me.lblFHINMEI_CD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFHINMEI_CD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI_CD.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI_CD.Location = New System.Drawing.Point(264, 32)
        Me.lblFHINMEI_CD.Name = "lblFHINMEI_CD"
        Me.lblFHINMEI_CD.Size = New System.Drawing.Size(104, 32)
        Me.lblFHINMEI_CD.TabIndex = 1
        Me.lblFHINMEI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(119, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 32)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "ﾊﾟﾚｯﾄ№:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(119, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 32)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "ﾗｲﾝ№:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(42, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(216, 32)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "製造年月日:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFHINMEI
        '
        Me.lblFHINMEI.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFHINMEI.ForeColor = System.Drawing.Color.Black
        Me.lblFHINMEI.Location = New System.Drawing.Point(376, 31)
        Me.lblFHINMEI.Name = "lblFHINMEI"
        Me.lblFHINMEI.Size = New System.Drawing.Size(576, 32)
        Me.lblFHINMEI.TabIndex = 2
        Me.lblFHINMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(42, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "品名ｺｰﾄﾞ:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmr305011
        '
        '
        'FRM_305011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_305011"
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
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As GamenCommon.cmpMDataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFDISP_ADDRESS As System.Windows.Forms.Label
    Friend WithEvents lblFHINMEI_CD As System.Windows.Forms.Label
    Friend WithEvents tmr305011 As System.Windows.Forms.Timer
    Friend WithEvents lblXSEIZOU_DT As System.Windows.Forms.Label
    Friend WithEvents lblXPALLET_NO As System.Windows.Forms.Label
    Friend WithEvents lblFHORYU_KUBUN As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblXHINSHITU_STS As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblXSYUKKA_KAHI As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblFTR_VOL As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblXSTRETCH_STS As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblFHASU_FLAG As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblXASRS_IN_DT As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblFARRIVE_DT As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblXLINE_NO As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblXAB_KUBUN As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblXKENSA_KUBUN As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label

End Class
