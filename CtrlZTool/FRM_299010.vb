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
Imports CtrlZTool.clsComFuncFRM
Imports JobCommon
#End Region

Public Class FRM_299010

#Region "�@���ʕϐ��@                               "

    '================================================
    '�ϐ�
    '================================================
    '�׽
    Private Shared mobjInstanceFRM_299011 As FRM_299011 'SQL�����s���

    '�����è
    Private mstrDispTableName As String                  '�����\������ð��ٖ�

    'ð����ް��ύX����ėp
    Private mintCurrentCellRow As Integer           '���ݑI���s�ʒu
    Private mintCurrentCellCol As Integer           '���ݑI���ʒu
    Private mintBeforeCellRow As Integer            '�O��I���s�ʒu
    Private mintBeforeCellCol As Integer            '�O��I���ʒu
    Private mblnCellValueChange As Boolean          '�ْl�ύX�׸�
    Private mblnRowInsert As Boolean                '�s�ǉ��׸�
    Private mstrSQLFilterWhere As String            '̨����pSQL��Where��
    Private mstrSQLFilterOrder As String            '̨����pSQL��OrderBy��
    Private mstrSQLFilterAryOrder(0) As String      '̨����pSQL��OrderBy��  (�z��)
    Private mstrSQLUpdateWhere As String            'Update�pSQL��Where��

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
    Private mblnFormClose As Boolean                    '̫�Ѹ۰���׸�(��۸��ъJ�n���ɕ���̫�ѕ\��������悤�ɂ�����A�ꖇ�ڂ�̫�т��c���Ă��܂������Ƃ������Ȃ�������ǉ�)
    Private mobjAryLogDispConfig() As strcLogDispConfig '۸�ð��ٕ\����`


    '================================================
    '�萔
    '================================================
    '�ް�����
    Private Const COL_DATA_TYPE_VARCHAR2 As String = "VARCHAR2"
    Private Const COL_DATA_TYPE_NUMBER As String = "NUMBER"
    Private Const COL_DATA_TYPE_DATE As String = "DATE"

    '���я�
    Private Const ORDER_BY_ASC As String = " ASC"       '����
    Private Const ORDER_BY_DESC As String = " DESC"     '�~��

    'ү����
    Private Const MSG001 As String = "�I������ں��ނ�ǉ����Ă���낵���ł����H"
    Private Const MSG002 As String = "�I������ں��ނ��X�V���Ă���낵���ł����H"
    Private Const MSG003 As String = "�I������ں��ނ��폜���Ă���낵���ł����H"
    Private Const MSG011 As String = "ں��ނ��ǉ�����܂����B�ǉ������s���Ă���낵���ł����H"
    Private Const MSG012 As String = "ں��ނ��X�V����܂����B�X�V�����s���Ă���낵���ł����H"
    Private Const MSG013 As String = "ں��ނ��폜����܂����B�폜�����s���Ă���낵���ł����H"
    Private Const MSG021 As String = "ں��ނ�ǉ����Ă���낵���ł����H"
    Private Const MSG101 As String = "��ݻ޸��݂��J�n���Ă���낵���ł����H"
    Private Const MSG102 As String = "۰��ޯ����Ă���낵���ł����H"
    Private Const MSG103 As String = "�ЯĂ��Ă���낵���ł����H"
    Private Const MSG501 As String = "�߰�č�Ƃ́A�ŏI�s��I�����Ă�����s���ĉ������B"
    Private Const MSG502 As String = "�د���ް�ނ��ް����ƁA��د�ނ��ް��̗񐔂���v���܂���B"
    Private Const MSG503 As String = "�ق��I������Ă��܂���B" & vbCrLf & "�ق�I�����Ă��������B"
    Private Const MSG504 As String = "�����̾ق��I������Ă��܂��B" & vbCrLf & "��̾ق�I�����Ă��������B"

    '��ï��������
    Private Const MENU_EQUAL_TEXT As String = "  �ɓ�����"
    Private Const MENU_NOTEQUAL_TEXT As String = "  �ɓ������Ȃ�"
    Private Const MENU_CONTAIN_TEXT As String = "  ���܂�"
    Private Const MENU_NOTCONTAIN_TEXT As String = "  ���܂܂Ȃ�"
    Private Const MENU_OVER_TEXT As String = "  �ȏ�"
    Private Const MENU_UNDER_TEXT As String = "  �ȉ�"

    '�F
    Private HEADER_COLOR_RED As Color = Color.FromArgb(255, 0, 0)          'ð����ް���د�ނ�ͯ�ް�w�i�F(��)
    Private HEADER_COLOR_BLUE As Color = Color.FromArgb(197, 196, 251)     'ð����ް���د�ނ�ͯ�ް�w�i�F(��)
    Private HEADER_COLOR_PURPLE As Color = Color.FromArgb(172, 101, 203)   'ð����ް���د�ނ�ͯ�ް�w�i�F(��)

    '���̑�
    Private Const CBOTABLENAME_LENGTH As Integer = 30           'ð��ٖ��̒���
    Private Const CONSTRAINT_TYPE_PK As String = "P"            '��ײ�ذ������
    Private Const SQL_COMMENT_POSITION As Integer = 35          'SQL�����ĊJ�n�ʒu
    Private Const SQL_USER_INPUT_PLACE As String = "@@@@"       'հ�ް��`����


    '================================================
    '�񋓑�
    '================================================
    ''' <summary>�����ް���د�ލ���</summary>
    Enum menmListCol
        COLUMN_NAME         '��
        COMMENTS            '����
        DATA_TYPE           '����
        DATA_LENGTH         '��̒���
        DATA_PRECISION      '���x
        DATA_SCALE          '���l�̏����_�ȉ��̌�
        PK                  '��ײ�ذ��
        NN                  'NULLABLE
        Data08              '�ް�08(��)
        Data09              '�ް�09(��)
        Data10              '�ް�10(��)
        Data11              '�ް�11(��)
        Data12              '�ް�12(��)
        Data13              '�ް�13(��)
        Data14              '�ް�14(��)
        Data15              '�ް�15(��)
        Data16              '�ް�16(��)
        Data17              '�ް�17(��)
        Data18              '�ް�18(��)
        Data19              '�ް�19(��)
        Data20              '�ް�20(��)
    End Enum

    ''' <summary>̨����@�\��SQL��Where��쐬���̕���</summary>
    Enum menmFilterSQLWhere
        Equal               '�`�ɓ�����
        NotEqual            '�`�ɓ������Ȃ�
        Contain             '�`���܂�
        NotContain          '�`���܂܂Ȃ�
        Over                '�`�ȏ�
        Under               '�`�ȉ�
    End Enum

    '================================================
    '�\����
    '================================================
    ''' <summary>۸�ð��ٕ\����`</summary>
    Private Structure strcLogDispConfig
        Public strTableName         'ð��ٖ�
        Public strFieldNameWhere    '̨���ޖ�(����)
        Public strFieldNameOrder    '̨���ޖ�(����)
    End Structure


#End Region
#Region "  �����è                                  "
    '''****************************************************************************************************************************************
    ''' <summary>
    ''' �������̫�тɱ�������ׂ������è
    ''' </summary>
    ''' <value>SQL�����s���</value>
    ''' <returns>SQL�����s���</returns>
    ''' <remarks></remarks>
    '''****************************************************************************************************************************************
    Private Shared ReadOnly Property objFRM_299011() As FRM_299011
        Get
            '̫�т�null�܂��͔j������Ă���Ƃ��́A�V�����ݽ�ݽ���쐬����
            If mobjInstanceFRM_299011 Is Nothing OrElse mobjInstanceFRM_299011.IsDisposed Then
                mobjInstanceFRM_299011 = New FRM_299011
            End If
            Return mobjInstanceFRM_299011
        End Get
    End Property

    '''****************************************************************************************************************************************
    ''' <summary>
    ''' ̨����pWhere����J
    ''' </summary>
    ''' <remarks></remarks>
    '''****************************************************************************************************************************************
    Public ReadOnly Property strSQLFilterWhere() As String
        Get
            Return mstrSQLFilterWhere
        End Get
    End Property

    '''****************************************************************************************************************************************
    ''' <summary>
    ''' �����\������ð��ٖ�
    ''' </summary>
    ''' <remarks></remarks>
    '''****************************************************************************************************************************************
    Public Property strDispTableName() As String
        Get
            Return mstrDispTableName
        End Get
        Set(ByVal Value As String)
            mstrDispTableName = Value
        End Set
    End Property
#End Region
#Region "  �����                                    "

#Region "  ̫��۰��                                                 "
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
            Call FormLoad(True)
        Catch ex As Exception
            ComError(ex)
        Finally
            mblnFormLoad = False    '̫��۰�ޒ��׸�
        End Try
    End Sub
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�Ѽ��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299010_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If mblnFormClose = True Then Me.Close()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �\��                                         ���ݸد�    "
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


            '********************************************************************
            '�F�X������
            '********************************************************************
            mstrSQLFilterWhere = ""
            mstrSQLFilterOrder = ""
            ReDim mstrSQLFilterAryOrder(0)
            grdTableData.DataSource = Nothing


            '********************************************************************
            '�\�����ݸد�����
            '********************************************************************
            Call cmdDispProcess()


        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �X�V                                         ���ݸد�    "
    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Try
            Call tsmRefreshClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ۸ޕ\��                                      ���ݸد�    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸ޕ\��                                      ���ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogDisp.Click
        Try
            Call cmdLogDisp_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ��k                                         ���ݸد�    "
    Private Sub cmdColInitialize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColInitialize.Click
        Try
            Call cmdColInitialize_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ��                                         ���ݸد�    "
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
#Region "  SQL                                          ���ݸد�    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL���ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSQLFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSQLFile.Click
        Try


            '********************************************************************
            '�\�����ݸد�����
            '********************************************************************
            Call cmdSQLFileProcess()


        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ̫��                                         ���ޕύX    "
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
#Region "  ���ް��\��                                   �����ޯ���ύX   "
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
#Region "  ð��ّI������ޯ��                           �ύX        "
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
#Region "  SQL�����s���                                    �د�"
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
#Region "  �V�K����޳                                       �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �V�K����޳�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmNewMake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmNewMake.Click
        Try
            Call tsmNewMakeClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �ް��X�V                                         �د�"
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
#Region "  Select                                           �د�"
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
#Region "  �\���X�V                                         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\���X�V�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmRefresh.Click
        Try
            Call tsmRefreshClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ��ݻ޸��݊J�n                                    �د�"
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
#Region "  ۰��ޯ�                                          �د�"
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
#Region "  �Я�                                             �د�"
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
#Region "  �ڑ�                                             �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ڑ��د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmConnect.Click
        Try
            Call tsmConnect_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �ؒf                                             �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ؒf�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDisConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDisConnect.Click
        Try
            Call tsmDisConnect_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ð��ّI������ޯ����������                       �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmTableNameSelectAutoCansel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTableNameSelectAutoCansel.Click
        Try
            Call tsmTableNameSelectAutoCansel_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ð��ّI������ޯ����ۯ���޳ݽ���                 �د�"
    Private Sub tsmTableNameDropDownStyle01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTableNameDropDownStyle01.Click
        Try
            Call tsmTableNameDropDownStyle00_ClickProcess(sender)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
    Private Sub tsmTableNameDropDownStyle02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTableNameDropDownStyle02.Click
        Try
            Call tsmTableNameDropDownStyle00_ClickProcess(sender)
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
#Region "  �ް���د�޷��޳ݲ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�޷��޳ݲ����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdTableData.KeyDown
        Try
            If e.Control And e.KeyCode = Keys.V Then
                '(Ctrl + V �̏ꍇ)
                Call DataPasteProcess()
            End If

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �ް���د�޾�ϳ��޳ݲ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�޾�ϳ��޳ݲ����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdTableData.CellMouseDown
        Try
            Call grdTableData_CellMouseDownProcess(sender, e)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �ް���د�޾�ϳ����߲����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�޾�ϳ����߲����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdTableData.CellMouseUp
        Try
            Call grdTableData_CellMouseDownProcess(sender, e)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    '�ް���د�޺�ï���ƭ���د�߲����
#Region "  �`�ɓ�����                   �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �`�ɓ�����                   �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Equal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Equal.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.Equal)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �`�ɓ������Ȃ�               �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �`�ɓ������Ȃ�               �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_NotEqual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_NotEqual.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.NotEqual)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �`���܂�                     �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �`���܂�                     �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Contain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Contain.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.Contain)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �`���܂܂Ȃ�                 �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �`���܂܂Ȃ�                 �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_NotContain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_NotContain.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.NotContain)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �`�ȏ�                       �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �`�ȏ�                       �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Over_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Over.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.Over)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �`�ȉ�                       �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �`�ȉ�                       �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Under_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Under.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.Under)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ÷��̨�� �ɓ�����            �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÷��̨�� �ɓ�����            �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_Equal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_Equal.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.Equal)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ÷��̨�� �ɓ������Ȃ�        �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÷��̨�� �ɓ������Ȃ�        �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_NotEqual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_NotEqual.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.NotEqual)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ÷��̨�� ���܂�              �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÷��̨�� ���܂�              �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_Contain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_Contain.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.Contain)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ÷��̨�� ���܂܂Ȃ�          �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÷��̨�� ���܂܂Ȃ�          �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_NotContain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_NotContain.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.NotContain)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ÷��̨�� �ȏ�                �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÷��̨�� �ȏ�                �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_Over_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_Over.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.Over)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ÷��̨�� �ȉ�                �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÷��̨�� �ȉ�                �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_Under_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_Under.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.Under)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ����                         �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����                         �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Asc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Asc.Click
        Try
            Call Menu_Asc_ClickProcess(ORDER_BY_ASC)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �~��                         �د������   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �~��                         �د������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Desc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Desc.Click
        Try
            Call Menu_Asc_ClickProcess(ORDER_BY_DESC)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ÷���ޯ��                    ����ٸد������  "
    Private Sub Menu_Sitei_TextBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Sitei_TextBox.DoubleClick
        Try
            Call Menu_Sitei_TextBox_DoubleClickProcess()
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
                If IsDate(strData) Then
                    strReturn = "TO_DATE('" & Format(TO_DATE(strData), CtrlZTool.clsComFuncFRM.DATE_FORMAT_03) & "','YYYY/MM/DD HH24:MI:SS')"
                Else
                    strReturn = "TO_DATE('" & Format(strData, CtrlZTool.clsComFuncFRM.DATE_FORMAT_03) & "','YYYY/MM/DD HH24:MI:SS')"
                End If
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
#Region "  ̫��                         ۰�ޏ���            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�ޏ���
    ''' </summary>
    ''' <param name="blnInitialize">�������׸�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad(ByVal blnInitialize As Boolean)


        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        '�F�X����������
        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        If blnInitialize = True Then
            Call InitializeProcess()
        End If



        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        '��������̖{�ԏ���
        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        Dim strSQL As String                    'SQL��
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�
        Dim aryData As ArrayList = New ArrayList


        '**************************************************************************
        '�F�X������
        '**************************************************************************
        chkgrdColumnDataVisible.Checked = True      '���ް����\������ĂȂ���̫��۰�ޏ����ł��������Ȃ�(�ł�̫��۰�ޏI�����ɂ͗��ް��͔�\��)


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
        gobjDb.SQL = strSQL
        strDataSetName = "USER_TABLES"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(�ް����擾�o�����ꍇ)
            For ii As Integer = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                '(ٰ��:�擾�ް���)

                Dim strComboDisp As String = ""         '�����ޯ���\���p������
                Dim strTableName As String = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)("TABLE_NAME"))        'ð��ٖ�
                Dim strTableComment As String = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)("COMMENTS"))       'ð��ٖ�����
                strComboDisp &= SPC_PAD(strTableName, CBOTABLENAME_LENGTH)
                strComboDisp &= strTableComment
                aryData.Add(New clsCboData(strComboDisp, strTableName))
            Next
        Else
            Throw New Exception("ð��ق�������܂���B")
        End If
        cboTableName.DisplayMember = clsCboData.DISPLAYMEMBER
        cboTableName.ValueMember = clsCboData.VALUEMEMBER
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
        'Call tsmBeginTransClickProcess()                        '��ݻ޸��݊J�n
        Call lblTransUpdate(TRANS_NOTRANS)                      '��ݻ޸��ݏ�ԕ\��


        '********************************************************************
        '�����\������ð��ق��ݒ肳��Ă����ꍇ
        '********************************************************************
        If IsNotNull(mstrDispTableName) Then
            '(�����\������ð��ق��ݒ肳��Ă����ꍇ)

            '�����ޯ���ݒ�
            cboTableName.SelectedValue = mstrDispTableName

        End If


        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        '��۸��ъJ�n��A���ڂ̏���
        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        If gblnFirst = True Then
            '(��۸��ъJ�n��A���ڂ̏����̏ꍇ)
            gblnFirst = False
            mblnFormClose = True


            '*******************************************************
            '̫�эő剻
            '*******************************************************
            If TO_INTEGER(GET_CONFIG_INFO(GKEY_G000000_042)) = 1 Then
                Me.WindowState = FormWindowState.Maximized
            End If


            ''*******************************************************
            ''��۸��ъJ�n���ɕ\������ð��وꗗ
            ''*******************************************************
            'Dim strAryTableName() As String = Split(TO_STRING(GET_CONFIG_INFO(GKEY_G000000_051)), ",")
            'For ii As Integer = 0 To strAryTableName.Length - 1
            '    strAryTableName(ii) = strAryTableName(ii).Replace(vbCrLf, "")
            '    strAryTableName(ii) = RTrim(strAryTableName(ii))
            '    strAryTableName(ii) = LTrim(strAryTableName(ii))

            '    Exit For  ''MOD
            'Next
            'For Each strTableName As String In strAryTableName
            '    '(ٰ��:��۸��ъJ�n���ɕ\������ð��وꗗ��)
            '    For Each cboTableNameItems As clsCboData In cboTableName.Items
            '        '(ٰ��:�����ޯ���ɾ�Ă���Ă��鱲�ѐ�)
            '        If cboTableNameItems.Value = strTableName Then
            '            '(��۸��ъJ�n���ɕ\������ꍇ)
            '            Call tsmNewMakeClickProcess(cboTableNameItems.Value)
            '            Exit For
            '        End If
            '    Next
            'Next
            Call tsmNewMakeClickProcess()       '�Ō�̈ꖇ��\��(�����̏ꍇ�����̏������K�v�Ȉ�)

        End If


    End Sub
#End Region
#Region "  �\��                         ���ݸد�����        "
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
        Dim blnDispData As Boolean = True       '�ް��\���׸�


        '********************************************************************
        '�ް������擾
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "    COUNT(*) "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    " & strTableName
        If mstrSQLFilterWhere <> "" Then
            '(����������ꍇ)
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "        1 = 1 "
            strSQL &= vbCrLf & mstrSQLFilterWhere
        End If
        strSQL &= vbCrLf
        gobjDb.SQL = strSQL
        strDataSetName01 = "COUNT"
        objDataSet02.Clear()
        gobjDb.GetDataSet(strDataSetName01, objDataSet02)
        If objDataSet02.Tables(strDataSetName01).Rows.Count > 0 Then
            '(�ް����擾�o�����ꍇ)
            If TO_INTEGER(GET_CONFIG_INFO(GKEY_G000000_043)) < TO_INTEGER(objDataSet02.Tables(strDataSetName01).Rows(0)(0)) Then
                '(�ް����������������ꍇ)

                If (New StackFrame(7).GetMethod.Name) = "FormLoad" Then
                    '(strDispTableName�����è���ݒ肳��Ă��āA����ɂ��\���̏ꍇ)
                    blnDispData = False
                ElseIf (New StackFrame(1).GetMethod.Name) = "Menu_Asc_ClickProcess" _
                   And (New StackFrame(2).GetMethod.Name) = "cmdLogDisp_ClickProcess" _
                   Then
                    '(۸ޕ\�������ł̕\���@���@���ёւ������̏ꍇ)
                    '(��d�̊m�F�ɂȂ��Ă��܂��̂ŁA�������鎖�ɂ���)
                    'NOP
                ElseIf (New StackFrame(2).GetMethod.Name) = "cboTableName_SelectedIndexChangedProcess" _
                   And RetCode.OK = SearchLogDispDefine(cboTableName.SelectedValue) _
                   Then
                    '(ð��ّI������ޯ���őI�����ύX���ꂽ�@���@۸�ð��ٕ\����`������Ă����ꍇ)
                    blnDispData = False
                Else
                    '(�ʏ�̕\���̏ꍇ)
                    Dim intRowCount As Integer = TO_INTEGER(objDataSet02.Tables(strDataSetName01).Rows(0)(0))       '�ް�����
                    Dim intRowPerSec As Integer = TO_INTEGER(GET_CONFIG_INFO(GKEY_G000000_044))                     '1�b�ŕ\���\�ȍs��(�s/sec)
                    Dim intMin As Integer = (intRowCount \ (intRowPerSec * 60))                                     '��
                    Dim intSec As Integer = (intRowCount Mod (intRowPerSec * 60)) \ (intRowPerSec)                  '�b
                    Dim strMsg As String = ""
                    strMsg = "�ް�������" & Format(intRowCount, "#,#") & "���ł��B"
                    strMsg &= vbCrLf & "��" & TO_STRING(intMin) & "��" & TO_STRING(intSec) & "�b"
                    strMsg &= vbCrLf & "������܂��B"
                    strMsg &= vbCrLf & "���s���܂����H"
                    If MsgBox(strMsg, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                        blnDispData = False
                    End If
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
        '========================================================
        'SELECT��
        '========================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    " & strTableName

        '========================================================
        'WHERE��
        '========================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        If blnDispData = False Then
            '(�ް���\�����Ȃ��ꍇ)
            strSQL &= vbCrLf & "    AND 1 <> 1 "
        End If
        If mstrSQLFilterWhere <> "" Then
            '(����������ꍇ)
            strSQL &= mstrSQLFilterWhere
        End If

        '========================================================
        'ORDER BY��
        '========================================================
        strSQL &= vbCrLf & " ORDER BY "
        If mstrSQLFilterOrder <> "" Then
            '(����������ꍇ)
            strSQL &= vbCrLf & mstrSQLFilterOrder
        Else
            '(�������Ȃ��ꍇ)
            strSQL &= vbCrLf & strSQLColumnData
        End If
        strSQL &= vbCrLf

        '========================================================
        '�擾
        '========================================================
        gobjDb.SQL = strSQL
        strDataSetName01 = "TABLE"
        objDataSetGrid.Clear()
        '�擾 & �������x����
        Dim dtmNow01 As Date = Now
        gobjDb.GetDataSet(strDataSetName01, objDataSetGrid)
        Dim objDiff As TimeSpan = Now - dtmNow01
        '۸ޏo��
        gobjDb.AddToLog(gobjDb.SQL & ";")
        gobjDb.AddToLog("[DB�擾��������:" & CStr(CDec(objDiff.TotalMilliseconds / 1000)) & "(sec)]")
        '��د�ނɔ��f
        grdTableData.DataSource = objDataSetGrid.Tables(strDataSetName01)


        '********************************************************************
        '��د�ޕ\���ݒ�
        '********************************************************************
        Call grdTableDataSetup()


    End Sub
#End Region
#Region "  ۸ޕ\��                      ���ݸد�����        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸ޕ\��                      ���ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogDisp_ClickProcess()
        Dim intRet As RetCode


        '*******************************************************
        '۸�ð��ْ�`��(ð��ٖ�)      �̌�������
        '*******************************************************
        Dim strFieldNameWhere As String = ""         '̨���ޖ�(����)
        Dim strFieldNameOrder As String = ""         '̨���ޖ�(����)
        intRet = SearchLogDispDefine(cboTableName.SelectedValue, strFieldNameWhere, strFieldNameOrder)
        If intRet = RetCode.OK Then
            '(��`�����������ꍇ)


            '*******************************************************
            '۸�ð��ْ�`��(̨���ޖ�)     �̌�������
            '*******************************************************
            Dim intColIndexWhere As Integer      '����ޯ��(����)
            Dim intColIndexOrder As Integer      '����ޯ��(����)
            Call SearchFieldIndex(strFieldNameWhere, intColIndexWhere)
            Call SearchFieldIndex(strFieldNameOrder, intColIndexOrder)


            '*******************************************************
            '÷��̨�� �ȏ�          ����
            '*******************************************************
            grdTableData.ClearSelection()                               '��د�ޑI��
            grdTableData.Item(intColIndexWhere, 0).Selected = True      '��د�ޑI��
            Menu_Sitei_TextBox.Text = Format(Now, CtrlZTool.clsComFuncFRM.DATE_FORMAT_02)
            Call TextFilterProcess(menmFilterSQLWhere.Over)


            '*******************************************************
            '�~��                   ����
            '*******************************************************
            If 1 < grdTableData.RowCount Then
                '(�\�����Ԃ̌x���ŷ�ݾق����������ꍇ�͕\���͍s��Ȃ�)
                grdTableData.ClearSelection()                               '��د�ޑI��
                grdTableData.Item(intColIndexOrder, 0).Selected = True      '��د�ޑI��
                Call Menu_Asc_ClickProcess(ORDER_BY_DESC)
            End If


        End If


    End Sub
#End Region
#Region "  ��k                         ���ݸد�����        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��k                         ���ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdColInitialize_ClickProcess()


        '********************************************************
        '�񕝂��k�߂�
        '********************************************************
        For ii As Integer = 0 To grdTableData.Columns.Count - 1
            If 120 <= grdTableData.Columns(ii).Width Then
                grdTableData.Columns(ii).Width = 120
            End If
        Next


    End Sub
#End Region
#Region "  ��                         ���ݸد�����        "
    Private Sub cmdPrintProcess()


        '********************************************************************
        'ͯ�ް�����쐬
        '********************************************************************
        Dim strColTerminator As String = GET_CONFIG_INFO(GKEY_G000000_020)
        Dim strRowTerminator As String = GET_CONFIG_INFO(GKEY_G000000_021)
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
        Call DivStringToArray(strHeader, strHeaderArray)
        If IsNothing(strHeaderArray) = False Then
            If 0 <= UBound(strHeaderArray) Then strText05 = strHeaderArray(0)
            If 1 <= UBound(strHeaderArray) Then strText06 = strHeaderArray(1)
            If 2 <= UBound(strHeaderArray) Then strText07 = strHeaderArray(2)
        End If


        '********************************************************************
        '��
        '********************************************************************
        Call CRPrintKaihatu(grdTableData, strTableName, strText01, "", strText05, strText06, strText07, txtTitle.Text)


    End Sub
#End Region
#Region "  SQL                          ���ݸد�����        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL���ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSQLFileProcess()


        '********************************************************************
        '۸�̧�ٕ\��
        '********************************************************************
        Dim strFilePathName As String = ""
        strFilePathName = gcstrLOG_FILE_PATH & gcstrLOG_FILE_NAME       '̧�ٖ�         ���
        Call System.Diagnostics.Process.Start(strFilePathName)


    End Sub
#End Region
#Region "  ̫��                         ���ޕύX����        "
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
#Region "  ���ް��\��                   �����ޯ���ύX����   "
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

        '̫�ѻ��ޕύX����
        Call FormSizeChangedProcess()

    End Sub
#End Region
#Region "  ð��ّI������ޯ��           �ύX����            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ð��ّI������ޯ���ύX����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboTableName_SelectedIndexChangedProcess()
        Dim intRet As RetCode


        '********************************************************************
        '̫�ѕ\�����X�V
        '********************************************************************
        Dim strText As String = cboTableName.Text
        While True
            strText = strText.Replace(Space(2), Space(1))
            If strText.IndexOf(Space(2)) < 0 Then Exit While
        End While
        Me.Text = strText


        '********************************************************************
        '��د�ޏ�����
        '********************************************************************
        grdTableData.DataSource = Nothing
        grdColumnData.DataSource = Nothing


        '********************************************************************
        '�ް���د�ޕ\��(���ް�)
        '********************************************************************
        Call grdColumnDataDisplay(cboTableName.SelectedValue)


        '********************************************************************
        '�ް��\��
        '********************************************************************
        Call cmdDisp_Click(Nothing, Nothing)
        'Call cmdDispProcess()


        '*******************************************************
        '۸�ð��ْ�`��(ð��ٖ�)      �̌�������
        '*******************************************************
        Dim strFieldNameWhere As String = ""         '̨���ޖ�(����)
        Dim strFieldNameOrder As String = ""         '̨���ޖ�(����)
        intRet = SearchLogDispDefine(cboTableName.SelectedValue, strFieldNameWhere, strFieldNameOrder)
        If intRet = RetCode.OK Then
            '(��`�����������ꍇ)


            '*******************************************************
            '۸ޕ\��                      ���ݸد�����
            '�ް��\���������s���Ȃ��ƁA����ɏ�������Ȃ�
            '*******************************************************
            Call cmdLogDisp_ClickProcess()


        End If


        '*******************************************************
        '�����ޯ���I������
        '*******************************************************
        If tsmTableNameSelectAutoCansel.Checked = True Then
            cmdDisp.Focus()
        End If


    End Sub
#End Region


    '�ƭ��ް�����
#Region "  SQL�����s���                        �د�����    "
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
        objFRM_299011.objFRM_299010 = Me            'DB����ݽ°�
        objFRM_299011.Location = Me.Location        '�ʒu�����킹��
        objFRM_299011.Show()                        '�\��
        objFRM_299011.TopMost = True                '��Ɏ�O�ɐݒ�(����O�Ɏ����ė���)
        objFRM_299011.TopMost = False               '��Ɏ�O�ɐݒ����


    End Sub
#End Region
#Region "  �V�K�쐬                             �د�����    "
    Private Sub tsmNewMakeClickProcess(Optional ByVal strDispTableName As String = "")
        Dim objForm As FRM_299010
        objForm = New FRM_299010
        objForm.strDispTableName = strDispTableName
        objForm.Show()
        If Me.WindowState = FormWindowState.Maximized Then
            objForm.WindowState = FormWindowState.Maximized
        End If
    End Sub
#End Region
#Region "  �ް��X�V                             �د�����    "
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
#Region "  �\���X�V                             �د�����    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\���X�V����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmRefreshClickProcess()


        '********************************************************************
        '�\���X�V
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  Select                               �د�����    "
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
        Call cmdDisp_Click(Nothing, Nothing)


    End Sub
#End Region
#Region "  ��ݻ޸��݊J�n                        �د�����    "
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
            gobjDb.BeginTrans()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        '���ٍX�V
        '********************************************************************
        Call lblTransUpdate(TRANS_BEGINTRANS)           '��ݻ޸��ݏ�ԕ\��


    End Sub
#End Region
#Region "  ۰��ޯ��J�n                          �د�����    "
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
            gobjDb.RollBack()
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


        ''********************************************************************
        ''��ݻ޸��݊J�n
        ''********************************************************************
        'Call tsmBeginTransClickProcess()


    End Sub
#End Region
#Region "  �ЯĊJ�n                             �د�����    "
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
            gobjDb.Commit()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        '���ٍX�V
        '********************************************************************
        Call lblTransUpdate(TRANS_NOTRANS)              '��ݻ޸��ݏ�ԕ\��


        ''********************************************************************
        ''��ݻ޸��݊J�n
        ''********************************************************************
        'Call tsmBeginTransClickProcess()


    End Sub
#End Region
#Region "  �ڑ�                                 �د�����    "
    Private Sub tsmConnect_ClickProcess()


        '**************************************************************************
        '�ڑ���ʋN��
        '**************************************************************************
        Dim objFRM_299012 As New FRM_299012
        objFRM_299012.ShowDialog()


        '**************************************************************************
        '̫��۰�ޏ���
        '**************************************************************************
        Call FormLoad(False)


    End Sub
#End Region
#Region "  �ؒf                                 �د�����    "
    Private Sub tsmDisConnect_ClickProcess()

        If IsNull(gobjDb) = False Then
            gobjDb.Disconnect()
            gobjDb = Nothing
        End If

    End Sub
#End Region
#Region "  ð��ّI������ޯ�� ��������          �د�����    "
    Private Sub tsmTableNameSelectAutoCansel_ClickProcess()

        tsmTableNameSelectAutoCansel.Checked = Not (tsmTableNameSelectAutoCansel.Checked)

    End Sub
#End Region
#Region "  ð��ّI������ޯ�� ��ۯ���޳ݽ���    �د�����    "
    Private Sub tsmTableNameDropDownStyle00_ClickProcess(ByVal sender As System.Object)


        '************************************************************
        '
        '************************************************************
        Dim tsmSelect As System.Windows.Forms.ToolStripMenuItem = sender
        Select Case tsmSelect.Name
            Case tsmTableNameDropDownStyle01.Name
                '(��ۯ���޳�ؽđI���̏ꍇ)
                tsmTableNameDropDownStyle01.Checked = True                  '�ƭ��\���X�V
                tsmTableNameDropDownStyle02.Checked = False                 '�ƭ��\���X�V
                cboTableName.DropDownStyle = ComboBoxStyle.DropDownList     '�����ޯ���X�V
            Case tsmTableNameDropDownStyle02.Name
                '(��ۯ���޳ݑI���̏ꍇ)
                tsmTableNameDropDownStyle01.Checked = False                 '�ƭ��\���X�V
                tsmTableNameDropDownStyle02.Checked = True                  '�ƭ��\���X�V
                cboTableName.DropDownStyle = ComboBoxStyle.DropDown         '�����ޯ���X�V
        End Select


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


            mblnCellValueChange = False         '�ْl�ύX�׸�
            mblnRowInsert = False               '�s�ǉ��׸�


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

            ''========================================================
            ''��ʍX�V
            ''========================================================
            'Call cmdDispProcess()

        ElseIf mblnCellValueChange = True Then
            '(�l���X�V����Ă����ꍇ)


            mblnCellValueChange = False         '�ْl�ύX�׸�
            mblnRowInsert = False               '�s�ǉ��׸�


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

            ''========================================================
            ''��ʍX�V
            ''========================================================
            'Call cmdDispProcess()

        End If


        '********************************************************************
        '�s���I�����ꂽ���_�ŁAUPDATE���p��WHERE����쐬����
        '********************************************************************
        mstrSQLUpdateWhere = ""
        If grdTableData.RowCount - 1 <> mintCurrentCellRow Then
            '(�ŏI�s�I���ȊO�̏ꍇ)
            For ii As Integer = 0 To grdColumnData.RowCount - 1
                '(ٰ��:��)

                If grdColumnData.Item(menmListCol.PK, ii).Value = CONSTRAINT_TYPE_PK Then
                    '(��ײ�ذ���̏ꍇ)
                    mstrSQLUpdateWhere &= vbCrLf & "    AND " & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
                    mstrSQLUpdateWhere &= GetStringSQLData(grdTableData.Item(ii, mintCurrentCellRow).Value, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
                End If

            Next
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

            For ii As Integer = 0 To grdTableData.RowCount - 2
                '(ٰ��:��د�ލs���A��ԉ��̍s���ް������݂��Ȃ��̂ŏȂ�)

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
#Region "  �ް���د���ް��߰�ď���                  "
    Private Sub DataPasteProcess()
        Dim blnRet As Boolean = False


        '********************************************************************
        '�F�X����
        '********************************************************************
        If grdTableData.Rows(grdTableData.RowCount - 1).Selected = False Then
            '(�ŏI�s��I�����Ă��Ȃ��ꍇ)
            MsgBox(MSG501, MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If MsgBox(MSG021, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        '�د���ް���ް����擾
        '********************************************************************
        '�د���ް�ނ̓��e���擾
        Dim strClipboardDataText As String = Clipboard.GetText()
        '���s��ϊ�
        strClipboardDataText = strClipboardDataText.Replace(vbCrLf, vbLf)
        strClipboardDataText = strClipboardDataText.Replace(vbCr, vbLf)
        '���s�ŕ���
        Dim strDatalines() As String = Split(strClipboardDataText, vbLf)


        '********************************************************************
        '�د���ް���ް��̓\��t��
        '********************************************************************
        Dim blnError As Boolean = False     '�ǉ��װ�׸�
        For ii As Integer = LBound(strDatalines) To UBound(strDatalines)
            '(ٰ��:�د���ް���ް��̍s��)

            '========================================================
            '�񖈂ɕ���
            '========================================================
            Dim strDataColumnes() As String = Split(strDatalines(ii), vbTab)
            If strDatalines(ii).Replace(Space(1), "").Replace(vbTab, "") = "" Then Exit For '(�Ō�̍s�Ƃ��Ĕ��f)
            If strDataColumnes.Length = 1 Then If IsNull(strDataColumnes(0)) Then Exit For '(�Ō�̍s�Ƃ��Ĕ��f)
            If strDataColumnes.Length <> grdTableData.ColumnCount Then
                '(��د�ނ̗񐔂ƍ����Ă��Ȃ��ꍇ)
                MsgBox(MSG502, MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            '========================================================
            '�ް����
            '========================================================
            For jj As Integer = LBound(strDataColumnes) To UBound(strDataColumnes)
                '(ٰ��:�د���ް���ް��̗�)
                If IsNotNull(strDataColumnes(jj)) Then
                    grdTableData.Item(jj, grdTableData.RowCount - 1).Value = strDataColumnes(jj)
                Else
                    grdTableData.Item(jj, grdTableData.RowCount - 1).Value = System.DBNull.Value
                End If
            Next

            '========================================================
            '�ǉ�����
            '========================================================
            Try
                Call DataInsert(grdTableData.RowCount - 1)
            Catch ex As Exception
                ComError(ex)
                blnError = True
            End Try


        Next


        '********************************************************************
        '��ʍX�V
        '********************************************************************
        If blnError = False Then
            '(����ɑS�Ă��ް����ǉ����ꂽ�ꍇ)
            Call cmdDispProcess()
        End If


    End Sub
#End Region
#Region "  �ް���د��ϳ��޳ݏ���                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د��ϳ��޳ݏ���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_CellMouseDownProcess(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)


        If e.Button = MouseButtons.Right Then
            '(�E�د��̏ꍇ)


            If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
                '(ͯ�ވȊO�̾ق̏ꍇ)


                '********************************************************************
                '�I��ق�ύX����
                '********************************************************************
                grdTableData.ClearSelection()
                grdTableData.Item(e.ColumnIndex, e.RowIndex).Selected = True


                '********************************************************************
                '��ï���ƭ���ύX����
                '********************************************************************
                grdTableData.ContextMenuStrip = ContextMenuStrip1
                Menu_Equal.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_EQUAL_TEXT
                Menu_NotEqual.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_NOTEQUAL_TEXT
                Menu_Contain.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_CONTAIN_TEXT
                Menu_NotContain.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_NOTCONTAIN_TEXT
                Menu_Over.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_OVER_TEXT
                Menu_Under.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_UNDER_TEXT


            Else
                '(ͯ�ނ̏ꍇ)
                grdTableData.ContextMenuStrip = Nothing
            End If


        End If


    End Sub
#End Region

    '�ް���د�޺�ï���ƭ���د�߲���ď���
#Region "  �I��̨������                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �I��̨������
    ''' </summary>
    ''' <param name="intFilterSQLWhere"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ChoiceFilterProcess(ByVal intFilterSQLWhere As menmFilterSQLWhere)


        '********************************************************************
        '�F�X����
        '********************************************************************
        If grdTableData.SelectedCells.Count = 0 Then
            MsgBox(MSG503, MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If 1 < grdTableData.SelectedCells.Count Then
            MsgBox(MSG504, MsgBoxStyle.OkOnly)
            Exit Sub
        End If


        '********************************************************************
        '�\��
        '********************************************************************
        Dim intRIndex As Integer = grdTableData.SelectedCells(0).RowIndex       '�I��ٍs���ޯ��
        Dim intCIndex As Integer = grdTableData.SelectedCells(0).ColumnIndex    '�I��ٗ���ޯ��
        Call FilterSQLWhereMakeProcess(intFilterSQLWhere _
                                     , grdColumnData.Item(menmListCol.COLUMN_NAME, intCIndex).Value _
                                     , grdColumnData.Item(menmListCol.DATA_TYPE, intCIndex).Value _
                                     , TO_STRING(grdTableData.Item(intCIndex, intRIndex).Value) _
                                     )


        '********************************************************************
        '�F�X������
        '********************************************************************
        '��ͯ�ސF����
        If grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_BLUE Then
            '(���ёւ���̏ꍇ)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE
        ElseIf grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE Then
            '(���ёւ�and̨����̏ꍇ)
            'NOP
        Else
            '(�������Ă��Ȃ��ꍇ)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_RED
        End If


    End Sub
#End Region
#Region "  ÷��̨������                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÷��̨������
    ''' </summary>
    ''' <param name="intFilterSQLWhere"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TextFilterProcess(ByVal intFilterSQLWhere As menmFilterSQLWhere)


        '********************************************************************
        '�F�X����
        '********************************************************************
        If grdTableData.SelectedCells.Count = 0 Then
            MsgBox(MSG503, MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If 1 < grdTableData.SelectedCells.Count Then
            MsgBox(MSG504, MsgBoxStyle.OkOnly)
            Exit Sub
        End If


        '********************************************************************
        '�\��
        '********************************************************************
        Dim intRIndex As Integer = grdTableData.SelectedCells(0).RowIndex       '�I��ٍs���ޯ��
        Dim intCIndex As Integer = grdTableData.SelectedCells(0).ColumnIndex    '�I��ٗ���ޯ��
        Call FilterSQLWhereMakeProcess(intFilterSQLWhere _
                                     , grdColumnData.Item(menmListCol.COLUMN_NAME, intCIndex).Value _
                                     , grdColumnData.Item(menmListCol.DATA_TYPE, intCIndex).Value _
                                     , Menu_Sitei_TextBox.Text _
                                     )


        '********************************************************************
        '�F�X������
        '********************************************************************
        Menu_Sitei_TextBox.Text = ""
        '��ͯ�ސF����
        If grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_BLUE Then
            '(���ёւ���̏ꍇ)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE
        ElseIf grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE Then
            '(���ёւ�and̨����̏ꍇ)
            'NOP
        Else
            '(�������Ă��Ȃ��ꍇ)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_RED
        End If


    End Sub
#End Region
#Region "  ̨��SQL�� Where��쐬����                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̨��SQL�� Where��쐬����
    ''' </summary>
    ''' <param name="intFilterSQLWhere"></param>
    ''' <param name="strColumnName"></param>
    ''' <param name="strColumnDataType"></param>
    ''' <param name="strDataValue"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FilterSQLWhereMakeProcess(ByVal intFilterSQLWhere As menmFilterSQLWhere _
                                        , ByVal strColumnName As String _
                                        , ByVal strColumnDataType As String _
                                        , ByVal strDataValue As String _
                                        )


        '********************************************************************
        'SQL��Where�啔���쐬
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL��
        Select Case intFilterSQLWhere
            Case menmFilterSQLWhere.Equal
                If IsNotNull(strDataValue) Then
                    strSQLWhere &= vbCrLf & "    AND " & strColumnName & " IN ( "
                    strSQLWhere &= GetStringSQLData(strDataValue, strColumnDataType) & " )"
                Else
                    strSQLWhere &= vbCrLf & "    AND " & strColumnName & " IS NULL "
                End If
            Case menmFilterSQLWhere.NotEqual
                If IsNotNull(strDataValue) Then
                    strSQLWhere &= vbCrLf & "    AND " & strColumnName & " NOT IN ( "
                    strSQLWhere &= GetStringSQLData(strDataValue, strColumnDataType) & " )"
                Else
                    strSQLWhere &= vbCrLf & "    AND " & strColumnName & " IS NOT NULL "
                End If
            Case menmFilterSQLWhere.Contain
                strSQLWhere &= vbCrLf & "    AND INSTR(" & strColumnName & " , "
                strSQLWhere &= "'" & strDataValue & "') > 0"
            Case menmFilterSQLWhere.NotContain
                strSQLWhere &= vbCrLf & "    AND INSTR(" & strColumnName & " , "
                strSQLWhere &= "'" & strDataValue & "') = 0"
            Case menmFilterSQLWhere.Over
                strSQLWhere &= vbCrLf & "    AND " & strColumnName & " >= "
                strSQLWhere &= GetStringSQLData(strDataValue, strColumnDataType)
            Case menmFilterSQLWhere.Under
                strSQLWhere &= vbCrLf & "    AND " & strColumnName & " <= "
                strSQLWhere &= GetStringSQLData(strDataValue, strColumnDataType)
        End Select


        '********************************************************************
        '�\�����ݸد�����
        '********************************************************************
        mstrSQLFilterWhere &= strSQLWhere
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  ̨��SQL�� OrderBy��쐬����              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strSort">����or�~���̎w��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Asc_ClickProcess(ByVal strSort As String)
        Dim intRIndex As Integer = grdTableData.SelectedCells(0).RowIndex       '�I��ٍs���ޯ��
        Dim intCIndex As Integer = grdTableData.SelectedCells(0).ColumnIndex    '�I��ٗ���ޯ��
        Dim strOrderAsc As String = grdColumnData.Item(menmListCol.COLUMN_NAME, intCIndex).Value & ORDER_BY_ASC     '����
        Dim strOrderDesc As String = grdColumnData.Item(menmListCol.COLUMN_NAME, intCIndex).Value & ORDER_BY_DESC   '�~��


        '********************************************************************
        '�ǉ��pOrderBy��쐬
        '********************************************************************
        Dim strOrderBy As String        'OrderBy��
        Select Case strSort
            Case ORDER_BY_ASC : strOrderBy = strOrderAsc
            Case ORDER_BY_DESC : strOrderBy = strOrderDesc
            Case Else : Throw New Exception("�������s���ł��B")
        End Select


        '********************************************************************
        '�d������
        '********************************************************************
        For ii As Integer = LBound(mstrSQLFilterAryOrder) To UBound(mstrSQLFilterAryOrder)
            '(ٰ��:���܂ł̏����~���̋L�^)
            If mstrSQLFilterAryOrder(ii) = strOrderAsc Or mstrSQLFilterAryOrder(ii) = strOrderDesc Then
                '(�ȑO�ɓ�����ŕ��ёւ����Ă����ꍇ)
                mstrSQLFilterAryOrder(ii) = Nothing
            End If
        Next


        '********************************************************************
        '̨����pSQL��OrderBy��(�z��)�X�V
        '********************************************************************
        ReDim Preserve mstrSQLFilterAryOrder(UBound(mstrSQLFilterAryOrder) + 1)           '�v�f�ǉ�
        mstrSQLFilterAryOrder(UBound(mstrSQLFilterAryOrder)) = strOrderBy                 'OrderBy�徯�


        '********************************************************************
        '̨����pSQL��OrderBy��쐬
        '********************************************************************
        mstrSQLFilterOrder = Space(6) & mstrSQLFilterAryOrder(UBound(mstrSQLFilterAryOrder))    '�ŏI�v�f�ɂ͕K���l�������Ă���͂�
        For ii As Integer = UBound(mstrSQLFilterAryOrder) - 1 To LBound(mstrSQLFilterAryOrder) Step -1
            '(ٰ��:���܂ł̏����~���̋L�^)
            If IsNotNull(mstrSQLFilterAryOrder(ii)) Then
                mstrSQLFilterOrder &= vbCrLf & Space(5) & "," & mstrSQLFilterAryOrder(ii)
            End If
        Next


        '********************************************************************
        '�F�X������
        '********************************************************************
        '============================================
        '��ͯ�ސF����
        '============================================
        If grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_RED Then
            '(̨����̏ꍇ)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE
        ElseIf grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE Then
            '(���ёւ�and̨����̏ꍇ)
            'NOP
        Else
            '(�������Ă��Ȃ��ꍇ)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_BLUE
        End If
        '============================================
        '��ͯ��÷�Ē���
        '============================================
        grdTableData.Columns(intCIndex).HeaderText = grdTableData.Columns(intCIndex).HeaderText.Replace("��", "")
        grdTableData.Columns(intCIndex).HeaderText = grdTableData.Columns(intCIndex).HeaderText.Replace("��", "")
        grdTableData.Columns(intCIndex).HeaderText = grdTableData.Columns(intCIndex).HeaderText.Replace("��", "")
        grdTableData.Columns(intCIndex).HeaderText = grdTableData.Columns(intCIndex).HeaderText.Replace("��", "")
        Select Case strSort
            Case ORDER_BY_ASC : grdTableData.Columns(intCIndex).HeaderText &= "��"
            Case ORDER_BY_DESC : grdTableData.Columns(intCIndex).HeaderText &= "��"
            Case Else : Throw New Exception("�������s���ł��B")
        End Select
        For ii As Integer = 0 To grdTableData.Columns.Count - 1
            If ii = intCIndex Then Continue For
            grdTableData.Columns(ii).HeaderText = grdTableData.Columns(ii).HeaderText.Replace("��", "��")
            grdTableData.Columns(ii).HeaderText = grdTableData.Columns(ii).HeaderText.Replace("��", "��")
        Next


        '********************************************************************
        '�\�����ݸد�����
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  ÷���ޯ��      ����ٸد�                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÷���ޯ��      ����ٸد�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_TextBox_DoubleClickProcess()
        Dim intDiffMin As Integer = TO_INTEGER(GET_CONFIG_INFO(GKEY_G000000_041))


        If IsNull(Menu_Sitei_TextBox.Text) Then
            '(�����ް����ݒ肳��Ă��Ȃ��ꍇ)


            '********************************************************************
            '���t��ݒ�
            '********************************************************************
            Dim dtmTemp As Date = Now.AddMinutes(-intDiffMin)
            Menu_Sitei_TextBox.Text = Format(dtmTemp, CtrlZTool.clsComFuncFRM.DATE_FORMAT_03)


        ElseIf IsDate(Menu_Sitei_TextBox.Text) Then
            '(���t�^���ް����ݒ肳��Ă����ꍇ)


            '********************************************************************
            '�����b���폜
            '********************************************************************
            Dim dtmTemp As Date = TO_DATE(Menu_Sitei_TextBox.Text)
            Menu_Sitei_TextBox.Text = Format(dtmTemp, CtrlZTool.clsComFuncFRM.DATE_FORMAT_02)


        End If


    End Sub
#End Region

    '�����֐�(DB����)
#Region "�@����������                               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ����������
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub InitializeProcess()


        '*******************************************************
        ' ��ʗp��Ű��޼ު�č쐬
        '*******************************************************
        gobjOwner = New clsOwner                 ' ��ʗp��Ű��޼ު��


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
        Dim blnRet As Boolean
        gobjDb = New clsConnZTool(gobjOwner)
        gobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
        blnRet = gobjDb.Connect()     '�ڑ�
        If blnRet = False Then
            Throw New Exception("DB�ڑ��Ɏ��s���܂����B")
        End If


        '**********************************************************
        'Config & ���ѕϐ�  �ް��擾
        '**********************************************************
        '���۸ޗp
        gcstrLOG_FILE_PATH = GET_CONFIG_INFO(GKEY_G000000_031)                           '���۸�̧�يi�[�ꏊ
        gcstrLOG_FILE_NAME = GET_CONFIG_INFO(GKEY_G000000_005)                           '̧�ٖ�
        gcstrLOG_FILE_NAME_OLD = GET_CONFIG_INFO(GKEY_G000000_006)                       '̧�ٖ�(�Â�)
        gcstrLOG_FILE_SIZE = GET_CONFIG_INFO(GKEY_G000000_007)                           '�ő�̧�ٻ���
        gcstrLOG_FILE_SIZE = TO_NUMBER(gcstrLOG_FILE_SIZE) * 1000000                     'Byte �� MByte


        '*******************************************************
        ' �N��۸ޏ�����
        '*******************************************************
        Call AddToLog_frm(Application.ExecutablePath & "  �N��")


        '********************************************************************
        '۸�ð��ٕ\����`   �yð��ٖ��z@@@�y̨���ޖ��z
        '********************************************************************
        Dim strAryTemp01() As String = Split(TO_STRING(GET_CONFIG_INFO(GKEY_G000000_061)), ",")         '۸�ð��ٕ\����`(������)
        ReDim mobjAryLogDispConfig(UBound(strAryTemp01))                                                '۸�ð��ٕ\����`
        For ii As Integer = 0 To strAryTemp01.Length - 1
            '(ٰ��:۸�ð��ٕ\����`��)

            strAryTemp01(ii) = strAryTemp01(ii).Replace(vbCrLf, "")
            strAryTemp01(ii) = RTrim(strAryTemp01(ii))
            strAryTemp01(ii) = LTrim(strAryTemp01(ii))
            Dim strAryTemp02() As String = Split(strAryTemp01(ii), TO_STRING(GET_CONFIG_INFO(GKEY_G000000_062)))        '۸�ð��ٕ\����`(������)
            mobjAryLogDispConfig(ii).strTableName = strAryTemp02(0)         'ð��ٖ�
            mobjAryLogDispConfig(ii).strFieldNameWhere = strAryTemp02(1)    '̨���ޖ�(����)
            mobjAryLogDispConfig(ii).strFieldNameOrder = strAryTemp02(2)    '̨���ޖ�(����)

        Next


    End Sub
#End Region
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
        gobjDb.SQL = strSQL
        strDataSetName01 = "TABLE"
        objDataSet01.Clear()
        gobjDb.GetDataSet(strDataSetName01, objDataSet01)


        '********************************************************************
        '�s�ް��擾
        '********************************************************************
        If objDataSet01.Tables(strDataSetName01).Rows.Count > 0 Then
            Dim objDataTable As New clsGridDataTable20          '�ް�ð���
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
                strSQL &= vbCrLf & "   ,USER_COL_COMMENTS.COMMENTS "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_TYPE "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.NULLABLE "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_LENGTH "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_PRECISION "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_SCALE "
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
                gobjDb.SQL = strSQL
                gobjDb.Parameter = objParameter
                strDataSetName02 = "COLUMNS"
                objDataSet02.Clear()
                gobjDb.GetDataSet(strDataSetName02, objDataSet02)
                Dim strCOLUMN_NAME As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("COLUMN_NAME"))          '��
                Dim strCOMMENTS As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("COMMENTS"))                '����
                Dim strDATA_TYPE As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_TYPE"))              '����
                Dim strNN As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("NULLABLE"))                      'NULLABLE
                Dim strDATA_LENGTH As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_LENGTH"))          '��̒���
                Dim strDATA_PRECISION As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_PRECISION"))    '���x
                Dim strDATA_SCALE As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_SCALE"))            '���l�̏����_�ȉ��̌�
                If IsNotNull(strDATA_PRECISION) Then strDATA_LENGTH = strDATA_PRECISION
                If strNN <> "N" Then strNN = ""

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
                gobjDb.SQL = strSQL
                gobjDb.Parameter = objParameter
                strDataSetName02 = "PK"
                objDataSet02.Clear()
                gobjDb.GetDataSet(strDataSetName02, objDataSet02)
                If objDataSet02.Tables(strDataSetName02).Rows.Count > 0 Then
                    strPK = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("CONSTRAINT_TYPE"))      '��ײ�ذ��
                End If

                '=====================================================
                '�ް�ð��قɒǉ�
                '=====================================================
                objDataTable.userAddRowDataSet(strCOLUMN_NAME _
                                             , strCOMMENTS _
                                             , strDATA_TYPE _
                                             , strDATA_LENGTH _
                                             , strDATA_PRECISION _
                                             , strDATA_SCALE _
                                             , strPK _
                                             , strNN _
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
        '' ''grdTableData.RowHeadersVisible = False                                     '�sͯ�ް�\��        ���ݒ�
        grdTableData.AllowUserToResizeRows = False                                      '�s�̻��ޕύX       ���ݒ�
        '' ''grdTableData.AllowUserToResizeColumns = False                              '��̻��ޕύX       ���ݒ�
        '' ''grdTableData.MultiSelect = False                                           '�����ٓ����I��     ���ݒ�
        grdTableData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect          '�I��Ӱ��
        '' ''grdTableData.AllowUserToAddRows = False                                    '�s�ǉ�             ���ݒ�
        '' ''grdTableData.AllowUserToDeleteRows = False                                 '�s�폜             ���ݒ�
        grdTableData.AllowUserToOrderColumns = True                                     '��ړ�             ���ݒ�
        grdTableData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)        '��̕���������
        grdTableData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText      '�د���ް�ނւ̺�߰�ݒ�
        For Each objColum As DataGridViewColumn In grdTableData.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '��̕��֋֎~
        Next
        'grdTableData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0)          '��ͯ�ޔw�i�F
        'grdTableData.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0)    '��ͯ�ޕ����F


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
        grdColumnData.MultiSelect = True                                          '�����ٓ����I��     ���ݒ�
        grdColumnData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect   '�I��Ӱ��
        grdColumnData.AllowUserToAddRows = False                                  '�s�ǉ�             ���ݒ�
        grdColumnData.AllowUserToDeleteRows = False                               '�s�폜             ���ݒ�
        grdColumnData.AllowUserToResizeRows = False                               '�s���ޕύX         ���ݒ�
        grdColumnData.AllowUserToOrderColumns = False                             '��ړ�             ���ݒ�
        For Each objColum As DataGridViewColumn In grdColumnData.Columns
            objColum.SortMode = DataGridViewColumnSortMode.Programmatic     '��̕��֋֎~
        Next
        grdColumnData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText     '�د���ް�ނւ̺�߰�ݒ�


        '***********************
        'ͯ�ް�\���ύX
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).HeaderText = "��"
        grdColumnData.Columns(menmListCol.COMMENTS).HeaderText = "����"
        grdColumnData.Columns(menmListCol.DATA_TYPE).HeaderText = "����"
        grdColumnData.Columns(menmListCol.DATA_LENGTH).HeaderText = "��̒���"
        grdColumnData.Columns(menmListCol.DATA_PRECISION).HeaderText = "���x"
        grdColumnData.Columns(menmListCol.DATA_SCALE).HeaderText = "�����_����"
        grdColumnData.Columns(menmListCol.PK).HeaderText = "PK"
        grdColumnData.Columns(menmListCol.NN).HeaderText = "NN"


        '***********************
        '�ް����z�u�ύX
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.COMMENTS).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.DATA_TYPE).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.DATA_LENGTH).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdColumnData.Columns(menmListCol.DATA_PRECISION).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdColumnData.Columns(menmListCol.DATA_SCALE).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdColumnData.Columns(menmListCol.PK).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdColumnData.Columns(menmListCol.NN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        '***********************
        '��\��
        '***********************
        grdColumnData.Columns(menmListCol.DATA_PRECISION).Visible = False
        grdColumnData.Columns(menmListCol.Data08).Visible = False
        grdColumnData.Columns(menmListCol.Data09).Visible = False
        grdColumnData.Columns(menmListCol.Data10).Visible = False
        grdColumnData.Columns(menmListCol.Data11).Visible = False
        grdColumnData.Columns(menmListCol.Data12).Visible = False
        grdColumnData.Columns(menmListCol.Data13).Visible = False
        grdColumnData.Columns(menmListCol.Data14).Visible = False
        grdColumnData.Columns(menmListCol.Data15).Visible = False
        grdColumnData.Columns(menmListCol.Data16).Visible = False
        grdColumnData.Columns(menmListCol.Data17).Visible = False
        grdColumnData.Columns(menmListCol.Data18).Visible = False
        grdColumnData.Columns(menmListCol.Data19).Visible = False
        grdColumnData.Columns(menmListCol.Data20).Visible = False


        '***********************
        '�񕝒���
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).Width = 120
        grdColumnData.Columns(menmListCol.COMMENTS).Width = 129
        grdColumnData.Columns(menmListCol.DATA_TYPE).Width = 80
        grdColumnData.Columns(menmListCol.DATA_LENGTH).Width = 30
        grdColumnData.Columns(menmListCol.DATA_PRECISION).Width = 30
        grdColumnData.Columns(menmListCol.DATA_SCALE).Width = 30
        grdColumnData.Columns(menmListCol.PK).Width = 20
        grdColumnData.Columns(menmListCol.NN).Width = 20


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

            Dim strValue As String = TO_STRING(grdTableData.Item(ii, intRow).EditedFormattedValue)
            If strValue = "" Then
                strSQLValue &= vbCrLf & "    ,Null"
            Else
                strSQLValue &= vbCrLf & "    ," & GetStringSQLData(strValue, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If

            If ii = 0 Then
                strSQLValue = Replace(strSQLValue, vbCrLf, "")
                strSQLValue = Replace(strSQLValue, ",", " ", 1, 1)
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
        intRetSQL = gobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_ADD & gobjDb.ErrMsg & "�y" & strSQL & "�z"
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
        strSQL &= strSQLWhere
        strSQL &= vbCrLf
        intRetSQL = gobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_ADD & gobjDb.ErrMsg & "�y" & strSQL & "�z"
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
                strSQLSet = Replace(strSQLSet, ",", " ", 1, 1)
            End If

        Next


        ''********************************************************************
        ''SQL��Where�啔���쐬
        ''********************************************************************
        'Dim strSQLWhere As String = ""                    'SQL��
        'For ii As Integer = 0 To grdColumnData.RowCount - 1
        '    '(ٰ��:��)

        '    If grdColumnData.Item(menmListCol.PK, ii).Value = CONSTRAINT_TYPE_PK Then
        '        '(��ײ�ذ���̏ꍇ)
        '        strSQLWhere &= vbCrLf & "    AND " & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
        '        strSQLWhere &= GetStringSQLData(grdTableData.Item(ii, intRow).Value, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
        '    End If

        'Next


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
        strSQL &= mstrSQLUpdateWhere
        'strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        intRetSQL = gobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_ADD & gobjDb.ErrMsg & "�y" & strSQL & "�z"
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
    '�����֐�(���̑�)
#Region "�@۸�ð��ٕ\����`��(ð��ٖ�)  �̌�������  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸�ð��ٕ\����`��(ð��ٖ�)      �̌�������
    ''' </summary>
    ''' <param name="strTableName">۸�ð��ٕ\����`��(ð��ٖ�)</param>
    ''' <param name="strFieldNameWhere">۸�ð��ٕ\����`��(̨���ޖ�(����))</param>
    ''' <param name="strFieldNameOrder">۸�ð��ٕ\����`��(̨���ޖ�(����))</param>
    ''' <returns>
    ''' OK :��`����
    ''' NO:��`�Ȃ�
    ''' </returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SearchLogDispDefine(ByVal strTableName As String _
                                       , Optional ByRef strFieldNameWhere As String = "" _
                                       , Optional ByRef strFieldNameOrder As String = "" _
                                       ) _
                                       As RetCode
        Dim intReturn As RetCode = RetCode.NotFound     '�߂�l


        '*******************************************************
        '۸�ð��ٕ\����`��ٰ��
        '*******************************************************
        For Each objLogDispConfig As strcLogDispConfig In mobjAryLogDispConfig
            '(ٰ��:۸�ð��ٕ\����`��)


            '*******************************************************
            'ð��ٖ������������ꍇ
            '*******************************************************
            If strTableName = objLogDispConfig.strTableName Then
                '(۸�ð��ٕ\����`����Ă����ꍇ)
                strFieldNameWhere = objLogDispConfig.strFieldNameWhere
                strFieldNameOrder = objLogDispConfig.strFieldNameOrder
                intReturn = RetCode.OK
                Exit For
            End If


        Next


        Return intReturn
    End Function
#End Region
#Region "  ۸�ð��ٕ\����`��(̨���ޖ�) �̌�������  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸�ð��ٕ\����`��(̨���ޖ�)     �̌�������
    ''' </summary>
    ''' <param name="strFieldName">۸�ð��ٕ\����`��(̨���ޖ�)</param>
    ''' <param name="intColIndex">̨���ނ̗���ޯ��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchFieldIndex(ByVal strFieldName As String _
                               , ByRef intColIndex As Integer _
                               )


        '*******************************************************
        'ð��ق̗�ٰ��
        '*******************************************************
        For jj As Integer = 0 To grdColumnData.ColumnCount - 1
            '(ٰ��:ð��ق̗�)


            '*******************************************************
            '̨���ޖ������������ꍇ
            '*******************************************************
            If grdColumnData.Item(menmListCol.COLUMN_NAME, jj).Value = strFieldName Then
                '(̨���ނ���v���Ă����ꍇ)

                intColIndex = jj
                Exit For

            End If


            If jj = (grdColumnData.ColumnCount - 1) Then Throw New Exception("Confiģ�ق�۸�ð��ٕ\����`���s���ł��B̨���ޖ���������܂���B")
        Next


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
            Call ComError_frm(objException)
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class