'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���đ��M°�
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_299002

#Region "�@���ʕϐ��@                               "

    '================================================
    '�萔
    '================================================
    '��د��
    Private Const GRIDHEADER_ROW_DSPCMD_ID As Integer = 0        'ͯ�ް��د��    �����ID     �s�ʒu
    Private Const GRIDHEADER_ROW_DSPTERM_ID As Integer = 1       'ͯ�ް��د��    �[��ID      �s�ʒu
    Private Const GRIDHEADER_ROW_DSPUSER_ID As Integer = 2        'ͯ�ް��د��    հ�ްID  �s�ʒu
    Private Const GRIDCONFIG_ROW_SOCK_SEND_ADDRESS As Integer = 0       '�ݒ����د�� ���M����ڽ �s�ʒu
    Private Const GRIDCONFIG_ROW_SOCK_SEND_PORT As Integer = 1          '�ݒ����د�� �߰�No      �s�ʒu
    Private Const GRIDCONFIG_ROW_SOCK_SEND_TIME_OUT As Integer = 2      '�ݒ����د�� ��ѱ��      �s�ʒu

    '================================================
    '�񋓑�
    '================================================
    ''' <summary>�����ް���د�ލ���</summary>
    Enum menmListCol
        ItemName        '���і���
        Data            '�ް�
        Item            '���і�
        Size            '����
        Data04          '�ް�4(��)
        Data05          '�ް�5(��)
    End Enum

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
    Private Sub FRM_299002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call FormLoad()
        Catch ex As Exception
            ComError(ex)
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
#Region "  ���M���ݸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���M���ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendFormatSock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendFormatSock.Click
        Try
            Call cmdSendFormatSockProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ASCII�ϊ����ݸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ASCII�ϊ����ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdASCII_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdASCII.Click
        Try
            Call cmdASCIIProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �Ǎ�̧�ٺ����ޯ���I��ύX"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �Ǎ�̧�ٺ����ޯ���I��ύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFile_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFile.SelectedIndexChanged
        Try
            Call cboFileSelChange()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ���M÷���ޯ��÷�ĕύX"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���M÷���ޯ��÷�ĕύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtSendText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSendText.TextChanged
        Try
            Call txtSendTextTextChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region

#Region "  ̫��۰�ޏ���                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()


        '*************************************************
        '̧�ّI������ޯ���쐬
        '*************************************************
        Dim aryData As ArrayList = New ArrayList
        aryData.Add(New GamenCommon.clsCboData("��ʗp", CONFIG_TELEGRAM_DSP))
        'aryData.Add(New clsCboData("PLC�p", CONFIG_TELEGRAM_PLC))
        aryData.Add(New GamenCommon.clsCboData("HDT�p", CONFIG_TELEGRAM_HDT))
        cboFile.DisplayMember = GamenCommon.clsCboData.DISPLAYMEMBER
        cboFile.ValueMember = GamenCommon.clsCboData.VALUEMEMBER
        cboFile.DataSource = aryData
        cboFile.SelectedIndex = 0


        '*************************************************
        '�ݒ����د�ލ쐬
        '*************************************************
        Call grdListSockConfigMake()


        '*************************************************
        '����ޑI������ޯ���쐬
        '*************************************************
        Call cboCommandNoMake()


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


        '*************************************************
        'Config�擾
        '*************************************************
        Dim strItemName As String = ""      '���і���
        Dim strData As String = ""          '�ް�
        Dim strItem As String = ""          '���і�
        Dim strSize As String = ""          '����
        Dim objDataTable As New GamenCommon.clsGridDataTable05          '�ް�ð���
        Dim objDocument As New System.Xml.XmlDocument       'XML�޷����
        Dim objNode As System.Xml.XmlNode                   'XMLɰ��
        objDocument.Load(cboFile.SelectedValue)             '�ް�۰��

        For Each objNode In objDocument(XML_NODE_CONFIG)(cboCommandID.SelectedValue)
            '(ٰ��:ɰ�ސ�)

            If objNode.Name = XML_NODE_ADD Then
                '(�ް���`�̏ꍇ)
                strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                strSize = objNode.Attributes.GetNamedItem(XML_NODE_VALUE).Value
            End If
            If objNode.NodeType = Xml.XmlNodeType.Comment Then
                strItemName = objNode.Value
                objDataTable.userAddRowDataSet(strItemName _
                                             , "" _
                                             , strItem _
                                             , strSize _
                                             )
            End If

        Next


        '*************************************************
        '��د�ޕ\��
        '*************************************************
        grdSockData.DataSource = objDataTable


        '*************************************************
        '��د�ޕ\���ݒ�
        '*************************************************
        Call grdListSetup(grdSockData)


        '*************************************************
        '��د���ް����
        '*************************************************
        grdSockHeader.Item(menmListCol.Data, GRIDHEADER_ROW_DSPCMD_ID).Value = Microsoft.VisualBasic.Right(cboCommandID.SelectedValue, 6) '�����ID


    End Sub
#End Region
#Region "  ���M���ݸد�����                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���M���ݸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendFormatSockProcess()


        '***************************************************
        ' Wait̫�ѕ\��
        '***************************************************
        Call gobjComFuncFRM.WaitFormShow()


        '*************************************************
        '�d���쐬
        '*************************************************
        Dim objTelegramSend As New clsTelegram(cboFile.SelectedValue)
        objTelegramSend.FORMAT_ID = Replace(cboCommandID.SelectedValue, XML_NODE_ID_PREFIX, "")     '̫�ϯĖ����
        '�ް������쐬
        For ii As Integer = 0 To grdSockData.RowCount - 1
            '(ٰ��:��د�ލs��)
            objTelegramSend.SETIN_DATA(grdSockData.Item(menmListCol.Item, ii).Value _
                                     , grdSockData.Item(menmListCol.Data, ii).Value _
                                      )
        Next
        'ͯ�ް�����쐬
        For ii As Integer = 0 To grdSockHeader.RowCount - 1
            '(ٰ��:��د�ލs��)
            objTelegramSend.SETIN_HEADER(grdSockHeader.Item(menmListCol.Item, ii).Value _
                                       , grdSockHeader.Item(menmListCol.Data, ii).Value _
                                        )
        Next
        '�d���쐬
        objTelegramSend.MAKE_TELEGRAM()


        '***************************************************
        ' ���đ��M
        '***************************************************
        Dim objSocketSend As New clsSocketClientGamen(gobjOwner)
        objSocketSend.strAddress = grdSockConfig.Item(menmListCol.Data, GRIDCONFIG_ROW_SOCK_SEND_ADDRESS).Value         '���M����ڽ
        objSocketSend.intPortNo = grdSockConfig.Item(menmListCol.Data, GRIDCONFIG_ROW_SOCK_SEND_PORT).Value             '�߰�No
        objSocketSend.intTimeOut = grdSockConfig.Item(menmListCol.Data, GRIDCONFIG_ROW_SOCK_SEND_TIME_OUT).Value        '��ѱ��
        If txtSendText.Text = "" Then
            objSocketSend.strSendText = objTelegramSend.TELEGRAM_MAKED      '���M÷��
        Else
            objSocketSend.strSendText = txtSendText.Text                    '���M÷��
        End If
        objSocketSend.blnReceiveFlag = True                             '�������đҋ@
        objSocketSend.SendSock()                                        '���đ��M


        '***************************************************
        ' Wait̫�э폜
        '***************************************************
        Call gobjComFuncFRM.WaitFormClose()


        '***************************************************
        ' ���đ��M����I������
        '***************************************************
        Select Case objSocketSend.udtRet
            Case clsSocketClient.RetCode.NG
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_SOCKSENDSERVER_01, PopupFormType.Ok, PopupIconType.Err)

            Case clsSocketClient.RetCode.ReceiveTimeOut
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_SOCKSENDSERVER_02, PopupFormType.Ok, PopupIconType.Err)

            Case clsSocketClient.RetCode.ConnectError
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_SOCKSENDSERVER_03, PopupFormType.Ok, PopupIconType.Err)

        End Select


        '***************************************************
        ' ��M���ĉ��
        '***************************************************
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strRET_STATE As String                  '�����ð��
        Dim strRET_MESSAGE_EXIST As String          '����ү���ޗL��
        Dim strRET_MESSAGE As String                '����ү����
        Dim strRET_DATA_SYUBETU As String           '�����ް����
        Dim strRET_DATA As String                   '�����ް�

        objTelegramRecv.FORMAT_ID = FORMAT_DSP_RETURN                                   '̫�ϯĖ����
        objTelegramRecv.TELEGRAM_PARTITION = objSocketSend.strRecvText                  '��������d�����
        objTelegramRecv.PARTITION()                                                     '�d������
        strRET_STATE = objTelegramRecv.SELECT_DATA("DSPRET_STATE")                      '�����ð��
        strRET_MESSAGE_EXIST = objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE_EXIST")      '����ү���ޗL��
        strRET_MESSAGE = Trim(objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE"))            '����ү����
        strRET_DATA_SYUBETU = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA_SYUBETU"))  '�����ް����
        strRET_DATA = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA"))                  '�����ް�


        '---------------------------------
        'ү���ޕ\��
        '---------------------------------
        If Trim(strRET_MESSAGE_EXIST) = ID_RETURN_RET_MESSAGE_EXIST_YES Then

            Select Case Trim(strRET_STATE)
                Case ID_RETURN_RET_STATE_OK
                    Call gobjComFuncFRM.DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Information, "", FRM_MSG_SOCKSENDSERVER_91)
                Case ID_RETURN_RET_STATE_NG
                    Call gobjComFuncFRM.DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
                Case Else
                    Call gobjComFuncFRM.DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
            End Select

        End If


    End Sub
#End Region
#Region "  ASCII�ϊ����ݸد�����                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ASCII�ϊ����ݸد�����
    ''' </summary>
    ''' *******************************************************************************************************************
    ''' <remarks></remarks>
    Private Sub cmdASCIIProcess()


        '***************************************************
        '�F�X����
        '***************************************************
        Dim strASCII As String = txtASCII.Text
        If IsNumeric(strASCII) = False Then Throw New Exception("�e�L�X�g�{�b�N�X�ɂ́A�J���}��؂��0�`255�̐��l��ݒ肵�ĉ������B")
        If CInt(strASCII) < 0 Or 255 < CInt(strASCII) Then Throw New Exception("�e�L�X�g�{�b�N�X�ɂ́A�J���}��؂��0�`255�̐��l��ݒ肵�ĉ������B")


        '***************************************************
        '������ǉ�
        '***************************************************
        txtSendText.Text &= Chr(CInt(strASCII))


    End Sub
#End Region
#Region "  �Ǎ�̧�ٺ����ޯ���I��ύX����            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �Ǎ�̧�ٺ����ޯ���I��ύX����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFileSelChange()


        '*************************************************
        '��د�ޕ\��
        '*************************************************
        '=========================================
        'Config�擾
        '=========================================
        Dim strItemName As String = ""      '���і���
        Dim strData As String = ""          '�ް�
        Dim strItem As String = ""          '���і�
        Dim strSize As String = ""          '����
        Dim objDataTable As New GamenCommon.clsGridDataTable05          '�ް�ð���
        Dim objDocument As New System.Xml.XmlDocument       'XML�޷����
        Dim objNode As System.Xml.XmlNode                   'XMLɰ��
        objDocument.Load(cboFile.SelectedValue)             '�ް�۰��

        For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_HEADER)
            '(ٰ��:ɰ�ސ�)

            If objNode.Name = XML_NODE_ADD Then
                '(�ް���`�̏ꍇ)
                strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                strSize = objNode.Attributes.GetNamedItem(XML_NODE_VALUE).Value
            End If
            If objNode.NodeType = Xml.XmlNodeType.Comment Then
                strItemName = objNode.Value
                objDataTable.userAddRowDataSet(strItemName _
                                             , "" _
                                             , strItem _
                                             , strSize _
                                             )
            End If

        Next

        '=========================================
        '��د�ޕ\��
        '=========================================
        grdSockHeader.DataSource = objDataTable

        '=========================================
        '��د�ޕ\���ݒ�
        '=========================================
        Call grdListSetup(grdSockHeader)


        '*************************************************
        '��د���ް����
        '*************************************************
        If cboFile.SelectedValue = CONFIG_TELEGRAM_DSP Then
            '(��ʗp���Ă̏ꍇ)
            grdSockHeader.Item(menmListCol.Data, GRIDHEADER_ROW_DSPTERM_ID).Value = gcstrFTERM_ID       '�[��ID
            grdSockHeader.Item(menmListCol.Data, GRIDHEADER_ROW_DSPUSER_ID).Value = gcstrFUSER_ID         'հ�ްID
        End If



        '*************************************************
        '����ޑI������ޯ���쐬
        '*************************************************
        Call cboCommandNoMake()


    End Sub
#End Region
#Region "  ���M÷���ޯ��÷�ĕύX����                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���M÷���ޯ��÷�ĕύX����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtSendTextTextChangedProcess()

        If txtSendText.Text = "" Then
            grdSockData.Visible = True
            grdSockHeader.Visible = True
        Else
            grdSockData.Visible = False
            grdSockHeader.Visible = False
        End If

    End Sub
#End Region

#Region "�@�ް���د�ޕ\���ݒ�                       "
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
        objGrid.AllowUserToResizeColumns = False                            '��̻��ޕύX       ���ݒ�
        objGrid.MultiSelect = False                                         '�����ٓ����I��     ���ݒ�
        objGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect     '�I��Ӱ��
        objGrid.AllowUserToAddRows = False                                  '�s�ǉ�             ���ݒ�
        objGrid.AllowUserToDeleteRows = False                               '�s�폜             ���ݒ�
        objGrid.AllowUserToResizeRows = False                               '�s���ޕύX         ���ݒ�
        objGrid.AllowUserToOrderColumns = False                             '��ړ�             ���ݒ�
        For Each objColum As DataGridViewColumn In objGrid.Columns
            objColum.SortMode = DataGridViewColumnSortMode.Programmatic     '��̕��֋֎~
        Next

        '***********************
        'ͯ�ް�\���ύX
        '***********************
        objGrid.Columns(menmListCol.ItemName).HeaderText = "���і���"
        objGrid.Columns(menmListCol.Data).HeaderText = "�ް�"
        objGrid.Columns(menmListCol.Item).HeaderText = "���і�"
        objGrid.Columns(menmListCol.Size).HeaderText = "����"


        '***********************
        '�ް����z�u�ύX
        '***********************
        objGrid.Columns(menmListCol.ItemName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.Data).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.Item).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.Size).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        '***********************
        '��\��
        '***********************
        objGrid.Columns(menmListCol.Data04).Visible = False
        objGrid.Columns(menmListCol.Data05).Visible = False


        '***********************
        '�񕝒���
        '***********************
        objGrid.Columns(menmListCol.ItemName).Width = 150
        objGrid.Columns(menmListCol.Data).Width = 150
        objGrid.Columns(menmListCol.Item).Width = 150
        objGrid.Columns(menmListCol.Size).Width = 40


        '***********************
        '�ҏWۯ�
        '***********************
        objGrid.Columns(menmListCol.ItemName).ReadOnly = True
        objGrid.Columns(menmListCol.Data).ReadOnly = False
        objGrid.Columns(menmListCol.Item).ReadOnly = True
        objGrid.Columns(menmListCol.Size).ReadOnly = True


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
#Region "�@����ޑI������ޯ���쐬                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����ޑI������ޯ���쐬
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboCommandNoMake()
        Dim strDisp As String = ""                          '�����ޯ���\���ް�
        Dim strData As String = ""                          '�����ޯ�������ް�
        Dim objNode As System.Xml.XmlNode                   'XMLɰ��
        Dim objDocument As New System.Xml.XmlDocument       'XML�޷����
        Dim aryData As ArrayList = New ArrayList


        '***********************
        'XML�Ǎ�
        '***********************
        objDocument.Load(cboFile.SelectedValue)             '�ް�۰��
        cboCommandID.DataSource = Nothing
        For Each objNode In objDocument(XML_NODE_CONFIG).ChildNodes
            '(ٰ��:��`���ꂽɰ�ސ�)

            If IsNull(objNode.Value) = False Then
                strDisp = objNode.Value  '���ĕ��擾
            End If
            strData = objNode.Name       'ɰ�ޖ��擾
            If 1 <= InStr(strData, XML_NODE_ID_PREFIX) Then
                aryData.Add(New GamenCommon.clsCboData(strDisp, strData))
            End If

        Next
        cboCommandID.DisplayMember = GamenCommon.clsCboData.DISPLAYMEMBER
        cboCommandID.ValueMember = GamenCommon.clsCboData.VALUEMEMBER
        cboCommandID.DataSource = aryData
        cboCommandID.SelectedIndex = 0


        '*************************************************
        '�\�����ݸد�����
        '*************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "�@�ݒ����د�ލ쐬                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݒ����د�ލ쐬
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSockConfigMake()


        '*************************************************
        '�ް����
        '*************************************************
        Dim objDataTable As New GamenCommon.clsGridDataTable05          '�ް�ð���
        objDataTable.userAddRowDataSet("���M����ڽ", gcstrSOCK_SEND_ADDRESS)
        objDataTable.userAddRowDataSet("�߰�No", gcstrSOCK_SEND_PORT)
        objDataTable.userAddRowDataSet("��ѱ��", gcstrSOCK_SEND_TIME_OUT)


        '*************************************************
        '��د�ޕ\��
        '*************************************************
        grdSockConfig.DataSource = objDataTable


        '*************************************************
        '��د�ޕ\���ݒ�
        '*************************************************
        Call grdListSetup(grdSockConfig)
        grdSockConfig.Columns(menmListCol.ItemName).Width = 90
        grdSockConfig.Columns(menmListCol.Data).Width = 131
        grdSockConfig.Columns(menmListCol.Item).Visible = False
        grdSockConfig.Columns(menmListCol.Size).Visible = False


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

End Class