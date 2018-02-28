'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�����w����������
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_010001
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �ݽ�׸�                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݽ�׸�
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <param name="objDb"></param>
    ''' <param name="objDbLog"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '�e�׽�̺ݽ�׸�������
    End Sub
#End Region
#Region "  Ҳݏ���                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ҳݏ���
    ''' </summary>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010002)                           '


            '************************
            '�����w��QUE�̌��m
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)     '�����w��QUE
            intRet = GetRecordQue(objTPLN_CARRY_QUE)
            If intRet = RetCode.NotFound Then
                '(�����w��QUE��ں��ނ��Ȃ������ꍇ)
                Return RetCode.OK
            End If


            '************************
            '��������
            '************************
            Dim dtmNow01 As Date = Now
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)

            For ii As Integer = LBound(objTPLN_CARRY_QUE.ARYME) To UBound(objTPLN_CARRY_QUE.ARYME)
                '(ٰ��:�����w��QUE��)

                Try


                    '************************
                    '�w�����򏈗�
                    '************************
                    intRet = JunctionDir(objTPLN_CARRY_QUE.ARYME(ii))
                    If intRet = RetCode.OK Then
                        '(����I�������ꍇ)

                        '������������************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/08/15  �����񍐂���M���Ȃ��ꍇ�A�����Ŋ��������邪�A�����Ŋ���������Ɣ����w��QUE��ں��ނ��Ȃ��Ȃ�A�װ�ƂȂ�̂ł��̑΍�
                        intRet = objTPLN_CARRY_QUE.ARYME(ii).GET_TPLN_CARRY_QUE(False)
                        If intRet = RetCode.OK Then
                            '������������************************************************************************************************************
                            objTPLN_CARRY_QUE.ARYME(ii).FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND
                            objTPLN_CARRY_QUE.ARYME(ii).UPDATE_TPLN_CARRY_QUE()
                            '������������************************************************************************************************************
                            'SystemMate:N.Dounoshita 2012/08/15  �����񍐂���M���Ȃ��ꍇ�A�����Ŋ��������邪�A�����Ŋ���������Ɣ����w��QUE��ں��ނ��Ȃ��Ȃ�A�װ�ƂȂ�̂ł��̑΍�
                        End If
                        '������������************************************************************************************************************

                    End If


                Catch ex As ContinueForException
                    ObjDb.RollBack()        '۰��ޯ�
                    ObjDb.BeginTrans()      '��ݻ޸��݊J�n
                Catch ex As UserException
                    Call ComUser(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    '۰��ޯ�
                    ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n
                Catch ex As Exception
                    Call ComError(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    '۰��ޯ�
                    ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n
                Finally
                    ObjDb.Commit()      '�Я�
                    ObjDb.BeginTrans()  '��ݻ޸��݊J�n
                End Try
            Next
            objTPLN_CARRY_QUE.ARYME_CLEAR()


            '************************
            '���튮��
            '************************
            Dim objDiff As TimeSpan = Now - dtmNow01
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL _
                             & "[��������:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
                             )


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  �����w��QUE�̓ǂݍ���                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����w��QUE�̓ǂݍ���
    ''' </summary>
    ''' <param name="objTPLN_CARRY_QUE">�����w��QUEð��ٵ�޼ު��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function GetRecordQue(ByRef objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE) As RetCode
        Try
            Dim intReturn As RetCode = RetCode.NG   '���g�֐��߂�l
            Dim strSQL As String                    'SQL��
            'Dim strMsg As String                    'ү����
            Dim intRet As RetCode                   '�߂�l

            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"                                              '�����w��QUE
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"                                 '�����w��QUE
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        TPLN_CARRY_QUE.FCARRYQUE_DIR_STS = " & FCARRYQUE_DIR_STS_SNON & ""      '�����w��QUE    .�����w����
            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/11/06  �o�Ɏw������ʂɾ�Ă����ƁA�����Ɏ��Ԃ�������ׁA�o�Ɏw�������͕ʂɂ����B
            '                                    �����w��QUEð��ق�ں���1���ɑ΂��A0.1�b������B
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_KUBUN NOT IN (" & FCARRYQUE_KUBUN_SOUT & ")"   '�����w��QUE    .�w���敪
            '������������************************************************************************************************************
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE.FPRIORITY DESC"                  '�����w��QUE  .��ײ��è�敪
            strSQL &= vbCrLf & "  , TPLN_CARRY_QUE.FCARRYQUE_D "                    '�����w��QUE  .�����w����
            strSQL &= vbCrLf & "  , TPLN_CARRY_QUE.FCARRYQUE_ORDER "                '�����w��QUE  .��������
            strSQL &= vbCrLf

            '***********************
            '���o
            '***********************
            objTPLN_CARRY_QUE.USER_SQL = strSQL
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_USER()
            If intRet = RetCode.OK Then
                '(ں��ނ����������ꍇ)
                intReturn = RetCode.OK
            Else
                '(ں��ނ��ꌏ���Ȃ��ꍇ)
                intReturn = RetCode.NotFound
            End If


            Return (intReturn)
        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
#Region "  �w�����򏈗�                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �w�����򏈗�
    ''' </summary>
    ''' <param name="objTPLN_CARRY_QUE">�����w��QUE</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function JunctionDir(ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE) As Integer
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                   'ү����
        Try
            '************************
            '�����w�����򏈗�
            '************************
            Select Case TO_INTEGER(objTPLN_CARRY_QUE.FCARRYQUE_KUBUN)
                Case FCARRYQUE_KUBUN_SIN                                        '���Ɏw��
                    Dim objSVR_010101 As New SVR_010101(Owner, ObjDb, ObjDbLog) '���Ɏw���׽
                    objSVR_010101.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '�����w��QUE
                    intRet = objSVR_010101.ExecCmdFunction()

                    '������������************************************************************************************************************
                    'SystemMate:N.Dounoshita 2012/11/06  �o�Ɏw������ʂɾ�Ă����ƁA�����Ɏ��Ԃ�������ׁA�o�Ɏw�������͕ʂɂ����B
                    '                                    �����w��QUEð��ق�ں���1���ɑ΂��A0.1�b������B

                    'Case FCARRYQUE_KUBUN_SOUT                                       '�o�Ɏw��(�I�Ԕ������܂�)
                    'Dim objSVR_010201 As New SVR_010201(Owner, ObjDb, ObjDbLog) '�o�Ɏw���׽
                    'objSVR_010201.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '�����w��QUE
                    'intRet = objSVR_010201.ExecCmdFunction()

                    '������������************************************************************************************************************

                Case FCARRYQUE_KUBUN_STANA_MOVE                                 '�I�Ԕ����w��
                    Dim objSVR_010201 As New SVR_010201(Owner, ObjDb, ObjDbLog) '�o�Ɏw���׽
                    objSVR_010201.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '�����w��QUE
                    intRet = objSVR_010201.ExecCmdFunction_Tana()

                Case FCARRYQUE_KUBUN_SMOVE                                      '�����w��
                    Dim objSVR_010301 As New SVR_010301(Owner, ObjDb, ObjDbLog) '�����w���׽
                    objSVR_010301.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '�����w��QUE
                    intRet = objSVR_010301.ExecCmdFunction()

                Case FCARRYQUE_KUBUN_SBUNKI                                     '����w������
                    'NOP

                Case Else
                    intRet = RetCode.NG
            End Select


            Return intRet
        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '���������ьŗL
    '���������ьŗL
    '**********************************************************************************************

End Class
