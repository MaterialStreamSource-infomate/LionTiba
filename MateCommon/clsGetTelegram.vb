'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【機能】電文用ﾃｷｽﾄ取得ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon.clsConst
Imports MateCommon
#End Region

Public Class clsGetTelegram

#Region "  共通変数         "

    '==================================================
    '共通変数、ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjOwner As Object                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mobjASCII As clsASCII               'ASCIIｺｰﾄﾞ文字ｸﾗｽ

    '==================================================
    'ﾌﾟﾛﾊﾟﾃｨ変数
    '==================================================
    Private mstrSTX As String           'ﾃｷｽﾄ開始
    Private mstrETX As String           'ﾃｷｽﾄ終了
    Private mintDebugFlag As Integer    'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ          "
    Public Sub New(ByVal objOwner As Object)


        '*****************************************************
        '色々初期化
        '*****************************************************
        mobjOwner = objOwner                    'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
        mobjASCII = New clsASCII()              'ASCIIｺｰﾄﾞ文字ｸﾗｽ


    End Sub
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ          "
    ''' =======================================
    ''' <summary>ｽﾀｰﾄﾃｷｽﾄ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strSTX() As String
        Get
            Return mstrSTX
        End Get
        Set(ByVal Value As String)
            mstrSTX = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ｴﾝﾄﾞﾃｷｽﾄ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strETX() As String
        Get
            Return mstrETX
        End Get
        Set(ByVal Value As String)
            mstrETX = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
        End Set
    End Property
#End Region

    '[STX] + [電文] + [ETX]             ﾊﾟﾀｰﾝの送受信
#Region "  電文作成         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄ作成
    ''' </summary>
    ''' <param name="strString">元となるﾃｷｽﾄ</param>
    ''' <returns>ｽﾀｰﾄﾃｷｽﾄとｴﾝﾄﾞﾃｷｽﾄを付加したﾃｷｽﾄ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function MakeTelegramSTXETX(ByVal strString As String) As String
        Dim strReturn As String = ""        '関数戻値


        strReturn &= mstrSTX
        strReturn &= strString
        strReturn &= mstrETX


        Return strReturn
    End Function
#End Region
#Region "  電文取得         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄ作成
    ''' </summary>
    ''' <param name="strString">
    ''' 元となるﾃｷｽﾄ。
    ''' ﾃｷｽﾄを取得出来た場合、取得したﾃｷｽﾄを削除した値が返る。
    ''' </param>
    ''' <returns>
    ''' ｽﾀｰﾄﾃｷｽﾄとｴﾝﾄﾞﾃｷｽﾄから判断して取得したﾃｷｽﾄ
    ''' </returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetTelegramSTXETX(ByRef strString As String) As String
        Dim strMessage As String            'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
        Try
            Dim strReturn As String = ""        '関数戻値


            '**************************************************
            'ﾁｪｯｸ
            '**************************************************
            If IsNull(strString) Then Return strReturn
            Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString(strString))


            '*****************************************************
            'STX,ETX        ｾｯﾄ
            '*****************************************************
            'STXの位置検索
            Dim intSTXPlace As Integer = InStr(strString, mstrSTX, CompareMethod.Binary)
            'ETXの位置検索
            Dim intETXPlace As Integer = InStr(strString, mstrETX, CompareMethod.Binary)


            '*****************************************************
            'STX,ETXが先頭にない場合、ｺﾞﾐと判断し削除
            '*****************************************************
            If intSTXPlace = 0 Then
                '(STX自体がない場合)

                'ｺﾞﾐﾃﾞｰﾀ取得ﾛｸﾞ出力
                strMessage = ""
                strMessage &= MSG_101
                strMessage &= mobjASCII.GetLogString(strString)
                Call AddToDebugLog(strMessage)

                'ｺﾞﾐﾃﾞｰﾀ削除
                strString = ""                      '一応受信ﾃﾞｰﾀとする

            ElseIf intSTXPlace <> 1 Then
                '-----------------------------------
                'ｺﾞﾐﾃﾞｰﾀ            取得
                'STX以降のﾃﾞｰﾀ      取得
                '-----------------------------------
                Dim strDust As String           'ｺﾞﾐﾃﾞｰﾀ
                Dim strNotDust As String        'ｺﾞﾐじゃないﾃﾞｰﾀ
                strDust = MID_SJIS(strString, 1, intSTXPlace - 1)      'ｺﾞﾐﾃﾞｰﾀ
                strNotDust = MID_SJIS(strString, intSTXPlace)          'ｺﾞﾐじゃないﾃﾞｰﾀ

                'ｺﾞﾐﾃﾞｰﾀ取得ﾛｸﾞ出力
                strMessage = ""
                strMessage &= MSG_101
                strMessage &= mobjASCII.GetLogString(strDust)
                Call AddToDebugLog(strMessage)

                'ｺﾞﾐﾃﾞｰﾀ削除
                strString = strNotDust            '一応受信ﾃﾞｰﾀとする
            End If


            '*****************************************************
            '正常なﾃﾞｰﾀを取得
            '*****************************************************
            If intSTXPlace = 1 Then
                '(STXがｽﾀｰﾄの場合)
                If GET_BYTE_LENGTH_STRING(mstrSTX) + 1 <= intETXPlace Then
                    '(STX、ETX が存在する場合)


                    '*****************************************************
                    'STX、ETX が存在する場合、ﾃﾞｰﾀ取得
                    '*****************************************************
                    '====================================
                    '電文取得
                    '====================================
                    strReturn = MID_SJIS(strString, 1, intETXPlace - 1)          '最初からETX直前まで取得
                    strReturn = MID_SJIS(strReturn, GET_BYTE_LENGTH_STRING(mstrSTX) + 1)          'このままだとSTXが付いているので削除


                    '====================================
                    'ﾊﾞｯﾌｧを更新
                    '====================================
                    strString = MID_SJIS(strString _
                                       , GET_BYTE_LENGTH_STRING(mstrSTX) + GET_BYTE_LENGTH_STRING(strReturn) + GET_BYTE_LENGTH_STRING(mstrETX) + 1 _
                                       )

                ElseIf intETXPlace = 0 Then
                    '(STX は存在するが、ETX が存在しない場合)

                    'NOP

                Else
                    '(STX は存在するが、ETX とかぶっている場合)

                    'ｺﾞﾐﾃﾞｰﾀ取得ﾛｸﾞ出力
                    strMessage = ""
                    strMessage &= MSG_101
                    strMessage &= mobjASCII.GetLogString(strString)
                    Call AddToDebugLog(strMessage)

                    'ｺﾞﾐﾃﾞｰﾀ削除
                    strString = ""                      '一応受信ﾃﾞｰﾀとする

                End If
            End If


            Return strReturn
        Catch ex As Exception
            Call ComError(ex)
            strString = ""      '永遠にﾙｰﾌﾟするので、初期化
            Throw ex

        Finally

            'ﾛｸﾞ出力
            strMessage = ""
            strMessage &= MSG_603
            strMessage &= mobjASCII.GetLogString(strString)
            Call AddToDebugLog(strMessage)

        End Try
    End Function
#End Region

    '[STX] + [電文] + [ETX] + [BCC]     ﾊﾟﾀｰﾝの送受信
#Region "  電文作成         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄ作成
    ''' </summary>
    ''' <param name="strString">元となるﾃｷｽﾄ</param>
    ''' <returns>[STX] + [電文] + [ETX] + [BCC]</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function MakeTelegramSTXETXBCC01(ByVal strString As String) As Byte()
        Dim bytReturn() As Byte             '関数戻値
        Dim strSendTelegram As String = ""  '送信電文


        '************************************************
        '[STX][ETX]を付加
        '************************************************
        strSendTelegram &= mstrSTX
        strSendTelegram &= strString
        strSendTelegram &= mstrETX


        '************************************************
        'BCC作成
        '************************************************
        Dim bytData() As Byte = Text.Encoding.GetEncoding(0).GetBytes(strSendTelegram)  '電文をﾊﾞｲﾄに変換
        Dim bytBCC(0) As Byte               'BCC
        bytBCC(0) = CreateBCC01(bytData)    'BCC取得


        '************************************************
        '電文作成
        '************************************************
        ReDim bytReturn(bytData.Length + bytBCC.Length - 1)     '電文部分 + BCC
        Call bytData.CopyTo(bytReturn, 0)
        Call bytBCC.CopyTo(bytReturn, bytData.Length)


        Return bytReturn
    End Function
#End Region
#Region "  BCC作成      【[STX] + [電文] + [ETX]の70ﾊﾞｲﾄのHEXﾃﾞｰﾀの和を100Hで除した余剰】"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' BCC作成
    ''' </summary>
    ''' <param name="bytData">BCCを作成する文字列</param>
    ''' <returns>BCC</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Protected Function CreateBCC01(ByVal bytData() As Byte) As Byte
        Dim bytBCC As Byte
        Dim lngSum As Long = 0


        '*********************************************************************************
        '[STX] + [電文] + [ETX]の70ﾊﾞｲﾄのHEXﾃﾞｰﾀの和
        '*********************************************************************************
        For ii As Integer = 0 To UBound(bytData)
            '(ﾙｰﾌﾟ:ﾊﾞｲﾄ配列の数だけ)
            lngSum = lngSum + bytData(ii)
        Next


        '*********************************************************************************
        '100Hで除した余剰
        '*********************************************************************************
        bytBCC = lngSum Mod 256


        Return (bytBCC)
    End Function
#End Region

    'ﾃﾞｰﾀ長を指定しているﾊﾟﾀｰﾝ
#Region "  電文取得(ﾊﾟﾀｰﾝ1)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文取得
    ''' 「長さ情報」が電文全体の場合
    ''' </summary>
    ''' <param name="strString">
    ''' 元となるﾃｷｽﾄ。
    ''' ﾃｷｽﾄを取得出来た場合、取得したﾃｷｽﾄを削除した値が返る。
    ''' </param>
    ''' <param name="intInforStartPosition">
    ''' 「長さ情報」が入っている位置
    ''' </param>
    ''' <param name="intInforLength">
    ''' 「長さ情報」の桁数
    ''' </param>
    ''' <returns>
    ''' ｽﾀｰﾄﾃｷｽﾄとｴﾝﾄﾞﾃｷｽﾄから判断して取得したﾃｷｽﾄ
    ''' </returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetTelegramDataLength01(ByRef strString As String _
                                          , ByVal intInforStartPosition As Integer _
                                          , ByVal intInforLength As Integer _
                                          ) As String
        Dim strMessage As String            'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
        Try
            Dim strReturn As String = ""        '関数戻値


            '**************************************************
            'ﾁｪｯｸ
            '**************************************************
            If IsNull(strString) Then Return strReturn
            Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString(strString))
            If GET_BYTE_LENGTH_STRING(strString) < intInforStartPosition + intInforLength Then Return strReturn


            '*****************************************************
            'ﾃﾞｰﾀ部長       取得
            '*****************************************************
            Dim strTelLength As String = MID_SJIS(strString, intInforStartPosition, intInforLength)        'ﾃﾞｰﾀ部長
            Dim intTelLength As Integer = TO_INTEGER(strTelLength)                                      'ﾃﾞｰﾀ部長
            If GET_BYTE_LENGTH_STRING(strString) < intTelLength Then Return strReturn


            '*****************************************************
            '正常なﾃﾞｰﾀを取得
            '*****************************************************
            '====================================
            '電文取得
            '====================================
            strReturn = MID_SJIS(strString, 1, intTelLength)

            '====================================
            'ﾊﾞｯﾌｧを更新
            '====================================
            If IsNumeric(strTelLength) Then
                strString = MID_SJIS(strString _
                                   , intTelLength + 1 _
                                   , _
                                   )
            Else
                strString = ""
            End If


            Return strReturn
        Catch ex As Exception
            Call ComError(ex)
            strString = ""      '永遠にﾙｰﾌﾟするので、初期化
            Throw ex

        Finally

            'ﾛｸﾞ出力
            strMessage = ""
            strMessage &= MSG_603
            strMessage &= mobjASCII.GetLogString(strString)
            Call AddToDebugLog(strMessage)

        End Try
    End Function
#End Region
#Region "  電文取得(ﾊﾟﾀｰﾝ2)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文取得
    ''' 「長さ情報」がﾃﾞｰﾀ部分の場合
    ''' </summary>
    ''' <param name="strString">
    ''' 元となるﾃｷｽﾄ。
    ''' ﾃｷｽﾄを取得出来た場合、取得したﾃｷｽﾄを削除した値が返る。
    ''' </param>
    ''' <param name="intInforStartPosition">
    ''' 「長さ情報」が入っている位置
    ''' </param>
    ''' <param name="intInforLength">
    ''' 「長さ情報」の桁数(16進数)
    ''' </param>
    ''' <param name="intHeaderLength">
    ''' ﾍｯﾀﾞｰ部分の桁数
    ''' </param>
    ''' <returns>
    ''' ｽﾀｰﾄﾃｷｽﾄとｴﾝﾄﾞﾃｷｽﾄから判断して取得したﾃｷｽﾄ
    ''' </returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************

    Public Function GetTelegramDataLength02(ByRef strString As String _
                                          , ByVal intInforStartPosition As Integer _
                                          , ByVal intInforLength As Integer _
                                          , ByVal intHeaderLength As Integer _
                                          ) As String
        Dim strMessage As String            'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
        Try
            Dim strReturn As String = ""        '関数戻値


            '**************************************************
            'ﾁｪｯｸ
            '**************************************************
            If IsNull(strString) Then Return strReturn
            Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString(strString))
            If GET_BYTE_LENGTH_STRING(strString) < intInforStartPosition + intInforLength Then Return strReturn


            '*****************************************************
            'ﾃﾞｰﾀ部長       取得
            '*****************************************************
            Dim strDataLength As String = MID_SJIS(strString, intInforStartPosition, intInforLength)        'ﾃﾞｰﾀ部長
            Dim intDataLength As Integer = Change16To10(strDataLength)                                      'ﾃﾞｰﾀ部長
            If GET_BYTE_LENGTH_STRING(strString) < intHeaderLength + intDataLength Then Return strReturn


            '*****************************************************
            '正常なﾃﾞｰﾀを取得
            '*****************************************************
            '====================================
            '電文取得
            '====================================
            strReturn = MID_SJIS(strString, 1, intHeaderLength + intDataLength)

            '====================================
            'ﾊﾞｯﾌｧを更新
            '====================================
            If IsNumeric(strDataLength) Then
                strString = MID_SJIS(strString _
                                   , intHeaderLength + intDataLength + 1 _
                                   , _
                                   )
            Else
                strString = ""
            End If


            Return strReturn
        Catch ex As Exception
            Call ComError(ex)
            strString = ""      '永遠にﾙｰﾌﾟするので、初期化
            Throw ex

        Finally

            'ﾛｸﾞ出力
            strMessage = ""
            strMessage &= MSG_603
            strMessage &= mobjASCII.GetLogString(strString)
            Call AddToDebugLog(strMessage)

        End Try
    End Function
#End Region

    'ある指定された固定長で電文を受信するﾊﾟﾀｰﾝ
#Region "  電文取得                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ある指定された固定長で電文を受信するﾊﾟﾀｰﾝ
    ''' </summary>
    ''' <param name="strString">
    ''' 元となるﾃｷｽﾄ。
    ''' ﾃｷｽﾄを取得出来た場合、取得したﾃｷｽﾄを削除した値が返る。
    ''' </param>
    ''' <param name="intLength">
    ''' 取得する長さ
    ''' </param>
    ''' <returns>
    '''判断して取得したﾃｷｽﾄ
    ''' </returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetTelegramDataLength03(ByRef strString As String _
                                          , ByVal intLength As Integer _
                                          ) As String
        Dim strMessage As String            'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
        Try
            Dim strReturn As String = ""        '関数戻値


            '**************************************************
            'ﾁｪｯｸ
            '**************************************************
            If IsNull(strString) Then Return strReturn
            Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString(strString))
            If GET_BYTE_LENGTH_STRING(strString) < intLength Then Return strReturn


            '*****************************************************
            '正常なﾃﾞｰﾀを取得
            '*****************************************************
            '====================================
            '電文取得
            '====================================
            strReturn = MID_SJIS(strString, 1, intLength)

            '====================================
            'ﾊﾞｯﾌｧを更新
            '====================================
            strString = MID_SJIS(strString, intLength + 1)


            Return strReturn
        Catch ex As Exception
            Call ComError(ex)
            strString = ""      '永遠にﾙｰﾌﾟするので、初期化
            Throw ex

        Finally

            'ﾛｸﾞ出力
            strMessage = ""
            strMessage &= MSG_603
            strMessage &= mobjASCII.GetLogString(strString)
            Call AddToDebugLog(strMessage)

        End Try
    End Function
#End Region


#Region "  電文取得(ﾊﾟﾀｰﾝ101)(車輌ｺﾝﾄﾛｰﾗ用)         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文取得
    ''' </summary>
    ''' <param name="bytString">
    ''' 元となるﾃｷｽﾄ。
    ''' ﾃｷｽﾄを取得出来た場合、取得したﾃｷｽﾄを削除した値が返る。
    ''' </param>
    ''' <param name="strFDENBUN_PRM1">
    ''' 電文ﾊﾟﾗﾒｰﾀ1
    ''' </param>
    ''' <returns>
    ''' 取得したﾃｷｽﾄ
    ''' </returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetTelegramDataLength101(ByRef bytString() As Byte _
                                           , ByRef strFDENBUN_PRM1 As String _
                                           , ByRef strFDENBUN_PRM2 As String _
                                           ) _
                                           As String
        'Dim strMessage As String            'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
        Try
            Dim strReturn As String = ""        '関数戻値


            '**************************************************
            'ﾁｪｯｸ
            '**************************************************
            If IsNull(bytString) Then Return strReturn
            'Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString16(bytString))


            '*****************************************************
            '電文ﾊﾟﾗﾒｰﾀ1        取得
            '*****************************************************
            'Dim bytTemp01() As Byte = {bytString(10), bytString(11), bytString(12), bytString(13), bytString(14), bytString(15)}
            'Dim bytTemp02() As Byte = {bytString(8), bytString(9)}
            Dim bytTemp01() As Byte = {bytString(6), bytString(7), bytString(8), bytString(9), bytString(10), bytString(11)}
            Dim bytTemp02() As Byte = {bytString(4), bytString(5)}
            strFDENBUN_PRM1 = Text.Encoding.GetEncoding(20290).GetString(bytTemp01)       'IBM EBCDIC (日本語カタカナ)        でｴﾝｺｰﾄﾞ
            strFDENBUN_PRM2 = Text.Encoding.GetEncoding(20290).GetString(bytTemp02)       'IBM EBCDIC (日本語カタカナ)        でｴﾝｺｰﾄﾞ


            '*****************************************************
            '電文
            '*****************************************************
            strReturn = mobjASCII.GetLogString16(bytString)


            '*****************************************************
            'ﾊﾞｯﾌｧを更新
            '*****************************************************
            bytString = Nothing


            Return strReturn
        Catch ex As Exception
            Call ComError(ex)
            bytString = Nothing      '永遠にﾙｰﾌﾟするので、初期化
            Throw ex

        Finally

            ''ﾛｸﾞ出力
            'strMessage = ""
            'strMessage &= MSG_603
            'If IsNotNull(bytString) Then strMessage &= mobjASCII.GetLogString(Text.Encoding.GetEncoding(0).GetString(bytString))
            'Call AddToDebugLog(strMessage)

        End Try
    End Function
    'Public Function GetTelegramDataLength101(ByRef bytString() As Byte _
    '                                       , ByRef strFDENBUN_PRM1 As String _
    '                                       , ByRef strFDENBUN_PRM2 As String _
    '                                       ) _
    '                                       As String
    '    Dim strMessage As String            'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
    '    Try
    '        Dim strReturn As String = ""        '関数戻値


    '        '**************************************************
    '        'ﾁｪｯｸ
    '        '**************************************************
    '        If IsNull(bytString) Then Return strReturn
    '        Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString16(bytString))
    '        If bytString.Length < 82 Then Return strReturn


    '        '*****************************************************
    '        '電文ﾊﾟﾗﾒｰﾀ1        取得
    '        '*****************************************************
    '        Dim bytTemp01() As Byte = {bytString(22), bytString(23), bytString(24), bytString(25), bytString(26), bytString(27)}
    '        Dim bytTemp02() As Byte = {bytString(20), bytString(21)}
    '        strFDENBUN_PRM1 = Text.Encoding.GetEncoding(20290).GetString(bytTemp01)       'IBM EBCDIC (日本語カタカナ)        でｴﾝｺｰﾄﾞ
    '        'strFDENBUN_PRM1 = Text.Encoding.GetEncoding(500).GetString(bytTemp)       'IBM EBCDIC (インターナショナル)     でｴﾝｺｰﾄﾞ
    '        strFDENBUN_PRM2 = Text.Encoding.GetEncoding(20290).GetString(bytTemp02)       'IBM EBCDIC (日本語カタカナ)        でｴﾝｺｰﾄﾞ


    '        '*****************************************************
    '        '電文
    '        '*****************************************************
    '        strReturn = mobjASCII.GetLogString16(bytString)


    '        '*****************************************************
    '        'ﾊﾞｯﾌｧを更新
    '        '*****************************************************
    '        bytString = Nothing


    '        Return strReturn
    '    Catch ex As Exception
    '        Call ComError(ex)
    '        bytString = Nothing      '永遠にﾙｰﾌﾟするので、初期化
    '        Throw ex

    '    Finally

    '        'ﾛｸﾞ出力
    '        strMessage = ""
    '        strMessage &= MSG_603
    '        If IsNotNull(bytString) Then strMessage &= mobjASCII.GetLogString(Text.Encoding.GetEncoding(0).GetString(bytString))
    '        Call AddToDebugLog(strMessage)

    '    End Try
    'End Function
#End Region


#Region "  ｴﾗｰ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub ComError(ByVal objException As Exception)


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


    End Sub
#End Region
#Region "  ﾛｸﾞ書き込み処理                  "
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
#Region "  ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToDebugLog(ByVal strMsg_1 As String)

        If intDebugFlag = 1 Then
            mobjOwner.AddToLog(strMsg_1)
        End If

    End Sub
#End Region

End Class
