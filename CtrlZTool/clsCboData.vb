'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���ʊ֐�
' �y�쐬�zSIT
'**********************************************************************************************


Public Class clsCboData

#Region "  �����è�ϐ�              "
    ''' <summary>�����è�ϐ�</summary>
    Private mstrDisp As String
    Private mstrValue As String
    Public Const DISPLAYMEMBER As String = "Disp"
    Public Const VALUEMEMBER As String = "Value"
#End Region
#Region "  �����è��`              "
    ''' <summary>�����è��`</summary>
    Public Property Disp() As String
        Get
            Return mstrDisp
        End Get
        Set(ByVal Value As String)
            mstrDisp = Value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return mstrValue
        End Get
        Set(ByVal Value As String)
            mstrValue = Value
        End Set
    End Property
#End Region
#Region "  �ݽ�׸�                  "
    ''' <summary>�ݽ�׸�</summary>
    Public Sub New(ByVal strDisp As String, ByVal strValue As String)
        mstrDisp = strDisp
        mstrValue = strValue
    End Sub
#End Region
#Region "  ToString�̵��ްײ��      "
    ''' <summary>ToString�̵��ްײ�</summary>
    Public Overrides Function ToString() As String
        Return mstrDisp
    End Function
#End Region

End Class
