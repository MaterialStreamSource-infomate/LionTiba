<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_311020
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtHenseiNo4 = New MateCommon.cmpMTextBoxString
        Me.txtHenseiNo3 = New MateCommon.cmpMTextBoxString
        Me.txtHenseiNo2 = New MateCommon.cmpMTextBoxString
        Me.txtHenseiNo1 = New MateCommon.cmpMTextBoxString
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdTumiHouhou3 = New System.Windows.Forms.Button
        Me.cmdTumiHouhou2 = New System.Windows.Forms.Button
        Me.cmdTumiHouhou1 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdTumiHoukou3 = New System.Windows.Forms.Button
        Me.cmdTumiHoukou2 = New System.Windows.Forms.Button
        Me.cmdTumiHoukou1 = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmdTouroku = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.cmdKettei = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmd9 = New System.Windows.Forms.Button
        Me.cmd8 = New System.Windows.Forms.Button
        Me.cmd7 = New System.Windows.Forms.Button
        Me.cmd6 = New System.Windows.Forms.Button
        Me.cmd5 = New System.Windows.Forms.Button
        Me.cmd4 = New System.Windows.Forms.Button
        Me.cmd3 = New System.Windows.Forms.Button
        Me.cmd2 = New System.Windows.Forms.Button
        Me.cmd1 = New System.Windows.Forms.Button
        Me.cmd0 = New System.Windows.Forms.Button
        Me.txtSyaryouNo = New MateCommon.cmpMTextBoxString
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(1138, 374)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSyaryouNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(168, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 140)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "1.車輌番号を入力してください。"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(492, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "ナンバープレートの数字４桁を入力してください。"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtHenseiNo4)
        Me.GroupBox2.Controls.Add(Me.txtHenseiNo3)
        Me.GroupBox2.Controls.Add(Me.txtHenseiNo2)
        Me.GroupBox2.Controls.Add(Me.txtHenseiNo1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(168, 243)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 140)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "２.編成番号を入力してください。"
        '
        'txtHenseiNo4
        '
        Me.txtHenseiNo4.BackColorMask = System.Drawing.Color.Empty
        Me.txtHenseiNo4.EnabledFull = False
        Me.txtHenseiNo4.EnabledFullAlphabetLower = False
        Me.txtHenseiNo4.EnabledFullAlphabetUpper = False
        Me.txtHenseiNo4.EnabledFullHiragana = False
        Me.txtHenseiNo4.EnabledFullKatakana = False
        Me.txtHenseiNo4.EnabledFullNumber = False
        Me.txtHenseiNo4.EnabledHalf = True
        Me.txtHenseiNo4.EnabledHalfAlphabetLower = False
        Me.txtHenseiNo4.EnabledHalfAlphabetUpper = False
        Me.txtHenseiNo4.EnabledHalfKatakana = False
        Me.txtHenseiNo4.EnabledHalfNumber = True
        Me.txtHenseiNo4.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Bold)
        Me.txtHenseiNo4.Location = New System.Drawing.Point(417, 47)
        Me.txtHenseiNo4.MaxLength = 4
        Me.txtHenseiNo4.MaxLengthByte = 0
        Me.txtHenseiNo4.Name = "txtHenseiNo4"
        Me.txtHenseiNo4.RegexCustomFalse = Nothing
        Me.txtHenseiNo4.RegexCustomTrue = Nothing
        Me.txtHenseiNo4.Size = New System.Drawing.Size(109, 39)
        Me.txtHenseiNo4.TabIndex = 7
        Me.txtHenseiNo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHenseiNo3
        '
        Me.txtHenseiNo3.BackColorMask = System.Drawing.Color.Empty
        Me.txtHenseiNo3.EnabledFull = False
        Me.txtHenseiNo3.EnabledFullAlphabetLower = False
        Me.txtHenseiNo3.EnabledFullAlphabetUpper = False
        Me.txtHenseiNo3.EnabledFullHiragana = False
        Me.txtHenseiNo3.EnabledFullKatakana = False
        Me.txtHenseiNo3.EnabledFullNumber = False
        Me.txtHenseiNo3.EnabledHalf = True
        Me.txtHenseiNo3.EnabledHalfAlphabetLower = False
        Me.txtHenseiNo3.EnabledHalfAlphabetUpper = False
        Me.txtHenseiNo3.EnabledHalfKatakana = False
        Me.txtHenseiNo3.EnabledHalfNumber = True
        Me.txtHenseiNo3.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Bold)
        Me.txtHenseiNo3.Location = New System.Drawing.Point(295, 47)
        Me.txtHenseiNo3.MaxLength = 4
        Me.txtHenseiNo3.MaxLengthByte = 0
        Me.txtHenseiNo3.Name = "txtHenseiNo3"
        Me.txtHenseiNo3.RegexCustomFalse = Nothing
        Me.txtHenseiNo3.RegexCustomTrue = Nothing
        Me.txtHenseiNo3.Size = New System.Drawing.Size(109, 39)
        Me.txtHenseiNo3.TabIndex = 6
        Me.txtHenseiNo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHenseiNo2
        '
        Me.txtHenseiNo2.BackColorMask = System.Drawing.Color.Empty
        Me.txtHenseiNo2.EnabledFull = False
        Me.txtHenseiNo2.EnabledFullAlphabetLower = False
        Me.txtHenseiNo2.EnabledFullAlphabetUpper = False
        Me.txtHenseiNo2.EnabledFullHiragana = False
        Me.txtHenseiNo2.EnabledFullKatakana = False
        Me.txtHenseiNo2.EnabledFullNumber = False
        Me.txtHenseiNo2.EnabledHalf = True
        Me.txtHenseiNo2.EnabledHalfAlphabetLower = False
        Me.txtHenseiNo2.EnabledHalfAlphabetUpper = False
        Me.txtHenseiNo2.EnabledHalfKatakana = False
        Me.txtHenseiNo2.EnabledHalfNumber = True
        Me.txtHenseiNo2.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Bold)
        Me.txtHenseiNo2.Location = New System.Drawing.Point(173, 47)
        Me.txtHenseiNo2.MaxLength = 4
        Me.txtHenseiNo2.MaxLengthByte = 0
        Me.txtHenseiNo2.Name = "txtHenseiNo2"
        Me.txtHenseiNo2.RegexCustomFalse = Nothing
        Me.txtHenseiNo2.RegexCustomTrue = Nothing
        Me.txtHenseiNo2.Size = New System.Drawing.Size(109, 39)
        Me.txtHenseiNo2.TabIndex = 5
        Me.txtHenseiNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHenseiNo1
        '
        Me.txtHenseiNo1.BackColorMask = System.Drawing.Color.Empty
        Me.txtHenseiNo1.EnabledFull = False
        Me.txtHenseiNo1.EnabledFullAlphabetLower = False
        Me.txtHenseiNo1.EnabledFullAlphabetUpper = False
        Me.txtHenseiNo1.EnabledFullHiragana = False
        Me.txtHenseiNo1.EnabledFullKatakana = False
        Me.txtHenseiNo1.EnabledFullNumber = False
        Me.txtHenseiNo1.EnabledHalf = True
        Me.txtHenseiNo1.EnabledHalfAlphabetLower = False
        Me.txtHenseiNo1.EnabledHalfAlphabetUpper = False
        Me.txtHenseiNo1.EnabledHalfKatakana = False
        Me.txtHenseiNo1.EnabledHalfNumber = True
        Me.txtHenseiNo1.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Bold)
        Me.txtHenseiNo1.Location = New System.Drawing.Point(50, 47)
        Me.txtHenseiNo1.MaxLength = 4
        Me.txtHenseiNo1.MaxLengthByte = 0
        Me.txtHenseiNo1.Name = "txtHenseiNo1"
        Me.txtHenseiNo1.RegexCustomFalse = Nothing
        Me.txtHenseiNo1.RegexCustomTrue = Nothing
        Me.txtHenseiNo1.Size = New System.Drawing.Size(109, 39)
        Me.txtHenseiNo1.TabIndex = 1
        Me.txtHenseiNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(451, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "４桁の番号を入力してください。(最大４伝票)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdTumiHouhou3)
        Me.GroupBox3.Controls.Add(Me.cmdTumiHouhou2)
        Me.GroupBox3.Controls.Add(Me.cmdTumiHouhou1)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(168, 394)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(568, 140)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "３.積込方法を選択してください。"
        '
        'cmdTumiHouhou3
        '
        Me.cmdTumiHouhou3.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTumiHouhou3.Location = New System.Drawing.Point(378, 65)
        Me.cmdTumiHouhou3.Name = "cmdTumiHouhou3"
        Me.cmdTumiHouhou3.Size = New System.Drawing.Size(183, 56)
        Me.cmdTumiHouhou3.TabIndex = 2
        Me.cmdTumiHouhou3.Text = "パレット積"
        Me.cmdTumiHouhou3.UseVisualStyleBackColor = True
        '
        'cmdTumiHouhou2
        '
        Me.cmdTumiHouhou2.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTumiHouhou2.Location = New System.Drawing.Point(192, 65)
        Me.cmdTumiHouhou2.Name = "cmdTumiHouhou2"
        Me.cmdTumiHouhou2.Size = New System.Drawing.Size(183, 56)
        Me.cmdTumiHouhou2.TabIndex = 1
        Me.cmdTumiHouhou2.Text = "バラ積"
        Me.cmdTumiHouhou2.UseVisualStyleBackColor = True
        '
        'cmdTumiHouhou1
        '
        Me.cmdTumiHouhou1.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTumiHouhou1.Location = New System.Drawing.Point(6, 65)
        Me.cmdTumiHouhou1.Name = "cmdTumiHouhou1"
        Me.cmdTumiHouhou1.Size = New System.Drawing.Size(183, 56)
        Me.cmdTumiHouhou1.TabIndex = 0
        Me.cmdTumiHouhou1.Text = "ローダ"
        Me.cmdTumiHouhou1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdTumiHoukou3)
        Me.GroupBox4.Controls.Add(Me.cmdTumiHoukou2)
        Me.GroupBox4.Controls.Add(Me.cmdTumiHoukou1)
        Me.GroupBox4.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(169, 548)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(568, 140)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "４.積込方向を選択してください。"
        '
        'cmdTumiHoukou3
        '
        Me.cmdTumiHoukou3.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTumiHoukou3.Location = New System.Drawing.Point(377, 65)
        Me.cmdTumiHoukou3.Name = "cmdTumiHoukou3"
        Me.cmdTumiHoukou3.Size = New System.Drawing.Size(183, 56)
        Me.cmdTumiHoukou3.TabIndex = 2
        Me.cmdTumiHoukou3.Text = "両横積"
        Me.cmdTumiHoukou3.UseVisualStyleBackColor = True
        '
        'cmdTumiHoukou2
        '
        Me.cmdTumiHoukou2.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTumiHoukou2.Location = New System.Drawing.Point(191, 65)
        Me.cmdTumiHoukou2.Name = "cmdTumiHoukou2"
        Me.cmdTumiHoukou2.Size = New System.Drawing.Size(183, 56)
        Me.cmdTumiHoukou2.TabIndex = 1
        Me.cmdTumiHoukou2.Text = "片横積"
        Me.cmdTumiHoukou2.UseVisualStyleBackColor = True
        '
        'cmdTumiHoukou1
        '
        Me.cmdTumiHoukou1.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTumiHoukou1.Location = New System.Drawing.Point(5, 65)
        Me.cmdTumiHoukou1.Name = "cmdTumiHoukou1"
        Me.cmdTumiHoukou1.Size = New System.Drawing.Size(183, 56)
        Me.cmdTumiHoukou1.TabIndex = 0
        Me.cmdTumiHoukou1.Text = "後積"
        Me.cmdTumiHoukou1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdTouroku)
        Me.GroupBox5.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(768, 548)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(439, 140)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "５.登録ボタンを押して下さい。"
        '
        'cmdTouroku
        '
        Me.cmdTouroku.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTouroku.Location = New System.Drawing.Point(51, 66)
        Me.cmdTouroku.Name = "cmdTouroku"
        Me.cmdTouroku.Size = New System.Drawing.Size(336, 56)
        Me.cmdTouroku.TabIndex = 0
        Me.cmdTouroku.Text = "登録"
        Me.cmdTouroku.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmdKettei)
        Me.GroupBox6.Controls.Add(Me.cmdClear)
        Me.GroupBox6.Controls.Add(Me.cmd9)
        Me.GroupBox6.Controls.Add(Me.cmd8)
        Me.GroupBox6.Controls.Add(Me.cmd7)
        Me.GroupBox6.Controls.Add(Me.cmd6)
        Me.GroupBox6.Controls.Add(Me.cmd5)
        Me.GroupBox6.Controls.Add(Me.cmd4)
        Me.GroupBox6.Controls.Add(Me.cmd3)
        Me.GroupBox6.Controls.Add(Me.cmd2)
        Me.GroupBox6.Controls.Add(Me.cmd1)
        Me.GroupBox6.Controls.Add(Me.cmd0)
        Me.GroupBox6.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(768, 92)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(439, 442)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        '
        'cmdKettei
        '
        Me.cmdKettei.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKettei.Location = New System.Drawing.Point(258, 183)
        Me.cmdKettei.Name = "cmdKettei"
        Me.cmdKettei.Size = New System.Drawing.Size(160, 240)
        Me.cmdKettei.TabIndex = 10
        Me.cmdKettei.Text = "決定"
        Me.cmdKettei.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(258, 103)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(160, 80)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "クリア"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmd9
        '
        Me.cmd9.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd9.Location = New System.Drawing.Point(178, 103)
        Me.cmd9.Name = "cmd9"
        Me.cmd9.Size = New System.Drawing.Size(80, 80)
        Me.cmd9.TabIndex = 9
        Me.cmd9.Text = "9"
        Me.cmd9.UseVisualStyleBackColor = True
        '
        'cmd8
        '
        Me.cmd8.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd8.Location = New System.Drawing.Point(98, 103)
        Me.cmd8.Name = "cmd8"
        Me.cmd8.Size = New System.Drawing.Size(80, 80)
        Me.cmd8.TabIndex = 8
        Me.cmd8.Text = "8"
        Me.cmd8.UseVisualStyleBackColor = True
        '
        'cmd7
        '
        Me.cmd7.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd7.Location = New System.Drawing.Point(18, 103)
        Me.cmd7.Name = "cmd7"
        Me.cmd7.Size = New System.Drawing.Size(80, 80)
        Me.cmd7.TabIndex = 7
        Me.cmd7.Text = "7"
        Me.cmd7.UseVisualStyleBackColor = True
        '
        'cmd6
        '
        Me.cmd6.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd6.Location = New System.Drawing.Point(178, 183)
        Me.cmd6.Name = "cmd6"
        Me.cmd6.Size = New System.Drawing.Size(80, 80)
        Me.cmd6.TabIndex = 6
        Me.cmd6.Text = "6"
        Me.cmd6.UseVisualStyleBackColor = True
        '
        'cmd5
        '
        Me.cmd5.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd5.Location = New System.Drawing.Point(98, 183)
        Me.cmd5.Name = "cmd5"
        Me.cmd5.Size = New System.Drawing.Size(80, 80)
        Me.cmd5.TabIndex = 5
        Me.cmd5.Text = "5"
        Me.cmd5.UseVisualStyleBackColor = True
        '
        'cmd4
        '
        Me.cmd4.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd4.Location = New System.Drawing.Point(18, 183)
        Me.cmd4.Name = "cmd4"
        Me.cmd4.Size = New System.Drawing.Size(80, 80)
        Me.cmd4.TabIndex = 4
        Me.cmd4.Text = "4"
        Me.cmd4.UseVisualStyleBackColor = True
        '
        'cmd3
        '
        Me.cmd3.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd3.Location = New System.Drawing.Point(178, 263)
        Me.cmd3.Name = "cmd3"
        Me.cmd3.Size = New System.Drawing.Size(80, 80)
        Me.cmd3.TabIndex = 3
        Me.cmd3.Text = "3"
        Me.cmd3.UseVisualStyleBackColor = True
        '
        'cmd2
        '
        Me.cmd2.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd2.Location = New System.Drawing.Point(98, 263)
        Me.cmd2.Name = "cmd2"
        Me.cmd2.Size = New System.Drawing.Size(80, 80)
        Me.cmd2.TabIndex = 2
        Me.cmd2.Text = "2"
        Me.cmd2.UseVisualStyleBackColor = True
        '
        'cmd1
        '
        Me.cmd1.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd1.Location = New System.Drawing.Point(18, 263)
        Me.cmd1.Name = "cmd1"
        Me.cmd1.Size = New System.Drawing.Size(80, 80)
        Me.cmd1.TabIndex = 1
        Me.cmd1.Text = "1"
        Me.cmd1.UseVisualStyleBackColor = True
        '
        'cmd0
        '
        Me.cmd0.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd0.Location = New System.Drawing.Point(18, 343)
        Me.cmd0.Name = "cmd0"
        Me.cmd0.Size = New System.Drawing.Size(240, 80)
        Me.cmd0.TabIndex = 0
        Me.cmd0.Text = "0"
        Me.cmd0.UseVisualStyleBackColor = True
        '
        'txtSyaryouNo
        '
        Me.txtSyaryouNo.BackColorMask = System.Drawing.Color.Empty
        Me.txtSyaryouNo.EnabledFull = False
        Me.txtSyaryouNo.EnabledFullAlphabetLower = False
        Me.txtSyaryouNo.EnabledFullAlphabetUpper = False
        Me.txtSyaryouNo.EnabledFullHiragana = False
        Me.txtSyaryouNo.EnabledFullKatakana = False
        Me.txtSyaryouNo.EnabledFullNumber = False
        Me.txtSyaryouNo.EnabledHalf = True
        Me.txtSyaryouNo.EnabledHalfAlphabetLower = False
        Me.txtSyaryouNo.EnabledHalfAlphabetUpper = False
        Me.txtSyaryouNo.EnabledHalfKatakana = False
        Me.txtSyaryouNo.EnabledHalfNumber = True
        Me.txtSyaryouNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 24.0!, System.Drawing.FontStyle.Bold)
        Me.txtSyaryouNo.Location = New System.Drawing.Point(231, 47)
        Me.txtSyaryouNo.MaxLength = 4
        Me.txtSyaryouNo.MaxLengthByte = 0
        Me.txtSyaryouNo.Name = "txtSyaryouNo"
        Me.txtSyaryouNo.RegexCustomFalse = Nothing
        Me.txtSyaryouNo.RegexCustomTrue = Nothing
        Me.txtSyaryouNo.Size = New System.Drawing.Size(109, 39)
        Me.txtSyaryouNo.TabIndex = 5
        Me.txtSyaryouNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FRM_311020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1278, 766)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_311020"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.Controls.SetChildIndex(Me.cmdF1, 0)
        Me.Controls.SetChildIndex(Me.cmdF2, 0)
        Me.Controls.SetChildIndex(Me.cmdF3, 0)
        Me.Controls.SetChildIndex(Me.cmdF4, 0)
        Me.Controls.SetChildIndex(Me.cmdF5, 0)
        Me.Controls.SetChildIndex(Me.cmdF6, 0)
        Me.Controls.SetChildIndex(Me.cmdF7, 0)
        Me.Controls.SetChildIndex(Me.cmdF8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox5, 0)
        Me.Controls.SetChildIndex(Me.GroupBox6, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdTumiHouhou1 As System.Windows.Forms.Button
    Friend WithEvents cmdTumiHouhou3 As System.Windows.Forms.Button
    Friend WithEvents cmdTumiHouhou2 As System.Windows.Forms.Button
    Friend WithEvents cmdTumiHoukou3 As System.Windows.Forms.Button
    Friend WithEvents cmdTumiHoukou2 As System.Windows.Forms.Button
    Friend WithEvents cmdTumiHoukou1 As System.Windows.Forms.Button
    Friend WithEvents cmdTouroku As System.Windows.Forms.Button
    Friend WithEvents cmd0 As System.Windows.Forms.Button
    Friend WithEvents cmdKettei As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmd9 As System.Windows.Forms.Button
    Friend WithEvents cmd8 As System.Windows.Forms.Button
    Friend WithEvents cmd7 As System.Windows.Forms.Button
    Friend WithEvents cmd6 As System.Windows.Forms.Button
    Friend WithEvents cmd5 As System.Windows.Forms.Button
    Friend WithEvents cmd4 As System.Windows.Forms.Button
    Friend WithEvents cmd3 As System.Windows.Forms.Button
    Friend WithEvents cmd2 As System.Windows.Forms.Button
    Friend WithEvents cmd1 As System.Windows.Forms.Button
    Friend WithEvents txtHenseiNo1 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtHenseiNo4 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtHenseiNo3 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtHenseiNo2 As MateCommon.cmpMTextBoxString
    Friend WithEvents txtSyaryouNo As MateCommon.cmpMTextBoxString

End Class
