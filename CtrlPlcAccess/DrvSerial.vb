'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ ｼﾘｱﾙ通信 ｸﾗｽ
' 【作成】2005/11/08　KSH/J.Kato　Rev 0.00　初版
'**********************************************************************************************

Imports System.Net
Imports System.Text
Imports System.IO.Ports


Public Class DrvSerial
    Inherits DrvRS232C

#Region "共通変数"
    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjSerial As SerialPort                'ｼﾘｱﾙﾎﾟｰﾄ通信ｸﾗｽ（受信用）
    Private mbytSerialRecvData() As Byte            'ｼﾘｱﾙ受信ﾃﾞｰﾀ格納ﾊﾞｯﾌｧ

    '表示用ﾒｯｾｰｼﾞ
    Private Const MESSAGE_01 As String = "  現在のﾊﾞｯﾌｧ="
    Private Const MESSAGE_02 As String = "  ｺﾞﾐﾃﾞｰﾀ取得="
    Private Const MESSAGE_11 As String = "  BCCｴﾗｰ="


    '==================================================
    '通信種別
    '==================================================
    Public Enum SerialKind
        Recv        '受信
        Send        '送信
    End Enum

#End Region

#Region "ﾌﾟﾛﾊﾟﾃｨ"
    '===================================================
    'ｼﾘｱﾙ通信ｵﾌﾞｼﾞｪｸﾄ(ｵﾌﾞｼﾞｪｸﾄの存在を確認するため)
    '===================================================
    Public ReadOnly Property OBJSERIAL() As Object
        Get
            Return mobjSerial
        End Get
    End Property

#End Region

#Region "初期/終了　処理"

#Region "初期処理"

    '*******************************************************************************************************************
    '【機能】コンストラクタ
    '【引数】   送信ポート	    :String     newSerialPort
    '           ﾎﾞｰﾚｰﾄ          :int        newSerialBaud
    '           ﾊﾟﾘﾃｨ           :int        newSerialParity
    '           ﾃﾞｰﾀ数          :int        newSerialDataLen
    '           ｽﾄｯﾌﾟﾋﾞｯﾄ数     :int        newSerialStopBit
    '           ｺｰﾄﾞﾍﾟｰｼﾞ       :int        newSerialCodePage
    '           new時ｺﾈｸﾄ       :Bool       blnConnect = False
    '【戻値】
    '*******************************************************************************************************************
    Public Sub New(ByRef objOwner As Object, _
                   ByVal newSerialPort As String, _
                   ByVal newSerialBaud As Integer, _
                   ByVal newSerialParity As Integer, _
                   ByVal newSerialDataLen As Integer, _
                   ByVal newSerialStopBit As Integer, _
                   ByVal newSerialCodePage As Integer, _
                   Optional ByVal blnConnect As Boolean = False)

        MyBase.new(objOwner, _
                   newSerialPort, _
                   newSerialBaud, _
                   newSerialParity, _
                   newSerialDataLen, _
                   newSerialStopBit, _
                   newSerialCodePage)

        Try
            '================================
            '初期設定
            '================================
            Call Init()


            If blnConnect = True Then
                '(New時接続ﾌﾗｸﾞがTrueの場合)
                '================================
                '接続
                '================================
                Call Connect()

            End If


        Catch ex As Exception
            Throw ex

        End Try
    End Sub


    '*******************************************************************************************************************
    '【機能】初期設定
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub Init()

    End Sub

#End Region

#Region "終了処理"
    '*******************************************************************************************************************
    '【機能】デストラクタ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Protected Overrides Sub Finalize()
        Try

            '*****************************************************
            'ｼﾘｱﾙﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄの開放
            '*****************************************************
            '================================
            'ｼﾘｱﾙﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ開放
            '================================
            If Not (mobjSerial Is Nothing) Then
                '(ｵﾌﾞｼﾞｪｸﾄがNothingでない場合)
                mobjSerial.Close()
                mobjSerial.Dispose()
                mobjSerial = Nothing

            End If


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region

#End Region

#Region "接続/切断　処理"

#Region "接続"
    '*******************************************************************************************************************
    '【機能】通信ｵｰﾌﾟﾝ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Sub Connect()


        If Not mobjSerial Is Nothing Then
            mobjSerial.Close()       '受信通信ｸﾛｰｽﾞ
            mobjSerial.Dispose()
            mobjSerial = Nothing
        End If

        '*****************************************************
        'ｼﾘｱﾙ通信ｾｯﾄｱｯﾌﾟ
        '*****************************************************
        If IsNothing(mobjSerial) Then
            mobjSerial = New SerialPort(MyBase.SerialPort, _
                                        MyBase.SerialBaud, _
                                        MyBase.SerialParity, _
                                        MyBase.SerialDataLength, _
                                        MyBase.SerialStopBit)
        End If


        '通信ｵｰﾌﾟﾝ
        mobjSerial.Open()

        mobjSerial.RtsEnable = True
        mobjSerial.DtrEnable = True


        'ｴﾝｺｰﾄﾞ設定
        mobjSerial.Encoding = Text.Encoding.GetEncoding(mintCodePage)


    End Sub
#End Region

#Region "切断"
    '*******************************************************************************************************************
    '【機能】通信ｸﾛｰｽﾞ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Sub Close()

        If Not mobjSerial Is Nothing Then
            mobjSerial.Close()       '受信通信ｸﾛｰｽﾞ
            mobjSerial.Dispose()
            mobjSerial = Nothing
        End If


    End Sub
#End Region

#End Region

#Region "ｺﾏﾝﾄﾞ送信"
    '*******************************************************************************************************************
    '【機能】コマンド送信
    '【引数】送信コマンド	:	String	SendTX
    '【戻値】返答テキスト	:	String
    '*******************************************************************************************************************
    Public Overrides Function SendMsg(ByVal SendTX As String) As String

        Dim strRet As String = ""

        '*****************************************************
        'ﾊﾞｲﾄに変換
        '*****************************************************
        Dim bytData() As Byte
        Dim bytCR() As Byte
        Dim bytLF() As Byte
        '↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        'Mente:2015/03/21 S.Ouchi 武州製薬 ﾘﾌﾀ電文調整のため
        Dim bytZR(2) As Byte
        '↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
        bytData = StringToByte(SendTX)
        bytCR = StringToByte(CR)
        bytLF = StringToByte(LF)
        '*****************************************************
        'ﾁｪｯｸｻﾑ　ｾｯﾄ
        '*****************************************************
        Dim bytChckSum() As Byte
        bytChckSum = CreateChckSum(bytData)

        '*****************************************************
        '受信ﾊﾞｯﾌｧｸﾘｱ
        '*****************************************************
        mbytSerialRecvData = Nothing

        '*****************************************************
        '送信ﾃﾞｰﾀ編集
        '*****************************************************
        Dim lstSend As New List(Of Byte)
        If mblnSendEnq Then lstSend.AddRange(mbytENQ)
        If mblnSendStx Then lstSend.AddRange(mbytSTX)
        lstSend.AddRange(bytData)
        If mblnSendSum Then lstSend.AddRange(bytChckSum)
        If mblnSendEtx Then lstSend.AddRange(mbytETX)
        If mblnSendCr Then lstSend.AddRange(bytCR)
        If mblnSendLf Then lstSend.AddRange(bytLF)
        Dim bytSend() As Byte = lstSend.ToArray

        '*****************************************************
        '送信
        '*****************************************************
        mobjSerial.Write(bytSend, 0, bytSend.Length)
        AddToLog("送信=" & ByteToString(bytSend))

        Return strRet
    End Function

#End Region

#Region "受信確認送信"
    '*******************************************************************************************************************
    '【機能】受信確認送信
    '【引数】送信コマンド	:	String	SendTX
    '【戻値】返答テキスト	:	String
    '*******************************************************************************************************************
    Public Function SendACK(ByVal SendTX As String) As String

        Dim strRet As String = ""

        '*****************************************************
        'ﾊﾞｲﾄに変換
        '*****************************************************
        Dim bytData() As Byte
        Dim bytCR() As Byte
        Dim bytLF() As Byte
        bytData = StringToByte(SendTX)
        bytCR = StringToByte(CR)
        bytLF = StringToByte(LF)

        '*****************************************************
        '受信ﾊﾞｯﾌｧｸﾘｱ
        '*****************************************************
        mbytSerialRecvData = Nothing

        '*****************************************************
        '送信ﾃﾞｰﾀ編集
        '*****************************************************
        Dim lstSend As New List(Of Byte)
        lstSend.AddRange(mbytACK)
        lstSend.AddRange(bytData)
        If mblnSendCr Then lstSend.AddRange(bytCR)
        If mblnSendLf Then lstSend.AddRange(bytLF)
        Dim bytSend() As Byte = lstSend.ToArray

        '*****************************************************
        '送信ﾃﾞｰﾀ編集
        '*****************************************************
        mobjSerial.Write(bytSend, 0, bytSend.Length)
        AddToLog("  送信=" & ByteToString(bytSend))

        Return strRet
    End Function

#End Region

#Region "ｼﾘｱﾙ通信受信ﾃｷｽﾄ取得"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ OUT ]strReceiveData  ：正常に受信できたﾃﾞｰﾀ
    '        [ OUT ]strResponsCode  ：応答ｺｰﾄﾞ
    '【戻値】変換したﾊﾞｲﾄ配列
    '*******************************************************************************************************************
    Public Sub ReceiveText(ByRef strReceiveData As String, _
                           ByRef strRetCode As String)


        '*****************************************************
        '受信用ﾎﾟｰﾄか送信用ﾎﾟｰﾄか選択
        '*****************************************************
        Call ReceiveText_Main(strReceiveData, _
                              mobjSerial, _
                              mbytSerialRecvData, _
                              strRetCode _
                              )


    End Sub

#Region "  ｼﾘｱﾙ通信受信ﾃｷｽﾄ取得"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ OUT ]strReceiveData  ：正常に受信できたﾃﾞｰﾀ
    '        [ OUT ]objSerialPort   ：使用するｼﾘｱﾙﾎﾟｰﾄ
    '        [ OUT ]bytBuffer       ：使用する受信格納ﾊﾞｯﾌｧ
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub ReceiveText_Main(ByRef strReceiveData As String, _
                                ByRef objSerialPort As SerialPort, _
                                ByRef bytBuffer() As Byte, _
                                ByRef strRetCode As RetCode)
        '' ''Dim strMessage As String        'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
        strRetCode = RetCode.OTHER

        '*****************************************************
        '受信ﾃﾞｰﾀを、ﾊﾞｲﾄ配列ﾊﾞｯﾌｧに追加
        '*****************************************************
        Dim bytRead(512) As Byte
        If objSerialPort.BytesToRead > 0 Then
            Dim intGetbyte As Integer       '取得ﾊﾞｲﾄ数
            intGetbyte = objSerialPort.Read(bytRead, 0, bytRead.Length)      'ﾃﾞｰﾀ取得
            For ii As Integer = 0 To intGetbyte - 1
                If IsNothing(bytBuffer) Then
                    ReDim Preserve bytBuffer(0)
                Else
                    ReDim Preserve bytBuffer(UBound(bytBuffer) + 1)
                End If
                bytBuffer(UBound(bytBuffer)) = bytRead(ii)
            Next

            ' '' ''ﾊﾞｯﾌｧﾛｸﾞ出力
            '' ''strMessage = ""
            '' ''strMessage &= MESSAGE_01
            '' ''strMessage &= ByteToString(bytBuffer)
            '' ''Call AddToLog(strMessage)
        End If


        '*****************************************************
        '正常なﾃﾞｰﾀを取得
        '*****************************************************
        'ﾃﾞｰﾀﾁｪｯｸ
        If IsNothing(bytBuffer) Then Exit Sub
        If bytBuffer.Length = 0 Then
            bytBuffer = Nothing
            Exit Sub
        End If

        '' ''AddToLog(MESSAGE_01 & ByteToString(bytBuffer))

        'STXの位置検索
        Dim intSTXPlace As Integer
        Dim blnSTXFound As Boolean = False
        For intSTXPlace = LBound(bytBuffer) To UBound(bytBuffer)
            '(ﾙｰﾌﾟ:STXが見つかるまで)
            If bytBuffer(intSTXPlace) <> mbytSTX(0) Then Continue For

            blnSTXFound = True
            Exit For
        Next

        'ETXの位置検索
        Dim intETXPlace As Integer
        Dim blnETXFound As Boolean = False
        For intETXPlace = LBound(bytBuffer) To UBound(bytBuffer)
            '(ﾙｰﾌﾟ:ETXが見つかるまで)
            If bytBuffer(intETXPlace).ToString <> mbytETX(0) Then Continue For

            blnETXFound = True
            Exit For
        Next

        'ACKの位置検索
        Dim intACKPlace As Integer
        Dim blnACKFound As Boolean = False
        If blnSTXFound = False And _
           blnETXFound = False Then
            For intACKPlace = LBound(bytBuffer) To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:ACKが見つかるまで)
                If bytBuffer(intACKPlace).ToString <> mbytACK(0) Then Continue For

                blnACKFound = True
                Exit For
            Next

            'ACK受信時
            If blnACKFound = True Then
                Dim bytCR() As Byte
                bytCR = StringToByte(CR)

                'CRの位置検索
                Dim intCRPlace As Integer
                Dim blnCRFound As Boolean = False
                For intCRPlace = LBound(bytBuffer) To UBound(bytBuffer)
                    '(ﾙｰﾌﾟ:CRが見つかるまで)
                    If bytBuffer(intCRPlace).ToString <> bytCR(0) Then Continue For

                    blnCRFound = True
                    Exit For
                Next

                If blnCRFound = True Then
                    AddToLog("  受信=" & ByteToString(bytBuffer))

                    '-----------------------------------
                    '電文取得
                    '-----------------------------------
                    If intCRPlace > intACKPlace Then
                        Dim bytGetData(intCRPlace - intACKPlace) As Byte      '受信するﾃﾞｰﾀを格納
                        Dim bytChckSum(1) As Byte
                        For ii As Integer = intACKPlace + 1 To intCRPlace
                            '(ﾙｰﾌﾟ:[ACK] + 1　から[CR]まで)

                            bytGetData(ii - 1) = bytBuffer(ii)       '受信するﾃﾞｰﾀ格納

                        Next

                        If mintChSmPs = CheckSumPosition.AfterETX Then
                            ReDim Preserve bytGetData(UBound(bytGetData) - 1)   'ACK 削除
                        End If
                        strReceiveData = ByteToString(bytGetData)           '受信ﾃﾞｰﾀ
                        strRetCode = RetCode.OK

                        Exit Sub
                    End If
                End If
            End If
        End If

        'NAKの位置検索
        Dim intNAKPlace As Integer
        Dim blnNAKFound As Boolean = False
        If blnSTXFound = False And _
           blnETXFound = False Then
            For intNAKPlace = LBound(bytBuffer) To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:NAKが見つかるまで)
                If bytBuffer(intNAKPlace).ToString <> mbytNAK(0) Then Continue For

                blnNAKFound = True
                Exit For
            Next

            'NAK受信時
            If blnNAKFound = True Then
                Dim bytCR() As Byte
                bytCR = StringToByte(CR)

                'CRの位置検索
                Dim intCRPlace As Integer
                Dim blnCRFound As Boolean = False
                For intCRPlace = LBound(bytBuffer) To UBound(bytBuffer)
                    '(ﾙｰﾌﾟ:CRが見つかるまで)
                    If bytBuffer(intCRPlace).ToString <> bytCR(0) Then Continue For

                    blnCRFound = True
                    Exit For
                Next

                If blnCRFound = True Then
                    AddToLog("  受信=" & ByteToString(bytBuffer))

                    '-----------------------------------
                    '電文取得
                    '-----------------------------------
                    If intCRPlace > intNAKPlace Then
                        Dim bytGetData(intCRPlace - intNAKPlace) As Byte      '受信するﾃﾞｰﾀを格納
                        Dim bytChckSum(1) As Byte
                        For ii As Integer = intNAKPlace + 1 To intCRPlace
                            '(ﾙｰﾌﾟ:[NAK] + 1　から[CR]まで)

                            bytGetData(ii - 1) = bytBuffer(ii)       '受信するﾃﾞｰﾀ格納

                        Next

                        If mintChSmPs = CheckSumPosition.AfterETX Then
                            ReDim Preserve bytGetData(UBound(bytGetData) - 1)   'NAK 削除
                        End If
                        strReceiveData = ByteToString(bytGetData)           '受信ﾃﾞｰﾀ
                        strRetCode = RetCode.NG

                        Exit Sub
                    End If
                End If
            End If
        End If

        '====================================================
        'STXが先頭にない場合、ｺﾞﾐと判断し削除
        '====================================================
        If intSTXPlace <> 0 And blnACKFound = False And blnNAKFound = False Then
            '-----------------------------------
            'ｺﾞﾐﾃﾞｰﾀ            取得
            'STX以降のﾃﾞｰﾀ      取得
            '-----------------------------------
            Dim bytDust(intSTXPlace - 1) As Byte                            'ｺﾞﾐﾃﾞｰﾀ
            Dim bytNotDust(UBound(bytBuffer) - intSTXPlace) As Byte      'ｺﾞﾐじゃないﾃﾞｰﾀの一時保管(STX以降のﾃﾞｰﾀ)
            For ii As Integer = LBound(bytBuffer) To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:全てのﾊﾞｯﾌｧﾃﾞｰﾀ)

                If ii < intSTXPlace Then
                    bytDust(ii) = bytBuffer(ii)                      'ｺﾞﾐﾃﾞｰﾀ取得
                Else
                    bytNotDust(ii - intSTXPlace) = bytBuffer(ii)     'STX以降のﾃﾞｰﾀ取得
                End If
            Next

            ' '' ''ｺﾞﾐﾃﾞｰﾀ取得ﾛｸﾞ出力
            '' ''strMessage = ""
            '' ''strMessage &= MESSAGE_02
            '' ''strMessage &= ByteToString(bytDust)
            '' ''Call AddToLog(strMessage)

            'ｺﾞﾐﾃﾞｰﾀ削除
            ReDim Preserve bytBuffer(UBound(bytNotDust))
            For ii As Integer = LBound(bytNotDust) To UBound(bytNotDust)
                '(ﾙｰﾌﾟ:全てのﾃﾞｰﾀ)
                bytBuffer(ii) = bytNotDust(ii)
            Next

            ''strResponsCode = MCV_RES_ER_STX                     'STX抜け
            'strReceiveData = ByteToString(bytDust)              '一応受信ﾃﾞｰﾀとする
        End If

        '====================================================
        'ACK が存在する場合、ACKが先頭にないと、ｺﾞﾐと判断し削除
        '====================================================
        If blnACKFound = True Then
            '-----------------------------------
            'ｺﾞﾐﾃﾞｰﾀ            取得
            'ACK以降のﾃﾞｰﾀ      取得
            '-----------------------------------
            Dim bytDust(intACKPlace - 1) As Byte                            'ｺﾞﾐﾃﾞｰﾀ
            Dim bytNotDust(UBound(bytBuffer) - intACKPlace) As Byte      'ｺﾞﾐじゃないﾃﾞｰﾀの一時保管(ACK以降のﾃﾞｰﾀ)
            For ii As Integer = LBound(bytBuffer) To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:全てのﾊﾞｯﾌｧﾃﾞｰﾀ)

                If ii < intACKPlace Then
                    bytDust(ii) = bytBuffer(ii)                      'ｺﾞﾐﾃﾞｰﾀ取得
                Else
                    bytNotDust(ii - intACKPlace) = bytBuffer(ii)     'ACK以降のﾃﾞｰﾀ取得
                End If
            Next

            ' '' ''ｺﾞﾐﾃﾞｰﾀ取得ﾛｸﾞ出力
            '' ''strMessage = ""
            '' ''strMessage &= MESSAGE_02
            '' ''strMessage &= ByteToString(bytDust)
            '' ''Call AddToLog(strMessage)

            'ｺﾞﾐﾃﾞｰﾀ削除
            ReDim Preserve bytBuffer(UBound(bytNotDust))
            For ii As Integer = LBound(bytNotDust) To UBound(bytNotDust)
                '(ﾙｰﾌﾟ:全てのﾃﾞｰﾀ)
                bytBuffer(ii) = bytNotDust(ii)
            Next

        End If

        '====================================================
        'NAK が存在する場合、NAKが先頭にないと、ｺﾞﾐと判断し削除
        '====================================================
        If blnNAKFound = True Then
            '-----------------------------------
            'ｺﾞﾐﾃﾞｰﾀ            取得
            'NAK以降のﾃﾞｰﾀ      取得
            '-----------------------------------
            Dim bytDust(intNAKPlace - 1) As Byte                            'ｺﾞﾐﾃﾞｰﾀ
            Dim bytNotDust(UBound(bytBuffer) - intNAKPlace) As Byte      'ｺﾞﾐじゃないﾃﾞｰﾀの一時保管(NAK以降のﾃﾞｰﾀ)
            For ii As Integer = LBound(bytBuffer) To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:全てのﾊﾞｯﾌｧﾃﾞｰﾀ)

                If ii < intNAKPlace Then
                    bytDust(ii) = bytBuffer(ii)                      'ｺﾞﾐﾃﾞｰﾀ取得
                Else
                    bytNotDust(ii - intNAKPlace) = bytBuffer(ii)     'NAK以降のﾃﾞｰﾀ取得
                End If
            Next

            ' '' ''ｺﾞﾐﾃﾞｰﾀ取得ﾛｸﾞ出力
            '' ''strMessage = ""
            '' ''strMessage &= MESSAGE_02
            '' ''strMessage &= ByteToString(bytDust)
            '' ''Call AddToLog(strMessage)

            'ｺﾞﾐﾃﾞｰﾀ削除
            ReDim Preserve bytBuffer(UBound(bytNotDust))
            For ii As Integer = LBound(bytNotDust) To UBound(bytNotDust)
                '(ﾙｰﾌﾟ:全てのﾃﾞｰﾀ)
                bytBuffer(ii) = bytNotDust(ii)
            Next

        End If

        '====================================================
        'STX、ETX が存在する場合、ﾃﾞｰﾀ取得
        '====================================================
        If intSTXPlace = 0 _
           And blnSTXFound = True _
           And blnETXFound = True _
           And intETXPlace <= UBound(bytBuffer) Then

            AddToLog("  受信=" & ByteToString(bytBuffer))

            '-----------------------------------
            '電文取得
            '-----------------------------------
            Dim bytGetData(intETXPlace - intSTXPlace - 1) As Byte      '受信するﾃﾞｰﾀを格納(STXは含めず、ETXは含む)
            Dim bytChckSum(1) As Byte
            For ii As Integer = intSTXPlace + 1 To intETXPlace
                '(ﾙｰﾌﾟ:[STX] + 1　から[ETX]まで)

                bytGetData(ii - 1) = bytBuffer(ii)       '受信するﾃﾞｰﾀ格納

                If ii >= intETXPlace - 2 And ii < intETXPlace Then
                    '(ﾁｪｯｸｻﾑ(ETXの前二つ)を取得)
                    bytChckSum(ii - (intETXPlace - 2)) = bytBuffer(ii)                   'ﾁｪｯｸｻﾑ取得

                End If
            Next

            '' '' ''-----------------------------------
            '' '' ''ｻﾑﾁｪｯｸ
            '' '' ''-----------------------------------
            ' '' ''Dim bytSumChData(1) As Byte     '電文から取得したﾁｪｯｸｻﾑ
            ' '' ''bytSumChData(0) = bytGetData(UBound(bytGetData) - 2)    'ﾁｪｯｸｻﾑ1ﾊﾞｲﾄ目
            ' '' ''bytSumChData(1) = bytGetData(UBound(bytGetData) - 1)    'ﾁｪｯｸｻﾑ2ﾊﾞｲﾄ目

            '' '' '' '' '' '' '' ''Call AddToLog(MESSAGE_08 & bytBCC)
            ' '' ''If ByteToString(bytChckSum) <> ByteToString(CreateChckSum(bytGetData)) Then         'ﾁｪｯｸｻﾑ取得

            ' '' ''End If
            ' '' '' '' ''    'BCCｴﾗｰﾛｸﾞ出力
            ' '' '' '' ''    strMessage = ""
            ' '' '' '' ''    strMessage &= MESSAGE_11 & bytBCC
            ' '' '' '' ''    ''Call AddToLog(strMessage)
            ' '' '' '' ''    ''strResponsCode = MCV_RES_ER_BCC
            ' '' '' '' ''End If
            ' ''-----------------------------------
            ' ''文字数ﾁｪｯｸ
            ' ''-----------------------------------
            ''If bytGetData.Length > 510 Then
            ''    strResponsCode = MCV_RES_ER_OVER
            ''End If


            '-----------------------------------
            '取得した電文以降のﾃﾞｰﾀを取得
            '-----------------------------------
            Dim bytBackETX(UBound(bytBuffer) - intETXPlace - 1) As Byte        '取得した電文以降のﾃﾞｰﾀを取得
            Dim intCount As Integer = 0     'bytBackETX用のｶｳﾝﾀ

            For ii As Integer = intETXPlace + 1 To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:[ETX]+1 以降)

                bytBackETX(intCount) = bytBuffer(ii)
                intCount += 1
            Next

            '-----------------------------------
            'ｼﾘｱﾙ受信ﾃﾞｰﾀ格納ﾊﾞｯﾌｧを更新
            '-----------------------------------
            If UBound(bytGetData) + 1 = UBound(bytBuffer) Then
                'ﾊﾞｯﾌｧﾃﾞｰﾀと受信ﾃﾞｰﾀが一緒の時
                bytBuffer = Nothing
            Else
                'ﾊﾞｯﾌｧﾃﾞｰﾀと受信ﾃﾞｰﾀが違う時
                ReDim Preserve bytBuffer(UBound(bytBackETX))
                For ii As Integer = LBound(bytBackETX) To UBound(bytBackETX)
                    '(ﾙｰﾌﾟ:全てのﾃﾞｰﾀ)
                    bytBuffer(ii) = bytBackETX(ii)
                Next
            End If



            '*****************************************************
            '正常に受信できたﾃﾞｰﾀを設定
            '*****************************************************
            '' '' ''If strResponsCode = MCV_RES_OK Then
            If mintChSmPs = CheckSumPosition.AfterETX Then
                ReDim Preserve bytGetData(UBound(bytGetData) - 1)   'ETX 削除
            Else
                ReDim Preserve bytGetData(UBound(bytGetData) - 3)   'ﾁｪｯｸｻﾑ、ETX 削除
            End If
            strReceiveData = ByteToString(bytGetData)           '受信ﾃﾞｰﾀ

            strRetCode = RetCode.OK

            '' '' ''End If

            ' '' ''電文取得ﾛｸﾞ出力
            '' ''strMessage = ""
            '' ''strMessage &= MESSAGE_03
            '' ''strMessage &= ByteToString(bytGetData)
            '' ''Call AddToLog(strMessage)

        End If


    End Sub
#End Region

#End Region

#Region "  ﾛｸﾞ書き込み処理"
    Public Sub AddToLog(ByVal strMsg_1 As String)

        strMsg_1 = Replace(strMsg_1, mstrSTX, strSTXDisp)
        strMsg_1 = Replace(strMsg_1, mstrETX, strETXDisp)
        strMsg_1 = Replace(strMsg_1, mstrENQ, strENQDisp)
        strMsg_1 = Replace(strMsg_1, mstrACK, strACKDisp)
        strMsg_1 = Replace(strMsg_1, mstrNAK, strNAKDisp)
        strMsg_1 = Replace(strMsg_1, CR, strCRDisp)
        strMsg_1 = Replace(strMsg_1, LF, strLFDisp)
        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
