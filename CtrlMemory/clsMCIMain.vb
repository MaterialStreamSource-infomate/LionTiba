'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCIﾒｲﾝｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon.clsConst
Imports MateCommon
#End Region

Public Class clsMCIMain

#Region "  共通変数02           "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================

    '==================================================
    '内部変数
    '==================================================


#End Region

    '***********************************************
    '↓↓↓↓↓↓毎回必要
#Region "  共通変数             "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjOwner As Object                                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ

    '==================================================
    '内部変数
    '==================================================
    Private mdtmNow As Date                     '現在日時
    Private mdtmBeforeMemoryLogTime As Date     '前回ﾒﾓﾘﾛｸﾞ出力時間
    Private mdtmBeforeOraLogTime As Date        '前回ﾒﾓﾘﾛｸﾞ出力時間

    '==================================================
    'Configﾌｧｲﾙ情報
    '==================================================
    'ﾛｸﾞ関係
    Private mstrFilePath As String                  'ﾌｧｲﾙﾊﾟｽ        ｾｯﾄ
    Private mstrFileName As String                  'ﾌｧｲﾙ名         ｾｯﾄ
    Private mintMaxDeleteDay As Integer             '保持日数       ｾｯﾄ
    Private mintMaxSize As Integer                  '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ
    'その他
    Private mintDebugFlag As Integer                'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ

    '==================================================
    '固定値
    '==================================================
    Private Const ERR_MSG_01 As String = "ｼｽﾃﾑｴﾗｰ発生。"

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
        End Set
    End Property
#End Region

#Region "  ﾒｲﾝ処理              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Overridable Sub Main()
        Try
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '*****************************************************
            '色々初期化
            '*****************************************************
            mdtmNow = Now


            '*****************************************************
            'Configﾌｧｲﾙ情報取得
            '*****************************************************
            Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)                              'Configﾌｧｲﾙ接続ｸﾗｽ生成
            'ﾛｸﾞ関係
            mstrFilePath = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_PATH))                    'ﾌｧｲﾙﾊﾟｽ        ｾｯﾄ
            mstrFileName = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_NAME))                    'ﾌｧｲﾙ名         ｾｯﾄ
            mintMaxDeleteDay = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_DELETE_DAY))          '保持日数       ｾｯﾄ
            mintMaxSize = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_SIZE))                     '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ
            'その他
            Dim intMemoryLogTimer As Integer                                                    'ﾒﾓﾘﾛｸﾞを出力する周期      (min)
            intMemoryLogTimer = TO_INTEGER(objConfig.GET_INFO("MemoryLogTimer"))


            '↓↓↓↓↓↓************************************************************************************************************
            'ﾏﾃｽﾄ特有処理

            '*****************************************************
            'ｵﾗｸﾙのﾒﾓﾘ状態の出力処理(ﾏﾃｽﾄ特有処理)
            '*****************************************************
            Try
                Call MainProcess03()
            Catch ex As Exception
                Call ComError(ex)
            End Try

            '↑↑↑↑↑↑************************************************************************************************************


            '*****************************************************
            'ﾀｲﾏｰ処理
            '*****************************************************
            Dim objDiff As TimeSpan = mdtmBeforeMemoryLogTime.AddMinutes(intMemoryLogTimer) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If
            mdtmBeforeMemoryLogTime = Now


            '*****************************************************
            'ﾌﾟﾛｾｽのﾒﾓﾘ状態の出力処理
            '*****************************************************
            Try
                Call MainProcess01()
            Catch ex As Exception
                Call ComError(ex)
            End Try


            '*****************************************************
            'ﾌｧｲﾙ削除処理
            '*****************************************************
            Try
                Call MainProcess02()
            Catch ex As Exception
                Call ComError(ex)
            End Try


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ(主にﾛｸﾞ書込みに使用)</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object)
        Try

            '*****************************************************
            '色々初期化
            '*****************************************************
            mobjOwner = objOwner                                'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
            mdtmNow = Now


        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region
#Region "  初期化               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Initialize()


        '****************************************************
        '通信ｵｰﾌﾟﾝ
        '****************************************************
        Call Open()


    End Sub
#End Region

#Region "  ﾛｸﾞ書き込み処理                  "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strMsg_1">ﾛｸﾞﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region
#Region "  ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)       "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)
    ''' </summary>
    ''' <param name="strMsg_1">ﾛｸﾞﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddToDebugLog(ByVal strMsg_1 As String)

        If intDebugFlag = 1 Then
            mobjOwner.AddToLog(strMsg_1)
        End If

    End Sub
#End Region
#Region "  ｴﾗｰ処理                          "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException">ｴﾗｰException</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
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
                AddToLog(objException.Message & "," & strStackTrace(ii))
            Next


        Catch ex2 As Exception
            'NOP
        End Try
    End Sub
#End Region
    '↑↑↑↑↑↑毎回必要
    '***********************************************


    '*******************
    'Public
    '*******************
#Region "  ﾌﾟﾛｾｽのﾒﾓﾘ状態の出力処理                     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾌﾟﾛｾｽのﾒﾓﾘ状態の出力処理
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub MainProcess01()


        '**********************************************************************************
        'Configﾌｧｲﾙ情報取得
        '**********************************************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Configﾌｧｲﾙ接続ｸﾗｽ生成
        Dim strProcessNameArray() As String                         'ﾌﾟﾛｾｽ名配列
        strProcessNameArray = Split(TO_STRING(objConfig.GET_INFO("ProcessNameArray")), ",")


        '**********************************************************************************
        'ﾌﾟﾛｾｽ名の取得
        '**********************************************************************************
        For ii As Integer = 0 To strProcessNameArray.Length - 1
            strProcessNameArray(ii) = strProcessNameArray(ii).Replace(vbCrLf, "")
            strProcessNameArray(ii) = RTrim(strProcessNameArray(ii))
            strProcessNameArray(ii) = LTrim(strProcessNameArray(ii))
        Next


        '**********************************************************************************
        'ローカルコンピュータ上で実行されているすべてのプロセスを取得
        '**********************************************************************************
        Dim ps As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcesses()

        '"machinename"という名前のコンピュータで実行されている
        'すべてのプロセスを取得するには次のようにする。
        'Dim ps As System.Diagnostics.Process() = _
        '    System.Diagnostics.Process.GetProcesses("machinename")

        '**********************************************************************************
        '配列から1つずつ取り出す
        '**********************************************************************************
        For Each p As System.Diagnostics.Process In ps
            Try


                '**********************************************************************************
                'ﾌﾟﾛｾｽﾁｪｯｸ
                '**********************************************************************************
                If -1 = ArrayFindData(strProcessNameArray, p.ProcessName) Then Continue For


                ''プロセス名を出力する
                'Call AddToLog("プロセス名: {0}" & p.ProcessName)
                ''ID
                'Call AddToLog("ID: {0}" & p.Id)
                ''メインモジュールのパス
                'Call AddToLog("パス: {0}" & p.MainModule.FileName)
                ''合計プロセッサ時間
                'Call AddToLog("合計プロセッサ時間: {0}" & TO_STRING(p.TotalProcessorTime.Days))
                ''物理メモリ使用量
                'Call AddToLog("物理メモリ使用量: {0}" & p.WorkingSet64)
                ''.NET Framework 1.1以前では次のようにする
                ''Call AddToLog("物理メモリ使用量: {0}", p.WorkingSet)


                '**********************************************************************************
                'ﾌｧｲﾙ名の作成
                '**********************************************************************************
                Dim strFile As String = ""
                Try
                    strFile &= p.MainModule.FileName
                Catch ex As Exception
                    'MainModule.FileNameへのｱｸｾｽが拒否される場合がある
                    'NOP
                End Try
                strFile = Replace(strFile, "\", "_")
                strFile = Replace(strFile, ":", "_")
                strFile &= "_ID_" & p.Id & "_" & p.ProcessName


                '**********************************************************************************
                'ﾛｸﾞﾃｷｽﾄ作成
                '**********************************************************************************
                Dim strMsg As String = ""
                strMsg &= "PrivateMemorySize:" & FixTextMemory(p.PrivateMemorySize64)
                strMsg &= ",VirtualMemorySize:" & FixTextMemory(p.VirtualMemorySize64)
                strMsg &= ",WorkingSet:" & FixTextMemory(p.WorkingSet64)
                Try
                    Dim objDiff As TimeSpan = Now - p.StartTime
                    strMsg &= ",動作日数:" & SPC_PAD_RIGHT_SJIS(Math.Floor(TO_INTEGER(objDiff.TotalDays)) & "日", 7)
                Catch ex As Exception
                    'ｱｸｾｽが拒否される場合がある
                    'NOP
                End Try


                '**********************************************************************************
                'ﾛｸﾞ書込み
                '**********************************************************************************
                Call AddMemoryLog(strFile, strMsg)


            Catch ex As Exception
                Call AddToLog("エラー: {0}" & ex.Message)
            End Try
        Next


        '*****************************************************
        'ﾛｸﾞ出力
        '*****************************************************
        AddToLog("ﾒﾓﾘﾛｸﾞ出力完了。")


    End Sub
#End Region
#Region "  ﾌｧｲﾙ削除処理                                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾌｧｲﾙ削除処理
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub MainProcess02()


        '**********************************************************************************
        'Configﾌｧｲﾙ情報取得
        '**********************************************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Configﾌｧｲﾙ接続ｸﾗｽ生成
        Dim strFolderMain As String                                 'ﾒﾓﾘﾛｸﾞ用ﾌｫﾙﾀﾞ名
        Dim strFolderDeleteTimer As String                          'ｵﾗｸﾙﾒﾓﾘﾛｸﾞ用ﾌｫﾙﾀﾞを削除する周期        (Day)
        strFolderMain = TO_STRING(objConfig.GET_INFO("FolderMain"))
        strFolderDeleteTimer = TO_STRING(objConfig.GET_INFO("FolderDeleteTimer"))


        '**********************************************************************************
        'ﾌｫﾙﾀﾞの削除
        '**********************************************************************************
        '================================================
        '色々設定
        '================================================
        Dim strOraMemoryLogFoler As String
        If Right(mstrFilePath, 1) = "\" Then
            strOraMemoryLogFoler = mstrFilePath & strFolderMain
        Else
            strOraMemoryLogFoler = mstrFilePath & "\" & strFolderMain
        End If

        '================================================
        'ﾌｧｲﾙを削除
        '================================================
        Call DeleteFile(strOraMemoryLogFoler, TO_INTEGER(strFolderDeleteTimer))


        '*****************************************************
        'ﾛｸﾞ出力
        '*****************************************************
        AddToLog("ﾌｧｲﾙ削除処理完了。")


    End Sub
#End Region
#Region "  ｵﾗｸﾙのﾒﾓﾘ状態の出力処理(ﾏﾃｽﾄ特有処理)        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｵﾗｸﾙのﾒﾓﾘ状態の出力処理(ﾏﾃｽﾄ特有処理)
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub MainProcess03()


        '**********************************************************************************
        'Configﾌｧｲﾙ情報取得
        '**********************************************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Configﾌｧｲﾙ接続ｸﾗｽ生成
        Dim strMaterialStreamMode As String                         'ﾏﾃﾘｱﾙｽﾄﾘｰﾑﾓｰﾄﾞ ﾏﾃｽﾄ特有のﾁｪｯｸが実行されるかどうかのﾌﾗｸﾞ
        Dim strFolderMain As String                                 'ﾒﾓﾘﾛｸﾞ用ﾌｫﾙﾀﾞ名
        Dim strFolderOra As String                                  'ｵﾗｸﾙﾒﾓﾘﾛｸﾞ用ﾌｫﾙﾀﾞ名
        Dim strOraLogTimer As String                                'ｵﾗｸﾙﾒﾓﾘﾛｸﾞを出力する周期                   (min)
        Dim strExcecProcess() As String                             '実行するﾌﾟﾛｾｽをｶﾝﾏ区切りで指定
        strMaterialStreamMode = TO_STRING(objConfig.GET_INFO("MaterialStreamMode"))
        strFolderMain = TO_STRING(objConfig.GET_INFO("FolderMain"))
        strFolderOra = TO_STRING(objConfig.GET_INFO("FolderOra"))
        strOraLogTimer = TO_STRING(objConfig.GET_INFO("OraLogTimer"))
        strExcecProcess = Split(TO_STRING(objConfig.GET_INFO("ExcecProcess")), ",")


        '*****************************************************
        'ﾀｲﾏｰ処理
        '*****************************************************
        Dim objDiff As TimeSpan = mdtmBeforeOraLogTime.AddMinutes(strOraLogTimer) - Now
        If 0 < objDiff.TotalMilliseconds Then
            Exit Sub
        End If
        mdtmBeforeOraLogTime = Now


        '**********************************************************************************
        '色々ﾁｪｯｸ
        '**********************************************************************************
        If TO_INTEGER(strMaterialStreamMode) = FLAG_OFF Then Exit Sub


        '**********************************************************************************
        'ﾌﾟﾛｾｽ名の取得
        '**********************************************************************************
        For ii As Integer = 0 To strExcecProcess.Length - 1
            strExcecProcess(ii) = strExcecProcess(ii).Replace(vbCrLf, "")
            strExcecProcess(ii) = RTrim(strExcecProcess(ii))
            strExcecProcess(ii) = LTrim(strExcecProcess(ii))
        Next


        '*************************************************
        'ﾌﾟﾛｾｽの実行
        '*************************************************
        For ii As Integer = 0 To strExcecProcess.Length - 1
            If IsNull(strExcecProcess(ii)) Then Continue For
            If mintDebugFlag <> FLAG_ON Then
                Call Shell(strExcecProcess(ii), AppWinStyle.Hide)
            Else
                Call Shell(strExcecProcess(ii), AppWinStyle.NormalFocus)
            End If
        Next


        '*****************************************************
        'ﾛｸﾞ出力
        '*****************************************************
        AddToLog("ｵﾗｸﾙﾒﾓﾘﾛｸﾞ出力完了。")


    End Sub
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ｵﾗｸﾙのﾒﾓﾘ状態の出力処理(ﾏﾃｽﾄ特有処理)
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Public Sub MainProcess02()


    '    '**********************************************************************************
    '    'Configﾌｧｲﾙ情報取得
    '    '**********************************************************************************
    '    Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Configﾌｧｲﾙ接続ｸﾗｽ生成
    '    Dim strMaterialStreamMode As String                         'ﾏﾃﾘｱﾙｽﾄﾘｰﾑﾓｰﾄﾞ ﾏﾃｽﾄ特有のﾁｪｯｸが実行されるかどうかのﾌﾗｸﾞ
    '    Dim strFolderTemp As String                                 'ｵﾗｸﾙﾒﾓﾘﾛｸﾞ用一時保管用ﾌｫﾙﾀﾞ
    '    Dim strFolderName As String                                 'ｵﾗｸﾙﾒﾓﾘﾛｸﾞ用ﾌｫﾙﾀﾞ名
    '    Dim strFolderDeleteTimer As String                          'ｵﾗｸﾙﾒﾓﾘﾛｸﾞ用ﾌｫﾙﾀﾞを削除する周期        (Day)
    '    Dim strFolderCopyWait As String                             'ｵﾗｸﾙﾒﾓﾘﾛｸﾞ用ﾌｫﾙﾀﾞをｺﾋﾟｰする待機時間    (ms)  CSVﾌｧｲﾙが作成されるまで待機
    '    Dim strExcecProcess() As String                             '実行するﾌﾟﾛｾｽをｶﾝﾏ区切りで指定
    '    strMaterialStreamMode = TO_STRING(objConfig.GET_INFO("MaterialStreamMode"))             
    '    strFolderTemp = TO_STRING(objConfig.GET_INFO("FolderTemp"))
    '    strFolderName = TO_STRING(objConfig.GET_INFO("FolderName"))
    '    strFolderDeleteTimer = TO_STRING(objConfig.GET_INFO("FolderDeleteTimer"))
    '    strFolderCopyWait = TO_STRING(objConfig.GET_INFO("FolderCopyWait"))
    '    strExcecProcess = TO_STRING(objConfig.GET_INFO("ExcecProcess")).Split(",")


    '    '**********************************************************************************
    '    '色々ﾁｪｯｸ
    '    '**********************************************************************************
    '    If TO_INTEGER(strMaterialStreamMode) = FLAG_OFF Then Exit Sub


    '    '**********************************************************************************
    '    'ﾌﾟﾛｾｽ名の取得
    '    '**********************************************************************************
    '    For ii As Integer = 0 To strExcecProcess.Length - 1
    '        strExcecProcess(ii) = strExcecProcess(ii).Replace(vbCrLf, "")
    '        strExcecProcess(ii) = RTrim(strExcecProcess(ii))
    '        strExcecProcess(ii) = LTrim(strExcecProcess(ii))
    '    Next


    '    '**********************************************************************************
    '    'ﾌｫﾙﾀﾞの作成
    '    '**********************************************************************************
    '    Call System.IO.Directory.CreateDirectory(strFolderTemp)          'ﾌｫﾙﾀﾞ作成


    '    '*************************************************
    '    'ｺﾏﾝﾄﾞﾌﾟﾛﾝﾌﾟﾄ実行
    '    '*************************************************
    '    For ii As Integer = 0 To strExcecProcess.Length - 1
    '        '(ﾙｰﾌﾟ:ｺﾏﾝﾄﾞﾌﾟﾛﾝﾌﾟﾄ実行)

    '        Dim psi As New System.Diagnostics.ProcessStartInfo()
    '        psi.FileName = System.Environment.GetEnvironmentVariable("ComSpec")     'ComSpecのパスを取得する
    '        psi.RedirectStandardInput = False           '出力を読み取れるようにする
    '        psi.RedirectStandardOutput = True           '出力を読み取れるようにする
    '        psi.UseShellExecute = False                 '出力を読み取れるようにする
    '        psi.CreateNoWindow = True                   'ウィンドウを表示しないようにする
    '        psi.Arguments = strExcecProcess(ii) 'コマンドラインを指定（"/c"は実行後閉じるために必要）
    '        'psi.Arguments = "/c " & strExcecProcess(ii) 'コマンドラインを指定（"/c"は実行後閉じるために必要）
    '        '起動
    '        System.Diagnostics.Process.Start(psi)

    '    Next


    '    '**********************************************************************************
    '    '作成されたcsvﾌｧｲﾙをｺﾋﾟｰ
    '    '**********************************************************************************
    '    '=======================================================
    '    'csvﾌｧｲﾙが出来るまで待機
    '    '=======================================================
    '    Call Threading.Thread.Sleep(TO_INTEGER(strFolderCopyWait))

    '    '=======================================================
    '    'ﾌｫﾙﾀﾞを作成
    '    '=======================================================
    '    Dim strOraMemoryLogFoler As String
    '    If Right(mstrFilePath, 1) = "\" Then
    '        strOraMemoryLogFoler = mstrFilePath & strFolderName
    '    Else
    '        strOraMemoryLogFoler = mstrFilePath & "\" & strFolderName
    '    End If
    '    strOraMemoryLogFoler &= "\" & Format(Now, "yyyyMMddhhmmss")
    '    Call System.IO.Directory.CreateDirectory(strOraMemoryLogFoler)      'ﾌｫﾙﾀﾞ作成

    '    '=======================================================
    '    'ﾌｫﾙﾀﾞをｺﾋﾟｰ
    '    '=======================================================
    '    Call My.Computer.FileSystem.CopyDirectory(strFolderTemp, strOraMemoryLogFoler)


    '    '**********************************************************************************
    '    'ﾌｫﾙﾀﾞの削除
    '    '**********************************************************************************
    '    '================================================
    '    '色々設定
    '    '================================================
    '    Dim dtmKigen As Date = Now.AddDays(-(TO_INTEGER(strFolderDeleteTimer)))

    '    '================================================
    '    'ﾌｧｲﾙを取得
    '    '================================================
    '    Dim objFiles As String() = System.IO.Directory.GetDirectories(strOraMemoryLogFoler _
    '                                                                , "*" _
    '                                                                , System.IO.SearchOption.TopDirectoryOnly _
    '                                                                )

    '    '================================================
    '    'ﾌｧｲﾙを削除
    '    '================================================
    '    For ii As Integer = 0 To UBound(objFiles)
    '        '(ﾙｰﾌﾟ:ﾌｫﾙﾀﾞ内のﾌｧｲﾙ数)

    '        '削除処理
    '        Dim dtmFileTime As Date = System.IO.File.GetLastWriteTime(objFiles(ii))   'ﾌｧｲﾙ更新日時取得
    '        If dtmFileTime <= dtmKigen Then
    '            '(期限が過ぎた場合)
    '            System.IO.File.Delete(objFiles(ii))      '削除
    '        End If

    '    Next


    'End Sub
#End Region

#Region "  通信ｵｰﾌﾟﾝ            "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｵｰﾌﾟﾝ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Open()
        'NOP
    End Sub
#End Region
#Region "  通信ｸﾛｰｽﾞ            "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｸﾛｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Close()
        'NOP
    End Sub
#End Region
#Region "  ﾒﾓﾘﾛｸﾞ出力           "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾓﾘﾛｸﾞ出力
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddMemoryLog(ByVal strFileName As String _
                          , ByVal strMsg1 As String _
                          , Optional ByVal strMsg2 As String = "" _
                          , Optional ByVal strMsg3 As String = "" _
                          )


        '**********************************************************************************
        'Configﾌｧｲﾙ情報取得
        '**********************************************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Configﾌｧｲﾙ接続ｸﾗｽ生成
        Dim strFolderMain As String                                 'ﾒﾓﾘﾛｸﾞ用ﾌｫﾙﾀﾞ名
        strFolderMain = TO_STRING(objConfig.GET_INFO("FolderMain"))


        '******************************************************
        'ﾛｸﾞ出力ﾊﾟｽの調整
        '******************************************************
        Dim strFilePathTemp As String
        'ﾌｧｲﾙﾊﾟｽ        ｾｯﾄ
        strFilePathTemp = mstrFilePath
        If Right(mstrFilePath, 1) <> "\" Then
            strFilePathTemp &= "\"
        End If
        'ﾒﾓﾘﾛｸﾞ用ﾌｫﾙﾀﾞ名
        strFilePathTemp &= strFolderMain
        If Right(mstrFilePath, 1) <> "\" Then
            strFilePathTemp &= "\"
        End If


        '******************************************************
        'ﾛｸﾞ出力        作成
        '******************************************************
        Dim objLogWrite As clsWriteLog
        objLogWrite = New clsWriteLog
        objLogWrite.clspFileName = strFilePathTemp & strFileName & ".log"            'ﾌｧｲﾙ名         ｾｯﾄ
        objLogWrite.clspCopyFile = strFilePathTemp & strFileName & "_Old.log"        'ﾌｧｲﾙ名(古い)   ｾｯﾄ
        objLogWrite.clspMaxSize = mintMaxSize * 1000 * 1000                          '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ    (Byte → MByte)


        '******************************************************
        'ﾛｸﾞ出力
        '******************************************************
        objLogWrite.WriteLog(strMsg1, strMsg2, strMsg3)              'ﾛｸﾞ書込


    End Sub
#End Region
#Region "  ﾌｫｰﾏｯﾄを整える処理   "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾏｯﾄを整える処理
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function FixTextMemory(ByVal strMemorySize As String) As String
        Dim strReturn As String


        '******************************************************
        'ﾌｫｰﾏｯﾄを整える
        '******************************************************
        strReturn = strMemorySize
        strReturn = Format(TO_INTEGER(strReturn), "#,0")
        strReturn = SPC_PAD_RIGHT_SJIS(strReturn, 17)
        strReturn = strReturn & Space(3)


        Return strReturn
    End Function
#End Region


End Class
