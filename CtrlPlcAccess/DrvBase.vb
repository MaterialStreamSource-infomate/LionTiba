'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ 接続基本 ｸﾗｽ
' 【作成】2005/11/08　KSH/S.Ouchi　Rev 0.00　初版
'**********************************************************************************************

Imports System.Text
Imports System.IO.Ports

Public MustInherit Class DrvBase


#Region "共通変数"
    '==================================================
    '共通ｺｰﾄﾞ
    '==================================================
    Public Enum RetCode
        OK        '正常
        NG        '異常
        OTHER     'その他(受信中など)
    End Enum

    Public Enum CheckSumPosition
        BeforeETX   'ETXの前
        AfterETX    'ETXの後
    End Enum

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Protected mblnSendStx As Boolean                  'ﾃｷｽﾄ開始文字送信有無ﾌﾗｸﾞ
    Protected mblnSendEtx As Boolean                  'ﾃｷｽﾄ終了文字送信有無ﾌﾗｸﾞ
    Protected mblnSendEnq As Boolean                  '照会文字送信有無ﾌﾗｸﾞ
    Protected mblnSendCr As Boolean                   'ﾃｷｽﾄ終端文字送信有無ﾌﾗｸﾞ
    Protected mblnSendLf As Boolean                   'ﾃｷｽﾄ終端文字送信有無ﾌﾗｸﾞ
    Protected mblnSendSum As Boolean                  'ﾁｪｯｸｻﾑ送信有無ﾌﾗｸﾞ
    Protected mintChSmPs As CheckSumPosition          'ﾁｪｯｸｻﾑの位置

    'その他
    Protected mintCodePage As Integer                 '通信に使用するﾃｷｽﾄのｺｰﾄﾞ

    '==================================================
    'その他
    '==================================================
    '制御文字
    Protected Const STX As Integer = &H2              '(数値型) ﾃｷｽﾄ開始
    Protected Const ETX As Integer = &H3              '(数値型) ﾃｷｽﾄ終了
    Protected Const ENQ As Integer = &H5              '(数値型) 照会
    Protected Const ACK As Integer = &H6              '(数値型) 受信確認
    Protected Const NAK As Integer = &H15             '(数値型) 受信失敗
    Protected CR As String = Chr(&HD).ToString    '改行コード CR
    Protected LF As String = Chr(&HA).ToString    '改行コード LF

    '制御文字（文字列に変換）
    Protected mstrSTX As String                         '(文字型) ﾃｷｽﾄ開始
    Protected mstrETX As String                         '(文字型) ﾃｷｽﾄ終了
    Protected mstrENQ As String                         '(文字型) 照会
    Protected mstrACK As String                         '(文字型) 受信確認
    Protected mstrNAK As String                         '(文字型) 受信失敗
    Protected mbytSTX() As Byte                         '(文字型) ﾃｷｽﾄ開始
    Protected mbytETX() As Byte                         '(文字型) ﾃｷｽﾄ終了
    Protected mbytENQ() As Byte                         '(文字型) 照会
    Protected mbytACK() As Byte                         '(文字型) 受信確認
    Protected mbytNAK() As Byte                         '(文字型) 受信失敗

    '表示用
    Protected Const strSTXDisp As String = "[STX]"    '(文字型) ﾃｷｽﾄ開始
    Protected Const strETXDisp As String = "[ETX]"    '(文字型) ﾃｷｽﾄ終了
    Protected Const strENQDisp As String = "[ENQ]"    '(文字型) 照会
    Protected Const strACKDisp As String = "[ACK]"    '(文字型) 受信確認
    Protected Const strNAKDisp As String = "[NAK]"    '(文字型) 受信失敗
    Protected Const strCRDisp As String = "[CR]"      '(文字型) 改行コード CR
    Protected Const strLFDisp As String = "[LF]"      '(文字型) 改行コード LF

#End Region

#Region "ﾌﾟﾛﾊﾟﾃｨ"
    '===================================================
    'ﾃｷｽﾄ開始文字送信有無ﾌﾗｸﾞ
    '===================================================
    Public Property SEND_STX() As Boolean
        Get
            Return mblnSendStx
        End Get
        Set(ByVal value As Boolean)
            mblnSendStx = value
        End Set
    End Property

    '===================================================
    'ﾃｷｽﾄ終了文字送信有無ﾌﾗｸﾞ
    '===================================================
    Public Property SEND_ETX() As Boolean
        Get
            Return mblnSendEtx
        End Get
        Set(ByVal value As Boolean)
            mblnSendEtx = value
        End Set
    End Property

    '===================================================
    '照会文字送信有無ﾌﾗｸﾞ
    '===================================================
    Public Property SEND_ENQ() As Boolean
        Get
            Return mblnSendEnq
        End Get
        Set(ByVal value As Boolean)
            mblnSendEnq = value
        End Set
    End Property

    '===================================================
    'ﾃｷｽﾄ終端文字送信有無ﾌﾗｸﾞ
    '===================================================
    Public Property SEND_CR() As Boolean
        Get
            Return mblnSendCr
        End Get
        Set(ByVal value As Boolean)
            mblnSendCr = value
        End Set
    End Property

    '===================================================
    'ﾃｷｽﾄ終端文字送信有無ﾌﾗｸﾞ
    '===================================================
    Public Property SEND_LF() As Boolean
        Get
            Return mblnSendLf
        End Get
        Set(ByVal value As Boolean)
            mblnSendLf = value
        End Set
    End Property

    '===================================================
    'ﾁｪｯｸｻﾑ送信有無ﾌﾗｸﾞ
    '===================================================
    Public Property SEND_SUM() As Boolean
        Get
            Return mblnSendSum
        End Get
        Set(ByVal value As Boolean)
            mblnSendSum = value
        End Set
    End Property

    '===================================================
    'ﾁｪｯｸｻﾑの位置
    '===================================================
    Public Property CHECK_SUM_POSITION() As CheckSumPosition
        Get
            Return mintChSmPs
        End Get
        Set(ByVal value As CheckSumPosition)
            mintChSmPs = value
        End Set
    End Property

#End Region

#Region "初期/終了 処理"
    '==========================================================
    '【機能】コンストラクタ
    '==========================================================
    Public Sub New()
        MyBase.New()

        '*****************************************************
        'ETX、STX設定
        '*****************************************************
        mbytSTX = Text.Encoding.GetEncoding(mintCodePage).GetBytes(Chr(STX)) '(文字型) ﾃｷｽﾄ開始
        mbytETX = Text.Encoding.GetEncoding(mintCodePage).GetBytes(Chr(ETX)) '(文字型) ﾃｷｽﾄ終了
        mbytENQ = Text.Encoding.GetEncoding(mintCodePage).GetBytes(Chr(ENQ)) '(文字型) 照会
        mbytACK = Text.Encoding.GetEncoding(mintCodePage).GetBytes(Chr(ACK)) '(文字型) 受信確認
        mbytNAK = Text.Encoding.GetEncoding(mintCodePage).GetBytes(Chr(NAK)) '(文字型) 受信失敗
        mstrSTX = Text.Encoding.GetEncoding(mintCodePage).GetString(mbytSTX)  '(文字型) ﾃｷｽﾄ開始
        mstrETX = Text.Encoding.GetEncoding(mintCodePage).GetString(mbytETX)  '(文字型) ﾃｷｽﾄ終了
        mstrENQ = Text.Encoding.GetEncoding(mintCodePage).GetString(mbytENQ)  '(文字型) 照会
        mstrACK = Text.Encoding.GetEncoding(mintCodePage).GetString(mbytACK)  '(文字型) 受信確認
        mstrNAK = Text.Encoding.GetEncoding(mintCodePage).GetString(mbytNAK)  '(文字型) 受信失敗

        mblnSendStx = True      'ﾃｷｽﾄ開始文字送信有無ﾌﾗｸﾞ
        mblnSendEtx = True      'ﾃｷｽﾄ終了文字送信有無ﾌﾗｸﾞ
        mblnSendEnq = False     '照会文字送信有無ﾌﾗｸﾞ
        mblnSendCr = True       'ﾃｷｽﾄ終端文字送信有無ﾌﾗｸﾞ
        mblnSendLf = False      'ﾃｷｽﾄ終端文字送信有無ﾌﾗｸﾞ
        mblnSendSum = False     'ﾁｪｯｸｻﾑ送信有無ﾌﾗｸﾞ

        'ﾁｪｯｸｻﾑの位置
        mintChSmPs = CheckSumPosition.BeforeETX     'ETXの前

    End Sub

    '==========================================================
    '【機能】デストラクタ
    '==========================================================
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "仮想関数"
    '==========================================================
    '【機能】仮想関数
    '【機能】メッセージ送信処理
    '【引数】送信コマンド	:	String	SendTX
    '【戻値】返答テキスト	:	String
    '==========================================================
    Public MustOverride Function SendMsg(ByVal SendTX As String) As String

#End Region

#Region "ﾊﾞｲﾄ配列 → 文字列"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]bytData()        ：変換するﾊﾞｲﾄ配列
    '【戻値】変換した文字列
    '*******************************************************************************************************************
    Public Function ByteToString(ByVal bytData() As Byte) As String
        Dim strRet As String

        strRet = Text.Encoding.GetEncoding(mintCodePage).GetString(bytData, 0, bytData.Length)
        ''strRet = Replace(strRet, strSTX, strSTXDisp)
        ''strRet = Replace(strRet, strETX, strETXDisp)


        Return (strRet)
    End Function
#End Region

#Region "文字列 → ﾊﾞｲﾄ配列"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]strData          ：変換する文字列
    '【戻値】変換したﾊﾞｲﾄ配列
    '*******************************************************************************************************************
    Public Function StringToByte(ByVal strData As String) As Byte()

        Dim bytRet() As Byte
        bytRet = Text.Encoding.GetEncoding(mintCodePage).GetBytes(strData)


        Return (bytRet)
    End Function
#End Region

#Region "16進数→10進数"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 16進数→10進数
    ''' </summary>
    ''' <param name="strValue16">16進数</param>
    ''' <returns>変換値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Change16To10(ByVal strValue16 As String) As Integer
        Try
            Dim strMsg As String

            '************************
            '16進数→10進数
            '************************
            Dim intValue10 As Integer
            If IsNothing(strValue16) = True Then strValue16 = "0"
            If strValue16 = "" Then strValue16 = "0"
            Try
                intValue10 = Convert.ToInt32(strValue16, 16)
            Catch ex As Exception
                strMsg = "ﾊﾟﾗﾒｰﾀが不正です。[16進数がIntegerの範囲を超えています。]"
                Throw New Exception(strMsg)
            End Try


            Return (intValue10)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "文字列のﾊﾞｲﾄ数取得(SJIS用)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字列ｽﾍﾟｰｽ詰め(SJIS用)
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <returns>文字列のﾊﾞｲﾄ数</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GET_BYTE_LENGTH_STRING(ByVal strMsg As String) As Integer
        Dim intRet As Integer = 0           '戻値

        Dim bytWork() As Byte = System.Text.Encoding.GetEncoding(932).GetBytes(strMsg)
        intRet = UBound(bytWork) + 1

        Return intRet
    End Function
#End Region

#Region "ｵﾌﾞｼﾞｪｸﾄを文字列に変換"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾌﾞｼﾞｪｸﾄを文字列に変換
    ''' </summary>
    ''' <param name="objString">文字列ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>文字列変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function TO_STRING(ByVal objString As Object) As String
        Try
            Dim strRet As String = Nothing
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then

                strRet = CStr(objString)

            End If
            Return strRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
    '' ''Public Function TO_STRING(ByVal objString As Object) As String
    '' ''    Try
    '' ''        Dim strRet As String = ""
    '' ''        If (Not objString Is Nothing) And _
    '' ''           (Not IsDBNull(objString)) Then
    '' ''            strRet = CStr(objString)
    '' ''        End If
    '' ''        Return strRet
    '' ''    Catch ex As Exception
    '' ''        Throw New System.Exception(ex.Message)
    '' ''    End Try
    '' ''End Function
    Public Function TO_STRING_NULLABLE(ByVal objString As Object) As String
        Try
            Dim strRet As String = Nothing
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then

                strRet = CStr(objString)

            End If
            Return strRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

#Region "ｵﾌﾞｼﾞｪｸﾄを数値に変換"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾌﾞｼﾞｪｸﾄを数値に変換
    ''' </summary>
    ''' <param name="objString">文字列ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>数値変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function TO_NUMBER(ByVal objString As Object) As Decimal
        Try
            Dim dblRet As Decimal = 0
            If (Not objString Is Nothing) _
               And (CStr(objString) <> "") _
               And (Not IsDBNull(objString)) _
               Then
                dblRet = CDec(CStr(objString))
            End If
            Return dblRet

        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

#Region "ｵﾌﾞｼﾞｪｸﾄを数値(INTEGER)に変換"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾌﾞｼﾞｪｸﾄを数値に変換
    ''' </summary>
    ''' <param name="objString">文字列ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>数値変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function TO_INTEGER(ByVal objString As Object) As Integer
        Try
            Dim intRet As Integer = 0
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then
                intRet = Val(CStr(objString))
            End If
            Return intRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
    Public Function TO_INTEGER_NULLABLE(ByVal objString As Object) As Nullable(Of Integer)
        Try
            Dim intRet As Nullable(Of Integer) = Nothing
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then

                If CStr(objString) <> "" Then
                    intRet = Val(CStr(objString))
                End If

            End If
            Return intRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

#Region "ﾁｪｯｸｻﾑ作成"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]bytData()          ：ﾁｪｯｸｻﾑを作成する文字列
    '【戻値】変換したﾊﾞｲﾄ配列
    '*******************************************************************************************************************
    Public Function CreateChckSum(ByVal bytData() As Byte) As Byte()
        Dim bytChckSum() As Byte

        Dim int10Sin As Integer = 0     '10進数
        Dim str16Sin As String = "0"    '16進数

        For ii As Integer = 0 To UBound(bytData)
            '(配列分ﾙｰﾌﾟ)
            int10Sin = int10Sin + CInt(bytData(ii))      'すべてのデータを加算
        Next

        str16Sin = Hex(int10Sin)         '16進に変換

        Dim strChckSum_16 As String = Right("0000" & str16Sin, 2)       '(ﾁｪｯｸｻﾑ16進)合計値から1ﾊﾞｲﾄ分取得
        bytChckSum = StringToByte(strChckSum_16)                        '文字列ﾊﾞｲﾄ変換

        Return (bytChckSum)


    End Function

#End Region

End Class
