'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【機能】ASCIIｺｰﾄﾞ文字ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Public Class clsASCII

#Region "  共通変数         "

    'ASCIIｺｰﾄﾞ
    Private Const mintNUL As Integer = 0        'null文字
    Private Const mintSOH As Integer = 1        'ヘッダ開始
    Private Const mintSTX As Integer = 2        'テキスト開始
    Private Const mintETX As Integer = 3        'テキスト終了
    Private Const mintEOT As Integer = 4        '転送終了
    Private Const mintENQ As Integer = 5        '照会
    Private Const mintACK As Integer = 6        '受信確認
    Private Const mintBEL As Integer = 7        '警告
    Private Const mintBS As Integer = 8         '後退
    Private Const mintHT As Integer = 9         '水平タブ
    Private Const mintLF As Integer = 10        '改行
    Private Const mintVT As Integer = 11        '垂直タブ
    Private Const mintFF As Integer = 12        '改頁
    Private Const mintCR As Integer = 13        '復帰
    Private Const mintSO As Integer = 14        'シフトアウト
    Private Const mintSI As Integer = 15        'シフトイン
    Private Const mintDLE As Integer = 16       'データリンクエスケー プ
    Private Const mintDC1 As Integer = 17       '装置制御１
    Private Const mintDC2 As Integer = 18       '装置制御２
    Private Const mintDC3 As Integer = 19       '装置制御３
    Private Const mintDC4 As Integer = 20       '装置制御４
    Private Const mintNAK As Integer = 21       '受信失敗
    Private Const mintSYN As Integer = 22       '同期
    Private Const mintETB As Integer = 23       '転送ブロック終了
    Private Const mintCAN As Integer = 24       'キャンセル
    Private Const mintEM As Integer = 25        'メディア終了
    Private Const mintSUB As Integer = 26       '置換
    Private Const mintESC As Integer = 27       'エスケープ
    Private Const mintFS As Integer = 28        'フォーム区切り
    Private Const mintGS As Integer = 29        'グループ区切り
    Private Const mintRS As Integer = 30        'レコード区切り
    Private Const mintUS As Integer = 31        'ユニット区切り
    Private Const mintSPC As Integer = 32       '空白文字
    Private Const mintDEL As Integer = 127      '削除

    '置換用文字列
    Private Const mstrDspNUL As String = "[NUL]"        'null文字
    Private Const mstrDspSOH As String = "[SOH]"        'ヘッダ開始
    Private Const mstrDspSTX As String = "[STX]"        'テキスト開始
    Private Const mstrDspETX As String = "[ETX]"        'テキスト終了
    Private Const mstrDspEOT As String = "[EOT]"        '転送終了
    Private Const mstrDspENQ As String = "[ENQ]"        '照会
    Private Const mstrDspACK As String = "[ACK]"        '受信確認
    Private Const mstrDspBEL As String = "[BEL]"        '警告
    Private Const mstrDspBS As String = "[BS]"          '後退
    Private Const mstrDspHT As String = "[HT]"          '水平タブ
    Private Const mstrDspLF As String = "[LF]"          '改行
    Private Const mstrDspVT As String = "[VT]"          '垂直タブ
    Private Const mstrDspFF As String = "[FF]"          '改頁
    Private Const mstrDspCR As String = "[CR]"          '復帰
    Private Const mstrDspSO As String = "[SO]"          'シフトアウト
    Private Const mstrDspSI As String = "[SI]"          'シフトイン
    Private Const mstrDspDLE As String = "[DLE]"        'データリンクエスケー プ
    Private Const mstrDspDC1 As String = "[DC1]"        '装置制御１
    Private Const mstrDspDC2 As String = "[DC2]"        '装置制御２
    Private Const mstrDspDC3 As String = "[DC3]"        '装置制御３
    Private Const mstrDspDC4 As String = "[DC4]"        '装置制御４
    Private Const mstrDspNAK As String = "[NAK]"        '受信失敗
    Private Const mstrDspSYN As String = "[SYN]"        '同期
    Private Const mstrDspETB As String = "[ETB]"        '転送ブロック終了
    Private Const mstrDspCAN As String = "[CAN]"        'キャンセル
    Private Const mstrDspEM As String = "[EM]"          'メディア終了
    Private Const mstrDspSUB As String = "[SUB]"        '置換
    Private Const mstrDspESC As String = "[ESC]"        'エスケープ
    Private Const mstrDspFS As String = "[FS]"          'フォーム区切り
    Private Const mstrDspGS As String = "[GS]"          'グループ区切り
    Private Const mstrDspRS As String = "[RS]"          'レコード区切り
    Private Const mstrDspUS As String = "[US]"          'ユニット区切り
    Private Const mstrDspSPC As String = "[SPC]"        '空白文字
    Private Const mstrDspDEL As String = "[DEL]"        '削除

    'ﾌﾟﾛﾊﾟﾃｨ変数
    Private mstrNUL As String                   'null文字
    Private mstrSOH As String                   'ヘッダ開始
    Private mstrSTX As String                   'テキスト開始
    Private mstrETX As String                   'テキスト終了
    Private mstrEOT As String                   '転送終了
    Private mstrENQ As String                   '照会
    Private mstrACK As String                   '受信確認
    Private mstrBEL As String                   '警告
    Private mstrBS As String                    '後退
    Private mstrHT As String                    '水平タブ
    Private mstrLF As String                    '改行
    Private mstrVT As String                    '垂直タブ
    Private mstrFF As String                    '改頁
    Private mstrCR As String                    '復帰
    Private mstrSO As String                    'シフトアウト
    Private mstrSI As String                    'シフトイン
    Private mstrDLE As String                   'データリンクエスケー プ
    Private mstrDC1 As String                   '装置制御１
    Private mstrDC2 As String                   '装置制御２
    Private mstrDC3 As String                   '装置制御３
    Private mstrDC4 As String                   '装置制御４
    Private mstrNAK As String                   '受信失敗
    Private mstrSYN As String                   '同期
    Private mstrETB As String                   '転送ブロック終了
    Private mstrCAN As String                   'キャンセル
    Private mstrEM As String                    'メディア終了
    Private mstrSUB As String                   '置換
    Private mstrESC As String                   'エスケープ
    Private mstrFS As String                    'フォーム区切り
    Private mstrGS As String                    'グループ区切り
    Private mstrRS As String                    'レコード区切り
    Private mstrUS As String                    'ユニット区切り
    Private mstrSPC As String                   '空白文字
    Private mstrDEL As String                   '削除

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ          "
    Public Sub New()
        Try

            mstrNUL = CStr(Chr(mintNUL))            'null文字
            mstrSOH = CStr(Chr(mintSOH))            'ヘッダ開始
            mstrSTX = CStr(Chr(mintSTX))            'テキスト開始
            mstrETX = CStr(Chr(mintETX))            'テキスト終了
            mstrEOT = CStr(Chr(mintEOT))            '転送終了
            mstrENQ = CStr(Chr(mintENQ))            '照会
            mstrACK = CStr(Chr(mintACK))            '受信確認
            mstrBEL = CStr(Chr(mintBEL))            '警告
            mstrBS = CStr(Chr(mintBS))              '後退
            mstrHT = CStr(Chr(mintHT))              '水平タブ
            mstrLF = CStr(Chr(mintLF))              '改行
            mstrVT = CStr(Chr(mintVT))              '垂直タブ
            mstrFF = CStr(Chr(mintFF))              '改頁
            mstrCR = CStr(Chr(mintCR))              '復帰
            mstrSO = CStr(Chr(mintSO))              'シフトアウト
            mstrSI = CStr(Chr(mintSI))              'シフトイン
            mstrDLE = CStr(Chr(mintDLE))            'データリンクエスケー プ
            mstrDC1 = CStr(Chr(mintDC1))            '装置制御１
            mstrDC2 = CStr(Chr(mintDC2))            '装置制御２
            mstrDC3 = CStr(Chr(mintDC3))            '装置制御３
            mstrDC4 = CStr(Chr(mintDC4))            '装置制御４
            mstrNAK = CStr(Chr(mintNAK))            '受信失敗
            mstrSYN = CStr(Chr(mintSYN))            '同期
            mstrETB = CStr(Chr(mintETB))            '転送ブロック終了
            mstrCAN = CStr(Chr(mintCAN))            'キャンセル
            mstrEM = CStr(Chr(mintEM))              'メディア終了
            mstrSUB = CStr(Chr(mintSUB))            '置換
            mstrESC = CStr(Chr(mintESC))            'エスケープ
            mstrFS = CStr(Chr(mintFS))              'フォーム区切り
            mstrGS = CStr(Chr(mintGS))              'グループ区切り
            mstrRS = CStr(Chr(mintRS))              'レコード区切り
            mstrUS = CStr(Chr(mintUS))              'ユニット区切り
            mstrSPC = CStr(Chr(mintSPC))            '空白文字
            mstrDEL = CStr(Chr(mintDEL))            '削除

        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ          "
    ''' =======================================
    ''' <summary>null文字</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strNUL() As String
        Get
            Return mstrNUL
        End Get
    End Property
    ''' =======================================
    ''' <summary>ヘッダ開始</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strSOH() As String
        Get
            Return mstrSOH
        End Get
    End Property
    ''' =======================================
    ''' <summary>テキスト開始</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strSTX() As String
        Get
            Return mstrSTX
        End Get
    End Property
    ''' =======================================
    ''' <summary>テキスト終了</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strETX() As String
        Get
            Return mstrETX
        End Get
    End Property
    ''' =======================================
    ''' <summary>転送終了</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strEOT() As String
        Get
            Return mstrEOT
        End Get
    End Property
    ''' =======================================
    ''' <summary>照会</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strENQ() As String
        Get
            Return mstrENQ
        End Get
    End Property
    ''' =======================================
    ''' <summary>受信確認</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strACK() As String
        Get
            Return mstrACK
        End Get
    End Property
    ''' =======================================
    ''' <summary>警告</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strBEL() As String
        Get
            Return mstrBEL
        End Get
    End Property
    ''' =======================================
    ''' <summary>後退</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strBS() As String
        Get
            Return mstrBS
        End Get
    End Property
    ''' =======================================
    ''' <summary>水平タブ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strHT() As String
        Get
            Return mstrHT
        End Get
    End Property
    ''' =======================================
    ''' <summary>改行</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strLF() As String
        Get
            Return mstrLF
        End Get
    End Property
    ''' =======================================
    ''' <summary>垂直タブ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strVT() As String
        Get
            Return mstrVT
        End Get
    End Property
    ''' =======================================
    ''' <summary>改頁</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strFF() As String
        Get
            Return mstrFF
        End Get
    End Property
    ''' =======================================
    ''' <summary>復帰</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strCR() As String
        Get
            Return mstrCR
        End Get
    End Property
    ''' =======================================
    ''' <summary>シフトアウト</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strSO() As String
        Get
            Return mstrSO
        End Get
    End Property
    ''' =======================================
    ''' <summary>シフトイン</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strSI() As String
        Get
            Return mstrSI
        End Get
    End Property
    ''' =======================================
    ''' <summary>データリンクエスケー プ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strDLE() As String
        Get
            Return mstrDLE
        End Get
    End Property
    ''' =======================================
    ''' <summary>装置制御１</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strDC1() As String
        Get
            Return mstrDC1
        End Get
    End Property
    ''' =======================================
    ''' <summary>装置制御２</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strDC2() As String
        Get
            Return mstrDC2
        End Get
    End Property
    ''' =======================================
    ''' <summary>装置制御３</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strDC3() As String
        Get
            Return mstrDC3
        End Get
    End Property
    ''' =======================================
    ''' <summary>装置制御４</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strDC4() As String
        Get
            Return mstrDC4
        End Get
    End Property
    ''' =======================================
    ''' <summary>受信失敗</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strNAK() As String
        Get
            Return mstrNAK
        End Get
    End Property
    ''' =======================================
    ''' <summary>同期</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strSYN() As String
        Get
            Return mstrSYN
        End Get
    End Property
    ''' =======================================
    ''' <summary>転送ブロック終了</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strETB() As String
        Get
            Return mstrETB
        End Get
    End Property
    ''' =======================================
    ''' <summary>キャンセル</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strCAN() As String
        Get
            Return mstrCAN
        End Get
    End Property
    ''' =======================================
    ''' <summary>メディア終了</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strEM() As String
        Get
            Return mstrEM
        End Get
    End Property
    ''' =======================================
    ''' <summary>置換</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strSUB() As String
        Get
            Return mstrSUB
        End Get
    End Property
    ''' =======================================
    ''' <summary>エスケープ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strESC() As String
        Get
            Return mstrESC
        End Get
    End Property
    ''' =======================================
    ''' <summary>フォーム区切り</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strFS() As String
        Get
            Return mstrFS
        End Get
    End Property
    ''' =======================================
    ''' <summary>グループ区切り</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strGS() As String
        Get
            Return mstrGS
        End Get
    End Property
    ''' =======================================
    ''' <summary>レコード区切り</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strRS() As String
        Get
            Return mstrRS
        End Get
    End Property
    ''' =======================================
    ''' <summary>ユニット区切り</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strUS() As String
        Get
            Return mstrUS
        End Get
    End Property
    ''' =======================================
    ''' <summary>空白文字</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strSPC() As String
        Get
            Return mstrSPC
        End Get
    End Property
    ''' =======================================
    ''' <summary>削除</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strDEL() As String
        Get
            Return mstrDEL
        End Get
    End Property
#End Region
#Region "  ﾛｸﾞ用に変換      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字化けするASCII文字列を変換する
    ''' </summary>
    ''' <param name="strString">変換する文字列</param>
    ''' <returns>変換後の文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetLogString(ByVal strString As String) As String
        Try

            Dim strTemp As String       '作業用
            Dim strReturn As String     '関数戻値

            strTemp = strString
            strTemp = Replace(strTemp, mstrNUL, mstrDspNUL)             'null文字
            strTemp = Replace(strTemp, mstrSOH, mstrDspSOH)             'ヘッダ開始
            strTemp = Replace(strTemp, mstrSTX, mstrDspSTX)             'テキスト開始
            strTemp = Replace(strTemp, mstrETX, mstrDspETX)             'テキスト終了
            strTemp = Replace(strTemp, mstrEOT, mstrDspEOT)             '転送終了
            strTemp = Replace(strTemp, mstrENQ, mstrDspENQ)             '照会
            strTemp = Replace(strTemp, mstrACK, mstrDspACK)             '受信確認
            strTemp = Replace(strTemp, mstrBEL, mstrDspBEL)             '警告
            strTemp = Replace(strTemp, mstrBS, mstrDspBS)               '後退
            strTemp = Replace(strTemp, mstrHT, mstrDspHT)               '水平タブ
            strTemp = Replace(strTemp, mstrLF, mstrDspLF)               '改行
            strTemp = Replace(strTemp, mstrVT, mstrDspVT)               '垂直タブ
            strTemp = Replace(strTemp, mstrFF, mstrDspFF)               '改頁
            strTemp = Replace(strTemp, mstrCR, mstrDspCR)               '復帰
            strTemp = Replace(strTemp, mstrSO, mstrDspSO)               'シフトアウト
            strTemp = Replace(strTemp, mstrSI, mstrDspSI)               'シフトイン
            strTemp = Replace(strTemp, mstrDLE, mstrDspDLE)             'データリンクエスケー プ
            strTemp = Replace(strTemp, mstrDC1, mstrDspDC1)             '装置制御１
            strTemp = Replace(strTemp, mstrDC2, mstrDspDC2)             '装置制御２
            strTemp = Replace(strTemp, mstrDC3, mstrDspDC3)             '装置制御３
            strTemp = Replace(strTemp, mstrDC4, mstrDspDC4)             '装置制御４
            strTemp = Replace(strTemp, mstrNAK, mstrDspNAK)             '受信失敗
            strTemp = Replace(strTemp, mstrSYN, mstrDspSYN)             '同期
            strTemp = Replace(strTemp, mstrETB, mstrDspETB)             '転送ブロック終了
            strTemp = Replace(strTemp, mstrCAN, mstrDspCAN)             'キャンセル
            strTemp = Replace(strTemp, mstrEM, mstrDspEM)               'メディア終了
            strTemp = Replace(strTemp, mstrSUB, mstrDspSUB)             '置換
            strTemp = Replace(strTemp, mstrESC, mstrDspESC)             'エスケープ
            strTemp = Replace(strTemp, mstrFS, mstrDspFS)               'フォーム区切り
            strTemp = Replace(strTemp, mstrGS, mstrDspGS)               'グループ区切り
            strTemp = Replace(strTemp, mstrRS, mstrDspRS)               'レコード区切り
            strTemp = Replace(strTemp, mstrUS, mstrDspUS)               'ユニット区切り
            strTemp = Replace(strTemp, mstrSPC, mstrDspSPC)             '空白文字
            strTemp = Replace(strTemp, mstrDEL, mstrDspDEL)             '削除
            strReturn = strTemp


            Return strReturn
        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region
#Region "  ﾛｸﾞ用に変換(ﾊﾞｲﾅﾘ)10進数     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ用に変換(ﾊﾞｲﾅﾘ)10進数
    ''' </summary>
    ''' <param name="bytString">変換する文字列配列</param>
    ''' <returns>変換後の文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetLogString10(ByVal bytString() As Byte _
                                 , Optional ByVal strDelimiter As String = "_" _
                                 ) _
                                 As String
        Try

            Dim strTemp As String = ""      '作業用
            Dim strReturn As String         '関数戻値

            For ii As Integer = 0 To UBound(bytString)
                '(ﾙｰﾌﾟ:文字列配列数)

                If ii = 0 Then
                    strTemp = ZERO_PAD(bytString(ii), 3)
                Else
                    strTemp &= strDelimiter & ZERO_PAD(bytString(ii), 3)
                End If

            Next
            strReturn = strTemp


            Return strReturn
        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region
#Region "  ﾛｸﾞ用に変換(ﾊﾞｲﾅﾘ)16進数     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ用に変換(ﾊﾞｲﾅﾘ)16進数
    ''' </summary>
    ''' <param name="bytString">変換する文字列配列</param>
    ''' <returns>変換後の文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetLogString16(ByVal bytString() As Byte _
                                 , Optional ByVal strDelimiter As String = "_" _
                                 ) _
                                 As String
        Try

            Dim strTemp As String = ""      '作業用
            Dim strReturn As String         '関数戻値

            For ii As Integer = 0 To UBound(bytString)
                '(ﾙｰﾌﾟ:文字列配列数)

                If ii = 0 Then
                    strTemp = Change10To16(bytString(ii), 3)
                Else
                    strTemp &= strDelimiter & Change10To16(bytString(ii), 3)
                End If

            Next
            strReturn = strTemp


            Return strReturn
        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region

End Class
