'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCV通信ｸﾗｽ                        (KSH用ﾃﾞﾊﾞｯｸﾞﾂｰﾙです)
' 【作成】2006/05/30  KSH  Rev 0.00
'**********************************************************************************************

#Region "  Imports  "
Imports CtrlMCIC
Imports MateCommon
Imports MateCommon.clsConst
Imports System.IO.Ports
#End Region

Public Class clsMcvDummySerial
    Inherits clsMcvSerial

#Region "  共通変数 "

    '共通ｵﾌﾞｼﾞｪｸﾄ
    Private mobjConfig As clsConnectConfig      'Configﾌｧｲﾙ接続ｸﾗｽ
    Private mbytRecvData() As Byte              'ｼﾘｱﾙ受信ﾃﾞｰﾀ格納ﾊﾞｯﾌｧ(受信ﾎﾟｰﾄ)
    Private mbytResponsData() As Byte           'ｼﾘｱﾙ受信ﾃﾞｰﾀ格納ﾊﾞｯﾌｧ(送信ﾎﾟｰﾄ)

    'Config取得情報
    Private mstrRecvPort As String                   'ﾎﾟｰﾄ番号              
    Private mintRecvBaud As Integer                  '通信速度              
    Private mstrRecvParity As String                 'ﾊﾟﾘﾃｨ                 
    Private mintRecvDataLength As Integer            'ﾃﾞｰﾀ長                
    Private mstrRecvStopBit As String                'ｽﾄｯﾌﾟﾋﾞｯﾄ長           
    Private mstrRecvCheckInterval As String          '割り込みﾁｪｯｸ間隔(ms)  
    Private mstrRecvTimeOut As String                'ﾀｲﾑｱｳﾄ時間(秒)  
    Private mstrRecvEndString As String              '終端文字列ｺｰﾄﾞ(10進)

    Private mstrSendPort As String                   'ﾎﾟｰﾄ番号              
    Private mintSendBaud As Integer                  '通信速度              
    Private mstrSendParity As String                 'ﾊﾟﾘﾃｨ                 
    Private mintSendDataLength As Integer            'ﾃﾞｰﾀ長                
    Private mstrSendStopBit As String                'ｽﾄｯﾌﾟﾋﾞｯﾄ長           
    Private mstrSendCheckInterval As String          '割り込みﾁｪｯｸ間隔(ms)  
    Private mstrSendTimeOut As String                'ﾀｲﾑｱｳﾄ時間(秒)  
    Private mstrSendEndString As String              '終端文字列ｺｰﾄﾞ(10進)

    Private mintCodePage As Integer                  '通信に使用するﾃｷｽﾄのｺｰﾄﾞ


    '232C制御文字
    Private Const STX = &H2                         '(数値型) ﾃｷｽﾄ開始
    Private Const ETX = &H3                         '(数値型) ﾃｷｽﾄ終了
    '表示用
    Private Const strSTXDisp As String = "[STX]"    '(文字型) ﾃｷｽﾄ開始
    Private Const strETXDisp As String = "[ETX]"    '(文字型) ﾃｷｽﾄ終了


    '表示用ﾒｯｾｰｼﾞ
    Private Const MESSAGE_01 As String = "現在のﾊﾞｯﾌｧ    :"
    Private Const MESSAGE_02 As String = "ｺﾞﾐﾃﾞｰﾀ取得 　 :"
    Private Const MESSAGE_11 As String = "BCCｴﾗｰ         :"

#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ  "
    Public Sub New(ByVal objOwner As Object)

        Call MyBase.New(objOwner)

    End Sub
#End Region

#Region "  送信ﾒｿｯﾄﾞ"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]strSendText     ：送信するﾃｷｽﾄﾃﾞｰﾀ
    '　　　　[ IN ]udtSerial       ：送信ﾎﾟｰﾄ、受信ﾎﾟｰﾄの使用区別
    '　　　　[ IN ]blnSTX          ：STXを付加するかどうか
    '　　　　[ IN ]blnETX          ：ETXを付加するかどうか
    '　　　　[ IN ]blnBCC          ：BCCを付加するかどうか
    '【戻値】ﾌﾟﾛｸﾞﾗﾑ正常完了の有無
    '*******************************************************************************************************************
    Public Function SendSpecial(ByVal strSendText As String, _
                                ByVal udtSerial As SerialKind, _
                                ByVal blnSTX As Boolean, _
                                ByVal blnETX As Boolean, _
                                ByVal blnBCC As Boolean, _
                                ByVal strBCC As String _
                                ) _
                                As RetCode

        Try

            '*****************************************************
            '受信用ﾎﾟｰﾄか送信用ﾎﾟｰﾄか選択
            '*****************************************************
            Dim objSerialPort As SerialPort = Nothing       '使用するｼﾘｱﾙﾎﾟｰﾄ
            Select Case udtSerial
                Case SerialKind.Recv
                    objSerialPort = objRecv

                Case SerialKind.Send
                    objSerialPort = objSend

            End Select


            '*****************************************************
            'ﾊﾞｲﾄに変換
            '*****************************************************
            Dim bytData() As Byte
            bytData = StringToByte(strSendText)
            'ETX を付ける
            If blnETX = True Then
                ReDim Preserve bytData(UBound(bytData) + 1)
                bytData(UBound(bytData)) = bytETX(0)
            End If


            '*****************************************************
            'BCC    ｾｯﾄ
            '*****************************************************
            Dim bytBCC(0) As Byte
            If strBCC = "" Then
                bytBCC(0) = CreateBCC(bytData)                 'BCC取得
            Else
                bytBCC(0) = strBCC
            End If


            '*****************************************************
            '送信
            '*****************************************************
            If blnSTX = True Then
                objSerialPort.Write(bytSTX, 0, bytSTX.Length)
            End If

            objSerialPort.Write(bytData, 0, bytData.Length)

            If blnBCC = True Then
                objSerialPort.Write(bytBCC, 0, bytBCC.Length)
            End If



            Return RetCode.OK
        Catch ex As Exception
            Return RetCode.NG

        End Try
    End Function
#End Region

End Class
