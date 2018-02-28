'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ڰݗD�揇�擾�׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100204
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)    '�ׯ�ݸ��ޯ̧No
    Private mFEQ_ID() As String                     '�ݔ�ID(�z��)
#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>�ׯ�ݸ��ޯ̧No</summary>
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
    ''' <summary>�ݔ�ID(�z��)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID() As String()
        Get
            Return mFEQ_ID
        End Get
        Set(ByVal Value As String())
            mFEQ_ID = Value
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
#Region "  �ڰݗD�揇�擾                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ڰݗD�揇�擾
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CRANE_ORDER_GET()
        Try
            Dim strMsg As String        'ү����
            Dim intRet As RetCode       '�߂�l


            '************************
            '�����è����
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�ڰݗD�揇�̍쐬
            '************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         '���ѕϐ��׽
            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002                         '�ϐ�ID
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '�擾
            mFEQ_ID = Split(objTPRG_SYS_HEN.FHENSU_CHAR, KUGIRI01)


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

    '���������ьŗL
    '**********************************************************************************************

End Class
