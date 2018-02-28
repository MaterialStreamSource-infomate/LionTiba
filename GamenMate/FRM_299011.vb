'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zSQL�����s���
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports JobCommon
#End Region

Public Class FRM_299011

#Region "�@���ʕϐ��@                               "

    '================================================
    '�ϐ�
    '================================================
    '��ʻ��ޕύX�p
    Private mobjDb As clsConn                       'DB�ڑ�
    Private mobjFRM_299010 As FRM_299010            'DB����ݽ°�

    '��ʻ��ޕύX�p
    Private mintDifftxtSQLX As Integer              'SQL÷���ޯ��X������
    Private mintDifftxtSQLY As Integer              'SQL÷���ޯ��Y������

    '================================================
    '�萔
    '================================================
    'ү����
    Private Const MSG001 As String = "�ް����擾���܂��B��낵���ł����H"
    Private Const MSG002 As String = "SQL�������s���܂��B��낵���ł����H"
    Private Const MSG003 As String = "����ں��ނ����s����܂����B"


#End Region
#Region "  �����è                                  "
    Public Property objFRM_299010() As FRM_299010
        Get
            Return mobjFRM_299010
        End Get
        Set(ByVal Value As FRM_299010)
            mobjFRM_299010 = Value
        End Set
    End Property
    Public Property objDb() As clsConn
        Get
            Return mobjDb
        End Get
        Set(ByVal Value As clsConn)
            mobjDb = Value
        End Set
    End Property
#End Region
#Region "  �����                                    "
#Region "  ̫��۰��"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call FormLoad()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ̫�ѻ��ޕύX"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѻ��ޕύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299011_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            Call FormSizeChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �擾���ݸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �擾���ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdGetDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetDisp.Click
        Try
            Call cmdGetDispProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �X�V���ݸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �X�V���ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExecute.Click
        Try
            Call cmdExecuteProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    '�ƭ�
#Region "  Select���د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Select���د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSelect.Click
        Try
            Call tsmSelectClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Update���د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Update���د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmUpdate.Click
        Try
            Call tsmUpdateClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Insert���د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Insert���د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInsert.Click
        Try
            Call tsmInsertClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Delete���د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Delete���د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDelete.Click
        Try
            Call tsmDeleteClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �擾�د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �擾�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmGetDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmGetDisp.Click
        Try
            Call tsmGetDispClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �X�V�د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �X�V�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExecute.Click
        Try
            Call tsmExecuteClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region

    '����ď���
#Region "  ̫��۰�ޏ���                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()


        '********************************************************************
        '�F�X������
        '********************************************************************
        mintDifftxtSQLX = Me.Size.Width - txtSQL.Size.Width         'ð����ް���د��X������
        mintDifftxtSQLY = Me.Size.Height - txtSQL.Size.Height       'ð����ް���د��Y������


    End Sub
#End Region
#Region "  ̫�ѻ��ޕύX����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѻ��ޕύX����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormSizeChangedProcess()


        If mintDifftxtSQLX <> 0 Then


            '********************************************************************
            'ð����ް���د�ޒ���
            '********************************************************************
            Dim inttxtSQLSizeX As Integer = Me.Size.Width - mintDifftxtSQLX
            Dim inttxtSQLSizeY As Integer = Me.Size.Height - mintDifftxtSQLY
            txtSQL.Size = New System.Drawing.Size(inttxtSQLSizeX, inttxtSQLSizeY)


        End If


    End Sub
#End Region
#Region "  �擾���ݸد�����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �擾���ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdGetDispProcess()
        Dim strSQL As String                    'SQL��
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�


        '********************************************************************
        '�m�F���
        '********************************************************************
        If MsgBox(MSG001, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        '��د�ޕ\��
        '********************************************************************
        strSQL = txtSQL.Text
        mobjDb.SQL = strSQL
        strDataSetName = "TABLE"
        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)
        mobjFRM_299010.grdTableData.DataSource = objDataSet.Tables(strDataSetName)


    End Sub
#End Region
#Region "  �X�V���ݸد�����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �X�V���ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdExecuteProcess()
        Dim strSQL As String                    'SQL��
        Dim intRetSQL As Integer                'SQL���s�߂�l
        Dim strMsg As String                    'ү����


        '********************************************************************
        '�m�F���
        '********************************************************************
        If MsgBox(MSG002, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        '�ް��X�V
        '********************************************************************
        strSQL = txtSQL.Text
        intRetSQL = mobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_ADD & mobjDb.ErrMsg & "�y" & strSQL & "�z"
            Throw New Exception(strMsg)
        ElseIf intRetSQL = 0 Then
            strMsg = "�Ώ�ں��ނ����݂��܂���B" & "�y" & strSQL & "�z"
            Throw New Exception(strMsg)
        Else
            MsgBox(CStr(intRetSQL) & MSG003)
        End If


        '********************************************************************
        '��د�ޕ\��
        '********************************************************************
        Call cmdGetDispProcess()


    End Sub
#End Region
    '�ƭ�
#Region "  Select���د�����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  Select���د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSelectClickProcess()
        Dim strTableName As String = mobjFRM_299010.cboTableName.SelectedValue


        '********************************************************************
        'SQL���񖼕����쐬
        '********************************************************************
        Dim strSQLColumnData As String = ""                    'SQL��
        Call mobjFRM_299010.MakeSQLColumnData(strSQLColumnData, 5)


        '********************************************************************
        'SQL��Where�啔���쐬
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL��
        Call mobjFRM_299010.MakeSQLWhere(strSQLWhere, 5)


        '********************************************************************
        'SQL���쐬
        '********************************************************************
        Dim strSQL As String                    'SQL��
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf
        txtSQL.Text &= strSQL


    End Sub
#End Region
#Region "  Update���د�����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Update���د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmUpdateClickProcess()
        Dim strTableName As String = mobjFRM_299010.cboTableName.SelectedValue


        '********************************************************************
        'SQL���񖼕����쐬
        '********************************************************************
        Dim strSQLSet As String = ""            'SQL��
        Call mobjFRM_299010.MakeSQLSet(strSQLSet, 5)


        '********************************************************************
        'SQL��Where�啔���쐬
        '********************************************************************
        Dim strSQLWhere As String = ""          'SQL��
        Call mobjFRM_299010.MakeSQLWhere(strSQLWhere, 5)


        '********************************************************************
        'SQL���쐬
        '********************************************************************
        Dim strSQL As String                    'SQL��
        strSQL = ""
        strSQL &= vbCrLf & " UPDATE "
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & " SET "
        strSQL &= vbCrLf & strSQLSet
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        txtSQL.Text &= strSQL


    End Sub
#End Region
#Region "  Insert���د�����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Insert���د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmInsertClickProcess()
        Dim strTableName As String = mobjFRM_299010.cboTableName.SelectedValue


        '********************************************************************
        'SQL���񖼕����쐬
        '********************************************************************
        Dim strSQLColumnData As String = ""                    'SQL��
        Call mobjFRM_299010.MakeSQLColumnData(strSQLColumnData, 5)


        '********************************************************************
        'SQL���񖼕����쐬
        '********************************************************************
        Dim strSQLValue As String = ""          'SQL��
        Call mobjFRM_299010.MakeSQLValue(strSQLValue, 5)


        '********************************************************************
        'SQL���쐬
        '********************************************************************
        Dim strSQL As String                    'SQL��
        strSQL = ""
        strSQL &= vbCrLf & " INSERT INTO "
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & "    )"
        strSQL &= vbCrLf & "    VALUES"
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & strSQLValue
        strSQL &= vbCrLf & "    )"
        strSQL &= vbCrLf
        txtSQL.Text &= strSQL


    End Sub
#End Region
#Region "  Delete���د�����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Delete���د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDeleteClickProcess()
        Dim strTableName As String = mobjFRM_299010.cboTableName.SelectedValue


        '********************************************************************
        'SQL��Where�啔���쐬
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL��
        Call mobjFRM_299010.MakeSQLWhere(strSQLWhere, 5)


        '********************************************************************
        'SQL���쐬
        '********************************************************************
        Dim strSQL As String                    'SQL��
        strSQL = ""
        strSQL &= vbCrLf & " DELETE "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        txtSQL.Text &= strSQL


    End Sub
#End Region
#Region "  �擾�د�����                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �擾�د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmGetDispClickProcess()


        '********************************************************************
        '�擾����
        '********************************************************************
        Call cmdGetDispProcess()


    End Sub
#End Region
#Region "  �X�V�د�����                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �X�V�د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmExecuteClickProcess()


        '********************************************************************
        '�X�V����
        '********************************************************************
        Call cmdExecuteProcess()


    End Sub
#End Region
    '�����֐�
#Region "�@�װ����                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="objException">����߼��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try
            Call gobjComFuncFRM.ComError_frm(objException)
        Catch ex As Exception

        End Try
    End Sub
#End Region


End Class