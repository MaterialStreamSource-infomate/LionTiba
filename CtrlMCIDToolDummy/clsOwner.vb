'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCIｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
' 【作成】SIT
'**********************************************************************************************

Imports MateCommon
Imports MateCommon.clsConst


Public Class clsOwner

    Private mobjfrmMCI As frmMCIDummy            'ﾒｲﾝﾌｫｰﾑ

#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    Public Property STRENTRY_NO() As frmMCIDummy
        Get
            Return mobjfrmMCI
        End Get
        Set(ByVal Value As frmMCIDummy)
            mobjfrmMCI = Value
        End Set
    End Property
#End Region

#Region "  ﾛｸﾞ書込処理1"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理1
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <param name="strProd"></param>
    ''' <param name="intType"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, _
                        ByVal strProd As String, _
                        ByVal intType As Integer)

        Call gobjMCI.AddToLog(strMsg & Space(5) & strProd)


    End Sub
#End Region

#Region "  ﾛｸﾞ書込処理2"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理2"
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        Call gobjMCI.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
