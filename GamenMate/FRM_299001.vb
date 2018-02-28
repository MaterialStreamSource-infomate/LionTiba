'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z��ݻ޸���۸މ��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                                      "
Imports MateCommon
Imports MateCommon.clsConst
Imports MateCommon.mdlComFunc
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_299001

#Region "�@���ʕϐ��@                                   "

    '���������p�\����
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

#Region "  �񋓑́@                                     "
    ''' <summary>���������ꍇ����</summary>
    Enum menmCheckCase
        Search_Click        '�������ݸد���
    End Enum

    ''' <summary>��د�ލ���</summary>
    Enum menmListCol
        FLOG_NO_CYCLIC                  '��ݻ޸���۸�.      ���د�۸އ�
        FHASSEI_DT                      '��ݻ޸���۸�.      ��������
        FUSER_ID                         '��ݻ޸���۸�.      հ�ްID
        FTERM_ID                        '��ݻ޸���۸�.      �[��ID
        FSYORI_ID                       '��ݻ޸���۸�.      ����ID
        FMSG_PRM1                       '��ݻ޸���۸�.      ���Ұ�1
        FMSG_PRM2                       '��ݻ޸���۸�.      ���Ұ�2
        FMSG_PRM3                       '��ݻ޸���۸�.      ���Ұ�3
        FMSG_PRM4                       '��ݻ޸���۸�.      ���Ұ�4
        FMSG_PRM5                       '��ݻ޸���۸�.      ���Ұ�5
        FLOG_DATA_TRN                   '��ݻ޸���۸�.      ��ݻ޸���۸��ް�

        MAXCOL

    End Enum

#End Region

#End Region
#Region "  �\���̒�`                                   "
    ''' <summary>��������</summary>
    Private Structure SEARCH_ITEM
        Dim FHASSEI_DT_FROM As String           '��������(FROM)
        Dim FHASSEI_DT_TO As String             '��������(TO)
        Dim FUSER_ID As String                   'հ�ްID
        Dim FTERM_ID As String                  '�[��ID
        Dim FSYORI_ID As String                 '����ID
        Dim FMSG_PRM1 As String                 '���Ұ�1
        Dim FMSG_PRM2 As String                 '���Ұ�2
        Dim FMSG_PRM3 As String                 '���Ұ�3
        Dim FMSG_PRM4 As String                 '���Ұ�4
        Dim FMSG_PRM5 As String                 '���Ұ�5
        Dim FLOG_DATA_TRN As String             '��ݻ޸���۸��ް�

    End Structure
#End Region
#Region "�@�����                                        "
#Region "�@̫��۰��                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call FormLoad()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@̫�ѱ�۰��                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѱ�۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299001_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Call FormClose()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�\������                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\������
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
#Region "�@��������                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try
            Call cmdCloseProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region

#Region "  ̫��۰�ޏ���                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()

        '****************************************
        '����Enable
        '****************************************
        cmdDisp.Enabled = True    '�\������
        cmdClose.Enabled = True    '��������

        '****************************************
        '����           ���
        '****************************************
        Call dtpKikanFromToSetup(dtpDate_From, dtpTime_From, dtpDate_To, dtpTime_To)

        '****************************************
        'հ�ްID���� ���
        '****************************************
        Call cboEnpMake(cboFUSER_ID)

        '****************************************
        '�[��ID����     ���
        '****************************************
        Call cboTermMake(cboFTERM_ID)

        '****************************************
        '����ID����     ���
        '****************************************
        Call cboSyoriMake(cboFSYORI_ID)

        '****************************************
        '��د�ޏ����ݒ�
        '****************************************
        grdList.ColumnCount = menmListCol.MAXCOL
        Call grdListSetup(grdList)

    End Sub
#End Region
#Region "�@̫�Ѹ۰�ޏ���                                "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ̫�Ѹ۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub FormClose()

    End Sub
#End Region
#Region "�@�\�����ݸد�����                             "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' �\�����ݸد����� 
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cmdDispProcess()

        '**********************************
        '�\���̾��
        '**********************************
        Call SearchItem_Set()

        '**********************************
        '��د�ޕ\��
        '**********************************
        Call grdListDisplay()

    End Sub
#End Region
#Region "�@�������ݸد�����                           "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' �������ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cmdCloseProcess()

        '**********************************
        '��ʏI��
        '**********************************
        Me.Close()

    End Sub
#End Region
#Region "�@�ް���د�ޕ\���@                             "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޕ\��
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub grdListDisplay()

        Dim strSQL As String                        'SQL��
        Dim blnDispOkFlg As Boolean = True          '�\�����邩�ǂ������׸�

        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     TLOG_TRNS.FLOG_NO_CYCLIC "                                 '��ݻ޸���۸�.      ���د�۸އ�
        strSQL &= vbCrLf & "   , TO_CHAR(TLOG_TRNS.FHASSEI_DT,'YYYY/MM/DD HH24:MI:SS') "    '��ݻ޸���۸�.      ��������
        strSQL &= vbCrLf & "   , TLOG_TRNS.FUSER_ID "                                        '��ݻ޸���۸�.      հ�ްID
        strSQL &= vbCrLf & "   , TLOG_TRNS.FTERM_ID "                                       '��ݻ޸���۸�.      �[��ID
        strSQL &= vbCrLf & "   , TLOG_TRNS.FSYORI_ID "                                      '��ݻ޸���۸�.      ����ID
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM1 "                                      '��ݻ޸���۸�.      ���Ұ�1
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM2 "                                      '��ݻ޸���۸�.      ���Ұ�2
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM3 "                                      '��ݻ޸���۸�.      ���Ұ�3
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM4 "                                      '��ݻ޸���۸�.      ���Ұ�4
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM5 "                                      '��ݻ޸���۸�.      ���Ұ�5
        strSQL &= vbCrLf & "   , TLOG_TRNS.FLOG_DATA_TRN "                                  '��ݻ޸���۸�.      ��ݻ޸���۸��ް�
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TLOG_TRNS "
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        '--------------------------
        '����
        '--------------------------
        'FROM
        If mudtSEARCH_ITEM.FHASSEI_DT_FROM <> "" And IsDate(mudtSEARCH_ITEM.FHASSEI_DT_FROM) Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FHASSEI_DT >= TO_DATE('" & mudtSEARCH_ITEM.FHASSEI_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"          '���ڰ���۸�.     ��������
        End If
        'TO
        If mudtSEARCH_ITEM.FHASSEI_DT_TO <> "" And IsDate(mudtSEARCH_ITEM.FHASSEI_DT_TO) Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FHASSEI_DT <= TO_DATE('" & mudtSEARCH_ITEM.FHASSEI_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"            '���ڰ���۸�.     ��������
        End If
        '--------------------------
        'հ�ްID
        '--------------------------
        If mudtSEARCH_ITEM.FUSER_ID <> "" And mudtSEARCH_ITEM.FUSER_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FUSER_ID = '" & mudtSEARCH_ITEM.FUSER_ID & "' "
        End If
        '--------------------------
        '�[��ID
        '--------------------------
        If mudtSEARCH_ITEM.FTERM_ID <> "" And mudtSEARCH_ITEM.FTERM_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FTERM_ID = '" & mudtSEARCH_ITEM.FTERM_ID & "' "
        End If
        '--------------------------
        '����ID
        '--------------------------
        If mudtSEARCH_ITEM.FSYORI_ID <> "" And mudtSEARCH_ITEM.FSYORI_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FSYORI_ID = '" & mudtSEARCH_ITEM.FSYORI_ID & "' "
        End If
        '--------------------------
        'ү�������Ұ�1�`5
        '--------------------------
        If mudtSEARCH_ITEM.FMSG_PRM1 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM1 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM1 & "%' "
        End If
        If mudtSEARCH_ITEM.FMSG_PRM2 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM2 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM2 & "%' "
        End If
        If mudtSEARCH_ITEM.FMSG_PRM3 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM3 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM3 & "%' "
        End If
        If mudtSEARCH_ITEM.FMSG_PRM4 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM4 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM4 & "%' "
        End If
        If mudtSEARCH_ITEM.FMSG_PRM5 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM5 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM5 & "%' "
        End If
        '--------------------------
        '��ݻ޸���۸��ް�
        '--------------------------
        If mudtSEARCH_ITEM.FLOG_DATA_TRN <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FLOG_DATA_TRN LIKE '%" & mudtSEARCH_ITEM.FLOG_DATA_TRN & "%' "
        End If


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     TLOG_TRNS.FHASSEI_DT DESC "              '��ݻ޸���۸�.      ��������(�~��)
        strSQL &= vbCrLf & "   , TLOG_TRNS.FLOG_NO_CYCLIC "                         '��ݻ޸���۸�.      ���د�۸އ�(����)
        strSQL &= vbCrLf

        '============================================================
        '�\����������
        '============================================================
        '�\��������������(�����������ꍇ��ү���ޕ\��)
        Call ChckDataCount(strSQL, blnDispOkFlg)
        '�\�������׸ނ�False�̏ꍇ�͕\�����Ȃ��B
        If blnDispOkFlg = False Then
            Exit Sub
        End If

        '********************************************************************
        '�ް���Ď擾
        '********************************************************************
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�
        gobjDb.SQL = strSQL
        strDataSetName = "TLOG_TRNS"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        '********************************************************************
        '��د�ޕ\��
        '********************************************************************
        grdList.Columns.Clear()
        '�ް�����ر
        If IsNull(grdList.DataSource) = False Then
            grdList.DataSource.Rows.Clear()
            grdList.DataSource.Dispose()
            grdList.DataSource = Nothing
        End If
        grdList.DataSource = objDataSet.Tables(strDataSetName)
        objDataSet = Nothing

        '********************************************************************
        '��د�ޕ\���ݒ�
        '********************************************************************
        Call grdListSetup(grdList)


    End Sub
#End Region
#Region "�@�ް���د�ޕ\���ݒ�                           "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޕ\���ݒ�
    ''' </summary>
    ''' <param name="objGrid">�ݒ肷���د�޵�޼ު��</param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub grdListSetup(ByRef objGrid As DataGridView)

        '***********************
        '�����ݒ�
        '***********************
        objGrid.RowHeadersVisible = False                                   '�sͯ�ް�\��        ���ݒ�
        objGrid.AllowUserToResizeColumns = True                             '��̻��ޕύX       ���ݒ�
        objGrid.MultiSelect = False                                         '�����ٓ����I��     ���ݒ�
        objGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect     '�I��Ӱ��
        objGrid.AllowUserToAddRows = False                                  '�s�ǉ�             ���ݒ�
        objGrid.AllowUserToDeleteRows = False                               '�s�폜             ���ݒ�
        objGrid.AllowUserToResizeRows = False                               '�s���ޕύX         ���ݒ�
        objGrid.AllowUserToOrderColumns = False                             '��ړ�             ���ݒ�
        For Each objColum As DataGridViewColumn In objGrid.Columns
            objColum.SortMode = DataGridViewColumnSortMode.Programmatic     '��̕��֋֎~
        Next
        objGrid.ReadOnly = True                                             '��د�ޓǎ��p�ݒ�

        '***********************
        'ͯ�ް�\���ύX
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO_CYCLIC).HeaderText = "���د�۸އ�"                '��ݻ޸���۸�.      ���د�۸އ�
        objGrid.Columns(menmListCol.FHASSEI_DT).HeaderText = "��������"                       '��ݻ޸���۸�.      ��������
        objGrid.Columns(menmListCol.FUSER_ID).HeaderText = "հ�ްID"                        '��ݻ޸���۸�.      հ�ްID
        objGrid.Columns(menmListCol.FTERM_ID).HeaderText = "�[��ID"                           '��ݻ޸���۸�.      �[��ID
        objGrid.Columns(menmListCol.FSYORI_ID).HeaderText = "����ID"                          '��ݻ޸���۸�.      ����ID
        objGrid.Columns(menmListCol.FMSG_PRM1).HeaderText = "���Ұ�1"                         '��ݻ޸���۸�.      ���Ұ�1
        objGrid.Columns(menmListCol.FMSG_PRM2).HeaderText = "���Ұ�2"                         '��ݻ޸���۸�.      ���Ұ�2
        objGrid.Columns(menmListCol.FMSG_PRM3).HeaderText = "���Ұ�3"                         '��ݻ޸���۸�.      ���Ұ�3
        objGrid.Columns(menmListCol.FMSG_PRM4).HeaderText = "���Ұ�4"                         '��ݻ޸���۸�.      ���Ұ�4
        objGrid.Columns(menmListCol.FMSG_PRM5).HeaderText = "���Ұ�5"                         '��ݻ޸���۸�.      ���Ұ�5
        objGrid.Columns(menmListCol.FLOG_DATA_TRN).HeaderText = "��ݻ޸���۸��ް�"            '��ݻ޸���۸�.      ��ݻ޸���۸��ް�

        '***********************
        '�ް����z�u�ύX
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO_CYCLIC).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FHASSEI_DT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FUSER_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FTERM_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FSYORI_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FLOG_DATA_TRN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        '***********************
        '��\��
        '***********************
        ''objGrid.Columns(menmListCol.Data04).Visible = False
        ''objGrid.Columns(menmListCol.Data05).Visible = False

        '***********************
        '�񕝒���
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO_CYCLIC).Width = 100
        objGrid.Columns(menmListCol.FHASSEI_DT).Width = 120
        objGrid.Columns(menmListCol.FUSER_ID).Width = 100
        objGrid.Columns(menmListCol.FTERM_ID).Width = 100
        objGrid.Columns(menmListCol.FSYORI_ID).Width = 100
        objGrid.Columns(menmListCol.FMSG_PRM1).Width = 150
        objGrid.Columns(menmListCol.FMSG_PRM2).Width = 150
        objGrid.Columns(menmListCol.FMSG_PRM3).Width = 150
        objGrid.Columns(menmListCol.FMSG_PRM4).Width = 150
        objGrid.Columns(menmListCol.FMSG_PRM5).Width = 150
        objGrid.Columns(menmListCol.FLOG_DATA_TRN).Width = 300

        ' ''***********************
        ' ''�ҏWۯ�
        ' ''***********************
        ''objGrid.Columns(menmListCol.ItemName).ReadOnly = True
        ''objGrid.Columns(menmListCol.Data).ReadOnly = False
        ''objGrid.Columns(menmListCol.Item).ReadOnly = True
        ''objGrid.Columns(menmListCol.Size).ReadOnly = True

        '***********************
        '��د�ސF�ւ�
        '***********************
        Call grdListChangeColor(grdList)

        '***********************
        '�����I��
        '***********************
        Try
            '�ް����\������Ȃ��ꍇ�������
            objGrid(-1, -1).Selected = True
        Catch ex As Exception
        End Try

    End Sub
#End Region
#Region "�@�\����������                                 "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' �\����������
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="blnDspOkFlg"></param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub ChckDataCount(ByVal strSQL As String, _
                              ByRef blnDspOkFlg As Boolean)

        Dim strCountSQL As String
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�
        Dim lngDataRowCount As Long = 0         '�ް���
        Dim lngChckRows As Long = 100000         '��r����

        strCountSQL = ""
        strCountSQL &= vbCrLf & " SELECT "
        strCountSQL &= vbCrLf & "      COUNT(*) AS ROW_COUNT "
        strCountSQL &= vbCrLf & " FROM "
        strCountSQL &= vbCrLf & "      ( "
        strCountSQL &= vbCrLf & strSQL
        strCountSQL &= vbCrLf & "      )"


        gobjDb.SQL = strCountSQL
        strDataSetName = "CountDataRow"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        lngDataRowCount = CLng(objDataSet.Tables(strDataSetName).Rows(0).Item("ROW_COUNT"))
        objDataSet.Dispose()
        objDataSet = Nothing

        '�\����������
        If lngChckRows < lngDataRowCount Then
            '(�ݒ萔�l�����擾�����������ꍇ)
            Dim strMsg As String
            Dim udtMsgRet As DialogResult

            '�\�����邩��ү���ޕ\��
            strMsg = "������" & CStr(lngChckRows) & "�𒴂��Ă��܂��B" & vbCrLf & "�\�����܂����H"
            udtMsgRet = _
                MessageBox.Show(strMsg, "ү����", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            'YES/NO�̕��򏈗�
            If udtMsgRet = Windows.Forms.DialogResult.Yes Then
                '(Yes���݂������ꂽ�ꍇ)
                blnDspOkFlg = True          '�\�����f�׸�=TURE
            Else
                '(���̑�)
                blnDspOkFlg = False         '�\�������׸�=FALSE
            End If
        End If

    End Sub
#End Region
#Region "�@���Ԑݒ�                                     "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ���Ԑݒ�
    ''' </summary>
    ''' <param name="dtpFromDate">�J�n���t</param>
    ''' <param name="dtpFromTime">�J�n����</param>
    ''' <param name="dtpToDate">�I�����t</param>
    ''' <param name="dtpToTime">�I������</param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub dtpKikanFromToSetup(ByRef dtpFromDate As System.Windows.Forms.DateTimePicker, _
                                    ByRef dtpFromTime As System.Windows.Forms.DateTimePicker, _
                                    ByRef dtpToDate As System.Windows.Forms.DateTimePicker, _
                                    ByRef dtpToTime As System.Windows.Forms.DateTimePicker)
        Dim dtmFrom As Date                 'From ����
        '' ''Dim dtmTo As Date                   'To   ����
        Dim dtmNow As Date = Now            '���ݓ���

        '*********************************************
        ' ���ԏ�����
        '*********************************************
        dtmFrom = DateAdd(DateInterval.Minute, _
                          Val("-" & gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_008)), _
                          dtmNow)


        dtpFromDate.Value = dtmFrom
        dtpFromTime.Value = dtmFrom
        dtpToDate.Value = dtpToDate.MaxDate
        dtpToTime.Value = dtpToDate.MaxDate

    End Sub
#End Region
#Region "�@�����ޯ���쐬(հ�ްID)                    "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' �����ޯ���쐬(հ�ްID)
    ''' </summary>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cboEnpMake(ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          '�����ޯ���\���ް�
        Dim strData As String = ""                          '�����ޯ�������ް�
        Dim strSQL As String                                'SQL��
        Dim lngCnt As Long = 0                              'ٰ�߶���
        Dim clsList(0) As GamenCommon.clsCboData            '���ޗp�z��

        '�I���Ȃ��s�ǉ�
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     FUSER_ID "
        strSQL &= vbCrLf & "   , FUSER_NAME "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TMST_USER "
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     FUSER_ID "

        '********************************************************************
        '�ް���Ď擾
        '********************************************************************
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�
        gobjDb.SQL = strSQL
        strDataSetName = "TMST_USER"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FUSER_ID")), CStr(objRow("FUSER_ID")))

            Next
        End If

        objCbo.DataSource = clsList

        objCbo.ValueMember = "Value"
        objCbo.DisplayMember = "Disp"

        '*******************************************************
        '�����ޯ��1�s�ڑI��ݒ�
        '*******************************************************
        objCbo.SelectedIndex = 0


    End Sub
#End Region
#Region "�@�����ޯ���쐬(�[��ID)                        "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' �����ޯ���쐬(�[��ID)
    ''' </summary>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cboTermMake(ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          '�����ޯ���\���ް�
        Dim strData As String = ""                          '�����ޯ�������ް�
        Dim strSQL As String                                'SQL��
        Dim lngCnt As Long = 0                              'ٰ�߶���
        Dim clsList(0) As GamenCommon.clsCboData            '���ޗp�z��

        '�I���Ȃ��s�ǉ�
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     FTERM_ID "
        strSQL &= vbCrLf & "   , FTERM_NAME "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TDSP_TERM "
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     FTERM_ID "

        '********************************************************************
        '�ް���Ď擾
        '********************************************************************
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�
        gobjDb.SQL = strSQL
        strDataSetName = "TDSP_TERM"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FTERM_ID")), CStr(objRow("FTERM_ID")))

            Next
        End If

        objCbo.DataSource = clsList

        objCbo.ValueMember = "Value"
        objCbo.DisplayMember = "Disp"

        '*******************************************************
        '�����ޯ��1�s�ڑI��ݒ�
        '*******************************************************
        objCbo.SelectedIndex = 0


    End Sub
#End Region
#Region "�@�����ޯ���쐬(����ID)                        "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' �����ޯ���쐬(����ID)
    ''' </summary>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cboSyoriMake(ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          '�����ޯ���\���ް�
        Dim strData As String = ""                          '�����ޯ�������ް�
        Dim strSQL As String                                'SQL��
        Dim lngCnt As Long = 0                              'ٰ�߶���
        Dim clsList(0) As GamenCommon.clsCboData            '���ޗp�z��

        '�I���Ȃ��s�ǉ�
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     FSYORI_ID "
        strSQL &= vbCrLf & "   , FCOMMENT "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TPRG_TIMER "
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     FSYORI_ID "

        '********************************************************************
        '�ް���Ď擾
        '********************************************************************
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�
        gobjDb.SQL = strSQL
        strDataSetName = "TPRG_TIMER"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FCOMMENT")), CStr(objRow("FSYORI_ID")))

            Next
        End If

        objCbo.DataSource = clsList

        objCbo.ValueMember = "Value"
        objCbo.DisplayMember = "Disp"

        '*******************************************************
        '�����ޯ��1�s�ڑI��ݒ�
        '*******************************************************
        objCbo.SelectedIndex = 0


    End Sub
#End Region

#Region "�@�\���̾�ā@                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\���̾��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set()

        '***********************************************
        '�����������
        '***********************************************
        mudtSEARCH_ITEM.FHASSEI_DT_FROM = TO_STRING(dtpDate_From.Text & " " & dtpTime_From.Text)    '����(FROM)
        mudtSEARCH_ITEM.FHASSEI_DT_TO = TO_STRING(dtpDate_To.Text & " " & dtpTime_To.Text)          '����(TO)
        mudtSEARCH_ITEM.FUSER_ID = TO_STRING(cboFUSER_ID.SelectedValue)                               'հ�ްID
        mudtSEARCH_ITEM.FTERM_ID = TO_STRING(cboFTERM_ID.SelectedValue)                             '�[��ID
        mudtSEARCH_ITEM.FSYORI_ID = TO_STRING(cboFSYORI_ID.SelectedValue)                           '����ID
        mudtSEARCH_ITEM.FMSG_PRM1 = TO_STRING(txtFMSG_PRM1.Text)                                    'ү�������Ұ�1
        mudtSEARCH_ITEM.FMSG_PRM2 = TO_STRING(txtFMSG_PRM2.Text)                                    'ү�������Ұ�2
        mudtSEARCH_ITEM.FMSG_PRM3 = TO_STRING(txtFMSG_PRM3.Text)                                    'ү�������Ұ�3
        mudtSEARCH_ITEM.FMSG_PRM4 = TO_STRING(txtFMSG_PRM4.Text)                                    'ү�������Ұ�4
        mudtSEARCH_ITEM.FMSG_PRM5 = TO_STRING(txtFMSG_PRM5.Text)                                    'ү�������Ұ�5
        mudtSEARCH_ITEM.FLOG_DATA_TRN = TO_STRING(txtFLOG_DATA_TRNS_Srch.Text)                      '��ݻ޸���۸��ް�

    End Sub
#End Region
#Region "�@��د�ޕ\�����̐F�ւ�                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\�����̐F�ւ�
    ''' </summary>
    ''' <param name="grdList">��د��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListChangeColor(ByRef grdList As Windows.Forms.DataGridView)

        Dim strLogDataTrn As String     '��ݻ޸���۸��ް�
        Dim intCntCol As Integer           '�s���ėp
        Dim objTxtBox As Windows.Forms.TextBox
        Dim objColor As Color
        Dim intCntColor As Integer

        For lngCnt As Long = 0 To grdList.Rows.Count - 1
            strLogDataTrn = ""

            '��ݻ޸���۸��ް��擾
            strLogDataTrn = _
                grdList.Rows(lngCnt).Cells(menmListCol.FLOG_DATA_TRN).Value.ToString()


            For intCntColor = 1 To 4

                objTxtBox = Nothing
                objColor = Nothing

                Select Case intCntColor
                    Case 1
                        objTxtBox = txtLOG_DATA_Color4
                        objColor = Color.DeepSkyBlue
                    Case 2
                        objTxtBox = txtLOG_DATA_Color3
                        objColor = Color.Lime
                    Case 3
                        objTxtBox = txtLOG_DATA_Color2
                        objColor = Color.Yellow
                    Case 4
                        objTxtBox = txtLOG_DATA_Color1
                        objColor = Color.Red
                End Select

                If objTxtBox.Text <> "" Then
                    '(÷�Ă����͂���Ă���ꍇ)

                    '-------------------------------
                    '��ݻ޸���۸��ް��̕����񌟍�
                    '-------------------------------
                    If strLogDataTrn.IndexOf(objTxtBox.Text) >= 0 Then
                        '�����񂪊܂܂�Ă���ꍇ
                        For intCntCol = 0 To grdList.Columns.Count - 1
                            grdList.Rows(lngCnt).Cells(intCntCol).Style.BackColor = objColor    '�F�ւ�
                        Next
                    End If
                End If
            Next
        Next

    End Sub
#End Region
#Region "�@�װ����                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="objException">����߼��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try
            MsgBox(objException.Message)
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class