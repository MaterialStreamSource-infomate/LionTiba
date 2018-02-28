'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
' 【機能】FTPｱｸｾｽｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region " imports "
Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Net.Sockets
#End Region

Public Class clsFTP

#Region " 変数宣言 "
    Private mobjSock As Sockets.Socket  'ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ


    Private mstrRemoteHost As String    'ｻｰﾊﾞｰ名(IP)
    Private mstrRemotePath As String    'ｽﾀｰﾄｱｯﾌﾟﾌｫﾙﾀﾞ
    Private mstrRemoteUser As String    'ﾕｰｻﾞｰ名
    Private mstrRemotePass As String    'ﾊﾟｽﾜｰﾄﾞ
 
    Private mblnLogIn As Boolean        'ﾛｸﾞｲﾝﾌﾗｸﾞ

    Private mobjException As Exception  'ｴｸｾﾌﾟｼｮﾝｸﾗｽ
    Private mintRemotePort As Int32     'ｻｰﾊﾞｰﾎﾟｰﾄ
    Private mobjClientSocket As Socket  'ｿｹｯﾄ
    Private ASCII As Encoding = Encoding.ASCII  'ｱｽｷｰｺｰﾄﾞ

    Private mintRetValue As Int32               '戻り値
    Private mstrReplyMessage As String          '受信ﾒｯｾｰｼﾞ
    Private mstrMessage As String               'ﾒｯｾｰｼﾞ
    Private mintBytes As Int32                  'ﾊﾞｲﾄ数

    Public Const BLOCK_SIZE = 512               'ﾌﾞﾛｯｸｻｲｽﾞ
    Private mbytBuffer(BLOCK_SIZE) As Byte      '書き込みﾊﾞｯﾌｧ
    Public blnFlag As Boolean                   'ﾌﾗｸﾞ

#End Region

#Region " ﾌﾟﾛﾊﾟﾃｨ "
    ''' =======================================
    ''' <summary>Exception ﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property Exception() As Exception
        Get
            Return mobjException
        End Get
        Set(ByVal Value As Exception)
            mobjException = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>RemoteHostFTPServer ﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property RemoteHostFTPServer() As String
        Get
            Return mstrRemoteHost
        End Get
        Set(ByVal Value As String)
            mstrRemoteHost = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>RemotePort ﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property RemotePort() As Int32
        Get
            Return mintRemotePort
        End Get
        Set(ByVal Value As Int32)
            mintRemotePort = Value

        End Set
    End Property

    ''' =======================================
    ''' <summary>RemotePath ﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property RemotePath() As String
        Get
            Return mstrRemotePath
        End Get
        Set(ByVal Value As String)
            mstrRemotePath = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>RemotePassword ﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property RemotePassword() As String
        Get
            Return mstrRemotePass
        End Get
        Set(ByVal Value As String)
            mstrRemotePass = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>RemoteUser ﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property RemoteUser() As String
        Get
            Return mstrRemoteUser
        End Get
        Set(ByVal Value As String)
            mstrRemoteUser = Value
        End Set
    End Property

#End Region

#Region " New "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="strRemoteHost"></param>
    ''' <param name="strRemotePath"></param>
    ''' <param name="strRemoteUser"></param>
    ''' <param name="strRemotePass"></param>
    ''' <param name="intRemotePort"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal strRemoteHost As String _
                , ByVal strRemotePath As String _
                , ByVal strRemoteUser As String _
                , ByVal strRemotePass As String _
                , ByVal intRemotePort As Int32)

        'ｺﾋﾟｰ
        mstrRemoteHost = strRemoteHost
        mstrRemotePath = strRemotePath
        mstrRemoteUser = strRemoteUser
        mstrRemotePass = strRemotePass
        mintRemotePort = intRemotePort
        mblnLogIn = False
    End Sub
#End Region

#Region " Finalize "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｧｲﾅﾗｲｽ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region " strGetFilelist "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPのﾌｧｲﾙ一覧取得
    ''' </summary>
    ''' <param name="strMask">ﾏｽｸ(NLST時に使用)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function strGetFilelist(ByVal strMask As String) As String()
        Dim objSocket As Socket
        Dim intbytes As Int32
        Dim chrSeperator As Char = ControlChars.Lf
        Dim strMess() As String

        'ﾛｸﾞｲﾝしていない場合は、再度ﾛｸﾞｲﾝする
        If (Not (mblnLogIn)) Then
            blnLogin()
        End If

        objSocket = CreateDataSocket()
        'Send an FTP command, 
        SendCommand("NLST " & strMask)

        If (Not (mintRetValue = 150 Or mintRetValue = 125)) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

        mstrMessage = ""
        Do While (True)
            Array.Clear(mbytBuffer, 0, mbytBuffer.Length)
            intbytes = objSocket.Receive(mbytBuffer, mbytBuffer.Length, 0)
            mstrMessage += ASCII.GetString(mbytBuffer, 0, intbytes)

            If (intbytes < mbytBuffer.Length) Then
                Exit Do
            End If
        Loop

        strMess = mstrMessage.Split(chrSeperator)
        objSocket.Close()
        ReadReply()

        If (mintRetValue <> 226) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

        Return strMess
    End Function
#End Region

#Region " lngGetFileSize "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPのﾌｧｲﾙｻｲｽﾞ取得
    ''' </summary>
    ''' <param name="strFileName">ﾌｧｲﾙ名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function lngGetFileSize(ByVal strFileName As String) As Long
        Dim lngsize As Long

        If (Not (mblnLogIn)) Then
            blnLogin()
        End If
        'Send an FTP command. 
        SendCommand("SIZE " & strFileName)
        lngsize = 0

        If (mintRetValue = 213) Then
            lngsize = Int64.Parse(mstrReplyMessage.Substring(4))
        Else
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

        Return lngsize
    End Function
#End Region

#Region " blnLogin "

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPLogIn
    ''' </summary>
    ''' <returns>True or False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function blnLogin() As Boolean

        Dim objIPAddress As IPAddress
        mobjClientSocket = _
        New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        objIPAddress = IPAddress.Parse(mstrRemoteHost)
        Dim ep As New IPEndPoint(objIPAddress, mintRemotePort)

        Try
            mobjClientSocket.Connect(ep)
        Catch ex As Exception
            mstrMessage = mstrReplyMessage
            Throw New IOException("Cannot connect to the remote server")
        End Try

        'ｺﾈｸﾄが成功したか？
        ReadReply()
        If (mintRetValue <> 220) Then
            CloseConnection()
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

        'ﾛｸﾞｲﾝﾕｰｻﾞｰ
        SendCommand("USER " & mstrRemoteUser)
        If (Not (mintRetValue = 331 Or mintRetValue = 230)) Then
            Cleanup()
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

        If (mintRetValue <> 230) Then
            'ﾊﾟｽﾜｰﾄﾞ
            SendCommand("PASS " & mstrRemotePass)
            If (Not (mintRetValue = 230 Or mintRetValue = 202)) Then
                Cleanup()
                mstrMessage = mstrReplyMessage
                Throw New IOException(mstrReplyMessage.Substring(4))
            End If
        End If

        mblnLogIn = True
        '引数で渡されたﾊﾟｽをﾃﾞﾌｫﾙﾄとする。
        ChangeDirectory(mstrRemotePath)

        Return mblnLogIn
    End Function
#End Region

#Region " SetBinaryMode "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｲﾅﾘﾓｰﾄﾞ変更処理
    ''' </summary>
    ''' <param name="blnMode">bMode:True=ﾊﾞｲﾅﾘﾓｰﾄﾞ,False=ｱｽｷｰﾓｰﾄﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SetBinaryMode(ByVal blnMode As Boolean)

        If (blnMode) Then
            'binary modeを送信
            SendCommand("TYPE I")
        Else
            'ASCII modeを送信
            SendCommand("TYPE A")
        End If

        If (mintRetValue <> 200) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If
    End Sub
#End Region

#Region " DownLoadFile "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾀﾞｳﾝﾛｰﾄﾞ機能
    ''' </summary>
    ''' <param name="strFileName">ﾌｧｲﾙ名</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub DownloadFile(ByVal strFileName As String)
        DownloadFile(strFileName, "", False)
    End Sub
#End Region

#Region " DownloadFile "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾀﾞｳﾝﾛｰﾄﾞ機能
    ''' </summary>
    ''' <param name="strFileName">ﾌｧｲﾙ名</param>
    ''' <param name="blnResume">ﾚｼﾞｭｰﾑﾌﾗｸﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub DownloadFile(ByVal strFileName As String, _
                            ByVal blnResume As Boolean)
        DownloadFile(strFileName, "", blnResume)
    End Sub
#End Region

#Region " DownloadFile "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾀﾞｳﾝﾛｰﾄﾞ機能
    ''' </summary>
    ''' <param name="strFileName">ﾌｧｲﾙ名</param>
    ''' <param name="strLocalFileName">ﾀﾞｳﾝﾛｰﾄﾞﾊﾟｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub DownloadFile(ByVal strFileName As String, _
                            ByVal strLocalFileName As String)
        DownloadFile(strFileName, strLocalFileName, False)
    End Sub
#End Region

#Region " DownloadFile "

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾀﾞｳﾝﾛｰﾄﾞ機能
    ''' </summary>
    ''' <param name="strFileName">ﾌｧｲﾙ名</param>
    ''' <param name="strLocalFileName">ﾀﾞｳﾝﾛｰﾄﾞﾊﾟｽ</param>
    ''' <param name="blnResume">ﾚｼﾞｭｰﾑ機能(ﾘｽﾀｰﾄ)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub DownloadFile(ByVal strFileName As String, _
                            ByVal strLocalFileName As String, _
                            ByVal blnResume As Boolean)
        Dim objSt As Stream
        Dim objOutput As FileStream
        Dim objSocket As Socket
        Dim lngOffset, lngPos As Long

        If (Not (mblnLogIn)) Then
            blnLogin()
        End If

        SetBinaryMode(True)

        If (strLocalFileName.Equals("")) Then
            strLocalFileName = strFileName
        End If

        If (Not (File.Exists(strLocalFileName))) Then
            objSt = File.Create(strLocalFileName)
            objSt.Close()
        End If

        objOutput = New FileStream(strLocalFileName, FileMode.Open)
        objSocket = CreateDataSocket()
        lngOffset = 0

        'ﾚｼﾞｭｰﾑ機能は、とりあえず実装するが
        'FTPｻｰﾊﾞｰが実装しているか不明なので
        '使わないようにしたほうが無難
        If (blnResume) Then
            lngOffset = objOutput.Length

            If (lngOffset > 0) Then
                'Send an FTP command to restart.
                SendCommand("REST " & lngOffset)
                If (mintRetValue <> 350) Then
                    lngOffset = 0
                End If
            End If

            If (lngOffset > 0) Then
                lngPos = objOutput.Seek(lngOffset, SeekOrigin.Begin)
            End If
        End If
        '取得ｺﾏﾝﾄﾞ送信
        SendCommand("RETR " & strFileName)

        If (Not (mintRetValue = 150 Or mintRetValue = 125)) Then
            objOutput.Close()
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

        Do While (True)
            Array.Clear(mbytBuffer, 0, mbytBuffer.Length)
            mintBytes = objSocket.Receive(mbytBuffer, mbytBuffer.Length, 0)
            objOutput.Write(mbytBuffer, 0, mintBytes)

            If (mintBytes <= 0) Then
                Exit Do
            End If
        Loop

        objOutput.Close()
        If (objSocket.Connected) Then
            objSocket.Close()
        End If

        ReadReply()
        If (Not (mintRetValue = 226 Or mintRetValue = 250)) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

    End Sub
#End Region

#Region " UploadFile "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPｱｯﾌﾟﾛｰﾄﾞ機能
    ''' </summary>
    ''' <param name="strFileName">ﾌｧｲﾙ名</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UploadFile(ByVal strFileName As String)
        UploadFile(strFileName, False)
    End Sub
#End Region

#Region " UploadFile "

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPｱｯﾌﾟﾛｰﾄﾞ機能
    ''' </summary>
    ''' <param name="strFileName">ﾌｧｲﾙ名</param>
    ''' <param name="blnResume">ﾚｼﾞｭｰﾑ機能(ﾘｽﾀｰﾄ)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UploadFile(ByVal strFileName As String, _
                          ByVal blnResume As Boolean)
        Dim objSocket As Socket
        Dim lngOffset As Long
        Dim objInput As FileStream
        Dim blnFileNotFound As Boolean

        If (Not (mblnLogIn)) Then
            blnLogin()
        End If

        objSocket = CreateDataSocket()
        lngOffset = 0

        'ﾚｼﾞｭｰﾑ機能は、とりあえず実装するが
        'FTPｻｰﾊﾞｰが実装しているか不明なので
        '使わないようにしたほうが無難
        If (blnResume) Then
            Try
                SetBinaryMode(True)
                lngOffset = lngGetFileSize(strFileName)
            Catch ex As Exception
                lngOffset = 0
            End Try
        End If

        If (lngOffset > 0) Then
            SendCommand("REST " & lngOffset)
            If (mintRetValue <> 350) Then
                lngOffset = 0
            End If
        End If

        'ﾌｧｲﾙ作成(既にある場合は、上書きする。)
        SendCommand("STOR " & Path.GetFileName(strFileName))
        If (Not (mintRetValue = 125 Or mintRetValue = 150)) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

        'ﾌｧｲﾙが存在するかﾁｪｯｸ.
        blnFileNotFound = False
        If (File.Exists(strFileName)) Then
            ' 存在した場合、ﾌｧｲﾙｵｰﾌﾟﾝ
            objInput = New FileStream(strFileName, FileMode.Open)
            If (lngOffset <> 0) Then
                objInput.Seek(lngOffset, SeekOrigin.Begin)
            End If

            'ﾌｧｲﾙの中身を更新
            mintBytes = objInput.Read(mbytBuffer, 0, mbytBuffer.Length)
            Do While (mintBytes > 0)
                objSocket.Send(mbytBuffer, mintBytes, 0)
                mintBytes = objInput.Read(mbytBuffer, 0, mbytBuffer.Length)
            Loop
            objInput.Close()
        Else
            blnFileNotFound = True
        End If

        If (objSocket.Connected) Then
            objSocket.Close()
        End If

        'ﾌｧｲﾙが見つからない場合は、ｴﾗｰ
        If (blnFileNotFound) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException("ﾌｧｲﾙが見つかりません。ﾌｧｲﾙ名: " & strFileName & _
           "FTPｻｰﾊﾞｰへUploadができませんでした。")
        End If

        ReadReply()
        If (Not (mintRetValue = 226 Or mintRetValue = 250)) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If
    End Sub
#End Region

#Region " DeleteFile "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTP削除機能
    ''' </summary>
    ''' <param name="strFileName">ﾌｧｲﾙ名</param>
    ''' <returns>True or False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function DeleteFile(ByVal strFileName As String) As Boolean
        Dim blnResult As Boolean

        blnResult = True
        If (Not (mblnLogIn)) Then
            blnLogin()
        End If
        '削除ｺﾏﾝﾄﾞ送信
        SendCommand("DELE " & strFileName)
        If (mintRetValue <> 250) Then
            blnResult = False
            mstrMessage = mintRetValue
        End If

        ' 結果を返す。
        Return blnResult
    End Function
#End Region

#Region " RenameFile "

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾌｧｲﾙ名変更機能
    ''' </summary>
    ''' <param name="strOldFileName">ﾌｧｲﾙ名</param>
    ''' <param name="strNewFileName">ﾌｧｲﾙ名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function RenameFile(ByVal strOldFileName As String, _
                               ByVal strNewFileName As String) As Boolean
        Dim blnResult As Boolean

        blnResult = True
        If (Not (mblnLogIn)) Then
            blnLogin()
        End If

        '変更ﾌｧｲﾙｺﾏﾝﾄﾞ送信(変更されるﾌｧｲﾙ名を指定)
        SendCommand("RNFR " & strOldFileName)
        If (mintRetValue <> 350) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

        '新しいﾌｧｲﾙ名を指定する
        'ﾌｧｲﾙ名が存在する場合は、上書き
        SendCommand("RNTO " & strNewFileName)
        If (mintRetValue <> 250) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If
        '結果を返す。
        Return blnResult
    End Function
#End Region

#Region " CreateDirectory "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾃﾞｨﾚｸﾄﾘ生成機能
    ''' </summary>
    ''' <param name="strDirName">ﾃﾞｨﾚｸﾄﾘ名</param>
    ''' <returns>True or False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function CreateDirectory(ByVal strDirName As String) As Boolean
        Dim blnResult As Boolean

        blnResult = True
        If (Not (mblnLogIn)) Then
            blnLogin()
        End If
        'ﾃﾞｨﾚｸﾄﾘ生成ｺﾏﾝﾄﾞ送信
        SendCommand("MKD " & strDirName)
        If (mintRetValue <> 257) Then
            blnResult = False
            mstrMessage = mstrReplyMessage
        End If

        ' 結果を返す。
        Return blnResult
    End Function
#End Region

#Region " RemoveDirectory "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾃﾞｨﾚｸﾄﾘ削除機能
    ''' </summary>
    ''' <param name="strDirName">ﾃﾞｨﾚｸﾄﾘ名</param>
    ''' <returns>True or False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function RemoveDirectory(ByVal strDirName As String) As Boolean
        Dim blnResult As Boolean

        blnResult = True
        If (Not (mblnLogIn)) Then
            blnLogin()
        End If

        'ﾃﾞｨﾚｸﾄﾘ削除ｺﾏﾝﾄﾞ送信
        SendCommand("RMD " & strDirName)
        If (mintRetValue <> 250) Then
            blnResult = False
            mstrMessage = mstrReplyMessage
        End If

        ' 結果を返す
        Return blnResult
    End Function
#End Region

#Region " ChangeDirectory "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾃﾞｨﾚｸﾄﾘ変更機能
    ''' </summary>
    ''' <param name="strDirName">ﾃﾞｨﾚｸﾄﾘ名</param>
    ''' <returns>True or False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ChangeDirectory(ByVal strDirName As String) As Boolean
        Dim blnResult As Boolean

        blnResult = True
        'ﾙｰﾄﾃﾞｨﾚｸﾄﾘ→ﾙｰﾄﾃﾞｨﾚｸﾄﾘの変更はなにもしない。
        If (strDirName.Equals(".")) Then
            Exit Function
        End If

        If (Not (mblnLogIn)) Then
            blnLogin()
        End If

        'ﾃﾞｨﾚｸﾄﾘ変更ｺﾏﾝﾄﾞ送信
        SendCommand("CWD " & strDirName)
        If (mintRetValue <> 250) Then
            blnResult = False
            mstrMessage = mstrReplyMessage
        End If

        'Path変更
        Me.mstrRemotePath = strDirName

        ' 結果を返す
        Return blnResult
    End Function
#End Region

#Region " CloseConnection "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾛｸﾞｱｳﾄ機能
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CloseConnection()
        If (Not (mobjClientSocket Is Nothing)) Then
            'QUITｺﾏﾝﾄﾞ送信
            SendCommand("QUIT")
        End If

        Cleanup()
    End Sub
#End Region

#Region " ReadReply "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 返信ﾒｯｾｰｼﾞの読み込み
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ReadReply()
        mstrMessage = ""
        mstrReplyMessage = ReadLine()
        mintRetValue = Int32.Parse(mstrReplyMessage.Substring(0, 3))
    End Sub
#End Region

#Region " Cleanup "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄｸﾘｰﾝｱｯﾌﾟ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Cleanup()
        If Not (mobjClientSocket Is Nothing) Then
            mobjClientSocket.Close()
            mobjClientSocket = Nothing
        End If

        mblnLogIn = False
    End Sub
#End Region

#Region " ReadLine "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPﾒｯｾｰｼﾞ読み込み
    ''' </summary>
    ''' <param name="blnClearMes">ﾒｯｾｰｼﾞｸﾘｱﾌﾗｸﾞ</param>
    ''' <returns>FTPﾒｯｾｰｼﾞ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function ReadLine(Optional ByVal blnClearMes As Boolean = False) As String
        Dim strSeperator As Char = ControlChars.Lf
        Dim strMess() As String

        If (blnClearMes) Then
            mstrMessage = ""
        End If
        Do While (True)
            Array.Clear(mbytBuffer, 0, BLOCK_SIZE)
            mintBytes = mobjClientSocket.Receive(mbytBuffer, mbytBuffer.Length, 0)
            mstrMessage += ASCII.GetString(mbytBuffer, 0, mintBytes)
            If (mintBytes < mbytBuffer.Length) Then
                Exit Do
            End If
        Loop

        strMess = mstrMessage.Split(strSeperator)
        If (mstrMessage.Length > 2) Then
            mstrMessage = strMess(strMess.Length - 2)
        Else
            mstrMessage = strMess(0)
        End If

        If (Not (mstrMessage.Substring(3, 1).Equals(" "))) Then
            Return ReadLine(True)
        End If

        Return mstrMessage
    End Function
#End Region

#Region " SendCommand"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' FTPｺﾏﾝﾄﾞ送信
    ''' </summary>
    ''' <param name="strCommand">ｺﾏﾝﾄﾞ</param>
    ''' <remarks>FTPﾒｯｾｰｼﾞ</remarks>
    ''' *******************************************************************************************************************
    Private Sub SendCommand(ByVal strCommand As String)
        strCommand = strCommand & ControlChars.CrLf
        Dim cmdbytes As Byte() = ASCII.GetBytes(strCommand)
        mobjClientSocket.Send(cmdbytes, cmdbytes.Length, 0)
        ReadReply()
    End Sub
#End Region

#Region " CreatedataSocket "

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ受信ｿｹｯﾄ生成
    ''' </summary>
    ''' <returns>ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function CreateDataSocket() As Socket
        Dim intIndex1, intIndex2, intLen As Int32
        Dim intPartCount, i, port As Int32
        Dim ipData, buf, ipAddress As String
        Dim parts(6) As Int32
        Dim ch As Char
        Dim s As Socket
        Dim ep As IPEndPoint

        'Passiveﾓｰﾄﾞにする。
        SendCommand("PASV")
        If (mintRetValue <> 227) Then
            mstrMessage = mstrReplyMessage
            Throw New IOException(mstrReplyMessage.Substring(4))
        End If

        intIndex1 = mstrReplyMessage.IndexOf("(")
        intIndex2 = mstrReplyMessage.IndexOf(")")
        ipData = mstrReplyMessage.Substring(intIndex1 + 1, intIndex2 - intIndex1 - 1)

        intLen = ipData.Length
        intPartCount = 0
        buf = ""

        For i = 0 To ((intLen - 1) And intPartCount <= 6)
            ch = Char.Parse(ipData.Substring(i, 1))
            If (Char.IsDigit(ch)) Then
                buf += ch
            ElseIf (ch <> ",") Then
                mstrMessage = mstrReplyMessage
                Throw New IOException("送信ｺﾏﾝﾄﾞ(PASV)のReplyが異常です。: " & mstrReplyMessage)
            End If

            If ((ch = ",") Or (i + 1 = intLen)) Then
                Try
                    parts(intPartCount) = Int32.Parse(buf)
                    intPartCount += 1
                    buf = ""
                Catch ex As Exception
                    mstrMessage = mstrReplyMessage
                    Throw New IOException("送信ｺﾏﾝﾄﾞ(PASV)のReplyが異常です。: " & mstrReplyMessage)
                End Try
            End If
        Next

        'IPADDRESSの取得
        ipAddress = parts(0) & "." & parts(1) & "." & parts(2) & "." & parts(3)

        'port番号の取得
        port = CInt(parts(4) * 256) + CInt(parts(5))

        Dim objIPAddress As IPAddress
        objIPAddress = Net.IPAddress.Parse(ipAddress)

        s = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        ep = New IPEndPoint(objIPAddress, port)
        Try
            'ｻｰﾊﾞｰからもらったIP、Portで接続
            s.Connect(ep)
        Catch ex As Exception
            mstrMessage = mstrReplyMessage
            Throw New IOException("FTPｻｰﾊﾞｰへ接続できませんでした。")
            blnFlag = False
        End Try

        blnFlag = True
        Return s
    End Function
#End Region

End Class
