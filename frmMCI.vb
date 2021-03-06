'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCIﾒｲﾝﾌｫｰﾑ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports    "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports System.IO.Ports
Imports JobCommon
#End Region

Public Class frmMCI

    '***********************************************
    '↓↓↓↓↓↓毎回必要
#Region "  共通変数         "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjDb As clsConn                       'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                    'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    Private mobjOwner As clsOwner                   'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mobjLogWriter As clsLogWriter           'ﾃｷｽﾄﾛｸﾞｸﾗｽ

    '==================================================
    'Configﾌｧｲﾙ情報
    '==================================================
    'ﾛｸﾞ関係
    Private mstrFilePath As String                  'ﾌｧｲﾙﾊﾟｽ        ｾｯﾄ
    Private mstrFileName As String                  'ﾌｧｲﾙ名         ｾｯﾄ
    Private mintMaxDeleteDay As Integer             '保持日数       ｾｯﾄ
    Private mintMaxSize As Integer                  '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ
    'その他
    Private mintListCount As Integer                'ﾘｽﾄﾎﾞｯｸｽに表示する最大行数
    Private mintListFlag As Integer                 'ﾘｽﾄﾎﾞｯｸｽ使用ﾌﾗｸﾞ      0:使用しない    1:使用
    Private mstrFormName As String                  'ﾌｫｰﾑ名
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/05/08  二重起動ﾁｪｯｸをConfigへ持たせる
    Private mintProcessCheck As Integer             'ﾌﾟﾛｸﾞﾗﾑ起動ﾁｪｯｸ数
    '↑↑↑↑↑↑************************************************************************************************************
    Private minttmrMainInterval As Integer          '通信処理ﾀｲﾏｰ             ｲﾝﾀｰﾊﾞﾙ
    Private mintCloseWaitTime As Integer            'ﾌｫｰﾑｸﾛｰｽﾞ時の待機時間
    Private mintDebugFlag As Integer                'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/07/03  ｵﾗｸﾙ接続文字列のPoolingの設定値をConfigへ持たせる
    Private mintOraclePoolingFlag As Integer        'ｵﾗｸﾙ接続文字列のPoolingの設定値  [0:False  1:True(ﾃﾞﾌｫﾙﾄ値)]
    '↑↑↑↑↑↑************************************************************************************************************

#End Region
#Region "  ｲﾍﾞﾝﾄ            "
#Region "  ﾌｫｰﾑﾛｰﾄﾞ                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmMCI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call FormLoadProcess()


        Catch ex As Exception
            ComError(ex)
            MsgBox(ex.Message)
            Me.Close()

        End Try
    End Sub
#End Region
#Region "  ﾌｫｰﾑｸﾛｰｽﾞ                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ﾌｫｰﾑｸﾛｰｽﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmMCI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call FormClosingProcess()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region
#Region "  通信処理ﾀｲﾏｰ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  通信処理ﾀｲﾏｰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMain.Tick
        Try

            tmrMain.Enabled = False

            Call tmrMainProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmrMain.Enabled = True

        End Try
    End Sub
#End Region
#Region "  ｼﾘｱﾙ通信ｵｰﾌﾟﾝ        ｸﾘｯｸ        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ｼﾘｱﾙ通信ｵｰﾌﾟﾝ ｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCOMOpen.Click
        Try

            Call cmdOpenProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ｼﾘｱﾙ通信ｸﾛｰｽﾞ        ｸﾘｯｸ        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ｼﾘｱﾙ通信ｸﾛｰｽﾞ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCOMClose.Click
        Try

            Call cmdCloseProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾃｽﾄ送信              ｸﾘｯｸ        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｽﾄ送信 ｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdShowSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowSend.Click
        Try

            Call cmdShowSendProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  閉じる               ｸﾘｯｸ        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  閉じる ｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdFormClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFormClose.Click
        Try

            Call cmdFormClose_Click_Process()

        Catch ex As Exception
            Call MsgBox(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ｱｲｺﾝ化               ｸﾘｯｸ        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ｱｲｺﾝ化 ｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIcon.Click
        Try

            Call cmdIcon_ClickProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ｱｲｺﾝ                 ﾀﾞﾌﾞﾙｸﾘｯｸ   "
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
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ変更                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub chkDebugFlag_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDebugFlag.CheckedChanged
        Try

            If chkDebugFlag.Checked = True Then
                gobjMain.intDebugFlag = FLAG_ON
            Else
                gobjMain.intDebugFlag = FLAG_OFF
            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region
#End Region

#Region "  ﾌｫｰﾑﾛｰﾄﾞ         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoadProcess()


        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  二重起動ﾁｪｯｸをConfigへ持たせる

        ''*********************************************
        ''二重起動ﾁｪｯｸ
        ''*********************************************
        'If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) >= 2 Then
        '    Dim strMessage As String
        '    strMessage = "既にﾌﾟﾛｸﾞﾗﾑは起動しているので、実行されません。"
        '    MsgBox(strMessage)
        '    Me.Close()
        '    Me.Dispose()
        '    Exit Sub
        'End If

        '↑↑↑↑↑↑************************************************************************************************************


        '*****************************************************
        'Configﾌｧｲﾙ情報取得
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCIC)                                  'Configﾌｧｲﾙ接続ｸﾗｽ生成
        'ﾛｸﾞ関係
        mstrFilePath = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_PATH))                    'ﾌｧｲﾙﾊﾟｽ        ｾｯﾄ
        mstrFileName = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_NAME))                    'ﾌｧｲﾙ名         ｾｯﾄ
        mintMaxDeleteDay = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_DELETE_DAY))          '保持日数       ｾｯﾄ
        mintMaxSize = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_SIZE))                     '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ
        'その他
        mintListCount = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_LIST_COUNT))                  'ﾘｽﾄ表示行数
        mintListFlag = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_LIST_FLAG))                    'ﾘｽﾄﾎﾞｯｸｽ使用ﾌﾗｸﾞ      0:使用しない    1:使用
        mstrFormName = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FORM_NAME))                    'ﾌｫｰﾑ名
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  二重起動ﾁｪｯｸをConfigへ持たせる
        mintProcessCheck = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_PROCESS_CHECK))           'ﾌﾟﾛｸﾞﾗﾑ起動ﾁｪｯｸ数
        '↑↑↑↑↑↑************************************************************************************************************
        minttmrMainInterval = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_TMRMAIN_INTERVAL))      '通信処理ﾀｲﾏｰ             ｲﾝﾀｰﾊﾞﾙ 
        mintCloseWaitTime = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_CLOSE_WAIT_TIME))         'ﾌｫｰﾑｸﾛｰｽﾞ時の待機時間
        mintDebugFlag = TO_STRING(objConfig.GET_INFO(GKEY_MCI_DEBUG_FLAG))                  'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/07/03  ｵﾗｸﾙ接続文字列のPoolingの設定値をConfigへ持たせる
        mintOraclePoolingFlag = TO_STRING(objConfig.GET_INFO(GKEY_MCI_ORACLE_POOLING_FLAG)) 'ｵﾗｸﾙ接続文字列のPoolingの設定値  [0:False  1:True(ﾃﾞﾌｫﾙﾄ値)]
        '↑↑↑↑↑↑************************************************************************************************************


        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  二重起動ﾁｪｯｸをConfigへ持たせる

        '*********************************************
        '二重起動ﾁｪｯｸ
        '*********************************************
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) >= mintProcessCheck Then
            Dim strMessage As String
            strMessage = "同時に起動可能なﾌﾟﾛｸﾞﾗﾑ数を超えているので、起動できません。[同時起動制限数:" & TO_STRING(mintProcessCheck) & "]"
            MsgBox(strMessage)
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        '↑↑↑↑↑↑************************************************************************************************************


        '*****************************************************
        'ﾛｸﾞ出力ｵﾌﾞｼﾞｪｸﾄ生成
        '*****************************************************
        Dim strLogFileName As String = ""       'ﾛｸﾞﾌｧｲﾙ名
        strLogFileName &= mstrFileName
        'strLogFileName &= Diagnostics.Process.GetCurrentProcess.ProcessName
        'strLogFileName &= Me.Name
        mobjLogWriter = clsLogWriter.GetInstance(mstrFilePath, _
                                                 strLogFileName, _
                                                 mintMaxDeleteDay, _
                                                 mintMaxSize _
                                                 )


        '**************************************************************************
        ' ｵﾗｸﾙ接続
        '**************************************************************************
        '===============================================
        'Config取得
        '===============================================
        Dim objSystem As New clsConnectConfig(CONFIG_FILE)

        '===============================================
        'DB接続
        '===============================================
        mobjDb = New clsConn
        mobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/07/03  ｵﾗｸﾙ接続文字列のPoolingの設定値をConfigへ持たせる
        If mintOraclePoolingFlag = FLAG_OFF Then mobjDb.ConnectString &= ORACLE_CONNECT_STRING01
        '↑↑↑↑↑↑************************************************************************************************************
        While True
            '(接続するまでﾙｰﾌﾟ)
            Dim blnRet As Boolean = False
            blnRet = mobjDb.Connect()
            If blnRet = True Then Exit While
        End While

        '===============================================
        'DB接続
        '===============================================
        mobjDbLog = New clsConn
        mobjDbLog.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/07/03  ｵﾗｸﾙ接続文字列のPoolingの設定値をConfigへ持たせる
        If mintOraclePoolingFlag = FLAG_OFF Then mobjDbLog.ConnectString &= ORACLE_CONNECT_STRING01
        '↑↑↑↑↑↑************************************************************************************************************
        While True
            '(接続するまでﾙｰﾌﾟ)
            Dim blnRet As Boolean = False
            blnRet = mobjDbLog.Connect()
            If blnRet = True Then Exit While
            Call AddToLog(Me.Text & "DB接続失敗")
        End While


        mobjDb.BeginTrans()     'ﾄﾗﾝｻﾞｸｼｮﾝ開始
        Try

            '*****************************************************
            '色々設定
            '*****************************************************
            mobjOwner = New clsOwner                                        'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
            gobjMain = New clsMCIMain(mobjOwner, mobjDb, mobjDbLog)         'MCI通信ｵﾌﾞｼﾞｪｸﾄ生成
            gobjMCI = Me                                                    '自ﾌｫｰﾑｾｯﾄ
            Me.Text = mstrFormName                                          'ﾌｫｰﾑ名ｾｯﾄ
            NotifyIcon1.Text = Me.Text                                      'ｱｲｺﾝ名ｾｯﾄ
            NotifyIcon1.Visible = False                                     'ｱｲｺﾝ非表示


            '*****************************************************
            'ﾛｸﾞ出力
            '*****************************************************
            Call AddToLog(Me.Text & "開始。")


            '*****************************************************
            'ﾒｲﾝｵﾌﾞｼﾞｪｸﾄ初期化
            '*****************************************************
            gobjMain.Initialize()


            '*****************************************************
            'ｱｲｺﾝ化
            '*****************************************************
            'Me.ShowInTaskbar = True
            Call cmdIcon_ClickProcess()


            '*****************************************************
            '通信処理ﾀｲﾏｰ   ｾｯﾄ
            '*****************************************************
            tmrMain.Interval = minttmrMainInterval      'ﾀｲﾏｰｲﾝﾀｰﾊﾞﾙ
            tmrMain.Enabled = True


            '*****************************************************
            'その他
            '*****************************************************
            'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
            If mintDebugFlag = FLAG_ON Then chkDebugFlag.Checked = True Else chkDebugFlag.Checked = False


        Catch ex As Exception
            Throw ex

        Finally
            mobjDb.Commit()     'ｺﾐｯﾄ

        End Try
    End Sub
#End Region
#Region "  通信処理ﾀｲﾏｰ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 通信処理ﾀｲﾏｰ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrMainProcess()

        gobjMain.Main()

    End Sub
#End Region
#Region "  閉じる           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 閉じる
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdFormClose_Click_Process()
        Dim udtRetMsg As MsgBoxResult


        '*****************************************************
        'ﾒｯｾｰｼﾞﾎﾞｯｸ表示
        '*****************************************************
        If 0 < mintCloseWaitTime Then
            '(ﾌｫｰﾑｸﾛｰｽﾞ時の待機時間が設定されていた場合)
            Dim strMsg As String = ""
            strMsg &= Me.Text & "を終了してよろしいですか？"
            strMsg &= vbCrLf & "終了するには" & mintCloseWaitTime & "秒かかります。"
            udtRetMsg = MsgBox(strMsg, MsgBoxStyle.YesNo)
            If udtRetMsg <> MsgBoxResult.Yes Then Exit Sub
        End If


        '*****************************************************
        '色々処理
        '*****************************************************
        Dim dtmTemp As Date = Now       '現在時刻
        tmrMain.Enabled = False         'ﾀｲﾏｰｽﾄｯﾌﾟ
        While True
            '(指定された秒数経過したらExit)
            If DateAdd(DateInterval.Second, mintCloseWaitTime, dtmTemp) < Now Then Exit While
        End While
        mobjOwner.AddToLog("ﾌﾟﾛｸﾞﾗﾑを終了します。")


        '*****************************************************
        'ﾃｷｽﾄﾛｸﾞｸﾗｽ     削除
        '*****************************************************
        If IsNull(mobjLogWriter) = False Then
            mobjLogWriter.Dispose()
            mobjLogWriter = Nothing
        End If


        '*****************************************************
        'ﾌｫｰﾑｸﾛｰｽﾞ
        '*****************************************************
        Me.Close()


    End Sub
#End Region
#Region "  ｱｲｺﾝ関係         "
#Region "  ｱｲｺﾝ化       処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ化 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cmdIcon_ClickProcess()

        Me.Opacity = 0
        Me.ShowInTaskbar = False
        NotifyIcon1.Visible = True
        Me.Hide()

    End Sub
#End Region
#Region "  ｱｲｺﾝ         ﾀﾞﾌﾞﾙｸﾘｯｸ処理   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ ﾀﾞﾌﾞﾙｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub NotifyIcon1_MouseDoubleClickProcess()

        Me.Show()
        Me.Opacity = 100
        Me.ShowInTaskbar = True
        NotifyIcon1.Visible = False

    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑｸﾛｰｽﾞ        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｸﾛｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormClosingProcess()


        '*****************************************************
        'ﾃｷｽﾄﾛｸﾞｸﾗｽ     削除
        '*****************************************************
        If IsNull(mobjLogWriter) = False Then
            mobjLogWriter.Dispose()
            mobjLogWriter = Nothing
        End If


        '***********************************************
        '通信切断
        '***********************************************
        tmrMain.Enabled = False
        If IsNull(gobjMain) = False Then
            gobjMain.Close()
        End If


        '***********************************************
        'ｵﾌﾞｼﾞｪｸﾄ開放
        '***********************************************
        If IsNull(mobjDb) = False Then
            mobjDb.Disconnect()
            mobjDb = Nothing
        End If
        If IsNull(mobjDbLog) = False Then
            mobjDbLog.Disconnect()
            mobjDbLog = Nothing
        End If
        If IsNull(gobjMain) = False Then
            gobjMain = Nothing
        End If


    End Sub
#End Region

#Region "  ｴﾗｰ処理          "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException">ｴﾗｰException</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ComError(ByVal objException As Exception)
        Try
            '*****************************************************
            'ﾃｷｽﾄ生成
            '*****************************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(objException.StackTrace, ",", "，")       '半角ｶﾝﾏを全角ｶﾝﾏに変換
            strStackTrace = Split(strTemp, vbCrLf)

            '*****************************************************
            ' ﾛｸﾞ書込み
            '*****************************************************
            For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
                Me.AddToLog(objException.Message & "," & strStackTrace(ii))
            Next


        Catch ex2 As Exception
            'NOP
        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞ書込処理      "
    ''' ****************************************************************************************
    ''' <summary>
    '''  ﾛｸﾞ書込処理
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)
        Try

            '*****************************************************
            'ﾌｧｲﾙﾛｸﾞ出力
            '*****************************************************
            Dim strLogMessage As String = ""
            strLogMessage &= "," & strMsg_1
            mobjLogWriter.WriteTxtLog(strLogMessage)


            '*****************************************************
            'ﾘｽﾄ出力
            '*****************************************************
            Dim strMessage As String = Format(Now, DATE_FORMAT_99) & Space(5) & strMsg_1 & Space(5)
            If mintListFlag = FLAG_ON Then
                '==============================================
                '定義された行数までﾘｽﾄﾎﾞｯｸｽの行を削除
                '==============================================
                While ListBox1.Items.Count >= mintListCount
                    ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1)
                End While

                '==============================================
                'ﾘｽﾄ追加
                '==============================================
                ListBox1.Items.Insert(0, strMessage)

            End If


        Catch ex2 As Exception
            '何もしない

        End Try
    End Sub
#End Region
    '↑↑↑↑↑↑毎回必要
    '***********************************************


#Region "  ｼﾘｱﾙ通信ｵｰﾌﾟﾝ    "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｼﾘｱﾙ通信ｵｰﾌﾟﾝ
    ''' </summary>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Private Sub cmdOpenProcess()
        Try
            Call cmdCloseProcess()      '通信切断
        Catch ex As Exception
            Call AddToLog("通信ﾎﾟｰﾄｸﾛｰｽﾞ処理に失敗しました。")
        End Try
        Call FormLoadProcess()      '通信再開

        tmrMain.Enabled = True

    End Sub
#End Region
#Region "  ｼﾘｱﾙ通信ｸﾛｰｽﾞ    "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｼﾘｱﾙ通信ｸﾛｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Private Sub cmdCloseProcess()

        tmrMain.Enabled = False

        mobjDb.Disconnect()         'DB切断
        mobjDbLog.Disconnect()      'DB切断

        gobjMain.Close()

    End Sub
#End Region
#Region "  ﾃｽﾄ送信          "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ﾃｽﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Private Sub cmdShowSendProcess()
        Try

            'gobjMain.SendDataListener(TextBox1.Text)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region


End Class