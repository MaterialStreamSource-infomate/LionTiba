'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zٰĐݔ������׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100203
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mFBUF_FM As Nullable(Of Integer)        '���ׯ�ݸ��ޯ̧��
    Private mFEQ_ID_CRANE_FM As String              '���ڰݐݔ�ID
    Private mFBUF_TO As Nullable(Of Integer)        '���ׯ�ݸ��ޯ̧��
    Private mFEQ_ID_CRANE_TO As String              '��ڰݐݔ�ID
    Private mstrNG_DTL As String                    'NG�ڍ�
#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>���ׯ�ݸ��ޯ̧��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FBUF_FM() As Nullable(Of Integer)
        Get
            Return mFBUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_FM = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>���ڰݐݔ�ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID_CRANE_FM() As String
        Get
            Return mFEQ_ID_CRANE_FM
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_FM = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>���ׯ�ݸ��ޯ̧��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FBUF_TO() As Nullable(Of Integer)
        Get
            Return mFBUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_TO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>��ڰݐݔ�ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID_CRANE_TO() As String
        Get
            Return mFEQ_ID_CRANE_TO
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_TO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>NG�ڍ�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property STRNG_DTL() As String
        Get
            Return mstrNG_DTL
        End Get
        Set(ByVal Value As String)
            mstrNG_DTL = Value
        End Set
    End Property
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
#Region "  ٰĐݔ�����                                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ٰĐݔ�����
    ''' </summary>
    ''' <param name="objTSTS_HIKIATE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function CHECK_ROUTE(ByRef objTSTS_HIKIATE As TBL_TSTS_HIKIATE) As RetCode
        Try
            Dim strSQL As String        'SQL��
            Dim strMsg As String        'ү����
            Dim intRet As RetCode       '�߂�l


            '************************
            '�����è����
            '************************
            If IsNull(mFBUF_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFBUF_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ڰݐݔ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��ڰݐݔ�ID]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�����N������Ͻ�����
            '************************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    * "
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TMST_CHECK_EQ"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FBUF_FM = " & TO_STRING(mFBUF_FM)                   '���ޯ̧No
            strSQL &= vbCrLf & "    AND FBUF_TO = " & TO_STRING(mFBUF_TO)                   '���ޯ̧No
            strSQL &= vbCrLf & "    AND FEQ_ID_CRANE_FM = '" & mFEQ_ID_CRANE_FM & "'"       '���ڰݐݔ�ID
            strSQL &= vbCrLf & "    AND FEQ_ID_CRANE_TO = '" & mFEQ_ID_CRANE_TO & "'"       '��ڰݐݔ�ID
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FCHECK_EQ_INDEX"                    '����ݔ����ޯ��
            strSQL &= vbCrLf
            Dim objTMST_CHECK_EQ As New TBL_TMST_CHECK_EQ(Owner, ObjDb, ObjDbLog) '�����N������Ͻ�ð��ٸ׽
            objTMST_CHECK_EQ.USER_SQL = strSQL
            intRet = objTMST_CHECK_EQ.GET_TMST_CHECK_EQ_USER()
            If intRet = RetCode.OK Then
                '(���������ꍇ)

                For ii As Integer = LBound(objTMST_CHECK_EQ.ARYME) To UBound(objTMST_CHECK_EQ.ARYME)
                    '(ٰ��:�ΏۂƂȂ�����N������Ͻ���ں��ސ�)


                    '************************
                    '�ݔ��󋵂̓���
                    '************************
                    Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '�ݔ��󋵸׽
                    objTSTS_EQ_CTRL.FEQ_ID = objTMST_CHECK_EQ.ARYME(ii).FCHECK_EQ_ID    '����ݔ�ID
                    intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                     '����


                    '************************
                    '�ݔ��������
                    '************************
                    If TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_STS) <> FEQ_STS_SCHECK_OFF And _
                       TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_STS) <> TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS) Then
                        '(�ݔ���Ԃ�NG�̏ꍇ)

                        '========================
                        'NG�ڍׂ̓o�^
                        '========================
                        mstrNG_DTL = "�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "  ,�ݔ���:" & objTSTS_EQ_CTRL.FEQ_NAME & "  ,۰�ِݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & "  ,�ݔ����:" & TO_STRING(objTSTS_EQ_CTRL.FEQ_STS) & "  ,������:" & TO_STRING(objTMST_CHECK_EQ.ARYME(ii).FEQ_STS)

                        '========================
                        '�w�����M�҂����R�̓o�^
                        '========================
                        objTSTS_HIKIATE.FWAIT_REASON = mstrNG_DTL
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return (RetCode.NG)

                    ElseIf TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_CUT_STS) <> FEQ_CUT_STS_SCHECK_OFF And _
                           TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_CUT_STS) <> TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) Then
                        '(�ؗ���Ԃ�NG�̏ꍇ)

                        '========================
                        'NG�ڍׂ̓o�^
                        '========================
                        mstrNG_DTL = "�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "  ,�ݔ���:" & objTSTS_EQ_CTRL.FEQ_NAME & "  ,۰�ِݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & "  ,�ؗ����:" & TO_STRING(objTSTS_EQ_CTRL.FEQ_CUT_STS) & "  ,������:" & TO_STRING(objTMST_CHECK_EQ.ARYME(ii).FEQ_CUT_STS)

                        '========================
                        '�w�����M�҂����R�̓o�^
                        '========================
                        objTSTS_HIKIATE.FWAIT_REASON = mstrNG_DTL
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return (RetCode.NG)


                    ElseIf TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_REQ_STS) <> FEQ_CUT_STS_SCHECK_OFF And _
                           TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_REQ_STS) <> TO_INTEGER(objTSTS_EQ_CTRL.FEQ_REQ_STS) Then
                        '(�v����Ԃ���������ꍇ)

                        '========================
                        'NG�ڍׂ̓o�^
                        '========================
                        mstrNG_DTL = "�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "  ,�ݔ���:" & objTSTS_EQ_CTRL.FEQ_NAME & "  ,۰�ِݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & "  ,�v�����:" & TO_STRING(objTSTS_EQ_CTRL.FEQ_REQ_STS) & "  ,������:" & TO_STRING(objTMST_CHECK_EQ.ARYME(ii).FEQ_REQ_STS)

                        '========================
                        '�w�����M�҂����R�̓o�^
                        '========================
                        objTSTS_HIKIATE.FWAIT_REASON = mstrNG_DTL
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return (RetCode.NG)

                    End If

                Next

            End If
            objTMST_CHECK_EQ.ARYME_CLEAR()

            Return (RetCode.OK)

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
