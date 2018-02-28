'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ EtherNetTCP ｸﾗｽ
' 【作成】2005/11/08　KSH/S.Ouchi　Rev 0.00　初版
'**********************************************************************************************

Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class DrvTCP
    Inherits DrvEther

#Region "内部変数"
    '==================================================
    '   内部変数
    '==================================================
    Private mobjEndPoint As IPEndPoint
    Private mobjTcpClient As System.Net.Sockets.TcpClient
    Private mobjNetworkStream As NetworkStream
    Private mbytSockRecvData() As Byte              'ｿｹｯﾄ受信ﾃﾞｰﾀ格納ﾊﾞｯﾌｧ

    Private mstrKyokuNo As String                   '局番号
    Private mstrNetwkNo As String                   'ﾈｯﾄﾜｰｸ番号
    Private mstrPcNo As String                      'PC番号
    Private mstrJiKyoku As String                   '自局局番
    Private mstrUnitIo As String                    '要求先ﾕﾆｯﾄI/O番号
#End Region

#Region "初期/終了 処理"
    '==========================================================
    '【機能】コンストラクタ
    '【引数】ホスト名   :	String	Host
    '        送信ポート	:	int		newSendPort
    '==========================================================
    Public Sub New(ByRef objOwner As Object, ByVal Host As String, ByVal newSendPort As Integer)
        Me.New(objOwner, Host, newSendPort, 0)
    End Sub

    '==========================================================
    '【機能】コンストラクタ
    '【引数】ホスト名   :	String	Host
    '        送信ポート	:	int		newSendPort
    '        受信ポート	:	int		newRecvPort
    '==========================================================
    Public Sub New(ByRef objOwner As Object, ByVal Host As String, ByVal newSendPort As Integer, ByVal newRecvPort As Integer)
        MyBase.New(objOwner, Host, newSendPort, newRecvPort)
        Try
            '' ''mobjEndPoint = New IPEndPoint(MyBase.IpAddress, MyBase.SendPort)
            '' ''mobjTcpClient = New System.Net.Sockets.TcpClient
            '' ''mobjTcpClient.Connect(mobjEndPoint)
            '' ''mobjNetworkStream = mobjTcpClient.GetStream()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '==========================================================
    '【機能】デストラクタ
    '==========================================================
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Try
            mobjNetworkStream = Nothing
            If Not mobjTcpClient Is Nothing Then
                mobjTcpClient.Close()
                mobjTcpClient = Nothing
            End If
            mobjEndPoint = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "接続/切断"
    '==========================================================
    '【機能】接続
    '==========================================================
    Public Sub Connect()
        Try
            mobjEndPoint = Nothing
            mobjTcpClient = Nothing
            mobjTcpClient = New System.Net.Sockets.TcpClient
            mobjNetworkStream = Nothing
            mobjEndPoint = New IPEndPoint(MyBase.IpAddress, MyBase.SendPort)
            mobjTcpClient.Connect(mobjEndPoint)
            mobjNetworkStream = mobjTcpClient.GetStream()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '==========================================================
    '【機能】切断
    '==========================================================
    Public Sub Close()
        Try
            mobjNetworkStream = Nothing
            If Not mobjTcpClient Is Nothing Then
                mobjTcpClient.Close()
                mobjTcpClient = Nothing
            End If
            mobjEndPoint = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "コマンド送信"
    '==========================================================
    '【機能】コマンド送信
    '【引数】送信コマンド	:	String	SendTX
    '【戻値】返答テキスト	:	String
    '==========================================================
    Public Overrides Function SendMsg(ByVal SendTX As String) As String
        Try
            If mobjNetworkStream.CanWrite And mobjNetworkStream.CanRead Then
                mstrNetwkNo = Mid(SendTX, 5, 2)             'ﾈｯﾄﾜｰｸ番号
                mstrPcNo = Mid(SendTX, 7, 2)                'PC番号
                mstrUnitIo = Mid(SendTX, 9, 4)              '要求先ﾕﾆｯﾄI/O番号
                mstrKyokuNo = Mid(SendTX, 13, 2)            '局番号

                '*****************************************************
                'ﾊﾞｲﾄに変換
                '*****************************************************
                Dim bytSend() As Byte
                bytSend = StringToByte(SendTX)

                '*****************************************************
                '受信ﾊﾞｯﾌｧｸﾘｱ
                '*****************************************************
                mbytSockRecvData = Nothing

                '*****************************************************
                '送信
                '*****************************************************
                mobjNetworkStream.Write(bytSend, 0, bytSend.Length)
                AddToLog("送信=" & ByteToString(bytSend))

                '返答受信
                Dim bytes(mobjTcpClient.ReceiveBufferSize) As Byte
                Dim intReadLen As Integer
                intReadLen = mobjNetworkStream.Read(bytes, 0, CInt(mobjTcpClient.ReceiveBufferSize))
                If intReadLen > 0 Then
                    ReDim Preserve mbytSockRecvData(intReadLen - 1)
                    Array.Copy(bytes, 0, mbytSockRecvData, 0, intReadLen)
                End If
                SendMsg = Encoding.ASCII.GetString(mbytSockRecvData)

            Else
                Close()
                Connect()
                Throw New Exception("SendMsg Read/Write StatusError")
            End If
        Catch ex As Exception
            Close()
            Connect()
            Throw New Exception("SendMsg Read/Write ConnectionError")

        End Try
    End Function
#End Region

#Region "ｼﾘｱﾙ通信受信ﾃｷｽﾄ取得"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ OUT ]strReceiveData  ：正常に受信できたﾃﾞｰﾀ
    '        [ OUT ]strResponsCode  ：応答ｺｰﾄﾞ
    '【戻値】変換したﾊﾞｲﾄ配列
    '*******************************************************************************************************************
    Public Sub ReceiveText(ByRef strReceiveData As String, _
                           ByRef strRetCode As String)


        '*****************************************************
        '受信用ﾎﾟｰﾄか送信用ﾎﾟｰﾄか選択
        '*****************************************************
        Call ReceiveText_Main(strReceiveData, _
                              mbytSockRecvData, _
                              strRetCode _
                              )


    End Sub
#End Region

#Region "  ｼﾘｱﾙ通信受信ﾃｷｽﾄ取得"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ OUT ]strReceiveData  ：正常に受信できたﾃﾞｰﾀ
    '        [ OUT ]objSerialPort   ：使用するｼﾘｱﾙﾎﾟｰﾄ
    '        [ OUT ]bytBuffer       ：使用する受信格納ﾊﾞｯﾌｧ
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub ReceiveText_Main(ByRef strReceiveData As String, _
                                ByRef bytBuffer() As Byte, _
                                ByRef strRetCode As RetCode)
        strRetCode = RetCode.OTHER

        '*****************************************************
        '正常なﾃﾞｰﾀを取得
        '*****************************************************
        'ﾃﾞｰﾀﾁｪｯｸ
        If IsNothing(bytBuffer) Then Exit Sub
        If bytBuffer.Length = 0 Then
            bytBuffer = Nothing
            Exit Sub
        End If

        '====================================================
        'ﾃﾞｰﾀ取得
        '====================================================
        Dim strRecvMsg As String
        Dim strSubHeader As String                  'ｻﾌﾞﾍｯﾀﾞ
        Dim strNetwkNo As String                    'ﾈｯﾄﾜｰｸ番号
        Dim strPcNo As String                       'PC番号
        Dim strUnitIo As String                     '要求先ﾕﾆｯﾄI/O番号
        Dim strKyokuNo As String                    '局番号
        Dim strLen As String                        'ﾃﾞｰﾀ長
        Dim intLen As Integer                       'ﾃﾞｰﾀ長
        Dim strEndCode As String                    '終了ｺｰﾄﾞ
        Dim intEndCode As Integer                   '終了ｺｰﾄﾞ(ﾃﾞｰﾀ長)
        Dim strRecv As String                       '応答ﾃﾞｰﾀ
        Dim intRecv As Integer                      '応答ﾃﾞｰﾀ(ﾃﾞｰﾀ長)

        strRecvMsg = ByteToString(bytBuffer)
        AddToLog("  受信=" & strRecvMsg)

        '-----------------------------------
        '受信電文分解
        '-----------------------------------
        strSubHeader = Mid(strRecvMsg, 1, 4)            'ｻﾌﾞﾍｯﾀﾞ   
        strNetwkNo = Mid(strRecvMsg, 5, 2)              'ﾈｯﾄﾜｰｸ番号
        strPcNo = Mid(strRecvMsg, 7, 2)                 'PC番号
        strUnitIo = Mid(strRecvMsg, 9, 4)               '要求先ﾕﾆｯﾄI/O番号
        strKyokuNo = Mid(strRecvMsg, 13, 2)             '局番号
        strLen = Mid(strRecvMsg, 15, 4)                 'ﾃﾞｰﾀ長
        intLen = Change16To10(strLen)                   'ﾃﾞｰﾀ長
        strEndCode = Mid(strRecvMsg, 19, 4)             '終了ｺｰﾄﾞ
        intEndCode = GET_BYTE_LENGTH_STRING(strEndCode) '終了ｺｰﾄﾞ(ﾃﾞｰﾀ長)
        strRecv = Mid(strRecvMsg, 23)                   '応答ﾃﾞｰﾀ
        intRecv = GET_BYTE_LENGTH_STRING(strRecv)       '応答ﾃﾞｰﾀ(ﾃﾞｰﾀ長)

        '-----------------------------------
        'ｻﾌﾞﾍｯﾀﾞ
        '-----------------------------------
        If strSubHeader <> "D000" Then
            AddToLog("  ｻﾌﾞﾍｯﾀﾞ異常=" & strSubHeader)

            strReceiveData = ""
            bytBuffer = Nothing
            strRetCode = RetCode.NG
            Exit Sub
        End If

        '-----------------------------------
        'ﾈｯﾄﾜｰｸ番号
        '-----------------------------------
        If strNetwkNo <> mstrNetwkNo Then
            AddToLog("  ﾈｯﾄﾜｰｸ番号異常=" & strNetwkNo)

            strReceiveData = ""
            bytBuffer = Nothing
            strRetCode = RetCode.NG
            Exit Sub
        End If

        '-----------------------------------
        'PC番号
        '-----------------------------------
        If strPcNo <> mstrPcNo Then
            AddToLog("  PC番号異常=" & strPcNo)

            strReceiveData = ""
            bytBuffer = Nothing
            strRetCode = RetCode.NG
            Exit Sub
        End If

        '-----------------------------------
        '要求先ﾕﾆｯﾄI/O番号
        '-----------------------------------
        If strUnitIo <> mstrUnitIo Then
            AddToLog("  要求先ﾕﾆｯﾄI/O番号異常=" & strUnitIo)

            strReceiveData = ""
            bytBuffer = Nothing
            strRetCode = RetCode.NG
            Exit Sub
        End If

        '-----------------------------------
        '局番号
        '-----------------------------------
        If strKyokuNo <> mstrKyokuNo Then
            AddToLog("  局番号異常=" & strKyokuNo)

            strReceiveData = ""
            bytBuffer = Nothing
            strRetCode = RetCode.NG
            Exit Sub
        End If

        '-----------------------------------
        'ﾃﾞｰﾀ長
        '-----------------------------------
        If intLen <> (intEndCode + intRecv) Then
            AddToLog("  ﾃﾞｰﾀ長異常=" & intLen)

            strReceiveData = ""
            bytBuffer = Nothing
            strRetCode = RetCode.NG
            Exit Sub
        End If

        '-----------------------------------
        '終了ｺｰﾄﾞ
        '-----------------------------------
        If strEndCode <> "0000" Then
            AddToLog("  終了ｺｰﾄﾞ異常=" & strEndCode)

            strReceiveData = ""
            bytBuffer = Nothing
            strRetCode = RetCode.NG
            Exit Sub
        End If

        '*****************************************************
        '正常に受信できたﾃﾞｰﾀを設定
        '*****************************************************
        strReceiveData = strRecv
        bytBuffer = Nothing
        strRetCode = RetCode.OK

    End Sub
#End Region

#Region "  ﾛｸﾞ書き込み処理"
    Public Sub AddToLog(ByVal strMsg_1 As String)

        strMsg_1 = Replace(strMsg_1, mstrSTX, strSTXDisp)
        strMsg_1 = Replace(strMsg_1, mstrETX, strETXDisp)
        strMsg_1 = Replace(strMsg_1, mstrENQ, strENQDisp)
        strMsg_1 = Replace(strMsg_1, mstrACK, strACKDisp)
        strMsg_1 = Replace(strMsg_1, mstrNAK, strNAKDisp)
        strMsg_1 = Replace(strMsg_1, CR, strCRDisp)
        strMsg_1 = Replace(strMsg_1, LF, strLFDisp)
        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
