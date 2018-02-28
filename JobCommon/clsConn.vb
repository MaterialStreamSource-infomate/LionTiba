'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y�@�\�z�ȸĸ׽
'           ���Đڑ������͐ڑ��߰�ݸ�(��̫�ėL��)�𖳌��ɂ��Ȃ��ƁADecr Pool Size(��̫��5��)���A
'           �@�Đڑ����������܂������Ȃ��Ȃ�
'           �@�ײ���/���ް�^�̱��ع���݂ł́A�߰�ݸދ@�\�������Ă����܂�Ӗ����Ȃ��ׁA
'           �@�ڑ��߰�ݸދ@�\�𖳌��ɂ���[�ڑ��������"Pooling=false"������]
'           �@by KSH H.Kita
'           ��VBA,VB6����̎Q�Ƃ͍s��Ȃ����߁A�@�\�Ƃ��č폜
'           �@�܂��A���Ұ���޼ު�Ă͵�޼ު�Č^�łȂ����޲��ޕϐ��Ƃ��Ă̋@�\��
'             �s���S�ɂȂ邽�߁ARev 0.00�ɖ߂����B
'           �@by KSH Y.Kitagawa
'
'           ��Rev 0.03
'             ��xDB�̐ڑ����ؒf�����ƁA��x�ƍĐڑ��o���Ȃ������B
'             �����I�ɍĐڑ������悤�ɏC��
'           �@by KSH Y.Kitagawa
'
' �y�쐬�z2006/09/21  KSH J.Kato      Rev 0.00
'         2007/10/01  KSH H.Kita      Rev 0.01
'         2008/06/25  KSH Y.Kitagawa  Rev 0.02
'         2009/08/06  KSH Y.Kitagawa  Rev 0.03
'**********************************************************************************************

#Region " Imports "
Imports System
Imports System.Data
Imports System.Threading
Imports System.Collections
Imports System.Collections.Specialized
Imports Oracle.DataAccess.Client
Imports System.Runtime.Remoting.Lifetime
#End Region

Public Class clsConn

#Region "  �萔�錾"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �萔�錾
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Const SLEEP_TIME As Integer = 1000

    ' �Đڑ��������s���G���[�R�[�h��`
    Public Enum RetryErrCode
        ErrCode01033 = 1033
        ErrCode01034 = 1034
        ErrCode01089 = 1089
        ErrCode03001 = -3001
        ErrCode03113 = 3113
        ErrCode03114 = 3114
        ErrCode12203 = 12203
        ErrCode12500 = 12500
        ErrCode12537 = 12537
        ErrCode12545 = 12545
        ErrCode12560 = 12560
        ErrCode12571 = 12571
    End Enum

#End Region

#Region "  �ϐ��錾"
    '�����ϐ�
    Private RETRY_COUNT As Integer                  'DB�Đڑ���ײ��(1����ײ�Ȃ�)

    'Private moForm As frmConnPool
    Protected mobjOraCon As OracleConnection
    Private mobjRdr As OracleDataReader
    Private mobjOraValue() As Object        ' ORACLE�t�B�[���h�f�[�^
    Private mobjFieldName As New StringCollection   'ORACLE�t�B�[���h��
    Private mintOraValueCnt As Integer
    Private mstrSQL As String
    Private mstrErrMsg As String
    Private mintErrCode As Integer
    Private mobjTrans As OracleTransaction
    Private mstrConnectString As String
    Private Owner As Object                         '�I�[�i�I�u�W�F�N�g
    Private da As New OracleDataAdapter             'Oracle �ް� ������

    '�޲��ޕϐ��p��޼ު��
    Private mBndObj(,) As Object                   '�޲��ޕϐ��p��޼ު��

    Protected mblnReconnectingFlg As Boolean      '�ȸď�Ԃ����ڑ���Ԏ��ɍĐڑ����邩�ǂ������׸�
    '                                              True�F�Đڑ�����B�@False�F�Đڑ����Ȃ��B
#End Region

#Region " ����Đ錾 "

    'DB�ؒf�����
    Public Delegate Sub ConnectBrokenEventHandler(ByVal Sender As Object)
    Public Event ConnectBroken As ConnectBrokenEventHandler

#End Region

#Region "  �ݽ�׸�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="intConnectRtryCnt">DB�Đڑ���ײ��(1����ײ�Ȃ�)���ȗ�����1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(Optional ByVal intConnectRtryCnt As Integer = 1)
        Owner = Nothing
        RETRY_COUNT = intConnectRtryCnt  'DB�Đڑ���ײ��
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ������
    ''' </summary>
    ''' <param name="objOwner">�I�[�i�I�u�W�F�N�g��`</param>
    ''' <param name="intConnectRtryCnt">DB�Đڑ���ײ��(1����ײ�Ȃ�)���ȗ�����1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, Optional ByVal intConnectRtryCnt As Integer = 1)
        Owner = objOwner        '�I�[�i�I�u�W�F�N�g��`
        RETRY_COUNT = intConnectRtryCnt  'DB�Đڑ���ײ��
    End Sub

#End Region

#Region "  Finalize"

    Protected Overrides Sub Finalize()
        Owner = Nothing
        mobjOraValue = Nothing
        mobjFieldName = Nothing
        If IsNothing(mobjTrans) = False Then
            mobjTrans.Dispose()
            mobjTrans = Nothing
        End If
        If IsNothing(mobjRdr) = False Then
            mobjRdr.Close()
            mobjRdr.Dispose()
            mobjRdr = Nothing
        End If
        If IsNothing(mobjOraCon) = False Then
            mobjOraCon.Close()
            mobjOraCon.Dispose()
            mobjOraCon = Nothing
        End If
        MyBase.Finalize()
    End Sub

#End Region

#Region "  �����è"
    '------------------------------------------------------------------------
    ' �v���p�e�B
    '------------------------------------------------------------------------
    ''' =======================================
    ''' <summary>OraCon �v���p�e�B</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property OraCon() As Object
        Get
            Return mobjOraCon
        End Get
    End Property

    ''' =======================================
    ''' <summary>Rdr �v���p�e�B</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property Rdr() As Object
        Get
            Return mobjRdr
        End Get
    End Property

    ''' =======================================
    ''' <summary>ErrMsg �v���p�e�B</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ErrMsg() As String
        Get
            Return mstrErrMsg
        End Get
    End Property

    ''' =======================================
    ''' <summary>ErrCode �v���p�e�B</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ErrCode() As Integer
        Get
            Return mintErrCode
        End Get
    End Property

    ''' =======================================
    ''' <summary>SQL �v���p�e�B</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property SQL() As String
        Get
            Return mstrSQL
        End Get
        Set(ByVal Value As String)
            mstrSQL = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ConnectString �v���p�e�B</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property ConnectString() As String
        Get
            Return mstrConnectString
        End Get
        Set(ByVal Value As String)
            mstrConnectString = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>Parameter �v���p�e�B</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property Parameter() As Object
        Get
            Return mBndObj
        End Get
        Set(ByVal value As Object)
            mBndObj = value
        End Set
    End Property

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Data �v���p�e�B
    ''' </summary>
    ''' <param name="intIndex">0����n�܂�t�B�[���h�C���f�b�N�X</param>
    ''' <value></value>
    ''' <returns>�t�B�[���h�f�[�^</returns>
    ''' <remarks>�t�B�[���h�f�[�^�̎擾</remarks>
    ''' *******************************************************************************************************************
    Public Overloads ReadOnly Property Data(ByVal intIndex As Integer) As Object
        Get
            Return mobjOraValue(intIndex)
        End Get
    End Property

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Data
    ''' </summary>
    ''' <param name="strIndex">�t�B�[���h��</param>
    ''' <value></value>
    ''' <returns>�t�B�[���h�f�[�^</returns>
    ''' <remarks>�t�B�[���h�f�[�^�̎擾</remarks>
    ''' *******************************************************************************************************************
    Public Overloads ReadOnly Property Data( _
        ByVal strIndex As String _
        ) As Object
        Get
            Dim intIndex As Integer
            intIndex = SearchFieldIndex(strIndex)
            If intIndex >= 0 Then
                Return mobjOraValue(intIndex)
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "  Connect"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �f�[�^�x�[�X�ɐڑ�
    ''' </summary>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Connect() As Boolean
        Dim requestInitialOwnership As Boolean = True
        Dim mutexWasCreated As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer

        blnRet = True
        '�r������
        Dim objMtx As New Mutex(requestInitialOwnership, "mConnenct", mutexWasCreated)

        '�r���҂�����
        If Not (requestInitialOwnership And mutexWasCreated) Then
            objMtx.WaitOne()
        End If
        Try
            '--------------------------------------------------------------------
            ' �f�[�^�x�[�X�ɐڑ�
            '--------------------------------------------------------------------
            Call ClearExceptionData()
            For i = 0 To RETRY_COUNT - 1
                Try
                    '�ڑ�����
                    If IsNothing(mobjOraCon) = True Then
                        mobjOraCon = New OracleConnection
                        mobjOraCon.ConnectionString = mstrConnectString
                        mobjOraCon.Open()
                        Exit For
                    Else
                        Exit For
                    End If
                Catch ex As OracleException
                    strErrMsg = ex.Message
                    Call SetExceptionData(ex.Message, ex.Number)
                    Disconnect()                    '�ǉ��@Rev 0.03
                    If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                        '' ''Disconnect()                    '�폜�@Rev 0.03
                        Thread.Sleep(SLEEP_TIME)
                    Else
                        Disconnect()
                        blnRet = False
                    End If
                End Try
            Next

        Finally
            '�r�������J��
            objMtx.ReleaseMutex()
        End Try

        Return blnRet

    End Function
#End Region

#Region "  Disconnect"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �f�[�^�x�[�X��ؒf
    ''' </summary>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Disconnect() As Boolean
        Dim strErrMsg As String
        Dim blnRet As Boolean

        blnRet = True
        '--------------------------------------------------------------------
        ' �f�[�^�x�[�X��ؒf
        '--------------------------------------------------------------------
        'Call ClearExceptionData()
        Try
            If IsNothing(mobjRdr) = False Then
                mobjRdr.Close()
                mobjRdr.Dispose()
                mobjRdr = Nothing
            End If
            If IsNothing(mobjOraCon) = False Then
                mobjOraCon.Close()
                mobjOraCon.Dispose()
                mobjOraCon = Nothing
            End If
        Catch ex As OracleException
            strErrMsg = ex.Message
            Call SetExceptionData(ex.Message, ex.Number)
            blnRet = False
        End Try

        Return blnRet
    End Function
#End Region

#Region "  GetData"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����܂���SQL�v���p�e�B�ɐݒ肳�ꂽSELECT���Ńf�[�^���擾
    ''' </summary>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks>������:SQL��(�ȗ����ASQL�v���p�e�B�ݒ肳�ꂽSQL�����s)</remarks>
    ''' *******************************************************************************************************************
    Public Function GetData() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer
        Dim intCnt As Integer
        Dim oCmd As OracleCommand = Nothing

        blnRet = False
        '--------------------------------------------------------------------
        ' SELECT���Ńf�[�^���擾
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB�ؒf�ʒm�����
                        Throw New SystemException("DB�Đڑ��Ɏ��s���܂���")
                    End If
                End If
                If IsNothing(mobjRdr) = False Then
                    mobjRdr.Close()
                    mobjRdr.Dispose()
                    mobjRdr = Nothing
                End If

                oCmd = New OracleCommand(mstrSQL, mobjOraCon)
                oCmd.BindByName = True

                '====================================================================
                ' �޲��ޕϐ���ď���
                '====================================================================
                If IsNothing(mBndObj) = False Then
                    '(�޲��ޕϐ���ėp��޼ު�Ă�����ꍇ)

                    '--------------------------------------------------------------------
                    ' �޲��ޕϐ����
                    '--------------------------------------------------------------------
                    For intii As Integer = 0 To UBound(mBndObj, 2)
                        '(�޲��ޕϐ��ɒl���)
                        oCmd.Parameters.Add(mBndObj(0, intii), mBndObj(1, intii))
                    Next

                    mBndObj = Nothing           'mBndObj��nothing��ݒ�

                End If


                mobjRdr = oCmd.ExecuteReader()

                '--------------------------------------------------------------------
                ' �t�B�[���h�f�[�^���擾
                '--------------------------------------------------------------------
                mobjFieldName.Clear()
                For intCnt = 0 To mobjRdr.FieldCount - 1
                    Dim intIndex As Integer
                    intIndex = mobjFieldName.Add(mobjRdr.GetName(intCnt))
                Next

                oCmd.Dispose()
                oCmd = Nothing

                blnRet = True
                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message

                If IsNothing(oCmd) = False Then
                    oCmd.Dispose()
                    oCmd = Nothing
                End If

                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '�ǉ��@Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    '' ''Disconnect()                    '�폜�@Rev 0.03
                    'mobjOraCon = Nothing
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet
    End Function
#End Region

#Region "  GetDataSet"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����܂���SQL�v���p�e�B�ɐݒ肳�ꂽSELECT���Ńf�[�^���擾 ���ʂ� DataSet �Ɋi�[����
    ''' </summary>
    ''' <param name="strCur">�e�[�u�� �}�b�v�Ɏg�p����\�[�X �e�[�u���̖�</param>
    ''' <param name="dsData">�f�[�^�Z�b�g</param>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks>�޲��ޕϐ����p�@(kato)</remarks>
    ''' *******************************************************************************************************************
    Public Function GetDataSet(ByVal strCur As String, _
                               ByRef dsData As DataSet) As Boolean


        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer
        Dim oCmd As OracleCommand = Nothing

        blnRet = False

        Try
            '--------------------------------------------------------------------
            ' SELECT���Ńf�[�^���擾��A�f�[�^�Z�b�g�Ɋi�[
            '--------------------------------------------------------------------
            Call ClearExceptionData()
            For i = 0 To RETRY_COUNT - 1
                Try
                    If IsNothing(mobjOraCon) = True Then
                        If Connect() = False Then
                            RaiseEvent ConnectBroken(Me)        'DB�ؒf�ʒm�����
                            Throw New SystemException("DB�Đڑ��Ɏ��s���܂���")
                        End If
                    End If
                    'Dim sg As OracleGlobalization = mobjOraCon.GetSessionInfo()
                    oCmd = New OracleCommand(mstrSQL, mobjOraCon)
                    oCmd.BindByName = True
                    da = New OracleDataAdapter(oCmd)

                    '====================================================================
                    ' �޲��ޕϐ���ď���
                    '====================================================================
                    If IsNothing(mBndObj) = False Then
                        '(�޲��ޕϐ���ėp��޼ު�Ă�����ꍇ)

                        '--------------------------------------------------------------------
                        ' �޲��ޕϐ����
                        '--------------------------------------------------------------------
                        For intii As Integer = 0 To UBound(mBndObj, 2)
                            '(�޲��ޕϐ��ɒl���)
                            da.SelectCommand.Parameters.Add(mBndObj(0, intii), mBndObj(1, intii))
                        Next

                        mBndObj = Nothing           'mBndObj��nothing��ݒ�

                    End If


                    da.Fill(dsData, strCur)

                    oCmd.Dispose()
                    oCmd = Nothing

                    blnRet = True
                    Exit For
                Catch ex As OracleException
                    strErrMsg = ex.Message

                    If IsNothing(da) = False Then
                        da.Dispose()
                        da = Nothing
                    End If
                    If IsNothing(oCmd) = False Then
                        oCmd.Dispose()
                        oCmd = Nothing
                    End If

                    SetExceptionData(ex.Message, ex.Number)
                    Disconnect()                    '�ǉ��@Rev 0.03
                    If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                        '' ''Disconnect()                    '�폜�@Rev 0.03
                        'mobjOraCon = Nothing
                        Thread.Sleep(SLEEP_TIME)
                    Else
                        Throw ex
                    End If
                Catch exs As Exception
                    Throw exs
                End Try
            Next
        Finally
            If IsNothing(da) = False Then
                da.Dispose()
                da = Nothing
            End If
        End Try

        Return blnRet
    End Function
#End Region

#Region "  Read"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SELECT���Ŏ擾�����f�[�^����s�擾
    ''' </summary>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Read() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim intFieldNo As Integer
        Dim intCounter As Integer
        Dim i As Integer

        blnRet = False
        '--------------------------------------------------------------------
        ' ��s���̃f�[�^���擾
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB�ؒf�ʒm�����
                        Throw New SystemException("DB�Đڑ��Ɏ��s���܂���")
                    End If
                End If

                If IsNothing(mobjRdr) = True Then
                    GetData()
                End If

                If mobjRdr.Read() = True Then
                    intFieldNo = mobjRdr.FieldCount
                    ReDim mobjOraValue(intFieldNo - 1)              ' �t�B�[���h���̔z����쐬
                    mintOraValueCnt = intFieldNo                    ' �z�񐔂�ۑ�(CloseDB�Ŏg�p)
                    For intCounter = 0 To intFieldNo - 1            ' �t�B�[���h���I�u�W�F�N�g���Z�b�g
                        mobjOraValue(intCounter) = mobjRdr.GetValue(intCounter)
                    Next intCounter
                    blnRet = True
                    Exit For
                End If
            Catch ex As OracleException
                strErrMsg = ex.Message
                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '�ǉ��@Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    'mobjOraCon = Nothing
                    '' ''Disconnect()                    '�폜�@Rev 0.03
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet
    End Function
#End Region

#Region "  CloseDataReader"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �f�[�^���[�_���N���[�Y
    ''' </summary>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function CloseDataReader() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String

        blnRet = False
        '--------------------------------------------------------------------
        ' �f�[�^���[�_���N���[�Y
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        Try
            If IsNothing(mobjRdr) = False Then
                mobjRdr.Close()
                mobjRdr.Dispose()
                mobjRdr = Nothing
            End If

            blnRet = True

        Catch ex As OracleException
            strErrMsg = ex.Message
            Call SetExceptionData(ex.Message, ex.Number)
        End Try

        Return blnRet

    End Function
#End Region

#Region "  Execute"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����܂���SQL�v���p�e�B�ɐݒ肳�ꂽSQL�����s
    ''' </summary>
    ''' <param name="asSQL">SQL�� �i�ȗ����ASQL�v���p�e�B�ݒ肳�ꂽSQL�����s</param>
    ''' <returns>���펞 ��������(�������� 0)/ �ُ펞 -1</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Function Execute(Optional ByVal asSQL As String = "") As Integer
        Dim intRet As Integer     ' �ėp�ߒl
        Dim strErrMsg As String
        Dim i As Integer
        Dim oCmd As OracleCommand = Nothing

        intRet = -1
        If asSQL <> "" Then
            mstrSQL = asSQL
        End If
        '--------------------------------------------------------------------
        ' SQL���s
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB�ؒf�ʒm�����
                        Throw New SystemException("DB�Đڑ��Ɏ��s���܂���")
                    End If
                End If
                oCmd = New OracleCommand(mstrSQL, mobjOraCon)
                oCmd.BindByName = True

                '====================================================================
                ' �޲��ޕϐ���ď���
                '====================================================================
                If IsNothing(mBndObj) = False Then
                    '(�޲��ޕϐ���ėp��޼ު�Ă�����ꍇ)

                    '--------------------------------------------------------------------
                    ' �޲��ޕϐ����
                    '--------------------------------------------------------------------
                    For intii As Integer = 0 To UBound(mBndObj, 2)
                        '(�޲��ޕϐ��ɒl���)
                        oCmd.Parameters.Add(mBndObj(0, intii), mBndObj(1, intii))
                    Next

                    mBndObj = Nothing           'mBndObj��nothing��ݒ�

                End If

                intRet = oCmd.ExecuteNonQuery()

                oCmd.Dispose()
                oCmd = Nothing

                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message

                If IsNothing(oCmd) = False Then
                    oCmd.Dispose()
                    oCmd = Nothing
                End If

                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '�ǉ��@Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    'mobjOraCon = Nothing
                    '' ''Disconnect()                    '�폜�@Rev 0.03
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return intRet

    End Function
#End Region

#Region "  GetCount"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����R�[�h�Z�b�g�̌����̎擾
    ''' </summary>
    ''' <param name="asSQL"></param>
    ''' <returns>���펞 ���R�[�h���� / �ُ펞 -1</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetCount( _
        Optional ByVal asSQL As String = "" _
    ) As Integer
        Dim intCount As Integer
        Dim strErrMsg As String
        Dim i As Integer
        Dim oCmd As OracleCommand = Nothing

        intCount = -1
        '--------------------------------------------------------------------
        ' �����擾
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB�ؒf�ʒm�����
                        Throw New SystemException("DB�Đڑ��Ɏ��s���܂���")
                    End If
                End If
                If IsNothing(mobjRdr) = False Then
                    mobjRdr.Close()
                    mobjRdr.Dispose()
                    mobjRdr = Nothing
                End If

                oCmd = New OracleCommand(asSQL, mobjOraCon)
                oCmd.BindByName = True

                '====================================================================
                ' �޲��ޕϐ���ď���
                '====================================================================
                If IsNothing(mBndObj) = False Then
                    '(�޲��ޕϐ���ėp��޼ު�Ă�����ꍇ)

                    '--------------------------------------------------------------------
                    ' �޲��ޕϐ����
                    '--------------------------------------------------------------------
                    For intii As Integer = 0 To UBound(mBndObj, 2)
                        '(�޲��ޕϐ��ɒl���)
                        oCmd.Parameters.Add(mBndObj(0, intii), mBndObj(1, intii))
                    Next

                    mBndObj = Nothing           'mBndObj��nothing��ݒ�

                End If


                mobjRdr = oCmd.ExecuteReader()
                While mobjRdr.Read()
                    intCount = CInt(mobjRdr.GetValue(0))
                End While
                mobjRdr.Close()
                mobjRdr.Dispose()
                mobjRdr = Nothing

                oCmd.Dispose()
                oCmd = Nothing

                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message

                If IsNothing(mobjRdr) = False Then
                    mobjRdr.Close()
                    mobjRdr.Dispose()
                    mobjRdr = Nothing
                End If
                If IsNothing(oCmd) = False Then
                    oCmd.Dispose()
                    oCmd = Nothing
                End If

                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '�ǉ��@Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    'mobjOraCon = Nothing
                    '' ''Disconnect()                    '�폜�@Rev 0.03
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return intCount

    End Function
#End Region

#Region "  GetFieldCount"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����R�[�h�Z�b�g�̃t�B�[���h���̎擾
    ''' </summary>
    ''' <returns>���펞 �t�B�[���h�� / �ُ펞 -1</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetFieldCount() As Long
        Dim lCount As Long
        Dim strErrMsg As String

        lCount = -1
        '--------------------------------------------------------------------
        ' �t�B�[���h���擾
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        Try
            lCount = mobjRdr.FieldCount
        Catch ex As OracleException
            strErrMsg = ex.Message
            Call SetExceptionData(ex.Message, ex.Number)
            Throw ex
        End Try

        Return lCount

    End Function
#End Region

#Region "  BeginTrans"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �g�����U�N�V�����J�n����
    ''' </summary>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function BeginTrans() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer

        blnRet = False
        '--------------------------------------------------------------------
        ' �g�����U�N�V�����J�n
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB�ؒf�ʒm�����
                        Throw New SystemException("DB�Đڑ��Ɏ��s���܂���")
                    End If
                End If

                If IsNothing(mobjTrans) = False Then
                    mobjTrans.Dispose()
                    mobjTrans = Nothing
                End If
                mobjTrans = mobjOraCon.BeginTransaction()

                blnRet = True
                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message
                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '�ǉ��@Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    '' ''Disconnect()                    '�폜�@Rev 0.03
                    'mobjOraCon = Nothing
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet

    End Function
#End Region

#Region "  Commit"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �R�~�b�g����
    ''' </summary>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Commit() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer

        blnRet = False
        '--------------------------------------------------------------------
        ' �R�~�b�g���s
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB�ؒf�ʒm�����
                        Throw New SystemException("DB�Đڑ��Ɏ��s���܂���")
                    End If
                Else
                    If IsNothing(mobjTrans) = False Then
                        If IsNothing(mobjTrans.Connection) = False Then
                            mobjTrans.Commit()
                            mobjTrans.Dispose()
                            mobjTrans = Nothing
                            blnRet = True
                        Else
                            mobjTrans.Dispose()
                            mobjTrans = Nothing
                        End If
                    End If
                End If

                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message
                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '�ǉ��@Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    '' ''Disconnect()                    '�폜�@Rev 0.03
                    'mobjOraCon = Nothing
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet

    End Function
#End Region

#Region "  RollBack"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���[���o�b�N����
    ''' </summary>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function RollBack() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer

        blnRet = False
        '--------------------------------------------------------------------
        ' ���[���o�b�N���s
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB�ؒf�ʒm�����
                        Throw New SystemException("DB�Đڑ��Ɏ��s���܂���")
                    End If
                Else
                    If IsNothing(mobjTrans) = False Then
                        If IsNothing(mobjTrans.Connection) = False Then
                            mobjTrans.Rollback()
                            mobjTrans.Dispose()
                            mobjTrans = Nothing
                            blnRet = True
                        Else
                            mobjTrans.Dispose()
                            mobjTrans = Nothing
                        End If
                    End If
                End If

                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message
                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '�ǉ��@Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    '' ''Disconnect()                    '�폜�@Rev 0.03
                    'mobjOraCon = Nothing
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet

    End Function
#End Region

#Region "  ConnenctSrv"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �f�[�^�x�[�X�ɐڑ�
    ''' </summary>
    ''' <returns>���펞 true / �ُ펞 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ConnenctSrv() As Boolean
        Dim requestInitialOwnership As Boolean = True
        Dim mutexWasCreated As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer
        Dim blnExit As Boolean

        blnRet = True
        '�r������
        Dim objMtx As New Mutex(requestInitialOwnership, "mConnenctSrv", mutexWasCreated)

        '�r���҂�����
        If Not (requestInitialOwnership And mutexWasCreated) Then
            objMtx.WaitOne()
        End If
        Try
            '--------------------------------------------------------------------
            ' �f�[�^�x�[�X�ɐڑ�
            '--------------------------------------------------------------------
            Call ClearExceptionData()
            blnExit = False
            Do While blnExit = False
                Try
                    '�ڑ�����
                    If IsNothing(mobjOraCon) = True Then
                        mobjOraCon = New OracleConnection
                        mobjOraCon.ConnectionString = mstrConnectString
                        mobjOraCon.Open()
                        blnExit = True
                    End If
                Catch ex As OracleException
                    strErrMsg = ex.Message
                    Call SetExceptionData(ex.Message, ex.Number)
                    Disconnect()                    '�ǉ��@Rev 0.03
                    If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                        '' ''Disconnect()                    '�폜�@Rev 0.03
                        Thread.Sleep(SLEEP_TIME)
                    Else
                        Disconnect()
                        blnRet = False
                    End If
                End Try
            Loop

        Finally
            '�r�������J��
            objMtx.ReleaseMutex()
        End Try

        Return blnRet

    End Function
#End Region

#Region "  AddToLog"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���O�������ݏ���
    ''' </summary>
    ''' <param name="buf"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal buf As String)

        If IsNothing(Owner) = False Then
            Owner.AddToLog(buf)
        End If

    End Sub
#End Region

#Region "  SetExceptionData"
    Protected Sub SetExceptionData( _
        ByVal strMsg As String, _
        ByVal intCode As Integer)

        mstrErrMsg = strMsg
        mintErrCode = intCode
    End Sub
#End Region

#Region "  ClearExceptionData"
    Protected Sub ClearExceptionData()
        mstrErrMsg = ""
        mintErrCode = 0
    End Sub
#End Region

#Region "  IsRetry"
    Protected Function IsRetry( _
        ByVal intErrCode As Integer) As Boolean

        Dim blnRet As Boolean

        blnRet = True
        Select Case intErrCode
            Case RetryErrCode.ErrCode01033
            Case RetryErrCode.ErrCode01034
            Case RetryErrCode.ErrCode01089
            Case RetryErrCode.ErrCode03001
            Case RetryErrCode.ErrCode03113
            Case RetryErrCode.ErrCode03114
            Case RetryErrCode.ErrCode12203
            Case RetryErrCode.ErrCode12500
            Case RetryErrCode.ErrCode12537
            Case RetryErrCode.ErrCode12545
            Case RetryErrCode.ErrCode12560
            Case RetryErrCode.ErrCode12571
            Case Else
                blnRet = False
        End Select
        Return (blnRet)
    End Function
#End Region

#Region "  SearchFieldIndex"
    Private Function SearchFieldIndex(ByVal strIndex As String) As Integer
        Dim intCount As Integer
        Dim intIndex As Integer

        intIndex = -1
        If mobjFieldName.Count > 0 Then
            For intCount = 0 To mobjFieldName.Count - 1
                If StrComp(mobjFieldName.Item(intCount), strIndex, CompareMethod.Text) = 0 Then
                    intIndex = intCount
                    Exit For
                End If
            Next
        End If

        Return (intIndex)

    End Function
#End Region


    '**********************************************************************************************
    '���������ьŗL

    '         �@�@2010/05/27  SIT J.Kato
    '           �@PL/SQĻݸ��݂�Call����ҿ��ނ�ǉ�
#Region "  StoredFunctionExeute"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' PL/SQĻݸ���Callҿ���
    ''' </summary>
    ''' <param name="strFuncionName"></param>
    ''' <param name="udtParamater"></param>
    ''' <param name="strFunctionReturn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function StoredFunctionExeute(ByVal strFuncionName As String, _
                                         ByRef udtParamater() As OraParam, _
                                         ByRef strFunctionReturn As Integer _
                                        ) As Boolean

        Dim blnRet As Boolean = True

        '=============================================
        '�׸ٺ���޵�޼ު�č쐬
        '=============================================
        Dim objCommand As New OracleCommand(strFuncionName, mobjOraCon)
        objCommand.CommandType = CommandType.StoredProcedure

        '=============================================
        '���Ұ��ر
        '=============================================
        objCommand.Parameters.Clear()

        '=============================================
        '̧ݸ���Return���Ұ����
        '=============================================
        Dim objReturnPram As OracleParameter
        objReturnPram = New OracleParameter("Ret", OracleDbType.Int32, ParameterDirection.ReturnValue)
        objCommand.Parameters.Add(objReturnPram)

        Dim objParamType As OracleDbType = Nothing

        If IsNothing(udtParamater) <> True Then
            '(���Ұ�����Ă���Ă���ꍇ)
            For ii As Integer = 0 To UBound(udtParamater)

                '=============================================
                '̧ݸ��݈����ݒ�
                '=============================================

                Select Case udtParamater(ii).DbType
                    Case OraDBType.Type_NVarchar2
                        objParamType = OracleDbType.NVarchar2
                    Case OraDBType.Type_Int32
                        objParamType = OracleDbType.Int32
                    Case OraDBType.Type_Decimal
                        objParamType = OracleDbType.Decimal
                    Case OraDBType.Type_Date
                        objParamType = OracleDbType.Date
                End Select

                '���Ұ��ǉ�
                objCommand.Parameters.Add(udtParamater(ii).Name, _
                                          objParamType, _
                                          udtParamater(ii).Size, _
                                          udtParamater(ii).Value, _
                                          udtParamater(ii).Direction)

                ' ''���Ұ��ǉ�
                ''objCommand.Parameters.Add(udtParamater(ii).Name, _
                ''                          udtParamater(ii).DbType, _
                ''                          udtParamater(ii).Value, _
                ''                          udtParamater(ii).Direction)
            Next
        End If

        '=============================================
        '�ı��̧ݸ��݂̎��s
        '=============================================
        Call objCommand.ExecuteNonQuery()

        '=============================================
        '�擾���Ұ����
        '=============================================
        If IsNothing(udtParamater) <> True Then
            For ii As Integer = 0 To UBound(udtParamater)
                If udtParamater(ii).Direction = ParameterDirection.InputOutput Or _
                   udtParamater(ii).Direction = ParameterDirection.Output Then
                    '(�߂�l����������ꍇ)
                    Dim objData As Object
                    objData = Nothing
                    Select Case objCommand.Parameters(udtParamater(ii).Name).DbType
                        Case DbType.String
                            objData = objCommand.Parameters(udtParamater(ii).Name).Value.ToString
                        Case DbType.Int16, DbType.Int32, DbType.Int64
                            objData = CInt(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Date
                            objData = CDate(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Decimal
                            objData = CDec(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Double
                            objData = CDbl(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                    End Select

                    udtParamater(ii).Value = objData
                End If
            Next
        End If

        '=============================================
        '�׸�Return���
        '=============================================
        strFunctionReturn = CInt(objCommand.Parameters("Ret").Value.ToString)


        Return blnRet

    End Function
#End Region

    '         �@�@2010/05/27  SIT J.Kato
    '           �@PL/SQL��ۼ��ެ��Call����ҿ��ނ�ǉ�
#Region "  StoredProcedureExeute"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' PL/SQL��ۼ��ެCallҿ���
    ''' </summary>
    ''' <param name="strFuncionName"></param>
    ''' <param name="udtParamater"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function StoredProcedureExeute(ByVal strFuncionName As String, _
                                          ByRef udtParamater() As OraParam _
                                         ) As Boolean

        Dim blnRet As Boolean = True

        '=============================================
        '�׸ٺ���޵�޼ު�č쐬
        '=============================================
        Dim objCommand As New OracleCommand(strFuncionName, mobjOraCon)
        objCommand.CommandType = CommandType.StoredProcedure

        '=============================================
        '���Ұ��ر
        '=============================================
        objCommand.Parameters.Clear()

        Dim objParamType As OracleDbType = Nothing

        If IsNothing(udtParamater) <> True Then
            '(���Ұ�����Ă���Ă���ꍇ)
            For ii As Integer = 0 To UBound(udtParamater)

                Select Case udtParamater(ii).DbType
                    Case OraDBType.Type_NVarchar2
                        objParamType = OracleDbType.NVarchar2
                    Case OraDBType.Type_Int32
                        objParamType = OracleDbType.Int32
                    Case OraDBType.Type_Decimal
                        objParamType = OracleDbType.Decimal
                    Case OraDBType.Type_Date
                        objParamType = OracleDbType.Date
                End Select

                '=============================================
                '̧ݸ��݈����ݒ�
                '=============================================
                '���Ұ��ǉ�
                objCommand.Parameters.Add(udtParamater(ii).Name, _
                                          objParamType, _
                                          udtParamater(ii).Size, _
                                          udtParamater(ii).Value, _
                                          udtParamater(ii).Direction)

                ' ''=============================================
                ' ''̧ݸ��݈����ݒ�
                ' ''=============================================
                ' ''���Ұ��ǉ�
                ''objCommand.Parameters.Add(udtParamater(ii).Name, _
                ''                          udtParamater(ii).DbType, _
                ''                          udtParamater(ii).Value, _
                ''                          udtParamater(ii).Direction)
            Next
        End If

        '=============================================
        '�ı��̧ݸ��݂̎��s
        '=============================================
        Call objCommand.ExecuteNonQuery()

        '=============================================
        '�擾���Ұ����
        '=============================================
        If IsNothing(udtParamater) <> True Then
            For ii As Integer = 0 To UBound(udtParamater)
                If udtParamater(ii).Direction = ParameterDirection.InputOutput Or _
                   udtParamater(ii).Direction = ParameterDirection.Output Then
                    '(�߂�l����������ꍇ)
                    Dim objData As Object
                    objData = Nothing
                    Select Case objCommand.Parameters(udtParamater(ii).Name).DbType
                        Case DbType.String
                            objData = objCommand.Parameters(udtParamater(ii).Name).Value.ToString
                        Case DbType.Int16, DbType.Int32, DbType.Int64
                            objData = CInt(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Date
                            objData = CDate(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Decimal
                            objData = CDec(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Double
                            objData = CDbl(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                    End Select

                    udtParamater(ii).Value = objData
                End If
            Next
        End If

        Return blnRet

    End Function
#End Region

#Region "�@OraParam(̧ݸ���/��ۼ��ެ����)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̧ݸ��݁E��ۼ��ެ���Ұ�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Structure OraParam
        Dim Name As String
        Dim DbType As OraDBType
        Dim Size As Integer
        Dim Value As Object
        Dim Direction As ParameterDirection
    End Structure
#End Region

#Region "�@OracleDBType(OraPram�p)"

    Public Enum OraDBType
        Type_Int32 = OracleDbType.Int32
        Type_NVarchar2 = OracleDbType.NVarchar2
        Type_Decimal = OracleDbType.Decimal
        Type_Date = OracleDbType.Date
    End Enum

#End Region

    '���������ьŗL
    '**********************************************************************************************

End Class
