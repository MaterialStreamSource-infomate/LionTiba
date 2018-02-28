'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】共通関数ﾓｼﾞｭｰﾙ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System.Text
#End Region

Public Module mdlComFunc

#Region "  ｵﾌﾞｼﾞｪｸﾄを文字列に変換           (Public  TO_STRING)"
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
#Region "  ｵﾌﾞｼﾞｪｸﾄを数値に変換             (Public  TO_NUMBER)"
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
#Region "  ｵﾌﾞｼﾞｪｸﾄを数値(INTEGER)に変換    (Public  TO_INTEGER)"
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
#Region "  ｵﾌﾞｼﾞｪｸﾄを数値(LONG)に変換       (Public  TO_LONG)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾌﾞｼﾞｪｸﾄを数値に変換
    ''' </summary>
    ''' <param name="objString">文字列ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>数値変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function TO_LONG(ByVal objString As Object) As Long
        Try
            Dim lngRet As Long = 0
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then
                lngRet = Val(CStr(objString))
            End If
            Return lngRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ｵﾌﾞｼﾞｪｸﾄを数値(SHORT)に変換      (Public  TO_SHORT)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾌﾞｼﾞｪｸﾄを数値に変換
    ''' </summary>
    ''' <param name="objString">文字列ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>数値変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function TO_SHORT(ByVal objString As Object) As Short
        Try
            Dim shoRet As Short = 0
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then
                shoRet = Val(CStr(objString))
            End If
            Return shoRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ｵﾌﾞｼﾞｪｸﾄを数値(DECIMAL)に変換    (Public  TO_DECIMAL)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾌﾞｼﾞｪｸﾄを数値に変換
    ''' </summary>
    ''' <param name="objString">文字列ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>数値変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function TO_DECIMAL(ByVal objString As Object) As Decimal
        Try
            Dim dclRet As Decimal = 0
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then
                dclRet = Val(CStr(objString))
            End If
            Return dclRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
    Public Function TO_DECIMAL_NULLABLE(ByVal objString As Object) As Nullable(Of Decimal)
        Try
            Dim dclRet As Nullable(Of Decimal) = Nothing
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then

                If CStr(objString) <> "" Then
                    dclRet = Val(CStr(objString))
                End If

            End If
            Return dclRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ｵﾌﾞｼﾞｪｸﾄを日付に変換             (Public  TO_DATE)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾌﾞｼﾞｪｸﾄを日付に変換
    ''' </summary>
    ''' <param name="objString">文字列ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>日付変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function TO_DATE(ByVal objString As Object) As Date
        Try
            Dim dtmRet As Date
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then

                If CStr(objString) <> "" Then
                    dtmRet = CDate(CStr(objString))
                End If

            End If
            Return dtmRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
    Public Function TO_DATE_NULLABLE(ByVal objString As Object) As Nullable(Of Date)
        Try
            Dim dtmRet As Nullable(Of Date) = Nothing
            If (Not objString Is Nothing) And _
               (Not IsDBNull(objString)) Then

                If CStr(objString) <> "" Then
                    dtmRet = CDate(CStr(objString))
                End If

            End If
            Return dtmRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  Null判定                         (Public  IsNull)"
    '''****************************************************************************************************
    ''' <summary>
    ''' Null判定
    ''' </summary>
    ''' <param name="objObject">Null判定するｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>Null判定の場合True。NotNull判定の場合False</returns>
    ''' <remarks>IsNothing関数では""だとFalseとなるが、Trueとなる関数にした。</remarks>
    '''****************************************************************************************************
    Public Function IsNull(ByVal objObject As Object) As Boolean
        Try
            Dim blnRet As Boolean = False

            If IsNothing(objObject) = True Then
                blnRet = True
            Else
                If TypeName(objObject) = "String" Then
                    If objObject = "" Then
                        blnRet = True
                    End If
                End If
            End If

            Return blnRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

#Region "  文字列のﾊﾞｲﾄ数取得(SJIS用)       (Public  GET_BYTE_LENGTH_STRING)"
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
#Region "  文字列のﾊﾞｲﾄ数切出し(SJIS用)     (Public  MID_SJIS)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字列のﾊﾞｲﾄ数切出し(SJIS用)
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <param name="intPos">開始位置</param>
    ''' <param name="intLen">ﾊﾞｲﾄ数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function MID_SJIS(ByVal strMsg As String _
                           , ByVal intPos As Integer _
                           , Optional ByVal intLen As Integer = Integer.MaxValue _
                             ) _
                             As String
        Try
            Dim strRet As String
            Dim bytWork() As Byte = System.Text.Encoding.GetEncoding(932).GetBytes(strMsg)
            Dim bytRet() As Byte
            Dim intLenWk As Integer

            If bytWork.Length - intPos + 1 >= intLen Then
                ReDim bytRet(intLen - 1)
                Array.Copy(bytWork, intPos - 1, bytRet, 0, intLen)
                intLenWk = intLen
            ElseIf bytWork.Length - intPos + 1 <= 0 Then
                strRet = ""
                Return strRet
            Else
                intLenWk = bytWork.Length - intPos + 1
                ReDim bytRet(intLenWk - 1)
                Array.Copy(bytWork, intPos - 1, bytRet, 0, intLenWk)
            End If
            strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet) & ""


            'もう一度カウントする
            Dim intByteCnt2 As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)

            'もう一度カウントしたものが指定したﾊﾞｲﾄより大きい場合は、最後の文字が全角のため省く
            If intByteCnt2 > intLenWk Then
                ReDim bytRet(intLenWk - 2)
                '配列のコピー
                Array.Copy(bytWork, bytRet, intLenWk - 1)
                strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)
                Dim intByteCnt3 = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)
                'strRet = strRet & StrDup(intLenWk - intByteCnt3, " ")

            End If

            Return strRet

        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try

    End Function
#End Region
#Region "  文字列ｽﾍﾟｰｽ詰め(SJIS用)          (Public  SPC_PAD_SJIS)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字列ｽﾍﾟｰｽ詰め(SJIS用)
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <param name="intByte">ﾊﾞｲﾄ数</param>
    ''' <param name="intOpt">ｵﾌﾟｼｮﾝ(1:右詰,2:左詰)</param>
    ''' <returns>文字列変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SPC_PAD_SJIS(ByVal strMsg As String, ByVal intByte As Integer, ByVal intOpt As Integer) As String
        Dim strRet As String = ""

        '指定した文字列が空、ﾊﾞｲﾄ数が0のときは空文字を返す。
        If intByte = 0 Or strMsg.Length = 0 Then
            Return strRet
        End If

        Select Case intOpt
            Case 1
                '左詰
                strRet = SPC_PAD_LEFT_SJIS(strMsg, intByte)
            Case 2
                '右詰
                strRet = SPC_PAD_RIGHT_SJIS(strMsg, intByte)
        End Select
        Return strRet
    End Function
#End Region
#Region "  文字列左詰め(SJIS用)             (Public  SPC_PAD_LEFT_SJIS)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字列左詰め(SJIS用)
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <param name="intByte">ﾊﾞｲﾄ数</param>
    ''' <returns>文字列変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SPC_PAD_LEFT_SJIS(ByVal strMsg As String, ByVal intByte As Integer) As String
        Try
            Dim strRet As String = ""
            Dim intMojisu As Integer = strMsg.Length

            'strMsgをByte配列(SJIS)に変換
            Dim bytWork() As Byte = System.Text.Encoding.GetEncoding(932).GetBytes(strMsg)
            Dim intByteCnt As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strMsg)
            Dim bytRet() As Byte

            If intByte > intByteCnt Then
                ReDim bytRet(intByteCnt - 1)
                '配列のコピー
                Array.Copy(bytWork, bytRet, intByteCnt)
            Else
                ReDim bytRet(intByte - 1)
                '配列のコピー
                Array.Copy(bytWork, bytRet, intByte)
            End If

            strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)

            'もう一度カウントする
            Dim intByteCnt2 As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)

            'もう一度カウントしたものが指定したﾊﾞｲﾄより大きい場合は、最後の文字が全角のため省く
            If intByteCnt2 > intByte Then
                ReDim bytRet(intByte - 2)
                '配列のコピー
                Array.Copy(bytWork, bytRet, intByte - 1)
                strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)
                Dim intByteCnt3 = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)
                strRet = strRet & StrDup(intByte - intByteCnt3, " ")

            End If


            If intByte > intByteCnt Then
                strRet = strRet & StrDup(intByte - intByteCnt, " ")
            End If

            Return strRet

        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  文字列右詰め(SJIS用)             (Public  SPC_PAD_RIGHT_SJIS)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字列右詰め(SJIS用)
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <param name="intByte">ﾊﾞｲﾄ数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SPC_PAD_RIGHT_SJIS(ByVal strMsg As String, ByVal intByte As Integer) As String
        Try
            Dim strRet As String = ""
            Dim intMojisu As Integer = strMsg.Length

            'strMsgをByte配列(Unicode)に変換
            Dim bytWork() As Byte = System.Text.Encoding.GetEncoding(932).GetBytes(strMsg)
            Dim intByteCnt As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strMsg)
            Dim bytRet() As Byte

            If intByte > intByteCnt Then
                ReDim bytRet(intByteCnt - 1)
                '配列のコピー
                Array.Copy(bytWork, bytRet, intByteCnt)
            Else
                ReDim bytRet(intByte - 1)
                '配列のコピー
                Array.Copy(bytWork, bytRet, intByte)
            End If

            strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)

            'もう一度カウントする
            Dim intByteCnt2 As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)

            'もう一度カウントしたものが指定したﾊﾞｲﾄより大きい場合は、最後の文字が全角のため省く
            If intByteCnt2 > intByte Then
                ReDim bytRet(intByte - 2)
                '配列のコピー
                Array.Copy(bytWork, bytRet, intByte - 1)
                strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)
                Dim intByteCnt3 = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)
                strRet = StrDup(intByte - intByteCnt3, " ") & strRet

            End If


            If intByte > intByteCnt Then
                strRet = StrDup(intByte - intByteCnt, " ") & strRet
            End If

            Return strRet

        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  文字列ｽﾍﾟｰｽ詰め                  (Public  SPC_PAD)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字列ｽﾍﾟｰｽ詰め
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <param name="intLen">文字数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SPC_PAD(ByVal strMsg As String, ByVal intLen As Integer) As String
        Try
            Dim strRet As String = ""
            strRet = strMsg & StrDup(intLen, " ")
            strRet = Left(strRet, intLen)

            Return strRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  数値文字列ｾﾞﾛ詰め                (Public  ZERO_PAD)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 数値文字列ｾﾞﾛ詰め（文字列渡し）
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <param name="intLen">文字数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ZERO_PAD(ByVal strMsg As String, ByVal intLen As Integer) As String
        Try
            Dim strRet As String = ""
            strRet = StrDup(intLen, "0") & strMsg
            strRet = Right(strRet, intLen)

            Return strRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 数値文字列ｾﾞﾛ詰め（数値渡し）
    ''' </summary>
    ''' <param name="intMsg">文字列</param>
    ''' <param name="intLen">文字数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ZERO_PAD(ByVal intMsg As Integer, ByVal intLen As Integer) As String
        Try
            Dim strRet As String = ""
            strRet = StrDup(intLen, "0") & Trim(Str(intMsg))
            strRet = Right(strRet, intLen)

            Return strRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 数値文字列ゼロ詰め（数値渡し）
    ''' </summary>
    ''' <param name="decMsg">文字列</param>
    ''' <param name="intLen">文字数</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' *******************************************************************************************************************
    Public Function ZERO_PAD(ByVal decMsg As Decimal, ByVal intLen As Integer) As String
        Try
            Dim strRet As String = ""
            strRet = ZERO_PAD(Convert.ToString(decMsg), intLen)

            Return strRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 数値文字列後ろにｾﾞﾛ詰め（文字列渡し）
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <param name="intLen">文字数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ZERO_PAD_BACK(ByVal strMsg As String, ByVal intLen As Integer) As String
        Try
            Dim strRet As String = ""
            strRet = strMsg & StrDup(intLen, "0")
            strRet = Left(strRet, intLen)

            Return strRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function

#End Region
#Region "  SQL登録用ｱｲﾃﾑ変換                (Public  SQL_ITEM)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL登録用ｱｲﾃﾑ変換(ﾊﾞｲﾄ数で文字列ｶｯﾄ＆ｼﾝｸﾞﾙｸｫｰﾃｰｼｮﾝ対応)
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <param name="intLen">文字数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SQL_ITEM(ByVal strMsg As String, ByVal intLen As Integer) As String
        Try
            Dim enc As Encoding = Encoding.Default  '文字列操作




            Dim btTmp() As Byte                     '受信ﾒｯｾｰｼﾞ変換
            Dim btMsg(intLen) As Byte               '処理ｺｰﾄﾞ




            Dim strMsgWrk As String                 'ﾒｯｾｰｼﾞ（ｼﾝｸﾞﾙｸｫｰﾃｰｼｮﾝ調整）




            '' ''Dim intIndex As Integer                 '処理文字列数

            If strMsg = "" Then
                strMsgWrk = ""
            Else
                Erase btTmp
                strMsgWrk = Replace(strMsg, "'", "’")
                strMsgWrk = Replace(strMsgWrk, vbCr, "")
                strMsgWrk = Replace(strMsgWrk, vbLf, "")
                strMsgWrk = Replace(strMsgWrk, Chr(0).ToString, "")
                '' ''btTmp = enc.GetBytes(strMsgWrk)
                '' ''If btTmp.Length > intLen Then
                '' ''    intIndex = intLen
                '' ''Else
                '' ''    intIndex = btTmp.Length
                '' ''End If
                '' ''Array.Copy(btTmp, 0, btMsg, 0, intIndex)
                '' ''strMsgWrk = enc.GetString(btMsg)
                '' ''strMsgWrk = Replace(strMsgWrk, Chr(0).ToString, "")
                strMsgWrk = MID_SJIS(strMsgWrk, 1, intLen)

                ' '' ''ｼﾝｸﾞﾙｺｰﾃｰｼｮﾝ調整
                '' ''Dim blnEnd As Boolean = False
                '' ''Dim intPosNew As Integer = 0
                '' ''Dim intPosOld As Integer = 1
                '' ''Dim intCnt As Integer = 0
                '' ''Dim strMsgWrk2 As String = strMsgWrk
                '' ''While blnEnd = False
                '' ''    intPosNew = InStr(intPosOld, strMsgWrk2, "''", CompareMethod.Binary)
                '' ''    If intPosNew <> 0 Then
                '' ''        intCnt += 1
                '' ''        intPosOld = intPosNew + 2
                '' ''    Else
                '' ''        blnEnd = True
                '' ''    End If
                '' ''End While

                '' ''If intCnt Mod 2 <> 0 Then
                '' ''    strMsgWrk &= "''"
                '' ''End If


            End If

            Return strMsgWrk

        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ビット文字列 生成                (Public  WordToString)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ビット文字列 生成
    ''' </summary>
    ''' <param name="intNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function MakeBitStr(ByVal intNum As Integer) As String
        Try
            Dim strBit As String
            Dim intBit(16) As Integer
            Dim intWrk As Integer = intNum

            '戻り値初期化




            strBit = ""

            'ビットデータ抽出
            For i As Integer = 16 To 1 Step -1
                If intWrk >= 2 ^ (i - 1) Then
                    intBit(i) = 1
                    intWrk -= 2 ^ (i - 1)
                Else
                    intBit(i) = 0
                End If
            Next

            'ビット文字列 生成
            For i As Integer = 1 To 16
                strBit &= intBit(i).ToString
            Next

            Return strBit

        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  PLC用文字列変換                  (Public  WordToString)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' PLC用文字列変換
    ''' </summary>
    ''' <param name="intWrd">レジスタ情報</param>
    ''' <returns>変換後文字列ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function WordToString(ByVal intWrd() As Integer) As String
        Try
            Dim strRet As String
            Dim intWrk As Integer
            Dim intHi As Integer
            Dim intLo As Integer

            strRet = ""
            Try
                For intCnt As Integer = 1 To UBound(intWrd)
                    '作業変数初期化




                    intHi = 0
                    intLo = 0
                    intWrk = intWrd(intCnt)

                    '上位文字抽出
                    For i As Integer = 16 To 9 Step -1
                        If intWrk >= 2 ^ (i - 1) Then
                            intHi += 2 ^ (i - 9)
                            intWrk -= 2 ^ (i - 1)
                        End If
                    Next

                    '下位文字抽出
                    For i As Integer = 8 To 1 Step -1
                        If intWrk >= 2 ^ (i - 1) Then
                            intLo += 2 ^ (i - 1)
                            intWrk -= 2 ^ (i - 1)
                        End If
                    Next

                    If (Asc("0") <= intHi And intHi <= Asc("9")) Or _
                       (Asc("A") <= intHi And intHi <= Asc("Z")) Or _
                       (Asc("a") <= intHi And intHi <= Asc("z")) Then
                        strRet &= Chr(intHi)
                    Else
                        strRet &= "?"
                    End If

                    If (Asc("0") <= intLo And intLo <= Asc("9")) Or _
                       (Asc("A") <= intLo And intLo <= Asc("Z")) Or _
                       (Asc("a") <= intLo And intLo <= Asc("z")) Then
                        strRet &= Chr(intLo)
                    Else
                        strRet &= "?"
                    End If
                Next
            Catch ex As Exception
                strRet = ""
            End Try

            Return strRet

        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region


#Region "  10進数→2進数                (Public  Change10To2)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 10進数→2進数
    ''' </summary>
    ''' <param name="intValue10">10進数</param>
    ''' <param name="intKeta">桁数(変換後の桁数未満の指定はNGとなる)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Change10To2(ByVal intValue10 As Integer, ByVal intKeta As Integer) As String
        Try
            Dim strMsg As String

            '************************
            '10進数→2進数
            '************************
            Dim strValue2 As String
            strValue2 = Convert.ToString(intValue10, 2)


            '************************
            '桁合わせ
            '************************
            If Len(strValue2) < intKeta Then
                '(桁が少ない場合)
                Dim ii As Integer
                For ii = 1 To intKeta - Len(strValue2)
                    strValue2 = "0" & strValue2
                Next
            ElseIf Len(strValue2) > intKeta Then
                '(桁が多い場合)
                strMsg = "ﾊﾟﾗﾒｰﾀが不正です。[2進数桁数 > 桁数]"
                Throw New Exception(strMsg)
            End If


            Return (strValue2)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  10進数→16進数               (Public  Change10To16)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 10進数→16進数
    ''' </summary>
    ''' <param name="intValue10">10進数</param>
    ''' <param name="intKeta"></param>
    ''' <returns>変換値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Change10To16(ByVal intValue10 As Integer, ByVal intKeta As Integer) As String
        Try
            Dim strMsg As String

            '************************
            '10進数→16進数
            '************************
            Dim strValue2 As String
            strValue2 = Convert.ToString(intValue10, 16)


            '************************
            '値ﾁｪｯｸ
            '************************
            If Len(strValue2) > intKeta Then
                '(桁が多い場合)
                strMsg = "ﾊﾟﾗﾒｰﾀが不正です。[2進数桁数 > 桁数]"
                Throw New Exception(strMsg)
            Else
                strValue2 = ZERO_PAD(strValue2, intKeta)
            End If


            Return (strValue2)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  10進数→文字列               (Public  Change10ToString)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 10進数→文字列
    ''' </summary>
    ''' <param name="intValue10">10進数(65535以下じゃないとﾀﾞﾒ)</param>
    ''' <returns>ASCII変換した文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Change10ToString(ByVal intValue10 As Integer) As String
        Try
            Dim strMsg As String

            '************************
            '値ﾁｪｯｸ
            '************************
            If 65535 < intValue10 Then
                '(65535よりも大きい場合)
                strMsg = "値が不正です。2ﾊﾞｲﾄ文字列に変換出来ません[値:" & intValue10 & "]"
                Throw New Exception(strMsg)
            End If


            '************************
            '4ﾊﾞｲﾄに分割
            '************************
            Dim strValue2 As String        '2進数変換
            Dim strData3 As String         '4ﾊﾞｲﾄﾃﾞｰﾀ3(2進数)
            Dim strData4 As String         '4ﾊﾞｲﾄﾃﾞｰﾀ4(2進数)
            Dim intData3 As Integer        '4ﾊﾞｲﾄﾃﾞｰﾀ3(10進数)
            Dim intData4 As Integer        '4ﾊﾞｲﾄﾃﾞｰﾀ4(10進数)
            '10進数→2進数
            strValue2 = Change10To2(intValue10, 32)
            strData3 = Mid(strValue2, 17, 8)
            strData4 = Mid(strValue2, 25, 8)
            '2進数→10進数
            intData3 = Change2To10(strData3)
            intData4 = Change2To10(strData4)


            '************************
            '10進数→2進数
            '************************
            Dim bytString(1) As Byte    '文字列のﾊﾞｲﾄ配列
            Dim strAscii As String      '変換後の文字列
            strAscii = ""
            bytString(0) = intData3
            bytString(1) = intData4
            strAscii = Text.Encoding.GetEncoding(932).GetString(bytString, 0, bytString.Length)     'shift_jis


            Return (strAscii)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  10進数→文字列   [ﾚｼﾞｽﾀ用]   (Public  Change10ToStringReg)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 10進数→文字列[ﾚｼﾞｽﾀ用][最初の8ﾋﾞｯﾄと最後の8ﾋﾞｯﾄを入替えて文字列に変換]
    ''' </summary>
    ''' <param name="intValue10">10進数(65535以下じゃないとﾀﾞﾒ)</param>
    ''' <returns>ASCII変換した文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Change10ToStringReg(ByVal intValue10 As Integer) As String
        Try
            Dim strMsg As String

            '************************
            '値ﾁｪｯｸ
            '************************
            If 65535 < intValue10 Then
                '(65535よりも大きい場合)
                strMsg = "値が不正です。2ﾊﾞｲﾄ文字列に変換出来ません[値:" & intValue10 & "]"
                Throw New Exception(strMsg)
            End If


            '************************
            '4ﾊﾞｲﾄに分割
            '************************
            Dim strValue2 As String        '2進数変換
            '' ''Dim strData1 As String         '4ﾊﾞｲﾄﾃﾞｰﾀ1(2進数)
            '' ''Dim strData2 As String         '4ﾊﾞｲﾄﾃﾞｰﾀ2(2進数)
            Dim strData3 As String         '4ﾊﾞｲﾄﾃﾞｰﾀ3(2進数)
            Dim strData4 As String         '4ﾊﾞｲﾄﾃﾞｰﾀ4(2進数)
            '' ''Dim intData1 As Integer        '4ﾊﾞｲﾄﾃﾞｰﾀ1(10進数)
            '' ''Dim intData2 As Integer        '4ﾊﾞｲﾄﾃﾞｰﾀ2(10進数)
            Dim intData3 As Integer        '4ﾊﾞｲﾄﾃﾞｰﾀ3(10進数)
            Dim intData4 As Integer        '4ﾊﾞｲﾄﾃﾞｰﾀ4(10進数)
            '10進数→2進数
            strValue2 = Change10To2(intValue10, 32)
            '' ''strData1 = Mid(strValue2, 1, 8)
            '' ''strData2 = Mid(strValue2, 9, 8)
            strData3 = Mid(strValue2, 17, 8)
            strData4 = Mid(strValue2, 25, 8)
            '2進数→10進数
            '' ''intData1 = Change2To10(strData1)
            '' ''intData2 = Change2To10(strData2)
            intData3 = Change2To10(strData3)
            intData4 = Change2To10(strData4)


            '************************
            '10進数→2進数
            '************************
            Dim bytString(1) As Byte    '文字列のﾊﾞｲﾄ配列
            Dim strAscii As String      '変換後の文字列
            strAscii = ""
            '' '' '' ''strAscii &= Chr(intData1)
            '' '' '' ''strAscii &= Chr(intData2)
            '' ''strAscii &= Chr(intData3)
            '' ''strAscii &= Chr(intData4)
            bytString(0) = intData4
            bytString(1) = intData3
            strAscii = Text.Encoding.GetEncoding(932).GetString(bytString, 0, bytString.Length)     'shift_jis


            Return (strAscii)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  文字→2進数                  (Public  ChangeCharTo2)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字→2進数
    ''' </summary>
    ''' <param name="strChar">文字(半角文字1桁以外の指定はNGとなる)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ChangeCharTo2(ByVal strChar As String) As String
        Try
            Dim strMsg As String


            '************************
            '文字→2進数
            '************************
            Dim bytValue() As Byte
            If IsNothing(strChar) = True Then strChar = ""
            bytValue = System.Text.Encoding.GetEncoding(932).GetBytes(strChar)


            '************************
            '10進数→2進数
            '************************
            Dim strValue2 As String = ""
            Dim ii As Integer
            For ii = LBound(bytValue) To UBound(bytValue)
                Dim strTemp As String
                strTemp = Convert.ToString(bytValue(ii), 2)
                If Len(strTemp) < 8 Then
                    '(桁が少ない場合)
                    Dim jj As Integer
                    For jj = 1 To 8 - Len(strTemp)
                        strTemp = "0" & strTemp
                    Next
                End If
                strValue2 = strValue2 & strTemp
            Next


            '************************
            '結果ﾁｪｯｸ
            '************************
            If Len(strValue2) <> 8 Then
                strMsg = "ﾊﾟﾗﾒｰﾀが不正です。[文字 <> 半角1桁]"
                Throw New Exception(strMsg)
            End If


            Return (strValue2)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  文字→16進数                 (Public  ChangeCharTo16)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字→16進数
    ''' </summary>
    ''' <param name="strChar">文字列</param>
    ''' <returns>変換値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ChangeCharTo16(ByVal strChar As String) As String
        Try
            '' ''Dim strMsg As String


            '************************
            '文字→ﾊﾞｲﾄ配列
            '************************
            Dim bytValue() As Byte
            If IsNothing(strChar) = True Then strChar = ""
            bytValue = System.Text.Encoding.GetEncoding(932).GetBytes(strChar)


            '************************
            'ﾊﾞｲﾄ配列→16進数
            '************************
            Dim strValue16 As String = ""
            Dim ii As Integer
            For ii = LBound(bytValue) To UBound(bytValue)
                Dim strTemp As String
                strTemp = Convert.ToString(bytValue(ii), 16)
                strTemp = ZERO_PAD(strTemp, 2)
                strValue16 &= strTemp
            Next


            Return (strValue16)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  文字→16進数     [ﾚｼﾞｽﾀ用]   (Public  ChangeCharTo16Reg)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字→16進数[ﾚｼﾞｽﾀ用]
    ''' </summary>
    ''' <param name="strChar">文字列</param>
    ''' <returns>変換値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ChangeCharTo16Reg(ByVal strChar As String) As String
        Try
            '' ''Dim strMsg As String


            '************************
            '文字→ﾊﾞｲﾄ配列
            '************************
            Dim bytValue() As Byte
            If IsNothing(strChar) = True Then strChar = ""
            bytValue = System.Text.Encoding.GetEncoding(932).GetBytes(strChar)


            '************************
            '強引に偶数文字数にする
            '************************
            If bytValue.Length Mod 2 <> 0 Then
                ReDim Preserve bytValue(UBound(bytValue) + 1)
            End If


            '************************
            'ﾊﾞｲﾄ配列→16進数
            '************************
            Dim strValue16 As String = ""
            Dim ii As Integer
            For ii = LBound(bytValue) To UBound(bytValue) Step 2
                Dim strTemp As String

                strTemp = Convert.ToString(bytValue(ii + 1), 16)
                strTemp = ZERO_PAD(strTemp, 2)
                strValue16 &= strTemp

                strTemp = Convert.ToString(bytValue(ii), 16)
                strTemp = ZERO_PAD(strTemp, 2)
                strValue16 &= strTemp
            Next


            Return (strValue16)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  2進数→10進数                (Public  Change2To10)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 2進数→10進数
    ''' </summary>
    ''' <param name="strValue2">2進数</param>
    ''' <returns>変換値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Change2To10(ByVal strValue2 As String) As Long
        Try

            Dim lngValue10 As Long                      '10進数
            lngValue10 = Convert.ToInt32(strValue2, 2)


            '' ''Dim strMsg As String

            ' '' ''************************
            ' '' ''2進数→10進数
            ' '' ''************************
            '' ''Dim intKeta As Integer = Len(strValue2)     '2進数の桁数
            '' ''Dim lngValue10 As Long                      '10進数
            '' ''For ii As Integer = intKeta To 1 Step -1
            '' ''    '(2進数の桁数)

            '' ''    '値ﾁｪｯｸ
            '' ''    Dim strBitData As String = Mid(strValue2, ii, 1)
            '' ''    If Not (strBitData = "0" Or strBitData = "1") Then
            '' ''        '(01以外)
            '' ''        strMsg = "2進数が不正です。[" & strValue2 & "]"
            '' ''        Throw New Exception(strMsg)
            '' ''    End If

            '' ''    'ﾃﾞｰﾀ更新
            '' ''    lngValue10 += Val(strBitData) * 2 ^ (intKeta - ii)

            '' ''Next


            Return (lngValue10)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  16進数→10進数               (Public  Change16To10)"
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
#Region "  16進数→文字列               (Public  Change16ToString)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 16進数→文字列
    ''' </summary>
    ''' <param name="strValue16">16進数</param>
    ''' <returns>変換値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Change16ToString(ByVal strValue16 As String) As String
        Try
            Dim strMsg As String
            Dim ii As Integer                       'ｶｳﾝﾀ
            Dim strValueString As String = ""       '変換後文字列
            If IsNothing(strValue16) = True Then strValue16 = "0"


            '************************
            '事前ﾁｪｯｸ
            '************************
            If strValue16.Length Mod 4 <> 0 Then
                '(4で割り切れなかった場合)
                strMsg = "ﾊﾟﾗﾒｰﾀが不正です。[16進数は4で割り切れる桁数にして下さい。]"
                Throw New Exception(strMsg)
            End If


            ii = 0              'ｶｳﾝﾀﾘｾｯﾄ
            While True

                '************************
                'ﾙｰﾌﾟ判定
                '************************
                If Len(strValue16) <= ii Then Exit While


                '************************
                '4文字切り出し
                '************************
                Dim strTemp As String
                strTemp = Mid(strValue16, ii + 1, 4)


                '************************
                '16進数→10進数
                '************************
                Dim intValue10 As Integer
                Try
                    intValue10 = Convert.ToInt32(strTemp, 16)
                Catch ex As Exception
                    strMsg = "ﾊﾟﾗﾒｰﾀが不正です。[16進数がIntegerの範囲を超えています。]"
                    Throw New Exception(strMsg)
                End Try


                '************************
                '10進数→文字列
                '************************
                strValueString &= Change10ToStringReg(intValue10)
                '' ''strValueString &= Change10ToString(intValue10)


                ii += 4         'ｶｳﾝﾀｱｯﾌﾟ
            End While


            '************************
            'Null文字を削除
            '************************
            strValueString = Replace(strValueString, Chr(0), "")


            Return (strValueString)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "　四捨五入　                   (Public  HalfAdjust)"
    '''*******************************************************************************************************************
    '''【機能】<summary>指定した精度の数値に四捨五入します。</summary>
    '''【引数】[ IN  ]dValue 　     ：<param name="dValue">丸め対象の倍精度浮動小数点数。</param>
    '''        [ IN  ]iDigits       ：<param name="iDigits">戻り値の有効桁数の精度。ﾃﾞﾌｫﾙﾄ=0</param>
    '''【戻値】                     ：<returns>iDigits に等しい精度の数値に四捨五入された数値。</returns>
    '''*******************************************************************************************************************
    Public Function HalfAdjust(ByVal dValue As Decimal, Optional ByVal iDigits As Integer = 0) As Decimal
        Dim dCoef As Decimal = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor((dValue * dCoef) + 0.5) / dCoef
        Else
            Return System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef
        End If
    End Function

#End Region

#Region "　Boolean型を数値に変換　                   (Public  BlnToInt)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' Boolean型を数値に変換
    ''' </summary>
    ''' <param name="blnBoolean">変換するBoolean型変数</param>
    ''' <returns>変換後の数値</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function BlnToInt(ByVal blnBoolean As Boolean) As Integer
        Dim intReturn As Integer = -1

        If blnBoolean = True Then
            intReturn = 1
        Else
            intReturn = 0
        End If

        Return intReturn
    End Function
#End Region
#Region "　数値をBoolean型に変換　                   (Public  IntToBln)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 数値をBoolean型に変換
    ''' </summary>
    ''' <param name="intInteger">変換する数値型変数</param>
    ''' <returns>Boolean型</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function IntToBln(ByVal intInteger As Nullable(Of Integer)) As Boolean
        Dim blnReturn As Boolean = False

        If intInteger = 0 Or IsNull(intInteger) Then
            blnReturn = False
        Else
            blnReturn = True
        End If

        Return blnReturn
    End Function
#End Region

#Region "  配列の比較                   (Public  ArrayEquals)"
    '''***************************************************************************************************************
    ''' <summary>
    ''' 配列の比較
    ''' </summary>
    ''' <param name="objArray1">比較する配列1</param>
    ''' <param name="objArray2">比較する配列2</param>
    ''' <returns>objArray1とobjArray2が同一の配列の場合はTrue、それ以外はFalse</returns>
    ''' <remarks>
    ''' 配列の比較を行う。
    ''' objArray1とobjArray2を比較し、同一の配列の場合はTrue、それ以外はFalseを戻り値として返す。
    ''' </remarks>
    '''***************************************************************************************************************
    Public Function ArrayEquals(ByVal objArray1() As Integer _
                              , ByVal objArray2() As Integer _
                              ) _
                              As Boolean
        Dim blnRerutn As Boolean = False        '戻り値

        If UBound(objArray1) = UBound(objArray1) Then
            '(要素数が同じ場合)

            For ii As Integer = LBound(objArray1) To UBound(objArray1)
                '(ﾙｰﾌﾟ:配列1の要素数)

                If objArray1(ii) <> objArray2(ii) Then Exit For
                If ii = UBound(objArray1) Then
                    blnRerutn = True
                End If

            Next

        End If


        Return blnRerutn
    End Function
#End Region
#Region "  配列内ﾃﾞｰﾀ有無               (Public  ArrayFindData)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 配列内ﾃﾞｰﾀ有無
    ''' </summary>
    ''' <param name="objArray1"></param>
    ''' <param name="strFindData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ArrayFindData(ByVal objArray1() As String _
                                , ByVal strFindData As String _
                                ) _
                                As Integer
        Dim intRerutn As Integer = -1       '戻り値

        If IsNothing(objArray1) = False Then
            For ii As Integer = LBound(objArray1) To UBound(objArray1)
                '(ﾙｰﾌﾟ:配列1の要素数)

                If objArray1(ii) = strFindData Then
                    '(ﾃﾞｰﾀが見つかった場合)
                    intRerutn = ii
                    Exit For
                End If
            Next
        End If


        Return intRerutn
    End Function
#End Region


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  ｺﾏﾝﾄﾞID→電文送信用ID変換"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾏﾝﾄﾞID→電文送信用ID変換
    ''' </summary>
    ''' <param name="strFCOMMAND_ID">変換するｺﾏﾝﾄﾞID</param>
    ''' <returns>電文分解用ID</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ChangeMCR1VID(ByVal strFCOMMAND_ID As String) As String
        Dim strReturn As String = ""        '戻り値

        Select Case strFCOMMAND_ID
            'Case FCOMMAND_ID_SONLINE : strReturn = MCV_ID_DIR_ONLINE     'ﾃﾞｰﾀﾘﾝｸ確立
            'Case FCOMMAND_ID_SOFFLINE : strReturn = MCV_ID_DIR_OFFLINE   'ﾃﾞｰﾀﾘﾝｸ切断
            'Case FCOMMAND_ID_SIN : strReturn = MCV_TELID_B2              'B2入庫指示
            'Case FCOMMAND_ID_SOUT : strReturn = MCV_TELID_B3             'B3出庫指示
            'Case FCOMMAND_ID_MCR1V_B5 : strReturn = MCV_TELID_B5        'B5行先変更指令
            'Case FCOMMAND_ID_MCR1V_A1 : strReturn = MCV_TELID_A1        '状態問合せ
            'Case FCOMMAND_ID_MCR1V_A2 : strReturn = MCV_TELID_A2        '異常問合せ
            'Case FCOMMAND_ID_MCR1V_D1 : strReturn = MCV_TELID_D1        '起動ｺﾏﾝﾄﾞ
            'Case FCOMMAND_ID_MCR1V_D2 : strReturn = MCV_TELID_D2        '実行中ｸﾘｱｺﾏﾝﾄﾞ
            'Case FCOMMAND_ID_MCR1V_D3 : strReturn = MCV_TELID_D3        '原点戻しｺﾏﾝﾄﾞ
            'Case FCOMMAND_ID_MCR1V_D4 : strReturn = MCV_TELID_D4        '異常ﾘｾｯﾄｺﾏﾝﾄﾞ
            '' ''Case Else : Throw New Exception("ｺﾏﾝﾄﾞID異常")
        End Select

        Return strReturn
    End Function
#End Region
#Region "  ｺﾏﾝﾄﾞID→電文送信用ID変換"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾏﾝﾄﾞID→電文送信用ID変換
    ''' </summary>
    ''' <param name="strFCOMMAND_ID">変換するｺﾏﾝﾄﾞID</param>
    ''' <returns>電文分解用ID</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ChangeRTNID(ByVal strFCOMMAND_ID As String) As String
        Dim strReturn As String = ""        '戻り値

        Select Case strFCOMMAND_ID
            'Case FCOMMAND_ID_RTN_B2 : strReturn = RTN_TELID_B2      'B2搬送指令
            'Case FCOMMAND_ID_RTN_A1 : strReturn = RTN_TELID_A1      'A1RTN状態問合わせ
            'Case FCOMMAND_ID_RTN_C1 : strReturn = RTN_TELID_C1      'C1荷すくい発信指令
            'Case FCOMMAND_ID_RTN_C2 : strReturn = RTN_TELID_C2      'C2荷降ろし発信指令
            'Case FCOMMAND_ID_RTN_D1 : strReturn = RTN_TELID_D1      'D1起動
            'Case FCOMMAND_ID_RTN_D2 : strReturn = RTN_TELID_D2      'D2実行ｸﾘｱ
            'Case FCOMMAND_ID_RTN_D3 : strReturn = RTN_TELID_D3      'D3HP搬送指令
            'Case FCOMMAND_ID_RTN_D4 : strReturn = RTN_TELID_D4      'D4一時停止
            'Case FCOMMAND_ID_RTN_D5 : strReturn = RTN_TELID_D5      'D5一時停止解除
            '' ''Case Else : Throw New Exception("ｺﾏﾝﾄﾞID異常")
        End Select

        Return strReturn
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Module
