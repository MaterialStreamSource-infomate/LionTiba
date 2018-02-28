'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ FAM3 ｸﾗｽ
' 【作成】2005/11/08　KSH/S.Ouchi　Rev 0.00　初版
'**********************************************************************************************

Public Class UntFAM3
    Inherits UntBase

#Region "内部定数"
    '==================================================
    '   内部定数
    '==================================================
    Private Const CM As String = ","                      '区切り文字
    Private Const OK As String = "OK"                     'OK
    Private Const ER As String = "ER"                     'ER
    Private Const BRD As String = "BRD"                   'ﾋﾞｯﾄ単位読込ｺﾏﾝﾄﾞ
    Private Const BWR As String = "BWR"                   'ﾋﾞｯﾄ単位書込ｺﾏﾝﾄﾞ
    Private Const WRD As String = "WRD"                   'ﾜｰﾄﾞ単位読込ｺﾏﾝﾄﾞ
    Private Const WWR As String = "WWR"                   'ﾜｰﾄﾞ単位書込ｺﾏﾝﾄﾞ
    Private CR As String = Chr(&HD).ToString    '改行コード CR
    Private LF As String = Chr(&HA).ToString    '改行コード LF
#End Region

#Region "内部変数"
    '==================================================
    '   内部変数
    '==================================================
    Private mstrSend As String                  '送信テキスト
    Private mstrRecv As String                  '受信テキスト
#End Region

#Region "初期/終了 処理"
    '==========================================================
    '【機能】コンストラクタ
    '【引数】接続ﾓｼﾞｭｰﾙ :	DrvBase	    objDrvBase
    '==========================================================
    Public Sub New(ByVal objDrvBase As DrvBase)
        MyBase.New(objDrvBase)
    End Sub

    '==========================================================
    '【機能】デストラクタ
    '==========================================================
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "読込/書込 関数"
    '==========================================================
    '【機能】ビット単位読込
    '【引数】CPU 番号	:	int		intCPU
    '        デバイス名	:	String	strDev
    '        処理数		:	int		intCnt
    '        読込データ	:	int		intBit()
    '==========================================================
    Public Overrides Sub SeqBitRead(ByVal intCPU As Integer, ByVal strDev As String, ByVal intCnt As Integer, ByRef intBit() As Integer)
        Try
            mstrSend = ""
            mstrSend &= ZeroSppr(2, intCPU)     'ｻﾌﾞﾍｯﾀﾞ CPU
            mstrSend &= BRD                     'ｺﾏﾝﾄﾞ
            mstrSend &= strDev                  'ﾃﾞﾊﾞｲｽ
            mstrSend &= CM                      '区切り文字
            mstrSend &= ZeroSppr(3, intCnt)     '点数
            mstrSend &= CR + LF                 '終端

            SeqCmdSend()                        '送信実行
            For i As Integer = 1 To intCnt
                intBit(i) = Val(Mid(mstrRecv, 5 + (i - 1), 1))
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '==========================================================
    '【機能】ビット単位書込
    '【引数】CPU 番号	:	int		intCPU
    '        デバイス名	:	String	strDev
    '        処理数		:	int		intCnt
    '        書込データ	:	int		intBit()
    '==========================================================
    Public Overrides Sub SeqBitWrite(ByVal intCPU As Integer, ByVal strDev As String, ByVal intCnt As Integer, ByVal intBit() As Integer)
        Try
            mstrSend = ""
            mstrSend &= ZeroSppr(2, intCPU)     'ｻﾌﾞﾍｯﾀﾞ CPU
            mstrSend &= BWR                     'ｺﾏﾝﾄﾞ
            mstrSend &= strDev                  'ﾃﾞﾊﾞｲｽ
            mstrSend &= CM                      '区切り文字
            mstrSend &= ZeroSppr(3, intCnt)     '点数
            mstrSend &= CM                      '区切り文字
            For i As Integer = 1 To intCnt
                If intBit(i) = 0 Then
                    mstrSend &= "0"
                Else
                    mstrSend &= "1"
                End If
            Next
            mstrSend &= CR + LF                 '終端

            SeqCmdSend()                        '送信実行
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '==========================================================
    '【機能】ワード単位読込
    '【引数】CPU 番号	:	int		intCPU
    '        デバイス名	:	String	strDev
    '        処理数		:	int		intCnt
    '        読込データ	:	int		intBit()
    '==========================================================
    Public Overrides Sub SeqWordRead(ByVal intCPU As Integer, ByVal strDev As String, ByVal intCnt As Integer, ByRef intWord() As Integer)
        Try
            mstrSend = ""
            mstrSend &= ZeroSppr(2, intCPU)     'ｻﾌﾞﾍｯﾀﾞ CPU
            mstrSend &= WRD                     'ｺﾏﾝﾄﾞ
            mstrSend &= strDev                  'ﾃﾞﾊﾞｲｽ
            mstrSend &= CM                      '区切り文字
            mstrSend &= ZeroSppr(2, intCnt)     '点数
            mstrSend &= CR + LF                 '終端

            SeqCmdSend()                        '送信実行
            For i As Integer = 1 To intCnt
                intWord(i) = Val("&H" & Mid(mstrRecv, 5 + ((i - 1) * 4), 4))
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '==========================================================
    '【機能】ワード単位書込
    '【引数】CPU 番号	:	int		intCPU
    '        デバイス名	:	String	strDev
    '        処理数		:	int		intCnt
    '        書込データ	:	int		intBit()
    '==========================================================
    Public Overrides Sub SeqWordWrite(ByVal intCPU As Integer, ByVal strDev As String, ByVal intCnt As Integer, ByVal intWord() As Integer)
        Try
            mstrSend = ""
            mstrSend &= ZeroSppr(2, intCPU)     'ｻﾌﾞﾍｯﾀﾞ CPU
            mstrSend &= WWR                     'ｺﾏﾝﾄﾞ
            mstrSend &= strDev                  'ﾃﾞﾊﾞｲｽ
            mstrSend &= CM                      '区切り文字
            mstrSend &= ZeroSppr(2, intCnt)     '点数
            mstrSend &= CM                      '区切り文字
            For i As Integer = 1 To intCnt
                mstrSend &= Right("0000" & Hex(intWord(i)), 4)
            Next
            mstrSend &= CR + LF                 '終端

            SeqCmdSend()                        '送信実行
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '==========================================================
    '【機能】コマンド送信処理
    '==========================================================
    Private Sub SeqCmdSend()
        Try
            mstrRecv = MyBase.Connector.SendMsg(mstrSend)   ' 送信実行
            If StrComp(Mid(mstrRecv, 3, 2), OK) = 0 Then
                ' 正常(NOP)
            ElseIf StrComp(Mid(mstrRecv, 3, 2), ER) = 0 Then
                Throw New PlcAccessException(SeqError(Val(Mid(mstrRecv, 5, 2))))
            Else
                Throw New PlcAccessException(SeqError(-1))
            End If
        Catch ex As Exception
            mstrRecv = ""
            Throw ex
        End Try
    End Sub

    '==========================================================
    '【機能】エラー処理
    '【引数】エラー番号	:	int		intERR
    '==========================================================
    Private Function SeqError(ByVal intERR As Integer) As String
        Try
            Dim strERR As String

            Select Case intERR
                Case -1
                    strERR = "レスポンス解読不能"
                Case -2
                    strERR = "配列数オーバー"
                Case 1
                    strERR = "CPU番号指定エラー"
                Case 2
                    strERR = "コマンドエラー"
                Case 3
                    strERR = "デバイス指定エラー"
                Case 4
                    strERR = "設定値範囲外"
                Case 5
                    strERR = "データ数範囲外"
                Case 6
                    strERR = "モニタエラー"
                Case 8
                    strERR = "パラメータエラー"
                Case 51
                    strERR = "CPU異常"
                Case 52
                    strERR = "CPU処理異常"
                Case Else
                    strERR = ""
            End Select

            Return strERR
        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region

End Class
