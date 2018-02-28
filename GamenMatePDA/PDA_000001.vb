'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PDA画面親ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMatePDA.clsComFuncPDA
#End Region

Public Class PDA_000001

#Region "  API定義                              "

    '***************************************************************
    'API宣言
    '***************************************************************
    '最後に発生した入力イベントの時刻を取得する関数の宣言
    Declare Function GetLastInputInfo Lib "user32.dll" (ByRef Plii As LASTINPUTINFO) As Integer
    'システムを起動した後の経過時間が、ミリ秒単位で返る関数の宣言
    Declare Function GetTickCount Lib "kernel32" () As Integer

    Public Const KEYEVENTF_EXTENDEDKEY = &H1
    Public Const KEYEVENTF_KEYUP = &H2          'ｷｰを放す　　　
    Public Const VK_CAPITAL = &H14              '[CAPS LOCK]ｷｰ
    'ｷｰ入力する関数の宣言
    Public Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)

    '***************************************************************
    '最後に発生した入力イベントの時刻を定義する構造体の宣言
    '***************************************************************
    Structure LASTINPUTINFO
        Dim cbSize As UInteger
        Dim dwTime As UInteger
    End Structure


    Private dwStartTime As UInteger     '画面が起動した時間

#End Region

#Region "  ｲﾍﾞﾝﾄ　　　　　　　　                "
#Region "  Visible変更                          "
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

            '*******************************************************
            ' CapsLockﾁｪｯｸ
            '*******************************************************
            If Control.IsKeyLocked(Keys.CapsLock) Then
                '(CapsLockがONのとき)
                Call keybd_event(VK_CAPITAL, 0, 0, 0)                   'ｷｰ押下
                Call keybd_event(VK_CAPITAL, 0, KEYEVENTF_KEYUP, 0)     'ｷｰ離す
            End If

            If Me.DesignMode = True Then Exit Sub 'ﾃﾞｻﾞｲﾝﾓｰﾄﾞの時はﾌﾟﾛｸﾞﾗﾑを実行しない
            If gcintAfkAutoFlg = FLAG_OFF Then
                tmrTimeOutLogin.Enabled = False
            Else
                tmrTimeOutLogin.Enabled = True
            End If
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞｲﾝ状態ﾀｲﾑｱｳﾄ監視ﾀｲﾏｰ              "
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

        ''***************************************************************
        ''ﾓｰﾄﾞﾁｪｯｸ
        ''***************************************************************
        'If gcintDSPLOGIN_FLG = FLAG_OFF Then Exit Sub

        ''***************************************************************
        ''離席ﾛｸﾞｵﾝ設定画面ｵﾌﾞｼﾞｪｸﾄﾁｪｯｸ
        ''***************************************************************
        'If IsNull(gobjPDA_100005) = False Then Exit Sub

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

        If udtLastInputInfo.dwTime = 0 Then
            '(最後に入力が行われた時刻がないとき(画面が新規起動したとき))
            If dwStartTime = 0 Then
                dwStartTime = intNow
            End If

            udtLastInputInfo.dwTime = dwStartTime

        End If

        If (gcintDSPLOGOFF * 1000) <= intNow - udtLastInputInfo.dwTime Then
            '(ﾀｲﾑｱｳﾄ発生)

            '***************************************************************
            '離席画面表示
            '***************************************************************
            'If gblnLogoff = False Then
            '    Call AfkProc(Me)
            'End If


            '----------------------------------------
            ' 子画面削除処理
            '----------------------------------------
            Call DisposeGamenPDA()

            '----------------------------------------
            ' ｼｬｯﾄﾀﾞｳﾝ
            '----------------------------------------
            Call PDA_100001.PubF_ShutDown()            ' ｼｬｯﾄﾀﾞｳﾝ

        End If


    End Sub
#End Region
#Region "  子画面削除処理                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 子画面削除処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DisposeGamenPDA()

        If IsNull(gobjPDA_100005) = False Then
            gobjPDA_100005.Dispose()
            gobjPDA_100005 = Nothing
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

            gobjComFuncPDA.ComError_frm(ex)

        Catch ex2 As Exception
            MsgBox("ComError関数でｴﾗｰ発生")

        End Try
    End Sub
#End Region

End Class