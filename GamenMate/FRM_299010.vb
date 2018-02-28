'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zDB����ݽ°�
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports JobCommon
#End Region

Public Class FRM_299010

#Region "�@���ʕϐ��@                               "

    '================================================
    '�ϐ�
    '================================================
    '�׽
    Private mobjDb As clsConn                           'DB�ڑ�
    Private Shared mobjInstanceFRM_299011 As FRM_299011 'SQL�����s���

    'ð����ް��ύX����ėp
    Private mintCurrentCellRow As Integer           '���ݑI���s�ʒu
    Private mintCurrentCellCol As Integer           '���ݑI���ʒu
    Private mintBeforeCellRow As Integer            '�O��I���s�ʒu
    Private mintBeforeCellCol As Integer            '�O��I���ʒu
    Private mblnCellValueChange As Boolean          '�ْl�ύX�׸�
    Private mblnRowInsert As Boolean                '�s�ǉ��׸�

    '��ʻ��ޕύX�p
    Private mintDiffgrdColumnDataX As Integer       '���ް���د��X������
    Private mintDiffgrdColumnDataY As Integer       '���ް���د��Y������
    Private mintDiffgrdTableDataX As Integer        'ð����ް���د��X������
    Private mintDiffgrdTableDataY As Integer        'ð����ް���د��Y������
    Private mintgrdColumnDataWidth As Integer       '���ް���د�ޏ�����
    Private mintgrdTableDataWidth As Integer        'ð����ް���د�ޏ�����

    '��ݻ޸��ݗp
    Private Const TRANS_NOTRANS As String = "�����ЯĒ�"
    Private Const TRANS_BEGINTRANS As String = "��ݻ޸���" & vbCrLf & "�J�n��"
    Private TRANS_COLOR_NOTRANS As Color = Color.Red                '�����ЯĒ�
    Private TRANS_COLOR_BEGINTRANS As Color = Color.LightBlue       '��ݻ޸��݊J�n��

    '���̑�
    Private mblnFormLoad As Boolean                     '̫��۰�ޒ��׸�
    Private Const CBOTABLENAME_LENGTH As Integer = 20   'ð��ٖ��̒���

    '================================================
    '�萔
    '================================================
    '�ް�����
    Private Const COL_DATA_TYPE_VARCHAR2 As String = "VARCHAR2"
    Private Const COL_DATA_TYPE_NUMBER As String = "NUMBER"
    Private Const COL_DATA_TYPE_DATE As String = "DATE"

    'ү����
    Private Const MSG001 As String = "�I������ں��ނ�ǉ����Ă���낵���ł����H"
    Private Const MSG002 As String = "�I������ں��ނ��X�V���Ă���낵���ł����H"
    Private Const MSG003 As String = "�I������ں��ނ��폜���Ă���낵���ł����H"
    Private Const MSG011 As String = "ں��ނ��ǉ�����܂����B�ǉ������s���Ă���낵���ł����H"
    Private Const MSG012 As String = "ں��ނ��X�V����܂����B�X�V�����s���Ă���낵���ł����H"
    Private Const MSG013 As String = "ں��ނ��폜����܂����B�폜�����s���Ă���낵���ł����H"
    Private Const MSG101 As String = "��ݻ޸��݂��J�n���Ă���낵���ł����H"
    Private Const MSG102 As String = "۰��ޯ����Ă���낵���ł����H"
    Private Const MSG103 As String = "�ЯĂ��Ă���낵���ł����H"

    '���̑�
    Private Const CONSTRAINT_TYPE_PK As String = "P"    '��ײ�ذ������
    Private Const GRID_MAXCOUNT As Integer = 10000      '��د�ޕ\������(����ȏ��ں��ނ�\������ꍇ��ү�����ޯ�����o�͂���)
    Private Const SQL_COMMENT_POSITION As Integer = 35          'SQL�����ĊJ�n�ʒu
    Private Const SQL_USER_INPUT_PLACE As String = "@@@@"       'հ�ް��`����


    '================================================
    '�񋓑�
    '================================================
    ''' <summary>�����ް���د�ލ���</summary>
    Enum menmListCol
        COLUMN_NAME         '��
        DATA_TYPE           '����
        COMMENTS            '����
        PK                  '��ײ�ذ��
        Data04              '�ް�4(��)
        Data05              '�ް�5(��)
    End Enum

#End Region
#Region "  �����è                                  "
    '********************************************************************
    '�������̫�тɱ�������ׂ������è
    '********************************************************************
    Private Shared ReadOnly Property objFRM_299011() As FRM_299011
        Get
            '̫�т�null�܂��͔j������Ă���Ƃ��́A�V�����ݽ�ݽ���쐬����
            If mobjInstanceFRM_299011 Is Nothing OrElse mobjInstanceFRM_299011.IsDisposed Then
                mobjInstanceFRM_299011 = New FRM_299011
            End If
            Return mobjInstanceFRM_299011
        End Get
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
    Private Sub FRM_299010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mblnFormLoad = True     '̫��۰�ޒ��׸�
        Try
            Call FormLoad()
        Catch ex As Exception
            ComError(ex)
        Finally
            mblnFormLoad = False    '̫��۰�ޒ��׸�
        End Try
    End Sub
#End Region
#Region "  �\�����ݸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\�����ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisp.Click
        Try
            Call cmdDispProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �����ݸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Try
            Call cmdPrintProcess()
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
    Private Sub FRM_299010_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            Call FormSizeChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ���ް��\�������ޯ���ύX"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ް��\�������ޯ���ύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub chkgrdColumnDataVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkgrdColumnDataVisible.CheckedChanged
        Try
            Call chkgrdColumnDataVisibleCheckedChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ð��ّI������ޯ���ύX"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ð��ّI������ޯ���ύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboTableName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTableName.SelectedIndexChanged
        Try
            Call cboTableName_SelectedIndexChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    '�ƭ�
#Region "  SQL�����s��ʸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL�����s��ʸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSQL.Click
        Try
            Call tsmSQLClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �ް��X�V�د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް��X�V�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDataUpdate_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmDataUpdate.DropDownOpened
        Try
            Call tsmDataUpdateDropDownOpenedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Select�د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Select�د�
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
#Region "  Insert�د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Insert�د�
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
#Region "  Update�د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Update�د�
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
#Region "  Delete�د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Delete�د�
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
#Region "  ��ݻ޸��݊J�n�د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ݻ޸��݊J�n�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmBeginTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBeginTrans.Click
        Try
            Call tsmBeginTransClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ۰��ޯ��د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۰��ޯ��د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmRollBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmRollBack.Click
        Try
            Call tsmRollBackClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �Яĸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �Яĸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCommit.Click
        Try
            Call tsmCommitClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    '�ް���د�޲����
#Region "  �ް���د�ޑI��ύX�����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޑI��ύX�����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTableData.SelectionChanged
        Try
            Call grdTableDataSelectionChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �ް���د�ޕҏW�I�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޕҏW�I�������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_CellParsing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs) Handles grdTableData.CellParsing
        Try
            Call grdTableDataCellParsingProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �ް���د�ސV�����s�ǉ������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ސV�����s�ǉ������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdTableData.UserAddedRow
        Try
            Call grdTableDataUserAddedRowProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �ް���د�ލs�폜�����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ލs�폜���O
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdTableData.UserDeletingRow
        Try
            Call grdTableDataUserDeletingRowProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ލs�폜����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdTableData.UserDeletedRow
        Try
            Call cmdDispProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region

    '�O�����J�֐�
#Region "�@SQL���p������擾                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL���p������擾
    ''' </summary>
    ''' <param name="strData">�ް�</param>
    ''' <param name="strDataType">�ް�����</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetStringSQLData(ByVal strData As String _
                                   , ByVal strDataType As String _
                                    ) As String
        Dim strReturn As String     '�߂�l


        Select Case strDataType
            Case COL_DATA_TYPE_VARCHAR2
                '(�����^�̏ꍇ)
                strReturn = "'" & strData & "'"
            Case COL_DATA_TYPE_NUMBER
                '(���l�^�̏ꍇ)
                strReturn = strData
            Case COL_DATA_TYPE_DATE
                '(���t�^�̏ꍇ)
                strReturn = "TO_DATE('" & strData & "','YYYY/MM/DD HH24:MI:SS')"
            Case Else
                Throw New Exception("�s���Ȍ^�����o���܂����B")
        End Select


        Return (strReturn)
    End Function
#End Region
#Region "�@SQL�� �񖼕����쐬                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL�� �񖼕����쐬
    ''' </summary>
    ''' <param name="strSQL">�쐬�����SQL��</param>
    ''' <param name="intSpace">���ɕt�������߰��̐�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeSQLColumnData(ByRef strSQL As String _
                               , ByVal intSpace As Integer _
                                )


        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)


            '********************************************************************
            '��s�����쐬
            '********************************************************************
            Dim strTemp As String = ""
            strTemp &= Space(intSpace) & ","
            strTemp &= grdColumnData.Item(FRM_299010.menmListCol.COLUMN_NAME, ii).Value
            If GET_BYTE_LENGTH_STRING(strTemp) <= SQL_COMMENT_POSITION Then
                strTemp = SPC_PAD(strTemp, SQL_COMMENT_POSITION)    '��߰��l��
            End If
            strTemp &= " --" & grdColumnData.Item(FRM_299010.menmListCol.COMMENTS, ii).Value     '����


            '********************************************************************
            '�S�̂ƌ���
            '********************************************************************
            strSQL &= vbCrLf & strTemp


            '********************************************************************
            '�s�v�����폜
            '********************************************************************
            If ii = 0 Then
                strSQL = Replace(strSQL, vbCrLf, "", 1, 1)
                strSQL = Replace(strSQL, ",", " ", 1, 1)
            End If


        Next


    End Sub
#End Region
#Region "�@SQL�� Where�啔���쐬                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL�� Where�啔���쐬
    ''' </summary>
    ''' <param name="strSQL">�쐬�����SQL��</param>
    ''' <param name="intSpace">���ɕt�������߰��̐�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeSQLWhere(ByRef strSQL As String _
                          , ByVal intSpace As Integer _
                            )


        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)


            '********************************************************************
            '��s�����쐬
            '********************************************************************
            Dim strTemp As String = ""
            strTemp &= Space(intSpace) & "AND "
            strTemp &= grdColumnData.Item(FRM_299010.menmListCol.COLUMN_NAME, ii).Value
            strTemp &= " = "
            strTemp &= GetStringSQLData(SQL_USER_INPUT_PLACE, grdColumnData.Item(FRM_299010.menmListCol.DATA_TYPE, ii).Value)
            If GET_BYTE_LENGTH_STRING(strTemp) <= SQL_COMMENT_POSITION Then
                strTemp = SPC_PAD(strTemp, SQL_COMMENT_POSITION)    '��߰��l��
            End If
            strTemp &= " --" & grdColumnData.Item(FRM_299010.menmListCol.COMMENTS, ii).Value     '����


            '********************************************************************
            '�S�̂ƌ���
            '********************************************************************
            strSQL &= vbCrLf & strTemp


        Next


    End Sub
#End Region
#Region "�@SQL�� Set�啔���쐬                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL�� Set�啔���쐬
    ''' </summary>
    ''' <param name="strSQL">�쐬�����SQL��</param>
    ''' <param name="intSpace">���ɕt�������߰��̐�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeSQLSet(ByRef strSQL As String _
                        , ByVal intSpace As Integer _
                          )


        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)


            '********************************************************************
            '��s�����쐬
            '********************************************************************
            Dim strTemp As String = ""
            strTemp &= Space(intSpace) & ","
            strTemp &= grdColumnData.Item(FRM_299010.menmListCol.COLUMN_NAME, ii).Value
            strTemp &= " = "
            strTemp &= GetStringSQLData(SQL_USER_INPUT_PLACE, grdColumnData.Item(FRM_299010.menmListCol.DATA_TYPE, ii).Value)
            If GET_BYTE_LENGTH_STRING(strTemp) <= SQL_COMMENT_POSITION Then
                strTemp = SPC_PAD(strTemp, SQL_COMMENT_POSITION)    '��߰��l��
            End If
            strTemp &= " --" & grdColumnData.Item(FRM_299010.menmListCol.COMMENTS, ii).Value     '����


            '********************************************************************
            '�S�̂ƌ���
            '********************************************************************
            strSQL &= vbCrLf & strTemp


            '********************************************************************
            '�s�v�����폜
            '********************************************************************
            If ii = 0 Then
                strSQL = Replace(strSQL, vbCrLf, "")
                strSQL = Replace(strSQL, ",", " ")
            End If


        Next


    End Sub
#End Region
#Region "�@SQL�� �ް������쐬                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL�� �ް������쐬 
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="intSpace"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeSQLValue(ByRef strSQL As String _
                          , ByVal intSpace As Integer _
                            )


        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)


            '********************************************************************
            '��s�����쐬
            '********************************************************************
            Dim strTemp As String = ""
            strTemp &= Space(intSpace) & ","
            strTemp &= GetStringSQLData(SQL_USER_INPUT_PLACE, grdColumnData.Item(FRM_299010.menmListCol.DATA_TYPE, ii).Value)
            If GET_BYTE_LENGTH_STRING(strTemp) <= SQL_COMMENT_POSITION Then
                strTemp = SPC_PAD(strTemp, SQL_COMMENT_POSITION)    '��߰��l��
            End If
            strTemp &= " --" & grdColumnData.Item(FRM_299010.menmListCol.COMMENTS, ii).Value     '����


            '********************************************************************
            '�S�̂ƌ���
            '********************************************************************
            strSQL &= vbCrLf & strTemp


            '********************************************************************
            '�s�v�����폜
            '********************************************************************
            If ii = 0 Then
                strSQL = Replace(strSQL, vbCrLf, "")
                strSQL = Replace(strSQL, ",", " ")
            End If


        Next


    End Sub
#End Region


    '����ď���
#Region "     ̫��۰�ޏ���                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()
        Dim strSQL As String                    'SQL��
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�
        Dim aryData As ArrayList = New ArrayList


        '**************************************************************************
        ' �׸ِڑ�
        '**************************************************************************
        '==========================================
        'Config�擾
        '==========================================
        Dim objSystem As clsConnectConfig
        objSystem = New clsConnectConfig(CONFIG_FILE)                ' Confiģ�ِڑ��׽�i��ʗpConfig�j

        '==========================================
        'DB�ڑ�
        '==========================================
        mobjDb = gobjDb
        '' ''Dim blnRet As Boolean
        '' ''mobjDb = New clsConn
        '' ''mobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
        '' ''blnRet = mobjDb.Connect()     '�ڑ�
        '' ''If blnRet = False Then
        '' ''    Throw New Exception("DB�ڑ��Ɏ��s���܂����B")
        '' ''End If


        '********************************************************************
        '������
        '********************************************************************
        mblnCellValueChange = False         '�ْl�ύX�׸�
        mblnRowInsert = False               '�s�ǉ��׸�
        txtTitle.Text = "FRM_"

        '********************************************************************
        '�ް��擾
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    USER_TABLES.TABLE_NAME"
        strSQL &= vbCrLf & "   ,USER_TAB_COMMENTS.COMMENTS"
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    USER_TABLES"
        strSQL &= vbCrLf & "   ,USER_TAB_COMMENTS"
        strSQL &= vbCrLf & " WHERE  1 = 1"
        strSQL &= vbCrLf & "    AND USER_TABLES.TABLE_NAME = USER_TAB_COMMENTS.TABLE_NAME"
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "    USER_TABLES.TABLE_NAME"
        strSQL &= vbCrLf
        mobjDb.SQL = strSQL
        strDataSetName = "USER_TABLES"
        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(�ް����擾�o�����ꍇ)
            For ii As Integer = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                '(ٰ��:�擾�ް���)

                Dim strComboDisp As String = ""         '�����ޯ���\���p������
                Dim strTableName As String = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)("TABLE_NAME"))        'ð��ٖ�
                Dim strTableComment As String = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)("COMMENTS"))       'ð��ٖ�����
                strComboDisp &= SPC_PAD(strTableName, CBOTABLENAME_LENGTH)
                strComboDisp &= strTableComment
                aryData.Add(New GamenCommon.clsCboData(strComboDisp, strTableName))
            Next
        Else
            Throw New Exception("ð��ق�������܂���B")
        End If
        cboTableName.DisplayMember = GamenCommon.clsCboData.DISPLAYMEMBER
        cboTableName.ValueMember = GamenCommon.clsCboData.VALUEMEMBER
        cboTableName.DataSource = aryData
        cboTableName.SelectedIndex = 0


        '********************************************************************
        '��د�ލ������擾
        '********************************************************************
        mintDiffgrdColumnDataX = Me.Size.Width - grdColumnData.Location.X       '���ް���د��X������
        mintDiffgrdColumnDataY = Me.Size.Height - grdColumnData.Size.Height     '���ް���د��Y������
        mintDiffgrdTableDataX = Me.Size.Width - grdTableData.Size.Width         'ð����ް���د��X������
        mintDiffgrdTableDataY = Me.Size.Height - grdTableData.Size.Height       'ð����ް���د��Y������
        mintgrdColumnDataWidth = grdColumnData.Size.Width                       '���ް���د�ޏ�����
        mintgrdTableDataWidth = grdTableData.Size.Width                         'ð����ް���د�ޏ�����


        '********************************************************************
        '�F�X������
        '********************************************************************
        chkgrdColumnDataVisible.Checked = False                 '���ް��\�������ޯ��
        Call chkgrdColumnDataVisibleCheckedChangedProcess()     '���ް��\�������ޯ��
        Call tsmBeginTransClickProcess()                        '��ݻ޸��݊J�n


    End Sub
#End Region
#Region "  �\�����ݸد�����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\�����ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDispProcess()
        Dim strSQL As String                    'SQL��
        Dim objDataSet01 As New DataSet         '�ް����
        Dim objDataSet02 As New DataSet         '�ް����
        Dim objDataSetGrid As New DataSet       '�ް����(��د�ޕ\���p)
        Dim strDataSetName01 As String          '�ް���Ė�
        Dim strTableName As String = cboTableName.SelectedValue



        '********************************************************************
        '�ް������擾
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "    COUNT(*) "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf
        mobjDb.SQL = strSQL
        strDataSetName01 = "COUNT"
        objDataSet02.Clear()
        mobjDb.GetDataSet(strDataSetName01, objDataSet02)
        If objDataSet02.Tables(strDataSetName01).Rows.Count > 0 Then
            '(�ް����擾�o�����ꍇ)
            If GRID_MAXCOUNT < TO_INTEGER(objDataSet02.Tables(strDataSetName01).Rows(0)(0)) Then
                '(�ް����������������ꍇ)

                Dim strMsg As String = ""
                strMsg = "�ް�������" & GRID_MAXCOUNT & "���𒴂��Ă��܂��B"
                strMsg &= vbCrLf & "��د�ނɕ\�����悤�Ƃ���ƁA���Ɏ��Ԃ�������܂��B"
                strMsg &= vbCrLf & "���s���܂����H�B"
                If MsgBox(strMsg, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                    Throw New Exception("�ް��\����ݾق��܂����B")
                End If
            End If
        Else
            Throw New Exception("ð��ق��ް��������擾�o���܂���B")
        End If


        '********************************************************************
        '�ް���د�ޕ\��(���ް�)
        '********************************************************************
        Call grdColumnDataDisplay(strTableName)


        '********************************************************************
        'SQL���񖼕����쐬
        '********************************************************************
        Dim strSQLColumnData As String = ""                    'SQL��
        Call MakeSQLColumnData(strSQLColumnData, 5)


        '********************************************************************
        '�ް��擾(�ް��\���p)
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf
        mobjDb.SQL = strSQL
        strDataSetName01 = "TABLE"
        objDataSetGrid.Clear()
        mobjDb.GetDataSet(strDataSetName01, objDataSetGrid)
        grdTableData.DataSource = objDataSetGrid.Tables(strDataSetName01)


        '********************************************************************
        '��د�ޕ\���ݒ�
        '********************************************************************
        Call grdTableDataSetup()


    End Sub
#End Region
#Region "  �����ݸد�����                         "
    Private Sub cmdPrintProcess()


        '********************************************************************
        'ͯ�ް�����쐬
        '********************************************************************
        Dim strColTerminator As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_020)
        Dim strRowTerminator As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_021)
        Dim strTableName As String = ""     'ð��ٖ�
        Dim strText01 As String = ""        'ͯ�ް÷��01
        Dim strText05 As String = ""        'ͯ�ް÷��05
        Dim strText06 As String = ""        'ͯ�ް÷��06
        Dim strText07 As String = ""        'ͯ�ް÷��07
        Dim strHeader As String = ""        'ͯ�ް÷��

        '===================================
        'ͯ�ް÷�č쐬01
        '===================================
        strText01 = MID_SJIS(cboTableName.Text, CBOTABLENAME_LENGTH + 1)
        strTableName = MID_SJIS(cboTableName.Text, 1, CBOTABLENAME_LENGTH)
        strTableName = Trim(strTableName)

        '===================================
        'ͯ�ް÷�č쐬02
        '===================================
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)
            If ii <> 0 Then strHeader &= strColTerminator
            strHeader &= """" & grdColumnData.Item(menmListCol.COMMENTS, ii).Value & """"
        Next
        strHeader &= strRowTerminator
        strHeader = Replace(strHeader, vbCrLf, "")
        'ͯ�ް÷�ĕ���
        Dim strHeaderArray() As String = Nothing
        Call gobjComFuncFRM.DivStringToArray(strHeader, strHeaderArray)
        If IsNothing(strHeaderArray) = False Then
            If 0 <= UBound(strHeaderArray) Then strText05 = strHeaderArray(0)
            If 1 <= UBound(strHeaderArray) Then strText06 = strHeaderArray(1)
            If 2 <= UBound(strHeaderArray) Then strText07 = strHeaderArray(2)
        End If


        '********************************************************************
        '��
        '********************************************************************
        Call gobjComFuncFRM.CRPrintKaihatu(grdTableData, strTableName, strText01, "", strText05, strText06, strText07, txtTitle.Text)


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


        If mintDiffgrdColumnDataX <> 0 Then


            '********************************************************************
            '���ް���د�ޒ���
            '********************************************************************
            Dim intgrdColumnDataLocationX As Integer = Me.Size.Width - mintDiffgrdColumnDataX
            Dim intgrdColumnDataSizeY As Integer = Me.Size.Height - mintDiffgrdColumnDataY
            grdColumnData.Location = New System.Drawing.Point(intgrdColumnDataLocationX, grdColumnData.Location.Y)
            grdColumnData.Size = New System.Drawing.Size(grdColumnData.Size.Width, intgrdColumnDataSizeY)


            '********************************************************************
            'ð����ް���د�ޒ���
            '********************************************************************
            Dim intgrdTableDataSizeX As Integer = Me.Size.Width - mintDiffgrdTableDataX
            Dim intgrdTableDataSizeY As Integer = Me.Size.Height - mintDiffgrdTableDataY
            If grdColumnData.Visible = False Then intgrdTableDataSizeX += mintgrdColumnDataWidth
            grdTableData.Size = New System.Drawing.Size(intgrdTableDataSizeX, intgrdTableDataSizeY)


        End If
        mintgrdColumnDataWidth = grdColumnData.Size.Width                       '���ް���د�ޏ�����
        mintgrdTableDataWidth = grdTableData.Size.Width                         'ð����ް���د�ޏ�����


    End Sub
#End Region
#Region "  ���ް��\�������ޯ���ύX����              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ް��\�������ޯ���ύX����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub chkgrdColumnDataVisibleCheckedChangedProcess()

        grdColumnData.Visible = chkgrdColumnDataVisible.Checked
        If grdColumnData.Visible = True Then
            '(�\���̏ꍇ)
            grdTableData.Size = New System.Drawing.Size(mintgrdTableDataWidth, grdTableData.Size.Height)
        Else
            '(��\���̏ꍇ)
            grdTableData.Size = New System.Drawing.Size(mintgrdTableDataWidth + mintgrdColumnDataWidth, grdTableData.Size.Height)
        End If


    End Sub
#End Region
#Region "  ð��ّI������ޯ���ύX����               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ð��ّI������ޯ���ύX����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboTableName_SelectedIndexChangedProcess()


        '********************************************************************
        '��د�ޏ�����
        '********************************************************************
        grdTableData.DataSource = Nothing
        grdColumnData.DataSource = Nothing


        '********************************************************************
        '�ް���د�ޕ\��(���ް�)
        '********************************************************************
        Call grdColumnDataDisplay(cboTableName.SelectedValue)


    End Sub
#End Region
    '�ƭ��ް�����
#Region "  SQL�����s��ʸد�����                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL�����s��ʸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSQLClickProcess()


        '********************************************************************
        '̫�ѕ\��
        '********************************************************************
        objFRM_299011.objDb = mobjDb                'DB�ڑ�
        objFRM_299011.objFRM_299010 = Me            'DB����ݽ°�
        objFRM_299011.Location = Me.Location        '�ʒu�����킹��
        objFRM_299011.Show()                        '�\��
        objFRM_299011.TopMost = True                '��Ɏ�O�ɐݒ�(����O�Ɏ����ė���)
        objFRM_299011.TopMost = False               '��Ɏ�O�ɐݒ����


    End Sub
#End Region
#Region "  �ް��X�V�د�����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް��X�V�د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDataUpdateDropDownOpenedProcess()


        '********************************************************************
        '�ް��X�V
        '********************************************************************
        Select Case lblTrans.Text
            Case TRANS_NOTRANS
                '(�����ЯĒ�)
                tsmBeginTrans.Enabled = True      '��ݻ޸��݊J�n
                tsmRollBack.Enabled = False       '۰��ޯ�
                tsmCommit.Enabled = False         '�Я�
            Case TRANS_BEGINTRANS
                '(��ݻ޸��݊J�n��)
                tsmBeginTrans.Enabled = False     '��ݻ޸��݊J�n
                tsmRollBack.Enabled = True        '۰��ޯ�
                tsmCommit.Enabled = True          '�Я�
        End Select


    End Sub
#End Region
#Region "  Select�د�����                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Select�د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSelectClickProcess()


        '********************************************************************
        '�\�����ݸد�����
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  Insert�د�����                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Insert�د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmInsertClickProcess()

        '********************************************************************
        '�m�F���
        '********************************************************************
        If MsgBox(MSG001, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        '�ǉ�����
        '********************************************************************
        Call DataInsert(grdTableData.CurrentCell.RowIndex)


        '********************************************************************
        '��ʍX�V
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  Update�د�����                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Update�د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmUpdateClickProcess()

        '********************************************************************
        '�m�F���
        '********************************************************************
        If MsgBox(MSG002, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        '�ǉ�����
        '********************************************************************
        Call DataUpdate(grdTableData.CurrentCell.RowIndex)


        '********************************************************************
        '��ʍX�V
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  Delete�د�����                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Delete�د�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDeleteClickProcess()


        Call grdTableDataUserDeletingRowProcess()


        ' '' ''********************************************************************
        ' '' ''�m�F���
        ' '' ''********************************************************************
        '' ''If MsgBox(MSG003, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
        '' ''    Exit Sub
        '' ''End If


        ' '' ''********************************************************************
        ' '' ''�ǉ�����
        ' '' ''********************************************************************
        '' ''Call DataDelete(grdTableData.CurrentCell.RowIndex)


        ' '' ''********************************************************************
        ' '' ''��ʍX�V
        ' '' ''********************************************************************
        '' ''Call cmdDispProcess()


    End Sub
#End Region
#Region "  ��ݻ޸��݊J�n�د�                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ݻ޸��݊J�n�د� 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmBeginTransClickProcess()


        '********************************************************************
        '�m�F���
        '********************************************************************
        If mblnFormLoad = False Then
            '(̫��۰�ވȊO�̏ꍇ)
            If MsgBox(MSG101, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If


        '********************************************************************
        '��ݻ޸��݊J�n
        '********************************************************************
        Try
            mobjDb.BeginTrans()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        '���ٍX�V
        '********************************************************************
        Call lblTransUpdate(TRANS_BEGINTRANS)           '��ݻ޸��ݏ�ԕ\��


    End Sub
#End Region
#Region "  ۰��ޯ��J�n�د�                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۰��ޯ��J�n�د�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmRollBackClickProcess()


        '********************************************************************
        '�m�F���
        '********************************************************************
        If MsgBox(MSG102, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        '��ݻ޸��݊J�n
        '********************************************************************
        Try
            mobjDb.RollBack()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        '���ٍX�V
        '********************************************************************
        Call lblTransUpdate(TRANS_NOTRANS)              '��ݻ޸��ݏ�ԕ\��


        '********************************************************************
        '��ʍX�V
        '********************************************************************
        Call cmdDispProcess()


        '********************************************************************
        '��ݻ޸��݊J�n
        '********************************************************************
        Call tsmBeginTransClickProcess()


    End Sub
#End Region
#Region "  �ЯĊJ�n�د�                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ЯĊJ�n�د�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmCommitClickProcess()


        '********************************************************************
        '�m�F���
        '********************************************************************
        If MsgBox(MSG103, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        '��ݻ޸��݊J�n
        '********************************************************************
        Try
            mobjDb.Commit()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        '���ٍX�V
        '********************************************************************
        Call lblTransUpdate(TRANS_NOTRANS)              '��ݻ޸��ݏ�ԕ\��


        '********************************************************************
        '��ݻ޸��݊J�n
        '********************************************************************
        Call tsmBeginTransClickProcess()


    End Sub
#End Region

    '�����֐�
#Region "�@�ް���د�ޕ\��(���ް�)                   "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޕ\��(���ް�)
    ''' </summary>
    ''' <param name="strTableName">ð��ٖ�</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub grdColumnDataDisplay(ByVal strTableName As String)
        Dim strSQL As String                    'SQL��
        Dim objDataSet01 As New DataSet         '�ް����
        Dim objDataSet02 As New DataSet         '�ް����
        Dim strDataSetName01 As String          '�ް���Ė�
        Dim strDataSetName02 As String          '�ް���Ė�


        '********************************************************************
        '�ް��擾(�񖼎擾�p)
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    USER_TAB_COLUMNS "
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "    AND TABLE_NAME = '" & strTableName & "'"
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    COLUMN_ID "
        strSQL &= vbCrLf
        mobjDb.SQL = strSQL
        strDataSetName01 = "TABLE"
        objDataSet01.Clear()
        mobjDb.GetDataSet(strDataSetName01, objDataSet01)


        '********************************************************************
        '�s�ް��擾
        '********************************************************************
        If objDataSet01.Tables(strDataSetName01).Rows.Count > 0 Then
            Dim objDataTable As New GamenCommon.clsGridDataTable05          '�ް�ð���
            For ii As Integer = 0 To objDataSet01.Tables(strDataSetName01).Rows.Count - 1
                '(ٰ��:�ް�����)

                Dim strColumnName As String = TO_STRING(objDataSet01.Tables(strDataSetName01).Rows(ii)("COLUMN_NAME"))   '��
                Dim strBindField(1) As String   '�޲��ޕϐ�(̨���ޖ�)
                Dim objBindValue(1) As Object   '�޲��ޕϐ�(�l)


                '=====================================================
                '�޲��ޕϐ���`
                '=====================================================
                Dim objParameter(1, 1) As Object
                objParameter(0, 0) = "TABLE_NAME"
                objParameter(1, 0) = strTableName
                objParameter(0, 1) = "COLUMN_NAME"
                objParameter(1, 1) = strColumnName

                '=====================================================
                '�����߁A���Ď擾
                '=====================================================
                strSQL = ""
                strSQL &= vbCrLf & " SELECT"
                strSQL &= vbCrLf & "    USER_TAB_COLUMNS.COLUMN_NAME "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_TYPE "
                strSQL &= vbCrLf & "   ,USER_COL_COMMENTS.COMMENTS "
                strSQL &= vbCrLf & " FROM"
                strSQL &= vbCrLf & "    USER_TAB_COLUMNS "
                strSQL &= vbCrLf & "   ,USER_COL_COMMENTS "
                strSQL &= vbCrLf & " WHERE"
                strSQL &= vbCrLf & "        1 = 1 "
                strSQL &= vbCrLf & "    AND USER_TAB_COLUMNS.TABLE_NAME  = USER_COL_COMMENTS.TABLE_NAME "
                strSQL &= vbCrLf & "    AND USER_TAB_COLUMNS.COLUMN_NAME = USER_COL_COMMENTS.COLUMN_NAME "
                strSQL &= vbCrLf & "    AND USER_TAB_COLUMNS.TABLE_NAME = :" & objParameter(0, 0) & ""
                strSQL &= vbCrLf & "    AND USER_TAB_COLUMNS.COLUMN_NAME = :" & objParameter(0, 1) & ""
                strSQL &= vbCrLf
                mobjDb.SQL = strSQL
                mobjDb.Parameter = objParameter
                strDataSetName02 = "COLUMNS"
                objDataSet02.Clear()
                mobjDb.GetDataSet(strDataSetName02, objDataSet02)
                Dim strCOLUMN_NAME As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("COLUMN_NAME"))      '��
                Dim strDATA_TYPE As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_TYPE"))          '����
                Dim strCOMMENTS As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("COMMENTS"))            '����

                '=====================================================
                '��ײ�ذ���擾
                '=====================================================
                Dim strPK As String = ""            '��ײ�ذ��
                strSQL = ""
                strSQL &= vbCrLf & " SELECT"
                strSQL &= vbCrLf & "     C.TABLE_NAME"
                strSQL &= vbCrLf & "    ,COL.COLUMN_NAME"
                strSQL &= vbCrLf & "    ,C.CONSTRAINT_TYPE"
                strSQL &= vbCrLf & " FROM"
                strSQL &= vbCrLf & "     USER_CONSTRAINTS C"
                strSQL &= vbCrLf & "    ,USER_CONS_COLUMNS COL"
                strSQL &= vbCrLf & " WHERE 1 = 1"
                strSQL &= vbCrLf & "   AND C.TABLE_NAME = COL.TABLE_NAME"
                strSQL &= vbCrLf & "   AND C.CONSTRAINT_NAME = COL.CONSTRAINT_NAME"
                strSQL &= vbCrLf & "   AND C.CONSTRAINT_TYPE = 'P'"
                strSQL &= vbCrLf & "   AND C.TABLE_NAME = :" & objParameter(0, 0) & ""
                strSQL &= vbCrLf & "   AND COL.COLUMN_NAME = :" & objParameter(0, 1) & ""
                strSQL &= vbCrLf
                mobjDb.SQL = strSQL
                mobjDb.Parameter = objParameter
                strDataSetName02 = "PK"
                objDataSet02.Clear()
                mobjDb.GetDataSet(strDataSetName02, objDataSet02)
                If objDataSet02.Tables(strDataSetName02).Rows.Count > 0 Then
                    strPK = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("CONSTRAINT_TYPE"))      '��ײ�ذ��
                End If

                '=====================================================
                '�ް�ð��قɒǉ�
                '=====================================================
                objDataTable.userAddRowDataSet(strCOLUMN_NAME _
                                             , strDATA_TYPE _
                                             , strCOMMENTS _
                                             , strPK _
                                             )

            Next
            grdColumnData.DataSource = objDataTable
        End If


        '********************************************************************
        '��د�ޕ\���ݒ�
        '********************************************************************
        Call grdColumnDataSetup()


    End Sub
#End Region
#Region "�@�ް���د�ޕ\���ݒ�(ð����ް�)            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޕ\���ݒ�(ð����ް�) 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataSetup()

        '***********************
        '�����ݒ�
        '***********************
        '' ''grdTableData.RowHeadersVisible = False                                      '�sͯ�ް�\��        ���ݒ�
        grdTableData.AllowUserToResizeRows = False                                  '�s�̻��ޕύX       ���ݒ�
        '' ''grdTableData.AllowUserToResizeColumns = False                            '��̻��ޕύX       ���ݒ�
        '' ''grdTableData.MultiSelect = False                                            '�����ٓ����I��     ���ݒ�
        grdTableData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect      '�I��Ӱ��
        '' ''grdTableData.AllowUserToAddRows = False                                  '�s�ǉ�             ���ݒ�
        '' ''grdTableData.AllowUserToDeleteRows = False                               '�s�폜             ���ݒ�
        grdTableData.AllowUserToOrderColumns = False                                '��ړ�             ���ݒ�
        grdTableData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)    '��̕���������


        '***********************
        '�ް����z�u�ύX
        '***********************
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)

            Select Case grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value
                Case COL_DATA_TYPE_VARCHAR2
                    '(�����^�̏ꍇ)
                    grdTableData.Columns(ii).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_DATA_TYPE_NUMBER
                    '(���l�^�̏ꍇ)
                    grdTableData.Columns(ii).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case COL_DATA_TYPE_DATE
                    '(���t�^�̏ꍇ)
                    grdTableData.Columns(ii).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
                    grdTableData.Columns(ii).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    grdTableData.Columns(ii).Width = 115
            End Select

        Next


        '***********************
        '�����I��
        '***********************
        Try
            '�ް����\������Ȃ��ꍇ�������
            grdTableData(-1, -1).Selected = True
        Catch ex As Exception
        End Try


    End Sub
#End Region
#Region "�@�ް���د�ޕ\���ݒ�(���ް�)               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޕ\���ݒ�(���ް�)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdColumnDataSetup()

        '***********************
        '�����ݒ�
        '***********************
        grdColumnData.RowHeadersVisible = False                                   '�sͯ�ް�\��        ���ݒ�
        '' ''grdColumnData.AllowUserToResizeColumns = False                            '��̻��ޕύX       ���ݒ�
        grdColumnData.MultiSelect = False                                         '�����ٓ����I��     ���ݒ�
        grdColumnData.SelectionMode = DataGridViewSelectionMode.FullRowSelect     '�I��Ӱ��
        grdColumnData.AllowUserToAddRows = False                                  '�s�ǉ�             ���ݒ�
        grdColumnData.AllowUserToDeleteRows = False                               '�s�폜             ���ݒ�
        grdColumnData.AllowUserToResizeRows = False                               '�s���ޕύX         ���ݒ�
        grdColumnData.AllowUserToOrderColumns = False                             '��ړ�             ���ݒ�
        For Each objColum As DataGridViewColumn In grdColumnData.Columns
            objColum.SortMode = DataGridViewColumnSortMode.Programmatic     '��̕��֋֎~
        Next

        '***********************
        'ͯ�ް�\���ύX
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).HeaderText = "��"
        grdColumnData.Columns(menmListCol.DATA_TYPE).HeaderText = "����"
        grdColumnData.Columns(menmListCol.COMMENTS).HeaderText = "����"
        grdColumnData.Columns(menmListCol.PK).HeaderText = "PK"


        '***********************
        '�ް����z�u�ύX
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.DATA_TYPE).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.COMMENTS).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.PK).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        '***********************
        '��\��
        '***********************
        grdColumnData.Columns(menmListCol.Data04).Visible = False
        grdColumnData.Columns(menmListCol.Data05).Visible = False


        '***********************
        '�񕝒���
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).Width = 120
        grdColumnData.Columns(menmListCol.DATA_TYPE).Width = 80
        grdColumnData.Columns(menmListCol.COMMENTS).Width = 129
        grdColumnData.Columns(menmListCol.PK).Width = 20


        '***********************
        '�ҏWۯ�
        '***********************
        grdColumnData.ReadOnly = True


    End Sub
#End Region
#Region "�@ں��ޒǉ�                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ں��ޒǉ�
    ''' </summary>
    ''' <param name="intRow">�ǉ�������د�ނ̍s���ޯ��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DataInsert(ByVal intRow As Integer)
        Dim strSQL As String                    'SQL��
        Dim intRetSQL As Integer                'SQL���s�߂�l
        Dim strMsg As String                    'ү����


        '********************************************************************
        '��ײ�ذ������
        '********************************************************************

        '********************************************************************
        'NotNull����
        '********************************************************************

        '********************************************************************
        'SQL���񖼕����쐬
        '********************************************************************
        Dim strSQLColumnData As String = ""                    'SQL��
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)

            strSQLColumnData &= vbCrLf & "    ," & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value
            If ii = 0 Then
                strSQLColumnData = Replace(strSQLColumnData, vbCrLf, "")
                strSQLColumnData = Replace(strSQLColumnData, ",", " ")
            End If
        Next


        '********************************************************************
        'SQL���ް������쐬
        '********************************************************************
        Dim strSQLValue As String = ""                    'SQL��
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)

            Dim strValue As String = TO_STRING(grdTableData.Item(ii, intRow).Value)
            If strValue = "" Then
                strSQLValue &= vbCrLf & "    ,Null"
            Else
                strSQLValue &= vbCrLf & "    ," & GetStringSQLData(strValue, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If

            If ii = 0 Then
                strSQLValue = Replace(strSQLValue, vbCrLf, "")
                strSQLValue = Replace(strSQLValue, ",", " ")
            End If
        Next


        '********************************************************************
        'INSERT���쐬
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " INSERT INTO "
        strSQL &= vbCrLf & "    " & cboTableName.SelectedValue
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & "    )"
        strSQL &= vbCrLf & "    VALUES"
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & strSQLValue
        strSQL &= vbCrLf & "    )"
        strSQL &= vbCrLf
        intRetSQL = mobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_ADD & mobjDb.ErrMsg & "�y" & strSQL & "�z"
            Throw New Exception(strMsg)
        End If


    End Sub
#End Region
#Region "�@ں��ލ폜                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ں��ލ폜
    ''' </summary>
    ''' <param name="intRow">�ǉ����ꂽ��د�ނ̍s���ޯ��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DataDelete(ByVal intRow As Integer)
        Dim strSQL As String                    'SQL��
        Dim intRetSQL As Integer                'SQL���s�߂�l
        Dim strMsg As String                    'ү����


        '********************************************************************
        'SQL��Where�啔���쐬
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL��
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)

            If grdColumnData.Item(menmListCol.PK, ii).Value = CONSTRAINT_TYPE_PK Then
                '(��ײ�ذ���̏ꍇ)
                strSQLWhere &= vbCrLf & "    AND " & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
                strSQLWhere &= GetStringSQLData(grdTableData.Item(ii, intRow).Value, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If

        Next


        '********************************************************************
        'Delete���쐬
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " DELETE "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "    " & cboTableName.SelectedValue
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        intRetSQL = mobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_ADD & mobjDb.ErrMsg & "�y" & strSQL & "�z"
            Throw New Exception(strMsg)
        ElseIf intRetSQL = 0 Then
            strMsg = "�Ώ�ں��ނ����݂��܂���B" & "�y" & strSQL & "�z"
            Throw New Exception(strMsg)
        End If


    End Sub
#End Region
#Region "�@ں��ލX�V                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ں��ލX�V
    ''' </summary>
    ''' <param name="intRow">�ǉ����ꂽ��د�ނ̍s���ޯ��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DataUpdate(ByVal intRow As Integer)
        Dim strSQL As String                    'SQL��
        Dim intRetSQL As Integer                'SQL���s�߂�l
        Dim strMsg As String                    'ү����


        '********************************************************************
        'SQL��Set�啔���쐬
        '********************************************************************
        Dim strSQLSet As String = ""                    'SQL��
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)

            Dim strValue As String = TO_STRING(grdTableData.Item(ii, intRow).Value)
            If strValue = "" Then
                strSQLSet &= vbCrLf & "    ," & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = Null"
            Else
                strSQLSet &= vbCrLf & "    ," & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
                strSQLSet &= GetStringSQLData(strValue, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If


            If ii = 0 Then
                strSQLSet = Replace(strSQLSet, vbCrLf, "")
                strSQLSet = Replace(strSQLSet, ",", " ")
            End If

        Next


        '********************************************************************
        'SQL��Where�啔���쐬
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL��
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ٰ��:��)

            If grdColumnData.Item(menmListCol.PK, ii).Value = CONSTRAINT_TYPE_PK Then
                '(��ײ�ذ���̏ꍇ)
                strSQLWhere &= vbCrLf & "    AND " & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
                strSQLWhere &= GetStringSQLData(grdTableData.Item(ii, intRow).Value, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If

        Next


        '********************************************************************
        'Update���쐬
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " UPDATE "
        strSQL &= vbCrLf & "    " & cboTableName.SelectedValue
        strSQL &= vbCrLf & " SET "
        strSQL &= vbCrLf & strSQLSet
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        intRetSQL = mobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_ADD & mobjDb.ErrMsg & "�y" & strSQL & "�z"
            Throw New Exception(strMsg)
        ElseIf intRetSQL = 0 Then
            strMsg = "�Ώ�ں��ނ����݂��܂���B" & "�y" & strSQL & "�z"
            Throw New Exception(strMsg)
        End If


    End Sub
#End Region
#Region "�@��ݻ޸��ݏ�����ٍX�V                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ݻ޸��ݏ�����ٍX�V
    ''' </summary>
    ''' <param name="strText">���ق��X�V����÷�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub lblTransUpdate(ByVal strText As String)


        '********************************************************************
        '���ٍX�V
        '********************************************************************
        Select Case strText
            Case TRANS_NOTRANS
                lblTrans.BackColor = TRANS_COLOR_NOTRANS
            Case TRANS_BEGINTRANS
                lblTrans.BackColor = TRANS_COLOR_BEGINTRANS
        End Select
        lblTrans.Text = strText


        '********************************************************************
        '��ۯ���޳ݍX�V
        '********************************************************************
        Call tsmDataUpdateDropDownOpenedProcess()


    End Sub
#End Region
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

    '�ް���د�޲���ď���
#Region "  �ް���د�ޑI��ύX����ď���              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޑI��ύX����ď��� 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataSelectionChangedProcess()


        '********************************************************************
        '���O����
        '********************************************************************
        If IsNull(grdTableData.CurrentCell) = True Then
            '(ͯ�ް��I�����ꂽ�ꍇ�Ƃ�)
            Exit Sub
        End If


        '********************************************************************
        '��د�ޑI�����L��
        '********************************************************************
        mintBeforeCellRow = mintCurrentCellRow                              '�O��I���s�ʒu
        mintBeforeCellCol = mintCurrentCellCol                              '�O��I���ʒu
        mintCurrentCellRow = grdTableData.CurrentCell.RowIndex              '���ݑI���s�ʒu
        mintCurrentCellCol = grdTableData.CurrentCell.ColumnIndex           '���ݑI���ʒu


        '********************************************************************
        '���򏈗�
        '********************************************************************
        If mintBeforeCellRow = mintCurrentCellRow Then
            '(�s�I�����ς���Ă��Ȃ��ꍇ)
            Exit Sub
        End If
        If mblnRowInsert = True Then
            '(�s���ǉ�����Ă����ꍇ)

            '========================================================
            '�m�F���
            '========================================================
            If MsgBox(MSG011, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            '========================================================
            '�ǉ�����
            '========================================================
            Try
                Call DataInsert(mintBeforeCellRow)
            Catch ex As Exception
                ComError(ex)
            End Try
            mblnCellValueChange = False         '�ْl�ύX�׸�
            mblnRowInsert = False               '�s�ǉ��׸�

            '========================================================
            '��ʍX�V
            '========================================================
            Call cmdDispProcess()

        ElseIf mblnCellValueChange = True Then
            '(�l���X�V����Ă����ꍇ)

            '========================================================
            '�m�F���
            '========================================================
            If MsgBox(MSG012, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            '========================================================
            '�X�V����
            '========================================================
            Try
                Call DataUpdate(mintBeforeCellRow)
            Catch ex As Exception
                ComError(ex)
            End Try
            mblnCellValueChange = False         '�ْl�ύX�׸�
            mblnRowInsert = False               '�s�ǉ��׸�

            '========================================================
            '��ʍX�V
            '========================================================
            Call cmdDispProcess()

        End If


    End Sub
#End Region
#Region "�@�ް���د�ޕҏW�I������ď���              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޕҏW�I������ď���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataCellParsingProcess()


        '********************************************************************
        '�׸�ON
        '********************************************************************
        mblnCellValueChange = True          '�ْl�ύX�׸�


    End Sub
#End Region
#Region "�@�ް���د�ސV�����s�ǉ�����ď���          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ސV�����s�ǉ�����ď���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataUserAddedRowProcess()


        '********************************************************************
        '�׸�ON
        '********************************************************************
        mblnRowInsert = True


    End Sub
#End Region
#Region "  �ް���د�ލs�폜����ď���                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ލs�폜����ď���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataUserDeletingRowProcess()


        '========================================================
        '�m�F���
        '========================================================
        If MsgBox(MSG013, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If

        '========================================================
        '�폜����
        '========================================================
        Try

            For ii As Integer = 0 To grdTableData.RowCount - 1
                '(ٰ��:��د�ލs��)

                If grdTableData.Rows(ii).Selected = True Then
                    Call DataDelete(ii)
                End If

                '' ''Call DataDelete(grdTableData.CurrentCell.RowIndex)
            Next

        Catch ex As Exception
            ComError(ex)
        End Try
        mblnCellValueChange = False         '�ْl�ύX�׸�
        mblnRowInsert = False               '�s�ǉ��׸�

        ' '' ''========================================================
        ' '' ''��ʍX�V
        ' '' ''========================================================
        '' ''Call cmdDispProcess()


    End Sub
#End Region


End Class