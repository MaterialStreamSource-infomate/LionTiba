'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zð��ٍ폜����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
Imports System.Threading
Imports System.Runtime.Remoting.Lifetime
#End Region

Public Class SVR_040001
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
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Function
#End Region



#Region "  �گ�ދN��                                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����폜�گ�ދN��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecThreadStart() As Integer
        Try
            Dim objThread As New Threading.Thread(AddressOf Me.ExecThread)
            objThread.Start()

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
#Region "  �گ�ޏ���                                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ð��ٍ폜����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ExecThread()
        Dim intRet As RetCode                   '�߂�l
        Dim strMsg As String                    'ү����
        '������������************************************************************************************************************
        'Checked SystemMate:N.Dounoshita 2011/10/25 �گ�ޗpDB�ڑ����@�̏C��
        'Dim mobjDb As clsConn                   'DB������޼ު��
        'Dim mobjDbLog As clsConn                'DB������޼ު��(۸ޏ����ݗp)
        '������������************************************************************************************************************
        Dim requestInitialOwnership As Boolean = True
        Dim mutexWasCreated As Boolean
        Try

            '�r������
            Dim objMtx As New Mutex(requestInitialOwnership, MUTEX_NAME_SVR_040001, mutexWasCreated)

            '�r���҂�����
            If Not (requestInitialOwnership And mutexWasCreated) Then
                objMtx.WaitOne()
            End If
            Try

                '������������************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/10/25 �گ�ޗpDB�ڑ����@�̏C��

                '************************************
                '�گ�ޗpDB�ڑ���޼ު�Ă̐���
                '************************************
                Call GetclsConnThreadConnect()

                ''DB�����޼ު�Đڑ�
                'Dim blnRet As Boolean
                'blnRet = False
                'mobjDb = New clsConn
                'mobjDb.ConnectString = ConfigFile.DBConnectString
                'blnRet = mobjDb.Connect()
                'If blnRet = False Then
                '    Throw New UserException(ERRMSG_DB_CONN)
                'End If
                'mobjDb.BeginTrans()

                ''DB������޼ު�Đڑ�(۸ޏ����ݗp)
                'blnRet = False
                'mobjDbLog = New clsConn
                'mobjDbLog.ConnectString = ConfigFile.DBConnectString
                'blnRet = mobjDbLog.Connect()
                'If blnRet = False Then
                '    Throw New UserException(ERRMSG_DB_CONN)
                'End If

                '������������************************************************************************************************************



                '************************
                '��������
                '************************
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


                '************************
                '����폜Ͻ��Ǎ���
                '************************
                Dim objTMST_DELETE_BASE As New TBL_TMST_DELETE(Owner, ObjDb, ObjDbLog)   '����폜Ͻ��׽
                intRet = Get_PlanDelete(objTMST_DELETE_BASE)

                If intRet = RetCode.OK Then
                    For Each objTMST_DELETE As TBL_TMST_DELETE In objTMST_DELETE_BASE.ARYME
                        '(ٰ��:ð��ٖ���)

                        Try
                            Dim strSQL As String        'SQL��
                            Dim intRetSQL As Integer    'SQL���s�߂�l


                            '************************
                            '�폜SQL�쐬
                            '************************
                            strSQL = ""
                            strSQL &= vbCrLf & "DELETE"
                            strSQL &= vbCrLf & " FROM"
                            strSQL &= vbCrLf & "    " & objTMST_DELETE.FTABLE_NAME
                            strSQL &= vbCrLf & " WHERE"
                            If TO_NUMBER(objTMST_DELETE.FDELETE_KUBUN) = FDELETE_KUBUN_SDAY Then
                                '(�o�ߓ����폜�̏ꍇ)
                                If ConfigFile.DBKind = DB_KIND_ORACLE Then
                                    '(ORACLE�̏ꍇ)
                                    strSQL &= vbCrLf & "    " & objTMST_DELETE.FDELETE_FIELD & " < TO_DATE('" & Format(DateAdd(DateInterval.Day, 0 - TO_NUMBER(objTMST_DELETE.FDELETE_VALUE), Now), "yyyy/MM/dd") & "','YYYY/MM/DD')"
                                ElseIf ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                                    '(SQLSERVER�̏ꍇ)
                                    strSQL &= vbCrLf & "    " & objTMST_DELETE.FDELETE_FIELD & " < '" & Format(DateAdd(DateInterval.Day, 0 - TO_NUMBER(objTMST_DELETE.FDELETE_VALUE), Now), "yyyy/MM/dd") & "'"
                                End If
                            ElseIf TO_NUMBER(objTMST_DELETE.FDELETE_KUBUN) = FDELETE_KUBUN_SVALUE Then
                                '(�ð���폜�̏ꍇ)
                                strSQL &= vbCrLf & "    " & TO_STRING(objTMST_DELETE.FDELETE_FIELD) & " = " & TO_STRING(objTMST_DELETE.FDELETE_VALUE)
                            End If


                            '������������************************************************************************************************************
                            'SystemMate:A.Noto 2012/04/28  �ް��폜�������ڂ�ǉ�
                            If IsNotNull(objTMST_DELETE.FDELETE_KUBUN02) Then
                                '(�폜�敪02��NULL�łȂ��Ƃ�)
                                If TO_NUMBER(objTMST_DELETE.FDELETE_KUBUN02) = FDELETE_KUBUN_SDAY Then
                                    '(�o�ߓ����폜�̏ꍇ)
                                    If ConfigFile.DBKind = DB_KIND_ORACLE Then
                                        '(ORACLE�̏ꍇ)
                                        strSQL &= vbCrLf & " AND " & objTMST_DELETE.FDELETE_FIELD02 & " < TO_DATE('" & Format(DateAdd(DateInterval.Day, 0 - TO_NUMBER(objTMST_DELETE.FDELETE_VALUE02), Now), "yyyy/MM/dd") & "','YYYY/MM/DD')"
                                    ElseIf ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                                        '(SQLSERVER�̏ꍇ)
                                        strSQL &= vbCrLf & " AND " & objTMST_DELETE.FDELETE_FIELD02 & " < '" & Format(DateAdd(DateInterval.Day, 0 - TO_NUMBER(objTMST_DELETE.FDELETE_VALUE02), Now), "yyyy/MM/dd") & "'"
                                    End If
                                ElseIf TO_NUMBER(objTMST_DELETE.FDELETE_KUBUN02) = FDELETE_KUBUN_SVALUE Then
                                    '(�ð���폜�̏ꍇ)
                                    strSQL &= vbCrLf & " AND " & TO_STRING(objTMST_DELETE.FDELETE_FIELD02) & " = " & TO_STRING(objTMST_DELETE.FDELETE_VALUE02)
                                End If
                            End If
                            '������������************************************************************************************************************


                            strSQL &= vbCrLf


                            '************************
                            '�폜����
                            '************************
                            intRetSQL = ObjDb.Execute(strSQL)
                            If intRetSQL = -1 Then
                                '(SQL�װ)
                                strSQL = Replace(strSQL, vbCrLf, "")
                                strMsg = ObjDb.ErrMsg & "�y" & strSQL & "�z"
                                strMsg = ERRMSG_ERR_DELETE & strMsg
                                Throw New System.Exception(strMsg)
                            End If



                        Catch ex As UserException
                            Call ComUser(ex, MeSyoriID)
                            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:" & TO_STRING(objTMST_DELETE.FTABLE_NAME) & "  ,�폜�敪:" & TO_STRING(objTMST_DELETE.FDELETE_KUBUN) & "]")
                            ObjDb.RollBack()                                   '۰��ޯ�
                            ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
                        Catch ex As Exception
                            Call ComError(ex, MeSyoriID)
                            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:" & TO_STRING(objTMST_DELETE.FTABLE_NAME) & "  ,�폜�敪:" & TO_STRING(objTMST_DELETE.FDELETE_KUBUN) & "]")
                            ObjDb.RollBack()                                   '۰��ޯ�
                            ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
                        Finally
                            ObjDb.Commit()     '�Я�
                            ObjDb.BeginTrans() '��ݻ޸��݊J�n
                        End Try
                    Next
                    objTMST_DELETE_BASE.ARYME_CLEAR()


                    '************************************************
                    '�֘A������ں��ލ폜(���ы���)
                    '************************************************
                    Call DeleteScrap()


                    '************************************************
                    '�֘A������ں��ލ폜(���ьŗL)
                    '************************************************
                    Call DeleteScrapSpecial()


                End If


                '************************
                '���튮��
                '************************
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL)


            Finally
                '�r�������J��
                objMtx.ReleaseMutex()

                '������������************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/10/25 �گ�ޗpDB�ڑ����@�̏C��

                '************************************
                '�گ�ޗpDB�ڑ���޼ު�Ă̊J��
                '************************************
                Call DeleteclsConnThreadConnect()

                '������������************************************************************************************************************
            End Try


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region

#Region "  ����폜Ͻ��Ǎ���                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����폜Ͻ��Ǎ���
    ''' </summary>
    ''' <param name="objTMST_DELETE">ð��ٖ�(�z��)</param>
    ''' <returns>OK/NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Get_PlanDelete(ByVal objTMST_DELETE As TBL_TMST_DELETE) As RetCode
        Try
            Dim strSQL As String                'SQL��
            'Dim objDataSet As New DataSet       '�ް����
            'Dim strDataSetName As String        '�ް���Ė�
            'Dim objRow As DataRow               '1ں��ޕ����ް�
            'Dim ii As Integer                   '����


            '************************
            '���oSQL�쐬
            '************************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TMST_DELETE"
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FTABLE_NAME"            'ð��ٖ�
            '������������************************************************************************************************************
            'SystemMate:A.Noto 2012/04/28  �޸ޏC��
            'strSQL &= vbCrLf & "   ,FDELETE_KUBUN"    '�폜�敪
            strSQL &= vbCrLf & "   ,FCONDITION_SERIAL"      '�����A��
            '������������************************************************************************************************************

            strSQL &= vbCrLf


            '************************
            '���o
            '************************
            objTMST_DELETE.USER_SQL = strSQL
            Return objTMST_DELETE.GET_TMST_DELETE_USER()


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
    '���������ы���
#Region "  �֘A������ں��ލ폜(���ы���)                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �֘A������ں��ލ폜(���ы���)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function DeleteScrap() As RetCode
        'Private Function DeleteSpecial() As RetCode
        Try


            Try
                '========================
                '��Ɨ����ڍ�ð���
                '========================
                Dim objTEVD_OPE_DTL As New TBL_TEVD_OPE_DTL(Owner, ObjDb, ObjDbLog)
                objTEVD_OPE_DTL.DELETE_TEVD_OPE_DTL_SCRAP()

            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TEVD_OPE_DTL]")
                ObjDb.RollBack()                                   '۰��ޯ�
                ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TEVD_OPE_DTL]")
                ObjDb.RollBack()                                   '۰��ޯ�
                ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            Finally
                ObjDb.Commit()     '�Я�
                ObjDb.BeginTrans() '��ݻ޸��݊J�n
            End Try


            Try
                '========================
                'ð��ٕύX�����ڍ�ð���
                '========================
                Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
                objTEVD_TBLCHANGE_DTL.DELETE_TEVD_TBLCHANGE_DTL_SCRAP()

            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TEVD_TBLCHANGE_DTL]")
                ObjDb.RollBack()                                   '۰��ޯ�
                ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TEVD_TBLCHANGE_DTL]")
                ObjDb.RollBack()                                   '۰��ޯ�
                ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            Finally
                ObjDb.Commit()     '�Я�
                ObjDb.BeginTrans() '��ݻ޸��݊J�n
            End Try


            Try
                '========================
                '���ڰ���۸ޏڍ�ð���
                '========================
                Dim objTLOG_OPE_DTL As New TBL_TLOG_OPE_DTL(Owner, ObjDb, ObjDbLog)
                objTLOG_OPE_DTL.DELETE_TLOG_OPE_DTL_SCRAP()

            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TLOG_OPE_DTL]")
                ObjDb.RollBack()                                   '۰��ޯ�
                ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TLOG_OPE_DTL]")
                ObjDb.RollBack()                                   '۰��ޯ�
                ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            Finally
                ObjDb.Commit()     '�Я�
                ObjDb.BeginTrans() '��ݻ޸��݊J�n
            End Try


            '������������************************************************************************************************************
            'JobMate:A.Noto 2012/07/05 ���ғߐ{�ł͖��g�p

            'Try
            '    '========================
            '    'νč݌ɏƍ��ڍ�ð���
            '    '========================
            '    Dim objTLOG_CHECK_HOST_DTL As New TBL_TLOG_CHECK_HOST_DTL(Owner, ObjDb, ObjDbLog)
            '    objTLOG_CHECK_HOST_DTL.DELETE_TLOG_CHECK_HOST_DTL_SCRAP()

            'Catch ex As UserException
            '    Call ComUser(ex, MeSyoriID)
            '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TLOG_CHECK_HOST_DTL]")
            '    ObjDb.RollBack()                                   '۰��ޯ�
            '    ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            'Catch ex As Exception
            '    Call ComError(ex, MeSyoriID)
            '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TLOG_CHECK_HOST_DTL]")
            '    ObjDb.RollBack()                                   '۰��ޯ�
            '    ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            'Finally
            '    ObjDb.Commit()     '�Я�
            '    ObjDb.BeginTrans() '��ݻ޸��݊J�n
            'End Try


            'Try
            '    '========================
            '    'ۯ�Ͻ�ð���
            '    '========================
            '    Dim objTMST_LOT As New TBL_TMST_LOT(Owner, ObjDb, ObjDbLog)
            '    objTMST_LOT.DELETE_TMST_LOT_SCRAP()

            'Catch ex As UserException
            '    Call ComUser(ex, MeSyoriID)
            '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TMST_LOT]")
            '    ObjDb.RollBack()                                   '۰��ޯ�
            '    ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            'Catch ex As Exception
            '    Call ComError(ex, MeSyoriID)
            '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ð��ٖ�:TMST_LOT]")
            '    ObjDb.RollBack()                                   '۰��ޯ�
            '    ObjDb.BeginTrans()                                 '��ݻ޸��݊J�n
            'Finally
            '    ObjDb.Commit()     '�Я�
            '    ObjDb.BeginTrans() '��ݻ޸��݊J�n
            'End Try
            '������������************************************************************************************************************


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL
#Region "  �֘A������ں��ލ폜(���ьŗL)                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �֘A������ں��ލ폜(���ьŗL)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function DeleteScrapSpecial() As RetCode
        Try







        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
    '���������ьŗL
    '**********************************************************************************************

End Class
