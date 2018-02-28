'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】通信ﾌｫｰﾑ                 (KSH用ﾃﾞﾊﾞｯｸﾞﾂｰﾙです)
' 【作成】2006/05/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports  "
Imports JOBCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
#End Region

Public Class frmMCIDummyToServer

    '***********************************************
    '↓↓↓↓↓↓毎回必要
#Region "  共通変数             "

    Private mobjDb As clsConn                       'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    Private mobjMCIMain As CtrlMCIB.clsMCIMain      '本当の通信ﾌﾟﾛｸﾞﾗﾑｸﾗｽ

#End Region
#Region "　列挙体　             "
#End Region
#Region "  ｲﾍﾞﾝﾄ                "
#Region "  ﾌｫｰﾑﾛｰﾄﾞ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim objConfig = New clsConnectConfig(CONFIG_MCIB_DUMMY)                     'Configﾌｧｲﾙ接続ｸﾗｽ生成

            '************************************
            '色々初期化
            '************************************
            Me.Text = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FORM_NAME))                 'ﾌｫｰﾑ名ｾｯﾄ
            Me.Text &= "ﾀﾞﾐｰ送信"                                                       'ﾌｫｰﾑ名ｾｯﾄ
            NotifyIcon1.Text = Me.Text                                                  'ｱｲｺﾝ名ｾｯﾄ
            NotifyIcon1.Visible = False                                                 'ｱｲｺﾝ非表示
            mobjMCIMain = New CtrlMCIB.clsMCIMain(Nothing, Nothing, Nothing)            '本当の通信ﾌﾟﾛｸﾞﾗﾑｸﾗｽ

            '--------------------------
            'DB接続開始
            '--------------------------
            Dim objSystem As New clsConnectConfig(CONFIG_FILE)
            mobjDb = New clsConn                                'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
            mobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            While True
                '(接続するまでﾙｰﾌﾟ)
                Dim blnRet As Boolean = False
                blnRet = mobjDb.Connect()
                If blnRet = True Then Exit While
            End While


            ''************************************
            ''ｱｲｺﾝ化
            ''************************************
            'Call cmdIcon_ClickProcess()


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  Closeｸﾘｯｸ    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Closeｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Me.Close()

        Catch ex As Exception
            '何もしない

        End Try
    End Sub
#End Region
#Region "  ｱｲｺﾝ化               ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ化 ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIcon.Click
        Try

            Call cmdIcon_ClickProcess()

        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ｱｲｺﾝ                 ﾀﾞﾌﾞﾙｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ ﾀﾞﾌﾞﾙｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try

            Call NotifyIcon1_MouseDoubleClickProcess()

        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ｱｲｺﾝ関係             "
#Region "  ｱｲｺﾝ化       処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ化 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cmdIcon_ClickProcess()

        '自身ﾌｫｰﾑ
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        Me.NotifyIcon1.Visible = True
        Me.Hide()

    End Sub
#End Region
#Region "  ｱｲｺﾝ         ﾀﾞﾌﾞﾙｸﾘｯｸ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ ﾀﾞﾌﾞﾙｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub NotifyIcon1_MouseDoubleClickProcess()

        '自身ﾌｫｰﾑ
        Me.Show()
        Me.Opacity = 100
        Me.ShowInTaskbar = True
        Me.NotifyIcon1.Visible = False

    End Sub
#End Region
#End Region
#Region "  Boolean型→Integer型に変換"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Boolean型→Integer型に変換
    ''' </summary>
    ''' <param name="blnBoolean"></param>
    ''' <returns></returns>
    ''' *******************************************************************************************************************
    ''' <remarks></remarks>
    Private Function ChangeBooleanToInteger(ByVal blnBoolean As Boolean) As Integer
        Dim intReturn As Integer

        intReturn = IIf(blnBoolean, 1, 0)

        Return intReturn
    End Function
#End Region

#Region "  ｴﾗｰ処理              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException">Exceptionｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try
            gobjMCI.ComError(objException)
            MsgBox(objException)
        Catch ex As Exception
            'NOP
        End Try
    End Sub
#End Region
    '↑↑↑↑↑↑毎回必要
    '***********************************************

#Region "  ｲﾍﾞﾝﾄ                "
#End Region



#Region "  ID:05  問合せﾒｯｾｰｼﾞに対する応答          "
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd01.Click
        'Try


        '    '*************************************************
        '    '電文送信
        '    '*************************************************
        '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_LC)
        '    objTelegram.FORMAT_ID = FORMAT_LC_00            'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        '    objTelegram.SETIN_DATA("LCCRN01_RES", gobjMCIToServer.txtLCCRN01_RES.Text)                  'ｸﾚｰﾝ1応答
        '    objTelegram.SETIN_DATA("LCCRN01_UNU", gobjMCIToServer.txtLCCRN01_UNU.Text)                  'ｸﾚｰﾝ1異常ｺｰﾄﾞ
        '    objTelegram.SETIN_DATA("LCCRN02_RES", gobjMCIToServer.txtLCCRN02_RES.Text)                  'ｸﾚｰﾝ2応答
        '    objTelegram.SETIN_DATA("LCCRN02_UNU", gobjMCIToServer.txtLCCRN02_UNU.Text)                  'ｸﾚｰﾝ2異常ｺｰﾄﾞ
        '    objTelegram.SETIN_DATA("LCCRN03_RES", gobjMCIToServer.txtLCCRN03_RES.Text)                  'ｸﾚｰﾝ3応答
        '    objTelegram.SETIN_DATA("LCCRN03_UNU", gobjMCIToServer.txtLCCRN03_UNU.Text)                  'ｸﾚｰﾝ3異常ｺｰﾄﾞ
        '    objTelegram.SETIN_DATA("LCCRN0401_RES", gobjMCIToServer.txtLCCRN0401_RES.Text)              'ｸﾚｰﾝ4台車1応答
        '    objTelegram.SETIN_DATA("LCCRN0402_RES", gobjMCIToServer.txtLCCRN0402_RES.Text)              'ｸﾚｰﾝ4台車2応答
        '    objTelegram.SETIN_DATA("LCCRN0401_STATE", gobjMCIToServer.txtLCCRN0401_STATE.Text)          'ｸﾚｰﾝ4台車1状態
        '    objTelegram.SETIN_DATA("LCCRN0402_STATE", gobjMCIToServer.txtLCCRN0402_STATE.Text)          'ｸﾚｰﾝ4台車2状態

        '    objTelegram.MAKE_TELEGRAM()                                 '電文作成
        '    gobjMain.SendDataVAGC(objTelegram.TELEGRAM_MAKED)           '送信電文


        'Catch ex As Exception
        '    Call ComError(ex)
        'End Try
    End Sub
#End Region
End Class