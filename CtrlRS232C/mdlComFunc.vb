''**********************************************************************************************
'' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
'' All Rights Reserved
''
'' �y���́z��رٽ�ذѕW���@�\
'' �y�@�\�z���ʊ֐�Ӽޭ��
'' �y�쐬�zSIT
''**********************************************************************************************

'#Region "  Imports"
'Imports System.Text
'#End Region

'Public Module mdlComFunc

'#Region "  ��޼ު�Ă𕶎���ɕϊ�           (Public  TO_STRING)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ��޼ު�Ă𕶎���ɕϊ�
'    ''' </summary>
'    ''' <param name="objString">�������޼ު��</param>
'    ''' <returns>������ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function TO_STRING(ByVal objString As Object) As String
'        Try
'            Dim strRet As String = Nothing
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then

'                strRet = CStr(objString)

'            End If
'            Return strRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'    '' ''Public Function TO_STRING(ByVal objString As Object) As String
'    '' ''    Try
'    '' ''        Dim strRet As String = ""
'    '' ''        If (Not objString Is Nothing) And _
'    '' ''           (Not IsDBNull(objString)) Then
'    '' ''            strRet = CStr(objString)
'    '' ''        End If
'    '' ''        Return strRet
'    '' ''    Catch ex As Exception
'    '' ''        Throw New System.Exception(ex.Message)
'    '' ''    End Try
'    '' ''End Function
'    Public Function TO_STRING_NULLABLE(ByVal objString As Object) As String
'        Try
'            Dim strRet As String = Nothing
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then

'                strRet = CStr(objString)

'            End If
'            Return strRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  ��޼ު�Ă𐔒l�ɕϊ�             (Public  TO_NUMBER)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ��޼ު�Ă𐔒l�ɕϊ�
'    ''' </summary>
'    ''' <param name="objString">�������޼ު��</param>
'    ''' <returns>���l�ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function TO_NUMBER(ByVal objString As Object) As Decimal
'        Try
'            Dim dblRet As Decimal = 0
'            If (Not objString Is Nothing) _
'               And (CStr(objString) <> "") _
'               And (Not IsDBNull(objString)) _
'               Then
'                dblRet = CDec(CStr(objString))
'            End If
'            Return dblRet

'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  ��޼ު�Ă𐔒l(INTEGER)�ɕϊ�    (Public  TO_INTEGER)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ��޼ު�Ă𐔒l�ɕϊ�
'    ''' </summary>
'    ''' <param name="objString">�������޼ު��</param>
'    ''' <returns>���l�ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function TO_INTEGER(ByVal objString As Object) As Integer
'        Try
'            Dim intRet As Integer = 0
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then
'                intRet = Val(CStr(objString))
'            End If
'            Return intRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'    Public Function TO_INTEGER_NULLABLE(ByVal objString As Object) As Nullable(Of Integer)
'        Try
'            Dim intRet As Nullable(Of Integer) = Nothing
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then

'                If CStr(objString) <> "" Then
'                    intRet = Val(CStr(objString))
'                End If

'            End If
'            Return intRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  ��޼ު�Ă𐔒l(LONG)�ɕϊ�       (Public  TO_LONG)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ��޼ު�Ă𐔒l�ɕϊ�
'    ''' </summary>
'    ''' <param name="objString">�������޼ު��</param>
'    ''' <returns>���l�ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function TO_LONG(ByVal objString As Object) As Long
'        Try
'            Dim lngRet As Long = 0
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then
'                lngRet = Val(CStr(objString))
'            End If
'            Return lngRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  ��޼ު�Ă𐔒l(SHORT)�ɕϊ�      (Public  TO_SHORT)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ��޼ު�Ă𐔒l�ɕϊ�
'    ''' </summary>
'    ''' <param name="objString">�������޼ު��</param>
'    ''' <returns>���l�ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function TO_SHORT(ByVal objString As Object) As Short
'        Try
'            Dim shoRet As Short = 0
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then
'                shoRet = Val(CStr(objString))
'            End If
'            Return shoRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  ��޼ު�Ă𐔒l(DECIMAL)�ɕϊ�    (Public  TO_DECIMAL)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ��޼ު�Ă𐔒l�ɕϊ�
'    ''' </summary>
'    ''' <param name="objString">�������޼ު��</param>
'    ''' <returns>���l�ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function TO_DECIMAL(ByVal objString As Object) As Decimal
'        Try
'            Dim dclRet As Decimal = 0
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then

'                '������������************************************************************************************************************
'                'Checked SystemMate:N.Dounoshita 2011/11/24 �����_�����������ƁA����Ɋۂ߂����

'                If CStr(objString) <> "" Then
'                    dclRet = CDec(CStr(objString))
'                End If

'                'dclRet = Val(CStr(objString))

'                '������������************************************************************************************************************

'            End If
'            Return dclRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'    Public Function TO_DECIMAL_NULLABLE(ByVal objString As Object) As Nullable(Of Decimal)
'        Try
'            Dim dclRet As Nullable(Of Decimal) = Nothing
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then

'                If CStr(objString) <> "" Then
'                    '������������************************************************************************************************************
'                    'Checked SystemMate:N.Dounoshita 2011/11/24 �����_�����������ƁA����Ɋۂ߂����
'                    dclRet = CDec(CStr(objString))
'                    'dclRet = Val(CStr(objString))
'                    '������������************************************************************************************************************
'                End If

'            End If
'            Return dclRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  ��޼ު�Ă���t�ɕϊ�             (Public  TO_DATE)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ��޼ު�Ă���t�ɕϊ�
'    ''' </summary>
'    ''' <param name="objString">�������޼ު��</param>
'    ''' <returns>���t�ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function TO_DATE(ByVal objString As Object) As Date
'        Try
'            Dim dtmRet As Date
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then

'                If CStr(objString) <> "" Then
'                    dtmRet = CDate(CStr(objString))
'                End If

'            End If
'            Return dtmRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'    Public Function TO_DATE_NULLABLE(ByVal objString As Object) As Nullable(Of Date)
'        Try
'            Dim dtmRet As Nullable(Of Date) = Nothing
'            If (Not objString Is Nothing) And _
'               (Not IsDBNull(objString)) Then

'                If CStr(objString) <> "" Then
'                    dtmRet = CDate(CStr(objString))
'                End If

'            End If
'            Return dtmRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  Null����                         (Public  IsNull)"
'    '''****************************************************************************************************
'    ''' <summary>
'    ''' Null����
'    ''' </summary>
'    ''' <param name="objObject">Null���肷���޼ު��</param>
'    ''' <returns>Null����̏ꍇTrue�BNotNull����̏ꍇFalse</returns>
'    ''' <remarks>IsNothing�֐��ł�""����False�ƂȂ邪�ATrue�ƂȂ�֐��ɂ����B</remarks>
'    '''****************************************************************************************************
'    Public Function IsNull(ByVal objObject As Object) As Boolean
'        Try
'            Dim blnRet As Boolean = False

'            If IsNothing(objObject) = True Then
'                blnRet = True
'            Else
'                If TypeName(objObject) = "String" Then
'                    If objObject = "" Then
'                        blnRet = True
'                    End If
'                End If
'            End If

'            Return blnRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  NotNull����                      (Public  IsNotNull)"
'    '''****************************************************************************************************
'    ''' <summary>
'    ''' NotNull����
'    ''' </summary>
'    ''' <param name="objObject">Null���肷���޼ު��</param>
'    ''' <returns>Null����̏ꍇTrue�BNotNull����̏ꍇFalse</returns>
'    ''' <remarks>IsNothing�֐��ł�""����False�ƂȂ邪�ATrue�ƂȂ�֐��ɂ����B</remarks>
'    '''****************************************************************************************************
'    Public Function IsNotNull(ByVal objObject As Object) As Boolean
'        Try
'            Dim blnRet As Boolean = False

'            blnRet = IsNull(objObject)
'            blnRet = Not (blnRet)

'            Return blnRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region

'#Region "  ��������޲Đ��擾(SJIS�p)       (Public  GET_BYTE_LENGTH_STRING)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' �������߰��l��(SJIS�p)
'    ''' </summary>
'    ''' <param name="strMsg">������</param>
'    ''' <returns>��������޲Đ�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function GET_BYTE_LENGTH_STRING(ByVal strMsg As String) As Integer
'        Dim intRet As Integer = 0           '�ߒl

'        Dim bytWork() As Byte = System.Text.Encoding.GetEncoding(932).GetBytes(strMsg)
'        intRet = UBound(bytWork) + 1

'        Return intRet
'    End Function
'#End Region
'#Region "  ��������޲Đ��؏o��(SJIS�p)     (Public  MID_SJIS)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ��������޲Đ��؏o��(SJIS�p)
'    ''' </summary>
'    ''' <param name="strMsg">������</param>
'    ''' <param name="intPos">�J�n�ʒu</param>
'    ''' <param name="intLen">�޲Đ�</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function MID_SJIS(ByVal strMsg As String _
'                           , ByVal intPos As Integer _
'                           , Optional ByVal intLen As Integer = Integer.MaxValue _
'                             ) _
'                             As String
'        Try
'            Dim strRet As String
'            Dim bytWork() As Byte = System.Text.Encoding.GetEncoding(932).GetBytes(strMsg)
'            Dim bytRet() As Byte
'            Dim intLenWk As Integer

'            If bytWork.Length - intPos + 1 >= intLen Then
'                ReDim bytRet(intLen - 1)
'                Array.Copy(bytWork, intPos - 1, bytRet, 0, intLen)
'                intLenWk = intLen
'            ElseIf bytWork.Length - intPos + 1 <= 0 Then
'                strRet = ""
'                Return strRet
'            Else
'                intLenWk = bytWork.Length - intPos + 1
'                ReDim bytRet(intLenWk - 1)
'                Array.Copy(bytWork, intPos - 1, bytRet, 0, intLenWk)
'            End If
'            strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet) & ""


'            '������x�J�E���g����
'            Dim intByteCnt2 As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)

'            '������x�J�E���g�������̂��w�肵���޲Ă��傫���ꍇ�́A�Ō�̕������S�p�̂��ߏȂ�
'            If intByteCnt2 > intLenWk Then
'                ReDim bytRet(intLenWk - 2)
'                '�z��̃R�s�[
'                Array.Copy(bytWork, bytRet, intLenWk - 1)
'                strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)
'                Dim intByteCnt3 = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)
'                'strRet = strRet & StrDup(intLenWk - intByteCnt3, " ")

'            End If

'            Return strRet

'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try

'    End Function
'#End Region
'#Region "  �������߰��l��(SJIS�p)          (Public  SPC_PAD_SJIS)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' �������߰��l��(SJIS�p)
'    ''' </summary>
'    ''' <param name="strMsg">������</param>
'    ''' <param name="intByte">�޲Đ�</param>
'    ''' <param name="intOpt">��߼��(1:�E�l,2:���l)</param>
'    ''' <returns>������ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function SPC_PAD_SJIS(ByVal strMsg As String, ByVal intByte As Integer, ByVal intOpt As Integer) As String
'        Dim strRet As String = ""

'        '�w�肵�������񂪋�A�޲Đ���0�̂Ƃ��͋󕶎���Ԃ��B
'        If intByte = 0 Or strMsg.Length = 0 Then
'            Return strRet
'        End If

'        Select Case intOpt
'            Case 1
'                '���l
'                strRet = SPC_PAD_LEFT_SJIS(strMsg, intByte)
'            Case 2
'                '�E�l
'                strRet = SPC_PAD_RIGHT_SJIS(strMsg, intByte)
'        End Select
'        Return strRet
'    End Function
'#End Region
'#Region "  �����񍶋l��(SJIS�p)             (Public  SPC_PAD_LEFT_SJIS)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' �����񍶋l��(SJIS�p)
'    ''' </summary>
'    ''' <param name="strMsg">������</param>
'    ''' <param name="intByte">�޲Đ�</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function SPC_PAD_LEFT_SJIS(ByVal strMsg As String, ByVal intByte As Integer) As String
'        Try
'            If IsNothing(strMsg) = True Then strMsg = ""
'            Dim strRet As String = ""
'            Dim intMojisu As Integer = strMsg.Length

'            'strMsg��Byte�z��(SJIS)�ɕϊ�
'            Dim bytWork() As Byte = System.Text.Encoding.GetEncoding(932).GetBytes(strMsg)
'            Dim intByteCnt As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strMsg)
'            Dim bytRet() As Byte

'            If intByte > intByteCnt Then
'                ReDim bytRet(intByteCnt - 1)
'                '�z��̃R�s�[
'                Array.Copy(bytWork, bytRet, intByteCnt)
'            Else
'                ReDim bytRet(intByte - 1)
'                '�z��̃R�s�[
'                Array.Copy(bytWork, bytRet, intByte)
'            End If

'            strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)

'            '������x�J�E���g����
'            Dim intByteCnt2 As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)

'            '������x�J�E���g�������̂��w�肵���޲Ă��傫���ꍇ�́A�Ō�̕������S�p�̂��ߏȂ�
'            If intByteCnt2 > intByte Then
'                ReDim bytRet(intByte - 2)
'                '�z��̃R�s�[
'                Array.Copy(bytWork, bytRet, intByte - 1)
'                strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)
'                Dim intByteCnt3 = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)
'                strRet = strRet & StrDup(intByte - intByteCnt3, " ")

'            End If


'            If intByte > intByteCnt Then
'                strRet = strRet & StrDup(intByte - intByteCnt, " ")
'            End If

'            Return strRet

'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  ������E�l��(SJIS�p)             (Public  SPC_PAD_RIGHT_SJIS)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ������E�l��(SJIS�p)
'    ''' </summary>
'    ''' <param name="strMsg">������</param>
'    ''' <param name="intByte">�޲Đ�</param>
'    ''' <returns>������ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function SPC_PAD_RIGHT_SJIS(ByVal strMsg As String, ByVal intByte As Integer) As String
'        Try
'            If IsNothing(strMsg) = True Then strMsg = ""
'            Dim strRet As String = ""
'            Dim intMojisu As Integer = strMsg.Length

'            'strMsg��Byte�z��(Unicode)�ɕϊ�
'            Dim bytWork() As Byte = System.Text.Encoding.GetEncoding(932).GetBytes(strMsg)
'            Dim intByteCnt As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strMsg)
'            Dim bytRet() As Byte

'            If intByte > intByteCnt Then
'                ReDim bytRet(intByteCnt - 1)
'                '�z��̃R�s�[
'                Array.Copy(bytWork, bytRet, intByteCnt)
'            Else
'                ReDim bytRet(intByte - 1)
'                '�z��̃R�s�[
'                Array.Copy(bytWork, bytRet, intByte)
'            End If

'            strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)

'            '������x�J�E���g����
'            Dim intByteCnt2 As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)

'            '������x�J�E���g�������̂��w�肵���޲Ă��傫���ꍇ�́A�Ō�̕������S�p�̂��ߏȂ�
'            If intByteCnt2 > intByte Then
'                ReDim bytRet(intByte - 2)
'                '�z��̃R�s�[
'                Array.Copy(bytWork, bytRet, intByte - 1)
'                strRet = System.Text.Encoding.GetEncoding(932).GetString(bytRet)
'                Dim intByteCnt3 = System.Text.Encoding.GetEncoding(932).GetByteCount(strRet)
'                strRet = StrDup(intByte - intByteCnt3, " ") & strRet

'            End If


'            If intByte > intByteCnt Then
'                strRet = StrDup(intByte - intByteCnt, " ") & strRet
'            End If

'            Return strRet

'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  �������߰��l��                  (Public  SPC_PAD)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' �������߰��l��
'    ''' </summary>
'    ''' <param name="strMsg">������</param>
'    ''' <param name="intLen">������</param>
'    ''' <returns>������ϊ����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function SPC_PAD(ByVal strMsg As String, ByVal intLen As Integer) As String
'        Try
'            Dim strRet As String = ""
'            strRet = strMsg & StrDup(intLen, " ")
'            strRet = Left(strRet, intLen)

'            Return strRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  ���l�������ۋl��                (Public  ZERO_PAD)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ���l�������ۋl�߁i������n���j
'    ''' </summary>
'    ''' <param name="strMsg">������</param>
'    ''' <param name="intLen">������</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function ZERO_PAD(ByVal strMsg As String, ByVal intLen As Integer) As String
'        Try
'            Dim strRet As String = ""
'            strRet = StrDup(intLen, "0") & strMsg
'            strRet = Right(strRet, intLen)

'            Return strRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function

'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ���l�������ۋl�߁i���l�n���j
'    ''' </summary>
'    ''' <param name="intMsg">������</param>
'    ''' <param name="intLen">������</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function ZERO_PAD(ByVal intMsg As Integer, ByVal intLen As Integer) As String
'        Try
'            Dim strRet As String = ""
'            strRet = StrDup(intLen, "0") & Trim(Str(intMsg))
'            strRet = Right(strRet, intLen)

'            Return strRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function

'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ���l������[���l�߁i���l�n���j
'    ''' </summary>
'    ''' <param name="decMsg">������</param>
'    ''' <param name="intLen">������</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function ZERO_PAD(ByVal decMsg As Decimal, ByVal intLen As Integer) As String
'        Try
'            Dim strRet As String = ""
'            strRet = ZERO_PAD(Convert.ToString(decMsg), intLen)

'            Return strRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ���l��������ɾ�ۋl�߁i������n���j
'    ''' </summary>
'    ''' <param name="strMsg">������</param>
'    ''' <param name="intLen">������</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function ZERO_PAD_BACK(ByVal strMsg As String, ByVal intLen As Integer) As String
'        Try
'            Dim strRet As String = ""
'            strRet = strMsg & StrDup(intLen, "0")
'            strRet = Left(strRet, intLen)

'            Return strRet
'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function

'#End Region
'#Region "  SQL�o�^�p���ѕϊ�                (Public  SQL_ITEM)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' SQL�o�^�p���ѕϊ�(�޲Đ��ŕ�����ā��ݸ�ٸ��ð��ݑΉ�)
'    ''' </summary>
'    ''' <param name="strMsg">������</param>
'    ''' <param name="intLen">������</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function SQL_ITEM(ByVal strMsg As String, ByVal intLen As Integer) As String
'        Try
'            Dim enc As Encoding = Encoding.Default  '�����񑀍�




'            Dim btTmp() As Byte                     '��Mү���ޕϊ�
'            Dim btMsg(intLen) As Byte               '��������




'            Dim strMsgWrk As String                 'ү���ށi�ݸ�ٸ��ð��ݒ����j




'            '' ''Dim intIndex As Integer                 '����������

'            If strMsg = "" Then
'                strMsgWrk = ""
'            Else
'                Erase btTmp
'                strMsgWrk = Replace(strMsg, "'", "�f")
'                strMsgWrk = Replace(strMsgWrk, vbCr, "")
'                strMsgWrk = Replace(strMsgWrk, vbLf, "")
'                strMsgWrk = Replace(strMsgWrk, Chr(0).ToString, "")
'                '' ''btTmp = enc.GetBytes(strMsgWrk)
'                '' ''If btTmp.Length > intLen Then
'                '' ''    intIndex = intLen
'                '' ''Else
'                '' ''    intIndex = btTmp.Length
'                '' ''End If
'                '' ''Array.Copy(btTmp, 0, btMsg, 0, intIndex)
'                '' ''strMsgWrk = enc.GetString(btMsg)
'                '' ''strMsgWrk = Replace(strMsgWrk, Chr(0).ToString, "")
'                strMsgWrk = MID_SJIS(strMsgWrk, 1, intLen)

'                ' '' ''�ݸ�ٺ�ð��ݒ���
'                '' ''Dim blnEnd As Boolean = False
'                '' ''Dim intPosNew As Integer = 0
'                '' ''Dim intPosOld As Integer = 1
'                '' ''Dim intCnt As Integer = 0
'                '' ''Dim strMsgWrk2 As String = strMsgWrk
'                '' ''While blnEnd = False
'                '' ''    intPosNew = InStr(intPosOld, strMsgWrk2, "''", CompareMethod.Binary)
'                '' ''    If intPosNew <> 0 Then
'                '' ''        intCnt += 1
'                '' ''        intPosOld = intPosNew + 2
'                '' ''    Else
'                '' ''        blnEnd = True
'                '' ''    End If
'                '' ''End While

'                '' ''If intCnt Mod 2 <> 0 Then
'                '' ''    strMsgWrk &= "''"
'                '' ''End If


'            End If

'            Return strMsgWrk

'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  �r�b�g������ ����                (Public  WordToString)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' �r�b�g������ ����
'    ''' </summary>
'    ''' <param name="intNum"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function MakeBitStr(ByVal intNum As Integer) As String
'        Try
'            Dim strBit As String
'            Dim intBit(16) As Integer
'            Dim intWrk As Integer = intNum

'            '�߂�l������




'            strBit = ""

'            '�r�b�g�f�[�^���o
'            For i As Integer = 16 To 1 Step -1
'                If intWrk >= 2 ^ (i - 1) Then
'                    intBit(i) = 1
'                    intWrk -= 2 ^ (i - 1)
'                Else
'                    intBit(i) = 0
'                End If
'            Next

'            '�r�b�g������ ����
'            For i As Integer = 1 To 16
'                strBit &= intBit(i).ToString
'            Next

'            Return strBit

'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region
'#Region "  PLC�p������ϊ�                  (Public  WordToString)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' PLC�p������ϊ�
'    ''' </summary>
'    ''' <param name="intWrd">���W�X�^���</param>
'    ''' <returns>�ϊ��㕶�����ް�</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function WordToString(ByVal intWrd() As Integer) As String
'        Try
'            Dim strRet As String
'            Dim intWrk As Integer
'            Dim intHi As Integer
'            Dim intLo As Integer

'            strRet = ""
'            Try
'                For intCnt As Integer = 1 To UBound(intWrd)
'                    '��ƕϐ�������




'                    intHi = 0
'                    intLo = 0
'                    intWrk = intWrd(intCnt)

'                    '��ʕ������o
'                    For i As Integer = 16 To 9 Step -1
'                        If intWrk >= 2 ^ (i - 1) Then
'                            intHi += 2 ^ (i - 9)
'                            intWrk -= 2 ^ (i - 1)
'                        End If
'                    Next

'                    '���ʕ������o
'                    For i As Integer = 8 To 1 Step -1
'                        If intWrk >= 2 ^ (i - 1) Then
'                            intLo += 2 ^ (i - 1)
'                            intWrk -= 2 ^ (i - 1)
'                        End If
'                    Next

'                    If (Asc("0") <= intHi And intHi <= Asc("9")) Or _
'                       (Asc("A") <= intHi And intHi <= Asc("Z")) Or _
'                       (Asc("a") <= intHi And intHi <= Asc("z")) Then
'                        strRet &= Chr(intHi)
'                    Else
'                        strRet &= "?"
'                    End If

'                    If (Asc("0") <= intLo And intLo <= Asc("9")) Or _
'                       (Asc("A") <= intLo And intLo <= Asc("Z")) Or _
'                       (Asc("a") <= intLo And intLo <= Asc("z")) Then
'                        strRet &= Chr(intLo)
'                    Else
'                        strRet &= "?"
'                    End If
'                Next
'            Catch ex As Exception
'                strRet = ""
'            End Try

'            Return strRet

'        Catch ex As Exception
'            Throw New System.Exception(ex.Message)
'        End Try
'    End Function
'#End Region


'#Region "  10�i����2�i��                (Public  Change10To2)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' 10�i����2�i�� 
'    ''' </summary>
'    ''' <param name="intValue10">10�i��</param>
'    ''' <param name="intKeta">����(�ϊ���̌��������̎w���NG�ƂȂ�)</param>
'    ''' <returns>�ϊ��l</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function Change10To2(ByVal intValue10 As Integer, ByVal intKeta As Integer) As String
'        Try
'            Dim strMsg As String

'            '************************
'            '10�i����2�i��
'            '************************
'            Dim strValue2 As String
'            strValue2 = Convert.ToString(intValue10, 2)


'            '************************
'            '�����킹
'            '************************
'            If Len(strValue2) < intKeta Then
'                '(�������Ȃ��ꍇ)
'                Dim ii As Integer
'                For ii = 1 To intKeta - Len(strValue2)
'                    strValue2 = "0" & strValue2
'                Next
'            ElseIf Len(strValue2) > intKeta Then
'                '(���������ꍇ)
'                strMsg = "���Ұ����s���ł��B[2�i������ > ����]"
'                Throw New Exception(strMsg)
'            End If


'            Return (strValue2)

'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "  10�i����16�i��               (Public  Change10To16)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' 10�i����16�i��
'    ''' </summary>
'    ''' <param name="intValue10">10�i��</param>
'    ''' <param name="intKeta"></param>
'    ''' <returns>�ϊ��l</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function Change10To16(ByVal intValue10 As Integer, ByVal intKeta As Integer) As String
'        Try
'            Dim strMsg As String

'            '************************
'            '10�i����16�i��
'            '************************
'            Dim strValue2 As String
'            strValue2 = Convert.ToString(intValue10, 16)


'            '************************
'            '�l����
'            '************************
'            If Len(strValue2) > intKeta Then
'                '(���������ꍇ)
'                strMsg = "���Ұ����s���ł��B[2�i������ > ����]"
'                Throw New Exception(strMsg)
'            Else
'                strValue2 = ZERO_PAD(strValue2, intKeta)
'            End If


'            Return (strValue2)

'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "  10�i����������               (Public  Change10ToString)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' 10�i����������
'    ''' </summary>
'    ''' <param name="intValue10">10�i��     (65535�ȉ�����Ȃ������)</param>
'    ''' <returns>ASCII�ϊ�����������</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function Change10ToString(ByVal intValue10 As Integer) As String
'        Try
'            Dim strMsg As String

'            '************************
'            '�l����
'            '************************
'            If 65535 < intValue10 Then
'                '(65535�����傫���ꍇ)
'                strMsg = "�l���s���ł��B2�޲ĕ�����ɕϊ��o���܂���[�l:" & intValue10 & "]"
'                Throw New Exception(strMsg)
'            End If


'            '************************
'            '4�޲Ăɕ���
'            '************************
'            Dim strValue2 As String        '2�i���ϊ�
'            Dim strData3 As String         '4�޲��ް�3(2�i��)
'            Dim strData4 As String         '4�޲��ް�4(2�i��)
'            Dim intData3 As Integer        '4�޲��ް�3(10�i��)
'            Dim intData4 As Integer        '4�޲��ް�4(10�i��)
'            '10�i����2�i��
'            strValue2 = Change10To2(intValue10, 32)
'            strData3 = Mid(strValue2, 17, 8)
'            strData4 = Mid(strValue2, 25, 8)
'            '2�i����10�i��
'            intData3 = Change2To10(strData3)
'            intData4 = Change2To10(strData4)


'            '************************
'            '10�i����2�i��
'            '************************
'            Dim bytString(1) As Byte    '��������޲Ĕz��
'            Dim strAscii As String      '�ϊ���̕�����
'            strAscii = ""
'            bytString(0) = intData3
'            bytString(1) = intData4
'            strAscii = Text.Encoding.GetEncoding(932).GetString(bytString, 0, bytString.Length)     'shift_jis


'            Return (strAscii)
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "  10�i����������   [ڼ޽��p]   (Public  Change10ToStringReg)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' [�ŏ���8�ޯĂƍŌ��8�ޯĂ���ւ��ĕ�����ɕϊ�]
'    ''' </summary>
'    ''' <param name="intValue10">10�i��     (65535�ȉ�����Ȃ������)</param>
'    ''' <returns>ASCII�ϊ�����������</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function Change10ToStringReg(ByVal intValue10 As Integer) As String
'        Try
'            Dim strMsg As String

'            '************************
'            '�l����
'            '************************
'            If 65535 < intValue10 Then
'                '(65535�����傫���ꍇ)
'                strMsg = "�l���s���ł��B2�޲ĕ�����ɕϊ��o���܂���[�l:" & intValue10 & "]"
'                Throw New Exception(strMsg)
'            End If


'            '************************
'            '4�޲Ăɕ���
'            '************************
'            Dim strValue2 As String        '2�i���ϊ�
'            '' ''Dim strData1 As String         '4�޲��ް�1(2�i��)
'            '' ''Dim strData2 As String         '4�޲��ް�2(2�i��)
'            Dim strData3 As String         '4�޲��ް�3(2�i��)
'            Dim strData4 As String         '4�޲��ް�4(2�i��)
'            '' ''Dim intData1 As Integer        '4�޲��ް�1(10�i��)
'            '' ''Dim intData2 As Integer        '4�޲��ް�2(10�i��)
'            Dim intData3 As Integer        '4�޲��ް�3(10�i��)
'            Dim intData4 As Integer        '4�޲��ް�4(10�i��)
'            '10�i����2�i��
'            strValue2 = Change10To2(intValue10, 32)
'            '' ''strData1 = Mid(strValue2, 1, 8)
'            '' ''strData2 = Mid(strValue2, 9, 8)
'            strData3 = Mid(strValue2, 17, 8)
'            strData4 = Mid(strValue2, 25, 8)
'            '2�i����10�i��
'            '' ''intData1 = Change2To10(strData1)
'            '' ''intData2 = Change2To10(strData2)
'            intData3 = Change2To10(strData3)
'            intData4 = Change2To10(strData4)


'            '************************
'            '10�i����2�i��
'            '************************
'            Dim bytString(1) As Byte    '��������޲Ĕz��
'            Dim strAscii As String      '�ϊ���̕�����
'            strAscii = ""
'            '' '' '' ''strAscii &= Chr(intData1)
'            '' '' '' ''strAscii &= Chr(intData2)
'            '' ''strAscii &= Chr(intData3)
'            '' ''strAscii &= Chr(intData4)
'            bytString(0) = intData4
'            bytString(1) = intData3
'            strAscii = Text.Encoding.GetEncoding(932).GetString(bytString, 0, bytString.Length)     'shift_jis


'            Return (strAscii)
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "  ������2�i��                  (Public  ChangeCharTo2)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ������2�i��
'    ''' </summary>
'    ''' <param name="strChar">����(���p����1���ȊO�̎w���NG�ƂȂ�)</param>
'    ''' <returns>�ϊ��l</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function ChangeCharTo2(ByVal strChar As String) As String
'        Try
'            Dim strMsg As String


'            '************************
'            '������2�i��
'            '************************
'            Dim bytValue() As Byte
'            If IsNothing(strChar) = True Then strChar = ""
'            bytValue = System.Text.Encoding.GetEncoding(932).GetBytes(strChar)


'            '************************
'            '10�i����2�i��
'            '************************
'            Dim strValue2 As String = ""
'            Dim ii As Integer
'            For ii = LBound(bytValue) To UBound(bytValue)
'                Dim strTemp As String
'                strTemp = Convert.ToString(bytValue(ii), 2)
'                If Len(strTemp) < 8 Then
'                    '(�������Ȃ��ꍇ)
'                    Dim jj As Integer
'                    For jj = 1 To 8 - Len(strTemp)
'                        strTemp = "0" & strTemp
'                    Next
'                End If
'                strValue2 = strValue2 & strTemp
'            Next


'            '************************
'            '��������
'            '************************
'            If Len(strValue2) <> 8 Then
'                strMsg = "���Ұ����s���ł��B[���� <> ���p1��]"
'                Throw New Exception(strMsg)
'            End If


'            Return (strValue2)

'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "  ������16�i��                 (Public  ChangeCharTo16)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ������16�i��
'    ''' </summary>
'    ''' <param name="strChar">������</param>
'    ''' <returns>�ϊ��l</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function ChangeCharTo16(ByVal strChar As String) As String
'        Try
'            '' ''Dim strMsg As String


'            '************************
'            '�������޲Ĕz��
'            '************************
'            Dim bytValue() As Byte
'            If IsNothing(strChar) = True Then strChar = ""
'            bytValue = System.Text.Encoding.GetEncoding(932).GetBytes(strChar)


'            '************************
'            '�޲Ĕz��16�i��
'            '************************
'            Dim strValue16 As String = ""
'            Dim ii As Integer
'            For ii = LBound(bytValue) To UBound(bytValue)
'                Dim strTemp As String
'                strTemp = Convert.ToString(bytValue(ii), 16)
'                strTemp = ZERO_PAD(strTemp, 2)
'                strValue16 &= strTemp
'            Next


'            Return (strValue16)

'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "  ������16�i��     [ڼ޽��p]   (Public  ChangeCharTo16Reg)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' ������16�i��
'    ''' </summary>
'    ''' <param name="strChar">������</param>
'    ''' <returns>�ϊ��l</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function ChangeCharTo16Reg(ByVal strChar As String) As String
'        Try
'            '' ''Dim strMsg As String


'            '************************
'            '�������޲Ĕz��
'            '************************
'            Dim bytValue() As Byte
'            If IsNothing(strChar) = True Then strChar = ""
'            bytValue = System.Text.Encoding.GetEncoding(932).GetBytes(strChar)


'            '************************
'            '�����ɋ����������ɂ���
'            '************************
'            If bytValue.Length Mod 2 <> 0 Then
'                ReDim Preserve bytValue(UBound(bytValue) + 1)
'            End If


'            '************************
'            '�޲Ĕz��16�i��
'            '************************
'            Dim strValue16 As String = ""
'            Dim ii As Integer
'            For ii = LBound(bytValue) To UBound(bytValue) Step 2
'                Dim strTemp As String

'                strTemp = Convert.ToString(bytValue(ii + 1), 16)
'                strTemp = ZERO_PAD(strTemp, 2)
'                strValue16 &= strTemp

'                strTemp = Convert.ToString(bytValue(ii), 16)
'                strTemp = ZERO_PAD(strTemp, 2)
'                strValue16 &= strTemp
'            Next


'            Return (strValue16)

'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "  2�i����10�i��                (Public  Change2To10)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' 2�i����10�i��
'    ''' </summary>
'    ''' <param name="strValue2">2�i��</param>
'    ''' <returns>�ϊ��l</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function Change2To10(ByVal strValue2 As String) As Long
'        Try

'            Dim lngValue10 As Long                      '10�i��
'            lngValue10 = Convert.ToInt32(strValue2, 2)


'            '' ''Dim strMsg As String

'            ' '' ''************************
'            ' '' ''2�i����10�i��
'            ' '' ''************************
'            '' ''Dim intKeta As Integer = Len(strValue2)     '2�i���̌���
'            '' ''Dim lngValue10 As Long                      '10�i��
'            '' ''For ii As Integer = intKeta To 1 Step -1
'            '' ''    '(2�i���̌���)

'            '' ''    '�l����
'            '' ''    Dim strBitData As String = Mid(strValue2, ii, 1)
'            '' ''    If Not (strBitData = "0" Or strBitData = "1") Then
'            '' ''        '(01�ȊO)
'            '' ''        strMsg = "2�i�����s���ł��B[" & strValue2 & "]"
'            '' ''        Throw New Exception(strMsg)
'            '' ''    End If

'            '' ''    '�ް��X�V
'            '' ''    lngValue10 += Val(strBitData) * 2 ^ (intKeta - ii)

'            '' ''Next


'            Return (lngValue10)
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "  16�i����10�i��               (Public  Change16To10)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' 16�i����10�i��
'    ''' </summary>
'    ''' <param name="strValue16">16�i��</param>
'    ''' <returns>�ϊ��l</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function Change16To10(ByVal strValue16 As String) As Integer
'        Try
'            Dim strMsg As String

'            '************************
'            '16�i����10�i��
'            '************************
'            Dim intValue10 As Integer
'            If IsNothing(strValue16) = True Then strValue16 = "0"
'            If strValue16 = "" Then strValue16 = "0"
'            Try
'                intValue10 = Convert.ToInt32(strValue16, 16)
'            Catch ex As Exception
'                strMsg = "���Ұ����s���ł��B[16�i����Integer�͈̔͂𒴂��Ă��܂��B]"
'                Throw New Exception(strMsg)
'            End Try


'            Return (intValue10)

'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "  16�i����������               (Public  Change16ToString)"
'    ''' *******************************************************************************************************************
'    ''' <summary>
'    ''' 16�i����������
'    ''' </summary>
'    ''' <param name="strValue16">16�i��</param>
'    ''' <returns>�ϊ��l</returns>
'    ''' <remarks></remarks>
'    ''' *******************************************************************************************************************
'    Public Function Change16ToString(ByVal strValue16 As String) As String
'        Try
'            Dim strMsg As String
'            Dim ii As Integer                       '����
'            Dim strValueString As String = ""       '�ϊ��㕶����
'            If IsNothing(strValue16) = True Then strValue16 = "0"


'            '************************
'            '���O����
'            '************************
'            If strValue16.Length Mod 4 <> 0 Then
'                '(4�Ŋ���؂�Ȃ������ꍇ)
'                strMsg = "���Ұ����s���ł��B[16�i����4�Ŋ���؂�錅���ɂ��ĉ������B]"
'                Throw New Exception(strMsg)
'            End If


'            ii = 0              '����ؾ��
'            While True

'                '************************
'                'ٰ�ߔ���
'                '************************
'                If Len(strValue16) <= ii Then Exit While


'                '************************
'                '4�����؂�o��
'                '************************
'                Dim strTemp As String
'                strTemp = Mid(strValue16, ii + 1, 4)


'                '************************
'                '16�i����10�i��
'                '************************
'                Dim intValue10 As Integer
'                Try
'                    intValue10 = Convert.ToInt32(strTemp, 16)
'                Catch ex As Exception
'                    strMsg = "���Ұ����s���ł��B[16�i����Integer�͈̔͂𒴂��Ă��܂��B]"
'                    Throw New Exception(strMsg)
'                End Try


'                '************************
'                '10�i����������
'                '************************
'                strValueString &= Change10ToStringReg(intValue10)
'                '' ''strValueString &= Change10ToString(intValue10)


'                ii += 4         '��������
'            End While


'            '************************
'            'Null�������폜
'            '************************
'            strValueString = Replace(strValueString, Chr(0), "")


'            Return (strValueString)

'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function
'#End Region
'#Region "�@�l�̌ܓ��@                   (Public  HalfAdjust)"
'    '''*******************************************************************************************************************
'    '''�y�@�\�z<summary>�w�肵�����x�̐��l�Ɏl�̌ܓ����܂��B</summary>
'    '''�y�����z[ IN  ]dValue �@     �F<param name="dValue">�ۂߑΏۂ̔{���x���������_���B</param>
'    '''        [ IN  ]iDigits       �F<param name="iDigits">�߂�l�̗L�������̐��x�B��̫��=0</param>
'    '''�y�ߒl�z                     �F<returns>iDigits �ɓ��������x�̐��l�Ɏl�̌ܓ����ꂽ���l�B</returns>
'    '''*******************************************************************************************************************
'    Public Function HalfAdjust(ByVal dValue As Decimal, Optional ByVal iDigits As Integer = 0) As Decimal
'        Dim dCoef As Decimal = System.Math.Pow(10, iDigits)

'        If dValue > 0 Then
'            Return System.Math.Floor((dValue * dCoef) + 0.5) / dCoef
'        Else
'            Return System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef
'        End If
'    End Function

'#End Region
'#Region "�@�؂�グ�@                   (Public  Kiriage)"
'    ''' <summary>
'    ''' �؂�グ
'    ''' </summary>
'    ''' <param name="dcmValue1">�����鐔</param>
'    ''' <param name="dcmValue2">���鐔</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function Kiriage(ByVal dcmValue1 As Nullable(Of Decimal), ByVal dcmValue2 As Nullable(Of Decimal)) As Long
'        '' ''Public Function Kiriage(ByVal dcmValue1 As Decimal, ByVal dcmValue2 As Decimal) As Long
'        Dim lngReturn As Long       '�߂�l

'        If TO_DECIMAL(dcmValue1) = 0 Then Return 0
'        If TO_DECIMAL(dcmValue2) = 0 Then Return 0

'        If (dcmValue1 Mod dcmValue2) = 0 Then
'            lngReturn = System.Math.Floor(CDec(dcmValue1 / dcmValue2))
'        Else
'            lngReturn = System.Math.Floor(CDec(dcmValue1 / dcmValue2)) + 1
'        End If


'        Return lngReturn
'    End Function
'#End Region
'#Region "�@���Z(�v�Z���ʂ�0�ȉ��̏ꍇ�́A0�Ƃ��ĕԂ�)               (Public  DiffMin0)"
'    ''' <summary>
'    ''' ���Z(�v�Z���ʂ�0�ȉ��̏ꍇ�́A0�Ƃ��ĕԂ�)
'    ''' </summary>
'    ''' <param name="dcmValue1">������鐔</param>
'    ''' <param name="dcmValue2">������</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function DiffMin0(ByVal dcmValue1 As Nullable(Of Decimal) _
'                           , ByVal dcmValue2 As Nullable(Of Decimal) _
'                           ) _
'                           As Decimal
'        Dim decReturn As Decimal       '�߂�l
'        decReturn = TO_DECIMAL(dcmValue1) - TO_DECIMAL(dcmValue2)


'        If decReturn < 0 Then
'            decReturn = 0
'        End If


'        Return decReturn
'    End Function
'#End Region


'#Region "�@Boolean�^�𐔒l�ɕϊ��@                   (Public  BlnToInt)"
'    '''*******************************************************************************************************************
'    ''' <summary>
'    ''' Boolean�^�𐔒l�ɕϊ�
'    ''' </summary>
'    ''' <param name="blnBoolean">�ϊ�����Boolean�^�ϐ�</param>
'    ''' <returns>�ϊ���̐��l</returns>
'    ''' <remarks></remarks>
'    '''*******************************************************************************************************************
'    Public Function BlnToInt(ByVal blnBoolean As Boolean) As Integer
'        Dim intReturn As Integer = -1

'        If blnBoolean = True Then
'            intReturn = 1
'        Else
'            intReturn = 0
'        End If

'        Return intReturn
'    End Function
'#End Region
'#Region "�@���l��Boolean�^�ɕϊ��@                   (Public  IntToBln)"
'    '''*******************************************************************************************************************
'    ''' <summary>
'    ''' ���l��Boolean�^�ɕϊ�
'    ''' </summary>
'    ''' <param name="intInteger">�ϊ����鐔�l�^�ϐ�</param>
'    ''' <returns>Boolean�^</returns>
'    ''' <remarks></remarks>
'    '''*******************************************************************************************************************
'    Public Function IntToBln(ByVal intInteger As Nullable(Of Integer)) As Boolean
'        Dim blnReturn As Boolean = False

'        If intInteger = 0 Or IsNull(intInteger) Then
'            blnReturn = False
'        Else
'            blnReturn = True
'        End If

'        Return blnReturn
'    End Function
'#End Region

'#Region "  �z��̔�r                   (Public  ArrayEquals)"
'    '''***************************************************************************************************************
'    ''' <summary>
'    ''' �z��̔�r
'    ''' </summary>
'    ''' <param name="objArray1">��r����z��1</param>
'    ''' <param name="objArray2">��r����z��2</param>
'    ''' <returns>objArray1��objArray2������̔z��̏ꍇ��True�A����ȊO��False</returns>
'    ''' <remarks>
'    ''' �z��̔�r���s���B
'    ''' objArray1��objArray2���r���A����̔z��̏ꍇ��True�A����ȊO��False��߂�l�Ƃ��ĕԂ��B
'    ''' </remarks>
'    '''***************************************************************************************************************
'    Public Function ArrayEquals(ByVal objArray1() As Integer _
'                              , ByVal objArray2() As Integer _
'                              ) _
'                              As Boolean
'        Dim blnRerutn As Boolean = False        '�߂�l

'        If UBound(objArray1) = UBound(objArray1) Then
'            '(�v�f���������ꍇ)

'            For ii As Integer = LBound(objArray1) To UBound(objArray1)
'                '(ٰ��:�z��1�̗v�f��)

'                If objArray1(ii) <> objArray2(ii) Then Exit For
'                If ii = UBound(objArray1) Then
'                    blnRerutn = True
'                End If

'            Next

'        End If


'        Return blnRerutn
'    End Function
'#End Region
'#Region "  �z����ް��L��               (Public  ArrayFindData)"
'    '''***************************************************************************************************************
'    ''' <summary>
'    ''' �z����ް��L��
'    ''' </summary>
'    ''' <param name="objArray1">�ΏۂƂȂ�z��</param>
'    ''' <param name="objFindData">���������ް�</param>
'    ''' <returns>-1:�ް����Ȃ�     -1�ȊO:�ް���������A�����ް����ŏ��Ɍ��������v�f��</returns>
'    ''' <remarks></remarks>
'    '''***************************************************************************************************************
'    Public Function ArrayFindData(ByVal objArray1() As Object _
'                                , ByVal objFindData As Object _
'                                ) _
'                                As Integer
'        Dim intRerutn As Integer = -1       '�߂�l

'        If IsNothing(objArray1) = False Then
'            For ii As Integer = LBound(objArray1) To UBound(objArray1)
'                '(ٰ��:�z��1�̗v�f��)

'                If objArray1(ii) = objFindData Then
'                    '(�ް������������ꍇ)
'                    intRerutn = ii
'                    Exit For
'                End If
'            Next
'        End If


'        Return intRerutn
'    End Function
'#End Region

'#Region "�@�����Ǘ��ʂ̌������킹        (Public  GetFTR_VOLFormat)"
'    ''' *****************************************************************************************************************
'    ''' <summary>
'    ''' �����Ǘ��ʂ̌������킹
'    ''' </summary>
'    ''' <param name="intFDECIMAL_POINTPosition">�����_�ʒu���̗�ʒu</param>
'    ''' <returns>̫�ϯ�</returns>
'    ''' <remarks></remarks>
'    ''' *****************************************************************************************************************
'    Public Function GetFTR_VOLFormat(ByVal intFDECIMAL_POINTPosition As Integer)

'        Dim strFormat As String = ""        '̫�ϯ�

'        '*********************************************
'        '̫�ϯĂ̐ݒ�
'        '*********************************************
'        Dim intFDECIMAL_POINT As Integer = intFDECIMAL_POINTPosition
'        If intFDECIMAL_POINT = 0 Then
'            '(�����̏ꍇ)
'            strFormat = "#0"
'        Else
'            '(�����_��������̏ꍇ)
'            strFormat = "#0" & "." & StrDup(intFDECIMAL_POINT, "0")
'        End If

'        Return strFormat


'    End Function
'#End Region

'#Region "  �����̉߂���̧�ق��폜                                                                   "
'    '''*******************************************************************************************************************
'    ''' <summary>
'    ''' �����̉߂���̧�ق��폜
'    ''' </summary>
'    ''' <param name="strPath">�폜����̧�ق��߽</param>
'    ''' <param name="intLimit">̧�ق̕ۑ�����(Day)</param>
'    ''' <remarks></remarks>
'    '''*******************************************************************************************************************
'    Public Sub DeleteFile(ByVal strPath As String _
'                        , ByVal intLimit As Integer _
'                        )


'        '*************************************************
'        '�F�X�ݒ�
'        '*************************************************
'        Dim dtmKigen As Date = Now.AddDays(-(intLimit))


'        '*************************************************
'        '̧�ق�̫��ނ��擾
'        '*************************************************
'        Dim objFiles As String() = Nothing
'        '̧�ٖ��擾
'        Dim strTemp01_Array As String() = System.IO.Directory.GetFiles(strPath _
'                                                                     , "*" _
'                                                                     , IO.SearchOption.AllDirectories _
'                                                                     )
'        '̫��ޖ��擾
'        Dim strTemp02_Array As String() = System.IO.Directory.GetDirectories(strPath _
'                                                                           , "*" _
'                                                                           , IO.SearchOption.AllDirectories _
'                                                                           )
'        For Each strTemp As String In strTemp01_Array
'            If IsNull(objFiles) Then ReDim objFiles(0) Else ReDim Preserve objFiles(UBound(objFiles) + 1)
'            objFiles(UBound(objFiles)) = strTemp
'        Next
'        For Each strTemp As String In strTemp02_Array
'            If IsNull(objFiles) Then ReDim objFiles(0) Else ReDim Preserve objFiles(UBound(objFiles) + 1)
'            objFiles(UBound(objFiles)) = strTemp
'        Next
'        If IsNull(objFiles) Then Exit Sub


'        '*************************************************
'        '̧�ق��폜
'        '*************************************************
'        For ii As Integer = 0 To UBound(objFiles)
'            '(ٰ��:̫��ޓ���̧�ِ�)

'            If System.IO.Directory.Exists(objFiles(ii)) Then
'                '(̫��ނ̏ꍇ)

'                '===========================================
'                '��̫��ނ��폜
'                '===========================================
'                If System.IO.Directory.GetFiles(objFiles(ii), "*", IO.SearchOption.AllDirectories).Length = 0 _
'                   And System.IO.Directory.GetDirectories(objFiles(ii), "*", IO.SearchOption.AllDirectories).Length = 0 _
'                   Then
'                    '(̧�ق����݂��Ȃ��ꍇ)
'                    System.IO.Directory.Delete(objFiles(ii))    '�폜
'                End If

'            ElseIf System.IO.File.Exists(objFiles(ii)) Then
'                '(̧�ق̏ꍇ)

'                '===========================================
'                '�������߂���̧�ق��폜
'                '===========================================
'                Dim dtmFileTime As Date = System.IO.File.GetLastWriteTime(objFiles(ii))   '̧�ٍX�V�����擾
'                If dtmFileTime <= dtmKigen Then
'                    '(�������߂����ꍇ)
'                    System.IO.File.Delete(objFiles(ii))         '�폜
'                End If

'            Else
'                '(̧�قł��Ȃ��ꍇ)

'                Continue For '̫��ޖ��폜���Ă��܂����ꍇ�́A̧�ق����݂��Ȃ���������

'            End If

'        Next


'    End Sub
'#End Region

'    '**********************************************************************************************
'    '���������ьŗL

'    '���������ьŗL
'    '**********************************************************************************************

'End Module
