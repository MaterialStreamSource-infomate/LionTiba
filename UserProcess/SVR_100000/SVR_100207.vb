'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z��ٰĂ��ׯ�ݸ��ޯ̧�����׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100207
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mobjTPRG_TRK_BUF_NEXT As TBL_TPRG_TRK_BUF                                   '���ׯ�ݸ��ޯ̧
    Private mobjTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF                                  '���p�ׯ�ݸ��ޯ̧
    Private mFPALLET_ID As String                                                       '��گ�ID
    Private mFBUF_FM As Nullable(Of Integer)                                            '���ޯ̧��
    Private mFEQ_ID_CRANE_FM As String                                                  '���ڰݐݔ�ID
    Private mFBUF_TO As Nullable(Of Integer)                                            '���ޯ̧��
    Private mFEQ_ID_CRANE_TO As String                                                  '��ڰݐݔ�ID
    Private mFWAIT_REASON As String                                                     '�w�����M������R
    Private mFEQ_ID_CRANE As String                                                     '�ڰݐݔ�ID
#End Region
#Region "  �����è��`                                                                          "
    ''' <summary>
    ''' ���ׯ�ݸ��ޯ̧
    ''' </summary>
    Public Property TPRG_TRK_BUF_NEXT() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_NEXT
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_NEXT = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ׯ�ݸ��ޯ̧
    ''' </summary>
    Public Property TPRG_TRK_BUF_RELAY() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_RELAY
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_RELAY = Value
        End Set
    End Property
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
    ''' <summary>
    ''' �ڰݐݔ�ID
    ''' </summary>
    Public Property FEQ_ID_CRANE() As String
        Get
            Return mFEQ_ID_CRANE
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE = Value
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
#Region "  ��ٰĂ��ׯ�ݸ��ޯ̧����                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ٰĂ��ׯ�ݸ��ޯ̧����
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GET_NEXT_TPRG_TRK_BUF() As RetCode
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
            End If


            '������������************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/19 �����ׯ�ݸ��ޯ̧���ł̔����i��̓I�ɂ͒I�Ԉړ��j�ɂȂ�ƴװ�ƂȂ�̂őΉ�

            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)                  '�ׯ�ݸ��ޯ̧
            objTPRG_TRK_BUF_FM.FPALLET_ID = mFPALLET_ID            '��گ�ID
            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)     '�擾

            '������������************************************************************************************************************


            '************************
            '����ٰ�Ͻ��̓���
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)                 '����ٰ�Ͻ�
            objTMST_ROUTE.FBUF_FM = mFBUF_FM                                                '���ޯ̧��
            objTMST_ROUTE.FEQ_ID_CRANE_FM = mFEQ_ID_CRANE_FM                                '���ڰݐݔ�ID
            objTMST_ROUTE.FBUF_TO = mFBUF_TO                                                '���ޯ̧��
            objTMST_ROUTE.FEQ_ID_CRANE_TO = mFEQ_ID_CRANE_TO                                '��ڰݐݔ�ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                                     '����


            '************************
            '���ׯ�ݸނ̕␳(���ׯ�ݸނ�0�w��̏ꍇ)
            '************************
            If TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 Then
                objTMST_ROUTE.FBUF_NEXT = objTMST_ROUTE.FBUF_TO
            End If

            '************************
            '���ׯ�ݸ�Ͻ��̓���
            '************************
            Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                  '�ׯ�ݸ��ޯ̧Ͻ��׽
            objTMST_TRK_TO.FTRK_BUF_NO = objTMST_ROUTE.FBUF_NEXT                            '�ׯ�ݸ��ޯ̧No
            intRet = objTMST_TRK_TO.GET_TMST_TRK(True)                                      '����

            '************************
            '���ׯ�ݸ��ޯ̧�̓���
            '************************
            mobjTPRG_TRK_BUF_NEXT = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)            '�ׯ�ݸ��ޯ̧Ͻ��׽
            '������������************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/19 �����ׯ�ݸ��ޯ̧���ł̔����i��̓I�ɂ͒I�Ԉړ��j�ɂȂ�ƴװ�ƂȂ�̂őΉ�

            If IsNotNull(objTPRG_TRK_BUF_FM.FRSV_BUF_TO) And IsNotNull(objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO) Then
                '(�����悪�\�񂳂�Ă���ꍇ)
                mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FRSV_BUF_TO              '�ׯ�ݸ��ޯ̧No
                mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO         '�ׯ�ݸ��ޯ̧�z��
                intRet = mobjTPRG_TRK_BUF_NEXT.GET_TPRG_TRK_BUF(False)                          '����
            Else
                '(�����悪�\�񂳂�Ă��Ȃ��ꍇ)
                mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO = objTMST_TRK_TO.FTRK_BUF_NO                  '�ׯ�ݸ��ޯ̧No
                intRet = RetCode.NotFound
            End If

            'mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO = objTMST_TRK_TO.FTRK_BUF_NO                  '�ׯ�ݸ��ޯ̧No
            'mobjTPRG_TRK_BUF_NEXT.FRSV_PALLET = mFPALLET_ID                                 '��������گ�ID
            'intRet = mobjTPRG_TRK_BUF_NEXT.GET_TPRG_TRK_BUF_RSV_PALLET                      '����

            '������������************************************************************************************************************
            If intRet = RetCode.OK Then
                '(��Ɉ�������Ă���ꍇ)
                If TO_INTEGER(objTMST_TRK_TO.FBUF_KIND) = FBUF_KIND_SASRS Then
                    '************************
                    '�ڰ�Ͻ��̓���
                    '************************
                    Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)         '�ڰ�Ͻ��׽
                    objTMST_CRANE.FTRK_BUF_NO = mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO           '�ޯ̧��
                    objTMST_CRANE.INTCHECK_ROW = mobjTPRG_TRK_BUF_NEXT.FRAC_RETU            '��
                    intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                               '����
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                        Throw New UserException(strMsg)
                    End If

                    '************************
                    '��ڰݐݔ�ID�̓���
                    '************************
                    mFEQ_ID_CRANE = objTMST_CRANE.FEQ_ID

                Else

                    '************************
                    '��ڰݐݔ�ID�̓���
                    '************************
                    mFEQ_ID_CRANE = FEQ_ID_SKOTEI

                End If
            Else
                '(�V���Ɉ�������ꍇ)
                If TO_INTEGER(objTMST_TRK_TO.FBUF_KIND) = FBUF_KIND_SASRS Then
                    '(�����q�ɂ̏ꍇ)
                    '************************
                    '�����\�ȑS�ڰ݂��擾
                    '************************
                    Dim strEQ_ID() As String                                                '�ڰ�ID
                    intRet = objTMST_ROUTE.GET_TMST_ROUTE_CRANES()                          '�ڰ�ID�擾
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        strMsg = ERRMSG_NOTFOUND_TMST_ROUTE & "[���ޯ̧��:" & TO_STRING(objTMST_ROUTE.FBUF_FM) & "][���ڰݐݔ�ID:" & objTMST_ROUTE.FEQ_ID_CRANE_FM & "][���ޯ̧��:" & TO_STRING(objTMST_ROUTE.FBUF_TO) & "][��ڰݐݔ�ID:******]"
                        Throw New UserException(strMsg)
                    End If
                    ReDim Preserve strEQ_ID(UBound(objTMST_ROUTE.ARYME))
                    For ii As Integer = LBound(objTMST_ROUTE.ARYME) To UBound(objTMST_ROUTE.ARYME)
                        strEQ_ID(ii) = objTMST_ROUTE.ARYME(ii).FEQ_ID_CRANE_TO
                    Next
                    objTMST_ROUTE.ARYME_CLEAR()


                    '************************
                    '�݌ɏ��   �擾
                    '************************
                    Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)             '�݌ɏ��ð���
                    objTRST_STOCK.FPALLET_ID = mFPALLET_ID
                    intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)


                    '************************
                    '�i��Ͻ��擾
                    '************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)             '�i��Ͻ�
                    objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD
                    intRet = objTMST_ITEM.GET_TMST_ITEM(True)


                    '************************
                    '�ړ����ޯ̧�̋�I����
                    '************************
                    Dim objSVR_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog)             '��I�����׽
                    objSVR_100201.FTRK_BUF_NO = mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO           '�ޯ̧��
                    objSVR_100201.FEQ_ID_CRANE = strEQ_ID                                   '�ڰ�ID
                    objSVR_100201.FPALLET_ID = mFPALLET_ID                                  '��گ�ID
                    intRet = objSVR_100201.FIND_TANA_AKI                                    '����
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        mFWAIT_REASON = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO) & "]"
                        Return (RetCode.NotEnough)
                    End If
                    mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO = objSVR_100201.FTRK_BUF_NO           '�ޯ̧��
                    mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_ARRAY = objSVR_100201.FTRK_BUF_ARRAY     '�z��
                    intRet = mobjTPRG_TRK_BUF_NEXT.GET_TPRG_TRK_BUF(False)                  '����
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO) & "  ,�z��:" & TO_STRING(mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_ARRAY) & "]"
                        Throw New UserException(strMsg)
                    End If

                    '************************
                    '�ڰ�Ͻ��̓���
                    '************************
                    Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)         '�ڰ�Ͻ��׽
                    objTMST_CRANE.FTRK_BUF_NO = mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO           '�ޯ̧��
                    objTMST_CRANE.INTCHECK_ROW = mobjTPRG_TRK_BUF_NEXT.FRAC_RETU            '��
                    intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                               '����
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                        Throw New UserException(strMsg)
                    End If

                    '************************
                    '��ڰݐݔ�ID�̓���
                    '************************
                    mFEQ_ID_CRANE = objTMST_CRANE.FEQ_ID


                Else
                    '(�����q�ɈȊO�̏ꍇ)

                    '************************
                    '�ړ����ޯ̧�̈���
                    '************************
                    '������������************************************************************************************************************
                    'Checked SystemMate:N.Dounoshita 2011/12/13 �o�ɐ���������ĂȂ��ꍇ�́A���������s��Ȃ��Ă��ǂ����A�󂫂��Ȃ��Əo�Ɏw���o���Ȃ��B
                    '                                   �������A����ۼޯ����������Ȃ��ƁA����ɏo�Ɏw��������Ȃ��B

                    intRet = mobjTPRG_TRK_BUF_NEXT.GET_TPRG_TRK_BUF_AKI_HIRA                '����
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        mFWAIT_REASON = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO) & "]"
                        Return (RetCode.NotEnough)
                    End If

                    '������������************************************************************************************************************


                    '************************
                    '��ڰݐݔ�ID�̓���
                    '************************
                    mFEQ_ID_CRANE = FEQ_ID_SKOTEI
                End If
            End If

            If TO_INTEGER(objTMST_ROUTE.FBUF_RELAY) > 0 Then
                '************************
                '���p�ׯ�ݸ��ޯ̧�̓���
                '************************
                mobjTPRG_TRK_BUF_RELAY = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)           '�ׯ�ݸ��ޯ̧Ͻ��׽
                mobjTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = objTMST_ROUTE.FBUF_RELAY                   '�ׯ�ݸ��ޯ̧No
                mobjTPRG_TRK_BUF_RELAY.FRSV_PALLET = mFPALLET_ID                                '��������گ�ID
                intRet = mobjTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF_RSV_PALLET                     '����
                If intRet = RetCode.OK Then
                    '(��Ɉ�������Ă���ꍇ)
                Else
                    '(�V���Ɉ�������ꍇ)
                    '************************
                    '�ړ����ޯ̧�̈���
                    '************************
                    intRet = mobjTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF_AKI_HIRA                   '����
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        mFWAIT_REASON = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(mobjTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "]"
                        Return (RetCode.NotEnough)
                    End If
                End If
            End If

            Return (RetCode.OK)


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
