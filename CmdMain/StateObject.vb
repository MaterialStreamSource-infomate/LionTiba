'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｿｹｯﾄ受信ｽﾃｰﾀｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports MateCommon.clsConst
#End Region

Public Class StateObject

#Region "  共通変数"
    Private objWorkSocket As Socket = Nothing           'ｸﾗｲｱﾝﾄｿｹｯﾄ
    Private Const intBufferSize As Integer = 12288      '受信ﾊﾞｯﾌｧｻｲｽﾞ
    Private bytbuffer(intBufferSize) As Byte            '受信ﾊﾞｯﾌｧ
    Private objsb As New StringBuilder                  '受信ﾃﾞｰﾀ文字列
#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' =======================================
    ''' <summary>ｸﾗｲｱﾝﾄｿｹｯﾄ</summary>
    ''' <remarks>Property workSocket</remarks>
    ''' =======================================
    Public Property workSocket( _
       ) As Socket
        Get
            Return objWorkSocket
        End Get
        Set(ByVal Value As Socket)
            objWorkSocket = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>受信ﾊﾞｯﾌｧｻｲｽﾞ</summary>
    ''' <remarks>Property BufferSize</remarks>
    ''' =======================================
    Public ReadOnly Property BufferSize( _
     ) As Integer
        Get
            Return intBufferSize
        End Get
    End Property

    ''' =======================================
    ''' <summary>受信ﾊﾞｯﾌｧ</summary>
    ''' <remarks>Property buffer</remarks>
    ''' =======================================
    Public Property buffer( _
     ) As Byte()
        Get
            Return bytbuffer
        End Get
        Set(ByVal Value As Byte())
            bytbuffer = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>受信ﾃﾞｰﾀ文字列</summary>
    ''' <remarks> Property sb</remarks>
    ''' =======================================
    Public Property sb( _
      ) As StringBuilder
        Get
            Return objsb
        End Get
        Set(ByVal Value As StringBuilder)
            objsb = Value
        End Set
    End Property
#End Region

End Class
