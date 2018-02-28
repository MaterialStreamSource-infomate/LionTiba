'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ذ���
' �y�쐬�zSIT
'**********************************************************************************************

#Region " Imports                                "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100002

#Region "  �����ϐ�                             "
    '************************************************************************
    ' �����ϐ�
    '************************************************************************
    Private mblnTreeViewClick As Boolean            '�ذ�ޭ����د����ꂽ����������׸�

    '----------------------------------------
    ' �����è�p�ϐ�
    '----------------------------------------
    Private mblnCANCEL As Boolean           '��ݾ�
    Private mstrNowDispID As String         '���݂�         ���ID
    Private mstrNextDISP_ID As String       '���ɓW�J����   ���ID

    '----------------------------------------
    ' Config    �擾�ް�
    '----------------------------------------
    Private minttmrTest_1_Interval As Integer       '��ʑJ��ýėp            ��ϰ
    Private mstrTMRTEST_1_Flag As String            '��ʑJ��ýėp            ��ϰ�׸�

#End Region

#Region "  TreeNode.Tag�����è�ɑ}������        ��޼ު�ĸ׽"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' TreeNode.Tag�����è�ɑ}�������޼ު�ĸ׽
    ''' </summary>
    ''' <remarks>���ɕK�v�ȍ��ڂ��o�ė��邩������Ȃ��̂ŁA�ꉞ�׽�ɂ��Ă݂�</remarks>
    ''' *******************************************************************************************************************
    Private Class clsTreeNode_Tag

        '���ʕϐ�
        Private mSTRDISP_ID As String       '���ID

        '�����è
        Public Property STRDISP_ID() As String
            Get
                Return mSTRDISP_ID
            End Get
            Set(ByVal Value As String)
                mSTRDISP_ID = Value
            End Set
        End Property

    End Class
#End Region
#Region "  �����è                              "
    Public ReadOnly Property CANCEL() As Boolean
        Get
            Return mblnCANCEL
        End Get
    End Property

    Public Property NowDispID() As String
        Get
            Return mstrNowDispID
        End Get
        Set(ByVal Value As String)
            mstrNowDispID = Value
        End Set
    End Property

    Public ReadOnly Property NextDISP_ID() As String
        Get
            Return mstrNextDISP_ID
        End Get
    End Property

#End Region
#Region "  ����ā@�@�@�@�@                      "
#Region "  ̫��۰��                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmTree_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call FormLoad()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F8(�߂�)  ����                   �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(�߂�)  ���ݸد�"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF8.Click
        Try

            Call cmdF8Proc()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �ذɰ��                      �I�𒼌�i�د��ȊO��A��۸��ёI�����ł������j"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ذɰ�� �I�𒼌�i�د��ȊO��A��۸��ёI�����ł������j
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub trvTree_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvTree.AfterSelect
        Try
            Dim intRet As Integer

            '***************************************************
            ' �ذ�ޭ������ʑJ��
            '***************************************************
            If mblnTreeViewClick = True Then
                intRet = NextForm(sender, e)
            End If

            If intRet <> RetCode.OK Then
                mblnTreeViewClick = False
            End If


            '''''If mblnTrvClick = True Then
            '''''Call StartProc_FromTreeView(sender, e)
            '''''If Me.CANCEL = False Then
            '''''    Me.Close()
            '''''End If
            '''''End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �ذ�ޭ�                          �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ذ�ޭ� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub trvTree_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvTree.Click
        Try

            mblnTreeViewClick = True

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �ذɰ�ނ̂Ȃ�����ϳ�����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ذɰ�ނ̂Ȃ�����ϳ����� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub trvTree_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvTree.MouseDown
        Try

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ̧ݸ��ݷ�                    ��������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̧ݸ��ݷ���������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmTree_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Select Case e.KeyCode
                Case Windows.Forms.Keys.F8
                    cmdF8Proc()
            End Select


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  Enter��                      ��������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Enter����������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub trvTree_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles trvTree.KeyDown
        Try
            '***************************************************
            ' �ذ�ޭ������ʑJ��
            '***************************************************
            If e.KeyCode = Keys.Enter Then
                Call NextForm(sender, e)
            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ��ʑJ��ý�                      ��ϰ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʑJ��ý���ϰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrTest_1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTest_1.Tick
        Try
            Call FORM_MOVE_TEST()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ̫��۰��         ����                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()
        Try
            '*************************************************
            'Confiģ�َ擾
            '*************************************************
            minttmrTest_1_Interval = Val(gobjComFuncFRM.GET_CONFIG_INFO(GKEY_tmrTest_1_Interval))      '��ʑJ��ýėp            ��ϰ
            mstrTMRTEST_1_Flag = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_TMRTEST_1_FLG)                    '��ʑJ��ýėp            ��ϰ�׸�


            '*************************************************
            '��ϰ������
            '*************************************************
            tmrTest_1.Interval = minttmrTest_1_Interval
            Select Case mstrTMRTEST_1_Flag
                Case FLAG_ON
                    tmrTest_1.Enabled = True
                Case Else
                    tmrTest_1.Enabled = False
            End Select


            '*************************************************
            '���ʕϐ�    ������
            '*************************************************
            '------------------------------
            '�����è�ϐ�    ������
            '------------------------------
            mblnCANCEL = True


            '------------------------------
            '���̑�
            '------------------------------
            mblnTreeViewClick = False


            '*************************************************
            ' �ذ�ޭ��\��
            '*************************************************
            Call Make_Tree()


            '*************************************************
            ' �ذ�ޭ��I��
            '*************************************************
            trvTree.Select()


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  F8(�߂�)  ���݉���     ����          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(�߂�)  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8Proc()
        Try

            mblnCANCEL = True                                   '��ݾ������è   ���
            Me.DialogResult = Windows.Forms.DialogResult.No     '���g��\���i��\�����Ă��邾���j
            tmrTest_1.Enabled = False                           '��ʑJ��ý�      ��ϰ����  ��

        Catch ex As Exception
            ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

    '************************************************************************
    ' ��ײ�ްĊ֐�
    '************************************************************************

#Region "  �ذ�ޭ��\��                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ذ�ޭ��\��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Make_Tree()
        Try
            'DB�֌W
            Dim strSQL As String                    'SQL��
            Dim objDataSet As New DataSet           '�ް����
            Dim strDataSetName As String            '�ް���Ė�
            Dim objRow As DataRow                   '1ں��ޕ����ް�
            Dim intRet As RetCode                   '�ߒl�p

            '�ذ�ޭ��֌W
            Dim objTreeNode(0) As TreeNode          '�ذɰ��
            Dim strBefore_ID(9) As String           '�O����ذID
            Dim strNow_ID(9) As String              '������ذID
            Dim intBefore_Level As Integer = 0      '�O���ɰ�ނ�ǉ������K�w���L��
            Dim objTemp_TrNode(9) As TreeNode       'ɰ�ނ̋L��
            Dim blnExit_For As Boolean = False      'ٰ�ߒE�o�׸�

            '���̑�
            Dim ii As Integer = 0



            '**********************************************************************************
            ' �����ݒ�
            '**********************************************************************************
            '--------------------------------
            '���̑�         ������
            '--------------------------------
            ii = 0
            intBefore_Level = 0
            blnExit_For = False
            trvTree.Nodes.Clear()               '�ڸ��݂���A���ׂĂ��ذɰ�ނ��폜
            For jj As Integer = 0 To 9
                strBefore_ID(jj) = "00"
                strNow_ID(jj) = "00"
            Next


            '**********************************************************************************
            ' DB�����ް��擾
            '**********************************************************************************
            '-----------------------
            '���oSQL�쐬
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    TDSP_TREE.FTREE_ID             FTREE_ID"            '����ذϽ�.    �ذID
            strSQL &= vbCrLf & "  , TDSP_TREE.FDISP_ID             FDISP_ID"            '����ذϽ�.    �J�ډ\���ID
            strSQL &= vbCrLf & "  , TDSP_NAME.FOBJECT_NAME          FOBJECT_NAME"         '���Ͻ�.       ��ʖ���
            strSQL &= vbCrLf & "  , TDSP_PMT_TERM.FOPE_FLAG        FOPE_FLAG_T"         '�[���ʋ���Ͻ�. �����׸�
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TDSP_TREE"      '����ذϽ�
            strSQL &= vbCrLf & "  , TDSP_NAME"      '���Ͻ�
            strSQL &= vbCrLf & "  , (SELECT * FROM TDSP_PMT_TERM WHERE TDSP_PMT_TERM.FTERM_KUBUN = " & TO_STRING(gcintFTERM_KBN) & " AND TDSP_PMT_TERM.FCTRL_ID = '" & FCTRL_ID_SKOTEI & "') TDSP_PMT_TERM"            '�[���ʋ���Ͻ�
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "        TDSP_TREE.FDISP_ID = TDSP_NAME.FDISP_ID(+) "            '���ID     ����
            strSQL &= vbCrLf & "    AND TDSP_NAME.FDISP_ID = TDSP_PMT_TERM.FDISP_ID "           '���ID     ����
            strSQL &= vbCrLf & "    AND TDSP_NAME.FCTRL_ID = TDSP_PMT_TERM.FCTRL_ID "     '���۰�ID   ����
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "    TDSP_TREE.FTREE_ID "

            '-----------------------
            '���o
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TDSP_TREE"
            gobjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows
                    '**********************************************************************************
                    ' �ް��擾
                    '**********************************************************************************
                    Dim strFTREE_ID As String = TO_STRING(objRow("FTREE_ID"))
                    Dim strFDISP_ID As String = TO_STRING(objRow("FDISP_ID"))
                    Dim strFOBJECT_NAME As String
                    strFOBJECT_NAME = Replace(TO_STRING(objRow("FOBJECT_NAME")), REPLACE_STRING_01, "")
                    strFOBJECT_NAME = Replace(strFOBJECT_NAME, vbCrLf, "")
                    Dim intFOPE_FLAG_Term As Integer = 0            '�����׸�   (�[���ʋ���Ͻ��p)
                    intFOPE_FLAG_Term = IIf(IsDBNull(objRow("FOPE_FLAG_T")), gcintOPE_FLG, TO_NUMBER(objRow("FOPE_FLAG_T")))
                    If intFOPE_FLAG_Term <> FOPE_FLAG_SON Then
                        Continue For
                    End If


                    '**********************************************************************************
                    ' '�[���ʋ���Ͻ��̓���
                    '**********************************************************************************
                    Dim intFOPE_FLAG_User As Integer = 0            '�����׸�   (հ�ޕʋ���Ͻ��p)
                    Dim strSQLUserLevel As String = ""              'հ�����ق�SQL����
                    For jj As Integer = LBound(gcintFUSER_LEVEL) To UBound(gcintFUSER_LEVEL)
                        '(ٰ��:�^����ꂽհ�����ِ�)

                        Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)   'հ�ް����Ͻ�
                        objTDSP_PMT_USER.FUSER_DSP_LEVEL = gcintFUSER_LEVEL(jj)     'հ�ް��������  ���
                        objTDSP_PMT_USER.FDISP_ID = strFDISP_ID                     '���ID
                        objTDSP_PMT_USER.FCTRL_ID = FCTRL_ID_SKOTEI                  '���۰�ID
                        intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)          '�擾
                        If intRet = RetCode.OK Then
                            intFOPE_FLAG_User = objTDSP_PMT_USER.FOPE_FLAG
                        Else
                            intFOPE_FLAG_User = gcintOPE_FLG
                        End If
                        If intFOPE_FLAG_User = FOPE_FLAG_SON Then Exit For

                    Next


                    '**********************************************************************************
                    ' TreeNode.Tag�����è�ɑ}������        ��޼ު�ĸ׽�ݽ�ݽ��
                    '**********************************************************************************
                    Dim objTreeNode_Tag As New clsTreeNode_Tag


                    '**********************************************************************************
                    ' ɰ�ލ쐬
                    '**********************************************************************************
                    '--------------------------------
                    ' �ݽ�ݽ��
                    '--------------------------------
                    ReDim Preserve objTreeNode(ii)                                 '�z��Ē�`
                    objTreeNode(ii) = New TreeNode(strFOBJECT_NAME, 1, 1)            'ɰ�޲ݽ�ݽ��

                    '--------------------------------
                    ' �F�ݒ�
                    '--------------------------------
                    If strFDISP_ID = "" _
                       Or strFDISP_ID = mstrNowDispID _
                       Or intFOPE_FLAG_Term = FOPE_FLAG_SOFF _
                       Or intFOPE_FLAG_User = FOPE_FLAG_SOFF _
                       Then
                        objTreeNode(ii).ForeColor = Color.LightGray                'ɰ�ސF�ݒ� �i�D�F�j
                    Else
                        objTreeNode(ii).ForeColor = Color.Black                    'ɰ�ސF�ݒ� �i���F�j
                    End If

                    '--------------------------------
                    ' �׽��޼ު�āi���ID��āj
                    '--------------------------------
                    objTreeNode_Tag.STRDISP_ID = strFDISP_ID     '���ID���
                    objTreeNode(ii).Tag = objTreeNode_Tag       '��޼ު�ľ��
                    objTreeNode_Tag = Nothing                   '��޼ު�ĊJ��


                    '**********************************************************************************
                    ' �ذID����
                    '**********************************************************************************
                    Call Analysis_STRTREE_ID(strNow_ID, strFTREE_ID)


                    '**********************************************************************************
                    ' �ذ�쐬
                    '**********************************************************************************
                    For jj As Integer = LBound(strNow_ID) To UBound(strNow_ID)
                        If strNow_ID(jj) <> strBefore_ID(jj) Then
                            '**********************************************************************************
                            ' ɰ�ޒǉ�
                            '**********************************************************************************
                            If jj = 0 Then
                                '=======================================================
                                ' �ذ   ��ɰ�ޒǉ�
                                '=======================================================
                                trvTree.Nodes.Add(objTreeNode(ii))                 ' �ذ   ���ذɰ�ޒǉ�

                            Else
                                '=======================================================
                                ' ɰ��  ��ɰ�ޒǉ�
                                '=======================================================
                                If intBefore_Level >= jj Then
                                    '--------------------------------------
                                    ' �O��̊K�w��ɰ��      ��ɰ�ޒǉ�
                                    '--------------------------------------
                                    objTreeNode(jj - 1).Nodes.Add(objTreeNode(ii))    ' �ذɰ��   ���ذɰ�ޒǉ�
                                Else
                                    '--------------------------------------
                                    ' �O���ɰ��            ��ɰ�ޒǉ�
                                    '--------------------------------------
                                    objTreeNode(ii - 1).Nodes.Add(objTreeNode(ii))    ' �ذɰ��   ���ذɰ�ޒǉ�
                                End If
                            End If

                            objTreeNode(jj) = objTreeNode(ii)                   ' �O��̊K�w���ذɰ��           ���L��
                            intBefore_Level = jj                                ' �O����ذɰ�ނ�ǉ������K�w   ���L��
                            Exit For
                        End If

                        '=======================================================
                        ' �����h�~
                        '=======================================================
                        If jj >= intBefore_Level + 2 Then
                            Throw New Exception("Ͻ��̒�`�̎d�����Ԉ���Ă��܂��B")
                        End If
                    Next


                    '=======================================================
                    ' �ذID     �L��
                    '=======================================================
                    For jj As Integer = 0 To 9
                        strBefore_ID(jj) = strNow_ID(jj)
                    Next

                    ii += 1
                Next
            End If



            '*****************************************************************************
            ' ���݂�̫�т̏ꏊ�܂�ɰ�ނ�W�J
            '*****************************************************************************
            Call Development_TreeView()



        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  �ذ�ޭ������ʑJ��  �����è���      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ذ�ޭ������ʑJ�� �����è��� 
    ''' </summary>
    ''' <param name="sender">����Ă̿��</param>
    ''' <param name="e">������ް����i�[���Ă���System.EventArgs</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function NextForm(ByVal sender As Object, _
                              ByVal e As System.EventArgs) As Integer
        Dim objTreeView As TreeView = CType(sender, TreeView)
        Dim objTreeNode_Tag As clsTreeNode_Tag                      'TreeNode.Tag�����è�ɑ}������  ��޼ު�ĸ׽


        '*******************************************************
        ' �I��s�̏ꍇ�AExit
        '*******************************************************
        Select Case objTreeView.SelectedNode.ForeColor.ToString
            Case Color.LightGray.ToString
                Return (RetCode.NotEnough)
        End Select


        '*******************************************************
        ' ��ʑJ�ڏ���
        '*******************************************************
        objTreeNode_Tag = objTreeView.SelectedNode.Tag              '�׽��޼ު�Ď擾
        mstrNextDISP_ID = objTreeNode_Tag.STRDISP_ID                '���ɓW�J����   ���ID���
        mblnCANCEL = False                                          '��ݾ������è   ���
        Me.Close()

        Return (RetCode.OK)
    End Function
#End Region
#Region "  �װ����                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="ex">�װ�� Exception</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub ComError(ByVal ex As Exception)
        Try

            gobjComFuncFRM.ComError_frm(ex)

        Catch ex2 As Exception
            MsgBox("ComError�֐��Ŵװ����")

        End Try
    End Sub
#End Region
#Region "  �ذID������      ����                "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  �ذID�����񕪉�
    ''' </summary>
    ''' <param name="strNow_ID"></param>
    ''' <param name="strTREE_ID"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Analysis_STRTREE_ID(ByRef strNow_ID() As String, _
                                    ByVal strTREE_ID As String)
        '=======================================================
        ' �����h�~
        '=======================================================
        If Len(strTREE_ID) <> 20 Then
            Throw New Exception("Ͻ��̒�`�̎d�����Ԉ���Ă��܂��B�uSTRTREE_ID�v�͕K��20���œ��͂��ĉ������B")
        End If

        strNow_ID(0) = Mid(strTREE_ID, 1, 2)
        strNow_ID(1) = Mid(strTREE_ID, 3, 2)
        strNow_ID(2) = Mid(strTREE_ID, 5, 2)
        strNow_ID(3) = Mid(strTREE_ID, 7, 2)
        strNow_ID(4) = Mid(strTREE_ID, 9, 2)
        strNow_ID(5) = Mid(strTREE_ID, 11, 2)
        strNow_ID(6) = Mid(strTREE_ID, 13, 2)
        strNow_ID(7) = Mid(strTREE_ID, 15, 2)
        strNow_ID(8) = Mid(strTREE_ID, 17, 2)
        strNow_ID(9) = Mid(strTREE_ID, 19, 2)
    End Sub
#End Region
#Region "  ���݂�̫�т̏ꏊ�܂�ɰ�ނ�W�J       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���݂�̫�т̏ꏊ�܂�ɰ�ނ�W�J
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Development_TreeView()

        Dim Node0 As TreeNode
        Dim Node1 As TreeNode
        Dim Node2 As TreeNode
        Dim Node3 As TreeNode
        Dim Node4 As TreeNode
        Dim Node5 As TreeNode
        Dim Node6 As TreeNode
        Dim Node7 As TreeNode
        Dim Node8 As TreeNode
        Dim Node9 As TreeNode

        Dim objTreeNode_Tag As clsTreeNode_Tag
        Dim blnExit_For As Boolean = False      'ٰ�ߒE�o�׸�


        trvTree.CollapseAll()                   '�S�Ă��ذɰ�ނ����
        '' ''trvTree.ExpandAll()                     '�S�Ă��ذɰ�ނ�W�J

        For Each Node0 In trvTree.Nodes
            objTreeNode_Tag = Node0.Tag
            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                trvTree.SelectedNode = Node0
                Node0.Expand()
                blnExit_For = True

            Else
                For Each Node1 In Node0.Nodes
                    objTreeNode_Tag = Node1.Tag
                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                        trvTree.SelectedNode = Node1
                        Node1.Expand()
                        blnExit_For = True

                    Else
                        For Each Node2 In Node1.Nodes
                            objTreeNode_Tag = Node2.Tag
                            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                trvTree.SelectedNode = Node2
                                Node2.Expand()
                                blnExit_For = True

                            Else
                                For Each Node3 In Node2.Nodes
                                    objTreeNode_Tag = Node3.Tag
                                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                        trvTree.SelectedNode = Node3
                                        Node3.Expand()
                                        blnExit_For = True

                                    Else
                                        For Each Node4 In Node3.Nodes
                                            objTreeNode_Tag = Node4.Tag
                                            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                trvTree.SelectedNode = Node4
                                                Node4.Expand()
                                                blnExit_For = True

                                            Else
                                                For Each Node5 In Node4.Nodes
                                                    objTreeNode_Tag = Node5.Tag
                                                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                        trvTree.SelectedNode = Node5
                                                        Node5.Expand()
                                                        blnExit_For = True

                                                    Else
                                                        For Each Node6 In Node5.Nodes
                                                            objTreeNode_Tag = Node6.Tag
                                                            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                                trvTree.SelectedNode = Node6
                                                                Node6.Expand()
                                                                blnExit_For = True

                                                            Else
                                                                For Each Node7 In Node6.Nodes
                                                                    objTreeNode_Tag = Node7.Tag
                                                                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                                        trvTree.SelectedNode = Node7
                                                                        Node7.Expand()
                                                                        blnExit_For = True

                                                                    Else
                                                                        For Each Node8 In Node7.Nodes
                                                                            objTreeNode_Tag = Node8.Tag
                                                                            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                                                trvTree.SelectedNode = Node8
                                                                                Node8.Expand()
                                                                                blnExit_For = True

                                                                            Else
                                                                                For Each Node9 In Node8.Nodes
                                                                                    objTreeNode_Tag = Node9.Tag
                                                                                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                                                        trvTree.SelectedNode = Node9
                                                                                        Node9.Expand()
                                                                                        blnExit_For = True

                                                                                    Else
                                                                                        '-----�I��

                                                                                    End If
                                                                                    If blnExit_For = True Then Exit For
                                                                                Next

                                                                            End If
                                                                            If blnExit_For = True Then Exit For
                                                                        Next

                                                                    End If
                                                                    If blnExit_For = True Then Exit For
                                                                Next

                                                            End If
                                                            If blnExit_For = True Then Exit For
                                                        Next

                                                    End If
                                                    If blnExit_For = True Then Exit For
                                                Next

                                            End If
                                            If blnExit_For = True Then Exit For
                                        Next

                                    End If
                                    If blnExit_For = True Then Exit For
                                Next

                            End If
                            If blnExit_For = True Then Exit For
                        Next

                    End If
                    If blnExit_For = True Then Exit For
                Next

            End If
            If blnExit_For = True Then Exit For
        Next

    End Sub
#End Region
#Region "  ��ʑJ��ý�      ��ϰ����            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʑJ��ý���ϰ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FORM_MOVE_TEST()

        If Me.Visible = True Then

            gobjComFuncFRM.AddToLog_frm("frmCR2101�֑J��")
            Call cmdF8Proc()
        End If

    End Sub
#End Region

End Class