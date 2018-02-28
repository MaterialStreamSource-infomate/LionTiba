Public Class frmMelsecTool
    Private mobjMelsec As ComMelsec.clsMelsec           'Melsec通信ｸﾗｽ

    Private Sub FrmToolPLC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'レジスタ区分コンボボックス
        cboDevi.Items.Clear()
        cboDevi.Items.Add("D")

        '書き込みボタンをマスク
        btnConn.Enabled = True
        btnSlct.Enabled = False
        btnRead.Enabled = False
        btnWrite.Enabled = False

        '定周期読み込み間隔(1秒)
        tmrTimer.Interval = 1000
        tmrTimer.Enabled = False
        tmrTimer.Stop()

    End Sub

    Private Sub btnConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConn.Click
        Try
            If (mobjMelsec Is Nothing) = False Then
                mobjMelsec.Close()
                mobjMelsec = Nothing
            End If
            mobjMelsec = New ComMelsec.clsMelsec(Me)                        'Melsec通信ｸﾗｽ
            mobjMelsec.strSockMelSendAddress = txtAdrs.Text                'PLC側IPｱﾄﾞﾚｽ
            mobjMelsec.intSockMelSendPort = txtPort.Text                   'PLC側ﾎﾟｰﾄNo.
            mobjMelsec.intACPUTimer = 2560                                  'CPU監視ﾀｲﾏ(250ms単位:自局のと通信の場合"0001"～"0040"(0.25秒～10秒))
            mobjMelsec.intDebugFlag = 1                                     'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
            mobjMelsec.intSockRetry = 3                                     'ﾘﾄﾗｲ回数(回)
            mobjMelsec.intSockTimeOut = 10                                  'ﾀｲﾑｱｳﾄ時間(秒)(自局:1～10秒、他局:1～60秒)
            mobjMelsec.Open()                                               'ｵｰﾌﾟﾝ

            btnConn.Enabled = False
            txtAdrs.Enabled = False
            txtPort.Enabled = False
            btnSlct.Enabled = True
            btnRead.Enabled = False
            btnWrite.Enabled = False
        Catch ex As Exception
            mobjMelsec = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSlct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlct.Click
        objGrid.ResetBindings()
        objGrid.TableStyles.Clear()

        Dim dataSet1 As New DataSet("DevList")
        Dim dataTable1 As DataTable = dataSet1.Tables.Add("DevTable")
        Dim dataClumn2 As DataColumn = dataTable1.Columns.Add("Device")
        Dim dataClumn3 As DataColumn = dataTable1.Columns.Add("Value", GetType(Integer))

        ' 書込み禁止設定
        dataTable1.Columns(0).ReadOnly = True

        Dim dgTableStyle As New DataGridTableStyle
        dgTableStyle.MappingName = dataTable1.TableName
        objGrid.TableStyles.Add(dgTableStyle)

        'テーブルの列のスタイルを作成
        Dim dgColumnStyle1 As New DataGridTextBoxColumn
        Dim dgColumnStyle2 As New DataGridTextBoxColumn
        Dim dgColumnStyle3 As New DataGridTextBoxColumn

        dgColumnStyle2.MappingName = dataClumn2.ColumnName
        dgColumnStyle3.MappingName = dataClumn3.ColumnName

        '*** 列の幅を決定 ***
        dgColumnStyle2.Width = 66
        dgColumnStyle3.Width = 90

        '列のスタイルをテーブル・スタイルに登録
        dgTableStyle.GridColumnStyles.Clear()
        CType(dgTableStyle, System.Windows.Forms.DataGridTableStyle).RowHeadersVisible = False
        CType(dgTableStyle, System.Windows.Forms.DataGridTableStyle).ColumnHeadersVisible = False
        dgTableStyle.GridColumnStyles.Add(dgColumnStyle2)
        dgTableStyle.GridColumnStyles.Add(dgColumnStyle3)

        ' テーブルにデータを追加
        For i As Integer = 0 To Val(txtDevC.Text) - 1
            Dim strWrk As String
            strWrk = cboDevi.Text & ZeroSppr(5, Val(txtDevN.Text) + i)
            dataTable1.Rows.Add(New [Object]() {strWrk, 0})
        Next

        '追加＆削除　禁止
        dataTable1.DefaultView.AllowNew = False
        dataTable1.DefaultView.AllowDelete = False

        ' データグリッドにテーブルを表示する（データソースにDataViewを使う）
        objGrid.CaptionVisible = False
        objGrid.RowHeadersVisible = False
        objGrid.ColumnHeadersVisible = False
        objGrid.SetDataBinding(dataTable1.DefaultView, "")

        btnRead.Enabled = True
        btnWrite.Enabled = False
    End Sub

    Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
        Try
            ReadPLC()
            If tmrTimer.Enabled = True Then
                btnRead.Text = "Read"
                tmrTimer.Stop()
                tmrTimer.Enabled = False
                btnWrite.Enabled = True
                btnSlct.Enabled = True
                txtCpuN.Enabled = True
                txtKyok.Enabled = True
                cboDevi.Enabled = True
                txtDevN.Enabled = True
                txtDevC.Enabled = True
            Else
                btnRead.Text = "Stop"
                tmrTimer.Enabled = True
                tmrTimer.Start()
                btnWrite.Enabled = False
                btnSlct.Enabled = False
                txtCpuN.Enabled = False
                txtKyok.Enabled = False
                cboDevi.Enabled = False
                txtDevN.Enabled = False
                txtDevC.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click
        Try
            WritePLC()
            ReadPLC()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimer.Tick
        ReadPLC()
    End Sub

    Private Sub txtCpuN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCpuN.TextChanged
        btnRead.Enabled = False
        btnWrite.Enabled = False
    End Sub

    Private Sub txtKyok_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKyok.TextChanged
        btnRead.Enabled = False
        btnWrite.Enabled = False
    End Sub

    Private Sub cboDevi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDevi.SelectedIndexChanged
        btnRead.Enabled = False
        btnWrite.Enabled = False
    End Sub

    Private Sub txtDevN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDevN.TextChanged
        btnRead.Enabled = False
        btnWrite.Enabled = False
    End Sub

    Private Sub lblKyok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblKyok.Click
        btnRead.Enabled = False
        btnWrite.Enabled = False
    End Sub

    Private Sub txtDevC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDevC.TextChanged
        btnRead.Enabled = False
        btnWrite.Enabled = False
    End Sub

    Private Sub ReadPLC()
        Try
            Dim intBit(Val(txtDevC.Text)) As Integer

            'If ComboBox1.Text = "I" Or _
            '   ComboBox1.Text = "L" Then
            '    objUnitM3.SeqBitRead(Val(TextBox3.Text), ComboBox1.Text & TextBox4.Text, Val(TextBox5.Text), intBit)
            '    For i As Integer = 1 To UBound(intBit)
            '        DataGrid1.Item(i - 1, 1) = intBit(i)
            '    Next
            'ElseIf ComboBox1.Text = "D" Or _
            '       ComboBox1.Text = "W" Then
            '    objUnitM3.SeqWordRead(Val(TextBox3.Text), ComboBox1.Text & TextBox4.Text, Val(TextBox5.Text), intBit)
            '    For i As Integer = 1 To UBound(intBit)
            '        DataGrid1.Item(i - 1, 1) = intBit(i)
            '    Next
            'End If
            '******************************************************************************
            'Melsec再接続
            '******************************************************************************
            If mobjMelsec Is Nothing Then
                mobjMelsec = New ComMelsec.clsMelsec(Me)                        'Melsec通信ｸﾗｽ
                mobjMelsec.strSockMelSendAddress = txtAdrs.Text                'PLC側IPｱﾄﾞﾚｽ
                mobjMelsec.intSockMelSendPort = txtPort.Text                   'PLC側ﾎﾟｰﾄNo.
                mobjMelsec.intACPUTimer = 2560                                  'CPU監視ﾀｲﾏ(250ms単位:自局のと通信の場合"0001"～"0040"(0.25秒～10秒))
                mobjMelsec.intDebugFlag = 1                                     'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
                mobjMelsec.intSockRetry = 3                                     'ﾘﾄﾗｲ回数(回)
                mobjMelsec.intSockTimeOut = 10                                  'ﾀｲﾑｱｳﾄ時間(秒)(自局:1～10秒、他局:1～60秒)
                mobjMelsec.Open()                                               'ｵｰﾌﾟﾝ
            End If

            Dim intReturn As ComMelsec.clsMelsec.RetCode = ComMelsec.clsMelsec.RetCode.NG                   '関数戻値


            '***************************************
            'ﾚｼﾞｽﾀ読込
            '***************************************
            intReturn = mobjMelsec.AreaReadAJ71E71(CInt(txtCpuN.Text), ComMelsec.clsMelsec.RegType.D, CInt(txtDevN.Text), CInt(txtDevC.Text), intBit)
            For i As Integer = 0 To UBound(intBit) - 1
                objGrid.Item(i, 1) = intBit(i)
            Next
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub

    Private Sub WritePLC()
        Try
            Dim intBit(Val(txtDevC.Text)) As Integer

            '******************************************************************************
            'Melsec再接続
            '******************************************************************************
            If mobjMelsec Is Nothing Then
                mobjMelsec = New ComMelsec.clsMelsec(Me)                        'Melsec通信ｸﾗｽ
                mobjMelsec.strSockMelSendAddress = txtAdrs.Text                'PLC側IPｱﾄﾞﾚｽ
                mobjMelsec.intSockMelSendPort = txtPort.Text                   'PLC側ﾎﾟｰﾄNo.
                mobjMelsec.intACPUTimer = 2560                                  'CPU監視ﾀｲﾏ(250ms単位:自局のと通信の場合"0001"～"0040"(0.25秒～10秒))
                mobjMelsec.intDebugFlag = 1                                     'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
                mobjMelsec.intSockRetry = 3                                     'ﾘﾄﾗｲ回数(回)
                mobjMelsec.intSockTimeOut = 10                                  'ﾀｲﾑｱｳﾄ時間(秒)(自局:1～10秒、他局:1～60秒)
                mobjMelsec.Open()                                               'ｵｰﾌﾟﾝ
            End If

            Dim mintSRC_STATION As Integer = CInt(&HFF - Val(txtKyok.Text) + 1)
            Dim intPartAddress As Integer = CInt(txtDevN.Text)
            Dim intData(Val(txtDevC.Text) - 1) As Integer                                           '書込ﾃﾞｰﾀ
            For i As Integer = 0 To Val(txtDevC.Text) - 1
                intData(i) = objGrid.Item(i, 1)
            Next
            Dim intRetPLC As ComMelsec.clsMelsec.RetCode
            intRetPLC = mobjMelsec.AreaWriteAJ71E71(mintSRC_STATION, ComMelsec.clsMelsec.RegType.D, intPartAddress, intData.Length, intData)
            If intRetPLC <> ComMelsec.clsMelsec.RetCode.OK Then
                '(失敗した場合)
                Throw New Exception("ﾚｼﾞｽﾀ書込失敗。" _
                                    & "[開始ﾚｼﾞｽﾀ:" & intPartAddress & "]" _
                                    )
            End If
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub

    '==========================================================
    '【機能】桁数に合わせて「左０詰め」で数値を返す
    '        例：    (4, 12) → "0012"
    '                (3, 1)  → "001"
    '【引数】桁数			:	int		intLen
    '        変換数値		:	int		intNum
    '==========================================================
    Public Function ZeroSppr(ByVal intLen As Integer, ByVal intNum As Integer) As String
        Try
            Dim strNum As String

            strNum = StrDup(intLen, "0") & intNum.ToString
            strNum = Microsoft.VisualBasic.Strings.Right(strNum, intLen)
            Return strNum

        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try

    End Function

    Public Sub AddToLog(ByVal strMsg As String)
        MsgBox(strMsg)
    End Sub
End Class