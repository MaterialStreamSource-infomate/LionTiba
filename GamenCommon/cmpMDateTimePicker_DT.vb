#Region " imports "
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Drawing
#End Region

''' **************************************************************************************
''' <summary> ｶｽﾀﾑ日付ｺﾝﾎﾞﾎﾞｯｸｽ </summary>
''' <remarks>
'''           日付ｺﾝﾎﾞﾎﾞｯｸｽ
''' </remarks>
''' **************************************************************************************

Public Class cmpMDateTimePicker_DT

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
    ''' <summary>Timeｺﾝﾎﾞ表示ﾌﾗｸﾞ</summary>
    ''' ==================================================================
    Private mblnTimeComboDisp As Boolean = True

    ''' ==================================================================
    ''' <summary>日時</summary>
    ''' ==================================================================
    Private mstrDateTimeText As String

    ''' ==================================================================
    ''' <summary>表示ﾁｪｯｸ</summary>
    ''' ==================================================================
    Private mblnDispCheck As Boolean = True


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
    ''' <summary>Timeｺﾝﾎﾞ表示ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property TimeComboDisp() As Boolean
        Get
            Return mblnTimeComboDisp
        End Get
        Set(ByVal value As Boolean)
            mblnTimeComboDisp = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>日時</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public ReadOnly Property userDateTimeText() As String
        Get
            Return mstrDateTimeText
        End Get
    End Property

    ''' ==================================================================
    ''' <summary>表示ﾁｪｯｸ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public ReadOnly Property userDispChecked() As Boolean
        Get
            Return mblnDispCheck
        End Get
    End Property

    ''' ==================================================================
    ''' <summary>ﾁｪｯｸﾎﾞｯｸｽ表示非表示</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property userShowCheckBox() As Boolean
        Get
            Return cmpMDateTimePicker_D.ShowCheckBox
        End Get
        Set(ByVal value As Boolean)
            cmpMDateTimePicker_D.ShowCheckBox = value
        End Set
    End Property

    ''' ==================================================================
    ''' <summary>ﾁｪｯｸ</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Property userChecked() As Boolean
        Get
            Return cmpMDateTimePicker_D.Checked
        End Get
        Set(ByVal value As Boolean)
            cmpMDateTimePicker_D.Checked = value
            If cmpMDateTimePicker_D.Checked Then
                lblMsk.Visible = False
                cmpMDateTimePicker_T.Enabled = True
            Else
                lblMsk.Text = cmpMDateTimePicker_D.Text
                lblMsk.Visible = True
                cmpMDateTimePicker_T.Enabled = False
            End If
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
        mcolBackColorMask = Color.Empty
        mblnTimeComboDisp = True

    End Sub
#End Region
#Region " MouseDown "
    ''' ==================================================================
    ''' <summary>MouseDown</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMDateTimePicker_D_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmpMDateTimePicker_D.MouseDown
        Try

            If cmpMDateTimePicker_D.Checked = False Then
                '(CheckedがFalseのとき)
                lblMsk.Text = cmpMDateTimePicker_D.Text
                lblMsk.Visible = True
                cmpMDateTimePicker_T.Enabled = False
                cmpMDateTimePicker_D.BackColor = mcolBackColorMask
                'mblnDispCheck = False
            Else
                '(CheckedがTrueのとき)
                lblMsk.Visible = False
                cmpMDateTimePicker_T.Enabled = True
                cmpMDateTimePicker_D.BackColor = mcolBackColorDefault
                'mblnDispCheck = True
            End If

        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
    ''''' ==================================================================
    ''''' <summary>MouseUp</summary>
    ''''' <remarks></remarks>
    ''''' ==================================================================
    ''Private Sub cmpMDateTimePicker_D_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmpMDateTimePicker_D.MouseUp
    ''    Try

    ''        If cmpMDateTimePicker_D.Checked = False Then
    ''            '(CheckedがFalseのとき)
    ''            lblMsk.Text = cmpMDateTimePicker_D.Text
    ''            lblMsk.Visible = True
    ''            cmpMDateTimePicker_T.Enabled = False
    ''            cmpMDateTimePicker_D.BackColor = mcolBackColorMask
    ''            'mblnDispCheck = False
    ''        Else
    ''            '(CheckedがTrueのとき)
    ''            lblMsk.Visible = False
    ''            cmpMDateTimePicker_T.Enabled = True
    ''            cmpMDateTimePicker_D.BackColor = mcolBackColorDefault
    ''            'mblnDispCheck = True
    ''        End If

    ''    Catch ex As Exception
    ''        Call DoError(ex)
    ''    End Try
    ''End Sub
#End Region
#Region " KeyUp "
    ''' ==================================================================
    ''' <summary>KeyUp</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMDateTimePicker_D_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmpMDateTimePicker_D.KeyDown
        Try

            If e.KeyData = Keys.Space Then
                '(spaceが押下されたとき)
                If cmpMDateTimePicker_D.Checked = False Then
                    '(CheckedがFalseのとき)
                    lblMsk.Text = cmpMDateTimePicker_D.Text
                    lblMsk.Visible = True
                    cmpMDateTimePicker_T.Enabled = False
                    cmpMDateTimePicker_D.BackColor = mcolBackColorMask
                    mblnDispCheck = False
                    cmpMDateTimePicker_D.Checked = True
                Else
                    '(CheckedがTrueのとき)
                    lblMsk.Visible = False
                    cmpMDateTimePicker_T.Enabled = True
                    cmpMDateTimePicker_D.BackColor = mcolBackColorDefault
                    mblnDispCheck = True
                    cmpMDateTimePicker_D.Checked = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region " EnabledChanged "
    ''' ==================================================================
    ''' <summary>EnabledChanged</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMDateTimePicker_T_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmpMDateTimePicker_T.EnabledChanged
        Try
            '-----------------------------------------------
            '背景色の変更
            '-----------------------------------------------
            If cmpMDateTimePicker_T.Enabled = True Then
                '(ﾏｽｸOFFの場合)
                cmpMDateTimePicker_T.BackColor = mcolBackColorDefault
                mblnDispCheck = True
            Else
                '(ﾏｽｸONの場合)
                cmpMDateTimePicker_T.BackColor = mcolBackColorMask
                mblnDispCheck = False
            End If

        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
#End Region
#Region " ValueChanged "
    ''' ==================================================================
    ''' <summary>ValueChanged</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Private Sub cmpMDateTimePicker_D_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmpMDateTimePicker_D.ValueChanged, _
                                                                                                               cmpMDateTimePicker_T.ValueChanged
        Try

            mstrDateTimeText = cmpMDateTimePicker_D.Text & " " & cmpMDateTimePicker_T.Text

        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
#End Region


#End Region

#Region " ﾒｿｯﾄﾞ "

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
