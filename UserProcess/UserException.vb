'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zհ�ް�װ�׽
' �y�쐬�zSIT
'**********************************************************************************************

Public Class UserException
    Inherits System.ApplicationException

#Region "  �ݽ�׸�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݽ�׸�
    ''' </summary>
    ''' <param name="strUserMessage"></param>
    ''' <param name="blnAddLog">
    ''' True :�װ۸ނ��c��(��̫��)
    ''' False:�װ۸ނ��c���Ȃ�
    ''' </param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal strUserMessage As String _
                 , Optional ByVal blnAddLog As Boolean = True _
                 )
        MyBase.New(strUserMessage)
        mblnAddLog = blnAddLog
    End Sub
#End Region
#Region "�����è��`"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ۸ޏo���׸�
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Property blnAddLog() As Boolean
        Get
            Return mblnAddLog
        End Get
        Set(ByVal Value As Boolean)
            mblnAddLog = Value
        End Set
    End Property
#End Region
#Region "  �����ϐ���`"
    Private mblnAddLog As Boolean   '�װ۸ޏo���׸�
#End Region

    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
