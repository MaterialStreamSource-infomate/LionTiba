'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' �y���́z���P���
' �y�@�\�zRS232C�ʐMýėp��۸���
' �y�쐬�z2012/01/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports          "
Imports System.Text
Imports JobCommon
Imports MateCommon
Imports UserProcess
Imports MateCommon.clsConst
Imports MateCommon.mdlComFunc
#End Region

Public Class frmAnalysis

#Region "  ���ʕϐ�                             "
    Private mobjRS232C As frmRS232C
#End Region
#Region "  �����è                              "
    ''' <summary>
    ''' �e̫�ѵ�޼ު��
    ''' </summary>
    Public Property objRS232C() As frmRS232C
        Get
            Return mobjRS232C
        End Get
        Set(ByVal Value As frmRS232C)
            mobjRS232C = Value
        End Set
    End Property
#End Region
#Region "  ̫��۰��                             "
    Private Sub frmAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            txtLineEyeTextFile.AllowDrop = True
            txtTextFile02.AllowDrop = True
            txtTelegramAnalysis01.AllowDrop = True
            txtTelegramAnalysis02.AllowDrop = True

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ��ׯ�� & ��ۯ�� ��̧���߽���擾      "

    '******************************************************
    '̧���߽
    '******************************************************
    Private Sub txtLineEyeTextFile_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtLineEyeTextFile.DragEnter
        Try

            '�t�@�C���`���̏ꍇ�̂݁A�h���b�O���󂯕t���܂��B
            If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub

    Private Sub txtLineEyeTextFile_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtLineEyeTextFile.DragDrop
        Try

            '�h���b�O���ꂽ�t�@�C���E�t�H���_�̃p�X���i�[���܂��B
            Dim strFileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

            '�t�@�C���̑��݊m�F���s���A����ꍇ�ɂ̂݁A
            '�e�L�X�g�{�b�N�X�Ƀp�X��\�����܂��B
            '�i���̏����Ńt�H���_��ΏۊO�ɂ��Ă��܂��B�j
            If System.IO.File.Exists(strFileName(0).ToString) = True Then
                Me.txtLineEyeTextFile.Text = strFileName(0).ToString
            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub


    '******************************************************
    '̧���߽2
    '******************************************************
    Private Sub txtTextFile02_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTextFile02.DragEnter
        Try

            '�t�@�C���`���̏ꍇ�̂݁A�h���b�O���󂯕t���܂��B
            If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub

    Private Sub txtTextFile02_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTextFile02.DragDrop
        Try

            '�h���b�O���ꂽ�t�@�C���E�t�H���_�̃p�X���i�[���܂��B
            Dim strFileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

            '�t�@�C���̑��݊m�F���s���A����ꍇ�ɂ̂݁A
            '�e�L�X�g�{�b�N�X�Ƀp�X��\�����܂��B
            '�i���̏����Ńt�H���_��ΏۊO�ɂ��Ă��܂��B�j
            If System.IO.File.Exists(strFileName(0).ToString) = True Then
                Me.txtTextFile02.Text = strFileName(0).ToString
            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

#End Region
#Region "  ��ׯ�� & ��ۯ�� ��÷�Ă��擾         "

    '����d��01
    Private Sub txtTelegramAnalysis01_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTelegramAnalysis01.DragDrop
        txtTelegramAnalysis01.Text = e.Data.GetData(DataFormats.Text).ToString
    End Sub
    Private Sub txtTelegramAnalysis01_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTelegramAnalysis01.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    '����d��02
    Private Sub txtTelegramAnalysis02_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTelegramAnalysis02.DragDrop
        txtTelegramAnalysis02.Text = e.Data.GetData(DataFormats.Text).ToString
    End Sub
    Private Sub txtTelegramAnalysis02_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTelegramAnalysis02.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

#End Region
#Region "  ���n���̧�ُo��             ���ݸد�"
    Private Sub cmdAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnalysis.Click
        Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '�����ݒ�
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim strSD01 As String = ""        '���M�d��01÷��
            Dim strSD02 As String = ""        '���M�d��02÷��
            Dim strRD01 As String = ""        '��M�d��01÷��
            Dim strRD02 As String = ""        '��M�d��02÷��


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '̧�ٓǍ�
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
            Try
                While (objSR01.Peek >= 0)
                    '(ٰ��:�Ǎ��s�ƂȂ�܂�)


                    '**************************************
                    '��s�ځA��s�ړǍ�
                    '**************************************
                    Dim blnSD As Boolean = False    '���M÷���׸�
                    Dim blnRD As Boolean = False    '��M÷���׸�
                    Dim strTemp01 As String = objSR01.ReadLine()    '��s��÷��
                    If Microsoft.VisualBasic.Left(strTemp01, 3) = "SD:" Then
                        '(���M�d���̏ꍇ)
                        blnSD = True
                    ElseIf Microsoft.VisualBasic.Left(strTemp01, 3) = "RD:" Then
                        '(��M�d���̏ꍇ)
                        blnRD = True
                    Else
                        Continue While
                    End If
                    Dim strTemp02 As String = objSR01.ReadLine()    '��s��÷��


                    '**************************************
                    '÷�ĕҏW
                    '**************************************
                    strTemp01 = MidD(strTemp01, 4)      '���M�d��÷��
                    strTemp02 = MidD(strTemp02, 4)      '���M�d��÷��
                    strTemp01 = SPC_PAD_LEFT_SJIS(strTemp01, 56)      '���M�d��÷��
                    strTemp02 = SPC_PAD_LEFT_SJIS(strTemp02, 56)      '��M�d��÷��



                    '**************************************
                    '÷�č���
                    '**************************************
                    If blnSD = True Then
                        '(���M�d���̏ꍇ)
                        strSD01 &= strTemp01
                        strSD02 &= strTemp02
                    ElseIf blnRD = True Then
                        '(��M�d���̏ꍇ)
                        strRD01 &= strTemp01
                        strRD02 &= strTemp02
                    End If


                End While


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '����̧�ُo��
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '***********************
            'StreamWriter   �쐬
            '***********************
            Dim strDirectoryName As String = System.IO.Path.GetDirectoryName(txtLineEyeTextFile.Text)                           '�߽
            Dim strFileNameWithoutExtension As String = System.IO.Path.GetFileNameWithoutExtension(txtLineEyeTextFile.Text)     '�g���q���܂܂Ȃ�̧�ٖ�
            Dim strExtension As String = System.IO.Path.GetExtension(txtLineEyeTextFile.Text)                                   '�g���q
            'System.IO.Directory.CreateDirectory(strFilePath)        '̫��ނ̍쐬
            Dim objSW01 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_01" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JIS�ŏ�������
            Try
                objSW01.WriteLine(strSD01)          '�ǉ�
                objSW01.WriteLine(strSD02)          '�ǉ�
                'objSW01.Write(strRD01)          '�ǉ�
                'objSW01.Write(strRD02)          '�ǉ�
            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '[ TMSP ]��u��
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'Dim strSD01_Origin As String = strSD01        '���M�d��01÷��
            'Dim strSD02_Origin As String = strSD02        '���M�d��02÷��
            'Dim strRD01_Origin As String = strRD01        '��M�d��01÷��
            'Dim strRD02_Origin As String = strRD02        '��M�d��02÷��
            For ii As Integer = 1 To strSD01.Length - 8
                '(ٰ��:�u���\�ȕ�����)

                If MidD(strSD01, ii, 8) = TMSP Then
                    '([ TMSP ]�̏ꍇ)

                    If ii = 1 Then
                        strSD01 = MidD(strSD02, ii, 8) & MidD(strSD01, 9)
                        strRD01 = MidD(strSD02, ii, 8) & MidD(strRD01, 9)
                        strRD02 = MidD(strSD02, ii, 8) & MidD(strRD02, 9)
                    Else
                        strSD01 = MidD(strSD01, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strSD01, ii + 8)
                        strRD01 = MidD(strRD01, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strRD01, ii + 8)
                        strRD02 = MidD(strRD02, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strRD02, ii + 8)
                    End If

                End If


                '***********************
                '�i���\��
                '***********************
                If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                    lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                    Me.Refresh()
                    System.Windows.Forms.Application.DoEvents()
                End If


            Next


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '�d�����Ɉ�s�ɂ���
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSW02 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_02" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JIS�ŏ�������
            '������������********************************************************************************************************************************************************************************************************************************************
            '������������********************************************************************************************************************************************************************************************************************************************
            '���ϲ��

            Dim objSW03 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_91" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JIS�ŏ�������
            Dim strReadCommand(0) As String

            '������������********************************************************************************************************************************************************************************************************************************************
            '������������********************************************************************************************************************************************************************************************************************************************
            Try
                Dim strSDTemp01 As String = ""
                Dim strSDTemp02 As String = ""
                Dim strRDTemp01 As String = ""
                Dim strRDTemp02 As String = ""
                For ii As Integer = 1 To strSD01.Length
                    '(ٰ��:������̒���)


                    '**********************************************
                    '̧�ُo��       ����
                    '**********************************************
                    Dim blnOutFile As Boolean = False
                    If ii <= strSD01.Length - 8 And IsNotNull(strSDTemp01.ToString) Then
                        '(�����ް��������Ă���\��������ꍇ)

                        If rdoMakeFileNon.Checked Then
                            '(�����ް����ɋ�؂�ꍇ)

                            If MidD(strSD01, ii, 1) = "[" _
                               And MidD(strSD01, ii + 7, 1) = "]" _
                               And IsDate("2000/01/01 " & MidD(strSD01, ii + 1, 2) & ":" & MidD(strSD01, ii + 3, 2) & ":" & MidD(strSD01, ii + 5, 2)) _
                               Then
                                '(�����ް��������Ă���ꍇ)
                                blnOutFile = True
                            End If

                        ElseIf rdoMakeFileSend.Checked Then
                            '(���M-��M��Ă̏ꍇ)

                            If MidD(strSD01, ii, 1) = "[" _
                               And MidD(strSD01, ii + 7, 3) <> "] -" _
                               And IsDate("2000/01/01 " & MidD(strSD01, ii + 1, 2) & ":" & MidD(strSD01, ii + 3, 2) & ":" & MidD(strSD01, ii + 5, 2)) _
                               Then
                                '(�����ް��������Ă���ꍇ)
                                blnOutFile = True
                            End If

                        ElseIf rdoMakeFileRecv.Checked Then
                            '(��M-���M��Ă̏ꍇ)

                            If MidD(strRD01, ii, 1) = "[" _
                               And MidD(strRD01, ii + 7, 3) <> "] -" _
                               And IsDate("2000/01/01 " & MidD(strRD01, ii + 1, 2) & ":" & MidD(strRD01, ii + 3, 2) & ":" & MidD(strRD01, ii + 5, 2)) _
                               Then
                                '(�����ް��������Ă���ꍇ)
                                blnOutFile = True
                            End If

                        End If


                    End If


                    '**********************************************
                    '̧�ُo��
                    '**********************************************
                    If blnOutFile = True Then
                        '(̧�ُo�͂���̏ꍇ)

                        If chkBinary.Checked = True Then objSW02.WriteLine(strSDTemp01.ToString) '�ǉ�
                        If chkAscii.Checked = True Then objSW02.WriteLine(strSDTemp02.ToString) '�ǉ�
                        If chkBinary.Checked = True Then objSW02.WriteLine(strRDTemp01.ToString) '�ǉ�
                        If chkAscii.Checked = True Then objSW02.WriteLine(strRDTemp02.ToString) '�ǉ�
                        objSW02.WriteLine("")               '�ǉ�(���s)

                        '������������********************************************************************************************************************************************************************************************************************************************
                        '������������********************************************************************************************************************************************************************************************************************************************
                        '���ϲ��

                        ''�Ǎ��ݺ���ގ擾02(ذ�ޱ��ڽ�ꗗ)
                        'Dim strTemp As String = Mid(strSDTemp01, 13, 4)
                        'If ArrayFindData(strReadCommand, strTemp) = -1 And InStr(strSDTemp01, "]0310") = 0 Then
                        '    objSW03.WriteLine(TO_STRING(40001 + Change16To10(strTemp)))
                        '    ReDim Preserve strReadCommand(UBound(strReadCommand) + 1)
                        '    strReadCommand(UBound(strReadCommand)) = strTemp
                        'End If

                        ''�Ǎ��ݺ���ގ擾01(ذ�޺���ވꗗ)
                        'Dim strTemp As String = Mid(strSDTemp01, 8, 9)
                        'If ArrayFindData(strReadCommand, strTemp) = -1 And InStr(strSDTemp01, "]0310") = 0 Then
                        '    objSW03.WriteLine(strSDTemp01)
                        '    ReDim Preserve strReadCommand(UBound(strReadCommand) + 1)
                        '    strReadCommand(UBound(strReadCommand)) = strTemp
                        'End If

                        '�����ݺ���ގ擾01
                        'If 1 <= InStr(strSDTemp01, "]0310") And InStr(strSDTemp01, "]0310206C") = 0 Then
                        '    objSW03.WriteLine(strSDTemp01)
                        'End If

                        '������������********************************************************************************************************************************************************************************************************************************************
                        '������������********************************************************************************************************************************************************************************************************************************************

                        strSDTemp01 = ""       '������
                        strSDTemp02 = ""       '������
                        strRDTemp01 = ""       '������
                        strRDTemp02 = ""       '������

                    End If


                    '***********************
                    '�ꕶ���������o��
                    '***********************
                    strSDTemp01 &= (MidD(strSD01, ii, 1))
                    strSDTemp02 &= (MidD(strSD02, ii, 1))
                    strRDTemp01 &= (MidD(strRD01, ii, 1))
                    strRDTemp02 &= (MidD(strRD02, ii, 1))


                    '***********************
                    '̧�ُo��
                    '***********************
                    If ii = strSD01.Length Then
                        '(�ް����I������ꍇ)
                        objSW02.WriteLine(strSDTemp01.ToString)          '�ǉ�
                        objSW02.WriteLine(strSDTemp02.ToString)          '�ǉ�
                        objSW02.WriteLine(strRDTemp01.ToString)          '�ǉ�
                        objSW02.WriteLine(strRDTemp02.ToString)          '�ǉ�
                    End If


                    '***********************
                    '�i���\��
                    '***********************
                    If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                        lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()
                    End If


                Next


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW02.Close()
                objSW03.Close()
            End Try


            ''**************************************
            ''̧�ٓǍ�
            ''**************************************
            'Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
            'objSR01.ReadLine()    '��s�擾
            'objSR01.ReadLine()    '��s�擾
            'Dim strDBBackupPath As String = Trim(MidD(objSR01.ReadLine(), 4))
            'If System.IO.Directory.Exists(strDBBackupPath) = False Then
            '    '(̫��ނ����݂��Ȃ��ꍇ)
            '    Call AddToMsgLog(Now, FMSG_ID_S9002, "�O�t��HDD���ޯ����ߐ悪�F���o���܂���B", "�u" & strDBBackupPath & "�v��������܂���")
            '    Return RetCode.OK
            'End If





        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ð��قɒǉ�                  ���ݸد�"
    Private Sub cmdDBInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDBInsert.Click
        Try
            Dim strMsg As String = ""
            Dim intRet As RetCode


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '�����ݒ�
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim strSD01 As String = ""        '���M�d��01÷��
            Dim strSD02 As String = ""        '���M�d��02÷��
            Dim strRD01 As String = ""        '��M�d��01÷��
            Dim strRD02 As String = ""        '��M�d��02÷��

            '===============================================
            '�F�X����
            '===============================================
            If IsDate(txtInsertDate.Text) = False Then
                strMsg = "���t�ݒ���s���ĉ������B"
                MsgBox(strMsg)
                Throw New Exception(strMsg)
            End If

            '===============================================
            'DB�ڑ�
            '===============================================
            Dim objSystem As New clsConnectConfig(CONFIG_FILE)
            Dim objDb As New JobCommon.clsConn
            objDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            Dim blnRet As Boolean = False
            blnRet = objDb.Connect()
            If blnRet = False Then Throw New Exception("DB�ڑ��װ")

            '===============================================
            'ð��ٸ׽��` & ��ݻ޸��݊J�n
            '===============================================
            Dim objXLOG_MODBUS As New TBL_XLOG_MODBUS(Nothing, objDb, objDb)
            objDb.BeginTrans()


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '̧�ٓǍ�
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
            Try
                While (objSR01.Peek >= 0)
                    '(ٰ��:�Ǎ��s�ƂȂ�܂�)


                    '**************************************
                    '��s�ځA��s�ړǍ�
                    '**************************************
                    Dim blnSD As Boolean = False    '���M÷���׸�
                    Dim blnRD As Boolean = False    '��M÷���׸�
                    Dim strTemp01 As String = objSR01.ReadLine()    '��s��÷��
                    If Microsoft.VisualBasic.Left(strTemp01, 3) = "SD:" Then
                        '(���M�d���̏ꍇ)
                        blnSD = True
                    ElseIf Microsoft.VisualBasic.Left(strTemp01, 3) = "RD:" Then
                        '(��M�d���̏ꍇ)
                        blnRD = True
                    Else
                        Continue While
                    End If
                    Dim strTemp02 As String = objSR01.ReadLine()    '��s��÷��


                    '**************************************
                    '÷�ĕҏW
                    '**************************************
                    strTemp01 = MidD(strTemp01, 4)      '���M�d��÷��
                    strTemp02 = MidD(strTemp02, 4)      '���M�d��÷��
                    strTemp01 = SPC_PAD_LEFT_SJIS(strTemp01, 56)      '���M�d��÷��
                    strTemp02 = SPC_PAD_LEFT_SJIS(strTemp02, 56)      '��M�d��÷��



                    '**************************************
                    '÷�č���
                    '**************************************
                    If blnSD = True Then
                        '(���M�d���̏ꍇ)
                        strSD01 &= strTemp01
                        strSD02 &= strTemp02
                    ElseIf blnRD = True Then
                        '(��M�d���̏ꍇ)
                        strRD01 &= strTemp01
                        strRD02 &= strTemp02
                    End If


                End While


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '����̧�ُo��
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '***********************
            'StreamWriter   �쐬
            '***********************
            Dim strDirectoryName As String = System.IO.Path.GetDirectoryName(txtLineEyeTextFile.Text)                           '�߽
            Dim strFileNameWithoutExtension As String = System.IO.Path.GetFileNameWithoutExtension(txtLineEyeTextFile.Text)     '�g���q���܂܂Ȃ�̧�ٖ�
            Dim strExtension As String = System.IO.Path.GetExtension(txtLineEyeTextFile.Text)                                   '�g���q
            'System.IO.Directory.CreateDirectory(strFilePath)        '̫��ނ̍쐬
            Dim objSW01 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_01" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JIS�ŏ�������
            Try
                objSW01.WriteLine(strSD01)          '�ǉ�
                objSW01.WriteLine(strSD02)          '�ǉ�
                'objSW01.Write(strRD01)          '�ǉ�
                'objSW01.Write(strRD02)          '�ǉ�
            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '[ TMSP ]��u��
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'Dim strSD01_Origin As String = strSD01        '���M�d��01÷��
            'Dim strSD02_Origin As String = strSD02        '���M�d��02÷��
            'Dim strRD01_Origin As String = strRD01        '��M�d��01÷��
            'Dim strRD02_Origin As String = strRD02        '��M�d��02÷��
            For ii As Integer = 1 To strSD01.Length - 8
                '(ٰ��:�u���\�ȕ�����)

                If MidD(strSD01, ii, 8) = TMSP Then
                    '([ TMSP ]�̏ꍇ)

                    If ii = 1 Then
                        strSD01 = MidD(strSD02, ii, 8) & MidD(strSD01, 9)
                        strRD01 = MidD(strSD02, ii, 8) & MidD(strRD01, 9)
                        strRD02 = MidD(strSD02, ii, 8) & MidD(strRD02, 9)
                    Else
                        strSD01 = MidD(strSD01, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strSD01, ii + 8)
                        strRD01 = MidD(strRD01, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strRD01, ii + 8)
                        strRD02 = MidD(strRD02, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strRD02, ii + 8)
                    End If

                End If


                '***********************
                '�i���\��
                '***********************
                If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                    lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                    Me.Refresh()
                    System.Windows.Forms.Application.DoEvents()
                End If


            Next


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '�d�����Ɉ�s�ɂ���
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSW02 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_02" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JIS�ŏ�������
            '������������********************************************************************************************************************************************************************************************************************************************
            '������������********************************************************************************************************************************************************************************************************************************************
            '���ϲ��

            Dim objSW03 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_91" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JIS�ŏ�������
            Dim strReadCommand(0) As String

            '������������********************************************************************************************************************************************************************************************************************************************
            '������������********************************************************************************************************************************************************************************************************************************************
            Try
                Dim strSDTemp01 As String = ""
                Dim strSDTemp02 As String = ""
                Dim strRDTemp01 As String = ""
                Dim strRDTemp02 As String = ""
                For ii As Integer = 1 To strSD01.Length
                    '(ٰ��:������̒���)
                    Try


                        '**********************************************
                        '̧�ُo��       ����
                        '**********************************************
                        Dim blnOutFile As Boolean = False
                        If ii <= strSD01.Length - 8 And IsNotNull(strSDTemp01.ToString) Then
                            '(�����ް��������Ă���\��������ꍇ)

                            If rdoMakeFileNon.Checked Then
                                '(�����ް����ɋ�؂�ꍇ)

                                If MidD(strSD01, ii, 1) = "[" _
                                   And MidD(strSD01, ii + 7, 1) = "]" _
                                   And IsDate("2000/01/01 " & MidD(strSD01, ii + 1, 2) & ":" & MidD(strSD01, ii + 3, 2) & ":" & MidD(strSD01, ii + 5, 2)) _
                                   Then
                                    '(�����ް��������Ă���ꍇ)
                                    blnOutFile = True
                                End If

                            ElseIf rdoMakeFileSend.Checked Then
                                '(���M-��M��Ă̏ꍇ)

                                If MidD(strSD01, ii, 1) = "[" _
                                   And MidD(strSD01, ii + 7, 3) <> "] -" _
                                   And IsDate("2000/01/01 " & MidD(strSD01, ii + 1, 2) & ":" & MidD(strSD01, ii + 3, 2) & ":" & MidD(strSD01, ii + 5, 2)) _
                                   Then
                                    '(�����ް��������Ă���ꍇ)
                                    blnOutFile = True
                                End If

                            ElseIf rdoMakeFileRecv.Checked Then
                                '(��M-���M��Ă̏ꍇ)

                                If MidD(strRD01, ii, 1) = "[" _
                                   And MidD(strRD01, ii + 7, 3) <> "] -" _
                                   And IsDate("2000/01/01 " & MidD(strRD01, ii + 1, 2) & ":" & MidD(strRD01, ii + 3, 2) & ":" & MidD(strRD01, ii + 5, 2)) _
                                   Then
                                    '(�����ް��������Ă���ꍇ)
                                    blnOutFile = True
                                End If

                            End If


                        End If


                        '**********************************************
                        '̧�ُo��
                        '**********************************************
                        If blnOutFile = True Then
                            '(̧�ُo�͂���̏ꍇ)

                            If chkBinary.Checked = True Then objSW02.WriteLine(strSDTemp01.ToString) '�ǉ�
                            If chkAscii.Checked = True Then objSW02.WriteLine(strSDTemp02.ToString) '�ǉ�
                            If chkBinary.Checked = True Then objSW02.WriteLine(strRDTemp01.ToString) '�ǉ�
                            If chkAscii.Checked = True Then objSW02.WriteLine(strRDTemp02.ToString) '�ǉ�
                            objSW02.WriteLine("")               '�ǉ�(���s)

                            '������������********************************************************************************************************************************************************************************************************************************************
                            '������������********************************************************************************************************************************************************************************************************************************************
                            'ð��قɒǉ�

                            Try


                                '********************************************************************************************
                                'PC ��PLC       �d���擾
                                '********************************************************************************************
                                Dim strInsertDateSend As String = txtInsertDate.Text & Space(1) & MidD(strSDTemp01, 2, 2) & ":" & MidD(strSDTemp01, 4, 2) & ":" & MidD(strSDTemp01, 6, 2)       '���������擾(PC ��PLC)
                                Dim dtmInsertDateSend As Date = CDate(strInsertDateSend)                                                                                                        '���������擾(PC ��PLC)
                                Dim intStart02 As Integer = InStr(9, strSDTemp01, "[")          '��ڂ́u [ �v�̈ʒu���擾
                                Dim strTelSend As String = Mid(strSDTemp01, 9, intStart02 - 9)  'PC��PLC        �d��


                                '********************************************************************************************
                                'PLC��PC        �d���擾
                                '********************************************************************************************
                                Dim strInsertDateRecv As String = txtInsertDate.Text & Space(1) & MidD(strRDTemp01, intStart02 + 1, 2) & ":" & MidD(strRDTemp01, intStart02 + 3, 2) & ":" & MidD(strRDTemp01, intStart02 + 5, 2)    '���������擾(PLC��PC)
                                Dim dtmInsertDateRecv As Date = CDate(strInsertDateRecv)                                                                                                                                            '���������擾(PC ��PLC)
                                Dim strTelRecv As String = Mid(strRDTemp01, intStart02 + 8)               'PLC��PC        �d��


                                '********************************************************************************************
                                'ð��قɒǉ�����
                                '********************************************************************************************
                                Dim blnInsert As Boolean = True     '�ǉ��׸�
                                If chkCheckSame.Checked = True Then
                                    '(����ں��ނ͒ǉ����Ȃ��ꍇ)
                                    objXLOG_MODBUS.CLEAR_PROPERTY()
                                    objXLOG_MODBUS.FLOG_CHECK_DT1 = dtmInsertDateSend
                                    objXLOG_MODBUS.FLOG_CHECK_DT2 = dtmInsertDateRecv
                                    objXLOG_MODBUS.FDENBUN = strTelSend
                                    objXLOG_MODBUS.FDENBUN02 = strTelRecv
                                    intRet = objXLOG_MODBUS.GET_XLOG_MODBUS(False)
                                    If intRet = RetCode.OK Then
                                        '(���������ꍇ)
                                        blnInsert = False
                                        Call AddToLog("����ں��ނ����������ׁAں��ނ͒ǉ����܂���B[�m�F����_1:" & dtmInsertDateSend & "]" _
                                                                                                  & "[�m�F����_2:" & dtmInsertDateRecv & "]" _
                                                                                                  & "[�ʐM�d��:" & strTelSend & "]" _
                                                                                                  & "[�ʐM�d��02:" & strTelRecv & "]" _
                                                                                                    )
                                    End If
                                End If



                                '********************************************************************************************
                                'ð��قɒǉ�
                                '********************************************************************************************
                                If blnInsert = True Then
                                    '(�ǉ�����ꍇ)
                                    objXLOG_MODBUS.CLEAR_PROPERTY()
                                    objXLOG_MODBUS.FLOG_CHECK_DT1 = dtmInsertDateSend       '�m�F����_1
                                    objXLOG_MODBUS.FLOG_CHECK_DT2 = dtmInsertDateRecv       '�m�F����_2
                                    objXLOG_MODBUS.FDENBUN = strTelSend                     '�ʐM�d��
                                    objXLOG_MODBUS.FDENBUN02 = strTelRecv                   '�ʐM�d��02
                                    objXLOG_MODBUS.ADD_XLOG_MODBUS_SEQ()
                                End If


                            Catch ex As Exception
                                ComError(ex)

                            End Try

                            '������������********************************************************************************************************************************************************************************************************************************************
                            '������������********************************************************************************************************************************************************************************************************************************************



                            '������������********************************************************************************************************************************************************************************************************************************************
                            '������������********************************************************************************************************************************************************************************************************************************************
                            '���ϲ��

                            ''�Ǎ��ݺ���ގ擾02(ذ�ޱ��ڽ�ꗗ)
                            'Dim strTemp As String = Mid(strSDTemp01, 13, 4)
                            'If ArrayFindData(strReadCommand, strTemp) = -1 And InStr(strSDTemp01, "]0310") = 0 Then
                            '    objSW03.WriteLine(TO_STRING(40001 + Change16To10(strTemp)))
                            '    ReDim Preserve strReadCommand(UBound(strReadCommand) + 1)
                            '    strReadCommand(UBound(strReadCommand)) = strTemp
                            'End If

                            ''�Ǎ��ݺ���ގ擾01(ذ�޺���ވꗗ)
                            'Dim strTemp As String = Mid(strSDTemp01, 8, 9)
                            'If ArrayFindData(strReadCommand, strTemp) = -1 And InStr(strSDTemp01, "]0310") = 0 Then
                            '    objSW03.WriteLine(strSDTemp01)
                            '    ReDim Preserve strReadCommand(UBound(strReadCommand) + 1)
                            '    strReadCommand(UBound(strReadCommand)) = strTemp
                            'End If

                            '�����ݺ���ގ擾01
                            'If 1 <= InStr(strSDTemp01, "]0310") And InStr(strSDTemp01, "]0310206C") = 0 Then
                            '    objSW03.WriteLine(strSDTemp01)
                            'End If

                            '������������********************************************************************************************************************************************************************************************************************************************
                            '������������********************************************************************************************************************************************************************************************************************************************

                            strSDTemp01 = ""       '������
                            strSDTemp02 = ""       '������
                            strRDTemp01 = ""       '������
                            strRDTemp02 = ""       '������

                        End If


                        '***********************
                        '�ꕶ���������o��
                        '***********************
                        strSDTemp01 &= (MidD(strSD01, ii, 1))
                        strSDTemp02 &= (MidD(strSD02, ii, 1))
                        strRDTemp01 &= (MidD(strRD01, ii, 1))
                        strRDTemp02 &= (MidD(strRD02, ii, 1))


                        '***********************
                        '̧�ُo��
                        '***********************
                        If ii = strSD01.Length Then
                            '(�ް����I������ꍇ)
                            objSW02.WriteLine(strSDTemp01.ToString)          '�ǉ�
                            objSW02.WriteLine(strSDTemp02.ToString)          '�ǉ�
                            objSW02.WriteLine(strRDTemp01.ToString)          '�ǉ�
                            objSW02.WriteLine(strRDTemp02.ToString)          '�ǉ�
                        End If


                        '***********************
                        '�i���\��
                        '***********************
                        If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                            lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                            Me.Refresh()
                            System.Windows.Forms.Application.DoEvents()
                        End If


                    Catch ex As Exception
                        ComError(ex)
                    End Try
                Next


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW02.Close()
                objSW03.Close()
                objDb.Commit()
            End Try


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  Melsec�d�����               ���ݸد�"
    Private Sub cmdMelsecAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMelsecAnalysis.Click
        Try
            Dim strMsg As String = ""
            'Dim intRet As RetCode


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '�����ݒ�
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim strSD01 As String = ""          '���M�d��01÷��
            Dim strRD01 As String = ""          '��M�d��01÷��

            '===============================================
            '�F�X����
            '===============================================
            If IsDate(txtInsertDate.Text) = False Then
                strMsg = "���t�ݒ���s���ĉ������B"
                MsgBox(strMsg)
                Throw New Exception(strMsg)
            End If

            '===============================================
            'DB�ڑ�
            '===============================================
            Dim objSystem As New clsConnectConfig(CONFIG_FILE)
            Dim objDb As New JobCommon.clsConn
            objDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            Dim blnRet As Boolean = False
            blnRet = objDb.Connect()
            If blnRet = False Then Throw New Exception("DB�ڑ��װ")

            '===============================================
            'ð��ٸ׽��` & ��ݻ޸��݊J�n
            '===============================================
            Dim objXLOG_MELSEC As New TBL_XLOG_MELSEC(Nothing, objDb, objDb)
            objDb.BeginTrans()


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '̧�ٓǍ�
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '****************************************************************************
            'PC ��PLC
            '****************************************************************************
            Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
            Try


                '**************************************
                '�Ǎ�
                '**************************************
                strSD01 = objSR01.ReadToEnd()    '��s��÷��


                '**************************************
                '���ʂȕ��������ڰ�
                '**************************************
                strSD01 = Replace(strSD01, Space(1), "")
                strSD01 = Replace(strSD01, vbCr, "")
                strSD01 = Replace(strSD01, vbLf, "")


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
            End Try


            '****************************************************************************
            'PLC��PC
            '****************************************************************************
            Dim objSR02 As New System.IO.StreamReader(txtTextFile02.Text, System.Text.Encoding.Default)   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
            Try


                '**************************************
                '�Ǎ�
                '**************************************
                strRD01 = objSR02.ReadToEnd()    '��s��÷��


                '**************************************
                '���ʂȕ��������ڰ�
                '**************************************
                strRD01 = Replace(strRD01, Space(1), "")
                strRD01 = Replace(strRD01, vbCr, "")
                strRD01 = Replace(strRD01, vbLf, "")


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '����̧�ُo��
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '****************************************************************************
            'PC ��PLC
            '****************************************************************************
            Dim strDirectoryName As String = System.IO.Path.GetDirectoryName(txtLineEyeTextFile.Text)                           '�߽
            Dim strFileNameWithoutExtensionSD01 As String = System.IO.Path.GetFileNameWithoutExtension(txtLineEyeTextFile.Text) '�g���q���܂܂Ȃ�̧�ٖ�
            Dim strFileNameWithoutExtensionRD01 As String = System.IO.Path.GetFileNameWithoutExtension(txtTextFile02.Text)      '�g���q���܂܂Ȃ�̧�ٖ�
            Dim strExtension As String = System.IO.Path.GetExtension(txtLineEyeTextFile.Text)                                   '�g���q
            Dim objSW01_SD01 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtensionSD01 _
                                                      & "_01" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JIS�ŏ�������
            Dim objSW01_RD01 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtensionRD01 _
                                                      & "_01" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JIS�ŏ�������
            Try
                objSW01_SD01.WriteLine(strSD01)          '�ǉ�
                objSW01_RD01.WriteLine(strSD01)          '�ǉ�
            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW01_SD01.Close()
                objSW01_RD01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '����̧�ُo��
            '�d�����Ɉ�s�ɂ���
            'PC ��PLC
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'Dim strArySD01() As String = Nothing
            Dim lngRecordCount As Long = 0              'ں��ސ�
            Dim objSW02_SD01 As New System.IO.StreamWriter(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionSD01 _
                                                           & "_02" _
                                                           & strExtension _
                                                           , False _
                                                           , System.Text.Encoding.GetEncoding(932) _
                                                           )           'Shift JIS�ŏ�������
            '������������********************************************************************************************************************************************************************************************************************************************
            '������������********************************************************************************************************************************************************************************************************************************************
            '���ϲ��

            Dim objSW91_SD01 As New System.IO.StreamWriter(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionSD01 _
                                                           & "_91" _
                                                           & strExtension _
                                                           , False _
                                                           , System.Text.Encoding.GetEncoding(932) _
                                                           )           'Shift JIS�ŏ�������

            '������������********************************************************************************************************************************************************************************************************************************************
            '������������********************************************************************************************************************************************************************************************************************************************
            Try
                Dim strSDTemp01 As String = ""              '��Ɨp������
                Dim strRDTemp01 As String = ""              '��Ɨp������
                For ii As Integer = 1 To strSD01.Length
                    '(ٰ��:��͂��镶����)
                    Try


                        '*********************************************************************
                        '�����ݒ�
                        '*********************************************************************
                        strSDTemp01 &= (MidD(strSD01, ii, 1))


                        '*********************************************************************
                        '�Ǎ������      �擾
                        '*********************************************************************
                        If strSDTemp01.Length = 24 Then
                            If MidD(strSDTemp01, 1, 4) = "01FF" And MidD(strSDTemp01, 23, 2) = "00" Then
                                '(�Ǎ�����ނ̏ꍇ)

                                '̧�ُo��
                                objSW02_SD01.WriteLine(strSDTemp01)  '̧�ُo��
                                ''�z��ɾ��
                                'If IsNull(strArySD01) Then ReDim strArySD01(0) Else ReDim Preserve strArySD01(UBound(strArySD01) + 1)
                                'strArySD01(UBound(strArySD01)) = strTelSend
                                '������
                                strSDTemp01 = ""                    '��Ɨp������
                                lngRecordCount += 1                 'ں���+1
                            End If
                        End If


                        '*********************************************************************
                        '���������      �擾
                        '*********************************************************************
                        If 28 <= strSDTemp01.Length Then
                            If MidD(strSDTemp01, 1, 4) = "03FF" And MidD(strSDTemp01, 23, 2) = "00" Then
                                '(��������ނ̏ꍇ)
                                Dim intAdrsCount As Integer = Change16To10(Mid(strSDTemp01, 21, 2))                   '���޲��_��
                                If 24 + (intAdrsCount * 4) <= strSDTemp01.Length Then
                                    '(��������ނ̏ꍇ)

                                    objSW02_SD01.WriteLine(strSDTemp01)       '̧�ُo��
                                    strSDTemp01 = ""                    '��Ɨp������
                                    lngRecordCount += 1                 'ں���+1

                                End If
                            End If
                        End If


                        '*********************************************************************
                        '�d����肱�ڂ�����
                        '*********************************************************************
                        If 200 <= strSDTemp01.Length Then

                            Call AddToLog("��Гd�����o:" & strSDTemp01)     '۸ޏo��
                            objSW91_SD01.WriteLine(strSDTemp01)          '̧�ُo��
                            strSDTemp01 = ""                        '��Ɨp������
                            strSDTemp01 &= (MidD(strSD01, ii, 1))   '��Ɨp������

                        End If


                        '***********************
                        '�i���\��
                        '***********************
                        If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                            lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                            Me.Refresh()
                            System.Windows.Forms.Application.DoEvents()
                        End If


                    Catch ex As Exception
                        ComError(ex)
                    End Try


                Next


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW02_SD01.Close()
                objSW91_SD01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '����̧�ُo��
            '�d�����Ɉ�s�ɂ���
            'PLC��PC
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSW02_RD01 As New System.IO.StreamWriter(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionRD01 _
                                                           & "_02" _
                                                           & strExtension _
                                                           , False _
                                                           , System.Text.Encoding.GetEncoding(932) _
                                                           )           'Shift JIS�ŏ�������
            Dim objSW91_RD01 As New System.IO.StreamWriter(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionRD01 _
                                                           & "_91" _
                                                           & strExtension _
                                                           , False _
                                                           , System.Text.Encoding.GetEncoding(932) _
                                                           )           'Shift JIS�ŏ�������
            Try
                'Dim strSDTemp01 As String = ""              '��Ɨp������
                Dim strRDTemp01 As String = ""              '��Ɨp������
                For ii As Integer = 1 To strSD01.Length
                    '(ٰ��:��͂��镶����)
                    Try


                        '*********************************************************************
                        '�����ݒ�
                        '*********************************************************************
                        strRDTemp01 &= (MidD(strRD01, ii, 1))


                        '*********************************************************************
                        '�Ǎ�����       �擾
                        '�ʓ|�Ȃ̂ŁA1ܰ�ނ����ǂ�ł��Ȃ����O��
                        '*********************************************************************
                        If 8 = strRDTemp01.Length Then
                            If MidD(strRDTemp01, 1, 2) = "81" Then
                                '(�Ǎ������̏ꍇ)

                                objSW02_RD01.WriteLine(strRDTemp01)       '̧�ُo��
                                strRDTemp01 = ""                    '��Ɨp������

                            End If
                        End If


                        '*********************************************************************
                        '��������       �擾
                        '*********************************************************************
                        If strRDTemp01.Length = 4 Then
                            If MidD(strRDTemp01, 1, 2) = "83" Then
                                '(���������̏ꍇ)

                                objSW02_RD01.WriteLine(strRDTemp01) '̧�ُo��
                                strRDTemp01 = ""                    '��Ɨp������

                            End If
                        End If


                        '*********************************************************************
                        '�d����肱�ڂ�����
                        '*********************************************************************
                        If 200 <= strRDTemp01.Length Then

                            Call AddToLog("��Гd�����o:" & strRDTemp01)     '۸ޏo��
                            objSW91_RD01.WriteLine(strRDTemp01)          '̧�ُo��
                            strRDTemp01 = ""                        '��Ɨp������
                            strRDTemp01 &= (MidD(strSD01, ii, 1))   '��Ɨp������

                        End If


                        '***********************
                        '�i���\��
                        '***********************
                        If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                            lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                            Me.Refresh()
                            System.Windows.Forms.Application.DoEvents()
                        End If


                    Catch ex As Exception
                        ComError(ex)
                    End Try


                Next


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW02_SD01.Close()
                objSW02_RD01.Close()
                objSW91_SD01.Close()
                objSW91_RD01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'DB�ɏo��
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSR01_SD02 As New System.IO.StreamReader(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionSD01 _
                                                           & "_02" _
                                                           & strExtension _
                                                           , System.Text.Encoding.Default _
                                                           )   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
            Dim objSR01_RD02 As New System.IO.StreamReader(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionRD01 _
                                                           & "_02" _
                                                           & strExtension _
                                                           , System.Text.Encoding.Default _
                                                           )   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
            Dim hh As Integer = 0
            Try
                '**************************************
                '��s���Ǎ���
                '**************************************
                While (objSR01_SD02.Peek >= 0)
                    '(ٰ��:�Ǎ��s�ƂȂ�܂�)


                    '**************************************
                    '�����ݒ�
                    '**************************************
                    hh += 1


                    '**************************************
                    'ں��ޓǂݎ��
                    '**************************************
                    Dim strSDTemp01 As String = objSR01_SD02.ReadLine()                '��s��÷��
                    Dim strRDTemp01 As String = objSR01_RD02.ReadLine()                '��s��÷��


                    '********************************************************************************************
                    'ð��قɒǉ�
                    '********************************************************************************************
                    Try
                        objXLOG_MELSEC.CLEAR_PROPERTY()
                        objXLOG_MELSEC.FLOG_CHECK_DT1 = CDate(txtInsertDate.Text)       '�m�F����_1
                        objXLOG_MELSEC.FLOG_CHECK_DT2 = CDate(txtInsertDate.Text)       '�m�F����_2
                        objXLOG_MELSEC.FDENBUN = strSDTemp01                            '�ʐM�d��
                        objXLOG_MELSEC.FDENBUN02 = strRDTemp01                          '�ʐM�d��02
                        objXLOG_MELSEC.ADD_XLOG_MELSEC_SEQ()                            '�ǉ�
                    Catch ex As Exception
                        ComError(ex)

                    End Try


                    '***********************
                    '�i���\��
                    '***********************
                    If hh Mod 1000 = 0 Or hh = lngRecordCount Then
                        lblProgress.Text = Format((hh * 100) / lngRecordCount, "0.00") & "%"
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()
                    End If


                End While


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01_SD02.Close()
                objSR01_RD02.Close()
                objDb.Commit()
            End Try


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  XMST_EQ_NAME�ǉ�             ���ݸد�"
    Private Sub cmdInsertXMST_EQ_NAME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertXMST_EQ_NAME.Click
        Try
            Dim strMsg As String = ""
            Dim intRet As RetCode


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '�����ݒ�
            '************************************************************************************************************************************
            '************************************************************************************************************************************

            '===============================================
            'DB�ڑ�
            '===============================================
            Dim objSystem As New clsConnectConfig(CONFIG_FILE)
            Dim objDb As New JobCommon.clsConn
            objDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            Dim blnRet As Boolean = False
            blnRet = objDb.Connect()
            If blnRet = False Then Throw New Exception("DB�ڑ��װ")

            '===============================================
            'ð��ٸ׽��` & ��ݻ޸��݊J�n
            '===============================================
            Dim objXLOG_MELSEC As New TBL_XLOG_MELSEC(Nothing, objDb, objDb)
            objDb.BeginTrans()


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '̧�ٓǍ�
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
            Try


                '**************************************
                'ں��ސ�        �擾
                '**************************************
                Dim lngRecordCount As Long = 0
                While (objSR01.Peek >= 0)
                    '(ٰ��:�Ǎ��s�ƂȂ�܂�)
                    Dim strTemp01 As String = objSR01.ReadLine()                '��s��÷��
                    lngRecordCount += 1
                End While
                Dim ii As Long = 0


                '**************************************
                '������x�ǂݒ���
                '**************************************
                objSR01.Close()
                objSR01.Dispose()
                objSR01 = Nothing
                objSR01 = New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
                While (objSR01.Peek >= 0)
                    '(ٰ��:�Ǎ��s�ƂȂ�܂�)


                    '**************************************
                    '�����ݒ�
                    '**************************************
                    ii += 1


                    '**************************************
                    '��s�ځA��s�ړǍ�
                    '**************************************
                    Dim strTemp01 As String = objSR01.ReadLine()                '��s��÷��
                    Dim strAryTemp01() As String = Split(strTemp01, Space(1))   '��s��÷��


                    '**************************************
                    '�ݔ���Ͻ�        �ǉ�
                    '**************************************
                    If IsNotNull(strAryTemp01) Then
                        If 3 <= strAryTemp01.Length Then
                            '(�l�������Ă����ꍇ)
                            Dim objXMST_XCOMMENT01_01 As New TBL_XMST_XCOMMENT01_01(Nothing, objDb, objDb)
                            objXMST_XCOMMENT01_01.FEQ_ID = strAryTemp01(0)          '�ݔ�ID
                            objXMST_XCOMMENT01_01.XCOMMENT01 = strAryTemp01(1)      '����01
                            If 3 <= strAryTemp01.Length Then
                                For jj As Integer = 2 To strAryTemp01.Length - 1
                                    objXMST_XCOMMENT01_01.XCOMMENT01_01 &= strAryTemp01(jj)
                                Next
                            End If
                            intRet = objXMST_XCOMMENT01_01.GET_XMST_XCOMMENT01_01(False)
                            If intRet <> RetCode.OK Then
                                objXMST_XCOMMENT01_01.ADD_XMST_XCOMMENT01_01()
                            End If
                        End If

                    End If


                    '***********************
                    '�i���\��
                    '***********************
                    If ii Mod 1000 = 0 Or ii = lngRecordCount Then
                        lblProgress.Text = Format((ii * 100) / lngRecordCount, "0.00") & "%"
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()
                    End If


                End While


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
                objDb.Commit()
            End Try


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region




#Region "  ��ʴװ����                          "
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����zex         �F�װException
    '�y�ߒl�z
    '*******************************************************************************************************************
    Public Sub ComError(ByVal ex As Exception)
        If IsNotNull(mobjRS232C) Then mobjRS232C.ComError(ex)
        MsgBox(ex.Message)
    End Sub
#End Region
#Region "  ۸ޏ�������                          "
    '****************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z
    '****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String, _
                        Optional ByVal strMsg_2 As String = "�yհ�ް۸�      �z", _
                        Optional ByVal strMsg_3 As String = "")
        mobjRS232C.AddToLog(strMsg_1, strMsg_2, strMsg_3)
    End Sub
#End Region
#Region "  MidD�֐�                             "
    '''***********************************************************************************************************************************
    ''' <summary>
    ''' �����ޯ���ɂ���āA��Mid���޲�Mid������
    ''' </summary>
    ''' <param name="strMsg">������</param>
    ''' <param name="intPos">�J�n�ʒu</param>
    ''' <param name="intLen">�޲Đ�</param>
    ''' <returns>Mid�֐��ߒl</returns>
    ''' <remarks></remarks>
    '''***********************************************************************************************************************************
    Private Function MidD(ByVal strMsg As String _
                        , ByVal intPos As Integer _
                        , Optional ByVal intLen As Integer = Integer.MaxValue _
                        ) _
                        As String
        Dim strReturn As String


        '************************************************
        '�����ޯ���Ŕ��f
        '************************************************
        If chkSJIS.Checked = True Then
            '(�S�p�Ή��̏ꍇ)
            strReturn = MID_SJIS(strMsg, intPos, intLen)
        Else
            '(�S�p���Ή��̏ꍇ)
            If intLen = Integer.MaxValue Then
                strReturn = Mid(strMsg, intPos)
            Else
                strReturn = Mid(strMsg, intPos, intLen)
            End If
        End If


        Return strReturn
    End Function
#End Region


    'StringBuilder�ō쐬(���ʂ��Ȃ��������A�ꉞ�ޯ�����)
#Region "  ���n���̧�ُo��             ���ݸد�"
    'Private Sub cmdAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnalysis.Click
    '    Try


    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        '�����ݒ�
    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        Dim strSD01 As String = ""        '���M�d��01÷��
    '        Dim strSD02 As String = ""        '���M�d��02÷��
    '        Dim strRD01 As String = ""        '��M�d��01÷��
    '        Dim strRD02 As String = ""        '��M�d��02÷��


    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        '̧�ٓǍ�
    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
    '        Try
    '            While (objSR01.Peek >= 0)
    '                '(ٰ��:�Ǎ��s�ƂȂ�܂�)


    '                '**************************************
    '                '��s�ځA��s�ړǍ�
    '                '**************************************
    '                Dim blnSD As Boolean = False    '���M÷���׸�
    '                Dim blnRD As Boolean = False    '��M÷���׸�
    '                Dim strTemp01 As String = objSR01.ReadLine()    '��s��÷��
    '                If Microsoft.VisualBasic.Left(strTemp01, 3) = "SD:" Then
    '                    '(���M�d���̏ꍇ)
    '                    blnSD = True
    '                ElseIf Microsoft.VisualBasic.Left(strTemp01, 3) = "RD:" Then
    '                    '(��M�d���̏ꍇ)
    '                    blnRD = True
    '                Else
    '                    Continue While
    '                End If
    '                Dim strTemp02 As String = objSR01.ReadLine()    '��s��÷��


    '                '**************************************
    '                '÷�ĕҏW
    '                '**************************************
    '                strTemp01 = MidD(strTemp01, 4)      '���M�d��÷��
    '                strTemp02 = MidD(strTemp02, 4)      '���M�d��÷��
    '                strTemp01 = SPC_PAD_LEFT_SJIS(strTemp01, 56)      '���M�d��÷��
    '                strTemp02 = SPC_PAD_LEFT_SJIS(strTemp02, 56)      '��M�d��÷��



    '                '**************************************
    '                '÷�č���
    '                '**************************************
    '                If blnSD = True Then
    '                    '(���M�d���̏ꍇ)
    '                    strSD01 &= strTemp01
    '                    strSD02 &= strTemp02
    '                ElseIf blnRD = True Then
    '                    '(��M�d���̏ꍇ)
    '                    strRD01 &= strTemp01
    '                    strRD02 &= strTemp02
    '                End If


    '            End While


    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            objSR01.Close()
    '        End Try


    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        '����̧�ُo��
    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        '***********************
    '        'StreamWriter   �쐬
    '        '***********************
    '        Dim strDirectoryName As String = System.IO.Path.GetDirectoryName(txtLineEyeTextFile.Text)                           '�߽
    '        Dim strFileNameWithoutExtension As String = System.IO.Path.GetFileNameWithoutExtension(txtLineEyeTextFile.Text)     '�g���q���܂܂Ȃ�̧�ٖ�
    '        Dim strExtension As String = System.IO.Path.GetExtension(txtLineEyeTextFile.Text)                                   '�g���q
    '        'System.IO.Directory.CreateDirectory(strFilePath)        '̫��ނ̍쐬
    '        Dim objSW01 As New System.IO.StreamWriter(strDirectoryName _
    '                                                  & "\" _
    '                                                  & strFileNameWithoutExtension _
    '                                                  & "_01" _
    '                                                  & strExtension _
    '                                                  , False _
    '                                                  , System.Text.Encoding.GetEncoding(932) _
    '                                                  )           'Shift JIS�ŏ�������
    '        Try
    '            objSW01.WriteLine(strSD01)          '�ǉ�
    '            objSW01.WriteLine(strSD02)          '�ǉ�
    '            'objSW01.Write(strRD01)          '�ǉ�
    '            'objSW01.Write(strRD02)          '�ǉ�
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            objSW01.Close()
    '        End Try


    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        '�d�����Ɉ�s�ɂ���
    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        Dim objSW02 As New System.IO.StreamWriter(strDirectoryName _
    '                                                  & "\" _
    '                                                  & strFileNameWithoutExtension _
    '                                                  & "_02" _
    '                                                  & strExtension _
    '                                                  , False _
    '                                                  , System.Text.Encoding.GetEncoding(932) _
    '                                                  )           'Shift JIS�ŏ�������
    '        Try
    '            Dim strSDTemp01 As New StringBuilder
    '            Dim strSDTemp02 As New StringBuilder
    '            Dim strRDTemp01 As New StringBuilder
    '            Dim strRDTemp02 As New StringBuilder
    '            For ii As Integer = 1 To strSD01.Length
    '                '(ٰ��:������̒���)


    '                '***********************
    '                '̧�ُo��
    '                '***********************
    '                If ii <= strSD01.Length - 8 And IsNotNull(strSDTemp01.ToString) Then
    '                    '(�����ް��������Ă���\��������ꍇ)


    '                    If MidD(strSD01, ii, 8) = "[ TMSP ]" _
    '                       And MidD(strSD01, ii, 10) <> "[ TMSP ] -" Then
    '                        '(�����ް��������Ă���ꍇ)
    '                        objSW02.WriteLine(strSDTemp01.ToString)      '�ǉ�
    '                        objSW02.WriteLine(strSDTemp02.ToString)      '�ǉ�
    '                        objSW02.WriteLine(strRDTemp01.ToString)      '�ǉ�
    '                        objSW02.WriteLine(strRDTemp02.ToString)      '�ǉ�
    '                        objSW02.WriteLine("")               '�ǉ�(���s)
    '                        strSDTemp01.Remove(0, strSDTemp01.Length)       '������
    '                        strSDTemp02.Remove(0, strSDTemp02.Length)       '������
    '                        strRDTemp01.Remove(0, strRDTemp01.Length)       '������
    '                        strRDTemp02.Remove(0, strRDTemp02.Length)       '������
    '                    End If


    '                    ''If MID_SJIS(strSD01, ii, 8) = "[ TMSP ]" Then
    '                    ''    '(�����ް��������Ă���ꍇ)
    '                    ''    objSW02.WriteLine(strSDTemp01)      '�ǉ�
    '                    ''    objSW02.WriteLine(strSDTemp02)      '�ǉ�
    '                    ''    objSW02.WriteLine(strRDTemp01)      '�ǉ�
    '                    ''    objSW02.WriteLine(strRDTemp02)      '�ǉ�
    '                    ''    objSW02.WriteLine("")               '�ǉ�(���s)
    '                    ''    strSDTemp01 = ""        '������
    '                    ''    strSDTemp02 = ""        '������
    '                    ''    strRDTemp01 = ""        '������
    '                    ''    strRDTemp02 = ""        '������
    '                    ''End If


    '                End If


    '                '***********************
    '                '�ꕶ���������o��
    '                '***********************
    '                strSDTemp01.Append(MidD(strSD01, ii, 1))
    '                strSDTemp02.Append(MidD(strSD02, ii, 1))
    '                strRDTemp01.Append(MidD(strRD01, ii, 1))
    '                strRDTemp02.Append(MidD(strRD02, ii, 1))


    '                '***********************
    '                '̧�ُo��
    '                '***********************
    '                If ii = strSD01.Length Then
    '                    '(�ް����I������ꍇ)
    '                    objSW02.WriteLine(strSDTemp01.ToString)          '�ǉ�
    '                    objSW02.WriteLine(strSDTemp02.ToString)          '�ǉ�
    '                    objSW02.WriteLine(strRDTemp01.ToString)          '�ǉ�
    '                    objSW02.WriteLine(strRDTemp02.ToString)          '�ǉ�
    '                End If


    '                '***********************
    '                '�i���\��
    '                '***********************
    '                If ii Mod 1001 = 0 Or ii = strSD01.Length Then
    '                    lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
    '                    Me.Refresh()
    '                    System.Windows.Forms.Application.DoEvents()
    '                End If


    '            Next


    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            objSW02.Close()
    '        End Try


    '        ''**************************************
    '        ''̧�ٓǍ�
    '        ''**************************************
    '        'Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader �̐V�����ݽ�ݽ�𐶐�����
    '        'objSR01.ReadLine()    '��s�擾
    '        'objSR01.ReadLine()    '��s�擾
    '        'Dim strDBBackupPath As String = Trim(MidD(objSR01.ReadLine(), 4))
    '        'If System.IO.Directory.Exists(strDBBackupPath) = False Then
    '        '    '(̫��ނ����݂��Ȃ��ꍇ)
    '        '    Call AddToMsgLog(Now, FMSG_ID_S9002, "�O�t��HDD���ޯ����ߐ悪�F���o���܂���B", "�u" & strDBBackupPath & "�v��������܂���")
    '        '    Return RetCode.OK
    '        'End If





    '    Catch ex As Exception
    '        ComError(ex)

    '    End Try
    'End Sub
#End Region


    '������������������������************************************************************************************************************************************
    '����@�\

#Region "  ���ʕϐ�                                 "
    Private TMSP As String = "[ TMSP ]"
#End Region
#Region "  ����d��01                   ÷����ݼ�   "
    Private Sub txtTelegramAnalysis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelegramAnalysis01.TextChanged
        Try


            '**************************************************************************************************
            '**************************************************************************************************
            '�Ǐo�v��           �\��
            '**************************************************************************************************
            '**************************************************************************************************
            If MID_SJIS(txtTelegramAnalysis01.Text, 3, 2) = "03" Then
                txtReadSend01_01.Text = MID_SJIS(txtTelegramAnalysis01.Text, 1, 2)
                txtReadSend01_02.Text = MID_SJIS(txtTelegramAnalysis01.Text, 3, 2)
                txtReadSend01_03.Text = 40001 + Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 5, 4))
                txtReadSend01_04.Text = Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 9, 4))
                txtReadSend01_99.Text = Microsoft.VisualBasic.Right(txtTelegramAnalysis01.Text, 4)
            Else
                txtReadSend01_01.Text = ""
                txtReadSend01_02.Text = ""
                txtReadSend01_03.Text = ""
                txtReadSend01_04.Text = ""
                txtReadSend01_99.Text = ""
            End If


            '**************************************************************************************************
            '**************************************************************************************************
            '�����v��           �\��
            '**************************************************************************************************
            '**************************************************************************************************
            If MID_SJIS(txtTelegramAnalysis01.Text, 3, 2) = "10" Then

                '********************************************************
                '��{
                '********************************************************
                txtWriteSend01_01.Text = MID_SJIS(txtTelegramAnalysis01.Text, 1, 2)
                txtWriteSend01_02.Text = MID_SJIS(txtTelegramAnalysis01.Text, 3, 2)
                txtWriteSend01_03.Text = 40001 + Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 5, 4))
                txtWriteSend01_04.Text = Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 9, 4))
                txtWriteSend01_05.Text = Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 13, 2))
                txtWriteSend01_06.Text = MID_SJIS(txtTelegramAnalysis01.Text, 15, TO_INTEGER(txtWriteSend01_05.Text) * 2) & vbCrLf & vbCrLf
                If TO_INTEGER(txtWriteSend01_04.Text) <= 6 Then
                    txtWriteSend01_81.Text = MID_SJIS(txtTelegramAnalysis01.Text, 15, TO_INTEGER(txtWriteSend01_04.Text) * 4)
                Else
                    txtWriteSend01_81.Text = MID_SJIS(txtTelegramAnalysis01.Text, 15, 24)
                End If
                txtWriteSend01_99.Text = Microsoft.VisualBasic.Right(txtTelegramAnalysis01.Text, 4)


                '********************************************************
                '�����ް�
                '********************************************************
                txtWriteSend01_06.Text &= Space(6) & "(     2�i��      )(16�i)( 10�i)" & vbCrLf
                For ii As Integer = 0 To TO_INTEGER(txtWriteSend01_04.Text) - 1
                    '(ٰ��:�����ް���)

                    '================================================
                    '�����ް�
                    '================================================
                    Dim strData16 As String = MID_SJIS(txtTelegramAnalysis01.Text, 15 + (ii * 4), 4)
                    Dim strData10 As Integer = Change16To10(strData16)
                    Dim strData02 As String = Change10To2(strData10, 16)
                    txtWriteSend01_06.Text &= (TO_INTEGER(txtWriteSend01_03.Text) + ii) & ":"
                    txtWriteSend01_06.Text &= "(" & strData02 & ")"
                    txtWriteSend01_06.Text &= "(" & strData16 & ")"
                    txtWriteSend01_06.Text &= "(" & SPC_PAD_RIGHT_SJIS(strData10, 5) & ")"
                    txtWriteSend01_06.Text &= vbCrLf


                Next


            Else
                txtWriteSend01_01.Text = ""
                txtWriteSend01_02.Text = ""
                txtWriteSend01_03.Text = ""
                txtWriteSend01_04.Text = ""
                txtWriteSend01_05.Text = ""
                txtWriteSend01_06.Text = ""
                txtWriteSend01_99.Text = ""
            End If




        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ����d��02                   ÷����ݼ�   "
    Private Sub txtTelegramAnalysis02_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelegramAnalysis02.TextChanged
        Try


            '*************************************************
            '�Ǎ�����           �\��
            '*************************************************
            If MID_SJIS(txtTelegramAnalysis02.Text, 3, 2) = "03" Then

                '===================================
                '����
                '===================================
                If IsNull(txtTelegramAnalysis01.Text) Or IsNull(txtReadSend01_03.Text) Then
                    '(�Ǎ��v���d������������Ă��Ȃ��ꍇ)
                    txtReadRecv01_01.Text = ""
                    txtReadRecv01_02.Text = ""
                    txtReadRecv01_03.Text = ""
                    txtReadRecv01_04.Text = ""
                    txtReadRecv01_99.Text = ""
                    Throw New Exception("�Ή�����Ǎ��v���d���𕪉������ĉ������B" & vbCrLf & "�Ǎ��A�h���X���擾�o���܂���B")
                End If

                '===================================
                '��{
                '===================================
                txtReadRecv01_01.Text = MID_SJIS(txtTelegramAnalysis02.Text, 1, 2)
                txtReadRecv01_02.Text = MID_SJIS(txtTelegramAnalysis02.Text, 3, 2)
                txtReadRecv01_03.Text = Change16To10(MID_SJIS(txtTelegramAnalysis02.Text, 5, 2))
                txtReadRecv01_04.Text = MID_SJIS(txtTelegramAnalysis02.Text, 7, TO_INTEGER(txtReadRecv01_03.Text) * 2) & vbCrLf & vbCrLf
                txtReadRecv01_99.Text = Microsoft.VisualBasic.Right(txtTelegramAnalysis02.Text, 4)

                '===================================
                '�����ް�
                '===================================
                txtReadRecv01_04.Text &= Space(6) & "(     2�i��      )(16�i)( 10�i)" & vbCrLf
                For ii As Integer = 0 To (TO_INTEGER(txtReadRecv01_03.Text) / 2) - 1
                    '(ٰ��:�����ް���)

                    Dim strData16 As String = MID_SJIS(txtTelegramAnalysis02.Text, 7 + (ii * 4), 4)
                    Dim strData10 As Integer = Change16To10(strData16)
                    Dim strData02 As String = Change10To2(strData10, 16)
                    txtReadRecv01_04.Text &= (TO_INTEGER(txtReadSend01_03.Text) + ii) & ":"
                    txtReadRecv01_04.Text &= "(" & strData02 & ")"
                    txtReadRecv01_04.Text &= "(" & strData16 & ")"
                    txtReadRecv01_04.Text &= "(" & SPC_PAD_RIGHT_SJIS(strData10, 5) & ")"
                    txtReadRecv01_04.Text &= vbCrLf

                Next

            Else
                txtReadRecv01_01.Text = ""
                txtReadRecv01_02.Text = ""
                txtReadRecv01_03.Text = ""
                txtReadRecv01_04.Text = ""
                txtReadRecv01_99.Text = ""
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ���o��                       ÷����ݼ�   "
    Private Sub txtWriteSend01_81_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWriteSend01_81.TextChanged
        Try
            txtWriteSend01_82.Text = ""


            For ii As Integer = 1 To txtWriteSend01_81.Text.Length Step +4
                '(ٰ��:��Ă��ꂽ������)


                '**************************************************
                '�ް��擾
                '**************************************************
                Dim strData16 As String = MID_SJIS(txtWriteSend01_81.Text, ii, 4)   '16�i��
                Dim strData10 As String = Change16To10(strData16)                   '10�i��
                Dim strData02 As String = Change10To2(strData10, 16)                '02�i��


                '**************************************************
                '���o��
                '**************************************************
                '1��
                Dim strDataInout01 As String = MID_SJIS(strData02, 2, 1)        '����Ӱ��
                Dim strDataInout02 As String = MID_SJIS(strData02, 3, 1)        '�o��Ӱ��
                Dim strDataInout03 As String = MID_SJIS(strData02, 4, 1)        '�߱����
                Dim strDataInout04 As String = MID_SJIS(strData02, 5, 1)        '̫��2
                Dim strDataInout05 As String = MID_SJIS(strData02, 6, 1)        '̫��1
                Dim strDataInout06 As String = MID_SJIS(strData02, 7, 2)        'L/S�ԍ�
                Dim strDataInout07 As String = MID_SJIS(strData02, 10, 1)       '�����ذ�
                Dim strDataInout08 As String = Change2To10(MID_SJIS(strData02, 11, 2))      '��
                Dim strDataInout09 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '���@
                '2��
                Dim strDataInout10 As String = Change2To10(MID_SJIS(strData02, 3, 6))       '�A
                Dim strDataInout11 As String = MID_SJIS(strData02, 9, 1)                    'END�׸�
                Dim strDataInout12 As String = MID_SJIS(strData02, 10, 1)                   '���I�Đݒ�
                Dim strDataInout13 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '�i


                '**************************************************
                '÷���ޯ���ɏo��
                '**************************************************
                Select Case ii
                    Case 1, 13
                        txtWriteSend01_82.Text &= "����Ӱ��  :" & strDataInout01 & vbCrLf
                        txtWriteSend01_82.Text &= "�o��Ӱ��  :" & strDataInout02 & vbCrLf
                        txtWriteSend01_82.Text &= "�߱����   :" & strDataInout03 & vbCrLf
                        txtWriteSend01_82.Text &= "̫��2     :" & strDataInout04 & vbCrLf
                        txtWriteSend01_82.Text &= "̫��1     :" & strDataInout05 & vbCrLf
                        txtWriteSend01_82.Text &= "L/S�ԍ�   :" & strDataInout06 & vbCrLf
                        txtWriteSend01_82.Text &= "�����ذ�  :" & strDataInout07 & vbCrLf
                        txtWriteSend01_82.Text &= "��        :" & strDataInout08 & vbCrLf
                        txtWriteSend01_82.Text &= "���@      :" & strDataInout09 & vbCrLf
                    Case 5, 17
                        txtWriteSend01_82.Text &= "�A        :" & strDataInout10 & vbCrLf
                        txtWriteSend01_82.Text &= "END�׸�   :" & strDataInout11 & vbCrLf
                        txtWriteSend01_82.Text &= "���I�Đݒ�:" & strDataInout12 & vbCrLf
                        txtWriteSend01_82.Text &= "�i        :" & strDataInout13 & vbCrLf
                    Case 9, 21
                        txtWriteSend01_82.Text &= "���ڽ     :" & strData10 & vbCrLf & vbCrLf
                End Select


                If 21 <= ii Then Exit For
            Next


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

#Region "  �v�� or ����                 �I��ύX    "

    Private Sub rdoSend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoWriteSend.CheckedChanged
        Try
            Call rdoSend_CheckedChangedProcess()
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

    Private Sub rdoRecv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoWriteRecv.CheckedChanged
        Try
            Call rdoSend_CheckedChangedProcess()
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

    Private Sub rdoSend_CheckedChangedProcess()

        If rdoWriteSend.Checked = True And rdoWriteRecv.Checked = False Then
            '(�v���̏ꍇ)
            txtWriteSend01_05.Enabled = True
            txtWriteSend01_06.Enabled = True
        ElseIf rdoWriteSend.Checked = False And rdoWriteRecv.Checked = True Then
            '(�����̏ꍇ)
            txtWriteSend01_05.Enabled = False
            txtWriteSend01_06.Enabled = False
        End If

    End Sub

#End Region

    '������������������������************************************************************************************************************************************


End Class