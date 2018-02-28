'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z��Ɨ����ڍ׉��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_204051

#Region "�@���ʕϐ��@                               "

    '���������p�\����
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    '�����è
    Private mstrFLOG_NO As String       '۸އ�

    '���ʕϐ�
    Private mstrTableName As String     'ð��ٖ�

    ''' <summary>��د�ލ���</summary>
    Enum menmListCol
        FDENBUN_ITEM_NAME               '���ڰ���۸ޏڍ�.   �d�����і���
        FDENBUN_ITEM_DATA               '���ڰ���۸ޏڍ�.   �d�������ް�

        MAXCOL

    End Enum

#End Region
#Region "  �\���̒�`                               "

    ''' <summary>��������</summary>
    Private Structure SEARCH_ITEM
        Dim FLOG_NO As String               '۸އ�
    End Structure
#End Region
#Region "�@�����è                                  "
    ''' =======================================
    ''' <summary>۸އ�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFLOG_NO() As String
        Get
            Return mstrFLOG_NO
        End Get
        Set(ByVal value As String)
            mstrFLOG_NO = value
        End Set
    End Property
#End Region
#Region "  �����                                    "
#Region " ̫��۰��                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_204051_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ̫�ѱ�۰��                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѱ�۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_204051_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "�@�m�F   �@ ���݉���                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �m�F ���݉���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Call cmdClose_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ̫��۰��     ����                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ̫��۰�� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()


        '*********************************************
        ' ̫�і����
        '*********************************************
        If Me.Name = "FRM_204051" Then
            Me.Text = "��Ɨ����ڍ�"
            mstrTableName = "TEVD_OPE_DTL"
        Else
            Me.Text = "�I�y���[�V�������O�ڍ�"
            mstrTableName = "TLOG_OPE_DTL"
        End If


        '*********************************************
        ' �\���̾��
        '*********************************************
        Call SearchItem_Set()

        '*********************************************
        ' ��د�ޏ�����
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  '��د�ޏ����ݒ�
        Call grdListSetup()

        '*********************************************
        ' ��د�ޕ\��
        '*********************************************
        Call grdListDisplay()


    End Sub
#End Region
#Region "�@̫�ѱ�۰��   ����                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѱ�۰�� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ���۰ق̊J��
        '******************************************


    End Sub
#End Region
#Region "�@�m�F         ���݉�������                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �m�F ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProcess()

        Me.Close()

    End Sub
#End Region
#Region "�@�\���̾�ā@                              "
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
        '۸އ�
        '===============================================
        mudtSEARCH_ITEM.FLOG_NO = mstrFLOG_NO           '۸އ�


    End Sub
#End Region
#Region "�@��د�ޕ\���@                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay()

        Dim strSQL As String                    'SQL��


        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    " & mstrTableName & ".FDENBUN_ITEM_NAME "    '���ڰ���۸ޏڍ�.   �d�����і���
        strSQL &= vbCrLf & "  , " & mstrTableName & ".FDENBUN_ITEM_DATA "    '���ڰ���۸ޏڍ�.   �d�������ް�
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    " & mstrTableName & " "                      '���ڰ���۸ޏڍ�
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '�K���ʂ����
        '----------------------------
        '۸އ�
        '----------------------------
        strSQL &= vbCrLf & "    AND " & mstrTableName & ".FLOG_NO = '" & mudtSEARCH_ITEM.FLOG_NO & "' "  '���ڰ���۸ޏڍ�.    ۸އ�
        strSQL &= vbCrLf & "    AND " & mstrTableName & ".FDENBUN_ITEM_NAME IS NOT NULL "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    " & mstrTableName & ".FORDER "               '���ڰ���۸ޏڍ�.   �\����
        strSQL &= vbCrLf


        '********************************************************************
        '��د�ޕ\��
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, True)


        '********************************************************************
        '��د�ޕ\���ݒ�
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       '��د�ޑI������


    End Sub
#End Region
#Region "�@��د�ޕ\���ݒ�@                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\���ݒ�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()


        '************************************************
        '��د��Ͻ��̒�`�𔽉f
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)


        '************************************************
        '�񕝎�������
        '************************************************
        grdList.Columns(grdList.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region

End Class
