'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y�@�\�z���ݽNo�擾�A�X�V�@�\
' �y�쐬�zSIT
'**********************************************************************************************


Public Class clsSeqNo
    Implements IDisposable

#Region "  �ݽ�׸�      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݽ�׸�
    ''' </summary>
    ''' <param name="objDb">�����̐ڑ���޼ު��</param>
    ''' <param name="blnConnUse">�����̐ڑ���޼ު�Ă��g�p���邩�ۂ����׸� True:�g�p����  False:�g�p���Ȃ�(��̫��:True)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objDb As clsConn, _
                   Optional ByVal blnConnUse As Boolean = True _
                   )
        Try
            Dim blnRet As Boolean       '�ߒl


            '*****************************************
            '�����ϐ��ɋL��
            '*****************************************
            mblnConnUse = blnConnUse


            '*****************************************
            'DB�ڑ��ݒ�
            '*****************************************
            If blnConnUse = True Then
                '(�����̐ڑ����g�p����ꍇ)

                mobjDb = objDb

            Else
                '(�V�����ڑ����g�p����ꍇ)

                mobjDb = New clsConn
                mobjDb.ConnectString = objDb.ConnectString      '�ڑ��������
                blnRet = mobjDb.Connect()                       '�ڑ�
                If blnRet = False Then
                    Throw New UserException("DB�ڑ��Ɏ��s���܂����B")
                End If

            End If


            '*****************************************
            '�ϐ�������
            '*****************************************
            mFSEQ_NO = Integer.MaxValue               '���ݽ���ް
            mFSEQ_NO_MAX = Integer.MaxValue           '���ݽ���ް�ő�l
            mFSEQ_NO_MIN = Integer.MaxValue           '���ݽ���ް�ŏ��l


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �޽�׸�      "

    Private disposedValue As Boolean = False        ' �d������Ăяo�������o����ɂ�

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                '�����I�ɌĂяo���ꂽ�Ƃ��ɃA���}�l�[�W ���\�[�X��������܂�
            End If

            '���L�̃A���}�l�[�W ���\�[�X��������܂�

            '*********************************************
            '�۰�ޏ���
            '*********************************************
            Try
                Call Close()
            Catch ex As Exception
                '�������Ȃ�
            End Try


        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' ���̃R�[�h�́A�j���\�ȃp�^�[���𐳂��������ł���悤�� Visual Basic �ɂ���Ēǉ�����܂����B
    Public Sub Dispose() Implements IDisposable.Dispose
        ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(ByVal disposing As Boolean) �ɋL�q���܂��B
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#End Region
#Region "  �׽�ϐ���`"
    Protected mobjDb As clsConn                     'DB�ڑ�
    Protected mstrDBName As String                  'DB��
    Protected mstrTableName As String               'ð��ٖ�
    Protected mblnConnUse As Boolean                '�����ڑ���޼ު�Ďg�p�׸�

    Protected mFSEQ_ID As String                    '
    Protected mFSEQ_NAME As String                  '���ݽ���ް����
    Protected mFSEQ_NO As Integer                   '���ݽ���ް
    Protected mFSEQ_NO_MAX As Integer               '���ݽ���ް�ő�l
    Protected mFSEQ_NO_MIN As Integer               '���ݽ���ް�ŏ��l
    Protected mFUPDATE_DT As Date                   '�X�V����
    Protected mFRESET_DT As Date                    'ؾ�ē���
#End Region
#Region "  �����è��`"
    ''' =======================================
    ''' <summary>���ݽ���ްID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFSEQ_ID() As String
        Get
            Return mFSEQ_ID
        End Get
        Set(ByVal Value As String)
            mFSEQ_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>DB��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userstrDBName() As String
        Get
            Return mstrDBName
        End Get
        Set(ByVal Value As String)
            mstrDBName = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ð��ٖ�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userstrTableName() As String
        Get
            Return mstrTableName
        End Get
        Set(ByVal Value As String)
            mstrTableName = Value
        End Set
    End Property
#End Region
#Region "  ���ݽ���擾 & �X�V               (Public  userGetUpdateSeqNo)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ݽ���擾���X�V
    ''' </summary>
    ''' <returns>���ݽ��</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Function userGetUpdateSeqNo() As Integer
        Try
            mobjDb.BeginTrans()

            Try
                Dim intReturn As Integer    '�ߒl
                Dim strMsg As String        'ү����


                '******************************************************
                '�����è����
                '******************************************************
                If mFSEQ_ID = "" Then
                    strMsg = "���ݽ���ްID���ݒ肳��Ă��܂���B"
                    Throw New UserException(strMsg)
                End If
                'If mstrDBName = "" Then
                '    strMsg = "DB�����ݒ肳��Ă��܂���B"
                '    Throw New UserException(strMsg)
                'End If
                If mstrTableName = "" Then
                    strMsg = "ð��ٖ����ݒ肳��Ă��܂���B"
                    Throw New UserException(strMsg)
                End If


                '******************************************************
                '���ݽ���擾
                '******************************************************
                Call GetSeqNo()
                intReturn = mFSEQ_NO


                '******************************************************
                '���ݽ���X�V
                '******************************************************
                Call UpdateSeqNo()


                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/12/25  SEQ�����Ԏ���ؾ�Ă���Ȃ��޸ޏC��
                '                                    ���t���؂�ւ�����u�ԂɁA���exe��������SEQ���𔭔Ԃ����ꍇ�A���ݸނɂ���Ă͕Е���SEQ��ؾ�Ă���Ȃ��ꍇ������B


                '******************************************************
                '���ݽ���ްؾ��
                '******************************************************
                Dim strResetDate As String = Format(mFRESET_DT, "yyyy/MM/dd")       'ؾ�ē��t
                Dim strUpdateDate As String = Format(mFUPDATE_DT, "yyyy/MM/dd")     '�X�V����
                Dim dtmResetDate As Date = CDate(strResetDate)                      'ؾ�ē��t
                Dim dtmUpdateDate As Date = CDate(strUpdateDate)                    '�X�V����
                If DateAdd(DateInterval.Day, 1, dtmResetDate) <= dtmUpdateDate Then
                    '(�ŏIؾ�ē����������ȏ�o�߂��Ă����ꍇ)

                    Call userResetSeqNo()               '���ݽ��ؾ��
                    Call GetSeqNo()                     '���ݽ���擾
                    intReturn = mFSEQ_NO                '���ݽ���擾(�X�V�O�Ɏ擾���Ȃ���΂Ȃ�Ȃ�)
                    Call UpdateSeqNo()                  '���ݽ���X�V

                End If


                '������������************************************************************************************************************


                Return (intReturn)
            Catch ex As UserException
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                mobjDb.Commit()
            End Try
        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region
#Region "  ���ݽ��ؾ��                      (Public  userResetSeqNo)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ݽ��ؾ��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub userResetSeqNo()
        Try
            Dim strSQL As String                    'SQL��
            Dim strMsg As String                    'ү����
            Dim intRetSQL As Integer                'SQL���s�߂�l
            Dim dtmNow As Date = Now                '���ݓ���

            '******************************************************
            '�����è����
            '******************************************************
            If mFSEQ_ID = "" Then
                strMsg = "���ݽ���ްID���ݒ肳��Ă��܂���B"
                Throw New UserException(strMsg)
            End If
            'If mstrDBName = "" Then
            '    strMsg = "DB�����ݒ肳��Ă��܂���B"
            '    Throw New UserException(strMsg)
            'End If
            If mstrTableName = "" Then
                strMsg = "ð��ٖ����ݒ肳��Ă��܂���B"
                Throw New UserException(strMsg)
            End If


            '***********************
            '�X�VSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    " & mstrTableName
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FSEQ_NO = FSEQ_NO_MIN"
            strSQL &= vbCrLf & "   ,FUPDATE_DT = TO_DATE('" & dtmNow & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & "   ,FRESET_DT = TO_DATE('" & dtmNow & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FSEQ_ID = '" & mFSEQ_ID & "'"
            strSQL &= vbCrLf


            '***********************
            '�X�V
            '***********************
            intRetSQL = mobjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQL�װ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = "�X�V���s�F" & mobjDb.ErrMsg & "�y" & strSQL & "�z"
                Throw New UserException(strMsg)
            End If
            If intRetSQL < 1 Then
                '(�Ώۍs����)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = "�X�V���s�F" & "(�Ώۍs����)[ð���:TDSP_OPEN]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �۰�ޏ���                        (Private userClose)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Close()
        Try

            If mblnConnUse = False Then
                '(�V�����ڑ����g�p�����ꍇ)

                If IsNothing(mobjDb) = False Then
                    mobjDb.Disconnect()
                    mobjDb = Nothing
                End If

            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "  �����֐�     "

#Region "  ���ݽ���擾                      (Protected  GetSeqNo)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ݽ���擾
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Sub GetSeqNo()
        Try
            Dim strSQL As String            'SQL��
            Dim strMsg As String            'ү����
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            Dim objRow As DataRow           '1ں��ޕ����ް�
            Dim intReturn As Integer = -1   '�ߒl


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    " & mstrTableName
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FSEQ_ID = '" & mFSEQ_ID & "' "
            strSQL &= vbCrLf & " FOR UPDATE"
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            mobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SEQNO"
            mobjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                If Not IsDBNull(objRow("FSEQ_NO")) Then

                    Call SET_TPRG_SEQNO(objRow)

                Else
                    strMsg = "�ݒ肳�ꂽ���ݽID��ں��ނ�Null���ݒ肳��Ă��܂��B"
                    Throw New UserException(strMsg)
                End If

            Else
                strMsg = "�ݒ肳�ꂽ���ݽID��ں��ނ����݂��܂���B"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "  ���ݽ���X�V                      (Protected  UpdateSeqNo)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ݽ���X�V
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Sub UpdateSeqNo()
        Try
            Dim strSQL As String                    'SQL��
            Dim strMsg As String                    'ү����
            Dim intRetSQL As Integer                'SQL���s�߂�l
            Dim dtmNow As Date = Now                '���ݓ���
            Dim intUpdateSeqNo As Integer           '���ݽ�� + 1


            '***********************
            '���ݽ�� + 1
            '***********************
            intUpdateSeqNo = SeqNoPlus1()


            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/12/25  SEQ�����Ԏ���ؾ�Ă���Ȃ��޸ޏC��
            '                                    ���t���؂�ւ�����u�ԂɁA���exe��������SEQ���𔭔Ԃ����ꍇ�A���ݸނɂ���Ă͕Е���SEQ��ؾ�Ă���Ȃ��ꍇ������


            '******************************************************
            '�����è���
            '******************************************************
            mFSEQ_NO = intUpdateSeqNo   '���ݽ���ް
            mFUPDATE_DT = dtmNow        '�X�V����


            '������������************************************************************************************************************


            '***********************
            '�X�VSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    " & mstrTableName
            strSQL &= vbCrLf & " SET"
            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/12/25  SEQ�����Ԏ���ؾ�Ă���Ȃ��޸ޏC��
            '                                    ���t���؂�ւ�����u�ԂɁA���exe��������SEQ���𔭔Ԃ����ꍇ�A���ݸނɂ���Ă͕Е���SEQ��ؾ�Ă���Ȃ��ꍇ������

            strSQL &= vbCrLf & "    FSEQ_NO = " & CStr(mFSEQ_NO) & ""
            strSQL &= vbCrLf & "   ,FUPDATE_DT = TO_DATE('" & mFUPDATE_DT & "','YYYY/MM/DD HH24:MI:SS')"

            'strSQL &= vbCrLf & "    FSEQ_NO = " & CStr(intUpdateSeqNo) & ""
            'strSQL &= vbCrLf & "   ,FUPDATE_DT = TO_DATE('" & dtmNow & "','YYYY/MM/DD HH24:MI:SS')"

            '������������************************************************************************************************************
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FSEQ_ID = '" & mFSEQ_ID & "'"
            strSQL &= vbCrLf


            '***********************
            '�X�V
            '***********************
            intRetSQL = mobjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQL�װ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = "�X�V���s" & mobjDb.ErrMsg & "�y" & strSQL & "�z"
                Throw New UserException(strMsg)
            End If
            If intRetSQL < 1 Then
                '(�Ώۍs����)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = "�X�V���s" & "(�Ώۍs����)[ð���:TDSP_OPEN]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "  ���ݽ�� + 1                      (Protected  SeqNoPlus1)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ݽ�� + 1
    ''' </summary>
    ''' <returns>���ݽ��</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function SeqNoPlus1() As Integer
        Try
            Dim intReturn As Integer                                        '�ߒl


            '******************************************************
            '���ݽ�� + 1
            '******************************************************
            If mFSEQ_NO_MAX <= mFSEQ_NO Then
                '(���ݽ�����ő�l�ȏ�̎�)
                intReturn = mFSEQ_NO_MIN
            Else
                '(����ȊO�̎�)
                intReturn = mFSEQ_NO + 1
            End If


            Return (intReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "  ���ݽ���ް���ԕϐ��ݒ�           (Protected  SET_TPRG_SEQNO)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ݽ���ް���ԕϐ��ݒ�
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Sub SET_TPRG_SEQNO(ByVal objRow As DataRow)
        Try

            '***********************
            '�ް����
            '***********************
            mFSEQ_ID = objRow("FSEQ_ID")                             '���ݽ���ްID
            mFSEQ_NAME = objRow("FSEQ_NAME")                         '���ݽ���ް����
            mFSEQ_NO = objRow("FSEQ_NO")                             '���ݽ���ް
            mFSEQ_NO_MAX = objRow("FSEQ_NO_MAX")                     '���ݽ���ް�ő�l
            mFSEQ_NO_MIN = objRow("FSEQ_NO_MIN")                     '���ݽ���ް�ŏ��l
            mFUPDATE_DT = objRow("FUPDATE_DT")                       '�X�V����
            mFRESET_DT = objRow("FRESET_DT")                         'ؾ�ē���


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#End Region

End Class
