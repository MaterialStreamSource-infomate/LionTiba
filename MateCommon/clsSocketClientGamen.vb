'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｿｹｯﾄ送信ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Imports MateCommon.clsConst
Imports MateCommon
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text

Public Class clsSocketClientGamen
    Inherits clsSocketClient

#Region "  共通変数"

    '↓↓↓ 2012.11.16 12:58 「しばらくお待ちください」ﾀﾞｲｱﾛｸﾞﾎﾞｯｸｽ 白くなる防ぐ対応
    Private Declare Function GetInputState Lib "USER32" () As Long   'GetInputState関数はｲﾍﾞﾝﾄｷｭに待機中のｲﾍﾞﾝﾄがあるか調べる
    '↑↑↑ 2012.11.16 12:58 「しばらくお待ちください」ﾀﾞｲｱﾛｸﾞﾎﾞｯｸｽ 白くなる防ぐ対応

    Private mblnReceiveFlag As Boolean      '応答ｿｹｯﾄ待機ﾌﾗｸﾞ
    Private mintTimeOut As Integer          'ﾀｲﾑｱｳﾄ時間（ms）

#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    Public Sub New(ByVal objOwner As Object)

        MyBase.New(objOwner)

        Try

            mblnReceiveFlag = False                            '応答ｿｹｯﾄ待機ﾌﾗｸﾞ
            mintTimeOut = 10000                                 'ﾀｲﾑｱｳﾄ時間（ms）


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ"

    Public Property intTimeOut() As Integer
        Get
            Return mintTimeOut
        End Get
        Set(ByVal Value As Integer)
            mintTimeOut = Value
        End Set
    End Property

    Public Property blnReceiveFlag() As Boolean
        Get
            Return mblnReceiveFlag
        End Get
        Set(ByVal Value As Boolean)
            mblnReceiveFlag = Value
        End Set
    End Property

#End Region

#Region "  ｿｹｯﾄ送信(毎回接続、切断する画面用)   処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SendSock()
        Try
            Dim intRet As Integer
            Dim dtmNow As Date = Now            '現在時刻
            Dim Buffer_Send() As Byte           '送信用ﾊﾞｯﾌｧ
            Dim Buffer_Recv() As Byte           '受信用ﾊﾞｯﾌｧ
            Dim objIpAddress As IPAddress          'IPｱﾄﾞﾚｽ取得
            'Dim localEndPoint As New IPEndPoint(Dns.Resolve(mstrADDRESS).AddressList(0), _
            '                                    mintPORT_NO)                               'IPｱﾄﾞﾚｽ、PORT 設定
            Dim localEndPoint As IPEndPoint                                                 'IPｱﾄﾞﾚｽ、PORT 設定
            Dim objSocket As Socket = New Socket(AddressFamily.InterNetwork, _
                                                 SocketType.Stream, _
                                                 ProtocolType.Tcp)


            '*************************************************
            'EndPoint取得
            '*************************************************
            Try
                objIpAddress = IPAddress.Parse(mstrAddress)
            Catch ex As FormatException
                Dim oLog As New clsWriteLog
                oLog.WriteLog("IPｱﾄﾞﾚｽ Parse 異常 [" & ex.Message & "]")
                objIpAddress = Dns.GetHostEntry(mstrAddress).AddressList(0)
            End Try

            localEndPoint = New IPEndPoint(objIpAddress, _
                                                   mintPortNo)

            '*************************************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '*************************************************
            If mstrAddress = "" Or _
               mintPortNo = -1 Or _
               mstrSendText = "" Then
                mudtRET = RetCode.PropertyError
                Exit Sub
            End If


            '*************************************************
            'ｻｰﾊﾞｰ接続
            '*************************************************
            Try
                objSocket.Connect(localEndPoint)            '接続
                If objSocket.Connected = False Then         '接続の確認
                    Throw New Exception
                End If
            Catch ex As Exception
                mudtRET = RetCode.ConnectError
                Exit Sub
            End Try


            '*************************************************
            '送信
            '*************************************************
            Buffer_Send = StringToByte(mstrSendText)
            intRet = objSocket.Send(Buffer_Send, _
                                    0, _
                                    Buffer_Send.Length, _
                                    SocketFlags.None)               '送信
            AddToLog("ﾏﾃｽﾄｻｰﾊﾞへｿｹｯﾄを送信しました   ：" & mstrSendText)


            '*************************************************
            '受信
            '*************************************************
            If mblnReceiveFlag = True Then

                While objSocket.Available = 0
                    If DateAdd(DateInterval.Second, CInt(mintTimeOut / 1000), dtmNow) < Now Then
                        mudtRET = RetCode.ReceiveTimeOut
                        Exit Sub
                    End If

                    '↓↓↓ 2012.11.16 12:58 「しばらくお待ちください」ﾀﾞｲｱﾛｸﾞﾎﾞｯｸｽ 白くなる防ぐ対応
                    '* 2012/11/29 11:00 H.Morita ﾎﾞﾀﾝが再度押せてしまう。Windowsﾒｯｾｰｼﾞが処理されるので止める * If GetInputState() Then System.Windows.Forms.Application.DoEvents()
                    '↑↑↑ 2012.11.16 12:58 「しばらくお待ちください」ﾀﾞｲｱﾛｸﾞﾎﾞｯｸｽ 白くなる防ぐ対応

                    System.Threading.Thread.Sleep(100)
                End While

                ReDim Buffer_Recv(objSocket.Available)
                objSocket.Receive(Buffer_Recv, _
                                  0, _
                                  objSocket.Available, _
                                  SocketFlags.None)                         '受信
                mstrRecvText = mobjEncode.GetString(Buffer_Recv)           'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

            End If


            '*************************************************
            'ｻｰﾊﾞｰ切断
            '*************************************************
            objSocket.Shutdown(SocketShutdown.Both)
            objSocket.Close()


            mudtRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region

End Class