#Region " imports "
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
#End Region

''' **************************************************************************************
''' <summary> ｶｽﾀﾑ日付ｺﾝﾎﾞﾎﾞｯｸｽ </summary>
''' <remarks>
'''           日付ｺﾝﾎﾞﾎﾞｯｸｽ
''' </remarks>
''' **************************************************************************************

Public Class cmpMDateTimePicker

#Region " 列挙体宣言 "
#End Region

#Region " 定数宣言 "
    Const WM_ERASEBKGND As Int32 = &H14
#End Region

#Region " 変数宣言 "

    ''' ==================================================================
    ''' <summary>背景色</summary>
    ''' ==================================================================
    Private m_BackBrush As SolidBrush

#End Region

#Region " ﾌﾟﾛﾊﾟﾃｨ "
    ''' ==================================================================
    ''' <summary>背景色</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Public Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal Value As Color)
            If Not m_BackBrush Is Nothing Then
                m_BackBrush.Dispose()
            End If
            MyBase.BackColor = Value
            m_BackBrush = New SolidBrush(Me.BackColor)
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region " ｲﾍﾞﾝﾄ "

#Region " WndProc "
    ''' ==================================================================
    ''' <summary>WndProc</summary>
    ''' <remarks></remarks>
    ''' ==================================================================
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_ERASEBKGND Then
            Dim g As Graphics = Graphics.FromHdc(m.WParam)
            If m_BackBrush Is Nothing Then
                m_BackBrush = New SolidBrush(Me.BackColor)
            End If
            g.FillRectangle(m_BackBrush, Me.ClientRectangle)
            g.Dispose()
        Else
            MyBase.WndProc(m)
        End If
    End Sub
#End Region


#End Region


End Class
