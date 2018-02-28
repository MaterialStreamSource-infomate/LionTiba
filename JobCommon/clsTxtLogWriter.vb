'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
' 【機能】ﾃｷｽﾄﾛｸﾞｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "インポートの宣言"
Imports System.IO
Imports System.Threading
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Text
#End Region

'===============================================================================
'【機能】    LogWriter : ログファイル管理クラス
'===============================================================================
Public Class clsLogWriter
    Implements IDisposable

#Region "列挙体"
#End Region

#Region "定数"
    Private Const LOG_EXTENSION As String = ".Log"  'ログファイル拡張子
#End Region

#Region "フィールド"
    '----- Class Level Shared
    Private Shared mLogInstns As New Collection     ' LogWriter クラスオブジェクト コレクション

    '----- Class Level Valiables (Private)
    ' Local Valiables
    Private MsgQueue As Queue      ' ログQueue
    Private ThreadObj As Thread    ' ログスレッド

    Private mblnDisposedFlg As Boolean = False          ' Disposeフラグ
    Private mstrLogDateFormat As String                 ' ファイルフォーマット(Ex."yyyyMMdd")
    Private mblnEndFlg As Boolean = False               ' 終了フラグ

    ' Config Value
    Private mstrLogPath As String                       ' ログファイル出力パス
    Private mstrLogFileName As String                   ' ログファイル名
    Private mintLogDeleteDay As Integer                 ' ログ保持日数
    Private mintLogFileSize As Integer                  ' ログファイルMaxサイズ[M Byte]

#End Region

#Region "インスタンス生成"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' インスタンス生成(各ポートに一つのインスタンス生成)
    ''' </summary>
    ''' <param name="strLogPath">ﾛｸﾞﾌｧｲﾙ出力ﾊﾟｽ</param>
    ''' <param name="strLogFileName">ﾛｸﾞﾌｧｲﾙ名</param>
    ''' <param name="intLogDeleteDay">ﾛｸﾞ保持日数[省略可]初回時のみ指定</param>
    ''' <param name="intLogFileSize">ﾛｸﾞﾌｧｲﾙMaxｻｲｽﾞ[省略可]初回時のみ指定</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Shared Function GetInstance(ByVal strLogPath As String, ByVal strLogFileName As String, _
                                       Optional ByVal intLogDeleteDay As Integer = 0, _
                                       Optional ByVal intLogFileSize As Integer = 0) As clsLogWriter
        Dim LogWriterObj As clsLogWriter = Nothing          ' LogWriterクラスオブジェクト

        Try
            LogWriterObj = CType(mLogInstns.Item(strLogPath & strLogFileName), clsLogWriter)
        Catch
        End Try
        If LogWriterObj Is Nothing Then
            SyncLock GetType(clsLogWriter)
                If LogWriterObj Is Nothing Then
                    LogWriterObj = New clsLogWriter(strLogPath, strLogFileName, intLogDeleteDay, intLogFileSize)
                    mLogInstns.Add(LogWriterObj, strLogPath & strLogFileName)
                End If
            End SyncLock
        End If
        LogWriterObj = Nothing
        Return mLogInstns.Item(strLogPath & strLogFileName)

    End Function
#End Region

#Region "コンストラクタ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="strLogPath">ﾛｸﾞﾌｧｲﾙ出力ﾊﾟｽ</param>
    ''' <param name="strLogFileName">ﾛｸﾞﾌｧｲﾙ名</param>
    ''' <param name="intLogDeleteDay">ﾛｸﾞ保持日数</param>
    ''' <param name="intLogFileSize">ﾛｸﾞﾌｧｲﾙMaxｻｲｽﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub New(ByVal strLogPath As String, ByVal strLogFileName As String, ByVal intLogDeleteDay As Integer, ByVal intLogFileSize As Integer)

        '-------------------------------
        ' ログパス
        '-------------------------------
        Me.mstrLogPath = strLogPath
        ' 指定のパスが存在しなければ作成し、作成不可ならアプリケーション実行フォルダ
        If Directory.Exists(Me.mstrLogPath) = False Then
            Try
                Directory.CreateDirectory(Me.mstrLogPath)
            Catch ex As Exception
                Me.mstrLogPath = Application.StartupPath
            End Try
        End If
        If Right(Me.mstrLogPath, 1) <> "\" Then Me.mstrLogPath &= "\"

        '-------------------------------
        ' ログ保持期間[日]
        '-------------------------------
        Me.mintLogDeleteDay = intLogDeleteDay

        '-------------------------------
        ' ログファイルMaxサイズ[M Byte]
        '-------------------------------
        Me.mintLogFileSize = intLogFileSize

        '-------------------------------
        ' ログファイル名
        '-------------------------------
        Me.mstrLogFileName = strLogFileName

        '---------------------------------
        ' ファイルフォーマット
        '---------------------------------
        Me.mstrLogDateFormat = "yyyyMMdd"

        '---------------------------------
        ' キューオブジェクト生成
        '---------------------------------
        Me.MsgQueue = Queue.Synchronized(New Queue)

        '---------------------------------
        ' ログスレッドの立上げ
        '---------------------------------
        Me.ThreadObj = New Thread(New ThreadStart(AddressOf Me.WriteTxtLogThread))
        Me.ThreadObj.Start()

    End Sub
#End Region

#Region "デストラクタ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' デストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' オブジェクト解放
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' オブジェクト解放
    ''' </summary>
    ''' <param name="Disposing"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Overloads Sub Dispose(ByVal Disposing As Boolean)
        Dim iLoop As Integer
        Dim strNowFileName As String       ' 現ファイル名
        Dim strNewFileName As String       ' 変更ファイル名
        Dim intNowDateTime As String       ' 現在日時

        ' Disposeが行われたかどうかを判定
        If Not (Me.mblnDisposedFlg) Then
            ' DisposeフラグON
            Me.mblnDisposedFlg = True

            If mLogInstns.Count > 0 Then

                ' 終了フラグON
                Me.mblnEndFlg = True

                ' 現在日時取得
                intNowDateTime = Format(Now, Me.mstrLogDateFormat)

                Try
                    '------------------------------
                    ' ループ中のスレッドをとめる
                    '------------------------------
                    SyncLock (Me.MsgQueue)
                        Monitor.Pulse(Me.MsgQueue)
                    End SyncLock

                    '-------------------------------------
                    ' ループ中のスレッドが終了するまでまつ
                    '-------------------------------------
                    Me.ThreadObj.Join()

                    '------------------------------
                    ' オブジェクト破棄
                    '------------------------------
                    Me.MsgQueue = Nothing

                    '------------------------------
                    ' スレッド破棄
                    '------------------------------
                    Me.ThreadObj = Nothing

                    '---------------------------------------
                    ' ファイル名変更
                    '---------------------------------------
                    ' 現ファイル名
                    strNowFileName = Me.mstrLogPath & Me.mstrLogFileName & LOG_EXTENSION
                    ' 現ファイルがあれば
                    If Dir(strNowFileName) <> "" Then
                        Try
                            ' 変更ファイル名取得
                            strNewFileName = Me.mstrLogPath & Me.mstrLogFileName & "_" & intNowDateTime & LOG_EXTENSION
                            ' ファイル名更新
                            FileNameChange(strNowFileName, strNewFileName)
                        Catch ex As Exception
                        End Try
                    End If

                Catch
                End Try

                '------------------------------
                ' 古いログファイルの整理 
                '------------------------------
                Me.LogCleanRenameFile()

                '------------------------------
                ' コレクションから自ブジェクト破棄
                '------------------------------
                For iLoop = 1 To mLogInstns.Count
                    If CType(mLogInstns.Item(iLoop), clsLogWriter) Is Me Then
                        mLogInstns.Remove(iLoop)
                        Exit For
                    End If
                Next iLoop
            End If

        End If
    End Sub

#End Region

#Region "SetQueue"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' キューにデータを格納する
    ''' </summary>
    ''' <param name="MsgQueue">キューオブジェクトへの参照</param>
    ''' <param name="obj">キューに格納するデータ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetQueue(ByVal MsgQueue As Queue, ByVal obj As Object)
        SyncLock (MsgQueue)
            ' もらったメッセージをキューイング
            MsgQueue.Enqueue(obj)

            ' Lock開放通知
            Monitor.Pulse(MsgQueue)
        End SyncLock
    End Sub
#End Region

#Region "GetQueue"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' キューからデータを取り出す
    ''' </summary>
    ''' <param name="MsgQueue">キューオブジェクトへの参照</param>
    ''' <returns>キューから取り出したデータ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function GetQueue(ByVal MsgQueue As Queue) As Object
        Try
            SyncLock (MsgQueue)

                ' 終了フラグがOFFでキューに何も無ければ Wait する
                If Me.mblnEndFlg = False And MsgQueue.Count <= 0 Then
                    ' Wait
                    Monitor.Wait(MsgQueue)
                End If

                ' 終了フラグがONでキューに何も無ければ スレッド終了
                If Me.mblnEndFlg = True And MsgQueue.Count <= 0 Then
                    Thread.CurrentThread.Abort()
                End If

                ' Lock開放通知
                Monitor.Pulse(MsgQueue)

                ' キューの中身を返す
                Return MsgQueue.Dequeue

            End SyncLock

            Return MsgQueue.Dequeue

        Catch ex As ThreadAbortException
            ' スレッドの終了
            Throw ex
        Catch ex As Exception
            Try
                MsgQueue.Dequeue()
            Catch
            End Try
            Throw ex
        End Try

    End Function
#End Region

#Region "ログをファイルに出力する処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ログデータ構造体
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Structure LogDataTrace
        Friend DateTime As DateTime         ' 日時
        Friend strMessage As String            ' メッセージ
    End Structure
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ログをファイルに出力
    ''' </summary>
    ''' <param name="strMessage">メッセージ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub WriteTxtLog(ByVal strMessage As String)
        Dim intTraceLogData As LogDataTrace    ' ログデータ

        Try
            'Queueオブジェクトに追加するデータ作成
            With intTraceLogData
                .DateTime = Now             ' 現在日時
                .strMessage = strMessage          ' メッセージ
            End With

            ' Queueオブジェクトにログ内容追加
            Me.SetQueue(Me.MsgQueue, intTraceLogData)

        Catch ex As Exception
        End Try
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ログをファイルに出力(オーバーロード)
    ''' </summary>
    ''' <param name="strMessage">メッセージ</param>
    ''' <param name="txtObject"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub WriteTxtLog(ByVal strMessage As String, ByRef txtObject As TextBox)
        Dim intTraceLogData As LogDataTrace    ' ログデータ

        Try

            'Queueオブジェクトに追加するデータ作成
            With intTraceLogData
                .DateTime = Now             ' 現在日時
                .strMessage = strMessage          ' メッセージ
                txtObject.Text += Format(.DateTime, "yyyy/MM/dd HH:mm:ss[fff]") & " " & .strMessage & vbCrLf
            End With

            ' Queueオブジェクトにログ内容追加
            Me.SetQueue(Me.MsgQueue, intTraceLogData)

        Catch ex As Exception
        End Try
    End Sub
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ログ出力スレッド
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub WriteTxtLogThread()
        Dim intTraceLogData As LogDataTrace        ' 動作ログデータ
        Dim WriteMsg As StringBuilder           ' 書き込みメッセージ
        Dim strMsgTime As String                   ' タイムスタンプ
        Dim strWriteFile As String                 ' 書き込みファイル名

        While (True)
            Try
                ' キューからデータを取り出す
                intTraceLogData = CType(Me.GetQueue(Me.MsgQueue), LogDataTrace)

                ' 書き込みデータ作成
                WriteMsg = New StringBuilder
                With intTraceLogData
                    strMsgTime = Format(.DateTime, "yyyy/MM/dd HH:mm:ss[fff]")
                    WriteMsg.Append(strMsgTime & " " & .strMessage & vbCrLf)
                End With
                'Debug.WriteLine(strWriteMsg)

                ' フォルダがあれば
                If Directory.Exists(Me.mstrLogPath) Then

                    '----------------------------------
                    ' ファイル書き込み
                    '----------------------------------
                    strWriteFile = Me.mstrLogPath & Me.mstrLogFileName & LOG_EXTENSION
                    WriteFile_Normal(strWriteFile, WriteMsg)

                    '----------------------------------
                    ' ログファイルの圧縮処理
                    '----------------------------------
                    Me.Log_Pack_Check()
                End If
                WriteMsg = Nothing

            Catch ex As ThreadAbortException
                ' スレッドの終了
            Catch ex As Exception
            End Try
        End While
    End Sub
#End Region

#Region "ファイル書き込み処理"


    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ファイル書き込み
    ''' </summary>
    ''' <param name="strWriteFile">ログファイル名</param>
    ''' <param name="WriteMsg">書き込みメッセージ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub WriteFile_Normal(ByVal strWriteFile As String, _
                                 ByVal WriteMsg As StringBuilder)
        Dim fs As FileStream                    ' FileStreamオブジェクト
        Dim SwFromFileStream As StreamWriter    ' StreamWriterオブジェクト

        ' ファイル書き込み
        fs = New FileStream(strWriteFile, FileMode.Append, FileAccess.Write)
        Try
            SwFromFileStream = New StreamWriter(fs, System.Text.Encoding.Default)
            Try
                SwFromFileStream.Write(WriteMsg.ToString)
                SwFromFileStream.Flush()
            Finally
                SwFromFileStream.Close()
            End Try
        Finally
            fs.Close()
        End Try

    End Sub

#End Region

#Region "ログファイルの圧縮処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ログファイルの圧縮処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Log_Pack_Check()
        Dim strOldFileName As String        ' 旧ファイル名
        Dim strNewFileName As String        ' 変更ファイル名

        ' 旧ファイル名
        strOldFileName = Me.mstrLogPath & Me.mstrLogFileName & LOG_EXTENSION

        ' 旧ファイルがなければ処理終了
        If File.Exists(strOldFileName) = False Then Return

        ' Maxファイルサイズを超えたらファイルを換える
        If FileLen(strOldFileName) >= (Me.mintLogFileSize * (1024 ^ 2)) Then
            Try
                ' 圧縮後のファイル名取得
                strNewFileName = Me.mstrLogPath & Me.mstrLogFileName & "_" & Format(Now, Me.mstrLogDateFormat) & LOG_EXTENSION
                ' ファイル名更新
                FileNameChange(strOldFileName, strNewFileName)

                ' 古いログファイルの整理 
                Me.LogCleanRenameFile()
            Catch ex As Exception
                'Debug.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " [E] [Log_Pack_Check] Dsc:" & ex.Message)
            End Try
        End If

    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ファイル名更新
    ''' </summary>
    ''' <param name="strOldFileName">変更前ファイル名</param>
    ''' <param name="CheckFile">チェックファイル(変更後ファイル名)</param>
    ''' <remarks>同一ファイル名が存在するかどうかチェックし、存在すればファイル名をカウントアップする</remarks>
    ''' *******************************************************************************************************************
    Private Sub FileNameChange(ByVal strOldFileName As String, _
                               ByVal CheckFile As String)
        Dim strNonExtFileName As String     ' 拡張子なしファイル名
        Dim strNewFileName As String        ' 変更ファイル名
        Dim intSameFileCnt As Integer       ' 同一ファイル名件数

        ' 拡張子なしファイル名取得
        strNonExtFileName = Path.GetFileNameWithoutExtension(CheckFile)

        If File.Exists(CheckFile) = True Then
            '---------------------------------
            ' ファイルが存在すれば
            '---------------------------------
            ' 括弧なしファイルを「(1)」付きファイル名にする
            File.Move(CheckFile, Me.mstrLogPath & strNonExtFileName & "(1)" & LOG_EXTENSION)
            ' ファイル名の後ろに括弧でカウントアップした番号を付ける
            strNewFileName = Me.mstrLogPath & strNonExtFileName & "(2)" & LOG_EXTENSION

        ElseIf File.Exists(Me.mstrLogPath & strNonExtFileName & "(1)" & LOG_EXTENSION) = True Then
            '---------------------------------
            ' 括弧付きのファイルが存在すれば
            '---------------------------------
            intSameFileCnt = Directory.GetFiles(Me.mstrLogPath, strNonExtFileName & "(*)" & LOG_EXTENSION).Length + 1
            strNewFileName = Me.mstrLogPath & strNonExtFileName & "(" & intSameFileCnt.ToString & ")" & LOG_EXTENSION
        Else
            '---------------------------------
            ' ファイルが存在しなければ
            '---------------------------------
            strNewFileName = CheckFile
        End If

        ' ファイル名更新
        File.Move(strOldFileName, strNewFileName)

    End Sub

#End Region

#Region "古いログファイルの整理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 古いログファイルの整理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LogCleanRenameFile()
        Dim PreserveDtm As DateTime             ' 保持期間
        Dim strFileName As String                  ' 削除対象ファイル
        'Dim FileDate As DateTime                ' ファイル日時
        Dim strFileDate As String                  ' ファイル日時
        Dim intPointa As Integer

        Try
            ' ログフォルダの存在チェック
            If Directory.Exists(Me.mstrLogPath) = False Then Return

            '' ログフォルダのサイズチェック
            'If Me.GetFolderSize(Me.mstrLogPath) > (Me.LogDirMazSize * (1024 ^ 2)) Then

            '---------------------------------
            ' 保持期間以前のファイルを削除
            '---------------------------------
            PreserveDtm = DateAdd(DateInterval.Day, Me.mintLogDeleteDay * -1, Now)

            For Each strFileName In Directory.GetFiles(Me.mstrLogPath, "*" & LOG_EXTENSION)
                ''------------------------------
                '' 日時はタイムスタンプにて判断
                ''------------------------------
                '' ファイルのタイムスタンプを取得
                'strFileDate = File.GetLastWriteTime(strFileName)
                '' ログ保存期間を過ぎたファイル(分で比較)削除
                'If DateDiff(DateInterval.Minute, PreserveDtm, strFileDate) < 0 Then
                '    File.Delete(strFileName)
                'End If

                '------------------------------
                ' 日時はファイル名にて判断
                '------------------------------
                ' ファイル名称から更新日時を取得する()
                ' Renameされたログファイル[PreFix_YYYYMMDD.log] -> [YYYY/MM/DD]
                strFileName = Path.GetFileName(strFileName)
                intPointa = strFileName.IndexOf("_")
                If intPointa >= 0 Then
                    strFileDate = strFileName.Substring(intPointa + 1, 4) & "/" & _
                               strFileName.Substring(intPointa + 5, 2) & "/" & _
                               strFileName.Substring(intPointa + 7, 2) & " "
                    If IsDate(strFileDate) Then
                        ' ログ保存期間を過ぎたファイル(分で比較)
                        If DateDiff(DateInterval.Minute, PreserveDtm, CDate(strFileDate)) < 0 Then
                            File.Delete(Me.mstrLogPath & strFileName)
                        End If
                    End If
                End If
            Next
            'End If
        Catch ex As Exception
            'Debug.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " [E] [LogCleanRenameFile] Dsc:" & ex.Message)
        End Try
    End Sub
#End Region

#Region "フォルダのサイズ取得"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' フォルダのサイズ取得
    ''' </summary>
    ''' <param name="FolderName">フォルダ名(フルパス)</param>
    ''' <returns>フォルダのサイズ[Byte] (-1 = 内部エラー)</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function GetFolderSize(ByVal FolderName As String) As Long
        Dim objFs As Object
        Dim objFolder As Object
        Dim lngFolderSize As Long = 0      ' フォルダサイズ[Byte]

        Try
            ' フォルダのサイズ取得
            objFs = CreateObject("Scripting.FileSystemobject")
            objFolder = objFs.GetFolder(FolderName)
            lngFolderSize = objFolder.Size
        Catch ex As Exception
            lngFolderSize = -1
            'Debug.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " [E] [GetlngFolderSize] Dsc:" & ex.Message)
        Finally
            objFolder = Nothing
            objFs = Nothing
        End Try
        Return lngFolderSize
    End Function

#End Region

End Class
