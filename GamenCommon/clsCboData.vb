'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】共通関数
' 【作成】SIT
'**********************************************************************************************


Public Class clsCboData

#Region "  ﾌﾟﾛﾊﾟﾃｨ変数              "
    ''' <summary>ﾌﾟﾛﾊﾟﾃｨ変数</summary>
    Private mstrDisp As String
    Private mstrValue As String
    Public Const DISPLAYMEMBER As String = "Disp"
    Public Const VALUEMEMBER As String = "Value"
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義              "
    ''' <summary>ﾌﾟﾛﾊﾟﾃｨ定義</summary>
    Public Property Disp() As String
        Get
            Return mstrDisp
        End Get
        Set(ByVal Value As String)
            mstrDisp = Value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return mstrValue
        End Get
        Set(ByVal Value As String)
            mstrValue = Value
        End Set
    End Property
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                  "
    ''' <summary>ｺﾝｽﾄﾗｸﾀ</summary>
    Public Sub New(ByVal strDisp As String, ByVal strValue As String)
        mstrDisp = strDisp
        mstrValue = strValue
    End Sub
#End Region
#Region "  ToStringのｵｰﾊﾞｰﾗｲﾄﾞ      "
    ''' <summary>ToStringのｵｰﾊﾞｰﾗｲﾄ</summary>
    Public Overrides Function ToString() As String
        Return mstrDisp
    End Function
#End Region

End Class
