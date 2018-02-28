'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ EtherNet ｸﾗｽ
' 【作成】2005/11/08　KSH/S.Ouchi　Rev 0.00　初版
'**********************************************************************************************

Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public MustInherit Class DrvEther
    Inherits DrvBase

#Region "内部変数"
    '==================================================
    '   内部変数
    '==================================================
    Friend mobjOwner As Object              'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mstrHstNm As String             '送信先ホスト名
    Private mobjIpAdd As IpAddress          '送信先アドレス
    Private mintSdPrt As Integer            '送信ポート
    Private mintRvPrt As Integer            '受信ポート
#End Region

#Region "プロパティ"
    '==================================================
    '   Property    objOwner
    '==================================================
    ''' <summary>ﾎﾟｰﾄ番号</summary>
    Public Property objOwner() As Object
        Get
            Return mobjOwner
        End Get
        Set(ByVal value As Object)
            mobjOwner = value
        End Set
    End Property

    '==================================================
    '   Property    HostName
    '==================================================
    Public Property HostName( _
    ) As String
        Get
            Return mstrHstNm
        End Get
        Set(ByVal Value As String)
            mstrHstNm = Value
        End Set
    End Property

    '==================================================
    '   Property    IpAddress
    '==================================================
    Public Property IpAddress( _
    ) As IpAddress
        Get
            Return mobjIpAdd
        End Get
        Set(ByVal Value As IpAddress)
            mobjIpAdd = Value
        End Set
    End Property

    '==================================================
    '   Property    SendPort
    '==================================================
    Public Property SendPort( _
    ) As Integer
        Get
            Return mintSdPrt
        End Get
        Set(ByVal Value As Integer)
            mintSdPrt = Value
        End Set
    End Property

    '==================================================
    '   Property    RecvPort
    '==================================================
    Public Property RecvPort( _
    ) As Integer
        Get
            Return mintRvPrt
        End Get
        Set(ByVal Value As Integer)
            mintRvPrt = Value
        End Set
    End Property
#End Region

#Region "初期/終了 処理"
    '==========================================================
    '【機能】コンストラクタ
    '【引数】ホスト名   :	String	Host
    '        送信ポート	:	int		newSendPort
    '        受信ポート	:	int		newRecvPort
    '==========================================================
    Public Sub New(ByRef objOwner As Object, ByVal Host As String, ByVal newSendPort As Integer, ByVal newRecvPort As Integer)
        MyBase.New()
        Try
            'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
            mobjOwner = objOwner

            '送信先ホスト名をセット
            mstrHstNm = Host

            '送信先アドレスをセット
            Try
                mobjIpAdd = IpAddress.Parse(Host)
            Catch ex As FormatException
                mobjIpAdd = Dns.GetHostEntry(Host).AddressList(0)
            End Try

            ' 送信ポートをセット
            mintSdPrt = newSendPort

            ' 受信ポートをセット
            mintRvPrt = newRecvPort
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
            mobjIpAdd = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "仮想関数"
    '==========================================================
    '【機能】仮想関数
    '【機能】メッセージ送信処理
    '【引数】送信コマンド	:	String	SendTX
    '【戻値】返答テキスト	:	String
    '==========================================================
    Public Overrides Function SendMsg(ByVal SendTX As String) As String

        Dim strRet As String = ""               '戻値

        Return strRet

    End Function

#End Region

End Class
