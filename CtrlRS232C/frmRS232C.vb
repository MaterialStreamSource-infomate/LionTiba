'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' �y���́z���P���
' �y�@�\�zRS232C�ʐMýėp��۸���
' �y�쐬�z2008/10/16  KSH  Rev 0.00
'**********************************************************************************************

#Region "  Imports          "
Imports System.IO.Ports
Imports JobCommon
Imports MateCommon.mdlComFunc
#End Region

Public Class frmRS232C

#Region "  ���ʕϐ�         "

    Private mobjSerial As SerialPort        '�ر��߰�
    Private mobjLogWrite As clsWriteLog     '۸ޏo�͸׽

    Private mintListCount As Integer        'ؽ��ޯ���ɕ\������ő�s��
    Private Const DATE_FORMAT_99 As String = "yyyy/MM/dd HH:mm:ss.ffff "     '���ޯ�ޗp      ̫�ϯ�
    Private Const MESSAGE_001 As String = "�y�߰ĵ���݁z"
    Private Const MESSAGE_002 As String = "�y�߰ĸ۰�ށz"
    Private Const MESSAGE_003 As String = "�y  �� �M  �z"
    Private Const MESSAGE_004 As String = "�y  �� �M  �z"

#End Region

#Region "  ̫��۰��"
    Private Sub frmRS232C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            '****************************************************
            '�F�X������
            '****************************************************
            mintListCount = 100


            '*****************************************************
            '۸ޏo�͵�޼ު�Đ���
            '*****************************************************
            mobjLogWrite = New clsWriteLog
            mobjLogWrite.clspFileName = "logForm.log"       '̧�ٖ�         ���
            mobjLogWrite.clspCopyFile = "logForm_old.log"   '̧�ٖ�(�Â�)   ���
            mobjLogWrite.clspMaxSize = 500000               '�ő�̧�ٻ���   ���


            '*****************************************************
            '���̫�ѕ\��
            '*****************************************************
            Call cmdAnalysis_Click(Nothing, Nothing)
            'Me.WindowState = FormWindowState.Minimized


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region

    '���ݸد�
#Region "  �߰ĵ����            ���ݸد�"
    Private Sub cmdPortOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPortOpen.Click
        Try


            '****************************************************
            '�߰ĵ����
            '****************************************************
            If IsNothing(mobjSerial) = False Then
                mobjSerial.Close()       '�ʐM�۰��
                mobjSerial.Dispose()
                mobjSerial = Nothing
            End If
            mobjSerial = New SerialPort(txtPort.Text, _
                                        txtBaud.Text, _
                                        txtParity.Text, _
                                        txtDataLength.Text, _
                                        txtStopBit.Text)


            '�ʐM�����
            mobjSerial.Open()
            Call AddToLog(MESSAGE_001 & "[�߰�:" & txtPort.Text & "]" _
                                      & "[�ްڰ�:" & txtBaud.Text & "]" _
                                      & "[���è:" & txtParity.Text & "]" _
                                      & "[�ް���:" & txtDataLength.Text & "]" _
                                      & "[�į���ޯ�:" & txtStopBit.Text & "]" _
                                      )


            '****************************************************
            'RTS,DTR���
            '****************************************************
            mobjSerial.RtsEnable = chkRTS.Checked
            mobjSerial.DtrEnable = chkDTR.Checked


            '****************************************************
            '��ϰ���
            '****************************************************
            tmrReceive.Interval = txtInterval.Text
            tmrReceive.Enabled = True


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �߰ĸ۰��            ���ݸد�"
    Private Sub cmdPortClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPortClose.Click
        Try


            '****************************************************
            '�߰ĸ۰��
            '****************************************************
            If IsNothing(mobjSerial) = False Then
                mobjSerial.Close()       '�ʐM�۰��
                mobjSerial.Dispose()
                mobjSerial = Nothing
            End If
            Call AddToLog(MESSAGE_002)


            '****************************************************
            '��ϰ���
            '****************************************************
            tmrReceive.Enabled = False


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ÷�đ��M             ���ݸد�"
    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Try

            If IsNothing(mobjSerial) = True Then
                MsgBox("�߰Ă���݂��ĉ������B")
                Exit Sub
            End If


            mobjSerial.Write(txtSend.Text)
            Call AddToLog(MESSAGE_003 & txtSend.Text)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ÷�đ��M(Chr)        ���ݸد�"
    Private Sub cmdSendChr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendChr.Click
        Try
            Dim strChrNum() As String       '���M�d����16�i�z��
            Dim bytChrNum() As Byte         '���M�d����16�i�z��
            strChrNum = Split(txtSendChr.Text, ",")
            ReDim bytChrNum(UBound(strChrNum))
            For ii As Integer = LBound(strChrNum) To UBound(strChrNum)
                '(ٰ��:�z��)
                If Change16To10(strChrNum(ii)) < 0 Or 255 < Change16To10(strChrNum(ii)) Then Throw New Exception("�e�L�X�g�{�b�N�X�ɂ́A�J���}��؂��00�`FF�̐��l��ݒ肵�ĉ������B")
                bytChrNum(ii) = Change16To10(strChrNum(ii))
            Next


            '****************************************************
            '���M
            '****************************************************
            mobjSerial.Write(bytChrNum, 0, bytChrNum.Length)
            Call AddToLog(MESSAGE_003 & txtSendChr.Text)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ���                 ���ݸد�"
    Private Sub cmdAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnalysis.Click
        Try


            Dim objForm As New frmAnalysis
            objForm.objRS232C = Me
            objForm.Show()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

    '�����ޯ��
#Region "  RTS      �����ޯ���د�"
    Private Sub chkRTS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRTS.CheckedChanged, chkDSR.CheckedChanged
        Try
            If IsNothing(mobjSerial) = False Then
                mobjSerial.RtsEnable = chkRTS.Checked
            End If
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  DTR      �����ޯ���د�"
    Private Sub chkDTR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDTR.CheckedChanged, chkCD.CheckedChanged, chkCTS.CheckedChanged
        Try
            If IsNothing(mobjSerial) = False Then
                mobjSerial.DtrEnable = chkDTR.Checked
            End If
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

    '��M��ϰ
#Region "  ��M��ϰ"
    Private Sub tmrReceive_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReceive.Tick
        Try
            tmrReceive.Enabled = False


            Dim strReceiveText As String    '�擾�d��
            Dim strReceiveByte As String    '�擾�d��(�޲�)
            Dim bytRead(2048) As Byte       '�擾�p�޲Ĕz��
            strReceiveText = ""
            strReceiveByte = ""
            If mobjSerial.BytesToRead > 0 Then
                '(��M�ޯ̧���ް������݂����ꍇ)


                '****************************************************
                '��M�ޯ̧�ް��擾
                '****************************************************
                Dim intGetbyte As Integer       '�擾�޲Đ�
                intGetbyte = mobjSerial.Read(bytRead, 0, bytRead.Length)      '�ް��擾
                For ii As Integer = 0 To intGetbyte - 1
                    strReceiveText &= Chr(bytRead(ii))
                    If ii = 0 Then strReceiveByte &= Change10To16(bytRead(ii), 2) Else strReceiveByte &= "," & Change10To16(bytRead(ii), 2)
                Next


                '****************************************************
                '��M�ޯ̧�ް���\���p�ɕϊ�
                '****************************************************
                Dim strDispText As String = ""      '��M�d���\��������
                If rdoASCII.Checked = True Then
                    '(���䕶���\���̏ꍇ)
                    strDispText = strReceiveByte
                Else
                    '(ɰ�ق̏ꍇ)
                    strDispText = strReceiveText
                End If


                txtRecvText.Text = strDispText
                Call AddToLog(MESSAGE_004 & strDispText)
            End If


            '****************************************************
            'ײݏ��      �\��
            '****************************************************
            chkDSR.Checked = mobjSerial.DsrHolding      'Data Set Ready
            chkCTS.Checked = mobjSerial.CtsHolding      'Clear To Send
            chkCD.Checked = mobjSerial.CDHolding        '�|�[�g�̃L�����A���o���C��


            tmrReceive.Enabled = True
        Catch ex As Exception
            ComError(ex)
            tmrReceive.Enabled = False

        End Try
    End Sub
#End Region


#Region "  ��ʴװ����"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����zex         �F�װException
    '�y�ߒl�z
    '*******************************************************************************************************************
    Public Sub ComError(ByVal ex As Exception)
        Try

            '*****************************************************
            '÷�Đ���
            '*****************************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(ex.StackTrace, ",", "�C")       '���p��ς�S�p��ςɕϊ�
            strStackTrace = Split(strTemp, vbCrLf)

            '*****************************************************
            ' ۸ޏ�����
            '*****************************************************
            For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
                AddToLog(ex.Message, _
                         "�y��۸��я�̴װ�z", _
                         strStackTrace(ii))
            Next


        Catch ex2 As Exception
            Throw New Exception(ex2.Message)

        End Try
    End Sub
#End Region
#Region "  ۸ޏ�������"
    '****************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z
    '****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String, _
                        Optional ByVal strMsg_2 As String = "�yհ�ް۸�      �z", _
                        Optional ByVal strMsg_3 As String = "")
        Try

            '*****************************************************
            '̧��۸ޏo��
            '*****************************************************
            mobjLogWrite.WriteLog(strMsg_1, strMsg_2, strMsg_3)              '۸ޏ���


            '*****************************************************
            'ؽďo��
            '*****************************************************
            '==============================================
            '��`���ꂽ�s���܂�ؽ��ޯ���̍s���폜
            '==============================================
            While lstLog.Items.Count >= mintListCount
                lstLog.Items.RemoveAt(lstLog.Items.Count - 1)
            End While

            '==============================================
            'ؽĒǉ�
            '==============================================
            Dim strMessage As String = Format(Now, DATE_FORMAT_99) & Space(5) & strMsg_2 & strMsg_1 & Space(5) & strMsg_3
            If InStr(strMessage, "���݂��ޯ̧") = 0 Then
                lstLog.Items.Insert(0, strMessage)
            End If


        Catch ex2 As Exception
            Throw New Exception(ex2.Message)

        End Try
    End Sub
#End Region

#Region "  ����d�����M         ���ݸد�"
    Private Sub cmdYasukawaSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYasukawaSend.Click
        Try


            '****************************************************
            'CRC        �쐬�p�ް��擾
            '****************************************************
            Dim strChrNum() As String       '���M�d����16�i�z��
            Dim bytChrNum() As Byte         '���M�d����16�i�z��
            strChrNum = Split(txtSendChr.Text, ",")
            ReDim bytChrNum(UBound(strChrNum))
            For ii As Integer = LBound(strChrNum) To UBound(strChrNum)
                '(ٰ��:�z��)
                If Change16To10(strChrNum(ii)) < 0 Or 255 < Change16To10(strChrNum(ii)) Then Throw New Exception("�e�L�X�g�{�b�N�X�ɂ́A�J���}��؂��00�`FF�̐��l��ݒ肵�ĉ������B")
                bytChrNum(ii) = Change16To10(strChrNum(ii))
            Next


            '****************************************************
            'CRC        �쐬
            '****************************************************
            Dim shrKotei As UShort = 40961              '�Œ�l(1010 0000 0000 0001)
            Dim shrCRC As UShort = UShort.MaxValue      'CRC
            For ii As Integer = 0 To UBound(bytChrNum)
                '(ٰ��:�޲Ĕz��̐�����)

                '=======================================
                '�d���Ɖ�CRC�Ƃ�Xor
                '=======================================
                shrCRC = shrCRC Xor bytChrNum(ii)


                For jj As Integer = 1 To 8
                    '(ٰ��:���8�ޯ�(���ۂɂ͉���8�ޯ�))


                    If Microsoft.VisualBasic.Right(Change10To2(shrCRC, 16), 1) = "0" Then
                        '(0�̏ꍇ)

                        '=======================================
                        '�E���
                        '2�Ŋ���ƉE��Ă���
                        '=======================================
                        shrCRC = shrCRC \ 2

                    Else
                        '(1�̏ꍇ)

                        '=======================================
                        '�E���
                        '2�Ŋ���ƉE��Ă���
                        '=======================================
                        shrCRC = shrCRC \ 2

                        '=======================================
                        '�Œ�l�Ɖ�CRC�Ƃ�Xor
                        '=======================================
                        shrCRC = shrCRC Xor shrKotei

                    End If



                Next

            Next


            ''****************************************************
            ''CRC��16�i���ɕϊ�
            ''****************************************************
            'Dim bytCRC(1) As Byte                           'CRC(�޲Ĕz��)
            'bytCRC(0) = shrCRC Mod 256
            'bytCRC(1) = shrCRC \ 255


            '****************************************************
            'CRC��16�i���ɕϊ�
            '****************************************************
            Dim strCRC As String = Change10To16(shrCRC, 4)  'CRC(16�i��4��)
            Dim bytCRC(1) As Byte                           'CRC(�޲Ĕz��)
            bytCRC(0) = Change16To10(MID_SJIS(strCRC, 3, 2))
            bytCRC(1) = Change16To10(MID_SJIS(strCRC, 1, 2))


            '****************************************************
            'CRC��z��ɒǉ�
            '****************************************************
            ReDim Preserve bytChrNum(UBound(bytChrNum) + 2)
            bytChrNum(UBound(bytChrNum) - 1) = bytCRC(0)
            bytChrNum(UBound(bytChrNum) - 0) = bytCRC(1)


            ''****************************************************
            ''ɰ�ٓd��       ���M
            ''****************************************************
            'Call cmdSendChr_Click(Nothing, Nothing)


            '****************************************************
            'CRC            ���M
            '****************************************************
            mobjSerial.Write(bytChrNum, 0, bytChrNum.Length)
            'mobjSerial.Write(bytCRC, 0, bytCRC.Length)
            Call AddToLog(MESSAGE_003 & "�yCRC�z" & Change10To16(bytCRC(0), 2) & "," & Change10To16(bytCRC(1), 2))


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region


End Class