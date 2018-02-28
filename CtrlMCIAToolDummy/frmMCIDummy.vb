'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾀﾞﾐｰｺﾝﾄﾛｰﾙ通信用ﾌｫｰﾑ   (KSH用ﾃﾞﾊﾞｯｸﾞﾂｰﾙです)
' 【作成】2006/05/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports  "
Imports JOBCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
#End Region

Public Class frmMCIDummy

#Region "  共通変数"

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjOwner As clsOwner                   'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn                       'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                    'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
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
    Private minttmrMainInterval As Integer          '通信処理ﾀｲﾏｰ             ｲﾝﾀｰﾊﾞﾙ
    Private mintCloseWaitTime As Integer            'ﾌｫｰﾑｸﾛｰｽﾞ時の待機時間
    Private mintDebugFlag As Integer                'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ


#End Region
#Region "  ｲﾍﾞﾝﾄ    "
#Region "  ﾌｫｰﾑﾛｰﾄﾞ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmCtrlMCI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call FromLoadProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  通信処理ﾀｲﾏｰ              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 通信処理ﾀｲﾏｰ 
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
#Region "  送信ｼｰｹﾝｽNo  ｾｯﾄ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 送信ｼｰｹﾝｽNo  ｾｯﾄ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendSeqnoSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendSEQNoSet.Click
        Try

            Call cmdSendSeqnoSet_Click_Process()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  受信ｼｰｹﾝｽNo  ｾｯﾄ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 受信ｼｰｹﾝｽNo  ｾｯﾄ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdRecvSeqnoSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecvSEQNoSet.Click
        Try

            Call cmdRecvSeqnoSet_Click_Process()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  とにかく電文送信     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' とにかく電文送信 ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendTelegram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendTelegram.Click
        Try


            Call cmdSendTelegram_ClickProcess()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾀﾞﾐｰ → 物流          ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀﾞﾐｰ → 物流 ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendToButuryu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendToButuryu.Click
        Try

            Call cmdSendToButuryu_ClickProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  "
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
            ComError(ex)

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
    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Try

            Call NotifyIcon1_MouseDoubleClickProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region " "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  Close ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Call cmdClose_ClickProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ変更                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ変更
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


    '****************************************
    ' ｲﾍﾞﾝﾄ処理
    '****************************************
#Region "  ﾌｫｰﾑﾛｰﾄﾞ         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FromLoadProcess()


        '*****************************************************
        'Configﾌｧｲﾙ情報取得
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCIA_DUMMY)                             'Configﾌｧｲﾙ接続ｸﾗｽ生成
        'ﾛｸﾞ関係
        mstrFilePath = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_PATH))                    'ﾌｧｲﾙﾊﾟｽ        ｾｯﾄ
        mstrFileName = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_NAME))                    'ﾌｧｲﾙ名         ｾｯﾄ
        mintMaxDeleteDay = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_DELETE_DAY))          '保持日数       ｾｯﾄ
        mintMaxSize = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_SIZE))                     '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ
        'その他
        mintListCount = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_LIST_COUNT))                  'ﾘｽﾄ表示行数
        mintListFlag = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_LIST_FLAG))                    'ﾘｽﾄﾎﾞｯｸｽ使用ﾌﾗｸﾞ      0:使用しない    1:使用
        mstrFormName = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FORM_NAME))                    'ﾌｫｰﾑ名
        minttmrMainInterval = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_TMRMAIN_INTERVAL))      '通信処理ﾀｲﾏｰ             ｲﾝﾀｰﾊﾞﾙ 
        mintCloseWaitTime = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_CLOSE_WAIT_TIME))         'ﾌｫｰﾑｸﾛｰｽﾞ時の待機時間
        mintDebugFlag = TO_STRING(objConfig.GET_INFO(GKEY_MCI_DEBUG_FLAG))                  'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ


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
            gobjMain = New clsMCIMainDummy(mobjOwner, mobjDb, mobjDbLog)         'MCI通信ｵﾌﾞｼﾞｪｸﾄ生成
            gobjMCI = Me                                                    '自ﾌｫｰﾑｾｯﾄ
            Me.Text = mstrFormName                                          'ﾌｫｰﾑ名ｾｯﾄ
            NotifyIcon1.Text = Me.Text                                      'ｱｲｺﾝ名ｾｯﾄ
            NotifyIcon1.Visible = False                                     'ｱｲｺﾝ非表示


            '*****************************************************
            'ﾛｸﾞ出力
            '*****************************************************
            Call AddToLog(Me.Text & "開始")


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
            '送信画面表示
            '*****************************************************
            Call cmdSendToButuryu_ClickProcess()


            '*****************************************************
            'その他
            '*****************************************************
            'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
            If mintDebugFlag = FLAG_ON Then chkDebugFlag.Checked = True Else chkDebugFlag.Checked = False


        Catch ex As Exception
            Call ComError(ex)
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
#Region "  送信ｼｰｹﾝｽNo  ｾｯﾄ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 送信ｼｰｹﾝｽNo  ｾｯﾄ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendSeqnoSet_Click_Process()

        gobjMain.intSendSEQNo = TO_INTEGER(txtSendSEQNo.Text)
        txtSendSEQNo.Text = ZERO_PAD(gobjMain.intSendSEQNo, 4)

    End Sub
#End Region
#Region "  受信ｼｰｹﾝｽNo  ｾｯﾄ処理"
    Private Sub cmdRecvSeqnoSet_Click_Process()

        gobjMain.intRecvSEQNo = TO_INTEGER(txtRecvSEQNo.Text)
        txtRecvSEQNo.Text = ZERO_PAD(gobjMain.intRecvSEQNo, 4)

    End Sub
#End Region
#Region "  とにかく電文送信     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' とにかく電文送信 ｸﾘｯｸ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendTelegram_ClickProcess()

        Call Write(txtSendTelegram.Text)

    End Sub
#End Region
#Region "  ﾀﾞﾐｰ → 物流         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ﾀﾞﾐｰ → 物流 ｸﾘｯｸ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendToButuryu_ClickProcess()


        '***********************************************
        'ﾁｪｯｸ
        '***********************************************
        If IsNull(gobjMCIToServer) = False Then
            '(ﾌｫｰﾑが存在していた場合)

            If gobjMCIToServer.NotifyIcon1.Visible = True Then
                '(ｱｲｺﾝ化されていた場合)
                MsgBox("既にﾌｫｰﾑが展開されている為、さらにﾌｫｰﾑは作成できません。")
                Exit Sub
            Else
                '(ｱｲｺﾝ化されていない場合)
                gobjMCIToServer.Close()
                gobjMCIToServer.Dispose()
                gobjMCIToServer = Nothing
            End If
        End If


        '***********************************************
        'ﾌｫｰﾑ表示
        '***********************************************
        gobjMCIToServer = New frmMCIDummyToServer
        gobjMCIToServer.ShowDialog()
        If gobjMCIToServer.NotifyIcon1.Visible = False Then
            '(ｱｲｺﾝ化以外の場合)
            gobjMCIToServer.Close()
            gobjMCIToServer.Dispose()
            gobjMCIToServer = Nothing
        End If


    End Sub
#End Region
#Region "  Close                ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Close ｸﾘｯｸ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProcess()

        '*****************************************************
        'ﾃｷｽﾄﾛｸﾞｸﾗｽ     削除
        '*****************************************************
        If IsNull(mobjLogWriter) = False Then
            mobjLogWriter.Dispose()
            mobjLogWriter = Nothing
        End If


        gobjMain.Close()
        Me.Close()

    End Sub
#End Region
#Region "  ｱｲｺﾝ関係"

#Region "  ｱｲｺﾝ化       処理"
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

#Region "  ｱｲｺﾝ         ﾀﾞﾌﾞﾙｸﾘｯｸ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ｱｲｺﾝ ﾀﾞﾌﾞﾙｸﾘｯｸ処理
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


    '****************************************
    ' ﾌｫｰﾑ内共通関数処理
    '****************************************
#Region "  ﾃｷｽﾄ送信                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ﾃｷｽﾄ送信
    ''' </summary>
    ''' <param name="strText"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Write(ByVal strText As String)
        Try

            Call gobjMain.SendDataVAGC(strText)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ｴﾗｰ処理                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException"></param>
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
#Region "  ﾛｸﾞ書込処理                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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


End Class