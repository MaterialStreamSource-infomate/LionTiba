'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ EtherNetUDP ｸﾗｽ
' 【作成】2005/11/08　KSH/S.Ouchi　Rev 0.00　初版
'**********************************************************************************************

Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class DrvUDP
    Inherits DrvEther

#Region "内部変数"
    '==================================================
    '   内部変数
    '==================================================
    Private mobjEndPoint As IPEndPoint
    Private mobjUdpClient As New System.Net.Sockets.UdpClient
#End Region

#Region "初期/終了 処理"
    '==========================================================
    '【機能】コンストラクタ
    '【引数】ホスト名   :	String	Host
    '        送信ポート	:	int		newSendPort
    '==========================================================
    Public Sub New(ByRef objOwner As Object, ByVal Host As String, ByVal newSendPort As Integer)
        Me.New(objOwner, Host, newSendPort, newSendPort)
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
            mobjEndPoint = New IPEndPoint(MyBase.IpAddress, MyBase.SendPort)
            mobjUdpClient = New System.Net.Sockets.UdpClient(MyBase.RecvPort)
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
            If Not mobjUdpClient Is Nothing Then
                mobjUdpClient.Close()
                mobjUdpClient = Nothing
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
            'コマンド送信
            Dim bytSendBytes As [Byte]() = Encoding.ASCII.GetBytes(SendTX)
            mobjUdpClient.Send(bytSendBytes, bytSendBytes.Length, mobjEndPoint)

            '返答受信
            Dim bytes() As Byte
            bytes = mobjUdpClient.Receive(mobjEndPoint)
            SendMsg = Encoding.ASCII.GetString(bytes)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
