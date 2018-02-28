'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ FAM3(RS232C接続) ｸﾗｽ
' 【作成】2005/11/08　KSH/J.Kato　      Rev 0.00　初版
'**********************************************************************************************

#Region "imports"

#End Region

Public Class UntFAM3_RS232C
    Inherits UntBase

#Region "内部定数"

    '==================================================
    '   内部定数
    '==================================================
    Private Const CM As String = ","            '区切り文字
    Private Const OK As String = "OK"           'OK
    Private Const ER As String = "ER"           'ER
    Private Const BRD As String = "BRD"         'ﾋﾞｯﾄ単位読込ｺﾏﾝﾄﾞ
    Private Const BWR As String = "BWR"         'ﾋﾞｯﾄ単位書込ｺﾏﾝﾄﾞ
    Private Const WRD As String = "WRD"         'ﾜｰﾄﾞ単位読込ｺﾏﾝﾄﾞ
    Private Const WWR As String = "WWR"         'ﾜｰﾄﾞ単位書込ｺﾏﾝﾄﾞ
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

#End Region

#Region "ﾌﾟﾛﾊﾟﾃｨ"
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
    '【引数】ｽﾃｰｼｮﾝ番号 :   int     intSTNo
    '        CPU 番号   :	int		intCPU
    '        応答待時間 :   int     intRsWtTm
    '        ﾃﾞﾊﾞｲｽ名	:	String	strDev
    '        処理数		:	int		intCnt
    '**********************************************************************************************
    Public Sub SeqBitReadCmndSend(ByVal intSTNo As Integer, _
                                  ByVal intCPU As Integer, _
                                  ByVal intRsWtTm As Integer, _
                                  ByVal strDev As String, _
                                  ByVal intCnt As Integer)

        '*******************************************
        '送信ﾃｷｽﾄ作成
        '*******************************************
        mstrSend = ""
        mstrSend &= ZeroSppr(2, intSTNo)        'ｽﾃｰｼｮﾝ番号
        mstrSend &= ZeroSppr(2, intCPU)         'CPU番号
        mstrSend &= CStr(intRsWtTm)             '応答待ち時間
        mstrSend &= BRD                         'ｺﾏﾝﾄﾞ
        mstrSend &= strDev                      'ﾃﾞﾊﾞｲｽ
        mstrSend &= CM                          '区切り文字
        mstrSend &= ZeroSppr(3, intCnt)         '点数

        '*******************************************
        '送信
        '*******************************************
        mobjDrv.SendMsg(mstrSend)               ' 送信実行


    End Sub

#End Region

#Region "ﾋﾞｯﾄ単位読込"
    '**********************************************************************************************
    '【機能】ﾋﾞｯﾄ単位書込要求送信
    '【引数】ｽﾃｰｼｮﾝ番号 :   int     intSTNo
    '        CPU 番号   :	int		intCPU
    '        応答待時間 :   int     intRsWtTm
    '        ﾃﾞﾊﾞｲｽ名	:	String	strDev
    '        処理数		:	int		intCnt
    '        書込ﾃﾞｰﾀ   :	int		intBit()
    '**********************************************************************************************
    Public Sub SeqBitWriteCmndSend(ByVal intSTNo As Integer, _
                                   ByVal intCPU As Integer, _
                                   ByVal intRsWtTm As Integer, _
                                   ByVal strDev As String, _
                                   ByVal intCnt As Integer, _
                                   ByRef intBit() As Integer)


        '*******************************************
        '送信ﾃｷｽﾄ作成
        '*******************************************
        mstrSend = ""
        mstrSend &= ZeroSppr(2, intSTNo)        'ｽﾃｰｼｮﾝ番号
        mstrSend &= ZeroSppr(2, intCPU)         'CPU番号
        mstrSend &= CStr(intRsWtTm)             '応答待ち時間
        mstrSend &= BRD                         'ｺﾏﾝﾄﾞ
        mstrSend &= strDev                      'ﾃﾞﾊﾞｲｽ
        mstrSend &= CM                          '区切り文字
        mstrSend &= ZeroSppr(3, intCnt)         '点数
        mstrSend &= CM                          '区切り文字
        For i As Integer = 1 To intCnt
            If intBit(i) = 0 Then
                mstrSend &= "0"
            Else
                mstrSend &= "1"
            End If
        Next

        '*******************************************
        '送信
        '*******************************************
        mobjDrv.SendMsg(mstrSend)               ' 送信実行


    End Sub
#End Region

#End Region

#Region "ﾜｰﾄﾞ単位読込/書込要求ｺﾏﾝﾄﾞ送信 関数"

#Region "ﾜｰﾄﾞ単位読込み"
    '**********************************************************************************************
    '【機能】ﾜｰﾄﾞ単位読込要求送信
    '【引数】ｽﾃｰｼｮﾝ番号 :   int     intSTNo
    '        CPU 番号	:	int		intCPU
    '        応答待時間 :   int     intRsWtTm
    '        ﾃﾞﾊﾞｲｽ名	:	String	strDev
    '        処理数		:	int		intCnt
    '**********************************************************************************************
    Public Sub SeqWordReadCmndSend(ByVal intSTNo As Integer, _
                                   ByVal intCPU As Integer, _
                                   ByVal intRsWtTm As Integer, _
                                   ByVal strDev As String, _
                                   ByVal intCnt As Integer)

        '*******************************************
        '送信ﾃｷｽﾄ作成
        '*******************************************
        mstrSend = ""
        mstrSend &= ZeroSppr(2, intSTNo)        'ｽﾃｰｼｮﾝ番号
        mstrSend &= ZeroSppr(2, intCPU)         'CPU番号
        mstrSend &= CStr(intRsWtTm)             '応答待ち時間
        mstrSend &= WRD                         'ｺﾏﾝﾄﾞ
        mstrSend &= strDev                      'ﾃﾞﾊﾞｲｽ
        mstrSend &= CM                          '区切り文字
        mstrSend &= ZeroSppr(2, intCnt)         '点数

        '*******************************************
        '送信
        '*******************************************
        mobjDrv.SendMsg(mstrSend)               ' 送信実行


    End Sub
#End Region

#Region "ﾜｰﾄﾞ単位書込み"
    '**********************************************************************************************
    '【機能】ﾜｰﾄﾞ単位書込要求送信
    '【引数】ｽﾃｰｼｮﾝ番号 :   int     intSTNo
    '        CPU 番号	:	int		intCPU
    '        応答待時間 :   int     intRsWtTm
    '        ﾃﾞﾊﾞｲｽ名	:	String	strDev
    '        処理数		:	int		intCnt
    '        書込データ	:	int		intWord()
    '**********************************************************************************************
    Public Sub SeqWordWriteCmndSend(ByVal intSTNo As Integer, _
                                    ByVal intCPU As Integer, _
                                    ByVal intRsWtTm As Integer, _
                                    ByVal strDev As String, _
                                    ByVal intCnt As Integer, _
                                    ByVal intWord() As Integer)


        '*******************************************
        '送信ﾃｷｽﾄ作成
        '*******************************************
        mstrSend = ""
        mstrSend &= ZeroSppr(2, intSTNo)        'ｽﾃｰｼｮﾝ番号
        mstrSend &= ZeroSppr(2, intCPU)         'CPU番号
        mstrSend &= CStr(intRsWtTm)             '応答待ち時間
        mstrSend &= WWR                     'ｺﾏﾝﾄﾞ
        mstrSend &= strDev                  'ﾃﾞﾊﾞｲｽ
        mstrSend &= CM                      '区切り文字
        mstrSend &= ZeroSppr(2, intCnt)     '点数
        mstrSend &= CM                      '区切り文字
        For i As Integer = 1 To intCnt
            mstrSend &= Right("0000" & Hex(intWord(i)), 4)
        Next

        '*******************************************
        '送信
        '*******************************************
        mobjDrv.SendMsg(mstrSend)               ' 送信実行


    End Sub
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




#Region "ﾋﾞｯﾄ単位読込要求時　受信ﾃﾞｰﾀ取得"
    Public Sub BitReceiveText(ByRef intBit() As Integer, _
                              ByVal intCnt As Integer, _
                              ByRef intRetCode As DrvBase.RetCode)

        Dim strRecvdata As String = ""

        mobjDrv.ReceiveText(strRecvdata, intRetCode)    '受信ﾃﾞｰﾀ
        If intRetCode = DrvBase.RetCode.OK Then
            If strRecvdata <> "" Then
                ReDim intBit(intCnt)
                For i As Integer = 1 To intCnt
                    intBit(i) = Val(Mid(mstrRecv, 5 + (i - 1), 1))
                Next
            End If
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


End Class
