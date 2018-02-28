'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】改善提案
' 【機能】RS232C通信ﾃｽﾄ用ﾌﾟﾛｸﾞﾗﾑ
' 【作成】2008/10/16  KSH  Rev 0.00
'**********************************************************************************************

#Region "  Imports          "
Imports System.IO.Ports
Imports JobCommon
Imports MateCommon.mdlComFunc
#End Region

Public Class frmRS232C

#Region "  共通変数         "

    Private mobjSerial As SerialPort        'ｼﾘｱﾙﾎﾟｰﾄ
    Private mobjLogWrite As clsWriteLog     'ﾛｸﾞ出力ｸﾗｽ

    Private mintListCount As Integer        'ﾘｽﾄﾎﾞｯｸｽに表示する最大行数
    Private Const DATE_FORMAT_99 As String = "yyyy/MM/dd HH:mm:ss.ffff "     'ﾃﾞﾊﾞｯｸﾞ用      ﾌｫｰﾏｯﾄ
    Private Const MESSAGE_001 As String = "【ﾎﾟｰﾄｵｰﾌﾟﾝ】"
    Private Const MESSAGE_002 As String = "【ﾎﾟｰﾄｸﾛｰｽﾞ】"
    Private Const MESSAGE_003 As String = "【  送 信  】"
    Private Const MESSAGE_004 As String = "【  受 信  】"

#End Region

#Region "  ﾌｫｰﾑﾛｰﾄﾞ"
    Private Sub frmRS232C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            '****************************************************
            '色々初期化
            '****************************************************
            mintListCount = 100


            '*****************************************************
            'ﾛｸﾞ出力ｵﾌﾞｼﾞｪｸﾄ生成
            '*****************************************************
            mobjLogWrite = New clsWriteLog
            mobjLogWrite.clspFileName = "logForm.log"       'ﾌｧｲﾙ名         ｾｯﾄ
            mobjLogWrite.clspCopyFile = "logForm_old.log"   'ﾌｧｲﾙ名(古い)   ｾｯﾄ
            mobjLogWrite.clspMaxSize = 500000               '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ


            '*****************************************************
            '解析ﾌｫｰﾑ表示
            '*****************************************************
            Call cmdAnalysis_Click(Nothing, Nothing)
            'Me.WindowState = FormWindowState.Minimized


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region

    'ﾎﾞﾀﾝｸﾘｯｸ
#Region "  ﾎﾟｰﾄｵｰﾌﾟﾝ            ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdPortOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPortOpen.Click
        Try


            '****************************************************
            'ﾎﾟｰﾄｵｰﾌﾟﾝ
            '****************************************************
            If IsNothing(mobjSerial) = False Then
                mobjSerial.Close()       '通信ｸﾛｰｽﾞ
                mobjSerial.Dispose()
                mobjSerial = Nothing
            End If
            mobjSerial = New SerialPort(txtPort.Text, _
                                        txtBaud.Text, _
                                        txtParity.Text, _
                                        txtDataLength.Text, _
                                        txtStopBit.Text)


            '通信ｵｰﾌﾟﾝ
            mobjSerial.Open()
            Call AddToLog(MESSAGE_001 & "[ﾎﾟｰﾄ:" & txtPort.Text & "]" _
                                      & "[ﾎﾞｰﾚｰﾄ:" & txtBaud.Text & "]" _
                                      & "[ﾊﾟﾘﾃｨ:" & txtParity.Text & "]" _
                                      & "[ﾃﾞｰﾀ長:" & txtDataLength.Text & "]" _
                                      & "[ｽﾄｯﾌﾟﾋﾞｯﾄ:" & txtStopBit.Text & "]" _
                                      )


            '****************************************************
            'RTS,DTRｾｯﾄ
            '****************************************************
            mobjSerial.RtsEnable = chkRTS.Checked
            mobjSerial.DtrEnable = chkDTR.Checked


            '****************************************************
            'ﾀｲﾏｰｾｯﾄ
            '****************************************************
            tmrReceive.Interval = txtInterval.Text
            tmrReceive.Enabled = True


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾎﾟｰﾄｸﾛｰｽﾞ            ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdPortClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPortClose.Click
        Try


            '****************************************************
            'ﾎﾟｰﾄｸﾛｰｽﾞ
            '****************************************************
            If IsNothing(mobjSerial) = False Then
                mobjSerial.Close()       '通信ｸﾛｰｽﾞ
                mobjSerial.Dispose()
                mobjSerial = Nothing
            End If
            Call AddToLog(MESSAGE_002)


            '****************************************************
            'ﾀｲﾏｰｾｯﾄ
            '****************************************************
            tmrReceive.Enabled = False


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾃｷｽﾄ送信             ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Try

            If IsNothing(mobjSerial) = True Then
                MsgBox("ﾎﾟｰﾄをｵｰﾌﾟﾝして下さい。")
                Exit Sub
            End If


            mobjSerial.Write(txtSend.Text)
            Call AddToLog(MESSAGE_003 & txtSend.Text)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾃｷｽﾄ送信(Chr)        ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdSendChr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendChr.Click
        Try
            Dim strChrNum() As String       '送信電文の16進配列
            Dim bytChrNum() As Byte         '送信電文の16進配列
            strChrNum = Split(txtSendChr.Text, ",")
            ReDim bytChrNum(UBound(strChrNum))
            For ii As Integer = LBound(strChrNum) To UBound(strChrNum)
                '(ﾙｰﾌﾟ:配列数)
                If Change16To10(strChrNum(ii)) < 0 Or 255 < Change16To10(strChrNum(ii)) Then Throw New Exception("テキストボックスには、カンマ区切りで00～FFの数値を設定して下さい。")
                bytChrNum(ii) = Change16To10(strChrNum(ii))
            Next


            '****************************************************
            '送信
            '****************************************************
            mobjSerial.Write(bytChrNum, 0, bytChrNum.Length)
            Call AddToLog(MESSAGE_003 & txtSendChr.Text)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  解析                 ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnalysis.Click
        Try


            Dim objForm As New frmAnalysis
            objForm.objRS232C = Me
            objForm.Show()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

    'ﾁｪｯｸﾎﾞｯｸｽ
#Region "  RTS      ﾁｪｯｸﾎﾞｯｸｽｸﾘｯｸ"
    Private Sub chkRTS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRTS.CheckedChanged, chkDSR.CheckedChanged
        Try
            If IsNothing(mobjSerial) = False Then
                mobjSerial.RtsEnable = chkRTS.Checked
            End If
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  DTR      ﾁｪｯｸﾎﾞｯｸｽｸﾘｯｸ"
    Private Sub chkDTR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDTR.CheckedChanged, chkCD.CheckedChanged, chkCTS.CheckedChanged
        Try
            If IsNothing(mobjSerial) = False Then
                mobjSerial.DtrEnable = chkDTR.Checked
            End If
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

    '受信ﾀｲﾏｰ
#Region "  受信ﾀｲﾏｰ"
    Private Sub tmrReceive_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReceive.Tick
        Try
            tmrReceive.Enabled = False


            Dim strReceiveText As String    '取得電文
            Dim strReceiveByte As String    '取得電文(ﾊﾞｲﾄ)
            Dim bytRead(2048) As Byte       '取得用ﾊﾞｲﾄ配列
            strReceiveText = ""
            strReceiveByte = ""
            If mobjSerial.BytesToRead > 0 Then
                '(受信ﾊﾞｯﾌｧにﾃﾞｰﾀが存在した場合)


                '****************************************************
                '受信ﾊﾞｯﾌｧﾃﾞｰﾀ取得
                '****************************************************
                Dim intGetbyte As Integer       '取得ﾊﾞｲﾄ数
                intGetbyte = mobjSerial.Read(bytRead, 0, bytRead.Length)      'ﾃﾞｰﾀ取得
                For ii As Integer = 0 To intGetbyte - 1
                    strReceiveText &= Chr(bytRead(ii))
                    If ii = 0 Then strReceiveByte &= Change10To16(bytRead(ii), 2) Else strReceiveByte &= "," & Change10To16(bytRead(ii), 2)
                Next


                '****************************************************
                '受信ﾊﾞｯﾌｧﾃﾞｰﾀを表示用に変換
                '****************************************************
                Dim strDispText As String = ""      '受信電文表示文字列
                If rdoASCII.Checked = True Then
                    '(制御文字表示の場合)
                    strDispText = strReceiveByte
                Else
                    '(ﾉｰﾏﾙの場合)
                    strDispText = strReceiveText
                End If


                txtRecvText.Text = strDispText
                Call AddToLog(MESSAGE_004 & strDispText)
            End If


            '****************************************************
            'ﾗｲﾝ状態      表示
            '****************************************************
            chkDSR.Checked = mobjSerial.DsrHolding      'Data Set Ready
            chkCTS.Checked = mobjSerial.CtsHolding      'Clear To Send
            chkCD.Checked = mobjSerial.CDHolding        'ポートのキャリア検出ライン


            tmrReceive.Enabled = True
        Catch ex As Exception
            ComError(ex)
            tmrReceive.Enabled = False

        End Try
    End Sub
#End Region


#Region "  画面ｴﾗｰ処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】ex         ：ｴﾗｰException
    '【戻値】
    '*******************************************************************************************************************
    Public Sub ComError(ByVal ex As Exception)
        Try

            '*****************************************************
            'ﾃｷｽﾄ生成
            '*****************************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(ex.StackTrace, ",", "，")       '半角ｶﾝﾏを全角ｶﾝﾏに変換
            strStackTrace = Split(strTemp, vbCrLf)

            '*****************************************************
            ' ﾛｸﾞ書込み
            '*****************************************************
            For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
                AddToLog(ex.Message, _
                         "【ﾌﾟﾛｸﾞﾗﾑ上のｴﾗｰ】", _
                         strStackTrace(ii))
            Next


        Catch ex2 As Exception
            Throw New Exception(ex2.Message)

        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞ書込処理"
    '****************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String, _
                        Optional ByVal strMsg_2 As String = "【ﾕｰｻﾞｰﾛｸﾞ      】", _
                        Optional ByVal strMsg_3 As String = "")
        Try

            '*****************************************************
            'ﾌｧｲﾙﾛｸﾞ出力
            '*****************************************************
            mobjLogWrite.WriteLog(strMsg_1, strMsg_2, strMsg_3)              'ﾛｸﾞ書込


            '*****************************************************
            'ﾘｽﾄ出力
            '*****************************************************
            '==============================================
            '定義された行数までﾘｽﾄﾎﾞｯｸｽの行を削除
            '==============================================
            While lstLog.Items.Count >= mintListCount
                lstLog.Items.RemoveAt(lstLog.Items.Count - 1)
            End While

            '==============================================
            'ﾘｽﾄ追加
            '==============================================
            Dim strMessage As String = Format(Now, DATE_FORMAT_99) & Space(5) & strMsg_2 & strMsg_1 & Space(5) & strMsg_3
            If InStr(strMessage, "現在のﾊﾞｯﾌｧ") = 0 Then
                lstLog.Items.Insert(0, strMessage)
            End If


        Catch ex2 As Exception
            Throw New Exception(ex2.Message)

        End Try
    End Sub
#End Region

#Region "  安川電文送信         ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdYasukawaSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYasukawaSend.Click
        Try


            '****************************************************
            'CRC        作成用ﾃﾞｰﾀ取得
            '****************************************************
            Dim strChrNum() As String       '送信電文の16進配列
            Dim bytChrNum() As Byte         '送信電文の16進配列
            strChrNum = Split(txtSendChr.Text, ",")
            ReDim bytChrNum(UBound(strChrNum))
            For ii As Integer = LBound(strChrNum) To UBound(strChrNum)
                '(ﾙｰﾌﾟ:配列数)
                If Change16To10(strChrNum(ii)) < 0 Or 255 < Change16To10(strChrNum(ii)) Then Throw New Exception("テキストボックスには、カンマ区切りで00～FFの数値を設定して下さい。")
                bytChrNum(ii) = Change16To10(strChrNum(ii))
            Next


            '****************************************************
            'CRC        作成
            '****************************************************
            Dim shrKotei As UShort = 40961              '固定値(1010 0000 0000 0001)
            Dim shrCRC As UShort = UShort.MaxValue      'CRC
            For ii As Integer = 0 To UBound(bytChrNum)
                '(ﾙｰﾌﾟ:ﾊﾞｲﾄ配列の数だけ)

                '=======================================
                '電文と仮CRCとのXor
                '=======================================
                shrCRC = shrCRC Xor bytChrNum(ii)


                For jj As Integer = 1 To 8
                    '(ﾙｰﾌﾟ:上位8ﾋﾞｯﾄ(実際には下位8ﾋﾞｯﾄ))


                    If Microsoft.VisualBasic.Right(Change10To2(shrCRC, 16), 1) = "0" Then
                        '(0の場合)

                        '=======================================
                        '右ｼﾌﾄ
                        '2で割ると右ｼﾌﾄする
                        '=======================================
                        shrCRC = shrCRC \ 2

                    Else
                        '(1の場合)

                        '=======================================
                        '右ｼﾌﾄ
                        '2で割ると右ｼﾌﾄする
                        '=======================================
                        shrCRC = shrCRC \ 2

                        '=======================================
                        '固定値と仮CRCとのXor
                        '=======================================
                        shrCRC = shrCRC Xor shrKotei

                    End If



                Next

            Next


            ''****************************************************
            ''CRCを16進数に変換
            ''****************************************************
            'Dim bytCRC(1) As Byte                           'CRC(ﾊﾞｲﾄ配列)
            'bytCRC(0) = shrCRC Mod 256
            'bytCRC(1) = shrCRC \ 255


            '****************************************************
            'CRCを16進数に変換
            '****************************************************
            Dim strCRC As String = Change10To16(shrCRC, 4)  'CRC(16進数4桁)
            Dim bytCRC(1) As Byte                           'CRC(ﾊﾞｲﾄ配列)
            bytCRC(0) = Change16To10(MID_SJIS(strCRC, 3, 2))
            bytCRC(1) = Change16To10(MID_SJIS(strCRC, 1, 2))


            '****************************************************
            'CRCを配列に追加
            '****************************************************
            ReDim Preserve bytChrNum(UBound(bytChrNum) + 2)
            bytChrNum(UBound(bytChrNum) - 1) = bytCRC(0)
            bytChrNum(UBound(bytChrNum) - 0) = bytCRC(1)


            ''****************************************************
            ''ﾉｰﾏﾙ電文       送信
            ''****************************************************
            'Call cmdSendChr_Click(Nothing, Nothing)


            '****************************************************
            'CRC            送信
            '****************************************************
            mobjSerial.Write(bytChrNum, 0, bytChrNum.Length)
            'mobjSerial.Write(bytCRC, 0, bytCRC.Length)
            Call AddToLog(MESSAGE_003 & "【CRC】" & Change10To16(bytCRC(0), 2) & "," & Change10To16(bytCRC(1), 2))


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region


End Class