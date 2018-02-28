'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ׯ�ݸދ��������׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100301
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)    '�ׯ�ݸ��ޯ̧��
    Private mFPALLET_ID As String                   '��گ�ID
#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>�ׯ�ݸ��ޯ̧��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>��گ�ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
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
#Region "  �ׯ�ݸދ�������                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸދ�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MENTE_FINISH()
        Try
            Dim strMsg As String                    'ү����
            Dim intRet As RetCode                   '�߂�l


            '************************
            '�����è����
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
                Throw New UserException(strMsg)
            End If

          

            '************************
            '�ׯ�ݸ�Ͻ��̓���
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧Ͻ��׽
            objTMST_TRK.FTRK_BUF_NO = mFTRK_BUF_NO                      '�ׯ�ݸ��ޯ̧No
            intRet = objTMST_TRK.GET_TMST_TRK(True)                     '����

            
            '************************
            '�ׯ�ݸދ�������
            '************************
            Select Case TO_INTEGER(objTMST_TRK.FBUF_KIND)
                Case FBUF_KIND_SIN
                    '(���ɒ��̏ꍇ)

                    '========================
                    '���ɒ���������
                    '========================
                    Dim objSVR_010102 As New SVR_010102(Owner, ObjDb, ObjDbLog) '���Ɋ����׽
                    objSVR_010102.FPALLET_ID = mFPALLET_ID                      '��گ�ID
                    objSVR_010102.FINOUT_STS = FINOUT_STS_SMENTE_FINISH_IN       'IN/OUT
                    Call objSVR_010102.ExecCmdFunction()


                Case FBUF_KIND_SOUT
                    '(�o�ɒ��̏ꍇ)

                    '========================
                    '�o�ɒ���������
                    '========================
                    Dim objSVR_010202 As New SVR_010202(Owner, ObjDb, ObjDbLog) '�o�Ɋ����׽
                    objSVR_010202.FPALLET_ID = mFPALLET_ID                      '��گ�ID
                    objSVR_010202.FINOUT_STS = FINOUT_STS_SMENTE_FINISH_OUT      'IN/OUT
                    Call objSVR_010202.ExecCmdFunction()


                Case FBUF_KIND_STRNS
                    '(�������̏ꍇ)


                    '������������************************************************************************************************************
                    'JobMate:N.Dounoshita 2013/09/03 �\�萔ϲŽ1


                    ''*********************************************
                    ''�\�萔ϲŽ1
                    ''*********************************************
                    'Call UpdateYoteiNumMinus1(mFTRK_BUF_NO, mFPALLET_ID)


                    '������������************************************************************************************************************

                    '========================
                    '��������������
                    '========================
                    Dim objSVR_010302 As New SVR_010302(Owner, ObjDb, ObjDbLog) '���������׽
                    objSVR_010302.FPALLET_ID = mFPALLET_ID                      '��گ�ID
                    objSVR_010302.FINOUT_STS = FINOUT_STS_SMENTE_FINISH_RELAY    'IN/OUT
                    Call objSVR_010302.ExecCmdFunction()


                Case FBUF_KIND_SSOUKO
                    '(�q�ɊԔ����̏ꍇ)

                    '========================
                    '�q�ɊԔ�������������
                    '========================
                    Dim objSVR_010102 As New SVR_010102(Owner, ObjDb, ObjDbLog) '���Ɋ����׽
                    objSVR_010102.FPALLET_ID = mFPALLET_ID                      '��گ�ID
                    objSVR_010102.FINOUT_STS = FINOUT_STS_SMENTE_FINISH_SOUKO    'IN/OUT
                    Call objSVR_010102.ExecCmdFunction()


                Case Else
                    '(������Ȃ��ꍇ)

                    strMsg = ERRMSG_DISP_MENTE_FINISH_BUF_KIND & "[�������ȊO���ׯ�ݸ�]" & "[�ޯ̧No:" & TO_STRING(objTMST_TRK.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)


            End Select


            '************************
            '�������䑗�MIF�̍폜
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '�������䑗�MIF�׽
            objTLIF_TRNS_SEND.FPALLET_ID = mFPALLET_ID                              '��گ�ID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '�폜


            '************************
            '���������MIF�̍폜
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '���������MIF�׽
            objTLIF_TRNS_RECV.FPALLET_ID = mFPALLET_ID                              '��گ�ID
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

    '**********************************************************************************************
    '���������ьŗL
#Region "  ���ꏈ��31(�\�萔ؾ��)                                                                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��31(�\�萔ؾ��)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special31() As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************
        '����
        '************************
        'NOP

        '***********************************************
        '�ׯ�ݸ��ޯ̧
        '***********************************************
        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF.FPALLET_ID = mFPALLET_ID        '��گ�ID
        objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()
        If IsNull(objTPRG_TRK_BUF.FTR_TO) Then Return RetCode.OK


        '***********************************************
        '�ׯ�ݸ��ޯ̧Ͻ�(TO)
        '***********************************************
        Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK_TO.FTRK_BUF_NO = objTPRG_TRK_BUF.FTR_TO            '�ׯ�ݸ��ޯ̧��
        objTMST_TRK_TO.GET_TMST_TRK()                                  '�擾


        '**************************************
        '�����\�萔         ���M
        '�����\�萔��ؾ��
        '**************************************
        If IsNotNull(objTMST_TRK_TO.XADRS_YOTEI01) Then
            '(�\�萔������ꍇ)
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
            objSVR_190001.FPALLET_ID = ""                                   '��گ�ID
            objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
                                                  , 0 _
                                                  , 0 _
                                                  )
        End If


        Return intReturn
    End Function
#End Region
    '���������ьŗL
    '**********************************************************************************************

End Class
