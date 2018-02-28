'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｻｰﾊﾞｰへｿｹｯﾄ送信ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Imports MateCommon.clsConst

Public Class clsSocketToServer

#Region "  共通変数         "

    'ﾌﾟﾛﾊﾟﾃｨ変数
    Private mobjOwner As Object                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mstrTermID As String                '端末ID
    Private mstrEmpCD As String                 'ﾕｰｻﾞｰID
    Private mstrAddress As String               '送信先ｱﾄﾞﾚｽ
    Private mintPortNo As Integer               'ﾎﾟｰﾄNo
    Private mintTimeout As Integer              'ﾀｲﾑｱｳﾄ
    Private mstrTelFilePath As String           '読み込む定義ﾌｧｲﾙのﾊﾟｽ

#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' =======================================
    ''' <summary>ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property objOwner() As Object
        Get
            Return mobjOwner
        End Get
        Set(ByVal Value As Object)
            mobjOwner = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>端末ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strTermID() As String
        Get
            Return mstrTermID
        End Get
        Set(ByVal Value As String)
            mstrTermID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾕｰｻﾞｰID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strEmpCD() As String
        Get
            Return mstrEmpCD
        End Get
        Set(ByVal Value As String)
            mstrEmpCD = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>送信先ｱﾄﾞﾚｽ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strAddress() As String
        Get
            Return mstrAddress
        End Get
        Set(ByVal Value As String)
            mstrAddress = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾎﾟｰﾄNo</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intPortNo() As Integer
        Get
            Return mintPortNo
        End Get
        Set(ByVal Value As Integer)
            mintPortNo = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾀｲﾑｱｳﾄ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intTimeout() As Integer
        Get
            Return mintTimeout
        End Get
        Set(ByVal Value As Integer)
            mintTimeout = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>読み込む定義ﾌｧｲﾙのﾊﾟｽ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strTelFilePath() As String
        Get
            Return mstrTelFilePath
        End Get
        Set(ByVal Value As String)
            mstrTelFilePath = Value
        End Set
    End Property
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object)
        Try

            '***************************************
            ' 色々初期化
            '***************************************
            mobjOwner = objOwner                                'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region

#Region "  ｻｰﾊﾞｰへｿｹｯﾄ送信      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｻｰﾊﾞｰへｿｹｯﾄ送信
    ''' </summary>
    ''' <param name="objTelegramSend">電文作成ｸﾗｽ</param>
    ''' <param name="strRET_STATE">ｻｰﾊﾞから受信した応答ｽﾃｰﾀｽ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA_SYUBETU">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ種別(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <returns>ｿｹｯﾄ送信、正常応答 or 異常応答</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SockSendServer(ByRef objTelegramSend As clsTelegram, _
                                   Optional ByRef strRET_STATE As String = "", _
                                   Optional ByRef strRET_DATA_SYUBETU As String = "", _
                                   Optional ByRef strRET_DATA As String = "" _
                                   ) _
                                   As clsSocketClient.RetCode
        Dim dtmNow As Date = Now
        Dim objSocketSend As New clsSocketClientGamen(mobjOwner)

        '***************************************************
        ' 電文作成
        '***************************************************
        'ﾍｯﾀﾞｰ部分ｾｯﾄ
        objTelegramSend.SETIN_HEADER("DSPCMD_ID", Right(objTelegramSend.FORMAT_ID, 6))  'ｺﾏﾝﾄﾞID
        objTelegramSend.SETIN_HEADER("DSPTERM_ID", mstrTermID)                          '端末ID
        objTelegramSend.SETIN_HEADER("DSPUSER_ID", mstrEmpCD)                            'ﾕｰｻﾞｰID
        objTelegramSend.MAKE_TELEGRAM()                                                 '電文作成


        '***************************************************
        ' ｿｹｯﾄ送信
        '***************************************************
        objSocketSend.strAddress = mstrAddress                          '送信先ｱﾄﾞﾚｽ
        objSocketSend.intPortNo = mintPortNo                            'ﾎﾟｰﾄNo
        objSocketSend.intTimeOut = mintTimeout                          'ﾀｲﾑｱｳﾄ
        objSocketSend.strSendText = objTelegramSend.TELEGRAM_MAKED      '送信ﾃｷｽﾄ
        If mintTimeout = 0 Then
            objSocketSend.blnReceiveFlag = False                        '応答ｿｹｯﾄ待機
        Else
            objSocketSend.blnReceiveFlag = True                         '応答ｿｹｯﾄ待機
        End If
        objSocketSend.SendSock()                                        'ｿｹｯﾄ送信


        '***************************************************
        ' ｿｹｯﾄ送信正常終了ﾁｪｯｸ
        '***************************************************
        Select Case objSocketSend.udtRet
            Case clsSocketClient.RetCode.NG
                Call Me.AddToLog(FRM_MSG_SOCKSENDSERVER_01)

            Case clsSocketClient.RetCode.ReceiveTimeOut
                Call Me.AddToLog(FRM_MSG_SOCKSENDSERVER_02)

            Case clsSocketClient.RetCode.ConnectError
                Call Me.AddToLog(FRM_MSG_SOCKSENDSERVER_03)

        End Select


        '***************************************************
        ' 受信ｿｹｯﾄ解析
        '***************************************************
        If objSocketSend.blnReceiveFlag = True Then
            '(応答ｿｹｯﾄを受信する場合)

            Dim objTelegramRecv As New clsTelegram(mstrTelFilePath)
            Dim strRET_MESSAGE_EXIST As String          '応答ﾒｯｾｰｼﾞ有無
            Dim strRET_MESSAGE As String                '応答ﾒｯｾｰｼﾞ

            objTelegramRecv.FORMAT_ID = FORMAT_DSP_RETURN                       'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            objTelegramRecv.TELEGRAM_PARTITION = objSocketSend.strRecvText      '分割する電文ｾｯﾄ
            objTelegramRecv.PARTITION()                                         '電文分割
            strRET_STATE = objTelegramRecv.SELECT_DATA("DSPRET_STATE")                     '応答ｽﾃｰﾀｽ
            strRET_MESSAGE_EXIST = objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE_EXIST")     '応答ﾒｯｾｰｼﾞ有無
            strRET_MESSAGE = Trim(objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE"))           '応答ﾒｯｾｰｼﾞ
            strRET_DATA_SYUBETU = objTelegramRecv.SELECT_DATA("DSPRET_DATA_SYUBETU")       '応答ﾃﾞｰﾀ種別
            strRET_DATA = objTelegramRecv.SELECT_DATA("DSPRET_DATA")                       '応答ﾃﾞｰﾀ

            '---------------------------------
            '応答ｺｰﾄﾞ表示
            '---------------------------------
            If objSocketSend.udtRet = clsSocketClient.RetCode.OK Then
                '(正常の場合)
                If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                    '(応答ｺｰﾄﾞ正常の場合)
                    Me.AddToLog("ｿｹｯﾄ送信は正常に行われました。")
                Else
                    '(応答ｺｰﾄﾞ異常の場合)
                    Me.AddToLog("ｿｹｯﾄ送信は正常に行われましたが、応答ｺｰﾄﾞが正常ではありません。[応答ｺｰﾄﾞ:" & strRET_STATE & "]")
                End If
            Else
                '(異常の場合)
                Me.AddToLog("ｿｹｯﾄ送信は失敗しました。")
            End If

            '---------------------------------
            'ﾒｯｾｰｼﾞ表示
            '---------------------------------
            If Trim(strRET_MESSAGE_EXIST) = ID_RETURN_RET_MESSAGE_EXIST_YES Then
                Call Me.AddToLog("ｻｰﾊﾞｰから応答ﾒｯｾｰｼﾞを受信しました。[" & strRET_MESSAGE & "]")
            End If

            '---------------------------------
            '応答ﾃﾞｰﾀ表示
            '---------------------------------
            If Trim(strRET_DATA_SYUBETU) = ID_RETURN_RET_DATA_SYUBETU _
               And Trim(strRET_DATA) = ID_RETURN_RET_DATA Then
                '(応答ﾃﾞｰﾀ種別,応答ﾃﾞｰﾀなしの場合)
                'NOP
            Else
                '(応答ﾃﾞｰﾀ種別,応答ﾃﾞｰﾀありの場合)
                Me.AddToLog("[応答ﾃﾞｰﾀ種別:" & strRET_DATA_SYUBETU & "]    応答ﾃﾞｰﾀ[" & strRET_DATA & "]")
            End If

        End If


        Return (objSocketSend.udtRet)
    End Function
#End Region

#Region "  ﾛｸﾞ書き込み処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
