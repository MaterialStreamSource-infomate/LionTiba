#Region " imports "
#End Region

''' **************************************************************************************
''' <summary> ｶｽﾀﾑｺﾝﾎﾞﾎﾞｯｸｽ </summary>
''' <remarks>
'''           ｵﾌﾞｼﾞｪｸﾄを複数持つｺﾝﾎﾞﾎﾞｯｸｽ
''' </remarks>
''' **************************************************************************************

Public Class cmpMComboBox

#Region " 列挙体宣言 "
#End Region

#Region " 定数宣言 "
#End Region

#Region " 変数宣言 "

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ1  ｺﾚｸｼｮﾝ</summary>
    ''' ==================================================================
    Private mobjColData_1 As Collection

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ2  ｺﾚｸｼｮﾝ</summary>
    ''' ==================================================================
    Private mobjColData_2 As Collection

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ3  ｺﾚｸｼｮﾝ</summary>
    ''' ==================================================================
    Private mobjColData_3 As Collection

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ4  ｺﾚｸｼｮﾝ</summary>
    ''' ==================================================================
    Private mobjColData_4 As Collection

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ5  ｺﾚｸｼｮﾝ</summary>
    ''' ==================================================================
    Private mobjColData_5 As Collection

#End Region

#Region " ｲﾍﾞﾝﾄ宣言 "
#End Region

#Region " ﾌﾟﾛﾊﾟﾃｨ "

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ1  ｺﾚｸｼｮﾝ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public ReadOnly Property userSELECTED_DATA_1() As Object
        Get
            Return mobjColData_1
        End Get
    End Property

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ2  ｺﾚｸｼｮﾝ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public ReadOnly Property userSELECTED_DATA_2() As Object
        Get
            Return mobjColData_2
        End Get
    End Property

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ3  ｺﾚｸｼｮﾝ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public ReadOnly Property userSELECTED_DATA_3() As Object
        Get
            Return mobjColData_3
        End Get
    End Property

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ4  ｺﾚｸｼｮﾝ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public ReadOnly Property userSELECTED_DATA_4() As Object
        Get
            Return mobjColData_4
        End Get
    End Property

    ''' ==================================================================
    ''' <summary>ﾃﾞｰﾀ5  ｺﾚｸｼｮﾝ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public ReadOnly Property userSELECTED_DATA_5() As Object
        Get
            Return mobjColData_5
        End Get
    End Property

#End Region

#Region " ｲﾍﾞﾝﾄ "

#Region " ｺﾝｽﾄﾗｸﾀ "
    ''' ==================================================================
    ''' <summary>ｺﾝｽﾄﾗｸﾀ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Sub New()

        '-----------------------------------------------
        'vb.net標準部(変更不可)
        '-----------------------------------------------
        InitializeComponent()


        '-----------------------------------------------
        'ｶｽﾀﾑ部(変更可)
        '-----------------------------------------------
        mobjColData_1 = Nothing
        mobjColData_2 = Nothing
        mobjColData_3 = Nothing
        mobjColData_4 = Nothing
        mobjColData_5 = Nothing

    End Sub
#End Region

#End Region

#Region " ﾒｿｯﾄﾞ "

#Region "  ﾃﾞｰﾀを追加               処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】objAddItem         ：ｺﾝﾎﾞﾎﾞｯｸｽに追加するｵﾌﾞｼﾞｪｸﾄ
    '        objData_1          ：内部に保持しておくｵﾌﾞｼﾞｪｸﾄ1
    '        objData_2          ：内部に保持しておくｵﾌﾞｼﾞｪｸﾄ2
    '        objData_3          ：内部に保持しておくｵﾌﾞｼﾞｪｸﾄ3
    '        objData_4          ：内部に保持しておくｵﾌﾞｼﾞｪｸﾄ4
    '        objData_5          ：内部に保持しておくｵﾌﾞｼﾞｪｸﾄ5
    '【戻値】
    '*******************************************************************************************************************
    Public Sub userAddData(ByVal objAddItem As Object, _
                           Optional ByVal objData_1 As Object = "", _
                           Optional ByVal objData_2 As Object = "", _
                           Optional ByVal objData_3 As Object = "", _
                           Optional ByVal objData_4 As Object = "", _
                           Optional ByVal objData_5 As Object = "")
        Try

            Dim intIndex As Integer

            '******************************************
            ' ｺﾝﾎﾞﾎﾞｯｸｽに追加
            '******************************************
            intIndex = Me.Items.Add(objAddItem)

            '******************************************
            ' ｺﾚｸｼｮﾝに追加
            '******************************************
            mobjColData_1.Add(objData_1, CStr(intIndex))
            mobjColData_2.Add(objData_2, CStr(intIndex))
            mobjColData_3.Add(objData_3, CStr(intIndex))
            mobjColData_4.Add(objData_4, CStr(intIndex))
            mobjColData_5.Add(objData_5, CStr(intIndex))

        Catch ex As Exception
            Call DoError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀ_1 取得              処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】intIndex       ：ｲﾝﾃﾞｯｸｽ
    '【戻値】
    '*******************************************************************************************************************
    Private Function userGetData_1(ByVal intIndex As Integer) As Object
        Dim objTemp As Object = Nothing

        '******************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽに追加
        '******************************************
        objTemp = mobjColData_1.Item(CStr(intIndex))

        Return (objTemp)

    End Function
#End Region
#Region "  ﾃﾞｰﾀ_2 取得              処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】intIndex       ：ｲﾝﾃﾞｯｸｽ
    '【戻値】
    '*******************************************************************************************************************
    Private Function userGetData_2(ByVal intIndex As Integer) As Object
        Dim objTemp As Object = Nothing

        '******************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽに追加
        '******************************************
        objTemp = mobjColData_2.Item(CStr(intIndex))

        Return (objTemp)

    End Function
#End Region
#Region "  ﾃﾞｰﾀ_3 取得              処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】intIndex       ：ｲﾝﾃﾞｯｸｽ
    '【戻値】
    '*******************************************************************************************************************
    Private Function userGetData_3(ByVal intIndex As Integer) As Object
        Dim objTemp As Object = Nothing

        '******************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽに追加
        '******************************************
        objTemp = mobjColData_3.Item(CStr(intIndex))

        Return (objTemp)

    End Function
#End Region
#Region "  ﾃﾞｰﾀ_4 取得              処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】intIndex       ：ｲﾝﾃﾞｯｸｽ
    '【戻値】
    '*******************************************************************************************************************
    Private Function userGetData_4(ByVal intIndex As Integer) As Object
        Dim objTemp As Object = Nothing

        '******************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽに追加
        '******************************************
        objTemp = mobjColData_4.Item(CStr(intIndex))

        Return (objTemp)

    End Function
#End Region
#Region "  ﾃﾞｰﾀ_5 取得              処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】intIndex       ：ｲﾝﾃﾞｯｸｽ
    '【戻値】
    '*******************************************************************************************************************
    Private Function userGetData_5(ByVal intIndex As Integer) As Object
        Dim objTemp As Object = Nothing

        '******************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽに追加
        '******************************************
        objTemp = mobjColData_5.Item(CStr(intIndex))

        Return (objTemp)

    End Function
#End Region
#Region "  ﾃﾞｰﾀをｸﾘｱ                処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub userDataClear()
        Try
            '******************************************
            ' ｺﾝﾎﾞﾎﾞｯｸｽｱｲﾃﾑ     ｸﾘｱ
            '******************************************
            Me.Items.Clear()


            '******************************************
            ' ｺﾚｸｼｮﾝ    ｸﾘｱ
            '******************************************
            For ii As Integer = 1 To mobjColData_1.Count
                mobjColData_1.Remove(1)
                mobjColData_2.Remove(1)
                mobjColData_3.Remove(1)
                mobjColData_4.Remove(1)
                mobjColData_5.Remove(1)
            Next


        Catch ex As Exception
            Call DoError(ex)

        End Try
    End Sub
#End Region
#Region "  ｺﾚｸｼｮﾝからﾃﾞｰﾀ取得       処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】objCol         ：取得するｺﾚｸｼｮﾝ
    '【戻値】
    '【備考】ﾌﾟﾛﾊﾟﾃｨ取得時に使用
    '*******************************************************************************************************************
    Private Function GetColSelectedIndex(ByVal objCol As Collection) As Object
        Dim objTemp As Object = Nothing

        objTemp = objCol.Item(CStr(Me.SelectedIndex))

        Return objTemp

    End Function
#End Region

#Region " ｴﾗｰ処理 "
    ''' ==================================================================
    ''' <summary>ｴﾗｰ処理</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub DoError(ByVal ex As Exception)
        MsgBox(ex.Message)
    End Sub
#End Region

#End Region

End Class
