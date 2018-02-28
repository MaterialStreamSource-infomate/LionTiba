'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】Exe起動用ﾌｫｰﾑ
'         ｻｰﾋﾞｽでは起動出来ない処理を実行するﾌﾟﾛｾｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports    "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports System.IO.Ports
Imports JobCommon
#End Region

Public Class frmExe

#Region "  共通変数         "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjDb As clsConn                       'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                    'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    Private mobjOwner As clsOwner                   'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ

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
    Private mintProcessCheck As Integer             'ﾌﾟﾛｸﾞﾗﾑ起動ﾁｪｯｸ数
    Private minttmrMainInterval As Integer          '通信処理ﾀｲﾏｰ             ｲﾝﾀｰﾊﾞﾙ
    Private mintCloseWaitTime As Integer            'ﾌｫｰﾑｸﾛｰｽﾞ時の待機時間
    Private mintDebugFlag As Integer                'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
    Private mintOraclePoolingFlag As Integer        'ｵﾗｸﾙ接続文字列のPoolingの設定値  [0:False  1:True(ﾃﾞﾌｫﾙﾄ値)]

#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ                                     "
    Private Sub frmExe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            '*****************************************************
            'Configﾌｧｲﾙ情報取得
            '*****************************************************
            Dim objConfig As New clsConnectConfig(CONFIG_EXE)                                   'Configﾌｧｲﾙ接続ｸﾗｽ生成
            'ﾛｸﾞ関係
            mstrFilePath = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_PATH))                    'ﾌｧｲﾙﾊﾟｽ        ｾｯﾄ
            mstrFileName = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_NAME))                    'ﾌｧｲﾙ名         ｾｯﾄ
            mintMaxDeleteDay = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_DELETE_DAY))          '保持日数       ｾｯﾄ
            mintMaxSize = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_SIZE))                     '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ
            'その他
            mstrFormName = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FORM_NAME))                    'ﾌｫｰﾑ名
            mintDebugFlag = TO_STRING(objConfig.GET_INFO(GKEY_MCI_DEBUG_FLAG))                  'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
            mintOraclePoolingFlag = TO_STRING(objConfig.GET_INFO(GKEY_MCI_ORACLE_POOLING_FLAG)) 'ｵﾗｸﾙ接続文字列のPoolingの設定値  [0:False  1:True(ﾃﾞﾌｫﾙﾄ値)]


            ''↓↓↓↓↓↓************************************************************************************************************
            ''SystemMate:N.Dounoshita 2012/05/08  二重起動ﾁｪｯｸをConfigへ持たせる

            ''*********************************************
            ''二重起動ﾁｪｯｸ
            ''*********************************************
            'If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) >= mintProcessCheck Then
            '    Dim strMessage As String
            '    strMessage = "同時に起動可能なﾌﾟﾛｸﾞﾗﾑ数を超えているので、起動できません。[同時起動制限数:" & TO_STRING(mintProcessCheck) & "]"
            '    MsgBox(strMessage)
            '    Me.Close()
            '    Me.Dispose()
            '    Exit Sub
            'End If

            ''↑↑↑↑↑↑************************************************************************************************************


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
            If mintOraclePoolingFlag = FLAG_OFF Then mobjDb.ConnectString &= ORACLE_CONNECT_STRING01
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
            If mintOraclePoolingFlag = FLAG_OFF Then mobjDbLog.ConnectString &= ORACLE_CONNECT_STRING01
            While True
                '(接続するまでﾙｰﾌﾟ)
                Dim blnRet As Boolean = False
                blnRet = mobjDbLog.Connect()
                If blnRet = True Then Exit While
                Call AddToLog(Me.Text & "DB接続失敗")
            End While


            Try


                '*****************************************************
                '初期設定
                '*****************************************************
                Me.Text = mstrFormName
                lblMessage.Text = "処理を実行しています。"


                '*****************************************************
                'ｺﾏﾝﾄﾞﾗｲﾝを配列で取得する
                '*****************************************************
                Dim strAryCmdString() As String = Nothing       'ｺﾏﾝﾄﾞﾗｲﾝ引数(配列)
                Dim strCmdStringLength As String = ""           'ｺﾏﾝﾄﾞﾗｲﾝ引数(文字列)
                strAryCmdString = System.Environment.GetCommandLineArgs()
                For ii As Integer = 1 To UBound(strAryCmdString)
                    If ii = 1 Then
                        strCmdStringLength &= strAryCmdString(ii)
                    Else
                        strCmdStringLength &= "," & strAryCmdString(ii)
                    End If
                Next
                Call AddToLog("【処理開始】[ｺﾏﾝﾄﾞﾗｲﾝ引数:" & strCmdStringLength & "]")


                '*****************************************************
                '処理開始
                '*****************************************************
                Dim objTemplateServer As New clsTemplateServer(mobjOwner, mobjDb, mobjDbLog)
                Select Case strAryCmdString(1)
                    Case CMD_STRING01_EXCEL_NIPPOU

                        lblMessage.Text = "Excel日報出力開始。[ｺﾏﾝﾄﾞﾗｲﾝ引数:" & strCmdStringLength & "]"
                        Call AddToLog(lblMessage.Text)
                        Call objTemplateServer.MakeExcelNippou(strAryCmdString(2))

                    Case CMD_STRING01_EXCEL_GEPPOU

                        lblMessage.Text = "Excel月報出力開始。[ｺﾏﾝﾄﾞﾗｲﾝ引数:" & strCmdStringLength & "]"
                        Call AddToLog(lblMessage.Text)
                        Call objTemplateServer.MakeExcelGeppou(strAryCmdString(2))

                    Case CMD_STRING01_PRINT

                        lblMessage.Text = "ﾋﾟｯｷﾝｸﾞﾘｽﾄ印字出力開始。[ｺﾏﾝﾄﾞﾗｲﾝ引数:" & strCmdStringLength & "]"
                        Call AddToLog(lblMessage.Text)
                        Call objTemplateServer.PrintPickingList(TO_DATE(strAryCmdString(2)), strAryCmdString(3))

                End Select


                '*****************************************************
                '処理開始
                '*****************************************************
                Call AddToLog("【処理終了】[ｺﾏﾝﾄﾞﾗｲﾝ引数:" & strCmdStringLength & "]")


            Catch ex As Exception
                Call ComError(ex)
                Call AddToLog("【処理異常終了】")
            End Try
        Catch ex As Exception
            'NOP
        Finally
            Me.Close()
        End Try
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


            '***************************************
            'ﾛｸﾞ出力
            '***************************************
            Dim objLogWrite As clsWriteLog
            objLogWrite = New clsWriteLog
            objLogWrite.clspFileName = mstrFilePath & mstrFileName                  'ﾌｧｲﾙ名         ｾｯﾄ
            objLogWrite.clspCopyFile = mstrFileName & "_old"                        'ﾌｧｲﾙ名(古い)   ｾｯﾄ
            objLogWrite.clspMaxSize = mintMaxSize * 1000000                         '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ


            objLogWrite.WriteLog(strMsg_1)                                          'ﾛｸﾞ書込


        Catch ex2 As Exception
            '何もしない

        End Try
    End Sub
#End Region

End Class