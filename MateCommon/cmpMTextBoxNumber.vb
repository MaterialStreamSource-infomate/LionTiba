#Region " imports "
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Drawing
#End Region

''' **************************************************************************************
''' <summary> ｶｽﾀﾑﾃｷｽﾄﾎﾞｯｸｽ </summary>
''' <remarks>
'''           入力ﾁｪｯｸ付き数字入力ﾃｷｽﾄﾎﾞｯｸｽ
''' </remarks>
''' **************************************************************************************

Public Class cmpMTextBoxNumber

#Region " 列挙体宣言 "
#End Region

#Region " 定数宣言 "
#End Region

#Region " 変数宣言 "

    ''' ==================================================================
    ''' <summary>ﾃﾞﾌｫﾙﾄ背景色</summary>
    ''' ==================================================================
    Private mcolBackColorDefault As Color

    ''' ==================================================================
    ''' <summary>ﾏｽｸ背景色</summary>
    ''' ==================================================================
    Private mcolBackColorMask As Color

    ''' ==================================================================
    ''' <summary>ﾌｫｰﾏｯﾄ</summary>
    ''' ==================================================================
    Private mstrFormat As String

    ''' ==================================================================
    ''' <summary>最大値</summary>
    ''' ==================================================================
    Private mdecMaxValue As Decimal

    ''' ==================================================================
    ''' <summary>最小値</summary>
    ''' ==================================================================
    Private mdecMinValue As Decimal

    ''' ==================================================================
    ''' <summary>前回値</summary>
    ''' ==================================================================
    Private mstrBeforeValue As String

    ''' ==================================================================
    ''' <summary>数値ﾃﾞｰﾀ</summary>
    ''' ==================================================================
    Private mstrValue As String

    ''' ==================================================================
    ''' <summary>Null許可</summary>
    ''' ==================================================================
    Private mblnNullable As Boolean

    ''' ==================================================================
    ''' <summary>元ｶｰｿﾙ位置</summary>
    ''' ==================================================================
    Private mintPosBefore As Integer

    ''' ==================================================================
    ''' <summary>ｲﾍﾞﾝﾄ処理中ﾌﾗｸﾞ</summary>
    ''' ==================================================================
    Private blnEventStop As Boolean = False

#End Region

#Region " ｲﾍﾞﾝﾄ宣言 "
    Public Event ValueChanged(ByVal strValueBefore As String, ByVal strValueNew As String)
#End Region

#Region " ﾌﾟﾛﾊﾟﾃｨ "

    ''' ==================================================================
    ''' <summary>ﾏｽｸ背景色</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property BackColorMask() As Color
        Get
            Return mcolBackColorMask
        End Get
        Set(ByVal value As Color)
            mcolBackColorMask = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>ﾌｫｰﾏｯﾄ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property Format() As String
        Get
            Return mstrFormat
        End Get
        Set(ByVal value As String)
            If value <> String.Empty Then
                '(ﾌﾞﾗﾝｸ以外の場合)
                Try
                    Dim objRegex As Regex
                    objRegex = New Regex("^[0#,.]+$")
                    If objRegex.IsMatch(value) = False Then
                        '(NGの場合)
                        Throw New Exception("正しい書式を入力して下さい。")
                    End If
                Catch ex As Exception
                    Call DoError(ex)
                    value = mstrFormat
                End Try
            End If
            mstrFormat = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>最大値</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property MaxValue() As Decimal
        Get
            Return mdecMaxValue
        End Get
        Set(ByVal value As Decimal)
            mdecMaxValue = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>最小値</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property MinValue() As Decimal
        Get
            Return mdecMinValue
        End Get
        Set(ByVal value As Decimal)
            mdecMinValue = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>数値ﾃﾞｰﾀ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property Value() As String
        Get
            Return mstrValue
        End Get
        Set(ByVal setValue As String)
            Try
                If (mblnNullable = False) And (setValue = String.Empty) Then
                    '(NGの場合)
                    Throw New Exception("正しい値を入力して下さい。")
                ElseIf (setValue <> String.Empty) And (IsNumeric(setValue) = False) Then
                    '(NGの場合)
                    Throw New Exception("正しい値を入力して下さい。")
                ElseIf (setValue <> String.Empty) AndAlso (setValue.Length > 1) AndAlso (InStr(setValue.Substring(1), "-") > 0) Then
                    '(NGの場合)
                    Throw New Exception("正しい値を入力して下さい。")
                End If

                '-----> 2011/06/20 kato (add) Valueの小数点以下文字数がフォーマットの小数点以下文字数を超えないよう調整
                Dim intPeriodValue As Integer = InStr(setValue, ".")
                Dim intPeriodFormat As Integer = InStr(Me.Format, ".")
                Dim strPlacesValue As String = IIf(intPeriodValue = 0, String.Empty, Mid(setValue, intPeriodValue + 1))
                Dim strPlacesFormat As String = IIf(intPeriodFormat = 0, String.Empty, Mid(Me.Format, intPeriodFormat + 1))
                Dim intDiff As Integer = 0      'フォーマットの小数点以下桁数とセットValueの小数点以下桁数の差
                If strPlacesValue.Length > strPlacesFormat.Length Then
                    '(NGの場合)
                    intDiff = strPlacesValue.Length - strPlacesFormat.Length
                    setValue = setValue.Remove(setValue.Length - intDiff)
                End If
                '-----< 2011/06/20 kato (add) Valueの小数点以下文字数がフォーマットの小数点以下文字数を超えないよう調整

            Catch ex As Exception
                Call DoError(ex)
                setValue = mstrValue
            End Try
            Me.Text = setValue
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>Null許可</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property Nullable() As Boolean
        Get
            Return mblnNullable
        End Get
        Set(ByVal value As Boolean)
            mblnNullable = value
        End Set
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
        Me.TextAlign = HorizontalAlignment.Right
        mcolBackColorDefault = Me.BackColor
        mcolBackColorMask = Color.Empty
        mstrFormat = ""
        mdecMaxValue = Decimal.MaxValue
        mdecMinValue = Decimal.MinValue
        mblnNullable = True

    End Sub
#End Region

#Region " ﾏｽｸ変更 "
    ''' ==================================================================
    ''' <summary>ﾏｽｸ変更</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMTextBoxNumber_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        Try

            '-----------------------------------------------
            '事前ﾁｪｯｸ
            '-----------------------------------------------
            If Me.ReadOnly = True Then Exit Try


            '-----------------------------------------------
            '背景色の変更
            '-----------------------------------------------
            If Me.Enabled = True Then
                '(ﾏｽｸOFFの場合)
                Me.BackColor = mcolBackColorDefault
            Else
                '(ﾏｽｸONの場合)
                Me.BackColor = mcolBackColorMask
            End If

        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
#End Region

#Region " ﾌｫｰｶｽ取得 "
    ''' ==================================================================
    ''' <summary>ﾌｫｰｶｽ取得</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMTextBoxNumber_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Try

            '-----------------------------------------------
            '事前ﾁｪｯｸ
            '-----------------------------------------------
            If (Me.ReadOnly = True) Then Exit Try
            If (Me.Text = String.Empty) Then Exit Try
            If (mstrFormat = String.Empty) Then Exit Try


            '-----------------------------------------------
            'ﾌｫｰﾏｯﾄの変更
            '-----------------------------------------------
            'RemoveHandler Me.TextChanged, AddressOf cmpTextBoxNumber_TextChanged
            blnEventStop = True
            Me.Text = CDec(Me.Text)
            blnEventStop = False
            'AddHandler Me.TextChanged, AddressOf cmpTextBoxNumber_TextChanged

        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
#End Region

#Region " ﾌｫｰｶｽ解除 "
    ''' ==================================================================
    ''' <summary>ﾌｫｰｶｽ解除</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMTextBoxNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Try

            '-----------------------------------------------
            '有効値変換
            '-----------------------------------------------
            Dim strText As String = String.Empty
            Dim strValue As String = String.Empty
            strValue = ChangeNumber(Me.Text)
            If (strValue <> String.Empty) And IsNumeric(strValue) Then
                strValue = CDec(strValue)
            End If
            strText = strValue
            If (strValue <> String.Empty) And (mstrFormat <> String.Empty) Then
                '(ﾌｫｰﾏｯﾄ設定が有効な場合)
                strText = String.Format("{0:" & mstrFormat & "}", CDec(strValue))
            Else
                '(ﾌｫｰﾏｯﾄ設定が無効な場合)
                strText = strValue
            End If


            '-----------------------------------------------
            '有設定
            '-----------------------------------------------
            blnEventStop = True
            Me.Text = strText
            mstrValue = strValue
            blnEventStop = False


        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
#End Region

#Region " ｸﾘｯｸ "
    ''' ==================================================================
    ''' <summary>ｸﾘｯｸ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMTextBoxNumber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Try

            '-----------------------------------------------
            'ｶｰｿﾙ位置の保持
            '-----------------------------------------------
            mintPosBefore = Me.SelectionStart

        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
#End Region

#Region " ｷｰﾎﾞｰﾄﾞ押下 "
    ''' ==================================================================
    ''' <summary>ｷｰﾎﾞｰﾄﾞ押下</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMTextBoxNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            '-----------------------------------------------
            'ｶｰｿﾙ位置の保持
            '-----------------------------------------------
            mintPosBefore = Me.SelectionStart

        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
#End Region

#Region " ﾃｷｽﾄ編集 "
    ''' ==================================================================
    ''' <summary>ﾃｷｽﾄ編集</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMTextBoxNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If blnEventStop = True Then Exit Sub
        Try

            '-----------------------------------------------
            'ｲﾍﾞﾝﾄ処理中
            '-----------------------------------------------
            'RemoveHandler Me.TextChanged, AddressOf cmpTextBoxNumber_TextChanged
            blnEventStop = True


            '-----------------------------------------------
            '入力値ﾁｪｯｸ
            '-----------------------------------------------
            Dim strInputValue As String = Me.Text
            If CheckInput(Me.Text) = False Then
                '(NGの場合)
                Me.Text = mstrValue
                Me.SelectionStart = mintPosBefore
                Exit Try
            End If


            '-----------------------------------------------
            '有効値変換
            '-----------------------------------------------
            strInputValue = ChangeNumber(Me.Text)


            '-----------------------------------------------
            '確定値ﾁｪｯｸ
            '-----------------------------------------------
            If CheckValue(strInputValue) = False Then
                '(NGの場合)
                Me.Text = mstrValue
                Me.SelectionStart = mintPosBefore
                Exit Try
            End If


            '-----------------------------------------------
            '値の変更ﾁｪｯｸ
            '-----------------------------------------------
            Dim blnChange As Boolean = False
            Dim strValueBefore As String = mstrValue
            Dim strValueNew As String = Me.Text
            If (strValueBefore <> "") And IsNumeric(strValueBefore) = True Then strValueBefore = CDec(strValueBefore)
            If (strValueNew <> "") And IsNumeric(strValueNew) = True Then strValueNew = CDec(strValueNew)
            If strValueBefore <> strValueNew Then
                '(値が変更した場合)
                mstrValue = strValueNew
                blnChange = True
            End If


            '-----------------------------------------------
            'ﾌｫｰﾏｯﾄの変更
            '-----------------------------------------------
            '▼ 2010/12/02 加藤 Rev 0.01 (2) 
            If Me.Focused = False Or Me.ReadOnly = True Then
                If (Me.Text <> String.Empty) And (mstrFormat <> String.Empty) Then
                    '(ﾌｫｰﾏｯﾄ設定が有効な場合)
                    Me.Text = String.Format("{0:" & mstrFormat & "}", CDec(Me.Text))
                End If
            End If
            ''If Me.Focused = False Then
            ''    If (Me.Text <> String.Empty) And (mstrFormat <> String.Empty) Then
            ''        '(フォーマット設定が有効な場合)
            ''        Me.Text = String.Format("{0:" & mstrFormat & "}", CDec(Me.Text))
            ''    End If
            ''End If
            '▲ 2010/12/02 加藤 Rev 0.01 (2) 


            '-----------------------------------------------
            '値の変更ｲﾍﾞﾝﾄ通知
            '-----------------------------------------------
            If blnChange = True Then
                '(値が変更した場合)
                RaiseEvent ValueChanged(strValueBefore, strValueNew)
            End If

        Catch ex As Exception
            Call DoError(ex)
        Finally
            blnEventStop = False
            'AddHandler Me.TextChanged, AddressOf cmpTextBoxNumber_TextChanged
        End Try
    End Sub
#End Region

#End Region

#Region " ﾒｿｯﾄﾞ "

#Region " 有効値変換 "
    ''' ==================================================================
    ''' <summary>有効値変換</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Function ChangeNumber(ByVal strValue As String) As String
        Dim strRet As String = strValue
        Dim strDefault As String = IIf(mblnNullable, String.Empty, "0")
        Try
            strRet = strRet.Replace("-.", "-0.")
            If (strRet = "-") Then strRet = strDefault
            If (strRet = ".") Then strRet = strDefault
            If IsNumeric(strRet) = False Then strRet = strDefault
            If (strRet.Length > 1) AndAlso _
               (strRet.Substring(strRet.Length - 1) = "-") Then
                strRet = strRet.Substring(0, strRet.Length - 1)
            End If
        Catch ex As Exception
            Call DoError(ex)
            Throw ex
        End Try
        Return strRet
    End Function

#End Region

#Region " 入力値ﾁｪｯｸ "
    ''' ==================================================================
    ''' <summary>入力値ﾁｪｯｸ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Function CheckInput(ByVal strValue As String) As Boolean
        Dim blnRet As Boolean = False
        Try

            '-----------------------------------------------
            'ﾌﾞﾗﾝｸﾁｪｯｸ
            '-----------------------------------------------
            If (strValue = String.Empty) Then
                '(ﾌﾞﾗﾝｸの場合)
                blnRet = True
                Exit Try
            End If


            '-----------------------------------------------
            '有効値ﾁｪｯｸ
            '-----------------------------------------------
            Dim objRegex As Regex
            objRegex = New Regex("^[0-9\b.-]+$")
            If objRegex.IsMatch(strValue) = False Then
                '(NGの場合)
                Exit Try
            End If


            '-----------------------------------------------
            '.記号ﾁｪｯｸ
            '-----------------------------------------------
            Dim strValueTemp1 As String = strValue
            If InStr(strValueTemp1, ".") > 0 Then
                '(見つかった場合)
                If InStr(Me.Format, ".") = 0 Then
                    '(NGの場合)
                    Exit Try
                End If
                strValueTemp1 = strValue.Substring(InStr(strValue, "."))
                If InStr(strValueTemp1, ".") > 0 Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '-記号ﾁｪｯｸ
            '-----------------------------------------------
            Dim strValueTemp2 As String = strValue
            If InStr(strValueTemp2.Substring(1), "-") > 0 Then
                '(NGの場合)
                Exit Try
            ElseIf (mdecMinValue >= 0) And _
                   (InStr(strValueTemp2, "-") > 0) Then
                '(NGの場合)
                Exit Try
            End If

            blnRet = True
        Catch ex As Exception
            Call DoError(ex)
            Throw ex
        End Try
        Return blnRet
    End Function
#End Region

#Region " 確定値ﾁｪｯｸ "
    ''' ==================================================================
    ''' <summary>確定値ﾁｪｯｸ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Function CheckValue(ByVal strValue As String) As Boolean
        Dim blnRet As Boolean = False
        Try

            '-----------------------------------------------
            '事前ﾁｪｯｸ
            '-----------------------------------------------
            If (strValue = String.Empty) Then
                '(ﾌﾞﾗﾝｸの場合)
                blnRet = True
                Exit Try
            End If


            '-----------------------------------------------
            '最大値ﾁｪｯｸ
            '-----------------------------------------------
            If CDec(strValue) > mdecMaxValue Then
                '(NGの場合)
                Exit Try
            End If


            '-----------------------------------------------
            '最小値ﾁｪｯｸ
            '-----------------------------------------------
            If CDec(strValue) < mdecMinValue Then
                '(NGの場合)
                Exit Try
            End If


            '-----------------------------------------------
            '少数ﾁｪｯｸ
            '-----------------------------------------------
            Dim intPeriodValue As Integer = InStr(strValue, ".")
            Dim intPeriodFormat As Integer = InStr(Me.Format, ".")
            Dim strPlacesValue As String = IIf(intPeriodValue = 0, String.Empty, Mid(strValue, intPeriodValue + 1))
            Dim strPlacesFormat As String = IIf(intPeriodFormat = 0, String.Empty, Mid(Me.Format, intPeriodFormat + 1))
            If strPlacesValue.Length > strPlacesFormat.Length Then
                '(NGの場合)
                Exit Try
            End If

            blnRet = True
        Catch ex As Exception
            Call DoError(ex)
            Throw ex
        End Try
        Return blnRet
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
