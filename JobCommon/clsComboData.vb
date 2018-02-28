'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
' 【機能】ｺﾝﾎﾞﾃﾞｰﾀｸﾗｽ
' 【作成】SIT
'**********************************************************************************************
Public Class clsComboData

#Region " 変数宣言 "

    Private aDisplayData As String
    Private aValueData As String
    Private aDescriptionData As String
    'Private aImageData As Object

#End Region

#Region " ｺﾝｽﾄﾗｸﾀ "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strDisplay">表示ﾃﾞｰﾀ</param>
    ''' <param name="strData">実際の値</param>
    ''' <param name="strDescription">説明文[省略可]</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal strDisplay As String, ByVal strData As String, Optional ByVal strDescription As String = "")
        MyBase.New()
        Me.aDisplayData = strDisplay
        Me.aValueData = strData
        Me.aDescriptionData = strDescription
        'Me.aImageData = iData
    End Sub

#End Region

#Region " ﾌﾟﾛﾊﾟﾃｨ "
    ''' =======================================
    ''' <summary>表示ﾃﾞｰﾀ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property DisplayData() As String
        Get
            Return Me.aDisplayData
        End Get
    End Property
    ''' =======================================
    ''' <summary>実際の値</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ValueData() As String
        Get
            Return Me.aValueData
        End Get
    End Property

    ''' =======================================
    ''' <summary>説明文</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property DescriptionData() As String
        Get
            Return Me.aDescriptionData
        End Get
    End Property

    'Public ReadOnly Property ImageData() As Object
    '    Get
    '        Return aImageData
    '    End Get
    'End Property

#End Region

#Region " ﾒｿｯﾄﾞ "

    Public Overrides Function ToString() As String
        Return Me.DisplayData + " - " + Me.DescriptionData + " - " + Me.ValueData
    End Function

#End Region

End Class
