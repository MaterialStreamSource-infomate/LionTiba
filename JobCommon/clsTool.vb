'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
' 【機能】ﾂｰﾙｸﾗｽ
' 【作成】KSH
'**********************************************************************************************
Public Class clsTool

#Region " LenB 指定文字列のﾊﾞｲﾄ数を返す "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 指定文字列のﾊﾞｲﾄ数を返す
    ''' </summary>
    ''' <param name="strData">文字列</param>
    ''' <returns>ﾊﾞｲﾄ数</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function LenB(ByVal strData As String) As Long
        Dim Data() As Byte
        Dim nLen As Long

        Data = System.Text.Encoding.Default.GetBytes(strData)
        nLen = Data.Length
        Return nLen
    End Function
#End Region

#Region " LeftB 指定の文字列を左から指定ﾊﾞｲﾄ数分ｺﾋﾟｰ "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 指定の文字列を左から指定ﾊﾞｲﾄ数分ｺﾋﾟｰする
    ''' </summary>
    ''' <param name="strData">文字列</param>
    ''' <param name="cnt">切り出しﾊﾞｲﾄ数</param>
    ''' <returns>切り出した文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function LeftB(ByVal strData As String, ByVal cnt As Integer) As String
        Dim Data() As Byte
        Dim strRet As String = ""
        Dim nLen As Integer

        Data = System.Text.Encoding.Default.GetBytes(strData)
        nLen = IIf(Data.Length < cnt, Data.Length, cnt)
        If nLen > 0 Then
            Dim data2(nLen - 1) As Byte
            Array.Copy(Data, 0, data2, 0, nLen)
            strRet = System.Text.Encoding.Default.GetString(data2)
        End If
        Return strRet
    End Function
#End Region

#Region " MidB 指定の文字列を指定位置から指定ﾊﾞｲﾄ数分ｺﾋﾟｰ "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 指定の文字列を指定位置から指定ﾊﾞｲﾄ数分ｺﾋﾟｰする
    ''' </summary>
    ''' <param name="strData">文字列</param>
    ''' <param name="st">開始位置</param>
    ''' <param name="cnt">切り出しﾊﾞｲﾄ数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function MidB(ByVal strData As String, ByVal st As Integer, ByVal cnt As Integer) As String
        Dim Data() As Byte
        Dim strRet As String = ""
        Dim nLen As Integer

        Data = System.Text.Encoding.Default.GetBytes(strData)
        nLen = IIf(Data.Length < (st - 1) + cnt, Data.Length - (st - 1), cnt)
        If nLen > 0 Then
            Dim data2(nLen - 1) As Byte
            Array.Copy(Data, st - 1, data2, 0, nLen)
            strRet = System.Text.Encoding.Default.GetString(data2)
        End If
        Return strRet
    End Function
#End Region

End Class
