'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】DAIFUKU通信ｸﾗｽ(ｿｹｯﾄ通信)
' 【作成】SIT
'**********************************************************************************************

Public Class clsDaifukuSock

#Region "  共通変数             "

    '==================================================
    '共通変数、ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjOwner As Object                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mobjSock As clsSocketClient         'ｿｹｯﾄ送信ｸﾗｽ(Client)
    Private mobjASCII As clsASCII               'ASCIIｺｰﾄﾞ文字ｸﾗｽ
    Private mstrRecvTelBuff As String           'ｿｹｯﾄ受信ﾊﾞｯﾌｧ

    '==================================================
    'ﾌﾟﾛﾊﾟﾃｨ変数
    '==================================================
    Private mstrSockSendAddress As String       '送信先ｱﾄﾞﾚｽ
    Private mintSockSendPort As Integer         '送信先ﾎﾟｰﾄNo
    Private mintSockRetry As Integer            '送信ﾘﾄﾗｲ回数(回)
    Private mintSockTimeOut As Integer          'ﾀｲﾑｱｳﾄ時間(秒)
    Private mintDebugFlag As Integer            'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
    Private mblnIsConnect As Boolean            'ｿｹｯﾄ接続ﾌﾗｸﾞ

    '==================================================
    '固定値
    '==================================================
    Private Const MSG_001 As String = "ｺﾈｸｼｮﾝ接続完了。"
    Private Const MSG_002 As String = "ｺﾈｸｼｮﾝ切断完了。"
    Private Const MSG_003 As String = "ｺﾈｸｼｮﾝ接続失敗。"

    Private Const MSG_101 As String = "ｺﾞﾐﾃﾞｰﾀ取得 　     :"
    Private Const MSG_102 As String = "受信ﾊﾞｲﾄ数ｵｰﾊﾞｰ 　 :"

    Private Const MSG_602 As String = "受信ﾊﾞｯﾌｧ(追加後)  :"
    Private Const MSG_603 As String = "受信ﾊﾞｯﾌｧ(削除後)  :"

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ              "

    ''' =======================================
    ''' <summary>送信先ｱﾄﾞﾚｽ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strSockSendAddress() As String
        Get
            Return mstrSockSendAddress
        End Get
        Set(ByVal Value As String)
            mstrSockSendAddress = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>送信先ﾎﾟｰﾄNo</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intSockSendPort() As Integer
        Get
            Return mintSockSendPort
        End Get
        Set(ByVal Value As Integer)
            mintSockSendPort = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>送信ﾘﾄﾗｲ回数(回)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intSockRetry() As Integer
        Get
            Return mintSockRetry
        End Get
        Set(ByVal Value As Integer)
            mintSockRetry = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾀｲﾑｱｳﾄ時間(秒)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intSockTimeOut() As Integer
        Get
            Return mintSockTimeOut
        End Get
        Set(ByVal Value As Integer)
            mintSockTimeOut = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ｿｹｯﾄ接続ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property blnIsConnect() As Boolean
        Get
            Return mblnIsConnect
        End Get
        '' ''Set(ByVal Value As Integer)
        '' ''    mintLogWrite = Value
        '' ''End Set
    End Property

#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ  (主にﾛｸﾞ書込みに使用)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object)


        '*****************************************************
        '色々初期化
        '*****************************************************
        mobjOwner = objOwner                    'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
        mobjASCII = New clsASCII()              'ASCIIｺｰﾄﾞ文字ｸﾗｽ
        mstrSockSendAddress = ""                '送信先ｱﾄﾞﾚｽ
        mintSockSendPort = 0                    '送信先ﾎﾟｰﾄNo
        mintSockRetry = 0                       '送信ﾘﾄﾗｲ回数(回)
        mintSockTimeOut = 10                    'ﾀｲﾑｱｳﾄ時間(秒)
        intDebugFlag = 0                        'ﾛｸﾞ書込ﾌﾗｸﾞ


    End Sub
#End Region

#Region "  通信ｵｰﾌﾟﾝ            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 通信ｵｰﾌﾟﾝ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Open()


        If IsNothing(mobjSock) = True Then
            '(ｵﾌﾞｼﾞｪｸﾄが存在しなかった場合)
            mobjSock = New clsSocketClient(mobjOwner)
        End If
        mobjSock.strAddress = mstrSockSendAddress       '送信先ｱﾄﾞﾚｽ
        mobjSock.intPortNo = mintSockSendPort           '送信先ﾎﾟｰﾄNo
        mobjSock.Connect()                              '通信ｵｰﾌﾟﾝ
        If mobjSock.udtRet = clsSocketClient.RetCode.OK Then
            '(接続成功の場合)
            Call AddToLog(MSG_001)
            mblnIsConnect = True
        Else
            '(接続失敗の場合)
            Call AddToLog(MSG_003)
            mblnIsConnect = False
        End If


    End Sub
#End Region
#Region "  通信ｸﾛｰｽﾞ            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 通信ｸﾛｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Close()

        Try
            mobjSock.ShutDown()
        Catch ex As Exception
        End Try
        Call AddToLog(MSG_002)


    End Sub
#End Region
#Region "  再接続処理           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 再接続処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ConnectRetry()


        '===========================================
        '切断
        '===========================================
        Try
            Call Close()
        Catch ex As Exception
            Call ComError(ex)
        End Try

        '===========================================
        '接続
        '===========================================
        Try
            Call Open()
        Catch ex As Exception
            Call ComError(ex)
            mblnIsConnect = False
        End Try


    End Sub
#End Region

#Region "  ﾃﾞｰﾀ受信             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ受信
    ''' </summary>
    ''' <param name="strRecvText">受信ﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub RecvData(ByRef strRecvText As String)
        Try
            Dim strMessage As String        'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
            strRecvText = ""


            '*****************************************************
            'ｿｹｯﾄ再接続処理
            '*****************************************************
            If mblnIsConnect = False Then Call ConnectRetry()
            If mblnIsConnect = False Then Exit Sub


            '*****************************************************
            'ｿｹｯﾄ受信
            '*****************************************************
            While True
                mobjSock.Receive()
                If mobjSock.strRecvText <> "" Then
                    '(受信電文が存在した場合)
                    mstrRecvTelBuff &= mobjSock.strRecvText
                    Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString(mstrRecvTelBuff))
                Else
                    '(受信電文が存在しない場合)
                    Exit While
                End If
            End While


            '*****************************************************
            '正常なﾃﾞｰﾀを取得
            '*****************************************************
            'ﾃﾞｰﾀﾁｪｯｸ
            If IsNull(mstrRecvTelBuff) Then Exit Sub

            'STXの位置検索
            Dim intSTXPlace As Integer
            Dim blnSTXFound As Boolean = False
            For intSTXPlace = 1 To mstrRecvTelBuff.Length
                '(ﾙｰﾌﾟ:STXが見つかるまで)
                If Mid(mstrRecvTelBuff, intSTXPlace, 1) <> mobjASCII.strSTX Then Continue For

                blnSTXFound = True
                Exit For
            Next

            'ETXの位置検索
            Dim intETXPlace As Integer
            Dim blnETXFound As Boolean = False
            For intETXPlace = 1 To mstrRecvTelBuff.Length
                '(ﾙｰﾌﾟ:ETXが見つかるまで)
                If Mid(mstrRecvTelBuff, intETXPlace, 1) <> mobjASCII.strETX Then Continue For

                blnETXFound = True
                Exit For
            Next


            '*****************************************************
            'STX,ETXが先頭にない場合、ｺﾞﾐと判断し削除
            '*****************************************************
            If intSTXPlace <> 1 And intETXPlace <> 1 Then
                '-----------------------------------
                'ｺﾞﾐﾃﾞｰﾀ            取得
                'STX以降のﾃﾞｰﾀ      取得
                '-----------------------------------
                Dim strDust As String           'ｺﾞﾐﾃﾞｰﾀ
                Dim strNotDust As String        'ｺﾞﾐじゃないﾃﾞｰﾀ
                strDust = Mid(mstrRecvTelBuff, 1, intSTXPlace - 1)      'ｺﾞﾐﾃﾞｰﾀ
                strNotDust = Mid(mstrRecvTelBuff, intSTXPlace)          'ｺﾞﾐじゃないﾃﾞｰﾀ

                'ｺﾞﾐﾃﾞｰﾀ取得ﾛｸﾞ出力
                strMessage = ""
                strMessage &= MSG_101
                strMessage &= mobjASCII.GetLogString(strDust)
                Call AddToDebugLog(strMessage)

                'ｺﾞﾐﾃﾞｰﾀ削除
                mstrRecvTelBuff = strNotDust            '一応受信ﾃﾞｰﾀとする
            End If


            If intSTXPlace = 1 _
               And blnSTXFound = True _
               And blnETXFound = True Then
                '(STX、ETX が存在する場合)


                '*****************************************************
                'STX、ETX が存在する場合、ﾃﾞｰﾀ取得
                '*****************************************************
                '====================================
                '電文取得
                '====================================
                If 4 < intETXPlace Then
                    strRecvText = Mid(mstrRecvTelBuff, intSTXPlace + 1, intETXPlace - 4)    '[STX]以降 から BCC直前 まで
                Else
                    strRecvText = ""                                                        '前提としているﾌｫｰﾏｯﾄではない為、受信電文なし
                End If

                '====================================
                'BCCﾁｪｯｸ
                '====================================
                'なし

                '====================================
                'ﾊﾞｲﾄ数ﾁｪｯｸ
                '====================================
                If (512 - 4) < GET_BYTE_LENGTH_STRING(strRecvText) Then
                    '(ﾊﾞｲﾄ数ｵｰﾊﾞｰ)

                    'ﾊﾞｲﾄ数ｵｰﾊﾞｰ
                    strMessage = ""
                    strMessage &= MSG_102
                    strMessage &= GET_BYTE_LENGTH_STRING(strRecvText) & "ﾊﾞｲﾄ"
                    Call AddToDebugLog(strMessage)

                    strRecvText = ""
                End If

                '====================================
                '取得した電文以降のﾃﾞｰﾀを取得 & 更新
                '====================================
                If intETXPlace = mstrRecvTelBuff.Length Then
                    mstrRecvTelBuff = ""
                Else
                    mstrRecvTelBuff = Mid(mstrRecvTelBuff, intETXPlace)
                End If
                'ﾛｸﾞ出力
                strMessage = ""
                strMessage &= MSG_603
                strMessage &= mobjASCII.GetLogString(mstrRecvTelBuff)
                Call AddToDebugLog(strMessage)


            ElseIf intETXPlace = 1 And blnETXFound = True Then
                '(ETX 受信の場合)

                '*****************************************************
                'ETX が先頭の場合、ETXだけを取得
                '*****************************************************
                '====================================
                '電文取得
                '====================================
                strRecvText = Mid(mstrRecvTelBuff, 1, 1)    '[ETX]だけ取得

                '====================================
                '取得した電文以降のﾃﾞｰﾀを取得 & 更新
                '====================================
                If intETXPlace = mstrRecvTelBuff.Length Then
                    mstrRecvTelBuff = ""
                Else
                    mstrRecvTelBuff = Mid(mstrRecvTelBuff, 2)
                End If
                'ﾛｸﾞ出力
                strMessage = ""
                strMessage &= MSG_603
                strMessage &= mobjASCII.GetLogString(mstrRecvTelBuff)
                Call AddToDebugLog(strMessage)


            End If


        Catch ex As Exception
            Call ComError(ex)
            strRecvText = ""
            mblnIsConnect = False

        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀ送信             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ送信
    ''' </summary>
    ''' <param name="strSendText">送信ﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SendData(ByVal strSendText As String)
        Try


            '*****************************************************
            'ｿｹｯﾄ再接続処理
            '*****************************************************
            If mblnIsConnect = False Then Call ConnectRetry()
            If mblnIsConnect = False Then Exit Sub


            '*****************************************************
            '電文作成
            '*****************************************************
            Dim strTel As String
            If strSendText = mobjASCII.strETX Then
                '(ETX送信の場合)
                strTel = ""
                strTel &= strSendText           '電文部分
            Else
                '(通常電文送信の場合)
                strTel = ""
                strTel &= mobjASCII.strSTX      'STX
                strTel &= strSendText           '電文部分
                strTel &= Space(2)              'BCC
                strTel &= mobjASCII.strETX      'ETX
            End If


            '*****************************************************
            '送信
            '*****************************************************
            mobjSock.strSendText = strTel
            mobjSock.Send()
            If mobjSock.udtRet <> clsSocketClient.RetCode.OK Then
                '(失敗の場合)
                mblnIsConnect = False
            End If


        Catch ex As Exception
            Call ComError(ex)
            mblnIsConnect = False

        End Try
    End Sub
#End Region

#Region "  ﾛｸﾞ書き込み処理                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region
#Region "  ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToDebugLog(ByVal strMsg_1 As String)

        If intDebugFlag = 1 Then
            mobjOwner.AddToLog(strMsg_1)
        End If

    End Sub
#End Region
#Region "  ｴﾗｰ処理                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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


        Catch ex2 As Exception
            'NOP
        End Try
    End Sub
#End Region

End Class
