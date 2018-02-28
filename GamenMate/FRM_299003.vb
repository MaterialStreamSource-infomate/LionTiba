'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���o�Ɏ��щ��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                                      "
Imports MateCommon
Imports MateCommon.clsConst
Imports MateCommon.mdlComFunc
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_299003

#Region "�@���ʕϐ��@                                   "

    '���������p�\����
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    ''' <summary>��د�ލ���</summary>
    Enum menmListCol
        FLOG_NO             'INOUT����.         ۸އ�
        FLOT_NO_STOCK       'INOUT����.         �݌�ۯć�
        FRESULT_DT          'INOUT����.         ���ѓ���
        FPALLET_ID          'INOUT����.         ��گ�ID
        FBUF_FM             'INOUT����.         ���ޯ̧��
        FARRAY_FM           'INOUT����.         ���z��
        FBUF_TO             'INOUT����.         ���ޯ̧��
        FARRAY_TO           'INOUT����.         ��z��
        FINOUT_STS          'INOUT����.         IN/OUT
        FSAGYOU_KIND        'INOUT����.         ��Ǝ��
        FDISP_ADDRESS_FM    'INOUT����.         FM�\�L�p���ڽ
        FDISP_ADDRESS_TO    'INOUT����.         TO�\�L�p���ڽ
        FDISPLOG_ADDRESS_FM 'INOUT����.         FM�\�L�p���ڽ_۸ޗp
        FDISPLOG_ADDRESS_TO 'INOUT����.         TO�\�L�p���ڽ_۸ޗp
        FHINMEI_CD          'INOUT����.         �i������
        FLOT_NO             'INOUT����.         ۯć�
        FARRIVE_DT          'INOUT����.         �݌ɔ�������
        FIN_KUBUN           'INOUT����.         ���ɋ敪
        FSEIHIN_KUBUN       'INOUT����.         ���i�敪
        FZAIKO_KUBUN        'INOUT����.         �݌ɋ敪
        FST_FM              'INOUT����.         ���ð��݇�
        FTR_VOL             'INOUT����.         �����Ǘ���
        FTR_RES_VOL         'INOUT����.         ����������
        FTRNS_SERIAL        'INOUT����.         �����ره�
        FUSER_ID             'INOUT����.         հ�ްID
        '**********************************************************************************************
        '���������ьŗL
        FFORM               'INOUT����.         �^��
        FGOUKI              'INOUT����.         ���@
        '���������ьŗL
        '**********************************************************************************************

        MAXCOL

    End Enum

    ''' <summary>���������ꍇ����</summary>
    Enum menmCheckCase
        SearchBtn_Click         '�������ݸد���
        PrintBtn_Click          '������ݸد���
    End Enum

#End Region
#Region "  �\���̒�`�@                                 "
    ''' <summary>��������</summary>
    Private Structure SEARCH_ITEM
        Dim KIKAN_FROM As String        '����(FROM)
        Dim KIKAN_TO As String          '����(TO)
        Dim FPALLET_ID As String        '��گ�ID
        Dim FINOUT_STS As String        '����
        Dim FBUF_FM As String           'FROM
        Dim FBUF_TO As String           'TO
    End Structure
#End Region
#Region "�@�����                                        "
#Region "�@̫��۰��                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
#Region "�@��گ�ID����                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��گ�ID����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPalletID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPalletID.Click
        Try
            Call cmdPalletIDProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@��������                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��������
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
        cmdDisp.Enabled = True      '�\������
        cmdPalletID.Enabled = True  '��گ�ID����
        cmdClose.Enabled = True     '��������

        '**********************************************************
        ' ����                      ���
        '**********************************************************
        Call dtpKikanFromToSetup(dtpKikanFromDate, _
                              dtpKikanFromTime, _
                              dtpKikanToDate, _
                              dtpKikanToTime)

        '**********************************************************
        ' �������                  ���
        '**********************************************************
        Call cboDefaultMake("FRM_204010", cboFINOUT_STS)

        '**********************************************************
        ' FROM-TO����               ���
        '**********************************************************
        Call cboDspSTMake(cboFROM)
        Call cboDspSTMake(cboTO)

        '**********************************************************
        ' ÷���ޯ��                 ���
        '**********************************************************
        txtPallet_ID.Text = ""          '��گ�ID

        '****************************************
        ' ����ؽ��ޯ��
        '****************************************
        Call chckLstBoxSetUp(chckLstColDsp)

        '****************************************
        '��د�ޏ����ݒ�
        '****************************************
        grdList.ColumnCount = menmListCol.MAXCOL
        Call grdListSetup(grdList)


    End Sub
#End Region
#Region "�@̫�Ѹ۰�ޏ���                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�Ѹ۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormClose()

    End Sub
#End Region
#Region "�@�\�����ݸد�����                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\�����ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
#Region "�@��گ�ID���ݸد�����                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��گ�ID���ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPalletIDProcess()

        '**********************************
        '��گ�ID���
        '**********************************
        If grdList.SelectedRows.Count > 0 Then
            '(�ّI��������ꍇ)
            Dim objSelectedRow As DataGridViewRow
            objSelectedRow = grdList.SelectedRows(0)
            txtPallet_ID.Text = CStr(objSelectedRow.Cells(menmListCol.FPALLET_ID).Value)
        End If

    End Sub
#End Region
#Region "�@�������ݸد�����                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �������ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCloseProcess()

        '**********************************
        '��ʏI��
        '**********************************
        Me.Close()

    End Sub
#End Region
#Region "�@�ް���د�ޕ\���@                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޕ\��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay()

        Dim strSQL As String                        'SQL��
        Dim blnDispOkFlg As Boolean = True          '�\�����邩�ǂ������׸�
        Dim intDspRows As Integer

        '(ؽĕ\���ő匏��500)
        intDspRows = 500

        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     TLOG_INOUT_FULL.FLOG_NO "                      'INOUT����.         ۸އ�
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FLOT_NO_STOCK "                'INOUT����.         �݌�ۯć�
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FRESULT_DT "                   'INOUT����.         ���ѓ���
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FPALLET_ID "                   'INOUT����.         ��گ�ID
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FBUF_FM "                      'INOUT����.         ���ޯ̧��
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FARRAY_FM "                    'INOUT����.         ���z��
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FBUF_TO "                      'INOUT����.         ���ޯ̧��
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FARRAY_TO "                    'INOUT����.         ��z��
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FINOUT_STS "                   'INOUT����.         IN/OUT
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FSAGYOU_KIND "                 'INOUT����.         ��Ǝ��
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FDISP_ADDRESS_FM "             'INOUT����.         FM�\�L�p���ڽ
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FDISP_ADDRESS_TO "             'INOUT����.         TO�\�L�p���ڽ
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FDISPLOG_ADDRESS_FM "          'INOUT����.         FM�\�L�p���ڽ_۸ޗp
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FDISPLOG_ADDRESS_TO "          'INOUT����.         TO�\�L�p���ڽ_۸ޗp
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FHINMEI_CD "                   'INOUT����.         �i������
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FLOT_NO "                      'INOUT����.         ۯć�
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FARRIVE_DT "                   'INOUT����.         �݌ɔ�������
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FIN_KUBUN "                    'INOUT����.         ���ɋ敪
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FSEIHIN_KUBUN "                'INOUT����.         ���i�敪
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FZAIKO_KUBUN "                 'INOUT����.         �݌ɋ敪
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FST_FM "                       'INOUT����.         ���ð��݇�
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FTR_VOL "                      'INOUT����.         �����Ǘ���
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FTR_RES_VOL "                  'INOUT����.         ����������
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FTRNS_SERIAL "                 'INOUT����.         �����ره�
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FUSER_ID "                      'INOUT����.         հ�ްID
        '**********************************************************************************************
        '���������ьŗL
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FFORM "                        'INOUT����.         �^��
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FGOUKI "                       'INOUT����.         ���@
        '���������ьŗL
        '**********************************************************************************************

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        '------------------------------------
        'SELECT
        '------------------------------------
        strSQL &= vbCrLf & "   ( SELECT "
        strSQL &= vbCrLf & "        ROW_NUMBER() "
        strSQL &= vbCrLf & "              OVER( ORDER BY TLOG_INOUT.FLOG_NO DESC ) AS REC"
        strSQL &= vbCrLf & "      , TLOG_INOUT.* "             'INOUT����.         ���ׂ�
        '------------------------------------
        'FROM
        '------------------------------------
        strSQL &= vbCrLf & "     FROM "
        strSQL &= vbCrLf & "        TLOG_INOUT  "

        '------------------------------------
        'WHERE
        '------------------------------------
        strSQL &= vbCrLf & "     WHERE 1 = 1 "

        '----------------------------
        ' INOUT����.���� �͈͎w�� 
        '----------------------------
        If mudtSEARCH_ITEM.KIKAN_FROM <> "" Then
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FRESULT_DT >= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_FROM & "','YYYY/MM/DD HH24:MI:SS')"
        End If
        If mudtSEARCH_ITEM.KIKAN_TO <> "" Then
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FRESULT_DT <= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_TO & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        '-----------------------------
        '��گ�ID
        '-----------------------------
        If mudtSEARCH_ITEM.FPALLET_ID <> "" Then
            '(��گć��ɉ������͂���Ă���ꍇ)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FPALLET_ID = '" & mudtSEARCH_ITEM.FPALLET_ID & "' "       '��گć�
        End If
        '-----------------------------
        'IN/OUT(����)
        '-----------------------------
        If mudtSEARCH_ITEM.FINOUT_STS <> CBO_ALL_VALUE Then
            '(����ɉ������͂���Ă���ꍇ)
            If mudtSEARCH_ITEM.FINOUT_STS = CONBOITEM_INOUT Then
                '(�����"���o��"���I�����ꂽ�ꍇ)
                strSQL &= vbCrLf & "        AND (   TLOG_INOUT.FINOUT_STS = " & FINOUT_STS_SIN_END
                strSQL &= vbCrLf & "             OR TLOG_INOUT.FINOUT_STS = " & FINOUT_STS_SOUT_START
                strSQL &= vbCrLf & "             OR TLOG_INOUT.FINOUT_STS = " & FINOUT_STS_SMENTE_ADD
                strSQL &= vbCrLf & "             OR TLOG_INOUT.FINOUT_STS = " & FINOUT_STS_SMENTE_DELETE
                strSQL &= vbCrLf & "            ) "

                '���o�Ɋ֘A�̓����\��
                '�\�����O�F ���Ɋ���
                '           �o�Ɏw��
                '           �����e�i���X�ǉ�
                '           �����e�i���X�폜

            Else
                '(����ł��̑����I�����ꂽ�ꍇ)
                strSQL &= vbCrLf & "        AND TLOG_INOUT.FINOUT_STS = '" & mudtSEARCH_ITEM.FINOUT_STS & "' "         'IN/OUT

            End If

        End If
        '-----------------------------
        'FROM ST
        '-----------------------------
        If mudtSEARCH_ITEM.FBUF_FM <> CBO_ALL_VALUE Then
            '(FROM ST�����͂���Ă���ꍇ)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FBUF_FM = '" & mudtSEARCH_ITEM.FBUF_FM & "' "       'FROM ST
        End If
        '-----------------------------
        'TO ST
        '-----------------------------
        If mudtSEARCH_ITEM.FBUF_TO <> CBO_ALL_VALUE Then
            '(FROM ST�����͂���Ă���ꍇ)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FBUF_TO = '" & mudtSEARCH_ITEM.FBUF_TO & "' "           'TO ST
        End If

        strSQL &= vbCrLf & "   ) TLOG_INOUT_FULL "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND TLOG_INOUT_FULL.REC <= " & intDspRows

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    TLOG_INOUT_FULL.FLOG_NO DESC "           'INOUT����.۸�


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
        strDataSetName = "TLOG_INOUT"
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
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���د�ޕ\���ݒ�
    ''' </summary>
    ''' <param name="objGrid">�ݒ肷���د�޵�޼ު��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
        objGrid.Columns(menmListCol.FLOG_NO).HeaderText = "۸އ�"                             'INOUT����.         ۸އ�
        objGrid.Columns(menmListCol.FLOT_NO_STOCK).HeaderText = "�݌�ۯć�"                   'INOUT����.         �݌�ۯć�
        objGrid.Columns(menmListCol.FRESULT_DT).HeaderText = "���ѓ���"                       'INOUT����.         ���ѓ���
        objGrid.Columns(menmListCol.FPALLET_ID).HeaderText = "��گ�ID"                        'INOUT����.         ��گ�ID
        objGrid.Columns(menmListCol.FBUF_FM).HeaderText = "���ޯ̧��"                         'INOUT����.         ���ޯ̧��
        objGrid.Columns(menmListCol.FARRAY_FM).HeaderText = "���z��"                        'INOUT����.         ���z��
        objGrid.Columns(menmListCol.FBUF_TO).HeaderText = "���ޯ̧��"                         'INOUT����.         ���ޯ̧��
        objGrid.Columns(menmListCol.FARRAY_TO).HeaderText = "��z��"                        'INOUT����.         ��z��
        objGrid.Columns(menmListCol.FINOUT_STS).HeaderText = "IN/OUT"                         'INOUT����.         IN/OUT
        objGrid.Columns(menmListCol.FSAGYOU_KIND).HeaderText = "��Ǝ��"                     'INOUT����.         ��Ǝ��
        objGrid.Columns(menmListCol.FDISP_ADDRESS_FM).HeaderText = "FM�\�L�p���ڽ"            'INOUT����.         FM�\�L�p���ڽ
        objGrid.Columns(menmListCol.FDISP_ADDRESS_TO).HeaderText = "TO�\�L�p���ڽ"            'INOUT����.         TO�\�L�p���ڽ
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_FM).HeaderText = "FM�\�L�p���ڽ_۸ޗp"   'INOUT����.         FM�\�L�p���ڽ_۸ޗp
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_TO).HeaderText = "TO�\�L�p���ڽ_۸ޗp"   'INOUT����.         TO�\�L�p���ڽ_۸ޗp
        objGrid.Columns(menmListCol.FHINMEI_CD).HeaderText = "�i������"                       'INOUT����.         �i������
        objGrid.Columns(menmListCol.FLOT_NO).HeaderText = "ۯć�"                             'INOUT����.         ۯć�
        objGrid.Columns(menmListCol.FARRIVE_DT).HeaderText = "�݌ɔ�������"                   'INOUT����.         �݌ɔ�������
        objGrid.Columns(menmListCol.FIN_KUBUN).HeaderText = "���ɋ敪"                        'INOUT����.         ���ɋ敪
        objGrid.Columns(menmListCol.FSEIHIN_KUBUN).HeaderText = "���i�敪"                    'INOUT����.         ���i�敪
        objGrid.Columns(menmListCol.FZAIKO_KUBUN).HeaderText = "�݌ɋ敪"                     'INOUT����.         �݌ɋ敪
        objGrid.Columns(menmListCol.FST_FM).HeaderText = "���ð��݇�"                         'INOUT����.         ���ð��݇�
        objGrid.Columns(menmListCol.FTR_VOL).HeaderText = "�����Ǘ���"                        'INOUT����.         �����Ǘ���
        objGrid.Columns(menmListCol.FTR_RES_VOL).HeaderText = "����������"                    'INOUT����.         ����������
        objGrid.Columns(menmListCol.FTRNS_SERIAL).HeaderText = "�����ره�"                   'INOUT����.         �����ره�
        objGrid.Columns(menmListCol.FUSER_ID).HeaderText = "հ�ްID"                        'INOUT����.         հ�ްID
        objGrid.Columns(menmListCol.FFORM).HeaderText = "�^��"                                'INOUT����.         �^��
        objGrid.Columns(menmListCol.FGOUKI).HeaderText = "���@"                               'INOUT����.         ���@

        '***********************
        '��ͯ�ޕ��z�u�ύX
        '***********************
        objGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '***********************
        '�ް����z�u�ύX
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                   'INOUT����.         ۸އ�
        objGrid.Columns(menmListCol.FLOT_NO_STOCK).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft             'INOUT����.         �݌�ۯć�
        objGrid.Columns(menmListCol.FRESULT_DT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter              'INOUT����.         ���ѓ���
        objGrid.Columns(menmListCol.FPALLET_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                'INOUT����.         ��گ�ID
        objGrid.Columns(menmListCol.FBUF_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                  'INOUT����.         ���ޯ̧��
        objGrid.Columns(menmListCol.FARRAY_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                'INOUT����.         ���z��
        objGrid.Columns(menmListCol.FBUF_TO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                  'INOUT����.         ���ޯ̧��
        objGrid.Columns(menmListCol.FARRAY_TO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                'INOUT����.         ��z��
        objGrid.Columns(menmListCol.FINOUT_STS).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                'INOUT����.         IN/OUT
        objGrid.Columns(menmListCol.FSAGYOU_KIND).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft              'INOUT����.         ��Ǝ��
        objGrid.Columns(menmListCol.FDISP_ADDRESS_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft          'INOUT����.         FM�\�L�p���ڽ
        objGrid.Columns(menmListCol.FDISP_ADDRESS_TO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft          'INOUT����.         TO�\�L�p���ڽ
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft       'INOUT����.         FM�\�L�p���ڽ_۸ޗp
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_TO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft       'INOUT����.         TO�\�L�p���ڽ_۸ޗp
        objGrid.Columns(menmListCol.FHINMEI_CD).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                'INOUT����.         �i������
        objGrid.Columns(menmListCol.FLOT_NO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                   'INOUT����.         ۯć�
        objGrid.Columns(menmListCol.FARRIVE_DT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter              'INOUT����.         �݌ɔ�������
        objGrid.Columns(menmListCol.FIN_KUBUN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                 'INOUT����.         ���ɋ敪
        objGrid.Columns(menmListCol.FSEIHIN_KUBUN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft             'INOUT����.         ���i�敪
        objGrid.Columns(menmListCol.FZAIKO_KUBUN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft              'INOUT����.         �݌ɋ敪
        objGrid.Columns(menmListCol.FST_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                   'INOUT����.         ���ð��݇�
        objGrid.Columns(menmListCol.FTR_VOL).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                  'INOUT����.         �����Ǘ���
        objGrid.Columns(menmListCol.FTR_RES_VOL).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight              'INOUT����.         ����������
        objGrid.Columns(menmListCol.FTRNS_SERIAL).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft              'INOUT����.         �����ره�
        objGrid.Columns(menmListCol.FUSER_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                   'INOUT����.         հ�ްID
        objGrid.Columns(menmListCol.FFORM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                     'INOUT����.         �^��
        objGrid.Columns(menmListCol.FGOUKI).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                    'INOUT����.         ���@

        '***********************
        '��\��
        '***********************
        ''objGrid.Columns(menmListCol.Data04).Visible = False
        ''objGrid.Columns(menmListCol.Data05).Visible = False
        For intII As Integer = 0 To menmListCol.MAXCOL - 1
            '(��ٰ��)
            objGrid.Columns(intII).Visible = False
        Next
        For intJJ As Integer = 0 To chckLstColDsp.CheckedIndices.Count - 1
            '(������ٰ��)
            grdList.Columns(chckLstColDsp.CheckedIndices.Item(intJJ)).Visible = True
        Next

        '***********************
        '�񕝒���
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO).Width = 110                'INOUT����.         ۸އ�
        objGrid.Columns(menmListCol.FLOT_NO_STOCK).Width = 110          'INOUT����.         �݌�ۯć�
        objGrid.Columns(menmListCol.FRESULT_DT).Width = 120             'INOUT����.         ���ѓ���
        objGrid.Columns(menmListCol.FPALLET_ID).Width = 120             'INOUT����.         ��گ�ID
        objGrid.Columns(menmListCol.FBUF_FM).Width = 100                'INOUT����.         ���ޯ̧��
        objGrid.Columns(menmListCol.FARRAY_FM).Width = 100              'INOUT����.         ���z��
        objGrid.Columns(menmListCol.FBUF_TO).Width = 100                'INOUT����.         ���ޯ̧��
        objGrid.Columns(menmListCol.FARRAY_TO).Width = 100              'INOUT����.         ��z��
        objGrid.Columns(menmListCol.FINOUT_STS).Width = 100             'INOUT����.         IN/OUT
        objGrid.Columns(menmListCol.FSAGYOU_KIND).Width = 100           'INOUT����.         ��Ǝ��
        objGrid.Columns(menmListCol.FDISP_ADDRESS_FM).Width = 100       'INOUT����.         FM�\�L�p���ڽ
        objGrid.Columns(menmListCol.FDISP_ADDRESS_TO).Width = 100       'INOUT����.         TO�\�L�p���ڽ
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_FM).Width = 100    'INOUT����.         FM�\�L�p���ڽ_۸ޗp
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_TO).Width = 100    'INOUT����.         TO�\�L�p���ڽ_۸ޗp
        objGrid.Columns(menmListCol.FHINMEI_CD).Width = 100             'INOUT����.         �i������
        objGrid.Columns(menmListCol.FLOT_NO).Width = 100                'INOUT����.         ۯć�
        objGrid.Columns(menmListCol.FARRIVE_DT).Width = 120             'INOUT����.         �݌ɔ�������
        objGrid.Columns(menmListCol.FIN_KUBUN).Width = 100              'INOUT����.         ���ɋ敪
        objGrid.Columns(menmListCol.FSEIHIN_KUBUN).Width = 100          'INOUT����.         ���i�敪
        objGrid.Columns(menmListCol.FZAIKO_KUBUN).Width = 100           'INOUT����.         �݌ɋ敪
        objGrid.Columns(menmListCol.FST_FM).Width = 100                 'INOUT����.         ���ð��݇�
        objGrid.Columns(menmListCol.FTR_VOL).Width = 100                'INOUT����.         �����Ǘ���
        objGrid.Columns(menmListCol.FTR_RES_VOL).Width = 100            'INOUT����.         ����������
        objGrid.Columns(menmListCol.FTRNS_SERIAL).Width = 100           'INOUT����.         �����ره�
        objGrid.Columns(menmListCol.FUSER_ID).Width = 100                'INOUT����.         հ�ްID
        objGrid.Columns(menmListCol.FFORM).Width = 100                  'INOUT����.         �^��
        objGrid.Columns(menmListCol.FGOUKI).Width = 100                 'INOUT����.         ���@


        ' ''***********************
        ' ''�ҏWۯ�
        ' ''***********************
        ''objGrid.Columns(menmListCol.ItemName).ReadOnly = True
        ''objGrid.Columns(menmListCol.Data).ReadOnly = False
        ''objGrid.Columns(menmListCol.Item).ReadOnly = True
        ''objGrid.Columns(menmListCol.Size).ReadOnly = True

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

#Region "  �\���̾��                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\���̾��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set()

        '********************************************************************
        '�\���̂ɒl���
        '********************************************************************
        '===============================================
        '����(FROM)
        '===============================================
        mudtSEARCH_ITEM.KIKAN_FROM = TO_STRING(dtpKikanFromDate.Text & " " & dtpKikanFromTime.Text)    '����(FROM)

        '===============================================
        '����(TO)
        '===============================================
        mudtSEARCH_ITEM.KIKAN_TO = TO_STRING(dtpKikanToDate.Text & " " & dtpKikanToTime.Text)          '����(TO)

        '===============================================
        ' ��گ�ID
        '===============================================
        mudtSEARCH_ITEM.FPALLET_ID = TO_STRING(txtPallet_ID.Text)

        '===============================================
        ' ����
        '===============================================
        mudtSEARCH_ITEM.FINOUT_STS = TO_STRING(cboFINOUT_STS.SelectedValue)

        '===============================================
        'FROM ST
        '===============================================
        mudtSEARCH_ITEM.FBUF_FM = TO_STRING(cboFROM.SelectedValue)

        '===============================================
        'TO ST
        '===============================================
        mudtSEARCH_ITEM.FBUF_TO = TO_STRING(cboTO.SelectedValue)


    End Sub
#End Region
#Region "�@���Ԑݒ�                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���Ԑݒ�
    ''' </summary>
    ''' <param name="dtpFromDate">�J�n���t</param>
    ''' <param name="dtpFromTime">�J�n����</param>
    ''' <param name="dtpToDate">�I�����t</param>
    ''' <param name="dtpToTime">�I������</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
#Region "�@�����ޯ���쐬(�W��)                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����ޯ���쐬(�W��)
    ''' </summary>
    ''' <param name="strDispID"></param>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboDefaultMake(ByVal strDispID As String, ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          '�����ޯ���\���ް�
        Dim strData As String = ""                          '�����ޯ�������ް�
        Dim strSQL As String                                'SQL��
        Dim lngCnt As Long = 0              'ٰ�߶���
        Dim clsList(0) As GamenCommon.clsCboData        '���ޗp�z��

        '�I���Ȃ��s�ǉ�
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        '*******************************************************
        '�����ޯ���ݒ�l    �擾
        '   �yDSP_CTRL�z
        '*******************************************************
        '-----------------------
        '���oSQL�쐬
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    TDSP_DISP.FGAMEN_DISP FGAMEN_DISP "          '��ʕ\��Ͻ�.   �\���p����
        strSQL &= vbCrLf & "  , TDSP_DISP.FDISP_VALUE FDISP_VALUE "          '��ʕ\��Ͻ�.   �ݒ�l
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TDSP_CTRL LEFT OUTER JOIN "       '��ʕ\��Ͻ�     (�O������
        strSQL &= vbCrLf & "    TDSP_DISP ON "                    '��ʺ��۰�Ͻ�   (�O������
        strSQL &= vbCrLf & "           TDSP_CTRL.FTABLE_NAME = TDSP_DISP.FTABLE_NAME "     '�O������   ð��ٖ�
        strSQL &= vbCrLf & "       AND TDSP_CTRL.FFIELD_NAME = TDSP_DISP.FFIELD_NAME "     '�O������   ̨���ޖ�
        strSQL &= vbCrLf & "       AND TDSP_CTRL.FCTRL_VALUE = TDSP_DISP.FDISP_VALUE "     '�O������   �ݒ�l
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        TDSP_CTRL.FDISP_ID = '" & TO_STRING(strDispID) & "'"                    '���ID
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ID = '" & TO_STRING(objCbo.Name) & "'"            '���۰ٖ�
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    TDSP_CTRL.FCTRL_ORDER "    '��ʺ��۰�Ͻ�. ����
        strSQL &= vbCrLf

        '********************************************************************
        '�ް���Ď擾
        '********************************************************************
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�
        gobjDb.SQL = strSQL
        strDataSetName = "TDSP_CTRL"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                If IsDBNull(objRow("FGAMEN_DISP")) = True Or IsDBNull(objRow("FDISP_VALUE")) = True Then
                    clsList(lngCnt) = New GamenCommon.clsCboData("", "")
                Else
                    clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FGAMEN_DISP")), CStr(objRow("FDISP_VALUE")))
                End If


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
#Region "�@�����ޯ���쐬(ST)                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����ޯ���쐬(ST)
    ''' </summary>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboDspSTMake(ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          '�����ޯ���\���ް�
        Dim strData As String = ""                          '�����ޯ�������ް�
        Dim strSQL As String                                'SQL��
        Dim lngCnt As Long = 0                              'ٰ�߶���
        Dim clsList(0) As GamenCommon.clsCboData            '���ޗp�z��

        '�I���Ȃ��s�ǉ�
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        '*******************************************************
        '�����ޯ���ݒ�l    �擾
        '   �yTMST_TRK�z
        '*******************************************************
        '-----------------------
        '���oSQL�쐬
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT "
        strSQL &= vbCrLf & "    FTRK_BUF_NO "                                   '�ׯ�ݸ��ޯ̧��
        strSQL &= vbCrLf & "  , FBUF_NAME "                                     '�ׯ�ݸ��ޯ̧����
        strSQL &= vbCrLf & " FROM TMST_TRK "                                    '�ׯ�ݸ��ޯ̧Ͻ�
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FTRK_BUF_NO "
        strSQL &= vbCrLf


        '********************************************************************
        '�ް���Ď擾
        '********************************************************************
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�
        gobjDb.SQL = strSQL
        strDataSetName = "TMST_TRK"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FBUF_NAME")), CStr(objRow("FTRK_BUF_NO")))

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
#Region "�@����ؽ��ޯ���ݒ菈��                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����ؽ��ޯ���ݒ菈�� 
    ''' </summary>
    ''' <param name="ctlChckLstBox"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub chckLstBoxSetUp(ByVal ctlChckLstBox As CheckedListBox)
        '****************************************
        '�����ݒ�
        '****************************************
        ctlChckLstBox.Items.Clear()
        Dim blnChck(0 To menmListCol.MAXCOL - 1) As Boolean    '�����׸�
        blnChck(menmListCol.FLOG_NO) = False                    '۸އ�
        blnChck(menmListCol.FLOT_NO_STOCK) = False              '�݌�ۯć�
        blnChck(menmListCol.FRESULT_DT) = True                  '���ѓ���
        blnChck(menmListCol.FPALLET_ID) = True                  '��گ�ID
        blnChck(menmListCol.FBUF_FM) = False                    '���ޯ̧��
        blnChck(menmListCol.FARRAY_FM) = False                  '���z��
        blnChck(menmListCol.FBUF_TO) = False                    '���ޯ̧��
        blnChck(menmListCol.FARRAY_TO) = False                  '��z��
        blnChck(menmListCol.FINOUT_STS) = True                  'IN/OUT
        blnChck(menmListCol.FSAGYOU_KIND) = False               '��Ǝ��
        blnChck(menmListCol.FDISP_ADDRESS_FM) = True            'FM�\�L�p���ڽ
        blnChck(menmListCol.FDISP_ADDRESS_TO) = True            'TO�\�L�p���ڽ
        blnChck(menmListCol.FDISPLOG_ADDRESS_FM) = True         'FM�\�L�p���ڽ_۸ޗp
        blnChck(menmListCol.FDISPLOG_ADDRESS_TO) = True         'TO�\�L�p���ڽ_۸ޗp
        blnChck(menmListCol.FHINMEI_CD) = False                 '�i������
        blnChck(menmListCol.FLOT_NO) = False                    'ۯć�
        blnChck(menmListCol.FARRIVE_DT) = True                  '�݌ɔ�������
        blnChck(menmListCol.FIN_KUBUN) = False                  '���ɋ敪
        blnChck(menmListCol.FSEIHIN_KUBUN) = False              '���i�敪
        blnChck(menmListCol.FZAIKO_KUBUN) = False               '�݌ɋ敪
        blnChck(menmListCol.FST_FM) = False                     '���ð��݇�
        blnChck(menmListCol.FTR_VOL) = False                    '�����Ǘ���
        blnChck(menmListCol.FTR_RES_VOL) = False                '����������
        blnChck(menmListCol.FTRNS_SERIAL) = False               '�����ره�
        blnChck(menmListCol.FUSER_ID) = False                    'հ�ްID
        blnChck(menmListCol.FFORM) = True                       '�^��
        blnChck(menmListCol.FGOUKI) = True                      '���@

        ctlChckLstBox.Items.Add("۸އ�", blnChck(menmListCol.FLOG_NO))
        ctlChckLstBox.Items.Add("�݌�ۯć�", blnChck(menmListCol.FLOT_NO_STOCK))
        ctlChckLstBox.Items.Add("���ѓ���", blnChck(menmListCol.FRESULT_DT))
        ctlChckLstBox.Items.Add("��گ�ID", blnChck(menmListCol.FPALLET_ID))
        ctlChckLstBox.Items.Add("���ޯ̧��", blnChck(menmListCol.FBUF_FM))
        ctlChckLstBox.Items.Add("���z��", blnChck(menmListCol.FARRAY_FM))
        ctlChckLstBox.Items.Add("���ޯ̧��", blnChck(menmListCol.FBUF_TO))
        ctlChckLstBox.Items.Add("��z��", blnChck(menmListCol.FARRAY_TO))
        ctlChckLstBox.Items.Add("IN/OUT", blnChck(menmListCol.FINOUT_STS))
        ctlChckLstBox.Items.Add("��Ǝ��", blnChck(menmListCol.FSAGYOU_KIND))
        ctlChckLstBox.Items.Add("FM�\�L�p���ڽ", blnChck(menmListCol.FDISP_ADDRESS_FM))
        ctlChckLstBox.Items.Add("TO�\�L�p���ڽ", blnChck(menmListCol.FDISP_ADDRESS_TO))
        ctlChckLstBox.Items.Add("FM�\�L�p���ڽ_۸ޗp", blnChck(menmListCol.FDISPLOG_ADDRESS_FM))
        ctlChckLstBox.Items.Add("TO�\�L�p���ڽ_۸ޗp", blnChck(menmListCol.FDISPLOG_ADDRESS_TO))
        ctlChckLstBox.Items.Add("�i������", blnChck(menmListCol.FHINMEI_CD))
        ctlChckLstBox.Items.Add("ۯć�", blnChck(menmListCol.FLOT_NO))
        ctlChckLstBox.Items.Add("�݌ɔ�������", blnChck(menmListCol.FARRIVE_DT))
        ctlChckLstBox.Items.Add("���ɋ敪", blnChck(menmListCol.FIN_KUBUN))
        ctlChckLstBox.Items.Add("���i�敪", blnChck(menmListCol.FSEIHIN_KUBUN))
        ctlChckLstBox.Items.Add("�݌ɋ敪", blnChck(menmListCol.FZAIKO_KUBUN))
        ctlChckLstBox.Items.Add("���ð��݇�", blnChck(menmListCol.FST_FM))
        ctlChckLstBox.Items.Add("�����Ǘ���", blnChck(menmListCol.FTR_VOL))
        ctlChckLstBox.Items.Add("����������", blnChck(menmListCol.FTR_RES_VOL))
        ctlChckLstBox.Items.Add("�����ره�", blnChck(menmListCol.FTRNS_SERIAL))
        ctlChckLstBox.Items.Add("հ�ްID", blnChck(menmListCol.FUSER_ID))
        ctlChckLstBox.Items.Add("�^��", blnChck(menmListCol.FFORM))
        ctlChckLstBox.Items.Add("���@", blnChck(menmListCol.FGOUKI))

    End Sub
#End Region
#Region "�@�\����������                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �\���������� 
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="blnDspOkFlg"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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