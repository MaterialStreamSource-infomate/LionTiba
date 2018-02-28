'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ RS232C ｸﾗｽ
' 【作成】2005/11/08　KSH/S.Ouchi　Rev 0.00　初版
'**********************************************************************************************

Imports System.Net
Imports System.Text
Imports System.IO.Ports

Public MustInherit Class DrvRS232C
    Inherits DrvBase

#Region "共通変数"

    '==================================================
    'ﾌﾟﾛﾊﾟﾃｨ変数
    '==================================================
    '受信用COM設定
    Friend mobjOwner As Object                          'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mstrSerialPort As String                    'ﾎﾟｰﾄ番号              
    Private mintSerialBaud As Integer                   '通信速度              
    Private mintSerialParity As Integer                 'ﾊﾟﾘﾃｨ                 
    Private mintSerialDataLength As Integer             'ﾃﾞｰﾀ長                
    Private mintSerialStopBit As Integer                'ｽﾄｯﾌﾟﾋﾞｯﾄ長           
    Private mstrSerialCheckInterval As String           '割り込みﾁｪｯｸ間隔(ms)  
    Private mstrSerialTimeOut As String                 'ﾀｲﾑｱｳﾄ時間(秒)  
    Private mstrSerialEndString As String               '終端文字列ｺｰﾄﾞ(10進)

#End Region

#Region "プロパティ"
    '***************************************************************
    '   受信用　ﾌﾟﾛﾊﾟﾃｨ
    '***************************************************************
    '==================================================
    '   Property    SerialPort
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
    '   Property    SerialPort
    '==================================================
    ''' <summary>ﾎﾟｰﾄ番号</summary>
    Public Property SerialPort() As String
        Get
            Return mstrSerialPort
        End Get
        Set(ByVal value As String)
            mstrSerialPort = value
        End Set
    End Property
    '==================================================
    '   Property    SerialBaud
    '==================================================
    Public Property SerialBaud() As Integer
        Get
            Return mintSerialBaud
        End Get
        Set(ByVal value As Integer)
            mintSerialBaud = value
        End Set
    End Property
    '==================================================
    '   Property    SerialParity
    '==================================================
    Public Property SerialParity() As String
        Get
            Return mintSerialParity
        End Get
        Set(ByVal value As String)
            mintSerialParity = value
        End Set
    End Property
    '==================================================
    '   Property    SerialDataLength
    '==================================================
    Public Property SerialDataLength() As Integer
        Get
            Return mintSerialDataLength
        End Get
        Set(ByVal value As Integer)
            mintSerialDataLength = value
        End Set
    End Property
    '==================================================
    '   Property    SerialStopBit
    '==================================================
    Public Property SerialStopBit() As String
        Get
            Return mintSerialStopBit
        End Get
        Set(ByVal value As String)
            mintSerialStopBit = value
        End Set
    End Property
    '==================================================
    '   Property    SerialCheckInterval
    '==================================================
    Public Property SerialCheckInterval() As String
        Get
            Return mstrSerialCheckInterval
        End Get
        Set(ByVal value As String)
            mstrSerialCheckInterval = value
        End Set
    End Property
    '==================================================
    '   Property    SerialCheckInterval
    '==================================================
    Public Property SerialTimeOut() As String
        Get
            Return mstrSerialTimeOut
        End Get
        Set(ByVal value As String)
            mstrSerialTimeOut = value
        End Set
    End Property
    '==================================================
    '   Property    SerialEndString
    '==================================================
    Public Property SerialEndString() As String
        Get
            Return mstrSerialEndString
        End Get
        Set(ByVal value As String)
            mstrSerialEndString = value
        End Set
    End Property



    '***************************************************************
    '   その他　ﾌﾟﾛﾊﾟﾃｨ
    '***************************************************************
    '==================================================
    '   Property    CodePage
    '==================================================
    Public Property CodePage() As Integer
        Get
            Return mintCodePage
        End Get
        Set(ByVal value As Integer)
            mintCodePage = value
        End Set
    End Property

#End Region

#Region "初期/終了 処理"
    '==========================================================
    '【機能】コンストラクタ
    '==========================================================
    Public Sub New(ByRef objOwner As Object, _
                   ByVal newSerialPort As String, _
                   ByVal newSerialBaud As Integer, _
                   ByVal newSerialParity As Integer, _
                   ByVal newSerialDataLen As Integer, _
                   ByVal newSerialStopBit As Integer, _
                   ByVal newSerialCodePage As Integer)

        MyBase.New()
        Try

            '============================================
            '初期設定
            '============================================
            mobjOwner = objOwner
            mstrSerialPort = newSerialPort
            mintSerialBaud = newSerialBaud
            mintSerialParity = newSerialParity
            mintSerialDataLength = newSerialDataLen
            mintSerialStopBit = newSerialStopBit
            mintCodePage = newSerialCodePage

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    '==========================================================
    '【機能】デストラクタ
    '==========================================================
    Protected Overrides Sub Finalize()
        MyBase.Finalize()

    End Sub
#End Region

#Region "コマンド送信"
    '==========================================================
    '【機能】コマンド送信
    '【引数】送信コマンド	:	String	SendTX
    '【戻値】返答テキスト	:	String
    '==========================================================
    Public Overrides Function SendMsg(ByVal SendTX As String) As String

        Return ""
    End Function
#End Region

End Class
