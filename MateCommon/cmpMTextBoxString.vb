#Region " imports "
Imports System.Text.RegularExpressions
Imports System.Drawing
#End Region

''' **************************************************************************************
''' <summary> ｶｽﾀﾑﾃｷｽﾄﾎﾞｯｸｽ </summary>
''' <remarks>
'''           入力ﾁｪｯｸ付き文字入力ﾃｷｽﾄﾎﾞｯｸｽ
''' </remarks>
''' **************************************************************************************
Public Class cmpMTextBoxString

#Region " ｶｽﾀﾑﾌﾟﾛﾊﾟﾃｨｻﾝﾌﾟﾙ "

#Region " RegexCustomTrue "

    '■数値のみ有効
    'Dim objRegex As New Regex("^[0-9]+$")

    '■全角かなのみ有効
    'Dim objRegex As New Regex("^\p{IsHiragana}+$")

    '■全角かな＋伸ばし棒のみ有効
    'Dim objRegex As New Regex("^[\p{IsHiragana}\u30FC]+$")

#End Region

#End Region

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
    ''' <summary>最大ﾊﾞｲﾄ数</summary>
    ''' ==================================================================
    Private mintMaxLengthByte As Integer

    ''' ==================================================================
    ''' <summary>半角数値可否</summary>
    ''' ==================================================================
    Private mblnEnabledHalfNumber As Boolean

    ''' ==================================================================
    ''' <summary>半角英小文字可否</summary>
    ''' ==================================================================
    Private mblnEnabledHalfAlphabetLower As Boolean

    ''' ==================================================================
    ''' <summary>半角英大文字可否</summary>
    ''' ==================================================================
    Private mblnEnabledHalfAlphabetUpper As Boolean

    ''' ==================================================================
    ''' <summary>半角ｶﾅ可否</summary>
    ''' ==================================================================
    Private mblnEnabledHalfKatakana As Boolean

    ''' ==================================================================
    ''' <summary>半角文字全般可否</summary>
    ''' ==================================================================
    Private mblnEnabledHalf As Boolean

    ''' ==================================================================
    ''' <summary>全角数値可否</summary>
    ''' ==================================================================
    Private mblnEnabledFullNumber As Boolean

    ''' ==================================================================
    ''' <summary>全角英小文字可否</summary>
    ''' ==================================================================
    Private mblnEnabledFullAlphabetLower As Boolean

    ''' ==================================================================
    ''' <summary>全角英大文字可否</summary>
    ''' ==================================================================
    Private mblnEnabledFullAlphabetUpper As Boolean

    ''' ==================================================================
    ''' <summary>全角ｶﾅ可否</summary>
    ''' ==================================================================
    Private mblnEnabledFullKatakana As Boolean

    ''' ==================================================================
    ''' <summary>全角ｶﾅ可否</summary>
    ''' ==================================================================
    Private mblnEnabledFullHiragana As Boolean

    ''' ==================================================================
    ''' <summary>全角文字全般可否</summary>
    ''' ==================================================================
    Private mblnEnabledFull As Boolean

    ''' ==================================================================
    ''' <summary>ｶｽﾀﾑ正規文字ﾊﾟﾀｰﾝ</summary>
    ''' ==================================================================
    Private mrgxCustomTrue As Regex

    ''' ==================================================================
    ''' <summary>ｶｽﾀﾑ禁止文字ﾊﾟﾀｰﾝ</summary>
    ''' ==================================================================
    Private mrgxCustomFalse As Regex

    ''' ==================================================================
    ''' <summary>文字ﾃﾞｰﾀ</summary>
    ''' ==================================================================
    Private mstrValue As String

    ''' ==================================================================
    ''' <summary>元ｶｰｿﾙ位置</summary>
    ''' ==================================================================
    Private mintPosBefore As Integer

    ''' ==================================================================
    ''' <summary>ｲﾍﾞﾝﾄ処理中ﾌﾗｸﾞ</summary>
    ''' ==================================================================
    Private blnEventStop As Boolean = False

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
    ''' <summary>最大ﾊﾞｲﾄ数</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property MaxLengthByte() As Integer
        Get
            Return mintMaxLengthByte
        End Get
        Set(ByVal value As Integer)
            mintMaxLengthByte = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>半角数字可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledHalfNumber() As Boolean
        Get
            Return mblnEnabledHalfNumber
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledHalfNumber = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>半角英小文字可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledHalfAlphabetLower() As Boolean
        Get
            Return mblnEnabledHalfAlphabetLower
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledHalfAlphabetLower = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>半角英大文字可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledHalfAlphabetUpper() As Boolean
        Get
            Return mblnEnabledHalfAlphabetUpper
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledHalfAlphabetUpper = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>半角ｶﾅ可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledHalfKatakana() As Boolean
        Get
            Return mblnEnabledHalfKatakana
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledHalfKatakana = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>半角文字全般可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledHalf() As Boolean
        Get
            Return mblnEnabledHalf
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledHalf = value
            mblnEnabledHalfNumber = value
            mblnEnabledHalfAlphabetLower = value
            mblnEnabledHalfAlphabetUpper = value
            mblnEnabledHalfKatakana = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>全角数字可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledFullNumber() As Boolean
        Get
            Return mblnEnabledFullNumber
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledFullNumber = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>全角英小文字可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledFullAlphabetLower() As Boolean
        Get
            Return mblnEnabledFullAlphabetLower
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledFullAlphabetLower = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>全角英大文字可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledFullAlphabetUpper() As Boolean
        Get
            Return mblnEnabledFullAlphabetUpper
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledFullAlphabetUpper = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>全角ｶﾅ可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledFullKatakana() As Boolean
        Get
            Return mblnEnabledFullKatakana
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledFullKatakana = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>全角かな可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledFullHiragana() As Boolean
        Get
            Return mblnEnabledFullHiragana
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledFullHiragana = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>全角文字全般可否</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property EnabledFull() As Boolean
        Get
            Return mblnEnabledFull
        End Get
        Set(ByVal value As Boolean)
            mblnEnabledFull = value
            mblnEnabledFullNumber = value
            mblnEnabledFullAlphabetLower = value
            mblnEnabledFullAlphabetUpper = value
            mblnEnabledFullKatakana = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>ｶｽﾀﾑ正規文字ﾊﾟﾀｰﾝ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property RegexCustomTrue() As Regex
        Get
            Return mrgxCustomTrue
        End Get
        Set(ByVal value As Regex)
            mrgxCustomTrue = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>ｶｽﾀﾑ禁止文字ﾊﾟﾀｰﾝ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property RegexCustomFalse() As Regex
        Get
            Return mrgxCustomFalse
        End Get
        Set(ByVal value As Regex)
            mrgxCustomFalse = value
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
        mcolBackColorDefault = Me.BackColor
        mcolBackColorMask = Color.Empty
        mblnEnabledHalfNumber = True
        mblnEnabledHalfAlphabetLower = True
        mblnEnabledHalfAlphabetUpper = True
        mblnEnabledHalfKatakana = True
        mblnEnabledHalf = True
        mblnEnabledFullNumber = True
        mblnEnabledFullAlphabetLower = True
        mblnEnabledFullAlphabetUpper = True
        mblnEnabledFullKatakana = True
        mblnEnabledFullHiragana = True
        mblnEnabledFull = True
        mrgxCustomTrue = Nothing
        mrgxCustomFalse = Nothing

    End Sub
#End Region

#Region " ﾏｽｸ変更 "
    ''' ==================================================================
    ''' <summary>ﾏｽｸ変更</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMTextBoxString_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
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

#Region " ｸﾘｯｸ "
    ''' ==================================================================
    ''' <summary>ｸﾘｯｸ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMTextBoxString_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
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
    ''' ==================================================================
    Private Sub cmpMTextBoxString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
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
    Private Sub cmpMTextBoxString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If blnEventStop = True Then Exit Sub
        Try

            '-----------------------------------------------
            'ｲﾍﾞﾝﾄ処理中
            '-----------------------------------------------
            blnEventStop = True


            '-----------------------------------------------
            '入力ﾁｪｯｸ
            '-----------------------------------------------
            If CheckInput(Me.Text) = False Then
                '(NGの場合)
                Me.Text = mstrValue
                Me.SelectionStart = mintPosBefore
                Exit Try
            End If


            '-----------------------------------------------
            '値の確定
            '-----------------------------------------------
            mstrValue = Me.Text

        Catch ex As Exception
            Call DoError(ex)
        End Try
        blnEventStop = False
    End Sub
#End Region

#End Region

#Region " ﾒｿｯﾄﾞ "

#Region " 入力値ﾁｪｯｸ "
    ''' ==================================================================
    ''' <summary>入力値ﾁｪｯｸ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Function CheckInput(ByVal strText As String) As Boolean
        Dim blnRet As Boolean = False
        Try

            '-----------------------------------------------
            '半角数字ﾁｪｯｸ
            '-----------------------------------------------
            Dim objRegex As Regex
            If mblnEnabledHalfNumber = False Then
                '(禁止されている場合)
                objRegex = New Regex("[0-9]")
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '半角英小文字ﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledHalfAlphabetLower = False Then
                '(禁止されている場合)
                objRegex = New Regex("[a-z]")
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '半角英大文字ﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledHalfAlphabetUpper = False Then
                '(禁止されている場合)
                objRegex = New Regex("[A-Z]")
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '半角ｶﾅﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledHalfKatakana = False Then
                '(禁止されている場合)
                objRegex = New Regex("[ｦ-ﾟ]")
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '半角文字全般ﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledHalf = False Then
                '(禁止されている場合)
                If strText.Length = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(strText) Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '全角数字ﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledFullNumber = False Then
                '(禁止されている場合)
                objRegex = New Regex("[０-９]")
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '全角英小文字ﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledFullAlphabetLower = False Then
                '(禁止されている場合)
                objRegex = New Regex("[ａ-ｚ]")
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '全角英大文字ﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledFullAlphabetUpper = False Then
                '(禁止されている場合)
                objRegex = New Regex("[Ａ-Ｚ]")
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '全角ｶﾅﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledFullKatakana = False Then
                '(禁止されている場合)
                objRegex = New Regex("[ァ-ヶ]")
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '全角かなﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledFullHiragana = False Then
                '(禁止されている場合)
                objRegex = New Regex("\p{IsHiragana}")
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            '全角文字全般ﾁｪｯｸ
            '-----------------------------------------------
            If mblnEnabledFull = False Then
                '(禁止されている場合)
                If strText.Length < System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(strText) Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            'ｶｽﾀﾑ正規文字ﾁｪｯｸ
            '-----------------------------------------------
            If IsNothing(mrgxCustomTrue) = False Then
                '(設定されている場合)
                objRegex = mrgxCustomTrue
                If (objRegex.IsMatch(strText) = False) And (strText <> String.Empty) Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            'ｶｽﾀﾑ禁止文字ﾁｪｯｸ
            '-----------------------------------------------
            If IsNothing(mrgxCustomFalse) = False Then
                '(設定されている場合)
                objRegex = mrgxCustomFalse
                If objRegex.IsMatch(strText) = True Then
                    '(NGの場合)
                    Exit Try
                End If
            End If


            '-----------------------------------------------
            'ﾊﾞｲﾄ数ﾁｪｯｸ
            '-----------------------------------------------
            If mintMaxLengthByte > 0 Then
                '(上限がある場合)
                Dim strData As String = strText
                If mintMaxLengthByte < System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(strData) Then
                    '(NGの場合)
                    Exit Try
                End If
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
