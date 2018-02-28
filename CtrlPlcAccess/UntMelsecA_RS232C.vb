'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ MelsecA(RS232C接続) ｸﾗｽ
' 【作成】2014/10/31　SBY/S.Ouchi　      Rev 0.00　初版
' 【備考】Melsec Qｼﾘｰｽﾞのﾌﾟﾛﾄｺﾙに対応
' 　　　　3C/4Cﾌﾚｰﾑの形式4
'**********************************************************************************************

#Region "imports"

#End Region

Public Class UntMelsecA_RS232C
    Inherits UntBase

#Region "内部定数"

    '==================================================
    '   内部定数
    '==================================================
    Private Const CM As String = ","            '区切り文字
    Private Const OK As String = "OK"           'OK
    Private Const ER As String = "ER"           'ER
    Private Const FLM As String = "F9"          '識別番号&ﾌﾚｰﾑ
    Private Const BRD As String = "0401"        'ﾋﾞｯﾄ単位読込ｺﾏﾝﾄﾞ
    Private Const BRDS As String = "0001"       'ﾋﾞｯﾄ単位読込ｻﾌﾞｺﾏﾝﾄﾞ
    Private Const BWR As String = "1401"        'ﾋﾞｯﾄ単位書込ｺﾏﾝﾄﾞ
    Private Const BWRS As String = "0001"       'ﾋﾞｯﾄ単位書込ｻﾌﾞｺﾏﾝﾄﾞ
    Private Const WRD As String = "0401"        'ﾜｰﾄﾞ単位読込ｺﾏﾝﾄﾞ
    Private Const WRDS As String = "0000"       'ﾜｰﾄﾞ単位読込ｻﾌﾞｺﾏﾝﾄﾞ
    Private Const WWR As String = "1401"        'ﾜｰﾄﾞ単位書込ｺﾏﾝﾄﾞ
    Private Const WWRS As String = "0000"       'ﾜｰﾄﾞ単位書込ｻﾌﾞｺﾏﾝﾄﾞ
    Private Const DEVICE_D As String = "D*"     'ﾃﾞﾊﾞｲｽｺｰﾄﾞ(Dﾚｼﾞｽﾀ)
    Private CR As String = Chr(&HD).ToString    '改行コード CR
    Private LF As String = Chr(&HA).ToString    '改行コード LF

#End Region

#Region "内部変数"
    '==================================================
    '   内部変数
    '==================================================
    Private mobjDrv As DrvSerial                '接続ｸﾗｽｵﾌﾞｼﾞｪｸﾄ(RS232C通信用)
    Private mstrSend As String                  '送信テキスト
    Private mstrRecv As String                  '受信テキスト

    Private mintTimeOut As Integer              'ﾘﾄﾗｲﾀｲﾑｱｳﾄ時間(秒)  
    Private mintRetry As Integer                'ﾘﾄﾗｲ回数
    Private mstrWait As String                  '伝文ｳｪｲﾄ

    'その他
    Private mintDebugFlag As Integer                'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
#End Region


#Region "プロパティ"
    '==================================================
    '   Property    TimeOut
    '==================================================
    Public Property TimeOut( _
    ) As Integer
        Get
            Return mintTimeOut
        End Get
        Set(ByVal Value As Integer)
            mintTimeOut = Value
        End Set
    End Property

    '==================================================
    '   Property    Retry
    '==================================================
    Public Property Retry( _
    ) As Integer
        Get
            Return mintRetry
        End Get
        Set(ByVal Value As Integer)
            mintRetry = Value
        End Set
    End Property

    '==================================================
    '   Property    Wait
    '==================================================
    Public Property Wait( _
    ) As String
        Get
            Return mstrWait
        End Get
        Set(ByVal Value As String)
            mstrWait = Value
        End Set
    End Property

    '==================================================
    '   Property    Wait
    '==================================================
    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
        End Set
    End Property
#End Region

#Region "初期/終了 処理"

#Region "ｺﾝｽﾄﾗｸﾀ"
    '**********************************************************************************************
    '【機能】ｺﾝｽﾄﾗｸﾀ
    '【引数】接続ﾓｼﾞｭｰﾙ :	DrvRS232C	    objDrvRS232C
    '**********************************************************************************************
    Public Sub New(ByVal objDrvSerial As DrvSerial)
        MyBase.New(objDrvSerial)

        Try
            '接続ﾓｼﾞｭｰﾙｾｯﾄ
            mobjDrv = objDrvSerial

            mobjDrv.SEND_ENQ = True
            mobjDrv.SEND_STX = False
            mobjDrv.SEND_ETX = False
            mobjDrv.SEND_CR = True
            mobjDrv.SEND_LF = True

            mobjDrv.CHECK_SUM_POSITION = DrvSerial.CheckSumPosition.AfterETX

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

#Region "ﾃﾞｽﾄﾗｸﾀ"
    '**********************************************************************************************
    '【機能】ﾃﾞｽﾄﾗｸﾀ
    '**********************************************************************************************
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#End Region


#Region "ﾋﾞｯﾄ単位読込/書込要求ｺﾏﾝﾄﾞ送信 関数"

#Region "ﾋﾞｯﾄ単位読込"
    '**********************************************************************************************
    '【機能】ﾋﾞｯﾄ単位読込要求送信
    '【引数】局番号     :   String  strKyokuNo
    '        ﾈｯﾄﾜｰｸ番号 :   String  strNetwkNo
    '        PC番号     :	String  strPcNo
    '        自局局番   :   String  strJiKyoku
    '        ﾃﾞﾊﾞｲｽ名	:	String	strDev
    '        処理数		:	int		intCnt
    '**********************************************************************************************
    Public Sub SeqBitReadCmndSend(ByVal strKyokuNo As String, _
                                  ByVal strNetwkNo As String, _
                                  ByVal strPcNo As String, _
                                  ByVal strJiKyoku As String, _
                                  ByVal strDev As String, _
                                  ByVal intCnt As Integer, _
                                  ByVal intBit() As Integer, _
                                  ByVal intRetCode As DrvBase.RetCode)

        '*******************************************
        '送信ﾃｷｽﾄ作成
        '*******************************************
        mstrSend = ""
        mstrSend &= ZeroSppr(2, strKyokuNo)     '局番号
        mstrSend &= ZeroSppr(2, strPcNo)        'PC番号
        mstrSend &= BRD                         'ｺﾏﾝﾄﾞ
        mstrSend &= Wait                        '伝文ｳｪｲﾄ
        mstrSend &= SpaceSppr(5, strDev)        'ﾃﾞﾊﾞｲｽ
        mstrSend &= Right("00" & Hex(intCnt), 2)    '点数

        '*******************************************
        '送信
        '*******************************************
        Dim strRecv As String = ""
        mobjDrv.SendMsg(mstrSend)               ' 送信実行
        ReceiveWait(strKyokuNo, strNetwkNo, strPcNo, strJiKyoku, strDev, intCnt, mstrSend, strRecv, intRetCode, True)

        '*******************************************
        '応答ﾃﾞｰﾀｾｯﾄ
        '*******************************************
        For i As Integer = 0 To intCnt - 1
            intBit(i) = Val(Mid(strRecv, 11 + (i), 1))
        Next
    End Sub

#End Region

#Region "ﾋﾞｯﾄ単位書込"
    '**********************************************************************************************
    '【機能】ﾋﾞｯﾄ単位書込要求送信
    '【引数】局番号     :   String  strKyokuNo
    '        ﾈｯﾄﾜｰｸ番号 :   String  strNetwkNo
    '        PC番号     :	String  strPcNo
    '        自局局番   :   String  strJiKyoku
    '        ﾃﾞﾊﾞｲｽ名	:	String	strDev
    '        処理数		:	int		intCnt
    '        書込ﾃﾞｰﾀ   :	int		intBit()
    '**********************************************************************************************
    Public Sub SeqBitWriteCmndSend(ByVal strKyokuNo As String, _
                                   ByVal strNetwkNo As String, _
                                   ByVal strPcNo As String, _
                                   ByVal strJiKyoku As String, _
                                   ByVal strDev As String, _
                                   ByVal intCnt As Integer, _
                                   ByRef intBit() As Integer, _
                                   ByVal intRetCode As DrvBase.RetCode)


        '*******************************************
        '送信ﾃｷｽﾄ作成
        '*******************************************
        mstrSend = ""
        mstrSend &= ZeroSppr(2, strKyokuNo)     '局番号
        mstrSend &= ZeroSppr(2, strPcNo)        'PC番号
        mstrSend &= BWR                         'ｺﾏﾝﾄﾞ
        mstrSend &= Wait                        '伝文ｳｪｲﾄ
        mstrSend &= SpaceSppr(5, strDev)        'ﾃﾞﾊﾞｲｽ
        mstrSend &= Right("00" & Hex(intCnt), 2)    '点数
        For i As Integer = 0 To intCnt - 1
            If intBit(i) = 0 Then
                mstrSend &= "0"
            Else
                mstrSend &= "1"
            End If
        Next

        '*******************************************
        '送信
        '*******************************************
        Dim strRecv As String = ""
        mobjDrv.SendMsg(mstrSend)               ' 送信実行
        ReceiveWait(strKyokuNo, strNetwkNo, strPcNo, strJiKyoku, strDev, intCnt, mstrSend, strRecv, intRetCode, False)

    End Sub
#End Region

#End Region

#Region "ﾜｰﾄﾞ単位読込/書込要求ｺﾏﾝﾄﾞ送信 関数"

#Region "ﾜｰﾄﾞ単位読込み"
    '**********************************************************************************************
    '【機能】ﾜｰﾄﾞ単位読込要求送信
    '【引数】局番号     :   String  strKyokuNo
    '        ﾈｯﾄﾜｰｸ番号 :   String  strNetwkNo
    '        PC番号     :	String  strPcNo
    '        自局局番   :   String  strJiKyoku
    '        ﾃﾞﾊﾞｲｽ名	:	String	strDev
    '        処理数		:	int		intCnt
    '**********************************************************************************************
    Public Function SeqWordReadCmndSend(ByVal strKyokuNo As String _
                                      , ByVal strNetwkNo As String _
                                      , ByVal strPcNo As String _
                                      , ByVal strJiKyoku As String _
                                      , ByVal strDev As Integer _
                                      , ByVal intCnt As Integer _
                                      , ByRef intWord() As Integer _
                                       ) As DrvBase.RetCode
        Dim intRetCode As DrvBase.RetCode

        '*******************************************
        '送信ﾃｷｽﾄ作成
        '*******************************************
        If strDev > 40000 Then strDev = strDev - 40000
        mstrSend = ""
        mstrSend &= FLM                         '識別番号&ﾌﾚｰﾑ
        mstrSend &= ZeroSppr(2, strKyokuNo)     '局番
        mstrSend &= ZeroSppr(2, strNetwkNo)     'ﾈｯﾄﾜｰｸ番号
        mstrSend &= ZeroSppr(2, strPcNo)        'PC番号
        mstrSend &= ZeroSppr(2, strJiKyoku)     '自局局番
        mstrSend &= WRD                         'ｺﾏﾝﾄﾞ
        mstrSend &= WRDS                        'ｻﾌﾞｺﾏﾝﾄﾞ
        mstrSend &= DEVICE_D                    'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        mstrSend &= ZeroSppr(6, strDev)         '先頭ﾃﾞﾊﾞｲｽ
        mstrSend &= ZeroSppr(4, Hex(intCnt))    'ﾃﾞﾊﾞｲｽ点数

        '*******************************************
        '送信
        '*******************************************
        Dim strRecv As String = ""
        mobjDrv.SendMsg(mstrSend)               ' 送信実行
        ReceiveWait(strKyokuNo, strNetwkNo, strPcNo, strJiKyoku, strDev, intCnt, mstrSend, strRecv, intRetCode, True)

        '*******************************************
        '応答ﾃﾞｰﾀｾｯﾄ
        '*******************************************
        If intRetCode = DrvBase.RetCode.OK Then
            For i As Integer = 0 To intCnt - 1
                intWord(i) = Val("&H" & Mid(strRecv, 11 + ((i) * 4), 4))
            Next
        End If

        Return intRetCode

    End Function
#End Region

#Region "ﾜｰﾄﾞ単位書込み"
    '**********************************************************************************************
    '【機能】ﾜｰﾄﾞ単位書込要求送信
    '【引数】局番号     :   String  strKyokuNo
    '        ﾈｯﾄﾜｰｸ番号 :   String  strNetwkNo
    '        PC番号     :	String  strPcNo
    '        自局局番   :   String  strJiKyoku
    '        ﾃﾞﾊﾞｲｽ名	:	String	strDev
    '        処理数		:	int		intCnt
    '        書込データ	:	int		intWord()
    '**********************************************************************************************
    Public Function SeqWordWriteCmndSend(ByVal strKyokuNo As String _
                                       , ByVal strNetwkNo As String _
                                       , ByVal strPcNo As String _
                                       , ByVal strJiKyoku As String _
                                       , ByVal strDev As Integer _
                                       , ByVal intWord() As Integer _
                                        ) As CtrlPlcAccess.DrvBase.RetCode
        Dim intRetCode As DrvBase.RetCode
        Dim intCnt As Integer = UBound(intWord)

        '*******************************************
        '送信ﾃｷｽﾄ作成
        '*******************************************
        If strDev > 40000 Then strDev = strDev - 40000
        mstrSend = ""
        mstrSend &= FLM                         '識別番号&ﾌﾚｰﾑ
        mstrSend &= ZeroSppr(2, strKyokuNo)     '局番
        mstrSend &= ZeroSppr(2, strNetwkNo)     'ﾈｯﾄﾜｰｸ番号
        mstrSend &= ZeroSppr(2, strPcNo)        'PC番号
        mstrSend &= ZeroSppr(2, strJiKyoku)     '自局局番
        mstrSend &= WWR                         'ｺﾏﾝﾄﾞ
        mstrSend &= WWRS                        'ｻﾌﾞｺﾏﾝﾄﾞ
        mstrSend &= DEVICE_D                    'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        mstrSend &= ZeroSppr(6, strDev)         '先頭ﾃﾞﾊﾞｲｽ
        mstrSend &= ZeroSppr(4, Hex(intCnt))    'ﾃﾞﾊﾞｲｽ点数
        For i As Integer = 0 To intCnt - 1
            mstrSend &= Right("0000" & Hex(intWord(i)), 4)
        Next

        '*******************************************
        '送信
        '*******************************************
        Dim strRecv As String = ""
        mobjDrv.SendMsg(mstrSend)               ' 送信実行
        ReceiveWait(strKyokuNo, strNetwkNo, strPcNo, strJiKyoku, strDev, intCnt, mstrSend, strRecv, intRetCode, False)

        Return intRetCode

    End Function
#End Region

#End Region

#Region "電文送信"
    Public Sub CmndSend(ByVal strSendData As String)
        '*******************************************
        '送信
        '*******************************************
        mobjDrv.SendMsg(strSendData)               ' 送信実行

    End Sub
#End Region

#Region "受信ﾃﾞｰﾀ取得"
    '**********************************************************************************************
    '【機能】受信ﾃﾞｰﾀ取得
    '【引数】[OUT]受信ﾃﾞｰﾀ      :strRecvdata
    '**********************************************************************************************
    Public Sub ReceiveText(ByRef strRecvdata As String, _
                           ByRef intRetCode As DrvBase.RetCode)

        mobjDrv.ReceiveText(strRecvdata, intRetCode)    '受信ﾃﾞｰﾀ

    End Sub
#End Region

#Region "ｺﾏﾝﾄﾞ送信後受信待ち処理"
    '**********************************************************************************************
    '【機能】受信ﾃﾞｰﾀ取得
    '【引数】[OUT]受信ﾃﾞｰﾀ      :strRecvdata
    '**********************************************************************************************
    Public Sub ReceiveWait(ByVal strKyokuNo As String, _
                           ByVal strNetwkNo As String, _
                           ByVal strPcNo As String, _
                           ByVal strJiKyoku As String, _
                           ByVal strDev As String, _
                           ByVal intCnt As Integer, _
                           ByVal strSenddata As String, _
                           ByRef strRecvdata As String, _
                           ByRef intRetCode As DrvBase.RetCode, _
                           ByVal blnSendACK As Boolean)
        Dim dtmStart As Date = Now
        Dim blnLoop As Boolean = True
        Dim intRetryCnt As Integer = 1
        While blnLoop
            '受信処理
            ReceiveText(strRecvdata, intRetCode)

            'ｴﾗｰ判定
            Dim blnError As Boolean = False
            If DateDiff(DateInterval.Second, dtmStart, Now) > mintTimeOut Then
                AddToLog("送信時ﾀｲﾑｱｳﾄ")
                blnError = True
            End If
            If intRetCode = DrvBase.RetCode.NG Then
                AddToLog("異常応答:" & strRecvdata)
                blnError = True
            End If
            If strRecvdata <> "" And intRetCode = DrvBase.RetCode.OK Then
                '局番号CHECK
                If Mid(strRecvdata, 3, 2) <> strKyokuNo Then
                    AddToLog("局番号異常:" & strRecvdata)
                    blnError = True
                End If
                'ﾈｯﾄﾜｰｸ番号CHECK
                If Mid(strRecvdata, 5, 2) <> strNetwkNo Then
                    AddToLog("ﾈｯﾄﾜｰｸ番号異常:" & strRecvdata)
                    blnError = True
                End If
                'PC番号CHECK
                If Mid(strRecvdata, 7, 2) <> strPcNo Then
                    AddToLog("PC番号異常:" & strRecvdata)
                    blnError = True
                End If
                '自局局番CHECK
                If Mid(strRecvdata, 9, 2) <> strJiKyoku Then
                    AddToLog("自局局番異常:" & strRecvdata)
                    blnError = True
                End If
            End If

            '正常処理/ｴﾗｰ処理
            If blnError = True Then
                If intRetryCnt >= mintRetry Then
                    '処理ﾙｰﾌﾟ脱出 & 異常処理
                    AddToLog("ﾘﾄﾗｲｵｰﾊﾞｰ")
                    blnLoop = False
                    intRetCode = DrvBase.RetCode.NG
                Else
                    '再送信
                    mobjDrv.SendMsg(mstrSend)               ' 送信実行
                    AddToLog("再送信")
                    dtmStart = Now
                    intRetryCnt += 1
                End If
            Else
                If strRecvdata <> "" And intRetCode = DrvBase.RetCode.OK Then
                    '正常受信
                    blnLoop = False

                    If blnSendACK = True Then
                        '受信確認送信
                        mstrSend = ""
                        mstrSend &= ZeroSppr(2, strKyokuNo)     '局番号
                        mstrSend &= ZeroSppr(2, strPcNo)        'PC番号
                        mobjDrv.SendACK(mstrSend)               '受信確認送信
                    End If
                Else
                    '受信待ち
                    Threading.Thread.Sleep(10)
                End If
            End If
        End While
    End Sub
#End Region



#Region "ﾋﾞｯﾄ単位読込要求時　受信ﾃﾞｰﾀ取得"
    Public Sub BitReceiveText(ByRef intBit() As Integer, _
                              ByVal intCnt As Integer, _
                              ByRef intRetCode As DrvBase.RetCode)

        Dim strRecvdata As String = ""

        mobjDrv.ReceiveText(strRecvdata, intRetCode)    '受信ﾃﾞｰﾀ
        If strRecvdata <> "" Then
            ReDim intBit(intCnt)
            For i As Integer = 1 To intCnt
                intBit(i) = Val(Mid(mstrRecv, 5 + (i - 1), 1))
            Next
        End If



    End Sub
#End Region

#Region "ﾜｰﾄﾞ単位読込要求時　受信ﾃﾞｰﾀ取得"
    Public Sub WordReadReceiveText(ByRef intWord() As Integer, _
                                   ByVal intCnt As Integer, _
                                   ByRef intRetCode As DrvBase.RetCode)

        Dim strRecvdata As String = ""

        mobjDrv.ReceiveText(strRecvdata, intRetCode)    '受信ﾃﾞｰﾀ

        If intRetCode = DrvBase.RetCode.OK Then
            If strRecvdata <> "" Then
                For i As Integer = 1 To intCnt
                    intWord(i) = Val("&H" & Mid(mstrRecv, 5 + ((i - 1) * 4), 4))
                Next
            End If
        Else

        End If




    End Sub
#End Region

#Region "ﾜｰﾄﾞ単位書込み要求時　受信ﾃﾞｰﾀ取得"
    Public Sub WordWriteReceiveText(ByRef strRecvdata As String, _
                                    ByRef intRetCode As DrvBase.RetCode)


        mobjDrv.ReceiveText(strRecvdata, intRetCode)    '受信ﾃﾞｰﾀ


        '' ''strRetCode = strRecvdata.Substring(4, 2)    'ﾚｼｰﾌﾞｺｰﾄﾞ


    End Sub
#End Region



#Region "  ﾛｸﾞ書き込み処理"
    Public Sub AddToLog(ByVal strMsg_1 As String)

        mobjDrv.AddToLog(strMsg_1)

    End Sub
#End Region

#Region "  ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)"
    Public Sub AddToDebugLog(ByVal strMsg_1 As String)

        If mintDebugFlag = 0 Then
            mobjDrv.AddToLog(strMsg_1)
        End If

    End Sub
#End Region

End Class
