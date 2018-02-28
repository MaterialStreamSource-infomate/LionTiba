'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】画面親ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************


#Region "  Imports      "

Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMate.clsComFuncFRM

#End Region

Public Class FRM_000001

#Region "  API定義                              "

    '***************************************************************
    'API宣言
    '***************************************************************
    '最後に発生した入力イベントの時刻を取得する関数の宣言
    Declare Function GetLastInputInfo Lib "user32.dll" (ByRef Plii As LASTINPUTINFO) As Integer
    'システムを起動した後の経過時間が、ミリ秒単位で返る関数の宣言
    Declare Function GetTickCount Lib "kernel32" () As Integer


    '***************************************************************
    '最後に発生した入力イベントの時刻を定義する構造体の宣言
    '***************************************************************
    Structure LASTINPUTINFO
        Dim cbSize As UInteger
        Dim dwTime As UInteger
    End Structure

#End Region
#Region "  ｲﾍﾞﾝﾄ　　　　　　　　                "
#Region "  Visible変更              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Visible変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_000001_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Me.DesignMode = True Then Exit Sub 'ﾃﾞｻﾞｲﾝﾓｰﾄﾞの時はﾌﾟﾛｸﾞﾗﾑを実行しない
            If gcintAfkFlg = FLAG_OFF Then
                tmrTimeOutLogin.Enabled = False
            Else
                tmrTimeOutLogin.Enabled = True
            End If
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞｲﾝ状態ﾀｲﾑｱｳﾄ監視ﾀｲﾏｰ  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞｲﾝ状態ﾀｲﾑｱｳﾄ監視ﾀｲﾏｰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrTimeOutLogin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimeOutLogin.Tick
        Try

            If Me.DesignMode = True Then Exit Sub 'ﾃﾞｻﾞｲﾝﾓｰﾄﾞの時はﾌﾟﾛｸﾞﾗﾑを実行しない
            tmrTimeOutLogin.Enabled = False
            Call TimeOutLoginProc()


        Catch ex As Exception
            ComError(ex)

        Finally
            tmrTimeOutLogin.Enabled = True

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾛｸﾞｲﾝ状態ﾀｲﾑｱｳﾄ監視ﾀｲﾏｰ処理          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞｲﾝ状態ﾀｲﾑｱｳﾄ監視ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TimeOutLoginProc()

        '***************************************************************
        'ﾓｰﾄﾞﾁｪｯｸ
        '***************************************************************
        If gcintDSPLOGIN_FLG = FLAG_OFF Then Exit Sub

        '***************************************************************
        '離席ﾛｸﾞｵﾝ設定画面ｵﾌﾞｼﾞｪｸﾄﾁｪｯｸ
        '***************************************************************
        If IsNull(gobjFRM_100005) = False Then Exit Sub

        '***************************************************************
        '最後に入力が行われた時刻を取得
        '***************************************************************
        Dim udtLastInputInfo As LASTINPUTINFO
        Dim blnRet As Boolean
        udtLastInputInfo.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(udtLastInputInfo)
        blnRet = GetLastInputInfo(udtLastInputInfo)
        If blnRet = False Then Throw New Exception("API関数「GetLastInputInfo」でｴﾗｰ発生。")


        '***************************************************************
        '現在時刻を取得
        '***************************************************************
        Dim intNow As Integer        'OSが起動してからの時間
        intNow = GetTickCount
        If (gcintDSPLOGOFF * 1000) <= intNow - udtLastInputInfo.dwTime Then
            '(ﾀｲﾑｱｳﾄ発生)

            '***************************************************************
            '離席画面表示
            '***************************************************************
            If gblnLogoff = False Then
                Call gobjComFuncFRM.AfkProc(Me)

            End If

        End If

    End Sub
#End Region
#Region "  画面ｵｰﾌﾟﾝ処理    (各画面処理)        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面ｵｰﾌﾟﾝ処理(各画面処理)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub InitializeChild()



    End Sub
#End Region
#Region "  ｴﾗｰ処理                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="ex">ｴﾗｰExceptio</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub ComError(ByVal ex As Exception)
        Try

            gobjComFuncFRM.ComError_frm(ex)

        Catch ex2 As Exception
            MsgBox("ComError関数でｴﾗｰ発生")

        End Try
    End Sub
#End Region

    '他の手段(ｻﾝﾌﾟﾙ)
#Region "  Application.AddMessageFilterを使用した場合"
    '    Private Const INPUT_TIMEOUT As Long = 10000
    '    Private Shared dtmInput As Date

    '    'フィルタ定義
    '    Private Class TestFilter
    '        Implements IMessageFilter

    '        Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
    '            Try

    '                Const WM_MOUSEMOVE = &H200
    '                If m.Msg = WM_MOUSEMOVE Then
    '                    frmOya1.TextBox1.Text = Val(frmOya1.TextBox1.Text) + 1
    '                    dtmInput = Now
    '                End If
    '            Catch ex As Exception
    '                MsgBox(ex.Message)

    '            End Try
    '        End Function
    '    End Class

    '    Private Sub frmOya1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        'フィルタを登録(アプリ内で最初に記述)
    '        Application.AddMessageFilter(New TestFilter)
    '        dtmInput = Now
    '    End Sub

    '    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '        Try
    '            If DateAdd(DateInterval.Second, INPUT_TIMEOUT / 1000, dtmInput) <= Now Then
    '                Me.Close()
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)

    '        End Try
    '    End Sub
#End Region
#Region "  MouseMoveを使用した場合"
    '' ''Private Sub frmOya1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '' ''    Try
    '' ''        MsgBox("キーダウン成功！")
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message)

    '' ''    End Try
    '' ''End Sub


    '' ''Private Sub frmOya1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '' ''    Try
    '' ''        Me.KeyPreview = True
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message)

    '' ''    End Try
    '' ''End Sub


    '' ''Private Sub frmOya1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
    '' ''    Try
    '' ''        MsgBox("マウスダウン成功！")
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message)

    '' ''    End Try
    '' ''End Sub

    '' ''Private Sub frmOya1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    '' ''    Try
    '' ''        TextBox1.Text = Val(TextBox1.Text) + 1
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message)

    '' ''    End Try
    '' ''End Sub
#End Region

End Class