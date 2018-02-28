'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】安川PLCﾂｰﾙ01画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports    "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports System.IO.Ports
Imports JobCommon
#End Region

Public Class frmTool01


#Region "  共通変数                             "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjOwner As Object                                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ

#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ                              "
    Public Sub New(ByVal objOwner As Object)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        mobjOwner = objOwner

    End Sub
#End Region

#Region "  ﾌｫｰﾑﾛｰﾄﾞ                             "
    Private Sub frmTool01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim objConfig As New clsConnectConfig(CONFIG_MCIA)                                  'Configﾌｧｲﾙ接続ｸﾗｽ生成
            txtReadSend01_01.Text = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_PLCSLAVEADRS))       '通信対象となるPLCのｽﾚｰﾌﾞｱﾄﾞﾚｽ
            txtWriteSend01_01.Text = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_PLCSLAVEADRS))       '通信対象となるPLCのｽﾚｰﾌﾞｱﾄﾞﾚｽ

        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region
#Region "  読込                         ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdRead01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRead01.Click
        Dim strMsg As String = ""
        Dim intRetPLC As ComPLCYaskawa.clsPLC.RetCode
        txtReadRecv01_04.Text = ""

        Try


            '*****************************************************
            'ﾚｼﾞｽﾀ値取得
            '*****************************************************
            Dim bytRead() As Integer = Nothing
            intRetPLC = gobjMain.AreaRead(txtReadSend01_01.Text, txtReadSend01_03.Text, txtReadSend01_04.Text, bytRead)
            If intRetPLC <> RetCode.OK Then
                strMsg = "PLCﾚｼﾞｽﾀ内容取得失敗。"
                txtReadRecv01_04.Text = strMsg
                Throw New Exception(strMsg)
            End If


            '*****************************************************
            'ﾚｼﾞｽﾀ値表示
            '*****************************************************
            txtReadRecv01_04.Text = Space(6) & "(     2進数      )(16進)( 10進)" & vbCrLf
            For ii As Integer = 0 To UBound(bytRead)
                '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)

                Dim strData16 As String = Change10To16(bytRead(ii), 4)
                Dim strData10 As Integer = bytRead(ii)
                Dim strData02 As String = Change10To2(bytRead(ii), 16)
                txtReadRecv01_04.Text &= (TO_INTEGER(txtReadSend01_03.Text) + ii) & ":"
                txtReadRecv01_04.Text &= "(" & strData02 & ")"
                txtReadRecv01_04.Text &= "(" & strData16 & ")"
                txtReadRecv01_04.Text &= "(" & SPC_PAD_RIGHT_SJIS(strData10, 5) & ")"
                txtReadRecv01_04.Text &= vbCrLf

            Next
            Call AddToLog(Me.Text & "画面から読込みを行いました。")


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub

    'Private Sub cmdRead01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRead01.Click
    '    Dim strMsg As String = ""
    '    Dim intRetPLC As ComPLCYaskawa.clsPLC.RetCode
    '    txtReadRecv01_04.Text = ""


    '    '*****************************************************
    '    '安川PLCｸﾗｽ     生成
    '    '*****************************************************
    '    Dim objPLC As New ComPLCYaskawa.clsPLC(mobjOwner)
    '    Try


    '        '*****************************************************
    '        'ｵｰﾌﾟﾝ
    '        '*****************************************************
    '        objPLC.strCOMRecvPort = "COM4"              'ﾎﾟｰﾄ番号
    '        objPLC.intCOMRecvBaud = 9600                '通信速度
    '        objPLC.strCOMRecvParity = 0                 'ﾊﾟﾘﾃｨ
    '        objPLC.intCOMRecvDataLength = 8             'ﾃﾞｰﾀ長
    '        objPLC.strCOMRecvStopBit = 2                'ｽﾄｯﾌﾟﾋﾞｯﾄ長
    '        objPLC.intCOMCodePage = 932                 '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
    '        objPLC.strCOMComName = "aaa"                '通信名
    '        objPLC.intSendTimeout = 11000               '送信ﾀｲﾑｱｳﾄ(ms)
    '        objPLC.intSendRetry = 5                     '送信ﾘﾄﾗｲ回数
    '        'その他
    '        objPLC.intDebugFlag = 1                     'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
    '        objPLC.Open()


    '        '*****************************************************
    '        'ﾚｼﾞｽﾀ値取得
    '        '*****************************************************
    '        Dim bytRead() As Integer = Nothing
    '        intRetPLC = objPLC.AreaRead(txtReadSend01_01.Text, txtReadSend01_03.Text, txtReadSend01_04.Text, bytRead)
    '        If intRetPLC <> RetCode.OK Then
    '            strMsg = "PLCﾚｼﾞｽﾀ内容取得失敗。"
    '            txtReadRecv01_04.Text = strMsg
    '            Throw New Exception(strMsg)
    '        End If


    '        '*****************************************************
    '        'ﾚｼﾞｽﾀ値表示
    '        '*****************************************************
    '        txtReadRecv01_04.Text = Space(6) & "(     2進数      )(16進)( 10進)" & vbCrLf
    '        For ii As Integer = 0 To UBound(bytRead)
    '            '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)

    '            Dim strData16 As String = Change10To16(bytRead(ii), 4)
    '            Dim strData10 As Integer = bytRead(ii)
    '            Dim strData02 As String = Change10To2(bytRead(ii), 16)
    '            txtReadRecv01_04.Text &= (TO_INTEGER(txtReadSend01_03.Text) + ii) & ":"
    '            txtReadRecv01_04.Text &= "(" & strData02 & ")"
    '            txtReadRecv01_04.Text &= "(" & strData16 & ")"
    '            txtReadRecv01_04.Text &= "(" & SPC_PAD_RIGHT_SJIS(strData10, 5) & ")"
    '            txtReadRecv01_04.Text &= vbCrLf

    '        Next



    '    Catch ex As Exception
    '        Call ComError(ex)

    '    Finally
    '        Try
    '            objPLC.Close()
    '        Catch ex As Exception
    '            Call ComError(ex)

    '        End Try
    '    End Try
    'End Sub
#End Region
#Region "  書込                         ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdWrite01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWrite01.Click
        Try
            Dim strMsg As String = ""
            Dim intRetPLC As ComPLCYaskawa.clsPLC.RetCode


            '*****************************************************
            '確認ﾒｯｾｰｼﾞ
            '*****************************************************
            If MsgBox("ﾚｼﾞｽﾀに値を書き込みます。" & vbCrLf & "よろしいですか？", MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                Exit Sub
            End If


            '*****************************************************
            'ﾚｼﾞｽﾀ値取得
            '*****************************************************
            '===========================================
            'ﾃｷｽﾄﾎﾞｯｸｽからﾃﾞｰﾀ取得
            '===========================================
            Dim strWrite() As String
            If IsNull(txtDelimiter.Text) Then
                strWrite = Split(txtWriteSend01_06.Text, vbCrLf)
            Else
                strWrite = Split(txtWriteSend01_06.Text, txtDelimiter.Text)
            End If

            '===========================================
            '数値型に変換
            '===========================================
            Dim intWrite(UBound(strWrite)) As Integer
            For ii As Integer = 0 To UBound(intWrite)
                '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)
                intWrite(ii) = TO_INTEGER(strWrite(ii))
            Next


            '*****************************************************
            'ﾚｼﾞｽﾀ値書込み
            '*****************************************************
            Dim bytRead() As Integer = Nothing
            intRetPLC = gobjMain.AreaWrite(txtWriteSend01_01.Text, txtWriteSend01_03.Text, intWrite)
            If intRetPLC <> RetCode.OK Then
                strMsg = "PLCﾚｼﾞｽﾀ内容書込失敗。"
                Throw New Exception(strMsg)
            End If


            '*****************************************************
            '確認ﾒｯｾｰｼﾞ
            '*****************************************************
            Call AddToLog(Me.Text & "画面から書込みを行いました。")
            Call MsgBox("ﾚｼﾞｽﾀの書込みに成功しました。")


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
    'Private Sub cmdWrite01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWrite01.Click
    '    Dim strMsg As String = ""
    '    Dim intRetPLC As ComPLCYaskawa.clsPLC.RetCode


    '    '*****************************************************
    '    '安川PLCｸﾗｽ     生成
    '    '*****************************************************
    '    Dim objPLC As New ComPLCYaskawa.clsPLC(mobjOwner)
    '    Try


    '        '*****************************************************
    '        'ｵｰﾌﾟﾝ
    '        '*****************************************************
    '        objPLC.strCOMRecvPort = "COM4"              'ﾎﾟｰﾄ番号
    '        objPLC.intCOMRecvBaud = 9600                '通信速度
    '        objPLC.strCOMRecvParity = 0                 'ﾊﾟﾘﾃｨ
    '        objPLC.intCOMRecvDataLength = 8             'ﾃﾞｰﾀ長
    '        objPLC.strCOMRecvStopBit = 2                'ｽﾄｯﾌﾟﾋﾞｯﾄ長
    '        objPLC.intCOMCodePage = 932                 '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
    '        objPLC.strCOMComName = "aaa"                '通信名
    '        objPLC.intSendTimeout = 11000               '送信ﾀｲﾑｱｳﾄ(ms)
    '        objPLC.intSendRetry = 5                     '送信ﾘﾄﾗｲ回数
    '        'その他
    '        objPLC.intDebugFlag = 1                     'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
    '        objPLC.Open()


    '        '*****************************************************
    '        'ﾚｼﾞｽﾀ値取得
    '        '*****************************************************
    '        '===========================================
    '        'ﾃｷｽﾄﾎﾞｯｸｽからﾃﾞｰﾀ取得
    '        '===========================================
    '        Dim strWrite() As String
    '        If IsNull(txtDelimiter.Text) Then
    '            strWrite = Split(txtWriteSend01_06.Text, vbCrLf)
    '        Else
    '            strWrite = Split(txtWriteSend01_06.Text, txtDelimiter.Text)
    '        End If

    '        '===========================================
    '        '数値型に変換
    '        '===========================================
    '        Dim intWrite(UBound(strWrite)) As Integer
    '        For ii As Integer = 0 To UBound(intWrite)
    '            '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)
    '            intWrite(ii) = TO_INTEGER(strWrite(ii))
    '        Next
    '        intRetPLC = objPLC.AreaWrite(txtWriteSend01_01.Text, txtWriteSend01_03.Text, intWrite)
    '        If intRetPLC <> RetCode.OK Then
    '            strMsg = "PLCﾚｼﾞｽﾀ内容書込失敗。"
    '            Throw New Exception(strMsg)
    '        End If


    '    Catch ex As Exception
    '        Call ComError(ex)

    '    Finally
    '        Try
    '            objPLC.Close()
    '        Catch ex As Exception
    '            Call ComError(ex)

    '        End Try
    '    End Try
    'End Sub
#End Region
#Region "  搬送ﾃﾞｰﾀ書込                 ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdWrite02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWrite02.Click
        Try
            Dim strData01_02 As String = ""     'ﾃﾞｰﾀ01(02進数)
            Dim strData02_02 As String = ""     'ﾃﾞｰﾀ02(02進数)
            'Dim strData03_02 As String = ""     'ﾃﾞｰﾀ03(02進数)
            Dim strData04_02 As String = ""     'ﾃﾞｰﾀ04(02進数)
            Dim strData05_02 As String = ""     'ﾃﾞｰﾀ05(02進数)
            'Dim strData06_02 As String = ""     'ﾃﾞｰﾀ06(02進数)
            Dim strData01_10 As String = ""     'ﾃﾞｰﾀ01(10進数)
            Dim strData02_10 As String = ""     'ﾃﾞｰﾀ02(10進数)
            Dim strData03_10 As String = ""     'ﾃﾞｰﾀ03(10進数)
            Dim strData04_10 As String = ""     'ﾃﾞｰﾀ04(10進数)
            Dim strData05_10 As String = ""     'ﾃﾞｰﾀ05(10進数)
            Dim strData06_10 As String = ""     'ﾃﾞｰﾀ06(10進数)


            '*****************************************************
            '確認ﾒｯｾｰｼﾞ
            '*****************************************************
            If MsgBox("ﾚｼﾞｽﾀに値を書き込みます。" & vbCrLf & "よろしいですか？", MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                Exit Sub
            End If


            '*****************************************************
            'ﾃﾞｰﾀ               作成
            '*****************************************************
            'ﾃﾞｰﾀ01(02進数)
            strData01_02 &= "0"                         '固定
            strData01_02 &= txtHansouData01_01.Text     '入庫ﾓｰﾄﾞ
            strData01_02 &= txtHansouData02_01.Text     '出庫ﾓｰﾄﾞ
            strData01_02 &= txtHansouData03_01.Text     'ﾍﾟｱ搬送
            strData01_02 &= txtHansouData04_01.Text     'ﾌｫｰｸ2
            strData01_02 &= txtHansouData05_01.Text     'ﾌｫｰｸ1
            strData01_02 &= Change10To2(txtHansouData06_01.Text, 2)     'L/S番号
            strData01_02 &= "0"                         '固定
            strData01_02 &= txtHansouData07_01.Text     'ﾀﾞﾌﾞﾙﾘｰﾁ
            strData01_02 &= Change10To2(txtHansouData08_01.Text, 2)     '列
            strData01_02 &= Change10To2(txtHansouData09_01.Text, 4)     '号機
            'ﾃﾞｰﾀ02(02進数)
            strData02_02 &= "00"                        '固定
            strData02_02 &= Change10To2(txtHansouData10_01.Text, 6)     '連
            strData02_02 &= txtHansouData11_01.Text     'ENDﾌﾗｸﾞ
            strData02_02 &= txtHansouData12_01.Text     '入棚再設定
            strData02_02 &= "00"                        '固定
            strData02_02 &= Change10To2(txtHansouData13_01.Text, 4)     '段
            'ﾃﾞｰﾀ01(02進数)
            strData04_02 &= "0"                         '固定
            strData04_02 &= txtHansouData01_02.Text     '入庫ﾓｰﾄﾞ
            strData04_02 &= txtHansouData02_02.Text     '出庫ﾓｰﾄﾞ
            strData04_02 &= txtHansouData03_02.Text     'ﾍﾟｱ搬送
            strData04_02 &= txtHansouData04_02.Text     'ﾌｫｰｸ2
            strData04_02 &= txtHansouData05_02.Text     'ﾌｫｰｸ1
            strData04_02 &= Change10To2(txtHansouData06_02.Text, 2)     'L/S番号
            strData04_02 &= "0"                         '固定
            strData04_02 &= txtHansouData07_02.Text     'ﾀﾞﾌﾞﾙﾘｰﾁ
            strData04_02 &= Change10To2(txtHansouData08_02.Text, 2)     '列
            strData04_02 &= Change10To2(txtHansouData09_02.Text, 4)     '号機
            'ﾃﾞｰﾀ02(02進数)
            strData05_02 &= "00"                        '固定
            strData05_02 &= Change10To2(txtHansouData10_02.Text, 6)     '連
            strData05_02 &= txtHansouData11_02.Text     'ENDﾌﾗｸﾞ
            strData05_02 &= txtHansouData12_02.Text     '入棚再設定
            strData05_02 &= "00"                        '固定
            strData05_02 &= Change10To2(txtHansouData13_02.Text, 4)     '段


            '*****************************************************
            'ﾁｪｯｸ
            '*****************************************************
            If strData01_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ01(02進)が16桁じゃないのでｴﾗｰとします。")
            If strData02_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ02(02進)が16桁じゃないのでｴﾗｰとします。")
            'If strData03_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ03(02進)が16桁じゃないのでｴﾗｰとします。")
            If strData04_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ04(02進)が16桁じゃないのでｴﾗｰとします。")
            If strData05_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ05(02進)が16桁じゃないのでｴﾗｰとします。")
            'If strData06_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ06(02進)が16桁じゃないのでｴﾗｰとします。")


            '*****************************************************
            '10進数に変換
            '*****************************************************
            strData01_10 = Change2To10(strData01_02)    'ﾃﾞｰﾀ01(10進数)
            strData02_10 = Change2To10(strData02_02)    'ﾃﾞｰﾀ02(10進数)
            strData03_10 = txtHansouData14_01.Text      'ﾃﾞｰﾀ03(10進数)
            strData04_10 = Change2To10(strData04_02)    'ﾃﾞｰﾀ04(10進数)
            strData05_10 = Change2To10(strData05_02)    'ﾃﾞｰﾀ05(10進数)
            strData06_10 = txtHansouData14_02.Text      'ﾃﾞｰﾀ06(10進数)


            '*****************************************************
            '10進数に変換
            '*****************************************************
            txtWriteSend01_06.Text = strData01_10
            txtWriteSend01_06.Text &= vbCrLf & strData02_10
            txtWriteSend01_06.Text &= vbCrLf & strData03_10
            txtWriteSend01_06.Text &= vbCrLf & strData04_10
            txtWriteSend01_06.Text &= vbCrLf & strData05_10
            txtWriteSend01_06.Text &= vbCrLf & strData06_10


            '*****************************************************
            '書込
            '*****************************************************
            Call cmdWrite01_Click(Nothing, Nothing)


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  入庫ﾌｫｰﾏｯﾄ                   ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdFormatIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFormatIn.Click
        Try


            txtHansouData01_01.Text = "1"           '入庫ﾓｰﾄﾞ
            txtHansouData02_01.Text = "0"           '出庫ﾓｰﾄﾞ
            txtHansouData03_01.Text = "1"           'ﾍﾟｱ搬送
            txtHansouData04_01.Text = "0"           'ﾌｫｰｸ2
            txtHansouData05_01.Text = "1"           'ﾌｫｰｸ1
            txtHansouData06_01.Text = "00"          'L/S番号
            txtHansouData07_01.Text = "0"           'ﾀﾞﾌﾞﾙﾘｰﾁ
            txtHansouData08_01.Text = "00"          '列
            txtHansouData09_01.Text = "0000"        '号機
            txtHansouData10_01.Text = "00000"       '連
            txtHansouData11_01.Text = "0"           'ENDﾌﾗｸﾞ
            txtHansouData12_01.Text = "0"           '入棚再設定
            txtHansouData13_01.Text = "0000"        '段
            txtHansouData14_01.Text = "0"           'ｱﾄﾞﾚｽ

            txtHansouData01_02.Text = "1"           '入庫ﾓｰﾄﾞ
            txtHansouData02_02.Text = "0"           '出庫ﾓｰﾄﾞ
            txtHansouData03_02.Text = "1"           'ﾍﾟｱ搬送
            txtHansouData04_02.Text = "1"           'ﾌｫｰｸ2
            txtHansouData05_02.Text = "0"           'ﾌｫｰｸ1
            txtHansouData06_02.Text = "00"          'L/S番号
            txtHansouData07_02.Text = "0"           'ﾀﾞﾌﾞﾙﾘｰﾁ
            txtHansouData08_02.Text = "00"          '列
            txtHansouData09_02.Text = "0000"        '号機
            txtHansouData10_02.Text = "00000"       '連
            txtHansouData11_02.Text = "0"           'ENDﾌﾗｸﾞ
            txtHansouData12_02.Text = "0"           '入棚再設定
            txtHansouData13_02.Text = "0000"        '段
            txtHansouData14_02.Text = "0"           'ｱﾄﾞﾚｽ


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  出庫ﾌｫｰﾏｯﾄ                   ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdFormatOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFormatOut.Click
        Try


            txtHansouData01_01.Text = "0"           '入庫ﾓｰﾄﾞ
            txtHansouData02_01.Text = "1"           '出庫ﾓｰﾄﾞ
            txtHansouData03_01.Text = "1"           'ﾍﾟｱ搬送
            txtHansouData04_01.Text = "0"           'ﾌｫｰｸ2
            txtHansouData05_01.Text = "1"           'ﾌｫｰｸ1
            txtHansouData06_01.Text = "00"          'L/S番号
            txtHansouData07_01.Text = "0"           'ﾀﾞﾌﾞﾙﾘｰﾁ
            txtHansouData08_01.Text = "00"          '列
            txtHansouData09_01.Text = "0000"        '号機
            txtHansouData10_01.Text = "00000"       '連
            txtHansouData11_01.Text = "0"           'ENDﾌﾗｸﾞ
            txtHansouData12_01.Text = "0"           '入棚再設定
            txtHansouData13_01.Text = "0000"        '段
            txtHansouData14_01.Text = "0"           'ｱﾄﾞﾚｽ

            txtHansouData01_02.Text = "0"           '入庫ﾓｰﾄﾞ
            txtHansouData02_02.Text = "1"           '出庫ﾓｰﾄﾞ
            txtHansouData03_02.Text = "1"           'ﾍﾟｱ搬送
            txtHansouData04_02.Text = "1"           'ﾌｫｰｸ2
            txtHansouData05_02.Text = "0"           'ﾌｫｰｸ1
            txtHansouData06_02.Text = "00"          'L/S番号
            txtHansouData07_02.Text = "0"           'ﾀﾞﾌﾞﾙﾘｰﾁ
            txtHansouData08_02.Text = "00"          '列
            txtHansouData09_02.Text = "0000"        '号機
            txtHansouData10_02.Text = "00000"       '連
            txtHansouData11_02.Text = "0"           'ENDﾌﾗｸﾞ
            txtHansouData12_02.Text = "0"           '入棚再設定
            txtHansouData13_02.Text = "0000"        '段
            txtHansouData14_02.Text = "0"           'ｱﾄﾞﾚｽ


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ｼﾝｸﾞﾙﾌｫｰﾏｯﾄ                  ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdFormatSingle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFormatSingle.Click
        Try


            txtHansouData01_02.Text = "0"           '入庫ﾓｰﾄﾞ
            txtHansouData02_02.Text = "0"           '出庫ﾓｰﾄﾞ
            txtHansouData03_02.Text = "0"           'ﾍﾟｱ搬送
            txtHansouData04_02.Text = "0"           'ﾌｫｰｸ2
            txtHansouData05_02.Text = "0"           'ﾌｫｰｸ1
            txtHansouData06_02.Text = "00"          'L/S番号
            txtHansouData07_02.Text = "0"           'ﾀﾞﾌﾞﾙﾘｰﾁ
            txtHansouData08_02.Text = "00"          '列
            txtHansouData09_02.Text = "0000"        '号機
            txtHansouData10_02.Text = "00000"       '連
            txtHansouData11_02.Text = "0"           'ENDﾌﾗｸﾞ
            txtHansouData12_02.Text = "0"           '入棚再設定
            txtHansouData13_02.Text = "0000"        '段
            txtHansouData14_02.Text = "0"           'ｱﾄﾞﾚｽ


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region




#Region "  ﾛｸﾞ書き込み処理                  "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strMsg_1">ﾛｸﾞﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region
#Region "  ｴﾗｰ処理                          "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException">ｴﾗｰException</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub ComError(ByVal objException As Exception)
        Try


            '*****************************************************
            'ﾃｷｽﾄ生成
            '*****************************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(objException.StackTrace, ",", "，")       '半角ｶﾝﾏを全角ｶﾝﾏに変換
            strStackTrace = Split(strTemp, vbCrLf)


            '*****************************************************
            ' ﾛｸﾞ書込み
            '*****************************************************
            For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
                AddToLog(objException.Message & "," & strStackTrace(ii))
            Next


            '*****************************************************
            'ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
            '*****************************************************
            Call MsgBox(objException.Message)


        Catch ex2 As Exception
            'NOP
        End Try
    End Sub
#End Region




#Region "  搬送ﾃﾞｰﾀ分解                 ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdHansouDataBunkai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHansouDataBunkai.Click
        Try


            '************************************************
            '搬送ﾃﾞｰﾀ           取得
            '************************************************
            Dim strFEQ_STS(5) As String
            strFEQ_STS(0) = txtHansouData00.Text
            strFEQ_STS(1) = txtHansouData01.Text
            strFEQ_STS(2) = txtHansouData02.Text
            strFEQ_STS(3) = txtHansouData03.Text
            strFEQ_STS(4) = txtHansouData04.Text
            strFEQ_STS(5) = txtHansouData05.Text
            Dim intAryHansouSiziData() As Integer = Nothing         '搬送指示ﾃﾞｰﾀ配列
            Call GetHansouSiziData(strFEQ_STS, intAryHansouSiziData)


            '************************************************
            '搬送ﾃﾞｰﾀ           ｾｯﾄ
            '************************************************
            txtHansouData01_01.Text = intAryHansouSiziData(0)
            txtHansouData02_01.Text = intAryHansouSiziData(1)
            txtHansouData03_01.Text = intAryHansouSiziData(2)
            txtHansouData04_01.Text = intAryHansouSiziData(3)
            txtHansouData05_01.Text = intAryHansouSiziData(4)
            txtHansouData06_01.Text = intAryHansouSiziData(5)
            txtHansouData07_01.Text = intAryHansouSiziData(6)
            txtHansouData08_01.Text = intAryHansouSiziData(7)
            txtHansouData09_01.Text = intAryHansouSiziData(8)
            txtHansouData10_01.Text = intAryHansouSiziData(9)
            txtHansouData11_01.Text = intAryHansouSiziData(10)
            txtHansouData12_01.Text = intAryHansouSiziData(11)
            txtHansouData13_01.Text = intAryHansouSiziData(12)
            txtHansouData14_01.Text = intAryHansouSiziData(13)

            txtHansouData01_02.Text = intAryHansouSiziData(14)
            txtHansouData02_02.Text = intAryHansouSiziData(15)
            txtHansouData03_02.Text = intAryHansouSiziData(16)
            txtHansouData04_02.Text = intAryHansouSiziData(17)
            txtHansouData05_02.Text = intAryHansouSiziData(18)
            txtHansouData06_02.Text = intAryHansouSiziData(19)
            txtHansouData07_02.Text = intAryHansouSiziData(20)
            txtHansouData08_02.Text = intAryHansouSiziData(21)
            txtHansouData09_02.Text = intAryHansouSiziData(22)
            txtHansouData10_02.Text = intAryHansouSiziData(23)
            txtHansouData11_02.Text = intAryHansouSiziData(24)
            txtHansouData12_02.Text = intAryHansouSiziData(25)
            txtHansouData13_02.Text = intAryHansouSiziData(26)
            txtHansouData14_02.Text = intAryHansouSiziData(27)


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region

End Class