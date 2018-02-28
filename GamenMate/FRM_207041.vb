'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�d����͉��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_207041

#Region "�@���ʕϐ��@                           "

    '�����è
    Private mstrEQ_ID As String             '�ݔ�ID(PLC�EALC)
    Private mstrDIRECTION As String         '����
    Private mstrTEXT_ID As String           '÷��ID
    Private mstrDENBUN As String            '�d��
    Private mobjOwner As FRM_207040         '��Ű̫��

    Enum menmListCol
        DENBUN_NAME         '�d������
        DENBUN_CONTENTS     '���e
        DATA02              '���g�p
        DATA03              '���g�p
        DATA04              '���g�p
        DATA05              '���g�p

        MAXCOL

    End Enum

#End Region
#Region "  �����è��`�@                        "
    ''' =======================================
    ''' <summary>��Ű̫��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userOWNER() As FRM_207040
        Get
            Return mobjOwner
        End Get
        Set(ByVal Value As FRM_207040)
            mobjOwner = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�ݔ�ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userEQ_ID() As String
        Get
            Return mstrEQ_ID
        End Get
        Set(ByVal Value As String)
            mstrEQ_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>����</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userDIRECTION() As String
        Get
            Return mstrDIRECTION
        End Get
        Set(ByVal Value As String)
            mstrDIRECTION = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>÷��ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userTEXT_ID() As String
        Get
            Return mstrTEXT_ID
        End Get
        Set(ByVal Value As String)
            mstrTEXT_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�d��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userDENBUN() As String
        Get
            Return mstrDENBUN
        End Get
        Set(ByVal Value As String)
            mstrDENBUN = Value
        End Set
    End Property

#End Region
#Region "�@����ā@                              "
#Region "�@̫��۰�ށ@                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_207041_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "�@̫�ѱ�۰�ށ@                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѱ�۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_207041_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "�@����   ���݉�������                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���� ���݉�������
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
#Region "�@̫�ѱ�è��                           "
    '*******************************************************************************************************************
    '�y�@�\�z̫�ѱ�è�ގ������
    '�y�����z
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub FRM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          '��̫��̫����̖�����

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "  ̫��۰�ޏ���                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�� ����
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadProcess()

        '**********************************************************
        ' ��د�ޕ\��
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  '��د�ޏ����ݒ�
        Call grdListDisplay()


    End Sub
#End Region
#Region "�@̫�ѱ�۰�ޏ���                       "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѱ�۰�� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub ClosingProcess()

        '**********************************************************
        ' ���۰يJ��
        '**********************************************************
        grdList.Dispose()

    End Sub
#End Region
#Region "�@����   �@���݉��������@            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���� ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProcess()

        Me.Close()

    End Sub

#End Region
#Region "  ��د�ޕ\���@                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay()

        'Dim strTelConfigPath As String

        Select Case mstrEQ_ID
            Case FEQ_ID_JSYS0000, FEQ_ID_JSYS0001, FEQ_ID_JSYS0002, FEQ_ID_JSYS0003, FEQ_ID_JSYS0004, FEQ_ID_JSYS0005, FEQ_ID_JSYS0006
                '********************************************************************
                '����PLC�AMELSEC�̂Ƃ�
                '********************************************************************
                Call TelegramDisp_Bunkai()

            Case FEQ_ID_JSYS0101
                '********************************************************************
                '�ԗ����۰ׂ̂Ƃ�
                '********************************************************************


                If mstrTEXT_ID = FTEXT_ID_JR_CARD Then
                    Call TelegramDisp_CARD01()
                ElseIf mstrTEXT_ID = FTEXT_ID_JS_CARD01 Then
                    Call TelegramDisp_CARD01()

                ElseIf mstrTEXT_ID = FTEXT_ID_JS_CARD02 Then
                    Call TelegramDisp_CARD02()
                End If




        End Select

    End Sub
#End Region
#Region "  ��د�ޕ\���ݒ�@                     "
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

    End Sub

#End Region
#Region "�@�d�������د�ޕ\��(JOB�ŗL)          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �d�������د�ޕ\��(JOB�ŗL)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TelegramDisp_Bunkai()

        Dim objDataTable As New GamenCommon.clsGridDataTable05          '��د�ޗp�ް�ð���

        Dim strDENBUN_BEFORE As String                      '����O�d��
        Dim strDENBUN_ARY(RTNSiziArray.MAX) As String       '������d��

        strDENBUN_BEFORE = mstrDENBUN
        strDENBUN_BEFORE = strDENBUN_BEFORE.Replace("][", "],[")
        strDENBUN_ARY = Split(strDENBUN_BEFORE, KUGIRI01)

        For jj As Integer = LBound(strDENBUN_ARY) To UBound(strDENBUN_ARY)
            '(ٰ��:�z�񐔕�)

            Dim strDENBUN_ARY_ROW(1) As String
            strDENBUN_ARY_ROW = Split(strDENBUN_ARY(jj), ":")

            strDENBUN_ARY_ROW(0) = Trim(strDENBUN_ARY_ROW(0).Replace("[", ""))
            strDENBUN_ARY_ROW(1) = Trim(strDENBUN_ARY_ROW(1).Replace("]", ""))


            '**********************************
            '�s�ǉ�
            '**********************************
            Call objDataTable.userAddRowDataSet(strDENBUN_ARY_ROW(0) _
                                              , strDENBUN_ARY_ROW(1) _
                                              )

        Next

        '������������************************************************************************************************************
        'CommentMate:A.Noto 2012/06/26 ��Őݒ�K�{
        ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
        ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) Then
        ''    '(�o�Ɍv��d���̎�)

        ''    For ii = 1 To intDataKensu - 1
        ''        '(�ް��������A2���ڂ���)
        ''        kk = ii * 60 + 31           '�d�����̌��ʒu

        ''        For jj As Integer = 0 To 7
        ''            '(���׍��ڕ�)
        ''            strDenData = Mid(mstrDENBUN, kk, intDenLeng(jj))            '���e
        ''            objDataTable.userAddRowDataSet("�m" & Microsoft.VisualBasic.Right("00" & TO_STRING(ii + 1), 2) & "�n" & _
        ''                                        strDenName(jj), strDenData)  '�d�����́A���e�̾��

        ''            kk += intDenLeng(jj)    '���ڌ��������Z
        ''        Next
        ''    Next
        ''End If
        '������������************************************************************************************************************


        '********************************************************************
        '��د�ޕ\��
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, grdList, True)
        objDataTable = Nothing


        '********************************************************************
        '��د�ޕ\���ݒ�
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      '��د�ޑI������


    End Sub
#End Region

#Region "�@�d�������د�ޕ\��(����1�p)          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �d�������د�ޕ\��(����1�p)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TelegramDisp_CARD01()

        Dim objDataTable As New GamenCommon.clsGridDataTable05          '��د�ޗp�ް�ð���

        Dim strDENBUN_BEFORE As String                      '����O�d��
        Dim strDENBUN_ARY() As String                       '������d��

        strDENBUN_BEFORE = mstrDENBUN
        strDENBUN_ARY = Split(strDENBUN_BEFORE, "_")


        '**********************************
        '�s�ǉ�
        '**********************************
        '���亰��
        Call objDataTable.userAddRowDataSet("���亰��", _
                                            strDENBUN_ARY(0) & "_" & strDENBUN_ARY(1) _
                                          )
        '���ތ����@�敪
        Call objDataTable.userAddRowDataSet("���ތ����@�敪", _
                                            strDENBUN_ARY(2) & "_" & strDENBUN_ARY(3) _
                                          )
        '����ذ�ދ敪
        Call objDataTable.userAddRowDataSet("����ذ�ދ敪", _
                                            strDENBUN_ARY(4) & "_" & strDENBUN_ARY(5) _
                                          )
        '�����ް�
        Call objDataTable.userAddRowDataSet("�����ް�", _
                                            strDENBUN_ARY(6) & "_" & strDENBUN_ARY(7) & "_" & strDENBUN_ARY(8) & "_" & strDENBUN_ARY(9) & "_" & strDENBUN_ARY(10) & "_" & strDENBUN_ARY(11) _
                                          )
        '�\��
        Dim strYobi As String = ""
        Dim i As Long
        For i = 12 To UBound(strDENBUN_ARY)
            strYobi = strYobi & strDENBUN_ARY(i) & "_"
        Next
        strYobi = strYobi.Substring(0, Len(strYobi) - 1)

        Call objDataTable.userAddRowDataSet("�\��", _
                                            strYobi _
                                          )

        '********************************************************************
        '��د�ޕ\��
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, grdList, True)
        objDataTable = Nothing


        '********************************************************************
        '��د�ޕ\���ݒ�
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      '��د�ޑI������

        grdList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        grdList.ScrollBars = ScrollBars.Both

    End Sub
#End Region
#Region "�@�d�������د�ޕ\��(����2�p)          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �d�������د�ޕ\��(����2�p)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TelegramDisp_CARD02()

        Dim objDataTable As New GamenCommon.clsGridDataTable05          '��د�ޗp�ް�ð���

        Dim strDENBUN_BEFORE As String                      '����O�d��
        Dim strDENBUN_ARY() As String                       '������d��

        strDENBUN_BEFORE = mstrDENBUN
        strDENBUN_ARY = Split(strDENBUN_BEFORE, "_")


        '**********************************
        '�s�ǉ�
        '**********************************
        '���亰��
        Call objDataTable.userAddRowDataSet("���亰��", _
                                            strDENBUN_ARY(0) & "_" & strDENBUN_ARY(1) _
                                          )
        '���ތ����@�敪
        Call objDataTable.userAddRowDataSet("���ތ����@�敪", _
                                            strDENBUN_ARY(2) & "_" & strDENBUN_ARY(3) _
                                          )
        '����ذ�ދ敪
        Call objDataTable.userAddRowDataSet("����ذ�ދ敪", _
                                            strDENBUN_ARY(4) & "_" & strDENBUN_ARY(5) _
                                          )
        '��گ���
        Call objDataTable.userAddRowDataSet("��گ���", _
                                            strDENBUN_ARY(6) & "_" & strDENBUN_ARY(7) & "_" & strDENBUN_ARY(8) & "_" & strDENBUN_ARY(9) _
                                          )
        '�ԗ�No1
        Call objDataTable.userAddRowDataSet("�ԗ�No1", _
                                            strDENBUN_ARY(10) & "_" & strDENBUN_ARY(11) & "_" & strDENBUN_ARY(12) & "_" & strDENBUN_ARY(13) _
                                          )
        '�ԗ�No2
        Call objDataTable.userAddRowDataSet("�ԗ�No2", _
                                            strDENBUN_ARY(14) & "_" & strDENBUN_ARY(15) & "_" & strDENBUN_ARY(16) & "_" & strDENBUN_ARY(17) _
                                          )
        '�ԗ�No3
        Call objDataTable.userAddRowDataSet("�ԗ�No3", _
                                            strDENBUN_ARY(18) & "_" & strDENBUN_ARY(19) & "_" & strDENBUN_ARY(20) & "_" & strDENBUN_ARY(21) _
                                          )
        '�ԗ�No4
        Call objDataTable.userAddRowDataSet("�ԗ�No4", _
                                            strDENBUN_ARY(22) & "_" & strDENBUN_ARY(23) & "_" & strDENBUN_ARY(24) & "_" & strDENBUN_ARY(25) _
                                          )
        '�ԗ�No5
        Call objDataTable.userAddRowDataSet("�ԗ�No5", _
                                            strDENBUN_ARY(26) & "_" & strDENBUN_ARY(27) & "_" & strDENBUN_ARY(28) & "_" & strDENBUN_ARY(29) _
                                          )
        '�ԗ�No6
        Call objDataTable.userAddRowDataSet("�ԗ�No6", _
                                            strDENBUN_ARY(30) & "_" & strDENBUN_ARY(31) & "_" & strDENBUN_ARY(32) & "_" & strDENBUN_ARY(33) _
                                          )
        '�ԗ�No7
        Call objDataTable.userAddRowDataSet("�ԗ�No7", _
                                            strDENBUN_ARY(34) & "_" & strDENBUN_ARY(35) & "_" & strDENBUN_ARY(36) & "_" & strDENBUN_ARY(37) _
                                          )
        '�ԗ�No8
        Call objDataTable.userAddRowDataSet("�ԗ�No8", _
                                            strDENBUN_ARY(38) & "_" & strDENBUN_ARY(39) & "_" & strDENBUN_ARY(40) & "_" & strDENBUN_ARY(41) _
                                          )
        '�ԗ�No9
        Call objDataTable.userAddRowDataSet("�ԗ�No9", _
                                            strDENBUN_ARY(42) & "_" & strDENBUN_ARY(43) & "_" & strDENBUN_ARY(44) & "_" & strDENBUN_ARY(45) _
                                          )
        '�ԗ�No10
        Call objDataTable.userAddRowDataSet("�ԗ�No10", _
                                            strDENBUN_ARY(46) & "_" & strDENBUN_ARY(47) & "_" & strDENBUN_ARY(48) & "_" & strDENBUN_ARY(49) _
                                          )
        '���B����
        Call objDataTable.userAddRowDataSet("���B����", _
                                            strDENBUN_ARY(50) & "_" & strDENBUN_ARY(51) & "_" & strDENBUN_ARY(52) & "_" & strDENBUN_ARY(53) _
                                          )
        '���C����
        Call objDataTable.userAddRowDataSet("���C����", _
                                            strDENBUN_ARY(54) & "_" & strDENBUN_ARY(55) & "_" & strDENBUN_ARY(56) & "_" & strDENBUN_ARY(57) _
                                          )
        '�\��
        Dim strYobi As String = ""
        Dim i As Long
        For i = 58 To UBound(strDENBUN_ARY)
            strYobi = strYobi & strDENBUN_ARY(i) & "_"
        Next
        strYobi = strYobi.Substring(0, Len(strYobi) - 1)

        Call objDataTable.userAddRowDataSet("�\��", _
                                            strYobi _
                                          )

        '********************************************************************
        '��د�ޕ\��
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, grdList, True)
        objDataTable = Nothing


        '********************************************************************
        '��د�ޕ\���ݒ�
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      '��د�ޑI������

        grdList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        grdList.ScrollBars = ScrollBars.Both

    End Sub
#End Region

    '������������************************************************************************************************************
    'JobMate:A.Noto 2013/04/10 ���g�p
#Region "�@�d�������د�ޕ\��(���g�p)           "
    '''' *******************************************************************************************************************
    '''' <summary>
    '''' �d�������د�ޕ\��
    '''' </summary>
    '''' <param name="strTelConfigPath"></param>
    '''' <param name="strFORMAT_ID"></param>
    '''' <remarks></remarks>
    '''' *******************************************************************************************************************
    'Private Sub TelegramDisp(ByVal strTelConfigPath _
    '                       , ByVal strFORMAT_ID _
    '                       )


    ''********************************************************************
    ''�o�Ɍv��(BZ_HOSTSK0)��M�d������p
    ''********************************************************************
    'Dim intDataKensu As Integer = 0     '�ް�����
    'Dim strDenName(7) As String         '�d������
    'Dim intDenLeng(7) As Integer        '���e����
    'Dim strDenData As String = ""       '���e
    'Dim ii As Integer = 0
    'Dim kk As Integer = 0


    ''********************************************************************
    ''��M�d������
    ''********************************************************************
    'Dim objTelegram As New clsTelegram(strTelConfigPath)        '�d��
    'objTelegram.FORMAT_ID = strFORMAT_ID                        '̫�ϯĖ����
    'objTelegram.TELEGRAM_PARTITION = mstrDENBUN                 '��������d�����
    'objTelegram.PARTITION()


    ''********************************************************************
    ''ͯ�ް����Config�擾
    ''********************************************************************
    'Dim strItem As String = ""          '���і�
    'Dim strItemName As String = ""      '���і���
    'Dim objDataTable As New GamenCommon.clsGridDataTable05          '��د�ޗp�ް�ð���
    'Dim objDocument As New System.Xml.XmlDocument       'XML�޷����
    'Dim objNode As System.Xml.XmlNode                   'XMLɰ��
    'objDocument.Load(strTelConfigPath)                  '�ް�۰��
    'objDataTable.Clear()                                '�ް�ð��ٸر
    'For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_HEADER)
    '    '(ٰ��:ɰ�ސ�)

    '    If objNode.Name = XML_NODE_ADD Then
    '        '(�ް���`�̏ꍇ)
    '        strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
    '    End If
    '    If objNode.NodeType = Xml.XmlNodeType.Comment Then
    '        strItemName = LTrim(objNode.Value)
    '        If strItem <> "DUMMY" Then
    '            objDataTable.userAddRowDataSet(strItemName _
    '                                         , objTelegram.SELECT_HEADER(strItem) _
    '                                         )
    '            '������������************************************************************************************************************
    '            'CommentMate:A.Noto 2012/06/26 ��Őݒ�K�{
    '            ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    '            ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) And _
    '            ''   (strItem = "BZRECORD_NUM") Then
    '            ''    '(�o�Ɍv��d������p�A�ް������̎擾)
    '            ''    intDataKensu = TO_INTEGER(objTelegram.SELECT_HEADER(strItem))
    '            ''End If
    '            '������������************************************************************************************************************

    '        End If

    '    End If

    'Next


    ''********************************************************************
    ''�ް�����Config�擾
    ''********************************************************************
    'For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_ID_PREFIX & strFORMAT_ID)
    '    '(ٰ��:ɰ�ސ�)

    '    If objNode.Name = XML_NODE_ADD Then
    '        '(�ް���`�̏ꍇ)
    '        strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value

    '        ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    '        ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) Then
    '        ''    '(�o�Ɍv��d������p�A�e���ڒ��擾)
    '        ''    intDenLeng(ii) = objNode.Attributes.GetNamedItem(XML_NODE_VALUE).Value
    '        ''End If

    '    End If
    '    If objNode.NodeType = Xml.XmlNodeType.Comment Then
    '        strItemName = LTrim(objNode.Value)
    '        If strItem <> "DUMMY" Then
    '            ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    '            ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) And _
    '            ''   (intDataKensu > 1) Then
    '            ''    '(�o�Ɍv��d���ŁA�ް�������1��葽����)
    '            ''    objDataTable.userAddRowDataSet("�m01�n" & strItemName _
    '            ''                                 , objTelegram.SELECT_DATA(strItem) _
    '            ''                                 )
    '            ''Else
    '            '(�ȊO�̎�)
    '            objDataTable.userAddRowDataSet(strItemName _
    '                                         , objTelegram.SELECT_DATA(strItem) _
    '                                         )
    '            ''End If

    '            ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    '            ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) Then
    '            ''    '(�o�Ɍv��d������p�A�d�����̎擾)
    '            ''    strDenName(ii) = strItemName
    '            ''    ii += 1
    '            ''End If

    '        End If
    '    End If

    'Next

    ''������������************************************************************************************************************
    ''CommentMate:A.Noto 2012/06/26 ��Őݒ�K�{
    ' ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    ' ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) Then
    ' ''    '(�o�Ɍv��d���̎�)

    ' ''    For ii = 1 To intDataKensu - 1
    ' ''        '(�ް��������A2���ڂ���)
    ' ''        kk = ii * 60 + 31           '�d�����̌��ʒu

    ' ''        For jj As Integer = 0 To 7
    ' ''            '(���׍��ڕ�)
    ' ''            strDenData = Mid(mstrDENBUN, kk, intDenLeng(jj))            '���e
    ' ''            objDataTable.userAddRowDataSet("�m" & Microsoft.VisualBasic.Right("00" & TO_STRING(ii + 1), 2) & "�n" & _
    ' ''                                        strDenName(jj), strDenData)  '�d�����́A���e�̾��

    ' ''            kk += intDenLeng(jj)    '���ڌ��������Z
    ' ''        Next
    ' ''    Next
    ' ''End If
    ''������������************************************************************************************************************


    ''********************************************************************
    ''��د�ޕ\��
    ''********************************************************************
    'Call gobjComFuncFRM.GridDisplay(objDataTable, grdList, True)
    'objDataTable = Nothing


    ''********************************************************************
    ''��د�ޕ\���ݒ�
    ''********************************************************************
    'Call grdListSetup()
    'Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      '��د�ޑI������


    'End Sub
#End Region
    '������������************************************************************************************************************

End Class