'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���ް��۾��p����ڰ�
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon

Imports System.IO

#End Region

Public Class clsTemplateServer
    Inherits clsTemplate


#Region "  �׽���������p�ϐ���`                                                                    "

    '��������
    Public MeSyoriID As String = Me.GetType.Name.ToString                                  '����ID
    Public MeDSPID As String = FORMAT_DSP_PRI & Replace(MeSyoriID, FORMAT_DSP_DELCMD, "")  '����ID

    '�d������p
    Private Const DSPTERM_ID As Integer = 0         '�[��ID
    Private Const DSPUSER_ID As Integer = 1         'հ�ްID
    Private Const DSPREASON As Integer = 2          '���R

    Private Const DSPTRK_BUF_NO As Integer = 3      '�ׯ�ݸ��ޯ̧��


#End Region
#Region "  �ݽ�׸�                                                                                  "
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
        MyBase.new(objOwner, objDb, objDbLog)   '�e�׽�̺ݽ�׸�������
    End Sub
#End Region
#Region "  ����ގ��s����[�����ͻ�޸׽]                                                              "
    '**********************************************************************************************
    '�y�@�\�z
    '�y�����z[IN] msgRecv       �F��Mү����
    '�@�@�@�@[OUT]msgSend       �F�ԓ�ү����
    '�y�ߒl�z0:OK 1:NG 2:NotFound
    '**********************************************************************************************
    ''' <summary>
    ''' ����ގ��s����(�����ͻ�޸׽�ɂčs��)
    ''' </summary>
    ''' <param name="msgRecv"></param>
    ''' <param name="msgSend"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function ExecCmd(ByVal msgRecv As String, ByRef msgSend As String) As RetCode

    End Function
#End Region
#Region "  ����ގ��s����[��ݻ޸��ݏ����t��]                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����ގ��s����[��ݻ޸��ݏ����t��](�����ͻ�޸׽�ɂčs��)
    ''' </summary>
    ''' <param name="msgRecv">��Mү����</param>
    ''' <param name="msgSend">�ԓ�ү����</param>
    ''' <returns>0:OK 1:NG 2:NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Function ExecCmdTrans(ByVal msgRecv As String, ByRef msgSend As String) As Integer
        Dim rtn As Integer = RetCode.NG


        '************************
        '��ݻ޸��݊J�n
        '************************
        ObjDb.BeginTrans()

        Try
            rtn = ExecCmd(msgRecv, msgSend)

        Catch ex As Exception
            ComError(ex)
            Throw New System.Exception(ex.Message)

        Finally
            If rtn = RetCode.NG Then
                '(�ُ�I���̏ꍇ)
                '************************
                '۰��ޯ�
                '************************
                ObjDb.RollBack()

            Else
                '(����I���̏ꍇ)
                '************************
                '�Я�
                '************************
                Try
                    ObjDb.Commit()
                Catch ex As Exception
                    Throw New Exception("�y�ЯĎ��s�z" & ex.Message)
                End Try

            End If
        End Try

        Return rtn

    End Function
#End Region
#Region "  �װ�� ����Ӽޭ��                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ�� ����Ӽޭ��
    ''' </summary>
    ''' <param name="e">��O�̊�{��޼ު��</param>
    ''' <param name="strFunc"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub ComError(ByVal e As Exception, Optional ByVal strFunc As String = "")
        Try

            '***********************
            '���Ѵװ�o�^
            '***********************
            Dim st As StackTrace = New StackTrace(e, True)
            Dim strMsg As String = ""   'ү����
            Dim strProd As String = ""
            strProd &= "Src="
            For ii As Integer = 0 To st.FrameCount - 1
                strProd &= "["
                strProd &= st.GetFrame(ii).GetFileName
                strProd &= "." & st.GetFrame(ii).GetFileLineNumber()
                strProd &= "]"
            Next

            If strFunc <> "" Then
                strFunc = " Fnc=[" & strFunc & "]"
            End If
            strMsg &= "Msg=[" & e.Message & "]"
            Call AddToLog(strMsg, strProd & strFunc, LogType.SERR)


            '������������************************************************************************************************************
            'JobMate:Dou 2014/07/29 ���̉ӏ����ޯ��ۯ����������Ă���^�������������̂ŁA���ı��
            '                       ���ı�Ă�����A���Ѵװ۸ނ��o�͂���Ȃ��Ȃ����̂ŁA���Ѵװ۸ޒǉ�������ǉ�


            Dim strPROC_CD As String            '��������
            Dim strLOG_DATA As String           '�ُ���e

            '************************
            'Insert���̏�����
            '************************
            Const LEN_PROC_CD As Integer = 1024              '̨���ޕ���������
            Const LEN_LOG_DATA As Integer = 1024             '̨���ޕ���������
            strPROC_CD = SQL_ITEM(strProd, LEN_PROC_CD)             '��������
            strLOG_DATA = SQL_ITEM(strMsg, LEN_LOG_DATA)            '�ُ���e


            '***********************
            '���Ѵװ۸ނ̓o�^
            '***********************
            Dim objTLOG_SYS As New UserProcess.TBL_TLOG_SYS(Owner, ObjDbLog, ObjDbLog)  '���Ѵװ۸�
            objTLOG_SYS.FHASSEI_DT = Now                        '��������
            objTLOG_SYS.FPROC_CD = strPROC_CD                   '��������
            objTLOG_SYS.FLOG_DATA = strLOG_DATA                 '�ُ���e
            objTLOG_SYS.FLOG_KIND = TO_STRING(LogType.SERR)          '۸ގ��
            objTLOG_SYS.ADD_TLOG_SYS_SEQ()                      '�o�^


            '������������************************************************************************************************************


            '***********************
            '�w���׸�����
            '***********************
            Dim strSQL As String            'SQL��
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            Dim objRow As DataRow           '1ں��ޕ����ް�
            Dim intDEBUG_FLAG As Integer    '�׸ޒl
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_SYS_HEN"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FHENSU_ID = '" & TO_STRING(FHENSU_ID_SSS000000_004) & "'"
            strSQL &= vbCrLf
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SYS_HEN"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                intDEBUG_FLAG = TO_INTEGER(objRow("FHENSU_INT"))                       '�����ް�
                If intDEBUG_FLAG = FLAG_ON Then
                    Call AddToMsgLog(Now, FMSG_ID_S9000, strProd, strMsg)
                End If
            End If


        Catch ex As UserException
            'NOP(Error �������� Error ���)
        Catch ex As Exception
            'NOP(Error �������� Error ���)
        End Try
    End Sub
#End Region
#Region "  հ�ް�װ�� ����Ӽޭ��                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' հ�ް�װ�� ����Ӽޭ��
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="strFunc"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub ComUser(ByVal e As UserException, Optional ByVal strFunc As String = "")
        Try

            '***********************
            '��������
            '***********************
            If e.blnAddLog = False Then Exit Sub

            '***********************
            '���Ѵװ�o�^
            '***********************
            Dim st As StackTrace = New StackTrace(e, True)
            Dim strMsg As String = ""   'ү����
            Dim strProd As String = ""
            strProd &= "Src="
            For ii As Integer = 0 To st.FrameCount - 1
                strProd &= "["
                strProd &= st.GetFrame(ii).GetFileName
                strProd &= "." & st.GetFrame(ii).GetFileLineNumber()
                strProd &= "]"
            Next

            If strFunc <> "" Then
                strFunc = " Fnc=[" & strFunc & "]"
            End If
            strMsg &= "Msg=[" & e.Message & "]"
            Call AddToLog(strMsg, strProd & strFunc, LogType.SERR)


            '������������************************************************************************************************************
            'JobMate:Dou 2014/07/29 ���̉ӏ����ޯ��ۯ����������Ă���^�������������̂ŁA���ı��
            '                       ���ı�Ă�����A���Ѵװ۸ނ��o�͂���Ȃ��Ȃ����̂ŁA���Ѵװ۸ޒǉ�������ǉ�


            Dim strPROC_CD As String            '��������
            Dim strLOG_DATA As String           '�ُ���e

            '************************
            'Insert���̏�����
            '************************
            Const LEN_PROC_CD As Integer = 1024              '̨���ޕ���������
            Const LEN_LOG_DATA As Integer = 1024             '̨���ޕ���������
            strPROC_CD = SQL_ITEM(strProd, LEN_PROC_CD)             '��������
            strLOG_DATA = SQL_ITEM(strMsg, LEN_LOG_DATA)            '�ُ���e



            '***********************
            '���Ѵװ۸ނ̓o�^
            '***********************
            Dim objTLOG_SYS As New UserProcess.TBL_TLOG_SYS(Owner, ObjDbLog, ObjDbLog)  '���Ѵװ۸�
            objTLOG_SYS.FHASSEI_DT = Now                        '��������
            objTLOG_SYS.FPROC_CD = strPROC_CD                   '��������
            objTLOG_SYS.FLOG_DATA = strLOG_DATA                 '�ُ���e
            objTLOG_SYS.FLOG_KIND = TO_STRING(LogType.SERR)          '۸ގ��
            objTLOG_SYS.ADD_TLOG_SYS_SEQ()                      '�o�^


            '������������************************************************************************************************************


            '***********************
            '�w���׸�����
            '***********************
            Dim strSQL As String            'SQL��
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            Dim objRow As DataRow           '1ں��ޕ����ް�
            Dim intDEBUG_FLAG As Integer    '�׸ޒl
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_SYS_HEN"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FHENSU_ID = '" & TO_STRING(FHENSU_ID_SSS000000_004) & "'"
            strSQL &= vbCrLf
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SYS_HEN"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                intDEBUG_FLAG = TO_NUMBER(objRow("FHENSU_INT"))                       '�����ް�
                If intDEBUG_FLAG = FLAG_ON Then
                    Call AddToMsgLog(Now, FMSG_ID_S9001, strProd, strMsg)
                End If
            End If


        Catch ex As UserException
            'NOP(Error �������� Error ���)
        Catch ex As Exception
            'NOP(Error �������� Error ���)
        End Try
    End Sub
#End Region
#Region "  ۸ޏ�������                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸ޏ������ݏ���
    ''' </summary>
    ''' <param name="strMsg">۸ޏ���ү����</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ү���ދ敪    0:��� 1:հ�ް�װ 2:���Ѵװ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        Try
            If Owner Is Nothing = False Then
                Owner.AddToLog(strMsg, strProd, intType)
            End If
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  ү���ޗ�����������                                                                       "
    '''**********************************************************************************************
    ''' <summary>
    ''' ү���ޗ����������ݏ���
    ''' </summary>
    ''' <param name="dtmACTION_DATE">��������</param>
    ''' <param name="strMSG_ID">ү����ID</param>
    ''' <param name="strPrm1">���Ұ�1</param>
    ''' <param name="strPrm2">���Ұ�2</param>
    ''' <param name="strPrm3">���Ұ�3</param>
    ''' <param name="strPrm4">���Ұ�4</param>
    ''' <param name="strPrm5">���Ұ�5</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub AddToMsgLog(ByVal dtmACTION_DATE As Date, _
                           ByVal strMSG_ID As String, _
                           Optional ByVal strPrm1 As String = "", _
                           Optional ByVal strPrm2 As String = "", _
                           Optional ByVal strPrm3 As String = "", _
                           Optional ByVal strPrm4 As String = "", _
                           Optional ByVal strPrm5 As String = "")
        Try

            Dim strSQL As String                'SQL��
            'Dim strMsg As String                'ү����
            Dim intRet As RetCode = RetCode.OK  '�֐��߂�l
            'Dim intRetSQL As Integer            'SQL���s�߂�l
            'Dim objRow As DataRow               '1ں��ޕ����ް�


            '***********************
            '���m�F����ү��������
            '***********************
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLOG_MESSAGE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FMSG_ID = '" & strMSG_ID & "'"               'ү����ID
            strSQL &= vbCrLf & "    AND FLOG_CHECK_FLAG = " & TO_STRING(FLAG_OFF)   '�m�F�׸�
            If strPrm1 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM1 = '" & SQL_ITEM(strPrm1, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM1 IS NULL"
            End If
            If strPrm2 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM2 = '" & SQL_ITEM(strPrm2, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM2 IS NULL"
            End If
            If strPrm3 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM3 = '" & SQL_ITEM(strPrm3, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM3 IS NULL"
            End If
            If strPrm4 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM4 = '" & SQL_ITEM(strPrm4, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM4 IS NULL"
            End If
            If strPrm5 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM5 = '" & SQL_ITEM(strPrm5, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM5 IS NULL"
            End If
            strSQL &= vbCrLf
            ObjDbLog.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TLOG_MESSAGE"
            ObjDbLog.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(���ꖢ�m�Fү���ޗL�̏ꍇ)
                Exit Try
            End If


            '***********************
            '۸ނ̓o�^
            '***********************
            Dim objTLOG_MESSAGE As New TBL_TLOG_MESSAGE(Owner, ObjDbLog, ObjDbLog)      'ү����۸�ð��ٸ׽
            objTLOG_MESSAGE.FMSG_ID = strMSG_ID                                         'ү����ID
            objTLOG_MESSAGE.FLOG_CHECK_FLAG = FLAG_OFF                                  '�m�F�׸�
            objTLOG_MESSAGE.FHASSEI_DT = dtmACTION_DATE                                 '��������
            objTLOG_MESSAGE.FLOG_CHECK_DT = DEFAULT_DATE                                '�m�F����
            objTLOG_MESSAGE.FUSER_ID = DEFAULT_STRING                                    'հ�ްID
            objTLOG_MESSAGE.FMSG_PRM1 = SQL_ITEM(strPrm1, LOGMSG_SYS_PRM_FLD_SIZE)      '���Ұ�1
            objTLOG_MESSAGE.FMSG_PRM2 = SQL_ITEM(strPrm2, LOGMSG_SYS_PRM_FLD_SIZE)      '���Ұ�2
            objTLOG_MESSAGE.FMSG_PRM3 = SQL_ITEM(strPrm3, LOGMSG_SYS_PRM_FLD_SIZE)      '���Ұ�3
            objTLOG_MESSAGE.FMSG_PRM4 = SQL_ITEM(strPrm4, LOGMSG_SYS_PRM_FLD_SIZE)      '���Ұ�4
            objTLOG_MESSAGE.FMSG_PRM5 = SQL_ITEM(strPrm5, LOGMSG_SYS_PRM_FLD_SIZE)      '���Ұ�5
            objTLOG_MESSAGE.ADD_TLOG_MESSAGE_SEQ()                                      '�o�^


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/09/05 �ُ��ޯčX�V


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J340011)                           '�N��


            '������������************************************************************************************************************


        Catch ex As UserException
            'NOP(Error �������� Error ���)
        Catch ex As Exception
            'NOP(Error �������� Error ���)
        End Try
    End Sub
#End Region
#Region "  ���ڰ���۸ޏ�������                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ڰ���۸ޏ������ݏ���
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="strDenbunDtlName">�d�����𖼏̔z��</param>
    ''' <param name="strSYORI_ID">����ID</param>
    ''' <param name="strFLOG_DATA_OPE">���ڰ���۸�.  ���ڰ���۸��ް�</param>
    ''' <param name="strFMSG_PRM1">��ݻ޸���۸�. ���Ұ�1</param>
    ''' <param name="strFMSG_PRM2">��ݻ޸���۸�. ���Ұ�2</param>
    ''' <param name="strFMSG_PRM3">��ݻ޸���۸�. ���Ұ�3</param>
    ''' <param name="strFMSG_PRM4">��ݻ޸���۸�. ���Ұ�4</param>
    ''' <param name="strFMSG_PRM5">��ݻ޸���۸�. ���Ұ�5</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToOpeLog(ByVal strDenbunDtl() As String _
                         , ByVal strDenbunDtlName() As String _
                         , ByVal strSYORI_ID As String _
                         , ByVal strFLOG_DATA_OPE As String _
                         , Optional ByVal strFMSG_PRM1 As String = Nothing _
                         , Optional ByVal strFMSG_PRM2 As String = Nothing _
                         , Optional ByVal strFMSG_PRM3 As String = Nothing _
                         , Optional ByVal strFMSG_PRM4 As String = Nothing _
                         , Optional ByVal strFMSG_PRM5 As String = Nothing _
                           )
        Try


            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)     '�[��Ͻ�
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '�[��ID     ���
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '����


            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)       '�[��Ͻ�
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)                    'հ�ްID
            Try
                '(۸޲݂̎��́Aհ�ް������o���Ȃ��ꍇ�������)
                Call objTMST_USER.GET_TMST_USER(False)  '����
            Catch ex As Exception
            End Try


            '***********************
            '����Ͻ��̓���
            '***********************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ�
            objTPRG_TIMER.FSYORI_ID = strSYORI_ID   '����ID
            objTPRG_TIMER.GET_TPRG_TIMER(False)     '����


            '***********************
            '۸ޓo�^����
            '***********************
            '���ڰ���۸�
            Dim blnLogOpe As Boolean = True                     '���ڰ���۸�  �o�^
            If IsNull(objTPRG_TIMER.FLOG_OPE_FLAG) = False Then
                If TO_DECIMAL(objTPRG_TIMER.FLOG_OPE_FLAG) = FLAG_OFF Then
                    blnLogOpe = False
                End If
            End If
            '��ݻ޸���۸�
            Dim blnLogTrn As Boolean = True                     '��ݻ޸���۸�   �o�^
            If IsNull(objTPRG_TIMER.FLOG_TRN_FLAG) = False Then
                If TO_DECIMAL(objTPRG_TIMER.FLOG_TRN_FLAG) = FLAG_OFF Then
                    blnLogTrn = False
                End If
            End If
            '��Ɨ���
            Dim blnEvdOpe As Boolean = False                    '��Ɨ���     �o�^���Ȃ�
            If IsNull(objTPRG_TIMER.FEVD_OPE_FLAG) = False Then
                If TO_DECIMAL(objTPRG_TIMER.FEVD_OPE_FLAG) = FLAG_ON Then
                    blnEvdOpe = True
                End If
            End If


            '***********************
            '���ڰ���۸�
            '***********************
            If blnLogOpe = True Then
                '***********************
                '���ڰ���۸ނ̓o�^
                '***********************
                Dim objTLOG_OPE As New TBL_TLOG_OPE(Owner, ObjDbLog, ObjDbLog)          '���ڰ���۸޸׽
                objTLOG_OPE.FHASSEI_DT = Now                        '��������
                objTLOG_OPE.FTERM_ID = strDenbunDtl(DSPTERM_ID)     '�[��ID
                objTLOG_OPE.FTERM_NAME = objTDSP_TERM.FTERM_NAME    '�[����
                objTLOG_OPE.FUSER_ID = strDenbunDtl(DSPUSER_ID)     'հ�ްID
                objTLOG_OPE.FUSER_NAME = objTMST_USER.FUSER_NAME    'հ�ް��
                objTLOG_OPE.FSYORI_ID = strSYORI_ID                 '����ID
                objTLOG_OPE.FSYORI_NAME = objTPRG_TIMER.FCOMMENT    '������
                objTLOG_OPE.FREASON_CD = Nothing                    '���R����
                objTLOG_OPE.FREASON = strDenbunDtl(2)                    '���R
                objTLOG_OPE.FLOG_DATA_OPE = strFLOG_DATA_OPE        '���ڰ���۸��ް�
                objTLOG_OPE.ADD_TLOG_OPE_SEQ()                      '�o�^


                '**************************************
                '���ڰ���۸ޏڍׂ̓o�^
                '**************************************
                Dim objTLOG_OPE_DTL As New TBL_TLOG_OPE_DTL(Owner, ObjDbLog, ObjDbLog)                  '���ڰ���۸ޏڍ׸׽
                objTLOG_OPE_DTL.FLOG_NO = objTLOG_OPE.FLOG_NO                                           '۸އ�
                For ii As Integer = 3 To UBound(strDenbunDtl)
                    '(ٰ��:���ڰ���۸ޏڍא�)

                    objTLOG_OPE_DTL.FORDER = ii - 1                             '�\����
                    objTLOG_OPE_DTL.FDENBUN_ITEM_NAME = strDenbunDtlName(ii)    '�d�����і���
                    objTLOG_OPE_DTL.FDENBUN_ITEM_DATA = strDenbunDtl(ii)        '�d�������ް�
                    objTLOG_OPE_DTL.ADD_TLOG_OPE_DTL()                          '�ǉ�

                Next
            End If


            '***********************
            '��Ɨ���
            '***********************
            If blnEvdOpe = True Then
                '***********************
                '��Ɨ����̓o�^
                '***********************
                Dim objTEVD_OPE As New TBL_TEVD_OPE(Owner, ObjDbLog, ObjDbLog)  '��Ɨ���׽
                objTEVD_OPE.FHASSEI_DT = Now                                    '��������
                objTEVD_OPE.FTERM_ID = strDenbunDtl(DSPTERM_ID)                 '�[��ID
                objTEVD_OPE.FTERM_NAME = objTDSP_TERM.FTERM_NAME                '�[����
                objTEVD_OPE.FUSER_ID = strDenbunDtl(DSPUSER_ID)                 'հ�ްID
                objTEVD_OPE.FUSER_NAME = objTMST_USER.FUSER_NAME                'հ�ް��
                objTEVD_OPE.FSYORI_ID = strSYORI_ID                             '����ID
                objTEVD_OPE.FSYORI_NAME = objTPRG_TIMER.FCOMMENT                '������
                objTEVD_OPE.FREASON_CD = Nothing                                '���R����
                objTEVD_OPE.FREASON = strDenbunDtl(2)                           '���R
                objTEVD_OPE.FLOG_DATA_OPE = strFLOG_DATA_OPE                    '���ڰ���۸��ް�
                objTEVD_OPE.ADD_TEVD_OPE_SEQ()                                  '�o�^


                '**************************************
                '��Ɨ����ڍׂ̓o�^
                '**************************************
                Dim objTEVD_OPE_DTL As New TBL_TEVD_OPE_DTL(Owner, ObjDbLog, ObjDbLog)                  '���ڰ���۸ޏڍ׸׽
                objTEVD_OPE_DTL.FLOG_NO = objTEVD_OPE.FLOG_NO                                           '۸އ�
                For ii As Integer = 3 To UBound(strDenbunDtl)
                    '(ٰ��:���ڰ���۸ޏڍא�)

                    objTEVD_OPE_DTL.FORDER = ii - 1                             '�\����
                    objTEVD_OPE_DTL.FDENBUN_ITEM_NAME = strDenbunDtlName(ii)    '�d�����і���
                    objTEVD_OPE_DTL.FDENBUN_ITEM_DATA = strDenbunDtl(ii)        '�d�������ް�
                    objTEVD_OPE_DTL.ADD_TEVD_OPE_DTL()                          '�ǉ�

                Next
            End If


            '***********************
            '��ݻ޸���۸ނ̒ǉ�
            '***********************
            If blnLogTrn = True Then
                Dim strDenbunInfo As String = ""        '�d�����Ұ�۸ޗp������
                Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
                Call AddToTrnLog(strDenbunDtl(DSPUSER_ID) _
                               , strDenbunDtl(DSPTERM_ID) _
                               , strSYORI_ID _
                               , strFLOG_DATA_OPE & strDenbunInfo _
                               , strFMSG_PRM1 _
                               , strFMSG_PRM2 _
                               , strFMSG_PRM3 _
                               , strFMSG_PRM4 _
                               , strFMSG_PRM5 _
                                 )

            End If


        Catch ex As Exception
            'NOP(Error �������� Error ���)
        End Try
    End Sub
#End Region
#Region "  ��ݻ޸���۸ޏ�������                                                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ݻ޸���۸ޏ������ݏ���
    ''' </summary>
    ''' <param name="strFUSER_ID">հ�ްID</param>
    ''' <param name="strFTERM_ID">�[��ID</param>
    ''' <param name="strFSYORI_ID">����ID</param>
    ''' <param name="strFSAGYOU_DTL">��Əڍ�</param>
    ''' <param name="strFMSG_PRM1">���Ұ�1</param>
    ''' <param name="strFMSG_PRM2">���Ұ�2</param>
    ''' <param name="strFMSG_PRM3">���Ұ�3</param>
    ''' <param name="strFMSG_PRM4">���Ұ�4</param>
    ''' <param name="strFMSG_PRM5">���Ұ�5</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToTrnLog(ByVal strFUSER_ID As String _
                         , ByVal strFTERM_ID As String _
                         , ByVal strFSYORI_ID As String _
                         , ByVal strFSAGYOU_DTL As String _
                         , Optional ByVal strFMSG_PRM1 As String = Nothing _
                         , Optional ByVal strFMSG_PRM2 As String = Nothing _
                         , Optional ByVal strFMSG_PRM3 As String = Nothing _
                         , Optional ByVal strFMSG_PRM4 As String = Nothing _
                         , Optional ByVal strFMSG_PRM5 As String = Nothing _
                           )
        Try


            '***********************
            '۸ނ̓o�^
            '***********************
            Dim objTLOG_TRNS As New TBL_TLOG_TRNS(Owner, ObjDbLog, ObjDbLog)                    '��ݻ޸���۸޸׽
            objTLOG_TRNS.FHASSEI_DT = Now                                                       '��������
            objTLOG_TRNS.FUSER_ID = strFUSER_ID                                                   'հ�ްID
            objTLOG_TRNS.FTERM_ID = strFTERM_ID                                                 '�[��ID
            objTLOG_TRNS.FSYORI_ID = strFSYORI_ID                                               '����ID
            objTLOG_TRNS.FMSG_PRM1 = strFMSG_PRM1                                               '���Ұ�1
            objTLOG_TRNS.FMSG_PRM2 = strFMSG_PRM2                                               '���Ұ�2
            objTLOG_TRNS.FMSG_PRM3 = strFMSG_PRM3                                               '���Ұ�3
            objTLOG_TRNS.FMSG_PRM4 = strFMSG_PRM4                                               '���Ұ�4
            objTLOG_TRNS.FMSG_PRM5 = strFMSG_PRM5                                               '���Ұ�5
            objTLOG_TRNS.FLOG_DATA_TRN = SQL_ITEM(strFSAGYOU_DTL, LOGTRN_FSAGYOU_DTL_FLD_SIZE)  '��ݻ޸���۸��ް�
            objTLOG_TRNS.ADD_TLOG_TRNS_SEQ()                                                    '�o�^


        Catch ex As Exception
            'NOP(Error �������� Error ���)
        End Try
    End Sub

#End Region
#Region "  ���ޯ��۸ޏ�������                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ޯ��۸ޏ������ݏ���
    ''' </summary>
    ''' <param name="strFUSER_ID">հ�ްID</param>
    ''' <param name="strFTERM_ID">�[��ID</param>
    ''' <param name="strFSYORI_ID">����ID</param>
    ''' <param name="strFSAGYOU_DTL">��Əڍ�</param>
    ''' <param name="strFMSG_PRM1">���Ұ�1</param>
    ''' <param name="strFMSG_PRM2">���Ұ�2</param>
    ''' <param name="strFMSG_PRM3">���Ұ�3</param>
    ''' <param name="strFMSG_PRM4">���Ұ�4</param>
    ''' <param name="strFMSG_PRM5">���Ұ�5</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToDebugLog(ByVal strFUSER_ID As String _
                           , ByVal strFTERM_ID As String _
                           , ByVal strFSYORI_ID As String _
                           , ByVal strFSAGYOU_DTL As String _
                           , Optional ByVal strFMSG_PRM1 As String = Nothing _
                           , Optional ByVal strFMSG_PRM2 As String = Nothing _
                           , Optional ByVal strFMSG_PRM3 As String = Nothing _
                           , Optional ByVal strFMSG_PRM4 As String = Nothing _
                           , Optional ByVal strFMSG_PRM5 As String = Nothing _
                             )
        Try


            '***********************
            '���ѕϐ��̓���
            '***********************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 '���ѕϐ�
            If objTPRG_SYS_HEN.SS000000_008 = FLAG_OFF Then
                '(���ޯ��۸ޓo�^�׸ނ�ON�ɂȂ��Ă��Ȃ��ꍇ)
                Exit Try
            End If


            '********************************
            '��ݻ޸���۸ޏ������ݏ���
            '********************************
            Call AddToTrnLog(strFUSER_ID _
                           , strFTERM_ID _
                           , strFSYORI_ID _
                           , strFSAGYOU_DTL _
                           , strFMSG_PRM1 _
                           , strFMSG_PRM2 _
                           , strFMSG_PRM3 _
                           , strFMSG_PRM4 _
                           , strFMSG_PRM5 _
                             )


        Catch ex As Exception
            'NOP(Error �������� Error ���)
        End Try
    End Sub
#End Region
#Region "  ү���ޕϊ�                                                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ү���ޕϊ�
    ''' </summary>
    ''' <param name="strMSG_ID">ү����ID</param>
    ''' <returns>ү���ޕϊ����ް�</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Change_Message(ByVal strMSG_ID As String) As String
        Try
            Dim objTMST_MESSAGE As New TBL_TMST_MESSAGE(Owner, ObjDb, ObjDbLog)
            Dim intRet As Integer
            Change_Message = ""
            objTMST_MESSAGE.FMSG_ID = strMSG_ID
            intRet = objTMST_MESSAGE.GET_TMST_MESSAGE(False)
            If intRet = RetCode.OK Then
                Return (objTMST_MESSAGE.FMSG_NAIYOU)
            Else
                Return (strMSG_ID)
            End If
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

#Region "  ��ʉ���ү���ލ쐬�i�����ݒ�j                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʉ���ү���ލ쐬�i�����ݒ�j
    ''' </summary>
    ''' <param name="objTelegramSend">�d���쐬�A�����׽</param>
    ''' <param name="msgSend">���M������</param>
    ''' <remarks>������ϊ����ް�</remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeMessageGamenIni(ByRef objTelegramSend As clsTelegram _
                                 , ByRef msgSend As String _
                                   )
        Try
            '�����M�d��������
            objTelegramSend.FORMAT_ID = FORMAT_DSP_RETURN                                       '̫�ϯĖ�   :���ĕԐM
            objTelegramSend.SETIN_DATA("DSPRET_STATE", ID_RETURN_RET_STATE_NG)                  '�ް����    :�����ð��
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE_EXIST", ID_RETURN_RET_MESSAGE_EXIST_YES) '�ް����    :����ү���ޗL��
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE", Me.Change_Message(FMSG_ID_S9000))       '�ް����    :����ү����
            objTelegramSend.SETIN_DATA("DSPRET_DATA_SYUBETU", ID_RETURN_RET_DATA_SYUBETU)       '�ް����    :�����ް����
            objTelegramSend.SETIN_DATA("DSPRET_DATA", ID_RETURN_RET_DATA)                       '�ް����    :�����ް�
            objTelegramSend.MAKE_TELEGRAM()                                                     '�d���쐬
            msgSend = objTelegramSend.TELEGRAM_MAKED


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "  ��ʉ���ү���ލ쐬�i���퉞���j                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʉ���ү���ލ쐬�i���퉞���j
    ''' </summary>
    ''' <param name="objTelegramSend">�d���쐬�A�����׽</param>
    ''' <param name="msgSend">���M������</param>
    ''' <param name="strDataSyubetu"></param>
    ''' <param name="strData"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeMessageGamenOK(ByRef objTelegramSend As clsTelegram _
                                , ByRef msgSend As String _
                                , Optional ByVal strDataSyubetu As String = ID_RETURN_RET_DATA_SYUBETU _
                                , Optional ByVal strData As String = ID_RETURN_RET_DATA _
                                  )
        Try
            '�����M�d��������
            objTelegramSend.FORMAT_ID = FORMAT_DSP_RETURN                                       '̫�ϯĖ�   :���ĕԐM
            objTelegramSend.SETIN_DATA("DSPRET_STATE", ID_RETURN_RET_STATE_OK)                  '�ް����    :�����ð��
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE_EXIST", ID_RETURN_RET_MESSAGE_EXIST_NO)  '�ް����    :����ү���ޗL��
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE", "")                                    '�ް����    :����ү����
            objTelegramSend.SETIN_DATA("DSPRET_DATA_SYUBETU", strDataSyubetu)                   '�ް����    :�����ް����
            objTelegramSend.SETIN_DATA("DSPRET_DATA", strData)                                  '�ް����    :�����ް�
            objTelegramSend.MAKE_TELEGRAM()                                                     '�d���쐬
            msgSend = objTelegramSend.TELEGRAM_MAKED


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "  ��ʉ���ү���ލ쐬�iү���މ����j                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʉ���ү���ލ쐬�iү���މ����j
    ''' </summary>
    ''' <param name="objTelegramSend">�d���쐬�A�����׽</param>
    ''' <param name="msgSend">���M������</param>
    ''' <param name="strRetMessage">����ү����</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeMessageGamenMessage(ByRef objTelegramSend As clsTelegram _
                                , ByRef msgSend As String _
                                , ByVal strRetMessage As String _
                                  )
        Try
            '�����M�d��������
            objTelegramSend.FORMAT_ID = FORMAT_DSP_RETURN                                       '̫�ϯĖ�   :���ĕԐM
            objTelegramSend.SETIN_DATA("DSPRET_STATE", ID_RETURN_RET_STATE_OK)                  '�ް����    :�����ð��
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE_EXIST", ID_RETURN_RET_MESSAGE_EXIST_YES) '�ް����    :����ү���ޗL��
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE", strRetMessage)                         '�ް����    :����ү����
            objTelegramSend.SETIN_DATA("DSPRET_DATA_SYUBETU", ID_RETURN_RET_DATA_SYUBETU)       '�ް����    :�����ް����
            objTelegramSend.SETIN_DATA("DSPRET_DATA", ID_RETURN_RET_DATA)                       '�ް����    :�����ް�
            objTelegramSend.MAKE_TELEGRAM()                                                     '�d���쐬
            msgSend = objTelegramSend.TELEGRAM_MAKED


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "  ��ʉ���ү���ލ쐬�i�װ�����j                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʉ���ү���ލ쐬�i�װ�����j
    ''' </summary>
    ''' <param name="objTelegramSend">�d���쐬�A�����׽</param>
    ''' <param name="msgSend">���M������</param>
    ''' <param name="strRetMessage">����ү����</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeMessageGamenNG(ByRef objTelegramSend As clsTelegram _
                                , ByRef msgSend As String _
                                , ByVal strRetMessage As String _
                                  )
        Try
            strRetMessage &= vbCrLf & "����Ɏ��s���܂����B"


            '�����M�d��������
            objTelegramSend.FORMAT_ID = FORMAT_DSP_RETURN                                       '̫�ϯĖ�   :���ĕԐM
            objTelegramSend.SETIN_DATA("DSPRET_STATE", ID_RETURN_RET_STATE_NG)                  '�ް����    :�����ð��
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE_EXIST", ID_RETURN_RET_MESSAGE_EXIST_YES) '�ް����    :����ү���ޗL��
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE", strRetMessage)                         '�ް����    :����ү����
            objTelegramSend.SETIN_DATA("DSPRET_DATA_SYUBETU", ID_RETURN_RET_DATA_SYUBETU)       '�ް����    :�����ް����
            objTelegramSend.SETIN_DATA("DSPRET_DATA", ID_RETURN_RET_DATA)                       '�ް����    :�����ް�
            objTelegramSend.MAKE_TELEGRAM()                                                     '�d���쐬
            msgSend = objTelegramSend.TELEGRAM_MAKED


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "  �d�����Ұ�۸ޗp�����񐶐�                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �d�����Ұ�۸ޗp�����񐶐�
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="strDenbunDtlName">�d�����𖼏̔z��</param>
    ''' <param name="strDenbunInfo">�d�����Ұ�۸ޗp������</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeLogDataDenbun(ByVal strDenbunDtl() As String _
                               , ByVal strDenbunDtlName() As String _
                               , ByRef strDenbunInfo As String _
                                 )
        Try

            strDenbunInfo = ""
            For ii As Integer = LBound(strDenbunDtl) To UBound(strDenbunDtl)
                '(ٰ��:���ڰ���۸ޏڍא�)

                strDenbunInfo &= "["
                strDenbunInfo &= strDenbunDtlName(ii)    '�d�����і���
                strDenbunInfo &= ":"
                strDenbunInfo &= strDenbunDtl(ii)        '�d�������ް�
                strDenbunInfo &= "]"

            Next


        Catch ex As UserException
            Call ComUser(ex)
            Throw ex
        Catch ex As Exception
            Call ComError(ex)
            Throw ex
        End Try

    End Sub

#End Region
#Region "  ���Ď�M���������ݒ�                                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ���Ď�M���������ݒ�
    ''' </summary>
    ''' <param name="strDenbunDtl">�������ʔz��</param>
    ''' <param name="strDenbunDtlName">�������ʖ��̔z��</param>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <param name="objTelegramRecv">��M�d����޼ު��</param>
    ''' <param name="objTelegramSend">���M�d����޼ު��</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DivDenbun(ByRef strDenbunDtl() As String _
                       , ByRef strDenbunDtlName() As String _
                       , ByVal strMSG_RECV As String _
                       , ByRef strMSG_SEND As String _
                       , ByVal objTelegramRecv As clsTelegram _
                       , ByRef objTelegramSend As clsTelegram _
                         )
        Try


            '************************
            '���M�d��������
            '************************
            Call MakeMessageGamenIni(objTelegramSend, strMSG_SEND)


            '************************
            '��M�d������
            '************************
            objTelegramRecv.FORMAT_ID = MeDSPID                         '̫�ϯĖ����
            objTelegramRecv.TELEGRAM_PARTITION = strMSG_RECV            '��������d�����
            objTelegramRecv.PARTITION()                                 '�d������


            '************************
            '�d������
            '************************
            Call AnalysisDenbun(strDenbunDtl _
                              , strDenbunDtlName _
                              , objTelegramRecv _
                              )


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ���Ď�M���������ݒ�(HDT)                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���Ď�M���������ݒ�(HDT)
    ''' </summary>
    ''' <param name="strSOCK_FORMAT">�d������̫�ϯ�</param>
    ''' <param name="strDenbunDtl">�������ʔz��</param>
    ''' <param name="strDenbunDtlName">�������ʖ��̔z��</param>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <param name="objTelegramRecv">��M�d����޼ު��</param>
    ''' <param name="objTelegramSend">���M�d����޼ު��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub DivDenbunHDT(ByVal strSOCK_FORMAT As String _
                        , ByRef strDenbunDtl() As String _
                        , ByRef strDenbunDtlName() As String _
                        , ByVal strMSG_RECV As String _
                        , ByRef strMSG_SEND As String _
                        , ByVal objTelegramRecv As clsTelegram _
                        , ByRef objTelegramSend As clsTelegram _
                          )
        Try


            '************************
            '��M�d������
            '************************
            objTelegramRecv.FORMAT_ID = strSOCK_FORMAT                  '̫�ϯĖ����
            objTelegramRecv.TELEGRAM_PARTITION = strMSG_RECV            '��������d�����
            objTelegramRecv.PARTITION()                                 '�d������


            '************************
            '���M�d���������i̫�ϯĂ͎�M�d���Ɠ����j
            '************************
            objTelegramSend.FORMAT_ID = strSOCK_FORMAT                  '̫�ϯĖ����
            objTelegramSend.TELEGRAM_PARTITION = strMSG_RECV            '��������d�����
            objTelegramSend.PARTITION()                                 '�d������


            '************************
            '�d������
            '************************
            Call AnalysisDenbunHDT(strDenbunDtl _
                              , strDenbunDtlName _
                              , objTelegramRecv _
                              )


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �d������                                                                                 "
    '''**********************************************************************************************
    ''' <summary>
    ''' �d������
    ''' </summary>
    ''' <param name="strDenbunDtl">�������ʔz��</param>
    ''' <param name="strDenbunDtlName">�������ʖ��̔z��</param>
    ''' <param name="objTelegramRecv">��M�d����޼ު��</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub AnalysisDenbun(ByRef strDenbunDtl() As String _
                            , ByRef strDenbunDtlName() As String _
                            , ByVal objTelegramRecv As clsTelegram _
                              )
        Try


            '*************************************************
            'Config�擾
            '*************************************************
            Dim objDocument As New System.Xml.XmlDocument       'XML�޷����
            Dim objNode As System.Xml.XmlNode                   'XMLɰ��
            Dim ii As Integer = -2                              '����(�����ID�΍�)
            objDocument.Load(CONFIG_TELEGRAM_DSP)               '�ް�۰��

            '==============================================
            'ͯ�ް����
            '==============================================
            For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_HEADER)
                '(ٰ��:ɰ�ސ�)

                If objNode.Name = XML_NODE_ADD Then
                    '(�ް���`�̏ꍇ)
                    Dim strItem As String = ""          '���і�
                    strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    ii += 1
                    If ii < 0 Then Continue For '�����ID�΍�
                    ReDim Preserve strDenbunDtl(ii)
                    strDenbunDtl(ii) = Trim(objTelegramRecv.SELECT_HEADER(strItem))
                End If
                If objNode.NodeType = Xml.XmlNodeType.Comment Then
                    If ii < 0 Then Continue For '�����ID�΍�
                    Dim strItemName As String = ""      '���і���
                    strItemName = objNode.Value
                    ReDim Preserve strDenbunDtlName(ii)
                    strDenbunDtlName(ii) = Trim(strItemName)
                End If

            Next

            '==============================================
            '�ް�����
            '==============================================
            For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_ID_PREFIX & objTelegramRecv.FORMAT_ID)
                '(ٰ��:ɰ�ސ�)

                If objNode.Name = XML_NODE_ADD Then
                    '(�ް���`�̏ꍇ)
                    Dim strItem As String = ""          '���і�
                    strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    ii += 1
                    ReDim Preserve strDenbunDtl(ii)
                    strDenbunDtl(ii) = Trim(objTelegramRecv.SELECT_DATA(strItem))
                End If
                If objNode.NodeType = Xml.XmlNodeType.Comment Then
                    Dim strItemName As String = ""      '���і���
                    strItemName = objNode.Value
                    ReDim Preserve strDenbunDtlName(ii)
                    strDenbunDtlName(ii) = Trim(strItemName)
                End If

            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �d������(HDT)                                                                            "
    '''**********************************************************************************************
    ''' <summary>
    ''' �d������
    ''' </summary>
    ''' <param name="strDenbunDtl">�������ʔz��</param>
    ''' <param name="strDenbunDtlName">�������ʖ��̔z��</param>
    ''' <param name="objTelegramRecv">��M�d����޼ު��</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub AnalysisDenbunHDT(ByRef strDenbunDtl() As String _
                            , ByRef strDenbunDtlName() As String _
                            , ByVal objTelegramRecv As clsTelegram _
                              )
        Try


            '*************************************************
            'Config�擾
            '*************************************************
            Dim objDocument As New System.Xml.XmlDocument       'XML�޷����
            Dim objNode As System.Xml.XmlNode                   'XMLɰ��
            Dim ii As Integer = -2                              '����(�����ID�΍�)
            objDocument.Load(CONFIG_TELEGRAM_HDT)               '�ް�۰��

            '==============================================
            'ͯ�ް����
            '==============================================
            For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_HEADER)
                '(ٰ��:ɰ�ސ�)

                If objNode.Name = XML_NODE_ADD Then
                    '(�ް���`�̏ꍇ)
                    Dim strItem As String = ""          '���і�
                    strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    ii += 1
                    If ii < 0 Then Continue For '�����ID�΍�
                    ReDim Preserve strDenbunDtl(ii)
                    strDenbunDtl(ii) = Trim(objTelegramRecv.SELECT_HEADER(strItem))
                    If ii > 1 Then Exit For '�����ð���ȍ~�΍�
                End If
                If objNode.NodeType = Xml.XmlNodeType.Comment Then
                    If ii < 0 Then Continue For '�����ID�΍�
                    Dim strItemName As String = ""      '���і���
                    strItemName = objNode.Value
                    ReDim Preserve strDenbunDtlName(ii)
                    strDenbunDtlName(ii) = Trim(strItemName)
                    If ii > 1 Then Exit For '�����ð���ȍ~�΍�
                End If

            Next

            '==============================================
            '�ް�����
            '==============================================
            For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_ID_PREFIX & objTelegramRecv.FORMAT_ID)
                '(ٰ��:ɰ�ސ�)

                If objNode.Name = XML_NODE_ADD Then
                    '(�ް���`�̏ꍇ)
                    Dim strItem As String = ""          '���і�
                    strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    ii += 1
                    ReDim Preserve strDenbunDtl(ii)
                    strDenbunDtl(ii) = Trim(objTelegramRecv.SELECT_DATA(strItem))
                End If
                If objNode.NodeType = Xml.XmlNodeType.Comment Then
                    Dim strItemName As String = ""      '���і���
                    strItemName = objNode.Value
                    ReDim Preserve strDenbunDtlName(ii)
                    strDenbunDtlName(ii) = Trim(strItemName)
                End If

            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �\���p���̎擾                                                                           "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �\���p���̎擾
    ''' </summary>
    ''' <param name="strFTABLE_NAME">��ʕ\��Ͻ�.ð��ٖ�</param>
    ''' <param name="strFFIELD_NAME">��ʕ\��Ͻ�.̨���ޖ�</param>
    ''' <param name="strFDISP_VALUE">��ʕ\��Ͻ�.��ʕ\���ݒ�l</param>
    ''' <returns>��ʕ\��Ͻ�.�\���p����</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetTDSP_DISP(ByVal strFTABLE_NAME As String _
                               , ByVal strFFIELD_NAME As String _
                               , ByVal strFDISP_VALUE As String _
                               ) _
                               As Object

        Dim objTDSP_DISP As New TBL_TDSP_DISP(Owner, ObjDb, ObjDbLog)
        Dim objRerutn As Object
        Dim intRet As RetCode
        '' ''Dim strMsg As String


        '*******************************************************
        ' ���ѕϐ��擾
        '*******************************************************
        If IsNull(strFTABLE_NAME) = False _
           And IsNull(strFFIELD_NAME) = False _
           And IsNull(strFDISP_VALUE) = False _
           Then
            '(�l���ݒ肳��Ă���ꍇ)

            objTDSP_DISP.FTABLE_NAME = strFTABLE_NAME       'ð��ٖ�
            objTDSP_DISP.FFIELD_NAME = strFFIELD_NAME       '̨���ޖ�
            objTDSP_DISP.FDISP_VALUE = strFDISP_VALUE       '��ʕ\���ݒ�l
            intRet = objTDSP_DISP.GET_TDSP_DISP(False)      '�擾
            If intRet = RetCode.OK Then
                '(���������ꍇ)
                objRerutn = objTDSP_DISP.FGAMEN_DISP        '�\���p����
            Else
                '(������Ȃ������ꍇ)
                objRerutn = strFDISP_VALUE
            End If

        Else
            '(�l���ݒ肳��Ă��Ȃ��ꍇ)

            objRerutn = strFDISP_VALUE

        End If

        Return objRerutn
    End Function
#End Region
#Region "�@�ݔ���     �擾                                                                        "
    '''***************************************************************************************************************
    ''' <summary>
    ''' �ݔ��󋵎擾
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽(�ݽ�ݽ�����ꂽ���)</param>
    ''' <param name="strFEQ_ID">�ݔ�ID</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub IniTSTS_EQ_CTRL(ByRef objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                             , ByVal strFEQ_ID As String _
                             )
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����


        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '�ݔ�ID
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)              '����


    End Sub
#End Region
#Region "�@�ݔ���     �ݔ���Ԑݒ�                                                                "
    '''***************************************************************************************************************
    ''' <summary>
    ''' �ݔ���     �ݔ���Ԑݒ�
    ''' </summary>
    ''' <param name="strFEQ_ID">�ݔ�ID</param>
    ''' <param name="strFEQ_STS">�ݔ����</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_FEQ_STS(ByVal strFEQ_ID As String, ByVal strFEQ_STS As String)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '�ݔ�ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '����

        objTSTS_EQ_CTRL.FEQ_STS = strFEQ_STS
        objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()


    End Sub
#End Region
#Region "�@�ݔ���     �v����Ԑݒ�                                                                "
    '''***************************************************************************************************************
    ''' <summary>
    ''' �ݔ���     �v����Ԑݒ�
    ''' </summary>
    ''' <param name="strFEQ_ID">�ݔ�ID</param>
    ''' <param name="intFEQ_REQ_STS">�؂藣�����</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_FEQ_REQ_STS(ByVal strFEQ_ID As String, ByVal intFEQ_REQ_STS As Integer)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '�ݔ�ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '����

        objTSTS_EQ_CTRL.FEQ_REQ_STS = intFEQ_REQ_STS
        objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()


    End Sub
#End Region
#Region "�@�ݔ���     �ؗ���Ԏ擾                                                                "
    '''***************************************************************************************************************
    ''' <summary>
    ''' �ݔ���     �ؗ���Ԏ擾
    ''' </summary>
    ''' <param name="strFEQ_ID">�ݔ�ID</param>
    ''' <returns>�ݔ����</returns>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Function Get_EQ_CUT_STS(ByVal strFEQ_ID As String) As Integer
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '�ݔ�ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '����

        Return objTSTS_EQ_CTRL.FEQ_CUT_STS

    End Function
#End Region
#Region "�@�ݔ���     �ؗ���Ԑݒ�                                                                "
    '''***************************************************************************************************************
    ''' <summary>
    ''' �ݔ���     �ؗ���Ԑݒ�
    ''' </summary>
    ''' <param name="strFEQ_ID">�ݔ�ID</param>
    ''' <param name="intFEQ_CUT_STS">�؂藣�����</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_EQ_CUT_STS(ByVal strFEQ_ID As String, ByVal intFEQ_CUT_STS As Integer)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '�ݔ�ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '����

        objTSTS_EQ_CTRL.FEQ_CUT_STS = intFEQ_CUT_STS
        objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()


    End Sub
#End Region
#Region "�@�ݔ���     ��~�v�����ސݒ�                                                            "
    '''***************************************************************************************************************
    ''' <summary>
    ''' �ݔ���     ��~�v�����ސݒ�
    ''' </summary>
    ''' <param name="strFEQ_ID">�ݔ�ID</param>
    ''' <param name="strFEQ_STOP_CD">��~�v������</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_FEQ_STOP_CD(ByVal strFEQ_ID As String, ByVal strFEQ_STOP_CD As String)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '�ݔ�ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '����

        objTSTS_EQ_CTRL.FEQ_STOP_CD = strFEQ_STOP_CD
        objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()


    End Sub
#End Region
#Region "�@�ݔ��󋵏ڍ�     �ݔ��������ސݒ�                                                        "
    '''***************************************************************************************************************
    ''' <summary>
    ''' �ݔ��󋵏ڍ�     �ݔ��������ސݒ�
    ''' </summary>
    ''' <param name="strFEQ_ID">�ݔ�ID</param>
    ''' <param name="strFRES_CD_EQ">�ݔ���������</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_XSTS_EQ_CTRL_DTL_FRES_CD_EQ(ByVal strFEQ_ID As String, ByVal strFRES_CD_EQ As String)
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����


        'Dim objXSTS_EQ_CTRL_DTL As New TBL_XSTS_EQ_CTRL_DTL(Owner, ObjDb, ObjDbLog)
        'objXSTS_EQ_CTRL_DTL.FEQ_ID = strFEQ_ID                      '�ݔ�ID
        'intRet = objXSTS_EQ_CTRL_DTL.GET_XSTS_EQ_CTRL_DTL(True)     '����

        'objXSTS_EQ_CTRL_DTL.FRES_CD_EQ = strFRES_CD_EQ
        'objXSTS_EQ_CTRL_DTL.UPDATE_XSTS_EQ_CTRL_DTL()


    End Sub
#End Region


#Region "  �݌ɏ��                 �ǉ�                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''   �݌ɏ��                 �ǉ�
    ''' </summary>
    ''' <param name="objTRST_STOCK">�݌ɏ��ð��ٸ׽</param>
    ''' <param name="strFHINMEI_CD">�i�ں���</param>
    ''' <param name="strFLOT_NO">ۯć�</param>
    ''' <param name="dtmFARRIVE_DT">�݌ɔ�������</param>
    ''' <param name="intFHORYU_KUBUN">�ۗ��敪</param>
    ''' <param name="decFTR_VOL">�����Ǘ���</param>
    ''' <param name="decFTR_RES_VOL">����������</param>
    ''' <param name="dtmFUPDATE_DT">�X�V����</param>
    ''' <param name="strXPROD_LINE">���Yײ݇�</param>
    ''' <param name="strXKENSA_KUBUN">�����敪</param>
    ''' <param name="strXKENPIN_KUBUN">���i�敪</param>
    ''' <param name="strXMAKER_CD">Ұ�����</param>
    ''' <param name="intFST_FM">������ST�ׯ�ݸ��ޯ̧��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub TRST_STOCKAddProcess(ByRef objTRST_STOCK As TBL_TRST_STOCK _
                                  , ByVal strFHINMEI_CD As String _
                                  , ByVal strFLOT_NO As String _
                                  , ByVal dtmFARRIVE_DT As Nullable(Of Date) _
                                  , ByVal intFIN_KUBUN As Nullable(Of Integer) _
                                  , ByVal intFHORYU_KUBUN As Nullable(Of Integer) _
                                  , ByVal decFTR_VOL As Nullable(Of Decimal) _
                                  , ByVal decFTR_RES_VOL As Nullable(Of Decimal) _
                                  , ByVal dtmFUPDATE_DT As Nullable(Of Date) _
                                  , ByVal strXPROD_LINE As String _
                                  , ByVal strXKENSA_KUBUN As String _
                                  , ByVal strXKENPIN_KUBUN As String _
                                  , ByVal strXMAKER_CD As String _
                                  , ByVal intFST_FM As Nullable(Of Integer) _
                                  )
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        '*****************************************************
        '�݌ɏ��                 �d������
        '*****************************************************
        'NOP


        '*****************************************************
        '�ׯ�ݸ��ޯ̧Ͻ�        �擾
        '*****************************************************
        Dim intFST_FM_Temp As Nullable(Of Integer) = intFST_FM          '������ST�ׯ�ݸ��ޯ̧��
        If IsNotNull(intFST_FM) Then
            '(��������l����Ă���Ă���ꍇ)
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.XTRK_BUF_NO_CONV = intFST_FM                '����Ԋ֘A�t��
            objTMST_TRK.GET_TMST_TRK(False)                         '�擾
            If IsNotNull(objTMST_TRK.FTRK_BUF_NO) Then
                intFST_FM_Temp = objTMST_TRK.FTRK_BUF_NO            '�ׯ�ݸ��ޯ̧��
            End If
        End If



        '*****************************************************
        '�݌ɏ��           �ǉ�
        '*****************************************************
        objTRST_STOCK.FHINMEI_CD = strFHINMEI_CD                '�i�ں���
        objTRST_STOCK.FLOT_NO = strFLOT_NO                      'ۯć�
        objTRST_STOCK.FARRIVE_DT = dtmFARRIVE_DT                '�݌ɔ�������
        objTRST_STOCK.FIN_KUBUN = intFIN_KUBUN                  '���ɋ敪
        'objTRST_STOCK.FSEIHIN_KUBUN = intFSEIHIN_KUBUN          '���i�敪
        'objTRST_STOCK.FZAIKO_KUBUN = intFZAIKO_KUBUN            '�݌ɋ敪
        objTRST_STOCK.FHORYU_KUBUN = intFHORYU_KUBUN            '�ۗ��敪
        objTRST_STOCK.FST_FM = intFST_FM_Temp                   '������ST�ׯ�ݸ��ޯ̧��
        objTRST_STOCK.FTR_VOL = decFTR_VOL                      '�����Ǘ���
        objTRST_STOCK.FTR_RES_VOL = decFTR_RES_VOL              '����������
        objTRST_STOCK.FUPDATE_DT = dtmFUPDATE_DT                '�X�V����
        'objTRST_STOCK.FHASU_FLAG = intFHASU_FLAG                '�[���׸�
        'objTRST_STOCK.FLABEL_ID = strFLABEL_ID                  '����ID
        'objTRST_STOCK.FSYUKKA_TO_CD = strFSYUKKA_TO_CD          '�o�א溰��
        'objTRST_STOCK.FSYUKKA_TO_NAME = strFSYUKKA_TO_NAME      '�o�א於��
        objTRST_STOCK.XPROD_LINE = strXPROD_LINE                '���Yײ݇�
        objTRST_STOCK.XKENSA_KUBUN = strXKENSA_KUBUN            '�����敪
        objTRST_STOCK.XKENPIN_KUBUN = strXKENPIN_KUBUN          '���i�敪
        objTRST_STOCK.XMAKER_CD = strXMAKER_CD                  'Ұ�����
        objTRST_STOCK.ADD_TRST_STOCK_ALL()                      '�o�^


    End Sub
#End Region
#Region "  Ӱ�ސؑ֏���                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ӱ�ސؑ֏���
    ''' </summary>
    ''' <param name="strDSPEQ_ID">�ݔ�ID</param>
    ''' <param name="strDSPMODE">Ӱ��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ModeChangeProcess(ByVal strDSPEQ_ID As String _
                               , ByVal strDSPMODE As String _
                                 )
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����
        Dim dtmNow As Date = Now
        Try

            '������������************************************************************************************************************
            'Checked Comment:A.Noto 2013/03/21 ��۸��ѐ������̺��ı��

            ''************************
            ''�����ݒ�
            ''************************
            'Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog) '�ݔ��󋵸׽
            'Dim strSendFEQ_ID As String = FEQ_ID_JSYS0002      '�ʐM����ݔ�


            ''************************
            ''�ݔ��󋵂̓���
            ''************************
            'Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '�ݔ��󋵸׽
            'objTSTS_EQ_CTRL.FEQ_ID = strDSPEQ_ID                                '�ݔ�ID
            'intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                     '����


            ''************************
            ''�ݔ��󋵂̍X�V
            ''************************
            'objTSTS_EQ_CTRL.FEQ_REQ_STS = FEQ_REQ_STS_SMODE_ON  '�v�����
            'objTSTS_EQ_CTRL.FUPDATE_DT = dtmNow                 '�X�V����
            'objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()               '�X�V


            ''************************
            ''�ݔ��󋵏ڍ�   �擾
            ''************************
            'Dim objXSTS_EQ_CTRL_DTL As New TBL_XSTS_EQ_CTRL_DTL(Owner, ObjDb, ObjDbLog) '�ݔ��󋵏ڍ׸׽
            'objXSTS_EQ_CTRL_DTL.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID
            'intRet = objXSTS_EQ_CTRL_DTL.GET_XSTS_EQ_CTRL_DTL(False)
            'If intRet = RetCode.NotFound Then
            '    '(������Ȃ��ꍇ)
            '    strMsg = ERRMSG_NOTFOUND_XSTS_EQ_CTRL_DTL & "[�ݔ�ID:" & objXSTS_EQ_CTRL_DTL.FEQ_ID & "]"
            '    Throw New UserException(strMsg)
            'End If


            ''************************
            ''�ݔ��󋵏ڍ�   �X�V
            ''************************
            'objXSTS_EQ_CTRL_DTL.FRES_CD_EQ = Nothing
            'objXSTS_EQ_CTRL_DTL.FUPDATE_DT = dtmNow
            'objXSTS_EQ_CTRL_DTL.UPDATE_XSTS_EQ_CTRL_DTL()
            '������������************************************************************************************************************

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �ׯ�ݸ�,�݌ɏ��,���̑���گĂɊ֌W������S�č폜                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ�,�݌ɏ��,���̑���گĂɊ֌W������S�č폜
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ClearDustProcess(ByVal strPALLET_ID As String)

        Try
            Dim intRet As RetCode                   '�߂�l
            'Dim strMsg As String                    'ү����


            '************************
            '�݌��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF.FPALLET_ID = strPALLET_ID                               '��گ�ID
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                         '����


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '�݌Ɉ������
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '����
            If intRet = RetCode.OK Then
                '(���������ꍇ)


                '************************
                '�݌Ɉ������̍폜
                '************************
                objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '�݌Ɉ������׽
                objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
                objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '�폜


            End If


            '************************
            '�\���ޯ̧�̉��
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = strPALLET_ID                          '��گ�ID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '���


            '************************
            '�����w��QUE�̍폜
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�����w��QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             '��گ�ID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                    '����
            If intRet = RetCode.OK Then
                '(���������ꍇ)
                objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE()   '�폜
            End If


            '************************
            '�������䑗�MIF�̍폜
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '�������䑗�MIF�׽
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '�폜


            '************************
            '�ري֘A�t���폜
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       '�ري֘A�t���׽
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                '��گ�ID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '�폜


            '************************
            '���������MIF�̍폜
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '���������MIF�׽
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '�폜


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region


    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/19  ��I�����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A��I�����̑ΏۂƂ��Ȃ��B
#Region "  ���ޱ�ؗ�����            (SVR_100201)                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ޱ�ؗ�����
    ''' </summary>
    ''' <param name="strFEQ_ID_CRANE">�ڰݐݔ�ID</param>
    ''' <param name="intFBUF_FM">�ׯ�ݸ��ޯ̧��(FM)</param>
    ''' <param name="intFBUF_TO">�ׯ�ݸ��ޯ̧��(TO)</param>
    ''' <returns>True:���ޱ�ؗ��L             False:���ޱ�ؗ���</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SVR_100201_CheckTMST_CNV_CRANE(ByVal strFEQ_ID_CRANE As String _
                                                 , ByVal intFBUF_FM As Nullable(Of Integer) _
                                                 , ByVal intFBUF_TO As Nullable(Of Integer) _
                                                 ) _
                                                 As Boolean
        Dim blnReturn As Boolean = False
        'Dim strMsg As String                    'ү����
        Dim intRet As RetCode                   '�߂�l


        '************************************************
        '����
        '************************************************
        If IsNull(intFBUF_FM) Then Return blnReturn


        '************************************************
        '���ޱ�ڰ�Ͻ�       �擾
        '************************************************
        Dim objTMST_CNV_CRANE_Ary As New TBL_TMST_CNV_CRANE(Owner, ObjDb, ObjDbLog)
        objTMST_CNV_CRANE_Ary.FEQ_ID_CRANE = strFEQ_ID_CRANE                '�ڰݐݔ�ID
        objTMST_CNV_CRANE_Ary.FINOUT_KUBUN = FINOUT_KUBUN_SIN               '���o�ɋ敪
        intRet = objTMST_CNV_CRANE_Ary.GET_TMST_CNV_CRANE_ANY()
        If intRet = RetCode.OK Then
            '(���������ꍇ)
            For Each objTMST_CNV_CRANE As TBL_TMST_CNV_CRANE In objTMST_CNV_CRANE_Ary.ARYME
                '(ٰ��:�ΏۂƂȂ���ޱ��)


                '************************************************
                '����
                '************************************************
                If objTMST_CNV_CRANE.FEQ_CUT_STS = FEQ_CUT_STS_SCHECK_OFF Then Continue For


                '************************************************
                '�����N������Ͻ�            �擾
                '************************************************
                Dim objTMST_CHECK_EQ As New TBL_TMST_CHECK_EQ(Owner, ObjDb, ObjDbLog)
                objTMST_CHECK_EQ.FBUF_FM = intFBUF_FM                                   '�������ׯ�ݸ��ޯ̧��
                objTMST_CHECK_EQ.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                        '���ڰݐݔ�ID
                objTMST_CHECK_EQ.FBUF_TO = intFBUF_TO                                   '�������ׯ�ݸ��ޯ̧��
                objTMST_CHECK_EQ.FEQ_ID_CRANE_TO = objTMST_CNV_CRANE.FEQ_ID_CRANE       '��ڰݐݔ�ID
                objTMST_CHECK_EQ.FCHECK_EQ_ID = objTMST_CNV_CRANE.FEQ_ID_CNV            '����ݔ�ID
                intRet = objTMST_CHECK_EQ.GET_TMST_CHECK_EQ(False)
                If intRet <> RetCode.OK Then
                    '(������Ȃ������ꍇ)
                    Continue For
                End If


                '************************************************
                '�ݔ���                   �擾
                '************************************************
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTMST_CNV_CRANE.FEQ_ID_CNV)


                '************************************************
                '��������
                '************************************************
                If objTSTS_EQ_CTRL.FEQ_CUT_STS <> objTMST_CNV_CRANE.FEQ_CUT_STS Then
                    '(�ؗ��������װ�̏ꍇ)
                    blnReturn = True
                    Exit For
                End If


            Next

        End If


        Return blnReturn
    End Function
#End Region
    '������������************************************************************************************************************
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/20  �݌Ɉ����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A�݌Ɉ����̑ΏۂƂ��Ȃ��B
#Region "  ���ޱ�ؗ�����            (SVR_100202)                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ޱ�ؗ�����
    ''' </summary>
    ''' <param name="strFPALLET_ID">��گ�ID</param>
    ''' <param name="intFBUF_FM">�ׯ�ݸ��ޯ̧��(FM)</param>
    ''' <param name="intFBUF_TO">�ׯ�ݸ��ޯ̧��(TO)</param>
    ''' <returns>True:���ޱ�ؗ��L             False:���ޱ�ؗ���</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SVR_100202_CheckTMST_CNV_CRANE(ByVal strFPALLET_ID As String _
                                                 , ByVal intFBUF_FM As Nullable(Of Integer) _
                                                 , ByVal intFBUF_TO As Nullable(Of Integer) _
                                                 ) _
                                                 As Boolean
        Dim blnReturn As Boolean = False
        Dim strMsg As String                    'ү����
        Dim intRet As RetCode                   '�߂�l


        '************************************************
        '����
        '************************************************
        If IsNull(intFBUF_TO) Then Return blnReturn


        '************************************************
        '�ׯ�ݸ��ޯ̧Ͻ�        �擾
        '�����q�ɈȊO�̏ꍇ�́A�����Ȃ�
        '************************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK.FTRK_BUF_NO = intFBUF_FM
        objTMST_TRK.GET_TMST_TRK()
        If objTMST_TRK.FBUF_KIND <> FBUF_KIND_SASRS Then
            '(�����q�ɈȊO�̏ꍇ)
            Return blnReturn
        End If


        '************************************************
        '�ׯ�ݸ��ޯ̧(�I)       �擾
        '************************************************
        Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_ASRS.FPALLET_ID = strFPALLET_ID
        objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()


        '************************************************
        '�ڰ�Ͻ�                ����
        '************************************************
        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)
        objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO        '�ޯ̧��
        objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU         '��
        intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                           '����
        If intRet = RetCode.NotFound Then
            '(������Ȃ��ꍇ)
            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
            Throw New UserException(strMsg)
        End If



        '************************************************
        '���ޱ�ڰ�Ͻ�       �擾
        '************************************************
        Dim objTMST_CNV_CRANE_Ary As New TBL_TMST_CNV_CRANE(Owner, ObjDb, ObjDbLog)
        objTMST_CNV_CRANE_Ary.FEQ_ID_CRANE = objTMST_CRANE.FEQ_ID           '�ڰݐݔ�ID
        objTMST_CNV_CRANE_Ary.FINOUT_KUBUN = FINOUT_KUBUN_SOUT              '���o�ɋ敪
        intRet = objTMST_CNV_CRANE_Ary.GET_TMST_CNV_CRANE_ANY()
        If intRet = RetCode.OK Then
            '(���������ꍇ)
            For Each objTMST_CNV_CRANE As TBL_TMST_CNV_CRANE In objTMST_CNV_CRANE_Ary.ARYME
                '(ٰ��:�ΏۂƂȂ���ޱ��)


                '************************************************
                '����
                '************************************************
                If objTMST_CNV_CRANE.FEQ_CUT_STS = FEQ_CUT_STS_SCHECK_OFF Then Continue For


                '************************************************
                '�����N������Ͻ�            �擾
                '************************************************
                Dim objTMST_CHECK_EQ As New TBL_TMST_CHECK_EQ(Owner, ObjDb, ObjDbLog)
                objTMST_CHECK_EQ.FBUF_FM = intFBUF_FM                                   '�������ׯ�ݸ��ޯ̧��
                objTMST_CHECK_EQ.FEQ_ID_CRANE_FM = objTMST_CNV_CRANE.FEQ_ID_CRANE       '���ڰݐݔ�ID
                objTMST_CHECK_EQ.FBUF_TO = intFBUF_TO                                   '�������ׯ�ݸ��ޯ̧��
                objTMST_CHECK_EQ.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                        '��ڰݐݔ�ID
                objTMST_CHECK_EQ.FCHECK_EQ_ID = objTMST_CNV_CRANE.FEQ_ID_CNV            '����ݔ�ID
                intRet = objTMST_CHECK_EQ.GET_TMST_CHECK_EQ(False)
                If intRet <> RetCode.OK Then
                    '(������Ȃ������ꍇ)
                    Continue For
                End If


                '************************************************
                '�ݔ���                   �擾
                '************************************************
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTMST_CNV_CRANE.FEQ_ID_CNV)


                '************************************************
                '��������
                '************************************************
                If objTSTS_EQ_CTRL.FEQ_CUT_STS <> objTMST_CNV_CRANE.FEQ_CUT_STS Then
                    '(�ؗ��������װ�̏ꍇ)
                    blnReturn = True
                    Exit For
                End If


            Next

        End If


        Return blnReturn
    End Function
#End Region
    '������������************************************************************************************************************

#Region "  �o�Ɏw����������01           (SVR_010002)                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �o�Ɏw����������             (SVR_010002)
    ''' </summary>
    ''' <param name="objTMST_CRANE">�ڰ�Ͻ�</param>
    ''' <param name="intLoopCount01">2��ٰ�߶���</param>
    ''' <param name="intLoopCount02">3��ٰ�߶���</param>
    ''' <param name="blnCheckASRS_OUT">�ڰ݂ɑ΂��A�o�Ɏw�����Ă��邩�ۂ����������邩�ۂ�</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SVR_010002_Process01(ByVal objTMST_CRANE As TBL_TMST_CRANE _
                                       , ByRef intLoopCount01 As Integer _
                                       , ByRef intLoopCount02 As Integer _
                                       , Optional ByVal blnCheckASRS_OUT As Boolean = True _
                                       ) As RetCode
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            ''************************
            ''��������
            ''************************
            'Dim dtmNow01 As Date = Now
            'Dim intLoopCount01 As Integer = 0
            'Dim intLoopCount02 As Integer = 0
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            '�ڰ�Ͻ�        �擾
            '�ڰݖ���ٰ��(1��)(SVR_010002����̋N���̏ꍇ�Ɍ���)
            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            '************************************************
            '�ׯ�ݸ��ޯ̧(�����p)       �擾
            '�ڰ݂ɑ΂��A�o�Ɏw�������M����Ă��邩�ۂ�������
            '************************************************
            If blnCheckASRS_OUT = True Then
                '(��������ꍇ)

                Dim blnASRS_OUT As Boolean = False      '�o���ׯ�ݸޑ����׸�
                Dim objTPRG_TRK_BUF_ASRS_CHECK As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_ASRS_CHECK.FTRK_BUF_NO = objTMST_CRANE.FTRK_BUF_NO          '�ׯ�ݸ��ޯ̧��
                objTPRG_TRK_BUF_ASRS_CHECK.objTMST_CRANE = objTMST_CRANE                    '�ڰ�Ͻ�
                intRet = objTPRG_TRK_BUF_ASRS_CHECK.GET_TPRG_TRK_BUF_RESERVE_RAC(True)      '�ׯ�ݸ��ޯ̧����  [���o�ɗ\��I]
                If intRet = RetCode.OK Then
                    For ii As Integer = 0 To UBound(objTPRG_TRK_BUF_ASRS_CHECK.ARYME)
                        '(ٰ��:���o�ɗ\��I��)

                        If objTPRG_TRK_BUF_ASRS_CHECK.ARYME(ii).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                            '(���o�\��̏ꍇ)
                            blnASRS_OUT = True
                            Continue For
                        End If

                    Next
                End If
                If blnASRS_OUT = True Then Return RetCode.OK

            End If


            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            '�ް��������o�Ɏw��
            '�ް�����ٰ��(2��)
            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2012/12/21 �������Ԃ�������A�ذ�ނ��錻�ۂ��C��
            '                                �o�ɂ���\��������S�Ă�ST��z��ɾ�Ă���悤�ɏC��


            '************************************************
            'SQL��          �쐬
            '************************************************
            Dim strSQL As String = ""           'SQL��
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim strAryFTRK_BUF_NO_BERTH() As String
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTR_TO AS FTR_TO"
            strSQL &= vbCrLf & "   ,MAX(TPLN_CARRY_QUE.FPRIORITY) AS FPRIORITY"
            strSQL &= vbCrLf & "   ,MIN(TPLN_CARRY_QUE.FCARRYQUE_D) AS FCARRYQUE_D"
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE "
            strSQL &= vbCrLf & "   ,TPRG_TRK_BUF "
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "    1 = 1 "
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "               '�ׯ�ݸ��ޯ̧�ƌ���
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_DIR_STS = " & FCARRYQUE_DIR_STS_SNON & ""  '�����w��QUE    .�����w����
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_KUBUN IN (" & FCARRYQUE_KUBUN_SOUT & ") "  '�����w��QUE    .�w���敪
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FEQ_ID = '" & objTMST_CRANE.FEQ_ID & "' "            '�����w��QUE    .�ݔ�ID
            strSQL &= vbCrLf & " GROUP BY "
            strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTR_TO "
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "    FPRIORITY DESC "
            strSQL &= vbCrLf & "   ,FCARRYQUE_D "
            strSQL &= vbCrLf & ""
            'strSQL &= vbCrLf & " SELECT DISTINCT "
            'strSQL &= vbCrLf & "    FBUF_TO "
            'strSQL &= vbCrLf & " FROM  "
            'strSQL &= vbCrLf & "    TMST_ROUTE "
            'strSQL &= vbCrLf & " WHERE "
            'strSQL &= vbCrLf & "        1 = 1 "
            'strSQL &= vbCrLf & "    AND FBUF_FM = " & FTRK_BUF_NO_J9000
            'strSQL &= vbCrLf & " ORDER BY "
            'strSQL &= vbCrLf & "    FBUF_TO "
            'strSQL &= vbCrLf & ""


            '************************************************
            '�ް�           �擾
            '************************************************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                ReDim Preserve strAryFTRK_BUF_NO_BERTH(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                For kk As Integer = LBound(strAryFTRK_BUF_NO_BERTH) To UBound(strAryFTRK_BUF_NO_BERTH)
                    strAryFTRK_BUF_NO_BERTH(kk) = objDataSet.Tables(strDataSetName).Rows(kk)("FTR_TO")
                Next kk
            Else
                Return RetCode.OK
                'Throw New UserException(ERRMSG_NOTFOUND_TMST_ROUTE & "[�������ׯ�ݸ��ޯ̧��:" & FTRK_BUF_NO_J9000 & "]")
            End If



            'Dim strAryFTRK_BUF_NO_BERTH(8) As String
            'strAryFTRK_BUF_NO_BERTH(0) = FTRK_BUF_NO_J1
            'strAryFTRK_BUF_NO_BERTH(1) = FTRK_BUF_NO_J2
            'strAryFTRK_BUF_NO_BERTH(2) = FTRK_BUF_NO_J3
            'strAryFTRK_BUF_NO_BERTH(3) = FTRK_BUF_NO_J4
            'strAryFTRK_BUF_NO_BERTH(4) = FTRK_BUF_NO_J5
            'strAryFTRK_BUF_NO_BERTH(5) = FTRK_BUF_NO_J6
            'strAryFTRK_BUF_NO_BERTH(6) = FTRK_BUF_NO_J7
            'strAryFTRK_BUF_NO_BERTH(7) = FTRK_BUF_NO_J8
            'strAryFTRK_BUF_NO_BERTH(8) = ""

            '������������************************************************************************************************************

            For ii As Integer = 0 To UBound(strAryFTRK_BUF_NO_BERTH)
                '(ٰ��:1�`8���ް��Ƃ��̑�)


                '������������************************************************************************************************************
                'JobMate:N.Dounoshita 2012/12/21 �������Ԃ�������A�ذ�ނ��錻�ۂ��C��
                '                                �o�ɂ���\��������S�Ă�ST��z��ɾ�Ă���悤�ɏC��

                ''************************************************
                ''�ް��ȊO������݂̏���������쐬
                ''************************************************
                'If ii = UBound(strAryFTRK_BUF_NO_BERTH) Then
                '    For jj As Integer = 0 To UBound(strAryFTRK_BUF_NO_BERTH) - 1
                '        If jj = 0 Then
                '            strAryFTRK_BUF_NO_BERTH(ii) = strAryFTRK_BUF_NO_BERTH(jj)
                '        Else
                '            strAryFTRK_BUF_NO_BERTH(ii) &= ", " & strAryFTRK_BUF_NO_BERTH(jj)
                '        End If
                '    Next
                'End If

                '������������************************************************************************************************************


                intLoopCount01 += 1
                '************************
                '�����w��QUE        �擾
                '************************
                Dim objAryTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                objAryTPLN_CARRY_QUE.FEQ_ID = objTMST_CRANE.FEQ_ID                      '�ݔ�ID
                objAryTPLN_CARRY_QUE.FTR_TO = strAryFTRK_BUF_NO_BERTH(ii)                     '����TO�ׯ�ݸ��ޯ̧��

                '������������************************************************************************************************************
                'JobMate:N.Dounoshita 2012/12/21 �������Ԃ�������A�ذ�ނ��錻�ۂ��C��
                '                                �o�ɂ���\��������S�Ă�ST��z��ɾ�Ă���悤�ɏC��

                intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_OUT_FTR_TO(WhereMode.IN_Mode)         '�擾

                'If ii <> UBound(strAryFTRK_BUF_NO_BERTH) Then
                '    intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_OUT_FTR_TO(WhereMode.IN_Mode)         '�擾
                'Else
                '    intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_OUT_FTR_TO(WhereMode.NOTIN_Mode)      '�擾
                'End If

                '������������************************************************************************************************************

                If intRet <> RetCode.OK Then
                    '(�����w��QUE��ں��ނ��Ȃ������ꍇ)
                    Continue For
                End If


                ''************************
                ''�����w��QUE        �擾
                ''************************
                'Dim objAryTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                'objAryTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SOUT             '�w���敪
                'objAryTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON         '�����w����
                'objAryTPLN_CARRY_QUE.FEQ_ID = objTMST_CRANE.FEQ_ID                      '�ݔ�ID
                'objAryTPLN_CARRY_QUE.ORDER_BY = "   FPRIORITY DESC"                     '����
                'objAryTPLN_CARRY_QUE.ORDER_BY &= ", FCARRYQUE_D "                       '����
                'objAryTPLN_CARRY_QUE.ORDER_BY &= ", FCARRYQUE_ORDER "                   '����
                'intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_ANY()                  '�擾
                'If intRet <> RetCode.OK Then
                '    '(�����w��QUE��ں��ނ��Ȃ������ꍇ)
                '    Continue For
                'End If


                '************************************************
                '�ׯ�ݸ��ޯ̧(�ް�)         �擾
                '************************************************
                '������������************************************************************************************************************
                'JobMate:N.Dounoshita 2012/12/21 �������Ԃ�������A�ذ�ނ��錻�ۂ��C��
                '                                �o�ɂ���\��������S�Ă�ST��z��ɾ�Ă���悤�ɏC��
                'If ii <> UBound(strAryFTRK_BUF_NO_BERTH) Then
                '    '(�ް��̏ꍇ)
                '������������************************************************************************************************************

                Dim objTPRG_TRK_BUF_BERTH As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_BERTH.FTRK_BUF_NO = strAryFTRK_BUF_NO_BERTH(ii)           '�ׯ�ݸ��ޯ̧��
                intRet = objTPRG_TRK_BUF_BERTH.GET_TPRG_TRK_BUF_AKI_HIRA()                '�擾
                If intRet <> RetCode.OK Then
                    '(���ޯ̧���Ȃ������ꍇ)
                    Continue For
                End If

                '������������************************************************************************************************************
                'JobMate:N.Dounoshita 2012/12/21 �������Ԃ�������A�ذ�ނ��錻�ۂ��C��
                '                                �o�ɂ���\��������S�Ă�ST��z��ɾ�Ă���悤�ɏC��
                'End If
                '������������************************************************************************************************************


                '************************************************************************************************************************************************************************
                '************************************************************************************************************************************************************************
                '�o�Ɏw��
                '�o�Ɏw����������ٰ��(3��)
                '************************************************************************************************************************************************************************
                '************************************************************************************************************************************************************************
                Dim blnSizi As Boolean = False      '�o�Ɏw�����s�׸�
                For Each objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE In objAryTPLN_CARRY_QUE.ARYME
                    '(ٰ��:�ڰݖ��̔����w��QUE��ں��ސ�)
                    intLoopCount02 += 1


                    Try


                        '************************
                        '�o�Ɏw������
                        '************************
                        Dim objSVR_010201 As New SVR_010201(Owner, ObjDb, ObjDbLog) '�o�Ɏw���׽
                        objSVR_010201.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '�����w��QUE
                        intRet = objSVR_010201.ExecCmdFunction()
                        If intRet = RetCode.OK Then
                            '(�o�Ɏw�����ꂽ�ꍇ)


                            blnSizi = True
                            '������������************************************************************************************************************
                            'SystemMate:N.Dounoshita 2012/08/15  �����񍐂���M���Ȃ��ꍇ�A�����Ŋ��������邪�A�����Ŋ���������Ɣ����w��QUE��ں��ނ��Ȃ��Ȃ�A�װ�ƂȂ�̂ł��̑΍�
                            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)
                            If intRet = RetCode.OK Then
                                '������������************************************************************************************************************
                                objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND
                                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()
                                '������������************************************************************************************************************
                                'SystemMate:N.Dounoshita 2012/08/15  �����񍐂���M���Ȃ��ꍇ�A�����Ŋ��������邪�A�����Ŋ���������Ɣ����w��QUE��ں��ނ��Ȃ��Ȃ�A�װ�ƂȂ�̂ł��̑΍�
                            End If
                            '������������************************************************************************************************************


                            Exit For
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


                    '************************************************************************************************************************
                    '�ڰ�ID�A�s����ST�������ׯ�ݸނł���΁A�S�ē��������̂͂��Ȃ̂ŁA�ŏ����ׯ�ݸނ�����������Ηǂ��B
                    '�ŏ����ׯ�ݸނ��o�ɏo���Ȃ���΁A���̌���S�ďo�ɏo���Ȃ��͂����Ƃ����l���B
                    '************************************************************************************************************************
                    '������������************************************************************************************************************
                    'JobMate:N.Dounoshita 2012/12/21 �������Ԃ�������A�ذ�ނ��錻�ۂ��C��
                    '                                �o�ɂ���\��������S�Ă�ST��z��ɾ�Ă���悤�ɏC��
                    Exit For
                    'If ii <> UBound(strAryFTRK_BUF_NO_BERTH) Then Exit For
                    '������������************************************************************************************************************


                Next
                If blnSizi = True Then Exit For


            Next


            ''************************
            ''���튮��
            ''************************
            'Dim objDiff As TimeSpan = Now - dtmNow01
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
            '                 FLOG_DATA_TRN_SEND_NORMAL _
            '                 & "[��������:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
            '                 & "[ٰ�߉�01:" & TO_STRING(intLoopCount01) & "]" _
            '                 & "[ٰ�߉�02:" & TO_STRING(intLoopCount02) & "]" _
            '                 )


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


    '**********************************************************************************************
    '���������ьŗL

    '�ύX����
#Region "  �ύX�����ڍגǉ�(TMST_ITEM)                                                              "
    '''****************************************************************************************************
    ''' <summary>
    ''' �ύX�����ڍגǉ�
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="MeSyoriID">����ID</param>
    ''' <param name="objTMST_ITEM_Before">�i��Ͻ��X�V�Oð��ٵ�޼ު��</param>
    ''' <param name="objTMST_ITEM_After">�i��Ͻ��X�V��ð��ٵ�޼ު��</param>
    ''' <remarks></remarks>
    '''****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TMST_ITEM(ByVal strDenbunDtl() As String _
                                              , ByVal MeSyoriID As String _
                                              , ByVal objTMST_ITEM_Before As TBL_TMST_ITEM _
                                              , ByVal objTMST_ITEM_After As TBL_TMST_ITEM _
                                              )
        Try
            'Dim intRet As RetCode
            'Dim strMsg As String                    'ү����

            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '�[��ID     ���
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '����


            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'հ�ްID
            Call objTMST_USER.GET_TMST_USER(False)              '����

            '***********************
            '�P��Ͻ��̓���
            '***********************
            Dim objTMST_UNIT_Before As New TBL_TMST_UNIT(Owner, ObjDb, ObjDbLog)
            Dim objTMST_UNIT_After As New TBL_TMST_UNIT(Owner, ObjDb, ObjDbLog)
            objTMST_UNIT_Before.FTANI = objTMST_ITEM_Before.FTANI
            objTMST_UNIT_After.FTANI = objTMST_ITEM_After.FTANI
            If Not (TO_STRING(objTMST_UNIT_Before.FTANI) Is Nothing) Or TO_STRING(objTMST_UNIT_Before.FTANI) <> "" Then
                Call objTMST_UNIT_Before.GET_TMST_UNIT(False)
            End If
            If Not (TO_STRING(objTMST_UNIT_After.FTANI) Is Nothing) Or TO_STRING(objTMST_UNIT_After.FTANI) <> "" Then
                Call objTMST_UNIT_After.GET_TMST_UNIT(False)
            End If


            '**************************************
            'ð��ٕύX����      �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               '۸އ�
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '����ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '��������
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '�[��ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '�[����
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID        'հ�ްID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'հ�ް��
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '���R����
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '���R
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '�ǉ�


            '**************************************
            'ð��ٕύX�����ڍ�  �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               '۸އ�
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '����ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_ITEM"                         'ð��ٖ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI_CD"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FHINMEI_CD)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FHINMEI_CD)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FHINMEI)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FHINMEI)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�


            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FNUM_IN_CASE"                                          '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FNUM_IN_CASE)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FNUM_IN_CASE)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTANI"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FTANI)                  '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FTANI)                    '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDECIMAL_POINT"                                        '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FDECIMAL_POINT)         '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FDECIMAL_POINT)           '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FNUM_IN_PALLET"                                        '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FNUM_IN_PALLET)         '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FNUM_IN_PALLET)           '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FZAIKO_KUBUN"                                          '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FZAIKO_KUBUN)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FZAIKO_KUBUN)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_FORM"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FRAC_FORM)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FRAC_FORM)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_DT"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FENTRY_DT)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FENTRY_DT)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_ID"                                        '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FENTRY_USER_ID)         '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FENTRY_USER_ID)           '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_NAME"                                      '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FENTRY_USER_NAME)       '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FENTRY_USER_NAME)         '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_TERM_ID"                                        '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FENTRY_TERM_ID)         '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FENTRY_TERM_ID)           '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FUPDATE_DT)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FUPDATE_DT)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_ID"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FUPDATE_USER_ID)        '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FUPDATE_USER_ID)          '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_NAME"                                     '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FUPDATE_USER_NAME)      '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FUPDATE_USER_NAME)        '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_TERM_ID"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FUPDATE_TERM_ID)        '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FUPDATE_TERM_ID)          '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�



        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �ύX�����ڍגǉ�(TMST_USER)                                                              "
    '''****************************************************************************************************
    ''' <summary>
    ''' �ύX�����ڍגǉ�
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="MeSyoriID">����ID</param>
    ''' <param name="objTMST_USER_Before">�X�V�Oð��ٵ�޼ު��</param>
    ''' <param name="objTMST_USER_DSP_Before">�X�V�Oð��ٵ�޼ު��</param>
    ''' <param name="objTMST_USER_After">�X�V��ð��ٵ�޼ު��</param>
    ''' <param name="objTMST_USER_DSP_After">�X�V��ð��ٵ�޼ު��</param>
    ''' <remarks></remarks>
    '''****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TMST_USER(ByVal strDenbunDtl() As String _
                                              , ByVal MeSyoriID As String _
                                              , ByVal objTMST_USER_Before As TBL_TMST_USER _
                                              , ByVal objTMST_USER_DSP_Before As TBL_TMST_USER_DSP _
                                              , ByVal objTMST_USER_After As TBL_TMST_USER _
                                              , ByVal objTMST_USER_DSP_After As TBL_TMST_USER_DSP _
                                              )
        Try
            '' ''Dim intRet As RetCode
            '' ''Dim strMsg As String                    'ү����
            Dim strYuukou As String = "��"          '�L���\��
            Dim strMukou As String = "�~"           '�����\��


            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPTERM_ID)) = False Then
                objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '�[��ID     ���
                Call objTDSP_TERM.GET_TDSP_TERM(False)              '����
            End If

            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPUSER_ID)) = False Then
                objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'հ�ްID
                Call objTMST_USER.GET_TMST_USER(False)              '����
            End If

            '**************************************
            'ð��ٕύX����      �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               '۸އ�
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '����ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '��������
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '�[��ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '�[����
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID          'հ�ްID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'հ�ް��
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '���R����
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '���R
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '�ǉ�


            '**************************************
            '�X�V�Oð��ٵ�޼ު�Ă̏�����
            '**************************************
            If IsNull(objTMST_USER_Before) Then
                objTMST_USER_Before = New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            End If
            If IsNull(objTMST_USER_After) Then
                objTMST_USER_After = New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            End If


            '**************************************
            'ð��ٕύX�����ڍ�  �ǉ�
            '**************************************
            '===========================
            'հ�ްϽ�
            '===========================
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               '۸އ�
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '����ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_USER"                         'ð��ٖ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_ID"                                                  '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUSER_ID)                   '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUSER_ID)                     '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FPASS_WORD"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FPASS_WORD)                 '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FPASS_WORD)                   '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_NAME"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUSER_NAME)                 '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUSER_NAME)                   '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOGIN_ID"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FLOGIN_ID)                  '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FLOGIN_ID)                    '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FPASS_WORDUP_DT"                                           '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FPASS_WORDUP_DT)            '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FPASS_WORDUP_DT)              '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_ATEST"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUSER_ATEST)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUSER_ATEST)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FWARNING_COUNT"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FWARNING_COUNT)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FWARNING_COUNT)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOCK_DT"                                                  '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FLOCK_DT)                   '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FLOCK_DT)                     '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_DT"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FENTRY_DT)                  '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FENTRY_DT)                    '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_ID"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FENTRY_USER_ID)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FENTRY_USER_ID)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_NAME"                                          '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FENTRY_USER_NAME)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FENTRY_USER_NAME)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_TERM_ID"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FENTRY_TERM_ID)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FENTRY_TERM_ID)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUPDATE_DT)                 '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUPDATE_DT)                   '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_ID"                                           '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUPDATE_USER_ID)            '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUPDATE_USER_ID)              '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_NAME"                                         '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUPDATE_USER_NAME)          '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUPDATE_USER_NAME)            '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_TERM_ID"                                           '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUPDATE_TERM_ID)            '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUPDATE_TERM_ID)              '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            '===========================
            'հ�ް����Ͻ�
            '===========================
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_USER_DSP"                                         'ð��ٖ�
            Dim objTMST_USER_DSP As New TBL_TMST_USER_DSP(Owner, ObjDb, ObjDbLog)
            For ii As Integer = 1 To 5
                '(ٰ��:�ް���)

                objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_DSP_LEVEL" & ii                                  '̨���ޖ�

                objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = ""
                If IsNull(objTMST_USER_DSP_Before) = False Then
                    '(�ް�������ꍇ)

                    objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = strMukou                  '�X�V�O���
                    For jj As Integer = 0 To UBound(objTMST_USER_DSP_Before.ARYME)
                        '(ٰ��:�ް���)
                        If objTMST_USER_DSP_Before.ARYME(jj).FUSER_DSP_LEVEL = ii Then
                            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = strYuukou         '�X�V�O���
                            Exit For
                        End If
                    Next

                End If

                objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = ""
                If IsNull(objTMST_USER_DSP_After) = False Then
                    '(�ް�������ꍇ)

                    objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = strMukou                  '�X�V����
                    For jj As Integer = 0 To UBound(objTMST_USER_DSP_After.ARYME)
                        '(ٰ��:�ް���)
                        If objTMST_USER_DSP_After.ARYME(jj).FUSER_DSP_LEVEL = ii Then
                            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = strYuukou           '�X�V����
                            Exit For
                        End If
                    Next

                End If

                Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �ύX�����ڍגǉ�(TRST_STOCK)                                                             "
    '''****************************************************************************************************
    ''' <summary>
    ''' �ύX�����ڍגǉ�
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="MeSyoriID">����ID</param>
    ''' <param name="objTPRG_TRK_BUF_Before">�X�V�Oð��ٵ�޼ު��</param>
    ''' <param name="objTRST_STOCK_Before">�X�V�Oð��ٵ�޼ު��</param>
    ''' <param name="objTPRG_TRK_BUF_After">�X�V��ð��ٵ�޼ު��</param>
    ''' <param name="objTRST_STOCK_After">�X�V��ð��ٵ�޼ު��</param>
    ''' <remarks></remarks>
    '''****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TRST_STOCK(ByVal strDenbunDtl() As String _
                                               , ByVal MeSyoriID As String _
                                               , ByVal objTPRG_TRK_BUF_Before As TBL_TPRG_TRK_BUF _
                                               , ByVal objTRST_STOCK_Before As TBL_TRST_STOCK _
                                               , ByVal objTPRG_TRK_BUF_After As TBL_TPRG_TRK_BUF _
                                               , ByVal objTRST_STOCK_After As TBL_TRST_STOCK _
                                               )
        Try
            '' ''Dim intRet As RetCode
            '' ''Dim strMsg As String                    'ү����


            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPTERM_ID)) = False Then
                objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '�[��ID     ���
                Call objTDSP_TERM.GET_TDSP_TERM(False)              '����
            End If

            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPUSER_ID)) = False Then
                objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'հ�ްID
                Call objTMST_USER.GET_TMST_USER(False)              '����
            End If


            '**************************************
            'ð��ٕύX����      �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               '۸އ�
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '����ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '��������
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '�[��ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '�[����
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID          'հ�ްID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'հ�ް��
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '���R����
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '���R
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '�ǉ�


            '**************************************
            '�X�V�Oð��ٵ�޼ު�Ă̏�����
            '**************************************
            If IsNull(objTPRG_TRK_BUF_Before) Then
                objTPRG_TRK_BUF_Before = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            End If
            If IsNull(objTPRG_TRK_BUF_After) Then
                objTPRG_TRK_BUF_After = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            End If
            If IsNull(objTRST_STOCK_Before) Then
                objTRST_STOCK_Before = New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            End If
            If IsNull(objTRST_STOCK_After) Then
                objTRST_STOCK_After = New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            End If


            '**************************************
            'ð��ٕύX�����ڍ�  �ǉ�
            '**************************************
            '===========================
            '�ׯ�ݸ��ޯ̧
            '===========================
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               '۸އ�
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '����ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TPRG_TRK_BUF"                      'ð��ٖ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRK_BUF_NO"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRK_BUF_NO)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRK_BUF_NO)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRK_BUF_ARRAY"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRK_BUF_ARRAY)          '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRK_BUF_ARRAY)            '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSERCH_NO"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FSERCH_NO)               '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FSERCH_NO)                 '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRNS_ADDRESS"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRNS_ADDRESS)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRNS_ADDRESS)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISP_ADDRESS"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISP_ADDRESS)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISP_ADDRESS)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_RETU"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_RETU)               '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_RETU)                 '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_REN"                                                  '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_REN)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_REN)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_DAN"                                                  '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_DAN)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_DAN)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_EDA"                                                  '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_EDA)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_EDA)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FREMOVE_KIND"                                              '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FREMOVE_KIND)            '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FREMOVE_KIND)              '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_FORM"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_FORM)               '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_FORM)                 '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRES_KIND"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRES_KIND)               '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRES_KIND)                 '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_PALLET"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_PALLET)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_PALLET)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_FM"                                                    '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTR_FM)                  '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTR_FM)                    '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_TO"                                                    '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTR_TO)                  '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTR_TO)                    '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_IDOU"                                                  '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTR_IDOU)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTR_IDOU)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRNS_FM"                                                  '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRNS_FM)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRNS_FM)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRNS_TO"                                                  '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRNS_TO)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRNS_TO)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_BUF_FM"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_BUF_FM)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_BUF_FM)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_ARRAY_FM"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_ARRAY_FM)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_ARRAY_FM)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_BUF_TO"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_BUF_TO)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_BUF_TO)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_ARRAY_TO"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_ARRAY_TO)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_ARRAY_TO)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISP_ADDRESS_FM"                                          '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISP_ADDRESS_FM)        '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISP_ADDRESS_FM)          '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISP_ADDRESS_TO"                                          '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISP_ADDRESS_TO)        '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISP_ADDRESS_TO)          '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISPLOG_ADDRESS_FM"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISPLOG_ADDRESS_FM)     '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISPLOG_ADDRESS_FM)       '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISPLOG_ADDRESS_TO"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISPLOG_ADDRESS_TO)     '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISPLOG_ADDRESS_TO)       '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FPALLET_ID"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FPALLET_ID)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FPALLET_ID)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FBUF_IN_DT"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FBUF_IN_DT)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FBUF_IN_DT)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_BUNRUI"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_BUNRUI)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_BUNRUI)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            '===========================
            '�݌ɏ��
            '===========================
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TRST_STOCK"                      'ð��ٖ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FPALLET_ID"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FPALLET_ID)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FPALLET_ID)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOT_NO_STOCK"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FLOT_NO_STOCK)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FLOT_NO_STOCK)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI_CD"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FHINMEI_CD)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FHINMEI_CD)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOT_NO"                                                   '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FLOT_NO)                   '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FLOT_NO)                     '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FARRIVE_DT"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FARRIVE_DT)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FARRIVE_DT)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FIN_KUBUN"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FIN_KUBUN)                 '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FIN_KUBUN)                   '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSEIHIN_KUBUN"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FSEIHIN_KUBUN)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FSEIHIN_KUBUN)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FZAIKO_KUBUN"                                              '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FZAIKO_KUBUN)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FZAIKO_KUBUN)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHORYU_KUBUN"                                              '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FHORYU_KUBUN)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FHORYU_KUBUN)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FST_FM"                                                    '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FST_FM)                    '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FST_FM)                      '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_VOL"                                                   '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FTR_VOL)                   '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FTR_VOL)                     '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_RES_VOL"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FTR_RES_VOL)               '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FTR_RES_VOL)                 '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FUPDATE_DT)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FUPDATE_DT)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHASU_FLAG"                                                '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FHASU_FLAG)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FHASU_FLAG)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLABEL_ID"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FLABEL_ID)                 '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FLABEL_ID)                   '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSYUKKA_TO_CD"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FSYUKKA_TO_CD)             '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FSYUKKA_TO_CD)               '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSYUKKA_TO_NAME"                                           '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FSYUKKA_TO_NAME)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FSYUKKA_TO_NAME)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '�ǉ�


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "�@�ύX�����ڍגǉ�(TMST_REASON)                                                            "
    ''' ****************************************************************************************************
    ''' <summary>
    ''' �ύX�����ڍגǉ�
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="MeSyoriID">����ID</param>
    ''' <param name="objTMST_REASON_Before">���RϽ��X�V�Oð��ٵ�޼ު��</param>
    ''' <param name="objTMST_REASON_After">���RϽ��X�V��ð��ٵ�޼ު��</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TMST_REASON(ByVal strDenbunDtl() As String _
                                                , ByVal MeSyoriID As String _
                                                , ByVal objTMST_REASON_Before As TBL_TMST_REASON _
                                                , ByVal objTMST_REASON_After As TBL_TMST_REASON _
                                                 )
        Try

            ''Dim intRet As RetCode
            ''Dim strMsg As String                    'ү����


            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '�[��ID     ���
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '����


            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'հ�ްID
            Call objTMST_USER.GET_TMST_USER(False)              '����


            '**************************************
            'ð��ٕύX����      �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               '۸އ�
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '����ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '��������
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '�[��ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '�[����
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID          'հ�ްID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'հ�ް��
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '���R����
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '���R
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '�ǉ�


            '**************************************
            'ð��ٕύX�����ڍ�  �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               '۸އ�
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '����ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_REASON"                       'ð��ٖ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FREASON_CD"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FREASON_CD)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FREASON_CD)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FREASON_KUBUN"                                         '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FREASON_KUBUN)        '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FREASON_KUBUN)          '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FREASON"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FREASON)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FREASON)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_DT"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FENTRY_DT)            '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FENTRY_DT)              '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_ID"                                        '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FENTRY_USER_ID)       '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FENTRY_USER_ID)         '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_TERM_ID"                                        '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FENTRY_TERM_ID)       '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FENTRY_TERM_ID)         '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FUPDATE_DT)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FUPDATE_DT)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_ID"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FUPDATE_USER_ID)      '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FUPDATE_USER_ID)        '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_TERM_ID"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FUPDATE_TERM_ID)      '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FUPDATE_TERM_ID)        '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "�@�ύX�����ڍגǉ�(TDSP_PMT_USER)                                                          "
    ''' ****************************************************************************************************
    ''' <summary>
    ''' �ύX�����ڍגǉ�
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="MeSyoriID">����ID</param>
    ''' <param name="objTDSP_PMT_USER_Before">հ�ޕʋ���Ͻ��X�V�Oð��ٵ�޼ު��</param>
    ''' <param name="objTDSP_PMT_USER_After">հ�ޕʋ���Ͻ��X�V��ð��ٵ�޼ު��</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TDSP_PMT_USER(ByVal strDenbunDtl() As String _
                                                , ByVal MeSyoriID As String _
                                                , ByVal objTDSP_PMT_USER_Before As TBL_TDSP_PMT_USER _
                                                , ByVal objTDSP_PMT_USER_After As TBL_TDSP_PMT_USER _
                                                 )
        Try

            ''Dim intRet As RetCode
            ''Dim strMsg As String                    'ү����
            Dim strYuukou As String = "��"          '�L���\��
            Dim strMukou As String = "�~"           '�����\��


            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '�[��ID     ���
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '����


            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'հ�ްID
            Call objTMST_USER.GET_TMST_USER(False)              '����


            '**************************************
            'ð��ٕύX����      �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               '۸އ�
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '����ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '��������
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '�[��ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '�[����
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID          'հ�ްID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'հ�ް��
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '���R����
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '���R
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '�ǉ�


            '**************************************
            'ð��ٕύX�����ڍ�  �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               '۸އ�
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '����ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TDSP_PMT_USER"                     'ð��ٖ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_DSP_LEBEL"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FUSER_DSP_LEVEL)    '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FUSER_DSP_LEVEL)      '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISP_ID"                                              '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FDISP_ID)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FDISP_ID)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FCTRL_ID"                                              '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FCTRL_ID)           '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FCTRL_ID)             '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FOPE_FLAG"                                             '̨���ޖ�
            If TO_STRING(objTDSP_PMT_USER_Before.FOPE_FLAG) = TO_STRING(FLAG_ON) Then
                objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = strYuukou
            Else
                objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = strMukou
            End If
            If TO_STRING(objTDSP_PMT_USER_After.FOPE_FLAG) = TO_STRING(FLAG_ON) Then
                objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = strYuukou
            Else
                objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = strMukou
            End If
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_DT"                                             '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FENTRY_DT)          '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FENTRY_DT)            '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_ID"                                        '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FENTRY_USER_ID)     '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FENTRY_USER_ID)       '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_TERM_ID"                                        '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FENTRY_TERM_ID)     '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FENTRY_TERM_ID)       '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FUPDATE_DT)         '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FUPDATE_DT)           '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_ID"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FUPDATE_USER_ID)    '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FUPDATE_USER_ID)      '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_TERM_ID"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FUPDATE_TERM_ID)    '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FUPDATE_TERM_ID)      '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �ύX�����ڍגǉ�(TMST_LOT)                                                               "
    '''****************************************************************************************************
    ''' <summary>
    ''' �ύX�����ڍגǉ�
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="MeSyoriID">����ID</param>
    ''' <param name="objTMST_LOT_Before">�i��Ͻ��X�V�Oð��ٵ�޼ު��</param>
    ''' <param name="objTMST_LOT_After">�i��Ͻ��X�V��ð��ٵ�޼ު��</param>
    ''' <remarks></remarks>
    '''****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TMST_LOT(ByVal strDenbunDtl() As String _
                                              , ByVal MeSyoriID As String _
                                              , ByVal objTMST_LOT_Before As TBL_TMST_LOT _
                                              , ByVal objTMST_LOT_After As TBL_TMST_LOT _
                                              )
        Try

            'Dim intRet As RetCode
            'Dim strMsg As String                    'ү����

            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '�[��ID     ���
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '����


            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'հ�ްID
            Call objTMST_USER.GET_TMST_USER(False)              '����

            '***********************
            '�i��Ͻ��̓���
            '***********************
            Dim objTMST_ITEM_Before As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            Dim objTMST_ITEM_After As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            objTMST_ITEM_Before.FHINMEI_CD = objTMST_LOT_Before.FHINMEI_CD
            objTMST_ITEM_After.FHINMEI_CD = objTMST_LOT_After.FHINMEI_CD
            If Not (TO_STRING(objTMST_ITEM_Before.FHINMEI_CD) Is Nothing) Or TO_STRING(objTMST_ITEM_Before.FHINMEI_CD) <> "" Then
                Call objTMST_ITEM_Before.GET_TMST_ITEM(False)
            End If
            If Not (TO_STRING(objTMST_ITEM_After.FHINMEI_CD) Is Nothing) Or TO_STRING(objTMST_ITEM_After.FHINMEI_CD) <> "" Then
                Call objTMST_ITEM_After.GET_TMST_ITEM(False)
            End If


            '***********************
            '�P��Ͻ��̓���
            '***********************
            Dim objTMST_UNIT_Before As New TBL_TMST_UNIT(Owner, ObjDb, ObjDbLog)
            Dim objTMST_UNIT_After As New TBL_TMST_UNIT(Owner, ObjDb, ObjDbLog)
            objTMST_UNIT_Before.FTANI = objTMST_LOT_Before.FTANI
            objTMST_UNIT_After.FTANI = objTMST_LOT_After.FTANI
            If Not (TO_STRING(objTMST_UNIT_Before.FTANI) Is Nothing) Or TO_STRING(objTMST_UNIT_Before.FTANI) <> "" Then
                Call objTMST_UNIT_Before.GET_TMST_UNIT(False)
            End If
            If Not (TO_STRING(objTMST_UNIT_After.FTANI) Is Nothing) Or TO_STRING(objTMST_UNIT_After.FTANI) <> "" Then
                Call objTMST_UNIT_After.GET_TMST_UNIT(False)
            End If


            '**************************************
            'ð��ٕύX����      �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               '۸އ�
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '����ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '��������
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '�[��ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '�[����
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID        'հ�ްID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'հ�ް��
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '���R����
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '���R
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '�ǉ�


            '**************************************
            'ð��ٕύX�����ڍ�  �ǉ�
            '**************************************
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               '۸އ�
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '����ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_LOT"                          'ð��ٖ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI_CD"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FHINMEI_CD)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FHINMEI_CD)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FHINMEI)                '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FHINMEI)                  '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOT_NO"                                               '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FLOT_NO)                 '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FLOT_NO)                   '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�



            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FNUM_IN_CASE"                                          '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FNUM_IN_CASE)            '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FNUM_IN_CASE)              '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTANI"                                                 '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FTANI)                   '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FTANI)                     '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSHIKEN_RESULT"                                        '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FSHIKEN_RESULT)          '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FSHIKEN_RESULT)            '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSHIKEN_RECV_DT"                                       '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FSHIKEN_RECV_DT)         '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FSHIKEN_RECV_DT)           '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSHIKEN_LIMIT_DT"                                      '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FSHIKEN_LIMIT_DT)        '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FSHIKEN_LIMIT_DT)          '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�



            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FARRIVE_DT"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FARRIVE_DT)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FARRIVE_DT)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDEPART_DT"                                            '̨���ޖ�
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FDEPART_DT)              '�X�V�O���
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FDEPART_DT)                '�X�V����
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '�ǉ�



        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �ۊǏo�[�L�^�ǉ�                                                                         "

    ''' <summary>
    ''' �ۊǏo�[�L�^�ǉ�
    ''' </summary>
    ''' <param name="intTRK_BUF_NO">�ׯ�ݸ��ޯ̧��</param>
    ''' <param name="intTR_TO">����TO�ׯ�ݸ��ޯ̧��</param>
    ''' <param name="intSAGYOU_KIND">��Ǝ��</param>
    ''' <param name="strTERM_ID">�[��ID</param>
    ''' <param name="strUSER_ID">հ�ްID</param>
    ''' <param name="strREASON_CD">���R����</param>
    ''' <param name="strREASON">���R</param>
    ''' <param name="objTRST_STOCK_BASE">�݌ɏ��</param>
    ''' <remarks></remarks>
    Public Sub Add_TBL_TEVD_SUITOU(ByVal intTRK_BUF_NO As Nullable(Of Integer) _
                                 , ByVal intTR_TO As Nullable(Of Integer) _
                                 , ByVal intSAGYOU_KIND As Integer _
                                 , ByVal strTERM_ID As String _
                                 , ByVal strUSER_ID As String _
                                 , ByVal strREASON_CD As String _
                                 , ByVal strREASON As String _
                                 , ByVal objTRST_STOCK_BASE As TBL_TRST_STOCK _
                                  )
        Try
            '' ''Dim intRet As RetCode
            '' ''Dim strMsg As String                    'ү����


            '***********************
            '۸އ��̓���
            '***********************
            Dim strFLOG_NO As String                                                    '۸އ�
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog)             '���ݽ���׽
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_SUITOU                            '���ݽID
            strFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                                   'SEQ���̓���


            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            If IsNull(strTERM_ID) = False Then
                objTDSP_TERM.FTERM_ID = strTERM_ID                                      '�[��ID
                Call objTDSP_TERM.GET_TDSP_TERM(False)                                  '����
            End If


            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            If IsNull(strUSER_ID) = False Then
                objTMST_USER.FUSER_ID = strUSER_ID                                      'հ�ްID
                Call objTMST_USER.GET_TMST_USER(False)                                  '����
            End If


            '************************
            '�݌ɏ��̎擾
            '************************
            For Each objTRST_STOCK As TBL_TRST_STOCK In objTRST_STOCK_BASE.ARYME
                '**************************************
                '�i��Ͻ��̓���
                '**************************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.FHINMEI_CD                      '�i������
                Call objTMST_ITEM.GET_TMST_ITEM(False)                                  '����

                '**************************************
                'ð��ٕύX����      �ǉ�
                '**************************************
                Dim objTEVD_SUITOU As New TBL_TEVD_SUITOU(Owner, ObjDb, ObjDbLog)
                objTEVD_SUITOU.FLOG_NO = strFLOG_NO                                     '۸އ�
                objTEVD_SUITOU.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK              '�݌�ۯć�
                objTEVD_SUITOU.FRESULT_DT = Now                                         '���ѓ���
                objTEVD_SUITOU.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                     '�i������
                objTEVD_SUITOU.FHINMEI = objTMST_ITEM.FHINMEI                           '�i��
                objTEVD_SUITOU.FLOT_NO = objTRST_STOCK.FLOT_NO                          'ۯć�
                objTEVD_SUITOU.FTRK_BUF_NO = intTRK_BUF_NO                              '�ׯ�ݸ��ޯ̧��
                objTEVD_SUITOU.FTR_TO = intTR_TO                                        '����TO�ׯ�ݸ��ޯ̧��
                objTEVD_SUITOU.FTR_VOL = objTRST_STOCK.FTR_VOL                          '�����Ǘ���
                objTEVD_SUITOU.FTERM_ID = objTDSP_TERM.FTERM_ID                         '�[��ID
                objTEVD_SUITOU.FTERM_NAME = objTDSP_TERM.FTERM_NAME                     '�[����
                objTEVD_SUITOU.FUSER_ID = objTMST_USER.FUSER_ID                         'հ�ްID
                objTEVD_SUITOU.FUSER_NAME = objTMST_USER.FUSER_NAME                     'հ�ް��
                objTEVD_SUITOU.FREASON_CD = strREASON_CD                                '���R����
                objTEVD_SUITOU.FREASON = strREASON                                      '���R
                objTEVD_SUITOU.FSAGYOU_KIND = intSAGYOU_KIND                            '��Ǝ��
                Call objTEVD_SUITOU.ADD_TEVD_SUITOU()                                   '�ǉ�
            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

    '�ϊ�����
#Region "  �ׯ�ݸ��ޯ̧��       �� �o�Ɋm�F�㕽�u��         �ϊ�                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧��       �� �o�Ɋm�F�㕽�u��         �ϊ�
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">�ׯ�ݸ��ޯ̧��</param>
    ''' <returns>�o�Ɋm�F�㕽�u��</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetXNEXTFromFTRK_BUF_NO(ByVal intFTRK_BUF_NO As Integer) As Integer
        Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����
        'Dim dtmNow As Date = Now
        Dim intReturn As Integer

        Try


            '************************
            '�ׯ�ݸ��ޯ̧Ͻ�
            '************************
            Dim intXNEXT As Integer = -1
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO
            intRet = objTMST_TRK.GET_TMST_TRK(False)
            If intRet = RetCode.OK Then
                '������������************************************************************************************************************
                'CommentMate:A.Noto 2012/06/26 ��Őݒ�K�{
                ''intXNEXT = objTMST_TRK.XNEXT
                '������������************************************************************************************************************
            End If



            intReturn = intXNEXT
            Return intReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �ׯ�ݸ��ޯ̧��       �� �ڰݐݔ�ID               �ϊ�                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧��       �� �ڰݐݔ�ID               �ϊ�
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">�ׯ�ݸ��ޯ̧��</param>
    ''' <returns>�ڰݐݔ�ID</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetXEQ_ID_CRANEFromFTRK_BUF_NO(ByVal intFTRK_BUF_NO As Integer) As String
        Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����
        'Dim dtmNow As Date = Now
        Dim strReturn As String

        Try


            '************************
            '�ׯ�ݸ��ޯ̧Ͻ�
            '************************
            Dim strXEQ_ID_CRANE As String = ""
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO
            intRet = objTMST_TRK.GET_TMST_TRK(False)
            If intRet = RetCode.OK Then
                '������������************************************************************************************************************
                'CommentMate:A.Noto 2012/06/26 ��Őݒ�K�{
                ''strXEQ_ID_CRANE = objTMST_TRK.XEQ_ID_CRANE
                '������������************************************************************************************************************
            End If


            strReturn = strXEQ_ID_CRANE
            Return strReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �ׯ�ݸ��ޯ̧��       �� ���o��Ӱ�ސݔ�ID         �ϊ�                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧��       �� ���o��Ӱ�ސݔ�ID         �ϊ�
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">�ׯ�ݸ��ޯ̧��</param>
    ''' <returns>�ڰݐݔ�ID</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetXEQ_ID_MODFromFTRK_BUF_NO(ByVal intFTRK_BUF_NO As Integer) As String
        Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����
        'Dim dtmNow As Date = Now
        Dim strReturn As String

        Try


            '************************
            '�ׯ�ݸ��ޯ̧Ͻ�
            '************************
            Dim strXEQ_ID_MOD As String = ""
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO
            intRet = objTMST_TRK.GET_TMST_TRK(False)
            If intRet = RetCode.OK Then
                strXEQ_ID_MOD = objTMST_TRK.XEQ_ID_MOD
            End If

            strReturn = strXEQ_ID_MOD

            Return strReturn

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ۰�ِݔ�ID           �� �ݔ�ID(���MPLC)          �ϊ�                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' ۰�ِݔ�ID           �� �ݔ�ID(���MPLC)          �ϊ�
    ''' </summary>
    ''' <param name="strFEQ_ID">�ݔ�ID</param>
    ''' <returns>�ݔ�ID(���MPLC)</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetXEQ_ID_SendFromFEQ_ID_LOCAL(ByVal strFEQ_ID As String) As String
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����
        'Dim dtmNow As Date = Now
        Dim strReturn As String = ""

        Try


            '************************************************
            '�ݔ���           �擾
            '************************************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID          '�ݔ�ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()          '�擾


            '************************************************
            '�ݔ�ID         �擾
            '************************************************
            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2015/07/13 CW6�ǉ��Ή� ������������
            '' ''Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 1)
            '' ''    Case "M" : strReturn = FEQ_ID_JSYS0000
            '' ''    Case "Y"
            '' ''        Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 2, 2)
            '' ''            Case "01" : strReturn = FEQ_ID_JSYS0001
            '' ''            Case "02" : strReturn = FEQ_ID_JSYS0002
            '' ''            Case "03" : strReturn = FEQ_ID_JSYS0003
            '' ''            Case "04" : strReturn = FEQ_ID_JSYS0004
            '' ''            Case "05" : strReturn = FEQ_ID_JSYS0005
            '' ''            Case "06" : strReturn = FEQ_ID_JSYS0006
            '' ''        End Select
            '' ''End Select
            Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 1)
                Case "M"
                    Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 2, 2)
                        Case "FF" : strReturn = FEQ_ID_JSYS0000
                        Case "FE" : strReturn = FEQ_ID_JSYS0007
                    End Select
                Case "Y"
                    Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 2, 2)
                        Case "01" : strReturn = FEQ_ID_JSYS0001
                        Case "02" : strReturn = FEQ_ID_JSYS0002
                        Case "03" : strReturn = FEQ_ID_JSYS0003
                        Case "04" : strReturn = FEQ_ID_JSYS0004
                        Case "05" : strReturn = FEQ_ID_JSYS0005
                        Case "06" : strReturn = FEQ_ID_JSYS0006
                    End Select
            End Select
            'JobMate:S.Ouchi 2015/07/13 CW6�ǉ��Ή� ������������
            '������������************************************************************************************************************


            Return strReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ��(�ý�)             �� ��(PLC)                  �ϊ�                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' ��(�ý�)         �� ��(PLC)                      �ϊ�
    ''' </summary>
    ''' <param name="intFRAC_RETU">��(�ý�)</param>
    ''' <returns>��(PLC)</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetPLCRetuFromFRAC_RETU(ByVal intFRAC_RETU As Integer) As Integer
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����
        'Dim dtmNow As Date = Now
        Dim strReturn As String = ""


        '************************************************
        '�ݔ���           �擾
        '************************************************
        If (intFRAC_RETU Mod 2) = 0 Then
            strReturn = 2
        Else
            strReturn = 1
        End If


        Return strReturn
    End Function
#End Region
#Region "  ��(PLC)              �� ��(�ý�)                 �ϊ�                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' ��(PLC)              �� ��(�ý�)                 �ϊ�
    ''' </summary>
    ''' <param name="intPLCRetu">��(PLC)</param>
    ''' <param name="intGouki">���@</param>
    ''' <param name="blnErr">�z��O�̒l�̏ꍇ�ʹװ�Ƃ��邩�ۂ�</param>
    ''' <returns>��(�ý�)</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetFRAC_RETUFromPLCRetu(ByVal intPLCRetu As Integer _
                                          , ByVal intGouki As Integer _
                                          , Optional ByVal blnErr As Boolean = True _
                                          ) As Integer
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����
        'Dim dtmNow As Date = Now
        Dim intReturn As Integer = -1


        '************************************************
        '�ݔ���           �擾
        '************************************************
        Select Case intPLCRetu
            Case 2 : intReturn = (intGouki * 2)
            Case 1 : intReturn = (intGouki * 2) - 1
            Case Else : If blnErr = True Then Throw New Exception("PLC�����擾���ɴװ�����B")
        End Select


        Return intReturn
    End Function
#End Region
#Region "  �װ����(PLC)         �� �װ����(MDD)             �ϊ�                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' �װ����(PLC)         �� �װ����(MDD)             �ϊ�
    ''' </summary>
    ''' <param name="strPLCErrCode">�װ����(PLC)</param>
    ''' <returns>�װ����(MDD)</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetMDDErrCodeFromPLCErrCode(ByVal strPLCErrCode As String) As String
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����
        'Dim dtmNow As Date = Now
        Dim strReturn As String = ""


        '************************************************
        '�l�ϊ�
        '************************************************
        strReturn = Change10To16(strPLCErrCode, 4)
        strReturn = Right(strReturn, 2)


        Return strReturn
    End Function
#End Region


    '�ׯ�ݸޗ\�����
#Region "  �ׯ�ݸޗ\�����  (������)                                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' �������ׯ�ݸޗ\�����
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">�������ׯ�ݸ�</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub ClearFromReserve(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF)
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        '************************************************
        '�\�񂳂�Ă����ׯ�ݸނ̎擾
        '************************************************
        Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM          '�ׯ�ݸ��ޯ̧��
        objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM     '�ׯ�ݸ��ޯ̧�z��
        objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF()                                       '����


        If objTPRG_TRK_BUF_FM.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FPALLET_ID Then
            objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()   '���
        End If


    End Sub
#End Region

    '���u���݌ɍ폜
#Region "  ���u���݌ɍ폜                                                                           "
    '''**********************************************************************************************
    ''' <summary>
    ''' ���u���݌ɍ폜
    ''' </summary>
    ''' <param name="strFPALLET_ID">��گ�ID</param>
    ''' <param name="intFINOUT_STS">IN/OUT</param>
    ''' <param name="intFSAGYOU_KIND">��Ǝ��</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DeleteHiraoki(ByVal strFPALLET_ID As String _
                           , ByVal intFINOUT_STS As Integer _
                           , ByVal intFSAGYOU_KIND As Integer _
                           )
        Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        '************************
        '�ׯ�ݸ��ޯ̧�̓���
        '************************
        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)         '�ׯ�ݸ��ޯ̧�׽
        objTPRG_TRK_BUF.FPALLET_ID = strFPALLET_ID                                  '��گ�ID
        objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                                          '����


        '************************
        '�݌Ɉ������̍폜
        '************************
        Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
        objTSTS_HIKIATE.FPALLET_ID = strFPALLET_ID                          '��گ�ID
        objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()                        '�폜


        '************************
        '�݌ɍ폜
        '************************
        Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '�݌ɍ폜�׽
        objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             '�ׯ�ݸ��ޯ̧
        objSVR_100102.FPALLET_ID = strFPALLET_ID                    '��گ�ID
        objSVR_100102.FINOUT_STS = intFINOUT_STS                    'INOUT
        objSVR_100102.FSAGYOU_KIND = intFSAGYOU_KIND                '��Ǝ��
        objSVR_100102.STOCK_DELETE()                                '�폜


        '************************
        '�݌ɏ��̓���
        '************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '�݌ɏ��׽
        objTRST_STOCK.FPALLET_ID = strFPALLET_ID                        '��گ�ID
        intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)             '����
        If intRet = RetCode.NotFound Then
            '(������Ȃ��ꍇ)

            '************************
            '�����ޯ̧�̉��
            '************************
            Dim objTPRG_TRK_BUF_CLEAR As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '�݌ɍ폜�׽
            objTPRG_TRK_BUF_CLEAR.FRSV_PALLET = strFPALLET_ID                           '��گ�ID
            objTPRG_TRK_BUF_CLEAR.CLEAR_TPRG_TRK_BUF_RSV_PC()                           '���

        End If


    End Sub
#End Region

    '��������
#Region "  �o�ɐݒ�                     (SVR_201601)                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' ���ɐݒ�
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO_TO">�ׯ�ݸ��ޯ̧��(TO)</param>
    ''' <param name="strFPALLET_ID_OYA">��گ�ID(�e)</param>
    ''' <param name="strFPALLET_ID_KO">��گ�ID(�q)</param>
    ''' <param name="intFSAGYOU_KIND">��Ǝ��</param>
    ''' <param name="strFTERM_ID">�[��ID</param>
    ''' <param name="strFUSER_ID">հ�ްID</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SVR_201601_Process(ByVal intFTRK_BUF_NO_TO As Integer _
                                     , ByVal strFPALLET_ID_OYA As String _
                                     , ByVal strFPALLET_ID_KO As String _
                                     , ByVal intFSAGYOU_KIND As Integer _
                                     , ByVal strFTERM_ID As String _
                                     , ByVal strFUSER_ID As String _
                                     ) As RetCode


        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        Try



            '************************************************************************************************************
            '************************************************************************************************************
            '�e�̏o��
            '************************************************************************************************************
            '************************************************************************************************************
            '************************************
            '�o���ׯ�ݸޒ�`�׽(��گ�ID�w��)
            '************************************
            Dim objSVR_100501_OYA As New SVR_100501(Owner, ObjDb, ObjDbLog)
            objSVR_100501_OYA.FTRK_BUF_NO_TO = intFTRK_BUF_NO_TO                            '�ׯ�ݸ��ޯ̧��(�o�ɐ��ׯ�ݸ�)
            objSVR_100501_OYA.FPALLET_ID = strFPALLET_ID_OYA                                '��گ�ID
            objSVR_100501_OYA.FSAGYOU_KIND = intFSAGYOU_KIND                                '��Ǝ��
            objSVR_100501_OYA.FTERM_ID = strFTERM_ID                                        '�[��ID
            objSVR_100501_OYA.FUSER_ID = strFUSER_ID                                        'հ�ްID
            objSVR_100501_OYA.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '��`


            ''************************************
            ''�����w��QUE        �X�V
            ''************************************
            'Dim objTPLN_CARRY_QUE_OYA As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
            'objTPLN_CARRY_QUE_OYA.FPALLET_ID = strFPALLET_ID_OYA    '��گ�ID
            'objTPLN_CARRY_QUE_OYA.GET_TPLN_CARRY_QUE()              '�擾
            'objTPLN_CARRY_QUE_OYA.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA      '�e�q�敪
            'objTPLN_CARRY_QUE_OYA.XPALLET_ID_AITE = strFPALLET_ID_KO    '������گ�ID
            'objTPLN_CARRY_QUE_OYA.UPDATE_TPLN_CARRY_QUE()               '�X�V


            '************************************************************************************************************
            '************************************************************************************************************
            '�q�̏o��
            '************************************************************************************************************
            '************************************************************************************************************
            If IsNotNull(strFPALLET_ID_KO) Then
                '(�߱�����̏ꍇ)


                '************************************
                '�o���ׯ�ݸޒ�`�׽(��گ�ID�w��)
                '************************************
                Dim objSVR_100501_KO As New SVR_100501(Owner, ObjDb, ObjDbLog)
                objSVR_100501_KO.FTRK_BUF_NO_TO = intFTRK_BUF_NO_TO                            '�ׯ�ݸ��ޯ̧��(�o�ɐ��ׯ�ݸ�)
                objSVR_100501_KO.FPALLET_ID = strFPALLET_ID_KO                                 '��گ�ID
                objSVR_100501_KO.FSAGYOU_KIND = intFSAGYOU_KIND                                '��Ǝ��
                objSVR_100501_KO.FTERM_ID = strFTERM_ID                                        '�[��ID
                objSVR_100501_KO.FUSER_ID = strFUSER_ID                                        'հ�ްID
                objSVR_100501_KO.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '��`


                '************************************
                '�����w��QUE        �X�V
                '************************************
                Dim objTPLN_CARRY_QUE_KO As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                objTPLN_CARRY_QUE_KO.FPALLET_ID = strFPALLET_ID_KO     '��گ�ID
                objTPLN_CARRY_QUE_KO.GET_TPLN_CARRY_QUE()              '�擾
                objTPLN_CARRY_QUE_KO.XOYAKO_KUBUN = XOYAKO_KUBUN_JKO       '�e�q�敪
                objTPLN_CARRY_QUE_KO.XPALLET_ID_AITE = strFPALLET_ID_OYA   '������گ�ID
                objTPLN_CARRY_QUE_KO.UPDATE_TPLN_CARRY_QUE()               '�X�V


            End If




            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ���ɐݒ�                     (SVR_400001)ST�Ɉ�x�ׯ�ݸނ������쐬�����ް�ޮ�            "
    '''**********************************************************************************************
    ''' <summary>
    ''' Ҳݏ���
    ''' </summary>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SVR_400001_Process(ByVal strDenbunDtl() As String _
                                     , ByVal strMSG_RECV As String _
                                     , ByRef strMSG_SEND As String _
                                     ) _
                                     As RetCode
        Dim strDenbunInfo As String = ""      '�d�����Ұ�۸ޗp������
        Dim intRet As RetCode                 '�߂�l
        Dim strMsg As String                  'ү����
        Try
            Dim DSPTERM_ID As Integer = 0             '�[��ID
            Dim DSPUSER_ID As Integer = 1             'հ�ްID
            Dim DSPREASON As Integer = 2              '���R
            Dim DSPST_FM As Integer = 3               '������ST�ׯ�ݸ��ޯ̧��
            Dim DSPST_TO As Integer = 4               '������ST�ׯ�ݸ��ޯ̧��
            Dim DSPPALLET_ID As Integer = 5           '��گ�ID
            Dim DSPLOT_NO_STOCK As Integer = 6        '�݌�ۯć�
            Dim DSPSAGYOU_KIND As Integer = 7         '��Ǝ��
            Dim DSPHINMEI_CD As Integer = 8           '�i������
            Dim DSPTR_VOL As Integer = 9              '�����Ǘ���
            Dim XDSPIN_KIND As Integer = 10           '���Ɏ��
            Dim XDSPIN_SITEI As Integer = 11          '���Ɏw��
            Dim DSPARRIVE_DT As Integer = 12          '�݌ɔ�������
            Dim XDSPPROD_LINE As Integer = 13         '���Yײ݇�
            Dim XDSPMAKER_CD As Integer = 14          'Ұ�����
            Dim XDSPKENSA_KUBUN As Integer = 15       '�����敪
            Dim DSPHORYU_KUBUN As Integer = 16        '�ۗ��敪
            Dim DSPIN_KUBUN As Integer = 17           '���ɋ敪
            Dim XDSPKENPIN_KUBUN As Integer = 18      '���i�敪
            Dim XDSPPALLET_ID_KO As Integer = 19      '��گ�ID(�q)
            Dim XDSPTR_VOL_KO As Integer = 20         '�����Ǘ���(�q)
            Dim XDSPTANA_BLOCK As Integer = 21        '�I��ۯ�
            Dim XDSPST_TO_ARRAY01 As Integer = 22     '�������ׯ�ݸ��ޯ̧�z��01
            Dim XDSPST_TO_ARRAY02 As Integer = 23     '�������ׯ�ݸ��ޯ̧�z��02


            '************************
            '�����ݒ�
            '************************
            Dim dtmNow As Date = Now
            Dim intFSAGYOU_KIND As Integer = strDenbunDtl(DSPSAGYOU_KIND)   '��Ǝ��
            Dim blnPair As Boolean                                          '�߱�׸�
            Dim blnHasuBlock As Boolean = False                             '�[���׸�
            Dim dtmFARRIVE_DT As Date = IIf(IsNotNull(strDenbunDtl(DSPARRIVE_DT)), TO_DATE(strDenbunDtl(DSPARRIVE_DT)), Now)    '�݌ɔ�������
            If strDenbunDtl(XDSPIN_KIND) = XDSPIN_KIND_PAIR Then blnPair = True
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)


            '*****************************************************
            'ۯć��擾
            '*****************************************************
            Dim strFLOT_NO As String = ""               'ۯć�
            If IsNull(strDenbunDtl(DSPARRIVE_DT)) Then
                '(�݌ɔ����������ݒ肳��Ă��Ȃ������ꍇ)
                Call GetFLOT_NO(strFLOT_NO, strDenbunDtl(XDSPPROD_LINE))
            Else
                '(�݌ɔ����������ݒ肳��Ă����ꍇ)
                strFLOT_NO = strDenbunDtl(XDSPPROD_LINE) & Format(TO_DATE(strDenbunDtl(DSPARRIVE_DT)), "yyyyMMdd")
            End If


            '************************************************************************************************
            '************************************************************************************************
            '1PL�ڍ݌ɍ쐬
            '************************************************************************************************
            '************************************************************************************************
            Dim strFPALLET_ID_OYA As String = ""
            Dim strFHINMEI_CD As String = ""
            '************************************************
            '�ׯ�ݸ��ޯ̧(������)(�e)       �擾
            '************************************************
            Dim objTPRG_TRK_BUF_TO_OYA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_TO_OYA.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)         '�ׯ�ݸ��ޯ̧��
            intRet = objTPRG_TRK_BUF_TO_OYA.GET_TPRG_TRK_BUF_AKI_HIRA()         '�擾
            If intRet <> RetCode.OK Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_TO_OYA.FTRK_BUF_NO) & "]"
                Throw New UserException(strMsg)
            End If


            If IsNull(strDenbunDtl(DSPPALLET_ID)) Then
                '(�V�K���ɂ̏ꍇ)


                '************************
                '�݌ɏ��̓o�^(�e)
                '************************
                Dim objTRST_STOCK_ADD_OYA As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '�݌ɏ��ð��ٸ׽
                Call TRST_STOCKAddProcess(objTRST_STOCK_ADD_OYA _
                                        , strDenbunDtl(DSPHINMEI_CD) _
                                        , strFLOT_NO _
                                        , dtmFARRIVE_DT _
                                        , TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN)) _
                                        , TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN)) _
                                        , TO_DECIMAL(strDenbunDtl(DSPTR_VOL)) _
                                        , FTR_RES_VOL_SKOTEI _
                                        , dtmNow _
                                        , strDenbunDtl(XDSPPROD_LINE) _
                                        , strDenbunDtl(XDSPKENSA_KUBUN) _
                                        , strDenbunDtl(XDSPKENPIN_KUBUN) _
                                        , strDenbunDtl(XDSPMAKER_CD) _
                                        , objTPRG_TRK_BUF_TO_OYA.FTRK_BUF_NO _
                                        )


                '************************
                '�݌ɓo�^(�e)
                '************************
                Dim objSYS_100101_OYA As New SVR_100101(Owner, ObjDb, ObjDbLog)         '�݌ɍ쐬�׽
                objSYS_100101_OYA.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_TO_OYA              '�ׯ�ݸ��ޯ̧
                objSYS_100101_OYA.FPALLET_ID = objTRST_STOCK_ADD_OYA.FPALLET_ID         '��گ�ID
                objSYS_100101_OYA.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(���ɐݒ�)
                objSYS_100101_OYA.FSAGYOU_KIND = intFSAGYOU_KIND                        '��Ǝ��(���ѕێ�)
                objSYS_100101_OYA.STOCK_ADD()                                           '�o�^


                '************************
                '�i��Ͻ�        �擾
                '************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objTRST_STOCK_ADD_OYA.FHINMEI_CD      '�i�ں���
                objTMST_ITEM.GET_TMST_ITEM()                                    '�擾


                '************************
                '�ް�               �ݒ�
                '************************
                strFPALLET_ID_OYA = objSYS_100101_OYA.FPALLET_ID    '��گ�ID
                strFHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)          '�i�ں���
                If objTMST_ITEM.FNUM_IN_PALLET <> objTRST_STOCK_ADD_OYA.FTR_VOL Then blnHasuBlock = True


            Else
                '(�q�֓��ɂ̏ꍇ)


                '************************************************
                '�݌ɏ��           �X�V
                '************************************************
                Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)   '��گ�ID
                objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)               '�擾
                For ii As Integer = 0 To UBound(objTRST_STOCK.ARYME)
                    '(ٰ��:�݌�ۯć���)
                    objTRST_STOCK.ARYME(ii).FIN_KUBUN = strDenbunDtl(DSPIN_KUBUN)               '���ɋ敪
                    objTRST_STOCK.ARYME(ii).XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)      '���i�敪
                    objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now                                    '�X�V����
                    objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK_ALL()                             '�X�V
                Next


                '************************************************
                '�ׯ�ݸ��ޯ̧(���u)         �擾
                '************************************************
                Dim objTPRG_TRK_BUF_HIRA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_HIRA.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)    '��گ�ID
                objTPRG_TRK_BUF_HIRA.GET_TPRG_TRK_BUF()                         '�擾


                '************************
                '�݌Ɉړ�
                '************************
                Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)         '�݌Ɉړ��׽
                objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_HIRA             '�ׯ�ݸ��ޯ̧
                objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO_OYA           '�ׯ�ݸ��ޯ̧
                objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_HIRA.FPALLET_ID          '��گ�ID
                objSVR_100103.FINOUT_STS = FINOUT_STS_SKURAGAE_UKETUKE              'INOUT
                objSVR_100103.FSAGYOU_KIND = strDenbunDtl(DSPSAGYOU_KIND)           '��Ǝ��
                objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                            '�������ر�׸�
                objSVR_100103.STOCK_TRNS()                                          '�ړ�


                '************************
                '�i��Ͻ�        �擾
                '************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD     '�i�ں���
                objTMST_ITEM.GET_TMST_ITEM()                                    '�擾


                '************************
                '�ް�               �ݒ�
                '************************
                strFPALLET_ID_OYA = strDenbunDtl(DSPPALLET_ID)      '��گ�ID
                strFHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD   '�i�ں���
                If objTMST_ITEM.FNUM_IN_PALLET <> objTRST_STOCK.ARYME(0).FTR_VOL Then blnHasuBlock = True


            End If


            '************************************************************************************************
            '************************************************************************************************
            '2PL�ڍ݌ɍ쐬
            '************************************************************************************************
            '************************************************************************************************
            Dim objTPRG_TRK_BUF_TO_KOO As TBL_TPRG_TRK_BUF = Nothing
            Dim strFPALLET_ID_KOO As String = ""
            If blnPair = True Then
                '(�߱�����̏ꍇ)


                '************************************************
                '�ׯ�ݸ��ޯ̧(������)(�q)       �擾
                '************************************************
                objTPRG_TRK_BUF_TO_KOO = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_TO_KOO.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)         '�ׯ�ݸ��ޯ̧��
                intRet = objTPRG_TRK_BUF_TO_KOO.GET_TPRG_TRK_BUF_AKI_HIRA()         '�擾
                If intRet <> RetCode.OK Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_TO_KOO.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
                End If


                If IsNull(strDenbunDtl(XDSPPALLET_ID_KO)) Then
                    '(�V�K���ɂ̏ꍇ)


                    '************************
                    '�݌ɏ��̓o�^(�q)
                    '************************
                    Dim objTRST_STOCK_ADD_KOO As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    Call TRST_STOCKAddProcess(objTRST_STOCK_ADD_KOO _
                                            , strDenbunDtl(DSPHINMEI_CD) _
                                            , strFLOT_NO _
                                            , dtmFARRIVE_DT _
                                            , TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN)) _
                                            , TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN)) _
                                            , TO_DECIMAL(strDenbunDtl(XDSPTR_VOL_KO)) _
                                            , FTR_RES_VOL_SKOTEI _
                                            , dtmNow _
                                            , strDenbunDtl(XDSPPROD_LINE) _
                                            , strDenbunDtl(XDSPKENSA_KUBUN) _
                                            , strDenbunDtl(XDSPKENPIN_KUBUN) _
                                            , strDenbunDtl(XDSPMAKER_CD) _
                                            , objTPRG_TRK_BUF_TO_KOO.FTRK_BUF_NO _
                                            )


                    '************************
                    '�݌ɓo�^(�q)
                    '************************
                    Dim objSYS_100101_KOO As New SVR_100101(Owner, ObjDb, ObjDbLog)
                    objSYS_100101_KOO.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_TO_KOO              '�ׯ�ݸ��ޯ̧
                    objSYS_100101_KOO.FPALLET_ID = objTRST_STOCK_ADD_KOO.FPALLET_ID         '��گ�ID
                    objSYS_100101_KOO.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(���ɐݒ�)
                    objSYS_100101_KOO.FSAGYOU_KIND = intFSAGYOU_KIND                        '��Ǝ��(���ѕێ�)
                    objSYS_100101_KOO.STOCK_ADD()                                           '�o�^


                    '************************
                    '�i��Ͻ�        �擾
                    '************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.FHINMEI_CD = objTRST_STOCK_ADD_KOO.FHINMEI_CD  '�i�ں���
                    objTMST_ITEM.GET_TMST_ITEM()                                '�擾


                    '************************
                    '��گ�ID            �ݒ�
                    '************************
                    strFPALLET_ID_KOO = objSYS_100101_KOO.FPALLET_ID
                    If objTMST_ITEM.FNUM_IN_PALLET <> objTRST_STOCK_ADD_KOO.FTR_VOL Then blnHasuBlock = True


                Else
                    '(�q�֓��ɂ̏ꍇ)


                    '************************************************
                    '�݌ɏ��           �X�V
                    '************************************************
                    Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    objTRST_STOCK.FPALLET_ID = strDenbunDtl(XDSPPALLET_ID_KO)   '��گ�ID
                    objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                   '�擾
                    For ii As Integer = 0 To UBound(objTRST_STOCK.ARYME)
                        '(ٰ��:�݌�ۯć���)
                        objTRST_STOCK.ARYME(ii).FIN_KUBUN = strDenbunDtl(DSPIN_KUBUN)               '���ɋ敪

                        '������������************************************************************************************************************
                        'JobMate:S.Ouchi 2013/11/14 �q�֓��� �����敪�����i�敪�̕s��C��
                        ''''objTRST_STOCK.ARYME(ii).XKENSA_KUBUN = strDenbunDtl(XDSPKENSA_KUBUN)        '���i�敪
                        objTRST_STOCK.ARYME(ii).XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)      '���i�敪
                        'JobMate:S.Ouchi 2013/11/14 �q�֓��� �����敪�����i�敪�̕s��C��
                        '������������************************************************************************************************************

                        objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now                                    '�X�V����
                        objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK_ALL()                             '�X�V
                    Next


                    '************************************************
                    '�ׯ�ݸ��ޯ̧(���u)         �擾
                    '************************************************
                    Dim objTPRG_TRK_BUF_HIRA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_HIRA.FPALLET_ID = strDenbunDtl(XDSPPALLET_ID_KO)    '��گ�ID
                    objTPRG_TRK_BUF_HIRA.GET_TPRG_TRK_BUF()                             '�擾


                    '************************
                    '�݌Ɉړ�
                    '************************
                    Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)         '�݌Ɉړ��׽
                    objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_HIRA             '�ׯ�ݸ��ޯ̧
                    objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO_KOO           '�ׯ�ݸ��ޯ̧
                    objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_HIRA.FPALLET_ID          '��گ�ID
                    objSVR_100103.FINOUT_STS = FINOUT_STS_SKURAGAE_UKETUKE              'INOUT
                    objSVR_100103.FSAGYOU_KIND = strDenbunDtl(DSPSAGYOU_KIND)           '��Ǝ��
                    objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                            '�������ر�׸�
                    objSVR_100103.STOCK_TRNS()                                          '�ړ�


                    '************************
                    '�i��Ͻ�        �擾
                    '************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD     '�i�ں���
                    objTMST_ITEM.GET_TMST_ITEM()                                    '�擾


                    '************************
                    '��گ�ID            �ݒ�
                    '************************
                    strFPALLET_ID_KOO = strDenbunDtl(XDSPPALLET_ID_KO)
                    If objTMST_ITEM.FNUM_IN_PALLET <> objTRST_STOCK.ARYME(0).FTR_VOL Then blnHasuBlock = True


                End If


            End If


            '************************************************************************************************
            '************************************************************************************************
            '��I��������
            '************************************************************************************************
            '************************************************************************************************
            Dim objTPRG_TRK_BUF_ASRS_OYA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            Dim objTPRG_TRK_BUF_ASRS_KOO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            If strDenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9000 Then
                '(�ʏ���ɂ̏ꍇ)


                '**********************************************
                '��I��������
                '**********************************************
                Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '��I�����׽
                intRet = AkitanaHikiate(objSYS_100201 _
                                      , objTPRG_TRK_BUF_ASRS_OYA _
                                      , objTPRG_TRK_BUF_ASRS_KOO _
                                      , objTPRG_TRK_BUF_TO_OYA _
                                      , strFPALLET_ID_OYA _
                                      , strFHINMEI_CD _
                                      , FTRK_BUF_NO_J9000 _
                                      , True _
                                      , blnPair _
                                      , IIf(IsNull(strDenbunDtl(XDSPTANA_BLOCK)), Nothing, TO_INTEGER(strDenbunDtl(XDSPTANA_BLOCK))) _
                                      , blnHasuBlock _
                                      )
                If intRet = RetCode.NotFound Then
                    '    '(������Ȃ��ꍇ)
                    Call AddToMsgLog(Now, FMSG_ID_S0102, objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS, "�i������:" & strFHINMEI_CD)
                    strMsg = ERRMSG_NOTFOUND_AKI
                    Throw New UserException(strMsg, False)
                    'Return RetCode.RollBack
                End If


            Else
                '(�ً}���ɂ̏ꍇ)


                '**********************************************
                '�ׯ�ݸ��ޯ̧Ͻ�        �擾
                '**********************************************
                Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                objTMST_TRK.XTRK_BUF_NO_CONV = strDenbunDtl(DSPST_FM)   '���ޱ�֘A�t��
                objTMST_TRK.GET_TMST_TRK()                              '�擾


                '**********************************************
                '���Y���ɐݒ���       �擾
                '**********************************************
                Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
                objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTMST_TRK.FTRK_BUF_NO    '�ׯ�ݸ��ޯ̧��
                objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN()                    '�擾


                '**********************************************
                '�o�ɐ�ST�̐ݒ�
                '**********************************************
                '�e
                objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO = objXSTS_PRODUCT_IN.XKINKYU_BUF_TO        '�ޯ̧��
                objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_ARRAY = 1                                     '�z��
                objTPRG_TRK_BUF_ASRS_OYA.GET_TPRG_TRK_BUF()                                     '����
                '�q
                If blnPair = True Then
                    objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_NO = objXSTS_PRODUCT_IN.XKINKYU_BUF_TO    '�ޯ̧��
                    objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_ARRAY = 1                                 '�z��
                    objTPRG_TRK_BUF_ASRS_KOO.GET_TPRG_TRK_BUF()                                 '����
                End If


            End If


            '************************************************************************************************
            '************************************************************************************************
            '1PL�ڐݒ�
            '************************************************************************************************
            '************************************************************************************************
            '******************************************
            '�ׯ�ݸ��ޯ̧(ST)(�e)�̍X�V
            '******************************************
            objTPRG_TRK_BUF_TO_OYA.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO               'TO�����ׯ�ݸއ�
            objTPRG_TRK_BUF_TO_OYA.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_ARRAY          'TO�����z��
            objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS          'FM�\�L�p���ڽ
            objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS_OYA.FDISP_ADDRESS        'TO�\�L�p���ڽ
            objTPRG_TRK_BUF_TO_OYA.FBUF_IN_DT = Now                                                 '�ޯ̧������
            objTPRG_TRK_BUF_TO_OYA.UPDATE_TPRG_TRK_BUF()                                            '�X�V


            '************************
            '�q�ɂ̍X�V(�e)
            '************************
            If strDenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9000 Then
                objTPRG_TRK_BUF_ASRS_OYA.FRSV_PALLET = objTPRG_TRK_BUF_TO_OYA.FPALLET_ID    '������PC��
                objTPRG_TRK_BUF_ASRS_OYA.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '�������
                objTPRG_TRK_BUF_ASRS_OYA.FBUF_IN_DT = Now                                   '�ޯ̧������
                objTPRG_TRK_BUF_ASRS_OYA.UPDATE_TPRG_TRK_BUF()                              '�X�V
            End If


            '************************
            '�݌ɏ��(�e)       �擾
            '************************
            Dim objTRST_STOCK_GET_OYA As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            objTRST_STOCK_GET_OYA.FPALLET_ID = strFPALLET_ID_OYA                '��گ�ID
            objTRST_STOCK_GET_OYA.GET_TRST_STOCK_KONSAI(True)                   '�擾


            '************************************************
            '�݌ɏ��(�e)       �����ׯ�ݸޏ��̍X�V
            '************************************************
            Call UpdateTRST_STOCK_InInfor(objTPRG_TRK_BUF_ASRS_OYA, objTRST_STOCK_GET_OYA)


            '************************
            '�݌Ɉ������(�e)�̓o�^
            '************************
            Dim objTSTS_HIKIATE_OYA As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)             '�݌Ɉ������׽
            objTSTS_HIKIATE_OYA.FSAGYOU_KIND = intFSAGYOU_KIND                                  '��Ǝ��
            objTSTS_HIKIATE_OYA.FPLAN_KEY = FPLAN_KEY_SKOTEI                                    '�v�淰
            objTSTS_HIKIATE_OYA.FPALLET_ID = objTRST_STOCK_GET_OYA.ARYME(0).FPALLET_ID          '��گ�ID
            objTSTS_HIKIATE_OYA.FLOT_NO_STOCK = objTRST_STOCK_GET_OYA.ARYME(0).FLOT_NO_STOCK    '�݌�ۯć�
            objTSTS_HIKIATE_OYA.FTR_VOL = objTRST_STOCK_GET_OYA.ARYME(0).FTR_VOL                '�����Ǘ���
            objTSTS_HIKIATE_OYA.FTERM_ID = DEFAULT_STRING                                       '�[��ID
            objTSTS_HIKIATE_OYA.FUSER_ID = DEFAULT_STRING                                       'հ�ްID
            objTSTS_HIKIATE_OYA.FWAIT_REASON = FWAIT_REASON_JIN_YOUKYUU                         '�w�����M�҂����R
            objTSTS_HIKIATE_OYA.FTRNS_START_DT = DEFAULT_DATE                                   '�����J�n����
            objTSTS_HIKIATE_OYA.FTRNS_END_DT = DEFAULT_DATE                                     '������������
            objTSTS_HIKIATE_OYA.FUPDATE_DT = Now                                                '�X�V����
            objTSTS_HIKIATE_OYA.ADD_TSTS_HIKIATE()                                              '�o�^


            '************************************************************************************************
            '************************************************************************************************
            '2PL�ڐݒ�
            '************************************************************************************************
            '************************************************************************************************
            If blnPair = True Then
                '(�߱�����̏ꍇ)


                '******************************************
                '�ׯ�ݸ��ޯ̧(ST)(�q)�̍X�V
                '******************************************
                objTPRG_TRK_BUF_TO_KOO.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_NO               'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_TO_KOO.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_ARRAY          'TO�����z��
                objTPRG_TRK_BUF_TO_KOO.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_TO_KOO.FDISP_ADDRESS          'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_TO_KOO.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS_KOO.FDISP_ADDRESS        'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_TO_KOO.FBUF_IN_DT = Now                                                 '�ޯ̧������
                objTPRG_TRK_BUF_TO_KOO.UPDATE_TPRG_TRK_BUF()                                            '�X�V


                '************************
                '�q�ɂ̍X�V(�q)
                '************************
                If strDenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9000 Then
                    objTPRG_TRK_BUF_ASRS_KOO.FRSV_PALLET = objTPRG_TRK_BUF_TO_KOO.FPALLET_ID    '������PC��
                    objTPRG_TRK_BUF_ASRS_KOO.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '�������
                    objTPRG_TRK_BUF_ASRS_KOO.FBUF_IN_DT = Now                                   '�ޯ̧������
                    objTPRG_TRK_BUF_ASRS_KOO.UPDATE_TPRG_TRK_BUF()                              '�X�V
                End If


                '************************
                '�݌ɏ��(�q)       �擾
                '************************
                Dim objTRST_STOCK_GET_KOO As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                objTRST_STOCK_GET_KOO.FPALLET_ID = strFPALLET_ID_KOO                '��گ�ID
                objTRST_STOCK_GET_KOO.GET_TRST_STOCK_KONSAI(True)                   '�擾


                '************************************************
                '�݌ɏ��(�q)       �����ׯ�ݸޏ��̍X�V
                '************************************************
                Call UpdateTRST_STOCK_InInfor(objTPRG_TRK_BUF_ASRS_KOO, objTRST_STOCK_GET_KOO)


                '************************
                '�݌Ɉ������(�q)�̓o�^
                '************************
                Dim objTSTS_HIKIATE_KOO As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)             '�݌Ɉ������׽
                objTSTS_HIKIATE_KOO.FSAGYOU_KIND = intFSAGYOU_KIND                                  '��Ǝ��
                objTSTS_HIKIATE_KOO.FPLAN_KEY = FPLAN_KEY_SKOTEI                                    '�v�淰
                objTSTS_HIKIATE_KOO.FPALLET_ID = objTRST_STOCK_GET_KOO.ARYME(0).FPALLET_ID          '��گ�ID
                objTSTS_HIKIATE_KOO.FLOT_NO_STOCK = objTRST_STOCK_GET_KOO.ARYME(0).FLOT_NO_STOCK    '�݌�ۯć�
                objTSTS_HIKIATE_KOO.FTR_VOL = objTRST_STOCK_GET_KOO.ARYME(0).FTR_VOL                '�����Ǘ���
                objTSTS_HIKIATE_KOO.FTERM_ID = DEFAULT_STRING                                       '�[��ID
                objTSTS_HIKIATE_KOO.FUSER_ID = DEFAULT_STRING                                       'հ�ްID
                objTSTS_HIKIATE_KOO.FWAIT_REASON = FWAIT_REASON_JIN_YOUKYUU                         '�w�����M�҂����R
                objTSTS_HIKIATE_KOO.FTRNS_START_DT = DEFAULT_DATE                                   '�����J�n����
                objTSTS_HIKIATE_KOO.FTRNS_END_DT = DEFAULT_DATE                                     '������������
                objTSTS_HIKIATE_KOO.FUPDATE_DT = Now                                                '�X�V����
                objTSTS_HIKIATE_KOO.ADD_TSTS_HIKIATE()                                              '�o�^


            End If


            ''************************************************************************************************
            ''************************************************************************************************
            ''�I��ۯ����            �X�V
            ''�ڰݗD�揇             �X�V
            ''************************************************************************************************
            ''************************************************************************************************
            'If TO_INTEGER(strDenbunDtl(DSPST_TO)) = FTRK_BUF_NO_J9000 Then
            '    '(�����q�ɂւ̓��ɂ̏ꍇ)

            '    If blnHasu = False Then
            '        '(�[���݌ɂ����݂��Ȃ� �ꍇ)


            '        '************************************************
            '        '�I��ۯ���Ԃ̍X�V
            '        '************************************************
            '        Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_ASRS_OYA, XTANA_BLOCK_STS_IN)


            '    Else
            '        '(�[���݌ɂ����݂��� �ꍇ)

            '        If TO_INTEGER(objTPRG_TRK_BUF_ASRS_OYA.FRAC_EDA) = FLAG_ON Then
            '            '(���I�̏ꍇ)


            '            '************************************************
            '            '�ڰݗD�揇�̍X�V
            '            '************************************************
            '            '====================================
            '            '�ڰ�Ͻ��̓���
            '            '====================================
            '            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             '�ڰ�Ͻ��׽
            '            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO            '�ޯ̧��
            '            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS_OYA.FRAC_RETU             '��
            '            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '����
            '            If intRet = RetCode.NotFound Then
            '                '(������Ȃ��ꍇ)
            '                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
            '                Throw New UserException(strMsg)
            '            End If

            '            '====================================
            '            '�ڰݗD�揇�̍X�V
            '            '====================================
            '            Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)     '�ڰݗD�揇�X�V�׽
            '            objSVR_100205.FTRK_BUF_NO = TO_INTEGER(strDenbunDtl(DSPST_TO))  '�ׯ�ݸ��ޯ̧No
            '            objSVR_100205.FEQ_ID = objTMST_CRANE.FEQ_ID                     '�g�p�ݔ�ID
            '            objSVR_100205.CRANE_ORDER_UPDATE()                              '�X�V


            '        End If

            '    End If

            'End If


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310102)                           '�N��


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ���ɐݒ�                     (SVR_400001)ST���璼�ړ��Ɏw���𑗐M��������݂ŁA����͖��g�p   "
    ''''**********************************************************************************************
    '''' <summary>
    '''' ���ɐݒ�
    '''' </summary>
    '''' <param name="strDenbunDtl">�d������z��</param>
    '''' <param name="strMSG_RECV">��M�d��</param>
    '''' <param name="strMSG_SEND">���M�d��</param>
    '''' <param name="strFPALLET_ID">���炩���ߍ쐬���Ă�������گ�ID</param>
    '''' <param name="strFTRK_BUF_NO_ASRS">���炩���ߗ\�񂵂Ă������q�ɂ��ׯ�ݸ��ޯ̧��</param>
    '''' <param name="strFTRK_BUF_ARRAY_ASRS">���炩���ߗ\�񂵂Ă������q�ɂ��ׯ�ݸ��ޯ̧�z��</param>
    '''' <param name="strXOYAKO_KUBUN">�e�q�敪</param>
    '''' <param name="strXPALLET_ID_AITE">������گ�ID</param>
    '''' <returns>OK/NG</returns>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Public Function SVR_400001_Process(ByVal strDenbunDtl() As String _
    '                                 , ByVal strMSG_RECV As String _
    '                                 , ByRef strMSG_SEND As String _
    '                                 , ByVal strFPALLET_ID As String _
    '                                 , ByVal strFTRK_BUF_NO_ASRS As String _
    '                                 , ByVal strFTRK_BUF_ARRAY_ASRS As String _
    '                                 , ByVal strXOYAKO_KUBUN As String _
    '                                 , ByVal strXPALLET_ID_AITE As String _
    '                                 ) As RetCode


    '    Dim intRet As RetCode                 '�߂�l
    '    Dim strMsg As String                  'ү����

    '    '�d������p
    '    Dim DSPTERM_ID As Integer = 0             '�[��ID
    '    Dim DSPUSER_ID As Integer = 1             'հ�ްID
    '    Dim DSPREASON As Integer = 2              '���R
    '    Dim DSPST_FM As Integer = 3               '������ST�ׯ�ݸ��ޯ̧��
    '    Dim DSPST_TO As Integer = 4               '������ST�ׯ�ݸ��ޯ̧��
    '    Dim DSPPALLET_ID As Integer = 5           '��گ�ID
    '    Dim DSPLOT_NO_STOCK As Integer = 6        '�݌�ۯć�
    '    Dim DSPSAGYOU_KIND As Integer = 7         '��Ǝ��
    '    Dim DSPHINMEI_CD As Integer = 8           '�i������
    '    Dim DSPTR_VOL As Integer = 9              '�����Ǘ���
    '    Dim XDSPIN_KIND As Integer = 10           '���Ɏ��
    '    Dim XDSPIN_SITEI As Integer = 11          '���Ɏw��
    '    Dim XDSPPROD_LINE As Integer = 12         '���Yײ݇�
    '    Dim XDSPKENSA_KUBUN As Integer = 13       '�����敪
    '    Dim DSPHORYU_KUBUN As Integer = 14        '�ۗ��敪
    '    Dim XDSPTR_VOL_KO As Integer = 15         '�����Ǘ���(�q)
    '    Dim XDSPKENSA_KUBUN_KO As Integer = 16    '�����敪(�q)
    '    Dim XDSPHORYU_KUBUN_KO As Integer = 17    '�ۗ��敪(�q)
    '    Dim XDSPST_TO_ARRAY01 As Integer = 18     '�������ׯ�ݸ��ޯ̧�z��01
    '    Dim XDSPST_TO_ARRAY02 As Integer = 19     '�������ׯ�ݸ��ޯ̧�z��02

    '    Try


    '        '************************************************
    '        '������ST���ׯ�ݸ��ޯ̧Ͻ�      �擾
    '        '************************************************
    '        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
    '        objTMST_TRK.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)
    '        objTMST_TRK.GET_TMST_TRK()


    '        '************************
    '        '������ST�擾
    '        '************************
    '        Dim intFTRK_BUF_NO_FM As Integer = strDenbunDtl(DSPST_FM)   '�ׯ�ݸ��ޯ̧��(FM)
    '        Dim intFTRK_BUF_NO_TO As Integer                            '�ׯ�ݸ��ޯ̧��(TO)
    '        Dim intFSAGYOU_KIND As Integer = strDenbunDtl(DSPSAGYOU_KIND)   '��Ǝ��

    '        '************************
    '        '���ޯ̧�̓���
    '        '************************
    '        Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      '�ׯ�ݸ��ޯ̧ð��ٸ׽
    '        If IsNull(strFPALLET_ID) Then
    '            objTPRG_TRK_BUF_FM.FTRK_BUF_NO = intFTRK_BUF_NO_FM                      '���ɐݒ�ST
    '            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF_AKI_HIRA                   '����
    '            If intRet = RetCode.NotFound Then
    '                '(������Ȃ��ꍇ)
    '                strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_FM.FTRK_BUF_NO) & "]"
    '                Throw New UserException(strMsg)
    '            End If
    '        End If


    '        If IsNull(strFPALLET_ID) Then
    '            '(�݌ɏ�񂪂Ȃ��ꍇ)

    '            Throw New Exception("�߱�����Ƃ����ނƂ�₱�����Ȃ�̂ŁA�����ł͍݌ɍ쐬���Ȃ��B")

    '            ' '' ''************************
    '            ' '' ''�i��Ͻ�        �擾
    '            ' '' ''************************
    '            '' ''Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
    '            '' ''objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)        '�i�ں���
    '            '' ''intRet = objTMST_ITEM.GET_TMST_ITEM(False)                  '�擾
    '            '' ''If intRet <> RetCode.OK Then
    '            '' ''    '(������Ȃ��ꍇ)
    '            '' ''    Call AddToMsgLog(Now, FMSG_ID_S0201, objTMST_ITEM.FHINMEI_CD)
    '            '' ''    strMsg = ERRMSG_NOTFOUND_TMST_ITEM
    '            '' ''    Throw New UserException(strMsg, False)
    '            '' ''    'Return RetCode.RollBack
    '            '' ''End If


    '            ' '' ''************************
    '            ' '' ''�݌ɏ��̓o�^
    '            ' '' ''************************
    '            '' ''Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '�݌ɏ��ð��ٸ׽
    '            '' ''Call TRST_STOCKAddProcess(objTRST_STOCK _
    '            '' ''                        , strDenbunDtl(DSPHINMEI_CD) _
    '            '' ''                        , Now _
    '            '' ''                        , FHORYU_KUBUN_SNORMAL _
    '            '' ''                        , TO_DECIMAL(strDenbunDtl(DSPTR_VOL)) _
    '            '' ''                        , FTR_RES_VOL_SKOTEI _
    '            '' ''                        , Now _
    '            '' ''                        , TO_DATE(strDenbunDtl(XDSPSEIZOU_DT)) _
    '            '' ''                        , strDenbunDtl(XDSPLINE_NO) _
    '            '' ''                        , strDenbunDtl(XDSPPALLET_NO) _
    '            '' ''                        , strDenbunDtl(XDSPKENSA_KUBUN) _
    '            '' ''                        , strDenbunDtl(XDSPAB_KUBUN) _
    '            '' ''                        , intXSYUKKA_KAHI _
    '            '' ''                        , IIf(objTMST_ITEM.XSTRETCH_KUBUN = XSTRETCH_KUBUN_JON, XSTRETCH_STS_JNONE, XSTRETCH_STS_JEND) _
    '            '' ''                        , intXHINSHITU_STS _
    '            '' ''                        , Nothing _
    '            '' ''                        , Nothing _
    '            '' ''                        , Nothing _
    '            '' ''                        , strDenbunDtl(XDSPBC_DATA) _
    '            '' ''                        , Nothing _
    '            '' ''                        , Now _
    '            '' ''                        , Nothing _
    '            '' ''                        )
    '            '' ''strFPALLET_ID = objTRST_STOCK.FPALLET_ID                                            '��گ�ID�X�V


    '            ' '' ''************************
    '            ' '' ''�݌Ɉ������̓o�^
    '            ' '' ''************************
    '            '' ''Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
    '            '' ''objTSTS_HIKIATE.FSAGYOU_KIND = intFSAGYOU_KIND                      '��Ǝ��
    '            '' ''objTSTS_HIKIATE.FPLAN_KEY = FPLAN_KEY_SKOTEI                        '�v�淰
    '            '' ''objTSTS_HIKIATE.FPALLET_ID = objTRST_STOCK.FPALLET_ID               '��گ�ID
    '            '' ''objTSTS_HIKIATE.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK         '�݌�ۯć�
    '            '' ''objTSTS_HIKIATE.FTR_VOL = objTRST_STOCK.FTR_VOL                     '�����Ǘ���
    '            '' ''objTSTS_HIKIATE.FTERM_ID = DEFAULT_STRING                           '�[��ID
    '            '' ''objTSTS_HIKIATE.FUSER_ID = DEFAULT_STRING                           'հ�ްID
    '            '' ''objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING                       '�w�����M�҂����R
    '            '' ''objTSTS_HIKIATE.FTRNS_START_DT = DEFAULT_DATE                       '�����J�n����
    '            '' ''objTSTS_HIKIATE.FTRNS_END_DT = DEFAULT_DATE                         '������������
    '            '' ''objTSTS_HIKIATE.FUPDATE_DT = Now                                    '�X�V����
    '            '' ''objTSTS_HIKIATE.ADD_TSTS_HIKIATE()                                  '�o�^


    '            ' '' ''************************
    '            ' '' ''�݌ɓo�^
    '            ' '' ''************************
    '            '' ''Dim objSYS_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog)         '�݌ɍ쐬�׽
    '            '' ''objSYS_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_FM                  '�ׯ�ݸ��ޯ̧
    '            '' ''objSYS_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID                 '��گ�ID
    '            '' ''objSYS_100101.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(���ɐݒ�)
    '            '' ''objSYS_100101.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND           '��Ǝ��(���ѕێ�)
    '            '' ''objSYS_100101.STOCK_ADD()                                           '�o�^


    '        Else
    '            '(�݌ɏ�񂪂���ꍇ)


    '            '************************
    '            'ST�ׯ�ݸނ̓���
    '            '************************
    '            objTPRG_TRK_BUF_FM.FTRK_BUF_NO = intFTRK_BUF_NO_FM          '���ɐݒ�ST
    '            objTPRG_TRK_BUF_FM.FPALLET_ID = strFPALLET_ID               '��گ�ID
    '            objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF()                       '����

    '        End If


    '        '************************
    '        '�ޯ̧�̍X�V
    '        '************************
    '        objTPRG_TRK_BUF_FM.FRSV_PALLET = strFPALLET_ID                         '��������گ�ID
    '        objTPRG_TRK_BUF_FM.FRES_KIND = FRES_KIND_SZAIKO                        '�������
    '        objTPRG_TRK_BUF_FM.FTR_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO             '����FM�ޯ̧��
    '        objTPRG_TRK_BUF_FM.FTR_TO = intFTRK_BUF_NO_TO                          '����TO�ޯ̧��
    '        objTPRG_TRK_BUF_FM.FTR_IDOU = intFTRK_BUF_NO_TO                        '����TO�ړ��ޯ̧��
    '        objTPRG_TRK_BUF_FM.FTRNS_FM = DEFAULT_STRING                           '�����w�ߗpFM
    '        objTPRG_TRK_BUF_FM.FTRNS_TO = DEFAULT_STRING                           '�����w�ߗpTO
    '        objTPRG_TRK_BUF_FM.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO        'FM�����ޯ̧��
    '        objTPRG_TRK_BUF_FM.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY   'FM�����z��
    '        objTPRG_TRK_BUF_FM.FRSV_BUF_TO = DEFAULT_INTEGER                       'TO�����ޯ̧��
    '        objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = DEFAULT_INTEGER                     'TO�����z��
    '        objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS 'FM�\�L�p���ڽ
    '        objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = DEFAULT_STRING                   'TO�\�L�p���ڽ
    '        objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now                                    '�ޯ̧������
    '        objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()                               '�X�V


    '        '************************
    '        '�q���ޯ̧�̓���
    '        '************************
    '        Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
    '        If IsNull(strFTRK_BUF_NO_ASRS) And IsNull(strFTRK_BUF_ARRAY_ASRS) Then
    '            '(�܂��I���m�肵�Ă��Ȃ��ꍇ)

    '            Throw New Exception("�����̎��_�ł͋�I���m�肵�Ă��Ȃ��Ƃ����܂���B")


    '            ''**********************************************
    '            ''��I��������
    '            ''**********************************************
    '            'Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '��I�����׽
    '            'intRet = AkitanaHikiate(objSYS_100201 _
    '            '                      , objTPRG_TRK_BUF_ASRS _
    '            '                      , objTPRG_TRK_BUF_FM _
    '            '                      , strFPALLET_ID _
    '            '                      , strDenbunDtl(DSPHINMEI_CD) _
    '            '                      , FTRK_BUF_NO_J9000 _
    '            '                      , True _
    '            '                      )


    '            'If intRet = RetCode.NotFound Then
    '            '    '    '(������Ȃ��ꍇ)
    '            '    Call AddToMsgLog(Now, FMSG_ID_S0102, objTMST_TRK.FBUF_NAME, "�i������:" & strDenbunDtl(DSPHINMEI_CD))
    '            '    strMsg = ERRMSG_NOTFOUND_AKI
    '            '    Throw New UserException(strMsg, False)
    '            '    'Return RetCode.RollBack
    '            'End If


    '            ''������������**********************************************************************************************************************************************************************************************
    '            ''SystemMate:N.Dounoshita 2012/08/15  ��I���������̋��ʉ�


    '            ' '' '' ''************************************************
    '            ' '' '' ''�i��Ͻ�      �擾
    '            ' '' '' ''************************************************
    '            '' '' ''Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
    '            '' '' ''objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)
    '            '' '' ''objTMST_ITEM.GET_TMST_ITEM()


    '            ' '' '' ''************************************************
    '            ' '' '' ''�������ߓ���Ͻ�        �擾
    '            ' '' '' ''************************************************
    '            '' '' ''Dim objTMST_SP_RES_TYPE As New TBL_TMST_SP_RES_TYPE(Owner, ObjDb, ObjDbLog)
    '            '' '' ''objTMST_SP_RES_TYPE.FCONDITION01 = objTMST_ITEM.XNIDAKA_KUBUN
    '            '' '' ''objTMST_SP_RES_TYPE.GET_TMST_SP_RES_TYPE()


    '            ' '' '' ''������������************************************************************************************************************
    '            ' '' '' ''JobMate:A.Noto 2012/07/07 �ڰ݈��������ǉ�

    '            ' '' '' ''************************
    '            ' '' '' ''�ڰ݂̓���
    '            ' '' '' ''************************
    '            '' '' ''Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         '���ѕϐ��׽
    '            '' '' ''objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002                         '�ϐ�ID
    '            '' '' ''intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '�擾
    '            ' '' '' ''�i��Ͻ��̍ŏI�����ڰ�ID�ōX�V
    '            '' '' ''objTPRG_SYS_HEN.OBJCHANGE_DATA = objTMST_ITEM.XHIKIATE_CRANE_ID             '�ύX�ް�
    '            '' '' ''objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN_OBJ()                                   '�X�V

    '            ' '' '' ''************************
    '            ' '' '' ''�ڰݗD�揇�̍쐬
    '            ' '' '' ''************************
    '            '' '' ''Dim strFEQ_ID_CRANE() As String
    '            '' '' ''objTPRG_SYS_HEN.FHENSU_CHAR = Nothing
    '            '' '' ''intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '�擾
    '            '' '' ''strFEQ_ID_CRANE = Split(objTPRG_SYS_HEN.FHENSU_CHAR, KUGIRI01)

    '            ' '' '' ''������������************************************************************************************************************


    '            ' '' '' ''************************
    '            ' '' '' ''�q���ޯ̧�̓���
    '            ' '' '' ''************************
    '            '' '' ''Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '��I�����׽
    '            '' '' ''objSYS_100201.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTR_TO       '�ޯ̧��(�q��)
    '            ' '' '' ''objSYS_100201.FRAC_FORM = objTMST_ITEM.FRAC_FORM            '�I�`����
    '            '' '' ''objSYS_100201.FRES_TYPE = objTMST_SP_RES_TYPE.FRES_TYPE     '��������
    '            '' '' ''objSYS_100201.FPALLET_ID = strFPALLET_ID                    '��گ�ID
    '            '' '' ''objSYS_100201.FEQ_ID_CRANE = strFEQ_ID_CRANE                '���ڰݐݔ�ID
    '            '' '' ''intRet = objSYS_100201.FIND_TANA_AKI            '����
    '            '' '' ''If intRet = RetCode.NotFound Then
    '            '' '' ''    '(������Ȃ��ꍇ)

    '            '' '' ''    Call AddToMsgLog(Now, FMSG_ID_S0102, objTMST_TRK.FBUF_NAME)
    '            '' '' ''    strMsg = ERRMSG_NOTFOUND_AKI
    '            '' '' ''    Throw New UserException(strMsg, False)
    '            '' '' ''    'Return RetCode.RollBack
    '            '' '' ''End If
    '            '' '' ''objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objSYS_100201.FTRK_BUF_NO                '�ޯ̧��
    '            '' '' ''objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objSYS_100201.FTRK_BUF_ARRAY          '�z��
    '            '' '' ''objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                                     '����


    '            ' '' '' ''������������************************************************************************************************************
    '            ' '' '' ''CommentMate:A.Noto 2012/07/07 ��Ÿڰ݈��������ǉ�

    '            ' '' '' ''************************
    '            ' '' '' ''�ڰ݂̓���
    '            ' '' '' ''************************
    '            '' '' ''Dim objTPRG_SYS_HEN_BEFORE As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         '���ѕϐ��׽
    '            '' '' ''objTPRG_SYS_HEN_BEFORE.FHENSU_ID = FHENSU_ID_SSS000000_002                         '�ϐ�ID
    '            '' '' ''intRet = objTPRG_SYS_HEN_BEFORE.GET_TPRG_SYS_HEN(True)                             '�擾

    '            ' '' '' ''************************
    '            ' '' '' ''�i��Ͻ��X�V
    '            ' '' '' ''************************
    '            '' '' ''objTMST_ITEM.XHIKIATE_CRANE_ID = objTPRG_SYS_HEN_BEFORE.FHENSU_CHAR
    '            '' '' ''objTMST_ITEM.UPDATE_TMST_ITEM()

    '            ' '' '' ''������������************************************************************************************************************


    '            ''������������**********************************************************************************************************************************************************************************************


    '        Else
    '            '(���ɒI���m�肵�Ă���ꍇ)


    '            '************************
    '            '�q���ޯ̧�̓���
    '            '************************
    '            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = strFTRK_BUF_NO_ASRS              '�ޯ̧��
    '            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = strFTRK_BUF_ARRAY_ASRS        '�z��
    '            objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                             '����


    '            '************************
    '            '��Ǝ�ʂ̕ύX
    '            '************************
    '            intFSAGYOU_KIND = FSAGYOU_KIND_SIN_PICK


    '        End If


    '        '************************
    '        '�ׯ�ݸ��ޯ̧(ST)�̍X�V
    '        '************************
    '        objTPRG_TRK_BUF_FM.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO               'TO�����ׯ�ݸއ�
    '        objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY          'TO�����z��
    '        objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS          'FM�\�L�p���ڽ
    '        objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS        'TO�\�L�p���ڽ
    '        objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now                                             '�ޯ̧������
    '        objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()                                        '�X�V


    '        '************************
    '        '�q�ɂ̍X�V
    '        '************************
    '        objTPRG_TRK_BUF_ASRS.FRSV_PALLET = objTPRG_TRK_BUF_FM.FPALLET_ID        '������PC��
    '        objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '�������
    '        objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                                   '�ޯ̧������
    '        objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                              '�X�V


    '        '������������************************************************************************************************************
    '        'JobMate:N.Dounoshita 2013/04/04 �I��ۯ���Ԃ��X�V


    '        '************************************************
    '        '�I��ۯ���Ԃ̍X�V
    '        '************************************************
    '        Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_ASRS, XTANA_BLOCK_STS_IN)


    '        '������������************************************************************************************************************


    '        '************************************************
    '        '���Ɏw���p�̔����w��QUE��ǉ�
    '        '************************************************
    '        Call Add_In_TPLN_CARRY_QUE_Process(objTPRG_TRK_BUF_FM, intFSAGYOU_KIND, strXOYAKO_KUBUN, strXPALLET_ID_AITE)


    '        '************************
    '        '�������N��
    '        '************************
    '        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
    '        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��


    '        Return RetCode.OK
    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Throw New UserException(ex.Message)
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Function
#End Region
#Region "  ���u���o��                   (SVR_400102)                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' ���u���o��
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SVR_400102_Process(ByVal strDenbunDtl() As String _
                                     , ByVal strMSG_RECV As String _
                                     , ByRef strMSG_SEND As String _
                                     ) As RetCode
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����

        '�d������p
        Dim DSPTERM_ID As Integer = 0         '�[��ID
        Dim DSPUSER_ID As Integer = 1         'հ�ްID
        Dim DSPREASON As Integer = 2          '���R
        Dim DSPPALLET_ID As Integer = 3       '��گ�ID

        Try


            '************************************************
            '�ׯ�ݸނ̓���
            '************************************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)     '��گ�ID
            objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                          '����


            '************************
            'IN/OUT     �ݒ�
            '************************
            Dim intFINOUT_STS As Integer = 0


            '************************
            '�ׯ�ݸލ폜
            '************************
            Dim objSVR_100302 As New SVR_100302(Owner, ObjDb, ObjDbLog)
            objSVR_100302.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO     '�ޯ̧��
            objSVR_100302.FPALLET_ID = objTPRG_TRK_BUF.FPALLET_ID       '��گ�ID
            objSVR_100302.FINOUT_STS = intFINOUT_STS                    'IN/OUT
            objSVR_100302.FTERM_ID = FTERM_ID_SKOTEI                    '�[��ID
            objSVR_100302.FUSER_ID = FUSER_ID_SKOTEI                    'հ�ްID
            objSVR_100302.MENTE_DELETE()                                '�ׯ�ݸލ폜


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ���s�ݒ�                     (SVR_499999)                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' ���s�ݒ�
    ''' </summary>
    ''' <param name="strDenbunDtl">�d������z��</param>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SVR_499999_Process(ByVal strDenbunDtl() As String _
                                     , ByVal strMSG_RECV As String _
                                     , ByRef strMSG_SEND As String _
                                     , Optional ByVal strFPALLET_ID As String = Nothing _
                                     , Optional ByVal strFTRK_BUF_NO_ASRS As String = Nothing _
                                     , Optional ByVal strFTRK_BUF_ARRAY_ASRS As String = Nothing _
                                     , Optional ByVal strXOYAKO_KUBUN As String = Nothing _
                                     , Optional ByVal strXPALLET_ID_AITE As String = Nothing _
                                     ) As RetCode
        Dim intRet As RetCode                 '�߂�l
        Dim strMsg As String                  'ү����

        '�d������p
        Dim DSPTERM_ID As Integer = 0             '�[��ID
        Dim DSPUSER_ID As Integer = 1             'հ�ްID
        Dim DSPREASON As Integer = 2              '���R
        Dim DSPST_FM As Integer = 3               '������ST�ׯ�ݸ��ޯ̧��
        Dim DSPST_TO As Integer = 4               '������ST�ׯ�ݸ��ޯ̧��
        Dim DSPPALLET_ID As Integer = 5           '��گ�ID
        Dim DSPLOT_NO_STOCK As Integer = 6        '�݌�ۯć�
        Dim DSPSAGYOU_KIND As Integer = 7         '��Ǝ��
        Dim DSPHINMEI_CD As Integer = 8           '�i������
        Dim DSPTR_VOL As Integer = 9              '�����Ǘ���
        Dim XDSPIN_KIND As Integer = 10           '���Ɏ��
        Dim XDSPIN_SITEI As Integer = 11          '���Ɏw��
        Dim XDSPPROD_LINE As Integer = 12         '���Yײ݇�
        Dim XDSPKENSA_KUBUN As Integer = 13       '�����敪
        Dim DSPHORYU_KUBUN As Integer = 14        '�ۗ��敪
        Dim XDSPTR_VOL_KO As Integer = 15         '�����Ǘ���(�q)
        Dim XDSPKENSA_KUBUN_KO As Integer = 16    '�����敪(�q)
        Dim XDSPHORYU_KUBUN_KO As Integer = 17    '�ۗ��敪(�q)
        Dim XDSPST_TO_ARRAY01 As Integer = 18     '�������ׯ�ݸ��ޯ̧�z��01
        Dim XDSPST_TO_ARRAY02 As Integer = 19     '�������ׯ�ݸ��ޯ̧�z��02

        Try


            '************************
            '������ST�擾
            '************************
            Dim intFTRK_BUF_NO_FM As Integer = strDenbunDtl(DSPST_FM)           '�ׯ�ݸ��ޯ̧��(FM)
            Dim intFTRK_BUF_NO_TO As Integer = strDenbunDtl(DSPST_TO)           '�ׯ�ݸ��ޯ̧��(TO)
            Dim intFSAGYOU_KIND As Integer = strDenbunDtl(DSPSAGYOU_KIND)       '��Ǝ��


            '************************
            '���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧ð��ٸ׽
            If IsNull(strFPALLET_ID) Then
                objTPRG_TRK_BUF_FM.FTRK_BUF_NO = intFTRK_BUF_NO_FM                     '���ɐݒ�ST
                intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF_AKI_HIRA                  '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_FM.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
                End If
            End If


            If IsNull(strFPALLET_ID) Then
                '(�݌ɏ�񂪂Ȃ��ꍇ)


                '************************
                '�i��Ͻ�        �擾
                '************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)        '�i�ں���
                intRet = objTMST_ITEM.GET_TMST_ITEM(False)                  '�擾
                If intRet <> RetCode.OK Then
                    '(������Ȃ��ꍇ)
                    Call AddToMsgLog(Now, FMSG_ID_S0201, objTMST_ITEM.FHINMEI_CD)
                    strMsg = ERRMSG_NOTFOUND_TMST_ITEM
                    Throw New UserException(strMsg, False)
                    'Return RetCode.RollBack
                End If

                '������������************************************************************************************************************
                'Checked Comment:A.Noto 2013/03/21 ��۸��ѐ������̺��ı��
                ''************************
                ''�݌ɏ��̓o�^
                ''************************
                'Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '�݌ɏ��ð��ٸ׽
                'Call TRST_STOCKAddProcess(objTRST_STOCK _
                '                        , strDenbunDtl(DSPHINMEI_CD) _
                '                        , Now _
                '                        , FHORYU_KUBUN_SNORMAL _
                '                        , TO_DECIMAL(strDenbunDtl(DSPTR_VOL)) _
                '                        , FTR_RES_VOL_SKOTEI _
                '                        , Now _
                '                        , TO_DATE(strDenbunDtl(XDSPSEIZOU_DT)) _
                '                        , strDenbunDtl(XDSPLINE_NO) _
                '                        , strDenbunDtl(XDSPPALLET_NO) _
                '                        , strDenbunDtl(XDSPKENSA_KUBUN) _
                '                        , strDenbunDtl(XDSPAB_KUBUN) _
                '                        , intXSYUKKA_KAHI _
                '                        , IIf(objTMST_ITEM.XSTRETCH_KUBUN = XSTRETCH_KUBUN_JON, XSTRETCH_STS_JNONE, XSTRETCH_STS_JEND) _
                '                        , intXHINSHITU_STS _
                '                        , Nothing _
                '                        , Nothing _
                '                        , Nothing _
                '                        , strDenbunDtl(XDSPBC_DATA) _
                '                        , Nothing _
                '                        , Now _
                '                        , Nothing _
                '                        )
                'strFPALLET_ID = objTRST_STOCK.FPALLET_ID                                            '��گ�ID�X�V


                ''************************
                ''�݌Ɉ������̓o�^
                ''************************
                'Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
                'objTSTS_HIKIATE.FSAGYOU_KIND = intFSAGYOU_KIND                      '��Ǝ��
                'objTSTS_HIKIATE.FPLAN_KEY = FPLAN_KEY_SKOTEI                        '�v�淰
                'objTSTS_HIKIATE.FPALLET_ID = objTRST_STOCK.FPALLET_ID               '��گ�ID
                'objTSTS_HIKIATE.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK         '�݌�ۯć�
                'objTSTS_HIKIATE.FTR_VOL = objTRST_STOCK.FTR_VOL                     '�����Ǘ���
                'objTSTS_HIKIATE.FTERM_ID = DEFAULT_STRING                           '�[��ID
                'objTSTS_HIKIATE.FUSER_ID = DEFAULT_STRING                           'հ�ްID
                'objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING                       '�w�����M�҂����R
                'objTSTS_HIKIATE.FTRNS_START_DT = DEFAULT_DATE                       '�����J�n����
                'objTSTS_HIKIATE.FTRNS_END_DT = DEFAULT_DATE                         '������������
                'objTSTS_HIKIATE.FUPDATE_DT = Now                                    '�X�V����
                'objTSTS_HIKIATE.ADD_TSTS_HIKIATE()                                  '�o�^


                ''************************
                ''�݌ɓo�^
                ''************************
                'Dim objSYS_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog)         '�݌ɍ쐬�׽
                'objSYS_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_FM                  '�ׯ�ݸ��ޯ̧
                'objSYS_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID                 '��گ�ID
                'objSYS_100101.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(���ɐݒ�)
                'objSYS_100101.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND           '��Ǝ��(���ѕێ�)
                'objSYS_100101.STOCK_ADD()                                           '�o�^
                '������������************************************************************************************************************

            Else
                '(�݌ɏ�񂪂���ꍇ)


                '************************
                'ST�ׯ�ݸނ̓���
                '************************
                objTPRG_TRK_BUF_FM.FPALLET_ID = strFPALLET_ID       '��گ�ID
                objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF()               '����


            End If


            '************************
            '�������ׯ�ݸ�Ͻ��̓���
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧Ͻ��׽
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO_TO                     '�ׯ�ݸ��ޯ̧No
            objTMST_TRK.GET_TMST_TRK()                                      '����


            '************************
            '�ׯ�ݸ��ޯ̧�̍X�V(FM)
            '************************
            objTPRG_TRK_BUF_FM.FRSV_PALLET = objTPRG_TRK_BUF_FM.FPALLET_ID              '��������گ�ID
            objTPRG_TRK_BUF_FM.FTR_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                  '����FM�ޯ̧��
            objTPRG_TRK_BUF_FM.FTR_TO = intFTRK_BUF_NO_TO                               '����TO�ޯ̧��
            objTPRG_TRK_BUF_FM.FTR_IDOU = DEFAULT_INTEGER                               '����TO�ړ��ޯ̧��
            objTPRG_TRK_BUF_FM.FTRNS_FM = DEFAULT_STRING                                '�����w�ߗpFM
            objTPRG_TRK_BUF_FM.FTRNS_TO = DEFAULT_STRING                                '�����w�ߗpTO
            objTPRG_TRK_BUF_FM.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO             'FM�����ׯ�ݸއ�
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY        'FM�����z��
            objTPRG_TRK_BUF_FM.FRSV_BUF_TO = DEFAULT_INTEGER                            'TO�����ׯ�ݸއ�
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = DEFAULT_INTEGER                          'TO�����z��
            objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS      'FM�\�L�p���ڽ
            objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = objTMST_TRK.FBUF_NAME                 'TO�\�L�p���ڽ
            objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now                                         '�ޯ̧������
            objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()                                    '�X�V


            '************************
            '��Ǝ�ʖ�������̓���
            '************************
            Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)
            objTMST_SAGYO.FSAGYOU_KIND = intFSAGYOU_KIND        '��Ǝ��
            objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                '�ݔ�ID
            objTMST_SAGYO.GET_TMST_SAGYO()                      '�擾


            '************************
            '�o�Ɏw��QUE�̓o�^
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�����w��QUE�׽
            objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '�����w����
            objTPLN_CARRY_QUE.FEQ_ID = FEQ_ID_SKOTEI                                '�ݔ�ID
            objTPLN_CARRY_QUE.FPRIORITY = objTMST_SAGYO.FPRIORITY                   '�D������
            objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID            '��گ�ID
            objTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SMOVE               '�w���敪
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON            '�����w����
            objTPLN_CARRY_QUE.FENTRY_DT = Now                                       '�o�^����
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '�X�V����
            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/27 �e�q�ݒ�
            objTPLN_CARRY_QUE.XOYAKO_KUBUN = strXOYAKO_KUBUN                        '�e�q�敪
            objTPLN_CARRY_QUE.XPALLET_ID_AITE = strXPALLET_ID_AITE                  '������گ�ID
            '������������************************************************************************************************************
            objTPLN_CARRY_QUE.ADD_TPLN_CARRY_QUE_ORDER()                            '�o�^


            ''������������************************************************************************************************************
            ''SystemMate:N.Dounoshita 2012/10/18  �����̎��_�ŁA��I���������Ă�ꍇ�͂��̏������K�v


            'If Not ( _
            '          objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J384 _
            '       Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J387 _
            '       Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J389 _
            '       Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J394 _
            '       Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J399 _
            '       ) _
            '       Then
            '    '(���Y���ɈȊO�̏ꍇ)


            '    '************************
            '    '�q���ޯ̧�̓���
            '    '************************
            '    Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            '    If IsNull(strFTRK_BUF_NO_ASRS) And IsNull(strFTRK_BUF_ARRAY_ASRS) Then
            '        '(�܂��I���m�肵�Ă��Ȃ��ꍇ)


            '        '**********************************************
            '        '��I��������
            '        '**********************************************
            '        Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '��I�����׽
            '        intRet = AkitanaHikiate(objSYS_100201 _
            '                              , objTPRG_TRK_BUF_ASRS _
            '                              , objTPRG_TRK_BUF_FM _
            '                              , strFPALLET_ID _
            '                              , strDenbunDtl(DSPHINMEI_CD) _
            '                              , FTRK_BUF_NO_J9000 _
            '                              , True _
            '                              )
            '        If intRet = RetCode.NotFound Then
            '            '(������Ȃ��ꍇ)

            '            Call AddToMsgLog(Now, FMSG_ID_S0102, objTMST_TRK.FBUF_NAME, "�i������:" & strDenbunDtl(DSPHINMEI_CD))
            '            strMsg = ERRMSG_NOTFOUND_AKI
            '            Throw New UserException(strMsg, False)
            '            'Return RetCode.RollBack

            '        End If


            '    Else
            '        '(���ɒI���m�肵�Ă���ꍇ)


            '        '************************
            '        '�q���ޯ̧�̓���
            '        '************************
            '        objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = strFTRK_BUF_NO_ASRS              '�ޯ̧��
            '        objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = strFTRK_BUF_ARRAY_ASRS        '�z��
            '        objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                             '����


            '        '************************
            '        '��Ǝ�ʂ̕ύX
            '        '************************
            '        intFSAGYOU_KIND = FSAGYOU_KIND_SIN_PICK


            '    End If


            '    '************************
            '    '�q�ɂ̍X�V
            '    '************************
            '    objTPRG_TRK_BUF_ASRS.FRSV_PALLET = objTPRG_TRK_BUF_FM.FPALLET_ID        '������PC��
            '    objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '�������
            '    objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                                   '�ޯ̧������
            '    objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                              '�X�V


            'End If


            ''������������************************************************************************************************************


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ���Ɏw���p�̔����w��QUE��ǉ�                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���Ɏw���p�̔����w��QUE��ǉ�
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_ST">ST�ׯ�ݸ�</param>
    ''' <param name="intFSAGYOU_KIND">��Ǝ��</param>
    ''' <param name="strXOYAKO_KUBUN">�e�q�敪</param>
    ''' <param name="strXPALLET_ID_AITE">������گ�ID</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Add_In_TPLN_CARRY_QUE_Process(ByRef objTPRG_TRK_BUF_ST As TBL_TPRG_TRK_BUF _
                                           , ByVal intFSAGYOU_KIND As Integer _
                                           , Optional ByVal strXOYAKO_KUBUN As String = Nothing _
                                           , Optional ByVal strXPALLET_ID_AITE As String = Nothing _
                                           )
        Dim intRet As RetCode                   '�߂�l
        Dim strMsg As String                    'ү����
        Try


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    '�ׯ�ݸ��ޯ̧
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FRSV_BUF_TO           '�ׯ�ݸ��ޯ̧��
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO      '�ׯ�ݸ��ޯ̧�z��
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_TRK & "[�ׯ�ݸ��ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO) & "  ,�ׯ�ݸ��ޯ̧�z��:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY) & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�ڰ�Ͻ��̓���
            '************************
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)     '�ڰ�Ͻ��׽
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO        '�ޯ̧��
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU         '��
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                           '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '��Ǝ�ʖ�������̓���
            '************************
            Dim intFPRIORITY As Integer = FPRIORITY_SLOW
            Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)
            objTMST_SAGYO.FSAGYOU_KIND = intFSAGYOU_KIND        '��Ǝ��
            objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                '�ݔ�ID
            intRet = objTMST_SAGYO.GET_TMST_SAGYO(False)        '����
            If intRet = RetCode.OK Then
                intFPRIORITY = objTMST_SAGYO.FPRIORITY
            End If


            '************************
            '�����w��QUE�̓o�^
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�����w��QUE�׽
            objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '�����w����
            objTPLN_CARRY_QUE.FEQ_ID = objTMST_CRANE.FEQ_ID                         '�ݔ�ID
            objTPLN_CARRY_QUE.FPRIORITY = intFPRIORITY                              '��ײ��è�敪
            objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID            '��گ�ID
            objTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN                 '�����敪
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON            '�����w����
            objTPLN_CARRY_QUE.FENTRY_DT = Now                                       '�o�^����
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '�X�V����
            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/27 �e�q�ݒ�
            objTPLN_CARRY_QUE.XOYAKO_KUBUN = strXOYAKO_KUBUN                        '�e�q�敪
            objTPLN_CARRY_QUE.XPALLET_ID_AITE = strXPALLET_ID_AITE                  '������گ�ID
            '������������************************************************************************************************************
            objTPLN_CARRY_QUE.ADD_TPLN_CARRY_QUE_ORDER()                            '�o�^


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��


        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

    '��I����
#Region "  ��I��������(�i�ږ��ɸڰݏ��Ԃ��L��)                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ��I��������(�i�ږ��ɸڰݏ��Ԃ��L��)
    ''' </summary>
    ''' <param name="objSYS_100201">��I�����׽</param>
    ''' <param name="objTPRG_TRK_BUF_ASRS_OYA">�q���ׯ�ݸ�(�e)</param>
    ''' <param name="objTPRG_TRK_BUF_ASRS_KOO">�q���ׯ�ݸ�(�q)</param>
    ''' <param name="objTPRG_TRK_BUF_FM">���ɂ��錳ST�ׯ�ݸ�</param>
    ''' <param name="strFPALLET_ID">���ɂ���݌ɏ�����گ�ID</param>
    ''' <param name="strFHINMEI_CD">���ɂ���݌ɏ��̕i������</param>
    ''' <param name="intFTRK_BUF_NO_ASRS">�ׯ�ݸ��ޯ̧��(�����q��)</param>
    ''' <param name="blnUpdate">�ڰݗD�揇�X�V�׸�</param>
    ''' <param name="blnPair">�߱�����׸�</param>
    ''' <param name="intXTANA_BLOCK">�I��ۯ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function AkitanaHikiate(ByRef objSYS_100201 As SVR_100201 _
                                 , ByRef objTPRG_TRK_BUF_ASRS_OYA As TBL_TPRG_TRK_BUF _
                                 , ByRef objTPRG_TRK_BUF_ASRS_KOO As TBL_TPRG_TRK_BUF _
                                 , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                                 , ByVal strFPALLET_ID As String _
                                 , ByVal strFHINMEI_CD As String _
                                 , ByVal intFTRK_BUF_NO_ASRS As Integer _
                                 , ByVal blnUpdate As Boolean _
                                 , ByVal blnPair As Boolean _
                                 , ByVal intXTANA_BLOCK As Nullable(Of Integer) _
                                 , ByVal blnHasuBlock As Boolean _
                                 ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        Dim strMsg As String
        Dim intRet As RetCode


        '************************************************
        '������ST���ׯ�ݸ��ޯ̧Ͻ�      �擾
        '************************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO
        objTMST_TRK.GET_TMST_TRK()


        '************************************************
        '�i��Ͻ�      �擾
        '************************************************
        Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
        objTMST_ITEM.FHINMEI_CD = strFHINMEI_CD
        objTMST_ITEM.GET_TMST_ITEM()
        '������������************************************************************************************************************
        'JobMate:A.Noto 2013/04/10 �I�`���ʂ̐ݒ�
        Dim intFRAC_FORM As Nullable(Of Integer) = Nothing
        If objTMST_ITEM.FRAC_FORM = FRAC_FORM_JHIGH_TANA Then intFRAC_FORM = objTMST_ITEM.FRAC_FORM
        '������������************************************************************************************************************


        '������������************************************************************************************************************
        'JobMate:A.Noto 2012/07/07 �ڰ݈��������ǉ�


        '************************************************
        '�݌ɏ��           �擾
        '************************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = strFPALLET_ID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)


        '************************************************
        '�ׯ�ݸޏ�        �擾
        '************************************************
        Dim objXSTS_TRK As New TBL_XSTS_TRK(Owner, ObjDb, ObjDbLog)
        objXSTS_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO    '�i�ں���
        objXSTS_TRK.GET_XSTS_TRK(True)                              '�擾


        '������������************************************************************************************************************


        '************************************************
        '�������ߓ���Ͻ�        �擾
        '************************************************
        Dim objTMST_SP_RES_TYPE As New TBL_TMST_SP_RES_TYPE(Owner, ObjDb, ObjDbLog)
        objTMST_SP_RES_TYPE.FCONDITION01 = objTMST_ITEM.XIN_RES_TYPE
        objTMST_SP_RES_TYPE.GET_TMST_SP_RES_TYPE()


        '������������************************************************************************************************************
        'JobMate:A.Noto 2012/07/07 �ڰ݈��������ǉ�

        '************************
        '�ڰ݂̓���
        '************************

        '������������************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/08 ��I�����ύX

        '' ''Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         '���ѕϐ��׽
        '' ''objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002                         '�ϐ�ID
        '' ''intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '�擾
        ' '' ''�i��Ͻ��̍ŏI�����ڰ�ID�ōX�V
        '' ''objTPRG_SYS_HEN.OBJCHANGE_DATA = objXSTS_TRK.XHIKIATE_CRANE_ID              '�ύX�ް�
        '' ''objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN_OBJ()                                   '�X�V

        Dim strFHENSU_ID As String

        Select Case TO_INTEGER(objTPRG_TRK_BUF_FM.FTRK_BUF_NO)
            Case 1000 To 1999
                strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
            Case 2000 To 2999
                strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
            Case 4000 To 4999
                strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
            Case 5000 To 5999
                strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
            Case Else
                strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
        End Select
        Dim objTPRG_SYS_HEN_WK As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)      '���ѕϐ��׽
        objTPRG_SYS_HEN_WK.FHENSU_ID = strFHENSU_ID                                 '�ϐ�ID
        intRet = objTPRG_SYS_HEN_WK.GET_TPRG_SYS_HEN(True)                          '�擾

        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         '���ѕϐ��׽
        objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002                         '�ϐ�ID
        intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '�擾
        '�i��Ͻ��̍ŏI�����ڰ�ID�ōX�V
        objTPRG_SYS_HEN.OBJCHANGE_DATA = objTPRG_SYS_HEN_WK.FHENSU_CHAR             '�ύX�ް�
        objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN_OBJ()                                   '�X�V

        'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
        '������������************************************************************************************************************

        '************************
        '�ڰݗD�揇�̍쐬
        '************************
        Dim strFEQ_ID_CRANE() As String
        objTPRG_SYS_HEN.FHENSU_CHAR = Nothing
        intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '�擾
        strFEQ_ID_CRANE = Split(objTPRG_SYS_HEN.FHENSU_CHAR, KUGIRI01)

        '������������************************************************************************************************************


        '************************
        '�q���ޯ̧�̓���
        '************************
        objSYS_100201.FTRK_BUF_NO = intFTRK_BUF_NO_ASRS                 '�ޯ̧��(�q��)
        'objSYS_100201.FRAC_FORM = objTMST_ITEM.FRAC_FORM               '�I�`����
        objSYS_100201.FRES_TYPE = objTMST_SP_RES_TYPE.FRES_TYPE         '��������
        objSYS_100201.FPALLET_ID = strFPALLET_ID                        '��گ�ID
        objSYS_100201.FEQ_ID_CRANE = strFEQ_ID_CRANE                    '���ڰݐݔ�ID
        objSYS_100201.blnUpdate = blnUpdate                             '�X�V�׸�
        objSYS_100201.FBUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO          '�������ׯ�ݸ��ޯ̧��
        objSYS_100201.FRAC_FORM = intFRAC_FORM                          '�I�`����
        objSYS_100201.blnPair = blnPair                                 '�߱�����׸�
        objSYS_100201.XTANA_BLOCK = intXTANA_BLOCK                      '�I��ۯ�
        intRet = objSYS_100201.FIND_PAIR_TANA_AKI                       '����
        'intRet = objSYS_100201.FIND_TANA_AKI                            '����
        If intRet = RetCode.NotFound Then
            '(������Ȃ��ꍇ)
            Return intRet
        End If
        '�e
        objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO = objSYS_100201.FTRK_BUF_NO                '�ޯ̧��
        objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_ARRAY = objSYS_100201.FTRK_BUF_ARRAY          '�z��
        objTPRG_TRK_BUF_ASRS_OYA.GET_TPRG_TRK_BUF()                                     '����
        '�q
        If blnPair = True Then
            objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_NO = objSYS_100201.FTRK_BUF_NO                '�ޯ̧��
            objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_ARRAY = objSYS_100201.FTRK_BUF_ARRAY_Pair     '�z��
            objTPRG_TRK_BUF_ASRS_KOO.GET_TPRG_TRK_BUF()                                     '����
        End If
        '۸ޏo��
        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                         "[��I����(�e):" & TO_STRING(objTPRG_TRK_BUF_ASRS_OYA.FDISP_ADDRESS) & "]" _
                       & "[��I����(�q):" & TO_STRING(objTPRG_TRK_BUF_ASRS_KOO.FDISP_ADDRESS) & "]" _
                         )
        If blnUpdate = False Then Return intRet


        '������������************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/21 ��I�����ύX
        ' '' ''************************************************************************************************
        ' '' ''************************************************************************************************
        ' '' ''�I��ۯ����            �X�V
        ' '' ''�ڰݗD�揇             �X�V
        ' '' ''************************************************************************************************
        ' '' ''************************************************************************************************
        '' ''If blnHasuBlock = False Then
        '' ''    '(�[���݌ɂ����݂��Ȃ� �ꍇ)


        '' ''    '************************************************
        '' ''    '�I��ۯ���Ԃ̍X�V
        '' ''    '************************************************
        '' ''    Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_ASRS_OYA, XTANA_BLOCK_STS_IN)


        '' ''Else
        '' ''    '(�[���݌ɂ����݂��� �ꍇ)

        '' ''    If TO_INTEGER(objTPRG_TRK_BUF_ASRS_OYA.FRAC_EDA) = FLAG_ON Then
        '' ''        '(���I�̏ꍇ)


        '' ''        '************************************************
        '' ''        '�ڰݗD�揇�̍X�V
        '' ''        '************************************************
        '' ''        '====================================
        '' ''        '�ڰ�Ͻ��̓���
        '' ''        '====================================
        '' ''        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             '�ڰ�Ͻ��׽
        '' ''        objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO            '�ޯ̧��
        '' ''        objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS_OYA.FRAC_RETU             '��
        '' ''        intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '����
        '' ''        If intRet = RetCode.NotFound Then
        '' ''            '(������Ȃ��ꍇ)
        '' ''            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
        '' ''            Throw New UserException(strMsg)
        '' ''        End If

        '' ''        '====================================
        '' ''        '�ڰݗD�揇�̍X�V
        '' ''        '====================================
        '' ''        Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)         '�ڰݗD�揇�X�V�׽
        '' ''        objSVR_100205.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO    '�ׯ�ݸ��ޯ̧No
        '' ''        objSVR_100205.FEQ_ID = objTMST_CRANE.FEQ_ID                         '�g�p�ݔ�ID
        '' ''        objSVR_100205.CRANE_ORDER_UPDATE()                                  '�X�V


        '' ''    End If

        '' ''End If


        '************************************************************************************************
        '************************************************************************************************
        '�I��ۯ����            �X�V
        '�ڰݗD�揇             �X�V
        '************************************************************************************************
        '************************************************************************************************
        If blnHasuBlock = False Then
            '(�[���݌ɂ����݂��Ȃ� �ꍇ)


            '************************************************
            '�I��ۯ���Ԃ̍X�V
            '************************************************
            Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_ASRS_OYA, XTANA_BLOCK_STS_IN)


        End If


        '�ڰݗD�揇�̍X�V
        If TO_INTEGER(objTPRG_TRK_BUF_ASRS_OYA.FRAC_EDA) = FLAG_ON Then
            '(���I�̏ꍇ)


            '************************************************
            '�ڰݗD�揇�̍X�V
            '************************************************
            '====================================
            '�ڰ�Ͻ��̓���
            '====================================
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             '�ڰ�Ͻ��׽
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO            '�ޯ̧��
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS_OYA.FRAC_RETU             '��
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If

            '====================================
            '�ڰݗD�揇�̍X�V
            '====================================
            Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)         '�ڰݗD�揇�X�V�׽
            objSVR_100205.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO    '�ׯ�ݸ��ޯ̧No
            objSVR_100205.FEQ_ID = objTMST_CRANE.FEQ_ID                         '�g�p�ݔ�ID
            objSVR_100205.CRANE_ORDER_UPDATE()                                  '�X�V


            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2013/12/02 ��I�����ύX
            Dim objTPRG_SYS_HEN_BEFORE2 As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog) '���ѕϐ��׽
            objTPRG_SYS_HEN_BEFORE2.FHENSU_ID = FHENSU_ID_SSS000000_002                 '�ϐ�ID
            intRet = objTPRG_SYS_HEN_BEFORE2.GET_TPRG_SYS_HEN(True)                     '�擾

            Dim objTPRG_SYS_HEN_AFTER2 As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)  '���ѕϐ��׽
            objTPRG_SYS_HEN_AFTER2.FHENSU_ID = strFHENSU_ID                             '�ϐ�ID
            intRet = objTPRG_SYS_HEN_AFTER2.GET_TPRG_SYS_HEN(True)                      '�擾
            objTPRG_SYS_HEN_AFTER2.OBJCHANGE_DATA = objTPRG_SYS_HEN_BEFORE2.FHENSU_CHAR '�ύX�ް�
            objTPRG_SYS_HEN_AFTER2.UPDATE_TPRG_SYS_HEN_OBJ()                            '�X�V
            'JobMate:S.Ouchi 2013/12/02 ��I�����ύX
            '������������************************************************************************************************************
        End If
        'JobMate:S.Ouchi 2013/11/21 ��I�����ύX
        '������������************************************************************************************************************



        '************************
        '�ڰ݂̓���
        '************************
        Dim objTPRG_SYS_HEN_BEFORE As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         '���ѕϐ��׽
        objTPRG_SYS_HEN_BEFORE.FHENSU_ID = FHENSU_ID_SSS000000_002                         '�ϐ�ID
        intRet = objTPRG_SYS_HEN_BEFORE.GET_TPRG_SYS_HEN(True)                             '�擾

        '************************
        '�i��Ͻ��X�V
        '************************
        objXSTS_TRK.XHIKIATE_CRANE_ID = objTPRG_SYS_HEN_BEFORE.FHENSU_CHAR
        objXSTS_TRK.UPDATE_XSTS_TRK()

        '������������************************************************************************************************************
        'JobMate:S.Ouchi 2013/12/02 ��I�����ύX
        ' '' ''������������************************************************************************************************************
        ' '' ''JobMate:S.Ouchi 2013/11/08 ��I�����ύX
        '' ''Dim objTPRG_SYS_HEN_AFTER As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)   '���ѕϐ��׽
        '' ''objTPRG_SYS_HEN_AFTER.FHENSU_ID = strFHENSU_ID                              '�ϐ�ID
        '' ''intRet = objTPRG_SYS_HEN_AFTER.GET_TPRG_SYS_HEN(True)                       '�擾
        '' ''objTPRG_SYS_HEN_AFTER.OBJCHANGE_DATA = objTPRG_SYS_HEN_BEFORE.FHENSU_CHAR   '�ύX�ް�
        '' ''objTPRG_SYS_HEN_AFTER.UPDATE_TPRG_SYS_HEN_OBJ()                             '�X�V
        ' '' ''JobMate:S.Ouchi 2013/11/08 ��I�����ύX
        ' '' ''������������************************************************************************************************************
        'JobMate:S.Ouchi 2013/12/02 ��I�����ύX
        '������������************************************************************************************************************

        Return intReturn
    End Function
#End Region


    '�o�׈���
#Region "  �o�׈�������(ٰ�)                                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׈�������(ٰ�)
    ''' </summary>
    ''' <param name="dtmXSYUKKA_D">�o�ד�</param>
    ''' <param name="strXHENSEI_NO_OYA">�e�Ґ�No.</param>
    ''' <param name="intSyukkaHikiateMode">�o�׈������̋敪</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateRoot(ByVal dtmXSYUKKA_D As Date _
                                    , ByVal strXHENSEI_NO_OYA As String _
                                    , ByVal intSyukkaHikiateMode As SyukkaHikiateMode _
                                    ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '****************************************
        '�����ݒ�
        '****************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
        Dim intOutSiziSameNum As Integer = objTPRG_SYS_HEN.SJ000000_001     '�����o�Ɏw����
        Dim intPointOutSiziSameNum As Integer = 1                           '�����o�Ɏw�����߲��
        Dim objOkuPalletIDList As New ArrayList                             '��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽ�
        Dim blnHikiate As Boolean = False                                   '�����׸�


        '************************************************************************************************
        '************************************************************************************************
        '�o��CV�A�����o�Ɏw����             �擾
        '************************************************************************************************
        '************************************************************************************************
        Dim intAryOutCV() As Integer = Nothing                              '�o��CV
        Dim intPointOutCV As Integer = 0                                    '�o��CV�߲��

        '=======================================
        '�o�׎w��           �擾
        '=======================================
        Dim objXPLN_OUT_Berth As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objXPLN_OUT_Berth.XSYUKKA_D = dtmXSYUKKA_D            '�o�ד�
        objXPLN_OUT_Berth.XHENSEI_NO = strXHENSEI_NO_OYA      '�Ґ�No.
        objXPLN_OUT_Berth.GET_XPLN_OUT_ANY()                  '�擾

        '=======================================
        '�o���ް���           �擾
        '=======================================
        Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
        objXSTS_BERTH.XBERTH_NO = objXPLN_OUT_Berth.ARYME(0).XBERTH_NO    '�ް���
        objXSTS_BERTH.GET_XSTS_BERTH()                              '�擾

        '=======================================
        '�o��CV�z��                   �擾
        '=======================================
        Call GetintAryOutCV(intAryOutCV, objXSTS_BERTH.XBERTH_GROUP)
        ''=======================================
        ''�o���ް���           �擾
        ''=======================================
        'Dim objAryXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
        'objAryXSTS_CONVEYOR.XBERTH_GROUP = objXSTS_BERTH.XBERTH_GROUP      '�ް���ٰ��
        'objAryXSTS_CONVEYOR.ORDER_BY = " XSTNO "                           '����
        'intRet = objAryXSTS_CONVEYOR.GET_XSTS_CONVEYOR_ANY()               '�擾
        'If intRet = RetCode.OK Then
        '    '(���������ꍇ)
        '    ReDim intAryOutCV(UBound(objAryXSTS_CONVEYOR.ARYME))
        '    For ii As Integer = 0 To UBound(objAryXSTS_CONVEYOR.ARYME)
        '        '(ٰ��:�o��CV��)
        '        intAryOutCV(ii) = objAryXSTS_CONVEYOR.ARYME(ii).XSTNO
        '    Next
        'Else
        '    '(������Ȃ������ꍇ)
        '    Throw New Exception(ERRMSG_NOTFOUND_XSTS_CONVEYOR & "[�ް���ٰ��:" & TO_STRING(objAryXSTS_CONVEYOR.XBERTH_GROUP) & "]")
        'End If


        '************************************************************************************************
        '************************************************************************************************
        '�o�׌v��           �擾
        '************************************************************************************************
        '************************************************************************************************
        '****************************************
        '�o�׎w���ڍ�               �擾
        '****************************************
        Dim objAryXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT_DTL.XSYUKKA_D = dtmXSYUKKA_D                 '�o�ד�
        objAryXPLN_OUT_DTL.XHENSEI_NO_OYA = strXHENSEI_NO_OYA       '�e�Ґ�No.
        objAryXPLN_OUT_DTL.WHERE = " AND XSYUKKA_KON_RESERVE < XSYUKKA_KON_PLAN "      '�ǉ�����
        'objAryXPLN_OUT_DTL.WHERE = " AND XSYUKKA_STS_DTL IN (" & XSYUKKA_STS_DTL_JNON & ", " & XSYUKKA_STS_DTL_JLESS & ")"      '�ǉ�����
        objAryXPLN_OUT_DTL.ORDER_BY = " XOUT_ORDER, FHINMEI_CD, XHENSEI_NO"     '����
        intRet = objAryXPLN_OUT_DTL.GET_XPLN_OUT_DTL_ANY()          '�擾
        If intRet <> RetCode.OK Then
            '(������Ȃ������ꍇ)
            If intSyukkaHikiateMode <> SyukkaHikiateMode.Loader02 Then
                '(�ׯ�۰��2��ڂ̏ꍇ�́A�S�ďo�׈�������Ă���ƁAں��ނ�������Ȃ��ꍇ�������)
                Throw New Exception("�����\��" & ERRMSG_NOTFOUND_XPLN_OUT_DTL & "[�o�ד�:" & Format(objAryXPLN_OUT_DTL.XSYUKKA_D, DATE_FORMAT_03) & "][�e�Ґ���" & objAryXPLN_OUT_DTL.XHENSEI_NO_OYA & "]")
            End If
        Else
            '(���������ꍇ)


            For Each objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL In objAryXPLN_OUT_DTL.ARYME
                '(ٰ��:�擾����ں��ސ�)


                '********************************************************************************
                '��������
                '********************************************************************************
                If intSyukkaHikiateMode = SyukkaHikiateMode.Loader01 Or intSyukkaHikiateMode = SyukkaHikiateMode.Loader02 Then
                    If objXPLN_OUT_DTL.FSAGYOU_KIND <> FSAGYOU_KIND_J57 Then Throw New Exception("�������Ԉ���Ă��܂��B[�o�ד�:" & Format(dtmXSYUKKA_D, DATE_FORMAT_03) & "][�e�Ґ���" & strXHENSEI_NO_OYA & "][�o�׈������̋敪:" & TO_STRING(intSyukkaHikiateMode) & "]")
                End If


                '********************************************************************************
                'ۯć��z��                  �擾
                '********************************************************************************
                Dim strAryFLOT_NO_FIN_KUBUN_J04() As String = Nothing        'ۯć��z��(���߂�i)
                Dim strAryFLOT_NO_FIN_KUBUN_J06() As String = Nothing        'ۯć��z��(�ē��ɕi)
                Dim strAryFLOT_NO_FIN_KUBUN_J02() As String = Nothing        'ۯć��z��(���וi(�O�����Y�i))
                Dim strAryFLOT_NO_All() As String = Nothing                 'ۯć��z��(�S��)
                intRet = SyukkaHikiateGetAryFLOT_NO(strAryFLOT_NO_FIN_KUBUN_J04, objXPLN_OUT_DTL.FHINMEI_CD, FIN_KUBUN_J04)
                intRet = SyukkaHikiateGetAryFLOT_NO(strAryFLOT_NO_FIN_KUBUN_J06, objXPLN_OUT_DTL.FHINMEI_CD, FIN_KUBUN_J06)
                intRet = SyukkaHikiateGetAryFLOT_NO(strAryFLOT_NO_FIN_KUBUN_J02, objXPLN_OUT_DTL.FHINMEI_CD, FIN_KUBUN_J02)
                intRet = SyukkaHikiateGetAryFLOT_NO(strAryFLOT_NO_All, objXPLN_OUT_DTL.FHINMEI_CD, Nothing)
                If intRet <> RetCode.OK Then
                    '(������Ȃ������ꍇ)

                    '====================================
                    '�o�׏󋵏ڍ�       �X�V
                    '====================================
                    objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JLESS     '�o�׏󋵏ڍ�
                    objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                       '�X�V

                    '====================================
                    'ү���ޗ���         �ǉ�
                    '====================================
                    Call AddToMsgLog(Now, FMSG_ID_S0101, "[�i�ں���:" & objXPLN_OUT_DTL.FHINMEI_CD & "]" _
                                                       & "[�o�ד�:" & objXPLN_OUT_DTL.XSYUKKA_D & "]" _
                                                       & "[�Ґ���:" & objXPLN_OUT_DTL.XHENSEI_NO & "]" _
                                                       & "[�`�[��:" & objXPLN_OUT_DTL.XDENPYOU_NO & "]" _
                                                       , "ۯć��z��擾���ɔ���")
                    Continue For
                End If


                '********************************************************************************
                '�o�׎w��           �擾
                '********************************************************************************
                Dim objXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                objXPLN_OUT.XSYUKKA_D = objXPLN_OUT_DTL.XSYUKKA_D           '�o�ד�
                objXPLN_OUT.XHENSEI_NO = objXPLN_OUT_DTL.XHENSEI_NO         '�Ґ�No.
                objXPLN_OUT.XDENPYOU_NO = objXPLN_OUT_DTL.XDENPYOU_NO       '�`�[No.
                objXPLN_OUT.GET_XPLN_OUT()                                  '�擾


                '********************************************************************************
                '���̑��K�v�ȏ����擾
                '********************************************************************************
                '=======================================
                '�i��Ͻ�                �擾
                '=======================================
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objXPLN_OUT_DTL.FHINMEI_CD            '�i�ں���
                objTMST_ITEM.GET_TMST_ITEM()                                    '�擾


                '********************************************************************************
                '�������ʂ��擾
                '********************************************************************************
                Dim decHikiateNum As Decimal = TO_DECIMAL(objXPLN_OUT_DTL.XSYUKKA_KON_PLAN) - TO_DECIMAL(objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE)   '�o�ח\�荫��
                If intSyukkaHikiateMode = SyukkaHikiateMode.Loader01 Then
                    '(�ׯ�۰��1��ڂ̏ꍇ)
                    '(�߱�����\�ȕ����������ĂāA�c��͌�ł����������Ă�)
                    decHikiateNum = decHikiateNum - (decHikiateNum Mod (objTMST_ITEM.FNUM_IN_PALLET * 2))
                End If
                Dim decSaveHikiateNum As Decimal = decHikiateNum            '�ꎞ�ۑ�


                '********************************************************************************
                '����&�R���x�����t����
                '(���ɋ敪�F�����߂�i)
                '********************************************************************************
                If IsNotNull(strAryFLOT_NO_FIN_KUBUN_J04) Then
                    If 0 < decHikiateNum Then
                        While True
                            '(ٰ��:�o�ח\�荫���𖞂����܂ŁA�����Ă�)

                            For Each strFLOT_NO As String In strAryFLOT_NO_FIN_KUBUN_J04
                                '(ٰ��:ۯć���)

                                intRet = SyukkaHikiateCVWarituke(TO_STRING(FIN_KUBUN_J04) _
                                                               , decHikiateNum _
                                                               , strFLOT_NO _
                                                               , intAryOutCV _
                                                               , intPointOutCV _
                                                               , intPointOutSiziSameNum _
                                                               , intOutSiziSameNum _
                                                               , objXPLN_OUT _
                                                               , objXPLN_OUT_DTL _
                                                               , objTMST_ITEM _
                                                               , intSyukkaHikiateMode _
                                                               , objOkuPalletIDList _
                                                               )
                                '�E�o
                                If intRet = RetCode.OK Then Exit For
                                If decHikiateNum <= 0 Then Exit For

                            Next

                            '�E�o
                            If intRet <> RetCode.OK Then Exit While
                            If decHikiateNum <= 0 Then Exit While

                        End While
                    End If
                End If


                '********************************************************************************
                '����&�R���x�����t����
                '(���ɋ敪�F�ē��ɕi)
                '********************************************************************************
                If IsNotNull(strAryFLOT_NO_FIN_KUBUN_J06) Then
                    If 0 < decHikiateNum Then
                        While True
                            '(ٰ��:�o�ח\�荫���𖞂����܂ŁA�����Ă�)

                            For Each strFLOT_NO As String In strAryFLOT_NO_FIN_KUBUN_J06
                                '(ٰ��:ۯć���)

                                intRet = SyukkaHikiateCVWarituke(TO_STRING(FIN_KUBUN_J06) _
                                                               , decHikiateNum _
                                                               , strFLOT_NO _
                                                               , intAryOutCV _
                                                               , intPointOutCV _
                                                               , intPointOutSiziSameNum _
                                                               , intOutSiziSameNum _
                                                               , objXPLN_OUT _
                                                               , objXPLN_OUT_DTL _
                                                               , objTMST_ITEM _
                                                               , intSyukkaHikiateMode _
                                                               , objOkuPalletIDList _
                                                               )
                                '�E�o
                                If intRet = RetCode.OK Then Exit For
                                If decHikiateNum <= 0 Then Exit For

                            Next

                            '�E�o
                            If intRet <> RetCode.OK Then Exit While
                            If decHikiateNum <= 0 Then Exit While

                        End While
                    End If
                End If


                '********************************************************************************
                '����&�R���x�����t����
                '(���ɋ敪�F�O�����Y�i)
                '********************************************************************************
                If IsNotNull(strAryFLOT_NO_FIN_KUBUN_J02) Then
                    If 0 < decHikiateNum Then
                        While True
                            '(ٰ��:�o�ח\�荫���𖞂����܂ŁA�����Ă�)

                            For Each strFLOT_NO As String In strAryFLOT_NO_FIN_KUBUN_J02
                                '(ٰ��:ۯć���)

                                intRet = SyukkaHikiateCVWarituke(TO_STRING(FIN_KUBUN_J02) _
                                                               , decHikiateNum _
                                                               , strFLOT_NO _
                                                               , intAryOutCV _
                                                               , intPointOutCV _
                                                               , intPointOutSiziSameNum _
                                                               , intOutSiziSameNum _
                                                               , objXPLN_OUT _
                                                               , objXPLN_OUT_DTL _
                                                               , objTMST_ITEM _
                                                               , intSyukkaHikiateMode _
                                                               , objOkuPalletIDList _
                                                               )
                                '�E�o
                                If intRet = RetCode.OK Then Exit For
                                If decHikiateNum <= 0 Then Exit For

                            Next

                            '�E�o
                            If intRet <> RetCode.OK Then Exit While
                            If decHikiateNum <= 0 Then Exit While

                        End While
                    End If
                End If


                '********************************************************************************
                '����&�R���x�����t����
                '(���ɋ敪�F�Ȃ�)
                '********************************************************************************
                If 0 < decHikiateNum Then
                    While True
                        '(ٰ��:�o�ח\�荫���𖞂����܂ŁA�����Ă�)

                        For Each strFLOT_NO As String In strAryFLOT_NO_All
                            '(ٰ��:ۯć���)

                            intRet = SyukkaHikiateCVWarituke("" _
                                                           , decHikiateNum _
                                                           , strFLOT_NO _
                                                           , intAryOutCV _
                                                           , intPointOutCV _
                                                           , intPointOutSiziSameNum _
                                                           , intOutSiziSameNum _
                                                           , objXPLN_OUT _
                                                           , objXPLN_OUT_DTL _
                                                           , objTMST_ITEM _
                                                           , intSyukkaHikiateMode _
                                                           , objOkuPalletIDList _
                                                           )
                            '�E�o
                            If intRet = RetCode.OK Then Exit For
                            If decHikiateNum <= 0 Then Exit For

                        Next

                        '�E�o
                        If intRet <> RetCode.OK Then Exit While
                        If decHikiateNum <= 0 Then Exit While

                    End While
                End If


                '********************************************************************************
                '�o�׈�������           �X�V
                '********************************************************************************
                With objXPLN_OUT_DTL
                    .XSYUKKA_KON_RESERVE = .XSYUKKA_KON_RESERVE + (decSaveHikiateNum - decHikiateNum)
                End With
                If decHikiateNum < decSaveHikiateNum Then blnHikiate = True
                If objXPLN_OUT_DTL.XSYUKKA_KON_PLAN <= objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE Then
                    'If decHikiateNum <= 0 Then
                    '(�o�׎w�����튮���̏ꍇ)

                    '====================================
                    '�o�׏󋵏ڍ�       �X�V
                    '====================================
                    '(���̑�)
                    If objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JNON Or objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JLESS Then
                        '(���u���őS�Ĉ������Ă�ꍇ������̂ŁA���̑Ή�)
                        objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JSTART        '�o�׏󋵏ڍ�
                    End If
                    objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                           '�X�V

                Else
                    '(���i�̏ꍇ)

                    If intSyukkaHikiateMode <> SyukkaHikiateMode.Loader01 Then
                        '(�ׯ�۰��1��ڂ̏ꍇ�͌��i�Ƃ��Ȃ�)

                        '====================================
                        '�o�׏󋵏ڍ�       �X�V
                        '====================================
                        objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JLESS         '�o�׏󋵏ڍ�
                        objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                           '�X�V

                        '====================================
                        'ү���ޗ���         �ǉ�
                        '====================================
                        Call AddToMsgLog(Now, FMSG_ID_S0101, "[�i�ں���:" & objXPLN_OUT_DTL.FHINMEI_CD & "]" _
                                                           & "[�o�ד�:" & objXPLN_OUT_DTL.XSYUKKA_D & "]" _
                                                           & "[�Ґ���:" & objXPLN_OUT_DTL.XHENSEI_NO & "]" _
                                                           & "[�`�[��:" & objXPLN_OUT_DTL.XDENPYOU_NO & "]" _
                                                           , "���ʌ��i" _
                                                           )
                        intReturn = RetCode.NotFound
                        Continue For

                    Else
                        '(�ׯ�۰��1��ڂ̏ꍇ)
                        objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                           '�X�V
                    End If

                End If


            Next


        End If


        '****************************************
        '�o�׎w���ڍ�           �擾
        '****************************************
        Dim blnLESS As Boolean = False          '���i�׸�
        Dim objAryXPLN_OUT_DTL_Check As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT_DTL_Check.XSYUKKA_D = dtmXSYUKKA_D                 '�o�ד�
        objAryXPLN_OUT_DTL_Check.XHENSEI_NO = strXHENSEI_NO_OYA           '�e�Ґ�No.
        intRet = objAryXPLN_OUT_DTL_Check.GET_XPLN_OUT_DTL_ANY()          '�擾
        If intRet = RetCode.OK Then
            '(���������ꍇ)
            For Each objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL In objAryXPLN_OUT_DTL_Check.ARYME
                '(ٰ��:�擾����ں��ސ�)
                If objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JLESS Then blnLESS = True : Exit For
            Next
        End If


        '****************************************
        '�o�׎w��           �擾
        '****************************************
        Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT.XSYUKKA_D = dtmXSYUKKA_D             '�o�ד�
        objAryXPLN_OUT.XHENSEI_NO_OYA = strXHENSEI_NO_OYA   '�e�Ґ�No.
        intRet = objAryXPLN_OUT.GET_XPLN_OUT_ANY()          '�擾
        If intRet = RetCode.OK Then
            '(���������ꍇ)
            For Each objXPLN_OUT As TBL_XPLN_OUT In objAryXPLN_OUT.ARYME
                '(ٰ��:�擾����ں��ސ�)


                '****************************************
                '�o�׎w��                       �X�V
                '****************************************
                If TO_INTEGER(objXPLN_OUT.XSYUKKA_STS) = XSYUKKA_STS_JRDY Or TO_INTEGER(objXPLN_OUT.XSYUKKA_STS) = XSYUKKA_STS_JLESS Then
                    '(�����\ or ���i�̏ꍇ)

                    If blnLESS = True Then
                        objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JLESS     '�o�׏�
                    Else
                        objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JRSV      '�o�׏�
                    End If

                    If IsNull(objXPLN_OUT.XOUT_START_DT) Then
                        '(Null�̏ꍇ)
                        objXPLN_OUT.XOUT_START_DT = Now                 '�o�ɊJ�n����
                    End If

                    If intSyukkaHikiateMode <> SyukkaHikiateMode.Loader01 _
                       Or (intSyukkaHikiateMode = SyukkaHikiateMode.Loader01 And objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JLESS) _
                       Then
                        '(    �ׯ�۰��1��ڈȊO         �̏ꍇ)
                        '( or �ׯ�۰��1��ڂ����i     �̏ꍇ)
                        objXPLN_OUT.UPDATE_XPLN_OUT()                   '�X�V
                    End If


                End If


            Next
        End If


        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        If blnHikiate = True Then
            '(�����ĂĂ����ꍇ)


            '****************************************
            '���q�ԍ��\��           �X�V
            '�Ґ����\��             �X�V
            '****************************************
            Call objSVR_190001.SendYasukawa_IDDispSyaban(objXSTS_BERTH.XBERTH_GROUP, objAryXPLN_OUT.ARYME(0).XSYARYOU_NO)
            Call objSVR_190001.SendYasukawa_IDDispHensei(objXSTS_BERTH.XBERTH_GROUP, objAryXPLN_OUT_DTL.ARYME(0).XHENSEI_NO_OYA)


            '****************************************
            '�߯�ݸ�ؽĈ󎚏o��
            '****************************************
            If intSyukkaHikiateMode = SyukkaHikiateMode.Bara Or intSyukkaHikiateMode = SyukkaHikiateMode.Pallet Then
                '(��� or ��گ� �̏ꍇ)

                Call objSVR_190001.SendOther_IDOther(FCOMMAND_ID_JPRINT_PICK, Format(dtmXSYUKKA_D, DATE_FORMAT_02), strXHENSEI_NO_OYA)
                'Call PrintPickingList(dtmXSYUKKA_D, strXHENSEI_NO_OYA)
                'Call Shell(objTPRG_SYS_HEN.SJ000000_024 _
                '           & " " & CMD_STRING01_PRINT _
                '           & " " & Format(dtmXSYUKKA_D, DATE_FORMAT_02) _
                '           & " " & strXHENSEI_NO_OYA _
                '           , AppWinStyle.NormalFocus _
                '           )

            End If


        End If


        '****************************************
        '�o�׈�������(�ׯ�۰�ނ̗\�萔����)
        '****************************************
        Call SyukkaHikiateSetYoteiLoader(dtmXSYUKKA_D _
                                       , strXHENSEI_NO_OYA _
                                       , intSyukkaHikiateMode _
                                       , intAryOutCV(0) _
                                       )


        '****************************************
        '���q���۰�   �\���Տo��
        '****************************************
        Call objSVR_190001.SendCar_IDJS_CARD02()


        ''****************************************
        ''Melsec       ۰�ްӰ��     ����
        ''****************************************
        'Call objSVR_190001.SendYasukawa_IDLoaderMode(objXSTS_BERTH.XBERTH_GROUP _
        '                                           , objAryXPLN_OUT.ARYME(0).XSYARYOU_NO _
        '                                           , intSyukkaHikiateMode _
        '                                           )


        Return intReturn
    End Function
#End Region
#Region "  �o�׈�������(���� �� ����Ԋ��t����)                                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׈�������(���� �� ����Ԋ��t����)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">���ɋ敪</param>
    ''' <param name="decHikiateNum">��������</param>
    ''' <param name="strFLOT_NO">ۯć�</param>
    ''' <param name="intAryOutCV">�o��CV</param>
    ''' <param name="intPointOutCV">�o��CV�߲��</param>
    ''' <param name="intPointOutSiziSameNum">�����o�Ɏw�����߲��</param>
    ''' <param name="intOutSiziSameNum">�����o�Ɏw����</param>
    ''' <param name="objXPLN_OUT">�o�׎w��</param>
    ''' <param name="objXPLN_OUT_DTL">�o�׎w���ڍ�</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="intSyukkaHikiateMode">�o�׈������̋敪</param>
    ''' <param name="objOkuPalletIDList">��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateCVWarituke(ByVal strFIN_KUBUN As String _
                                          , ByRef decHikiateNum As Decimal _
                                          , ByVal strFLOT_NO As String _
                                          , ByRef intAryOutCV() As Integer _
                                          , ByRef intPointOutCV As String _
                                          , ByRef intPointOutSiziSameNum As String _
                                          , ByVal intOutSiziSameNum As String _
                                          , ByVal objXPLN_OUT As TBL_XPLN_OUT _
                                          , ByVal objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL _
                                          , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                          , ByVal intSyukkaHikiateMode As SyukkaHikiateMode _
                                          , ByRef objOkuPalletIDList As ArrayList _
                                          ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************
        '�����ݒ�
        '************************************************
        Dim strAryFinalPALLET_ID() As String = Nothing      '�ŏI������گ�ID�z��


        '************************************************************************************************************************************************
        '************************************************************************************************************************************************
        '��������
        '************************************************************************************************************************************************
        '************************************************************************************************************************************************
        If objXPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_J57 Then
            '(�ׯ�۰�ނ̏ꍇ)

            If intPointOutCV = 0 And (objTMST_ITEM.FNUM_IN_PALLET * 2) <= decHikiateNum Then
                '(1�ڂ̺���Ԃ������ꍇ)


                '************************************************
                '�o�׈�������(�߱����گďo�׈�������)
                '************************************************
                intRet = SyukkaHikiatePairFull(strFIN_KUBUN _
                                             , objTMST_ITEM _
                                             , strAryFinalPALLET_ID _
                                             , "" _
                                             , objXPLN_OUT_DTL _
                                             , False _
                                             , objOkuPalletIDList _
                                             )


            Else
                '(����Ԃ��i��ł��܂��Ă����ꍇ)


                '************************************************
                '�o�׈�������(�ݸ������گďo�׈�������)
                '************************************************
                intRet = SyukkaHikiateSingleFull(strFIN_KUBUN _
                                               , objTMST_ITEM _
                                               , strAryFinalPALLET_ID _
                                               , "" _
                                               , objXPLN_OUT_DTL _
                                               , False _
                                               , objOkuPalletIDList _
                                               )


            End If


        Else
            '(���̑�)


            Dim intBaraRet As RetCode = RetCode.NG
            '***************************************************************************************
            '�[���̏ꍇ �́A���u���D��ɂ���ꍇ�̏���

            If ( _
                   (decHikiateNum < (objTMST_ITEM.FNUM_IN_PALLET * 2)) _
               And ((decHikiateNum Mod objTMST_ITEM.FNUM_IN_PALLET) <> 0) _
               ) _
               Then
                '(�[���o�ׂ̏ꍇ)

                '***************************************************************************************

                '***************************************************************************************
                '�[���̏ꍇ or ��׏o�ɂ̏ꍇ �́A���u���D��ɂ���ꍇ�̏���

                ''If ( _
                ''       (decHikiateNum < (objTMST_ITEM.FNUM_IN_PALLET * 2)) _
                ''   And ((decHikiateNum Mod objTMST_ITEM.FNUM_IN_PALLET) <> 0) _
                ''   ) _
                ''   Or _
                ''   ( _
                ''   intSyukkaHikiateMode = SyukkaHikiateMode.Bara _
                ''   ) _
                ''   Then
                ' ''(�[���o�ׂ̏ꍇ)

                '***************************************************************************************


                '************************************************
                '�o�׈�������(�[���o�׈�������)
                '************************************************
                intBaraRet = SyukkaHikiateHasu(strFIN_KUBUN _
                                             , objTMST_ITEM _
                                             , strAryFinalPALLET_ID _
                                             , strFLOT_NO _
                                             , objXPLN_OUT_DTL _
                                             , objOkuPalletIDList _
                                             )
                intRet = intBaraRet


            End If
            If intBaraRet <> RetCode.OK Then
                '(��׏o�ׂō݌ɂ������ĂĂ��Ȃ��ꍇ)


                '************************************************
                '�����o�Ɏw�����߲��            ����
                '************************************************
                If intPointOutSiziSameNum < intOutSiziSameNum _
                   And objTMST_ITEM.FNUM_IN_PALLET < decHikiateNum _
                   Then
                    '(�߲��1or2or3���A�c�萔�ʂ�1PL���̏ꍇ)


                    '************************************************
                    '�o�׈�������(�߱����گďo�׈�������)
                    '************************************************
                    intRet = SyukkaHikiatePairFull(strFIN_KUBUN _
                                                 , objTMST_ITEM _
                                                 , strAryFinalPALLET_ID _
                                                 , strFLOT_NO _
                                                 , objXPLN_OUT_DTL _
                                                 , True _
                                                 , objOkuPalletIDList _
                                                 )


                Else
                    '(���̑�)


                    '************************************************
                    '�o�׈�������(�ݸ������گďo�׈�������)
                    '************************************************
                    intRet = SyukkaHikiateSingleFull(strFIN_KUBUN _
                                                   , objTMST_ITEM _
                                                   , strAryFinalPALLET_ID _
                                                   , strFLOT_NO _
                                                   , objXPLN_OUT_DTL _
                                                   , True _
                                                   , objOkuPalletIDList _
                                                   )


                End If


            End If


        End If
        If intRet <> RetCode.OK Then
            '(������Ȃ������ꍇ)
            Return intRet
        End If


        '************************************************************************************************************************************************
        '************************************************************************************************************************************************
        '�o�ɏ���
        '************************************************************************************************************************************************
        '************************************************************************************************************************************************
        ReDim Preserve strAryFinalPALLET_ID(1)          '�ŏI������گ�ID�z��(�v�f�������킹��)
        For ii As Integer = 1 To 2
            '(ٰ��:�߱����)


            '************************************
            '��Ǝ��       �ݒ�
            '************************************
            Dim intXOYAKO_KUBUN As Integer          '�e�q�敪
            Dim strFPALLET_ID As String = ""        '�o����گ�ID
            Dim strXPALLET_ID_AITE As String = ""   '������گ�ID
            If ii = 1 Then
                '(1PL�ڂ̏ꍇ)
                intXOYAKO_KUBUN = XOYAKO_KUBUN_JOYA                     '�e�q�敪
                strFPALLET_ID = strAryFinalPALLET_ID(0)                 '�o����گ�ID
                strXPALLET_ID_AITE = strAryFinalPALLET_ID(1)            '������گ�ID
            ElseIf ii = 2 Then
                '(2PL�ڂ̏ꍇ)
                If IsNotNull(strAryFinalPALLET_ID(1)) Then
                    '(�q�̏o�ɂ�����ꍇ)
                    intXOYAKO_KUBUN = XOYAKO_KUBUN_JKO                  '�e�q�敪
                    strFPALLET_ID = strAryFinalPALLET_ID(1)             '�o����گ�ID
                    strXPALLET_ID_AITE = strAryFinalPALLET_ID(0)        '������گ�ID
                Else
                    '(�q�̏o�ɂ��Ȃ��ꍇ)
                    Exit For
                End If
            End If


            '************************************
            '�݌ɏ��               �擾
            '************************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            objTRST_STOCK.FPALLET_ID = strFPALLET_ID        '��گ�ID
            objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)       '�擾


            '************************************
            '�ׯ�ݸ��ޯ̧           �擾
            '************************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF.FPALLET_ID = strFPALLET_ID      '��گ�ID
            objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()              '�擾


            '************************************
            '��������               �v�Z
            '************************************
            Dim decTempNum As Decimal = 0
            If objTRST_STOCK.ARYME(0).FTR_VOL <= decHikiateNum Then
                '(��PL�����̏ꍇ)
                decTempNum = objTRST_STOCK.ARYME(0).FTR_VOL
            Else
                '(�[�������̏ꍇ)
                decTempNum = decHikiateNum
            End If
            '===============================================
            '��������                   �X�V
            '===============================================
            decHikiateNum = decHikiateNum - decTempNum


            If objTPRG_TRK_BUF.FTRK_BUF_NO = FTRK_BUF_NO_J9000 Then
                '(�����q�ɂ̏ꍇ)


                '************************************************************************************************************************************************
                '************************************************************************************************************************************************
                '�����q��               �o�Ɉ���
                '************************************************************************************************************************************************
                '************************************************************************************************************************************************
                '************************************
                '�o���ׯ�ݸޒ�`�׽(��گ�ID�w��)
                '************************************
                Dim objSVR_100501 As New SVR_100501(Owner, ObjDb, ObjDbLog)
                objSVR_100501.FTRK_BUF_NO_TO = intAryOutCV(intPointOutCV)                   '�ׯ�ݸ��ޯ̧��(�o�ɐ��ׯ�ݸ�)
                objSVR_100501.FPALLET_ID = strFPALLET_ID                                    '��گ�ID
                objSVR_100501.FSAGYOU_KIND = objXPLN_OUT_DTL.FSAGYOU_KIND                   '��Ǝ��
                objSVR_100501.FTERM_ID = FTERM_ID_SKOTEI                                    '�[��ID
                objSVR_100501.FUSER_ID = FUSER_ID_SKOTEI                                    'հ�ްID
                objSVR_100501.FPLAN_KEY = objXPLN_OUT_DTL.FPLAN_KEY                         '�v�淰
                If intSyukkaHikiateMode = SyukkaHikiateMode.Loader02 Then
                    objSVR_100501.FPRIORITY = FPRIORITY_JLOW_MORE01                         '�D������
                End If
                objSVR_100501.UPDATE_OUT_BUF_Syukka(decTempNum)                             '��`


                '************************
                '�����w��QUE�̓���
                '************************
                Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)         '�����w��QUE
                objTPLN_CARRY_QUE.FPALLET_ID = strFPALLET_ID                                    '��گ�ID
                objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                          '����


                '************************
                '�����w��QUE�̍X�V
                '************************
                objTPLN_CARRY_QUE.XOYAKO_KUBUN = intXOYAKO_KUBUN            '�e�q�敪
                objTPLN_CARRY_QUE.XPALLET_ID_AITE = strXPALLET_ID_AITE      '������گ�ID
                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                   '�X�V


                '************************************************************************
                '�����o�Ɏw�����߲��        �X�V
                '�o��CV�߲��                �X�V
                '************************************************************************
                If objXPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_J57 Then
                    '(�ׯ�۰�ނ̏ꍇ)

                    If IsNull(strXPALLET_ID_AITE) Then
                        '(�ݸ�ُo�ɂ̏ꍇ)

                        '�o��CV�߲��                �X�V
                        If UBound(intAryOutCV) <= intPointOutCV Then intPointOutCV = 0 Else intPointOutCV += 1

                    End If


                Else
                    '(���̑�)

                    If intOutSiziSameNum <= intPointOutSiziSameNum Then
                        '(����Ԉ�t�̏ꍇ)

                        '�����o�Ɏw�����߲��        �X�V
                        intPointOutSiziSameNum = 1
                        '�o��CV�߲��                �X�V
                        If UBound(intAryOutCV) <= intPointOutCV Then intPointOutCV = 0 Else intPointOutCV += 1

                    Else
                        intPointOutSiziSameNum += 1
                    End If

                End If


            Else


                '************************************************************************************************************************************************
                '************************************************************************************************************************************************
                '���u��                 �o�Ɉ���
                '************************************************************************************************************************************************
                '************************************************************************************************************************************************
                '*****************************************************
                '�o�׎w���A�o�׎w���ڍׁA�o�Ɏ��яڍ�  �̒ǉ��X�V
                '*****************************************************
                Call SyukkaHikiateHiraokiUpdate(objTRST_STOCK _
                                              , objTMST_ITEM _
                                              , objXPLN_OUT_DTL.FPLAN_KEY _
                                              , decTempNum _
                                              , objTPRG_TRK_BUF.FTRK_BUF_NO _
                                              , objTPRG_TRK_BUF.FTRK_BUF_ARRAY _
                                              , objTPRG_TRK_BUF.FTRK_BUF_NO _
                                              , objTPRG_TRK_BUF.FTRK_BUF_ARRAY _
                                              , True _
                                              )
                '�X�V����Ă���̂ŁA�Ď擾
                Dim dtmXSYUKKA_D_Temp As Date = objXPLN_OUT.XSYUKKA_D           '�o�ד�
                Dim strXHENSEI_NO_Temp As String = objXPLN_OUT.XHENSEI_NO       '�Ґ�No.
                Dim strXDENPYOU_NO_Temp As String = objXPLN_OUT.XDENPYOU_NO     '�`�[No.
                Dim strFHINMEI_CD_Temp As String = objXPLN_OUT_DTL.FHINMEI_CD   '�i�ں���
                '�o�׎w��
                objXPLN_OUT.CLEAR_PROPERTY()
                objXPLN_OUT.XSYUKKA_D = dtmXSYUKKA_D_Temp                       '�o�ד�
                objXPLN_OUT.XHENSEI_NO = strXHENSEI_NO_Temp                     '�Ґ�No.
                objXPLN_OUT.XDENPYOU_NO = strXDENPYOU_NO_Temp                   '�`�[No.
                objXPLN_OUT.GET_XPLN_OUT()                                      '�擾
                '�o�׎w���ڍ�
                objXPLN_OUT_DTL.CLEAR_PROPERTY()
                objXPLN_OUT_DTL.XSYUKKA_D = dtmXSYUKKA_D_Temp                   '�o�ד�
                objXPLN_OUT_DTL.XHENSEI_NO = strXHENSEI_NO_Temp                 '�Ґ�No.
                objXPLN_OUT_DTL.FHINMEI_CD = strFHINMEI_CD_Temp                 '�i�ں���
                objXPLN_OUT_DTL.XDENPYOU_NO = strXDENPYOU_NO_Temp               '�`�[No.
                objXPLN_OUT_DTL.GET_XPLN_OUT_DTL()                              '�擾


                If objTRST_STOCK.ARYME(0).FTR_VOL = decTempNum Then
                    '(�݌ɍ폜�̏ꍇ)


                    '************************
                    '���u���݌ɍ폜
                    '************************
                    Call DeleteHiraoki(objTRST_STOCK.ARYME(0).FPALLET_ID _
                                     , FINOUT_STS_SOUT_END _
                                     , objXPLN_OUT_DTL.FSAGYOU_KIND _
                                     )


                Else
                    '(�݌ɍX�V�̏ꍇ)


                    '************************
                    '�݌ɏ��       �X�V
                    '************************
                    objTRST_STOCK.ARYME(0).FTR_VOL -= decTempNum         '�����Ǘ���
                    objTRST_STOCK.ARYME(0).FUPDATE_DT = Now              '�X�V����
                    objTRST_STOCK.ARYME(0).UPDATE_TRST_STOCK_ALL()       '�X�V


                    '************************
                    'INOUT���ђǉ�
                    '************************
                    Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT���Ѹ׽
                    objTLOG_INOUT.FRESULT_DT = Now                                          '���ѓ���
                    objTLOG_INOUT.FBUF_FM = objTPRG_TRK_BUF.FTRK_BUF_NO                     '�������ޯ̧��
                    objTLOG_INOUT.FARRAY_FM = objTPRG_TRK_BUF.FTRK_BUF_ARRAY                '�������z��
                    objTLOG_INOUT.FBUF_TO = objTPRG_TRK_BUF.FTRK_BUF_NO                     '�������ޯ̧��
                    objTLOG_INOUT.FARRAY_TO = objTPRG_TRK_BUF.FTRK_BUF_ARRAY                '������z��
                    objTLOG_INOUT.FINOUT_STS = FINOUT_STS_SOUT_END                          'IN/OUT
                    objTLOG_INOUT.FSAGYOU_KIND = objXPLN_OUT_DTL.FSAGYOU_KIND               '��Ǝ��
                    objTLOG_INOUT.FDISP_ADDRESS_FM = objTPRG_TRK_BUF.FDISP_ADDRESS          'FM�\�L�p���ڽ
                    objTLOG_INOUT.FDISP_ADDRESS_TO = objTPRG_TRK_BUF.FDISP_ADDRESS          'TO�\�L�p���ڽ
                    objTLOG_INOUT.FDISPLOG_ADDRESS_FM = objTPRG_TRK_BUF.FDISP_ADDRESS       'FM�\�L�p���ڽ_۸ޗp
                    objTLOG_INOUT.FDISPLOG_ADDRESS_TO = objTPRG_TRK_BUF.FDISP_ADDRESS       'TO�\�L�p���ڽ_۸ޗp
                    objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'հ�ްID
                    objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK                             '�݌ɏ��
                    objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '�ǉ�


                End If


            End If


        Next


        Return intReturn
    End Function
#End Region
#Region "  �o�׈�������(�߱����گďo�׈�������)                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׈�������(�߱����گďo�׈�������)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">���ɋ敪</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="strAryFinalPALLET_ID">�ŏI������گ�ID�z��</param>
    ''' <param name="strFLOT_NO">ۯć��ꗗ�̔z��</param>
    ''' <param name="objXPLN_OUT_DTL">�o�׎w���ڍ�</param>
    ''' <param name="blnHikiateHasuHira">�[��or���u���̍݌ɂ������Ă邩�ۂ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiatePairFull(ByVal strFIN_KUBUN As String _
                                        , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                        , ByRef strAryFinalPALLET_ID() As String _
                                        , ByVal strFLOT_NO As String _
                                        , ByVal objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL _
                                        , ByVal blnHikiateHasuHira As Boolean _
                                        , ByRef objOkuPalletIDList As ArrayList _
                                        ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        '��PL��������
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '�݌Ɉ���
        '************************************************
        Dim objSVR_100202 As New SVR_100202(Owner, ObjDb, ObjDbLog)             '�݌Ɉ����׽
        objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_J9000                           '�ޯ̧��
        'objSVR_100202.INTMaxPlt = 2                                             '�ő������گĐ�
        objSVR_100202.intHasu = SVR_100202.HasuMode.FullPL                      '�[��Ӱ��
        objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.NON_UPDATE          '�X�VӰ��(�ʏ�)
        objSVR_100202.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '�i�ں���
        objSVR_100202.FIN_KUBUN = strFIN_KUBUN                                  '���ɋ敪
        objSVR_100202.FLOT_NO = strFLOT_NO                                      'ۯć�
        objSVR_100202.FHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                       '�ۗ��敪
        objSVR_100202.XKENSA_KUBUN = XKENSA_KUBUN_J_OK                          '�����敪
        'objSVR_100202.XKENPIN_KUBUN = XKENPIN_KUBUN_J_SUMI                      '���i�敪
        intRet = objSVR_100202.FIND_STOCK(FTR_VOL_SFULL)                        '�݌Ɉ���
        If intRet = RetCode.OK Then
            '(���������ꍇ)

            For ii As Integer = 1 To 2
                '(ٰ��:2��)
                '(1���ٰ��:�o�ɉ\PL���Ώ�(��O�I�ɁA�݌�or�\�񂪂���ꍇ�A���I�͈����ĂȂ�))
                '(2���ٰ��:�o�ɕs��PL���Ώ�(��O�I�ɁA�݌�or�\�񂪂���ꍇ�ł��A���I�͈����Ă�))


                '************************************************************************************************
                '�݌Ɉ�������(��ۯ��P�ʂň����Ă�)
                '������ۯ����������ĂȂ�
                '************************************************************************************************
                ReDim strAryFinalPALLET_ID(1)
                Select Case ii
                    Case 1 : Call ZaikoHikiatePair(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, False, PairOrSingle.intPair, objOkuPalletIDList)
                    Case 2 : Call ZaikoHikiatePair(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, PairOrSingle.intPair, objOkuPalletIDList)
                End Select
                If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


                '************************************************************************************************
                '�݌Ɉ�������(��ۯ��P�ʂň����Ă�)
                '************************************************************************************************
                ReDim strAryFinalPALLET_ID(0)
                Select Case ii
                    Case 1 : Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, False, False, True, objOkuPalletIDList)
                    Case 2 : Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, False, True, objOkuPalletIDList)
                End Select
                If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


            Next

        End If


        If blnHikiateHasuHira = True Then
            '(�[��or���u���̍݌ɂ������Ă�ꍇ)


            '************************************************************************************************
            '************************************************************************************************
            '�[��PL��������
            '************************************************************************************************
            '************************************************************************************************
            ReDim strAryFinalPALLET_ID(1)
            intRet = SyukkaHikiateHasu(strFIN_KUBUN _
                                     , objTMST_ITEM _
                                     , strAryFinalPALLET_ID _
                                     , strFLOT_NO _
                                     , objOkuPalletIDList _
                                     )
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


            '************************************************************************************************
            '************************************************************************************************
            '���u��PL��������
            '************************************************************************************************
            '************************************************************************************************
            intRet = SyukkaHikiateHira(strFIN_KUBUN _
                                     , objTMST_ITEM _
                                     , strAryFinalPALLET_ID _
                                     , strFLOT_NO _
                                     )
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        End If


        Return intReturn
    End Function
#End Region
#Region "  �o�׈�������(�ݸ������گďo�׈�������)                                                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׈�������(�ݸ������گďo�׈�������)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">���ɋ敪</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="strAryFinalPALLET_ID">�ŏI������گ�ID�z��</param>
    ''' <param name="strFLOT_NO">ۯć�</param>
    ''' <param name="objXPLN_OUT_DTL">�o�׎w���ڍ�</param>
    ''' <param name="blnHikiateHasuHira">�[��or���u���̍݌ɂ������Ă邩�ۂ�</param>
    ''' <param name="objOkuPalletIDList">��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateSingleFull(ByVal strFIN_KUBUN As String _
                                          , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                          , ByRef strAryFinalPALLET_ID() As String _
                                          , ByVal strFLOT_NO As String _
                                          , ByVal objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL _
                                          , ByVal blnHikiateHasuHira As Boolean _
                                          , ByRef objOkuPalletIDList As ArrayList _
                                          ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        '��PL��������
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '�݌Ɉ���
        '************************************************
        Dim objSVR_100202 As New SVR_100202(Owner, ObjDb, ObjDbLog)             '�݌Ɉ����׽
        objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_J9000                           '�ޯ̧��
        'objSVR_100202.INTMaxPlt = 2                                             '�ő������گĐ�
        objSVR_100202.intHasu = SVR_100202.HasuMode.FullPL                      '�[��Ӱ��
        objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.NON_UPDATE          '�X�VӰ��(�ʏ�)
        objSVR_100202.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '�i�ں���
        objSVR_100202.FIN_KUBUN = strFIN_KUBUN                                  '���ɋ敪
        objSVR_100202.FLOT_NO = strFLOT_NO                                      'ۯć�
        objSVR_100202.FHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                       '�ۗ��敪
        objSVR_100202.XKENSA_KUBUN = XKENSA_KUBUN_J_OK                          '�����敪
        'objSVR_100202.XKENPIN_KUBUN = XKENPIN_KUBUN_J_SUMI                      '���i�敪
        intRet = objSVR_100202.FIND_STOCK(FTR_VOL_SFULL)                        '�݌Ɉ���
        If intRet = RetCode.OK Then
            '(���������ꍇ)

            For ii As Integer = 1 To 2
                '(ٰ��:2��)
                '(1���ٰ��:�o�ɉ\PL���Ώ�(��O�I�ɁA�݌�or�\�񂪂���ꍇ�A���I�͈����ĂȂ�))
                '(2���ٰ��:�o�ɕs��PL���Ώ�(��O�I�ɁA�݌�or�\�񂪂���ꍇ�ł��A���I�͈����Ă�))


                '************************************************************************************************
                '�݌Ɉ�������(��ۯ��P�ʂň����Ă�)
                '�[����ۯ����������ĂȂ�
                '************************************************************************************************
                ReDim strAryFinalPALLET_ID(0)
                Select Case ii
                    Case 1 : Call ZaikoHikiatePair(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, False, PairOrSingle.intSingle, objOkuPalletIDList)
                    Case 2 : Call ZaikoHikiatePair(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, PairOrSingle.intSingle, objOkuPalletIDList)
                End Select
                If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


                '************************************************************************************************
                '�݌Ɉ�������(��ۯ��P�ʂň����Ă�)
                '************************************************************************************************
                ReDim strAryFinalPALLET_ID(0)
                Select Case ii
                    Case 1 : Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, False, False, True, objOkuPalletIDList)
                    Case 2 : Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, False, True, objOkuPalletIDList)
                End Select
                If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


            Next

        End If


        If blnHikiateHasuHira = True Then
            '(�[��or���u���̍݌ɂ������Ă�ꍇ)


            '************************************************************************************************
            '************************************************************************************************
            '�[��PL��������
            '************************************************************************************************
            '************************************************************************************************
            ReDim strAryFinalPALLET_ID(0)
            intRet = SyukkaHikiateHasu(strFIN_KUBUN _
                                     , objTMST_ITEM _
                                     , strAryFinalPALLET_ID _
                                     , strFLOT_NO _
                                     , objOkuPalletIDList _
                                     )
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


            '************************************************************************************************
            '************************************************************************************************
            '���u��PL��������
            '************************************************************************************************
            '************************************************************************************************
            intRet = SyukkaHikiateHira(strFIN_KUBUN _
                                     , objTMST_ITEM _
                                     , strAryFinalPALLET_ID _
                                     , strFLOT_NO _
                                     )
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        End If


        Return intReturn
    End Function
#End Region
#Region "  �o�׈�������(�[���o�׈�������)                                                           "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׈�������(�[���o�׈�������)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">���ɋ敪</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="strAryFinalPALLET_ID">�ŏI������گ�ID�z��</param>
    ''' <param name="strFLOT_NO">ۯć�</param>
    ''' <param name="objXPLN_OUT_DTL">�o�׎w���ڍ�</param>
    ''' <param name="objOkuPalletIDList">��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateHasu(ByVal strFIN_KUBUN As String _
                                    , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                    , ByRef strAryFinalPALLET_ID() As String _
                                    , ByVal strFLOT_NO As String _
                                    , ByVal objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL _
                                    , ByRef objOkuPalletIDList As ArrayList _
                                    ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode


        '*****************************************************
        '���u��PL��������
        '*****************************************************
        intRet = SyukkaHikiateHira(strFIN_KUBUN _
                                 , objTMST_ITEM _
                                 , strAryFinalPALLET_ID _
                                 , strFLOT_NO _
                                 )
        If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        '*****************************************************
        '�[��PL��������
        '*****************************************************
        ReDim strAryFinalPALLET_ID(0)
        intRet = SyukkaHikiateHasu(strFIN_KUBUN _
                                 , objTMST_ITEM _
                                 , strAryFinalPALLET_ID _
                                 , strFLOT_NO _
                                 , objOkuPalletIDList _
                                 )
        If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        Return intReturn
    End Function
#End Region
#Region "  �o�׈�������(�[��PL��������)                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׈�������(ۯć��z��擾)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">���ɋ敪</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="strAryFinalPALLET_ID">�ŏI������گ�ID�z��</param>
    ''' <param name="strFLOT_NO">ۯć�</param>
    ''' <param name="objOkuPalletIDList">��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function SyukkaHikiateHasu(ByVal strFIN_KUBUN As String _
                                     , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                     , ByRef strAryFinalPALLET_ID() As String _
                                     , ByVal strFLOT_NO As String _
                                     , ByRef objOkuPalletIDList As ArrayList _
                                     ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        '�[��PL��������
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '�݌Ɉ���
        '************************************************
        Dim objSVR_100202 As New SVR_100202(Owner, ObjDb, ObjDbLog)             '�݌Ɉ����׽
        objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_J9000                           '�ޯ̧��
        'objSVR_100202.INTMaxPlt = 2                                             '�ő������گĐ�
        objSVR_100202.intHasu = SVR_100202.HasuMode.All                         '�[��Ӱ��
        objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.NON_UPDATE          '�X�VӰ��(�ʏ�)
        objSVR_100202.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '�i�ں���
        objSVR_100202.FIN_KUBUN = strFIN_KUBUN                                  '���ɋ敪
        objSVR_100202.FLOT_NO = strFLOT_NO                                      'ۯć�
        objSVR_100202.FHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                       '�ۗ��敪
        objSVR_100202.XKENSA_KUBUN = XKENSA_KUBUN_J_OK                          '�����敪
        'objSVR_100202.XKENPIN_KUBUN = XKENPIN_KUBUN_J_SUMI                      '���i�敪
        intRet = objSVR_100202.FIND_STOCK(FTR_VOL_SFULL)                        '�݌Ɉ���
        If intRet = RetCode.OK Then
            '(���������ꍇ)


            '************************************************************************************************
            '�݌Ɉ�������(��ۯ��P�ʂň����ĂāA����O�I��������Ă�)
            '************************************************************************************************
            Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, True, True, objOkuPalletIDList)
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        End If


        Return intReturn
    End Function
#End Region
#Region "  �o�׈�������(���u��PL��������)                                                           "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׈�������(���u��PL��������)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">���ɋ敪</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="strAryFinalPALLET_ID">�ŏI������گ�ID�z��</param>
    ''' <param name="strFLOT_NO">ۯć�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function SyukkaHikiateHira(ByVal strFIN_KUBUN As String _
                                     , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                     , ByRef strAryFinalPALLET_ID() As String _
                                     , ByVal strFLOT_NO As String _
                                     ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode
        ReDim strAryFinalPALLET_ID(0)


        '************************************************************************************************
        '************************************************************************************************
        '���u��PL��������
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '���u���݌ɂ������Ă�
        '************************************************
        Dim strSQL As String = ""       'SQL��
        Dim objAryTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    TRST_STOCK.FPALLET_ID "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FLOT_NO_STOCK "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FLOT_NO "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FARRIVE_DT "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FIN_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FSEIHIN_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FZAIKO_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHORYU_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FST_FM "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FTR_VOL "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FTR_RES_VOL "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FUPDATE_DT "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHASU_FLAG "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FLABEL_ID "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FSYUKKA_TO_CD "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FSYUKKA_TO_NAME "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XPROD_LINE "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XKENSA_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XKENPIN_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XMAKER_CD "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XRAC_IN_DT "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XTRK_BUF_NO_IN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XTRK_BUF_ARRAY_IN "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TRST_STOCK "
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    1 = 1 "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "           '��گ�ID�Ō���
        strSQL &= vbCrLf & "    AND TRST_STOCK.FTR_RES_VOL < TRST_STOCK.FTR_VOL "               '��������Ă��Ȃ��݌ɂ�����
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & FTRK_BUF_NO_J9100 & ") "   '���u��
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & FHORYU_KUBUN_SNORMAL & " "    '�ۗ��敪
        strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & XKENSA_KUBUN_J_OK & " "       '�����敪
        If IsNotNull(objTMST_ITEM.FHINMEI_CD) Then
            '(�i�����ގw��L��̏ꍇ)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & objTMST_ITEM.FHINMEI_CD & "' "     '�i������
        End If
        If IsNotNull(strFLOT_NO) Then
            '(ۯć��w��L��̏ꍇ)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FLOT_NO = '" & strFLOT_NO & "' "                 'ۯć�
        End If
        If IsNotNull(strFIN_KUBUN) Then
            '(���ɋ敪�w��L��̏ꍇ)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FIN_KUBUN IN (" & strFIN_KUBUN & ")"             '���ɋ敪
        End If
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    TRST_STOCK.FLOT_NO "            'ۯć�
        strSQL &= vbCrLf & "   ,TRST_STOCK.FPALLET_ID "         '��گ�ID
        strSQL &= vbCrLf
        objAryTRST_STOCK.USER_SQL = strSQL                      'SQL��
        intRet = objAryTRST_STOCK.GET_TRST_STOCK_USER()         '�擾
        If intRet = RetCode.OK Then
            '(���������ꍇ)

            For Each objTRST_STOCK As TBL_TRST_STOCK In objAryTRST_STOCK.ARYME
                '(ٰ��:�擾����ں��ސ�)


                '************************************************
                '�ŏI������گ�ID�z��                �X�V
                '************************************************
                strAryFinalPALLET_ID(0) = objTRST_STOCK.FPALLET_ID      '��گ�ID
                Return RetCode.OK

            Next

        End If


        Return intReturn
    End Function
#End Region
    '�o�׈���(�����֐�)
#Region "  �o�׈�������(ۯć��z��擾)                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׈�������(ۯć��z��擾)
    ''' </summary>
    ''' <param name="strAryFLOT_NO">ۯć�</param>
    ''' <param name="strFHINMEI_CD">�i�ں���</param>
    ''' <param name="intFIN_KUBUN">���ɋ敪</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function SyukkaHikiateGetAryFLOT_NO(ByRef strAryFLOT_NO() As String _
                                              , ByVal strFHINMEI_CD As String _
                                              , ByVal intFIN_KUBUN As Nullable(Of Integer) _
                                              ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        'Dim intRet As RetCode


        '****************************************
        'ۯć�                  �擾
        '****************************************
        Dim strSQL As String = ""       'SQL��
        Dim objAryTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    FLOT_NO AS FLOT_NO "
        strSQL &= vbCrLf & "   ,MIN(FARRIVE_DT) AS FARRIVE_DT_MIN "
        strSQL &= vbCrLf & "   ,TO_CHAR(MIN(FARRIVE_DT), 'YYYYMMDD') AS FARRIVE_DT_MIN_TOCHAR "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TRST_STOCK "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    1 = 1 "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FTR_RES_VOL < TRST_STOCK.FTR_VOL "               '��������Ă��Ȃ��݌ɂ�����
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & strFHINMEI_CD & "' "           '�i�ں���
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & FHORYU_KUBUN_SNORMAL & " "    '�ۗ��敪
        strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & XKENSA_KUBUN_J_OK & " "       '�����敪
        If IsNotNull(intFIN_KUBUN) Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FIN_KUBUN = " & intFIN_KUBUN & " "           '���ɋ敪
        End If
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "    FLOT_NO "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FARRIVE_DT_MIN_TOCHAR "
        strSQL &= vbCrLf & "   ,FLOT_NO "
        strSQL &= vbCrLf


        '***********************
        '���o
        '***********************
        Dim objDataSet As New DataSet   '�ް����
        Dim strDataSetName As String    '�ް���Ė�
        'Dim objRow As DataRow           '1ں��ޕ����ް�
        ObjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TRST_STOCK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim strAryFLOT_NO(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii As Integer = LBound(strAryFLOT_NO) To UBound(strAryFLOT_NO)
                strAryFLOT_NO(ii) = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)(0))
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


        Return intReturn
    End Function
#End Region
#Region "  �o�׈�������(�ׯ�۰�ނ̗\�萔����)                                                       "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׈�������(�ׯ�۰�ނ̗\�萔����)
    ''' </summary>
    ''' <param name="dtmXSYUKKA_D">�o�ד�</param>
    ''' <param name="strXHENSEI_NO_OYA">�e�Ґ�No.</param>
    ''' <param name="intFTRK_BUF_NO_TO">�s���ׯ�ݸ��ޯ̧��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function SyukkaHikiateSetYoteiLoader(ByVal dtmXSYUKKA_D As Date _
                                               , ByVal strXHENSEI_NO_OYA As String _
                                               , ByVal intSyukkaHikiateMode As SyukkaHikiateMode _
                                               , ByVal intFTRK_BUF_NO_TO As Integer _
                                               ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '****************************************
        '����
        '****************************************
        If intSyukkaHikiateMode <> SyukkaHikiateMode.Loader02 Then Return RetCode.OK


        '****************************************
        '�݌Ɉ������               �擾
        '****************************************
        Dim intCountSingle As Integer = 0       '�ݸ�ٔ����̌v�搔
        Dim strSQL As String = ""       'SQL��
        Dim objAryTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TSTS_HIKIATE "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    1 = 1 "
        strSQL &= vbCrLf & "    AND FPLAN_KEY IN ( SELECT "
        strSQL &= vbCrLf & "                          FPLAN_KEY "
        strSQL &= vbCrLf & "                       FROM "
        strSQL &= vbCrLf & "                          XPLN_OUT_DTL "
        strSQL &= vbCrLf & "                       WHERE "
        strSQL &= vbCrLf & "                          1 = 1 "
        strSQL &= vbCrLf & "                          AND XSYUKKA_D = TO_DATE('" & Format(dtmXSYUKKA_D, DATE_FORMAT_03) & "','YYYY/MM/DD HH24:MI:SS') "
        strSQL &= vbCrLf & "                          AND XHENSEI_NO_OYA = '" & strXHENSEI_NO_OYA & "' "
        strSQL &= vbCrLf & "                      ) "
        strSQL &= vbCrLf
        objAryTSTS_HIKIATE.USER_SQL = strSQL
        intRet = objAryTSTS_HIKIATE.GET_TSTS_HIKIATE_USER()
        If intRet = RetCode.OK Then
            '(���������ꍇ)
            For Each objTSTS_HIKIATE As TBL_TSTS_HIKIATE In objAryTSTS_HIKIATE.ARYME
                '(ٰ��:�擾����ں��ސ�)


                '****************************************
                '�����w��QUE                �擾
                '****************************************
                Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                objTPLN_CARRY_QUE.FPALLET_ID = objTSTS_HIKIATE.FPALLET_ID       '��گ�ID
                intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)            '�擾
                If intRet = RetCode.OK Then
                    '(���������ꍇ)
                    '(�Ĉ����̏ꍇ�A����ST�ɓ������Ă����ׯ�ݸނඳ�Ă��Ă��܂���)
                    If IsNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then intCountSingle += 1
                End If


            Next


            '****************************************
            '�ׯ�ݸ��ޯ̧Ͻ�            �擾
            '****************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO_TO     '�ׯ�ݸ��ޯ̧��
            objTMST_TRK.GET_TMST_TRK()                      '�擾


            '************************************************
            '����         �����\�萔
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            'objSVR_190001.FEQ_ID = strFEQ_ID                                '�ݔ�ID
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
            objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                                                  , intCountSingle _
                                                  , objAryTSTS_HIKIATE.ARYME.Length - intCountSingle _
                                                  )


        End If


        Return intReturn
    End Function
#End Region

    '�݌Ɉ���
#Region "  �݌Ɉ�������(��ۯ��P�ʂň����Ă�)(1PL���������ĂȂ�)                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' �݌Ɉ�������(��ۯ��P�ʂň����ĂāA����O�I��������Ă�)
    ''' </summary>
    ''' <param name="objSVR_100202">�݌Ɉ����׽</param>
    ''' <param name="strAryFinalPALLET_ID">������ި��߂��l�����Ĉ����Ă���گ�ID�z��</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="blnOkuHikiate">��O�I���\�񂳂�Ă��Ă��A���I�������Ă邩�ۂ�</param>
    ''' <param name="blnHasuHikiate">�[��PL�͈����ΏۂƂ��邩�ۂ�</param>
    ''' <param name="blnHasuBlockHikiate">�[����ۯ��͈����ΏۂƂ��邩�ۂ�</param>
    ''' <param name="objOkuPalletIDList">��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function ZaikoHikiateNormal(ByVal objSVR_100202 As SVR_100202 _
                                     , ByRef strAryFinalPALLET_ID() As String _
                                     , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                     , ByVal blnOkuHikiate As Boolean _
                                     , ByVal blnHasuHikiate As Boolean _
                                     , ByVal blnHasuBlockHikiate As Boolean _
                                     , ByRef objOkuPalletIDList As ArrayList _
                                     ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        '��ۯ�����
        '************************************************************************************************
        '************************************************************************************************
        'ReDim strAryFinalPALLET_ID(0)                                       '��ۯ��P�ʂň����Ă���گ�ID�z��
        Dim intXTANA_BLOCK_Memory As Integer = -1                           '�����Ă���گĂ̒I��ۯ�(�L��)
        For ii As Integer = 0 To UBound(objSVR_100202.strArrayPALLET_ID)
            '(ٰ��:��������������گĐ�)


            '***********************************************
            '�����ݒ�
            '***********************************************
            Dim strHikiateFPALLET_ID As String = objSVR_100202.strArrayPALLET_ID(ii)                    '���Ɉ�������������گ�ID
            Dim intHikiateXTANA_BLOCK As Integer = TO_INTEGER(objSVR_100202.intAryXTANA_BLOCK(ii))      '���Ɉ�������������گ�ID�̒I��ۯ�


            '***********************************************
            '�������ԒZ�k����
            '***********************************************
            '======================================
            '�I��ۯ�����
            '======================================
            If intXTANA_BLOCK_Memory = intHikiateXTANA_BLOCK Then Continue For
            intXTANA_BLOCK_Memory = intHikiateXTANA_BLOCK

            ''======================================
            ''�o�ɕs�̉��I����
            ''======================================
            'If blnOkuHikiate = False Then
            '    '(���͈����ĂȂ��ꍇ)
            '    If objOkuPalletIDList.Contains(strHikiateFPALLET_ID) = True Then
            '        '(��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽĂɑ��݂��Ă����ꍇ)
            '        Continue For
            '    Else
            '        '(��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽĂɑ��݂��Ă��Ȃ��ꍇ)
            '        objOkuPalletIDList.Add(strHikiateFPALLET_ID)
            '    End If
            'End If
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, "%%%", FLOG_DATA_TRN_SEND_NORMAL, "[" & strHikiateFPALLET_ID & "][" & Format(Now, DATE_FORMAT_99) & "]%�o�׈������Ԓ���۸�")


            '***********************************************
            '�������������݌ɂ��ׯ�ݸނ̎擾
            '***********************************************
            Dim objTrkFind As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTrkFind.FPALLET_ID = strHikiateFPALLET_ID    '��گ�ID
            objTrkFind.GET_TPRG_TRK_BUF()                   '�擾


            '***********************************************
            '�֘A������ۯ��I�̎擾
            '***********************************************
            Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      '�ׯ�ݸ��ޯ̧�׽
            Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '�݌ɏ��
            Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '�݌ɏ��
            Call GetTPRG_TRK_BUF_Relation(objTrkFind, objTrkRelation, objStockFind, objStockRelation)


            '**********************************************************************************************
            '�O�I����O�I���������I������I����    �̏��Ԃň����Ē���
            '**********************************************************************************************
            intRet = ZaikoHikiateBlockHikiate(strAryFinalPALLET_ID _
                                            , objTMST_ITEM _
                                            , blnOkuHikiate _
                                            , blnHasuHikiate _
                                            , blnHasuBlockHikiate _
                                            , objTrkRelation _
                                            , objStockRelation _
                                            )
            If intRet = RetCode.OK Then Return intRet


        Next


        Return intReturn
    End Function
#End Region
#Region "  �݌Ɉ�������(��ۯ��P�ʂň����Ă�)                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' �݌Ɉ�������(��ۯ��P�ʂň����Ă�)
    ''' </summary>
    ''' <param name="objSVR_100202">�݌Ɉ����׽</param>
    ''' <param name="strAryFinalPALLET_ID">������ި��߂��l�����Ĉ����Ă���گ�ID�z��</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="blnOkuHikiate">��O�I���\�񂳂�Ă��Ă��A���I�������Ă邩�ۂ�</param>
    ''' <param name="intPairOrSingle">�߱ or �ݸ��</param>
    ''' <param name="objOkuPalletIDList">��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function ZaikoHikiatePair(ByVal objSVR_100202 As SVR_100202 _
                                   , ByRef strAryFinalPALLET_ID() As String _
                                   , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                   , ByVal blnOkuHikiate As Boolean _
                                   , ByVal intPairOrSingle As PairOrSingle _
                                   , ByRef objOkuPalletIDList As ArrayList _
                                   ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        '��ۯ�����
        '************************************************************************************************
        '************************************************************************************************
        Dim intXTANA_BLOCK_Memory As Integer = -1       '�����Ă���گĂ̒I��ۯ�(�L��)
        For ii As Integer = 0 To UBound(objSVR_100202.strArrayPALLET_ID)
            '(ٰ��:��������������گĐ�)


            '***********************************************
            '�����ݒ�
            '***********************************************
            Dim strHikiateFPALLET_ID As String = objSVR_100202.strArrayPALLET_ID(ii)                    '���Ɉ�������������گ�ID
            Dim intHikiateXTANA_BLOCK As Integer = TO_INTEGER(objSVR_100202.intAryXTANA_BLOCK(ii))      '���Ɉ�������������گ�ID�̒I��ۯ�


            '***********************************************
            '�������ԒZ�k����
            '***********************************************
            '======================================
            '�I��ۯ�����
            '======================================
            If intXTANA_BLOCK_Memory = intHikiateXTANA_BLOCK Then Continue For
            intXTANA_BLOCK_Memory = intHikiateXTANA_BLOCK

            ''======================================
            ''�o�ɕs�̉��I����
            ''======================================
            'If blnOkuHikiate = False Then
            '    '(���͈����ĂȂ��ꍇ)
            '    If objOkuPalletIDList.Contains(strHikiateFPALLET_ID) = True Then
            '        '(��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽĂɑ��݂��Ă����ꍇ)
            '        Continue For
            '    Else
            '        '(��O�I�ɍ݌ɂ�����ׁA�o�ɕs����گ�IDؽĂɑ��݂��Ă��Ȃ��ꍇ)
            '        objOkuPalletIDList.Add(strHikiateFPALLET_ID)
            '    End If
            'End If
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, "bbb", FLOG_DATA_TRN_SEND_NORMAL, "[" & strHikiateFPALLET_ID & "][" & Format(Now, DATE_FORMAT_99) & "]b�o�׈������Ԓ���۸�")


            '***********************************************
            '�������������݌ɂ��ׯ�ݸނ̎擾
            '***********************************************
            Dim objTrkFind As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTrkFind.FPALLET_ID = strHikiateFPALLET_ID    '��گ�ID
            objTrkFind.GET_TPRG_TRK_BUF()                   '�擾


            '***********************************************
            '�֘A������ۯ��I�̎擾
            '***********************************************
            Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      '�ׯ�ݸ��ޯ̧�׽
            Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '�݌ɏ��
            Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '�݌ɏ��
            Call GetTPRG_TRK_BUF_Relation(objTrkFind, objTrkRelation, objStockFind, objStockRelation)


            '***********************************************
            '�[����ۯ�����
            '***********************************************
            Dim blnPairBlock As Boolean = False     '�߱�o����ۯ����ۂ����׸�
            blnPairBlock = ZaikoHikiateBlockHasuBlockHantei(objTMST_ITEM, objTrkRelation, objStockRelation)



            If intPairOrSingle = PairOrSingle.intSingle Then
                '(�ݸ�ق̏ꍇ)
                '(�߱�o����ۯ��͈����ĂȂ�)


                If blnPairBlock = False Then
                    '(�߱�o����ۯ��͈����ĂȂ�)


                    '**********************************************************************************************
                    '�O�I����O�I���������I������I����    �̏��Ԃň����Ē���
                    '**********************************************************************************************
                    intRet = ZaikoHikiateBlockHikiate(strAryFinalPALLET_ID _
                                                    , objTMST_ITEM _
                                                    , blnOkuHikiate _
                                                    , False _
                                                    , True _
                                                    , objTrkRelation _
                                                    , objStockRelation _
                                                    )
                    If intRet = RetCode.OK Then Return intRet


                End If


            Else
                '(�߱�̏ꍇ)
                '(�߱�o����ۯ��݈̂����Ă�)


                If blnPairBlock = True Then
                    '(�߱�o����ۯ��݈̂����Ă�)


                    '**********************************************************************************************
                    '�O�I����O�I���������I������I����    �̏��Ԃň����Ē���
                    '**********************************************************************************************
                    intRet = ZaikoHikiateBlockHikiate(strAryFinalPALLET_ID _
                                                    , objTMST_ITEM _
                                                    , blnOkuHikiate _
                                                    , False _
                                                    , False _
                                                    , objTrkRelation _
                                                    , objStockRelation _
                                                    )
                    If intRet = RetCode.OK Then Return intRet


                End If


            End If


        Next


        Return intReturn
    End Function
#End Region
#Region "  �݌Ɉ�������(��ۯ����ł̍݌Ɉ�������)        (�����֐�)                                  "
    '''**********************************************************************************************
    ''' <summary>
    ''' �݌Ɉ�������(��ۯ����ł̍݌Ɉ�������)        (�����֐�)
    ''' </summary>
    ''' <param name="strAryFinalPALLET_ID">������ި��߂��l�����Ĉ����Ă���گ�ID�z��</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="blnOkuHikiate">��O�I���\�񂳂�Ă��Ă��A���I�������Ă邩�ۂ�</param>
    ''' <param name="blnHasuHikiate">�[��PL�͈����ΏۂƂ��邩�ۂ�</param>
    ''' <param name="blnHasuBlockHikiate">�[����ۯ��͈����ΏۂƂ��邩�ۂ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function ZaikoHikiateBlockHikiate(ByRef strAryFinalPALLET_ID() As String _
                                            , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                            , ByVal blnOkuHikiate As Boolean _
                                            , ByVal blnHasuHikiate As Boolean _
                                            , ByVal blnHasuBlockHikiate As Boolean _
                                            , ByVal objTrkRelation() As TBL_TPRG_TRK_BUF _
                                            , ByVal objStockRelation() As TBL_TRST_STOCK _
                                            ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        'Dim intRet As RetCode
        Dim intAryCount As Integer = 0          '�����Ă���گĂ̶���


        '**********************************************************************************************
        '�O�I�������O�I������I���������I�    �̏��Ԃň����Ē���
        '**********************************************************************************************
        '===============================================
        '�O�I����
        '===============================================
        If IsNotNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) And objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SZAIKO Then
            '(�݌ɒI�̏ꍇ)
            If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.MAE_EVN).ARYME(0).FTR_VOL Then
                '(�[��PL�������Ă� or ����PL�̏ꍇ)
                strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID        '�����Ă�
                intAryCount += 1                                                                            '���ı���
                'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[�o�׈���][��گ�ID:" & objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID & "][�I��:" & objTrkRelation(RelationArray.MAE_EVN).FDISP_ADDRESS & "][" & strLogMsg & "]")
                If UBound(strAryFinalPALLET_ID) < intAryCount Then
                    '(�K�v���ʈ����Ă��ꍇ)
                    Return RetCode.OK
                End If
            Else
                '(�[��PL�ŁA�[��PL�������ΏۂƂ��Ȃ��ꍇ)
                If blnHasuBlockHikiate = False Then
                    '(�[����ۯ��������ΏۂƂ��邩�ۂ�)
                    Return RetCode.NotFound
                End If
            End If
        End If

        '===============================================
        '�O�I�
        '===============================================
        If IsNotNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) And objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SZAIKO Then
            '(�݌ɒI�̏ꍇ)
            If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.MAE_ODD).ARYME(0).FTR_VOL Then
                '(�[��PL�������Ă� or ����PL�̏ꍇ)
                strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID        '�����Ă�
                intAryCount += 1                                                                            '���ı���
                'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[�o�׈���][��گ�ID:" & objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID & "][�I��:" & objTrkRelation(RelationArray.MAE_ODD).FDISP_ADDRESS & "][" & strLogMsg & "]")
                If UBound(strAryFinalPALLET_ID) < intAryCount Then
                    '(�K�v���ʈ����Ă��ꍇ)
                    Return RetCode.OK
                End If
            Else
                '(�[��PL�ŁA�[��PL�������ΏۂƂ��Ȃ��ꍇ)
                If blnHasuBlockHikiate = False Then
                    '(�[����ۯ��������ΏۂƂ��邩�ۂ�)
                    Return RetCode.NotFound
                End If
            End If
        End If


        '**********************************************************************************************
        '���I��������
        '**********************************************************************************************
        If (objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Or objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SAKI) _
       And (objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Or objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SAKI) _
        Then
            '(��O�I�������Ƃ��A���o�\��or��I�̏ꍇ)

            If objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT _
            Or objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT _
            Then
                '(��O�I�̂ǂ��炩���A���o�\��̏ꍇ)

                If blnOkuHikiate = False Then
                    '(��O�I�����Ƃ����o�\��̏ꍇ�ɁA���I�������ĂȂ��ꍇ)
                    Return RetCode.NotFound
                End If

            End If

        Else
            '(��O�I�̂ǂ��炩���A�݌ɒIor�����\��or�ُ�I�̏ꍇ)
            Return RetCode.NotFound
        End If

        '===============================================
        '���I����
        '===============================================
        If IsNotNull(objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID) And objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SZAIKO Then
            '(�݌ɒI�̏ꍇ)
            If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FTR_VOL Then
                '(�[��PL�������Ă� or ����PL�̏ꍇ)
                strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID        '�����Ă�
                intAryCount += 1                                                                            '���ı���
                'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[�o�׈���][��گ�ID:" & objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID & "][�I��:" & objTrkRelation(RelationArray.OKU_EVN).FDISP_ADDRESS & "][" & strLogMsg & "]")
                If UBound(strAryFinalPALLET_ID) < intAryCount Then
                    '(�K�v���ʈ����Ă��ꍇ)
                    Return RetCode.OK
                End If
            Else
                '(�[��PL�ŁA�[��PL�������ΏۂƂ��Ȃ��ꍇ)
                If blnHasuBlockHikiate = False Then
                    '(�[����ۯ��������ΏۂƂ��邩�ۂ�)
                    Return RetCode.NotFound
                End If
            End If
        End If

        '===============================================
        '���I�
        '===============================================
        If IsNotNull(objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID) And objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SZAIKO Then
            '(�݌ɒI�̏ꍇ)
            If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FTR_VOL Then
                '(�[��PL�������Ă� or ����PL�̏ꍇ)
                strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID        '�����Ă�
                intAryCount += 1                                                                            '���ı���
                'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[�o�׈���][��گ�ID:" & objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID & "][�I��:" & objTrkRelation(RelationArray.OKU_ODD).FDISP_ADDRESS & "][" & strLogMsg & "]")
                If UBound(strAryFinalPALLET_ID) < intAryCount Then
                    '(�K�v���ʈ����Ă��ꍇ)
                    Return RetCode.OK
                End If
            Else
                '(�[��PL�ŁA�[��PL�������ΏۂƂ��Ȃ��ꍇ)
                If blnHasuBlockHikiate = False Then
                    '(�[����ۯ��������ΏۂƂ��邩�ۂ�)
                    Return RetCode.NotFound
                End If
            End If
        End If


        Return intReturn
    End Function
#End Region
#Region "  �݌Ɉ�������(��ۯ����ł̍݌Ɉ�������)        (�����֐�)2013/08/12 Backup                 "
    ''''**********************************************************************************************
    '''' <summary>
    '''' �݌Ɉ�������(��ۯ����ł̍݌Ɉ�������)        (�����֐�)
    '''' </summary>
    '''' <param name="strAryFinalPALLET_ID">������ި��߂��l�����Ĉ����Ă���گ�ID�z��</param>
    '''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    '''' <param name="blnOkuHikiate">��O�I���\�񂳂�Ă��Ă��A���I�������Ă邩�ۂ�</param>
    '''' <param name="blnHasuHikiate">�[��PL�͈����ΏۂƂ��邩�ۂ�</param>
    '''' <param name="blnHasuBlockHikiate">�[����ۯ��͈����ΏۂƂ��邩�ۂ�</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Private Function ZaikoHikiateBlockHikiate(ByRef strAryFinalPALLET_ID() As String _
    '                                        , ByVal objTMST_ITEM As TBL_TMST_ITEM _
    '                                        , ByVal blnOkuHikiate As Boolean _
    '                                        , ByVal blnHasuHikiate As Boolean _
    '                                        , ByVal blnHasuBlockHikiate As Boolean _
    '                                        , ByVal objTrkRelation() As TBL_TPRG_TRK_BUF _
    '                                        , ByVal objStockRelation() As TBL_TRST_STOCK _
    '                                        ) As RetCode
    '    Dim intReturn As RetCode = RetCode.OK
    '    'Dim strMsg As String
    '    'Dim intRet As RetCode
    '    Dim intAryCount As Integer = 0          '�����Ă���گĂ̶���


    '    '**********************************************************************************************
    '    '�O�I����O�I���������I������I����    �̏��Ԃň����Ē���
    '    '**********************************************************************************************
    '    '===============================================
    '    '�O�I�
    '    '===============================================
    '    If IsNotNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) And objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SZAIKO Then
    '        '(�݌ɒI�̏ꍇ)
    '        If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.MAE_ODD).ARYME(0).FTR_VOL Then
    '            '(�[��PL�������Ă� or ����PL�̏ꍇ)
    '            strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID        '�����Ă�
    '            intAryCount += 1                                                                            '���ı���
    '            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[�o�׈���][��گ�ID:" & objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID & "][�I��:" & objTrkRelation(RelationArray.MAE_ODD).FDISP_ADDRESS & "][" & strLogMsg & "]")
    '            If UBound(strAryFinalPALLET_ID) < intAryCount Then
    '                '(�K�v���ʈ����Ă��ꍇ)
    '                Return RetCode.OK
    '            End If
    '        Else
    '            '(�[��PL�ŁA�[��PL�������ΏۂƂ��Ȃ��ꍇ)
    '            If blnHasuBlockHikiate = False Then
    '                '(�[����ۯ��������ΏۂƂ��邩�ۂ�)
    '                Return RetCode.NotFound
    '            End If
    '        End If
    '    End If

    '    '===============================================
    '    '�O�I����
    '    '===============================================
    '    If IsNotNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) And objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SZAIKO Then
    '        '(�݌ɒI�̏ꍇ)
    '        If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.MAE_EVN).ARYME(0).FTR_VOL Then
    '            '(�[��PL�������Ă� or ����PL�̏ꍇ)
    '            strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID        '�����Ă�
    '            intAryCount += 1                                                                            '���ı���
    '            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[�o�׈���][��گ�ID:" & objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID & "][�I��:" & objTrkRelation(RelationArray.MAE_EVN).FDISP_ADDRESS & "][" & strLogMsg & "]")
    '            If UBound(strAryFinalPALLET_ID) < intAryCount Then
    '                '(�K�v���ʈ����Ă��ꍇ)
    '                Return RetCode.OK
    '            End If
    '        Else
    '            '(�[��PL�ŁA�[��PL�������ΏۂƂ��Ȃ��ꍇ)
    '            If blnHasuBlockHikiate = False Then
    '                '(�[����ۯ��������ΏۂƂ��邩�ۂ�)
    '                Return RetCode.NotFound
    '            End If
    '        End If
    '    End If


    '    '**********************************************************************************************
    '    '���I��������
    '    '**********************************************************************************************
    '    If (objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Or objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SAKI) _
    '   And (objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Or objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SAKI) _
    '    Then
    '        '(��O�I�������Ƃ��A���o�\��or��I�̏ꍇ)

    '        If objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT _
    '        Or objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT _
    '        Then
    '            '(��O�I�̂ǂ��炩���A���o�\��̏ꍇ)

    '            If blnOkuHikiate = False Then
    '                '(��O�I�����Ƃ����o�\��̏ꍇ�ɁA���I�������ĂȂ��ꍇ)
    '                Return RetCode.NotFound
    '            End If

    '        End If

    '    Else
    '        '(��O�I�̂ǂ��炩���A�݌ɒIor�����\��or�ُ�I�̏ꍇ)
    '        Return RetCode.NotFound
    '    End If

    '    '===============================================
    '    '���I�
    '    '===============================================
    '    If IsNotNull(objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID) And objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SZAIKO Then
    '        '(�݌ɒI�̏ꍇ)
    '        If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FTR_VOL Then
    '            '(�[��PL�������Ă� or ����PL�̏ꍇ)
    '            strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID        '�����Ă�
    '            intAryCount += 1                                                                            '���ı���
    '            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[�o�׈���][��گ�ID:" & objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID & "][�I��:" & objTrkRelation(RelationArray.OKU_ODD).FDISP_ADDRESS & "][" & strLogMsg & "]")
    '            If UBound(strAryFinalPALLET_ID) < intAryCount Then
    '                '(�K�v���ʈ����Ă��ꍇ)
    '                Return RetCode.OK
    '            End If
    '        Else
    '            '(�[��PL�ŁA�[��PL�������ΏۂƂ��Ȃ��ꍇ)
    '            If blnHasuBlockHikiate = False Then
    '                '(�[����ۯ��������ΏۂƂ��邩�ۂ�)
    '                Return RetCode.NotFound
    '            End If
    '        End If
    '    End If

    '    '===============================================
    '    '���I����
    '    '===============================================
    '    If IsNotNull(objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID) And objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SZAIKO Then
    '        '(�݌ɒI�̏ꍇ)
    '        If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FTR_VOL Then
    '            '(�[��PL�������Ă� or ����PL�̏ꍇ)
    '            strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID        '�����Ă�
    '            intAryCount += 1                                                                            '���ı���
    '            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[�o�׈���][��گ�ID:" & objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID & "][�I��:" & objTrkRelation(RelationArray.OKU_EVN).FDISP_ADDRESS & "][" & strLogMsg & "]")
    '            If UBound(strAryFinalPALLET_ID) < intAryCount Then
    '                '(�K�v���ʈ����Ă��ꍇ)
    '                Return RetCode.OK
    '            End If
    '        Else
    '            '(�[��PL�ŁA�[��PL�������ΏۂƂ��Ȃ��ꍇ)
    '            If blnHasuBlockHikiate = False Then
    '                '(�[����ۯ��������ΏۂƂ��邩�ۂ�)
    '                Return RetCode.NotFound
    '            End If
    '        End If
    '    End If


    '    Return intReturn
    'End Function
#End Region
#Region "  �݌Ɉ�������(�[����ۯ�����)                  (�����֐�)                                  "
    '''**********************************************************************************************
    ''' <summary>
    ''' �݌Ɉ�������(�[����ۯ�����)                  (�����֐�)
    ''' </summary>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <returns>
    ''' �߱�o����ۯ����ۂ����׸�
    ''' True:������ۯ�
    ''' False:�[����ۯ�
    ''' </returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function ZaikoHikiateBlockHasuBlockHantei(ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                            , ByVal objTrkRelation() As TBL_TPRG_TRK_BUF _
                                            , ByVal objStockRelation() As TBL_TRST_STOCK _
                                            ) _
                                            As Boolean
        'Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        'Dim intRet As RetCode


        '***********************************************
        '�݌Ɉ������       �擾
        '***********************************************
        Dim intFRES_KIND_MAE_ODD As Integer = objTrkRelation(RelationArray.MAE_ODD).FRES_KIND
        Dim intFRES_KIND_MAE_EVN As Integer = objTrkRelation(RelationArray.MAE_EVN).FRES_KIND
        Dim intFRES_KIND_OKU_ODD As Integer = objTrkRelation(RelationArray.OKU_ODD).FRES_KIND
        Dim intFRES_KIND_OKU_EVN As Integer = objTrkRelation(RelationArray.OKU_EVN).FRES_KIND


        '***********************************************
        '��گ�ID            �擾
        '***********************************************
        Dim strFPALLET_ID_MAE_ODD As String = objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID
        Dim strFPALLET_ID_MAE_EVN As String = objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID
        Dim strFPALLET_ID_OKU_ODD As String = objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID
        Dim strFPALLET_ID_OKU_EVN As String = objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID


        '**********************************************************************************************
        '**********************************************************************************************
        '�[����ۯ�����
        '**********************************************************************************************
        '**********************************************************************************************
        Dim blnPairBlock As Boolean = False         '�߱�o����ۯ����ۂ����׸�
        If (IsNotNull(strFPALLET_ID_MAE_ODD) And IsNotNull(strFPALLET_ID_MAE_EVN) And IsNotNull(strFPALLET_ID_OKU_ODD) And IsNotNull(strFPALLET_ID_OKU_EVN)) _
           Or _
           (IsNull(strFPALLET_ID_MAE_ODD) And IsNull(strFPALLET_ID_MAE_EVN) And IsNotNull(strFPALLET_ID_OKU_ODD) And IsNotNull(strFPALLET_ID_OKU_EVN)) _
           Then
            '(4�Ƃ���گ�ID�����݂��� or ���I2������گ�ID�����݂���ꍇ)


            '***********************************************
            '�݌Ɉ������           ����
            '***********************************************
            Dim blnTempHasuBlock As Boolean = False         '�[����ۯ����m�׸�
            If (intFRES_KIND_MAE_ODD = FRES_KIND_SZAIKO And intFRES_KIND_MAE_EVN = FRES_KIND_SZAIKO And intFRES_KIND_OKU_ODD = FRES_KIND_SZAIKO And intFRES_KIND_OKU_EVN = FRES_KIND_SZAIKO) _
               Or _
               (intFRES_KIND_MAE_ODD = FRES_KIND_SAKI And intFRES_KIND_MAE_EVN = FRES_KIND_SAKI And intFRES_KIND_OKU_ODD = FRES_KIND_SZAIKO And intFRES_KIND_OKU_EVN = FRES_KIND_SZAIKO) _
               Or _
               (intFRES_KIND_MAE_ODD = FRES_KIND_SRSV_TRNS_OUT And intFRES_KIND_MAE_EVN = FRES_KIND_SRSV_TRNS_OUT And intFRES_KIND_OKU_ODD = FRES_KIND_SZAIKO And intFRES_KIND_OKU_EVN = FRES_KIND_SZAIKO) _
               Then
                '(   �S�č݌ɒI�̏ꍇ)
                '(or �O�I����I�A���I���݌ɒI�̏ꍇ)
                '(or �O�I���o�ɗ\��I�A���I���݌ɒI�̏ꍇ)
                blnTempHasuBlock = False
            Else
                '(����ȊO�̏ꍇ)
                blnTempHasuBlock = True
            End If


            '***********************************************
            '�[����گ�              ����
            '***********************************************
            Dim blnTempHasuZaiko As Boolean = False     '�[����ۯ����m�׸�
            If IsNotNull(objStockRelation(RelationArray.MAE_ODD)) Then If objStockRelation(RelationArray.MAE_ODD).ARYME(0).FTR_VOL <> objTMST_ITEM.FNUM_IN_PALLET Then blnTempHasuZaiko = True
            If IsNotNull(objStockRelation(RelationArray.MAE_EVN)) Then If objStockRelation(RelationArray.MAE_EVN).ARYME(0).FTR_VOL <> objTMST_ITEM.FNUM_IN_PALLET Then blnTempHasuZaiko = True
            If IsNotNull(objStockRelation(RelationArray.OKU_ODD)) Then If objStockRelation(RelationArray.OKU_ODD).ARYME(0).FTR_VOL <> objTMST_ITEM.FNUM_IN_PALLET Then blnTempHasuZaiko = True
            If IsNotNull(objStockRelation(RelationArray.OKU_EVN)) Then If objStockRelation(RelationArray.OKU_EVN).ARYME(0).FTR_VOL <> objTMST_ITEM.FNUM_IN_PALLET Then blnTempHasuZaiko = True

            If blnTempHasuBlock = False And blnTempHasuZaiko = False Then
                '(�[����ۯ����m�Ȃ� and �[���݌Ɍ��m�Ȃ� �̏ꍇ)
                blnPairBlock = True
            End If

        End If


        Return blnPairBlock
    End Function
#End Region

    '�ύ�����
#Region "  �ύ�����                                                                                 "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ύ�����
    ''' </summary>
    ''' <param name="strXDSPBERTH_NO">�ް���</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function TumikomiKanryou(ByVal strXDSPBERTH_NO As String _
                                  , ByVal dtmXDSPSYUKKA_D As Nullable(Of Date) _
                                  , ByVal strXDSPHENSEI_NO_OYA As String _
                                  ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        Dim strMsg As String
        Dim intRet As RetCode


        '***********************************************
        '�����ݒ�
        '***********************************************
        Dim strFPLAN_KEY As String = Nothing                '�v�淰


        '***********************************************
        '�o���ް���               �擾
        '***********************************************
        Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
        objXSTS_BERTH.XBERTH_NO = strXDSPBERTH_NO               '�ް�No.
        objXSTS_BERTH.GET_XSTS_BERTH()                          '�擾


        '**********************************************************************************************
        '**********************************************************************************************
        '�ׯ�ݸފ���
        '**********************************************************************************************
        '**********************************************************************************************
        '***********************************************
        '�o�׺���ԏ�              �擾
        '***********************************************
        Dim objAryXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
        objAryXSTS_CONVEYOR.XBERTH_GROUP = objXSTS_BERTH.XBERTH_GROUP      '�ް���ٰ��
        intRet = objAryXSTS_CONVEYOR.GET_XSTS_CONVEYOR_ANY()               '�擾
        If intRet <> RetCode.OK Then Throw New Exception(ERRMSG_NOTFOUND_XSTS_CONVEYOR & "[�ް���ٰ��:" & objAryXSTS_CONVEYOR.XBERTH_GROUP & "]")
        For Each objXSTS_CONVEYOR As TBL_XSTS_CONVEYOR In objAryXSTS_CONVEYOR.ARYME
            '(ٰ��:�擾����ں��ސ�)


            '***********************************************
            '�ׯ�ݸ��ޯ̧(ST)           �擾
            '***********************************************
            Dim objAryTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objAryTPRG_TRK_BUF_ST.FTRK_BUF_NO = objXSTS_CONVEYOR.XSTNO     '�ׯ�ݸ��ޯ̧
            intRet = objAryTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF_FIFO(True)     '�擾
            If intRet = RetCode.OK Then
                '(���������ꍇ)
                For Each objTPRG_TRK_BUF_ST As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_ST.ARYME
                    '(ٰ��:���������ׯ�ݸސ�)


                    '**************************************
                    '�݌ɏ��               �擾
                    '**************************************
                    Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    objTRST_STOCK.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID        '��گ�ID
                    objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                       '�擾


                    '**************************************
                    '�݌Ɉ������           �擾
                    '**************************************
                    Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                    objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID      '��گ�ID
                    objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET()                       '�擾
                    strFPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY                        '�v�淰


                    Dim intFSAGYOU_KIND As Integer = objTSTS_HIKIATE.FSAGYOU_KIND
                    If objTRST_STOCK.ARYME(0).FTR_VOL <= objTSTS_HIKIATE.FTR_VOL Then
                        '(�S�Ĉ����������Ă���ꍇ)


                        '************************************************************************
                        '�ׯ�ݸ�,�݌ɏ��,���̑���گĂɊ֌W������S�č폜
                        '************************************************************************
                        Call ClearDustProcess(objTPRG_TRK_BUF_ST.FPALLET_ID)


                        '************************
                        '�݌ɍ폜
                        '************************
                        Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '�݌ɍ폜�׽
                        objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_ST          '�ׯ�ݸ��ޯ̧
                        objSVR_100102.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID    '��گ�ID
                        'objSVR_100102.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '�݌�ۯć�
                        objSVR_100102.FINOUT_STS = FINOUT_STS_JTUMI_END             'INOUT
                        objSVR_100102.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
                        objSVR_100102.STOCK_DELETE()                                '�폜


                    Else
                        '(�S�Ĉ����������Ă��Ȃ��ꍇ)


                        '************************************************************************
                        '�݌ɏ��               �X�V
                        '************************************************************************
                        For ii As Integer = 0 To UBound(objTRST_STOCK.ARYME)
                            '(ٰ��:�݌�ۯć���)

                            objTRST_STOCK.ARYME(ii).FTR_VOL = objTRST_STOCK.ARYME(ii).FTR_VOL - objTSTS_HIKIATE.FTR_VOL         '�����Ǘ���
                            objTRST_STOCK.ARYME(ii).FTR_RES_VOL = 0             '����������
                            objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now            '�X�V����
                            objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK_ALL()     '�X�V

                        Next


                        '************************************************
                        '�ׯ�ݸ��ޯ̧(���u)         �擾
                        '************************************************
                        Dim objTPRG_TRK_BUF_HIRA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO = FTRK_BUF_NO_J9100            '�ׯ�ݸ��ޯ̧��
                        intRet = objTPRG_TRK_BUF_HIRA.GET_TPRG_TRK_BUF_AKI_HIRA()       '�擾
                        If intRet <> RetCode.OK Then
                            '(������Ȃ��ꍇ)
                            strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO) & "]"
                            Throw New UserException(strMsg)
                        End If


                        '************************
                        '�݌Ɉړ�
                        '************************
                        Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)         '�݌Ɉړ��׽
                        objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ST               '�ׯ�ݸ��ޯ̧
                        objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_HIRA             '�ׯ�ݸ��ޯ̧
                        objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID            '��گ�ID
                        objSVR_100103.FINOUT_STS = FINOUT_STS_JTUMI_END                     'INOUT
                        objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND           '��Ǝ��
                        objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                            '�������ر�׸�
                        objSVR_100103.STOCK_TRNS()                                          '�ړ�


                        '************************************************************************
                        '�ׯ�ݸ�,�݌ɏ��,���̑���گĂɊ֌W������S�č폜
                        '************************************************************************
                        Call ClearDustProcess(objTPRG_TRK_BUF_HIRA.FPALLET_ID)


                    End If


                Next
            End If


        Next


        '************************************************
        '�Ԕԕ\��               OFF
        '�Ґ���                 OFF
        '�o�Ɋ�������           OFF
        '************************************************
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        Call objSVR_190001.SendYasukawa_IDDispSyaban(objXSTS_BERTH.XBERTH_GROUP, FLAG_OFF)
        Call objSVR_190001.SendYasukawa_IDDispHensei(objXSTS_BERTH.XBERTH_GROUP, FLAG_OFF)
        Call objSVR_190001.SendYasukawa_IDDispOutEnd(objXSTS_BERTH.XBERTH_GROUP, FLAG_OFF)


        '**************************************************
        '����ذ�ޓǎ抮���ޯ�           OFF
        '**************************************************
        Select Case objXSTS_BERTH.XBERTH_NO
            Case XBERTH_NO_JX01, XBERTH_NO_JX02, XBERTH_NO_JX03
                '============================================
                '����ذ�ޓǎ抮��           OFF
                '============================================
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_15, FTEXT_ID_JW_ETC, FLAG_OFF)
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_14, FTEXT_ID_JW_ETC, FLAG_OFF)
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_13, FTEXT_ID_JW_ETC, FLAG_OFF)
                ''============================================
                ''�����߲�ď�����            OFF
                ''============================================
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_15, FTEXT_ID_JW_ETC, FLAG_OFF)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_14, FTEXT_ID_JW_ETC, FLAG_OFF)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_13, FTEXT_ID_JW_ETC, FLAG_OFF)
                ''============================================
                ''���q���۰�   �\���Տo��
                ''============================================
                'Call objSVR_190001.SendCar_IDJS_CARD02()
            Case XBERTH_NO_JX04, XBERTH_NO_JX05, XBERTH_NO_JX06
                '============================================
                '����ذ�ޓǎ抮��           OFF
                '============================================
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_12, FTEXT_ID_JW_ETC, FLAG_OFF)
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_11, FTEXT_ID_JW_ETC, FLAG_OFF)
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_10, FTEXT_ID_JW_ETC, FLAG_OFF)
                ''============================================
                ''�����߲�ď�����            OFF
                ''============================================
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_12, FTEXT_ID_JW_ETC, FLAG_OFF)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_11, FTEXT_ID_JW_ETC, FLAG_OFF)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_10, FTEXT_ID_JW_ETC, FLAG_OFF)
                ''============================================
                ''���q���۰�   �\���Տo��
                ''============================================
                'Call objSVR_190001.SendCar_IDJS_CARD02()
        End Select


        '**********************************************************************************************
        '**********************************************************************************************
        '�o�׎w������
        '**********************************************************************************************
        '**********************************************************************************************
        '************************************************
        '�o�׎w���ڍ�(�v�淰)                   �擾
        '************************************************
        Dim objXPLN_OUT_DTL01 As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        If (IsNotNull(dtmXDSPSYUKKA_D) And IsNotNull(strXDSPHENSEI_NO_OYA)) _
           Or (IsNotNull(strFPLAN_KEY)) _
           Then
            objXPLN_OUT_DTL01.XSYUKKA_D = dtmXDSPSYUKKA_D               '�o�ד�
            objXPLN_OUT_DTL01.XHENSEI_NO_OYA = strXDSPHENSEI_NO_OYA     '�e�Ґ�No.
        Else
            objXPLN_OUT_DTL01.FPLAN_KEY = strFPLAN_KEY                  '�v�淰
        End If
        intRet = objXPLN_OUT_DTL01.GET_XPLN_OUT_DTL_ANY()               '�擾
        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[�o�ד�:" & objXPLN_OUT_DTL01.XSYUKKA_D & "][�e�Ґ�No.:" & objXPLN_OUT_DTL01.XHENSEI_NO_OYA & "][�v�淰:" & objXPLN_OUT_DTL01.FPLAN_KEY & "]")


        '************************************************
        '�o�׎w���ڍ�(�o�ד��A�e�Ґ���)         �擾
        '************************************************
        Dim objAryXPLN_OUT_DTL02 As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT_DTL02.XSYUKKA_D = objXPLN_OUT_DTL01.ARYME(0).XSYUKKA_D               '�o�ד�
        objAryXPLN_OUT_DTL02.XHENSEI_NO_OYA = objXPLN_OUT_DTL01.ARYME(0).XHENSEI_NO_OYA     '�e�Ґ�No.
        intRet = objAryXPLN_OUT_DTL02.GET_XPLN_OUT_DTL_ANY()                                '�擾
        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[�o�ד�:" & objAryXPLN_OUT_DTL02.XSYUKKA_D & "][�e�Ґ�No.:" & objAryXPLN_OUT_DTL02.XHENSEI_NO_OYA & "]")
        For ii As Integer = 0 To UBound(objAryXPLN_OUT_DTL02.ARYME)
            '(ٰ��:�擾����ں��ސ�)

            '=====================================
            '�o�׏󋵏ڍ�       �X�V
            '=====================================
            objAryXPLN_OUT_DTL02.ARYME(ii).XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JTUMI      '�o�׏󋵏ڍ�
            objAryXPLN_OUT_DTL02.ARYME(ii).UPDATE_XPLN_OUT_DTL()                        '�X�V

        Next


        '************************************************
        '�o�׎w��(�o�ד��A�e�Ґ���)         �擾
        '************************************************
        Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT.XSYUKKA_D = objXPLN_OUT_DTL01.ARYME(0).XSYUKKA_D             '�o�ד�
        objAryXPLN_OUT.XHENSEI_NO_OYA = objXPLN_OUT_DTL01.ARYME(0).XHENSEI_NO_OYA   '�e�Ґ�No.
        intRet = objAryXPLN_OUT.GET_XPLN_OUT_ANY()                                  '�擾
        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[�o�ד�:" & objAryXPLN_OUT.XSYUKKA_D & "][�e�Ґ�No.:" & objAryXPLN_OUT.XHENSEI_NO_OYA & "]")
        For ii As Integer = 0 To UBound(objAryXPLN_OUT.ARYME)
            '(ٰ��:�擾����ں��ސ�)

            '=====================================
            '�o�׏󋵏ڍ�       �X�V
            '=====================================
            objAryXPLN_OUT.ARYME(ii).XSYUKKA_STS = XSYUKKA_STS_JTUMI        '�o�׏󋵏ڍ�
            If IsNull(objAryXPLN_OUT.ARYME(ii).XTUMI_END_DT) Then objAryXPLN_OUT.ARYME(ii).XTUMI_END_DT = Now '�ύ���������
            objAryXPLN_OUT.ARYME(ii).UPDATE_XPLN_OUT()                      '�X�V

        Next


        '**********************************************************************************************
        '**********************************************************************************************
        '�ް��J������
        '**********************************************************************************************
        '**********************************************************************************************
        Dim strSQL As String                    'SQL��

        '-------------------
        '�o���ް��󋵓Ǎ�
        '-------------------
        Dim objXSTS_BERTH_ALL As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)     '�o���ް��󋵸׽
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    *"
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    XSTS_BERTH"                                     '�o���ް���
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "    XBERTH_NO"                                      '�ް���
        strSQL &= vbCrLf
        objXSTS_BERTH_ALL.USER_SQL = strSQL
        objXSTS_BERTH_ALL.GET_XSTS_BERTH_USER()

        '-------------------
        '�ް��g�p�󋵍X�V
        '-------------------
        intRet = Get_Barth_Data(strXDSPBERTH_NO, objXSTS_BERTH_ALL, objXSTS_BERTH)
        objXSTS_BERTH.XSYUKKA_D = DEFAULT_DATE                      '�o�ד�
        objXSTS_BERTH.XHENSEI_NO = DEFAULT_STRING                   '�Ґ�No.
        objXSTS_BERTH.XSYUKKA_D_RIN1 = DEFAULT_DATE                 '�א�1�o�ד�
        objXSTS_BERTH.XHENSEI_NO_OYA_RIN1 = DEFAULT_STRING          '�א�1�e�Ґ�No.
        objXSTS_BERTH.XSYUKKA_D_RIN2 = DEFAULT_DATE                 '�א�2�o�ד�
        objXSTS_BERTH.XHENSEI_NO_OYA_RIN2 = DEFAULT_STRING          '�א�2�e�Ґ�No.
        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JAKI                  '�ް��g�p��
        objXSTS_BERTH.FUPDATE_DT = Now                              '�X�V����
        objXSTS_BERTH.UPDATE_XSTS_BERTH()

        If TO_INTEGER(objAryXPLN_OUT.ARYME(0).XTUMI_HOUHOU) = XTUMI_HOUHOU_JL Then
            '۰�ސς̏ꍇ�́A�{���ް��̊J���̂�(���̊J���͍s��Ȃ�)
        Else
            Select Case TO_INTEGER(objAryXPLN_OUT.ARYME(0).XTUMI_HOUKOU)
                Case XTUMI_HOUKOU_JBACK         '��ς�
                    'NOP
                Case XTUMI_HOUKOU_JSIDE         '�Љ��ς�
                    '-------------------
                    '���ް�(��)��ԍX�V
                    '-------------------
                    Dim strBth_Prev = ""
                    intRet = Get_Barth_Prev(strXDSPBERTH_NO, strBth_Prev)
                    intRet = Get_Barth_Data(strBth_Prev, objXSTS_BERTH_ALL, objXSTS_BERTH)
                    objXSTS_BERTH.XSYUKKA_D_RIN2 = DEFAULT_DATE                         '�א�2�o�ד�
                    objXSTS_BERTH.XHENSEI_NO_OYA_RIN2 = DEFAULT_STRING                  '�א�2�e�Ґ�No.
                    If objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUPDOWN Then
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUP                       '�ް��g�p��
                    Else
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JAKI                      '�ް��g�p��
                    End If
                    objXSTS_BERTH.FUPDATE_DT = Now                                      '�X�V����
                    objXSTS_BERTH.UPDATE_XSTS_BERTH()

                Case XTUMI_HOUKOU_JWING         '�����ς�
                    '-------------------
                    '�����ް�(��)��ԍX�V
                    '-------------------
                    Dim strBth_Prev = ""
                    intRet = Get_Barth_Prev(strXDSPBERTH_NO, strBth_Prev)
                    intRet = Get_Barth_Data(strBth_Prev, objXSTS_BERTH_ALL, objXSTS_BERTH)
                    objXSTS_BERTH.XSYUKKA_D_RIN2 = DEFAULT_DATE                         '�א�2�o�ד�
                    objXSTS_BERTH.XHENSEI_NO_OYA_RIN2 = DEFAULT_STRING                  '�א�2�e�Ґ�No.
                    If objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUPDOWN Then
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUP                       '�ް��g�p��
                    Else
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JAKI                      '�ް��g�p��
                    End If
                    objXSTS_BERTH.FUPDATE_DT = Now                                      '�X�V����
                    objXSTS_BERTH.UPDATE_XSTS_BERTH()

                    '-------------------
                    '�����ް�(��)��ԍX�V
                    '-------------------
                    Dim strBth_Next = ""
                    intRet = Get_Barth_Next(strXDSPBERTH_NO, strBth_Next)
                    intRet = Get_Barth_Data(strBth_Next, objXSTS_BERTH_ALL, objXSTS_BERTH)
                    objXSTS_BERTH.XSYUKKA_D_RIN1 = DEFAULT_DATE                         '�א�1�o�ד�
                    objXSTS_BERTH.XHENSEI_NO_OYA_RIN1 = DEFAULT_STRING                  '�א�1�e�Ґ�No.
                    If objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUPDOWN Then
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JDOWN                     '�ް��g�p��
                    Else
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JAKI                      '�ް��g�p��
                    End If
                    objXSTS_BERTH.FUPDATE_DT = Now                                      '�X�V����
                    objXSTS_BERTH.UPDATE_XSTS_BERTH()
            End Select
        End If


        '**************************************************
        '���q���۰�   �\���Տo��
        '**************************************************
        Select Case objXSTS_BERTH.XBERTH_NO
            Case XBERTH_NO_JX01, XBERTH_NO_JX02, XBERTH_NO_JX03, XBERTH_NO_JX04, XBERTH_NO_JX05, XBERTH_NO_JX06
                '============================================
                '���q���۰�   �\���Տo��
                '============================================
                Call objSVR_190001.SendCar_IDJS_CARD02()
        End Select


        Return intReturn
    End Function
#End Region

    '�o�׎w���A�o�Ɏ��яڍׁ@�̒ǉ��X�V
#Region "  �o�׎w���A�o�׎w���ڍׁA�o�Ɏ��яڍ�  �̒ǉ��X�V                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�׎w���A�o�׎w���ڍׁA�o�Ɏ��яڍ�  �̒ǉ��X�V
    ''' </summary>
    ''' <param name="objTRST_STOCK">�݌ɏ��</param>
    ''' <param name="objTMST_ITEM">�i��Ͻ�</param>
    ''' <param name="strFPLAN_KEY">�v�淰</param>
    ''' <param name="intHikiateNum">��������</param>
    ''' <param name="intFBUF_FM">�������ׯ�ݸ��ޯ̧��</param>
    ''' <param name="intFARRAY_FM">�������ׯ�ݸ��ޯ̧�z��</param>
    ''' <param name="intFBUF_TO">�������ׯ�ݸ��ޯ̧��</param>
    ''' <param name="intFARRAY_TO">�������ׯ�ݸ��ޯ̧�z��</param>
    ''' <param name="blnHiraoki">���u�����ۂ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateHiraokiUpdate(ByVal objTRST_STOCK As TBL_TRST_STOCK _
                                             , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                             , ByVal strFPLAN_KEY As String _
                                             , ByVal intHikiateNum As Integer _
                                             , ByVal intFBUF_FM As Integer _
                                             , ByVal intFARRAY_FM As Integer _
                                             , ByVal intFBUF_TO As Integer _
                                             , ByVal intFARRAY_TO As Integer _
                                             , ByVal blnHiraoki As Boolean _
                                             ) _
                                             As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        '�o�׎w���A�o�׎w���ڍ�ð���            �X�V
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '�o�׎w���ڍ�(�X�V�p)           �擾
        '************************************************
        Dim objXPLN_OUT_DTL_Update As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objXPLN_OUT_DTL_Update.FPLAN_KEY = strFPLAN_KEY                     '�v�淰
        intRet = objXPLN_OUT_DTL_Update.GET_XPLN_OUT_DTL(False)             '�擾
        If intRet <> RetCode.OK Then
            Return RetCode.OK
        End If


        '************************************************
        '�o�׎w���ڍ�(�X�V�p)           �X�V
        '************************************************
        objXPLN_OUT_DTL_Update.XSYUKKA_KON_RESULT += intHikiateNum              '�o�׎��э���
        If objXPLN_OUT_DTL_Update.XSYUKKA_KON_PLAN <= objXPLN_OUT_DTL_Update.XSYUKKA_KON_RESULT Then
            '(�o�ח\�荫�� <= �o�׎��э��� �̏ꍇ)
            If objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL <> XSYUKKA_STS_DTL_JTUMI Then
                '(�ύ��ψȊO�̏ꍇ)
                objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JALL       '�o�׏󋵏ڍ�
            End If
        Else
            If objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL <> XSYUKKA_STS_DTL_JLESS Then
                '(���i�ȊO�̏ꍇ)
                If blnHiraoki = False Then
                    '(���u���ȊO�̏ꍇ)
                    If objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL <> XSYUKKA_STS_DTL_JTUMI Then
                        '(�ύ��ψȊO�̏ꍇ)
                        objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JOUT   '�o�׏󋵏ڍ�
                    End If
                End If
            End If
        End If
        If blnHiraoki Then
            '(���u���̏ꍇ)
            objXPLN_OUT_DTL_Update.XSYUKKA_KON_H_RESULT = TO_INTEGER(objXPLN_OUT_DTL_Update.XSYUKKA_KON_H_RESULT) + intHikiateNum
        End If
        objXPLN_OUT_DTL_Update.UPDATE_XPLN_OUT_DTL()                            '�X�V


        '************************************************
        '�o�׎w���ڍ�(�����p)           �擾
        '************************************************
        Dim blnXSYUKKA_STS_DTL_JALL As Boolean = False          '�S�i�o�ɔ���
        Dim objAryXPLN_OUT_DTL_Check As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT_DTL_Check.XSYUKKA_D = objXPLN_OUT_DTL_Update.XSYUKKA_D                   '�o�ד�
        objAryXPLN_OUT_DTL_Check.XHENSEI_NO_OYA = objXPLN_OUT_DTL_Update.XHENSEI_NO_OYA         '�e�Ґ�No.
        intRet = objAryXPLN_OUT_DTL_Check.GET_XPLN_OUT_DTL_ANY()                                '�擾
        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[�o�ד�:" & objAryXPLN_OUT_DTL_Check.XSYUKKA_D & "][�e�Ґ�No.:" & objAryXPLN_OUT_DTL_Check.XHENSEI_NO_OYA & "]")
        For ii As Integer = 0 To UBound(objAryXPLN_OUT_DTL_Check.ARYME)
            '(ٰ��:�擾����ں��ސ�)

            '=====================================
            '�o�׏󋵏ڍ�       ����
            '=====================================
            If objAryXPLN_OUT_DTL_Check.ARYME(ii).XSYUKKA_STS_DTL <> XSYUKKA_STS_DTL_JALL Then
                '(�o�׏󋵏ڍ� <> �o�ɍ� �̏ꍇ)
                Exit For
            End If
            If UBound(objAryXPLN_OUT_DTL_Check.ARYME) <= ii Then
                blnXSYUKKA_STS_DTL_JALL = True
            End If

        Next


        '************************************************
        '�o�׎w��                       �擾
        '************************************************
        Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT.XSYUKKA_D = objXPLN_OUT_DTL_Update.XSYUKKA_D            '�o�ד�
        objAryXPLN_OUT.XHENSEI_NO_OYA = objXPLN_OUT_DTL_Update.XHENSEI_NO_OYA  '�e�Ґ�No.
        intRet = objAryXPLN_OUT.GET_XPLN_OUT_ANY()                             '�擾
        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[�o�ד�:" & objAryXPLN_OUT.XSYUKKA_D & "][�e�Ґ�No.:" & objAryXPLN_OUT.XHENSEI_NO_OYA & "]")


        '************************************************
        '�o�׎w��                       �X�V
        '************************************************
        If blnXSYUKKA_STS_DTL_JALL = True Then
            '(�S�i�o�ɂ̏ꍇ)
            For ii As Integer = 0 To UBound(objAryXPLN_OUT.ARYME)
                '(ٰ��:�擾����ں��ސ�)

                If objAryXPLN_OUT.ARYME(ii).XSYUKKA_STS <> XSYUKKA_STS_JTUMI Then
                    '(�ύ��ψȊO�̏ꍇ)
                    objAryXPLN_OUT.ARYME(ii).XSYUKKA_STS = XSYUKKA_STS_JOUT      '�o�׏�
                End If
                If IsNull(objAryXPLN_OUT.ARYME(ii).XOUT_START_DT) Then objAryXPLN_OUT.ARYME(ii).XOUT_START_DT = Now '�o�ɊJ�n����
                If IsNull(objAryXPLN_OUT.ARYME(ii).XOUT_END_DT) Then objAryXPLN_OUT.ARYME(ii).XOUT_END_DT = Now '�o�Ɋ�������
                objAryXPLN_OUT.ARYME(ii).UPDATE_XPLN_OUT()                   '�X�V

            Next


            '************************************************
            '�o���ް���           �擾
            '************************************************
            Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
            objXSTS_BERTH.XBERTH_NO = objAryXPLN_OUT.ARYME(0).XBERTH_NO '�ް���
            objXSTS_BERTH.GET_XSTS_BERTH()                              '�擾


            '************************************************
            '�o�Ɋ�������           ON
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            Call objSVR_190001.SendYasukawa_IDDispOutEnd(objXSTS_BERTH.XBERTH_GROUP, FLAG_ON)


            ''************************************************
            '' �o�׺���ԏ�             �擾
            ''************************************************
            'Dim objXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
            'objXSTS_CONVEYOR.XSTNO = intFBUF_TO                     'STNo.
            'intRet = objXSTS_CONVEYOR.GET_XSTS_CONVEYOR(False)      '�擾
            'If intRet = RetCode.OK Then
            '    '(���������ꍇ)
            '    '(ST�̏ꍇ)


            '    '************************************************
            '    '�o�Ɋ�������           ON
            '    '************************************************
            '    Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            '    Call objSVR_190001.SendYasukawa_IDDispOutEnd(objXSTS_CONVEYOR.XBERTH_GROUP, FLAG_ON)


            'End If


        End If


        '************************************************************************************************
        '************************************************************************************************
        '�o�Ɏ��яڍ�               �ǉ�
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '�o�׎��яڍ�                   �ǉ�
        '************************************************
        Dim objXRST_OUT_DTL As New TBL_XRST_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objXRST_OUT_DTL.XSYUKKA_D = objXPLN_OUT_DTL_Update.XSYUKKA_D            '�o�ד�
        objXRST_OUT_DTL.XHENSEI_NO = objXPLN_OUT_DTL_Update.XHENSEI_NO          '�Ґ�No.
        objXRST_OUT_DTL.XDENPYOU_NO = objXPLN_OUT_DTL_Update.XDENPYOU_NO        '�`�[No.
        objXRST_OUT_DTL.XSYUKKA_RESULT_DT = Now                                 '�o�׎��ѓ���
        objXRST_OUT_DTL.FPALLET_ID = objTRST_STOCK.ARYME(0).FPALLET_ID          '��گ�ID
        objXRST_OUT_DTL.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD          '�i�ں���
        objXRST_OUT_DTL.FLOT_NO = objTRST_STOCK.ARYME(0).FLOT_NO                'ۯć�
        objXRST_OUT_DTL.XNUM = intHikiateNum                                    '����
        objXRST_OUT_DTL.XTUMI_HOUKOU = objAryXPLN_OUT.ARYME(0).XTUMI_HOUKOU     '�ύ�����
        objXRST_OUT_DTL.XTUMI_HOUHOU = objAryXPLN_OUT.ARYME(0).XTUMI_HOUHOU     '�ύ����@
        objXRST_OUT_DTL.FIN_KUBUN = objTRST_STOCK.ARYME(0).FIN_KUBUN            '���ɋ敪
        objXRST_OUT_DTL.FARRIVE_DT = objTRST_STOCK.ARYME(0).FARRIVE_DT          '�݌ɔ�������
        objXRST_OUT_DTL.XPROD_LINE = objTRST_STOCK.ARYME(0).XPROD_LINE          '���Yײ݇�
        objXRST_OUT_DTL.XFM_ST = objTRST_STOCK.ARYME(0).FST_FM                  '�������ð���No.
        objXRST_OUT_DTL.FBUF_FM = intFBUF_FM                                    '�������ׯ�ݸ��ޯ̧��
        objXRST_OUT_DTL.FARRAY_FM = intFARRAY_FM                                '�������ׯ�ݸ��ޯ̧�z��
        objXRST_OUT_DTL.FBUF_TO = intFBUF_TO                                    '�������ׯ�ݸ��ޯ̧��
        objXRST_OUT_DTL.FARRAY_TO = intFARRAY_TO                                '�������ׯ�ݸ��ޯ̧�z��
        objXRST_OUT_DTL.XBERTH_NO = objAryXPLN_OUT.ARYME(0).XBERTH_NO           '�ް�No.
        objXRST_OUT_DTL.XSEND_NAME = objAryXPLN_OUT.ARYME(0).XSEND_NAME         '�͂��於��
        objXRST_OUT_DTL.XGYOUSYA_CD = objAryXPLN_OUT.ARYME(0).XGYOUSYA_CD       '�����ƎҺ���
        objXRST_OUT_DTL.XHINMEI_CD = objTMST_ITEM.XHINMEI_CD                    '�i�ں���(�����i�ں���)
        objXRST_OUT_DTL.XRAC_IN_DT = objTRST_STOCK.ARYME(0).XRAC_IN_DT          '���ɓ���
        objXRST_OUT_DTL.XSYARYOU_NO = objAryXPLN_OUT.ARYME(0).XSYARYOU_NO       '���q�ԍ�
        objXRST_OUT_DTL.XKENPIN_KUBUN = objTRST_STOCK.ARYME(0).XKENPIN_KUBUN    '���i�敪
        objXRST_OUT_DTL.XSAIMOKU = objXPLN_OUT_DTL_Update.XSAIMOKU              '����敪�ז�
        objXRST_OUT_DTL.XIDOU_KBN = objXPLN_OUT_DTL_Update.XIDOU_KBN            '�ړ��敪
        objXRST_OUT_DTL.XSYASYU_KBN = objAryXPLN_OUT.ARYME(0).XSYASYU_KBN       '�Ԏ�敪
        objXRST_OUT_DTL.XARTICLE_TYPE_CODE = objTMST_ITEM.XARTICLE_TYPE_CODE    '�i�ڎ��(���i�敪)
        '������������************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/12 ����ύX
        objXRST_OUT_DTL.XUNKOU_NO = objAryXPLN_OUT.ARYME(0).XUNKOU_NO           '�q�ɕʉ^�sNo.
        objXRST_OUT_DTL.XHENSEI_NO_OYA = objAryXPLN_OUT.ARYME(0).XHENSEI_NO_OYA '�e�Ґ�No.
        'JobMate:S.Ouchi 2013/11/12 ����ύX
        '������������************************************************************************************************************
        objXRST_OUT_DTL.ADD_XRST_OUT_DTL()                                      '�ǉ�


        Return intReturn
    End Function
#End Region

    '�ް������֘A
#Region "  �O�ް����擾                 (Public  Get_Barth_Prev)"
    '==============================================================================================
    '�y�@�\�z�O�ް����擾
    '�y�����z[IN ] strBth       :
    '        [OUT] strBth_Prev  :
    '�y�ߒl�zRetCode
    '==============================================================================================
    Public Function Get_Barth_Prev(ByVal strBth As String, ByRef strBth_Prev As String) As RetCode
        Try
            Select Case strBth
                Case XBERTH_NO_JX01                                                    'X�ް�01
                    Return RetCode.NG
                Case XBERTH_NO_JX02                                                    'X�ް�02
                    strBth_Prev = XBERTH_NO_JX01
                Case XBERTH_NO_JX03                                                    'X�ް�03
                    strBth_Prev = XBERTH_NO_JX02
                Case XBERTH_NO_JX04                                                    'X�ް�04
                    strBth_Prev = XBERTH_NO_JX03
                Case XBERTH_NO_JX05                                                    'X�ް�05
                    strBth_Prev = XBERTH_NO_JX04
                Case XBERTH_NO_JX06                                                    'X�ް�06
                    strBth_Prev = XBERTH_NO_JX05
                Case XBERTH_NO_JY01                                                    'Y�ް�01
                    Return RetCode.NG
                Case XBERTH_NO_JY02                                                    'Y�ް�02
                    strBth_Prev = XBERTH_NO_JY01
                Case XBERTH_NO_JY03                                                    'Y�ް�03
                    strBth_Prev = XBERTH_NO_JY02
                Case XBERTH_NO_JY04                                                    'Y�ް�04
                    strBth_Prev = XBERTH_NO_JY03
                Case XBERTH_NO_JY05                                                    'Y�ް�05
                    Return RetCode.NG
                Case XBERTH_NO_JY06                                                    'Y�ް�06
                    strBth_Prev = XBERTH_NO_JY05
                Case XBERTH_NO_JY07                                                    'Y�ް�07
                    strBth_Prev = XBERTH_NO_JY06
                Case XBERTH_NO_JY08                                                    'Y�ް�08
                    strBth_Prev = XBERTH_NO_JY07
                Case XBERTH_NO_JY09                                                    'Y�ް�09
                    Return RetCode.NG
                Case XBERTH_NO_JY10                                                    'Y�ް�10
                    strBth_Prev = XBERTH_NO_JY09
                Case XBERTH_NO_JY11                                                    'Y�ް�11
                    strBth_Prev = XBERTH_NO_JY10
                Case XBERTH_NO_JY12                                                    'Y�ް�12
                    strBth_Prev = XBERTH_NO_JY11
                Case XBERTH_NO_JY13                                                    'Y�ް�13
                    Return RetCode.NG
                Case XBERTH_NO_JY14                                                    'Y�ް�14
                    strBth_Prev = XBERTH_NO_JY13
                Case XBERTH_NO_JY15                                                    'Y�ް�15
                    strBth_Prev = XBERTH_NO_JY14
                Case XBERTH_NO_JY16                                                    'Y�ް�16
                    strBth_Prev = XBERTH_NO_JY15
                Case XBERTH_NO_JY17                                                    'Y�ް�17
                    Return RetCode.NG
                Case XBERTH_NO_JY18                                                    'Y�ް�18
                    strBth_Prev = XBERTH_NO_JY17
                Case XBERTH_NO_JY19                                                    'Y�ް�19
                    strBth_Prev = XBERTH_NO_JY18
                Case XBERTH_NO_JY20                                                    'Y�ް�20
                    strBth_Prev = XBERTH_NO_JY19
                Case Else
                    Return RetCode.NG
            End Select

            '����I��
            Return RetCode.OK

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
#Region "  ���ް����擾                 (Public  Get_Barth_Next)"
    '==============================================================================================
    '�y�@�\�z���ް����擾
    '�y�����z[IN ] strBth       :
    '        [OUT] strBth_Next  :
    '�y�ߒl�zRetCode
    '==============================================================================================
    Public Function Get_Barth_Next(ByVal strBth As String, ByRef strBth_Next As String) As RetCode
        Try
            Select Case strBth
                Case XBERTH_NO_JX01                                                    'X�ް�01
                    strBth_Next = XBERTH_NO_JX02
                Case XBERTH_NO_JX02                                                    'X�ް�02
                    strBth_Next = XBERTH_NO_JX03
                Case XBERTH_NO_JX03                                                    'X�ް�03
                    strBth_Next = XBERTH_NO_JX04
                Case XBERTH_NO_JX04                                                    'X�ް�04
                    strBth_Next = XBERTH_NO_JX05
                Case XBERTH_NO_JX05                                                    'X�ް�05
                    strBth_Next = XBERTH_NO_JX06
                Case XBERTH_NO_JX06                                                    'X�ް�06
                    Return RetCode.NG
                Case XBERTH_NO_JY01                                                    'Y�ް�01
                    strBth_Next = XBERTH_NO_JY02
                Case XBERTH_NO_JY02                                                    'Y�ް�02
                    strBth_Next = XBERTH_NO_JY03
                Case XBERTH_NO_JY03                                                    'Y�ް�03
                    strBth_Next = XBERTH_NO_JY04
                Case XBERTH_NO_JY04                                                    'Y�ް�04
                    Return RetCode.NG
                Case XBERTH_NO_JY05                                                    'Y�ް�05
                    strBth_Next = XBERTH_NO_JY06
                Case XBERTH_NO_JY06                                                    'Y�ް�06
                    strBth_Next = XBERTH_NO_JY07
                Case XBERTH_NO_JY07                                                    'Y�ް�07
                    strBth_Next = XBERTH_NO_JY08
                Case XBERTH_NO_JY08                                                    'Y�ް�08
                    Return RetCode.NG
                Case XBERTH_NO_JY09                                                    'Y�ް�09
                    strBth_Next = XBERTH_NO_JY10
                Case XBERTH_NO_JY10                                                    'Y�ް�10
                    strBth_Next = XBERTH_NO_JY11
                Case XBERTH_NO_JY11                                                    'Y�ް�11
                    strBth_Next = XBERTH_NO_JY12
                Case XBERTH_NO_JY12                                                    'Y�ް�12
                    Return RetCode.NG
                Case XBERTH_NO_JY13                                                    'Y�ް�13
                    strBth_Next = XBERTH_NO_JY14
                Case XBERTH_NO_JY14                                                    'Y�ް�14
                    strBth_Next = XBERTH_NO_JY15
                Case XBERTH_NO_JY15                                                    'Y�ް�15
                    strBth_Next = XBERTH_NO_JY16
                Case XBERTH_NO_JY16                                                    'Y�ް�16
                    Return RetCode.NG
                Case XBERTH_NO_JY17                                                    'Y�ް�17
                    strBth_Next = XBERTH_NO_JY18
                Case XBERTH_NO_JY18                                                    'Y�ް�18
                    strBth_Next = XBERTH_NO_JY19
                Case XBERTH_NO_JY19                                                    'Y�ް�19
                    strBth_Next = XBERTH_NO_JY20
                Case XBERTH_NO_JY20                                                    'Y�ް�20
                    Return RetCode.NG
                Case Else
                    Return RetCode.NG
            End Select

            '����I��
            Return RetCode.OK

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
#Region "  �ް����擾                 (Public  Get_Barth_Data)"
    '==============================================================================================
    '�y�@�\�z�ް����擾
    '�y�����z[IN ] strBth               :
    '        [IN ] objXSTS_BERTH_ALL    :
    '        [OUT] objXSTS_BERTH        :
    '�y�ߒl�zRetCode
    '==============================================================================================
    Public Function Get_Barth_Data(ByVal strBth As String, ByVal objXSTS_BERTH_ALL As TBL_XSTS_BERTH, ByRef objXSTS_BERTH As TBL_XSTS_BERTH) As RetCode
        Try
            Dim blnFlg As Boolean
            Dim strMsg As String                                    'ү����

            '�o���ް���
            blnFlg = False
            For Each objXSTS_BERTH_WK As TBL_XSTS_BERTH In objXSTS_BERTH_ALL.ARYME
                If strBth = objXSTS_BERTH_WK.XBERTH_NO Then         '�ް���
                    objXSTS_BERTH.COPY_PROPERTY(objXSTS_BERTH_WK)
                    blnFlg = True
                End If
            Next
            If blnFlg = False Then
                strMsg = "�o���ް��󋵂ɊY���o�[�X��񖳂��B[�o�[�X��:" & strBth & "]"
                Throw New UserException(strMsg)
            End If

            '����I��
            Return RetCode.OK

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
#Region "  �ް����擾(�ݔ���Ԋ܂�)   (Public  Get_Barth_Data_EQ)"
    '==============================================================================================
    '�y�@�\�z�ް����擾
    '�y�����z[IN ] strBth       :
    '        [IN ] objPLN_OUT   :
    '�y�ߒl�zRetCode
    '==============================================================================================
    Public Function Get_Barth_Data_EQ(ByVal strBth As String, ByVal objXSTS_BERTH_ALL As TBL_XSTS_BERTH, ByVal objTSTS_EQ_ALL As TBL_TSTS_EQ_CTRL, ByRef objXSTS_BERTH As TBL_XSTS_BERTH, ByRef objTSTS_EQ As TBL_TSTS_EQ_CTRL) As RetCode
        Try
            Dim blnFlg As Boolean
            Dim strMsg As String                                    'ү����

            '�o���ް���
            blnFlg = False
            For Each objXSTS_BERTH_WK As TBL_XSTS_BERTH In objXSTS_BERTH_ALL.ARYME
                If strBth = objXSTS_BERTH_WK.XBERTH_NO Then         '�ް���
                    objXSTS_BERTH.COPY_PROPERTY(objXSTS_BERTH_WK)
                    blnFlg = True
                End If
            Next
            If blnFlg = False Then
                strMsg = "�o���ް��󋵂ɊY���o�[�X��񖳂��B[�o�[�X��:" & strBth & "]"
                Throw New UserException(strMsg)
            End If

            '�ݔ���
            blnFlg = False
            For Each objTSTS_EQ_WK As TBL_TSTS_EQ_CTRL In objTSTS_EQ_ALL.ARYME
                If strBth = objTSTS_EQ_WK.FEQ_ID Then               '�ݔ�ID(�ް���)
                    objTSTS_EQ.COPY_PROPERTY(objTSTS_EQ_WK)
                    blnFlg = True
                End If
            Next
            If blnFlg = False Then
                strMsg = "�ݔ��󋵂ɊY���ݔ�ID�����B[�ݔ�ID:" & strBth & "]"
                Throw New UserException(strMsg)
            End If

            '����I��
            Return RetCode.OK

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
#Region "  ۰���ް������@�擾           (Public  Get_LOADER_GOUKI)"
    '==============================================================================================
    '�y�@�\�z۰���ް������@�擾
    '�y�����z[IN ] strBth       :
    '�y�ߒl�z���@
    '==============================================================================================
    Public Function Get_LOADER_GOUKI(ByVal strBth As String) As Integer
        Try
            Select Case strBth
                Case XBERTH_NO_JX01                                                    'X�ް�01
                    Return 1
                Case XBERTH_NO_JX02                                                    'X�ް�02
                    Return 1
                Case XBERTH_NO_JX03                                                    'X�ް�03
                    Return 1
                Case XBERTH_NO_JX04                                                    'X�ް�04
                    Return 2
                Case XBERTH_NO_JX05                                                    'X�ް�05
                    Return 2
                Case XBERTH_NO_JX06                                                    'X�ް�06
                    Return 2
                Case XBERTH_NO_JY01                                                    'Y�ް�01
                    Return 0
                Case XBERTH_NO_JY02                                                    'Y�ް�02
                    Return 0
                Case XBERTH_NO_JY03                                                    'Y�ް�03
                    Return 0
                Case XBERTH_NO_JY04                                                    'Y�ް�04
                    Return 0
                Case XBERTH_NO_JY05                                                    'Y�ް�05
                    Return 0
                Case XBERTH_NO_JY06                                                    'Y�ް�06
                    Return 0
                Case XBERTH_NO_JY07                                                    'Y�ް�07
                    Return 0
                Case XBERTH_NO_JY08                                                    'Y�ް�08
                    Return 0
                Case XBERTH_NO_JY09                                                    'Y�ް�09
                    Return 0
                Case XBERTH_NO_JY10                                                    'Y�ް�10
                    Return 0
                Case XBERTH_NO_JY11                                                    'Y�ް�11
                    Return 0
                Case XBERTH_NO_JY12                                                    'Y�ް�12
                    Return 0
                Case XBERTH_NO_JY13                                                    'Y�ް�13
                    Return 0
                Case XBERTH_NO_JY14                                                    'Y�ް�14
                    Return 0
                Case XBERTH_NO_JY15                                                    'Y�ް�15
                    Return 0
                Case XBERTH_NO_JY16                                                    'Y�ް�16
                    Return 0
                Case XBERTH_NO_JY17                                                    'Y�ް�17
                    Return 0
                Case XBERTH_NO_JY18                                                    'Y�ް�18
                    Return 0
                Case XBERTH_NO_JY19                                                    'Y�ް�19
                    Return 0
                Case XBERTH_NO_JY20                                                    'Y�ް�20
                    Return 0
                Case Else
                    Return 0
            End Select

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region

    '�󎚊֘A
#Region "  �߯�ݸ�ؽĈ󎚏o��                                       "
    '''*************************************************************************************************************
    ''' <summary>
    ''' �߯�ݸ�ؽĈ󎚏o��
    ''' </summary>
    ''' <param name="dtmXSYUKKA_D">�o�ד�</param>
    ''' <param name="strXHENSEI_NO_OYA">�e�Ґ�No.</param>
    ''' <remarks></remarks>
    '''*************************************************************************************************************
    Public Sub PrintPickingList(ByVal dtmXSYUKKA_D As Date _
                              , ByVal strXHENSEI_NO_OYA As String _
                              )

        '***********************************************
        ' �e��޼ު�Ă̲ݽ�ݽ
        '***********************************************
        Dim objCR As New PRT_311050_01          '�ؽ����߰ĵ�޼ު��
        Dim objDataSet As New clsPrintDataSet   '�ް�ð��ٵ�޼ު��
        Dim objComFuncFRM As New clsComFuncFRM  '�W���@�\(GamenMate.clsComFuncFRM����߰)

        Try
            Dim intRet As Integer = 0

            '************************************************************
            ' ͯ�ް�����擾
            '************************************************************
            'ͯ�ް���ϐ�
            Dim strXSYUKKA_D As String = ""                 '�o�ד�
            Dim strXSYARYOU_NO As String = ""               '���qNo.
            Dim strXBERTH_NO As String = ""                 '�ް�No.
            Dim strXTUMI_HOUHOU As String = ""              '�ύ����@
            Dim strXTUMI_HOUKOU As String = ""              '�ύ�����
            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
            Dim strSAIMOKU As String = ""                   '�ז�
            Dim strGYOUSYA As String = ""                   '�Ǝ�
            'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
            '������������************************************************************************************************************

            Dim objTBL_XPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, Nothing)
            objTBL_XPLN_OUT.XHENSEI_NO_OYA = strXHENSEI_NO_OYA     '�e�Ґ�No.
            objTBL_XPLN_OUT.XSYUKKA_D = dtmXSYUKKA_D               '�o�ד�
            intRet = objTBL_XPLN_OUT.GET_XPLN_OUT_ANY()
            If intRet <> RetCode.OK Then
                '(�ް��擾���s��)
                Exit Try
            End If


            For Each objTBL_XPLN_OUT_DATA As TBL_XPLN_OUT In objTBL_XPLN_OUT.ARYME
                strXSYARYOU_NO = TO_STRING(objTBL_XPLN_OUT_DATA.XSYARYOU_NO)     '���qNo.
                strXBERTH_NO = TO_STRING(objTBL_XPLN_OUT_DATA.XBERTH_NO)         '�ް�No.
                strXTUMI_HOUHOU = TO_STRING(objTBL_XPLN_OUT_DATA.XTUMI_HOUHOU)   '�ύ����@
                strXTUMI_HOUKOU = TO_STRING(objTBL_XPLN_OUT_DATA.XTUMI_HOUKOU)   '�ύ�����
            Next


            '************************************************************
            ' �ް������擾
            '************************************************************
            Dim strSQL As String                        'SQL��
            Dim objRow As DataRow                       '1ں��ޕ����ް�
            Dim strDataSetName As String                '�ް���Ė�
            Dim objTBLDataSet As New DataSet            '�ް���āi�ް��擾�p�j

            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
            ' '' ''============================================================
            ' '' ''SELECT
            ' '' ''============================================================

            '' ''strSQL = ""
            '' ''strSQL &= vbCrLf & "SELECT "
            '' ''strSQL &= vbCrLf & "    XPLN_OUT_DTL.XHENSEI_NO "                                       '�o�׎w���ڍ�.      �Ґ�No.
            '' ''strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XDENPYOU_NO "                                      '�o�׎w���ڍ�.      �`�[No.
            '' ''strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XOUT_ORDER "                                       '�o�׎w���ڍ�.  �@�@���q���o�וi�ڏ�
            '' ''strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                                          '�i��Ͻ�.�@�@       �i������
            '' ''strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                                       '�o�׎w���ڍ�.      �i���L��
            '' ''strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                                             '�i��Ͻ�.�@�@       �i��
            '' ''strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESERVE,0) XSYUKKA_KON_RESERVE "   '�o�׎w���ڍ�.  �@�@�o�׈�������
            '' ''strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_H_RESULT, 0) XSYUKKA_KON_H_RESULT" '�o�׎w���ڍ�.      �o�׎��э���
            '' ''strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FPLAN_KEY "                                        '�o�׎w���ڍ�.      �v�淰

            ' '' ''============================================================
            ' '' ''FROM
            ' '' ''============================================================
            '' ''strSQL &= vbCrLf & " FROM "
            '' ''strSQL &= vbCrLf & "    XPLN_OUT_DTL "           '�y�o�׎w���ڍׁz
            '' ''strSQL &= vbCrLf & "  , TMST_ITEM "              '�y�i��Ͻ��z

            ' '' ''============================================================
            ' '' ''WHERE
            ' '' ''============================================================
            '' ''strSQL &= vbCrLf & " WHERE "
            '' ''strSQL &= vbCrLf & "         1 = 1 "
            '' ''strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = '" & strXHENSEI_NO_OYA & "' "    '�o�׎w���ڍ� �� �e�Ґ�No. �œ���
            '' ''strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_D = '" & dtmXSYUKKA_D & "' "              '�o�׎w���ڍ� �� �o�ד� �œ���
            '' ''strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "               '�o�׎w���ڍ� �� �i��Ͻ� �� �i�ں��� �Ō���

            ' '' ''============================================================
            ' '' ''ORDER BY
            ' '' ''============================================================
            '' ''strSQL &= vbCrLf & " ORDER BY "
            '' ''strSQL &= vbCrLf & "         XPLN_OUT_DTL.XOUT_ORDER "                                      '�o�׎w���ڍ�.  �@�@���q���o�וi�ڏ�


            '============================================================
            'SELECT
            '============================================================
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "    XPLN_OUT_DTL.XHENSEI_NO "                                       '�o�׎w���ڍ�.      �Ґ�No.
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XDENPYOU_NO "                                      '�o�׎w���ڍ�.      �`�[No.
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XOUT_ORDER "                                       '�o�׎w���ڍ�.  �@�@���q���o�וi�ڏ�
            strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                                          '�i��Ͻ�.�@�@       �i������
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                                       '�o�׎w���ڍ�.      �i���L��
            strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                                             '�i��Ͻ�.�@�@       �i��
            strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESERVE,0) XSYUKKA_KON_RESERVE "   '�o�׎w���ڍ�.  �@�@�o�׈�������
            strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_H_RESULT, 0) XSYUKKA_KON_H_RESULT" '�o�׎w���ڍ�.      �o�׎��э���
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FPLAN_KEY "                                        '�o�׎w���ڍ�.      �v�淰
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSAIMOKU "                                         '�o�׎w���ڍ�.      ����敪�ז�
            strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSAIMOKU_Dsp "                            '�o�׎w���ڍ�.      ����敪�ז�(�\���p)
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XIDOU_KBN "                                        '�o�׎w���ڍ�.      �ړ��敪
            strSQL &= vbCrLf & "  , XPLN_OUT.XGYOUSYA_CD "                                          '�o�׎w��.          �ƎҺ���
            strSQL &= vbCrLf & "  , XMST_GYOUSYA.XGYOUSYA_NAME "                                    '�Ǝ�Ͻ�.           �ƎҖ�
            strSQL &= vbCrLf & "  , TMST_ITEM.FNUM_IN_PALLET "                                      '�i��Ͻ�.�@�@       PL���ύڐ�
            strSQL &= vbCrLf & "  , TMST_ITEM.XPLANE_PACK_NUMBER "                                  '�i��Ͻ�.�@�@       ���ʍ���

            '============================================================
            'FROM
            '============================================================
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    XPLN_OUT_DTL "           '�y�o�׎w���ڍׁz
            strSQL &= vbCrLf & "  , TMST_ITEM "              '�y�i��Ͻ��z
            strSQL &= vbCrLf & "  , XPLN_OUT "               '�y�o�׎w���z
            strSQL &= vbCrLf & "  , XMST_GYOUSYA "           '�y�Ǝ�Ͻ��z
            strSQL &= vbCrLf & "  ,(SELECT * FROM TDSP_DISP WHERE FTABLE_NAME = 'XPLN_OUT_DTL' AND FFIELD_NAME = 'XSAIMOKU') HASH01 "

            '============================================================
            'WHERE
            '============================================================
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "         1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = '" & strXHENSEI_NO_OYA & "' "    '�o�׎w���ڍ� �� �e�Ґ�No. �œ���
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_D = '" & dtmXSYUKKA_D & "' "              '�o�׎w���ڍ� �� �o�ד� �œ���
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "               '�o�׎w���ڍ� �� �i��Ͻ� �� �i�ں��� �Ō���
            strSQL &= vbCrLf & "     AND HASH01.FDISP_VALUE(+) = XPLN_OUT_DTL.XSAIMOKU "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_D = XPLN_OUT.XSYUKKA_D "                  '�o�׎w���ڍ� �� �o�׎w�� �� �o�ד� �œ���
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO = XPLN_OUT.XHENSEI_NO "                '�o�׎w���ڍ� �� �o�׎w�� �� �e�Ґ�No. �œ���
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XDENPYOU_NO = XPLN_OUT.XDENPYOU_NO "              '�o�׎w���ڍ� �� �o�׎w�� �� �`�[No. �œ���
            strSQL &= vbCrLf & "     AND XMST_GYOUSYA.XGYOUSYA_CD = XPLN_OUT.XGYOUSYA_CD "              '�o�׎w��     �� �Ǝ�Ͻ�  �� �ƎҺ��� �œ���

            '============================================================
            'ORDER BY
            '============================================================
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "         XPLN_OUT_DTL.XOUT_ORDER "                                      '�o�׎w���ڍ�.  �@�@���q���o�וi�ڏ�
            'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
            '������������************************************************************************************************************

            '-----------------------
            '���o
            '-----------------------
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "XPLN_OUT_DTL"
            ObjDb.GetDataSet(strDataSetName, objDataSet)


            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows

                    Dim strXHENSEI_NO As String = ""                '�Ґ�No.
                    Dim strXDENPYOU_NO As String = ""               '�`�[No.
                    Dim strXOUT_ORDER As String = ""                '�o�ɏ�
                    Dim strXHINMEI_CD As String = ""                '�i������
                    Dim strFHINMEI_CD As String = ""                '�i���L��
                    Dim strFHINMEI As String = ""                   '�i��
                    Dim strXSYUKKA_KON_RESERVE As String = ""       '�o�א�
                    Dim strXSYUKKA_KON_H_RESULT As String = ""      '���u
                    '������������************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    Dim strFNUM_IN_PALLET As String = ""            'PL���ύڐ�
                    Dim strMODOSHI_NUM As String = ""               '���u���߂���

                    If strSAIMOKU = "" Then
                        strSAIMOKU = TO_STRING(objRow("XSAIMOKU_Dsp"))
                        If TO_INTEGER(objRow("XSAIMOKU")) = XSAIMOKU_JIDOU Then
                            '(�זڂ��ړ��̏ꍇ)
                            If TO_INTEGER(objRow("XIDOU_KBN")) = XIDOU_KBN_JIDOU Then
                                '(�ړ��敪��1�̏ꍇ)
                                strSAIMOKU = "�ړ�-1"
                            End If
                        End If
                    End If

                    If strGYOUSYA = "" Then
                        strGYOUSYA = TO_STRING(objRow("XGYOUSYA_NAME"))
                    End If
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    '������������************************************************************************************************************

                    '�ް���
                    strXHENSEI_NO = TO_STRING(objRow("XHENSEI_NO"))
                    strXDENPYOU_NO = TO_STRING(objRow("XDENPYOU_NO"))
                    strXOUT_ORDER = TO_STRING(objRow("XOUT_ORDER"))
                    strXHINMEI_CD = TO_STRING(objRow("XHINMEI_CD"))
                    strFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
                    strFHINMEI = TO_STRING(objRow("FHINMEI"))
                    strXSYUKKA_KON_RESERVE = TO_STRING(objRow("XSYUKKA_KON_RESERVE"))
                    strXSYUKKA_KON_H_RESULT = TO_STRING(objRow("XSYUKKA_KON_H_RESULT"))
                    '������������************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    strFNUM_IN_PALLET = TO_STRING(objRow("FNUM_IN_PALLET"))             'PL���ύڐ�
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    '������������************************************************************************************************************

                    Dim strFPLAN_KEY As String = ""                 '�v�淰
                    strFPLAN_KEY = TO_STRING(objRow("FPLAN_KEY"))


                    '************************************************************
                    ' SQL���쐬 �݌Ɉ������擾
                    '************************************************************
                    Dim strSQL2 As String                        'SQL��
                    Dim objRow2 As DataRow                       '1ں��ޕ����ް�
                    Dim strDataSetName2 As String                '�ް���Ė�
                    Dim objTBLDataSet2 As New DataSet            '�ް���āi�ް��擾�p�j


                    '������������************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    ' '' ''============================================================
                    ' '' ''SELECT
                    ' '' ''============================================================
                    '' ''strSQL2 = ""
                    '' ''strSQL2 &= vbCrLf & " SELECT "
                    '' ''strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                           '�݌Ɉ������.  �@�@    �v�淰
                    ' '' ''strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                         '�ׯ�ݸ��ޯ̧.          �ׯ�ݸ��ޯ̧No.
                    '' ''strSQL2 &= vbCrLf & "  , SUM(NVL(TSTS_HIKIATE.FTR_VOL,0)) AS FTR_VOL_SUM "  '�݌Ɉ������.          �����Ǘ��ʍ��v
                    '' ''strSQL2 &= vbCrLf & "  , COUNT(0) AS FTR_VOL_PL "                           '�݌Ɉ������.          PL��
                    ' '' '' ''strSQL2 &= vbCrLf & "  , TSTS_HIKIATE.FPALLET_ID "                          '�݌Ɉ������.          ��گ�ID

                    ' '' ''============================================================
                    ' '' ''FROM
                    ' '' ''============================================================
                    '' ''strSQL2 &= vbCrLf & " FROM "
                    '' ''strSQL2 &= vbCrLf & "    TSTS_HIKIATE "           '�y�݌Ɉ������z
                    ' '' ''strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF "           '�y�ׯ�ݸ��ޯ̧�z

                    ' '' ''============================================================
                    ' '' ''WHERE
                    ' '' ''============================================================
                    '' ''strSQL2 &= vbCrLf & " WHERE "
                    '' ''strSQL2 &= vbCrLf & "         1 = 1 "
                    '' ''strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = '" & strFPLAN_KEY & "' "             '������� �� �v�淰 �œ���
                    ' '' ''strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "           '������� �� �ׯ�ݸ��ޯ̧ �� ��گ�ID �Ō���

                    ' '' ''============================================================
                    ' '' ''GROUP BY
                    ' '' ''============================================================
                    '' ''strSQL2 &= vbCrLf & " GROUP BY  "
                    '' ''strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                    '�݌Ɉ������.  �@�@�v�淰
                    ' '' ''strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                  '�ׯ�ݸ��ޯ̧.      �ׯ�ݸ��ޯ̧No.

                    ' '' ''============================================================
                    ' '' ''ORDER BY
                    ' '' ''============================================================
                    '' ''strSQL2 &= vbCrLf & " ORDER BY  "
                    '' ''strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                    '�݌Ɉ������.  �@�@�v�淰
                    ' '' ''strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                  '�ׯ�ݸ��ޯ̧.      �ׯ�ݸ��ޯ̧No.
                    '' ''strSQL2 &= vbCrLf

                    '============================================================
                    'SELECT
                    '============================================================
                    strSQL2 = ""
                    strSQL2 &= vbCrLf & " SELECT "
                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                               '�݌Ɉ������.  �@�@    �v�淰
                    strSQL2 &= vbCrLf & "  , SUM(NVL(TSTS_HIKIATE.FTR_VOL,0)) AS FTR_VOL_SUM "      '�݌Ɉ������.          �����Ǘ��ʍ��v
                    strSQL2 &= vbCrLf & "  , COUNT(0) AS FTR_VOL_PL "                               '�݌Ɉ������.          PL��
                    strSQL2 &= vbCrLf & "  , SUM(NVL(TRST_STOCK.FTR_VOL,0)) AS FTR_VOL "            '�݌ɏ��.              �����Ǘ��ʍ��v
                    strSQL2 &= vbCrLf & "  , SUM(NVL(TRST_STOCK.FTR_RES_VOL,0)) AS FTR_RES_VOL "    '�݌ɏ��.              ���������ʍ��v

                    '============================================================
                    'FROM
                    '============================================================
                    strSQL2 &= vbCrLf & " FROM "
                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE "                                         '�y�݌Ɉ������z
                    strSQL2 &= vbCrLf & "  , TRST_STOCK "                                           '�y�݌ɏ��z

                    '============================================================
                    'WHERE
                    '============================================================
                    strSQL2 &= vbCrLf & " WHERE "
                    strSQL2 &= vbCrLf & "         1 = 1 "
                    strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = '" & strFPLAN_KEY & "' " '������� �� �v�淰 �œ���
                    strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPALLET_ID = TRST_STOCK.FPALLET_ID " '������� �� �݌ɏ�� �� ��گ�ID �Ō���

                    '============================================================
                    'GROUP BY
                    '============================================================
                    strSQL2 &= vbCrLf & " GROUP BY  "
                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                               '�݌Ɉ������.  �@�@�v�淰

                    '============================================================
                    'ORDER BY
                    '============================================================
                    strSQL2 &= vbCrLf & " ORDER BY  "
                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                               '�݌Ɉ������.  �@�@�v�淰
                    strSQL2 &= vbCrLf

                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    '������������************************************************************************************************************

                    '-----------------------
                    '���o
                    '-----------------------
                    ObjDb.SQL = strSQL2
                    objTBLDataSet2.Clear()
                    strDataSetName2 = "TSTS_HIKIATE"
                    ObjDb.GetDataSet(strDataSetName2, objTBLDataSet2)

                    Dim intFTR_VOL_CONVEYOR As Integer = 0     '�o�׺����
                    Dim intFTR_VOL_CONVEYOR_PL As Integer = 0  '�o�׺����(PL��)
                    '������������************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    Dim intFTR_VOL As Decimal = 0               '�݌ɏ��.�����Ǘ��ʍ��v
                    Dim intFTR_RES_VOL As Decimal = 0           '�݌ɏ��.���������ʍ��v
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    '������������************************************************************************************************************

                    If objTBLDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
                        For Each objRow2 In objTBLDataSet2.Tables(strDataSetName2).Rows

                            Dim strFTR_VOL_SUM As String        '������
                            Dim strFTR_VOL_PL As String         '������(PL)

                            strFTR_VOL_SUM = TO_STRING(objRow2("FTR_VOL_SUM"))
                            strFTR_VOL_PL = TO_STRING(objRow2("FTR_VOL_PL"))

                            intFTR_VOL_CONVEYOR = intFTR_VOL_CONVEYOR + TO_INTEGER(strFTR_VOL_SUM)      '�o�׺����
                            intFTR_VOL_CONVEYOR_PL = intFTR_VOL_CONVEYOR_PL + TO_INTEGER(strFTR_VOL_PL) '�o�׺����(PL��)

                            '������������************************************************************************************************************
                            'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                            intFTR_VOL += TO_DECIMAL(objRow2("FTR_VOL"))                                '�݌ɏ��.�����Ǘ��ʍ��v
                            intFTR_RES_VOL += TO_DECIMAL(objRow2("FTR_RES_VOL"))                        '�݌ɏ��.���������ʍ��v
                            'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                            '������������************************************************************************************************************
                        Next
                    End If


                    '������������************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    Dim intRetVol As Decimal = 0                        '���u���߂���
                    Dim intXPLANE_PACK_NUMBER As Decimal = 0            '���ʍ���
                    Dim intDAN As Decimal = 0                           '�i��
                    Dim intKON As Decimal = 0                           '1�i�����̍���

                    '���u���߂���
                    intRetVol = intFTR_VOL - intFTR_RES_VOL
                    If intRetVol < 0 Then intRetVol = 0

                    '���u���߂���(������)
                    If intRetVol = 0 Then
                        strMODOSHI_NUM = "0"
                    Else
                        '���ʍ���
                        intXPLANE_PACK_NUMBER = TO_DECIMAL(objRow("XPLANE_PACK_NUMBER"))

                        '�i��
                        intDAN = Int(intRetVol / intXPLANE_PACK_NUMBER)

                        '1�i�����̍���
                        intKON = intRetVol Mod intXPLANE_PACK_NUMBER

                        strMODOSHI_NUM = ""
                        strMODOSHI_NUM &= TO_STRING(intRetVol)
                        strMODOSHI_NUM &= "("
                        strMODOSHI_NUM &= TO_STRING(intXPLANE_PACK_NUMBER)
                        strMODOSHI_NUM &= "x"
                        strMODOSHI_NUM &= TO_STRING(intDAN)
                        strMODOSHI_NUM &= "�i+"
                        strMODOSHI_NUM &= TO_STRING(intKON)
                        strMODOSHI_NUM &= "��)"
                    End If
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    '������������************************************************************************************************************


                    '***********************************************
                    ' �ް������쐬
                    '***********************************************
                    Dim objDataRow As clsPrintDataSet.DataTable01Row
                    objDataRow = objDataSet.DataTable01.NewRow

                    objDataRow.BeginEdit()

                    '�߯�ݸ�ؽ� �ް���
                    objDataRow.Data00 = strXHENSEI_NO                   '�Ґ�No.
                    objDataRow.Data01 = strXDENPYOU_NO                  '�`�[No.
                    objDataRow.Data02 = strXOUT_ORDER                   '�o�ɏ�
                    objDataRow.Data03 = strXHINMEI_CD                   '�i������
                    objDataRow.Data04 = strFHINMEI_CD                   '�i���L��
                    objDataRow.Data05 = strFHINMEI                      '�i��
                    objDataRow.Data06 = strXSYUKKA_KON_RESERVE          '�o�א�
                    objDataRow.Data07 = TO_STRING(intFTR_VOL_CONVEYOR)  '�o�׺����
                    objDataRow.Data08 = "(" & TO_STRING(intFTR_VOL_CONVEYOR_PL) & ")"   '(PL��)
                    objDataRow.Data09 = strXSYUKKA_KON_H_RESULT         '���u

                    '������������************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    objDataRow.Data10 = strFNUM_IN_PALLET               'PL���ύڐ�
                    objDataRow.Data11 = strMODOSHI_NUM                  '���u���߂���
                    'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
                    '������������************************************************************************************************************

                    objDataRow.EndEdit()

                    objDataSet.DataTable01.Rows.Add(objDataRow)

                Next
            End If

            '***********************************************
            ' ͯ�ް�����쐬
            '***********************************************
            Call objComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))          '���s����
            Call objComFuncFRM.ChangeCRText(objCR, "crXSYARYOU_NO", strXSYARYOU_NO)                            '�Ԕ�
            Call objComFuncFRM.ChangeCRText(objCR, "crXBERTH", strXBERTH_NO)                                   '�ް�
            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
            Call objComFuncFRM.ChangeCRText(objCR, "crSAIMOKU", strSAIMOKU)                                    '�ז�
            Call objComFuncFRM.ChangeCRText(objCR, "crGYOUSYA", strGYOUSYA)                                    '�Ǝ�
            'JobMate:S.Ouchi 2013/11/07 �߯�ݸ�ؽč��ڒǉ�
            '������������************************************************************************************************************

            Select Case strXTUMI_HOUHOU                                                                         '�ύ����@
                Case TO_STRING(XTUMI_HOUHOU_JP)
                    strXTUMI_HOUHOU = "�p���b�g"
                Case TO_STRING(XTUMI_HOUHOU_JB)
                    strXTUMI_HOUHOU = "�o��"
                Case TO_STRING(XTUMI_HOUHOU_JL)
                    strXTUMI_HOUHOU = "���[�_"
            End Select
            Call objComFuncFRM.ChangeCRText(objCR, "crXTUMI_HOUHOU", strXTUMI_HOUHOU)

            Select Case strXTUMI_HOUKOU                                                                         '�ύ�����
                Case TO_STRING(XTUMI_HOUKOU_JBACK)
                    strXTUMI_HOUKOU = "���"
                Case TO_STRING(XTUMI_HOUKOU_JSIDE)
                    strXTUMI_HOUKOU = "�Љ���"
                Case TO_STRING(XTUMI_HOUKOU_JWING)
                    strXTUMI_HOUKOU = "������"
                Case TO_STRING(XTUMI_HOUKOU_JALL)
                    strXTUMI_HOUKOU = "ALL"
            End Select
            Call objComFuncFRM.ChangeCRText(objCR, "crXTUMI_HOUKOU", strXTUMI_HOUKOU)

            '***********************************************
            ' �ؽ����߰Ă��ް���Ă��
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' ��
            '***********************************************
            Call objComFuncFRM.CRPrint(objCR)

        Catch ex As Exception
            Throw ex

        Finally

            '�ؽ����߰ĵ�޼ު��
            objCR.Dispose()
            objCR = Nothing
            '�ް�ð��ٵ�޼ު��
            objDataSet.Dispose()
            objDataSet = Nothing

        End Try


    End Sub
#End Region
#Region "  Excel����o��                                            "
    '''*************************************************************************************************************
    ''' <summary>
    ''' Excel����o��
    ''' </summary>
    ''' <param name="dtmSOUGYOU_D">���Ɠ�</param>
    ''' <remarks></remarks>
    '''*************************************************************************************************************
    Public Sub MakeExcelNippou(ByVal dtmSOUGYOU_D As Date)
        Dim strFile As String = ""
        Dim strFileNM As String = ""
        Dim strCSVFileNM As String = ""
        Dim objFuncExcel As New clsComFuncExcel(Owner, ObjDb, ObjDbLog)

        Try
            '*============================
            '* �쐬̧�ٖ��擾
            '*============================
            Dim identifier As String = Format(dtmSOUGYOU_D, "yyyyMMdd")
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 '���ѕϐ��׽
            'Dim strDirectory As String = "..\Excel\"
            Dim strDirectory As String = objTPRG_SYS_HEN.SJ000000_022
            strFileNM = "����_" & identifier & ".xls"
            strCSVFileNM = "����_" & identifier & ".csv"
            '' �t�@�C���̑��݊m�F
            'If File.Exists(strFile) = True Then
            '    '(�t�@�C��������)
            '    '*******************************************************
            '    '�m�Fү����
            '    '*******************************************************
            '    Dim udeRet As PopupFormType
            '    udeRet = gobjComFuncFRM.DisplayPopup("���ɏo�͍ς݂̓��񂪑��݂��܂��B�㏑�����Ă���낵���ł���?", PopupFormType.Ok_Cancel, PopupIconType.Quest)
            '    If udeRet <> PopupFormType.Ok Then
            '        Exit Sub
            '    End If
            'End If

            ' Exceļ�ق̋N���m�F
            If objFuncExcel.IsExcelBookOpen(strFileNM) Then
                Throw New UserException(strFileNM & "���J����Ă��܂��B���Ă���ēx���s���ĉ������B")
                Exit Sub
            End If

            '*============================
            '* ����쐬
            '*============================
            If objFuncExcel.makeReportNippo(dtmSOUGYOU_D, strDirectory, strFileNM, strCSVFileNM) = False Then
                '(�G���[�̏ꍇ)
                Throw New UserException("����̍쐬�Ɏ��s���܂����B")
            End If

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try

    End Sub
#End Region
#Region "  Excel����o��                                            "
    '''*************************************************************************************************************
    ''' <summary>
    ''' Excel����o��
    ''' </summary>
    ''' <param name="dtmSOUGYOU_D">���Ɠ�</param>
    ''' <remarks></remarks>
    '''*************************************************************************************************************
    Public Sub MakeExcelGeppou(ByVal dtmSOUGYOU_D As Date)

        Dim strFile As String = ""
        Dim strFileNM As String = ""
        Dim objFuncExcel As New clsComFuncExcel(Owner, ObjDb, ObjDbLog)

        Try

            '*============================
            '* �쐬̧�ٖ��擾
            '*============================
            Dim identifier As String = ""
            identifier &= dtmSOUGYOU_D.ToString("yyyyMM")
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 '���ѕϐ��׽
            'Dim strDirectory As String = "..\Excel\"
            Dim strDirectory As String = objTPRG_SYS_HEN.SJ000000_022
            strFileNM = "����_" & identifier & ".xls"
            '' �t�@�C���̑��݊m�F
            'If File.Exists(strFile) = True Then
            '    '(�t�@�C��������)
            '    '*******************************************************
            '    '�m�Fү����
            '    '*******************************************************
            '    Dim udeRet As PopupFormType
            '    udeRet = gobjComFuncFRM.DisplayPopup("���ɏo�͍ς݂̌��񂪑��݂��܂��B�㏑�����Ă���낵���ł���?", PopupFormType.Ok_Cancel, PopupIconType.Quest)
            '    If udeRet <> PopupFormType.Ok Then
            '        Exit Sub
            '    End If
            'End If

            ' Exceļ�ق̋N���m�F
            If objFuncExcel.IsExcelBookOpen(strFileNM) Then
                Throw New UserException(strFileNM & "���J����Ă��܂��B���Ă���ēx���s���ĉ������B")
                Exit Sub
            End If

            '*============================
            '* ����쐬
            '*============================
            If objFuncExcel.makeReportGeppo(dtmSOUGYOU_D.Year, dtmSOUGYOU_D.Month, strDirectory, strFileNM) = False Then
                '(�G���[�̏ꍇ)
                Throw New UserException("����̍쐬�Ɏ��s���܂����B")
            End If

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try

    End Sub
#End Region
    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/23 CW6�ǉ��Ή� ������������
#Region "  Excel���Y���C������o��                                  "
    '''*************************************************************************************************************
    ''' <summary>
    ''' Excel���Y���C������o��
    ''' </summary>
    ''' <param name="dtmSOUGYOU_D">���Ɠ�</param>
    ''' <remarks></remarks>
    '''*************************************************************************************************************
    Public Sub MakeExcelSeisanNippou(ByVal dtmSOUGYOU_D As Date)
        Dim strFile As String = ""
        Dim strFileNM As String = ""
        Dim strCSVFileNM As String = ""
        Dim objFuncExcel As New clsComFuncExcel(Owner, ObjDb, ObjDbLog)

        Try
            '*============================
            '* �쐬̧�ٖ��擾
            '*============================
            Dim identifier As String = Format(dtmSOUGYOU_D, "yyyyMMdd")
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 '���ѕϐ��׽
            Dim strDirectory As String = objTPRG_SYS_HEN.SJ000000_022
            strFileNM = "���Y���C������_" & identifier & ".xls"
            strCSVFileNM = "���Y���C������_" & identifier & ".csv"

            ' Exceļ�ق̋N���m�F
            If objFuncExcel.IsExcelBookOpen(strFileNM) Then
                Throw New UserException(strFileNM & "���J����Ă��܂��B���Ă���ēx���s���ĉ������B")
                Exit Sub
            End If

            '*============================
            '* ���Y���C������쐬
            '*============================
            If objFuncExcel.makeReportSeisanNippo(dtmSOUGYOU_D, strDirectory, strFileNM, strCSVFileNM) = False Then
                '(�G���[�̏ꍇ)
                Throw New UserException("���Y���C������̍쐬�Ɏ��s���܂����B")
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try

    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/23 CW6�ǉ��Ή� ������������
    '������������************************************************************************************************************

    '���̑�
#Region "  �֘A����I��ۯ��̎擾                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �֘A������ۯ��I�̎擾
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_Base">
    ''' ��ƂȂ�I
    ''' </param>
    ''' <param name="objTPRG_TRK_BUF_Relation">
    ''' �֘A������ۯ��I�̔z��
    ''' </param>
    ''' <param name="objTRST_STOCK_Base">
    ''' ��ƂȂ�݌ɏ��
    ''' </param>
    ''' <param name="objTRST_STOCK_Relation">
    ''' �֘A������ۯ��I�̍݌ɏ��̔z��
    ''' </param>
    ''' <param name="objTRST_PALLET_Base">
    ''' ��ƂȂ���گď��
    ''' </param>
    ''' <param name="objTRST_PALLET_Relation">
    ''' �֘A������ۯ��I����گď��̔z��
    ''' </param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetTPRG_TRK_BUF_Relation(ByVal objTPRG_TRK_BUF_Base As TBL_TPRG_TRK_BUF _
                                      , ByRef objTPRG_TRK_BUF_Relation() As TBL_TPRG_TRK_BUF _
                                      , ByRef objTRST_STOCK_Base As TBL_TRST_STOCK _
                                      , ByRef objTRST_STOCK_Relation() As TBL_TRST_STOCK _
                                      , Optional ByRef objTRST_PALLET_Base As TBL_TRST_PALLET = Nothing _
                                      , Optional ByRef objTRST_PALLET_Relation() As TBL_TRST_PALLET = Nothing _
                                        )
        Dim intRet As RetCode                 '�߂�l
        Dim strMsg As String                  'ү����

        Try


            '************************************************
            '�����ݒ�
            '************************************************
            ReDim objTPRG_TRK_BUF_Relation(RelationArray.MAX - 1)
            ReDim objTRST_STOCK_Relation(RelationArray.MAX - 1)
            ReDim objTRST_PALLET_Relation(RelationArray.MAX - 1)


            '************************************************************************************************
            '************************************************************************************************
            '�֘A���̎擾
            '************************************************************************************************
            '************************************************************************************************
            '************************************************
            '�֘A�I�̎擾
            '************************************************
            Dim objAryTPRG_TRK_BUF_Get As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objAryTPRG_TRK_BUF_Get.FTRK_BUF_NO = objTPRG_TRK_BUF_Base.FTRK_BUF_NO       '�ׯ�ݸ��ޯ̧��
            objAryTPRG_TRK_BUF_Get.XTANA_BLOCK = objTPRG_TRK_BUF_Base.XTANA_BLOCK       '�I��ۯ�
            objAryTPRG_TRK_BUF_Get.ORDER_BY = "XTANA_BLOCK_DTL ASC"                     '����
            intRet = objAryTPRG_TRK_BUF_Get.GET_TPRG_TRK_BUF_ANY()                      '�擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_BUF & "[�ׯ�ݸ��ޯ̧��:" & objAryTPRG_TRK_BUF_Get.FTRK_BUF_NO & "]" _
                                             & "[�I��ۯ�:" & objAryTPRG_TRK_BUF_Get.XTANA_BLOCK & "]"
                Throw New UserException(strMsg)
            End If
            For ii As Integer = 0 To UBound(objAryTPRG_TRK_BUF_Get.ARYME)
                '(ٰ��:����I��ۯ���)


                '************************************************
                '�֘A�I�̎擾
                '************************************************
                objTPRG_TRK_BUF_Relation(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_Relation(ii).FTRK_BUF_NO = objAryTPRG_TRK_BUF_Get.ARYME(ii).FTRK_BUF_NO
                objTPRG_TRK_BUF_Relation(ii).FTRK_BUF_ARRAY = objAryTPRG_TRK_BUF_Get.ARYME(ii).FTRK_BUF_ARRAY
                objTPRG_TRK_BUF_Relation(ii).GET_TPRG_TRK_BUF()


                '**********************************************
                '��ƂȂ�I�̍݌Ɏ擾
                '**********************************************
                If IsNotNull(objTPRG_TRK_BUF_Relation(ii).FPALLET_ID) Then
                    '(���I�̏ꍇ)

                    '==========================================
                    '�݌ɏ��̎擾
                    '==========================================
                    objTRST_STOCK_Relation(ii) = New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    objTRST_STOCK_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FPALLET_ID     '��گ�ID
                    intRet = objTRST_STOCK_Relation(ii).GET_TRST_STOCK_KONSAI(True)                     '�擾

                    '==========================================
                    '��گď��̎擾
                    '==========================================
                    If IsNotNull(objTRST_PALLET_Relation) Then
                        objTRST_PALLET_Relation(ii) = New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)
                        objTRST_PALLET_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FPALLET_ID    '��گ�ID
                        objTRST_PALLET_Relation(ii).GET_TRST_PALLET()                                       '�擾
                    End If

                ElseIf IsNotNull(objTPRG_TRK_BUF_Relation(ii).FRSV_PALLET) Then
                    '(�\��I�̏ꍇ)

                    '==========================================
                    '�݌ɏ��̎擾
                    '==========================================
                    objTRST_STOCK_Relation(ii) = New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    objTRST_STOCK_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FRSV_PALLET    '��گ�ID
                    intRet = objTRST_STOCK_Relation(ii).GET_TRST_STOCK_KONSAI(True)                     '�擾

                    '==========================================
                    '��گď��̎擾
                    '==========================================
                    If IsNotNull(objTRST_PALLET_Relation) Then
                        objTRST_PALLET_Relation(ii) = New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)
                        objTRST_PALLET_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FRSV_PALLET       '��گ�ID
                        objTRST_PALLET_Relation(ii).GET_TRST_PALLET()                                           '�擾
                    End If

                End If



            Next


            '************************************************************************************************
            '************************************************************************************************
            '��ƂȂ�I�̏��̎擾
            '************************************************************************************************
            '************************************************************************************************
            '**********************************************
            '��ƂȂ�I�̍݌Ɏ擾
            '**********************************************
            If IsNotNull(objTPRG_TRK_BUF_Base.FPALLET_ID) Then
                '(���I�̏ꍇ)

                '==========================================
                '�݌ɏ��̎擾
                '==========================================
                objTRST_STOCK_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FPALLET_ID             '��گ�ID
                intRet = objTRST_STOCK_Base.GET_TRST_STOCK_KONSAI(True)                     '�擾

                '==========================================
                '��گď��̎擾
                '==========================================
                If IsNotNull(objTRST_PALLET_Base) Then
                    objTRST_PALLET_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FPALLET_ID            '��گ�ID
                    objTRST_PALLET_Base.GET_TRST_PALLET()                                       '�擾
                End If

            ElseIf IsNotNull(objTPRG_TRK_BUF_Base.FRSV_PALLET) Then
                '(�\��I�̏ꍇ)

                '==========================================
                '�݌ɏ��̎擾
                '==========================================
                objTRST_STOCK_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FRSV_PALLET            '��گ�ID
                intRet = objTRST_STOCK_Base.GET_TRST_STOCK_KONSAI(True)                     '�擾

                '==========================================
                '��گď��̎擾
                '==========================================
                If IsNotNull(objTRST_PALLET_Base) Then
                    objTRST_PALLET_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FRSV_PALLET       '��گ�ID
                    objTRST_PALLET_Base.GET_TRST_PALLET()                                   '�擾
                End If

            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  �֘A����I��ۯ��̎擾(�݌Ɉ������A�����w��QUE)                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �֘A����I��ۯ��̎擾(�݌Ɉ������A�����w��QUE)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_Base">��ƂȂ�I</param>
    ''' <param name="objTPRG_TRK_BUF_Relation">�֘A������ۯ��I�̔z��</param>
    ''' <param name="objTSTS_HIKIATE_Base">��ƂȂ�I�̍݌Ɉ������̔z��</param>
    ''' <param name="objTSTS_HIKIATE_Relation">�֘A������ۯ��I�̍݌Ɉ������̔z��</param>
    ''' <param name="objTPLN_CARRY_QUE_Base">��ƂȂ�I�̔����w��QUE�̔z��</param>
    ''' <param name="objTPLN_CARRY_QUE_Relation">�֘A������ۯ��I�̔����w��QUE�̔z��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetInfor_Relation(ByVal objTPRG_TRK_BUF_Base As TBL_TPRG_TRK_BUF _
                               , ByVal objTPRG_TRK_BUF_Relation() As TBL_TPRG_TRK_BUF _
                               , ByRef objTSTS_HIKIATE_Base As TBL_TSTS_HIKIATE _
                               , ByRef objTSTS_HIKIATE_Relation() As TBL_TSTS_HIKIATE _
                               , ByRef objTPLN_CARRY_QUE_Base As TBL_TPLN_CARRY_QUE _
                               , ByRef objTPLN_CARRY_QUE_Relation() As TBL_TPLN_CARRY_QUE _
                               )
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����

        Try


            '************************************************
            '�����ݒ�
            '************************************************
            ReDim objTSTS_HIKIATE_Relation(RelationArray.MAX - 1)
            ReDim objTPLN_CARRY_QUE_Relation(RelationArray.MAX - 1)


            '************************************************************************************************
            '************************************************************************************************
            '��ۯ������                        �擾
            '************************************************************************************************
            '************************************************************************************************
            For ii As Integer = 0 To UBound(objTPRG_TRK_BUF_Relation)
                '(ٰ��:����I��ۯ���)


                If IsNotNull(objTPRG_TRK_BUF_Relation(ii).FPALLET_ID) And objTPRG_TRK_BUF_Relation(ii).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                    '(�݌ɂ����݂��Ă���ꍇ)


                    '==========================================
                    '�݌Ɉ������               �擾
                    '==========================================
                    objTSTS_HIKIATE_Relation(ii) = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                    objTSTS_HIKIATE_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FPALLET_ID   '��گ�ID
                    objTSTS_HIKIATE_Relation(ii).GET_TSTS_HIKIATE()                                     '�擾

                    '==========================================
                    '�����w��QUE                �擾
                    '==========================================
                    objTPLN_CARRY_QUE_Relation(ii) = New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    objTPLN_CARRY_QUE_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FPALLET_ID     '��گ�ID
                    objTPLN_CARRY_QUE_Relation(ii).GET_TPLN_CARRY_QUE()                                     '�擾


                End If


            Next


            '************************************************************************************************
            '************************************************************************************************
            '��ƂȂ�I�̏��̎擾
            '************************************************************************************************
            '************************************************************************************************
            '**********************************************
            '��ƂȂ�I�̍݌Ɏ擾
            '**********************************************
            If IsNotNull(objTPRG_TRK_BUF_Base.FPALLET_ID) And objTPRG_TRK_BUF_Base.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                '(���I�̏ꍇ)

                '==========================================
                '�݌Ɉ������               �擾
                '==========================================
                objTSTS_HIKIATE_Base = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                objTSTS_HIKIATE_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FPALLET_ID       '��گ�ID
                objTSTS_HIKIATE_Base.GET_TSTS_HIKIATE()                                 '�擾

                '==========================================
                '�݌Ɉ������               �擾
                '==========================================
                objTPLN_CARRY_QUE_Base = New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                objTPLN_CARRY_QUE_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FPALLET_ID     '��گ�ID
                objTPLN_CARRY_QUE_Base.GET_TPLN_CARRY_QUE()                             '�擾

            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  �֘A����I��ۯ��́A�S�I��ۯ���Ԃ��X�V                                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �֘A����I��ۯ��́A�S�I��ۯ���Ԃ��X�V
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_Base">��ƂȂ�I</param>
    ''' <param name="intXTANA_BLOCK_STS">�I��ۯ����</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(ByRef objTPRG_TRK_BUF_Base As TBL_TPRG_TRK_BUF _
                                                         , ByVal intXTANA_BLOCK_STS As Integer _
                                                         )
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************************************
        '�I��ۯ���Ԃ̍X�V
        '************************************************
        Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      '�ׯ�ݸ��ޯ̧�׽
        Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '�݌ɏ��
        Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '�݌ɏ��
        Call GetTPRG_TRK_BUF_Relation(objTPRG_TRK_BUF_Base, objTrkRelation, objStockFind, objStockRelation)
        For ii As Integer = 0 To UBound(objTrkRelation)
            '(ٰ��:�֌W�����ׯ�ݸސ�)

            If objTPRG_TRK_BUF_Base.FTRK_BUF_NO = objTrkRelation(ii).FTRK_BUF_NO And objTPRG_TRK_BUF_Base.FTRK_BUF_ARRAY = objTrkRelation(ii).FTRK_BUF_ARRAY Then
                '�ΏۂƂȂ�I
                objTPRG_TRK_BUF_Base.XTANA_BLOCK_STS = intXTANA_BLOCK_STS       '�I��ۯ����
                objTPRG_TRK_BUF_Base.FBUF_IN_DT = Now                           '�ޯ̧������
                objTPRG_TRK_BUF_Base.UPDATE_TPRG_TRK_BUF()                      '�X�V
            Else
                '�֘A����I
                objTrkRelation(ii).XTANA_BLOCK_STS = intXTANA_BLOCK_STS     '�I��ۯ����
                objTrkRelation(ii).FBUF_IN_DT = Now                         '�ޯ̧������
                objTrkRelation(ii).UPDATE_TPRG_TRK_BUF()                    '�X�V
            End If

        Next


        ''************************************************
        ''�I��ۯ���Ԃ̍X�V(27����ꏈ��)
        ''************************************************
        'Dim strSQL As String        'SQL��
        'Dim intRetSQL As Integer    'SQL���s�߂�l
        'strSQL = ""
        'strSQL &= vbCrLf & " UPDATE "
        'strSQL &= vbCrLf & "    TPRG_TRK_BUF "
        'strSQL &= vbCrLf & " SET "
        'strSQL &= vbCrLf & "    XTANA_BLOCK_STS = " & XTANA_BLOCK_STS_IN
        'strSQL &= vbCrLf & " WHERE "
        'strSQL &= vbCrLf & "     1 = 1 "
        'strSQL &= vbCrLf & " AND FRAC_RETU = " & FRAC_RETU_J27
        'strSQL &= vbCrLf & " AND ( XTANA_BLOCK_STS <> " & XTANA_BLOCK_STS_IN & " OR XTANA_BLOCK_STS IS NULL )"
        'strSQL &= vbCrLf
        'intRetSQL = ObjDb.Execute(strSQL)
        'If intRetSQL = -1 Then
        '    '(SQL�װ)
        '    strSQL = Replace(strSQL, vbCrLf, "")
        '    strMsg = ERRMSG_ERR_DELETE & ObjDb.ErrMsg & "�y" & strSQL & "�z"
        '    Throw New UserException(strMsg)
        'End If


    End Sub
#End Region
#Region "  �e�q����(��گ�ID)                                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �e�q����(��گ�ID)
    ''' </summary>
    ''' <param name="strFPALLET_ID_01">��گ�ID01</param>
    ''' <param name="strFPALLET_ID_02">��گ�ID02</param>
    ''' <returns>OK:�e�q�֌W     NG:�e�q�֌W����Ȃ�</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function HanteiOyakoFPALLET_ID(ByVal strFPALLET_ID_01 As String _
                                        , ByVal strFPALLET_ID_02 As String _
                                        ) _
                                        As RetCode
        Dim intReturn As RetCode = RetCode.NG
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����

        Try


            '************************************************
            '����
            '************************************************
            If IsNull(strFPALLET_ID_01) Then Return intReturn
            If IsNull(strFPALLET_ID_02) Then Return intReturn


            '************************************************
            '�ׯ�ݸ��ޯ̧(01)       �擾
            '************************************************
            Dim objTPRG_TRK_BUF01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF01.FPALLET_ID = strFPALLET_ID_01     '��گ�ID
            objTPRG_TRK_BUF01.GET_TPRG_TRK_BUF()                '�擾


            '************************************************
            '�ׯ�ݸ��ޯ̧(02)       �擾
            '************************************************
            Dim objTPRG_TRK_BUF02 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF02.FPALLET_ID = strFPALLET_ID_02     '��گ�ID
            objTPRG_TRK_BUF02.GET_TPRG_TRK_BUF()                '�擾


            '************************************************
            '�e�q����
            '************************************************
            If objTPRG_TRK_BUF01.XTANA_BLOCK = objTPRG_TRK_BUF02.XTANA_BLOCK Then
                '(�I��ۯ�������̏ꍇ)

                Select Case objTPRG_TRK_BUF01.XTANA_BLOCK_DTL
                    Case XTANA_BLOCK_DTL_OKU_EVN : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_ODD Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_OKU_ODD : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_EVN Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_MAE_EVN : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_ODD Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_MAE_ODD : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_EVN Then intReturn = RetCode.OK
                End Select


            End If


            Return intReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �e�q����(��������گ�ID)                                                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �e�q����(��������گ�ID)
    ''' </summary>
    ''' <param name="strFRSV_PALLET_01">��������گ�ID01</param>
    ''' <param name="strFRSV_PALLET_02">��������گ�ID02</param>
    ''' <returns>OK:�e�q�֌W     NG:�e�q�֌W����Ȃ�</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function HanteiOyakoFRSV_PALLET(ByVal strFRSV_PALLET_01 As String _
                                         , ByVal strFRSV_PALLET_02 As String _
                                         ) _
                                         As RetCode
        Dim intReturn As RetCode = RetCode.NG
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����

        Try


            '************************************************
            '����
            '************************************************
            If IsNull(strFRSV_PALLET_01) Then Return intReturn
            If IsNull(strFRSV_PALLET_02) Then Return intReturn


            '************************************************
            '�ׯ�ݸ��ޯ̧(01)       �擾
            '************************************************
            Dim objTPRG_TRK_BUF01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF01.FRSV_PALLET = strFRSV_PALLET_01       '��������گ�ID
            objTPRG_TRK_BUF01.GET_TPRG_TRK_BUF()                    '�擾


            '************************************************
            '�ׯ�ݸ��ޯ̧(02)       �擾
            '************************************************
            Dim objTPRG_TRK_BUF02 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF02.FRSV_PALLET = strFRSV_PALLET_02       '��������گ�ID
            objTPRG_TRK_BUF02.GET_TPRG_TRK_BUF()                    '�擾


            '************************************************
            '�e�q����
            '************************************************
            If objTPRG_TRK_BUF01.XTANA_BLOCK = objTPRG_TRK_BUF02.XTANA_BLOCK Then
                '(�I��ۯ�������̏ꍇ)

                Select Case objTPRG_TRK_BUF01.XTANA_BLOCK_DTL
                    Case XTANA_BLOCK_DTL_OKU_EVN : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_ODD Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_OKU_ODD : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_EVN Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_MAE_EVN : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_ODD Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_MAE_ODD : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_EVN Then intReturn = RetCode.OK
                End Select


            End If


            Return intReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �����ׯ�ݸޏ��̍X�V                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����ׯ�ݸޏ��̍X�V
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF">�ׯ�ݸ��ޯ̧ð��ٸ׽</param>
    ''' <param name="objTRST_STOCK">�݌ɏ��ð��ٸ׽</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UpdateTRST_STOCK_InInfor(ByVal objTPRG_TRK_BUF As TBL_TPRG_TRK_BUF _
                                      , ByVal objTRST_STOCK As TBL_TRST_STOCK _
                                      )


        '*****************************************************
        '�݌ɏ��               �X�V
        '*****************************************************
        objTRST_STOCK.ARYME(0).XTRK_BUF_NO_IN = objTPRG_TRK_BUF.FTRK_BUF_NO             '�����ׯ�ݸ��ޯ̧��
        objTRST_STOCK.ARYME(0).XTRK_BUF_ARRAY_IN = objTPRG_TRK_BUF.FTRK_BUF_ARRAY       '�����ׯ�ݸ��ޯ̧�z��
        objTRST_STOCK.ARYME(0).UPDATE_TRST_STOCK()                                      '�X�V


    End Sub
#End Region
#Region "  ۯć�                        �擾                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۯć��擾
    ''' </summary>
    ''' <param name="strFLOT_NO">ۯć�</param>
    ''' <param name="strXPROD_LINE">���Yײ݇�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetFLOT_NO(ByRef strFLOT_NO As String _
                        , ByVal strXPROD_LINE As String _
                        )
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        '*****************************************************
        '���Ɨ���                       �擾
        '*****************************************************
        Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)
        objXRST_SOUGYOU.GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX()    '�擾


        '*****************************************************
        'ۯć�                          �ݒ�
        '*****************************************************
        strFLOT_NO = strXPROD_LINE & Format(objXRST_SOUGYOU.XSOUGYOU_DT, "yyyyMMdd")


    End Sub
#End Region
#Region "  �o��CV�z��                   �擾                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �o��CV�z��擾
    ''' </summary>
    ''' <param name="intAryOutCV">�o��CV�z��</param>
    ''' <param name="intXBERTH_GROUP">�ް���ٰ��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetintAryOutCV(ByRef intAryOutCV() As Integer _
                            , ByVal intXBERTH_GROUP As Integer _
                            )
        Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        '=======================================
        '�o���ް���           �擾
        '=======================================
        Dim objAryXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
        objAryXSTS_CONVEYOR.XBERTH_GROUP = intXBERTH_GROUP                  '�ް���ٰ��
        objAryXSTS_CONVEYOR.ORDER_BY = " XSTNO "                            '����
        intRet = objAryXSTS_CONVEYOR.GET_XSTS_CONVEYOR_ANY()                '�擾
        If intRet = RetCode.OK Then
            '(���������ꍇ)
            ReDim intAryOutCV(UBound(objAryXSTS_CONVEYOR.ARYME))
            For ii As Integer = 0 To UBound(objAryXSTS_CONVEYOR.ARYME)
                '(ٰ��:�o��CV��)
                intAryOutCV(ii) = objAryXSTS_CONVEYOR.ARYME(ii).XSTNO
            Next
        Else
            '(������Ȃ������ꍇ)
            Throw New Exception(ERRMSG_NOTFOUND_XSTS_CONVEYOR & "[�ް���ٰ��:" & TO_STRING(objAryXSTS_CONVEYOR.XBERTH_GROUP) & "]")
        End If


    End Sub
#End Region
#Region "  �\�萔                       �擾                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\�萔                       �擾
    ''' </summary>
    ''' <param name="objTMST_TRK">�ׯ�ݸ��ޯ̧Ͻ�</param>
    ''' <param name="intYotei01">�\�萔01</param>
    ''' <param name="intYotei02">�\�萔02</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetYoteiNum(ByVal objTMST_TRK As TBL_TMST_TRK _
                         , ByRef intYotei01 As Integer _
                         , ByRef intYotei02 As Integer _
                         )
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
            '(�\�萔���ڽ01����`����Ă���ꍇ)


            '************************************************
            '�ݔ���           �擾
            '************************************************
            Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Dim objTSTS_EQ_CTRL_YOTEI02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI01, objTMST_TRK.XADRS_YOTEI01)
            If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                '(�\�萔���ڽ02����`����Ă���ꍇ)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI02, objTMST_TRK.XADRS_YOTEI02)
            End If


            '************************************************
            '�ް����
            '************************************************
            intYotei01 = objTSTS_EQ_CTRL_YOTEI01.FEQ_STS
            intYotei02 = objTSTS_EQ_CTRL_YOTEI02.FEQ_STS


        End If


    End Sub
#End Region
#Region "  �\�萔�A��گĐ���0����                                                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����\�萔���ׯ�ݸ��ޯ̧�����擾(�߱�����A�ݸ�ٔ���)
    ''' </summary>
    ''' <param name="objTMST_TRK">�ׯ�ݸ��ޯ̧Ͻ�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CheckYoteiPalletNum(ByVal objTMST_TRK As TBL_TMST_TRK)
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
            '(�\�萔���ڽ01����`����Ă���ꍇ)


            '************************************************
            '�ݔ���           �擾
            '************************************************
            Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Dim objTSTS_EQ_CTRL_YOTEI02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Dim objTSTS_EQ_CTRL_PALLET01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Dim objTSTS_EQ_CTRL_PALLET02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI01, objTMST_TRK.XADRS_YOTEI01)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PALLET01, objTMST_TRK.XADRS_PALLET01)
            If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                '(�\�萔���ڽ02����`����Ă���ꍇ)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI02, objTMST_TRK.XADRS_YOTEI02)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PALLET02, objTMST_TRK.XADRS_PALLET02)
            End If


            '************************************************
            '�\�萔
            '************************************************
            If objTSTS_EQ_CTRL_YOTEI01.FEQ_STS <> 0 Then Throw New Exception("�\�萔��0�łȂ��ׁA�o�ɂ͍s���܂���B[�ݔ�ID:" & objTSTS_EQ_CTRL_YOTEI01.FEQ_ID & "][�ݔ����:" & objTSTS_EQ_CTRL_YOTEI01.FEQ_STS & "]")
            If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                '(�\�萔���ڽ02����`����Ă���ꍇ)
                If objTSTS_EQ_CTRL_YOTEI02.FEQ_STS <> 0 Then Throw New Exception("�\�萔��0�łȂ��ׁA�o�ɂ͍s���܂���B[�ݔ�ID:" & objTSTS_EQ_CTRL_YOTEI02.FEQ_ID & "][�ݔ����:" & objTSTS_EQ_CTRL_YOTEI02.FEQ_STS & "]")
            End If


            '************************************************
            '��گĐ�����
            '************************************************
            Select Case objTMST_TRK.FTRK_BUF_NO
                Case FTRK_BUF_NO_J2039 _
                   , FTRK_BUF_NO_J2917 _
                   , FTRK_BUF_NO_J2062 _
                   , FTRK_BUF_NO_J2061 _
                   , FTRK_BUF_NO_J2037 _
                   , FTRK_BUF_NO_J2909 _
                   , FTRK_BUF_NO_J2908 _
                   , FTRK_BUF_NO_J2907 _
                   , FTRK_BUF_NO_J2906 _
                   , FTRK_BUF_NO_J2905
                    'NOP
                Case Else
                    If objTSTS_EQ_CTRL_PALLET01.FEQ_STS <> 0 Then Throw New Exception("��گĐ���0�łȂ��ׁA�o�ɂ͍s���܂���B[�ݔ�ID:" & objTSTS_EQ_CTRL_PALLET01.FEQ_ID & "][�ݔ����:" & objTSTS_EQ_CTRL_PALLET01.FEQ_STS & "]")
                    If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                        '(�\�萔���ڽ02����`����Ă���ꍇ)
                        If objTSTS_EQ_CTRL_PALLET02.FEQ_STS <> 0 Then Throw New Exception("��گĐ���0�łȂ��ׁA�o�ɂ͍s���܂���B[�ݔ�ID:" & objTSTS_EQ_CTRL_PALLET02.FEQ_ID & "][�ݔ����:" & objTSTS_EQ_CTRL_PALLET02.FEQ_STS & "]")
                    End If
            End Select


        End If


    End Sub
#End Region
#Region "  �\�萔ϲŽ1                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\�萔ϲŽ1
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">�ׯ�ݸ��ޯ̧��</param>
    ''' <param name="strFPALLET_ID">��گ�ID</param>
    ''' <param name="blnPair">�߱�׸�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UpdateYoteiNumMinus1(ByVal intFTRK_BUF_NO As Integer _
                                  , ByVal strFPALLET_ID As String _
                                  , ByVal blnPair As Boolean _
                                  )
        Try
            'Dim intRet As RetCode                 '�߂�l
            'Dim strMsg As String                  'ү����


            '***********************************************
            '�ׯ�ݸ��ޯ̧           �擾
            '***********************************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF.FPALLET_ID = strFPALLET_ID          '��گ�ID
            objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                  '�擾
            If IsNull(objTPRG_TRK_BUF.FTR_TO) Then Exit Sub


            '***********************************************
            '�ׯ�ݸ��ޯ̧Ͻ�(TO)
            '***********************************************
            Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK_TO.FTRK_BUF_NO = objTPRG_TRK_BUF.FTR_TO            '�ׯ�ݸ��ޯ̧��
            objTMST_TRK_TO.GET_TMST_TRK()                                  '�擾


            '***********************************************
            '�����w��QUE        ����
            '***********************************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
            objTPLN_CARRY_QUE.FPALLET_ID = strFPALLET_ID            '��گ�ID
            objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                  '�擾
            If IsNotNull(objTMST_TRK_TO.XADRS_YOTEI02) Then Exit Sub '�ׯ�۰�ނ̏ꍇ�͏������Ȃ�


            '***********************************************
            '�\�萔             �擾
            '***********************************************
            Dim intYotei01 As Integer = 0
            Dim intYotei02 As Integer = 0
            Call GetYoteiNum(objTMST_TRK_TO, intYotei01, intYotei02)
            If intYotei01 <= 0 And IsNull(objTMST_TRK_TO.XADRS_YOTEI02) Then Exit Sub
            If intYotei01 <= 0 And intYotei02 <= 0 Then Exit Sub


            '************************************************
            '�\�萔             �ް����
            '************************************************
            If blnPair Then
                '(�߱�����̏ꍇ)
                If 0 <= intYotei01 Then intYotei01 = intYotei01 - 2
            Else
                '(�ݸ�ٔ����̏ꍇ)
                If 0 <= intYotei01 Then intYotei01 = intYotei01 - 1
            End If


            '************************************************
            '����         �����\�萔
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            'objSVR_190001.FEQ_ID = strFEQ_ID                                '�ݔ�ID
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
            objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
                                                  , intYotei01 _
                                                  , intYotei02 _
                                                  )


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub


    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\�萔ϲŽ1
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">�ׯ�ݸ��ޯ̧��</param>
    ''' <param name="strFPALLET_ID">��گ�ID</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UpdateYoteiNumMinus1(ByVal intFTRK_BUF_NO As Integer _
                                  , ByVal strFPALLET_ID As String _
                                  )
        'Try
        '    'Dim intRet As RetCode                 '�߂�l
        '    'Dim strMsg As String                  'ү����


        '    '***********************************************
        '    '�ׯ�ݸ��ޯ̧           �擾
        '    '***********************************************
        '    Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        '    objTPRG_TRK_BUF.FPALLET_ID = strFPALLET_ID          '��گ�ID
        '    objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                  '�擾
        '    If IsNull(objTPRG_TRK_BUF.FTR_TO) Then Exit Sub


        '    '***********************************************
        '    '�ׯ�ݸ��ޯ̧Ͻ�(TO)
        '    '***********************************************
        '    Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        '    objTMST_TRK_TO.FTRK_BUF_NO = objTPRG_TRK_BUF.FTR_TO            '�ׯ�ݸ��ޯ̧��
        '    objTMST_TRK_TO.GET_TMST_TRK()                                  '�擾


        '    '***********************************************
        '    '�����w��QUE        ����
        '    '***********************************************
        '    Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
        '    objTPLN_CARRY_QUE.FPALLET_ID = strFPALLET_ID            '��گ�ID
        '    objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                  '�擾


        '    '***********************************************
        '    '�\�萔             �擾
        '    '***********************************************
        '    Dim intYotei01 As Integer = 0
        '    Dim intYotei02 As Integer = 0
        '    Call GetYoteiNum(objTMST_TRK_TO, intYotei01, intYotei02)
        '    If intYotei01 <= 0 And intYotei02 <= 0 Then Exit Sub


        '    '************************************************
        '    '�\�萔             �ް����
        '    '************************************************
        '    If IsNotNull(objTMST_TRK_TO.XADRS_YOTEI02) Then
        '        '(�ׯ�۰�ނ̏ꍇ)


        '        '************************************************
        '        '����         �����\�萔
        '        '************************************************
        '        If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
        '            '(�߱�����̏ꍇ)
        '            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                                  , intYotei01 _
        '                                                  , intYotei02 - 1 _
        '                                                  )
        '        Else
        '            '(�ݸ�ٔ����̏ꍇ)
        '            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                                  , intYotei01 - 1 _
        '                                                  , intYotei02 _
        '                                                  )
        '        End If


        '    ElseIf IsNotNull(objTMST_TRK_TO.XADRS_YOTEI01) Then
        '        '(�\�萔���ڽ01����`����Ă���ꍇ)


        '        '************************************************
        '        '����         �����\�萔
        '        '************************************************
        '        If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
        '            '(�߱�����̏ꍇ)
        '            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                                  , intYotei01 - 2 _
        '                                                  , 0 _
        '                                                  )
        '        Else
        '            '(�ݸ�ٔ����̏ꍇ)
        '            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                                  , intYotei01 - 1 _
        '                                                  , 0 _
        '                                                  )
        '        End If


        '    End If


        '    '************************************************
        '    '����         �����\�萔
        '    '************************************************
        '    Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        '    'objSVR_190001.FEQ_ID = strFEQ_ID                                '�ݔ�ID
        '    objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
        '    objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
        '    Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                          , intYotei01 _
        '                                          , intYotei02 _
        '                                          )


        'Catch ex As Exception
        '    Call ComError(ex)

        'End Try
    End Sub
#End Region
#Region "  �ׯ�ݸސ�����01(����ԗp�r�ݒ�A�ް����t����Ԑݒ�Ŏg�p)                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸސ�����01(����ԗp�r�ݒ�A�ް����t����Ԑݒ�Ŏg�p)
    ''' �ް���ٰ�߂���ST����肵�A�֘A����o�ɂ��Ȃ������肷��B
    ''' </summary>
    ''' <param name="intXBERTH_GROUP_Before">�ύX�O�̸�ٰ�߇�</param>
    ''' <param name="intXBERTH_GROUP_After">�ύX��̸�ٰ�߇�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CheckTrkBufCount01(ByVal intXBERTH_GROUP_Before As Integer _
                                , ByVal intXBERTH_GROUP_After As Integer _
                                )
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        '************************************************
        '�ׯ�ݸ��ޯ̧               ����
        '************************************************
        Dim strSQL01 As String = ""       'SQL��
        strSQL01 &= vbCrLf & " SELECT "
        strSQL01 &= vbCrLf & "    COUNT(*) "
        strSQL01 &= vbCrLf & " FROM "
        strSQL01 &= vbCrLf & "    TPRG_TRK_BUF "
        strSQL01 &= vbCrLf & " WHERE "
        strSQL01 &= vbCrLf & "    1 = 1 "
        strSQL01 &= vbCrLf & "    AND ("
        strSQL01 &= vbCrLf & "            FTR_TO      IN ( SELECT XSTNO FROM XSTS_CONVEYOR WHERE XBERTH_GROUP IN ( " & intXBERTH_GROUP_Before & ", " & intXBERTH_GROUP_After & " ) ) "
        strSQL01 &= vbCrLf & "         OR FTRK_BUF_NO IN ( SELECT XSTNO FROM XSTS_CONVEYOR WHERE XBERTH_GROUP IN ( " & intXBERTH_GROUP_Before & ", " & intXBERTH_GROUP_After & " ) ) "
        strSQL01 &= vbCrLf & "        ) "
        strSQL01 &= vbCrLf & "    AND FPALLET_ID IS NOT NULL "
        strSQL01 &= vbCrLf
        '���o
        Dim objDataSet As New DataSet   '�ް����
        Dim strDataSetName As String    '�ް���Ė�
        Dim objRow As DataRow           '1ں��ޕ����ް�
        ObjDb.SQL = strSQL01
        objDataSet.Clear()
        strDataSetName = "TPRG_TRK_BUF"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)
        If 0 < TO_INTEGER(objRow(0)) Then
            Throw New UserException("�ύX�O�������͕ύX��̃O���[�v���Ɋ֘A����o�Ƀg���b�L���O�����݂��܂��B", False)
        End If


    End Sub

    '''' *******************************************************************************************************************
    '''' <summary>
    '''' �ׯ�ݸސ�����01(����ԗp�r�ݒ�A�ް����t����Ԑݒ�Ŏg�p)
    '''' </summary>
    '''' <remarks></remarks>
    '''' *******************************************************************************************************************
    'Public Sub CheckTrkBufCount01()
    '    'Dim intRet As RetCode                 '�߂�l
    '    'Dim strMsg As String                  'ү����


    '    '************************************************
    '    '�ׯ�ݸ��ޯ̧               ����
    '    '************************************************
    '    Dim strSQL01 As String = ""       'SQL��
    '    strSQL01 &= vbCrLf & " SELECT "
    '    strSQL01 &= vbCrLf & "    COUNT(*) "
    '    strSQL01 &= vbCrLf & " FROM "
    '    strSQL01 &= vbCrLf & "    TPRG_TRK_BUF "
    '    strSQL01 &= vbCrLf & " WHERE "
    '    strSQL01 &= vbCrLf & "    1 = 1 "
    '    strSQL01 &= vbCrLf & "    AND FTRK_BUF_NO NOT IN (" & TO_STRING(FTRK_BUF_NO_J9000) & "," & TO_STRING(FTRK_BUF_NO_J9100) & "," & TO_STRING(FTRK_BUF_NO_J9200) & ") "
    '    strSQL01 &= vbCrLf & "    AND FPALLET_ID IS NOT NULL "
    '    strSQL01 &= vbCrLf
    '    '���o
    '    Dim objDataSet As New DataSet   '�ް����
    '    Dim strDataSetName As String    '�ް���Ė�
    '    Dim objRow As DataRow           '1ں��ޕ����ް�
    '    ObjDb.SQL = strSQL01
    '    objDataSet.Clear()
    '    strDataSetName = "TPRG_TRK_BUF"
    '    ObjDb.GetDataSet(strDataSetName, objDataSet)
    '    objRow = objDataSet.Tables(strDataSetName).Rows(0)
    '    If 0 < TO_INTEGER(objRow(0)) Then
    '        Throw New UserException("�����q�ɁA���u���A���i�ر�ȊO���ׯ�ݸނ����݂��Ă��܂��B�ׯ�ݸ�����ݽ��ʂ�����ݽ���ĉ������B", False)
    '    End If


    'End Sub
#End Region
#Region "  �ׯ�ݸ޷�ݾقŁA�o�׎w��.�o�׈������������ɖ߂�                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ޷�ݾقŁA�o�׎w��.�o�׈������������ɖ߂�
    ''' </summary>
    ''' <param name="strFPALLET_ID">��گ�ID</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Update_XSYUKKA_KON_RESERVE_Minus(ByVal strFPALLET_ID As String)
        Try

            Dim intRet As RetCode                 '�߂�l
            'Dim strMsg As String                  'ү����


            '************************************************
            '�o�׎w���ڍ�       �擾
            '************************************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            objTRST_STOCK.FPALLET_ID = strFPALLET_ID        '��گ�ID
            objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)       '�擾


            '************************************************
            '�݌Ɉ������       �擾
            '************************************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
            objTSTS_HIKIATE.FPALLET_ID = strFPALLET_ID          '��گ�ID
            objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET()           '�擾


            '************************************************
            '�o�׎w���ڍ�       �擾
            '************************************************
            Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
            objXPLN_OUT_DTL.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY       '�v�淰
            intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL(False)            '�擾
            If intRet = RetCode.OK Then
                '(���������ꍇ)


                '************************************************
                '�o�׈�������       �X�V
                '************************************************
                objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE = objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE - objTRST_STOCK.ARYME(0).FTR_RES_VOL      '�o�׈�������
                objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()


            End If


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region


    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/14 �����������Ȃ��g���b�L���O�̃`�F�b�N
#Region "  �����������Ȃ��ׯ�ݸނ�����                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����������Ȃ��ׯ�ݸނ�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CheckConveyanceTime()
        Try
            Dim intRet As RetCode
            Dim strSQL As String                'SQL��
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�

            '(�P�\���Ԃ̎擾)
            Dim intInterval As Integer = 0
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)     '���ѕϐ��׽
            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSJ000000_044                     '�ϐ�ID
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                         '�擾
            If intRet = RetCode.OK Then
                intInterval = objTPRG_SYS_HEN.FHENSU_INT
            End If

            '���Ԕ͈͂��w�肳��Ă���ꍇ�A���菈�����s��
            If intInterval > 0 Then
                '***********************
                '���oSQL�쐬
                '***********************
                strSQL = ""
                strSQL &= vbCrLf & "         SELECT "
                strSQL &= vbCrLf & "            * "
                strSQL &= vbCrLf & "         FROM"
                strSQL &= vbCrLf & "            TPRG_TRK_BUF"
                strSQL &= vbCrLf & "         WHERE"
                strSQL &= vbCrLf & "                FTRK_BUF_NO IN(" & TO_STRING(FTRK_BUF_NO_J3101)         '�ׯ�ݸ��ޯ̧No(1F���ɒ�)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3102)         '�ׯ�ݸ��ޯ̧No(2F���ɒ�)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3201)         '�ׯ�ݸ��ޯ̧No(1F�o�ɒ�)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3202)         '�ׯ�ݸ��ޯ̧No(2F�o�ɒ�)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3301)         '�ׯ�ݸ��ޯ̧No(1F���ɔ�����)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3302)         '�ׯ�ݸ��ޯ̧No(2F���ɔ�����)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3401)         '�ׯ�ݸ��ޯ̧No(1F�o�ɔ�����)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3402) & ")"   '�ׯ�ݸ��ޯ̧No(2F�o�ɔ�����)
                strSQL &= vbCrLf & "            AND FPALLET_ID IS NOT NULL"                                 '��گ�ID
                strSQL &= vbCrLf & "         ORDER BY "
                strSQL &= vbCrLf & "            FBUF_IN_DT"
                strSQL &= vbCrLf

                '***********************
                '���o
                '***********************
                ObjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TPRG_TRK_BUF"
                ObjDb.GetDataSet(strDataSetName, objDataSet)

                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    For Each objRow As DataRow In objDataSet.Tables(strDataSetName).Rows
                        '(�����̔���)
                        Dim dtmButInDt As Date
                        Dim dtmLimitDt As Date
                        dtmButInDt = TO_DATE(objRow("FBUF_IN_DT"))
                        dtmLimitDt = DateAdd(DateInterval.Minute, intInterval, dtmButInDt)
                        If Now > dtmLimitDt Then
                            'ү���ޏo��
                            Call AddToMsgLog(Now, FMSG_ID_J4002, "�ׯ�ݸ��ް����m�F���āA�����������̑�����s���ĉ������B" _
                                                               , "[������:" & TO_STRING(objRow("FDISP_ADDRESS_FM")) & "]" & _
                                                                 "[������:" & TO_STRING(objRow("FDISP_ADDRESS_TO")) & "]" _
                                                               , "[�����w�ߎ���:" & TO_DATE(objRow("FBUF_IN_DT")).ToString("HH:mm:ss") & "]" _
                                                               , "[��گ�ID:" & TO_STRING(objRow("FPALLET_ID")) & "]" _
                                                               )
                        Else
                            Exit For
                        End If
                    Next
                End If
            End If

        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    'JobMate:S.Ouchi 2013/11/14 �����������Ȃ��g���b�L���O�̃`�F�b�N
    '������������************************************************************************************************************

    '���������ьŗL
    '**********************************************************************************************

End Class
