'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�SٰĂ̌����y�ї\��׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100206
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private objAryRoute As TBL_TMST_ROUTE()                                             '����ٰ�Ͻ�
    Private mobjTRK_BUF_NEXT As TBL_TPRG_TRK_BUF()                                      '���ׯ�ݸ��ޯ̧
    Private mobjTRK_BUF_RELAY As TBL_TPRG_TRK_BUF()                                     '���p�ׯ�ݸ��ޯ̧
    Private mFPALLET_ID As String                                                       '��گ�ID
    Private mFBUF_FM As Nullable(Of Integer)                                            '���ޯ̧��
    Private mFEQ_ID_CRANE_FM As String                                                  '���ڰݐݔ�ID
    Private mFBUF_TO As Nullable(Of Integer)                                            '���ޯ̧��
    Private mFEQ_ID_CRANE_TO As String                                                  '��ڰݐݔ�ID
    Private mFRES_KIND As Nullable(Of Integer)                                          '�������
    Private mFWAIT_REASON As String                                                     '�w�����M������R
#End Region
#Region "  �����è��`                                                                          "
    ''' <summary>
    ''' ��گ�ID
    ''' </summary>
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ޯ̧��
    ''' </summary>
    Public Property FBUF_FM() As Nullable(Of Integer)
        Get
            Return mFBUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ڰݐݔ�ID
    ''' </summary>
    Public Property FEQ_ID_CRANE_FM() As String
        Get
            Return mFEQ_ID_CRANE_FM
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ޯ̧��
    ''' </summary>
    Public Property FBUF_TO() As Nullable(Of Integer)
        Get
            Return mFBUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' ��ڰݐݔ�ID
    ''' </summary>
    Public Property FEQ_ID_CRANE_TO() As String
        Get
            Return mFEQ_ID_CRANE_TO
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' �������  (�����^)
    ''' </summary>
    ''' <remarks>
    ''' ð��ٸ׽�������������è
    ''' </remarks>
    Public Property FRES_KIND() As Nullable(Of Integer)
        Get
            Return mFRES_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRES_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' �w�����M������R
    ''' </summary>
    Public Property FWAIT_REASON() As String
        Get
            Return mFWAIT_REASON
        End Get
        Set(ByVal Value As String)
            mFWAIT_REASON = Value
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
#Region "  �SٰĂ̌���                                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �SٰĂ̌���
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_TMST_ROUTE_TO_END() As RetCode
        Try
            Dim strMsg As String            'ү����
            Dim objDataSet As New DataSet   '�ް����
            Dim intRet As RetCode           '�߂�l

            '***********************
            '�����è����
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFBUF_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ڰݐݔ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFBUF_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��ڰݐݔ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFRES_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�������]"
                Throw New UserException(strMsg)
            End If


            '************************
            '����ٰ�Ͻ��̓���
            '************************
            ReDim Preserve objAryRoute(0)
            objAryRoute(0) = New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)   '����ٰ�Ͻ�
            objAryRoute(0).FBUF_FM = mFBUF_FM                             '���ޯ̧��
            objAryRoute(0).FEQ_ID_CRANE_FM = mFEQ_ID_CRANE_FM             '���ڰݐݔ�ID
            objAryRoute(0).FBUF_TO = mFBUF_TO                             '���ޯ̧��
            objAryRoute(0).FEQ_ID_CRANE_TO = mFEQ_ID_CRANE_TO             '��ڰݐݔ�ID
            intRet = objAryRoute(0).GET_TMST_ROUTE(True)                  '����


            '********************************
            '�ŏI�n�_�܂œ��B����܂�ٰ��
            '********************************
            ReDim Preserve mobjTRK_BUF_NEXT(0)
            Dim intMax As Integer = UBound(objAryRoute)                 '�z��̍ő�v�f��
            While TO_INTEGER(objAryRoute(intMax).FBUF_TO) <> TO_INTEGER(objAryRoute(intMax).FBUF_NEXT) And _
                  TO_INTEGER(objAryRoute(intMax).FBUF_RELAY) <> 0 And _
                  TO_INTEGER(objAryRoute(intMax).FBUF_NEXT) <> 0
                '(�ŏI�n�_�܂œ��B����܂�ٰ��)

                '************************
                '���ׯ�ݸ�Ͻ��̓���
                '************************
                Dim objTMST_TRK_FM As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                  '�ׯ�ݸ��ޯ̧Ͻ��׽
                objTMST_TRK_FM.FTRK_BUF_NO = objAryRoute(intMax).FBUF_NEXT                      '�ׯ�ݸ��ޯ̧No
                intRet = objTMST_TRK_FM.GET_TMST_TRK(True)                                      '����

                '************************
                '���ڰݐݔ�ID�̓���
                '************************
                Dim strEQ_ID_CRANE_FM As String
                If TO_INTEGER(objTMST_TRK_FM.FBUF_KIND) = FBUF_KIND_SASRS Then
                    strEQ_ID_CRANE_FM = objAryRoute(intMax).FEQ_ID_CRANE_TO
                Else
                    strEQ_ID_CRANE_FM = FEQ_ID_SKOTEI
                End If

                '************************
                '��ٰĂ��ׯ�ݸ��ޯ̧����
                '************************
                Dim objSVR_100207 As New SVR_100207(Owner, ObjDb, ObjDbLog)                     '��ٰĂ��ׯ�ݸ��ޯ̧�����׽
                objSVR_100207.FPALLET_ID = mFPALLET_ID                                          '��گ�ID
                objSVR_100207.FBUF_FM = objAryRoute(intMax).FBUF_FM                             '���ޯ̧��
                objSVR_100207.FEQ_ID_CRANE_FM = objAryRoute(intMax).FEQ_ID_CRANE_FM             '���ڰݐݔ�ID
                objSVR_100207.FBUF_TO = objAryRoute(intMax).FBUF_TO                             '���ޯ̧��
                objSVR_100207.FEQ_ID_CRANE_TO = objAryRoute(intMax).FEQ_ID_CRANE_TO             '��ڰݐݔ�ID
                intRet = objSVR_100207.GET_NEXT_TPRG_TRK_BUF                                    '��ٰĂ��ׯ�ݸ��ޯ̧����
                If intRet <> RetCode.OK Then
                    mFWAIT_REASON = objSVR_100207.FWAIT_REASON
                    Return (RetCode.NotEnough)
                End If

                '************************
                '���ׯ�ݸ��ޯ̧�̓���
                '************************
                Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)          '�ׯ�ݸ��ޯ̧�׽
                objTPRG_TRK_BUF_TO = objSVR_100207.TPRG_TRK_BUF_NEXT

                '************************
                '���ڰݐݔ�ID�̓���
                '************************
                Dim strEQ_ID_CRANE_TO As String
                strEQ_ID_CRANE_TO = objSVR_100207.FEQ_ID_CRANE

                '************************
                '���p�ׯ�ݸ��ޯ̧�̓���
                '************************
                Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       '�ׯ�ݸ��ޯ̧�׽
                objTPRG_TRK_BUF_RELAY = objSVR_100207.TPRG_TRK_BUF_RELAY

                '************************
                '����ٰ�Ͻ��̓���
                '************************
                ReDim Preserve objAryRoute(UBound(objAryRoute) + 1)                             '�v�f��+1
                intMax = UBound(objAryRoute)                                                    '�z��̍ő�v�f��
                objAryRoute(intMax) = New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)                '����ٰ�Ͻ� �ݽ�ݽ��
                objAryRoute(intMax).FBUF_FM = objAryRoute(intMax - 1).FBUF_NEXT                 '���ޯ̧��
                objAryRoute(intMax).FEQ_ID_CRANE_FM = strEQ_ID_CRANE_FM                         '���ڰݐݔ�ID
                objAryRoute(intMax).FBUF_TO = objAryRoute(intMax - 1).FBUF_TO                   '���ޯ̧��
                objAryRoute(intMax).FEQ_ID_CRANE_TO = strEQ_ID_CRANE_TO                         '��ڰݐݔ�ID
                intRet = objAryRoute(intMax).GET_TMST_ROUTE(True)                               '����


                '************************
                '�\���ޯ̧�̋L��
                '************************
                ReDim Preserve mobjTRK_BUF_NEXT(intMax)                                         '���ׯ�ݸ��ޯ̧��
                ReDim Preserve mobjTRK_BUF_RELAY(intMax)                                        '���p�ׯ�ݸ��ޯ̧��
                mobjTRK_BUF_NEXT(intMax) = objTPRG_TRK_BUF_TO
                mobjTRK_BUF_RELAY(intMax) = objTPRG_TRK_BUF_RELAY

            End While


            Return (RetCode.OK)


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �SٰĂ̗\��                                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �SٰĂ̗\��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub RSV_TMST_ROUTE_TO_END()
        Try
            Dim strMsg As String            'ү����

            '***********************
            '�����è����
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFBUF_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ڰݐݔ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFBUF_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��ڰݐݔ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFRES_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�������]"
                Throw New UserException(strMsg)
            End If

            '************************
            '�\���ޯ̧�̍X�V
            '************************
            If UBound(mobjTRK_BUF_NEXT) > 0 Then
                For ii As Integer = 1 To UBound(mobjTRK_BUF_NEXT)
                    mobjTRK_BUF_NEXT(ii).GET_TPRG_TRK_BUF(False)
                    mobjTRK_BUF_NEXT(ii).FRSV_PALLET = mFPALLET_ID                                  '��گ�ID
                    mobjTRK_BUF_NEXT(ii).FRES_KIND = mFRES_KIND                                     '�������
                    mobjTRK_BUF_NEXT(ii).FBUF_IN_DT = Now                                           '�ޯ̧������
                    If mobjTRK_BUF_NEXT(ii).FPALLET_ID = "" And _
                       mobjTRK_BUF_NEXT(ii).FRES_KIND = FRES_KIND_SAKI Then
                        mobjTRK_BUF_NEXT(ii).UPDATE_TPRG_TRK_BUF()
                    End If

                    mobjTRK_BUF_RELAY(ii).GET_TPRG_TRK_BUF(False)
                    mobjTRK_BUF_RELAY(ii).FRSV_PALLET = mFPALLET_ID                                 '��گ�ID
                    mobjTRK_BUF_RELAY(ii).FRES_KIND = mFRES_KIND                                    '�������
                    mobjTRK_BUF_RELAY(ii).FBUF_IN_DT = Now                                          '�ޯ̧������
                    If mobjTRK_BUF_RELAY(ii).FPALLET_ID = "" And _
                       mobjTRK_BUF_RELAY(ii).FRES_KIND = FRES_KIND_SAKI Then
                        mobjTRK_BUF_RELAY(ii).UPDATE_TPRG_TRK_BUF()
                    End If
                Next
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
