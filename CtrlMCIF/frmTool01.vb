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

            Dim objConfig As New clsConnectConfig(CONFIG_MCIF)                                  'Configﾌｧｲﾙ接続ｸﾗｽ生成
            txtReadSend01_01.Text = TO_INTEGER(objConfig.GET_INFO(GKEY_MEL_SRC_STATION))        '要求先局番を指定
            txtReadSend01_02.Text = TO_INTEGER(objConfig.GET_INFO(GKEY_MEL_CPU_TIMEOUT))        'CPU監視ﾀｲﾏを指定
            txtWriteSend01_01.Text = TO_INTEGER(objConfig.GET_INFO(GKEY_MEL_SRC_STATION))       '要求先局番を指定
            txtWriteSend01_02.Text = TO_INTEGER(objConfig.GET_INFO(GKEY_MEL_CPU_TIMEOUT))       'CPU監視ﾀｲﾏを指定

        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region
#Region "  読込                         ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdRead01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRead01.Click
        Dim strMsg As String = ""
        Dim intRetPLC As ComMelsec.clsMelsec.RetCode
        txtReadRecv01_04.Text = ""

        Try


            '*****************************************************
            'ﾚｼﾞｽﾀ値取得
            '*****************************************************
            Dim bytRead() As Integer = Nothing
            intRetPLC = gobjMain.AreaRead(txtReadSend01_01.Text, ComMelsec.clsMelsec.RegType.D, txtReadSend01_03.Text, txtReadSend01_04.Text, bytRead)
            If intRetPLC <> ComMelsec.clsMelsec.RetCode.OK Then
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
                txtReadRecv01_04.Text &= ZERO_PAD(TO_INTEGER(txtReadSend01_03.Text) + ii, 5) & ":"
                txtReadRecv01_04.Text &= "(" & strData02 & ")"
                txtReadRecv01_04.Text &= "(" & strData16 & ")"
                txtReadRecv01_04.Text &= "(" & SPC_PAD_RIGHT_SJIS(strData10, 5) & ")"
                txtReadRecv01_04.Text &= vbCrLf

            Next
            Call AddToLog(Me.Text & "画面から読込みを行いました。")


        Catch ex As Exception
            Call ComError(ex)
            gobjMain.Close()

        End Try
    End Sub

    'Private Sub cmdRead01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRead01.Click
    '    Dim strMsg As String = ""
    '    Dim intRetPLC As ComMelsec.clsMelsec.RetCode
    '    txtReadRecv01_04.Text = ""


    '    '*****************************************************
    '    '安川PLCｸﾗｽ     生成
    '    '*****************************************************
    '    Dim objMelsec As ComMelsec.clsMelsec   'Melsec通信ｸﾗｽ
    '    objMelsec = New ComMelsec.clsMelsec(mobjOwner)      'Melsec通信ｸﾗｽ
    '    Try


    '        '*****************************************************
    '        'ｵｰﾌﾟﾝ
    '        '*****************************************************
    '        objMelsec.strSockMelSendAddress = "202.243.175.135" 'PLC側IPｱﾄﾞﾚｽ
    '        objMelsec.intSockMelSendPort = 30001                'PLC側ﾎﾟｰﾄNo.
    '        objMelsec.intACPUTimer = txtReadSend01_02.Text      'CPU監視ﾀｲﾏ(250ms単位:自局のと通信の場合"0001"～"0040"(0.25秒～10秒))
    '        objMelsec.intDebugFlag = 1                          'ﾛｸﾞ書き込み(1:有、2:無)
    '        objMelsec.intSockRetry = 3                          'ﾘﾄﾗｲ回数(回)
    '        objMelsec.intSockTimeOut = 10                       'ﾀｲﾑｱｳﾄ時間(秒)(自局:1～10秒、他局:1～60秒)
    '        objMelsec.Open()                                    'ｵｰﾌﾟﾝ


    '        '*****************************************************
    '        'ﾚｼﾞｽﾀ値取得
    '        '*****************************************************
    '        Dim bytRead() As Integer = Nothing
    '        intRetPLC = objMelsec.AreaReadAJ71E71(txtReadSend01_01.Text, ComMelsec.clsMelsec.RegType.D, txtReadSend01_03.Text, txtReadSend01_04.Text, bytRead)
    '        If intRetPLC <> ComMelsec.clsMelsec.RetCode.OK Then
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
    '            txtReadRecv01_04.Text &= ZERO_PAD(TO_INTEGER(txtReadSend01_03.Text) + ii, 5) & ":"
    '            txtReadRecv01_04.Text &= "(" & strData02 & ")"
    '            txtReadRecv01_04.Text &= "(" & strData16 & ")"
    '            txtReadRecv01_04.Text &= "(" & SPC_PAD_RIGHT_SJIS(strData10, 5) & ")"
    '            txtReadRecv01_04.Text &= vbCrLf

    '        Next



    '    Catch ex As Exception
    '        Call ComError(ex)

    '    Finally
    '        Try
    '            objMelsec.Close()
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
            Dim intRetPLC As ComMelsec.clsMelsec.RetCode


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
            intRetPLC = gobjMain.AreaWrite(txtWriteSend01_01.Text, ComMelsec.clsMelsec.RegType.D, txtWriteSend01_03.Text, intWrite.Length, intWrite)
            If intRetPLC <> ComMelsec.clsMelsec.RetCode.OK Then
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
            gobjMain.Close()

        End Try
    End Sub
    'Private Sub cmdWrite01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWrite01.Click
    '    Dim strMsg As String = ""
    '    Dim intRetPLC As ComMelsec.clsMelsec.RetCode


    '    '*****************************************************
    '    '安川PLCｸﾗｽ     生成
    '    '*****************************************************
    '    Dim objMelsec As New ComMelsec.clsMelsec(mobjOwner)
    '    Try


    '        '*****************************************************
    '        'ｵｰﾌﾟﾝ
    '        '*****************************************************
    '        objMelsec.strSockMelSendAddress = "202.243.175.135" 'PLC側IPｱﾄﾞﾚｽ
    '        objMelsec.intSockMelSendPort = 30001                'PLC側ﾎﾟｰﾄNo.
    '        objMelsec.intACPUTimer = txtReadSend01_02.Text      'CPU監視ﾀｲﾏ(250ms単位:自局のと通信の場合"0001"～"0040"(0.25秒～10秒))
    '        objMelsec.intDebugFlag = 1                          'ﾛｸﾞ書き込み(1:有、2:無)
    '        objMelsec.intSockRetry = 3                          'ﾘﾄﾗｲ回数(回)
    '        objMelsec.intSockTimeOut = 10                       'ﾀｲﾑｱｳﾄ時間(秒)(自局:1～10秒、他局:1～60秒)
    '        objMelsec.Open()                                    'ｵｰﾌﾟﾝ


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
    '        intRetPLC = objMelsec.AreaWriteAJ71E71(txtWriteSend01_01.Text, ComMelsec.clsMelsec.RegType.D, txtWriteSend01_03.Text, intWrite.Length, intWrite)
    '        If intRetPLC <> ComMelsec.clsMelsec.RetCode.OK Then
    '            strMsg = "PLCﾚｼﾞｽﾀ内容書込失敗。"
    '            Throw New Exception(strMsg)
    '        End If


    '    Catch ex As Exception
    '        Call ComError(ex)

    '    Finally
    '        Try
    '            objMelsec.Close()
    '        Catch ex As Exception
    '            Call ComError(ex)

    '        End Try
    '    End Try
    'End Sub
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



End Class