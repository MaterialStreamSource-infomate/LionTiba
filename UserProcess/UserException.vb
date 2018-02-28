'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾕｰｻﾞｰｴﾗｰｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Public Class UserException
    Inherits System.ApplicationException

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="strUserMessage"></param>
    ''' <param name="blnAddLog">
    ''' True :ｴﾗｰﾛｸﾞを残す(ﾃﾞﾌｫﾙﾄ)
    ''' False:ｴﾗｰﾛｸﾞを残さない
    ''' </param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal strUserMessage As String _
                 , Optional ByVal blnAddLog As Boolean = True _
                 )
        MyBase.New(strUserMessage)
        mblnAddLog = blnAddLog
    End Sub
#End Region
#Region "ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰﾛｸﾞ出力ﾌﾗｸﾞ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Property blnAddLog() As Boolean
        Get
            Return mblnAddLog
        End Get
        Set(ByVal Value As Boolean)
            mblnAddLog = Value
        End Set
    End Property
#End Region
#Region "  内部変数定義"
    Private mblnAddLog As Boolean   'ｴﾗｰﾛｸﾞ出力ﾌﾗｸﾞ
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
