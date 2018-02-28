<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_307150
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
        Me.tmr307150 = New System.Windows.Forms.Timer(Me.components)
        Me.grdList01 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblGET_Time = New System.Windows.Forms.Label
        Me.grdList02 = New GamenCommon.cmpMDataGrid(Me.components)
        Me.cmdRedisplay = New System.Windows.Forms.Button
        Me.cmdRegistration = New System.Windows.Forms.Button
        Me.txtITF1_4 = New MateCommon.cmpMTextBoxString
        Me.txtITF1_3 = New MateCommon.cmpMTextBoxString
        Me.txtITF1_2 = New MateCommon.cmpMTextBoxString
        Me.txtITF1_1 = New MateCommon.cmpMTextBoxString
        Me.CmpMTextBoxString4 = New MateCommon.cmpMTextBoxString
        Me.txtList01 = New MateCommon.cmpMTextBoxString
        Me.txtList02 = New MateCommon.cmpMTextBoxString
        Me.CmpMTextBoxString6 = New MateCommon.cmpMTextBoxString
        Me.txtITF2_1 = New MateCommon.cmpMTextBoxString
        Me.txtITF2_2 = New MateCommon.cmpMTextBoxString
        Me.txtITF2_3 = New MateCommon.cmpMTextBoxString
        Me.txtITF2_4 = New MateCommon.cmpMTextBoxString
        Me.CmpMTextBoxString1 = New MateCommon.cmpMTextBoxString
        Me.txtITF1_1f = New MateCommon.cmpMTextBoxString
        Me.txtITF1_2f = New MateCommon.cmpMTextBoxString
        Me.txtITF1_3f = New MateCommon.cmpMTextBoxString
        Me.txtITF1_4f = New MateCommon.cmpMTextBoxString
        Me.CmpMTextBoxString2 = New MateCommon.cmpMTextBoxString
        Me.txtITF2_1f = New MateCommon.cmpMTextBoxString
        Me.txtITF2_2f = New MateCommon.cmpMTextBoxString
        Me.txtITF2_3f = New MateCommon.cmpMTextBoxString
        Me.txtITF2_4f = New MateCommon.cmpMTextBoxString
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdF7
        '
        Me.cmdF7.Location = New System.Drawing.Point(1162, 664)
        '
        'cmdF6
        '
        Me.cmdF6.Location = New System.Drawing.Point(563, 664)
        Me.cmdF6.Size = New System.Drawing.Size(120, 43)
        Me.cmdF6.TabIndex = 4
        '
        'cmdF5
        '
        Me.cmdF5.Location = New System.Drawing.Point(432, 664)
        Me.cmdF5.Size = New System.Drawing.Size(120, 43)
        Me.cmdF5.TabIndex = 3
        '
        'cmdF4
        '
        Me.cmdF4.Location = New System.Drawing.Point(299, 664)
        Me.cmdF4.Size = New System.Drawing.Size(120, 43)
        Me.cmdF4.TabIndex = 2
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(786, 664)
        Me.cmdF2.Size = New System.Drawing.Size(120, 43)
        Me.cmdF2.TabIndex = 1
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1036, 717)
        Me.cmdF1.Size = New System.Drawing.Size(120, 43)
        '
        'tmr307150
        '
        Me.tmr307150.Interval = 5000
        '
        'grdList01
        '
        Me.grdList01.blnDBUpdate = False
        Me.grdList01.blnSelectionChanged = False
        Me.grdList01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList01.Location = New System.Drawing.Point(192, 124)
        Me.grdList01.MyBeseDoubleBuffered = False
        Me.grdList01.Name = "grdList01"
        Me.grdList01.RowTemplate.Height = 21
        Me.grdList01.Size = New System.Drawing.Size(333, 100)
        Me.grdList01.TabIndex = 213
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(158, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 32)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "データ取得日時:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGET_Time
        '
        Me.lblGET_Time.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGET_Time.ForeColor = System.Drawing.Color.Black
        Me.lblGET_Time.Location = New System.Drawing.Point(333, 82)
        Me.lblGET_Time.Name = "lblGET_Time"
        Me.lblGET_Time.Size = New System.Drawing.Size(305, 32)
        Me.lblGET_Time.TabIndex = 30
        Me.lblGET_Time.Text = "2013/01/01 00:00:00"
        Me.lblGET_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdList02
        '
        Me.grdList02.blnDBUpdate = False
        Me.grdList02.blnSelectionChanged = False
        Me.grdList02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdList02.Location = New System.Drawing.Point(673, 124)
        Me.grdList02.MyBeseDoubleBuffered = False
        Me.grdList02.Name = "grdList02"
        Me.grdList02.RowTemplate.Height = 21
        Me.grdList02.Size = New System.Drawing.Size(333, 100)
        Me.grdList02.TabIndex = 214
        '
        'cmdRedisplay
        '
        Me.cmdRedisplay.BackColor = System.Drawing.Color.DarkGray
        Me.cmdRedisplay.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdRedisplay.ForeColor = System.Drawing.Color.Black
        Me.cmdRedisplay.Location = New System.Drawing.Point(185, 666)
        Me.cmdRedisplay.Name = "cmdRedisplay"
        Me.cmdRedisplay.Size = New System.Drawing.Size(187, 40)
        Me.cmdRedisplay.TabIndex = 219
        Me.cmdRedisplay.Text = "再表示"
        Me.cmdRedisplay.UseVisualStyleBackColor = False
        '
        'cmdRegistration
        '
        Me.cmdRegistration.BackColor = System.Drawing.Color.DarkGray
        Me.cmdRegistration.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdRegistration.ForeColor = System.Drawing.Color.Black
        Me.cmdRegistration.Location = New System.Drawing.Point(425, 666)
        Me.cmdRegistration.Name = "cmdRegistration"
        Me.cmdRegistration.Size = New System.Drawing.Size(187, 40)
        Me.cmdRegistration.TabIndex = 220
        Me.cmdRegistration.Text = "登録"
        Me.cmdRegistration.UseVisualStyleBackColor = False
        '
        'txtITF1_4
        '
        Me.txtITF1_4.BackColor = System.Drawing.Color.White
        Me.txtITF1_4.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF1_4.EnabledFull = True
        Me.txtITF1_4.EnabledFullAlphabetLower = False
        Me.txtITF1_4.EnabledFullAlphabetUpper = False
        Me.txtITF1_4.EnabledFullHiragana = False
        Me.txtITF1_4.EnabledFullKatakana = False
        Me.txtITF1_4.EnabledFullNumber = False
        Me.txtITF1_4.EnabledHalf = True
        Me.txtITF1_4.EnabledHalfAlphabetLower = True
        Me.txtITF1_4.EnabledHalfAlphabetUpper = True
        Me.txtITF1_4.EnabledHalfKatakana = True
        Me.txtITF1_4.EnabledHalfNumber = True
        Me.txtITF1_4.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF1_4.Location = New System.Drawing.Point(192, 280)
        Me.txtITF1_4.MaxLength = 8
        Me.txtITF1_4.MaxLengthByte = 0
        Me.txtITF1_4.Name = "txtITF1_4"
        Me.txtITF1_4.RegexCustomFalse = Nothing
        Me.txtITF1_4.RegexCustomTrue = Nothing
        Me.txtITF1_4.Size = New System.Drawing.Size(69, 26)
        Me.txtITF1_4.TabIndex = 221
        Me.txtITF1_4.Visible = False
        '
        'txtITF1_3
        '
        Me.txtITF1_3.BackColor = System.Drawing.Color.White
        Me.txtITF1_3.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF1_3.EnabledFull = True
        Me.txtITF1_3.EnabledFullAlphabetLower = False
        Me.txtITF1_3.EnabledFullAlphabetUpper = False
        Me.txtITF1_3.EnabledFullHiragana = False
        Me.txtITF1_3.EnabledFullKatakana = False
        Me.txtITF1_3.EnabledFullNumber = False
        Me.txtITF1_3.EnabledHalf = True
        Me.txtITF1_3.EnabledHalfAlphabetLower = True
        Me.txtITF1_3.EnabledHalfAlphabetUpper = True
        Me.txtITF1_3.EnabledHalfKatakana = True
        Me.txtITF1_3.EnabledHalfNumber = True
        Me.txtITF1_3.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF1_3.Location = New System.Drawing.Point(269, 280)
        Me.txtITF1_3.MaxLength = 8
        Me.txtITF1_3.MaxLengthByte = 0
        Me.txtITF1_3.Name = "txtITF1_3"
        Me.txtITF1_3.RegexCustomFalse = Nothing
        Me.txtITF1_3.RegexCustomTrue = Nothing
        Me.txtITF1_3.Size = New System.Drawing.Size(70, 26)
        Me.txtITF1_3.TabIndex = 222
        Me.txtITF1_3.Visible = False
        '
        'txtITF1_2
        '
        Me.txtITF1_2.BackColor = System.Drawing.Color.White
        Me.txtITF1_2.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF1_2.EnabledFull = True
        Me.txtITF1_2.EnabledFullAlphabetLower = False
        Me.txtITF1_2.EnabledFullAlphabetUpper = False
        Me.txtITF1_2.EnabledFullHiragana = False
        Me.txtITF1_2.EnabledFullKatakana = False
        Me.txtITF1_2.EnabledFullNumber = False
        Me.txtITF1_2.EnabledHalf = True
        Me.txtITF1_2.EnabledHalfAlphabetLower = True
        Me.txtITF1_2.EnabledHalfAlphabetUpper = True
        Me.txtITF1_2.EnabledHalfKatakana = True
        Me.txtITF1_2.EnabledHalfNumber = True
        Me.txtITF1_2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF1_2.Location = New System.Drawing.Point(347, 280)
        Me.txtITF1_2.MaxLength = 8
        Me.txtITF1_2.MaxLengthByte = 0
        Me.txtITF1_2.Name = "txtITF1_2"
        Me.txtITF1_2.RegexCustomFalse = Nothing
        Me.txtITF1_2.RegexCustomTrue = Nothing
        Me.txtITF1_2.Size = New System.Drawing.Size(70, 26)
        Me.txtITF1_2.TabIndex = 223
        Me.txtITF1_2.Visible = False
        '
        'txtITF1_1
        '
        Me.txtITF1_1.BackColor = System.Drawing.Color.White
        Me.txtITF1_1.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF1_1.EnabledFull = True
        Me.txtITF1_1.EnabledFullAlphabetLower = False
        Me.txtITF1_1.EnabledFullAlphabetUpper = False
        Me.txtITF1_1.EnabledFullHiragana = False
        Me.txtITF1_1.EnabledFullKatakana = False
        Me.txtITF1_1.EnabledFullNumber = False
        Me.txtITF1_1.EnabledHalf = True
        Me.txtITF1_1.EnabledHalfAlphabetLower = True
        Me.txtITF1_1.EnabledHalfAlphabetUpper = True
        Me.txtITF1_1.EnabledHalfKatakana = True
        Me.txtITF1_1.EnabledHalfNumber = True
        Me.txtITF1_1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF1_1.Location = New System.Drawing.Point(425, 280)
        Me.txtITF1_1.MaxLength = 8
        Me.txtITF1_1.MaxLengthByte = 0
        Me.txtITF1_1.Name = "txtITF1_1"
        Me.txtITF1_1.RegexCustomFalse = Nothing
        Me.txtITF1_1.RegexCustomTrue = Nothing
        Me.txtITF1_1.Size = New System.Drawing.Size(66, 26)
        Me.txtITF1_1.TabIndex = 224
        Me.txtITF1_1.Visible = False
        '
        'CmpMTextBoxString4
        '
        Me.CmpMTextBoxString4.BackColor = System.Drawing.Color.White
        Me.CmpMTextBoxString4.BackColorMask = System.Drawing.Color.Empty
        Me.CmpMTextBoxString4.EnabledFull = True
        Me.CmpMTextBoxString4.EnabledFullAlphabetLower = False
        Me.CmpMTextBoxString4.EnabledFullAlphabetUpper = False
        Me.CmpMTextBoxString4.EnabledFullHiragana = False
        Me.CmpMTextBoxString4.EnabledFullKatakana = False
        Me.CmpMTextBoxString4.EnabledFullNumber = False
        Me.CmpMTextBoxString4.EnabledHalf = True
        Me.CmpMTextBoxString4.EnabledHalfAlphabetLower = True
        Me.CmpMTextBoxString4.EnabledHalfAlphabetUpper = True
        Me.CmpMTextBoxString4.EnabledHalfKatakana = True
        Me.CmpMTextBoxString4.EnabledHalfNumber = True
        Me.CmpMTextBoxString4.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmpMTextBoxString4.Location = New System.Drawing.Point(518, 280)
        Me.CmpMTextBoxString4.MaxLength = 8
        Me.CmpMTextBoxString4.MaxLengthByte = 0
        Me.CmpMTextBoxString4.Name = "CmpMTextBoxString4"
        Me.CmpMTextBoxString4.RegexCustomFalse = Nothing
        Me.CmpMTextBoxString4.RegexCustomTrue = Nothing
        Me.CmpMTextBoxString4.Size = New System.Drawing.Size(101, 26)
        Me.CmpMTextBoxString4.TabIndex = 225
        Me.CmpMTextBoxString4.Visible = False
        '
        'txtList01
        '
        Me.txtList01.BackColor = System.Drawing.Color.White
        Me.txtList01.BackColorMask = System.Drawing.Color.Empty
        Me.txtList01.EnabledFull = True
        Me.txtList01.EnabledFullAlphabetLower = False
        Me.txtList01.EnabledFullAlphabetUpper = False
        Me.txtList01.EnabledFullHiragana = False
        Me.txtList01.EnabledFullKatakana = False
        Me.txtList01.EnabledFullNumber = False
        Me.txtList01.EnabledHalf = True
        Me.txtList01.EnabledHalfAlphabetLower = True
        Me.txtList01.EnabledHalfAlphabetUpper = True
        Me.txtList01.EnabledHalfKatakana = True
        Me.txtList01.EnabledHalfNumber = True
        Me.txtList01.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtList01.Location = New System.Drawing.Point(192, 248)
        Me.txtList01.MaxLength = 8
        Me.txtList01.MaxLengthByte = 0
        Me.txtList01.Name = "txtList01"
        Me.txtList01.RegexCustomFalse = Nothing
        Me.txtList01.RegexCustomTrue = Nothing
        Me.txtList01.Size = New System.Drawing.Size(101, 26)
        Me.txtList01.TabIndex = 226
        Me.txtList01.Visible = False
        '
        'txtList02
        '
        Me.txtList02.BackColor = System.Drawing.Color.White
        Me.txtList02.BackColorMask = System.Drawing.Color.Empty
        Me.txtList02.EnabledFull = True
        Me.txtList02.EnabledFullAlphabetLower = False
        Me.txtList02.EnabledFullAlphabetUpper = False
        Me.txtList02.EnabledFullHiragana = False
        Me.txtList02.EnabledFullKatakana = False
        Me.txtList02.EnabledFullNumber = False
        Me.txtList02.EnabledHalf = True
        Me.txtList02.EnabledHalfAlphabetLower = True
        Me.txtList02.EnabledHalfAlphabetUpper = True
        Me.txtList02.EnabledHalfKatakana = True
        Me.txtList02.EnabledHalfNumber = True
        Me.txtList02.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtList02.Location = New System.Drawing.Point(673, 248)
        Me.txtList02.MaxLength = 8
        Me.txtList02.MaxLengthByte = 0
        Me.txtList02.Name = "txtList02"
        Me.txtList02.RegexCustomFalse = Nothing
        Me.txtList02.RegexCustomTrue = Nothing
        Me.txtList02.Size = New System.Drawing.Size(101, 26)
        Me.txtList02.TabIndex = 227
        Me.txtList02.Visible = False
        '
        'CmpMTextBoxString6
        '
        Me.CmpMTextBoxString6.BackColor = System.Drawing.Color.White
        Me.CmpMTextBoxString6.BackColorMask = System.Drawing.Color.Empty
        Me.CmpMTextBoxString6.EnabledFull = True
        Me.CmpMTextBoxString6.EnabledFullAlphabetLower = False
        Me.CmpMTextBoxString6.EnabledFullAlphabetUpper = False
        Me.CmpMTextBoxString6.EnabledFullHiragana = False
        Me.CmpMTextBoxString6.EnabledFullKatakana = False
        Me.CmpMTextBoxString6.EnabledFullNumber = False
        Me.CmpMTextBoxString6.EnabledHalf = True
        Me.CmpMTextBoxString6.EnabledHalfAlphabetLower = True
        Me.CmpMTextBoxString6.EnabledHalfAlphabetUpper = True
        Me.CmpMTextBoxString6.EnabledHalfKatakana = True
        Me.CmpMTextBoxString6.EnabledHalfNumber = True
        Me.CmpMTextBoxString6.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmpMTextBoxString6.Location = New System.Drawing.Point(518, 312)
        Me.CmpMTextBoxString6.MaxLength = 8
        Me.CmpMTextBoxString6.MaxLengthByte = 0
        Me.CmpMTextBoxString6.Name = "CmpMTextBoxString6"
        Me.CmpMTextBoxString6.RegexCustomFalse = Nothing
        Me.CmpMTextBoxString6.RegexCustomTrue = Nothing
        Me.CmpMTextBoxString6.Size = New System.Drawing.Size(101, 26)
        Me.CmpMTextBoxString6.TabIndex = 232
        Me.CmpMTextBoxString6.Visible = False
        '
        'txtITF2_1
        '
        Me.txtITF2_1.BackColor = System.Drawing.Color.White
        Me.txtITF2_1.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF2_1.EnabledFull = True
        Me.txtITF2_1.EnabledFullAlphabetLower = False
        Me.txtITF2_1.EnabledFullAlphabetUpper = False
        Me.txtITF2_1.EnabledFullHiragana = False
        Me.txtITF2_1.EnabledFullKatakana = False
        Me.txtITF2_1.EnabledFullNumber = False
        Me.txtITF2_1.EnabledHalf = True
        Me.txtITF2_1.EnabledHalfAlphabetLower = True
        Me.txtITF2_1.EnabledHalfAlphabetUpper = True
        Me.txtITF2_1.EnabledHalfKatakana = True
        Me.txtITF2_1.EnabledHalfNumber = True
        Me.txtITF2_1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF2_1.Location = New System.Drawing.Point(425, 312)
        Me.txtITF2_1.MaxLength = 8
        Me.txtITF2_1.MaxLengthByte = 0
        Me.txtITF2_1.Name = "txtITF2_1"
        Me.txtITF2_1.RegexCustomFalse = Nothing
        Me.txtITF2_1.RegexCustomTrue = Nothing
        Me.txtITF2_1.Size = New System.Drawing.Size(66, 26)
        Me.txtITF2_1.TabIndex = 231
        Me.txtITF2_1.Visible = False
        '
        'txtITF2_2
        '
        Me.txtITF2_2.BackColor = System.Drawing.Color.White
        Me.txtITF2_2.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF2_2.EnabledFull = True
        Me.txtITF2_2.EnabledFullAlphabetLower = False
        Me.txtITF2_2.EnabledFullAlphabetUpper = False
        Me.txtITF2_2.EnabledFullHiragana = False
        Me.txtITF2_2.EnabledFullKatakana = False
        Me.txtITF2_2.EnabledFullNumber = False
        Me.txtITF2_2.EnabledHalf = True
        Me.txtITF2_2.EnabledHalfAlphabetLower = True
        Me.txtITF2_2.EnabledHalfAlphabetUpper = True
        Me.txtITF2_2.EnabledHalfKatakana = True
        Me.txtITF2_2.EnabledHalfNumber = True
        Me.txtITF2_2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF2_2.Location = New System.Drawing.Point(347, 312)
        Me.txtITF2_2.MaxLength = 8
        Me.txtITF2_2.MaxLengthByte = 0
        Me.txtITF2_2.Name = "txtITF2_2"
        Me.txtITF2_2.RegexCustomFalse = Nothing
        Me.txtITF2_2.RegexCustomTrue = Nothing
        Me.txtITF2_2.Size = New System.Drawing.Size(70, 26)
        Me.txtITF2_2.TabIndex = 230
        Me.txtITF2_2.Visible = False
        '
        'txtITF2_3
        '
        Me.txtITF2_3.BackColor = System.Drawing.Color.White
        Me.txtITF2_3.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF2_3.EnabledFull = True
        Me.txtITF2_3.EnabledFullAlphabetLower = False
        Me.txtITF2_3.EnabledFullAlphabetUpper = False
        Me.txtITF2_3.EnabledFullHiragana = False
        Me.txtITF2_3.EnabledFullKatakana = False
        Me.txtITF2_3.EnabledFullNumber = False
        Me.txtITF2_3.EnabledHalf = True
        Me.txtITF2_3.EnabledHalfAlphabetLower = True
        Me.txtITF2_3.EnabledHalfAlphabetUpper = True
        Me.txtITF2_3.EnabledHalfKatakana = True
        Me.txtITF2_3.EnabledHalfNumber = True
        Me.txtITF2_3.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF2_3.Location = New System.Drawing.Point(269, 312)
        Me.txtITF2_3.MaxLength = 8
        Me.txtITF2_3.MaxLengthByte = 0
        Me.txtITF2_3.Name = "txtITF2_3"
        Me.txtITF2_3.RegexCustomFalse = Nothing
        Me.txtITF2_3.RegexCustomTrue = Nothing
        Me.txtITF2_3.Size = New System.Drawing.Size(70, 26)
        Me.txtITF2_3.TabIndex = 229
        Me.txtITF2_3.Visible = False
        '
        'txtITF2_4
        '
        Me.txtITF2_4.BackColor = System.Drawing.Color.White
        Me.txtITF2_4.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF2_4.EnabledFull = True
        Me.txtITF2_4.EnabledFullAlphabetLower = False
        Me.txtITF2_4.EnabledFullAlphabetUpper = False
        Me.txtITF2_4.EnabledFullHiragana = False
        Me.txtITF2_4.EnabledFullKatakana = False
        Me.txtITF2_4.EnabledFullNumber = False
        Me.txtITF2_4.EnabledHalf = True
        Me.txtITF2_4.EnabledHalfAlphabetLower = True
        Me.txtITF2_4.EnabledHalfAlphabetUpper = True
        Me.txtITF2_4.EnabledHalfKatakana = True
        Me.txtITF2_4.EnabledHalfNumber = True
        Me.txtITF2_4.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF2_4.Location = New System.Drawing.Point(192, 312)
        Me.txtITF2_4.MaxLength = 8
        Me.txtITF2_4.MaxLengthByte = 0
        Me.txtITF2_4.Name = "txtITF2_4"
        Me.txtITF2_4.RegexCustomFalse = Nothing
        Me.txtITF2_4.RegexCustomTrue = Nothing
        Me.txtITF2_4.Size = New System.Drawing.Size(69, 26)
        Me.txtITF2_4.TabIndex = 228
        Me.txtITF2_4.Visible = False
        '
        'CmpMTextBoxString1
        '
        Me.CmpMTextBoxString1.BackColor = System.Drawing.Color.White
        Me.CmpMTextBoxString1.BackColorMask = System.Drawing.Color.Empty
        Me.CmpMTextBoxString1.EnabledFull = True
        Me.CmpMTextBoxString1.EnabledFullAlphabetLower = False
        Me.CmpMTextBoxString1.EnabledFullAlphabetUpper = False
        Me.CmpMTextBoxString1.EnabledFullHiragana = False
        Me.CmpMTextBoxString1.EnabledFullKatakana = False
        Me.CmpMTextBoxString1.EnabledFullNumber = False
        Me.CmpMTextBoxString1.EnabledHalf = True
        Me.CmpMTextBoxString1.EnabledHalfAlphabetLower = True
        Me.CmpMTextBoxString1.EnabledHalfAlphabetUpper = True
        Me.CmpMTextBoxString1.EnabledHalfKatakana = True
        Me.CmpMTextBoxString1.EnabledHalfNumber = True
        Me.CmpMTextBoxString1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmpMTextBoxString1.Location = New System.Drawing.Point(518, 370)
        Me.CmpMTextBoxString1.MaxLength = 8
        Me.CmpMTextBoxString1.MaxLengthByte = 0
        Me.CmpMTextBoxString1.Name = "CmpMTextBoxString1"
        Me.CmpMTextBoxString1.RegexCustomFalse = Nothing
        Me.CmpMTextBoxString1.RegexCustomTrue = Nothing
        Me.CmpMTextBoxString1.Size = New System.Drawing.Size(101, 26)
        Me.CmpMTextBoxString1.TabIndex = 237
        Me.CmpMTextBoxString1.Visible = False
        '
        'txtITF1_1f
        '
        Me.txtITF1_1f.BackColor = System.Drawing.Color.White
        Me.txtITF1_1f.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF1_1f.EnabledFull = True
        Me.txtITF1_1f.EnabledFullAlphabetLower = False
        Me.txtITF1_1f.EnabledFullAlphabetUpper = False
        Me.txtITF1_1f.EnabledFullHiragana = False
        Me.txtITF1_1f.EnabledFullKatakana = False
        Me.txtITF1_1f.EnabledFullNumber = False
        Me.txtITF1_1f.EnabledHalf = True
        Me.txtITF1_1f.EnabledHalfAlphabetLower = True
        Me.txtITF1_1f.EnabledHalfAlphabetUpper = True
        Me.txtITF1_1f.EnabledHalfKatakana = True
        Me.txtITF1_1f.EnabledHalfNumber = True
        Me.txtITF1_1f.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF1_1f.Location = New System.Drawing.Point(425, 370)
        Me.txtITF1_1f.MaxLength = 8
        Me.txtITF1_1f.MaxLengthByte = 0
        Me.txtITF1_1f.Name = "txtITF1_1f"
        Me.txtITF1_1f.RegexCustomFalse = Nothing
        Me.txtITF1_1f.RegexCustomTrue = Nothing
        Me.txtITF1_1f.Size = New System.Drawing.Size(66, 26)
        Me.txtITF1_1f.TabIndex = 236
        Me.txtITF1_1f.Visible = False
        '
        'txtITF1_2f
        '
        Me.txtITF1_2f.BackColor = System.Drawing.Color.White
        Me.txtITF1_2f.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF1_2f.EnabledFull = True
        Me.txtITF1_2f.EnabledFullAlphabetLower = False
        Me.txtITF1_2f.EnabledFullAlphabetUpper = False
        Me.txtITF1_2f.EnabledFullHiragana = False
        Me.txtITF1_2f.EnabledFullKatakana = False
        Me.txtITF1_2f.EnabledFullNumber = False
        Me.txtITF1_2f.EnabledHalf = True
        Me.txtITF1_2f.EnabledHalfAlphabetLower = True
        Me.txtITF1_2f.EnabledHalfAlphabetUpper = True
        Me.txtITF1_2f.EnabledHalfKatakana = True
        Me.txtITF1_2f.EnabledHalfNumber = True
        Me.txtITF1_2f.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF1_2f.Location = New System.Drawing.Point(347, 370)
        Me.txtITF1_2f.MaxLength = 8
        Me.txtITF1_2f.MaxLengthByte = 0
        Me.txtITF1_2f.Name = "txtITF1_2f"
        Me.txtITF1_2f.RegexCustomFalse = Nothing
        Me.txtITF1_2f.RegexCustomTrue = Nothing
        Me.txtITF1_2f.Size = New System.Drawing.Size(70, 26)
        Me.txtITF1_2f.TabIndex = 235
        Me.txtITF1_2f.Visible = False
        '
        'txtITF1_3f
        '
        Me.txtITF1_3f.BackColor = System.Drawing.Color.White
        Me.txtITF1_3f.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF1_3f.EnabledFull = True
        Me.txtITF1_3f.EnabledFullAlphabetLower = False
        Me.txtITF1_3f.EnabledFullAlphabetUpper = False
        Me.txtITF1_3f.EnabledFullHiragana = False
        Me.txtITF1_3f.EnabledFullKatakana = False
        Me.txtITF1_3f.EnabledFullNumber = False
        Me.txtITF1_3f.EnabledHalf = True
        Me.txtITF1_3f.EnabledHalfAlphabetLower = True
        Me.txtITF1_3f.EnabledHalfAlphabetUpper = True
        Me.txtITF1_3f.EnabledHalfKatakana = True
        Me.txtITF1_3f.EnabledHalfNumber = True
        Me.txtITF1_3f.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF1_3f.Location = New System.Drawing.Point(269, 370)
        Me.txtITF1_3f.MaxLength = 8
        Me.txtITF1_3f.MaxLengthByte = 0
        Me.txtITF1_3f.Name = "txtITF1_3f"
        Me.txtITF1_3f.RegexCustomFalse = Nothing
        Me.txtITF1_3f.RegexCustomTrue = Nothing
        Me.txtITF1_3f.Size = New System.Drawing.Size(70, 26)
        Me.txtITF1_3f.TabIndex = 234
        Me.txtITF1_3f.Visible = False
        '
        'txtITF1_4f
        '
        Me.txtITF1_4f.BackColor = System.Drawing.Color.White
        Me.txtITF1_4f.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF1_4f.EnabledFull = True
        Me.txtITF1_4f.EnabledFullAlphabetLower = False
        Me.txtITF1_4f.EnabledFullAlphabetUpper = False
        Me.txtITF1_4f.EnabledFullHiragana = False
        Me.txtITF1_4f.EnabledFullKatakana = False
        Me.txtITF1_4f.EnabledFullNumber = False
        Me.txtITF1_4f.EnabledHalf = True
        Me.txtITF1_4f.EnabledHalfAlphabetLower = True
        Me.txtITF1_4f.EnabledHalfAlphabetUpper = True
        Me.txtITF1_4f.EnabledHalfKatakana = True
        Me.txtITF1_4f.EnabledHalfNumber = True
        Me.txtITF1_4f.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF1_4f.Location = New System.Drawing.Point(192, 370)
        Me.txtITF1_4f.MaxLength = 8
        Me.txtITF1_4f.MaxLengthByte = 0
        Me.txtITF1_4f.Name = "txtITF1_4f"
        Me.txtITF1_4f.RegexCustomFalse = Nothing
        Me.txtITF1_4f.RegexCustomTrue = Nothing
        Me.txtITF1_4f.Size = New System.Drawing.Size(69, 26)
        Me.txtITF1_4f.TabIndex = 233
        Me.txtITF1_4f.Visible = False
        '
        'CmpMTextBoxString2
        '
        Me.CmpMTextBoxString2.BackColor = System.Drawing.Color.White
        Me.CmpMTextBoxString2.BackColorMask = System.Drawing.Color.Empty
        Me.CmpMTextBoxString2.EnabledFull = True
        Me.CmpMTextBoxString2.EnabledFullAlphabetLower = False
        Me.CmpMTextBoxString2.EnabledFullAlphabetUpper = False
        Me.CmpMTextBoxString2.EnabledFullHiragana = False
        Me.CmpMTextBoxString2.EnabledFullKatakana = False
        Me.CmpMTextBoxString2.EnabledFullNumber = False
        Me.CmpMTextBoxString2.EnabledHalf = True
        Me.CmpMTextBoxString2.EnabledHalfAlphabetLower = True
        Me.CmpMTextBoxString2.EnabledHalfAlphabetUpper = True
        Me.CmpMTextBoxString2.EnabledHalfKatakana = True
        Me.CmpMTextBoxString2.EnabledHalfNumber = True
        Me.CmpMTextBoxString2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmpMTextBoxString2.Location = New System.Drawing.Point(518, 402)
        Me.CmpMTextBoxString2.MaxLength = 8
        Me.CmpMTextBoxString2.MaxLengthByte = 0
        Me.CmpMTextBoxString2.Name = "CmpMTextBoxString2"
        Me.CmpMTextBoxString2.RegexCustomFalse = Nothing
        Me.CmpMTextBoxString2.RegexCustomTrue = Nothing
        Me.CmpMTextBoxString2.Size = New System.Drawing.Size(101, 26)
        Me.CmpMTextBoxString2.TabIndex = 242
        Me.CmpMTextBoxString2.Visible = False
        '
        'txtITF2_1f
        '
        Me.txtITF2_1f.BackColor = System.Drawing.Color.White
        Me.txtITF2_1f.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF2_1f.EnabledFull = True
        Me.txtITF2_1f.EnabledFullAlphabetLower = False
        Me.txtITF2_1f.EnabledFullAlphabetUpper = False
        Me.txtITF2_1f.EnabledFullHiragana = False
        Me.txtITF2_1f.EnabledFullKatakana = False
        Me.txtITF2_1f.EnabledFullNumber = False
        Me.txtITF2_1f.EnabledHalf = True
        Me.txtITF2_1f.EnabledHalfAlphabetLower = True
        Me.txtITF2_1f.EnabledHalfAlphabetUpper = True
        Me.txtITF2_1f.EnabledHalfKatakana = True
        Me.txtITF2_1f.EnabledHalfNumber = True
        Me.txtITF2_1f.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF2_1f.Location = New System.Drawing.Point(425, 402)
        Me.txtITF2_1f.MaxLength = 8
        Me.txtITF2_1f.MaxLengthByte = 0
        Me.txtITF2_1f.Name = "txtITF2_1f"
        Me.txtITF2_1f.RegexCustomFalse = Nothing
        Me.txtITF2_1f.RegexCustomTrue = Nothing
        Me.txtITF2_1f.Size = New System.Drawing.Size(66, 26)
        Me.txtITF2_1f.TabIndex = 241
        Me.txtITF2_1f.Visible = False
        '
        'txtITF2_2f
        '
        Me.txtITF2_2f.BackColor = System.Drawing.Color.White
        Me.txtITF2_2f.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF2_2f.EnabledFull = True
        Me.txtITF2_2f.EnabledFullAlphabetLower = False
        Me.txtITF2_2f.EnabledFullAlphabetUpper = False
        Me.txtITF2_2f.EnabledFullHiragana = False
        Me.txtITF2_2f.EnabledFullKatakana = False
        Me.txtITF2_2f.EnabledFullNumber = False
        Me.txtITF2_2f.EnabledHalf = True
        Me.txtITF2_2f.EnabledHalfAlphabetLower = True
        Me.txtITF2_2f.EnabledHalfAlphabetUpper = True
        Me.txtITF2_2f.EnabledHalfKatakana = True
        Me.txtITF2_2f.EnabledHalfNumber = True
        Me.txtITF2_2f.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF2_2f.Location = New System.Drawing.Point(347, 402)
        Me.txtITF2_2f.MaxLength = 8
        Me.txtITF2_2f.MaxLengthByte = 0
        Me.txtITF2_2f.Name = "txtITF2_2f"
        Me.txtITF2_2f.RegexCustomFalse = Nothing
        Me.txtITF2_2f.RegexCustomTrue = Nothing
        Me.txtITF2_2f.Size = New System.Drawing.Size(70, 26)
        Me.txtITF2_2f.TabIndex = 240
        Me.txtITF2_2f.Visible = False
        '
        'txtITF2_3f
        '
        Me.txtITF2_3f.BackColor = System.Drawing.Color.White
        Me.txtITF2_3f.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF2_3f.EnabledFull = True
        Me.txtITF2_3f.EnabledFullAlphabetLower = False
        Me.txtITF2_3f.EnabledFullAlphabetUpper = False
        Me.txtITF2_3f.EnabledFullHiragana = False
        Me.txtITF2_3f.EnabledFullKatakana = False
        Me.txtITF2_3f.EnabledFullNumber = False
        Me.txtITF2_3f.EnabledHalf = True
        Me.txtITF2_3f.EnabledHalfAlphabetLower = True
        Me.txtITF2_3f.EnabledHalfAlphabetUpper = True
        Me.txtITF2_3f.EnabledHalfKatakana = True
        Me.txtITF2_3f.EnabledHalfNumber = True
        Me.txtITF2_3f.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF2_3f.Location = New System.Drawing.Point(269, 402)
        Me.txtITF2_3f.MaxLength = 8
        Me.txtITF2_3f.MaxLengthByte = 0
        Me.txtITF2_3f.Name = "txtITF2_3f"
        Me.txtITF2_3f.RegexCustomFalse = Nothing
        Me.txtITF2_3f.RegexCustomTrue = Nothing
        Me.txtITF2_3f.Size = New System.Drawing.Size(70, 26)
        Me.txtITF2_3f.TabIndex = 239
        Me.txtITF2_3f.Visible = False
        '
        'txtITF2_4f
        '
        Me.txtITF2_4f.BackColor = System.Drawing.Color.White
        Me.txtITF2_4f.BackColorMask = System.Drawing.Color.Empty
        Me.txtITF2_4f.EnabledFull = True
        Me.txtITF2_4f.EnabledFullAlphabetLower = False
        Me.txtITF2_4f.EnabledFullAlphabetUpper = False
        Me.txtITF2_4f.EnabledFullHiragana = False
        Me.txtITF2_4f.EnabledFullKatakana = False
        Me.txtITF2_4f.EnabledFullNumber = False
        Me.txtITF2_4f.EnabledHalf = True
        Me.txtITF2_4f.EnabledHalfAlphabetLower = True
        Me.txtITF2_4f.EnabledHalfAlphabetUpper = True
        Me.txtITF2_4f.EnabledHalfKatakana = True
        Me.txtITF2_4f.EnabledHalfNumber = True
        Me.txtITF2_4f.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtITF2_4f.Location = New System.Drawing.Point(192, 402)
        Me.txtITF2_4f.MaxLength = 8
        Me.txtITF2_4f.MaxLengthByte = 0
        Me.txtITF2_4f.Name = "txtITF2_4f"
        Me.txtITF2_4f.RegexCustomFalse = Nothing
        Me.txtITF2_4f.RegexCustomTrue = Nothing
        Me.txtITF2_4f.Size = New System.Drawing.Size(69, 26)
        Me.txtITF2_4f.TabIndex = 238
        Me.txtITF2_4f.Visible = False
        '
        'FRM_307150
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.CmpMTextBoxString2)
        Me.Controls.Add(Me.txtITF2_1f)
        Me.Controls.Add(Me.txtITF2_2f)
        Me.Controls.Add(Me.txtITF2_3f)
        Me.Controls.Add(Me.txtITF2_4f)
        Me.Controls.Add(Me.CmpMTextBoxString1)
        Me.Controls.Add(Me.txtITF1_1f)
        Me.Controls.Add(Me.txtITF1_2f)
        Me.Controls.Add(Me.txtITF1_3f)
        Me.Controls.Add(Me.txtITF1_4f)
        Me.Controls.Add(Me.CmpMTextBoxString6)
        Me.Controls.Add(Me.txtITF2_1)
        Me.Controls.Add(Me.txtITF2_2)
        Me.Controls.Add(Me.txtITF2_3)
        Me.Controls.Add(Me.txtITF2_4)
        Me.Controls.Add(Me.txtList02)
        Me.Controls.Add(Me.txtList01)
        Me.Controls.Add(Me.CmpMTextBoxString4)
        Me.Controls.Add(Me.txtITF1_1)
        Me.Controls.Add(Me.txtITF1_2)
        Me.Controls.Add(Me.txtITF1_3)
        Me.Controls.Add(Me.txtITF1_4)
        Me.Controls.Add(Me.cmdRegistration)
        Me.Controls.Add(Me.cmdRedisplay)
        Me.Controls.Add(Me.grdList02)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblGET_Time)
        Me.Controls.Add(Me.grdList01)
        Me.Name = "FRM_307150"
        Me.Controls.SetChildIndex(Me.grdList01, 0)
        Me.Controls.SetChildIndex(Me.lblGET_Time, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.grdList02, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.cmdRedisplay, 0)
        Me.Controls.SetChildIndex(Me.cmdRegistration, 0)
        Me.Controls.SetChildIndex(Me.txtITF1_4, 0)
        Me.Controls.SetChildIndex(Me.txtITF1_3, 0)
        Me.Controls.SetChildIndex(Me.txtITF1_2, 0)
        Me.Controls.SetChildIndex(Me.txtITF1_1, 0)
        Me.Controls.SetChildIndex(Me.CmpMTextBoxString4, 0)
        Me.Controls.SetChildIndex(Me.txtList01, 0)
        Me.Controls.SetChildIndex(Me.txtList02, 0)
        Me.Controls.SetChildIndex(Me.txtITF2_4, 0)
        Me.Controls.SetChildIndex(Me.txtITF2_3, 0)
        Me.Controls.SetChildIndex(Me.txtITF2_2, 0)
        Me.Controls.SetChildIndex(Me.txtITF2_1, 0)
        Me.Controls.SetChildIndex(Me.CmpMTextBoxString6, 0)
        Me.Controls.SetChildIndex(Me.txtITF1_4f, 0)
        Me.Controls.SetChildIndex(Me.txtITF1_3f, 0)
        Me.Controls.SetChildIndex(Me.txtITF1_2f, 0)
        Me.Controls.SetChildIndex(Me.txtITF1_1f, 0)
        Me.Controls.SetChildIndex(Me.CmpMTextBoxString1, 0)
        Me.Controls.SetChildIndex(Me.txtITF2_4f, 0)
        Me.Controls.SetChildIndex(Me.txtITF2_3f, 0)
        Me.Controls.SetChildIndex(Me.txtITF2_2f, 0)
        Me.Controls.SetChildIndex(Me.txtITF2_1f, 0)
        Me.Controls.SetChildIndex(Me.CmpMTextBoxString2, 0)
        CType(Me.grdList01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmr307150 As System.Windows.Forms.Timer
    Friend WithEvents grdList01 As GamenCommon.cmpMDataGrid
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblGET_Time As System.Windows.Forms.Label
    Friend WithEvents grdList02 As GamenCommon.cmpMDataGrid
    Friend WithEvents cmdRedisplay As System.Windows.Forms.Button
    Friend WithEvents cmdRegistration As System.Windows.Forms.Button
    Friend WithEvents txtITF1_4 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF1_3 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF1_2 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF1_1 As MateCommon.cmpMTextBoxString
    Friend WithEvents CmpMTextBoxString4 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtList01 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtList02 As MateCommon.cmpMTextBoxString
    Friend WithEvents CmpMTextBoxString6 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF2_1 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF2_2 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF2_3 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF2_4 As MateCommon.cmpMTextBoxString
    Friend WithEvents CmpMTextBoxString1 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF1_1f As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF1_2f As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF1_3f As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF1_4f As MateCommon.cmpMTextBoxString
    Friend WithEvents CmpMTextBoxString2 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF2_1f As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF2_2f As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF2_3f As MateCommon.cmpMTextBoxString
    Friend WithEvents txtITF2_4f As MateCommon.cmpMTextBoxString

End Class
