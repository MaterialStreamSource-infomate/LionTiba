'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���ʊ֐�
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports      "
Imports System.Text
Imports System.Xml
Imports MateCommon.clsConst
Imports MateCommon
Imports JobCommon
Imports System.Net
Imports UserProcess
#End Region

Public Class clsComFuncFRM
    Inherits GamenCommon.clsComFuncGMN

    '**********************************************************************************************
    '���������ы���
#Region "  ��۰��ٕϐ�                          "

    '**********************************************************************************************
    '�@��۰��ٕϐ�
    '**********************************************************************************************
    Protected Friend Shared gobjComFuncFRM As New clsComFuncFRM   '���ʊ֐���޼ު��

    '��ʵ�޼ު��
    Public Shared gobjFRM_100001 As FRM_100001          '۸޲݉��
    Public Shared gobjFRM_100002 As FRM_100002          '�ذ���
    Public Shared gobjFRM_100004 As FRM_100004          'Wait���
    Public Shared gobjFRM_100005 As FRM_100005          '����۸޵݉��
    Public Shared gobjFRM_100006 As FRM_100006          '�߽ܰ�ޕύX���
    Public Shared gobjFRM_100007 As FRM_100007          '�߽ܰ�ފm�F���
    Public Shared gobjFRM_100102 As FRM_100102          '�m�F���1
    Public Shared gobjFRM_100103 As FRM_100103          '�m�F���2
    Public Shared gobjFRM_100104 As FRM_100104          '�߯�߱��߉��(�w�}�����s�����ޯ������)
    Public Shared gobjFRM_100105 As FRM_100105          '�m�F���3
    Public Shared gobjFRM_100201 As FRM_100201          '���R�����ޯ�����

    Public Shared gobjFRM_201000 As FRM_201000              '���C�����j���[
    Public Shared gobjFRM_202000 As FRM_202000              '���C�����j���[
    Public Shared gobjFRM_202001 As FRM_202001              '��d�i�[�Ή�����
    Public Shared gobjFRM_203000 As FRM_203000              '���o�ɋƖ����j���[
    Public Shared gobjFRM_204000 As FRM_204000              '�⍇�����j���[
    Public Shared gobjFRM_204010 As FRM_204010              '�݌ɖ⍇��
    Public Shared gobjFRM_204020 As FRM_204020              '�݌ɏڍז⍇��
    Public Shared gobjFRM_204030 As FRM_204030              '���o�Ɏ��і⍇��
    Public Shared gobjFRM_204050 As FRM_204050              '��Ɨ���⍇��
    Public Shared gobjFRM_204051 As FRM_204051              '��Ɨ����ڍ�
    Public Shared gobjFRM_204070 As FRM_204070              '�ύX����⍇��
    Public Shared gobjFRM_205000 As FRM_205000              '�����e�i���X���j���[
    Public Shared gobjFRM_205010 As FRM_205010              '�I�����C���ݒ�
    Public Shared gobjFRM_205020 As FRM_205020              '�g���b�L���O�����e�i���X
    Public Shared gobjFRM_205030 As FRM_205030              '�g���b�L���O�����e�i���X�ڍ�
    Public Shared gobjFRM_205040 As FRM_205040              '�݌Ƀ����e�i���X
    Public Shared gobjFRM_205041 As FRM_205041              '�݌Ƀ����e�i���X(�q���)
    Public Shared gobjFRM_205042 As FRM_205042              '�݌Ƀ����e�i���X(�q��ʁE�֎~�I�ꊇ�ݒ�)
    Public Shared gobjFRM_206000 As FRM_206000              '�}�X�^�����e�i���X���j���[
    Public Shared gobjFRM_206010 As FRM_206010              '�i���}�X�^�����e�i���X
    Public Shared gobjFRM_206011 As FRM_206011              '�i���}�X�^�����e�i���X(�q���)
    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/05 �i��Ͻ�����ݽ��ʂŕi������/�L���̒��ڎw��
    Public Shared gobjFRM_206012 As FRM_206012              '�i���}�X�^�����e�i���X(�q���)
    'JobMate:S.Ouchi 2013/11/05 �i��Ͻ�����ݽ��ʂŕi������/�L���̒��ڎw��
    '������������************************************************************************************************************
    Public Shared gobjFRM_206020 As FRM_206020              '�S���҃}�X�^�����e�i���X
    Public Shared gobjFRM_206021 As FRM_206021              '�S���҃}�X�^�����e�i���X(�q���)
    Public Shared gobjFRM_206030 As FRM_206030              '�{�������}�X�^�����e�i���X
    Public Shared gobjFRM_206040 As FRM_206040              '���R�}�X�^�����e�i���X
    Public Shared gobjFRM_206041 As FRM_206041              '���R�}�X�^�����e�i���X(�q���)
    Public Shared gobjFRM_207000 As FRM_207000              '�V�X�e�������e�i���X���j���[
    Public Shared gobjFRM_207010 As FRM_207010              '�I�y���[�V�������O
    Public Shared gobjFRM_207011 As FRM_207011              '�I�y���[�V�������O�ڍ�(�q���)
    Public Shared gobjFRM_207020 As FRM_207020              '�V�X�e���G���[���O
    Public Shared gobjFRM_207030 As FRM_207030              '�ݔ��ُ탍�O
    Public Shared gobjFRM_207040 As FRM_207040              '�ݔ��ʐM���O
    Public Shared gobjFRM_207041 As FRM_207041              '�d����͉��(�q���)
    Public Shared gobjFRM_207050 As FRM_207050              '���b�Z�[�W����
    Public Shared gobjFRM_207060 As FRM_207060              '�V�X�e���萔�����e�i���X
    Public Shared gobjFRM_207061 As FRM_207061              '�V�X�e���萔�����e�i���X(�q���)
    Public Shared gobjFRM_209000 As FRM_209000              '���b�Z�[�W�m�F

#End Region
    '���������ы���
    '**********************************************************************************************

    '**********************************************************************************************
    '������FRM���� ���ް۰��
#Region "  Wait̫��         Show�AClose����     "
    Public Overrides Sub WaitFormShow()

        '***************************************************
        ' ү���ޕ\��
        '***************************************************
        If IsNull(gobjFRM_100004) = False Then
            gobjFRM_100004.Close()
            gobjFRM_100004.Dispose()
            gobjFRM_100004 = Nothing
        End If
        gobjFRM_100004 = New FRM_100004
        gobjFRM_100004.Show()
        gobjFRM_100004.Refresh()

    End Sub

    Public Overrides Sub WaitFormClose()

        '***************************************************
        ' ү���ލ폜
        '***************************************************
        If IsNull(gobjFRM_100004) = False Then
            gobjFRM_100004.Close()
            gobjFRM_100004.Dispose()
            gobjFRM_100004 = Nothing
        End If

    End Sub

    '�������� 2012.12.13 10:00 H.Morita �u���΂炭���܂����������v�������Ή� 
    Public Sub WaitFormRefresh()

        '***************************************************
        ' ү���ލĕ\��
        '***************************************************
        If IsNull(gobjFRM_100004) = False Then
            gobjFRM_100004.Refresh()
        End If

    End Sub
    '�������� 2012.12.13 10:00 H.Morita �u���΂炭���܂����������v�������Ή� 

#End Region
#Region "  �߯�߱���̫��        �\������        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �߯�߱���̫�� �\������
    ''' </summary>
    ''' <param name="strMessage">ү����</param>
    ''' <param name="udtFormType">�߯�߱���̫������</param>
    ''' <param name="udtIconType">�߯�߱���̫������</param>
    ''' <param name="strSupplement">�⑫ү���ށiү���ނ̌�ɐڑ�����j</param>
    ''' <param name="strTitle">��̫���߯�߱��ߕ\����</param>
    ''' <param name="blnAddLog"></param>
    ''' <returns>�߯�߱���̫�іߒl</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function DisplayPopup(ByVal strMessage As String _
                                              , ByVal udtFormType As PopupFormType _
                                              , ByVal udtIconType As PopupIconType _
                                              , Optional ByVal strSupplement As String = "" _
                                              , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                                              , Optional ByVal blnAddLog As Boolean = True _
                                                ) As RetPopup

        '***********************************************************
        ' ۸ޏ����ݏ���
        '***********************************************************
        If blnAddLog = True Then
            gobjComFuncFRM.AddToLog_frm(strMessage & strSupplement)
        End If


        '***********************************************************
        ' �߯�߱���̫�ѕ\��
        '***********************************************************
        Dim udtPopupRet As RetPopup
        Select Case udtFormType
            Case PopupFormType.Ok
                udtPopupRet = Display_frmPopup_01(strMessage, udtIconType, strSupplement, strTitle)       'OK             ̫��

            Case PopupFormType.Ok_Cancel
                udtPopupRet = Display_frmPopup_02(strMessage, udtIconType, strSupplement, strTitle)       'OK/CANCEL      ̫��

            Case PopupFormType.YES_NO
                udtPopupRet = Display_frmPopup_03(strMessage, udtIconType, strSupplement, strTitle)       'YES/NO         ̫��

            Case Else
                udtPopupRet = Display_frmPopup_01(strMessage, udtIconType, strSupplement, strTitle)       'OK             ̫��

        End Select


        Return (udtPopupRet)
    End Function

#Region "  frmPopup_01          �\������"
    Private Function Display_frmPopup_01(ByVal strMessage As String, _
                                                ByVal udtIconType As PopupIconType, _
                                                ByVal strSupplement As String, _
                                                ByVal strTitle As String _
                                                ) _
                                                As RetPopup
        Dim strMessageTemp As String    '���قɕ\������÷��
        Dim udtRet As RetPopup          '�߂�l


        '***********************************************************
        ' ү���ލ쐬
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ү�����ޯ���\��
        '***********************************************************
        If IsNull(gobjFRM_100102) = False Then
            gobjFRM_100102.Close()
            gobjFRM_100102.Dispose()
            gobjFRM_100102 = Nothing
        End If
        gobjFRM_100102 = New FRM_100102

        gobjFRM_100102.Text = " " & strTitle                               '̫�����فi���������񂪓����Ă��Ȃ��ƕςɂȂ�j
        gobjFRM_100102.userIconType = udtIconType                          'ү�����ޯ������
        gobjFRM_100102.lblMsg.Text = strMessageTemp                        'ү����
        gobjFRM_100102.ShowDialog()                                        '�\��

        udtRet = gobjFRM_100102.userRet                                    '�߂�l�ݒ�

        Return (udtRet)
    End Function
#End Region

#Region "  frmPopup_02          �\������"
    Private Function Display_frmPopup_02(ByVal strMessage As String, _
                                                ByVal udtIconType As PopupIconType, _
                                                ByVal strSupplement As String, _
                                                ByVal strTitle As String _
                                                ) _
                                                As RetPopup

        Dim strMessageTemp As String    '���قɕ\������÷��
        Dim udtRet As RetPopup          '�߂�l


        '***********************************************************
        ' ү���ލ쐬
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ү�����ޯ���\��
        '***********************************************************
        If IsNull(gobjFRM_100103) = False Then
            gobjFRM_100103.Close()
            gobjFRM_100103.Dispose()
            gobjFRM_100103 = Nothing
        End If
        gobjFRM_100103 = New FRM_100103

        gobjFRM_100103.Text = " " & strTitle                               '̫�����فi���������񂪓����Ă��Ȃ��ƕςɂȂ�j
        gobjFRM_100103.userIconType = udtIconType                          'ү�����ޯ������
        gobjFRM_100103.lblMsg.Text = strMessageTemp                        'ү����
        gobjFRM_100103.ShowDialog()                                        '�\��

        udtRet = gobjFRM_100103.userRet                                    '�߂�l�ݒ�

        Return (udtRet)
    End Function
#End Region

#Region "  frmPopup_03          �\������"
    Private Function Display_frmPopup_03(ByVal strMessage As String, _
                                                ByVal udtIconType As PopupIconType, _
                                                ByVal strSupplement As String, _
                                                ByVal strTitle As String _
                                                ) _
                                                As RetPopup

        Dim strMessageTemp As String    '���قɕ\������÷��
        Dim udtRet As RetPopup          '�߂�l


        '***********************************************************
        ' ү���ލ쐬
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ү�����ޯ���\��
        '***********************************************************
        If IsNull(gobjFRM_100105) = False Then
            gobjFRM_100105.Close()
            gobjFRM_100105.Dispose()
            gobjFRM_100105 = Nothing
        End If
        gobjFRM_100105 = New FRM_100105

        gobjFRM_100105.Text = " " & strTitle                               '̫�����فi���������񂪓����Ă��Ȃ��ƕςɂȂ�j
        gobjFRM_100105.userIconType = udtIconType                          'ү�����ޯ������
        gobjFRM_100105.lblMsg.Text = strMessageTemp                        'ү����
        gobjFRM_100105.ShowDialog()                                        '�\��

        udtRet = gobjFRM_100105.userRet                                    '�߂�l�ݒ�

        Return (udtRet)
    End Function
#End Region

#End Region
#Region "  �߯�߱���̫��(�����ޯ������) �\������            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �߯�߱���̫��(�����ޯ������) �\������
    ''' </summary>
    ''' <param name="strMessage">ү����</param>
    ''' <param name="udtFormType">�߯�߱���̫������</param>
    ''' <param name="udtIconType">��������</param>
    ''' <param name="ChckBoxState">�����ޯ���l</param>
    ''' <param name="strSupplement">�⑫ү���ށiү���ނ̌�ɐڑ�����j</param>
    ''' <param name="strTitle">����</param>
    ''' <param name="blnAddLog">۸ޏ������׸�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function DisplayChckBoxPopup(ByVal strMessage As String _
                                                     , ByVal udtFormType As PopupFormType _
                                                     , ByVal udtIconType As PopupIconType _
                                                     , ByRef ChckBoxState As CheckState _
                                                     , Optional ByVal strSupplement As String = "" _
                                                     , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                                                     , Optional ByVal blnAddLog As Boolean = True _
                                                      ) _
                                                      As RetPopup

        '***********************************************************
        ' ۸ޏ����ݏ���
        '***********************************************************
        If blnAddLog = True Then
            gobjComFuncFRM.AddToLog_frm(strMessage & strSupplement)
        End If


        '***********************************************************
        ' �߯�߱���̫�ѕ\��
        '***********************************************************
        Dim udtPopupRet As RetPopup
        Select Case udtFormType
            Case PopupFormType.Ok_Cancel
                udtPopupRet = Display_frmPopup_03(strMessage, udtIconType, strSupplement, strTitle, ChckBoxState)       'OK/CANCEL(CheckBox�t��)      ̫��
        End Select

        Return (udtPopupRet)

    End Function
#Region "  frmPopup_03          �\������            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' frmPopup_03 �\������ 
    ''' </summary>
    ''' <param name="strMessage">ү����</param>
    ''' <param name="udtIconType">��������</param>
    ''' <param name="strSupplement">�⑫ү���ށiү���ނ̌�ɐڑ�����j</param>
    ''' <param name="strTitle">����</param>
    ''' <param name="ChckBoxValue">�����ޯ���ߒl</param>
    ''' <returns>�߯�߱���̫�іߒl</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Display_frmPopup_03(ByVal strMessage As String, _
                                                ByVal udtIconType As PopupIconType, _
                                                ByVal strSupplement As String, _
                                                ByVal strTitle As String, _
                                                ByRef ChckBoxValue As CheckState _
                                               ) As RetPopup

        Dim strMessageTemp As String    '���قɕ\������÷��
        Dim udtRet As RetPopup          '�߂�l


        '***********************************************************
        ' ү���ލ쐬
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ү�����ޯ���\��
        '***********************************************************
        If IsNothing(gobjFRM_100104) = False Then
            gobjFRM_100104.Close()
            gobjFRM_100104.Dispose()
            gobjFRM_100104 = Nothing
        End If
        gobjFRM_100104 = New FRM_100104

        gobjFRM_100104.Text = " " & strTitle                                '̫�����فi���������񂪓����Ă��Ȃ��ƕςɂȂ�j
        gobjFRM_100104.userIconType = udtIconType                           'ү�����ޯ������
        gobjFRM_100104.lblMsg.Text = strMessageTemp                         'ү����
        gobjFRM_100104.ShowDialog()                                         '�\��

        udtRet = gobjFRM_100104.userRet                                     '�߂�l�ݒ�
        ChckBoxValue = gobjFRM_100104.userCheck                             '�����ޯ���l

        gobjFRM_100104.Dispose()
        gobjFRM_100104 = Nothing

        Return (udtRet)

    End Function
#End Region
#End Region
#Region "  ���R�����ޯ��̫��        �\������                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���R�����ޯ��̫��        �\������
    ''' </summary>
    ''' <param name="strFREASON_KUBUN">[IN]���R�敪</param>
    ''' <param name="strFREASON">[OUT]���R</param>
    ''' <param name="strMessage">[IN]ү����</param>
    ''' <param name="strSupplement">[IN]�⑫ү���ށiү���ނ̌�ɐڑ�����j</param>
    ''' <param name="strTitle">[IN]����</param>
    ''' <param name="blnAddLog">[IN]۸ޏ������׸� True:������</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function DisplayFRM_100201(ByVal strFREASON_KUBUN As String _
                                                   , ByRef strFREASON As String _
                                                   , Optional ByVal strMessage As String = FRM_MSG_FREASON_CD_MSG_01 _
                                                   , Optional ByVal strSupplement As String = "" _
                                                   , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                                                   , Optional ByVal blnAddLog As Boolean = True _
                                                     ) As RetPopup
        Dim strMessageTemp As String    '���قɕ\������÷��
        Dim udtRet As RetPopup          '�߂�l


        '***********************************************************
        ' ۸ޏ����ݏ���
        '***********************************************************
        If blnAddLog = True Then
            gobjComFuncFRM.AddToLog_frm(strMessage & strSupplement)
        End If


        '***********************************************************
        ' ү���ލ쐬
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ү�����ޯ���\��
        '***********************************************************
        If IsNull(gobjFRM_100201) = False Then
            gobjFRM_100201.Close()
            gobjFRM_100201.Dispose()
            gobjFRM_100201 = Nothing
        End If
        gobjFRM_100201 = New FRM_100201

        gobjFRM_100201.Text = " " & strTitle                               '̫�����فi���������񂪓����Ă��Ȃ��ƕςɂȂ�j
        gobjFRM_100201.lblMsg.Text = strMessageTemp                        'ү����
        gobjFRM_100201.userFREASON_KUBUN = strFREASON_KUBUN                        'ү����
        gobjFRM_100201.ShowDialog()                                        '�\��
        udtRet = gobjFRM_100201.userRet                                    '�߂�l�ݒ�
        strFREASON = gobjFRM_100201.userFREASON                            '���R

        Return (udtRet)
    End Function
#End Region
#Region "  ��ʑJ�ځi���ID�őJ�ځj             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʑJ�ځi���ID�őJ�ځj
    ''' </summary>
    ''' <param name="strDISP_ID">���ID</param>
    ''' <param name="objFormNow">Ӱ��قɑJ�ڂ��邩�ǂ����i��̫�Ăł�Ӱ��ڽ�j</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub FormMoveSelect(ByVal strDISP_ID As String _
                                           , ByRef objFormNow As Object _
                                           )

        Select Case strDISP_ID
            Case FDISP_ID_SFRM_100001                    '���O�C��
                gobjFRM_100001 = New FRM_100001
                Call gobjComFuncFRM.FormMove(gobjFRM_100001, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_201000                    '���C�����j���[
                gobjFRM_201000 = New FRM_201000
                Call gobjComFuncFRM.FormMove(gobjFRM_201000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_202000
                gobjFRM_202000 = New FRM_202000         '�V�X�e�����j�^(����)
                Call gobjComFuncFRM.FormMove(gobjFRM_202000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_203000                    '���o�ɋƖ����j���[
                gobjFRM_203000 = New FRM_203000
                Call gobjComFuncFRM.FormMove(gobjFRM_203000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204000                    '�⍇�����j���[
                gobjFRM_204000 = New FRM_204000
                Call gobjComFuncFRM.FormMove(gobjFRM_204000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204010                    '�⍇�����j���[
                gobjFRM_204010 = New FRM_204010
                Call gobjComFuncFRM.FormMove(gobjFRM_204010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204030                    '���o�Ɏ��і⍇��
                gobjFRM_204030 = New FRM_204030
                Call gobjComFuncFRM.FormMove(gobjFRM_204030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204050                    '��Ɨ���⍇��
                gobjFRM_204050 = New FRM_204050
                Call gobjComFuncFRM.FormMove(gobjFRM_204050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204070                    '�ύX����⍇��
                gobjFRM_204070 = New FRM_204070
                Call gobjComFuncFRM.FormMove(gobjFRM_204070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205000                    '�����e�i���X���j���[
                gobjFRM_205000 = New FRM_205000
                Call gobjComFuncFRM.FormMove(gobjFRM_205000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205010                    '�I�����C���ݒ�
                gobjFRM_205010 = New FRM_205010
                Call gobjComFuncFRM.FormMove(gobjFRM_205010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205020                    '�g���b�L���O�����e�i���X
                gobjFRM_205020 = New FRM_205020
                Call gobjComFuncFRM.FormMove(gobjFRM_205020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205030                    '�g���b�L���O�����e�i���X�ڍ�
                gobjFRM_205030 = New FRM_205030
                Call gobjComFuncFRM.FormMove(gobjFRM_205030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205040                    '�݌Ƀ����e�i���X
                gobjFRM_205040 = New FRM_205040
                Call gobjComFuncFRM.FormMove(gobjFRM_205040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_206010                    '�i���}�X�^�����e�i���X
                gobjFRM_206010 = New FRM_206010
                Call gobjComFuncFRM.FormMove(gobjFRM_206010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_206020                    '�S���҃}�X�^�����e�i���X
                gobjFRM_206020 = New FRM_206020
                Call gobjComFuncFRM.FormMove(gobjFRM_206020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_206030                    '���쌠���}�X�^�����e�i���X
                gobjFRM_206030 = New FRM_206030
                Call gobjComFuncFRM.FormMove(gobjFRM_206030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_206040                    '���R�}�X�^�����e�i���X
                gobjFRM_206040 = New FRM_206040
                Call gobjComFuncFRM.FormMove(gobjFRM_206040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207000                    '�V�X�e�������e�i���X���j���[
                gobjFRM_207000 = New FRM_207000
                Call gobjComFuncFRM.FormMove(gobjFRM_207000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207010                    '�I�y���[�V�������O
                gobjFRM_207010 = New FRM_207010
                Call gobjComFuncFRM.FormMove(gobjFRM_207010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207020                    '�V�X�e���G���[���O
                gobjFRM_207020 = New FRM_207020
                Call gobjComFuncFRM.FormMove(gobjFRM_207020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207030                    '�ݔ��ُ탍�O
                gobjFRM_207030 = New FRM_207030
                Call gobjComFuncFRM.FormMove(gobjFRM_207030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207040                    '�ݔ��ʐM���O
                gobjFRM_207040 = New FRM_207040
                Call gobjComFuncFRM.FormMove(gobjFRM_207040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207050                    '�ݔ��ُ탍�O
                gobjFRM_207050 = New FRM_207050
                Call gobjComFuncFRM.FormMove(gobjFRM_207050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207060                    '�ݔ��ʐM���O
                gobjFRM_207060 = New FRM_207060
                Call gobjComFuncFRM.FormMove(gobjFRM_207060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_209000                    '���b�Z�[�W�m�F
                gobjFRM_209000 = New FRM_209000
                Call gobjComFuncFRM.FormMove(gobjFRM_209000, objFormNow, OpenType.Modal)

                '���������ьŗL

                '������������************************************************************************************************************
                'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
            Case FDISP_ID_JFRM_302010                    '���ɐݒ�
                gobjFRM_302010 = New FRM_302010
                Call gobjComFuncFRM.FormMove(gobjFRM_302010, objFormNow, OpenType.Modaless)
                'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
                '������������************************************************************************************************************

            Case FDISP_ID_JFRM_303010                    '���ɐݒ�
                gobjFRM_303010 = New FRM_303010
                Call gobjComFuncFRM.FormMove(gobjFRM_303010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_303020                    '�⍇���o�ɐݒ�
                gobjFRM_303020 = New FRM_303020
                Call gobjComFuncFRM.FormMove(gobjFRM_303020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_303030                    '�q�֓��ɐݒ�
                gobjFRM_303030 = New FRM_303030
                Call gobjComFuncFRM.FormMove(gobjFRM_303030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_303040                    '�q�֏o�ɐݒ�
                gobjFRM_303040 = New FRM_303040
                Call gobjComFuncFRM.FormMove(gobjFRM_303040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304040                    '�o�גǐՖ⍇��
                gobjFRM_304040 = New FRM_304040
                Call gobjComFuncFRM.FormMove(gobjFRM_304040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304050                    'ۯĒǐՖ⍇��
                gobjFRM_304050 = New FRM_304050
                Call gobjComFuncFRM.FormMove(gobjFRM_304050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304060                    '���Yײݕʓ��Ɏ��і⍇��
                gobjFRM_304060 = New FRM_304060
                Call gobjComFuncFRM.FormMove(gobjFRM_304060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304070                    '�I��Ԑі⍇��
                gobjFRM_304070 = New FRM_304070
                Call gobjComFuncFRM.FormMove(gobjFRM_304070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304080                    '�I�������X�g
                gobjFRM_304080 = New FRM_304080
                Call gobjComFuncFRM.FormMove(gobjFRM_304080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_305050                    '����ԗp�r�ݒ�
                gobjFRM_305050 = New FRM_305050
                Call gobjComFuncFRM.FormMove(gobjFRM_305050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_305060                    'ۯĕۗ�/����
                gobjFRM_305060 = New FRM_305060
                Call gobjComFuncFRM.FormMove(gobjFRM_305060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_305070                    '���Y�o������������ݽ
                gobjFRM_305070 = New FRM_305070
                Call gobjComFuncFRM.FormMove(gobjFRM_305070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_305080                    '�ް����t����Ԑݒ�
                gobjFRM_305080 = New FRM_305080
                Call gobjComFuncFRM.FormMove(gobjFRM_305080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306020                    '�ԗ�Ͻ�
                gobjFRM_306020 = New FRM_306020
                Call gobjComFuncFRM.FormMove(gobjFRM_306020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306030                    '�����Ǝ�Ͻ�
                gobjFRM_306030 = New FRM_306030
                Call gobjComFuncFRM.FormMove(gobjFRM_306030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306040                    '�A����iϽ�
                gobjFRM_306040 = New FRM_306040
                Call gobjComFuncFRM.FormMove(gobjFRM_306040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306050                    '��ޗ�Ұ�Ͻ�
                gobjFRM_306050 = New FRM_306050
                Call gobjComFuncFRM.FormMove(gobjFRM_306050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306060                    '���Yײ�Ͻ�
                gobjFRM_306060 = New FRM_306060
                Call gobjComFuncFRM.FormMove(gobjFRM_306060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306070                    '���Yײ�Ͻ�(D45)
                gobjFRM_306070 = New FRM_306070
                Call gobjComFuncFRM.FormMove(gobjFRM_306070, objFormNow, OpenType.Modaless)

                '������������************************************************************************************************************
                'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
            Case FDISP_ID_JFRM_306080                    '����ڥ�������Ͻ�
                gobjFRM_306080 = New FRM_306080
                Call gobjComFuncFRM.FormMove(gobjFRM_306080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306090                    '����ڥ������������Ͻ�
                gobjFRM_306090 = New FRM_306090
                Call gobjComFuncFRM.FormMove(gobjFRM_306090, objFormNow, OpenType.Modaless)
                'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
                '������������************************************************************************************************************

            Case FDISP_ID_JFRM_307070                    'PLC����ݽ(RTN)
                gobjFRM_307070 = New FRM_307070
                Call gobjComFuncFRM.FormMove(gobjFRM_307070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307080                    'PLC����ݽ(���o��CV)
                gobjFRM_307080 = New FRM_307080
                Call gobjComFuncFRM.FormMove(gobjFRM_307080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307090                    'PLC����ݽ(����ST)
                gobjFRM_307090 = New FRM_307090
                Call gobjComFuncFRM.FormMove(gobjFRM_307090, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307100                    'PLC����ݽ(�o�ɗ\�萔)
                gobjFRM_307100 = New FRM_307100
                Call gobjComFuncFRM.FormMove(gobjFRM_307100, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307110                    '���񌎕�o��
                gobjFRM_307110 = New FRM_307110
                Call gobjComFuncFRM.FormMove(gobjFRM_307110, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307120                    'PLC����ݽ(���o�ICV)
                gobjFRM_307120 = New FRM_307120
                Call gobjComFuncFRM.FormMove(gobjFRM_307120, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_308010                    '�������ʓo�^
                gobjFRM_308010 = New FRM_308010
                Call gobjComFuncFRM.FormMove(gobjFRM_308010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_310010                    '���Y���ɓo�^
                gobjFRM_310010 = New FRM_310010
                Call gobjComFuncFRM.FormMove(gobjFRM_310010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_310020                    '�[�����Y���ɐݒ�
                gobjFRM_310020 = New FRM_310020
                Call gobjComFuncFRM.FormMove(gobjFRM_310020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_310030                    '��ޏo�ɓo�^
                gobjFRM_310030 = New FRM_310030
                Call gobjComFuncFRM.FormMove(gobjFRM_310030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_310040                    'D45��ޏo�ɓo�^
                gobjFRM_310040 = New FRM_310040
                Call gobjComFuncFRM.FormMove(gobjFRM_310040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311010                    '�o�Ɏw���⍇��
                gobjFRM_311010 = New FRM_311010
                Call gobjComFuncFRM.FormMove(gobjFRM_311010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311015                    '�o�Ɏw���ڍ�
                gobjFRM_311015 = New FRM_311015
                Call gobjComFuncFRM.FormMove(gobjFRM_311015, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311020                    '�ԗ���t
                gobjFRM_311020 = New FRM_311020
                Call gobjComFuncFRM.FormMove(gobjFRM_311020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311030                    '�o�׎w��
                gobjFRM_311030 = New FRM_311030
                Call gobjComFuncFRM.FormMove(gobjFRM_311030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311040                    '�ް����
                gobjFRM_311040 = New FRM_311040
                Call gobjComFuncFRM.FormMove(gobjFRM_311040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311050                    '�o�ג��󋵏ڍ�
                gobjFRM_311050 = New FRM_311050
                Call gobjComFuncFRM.FormMove(gobjFRM_311050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311060                    '�o�׍݌Ɋm�F
                gobjFRM_311060 = New FRM_311060
                Call gobjComFuncFRM.FormMove(gobjFRM_311060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311070                    '�o�חʖ⍇��
                gobjFRM_311070 = New FRM_311070
                Call gobjComFuncFRM.FormMove(gobjFRM_311070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311080                    '�ׯ�۰���ް����
                gobjFRM_311080 = New FRM_311080
                Call gobjComFuncFRM.FormMove(gobjFRM_311080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311090                    '�ׯ�۰���ް������
                gobjFRM_311090 = New FRM_311090
                Call gobjComFuncFRM.FormMove(gobjFRM_311090, objFormNow, OpenType.Modaless)


                '������������************************************************************************************************************
                'JobMate:YAMAMOTO 2017/04/11 1F��ޏo�ɑΉ� ������������
            Case FDISP_ID_JFRM_310050
                gobjFRM_310050 = New FRM_310050
                Call gobjComFuncFRM.FormMove(gobjFRM_310050, objFormNow, OpenType.Modaless)
            Case FDISP_ID_JFRM_307130
                gobjFRM_307130 = New FRM_307130
                Call gobjComFuncFRM.FormMove(gobjFRM_307130, objFormNow, OpenType.Modaless)
                'JobMate:YAMAMOTO 2017/04/111F��ޏo�ɑΉ� ������������
                '������������************************************************************************************************************
                '���������ьŗL


                '������������************************************************************************************************************
                'JobMate:IKEDA 2017/04/11 1F��ޏo�ɑΉ� ������������
            Case FDISP_ID_JFRM_307140
                gobjFRM_307140 = New FRM_307140
                Call gobjComFuncFRM.FormMove(gobjFRM_307140, objFormNow, OpenType.Modaless)
            Case FDISP_ID_JFRM_307150
                gobjFRM_307150 = New FRM_307150
                Call gobjComFuncFRM.FormMove(gobjFRM_307150, objFormNow, OpenType.Modaless)
                'JobMate:ikeda 2017/04/111F��ޏo�ɑΉ� ������������
                '������������************************************************************************************************************
                '���������ьŗL

        End Select


    End Sub
#End Region
#Region "�@��ʗ��ȏ���                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʗ��ȏ���
    ''' </summary>
    ''' <param name="objForm"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub AfkProc(ByRef objForm As Form)

        '****************************************************
        '����۸޲ݐݒ��ʕ\��
        '****************************************************
        gobjFRM_100005 = Nothing
        gobjFRM_100005 = New FRM_100005     '����۸޲ݐݒ���

        Try

            '*******************************************************
            '���đ��M����
            '*******************************************************
            Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
            objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200005           '̫�ϯĖ����
            Call gobjComFuncFRM.SockSendServer01(objTelegram)                                  '���đ��M


            '****************************************************
            '��ʕ\��
            '****************************************************
            'objForm.Visible = False             '�W�J����ʂ��\��
            gobjFRM_100005.ShowDialog()


            '****************************************************
            '۸޲�/۸޵�����
            '****************************************************
            Dim udtAFKFrmRet As AFKFrmRetType
            udtAFKFrmRet = gobjFRM_100005.AFKFORMRET

            '===============================
            '۸޲�/۸޵�����
            '===============================
            If udtAFKFrmRet = AFKFrmRetType.LogOff Then
                '(����۸޵̂̏ꍇ)

                '***************************************************************
                '۸޲݉�ʕ\��
                '***************************************************************
                If gblnLogoff = False Then
                    gblnLogoff = True
                    Call gobjComFuncFRM.PubF_ShellExe(System.Reflection.Assembly.GetExecutingAssembly().Location)
                End If

                '***************************************************************
                '�������g����۾����擾
                '***************************************************************
                Dim hProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
                '======================================
                '�������g���I��
                '======================================
                hProcess.Kill()

            End If

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            Throw ex

        Finally

            '===============================
            '��޼ު�ĊJ��
            '===============================
            gobjFRM_100005.Dispose()
            gobjFRM_100005 = Nothing

        End Try
    End Sub
#End Region
#Region "  �߽ܰ�ފm�F����                      "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �߽ܰ�ފm�F����
    ''' </summary>
    ''' <param name="strFDISP_ID">���ID</param>
    ''' <param name="strFCTRL_ID">���۰�ID</param>
    ''' <returns>True:�߽ܰ�ފm�F����    False:�߽ܰ�ފm�F���s</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Overrides Function PassWordCheck(ByVal strFDISP_ID As String _
                                               , ByVal strFCTRL_ID As String _
                                               ) _
                                               As Boolean
        Dim intRet As RetCode
        Dim blnReturn As Boolean = True     '�߂�l(��{OK�ɂ��Ă���)


        '******************************************
        ' ���Ͻ��擾
        '******************************************
        Dim objTDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)
        objTDSP_NAME.FDISP_ID = strFDISP_ID        '���ID
        objTDSP_NAME.FCTRL_ID = strFCTRL_ID        '���۰�ID
        intRet = objTDSP_NAME.GET_TDSP_NAME(False)
        If intRet <> RetCode.OK Then
            '(������Ȃ������ꍇ)
            blnReturn = True
            Return blnReturn
        End If


        '******************************************
        ' �߽ܰ������
        '******************************************
        If objTDSP_NAME.FPASS_CHECK_FLAG = FPASS_CHECK_FLAG_SON Then
            '(�߽ܰ����������̏ꍇ)

            '***********************************************************
            ' �߽ܰ�ފm�F��ʕ\��
            '***********************************************************
            Dim udtRet As RetPopup
            If IsNull(gobjFRM_100007) = False Then
                gobjFRM_100007.Close()
                gobjFRM_100007.Dispose()
                gobjFRM_100007 = Nothing
            End If
            gobjFRM_100007 = New FRM_100007
            gobjFRM_100007.ShowDialog()                                        '�\��
            udtRet = gobjFRM_100007.userRet                                    '�߂�l�ݒ�
            If udtRet = RetPopup.OK Then
                '(�߽ܰ�ޔF��OK�̏ꍇ)
                blnReturn = True
            Else
                '(�߽ܰ�ޔF��NG�̏ꍇ)
                blnReturn = False
            End If

        Else
            '(�߽ܰ�������Ȃ��̏ꍇ)
            blnReturn = True
        End If


        Return blnReturn
    End Function
#End Region
    '�ؽ����߰�
#Region "  �ؽ����߰Ĉ󎚏���                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ؽ����߰Ĉ󎚏���
    ''' </summary>
    ''' <param name="objCR">�ؽ����߰ĵ�޼ު��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CRPrint(ByVal objCR As Object)

        Dim gobjetc1201 As New FRM_100003

        If gcstrPRINT_FLG = FLAG_ON Then

            '=====================================
            '���׸�   ��
            '=====================================
            objCR.PrintToPrinter(1, False, 0, 0)    ' ��

        Else
            '=====================================
            '���׸�   ��
            '=====================================
            If IsNull(gobjetc1201) = False Then
                gobjetc1201.Close()
                gobjetc1201.Dispose()
                gobjetc1201 = Nothing
            End If
            gobjetc1201 = FRM_100003
            gobjetc1201.CrystalReportViewer1.ReportSource = objCR
            gobjetc1201.ShowDialog()

            gobjetc1201.Close()
            gobjetc1201.Dispose()
            gobjetc1201 = Nothing

        End If


    End Sub
#End Region
#Region "�@�ؽ����߰Ĉ󎚏���(�J��°ٗp)            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ؽ����߰Ĉ󎚏���(�J��°ٗp)
    ''' </summary>
    ''' <param name="grdControl">��د�޺��۰�</param>
    ''' <param name="strTableName">ð��ٖ�</param>
    ''' <param name="strText01">÷��1</param>
    ''' <param name="strText02">÷��2</param>
    ''' <param name="strText05">÷��5</param>
    ''' <param name="strText06">÷��6</param>
    ''' <param name="strText07">÷��7</param>
    ''' <param name="strFooter01">̯��1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CRPrintKaihatu(ByVal grdControl As System.Windows.Forms.DataGridView _
                                           , ByVal strTableName As String _
                                           , ByVal strText01 As String _
                                           , ByVal strText02 As String _
                                           , ByVal strText05 As String _
                                           , ByVal strText06 As String _
                                           , ByVal strText07 As String _
                                           , ByVal strFooter01 As String _
                                           )

        Call gobjComFuncFRM.WaitFormShow()                     ' Wait̫�ѕ\��


        '***********************************************
        ' �e��޼ު�Ă̲ݽ�ݽ
        '***********************************************
        Dim objCR As New PRT_000001             '�ؽ����߰ĵ�޼ު��
        Dim objDataSet As New clsPrintDataSet   '�ް�ð��ٵ�޼ު��
        Dim strColTerminator As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_020)
        Dim strRowTerminator As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_021)

        Try


            '================================
            ' �ް����
            '================================
            Call ChangeCRText(objCR, "crDateTime01", "")    '���s����
            Call ChangeCRText(objCR, "Text3", "")           '���s����
            Call ChangeCRText(objCR, "crText01", strText01)
            Call ChangeCRText(objCR, "crText02", strText02)
            '' ''Call ChangeCRText(objCR, "crText03", strText03)
            '' ''Call ChangeCRText(objCR, "crText04", strText04)
            Call ChangeCRText(objCR, "crText05", strText05)
            Call ChangeCRText(objCR, "crText06", strText06)
            Call ChangeCRText(objCR, "crText07", strText07)
            Call ChangeCRText(objCR, "crFooter01", strFooter01)
            Call ChangeCRText(objCR, "crFooter02", strText01)


            '***********************************************
            ' �ް������쐬
            '***********************************************
            For ii As Integer = 0 To grdControl.Rows.Count - 1 - 1
                '(ٰ��:��د�ލs�� - 1    ��د�ލŏI�s�͋󔒂Ȃ̂ŏȂ�)

                '=========================================
                '������쐬
                '=========================================
                Dim strData As String = ""
                For jj As Integer = 0 To grdControl.ColumnCount - 1
                    If jj <> 0 Then strData &= strColTerminator
                    strData &= """" & grdControl.Item(jj, ii).Value & """"
                Next
                strData &= strRowTerminator

                '=========================================
                '�z��쐬
                '=========================================
                Dim strDataArray() As String = Nothing
                Call gobjComFuncFRM.DivStringToArray(strData, strDataArray)

                '=========================================
                '�ް��ǉ�
                '=========================================
                For jj As Integer = LBound(strDataArray) To UBound(strDataArray)
                    Dim objDataRow As clsPrintDataSet.DataTable01Row
                    objDataRow = objDataSet.DataTable01.NewRow
                    objDataRow.BeginEdit()
                    objDataRow.Data00 = strDataArray(jj)
                    objDataRow.EndEdit()
                    objDataSet.DataTable01.Rows.Add(objDataRow)
                Next

            Next


            '***********************************************
            ' �ؽ����߰Ă��ް���Ă��
            '***********************************************
            objCR.SetDataSource(objDataSet)


            ' ''***********************************************
            ' '' ��
            ' ''***********************************************
            ''objCR.PrintToPrinter(1, False, 0, 0)    ' ��


            '***********************************************
            ' PDF�o��
            '***********************************************
            '̧�ٖ��쐬
            Dim strPathPDF As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_022)
            strPathPDF &= strFooter01
            strPathPDF &= "_"
            strPathPDF &= strTableName
            '' ''strPathPDF &= "_"
            '' ''strPathPDF &= Format(Now, GAMEN_DATE_FORMAT_04)
            strPathPDF &= ".pdf"
            '̧������
            '̫��ލ쐬
            If System.IO.File.Exists(strPathPDF) Then
                If MessageBox.Show("�������O�̃t�@�C�������ɑ��݂��Ă��܂��B" & vbCrLf & "�㏑�����܂����H", "�m�F", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
                    Exit Sub
                End If
            End If
            'PDF�o��
            objCR.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strPathPDF)


        Catch ex As Exception
            Throw ex

        Finally
            '�ؽ����߰ĵ�޼ު��
            objCR.Dispose()
            objCR = Nothing
            '�ް�ð��ٵ�޼ު��
            objDataSet.Dispose()
            objDataSet = Nothing

            Call gobjComFuncFRM.WaitFormClose()                    ' Wait̫�э폜

        End Try

    End Sub
#End Region
#Region "  �ؽ����߰Ă�÷�ĵ�޼ު�Ă̕\��÷�Ă�ύX "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ؽ����߰Ă�÷�ĵ�޼ު�Ă̕\��÷�Ă�ύX
    ''' </summary>
    ''' <param name="objCR">�ؽ����߰ĵ�޼ު��</param>
    ''' <param name="strObjectName">�ؽ����߰Ă̓\��t���Ă����޼ު�Ė�</param>
    ''' <param name="strText">�ؽ����߰Ăɕ\��������÷��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub ChangeCRText(ByVal objCR As Object _
                                         , ByVal strObjectName As String _
                                         , ByVal strText As String _
                                         )

        CType(objCR.ReportDefinition.ReportObjects(strObjectName),  _
              CrystalDecisions.CrystalReports.Engine.TextObject). _
              Text = strText

    End Sub
#End Region

    '������FRM���� ���ް۰��
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
    '������������************************************************************************************************************
    'SystemMate:H.Morita 2012/08/23 CSV�o�͋@�\�̒ǉ�
#Region "  CSV̧�ُo��                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' CSV̧�ُo��
    ''' </summary>
    ''' <param name="objGrid">��د��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Shared Sub MakeCSV(ByVal objGrid As GamenCommon.cmpMDataGrid _
                            , ByVal strFilePath As String _
                            , ByVal strFileName As String _
                            , ByVal strHeader As String _
                            , ByVal strDataHeaderName_Ary() As String _
                            , ByVal intDataColumnIdx_Ary() As Integer _
                              )


        '***********************
        '̫��ނ̍쐬
        '***********************
        ' �w��̃p�X�����݂��Ȃ���΍쐬���A�쐬�s�Ȃ�A�v���P�[�V�������s�t�H���_
        If System.IO.Directory.Exists(strFilePath) = False Then
            Try
                System.IO.Directory.CreateDirectory(strFilePath)
            Catch ex As Exception
                strFilePath = Application.StartupPath
            End Try
        End If
        If Microsoft.VisualBasic.Strings.Right(strFilePath, 1) <> "\" Then strFilePath &= "\"


        '***********************
        '�����ݒ�
        '***********************
        '�o���߽ & ̧�ٖ�       �̐ݒ�
        Dim strFilePathName As String = ""
        strFilePathName &= strFilePath
        strFilePathName &= strFileName


        '***********************
        'ͯ�ޕ��쐬
        '***********************
        Dim strWrite As String = ""
        If IsNotNull(strHeader) Then
            strWrite = strHeader & vbCrLf
        End If


        '***********************
        '�ް�����ͯ�ޕ����̍쐬
        '***********************
        For ii As Integer = 0 To UBound(strDataHeaderName_Ary)
            If ii = 0 Then
                strWrite &= strDataHeaderName_Ary(ii)
            Else
                strWrite &= ","
                strWrite &= strDataHeaderName_Ary(ii)
            End If
        Next
        strWrite &= vbCrLf


        '***********************
        '�ް����쐬
        '***********************
        For ii As Integer = 0 To objGrid.Rows.Count - 1
            '(ٰ��:�ް�ð��قɾ�Ă���Ă����ް���)

            For jj As Integer = 0 To UBound(intDataColumnIdx_Ary)
                '(ٰ��:�o�͂����)

                If jj = 0 Then
                    If IsDBNull(objGrid.Item(intDataColumnIdx_Ary(jj), ii).Value) = True Then
                        '(DBNull�̎�)
                        strWrite &= ""
                    Else
                        '(�l�����鎞)
                        strWrite &= TO_STRING(objGrid.Item(intDataColumnIdx_Ary(jj), ii).Value).Replace(","c, "�C"c)    '2012.11.28 13:30 H.Morita ��� �S�p�ϊ�
                    End If
                Else
                    strWrite &= ","
                    If IsDBNull(objGrid.Item(intDataColumnIdx_Ary(jj), ii).Value) = True Then
                        '(DBNull�̎�)
                        strWrite &= ""
                    Else
                        '(�l�����鎞)
                        strWrite &= TO_STRING(objGrid.Item(intDataColumnIdx_Ary(jj), ii).Value).Replace(","c, "�C"c)    '2012.11.28 13:30 H.Morita ��� �S�p�ϊ�
                    End If
                End If

            Next

            strWrite &= vbCrLf

            Call gobjComFuncFRM.WaitFormRefresh()                    ' Wait̫�эĕ\��

        Next


        '***********************
        'StreamWriter   �쐬
        '***********************
        Dim objSW As New System.IO.StreamWriter(strFilePathName, False, System.Text.Encoding.GetEncoding(932))           'Shift JIS�ŏ�������
        Try
            objSW.Write(strWrite)          '�ǉ�
        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            Throw New Exception(ex.Message)
        Finally
            objSW.Close()
        End Try


    End Sub
#End Region
    '������������************************************************************************************************************

    '���������ы���
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ьŗL

#Region "  ��۰��ٕϐ�                          "

    '**********************************************************************************************
    '�@��۰��ٕϐ�
    '**********************************************************************************************
    '��ʵ�޼ު��
    Public Shared gobjFRM_302001 As FRM_302001              '��I�ڍו\��
    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
    Public Shared gobjFRM_302010 As FRM_302010              '���Yײ����
    Public Shared gobjFRM_302011 As FRM_302011              '���Yײ�����q���1
    Public Shared gobjFRM_302012 As FRM_302012              '���Yײ�����q���2
    'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
    '������������************************************************************************************************************
    Public Shared gobjFRM_303010 As FRM_303010              '���ɐݒ�
    Public Shared gobjFRM_303011 As FRM_303011              '���ɐݒ�q���1
    Public Shared gobjFRM_303012 As FRM_303012              '���ɐݒ�q���2
    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/17 �ݒ���ް��\��
    Public Shared gobjFRM_303013 As FRM_303013              '���ɐݒ�q���3
    'JobMate:S.Ouchi 2013/10/17 �ݒ���ް��\��
    '������������************************************************************************************************************
    Public Shared gobjFRM_303020 As FRM_303020              '�⍇���o�ɐݒ�
    Public Shared gobjFRM_303030 As FRM_303030              '�q�֓��ɐݒ�
    Public Shared gobjFRM_303031 As FRM_303031              '�q�֓��ɐݒ�q���
    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/18 �ݒ���ް��\��
    Public Shared gobjFRM_303032 As FRM_303032              '�q�֓��ɐݒ�q���2
    'JobMate:S.Ouchi 2013/10/18 �ݒ���ް��\��
    '������������************************************************************************************************************
    Public Shared gobjFRM_303040 As FRM_303040              '�q�֏o�ɐݒ�
    Public Shared gobjFRM_303041 As FRM_303041              '�q�֏o�ɐݒ�q���
    Public Shared gobjFRM_304040 As FRM_304040              '�o�ɒǐՖ⍇��
    Public Shared gobjFRM_304050 As FRM_304050              'ۯĒǐՖ⍇��
    Public Shared gobjFRM_304060 As FRM_304060              '���Yײݕʓ��Ɏ��і⍇��
    Public Shared gobjFRM_304070 As FRM_304070              '�I��Ԗ⍇��
    '������������************************************************************************************************************
    'JobMate:N.Nakada 2013/11/01 �I�����X�g
    Public Shared gobjFRM_304080 As FRM_304080              '�I�����X�g
    '������������************************************************************************************************************
    Public Shared gobjFRM_305050 As FRM_305050              '����ԗp�r�ݒ�
    Public Shared gobjFRM_305060 As FRM_305060              'ۯĕۗ�/����
    Public Shared gobjFRM_305061 As FRM_305061              'ۯĕۗ�/�����q���
    Public Shared gobjFRM_305070 As FRM_305070              '�ً}�����ɓo�^
    Public Shared gobjFRM_305071 As FRM_305071              '�ً}�����ɓo�^�q���
    Public Shared gobjFRM_305080 As FRM_305080              '�ް����t����Ԑݒ�
    Public Shared gobjFRM_306020 As FRM_306020              '�ԗ�Ͻ�
    Public Shared gobjFRM_306021 As FRM_306021              '�ԗ�Ͻ��q���
    Public Shared gobjFRM_306030 As FRM_306030              '�����Ǝ�Ͻ�
    Public Shared gobjFRM_306031 As FRM_306031              '�����Ǝ�Ͻ��q���
    Public Shared gobjFRM_306040 As FRM_306040              '�A����iϽ�
    Public Shared gobjFRM_306041 As FRM_306041              '�A����iϽ��q���
    Public Shared gobjFRM_306050 As FRM_306050              '��ޗ�Ұ�Ͻ�
    Public Shared gobjFRM_306051 As FRM_306051              '��ޗ�Ұ�Ͻ��q���
    Public Shared gobjFRM_306060 As FRM_306060              '���Yײ�Ͻ�
    Public Shared gobjFRM_306061 As FRM_306061              '���Yײ�Ͻ��q���
    Public Shared gobjFRM_306070 As FRM_306070              '���Yײ�Ͻ�(D45)
    Public Shared gobjFRM_306071 As FRM_306071              '���Yײ�Ͻ�(D45)�q���
    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
    Public Shared gobjFRM_306080 As FRM_306080              '����ڥ�������Ͻ�
    Public Shared gobjFRM_306081 As FRM_306081              '����ڥ�������Ͻ��q���
    Public Shared gobjFRM_306090 As FRM_306090              '����ڥ������������Ͻ�
    Public Shared gobjFRM_306091 As FRM_306091              '����ڥ������������Ͻ��q���
    'JobMate:S.Ouchi 2015/07/03 CW6�ǉ��Ή� ������������
    '������������************************************************************************************************************
    Public Shared gobjFRM_307070 As FRM_307070              'PLC����ݽ(RTN)
    Public Shared gobjFRM_307071 As FRM_307071              'PLC����ݽ(RTN)�q��� RTN�I��(1F)
    Public Shared gobjFRM_307072 As FRM_307072              'PLC����ݽ(RTN)�q��� RTN�I��(2F)
    Public Shared gobjFRM_307073 As FRM_307073              'PLC����ݽ(RTN)�q���
    Public Shared gobjFRM_307080 As FRM_307080              'PLC����ݽ(���o��CV)
    Public Shared gobjFRM_307081 As FRM_307081              'PLC����ݽ(���o��CV)�q���
    Public Shared gobjFRM_307090 As FRM_307090              'PLC����ݽ(����ST)
    Public Shared gobjFRM_307091 As FRM_307091              'PLC����ݽ(����ST)�q���
    Public Shared gobjFRM_307092 As FRM_307092              'PLC����ݽ(����ST)ST�I�����
    Public Shared gobjFRM_307100 As FRM_307100              'PLC����ݽ(�o�ɗ\�萔)
    Public Shared gobjFRM_307101 As FRM_307101              'PLC����ݽ(�o�ɗ\�萔)�q���
    Public Shared gobjFRM_307102 As FRM_307102              'PLC����ݽ(�o�ɗ\�萔)�q��� ���ݒl�ύX
    Public Shared gobjFRM_307110 As FRM_307110              '���񌎕�o��
    Public Shared gobjFRM_307120 As FRM_307120              'PLC����ݽ(���o�ICV)
    Public Shared gobjFRM_307121 As FRM_307121              'PLC����ݽ(���o�ICV)�q���
    Public Shared gobjFRM_307122 As FRM_307122              'PLC����ݽ(���o�ICV)�q��� ���ݒl�ύXRTN
    Public Shared gobjFRM_307123 As FRM_307123              'PLC����ݽ(���o�ICV)�q��� ���ݒl�ύX����
    Public Shared gobjFRM_308010 As FRM_308010              '�������ʓo�^
    Public Shared gobjFRM_308011 As FRM_308011              '�������ʓo�^�q���
    Public Shared gobjFRM_310010 As FRM_310010              '���Y���ɓo�^
    Public Shared gobjFRM_310011 As FRM_310011              '���Y���ɓo�^�q���
    Public Shared gobjFRM_310020 As FRM_310020              '�[�����Y���ɐݒ�
    Public Shared gobjFRM_310030 As FRM_310030              '��ޏo�ɓo�^
    Public Shared gobjFRM_310031 As FRM_310031              '��ޏo�ɓo�^�q���
    Public Shared gobjFRM_310040 As FRM_310040              'D45��ޏo�ɓo�^
    Public Shared gobjFRM_310041 As FRM_310041              'D45��ޏo�ɓo�^�q���
    Public Shared gobjFRM_311010 As FRM_311010              '�o�׎w���⍇��
    Public Shared gobjFRM_311011 As FRM_311011              '�o�׎w���⍇���q���
    Public Shared gobjFRM_311015 As FRM_311015              '�o�׎w���ڍ�
    Public Shared gobjFRM_311020 As FRM_311020              '�ԗ���t
    Public Shared gobjFRM_311030 As FRM_311030              '�o�׎w��
    Public Shared gobjFRM_311031 As FRM_311031              '�o�׎w���q���
    Public Shared gobjFRM_311040 As FRM_311040              '�ް����
    Public Shared gobjFRM_311050 As FRM_311050              '�o�ג��󋵏ڍ�
    Public Shared gobjFRM_311055 As FRM_311055              '�o�ג��󋵏ڍ׎q���
    Public Shared gobjFRM_311060 As FRM_311060              '�o�׍݌Ɋm�F
    Public Shared gobjFRM_311070 As FRM_311070              '�o�חʖ⍇��
    Public Shared gobjFRM_311080 As FRM_311080              '�ׯ�۰���ް����
    Public Shared gobjFRM_311090 As FRM_311090              '�ׯ�۰���ް������
    'Public Shared gobjFRM_311100 As FRM_311100              '�ް������

    '������������************************************************************************************************************
    'JobMate:YAMAMOTO 2017/04/11 1F��ޏo�ɑΉ� ������������
    Public Shared gobjFRM_307130 As FRM_307130              'PLC����ݽ(1F��ޏo��)
    Public Shared gobjFRM_307131 As FRM_307131              'PLC����ݽ(1F��ޏo��)�q���
    Public Shared gobjFRM_310050 As FRM_310050              '1F��ޏo�ɓo�^
    Public Shared gobjFRM_310051 As FRM_310051              '1F��ޏo�ɓo�^�q���
    'JobMate:YAMAMOTO 2017/04/111F��ޏo�ɑΉ� ������������
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'JobMate:IKEDA 2017/07/06 ���Y���ɓo�^(BCR)�Ή� ������������
    Public Shared gobjFRM_307140 As FRM_307140              '���Y���ɓo�^(BCR)
    Public Shared gobjFRM_307150 As FRM_307150              'PLC����ݽ(BCR)
    Public Shared gobjFRM_307151 As FRM_307151              'PLC����ݽ(BCR)�q���
    'JobMate:IKEDA 2017/07/06 PLC�����e�i���X(BCR)�Ή� ������������
    '������������************************************************************************************************************
#End Region
#Region "  �����_�ȉ������擾                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����_�ȉ������擾
    ''' </summary>
    ''' <param name="intValue">�Ώۂ̐��l</param>
    ''' <returns>�����_�ȉ�����</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetPrecision(ByVal intValue As Decimal) As Integer

        GetPrecision = (intValue - CInt(intValue)).ToString().TrimEnd("0"c).Replace("0.", String.Empty).Replace("-", String.Empty).Length
        Return GetPrecision

    End Function
#End Region
#Region "  ��ƎҖ��擾                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ƎҖ��擾
    ''' </summary>
    ''' <param name="strFUSER_ID">հ�ްID</param>
    ''' <returns>հ�ް��</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Get_FUSER_NAME(ByVal strFUSER_ID As String) As String


        '*********************************************
        ' ��ƎҖ��@�\��
        '*********************************************
        Dim objDataSet As New DataSet       '�ް����
        Dim strDataSetName As String        '�ް���Ė�

        Dim strSQL As String                'SQL��
        Dim objRow As DataRow               '1ں��ޕ����ް�

        Dim strFUSER_NAME As String = ""     'հ�ް��

        '-----------------------
        '���oSQL�쐬
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    FUSER_ID "                                'հ�ް����
        strSQL &= vbCrLf & "  , FUSER_NAME "                              'հ�ް��
        strSQL &= vbCrLf & " FROM TMST_USER "                             'հ�ްϽ�
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TMST_USER.FUSER_ID = '" & strFUSER_ID & "' "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FUSER_ID "
        strSQL &= vbCrLf

        '-----------------------
        '���o
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TMST_USER"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(���������ꍇ)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            strFUSER_NAME = TO_STRING(objRow("FUSER_NAME"))
        Else
            '(������Ȃ��ꍇ)
            strFUSER_NAME = ""
        End If

        Return strFUSER_NAME

    End Function
#End Region
#Region "  �ُ���گ�ID�擾                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ُ���گ�ID�擾
    ''' </summary>
    ''' <param name="strCraneID">�ڰ�ID</param>
    ''' <param name="intFCOMP_KUBUN">�����敪</param>
    ''' <param name="strFPALLET_ID">��گ�ID</param>
    ''' <returns>���ʖ߂�l</returns>
    ''' <remarks>��گ�ID���擾����֐�</remarks>
    ''' *******************************************************************************************************************
    Public Shared Function GetUnusual_PALLET_ID(ByVal strCraneID As String, ByVal intFCOMP_KUBUN As Integer, ByRef strFPALLET_ID As String) As RetCode

        Dim intRet As RetCode
        Dim strMsg As String = ""

        If intFCOMP_KUBUN = FCOMP_KUBUN_SNIJUU Then
            '(��d�����̂Ƃ�)
            strMsg = FRM_MSG_FRM202000_18
        ElseIf intFCOMP_KUBUN = FCOMP_KUBUN_SNISUGATA Then
            '(�׎p�s��v�̂Ƃ�)
            strMsg = FRM_MSG_FRM202000_19
        ElseIf intFCOMP_KUBUN = FCOMP_KUBUN_SKARA Then
            '(��o�ɂ̂Ƃ�)
            strMsg = FRM_MSG_FRM202000_21
        End If

        '************************************************
        '�ׯ�ݸ��ޯ̧�̓���
        '************************************************
        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
        objTPRG_TRK_BUF.FEQ_ID = strCraneID                                 '�ݔ�ID
        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_RELAY()
        If intRet <> RetCode.OK Then
            If intFCOMP_KUBUN = FCOMP_KUBUN_SNIJUU Or intFCOMP_KUBUN = FCOMP_KUBUN_SNISUGATA Then
                '(��d�����܂��͉׎p�s��v�̂Ƃ�)
                gobjComFuncFRM.DisplayPopup(strMsg & vbCrLf & FRM_MSG_FRM202000_17, PopupFormType.Ok, PopupIconType.Information)
            ElseIf intFCOMP_KUBUN = FCOMP_KUBUN_SKARA Then
                '(��o�ɂ̂Ƃ�)
                gobjComFuncFRM.DisplayPopup(strMsg & vbCrLf & FRM_MSG_FRM202000_22, PopupFormType.Ok, PopupIconType.Information)
            End If

            Exit Function

        End If

        '************************************************
        '�ׯ�ݸ��ޯ̧Ͻ��̓���
        '************************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO           '�ׯ�ݸ��ޯ̧��
        intRet = objTMST_TRK.GET_TMST_TRK()
        If intFCOMP_KUBUN = FCOMP_KUBUN_SNIJUU Or intFCOMP_KUBUN = FCOMP_KUBUN_SNISUGATA Then
            '(��d�����܂��͉׎p�s��v�̂Ƃ�)
            If objTMST_TRK.FBUF_KIND = FBUF_KIND_SOUT Then
                '(�ޯ̧��ʂ��o�ɒ��ޯ̧�̂Ƃ�)
                gobjComFuncFRM.DisplayPopup(strMsg & vbCrLf & FRM_MSG_FRM202000_20, PopupFormType.Ok, PopupIconType.Information)
                Exit Function
            End If
        ElseIf intFCOMP_KUBUN = FCOMP_KUBUN_SKARA Then
            '(��o�ɂ̂Ƃ�)
            If objTMST_TRK.FBUF_KIND = FBUF_KIND_SIN Then
                '(�ޯ̧��ʂ����ɒ��ޯ̧�̂Ƃ�)
                gobjComFuncFRM.DisplayPopup(strMsg & vbCrLf & FRM_MSG_FRM202000_23, PopupFormType.Ok, PopupIconType.Information)
                Exit Function
            End If
        End If

        strFPALLET_ID = objTPRG_TRK_BUF.FPALLET_ID

        Return True

    End Function
#End Region

#Region "  ���ٔw�i�F�ύX����  (���o��Ӱ�ޕ\������)         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ٔw�i�F�ύX����  (���o��Ӱ�ޕ\������) 
    ''' </summary>
    ''' <param name="lblControl">�w�i�F��ύX�������ٺ��۰�</param>
    ''' <param name="strFTRK_BUF_NO">���o�ɽð���</param>
    ''' <param name="udtLblDspType">���ٕ\������</param>
    ''' <param name="strFEQ_STS">�ݔ���ԋ敪</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AlterLabelColorMOD(ByVal lblControl As Label _
                                , ByVal strFTRK_BUF_NO As String _
                                , ByVal udtLblDspType As LBL_DSPTYPE _
                                , Optional ByRef strFEQ_STS As String = CBO_ALL_CONTENT_01 _
                                 )

        If strFTRK_BUF_NO = CBO_ALL_CONTENT_01 Then
            '(ST�w�薳��)
            lblControl.Visible = False
            lblControl.Text = ""
            lblControl.BackColor = gcLabelColor_Black
            Exit Sub
        End If


        Dim strSQL As String                'SQL��
        Dim objRow As DataRow               '1ں��ޕ����ް�
        Dim objDataSet As New DataSet       '�ް����
        Dim strDataSetName As String        '�ް���Ė�

        Dim strFEQ_ID As String = ""        '���o��Ӱ��

        strFEQ_ID = "JMOD" & Microsoft.VisualBasic.Right("0000" & strFTRK_BUF_NO, 4)

        ' ''Select Case strFEQ_ID
        ' ''    Case "JMOD0168"
        ' ''        strFEQ_ID = "JMOD0169"
        ' ''    Case "JMOD0173"
        ' ''        strFEQ_ID = "JMOD0174"
        ' ''    Case "JMOD0184"
        ' ''        strFEQ_ID = "JMOD0185"
        ' ''    Case "JMOD0186"
        ' ''        strFEQ_ID = "JMOD0187"
        ' ''    Case "JMOD0381"
        ' ''        strFEQ_ID = "JMOD0382"
        ' ''End Select

        ' ''If (strFTRK_BUF_NO = FTRK_BUF_NO_J8) Or _
        ' ''   (strFTRK_BUF_NO = FTRK_BUF_NO_J169) Or _
        ' ''   (strFTRK_BUF_NO = FTRK_BUF_NO_J174) Or _
        ' ''   (strFTRK_BUF_NO = FTRK_BUF_NO_J168) Or _
        ' ''   (strFTRK_BUF_NO = FTRK_BUF_NO_J173) Then
        ' ''    '(�o���ް�8�̎�)

        ' ''    strFEQ_ID = "JMOD0169"

        ' ''    If GetFEQ_STS(strFTRK_BUF_NO, False, False, False) = 2 Then
        ' ''        '(Ӱ�ޕs��v�̎�)
        ' ''        lblControl.Visible = True
        ' ''        lblControl.Text = "Ӱ�ޕs��v"
        ' ''        lblControl.BackColor = gcModeColor_CUS_FUITHI
        ' ''        Exit Sub
        ' ''    End If

        ' ''End If


        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_NAME "                           '�ݔ���.�ݔ�����
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS.FSTS_NAME "                           '��ʐݔ���ԕ\��Ͻ�.��Ԗ�
        strSQL &= vbCrLf & "   ,NVL(TDSP_EQ_STS.FCOLOR_KUBUN, " & FCOLOR_KUBUN_SWHITE & ") AS FCOLOR_KUBUN "      '��ʐݔ���ԕ\��Ͻ�.�\���F
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS.FEQ_STS "                             '��ʐݔ���ԕ\��Ͻ�.�ݔ���ԋ敪
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL "                                    '�ݔ���
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS "                                     '��ʐݔ���ԕ\��Ͻ�

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ð��ٌ���
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND '" & strFEQ_ID & "'      = TSTS_EQ_CTRL.FEQ_ID "                '�ݔ��� �� �ݔ�ID �� �w��
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_DSP_KUBUN   = TDSP_EQ_STS.FEQ_DSP_KUBUN(+) "   '�ݔ��� �� ��ʐݔ���ԕ\��Ͻ� �� ��ʐݔ��\���敪 �� �O������
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_STS     = TDSP_EQ_STS.FEQ_STS(+) "             '�ݔ��� �� ��ʐݔ���ԕ\��Ͻ� �� �ݔ���� �� �O������
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_CUT_STS = TDSP_EQ_STS.FEQ_CUT_STS(+) "         '�ݔ��� �� ��ʐݔ���ԕ\��Ͻ� �� �ؗ��L�� �� �O������


        '********************************************************************
        '�ް���Ď擾
        '********************************************************************
        '-----------------------
        '���o
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TDSP_EQ_STS"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(�ǂ߂���)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            lblControl.Visible = True

            Select Case udtLblDspType
                Case LBL_DSPTYPE.EQNAME
                    '��ʕ\���p���̕ύX(�ݔ���)
                    lblControl.Text = TO_STRING(objRow("FEQ_NAME"))
                Case LBL_DSPTYPE.STSNAME
                    '��ʕ\���p���̕ύX(�ð����)
                    lblControl.Text = StrConv(TO_STRING(objRow("FSTS_NAME")), VbStrConv.Wide)
                    strFEQ_STS = TO_STRING(objRow("FEQ_STS"))
                Case LBL_DSPTYPE.NO_DSP
                    '���ٕ\���ύX����
            End Select


            '�w�i�F�ύX
            Call AlterBackColorMOD(lblControl, TO_NUMBER(objRow("FCOLOR_KUBUN")))

        Else
            lblControl.Visible = False
            lblControl.Text = ""
            lblControl.BackColor = gcLabelColor_Black

        End If


    End Sub
#End Region
#Region "  �w�i�F�ύX����                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �w�i�F�ύX����
    ''' </summary>
    ''' <param name="objControl">�w�i�F��ύX������۰�</param>
    ''' <param name="intColorKubun">�װ�敪</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AlterBackColorMOD(ByVal objControl As Object _
                            , ByVal intColorKubun As Integer _
                            )

        '******************************************
        '�w�i�F�ύX
        '******************************************
        Select Case intColorKubun
            'Case FCOLOR_KUBUN_SGREEN
            Case FCOLOR_KUBUN_SLIGHTGREEN
                'objControl.BackColor = gcModeColor_IN       '����Ӱ��
                objControl.BackColor = gcModeColor_CUS_IN       '����Ӱ��
            Case FCOLOR_KUBUN_SBLUE
                'objControl.BackColor = gcModeColor_OUT      '�o��Ӱ��
                objControl.BackColor = gcModeColor_CUS_OUT      '�o��Ӱ��
        End Select

    End Sub
#End Region
#Region "  �ݔ��������                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݔ��������
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">�ׯ�ݸ��ޯ̧��</param>
    ''' <param name="intFEQ_STS">�ݔ����</param>
    ''' <param name="strErrMsg">�װү����</param>
    ''' <param name="intSTSagyo">���ɁE�o�ɍ��</param>
    ''' <returns>false:�װ����/true:�װ����</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function CheckFEQ_STS(ByVal intFTRK_BUF_NO As Integer, _
                                    ByVal intFEQ_STS As Integer, _
                                    ByVal strErrMsg As String, _
                                    ByVal intSTSagyo As Integer _
                                    ) As Boolean

        Dim strMsg As String = ""
        Dim blnCheckErr As Boolean = False       '�����װ�׸�
        Dim intRet As RetCode

        '==========================
        '���o��Ӱ������
        '==========================
        Dim intFTRK_BUF_NO1 As Integer          '�ׯ��ݸ��ޯ̬��
        Dim strFEQ_ID As String = ""            '�ݔ�ID(Ӱ��)
        Dim strFEQ_ID_STN As String = ""        '�ݔ�ID(���)
        Dim strFEQ_ID_CRN As String = ""        '�ݔ�ID(�ڰ�)

        intFTRK_BUF_NO1 = intFTRK_BUF_NO


        '**********************************************************
        ' �ׯ�ݸ��ޯ̧Ͻ��̓���
        '**********************************************************
        Dim objTMST_TRK As TBL_TMST_TRK                     '�ׯ�ݸ��ޯ̧Ͻ�
        objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO1           '�ׯ�ݸ��ޯ̧��
        intRet = objTMST_TRK.GET_TMST_TRK(False)
        If intRet = RetCode.OK Then
            '(�ǂ߂��Ƃ�)
            If IsNull(objTMST_TRK.XEQ_ID_MOD) = False Then
                '(�l�����鎞)
                strFEQ_ID = objTMST_TRK.XEQ_ID_MOD
                strFEQ_ID_STN = objTMST_TRK.XEQ_ID_STN
            Else
                '(�l���Ȃ���)
                blnCheckErr = True          '(Ӱ�ނ������̂������s�v�BOK)
                Return blnCheckErr
            End If
        Else
            '(�ǂ߂Ȃ���)
            strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & intFTRK_BUF_NO & "]"
            Throw New System.Exception(strMsg)
        End If


        '=============================================
        '�ݔ���TBL
        '=============================================
        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)     '�ݔ���ð��ٸ׽
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                                          '�ݔ�ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)                            '����
        If intRet = RetCode.NotFound Then
            '(������Ȃ��ꍇ)
            strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
            Throw New System.Exception(strMsg)
        End If

        If objTSTS_EQ_CTRL.FEQ_STS <> TO_STRING(intFEQ_STS) Then
            '(�w�肵��Ӱ�ނƈقȂ�Ƃ�)
            Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Information)
            Return blnCheckErr
        End If

        '====================================
        '�ׯ�ݸޏ�Ԏ擾����
        '====================================
        '(�o�ɍ�Ƃ̎�)
        If Chk_ST_TRK_BUF(intFTRK_BUF_NO1, True) = True Then
            '(�ׯ�ݸޗL��̎�)
            Return blnCheckErr
        End If

        blnCheckErr = True
        Return blnCheckErr

    End Function
#End Region
#Region "  ST �ׯ�ݸޏ�� �擾����               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ST �ׯ�ݸ� �L������
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">�ׯ�ݸ��ޯ̬��</param>
    ''' <param name="blnDSP_MSG">�װMSG�\���L��</param>
    ''' <returns>false:�װ�Ȃ�/true:�װ����</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Chk_ST_TRK_BUF(ByVal intFTRK_BUF_NO As Integer, ByVal blnDSP_MSG As Boolean) As Boolean

        Dim blnCheckErr As Boolean = False       '�����װ�׸�
        Dim intRet As RetCode

        '====================================
        '�ׯ�ݸޏ�Ԏ擾����
        '====================================
        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)       '�ׯ�ݸ��ޯ̬
        objTPRG_TRK_BUF.FTRK_BUF_NO = intFTRK_BUF_NO                        '�ׯ�ݸ��ޯ̬��
        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_ANY()                     '����

        If intRet = RetCode.OK Then
            '(�ׯ�ݸ��ޯ̬������Ƃ�)

            For ii As Integer = LBound(objTPRG_TRK_BUF.ARYME) To UBound(objTPRG_TRK_BUF.ARYME)
                '(��������ں��ތ���)
                If objTPRG_TRK_BUF.ARYME(ii).FRES_KIND = FRES_KIND_SAKI Then
                    '(������Ԃ���I�̎�)
                Else
                    '(�ȊO�̎�)
                    If blnDSP_MSG = True Then
                        '(�װ�\������)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_STN_ERROR_25, PopupFormType.Ok, PopupIconType.Information)
                    End If
                    blnCheckErr = True
                End If
            Next

        End If

        Return blnCheckErr

    End Function
#End Region

#Region "  ���ٔw�i�F�ύX���� ver.TIBA  (���o��Ӱ�ޕ\������)         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ٔw�i�F�ύX���� ver.TIBA (���o��Ӱ�ޕ\������) 
    ''' </summary>
    ''' <param name="lblControl">�w�i�F��ύX�������ٺ��۰�</param>
    ''' <param name="strFTRK_BUF_NO">���o�ɽð���</param>
    ''' <param name="udtLblDspType">���ٕ\������</param>
    ''' <param name="strFEQ_STS">�ݔ���ԋ敪</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AlterLabelColorMOD_TIBA(ByVal lblControl As Label _
                                , ByVal strFTRK_BUF_NO As String _
                                , ByVal udtLblDspType As LBL_DSPTYPE _
                                , Optional ByRef strFEQ_STS As String = CBO_ALL_CONTENT_01 _
                                 )

        If strFTRK_BUF_NO = CBO_ALL_CONTENT_01 Then
            '(ST�w�薳��)
            lblControl.Visible = False
            lblControl.Text = ""
            lblControl.BackColor = gcLabelColor_Black
            Exit Sub
        End If

        Dim strFEQ_ID_OUT As String = ""        '�o��Ӱ��ڼ޽��
        Dim strFEQ_ID_IN As String = ""         '����Ӱ��ڼ޽��
        Dim intFEQ_STS_OUT As Integer = -1      '�o��Ӱ�ޏ��
        Dim intFEQ_STS_IN As Integer = -1       '����Ӱ�ޏ��

        Select Case strFTRK_BUF_NO
            Case FTRK_BUF_NO_J2038      'D21�ً}���o��
                strFEQ_ID_OUT = "JOTHMFF_D000030_14"
                strFEQ_ID_IN = "JOTHMFF_D000030_15"

            Case FTRK_BUF_NO_J1171, FTRK_BUF_NO_J1172, FTRK_BUF_NO_J1173, FTRK_BUF_NO_J1174     'C01�`C04�O�����o��
                strFEQ_ID_OUT = "JOTHMFF_D000030_06"
                strFEQ_ID_IN = "JOTHMFF_D000030_07"

            Case Else
                lblControl.Visible = False
                lblControl.Text = ""
                lblControl.BackColor = gcLabelColor_Black
                Exit Sub

        End Select


        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        Dim strSQL As String                'SQL��
        Dim objRow As DataRow               '1ں��ޕ����ް�
        Dim objDataSet As New DataSet       '�ް����
        Dim strDataSetName As String        '�ް���Ė�

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_ID, "                          '�ݔ���.�ݔ�ID
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_STS "                          '�ݔ���.�ݔ����
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL "                                  '�ݔ���

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_ID IN ('" & strFEQ_ID_OUT & "','" & strFEQ_ID_IN & "') "                '�ݔ��� �� �ݔ�ID �� �w��

        '============================================================
        'ORDER
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FEQ_ID "

        '********************************************************************
        '�ް���Ď擾
        '********************************************************************
        '-----------------------
        '���o
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TDSP_EQ_STS"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(�ǂ߂���)
            Dim ii As Integer = 0
            For ii = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1

                objRow = objDataSet.Tables(strDataSetName).Rows(ii)

                Select Case udtLblDspType
                    Case LBL_DSPTYPE.EQNAME
                        '��ʕ\���p���̕ύX(�ݔ���)

                    Case LBL_DSPTYPE.STSNAME
                        '��ʕ\���p���̕ύX(�ð����)

                        Dim strFEQ_ID As String = ""                '�ݔ�ID
                        strFEQ_ID = TO_STRING(objRow("FEQ_ID"))

                        If strFEQ_ID = strFEQ_ID_OUT Then
                            '(�o��Ӱ��)
                            intFEQ_STS_OUT = TO_INTEGER(objRow("FEQ_STS"))

                        ElseIf strFEQ_ID = strFEQ_ID_IN Then
                            '(����Ӱ��)
                            intFEQ_STS_IN = TO_INTEGER(objRow("FEQ_STS"))

                        End If

                    Case LBL_DSPTYPE.NO_DSP
                        '���ٕ\���ύX����
                End Select

            Next

        Else
            lblControl.Visible = False
            lblControl.Text = ""
            lblControl.BackColor = gcLabelColor_Black
            Exit Sub
        End If


        '********************************************************************
        ' �ݔ�������ٕύX
        '********************************************************************
        lblControl.Visible = True

        If intFEQ_STS_OUT = 1 And intFEQ_STS_IN = 0 Then
            '(�o��Ӱ��)
            lblControl.Text = "�o�Ƀ��[�h"                                      'Ӱ��
            Call AlterBackColorMOD(lblControl, FCOLOR_KUBUN_SLIGHTGREEN)        '�w�i�F

        ElseIf intFEQ_STS_OUT = 0 And intFEQ_STS_IN = 1 Then
            '(����Ӱ��)
            lblControl.Text = "���Ƀ��[�h"                                      'Ӱ��
            Call AlterBackColorMOD(lblControl, FCOLOR_KUBUN_SBLUE)              '�w�i�F

        Else
            '(���̑�)
            lblControl.Text = "���[�h�s��"                                      'Ӱ��
            lblControl.BackColor = gcLabelColor_Black                           '�w�i�F

        End If

    End Sub
#End Region

#Region "  �߯�ݸ�ؽ� ���[�o��                   "
    '    ''' *******************************************************************************************************************
    '    ''' <summary>
    '    ''' �߯�ݸ�ؽ� ���[�o��
    '    ''' </summary>
    '    ''' <param name="XHENSEI_NO_OYA">�e�Ґ�No.</param>
    '    ''' <param name="XSYUKKA_D">�o�ד�</param>
    '    ''' <param name="DispWait">Wait̫�ѕ\���L��</param>
    '    ''' <returns>True=����</returns>
    '    ''' <remarks></remarks>
    '    ''' *******************************************************************************************************************
    '    Public Function Print_PRT_311050_01(ByVal XHENSEI_NO_OYA As String, _
    '                                         ByVal XSYUKKA_D As String, _
    '                                         Optional ByVal DispWait As Boolean = False _
    '                                         ) As Boolean

    '        Dim blnCheckErr As Boolean = False       '�����װ�׸�

    '        If DispWait Then
    '            Call gobjComFuncFRM.WaitFormShow()                     ' Wait̫�ѕ\��
    '        End If

    '        '***********************************************
    '        ' �e��޼ު�Ă̲ݽ�ݽ
    '        '***********************************************
    '        Dim objCR As New PRT_311050_01          '�ؽ����߰ĵ�޼ު��
    '        Dim objDataSet As New clsPrintDataSet   '�ް�ð��ٵ�޼ު��

    '        Try
    '            Dim intRet As Integer = 0

    '            '************************************************************
    '            ' ͯ�ް�����擾
    '            '************************************************************
    '            'ͯ�ް���ϐ�
    '            Dim strXSYUKKA_D As String = ""                 '�o�ד�
    '            'Dim strXHENSEI_NO_OYA As String = ""            '�e�Ґ�No.
    '            Dim strXSYARYOU_NO As String = ""               '���qNo.
    '            Dim strXBERTH_NO As String = ""                 '�ް�No.
    '            Dim strXTUMI_HOUHOU As String = ""              '�ύ����@
    '            Dim strXTUMI_HOUKOU As String = ""              '�ύ�����

    '            Dim objTBL_XPLN_OUT As New TBL_XPLN_OUT(gobjOwner, gobjDb, Nothing)
    '            objTBL_XPLN_OUT.XHENSEI_NO_OYA = XHENSEI_NO_OYA     '�e�Ґ�No.
    '            objTBL_XPLN_OUT.XSYUKKA_D = XSYUKKA_D               '�o�ד�
    '            intRet = objTBL_XPLN_OUT.GET_XPLN_OUT_ANY()
    '            If intRet <> RetCode.OK Then
    '                '(�ް��擾���s��)
    '                blnCheckErr = True
    '                Exit Try
    '            End If


    '            For Each objTBL_XPLN_OUT_DATA As TBL_XPLN_OUT In objTBL_XPLN_OUT.ARYME
    '                strXSYARYOU_NO = TO_STRING(objTBL_XPLN_OUT_DATA.XSYARYOU_NO)     '���qNo.
    '                strXBERTH_NO = TO_STRING(objTBL_XPLN_OUT_DATA.XBERTH_NO)         '�ް�No.
    '                strXTUMI_HOUHOU = TO_STRING(objTBL_XPLN_OUT_DATA.XTUMI_HOUHOU)   '�ύ����@
    '                strXTUMI_HOUKOU = TO_STRING(objTBL_XPLN_OUT_DATA.XTUMI_HOUKOU)   '�ύ�����
    '            Next


    '            '************************************************************
    '            ' �ް������擾
    '            '************************************************************
    '            Dim strSQL As String                        'SQL��
    '            Dim objRow As DataRow                       '1ں��ޕ����ް�
    '            Dim strDataSetName As String                '�ް���Ė�
    '            Dim objTBLDataSet As New DataSet            '�ް���āi�ް��擾�p�j

    '            '============================================================
    '            'SELECT
    '            '============================================================
    '            strSQL = ""
    '            strSQL &= vbCrLf & "SELECT "
    '            strSQL &= vbCrLf & "    XPLN_OUT_DTL.XHENSEI_NO "                                       '�o�׎w���ڍ�.      �Ґ�No.
    '            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XDENPYOU_NO "                                      '�o�׎w���ڍ�.      �`�[No.
    '            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XOUT_ORDER "                                       '�o�׎w���ڍ�.  �@�@���q���o�וi�ڏ�
    '            strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                                          '�i��Ͻ�.�@�@       �i������
    '            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                                       '�o�׎w���ڍ�.      �i���L��
    '            strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                                             '�i��Ͻ�.�@�@       �i��
    '            strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESERVE,0) XSYUKKA_KON_RESERVE "   '�o�׎w���ڍ�.  �@�@�o�׈�������
    '            strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_H_RESULT, 0) XSYUKKA_KON_H_RESULT" '�o�׎w���ڍ�.      �o�׎��э���
    '            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FPLAN_KEY "                                        '�o�׎w���ڍ�.      �v�淰


    '            '============================================================
    '            'FROM
    '            '============================================================
    '            strSQL &= vbCrLf & " FROM "
    '            strSQL &= vbCrLf & "    XPLN_OUT_DTL "           '�y�o�׎w���ڍׁz
    '            strSQL &= vbCrLf & "  , TMST_ITEM "              '�y�i��Ͻ��z

    '            '============================================================
    '            'WHERE
    '            '============================================================
    '            strSQL &= vbCrLf & " WHERE "
    '            strSQL &= vbCrLf & "         1 = 1 "
    '            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = '" & XHENSEI_NO_OYA & "' "       '�o�׎w���ڍ� �� �e�Ґ�No. �œ���
    '            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_D = '" & XSYUKKA_D & "' "                 '�o�׎w���ڍ� �� �o�ד� �œ���
    '            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "               '�o�׎w���ڍ� �� �i��Ͻ� �� �i�ں��� �Ō���

    '            '============================================================
    '            'ORDER BY
    '            '============================================================
    '            strSQL &= vbCrLf & " ORDER BY "
    '            strSQL &= vbCrLf & "         XPLN_OUT_DTL.XOUT_ORDER "                                      '�o�׎w���ڍ�.  �@�@���q���o�וi�ڏ�

    '            '-----------------------
    '            '���o
    '            '-----------------------
    '            gobjDb.SQL = strSQL
    '            objDataSet.Clear()
    '            strDataSetName = "XPLN_OUT_DTL"
    '            gobjDb.GetDataSet(strDataSetName, objDataSet)


    '            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
    '                For Each objRow In objDataSet.Tables(strDataSetName).Rows

    '                    Dim strXHENSEI_NO As String = ""                '�Ґ�No.
    '                    Dim strXDENPYOU_NO As String = ""               '�`�[No.
    '                    Dim strXOUT_ORDER As String = ""                '�o�ɏ�
    '                    Dim strXHINMEI_CD As String = ""                '�i������
    '                    Dim strFHINMEI_CD As String = ""                '�i���L��
    '                    Dim strFHINMEI As String = ""                   '�i��
    '                    Dim strXSYUKKA_KON_RESERVE As String = ""       '�o�א�
    '                    Dim strXSYUKKA_KON_H_RESULT As String = ""      '���u

    '                    '�ް���
    '                    strXHENSEI_NO = TO_STRING(objRow("XHENSEI_NO"))
    '                    strXDENPYOU_NO = TO_STRING(objRow("XDENPYOU_NO"))
    '                    strXOUT_ORDER = TO_STRING(objRow("XOUT_ORDER"))
    '                    strXHINMEI_CD = TO_STRING(objRow("XHINMEI_CD"))
    '                    strFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
    '                    strFHINMEI = TO_STRING(objRow("FHINMEI"))
    '                    strXSYUKKA_KON_RESERVE = TO_STRING(objRow("XSYUKKA_KON_RESERVE"))
    '                    strXSYUKKA_KON_H_RESULT = TO_STRING(objRow("XSYUKKA_KON_H_RESULT"))

    '                    Dim strFPLAN_KEY As String = ""                 '�v�淰
    '                    strFPLAN_KEY = TO_STRING(objRow("FPLAN_KEY"))


    '                    '************************************************************
    '                    ' SQL���쐬 �݌Ɉ������擾
    '                    '************************************************************
    '                    Dim strSQL2 As String                        'SQL��
    '                    Dim objRow2 As DataRow                       '1ں��ޕ����ް�
    '                    Dim strDataSetName2 As String                '�ް���Ė�
    '                    Dim objTBLDataSet2 As New DataSet            '�ް���āi�ް��擾�p�j

    '                    '============================================================
    '                    'SELECT
    '                    '============================================================
    '                    strSQL2 = ""
    '                    strSQL2 &= vbCrLf & " SELECT "
    '                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                           '�݌Ɉ������.  �@�@    �v�淰
    '                    'strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                         '�ׯ�ݸ��ޯ̧.          �ׯ�ݸ��ޯ̧No.
    '                    strSQL2 &= vbCrLf & "  , SUM(NVL(TSTS_HIKIATE.FTR_VOL,0)) AS FTR_VOL_SUM "  '�݌Ɉ������.          �����Ǘ��ʍ��v
    '                    strSQL2 &= vbCrLf & "  , COUNT(0) AS FTR_VOL_PL "                           '�݌Ɉ������.          PL��
    '                    ' ''strSQL2 &= vbCrLf & "  , TSTS_HIKIATE.FPALLET_ID "                          '�݌Ɉ������.          ��گ�ID

    '                    '============================================================
    '                    'FROM
    '                    '============================================================
    '                    strSQL2 &= vbCrLf & " FROM "
    '                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE "           '�y�݌Ɉ������z
    '                    'strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF "           '�y�ׯ�ݸ��ޯ̧�z

    '                    '============================================================
    '                    'WHERE
    '                    '============================================================
    '                    strSQL2 &= vbCrLf & " WHERE "
    '                    strSQL2 &= vbCrLf & "         1 = 1 "
    '                    strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = '" & strFPLAN_KEY & "' "             '������� �� �v�淰 �œ���
    '                    'strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "           '������� �� �ׯ�ݸ��ޯ̧ �� ��گ�ID �Ō���

    '                    '============================================================
    '                    'GROUP BY
    '                    '============================================================
    '                    strSQL2 &= vbCrLf & " GROUP BY  "
    '                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                    '�݌Ɉ������.  �@�@�v�淰
    '                    'strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                  '�ׯ�ݸ��ޯ̧.      �ׯ�ݸ��ޯ̧No.

    '                    '============================================================
    '                    'ORDER BY
    '                    '============================================================
    '                    strSQL2 &= vbCrLf & " ORDER BY  "
    '                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                    '�݌Ɉ������.  �@�@�v�淰
    '                    'strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                  '�ׯ�ݸ��ޯ̧.      �ׯ�ݸ��ޯ̧No.
    '                    strSQL2 &= vbCrLf

    '                    '-----------------------
    '                    '���o
    '                    '-----------------------
    '                    gobjDb.SQL = strSQL2
    '                    objTBLDataSet2.Clear()
    '                    strDataSetName2 = "TSTS_HIKIATE"
    '                    gobjDb.GetDataSet(strDataSetName2, objTBLDataSet2)

    '                    Dim intFTR_VOL_CONVEYOR As Integer = 0     '�o�׺����
    '                    Dim intFTR_VOL_CONVEYOR_PL As Integer = 0  '�o�׺����(PL��)

    '                    If objTBLDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
    '                        For Each objRow2 In objTBLDataSet2.Tables(strDataSetName2).Rows

    '                            ' ''Dim strFTRK_BUF_NO As String        '�ׯ�ݸ��ޯ̧No.
    '                            Dim strFTR_VOL_SUM As String        '������
    '                            Dim strFTR_VOL_PL As String         '������(PL)

    '                            ' ''strFTRK_BUF_NO = TO_STRING(objRow2("FTRK_BUF_NO"))
    '                            strFTR_VOL_SUM = TO_STRING(objRow2("FTR_VOL_SUM"))
    '                            strFTR_VOL_PL = TO_STRING(objRow2("FTR_VOL_PL"))

    '                            intFTR_VOL_CONVEYOR = intFTR_VOL_CONVEYOR + TO_INTEGER(strFTR_VOL_SUM)      '�o�׺����
    '                            intFTR_VOL_CONVEYOR_PL = intFTR_VOL_CONVEYOR_PL + TO_INTEGER(strFTR_VOL_PL) '�o�׺����(PL��)

    '                            '' ''Select Case strFTRK_BUF_NO
    '                            '' ''    Case FTRK_BUF_NO_J9000
    '                            '' ''        '(�����q�ɂ̏ꍇ)
    '                            '' ''        intFTR_VOL_CONVEYOR = intFTR_VOL_CONVEYOR + TO_INTEGER(strFTR_VOL_SUM)      '�o�׺����
    '                            '' ''        intFTR_VOL_CONVEYOR_PL = intFTR_VOL_CONVEYOR_PL + TO_INTEGER(strFTR_VOL_PL) '�o�׺����(PL��)
    '                            '' ''    Case FTRK_BUF_NO_J9100, FTRK_BUF_NO_J9200
    '                            '' ''        '(���u�A���i�ر�̏ꍇ)
    '                            '' ''        'intFTR_VOL_HIRAOKI = intFTR_VOL_HIRAOKI + TO_INTEGER(strFTR_VOL_SUM)        '���u
    '                            '' ''    Case Else
    '                            '' ''End Select

    '                        Next
    '                    End If

    '                    '***********************************************
    '                    ' �ް������쐬
    '                    '***********************************************
    '                    Dim objDataRow As clsPrintDataSet.DataTable01Row
    '                    objDataRow = objDataSet.DataTable01.NewRow

    '                    objDataRow.BeginEdit()

    '                    '�߯�ݸ�ؽ� �ް���
    '                    objDataRow.Data00 = strXHENSEI_NO                   '�Ґ�No.
    '                    objDataRow.Data01 = strXDENPYOU_NO                  '�`�[No.
    '                    objDataRow.Data02 = strXOUT_ORDER                   '�o�ɏ�
    '                    objDataRow.Data03 = strXHINMEI_CD                   '�i������
    '                    objDataRow.Data04 = strFHINMEI_CD                   '�i���L��
    '                    objDataRow.Data05 = strFHINMEI                      '�i��
    '                    objDataRow.Data06 = strXSYUKKA_KON_RESERVE          '�o�א�
    '                    objDataRow.Data07 = TO_STRING(intFTR_VOL_CONVEYOR) & "(" & TO_STRING(intFTR_VOL_CONVEYOR_PL) & ")"  '�o�׺����(PL��)
    '                    objDataRow.Data08 = strXSYUKKA_KON_H_RESULT         '���u

    '                    objDataRow.EndEdit()

    '                    objDataSet.DataTable01.Rows.Add(objDataRow)

    '                Next
    '            End If

    '            '***********************************************
    '            ' ͯ�ް�����쐬
    '            '***********************************************
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))          '���s����
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crXSYARYOU_NO", strXSYARYOU_NO)                            '�Ԕ�
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crXBERTH", strXBERTH_NO)                                   '�ް�

    '            Select Case strXTUMI_HOUHOU                                                                         '�ύ����@
    '                Case TO_STRING(XTUMI_HOUHOU_JP)
    '                    strXTUMI_HOUHOU = "�p���b�g"
    '                Case TO_STRING(XTUMI_HOUHOU_JB)
    '                    strXTUMI_HOUHOU = "�o��"
    '                Case TO_STRING(XTUMI_HOUHOU_JL)
    '                    strXTUMI_HOUHOU = "���[�_"
    '            End Select
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crXTUMI_HOUHOU", strXTUMI_HOUHOU)

    '            Select Case strXTUMI_HOUKOU                                                                         '�ύ�����
    '                Case TO_STRING(XTUMI_HOUKOU_JBACK)
    '                    strXTUMI_HOUKOU = "���"
    '                Case TO_STRING(XTUMI_HOUKOU_JSIDE)
    '                    strXTUMI_HOUKOU = "�Љ���"
    '                Case TO_STRING(XTUMI_HOUKOU_JWING)
    '                    strXTUMI_HOUKOU = "������"
    '                Case TO_STRING(XTUMI_HOUKOU_JALL)
    '                    strXTUMI_HOUKOU = "ALL"
    '            End Select
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crXTUMI_HOUKOU", strXTUMI_HOUKOU)

    '            '***********************************************
    '            ' �ؽ����߰Ă��ް���Ă��
    '            '***********************************************
    '            objCR.SetDataSource(objDataSet)

    '            '***********************************************
    '            ' ��
    '            '***********************************************
    '            Call gobjComFuncFRM.CRPrint(objCR)

    '        Catch ex As Exception
    '            Throw ex

    '        Finally

    '            '�ؽ����߰ĵ�޼ު��
    '            objCR.Dispose()
    '            objCR = Nothing
    '            '�ް�ð��ٵ�޼ު��
    '            objDataSet.Dispose()
    '            objDataSet = Nothing

    '            If DispWait Then
    '                Call gobjComFuncFRM.WaitFormClose()                    ' Wait̫�э폜
    '            End If

    '        End Try

    '        If blnCheckErr = True Then
    '            Return False
    '        Else
    '            Return True
    '        End If

    '    End Function

#End Region

#Region "  ��ޏo�ɐݒ�����              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ޏo�ɐݒ�����
    ''' </summary>
    ''' <param name="FTRK_BUF_NO">�ׯ�ݸ��ޯ̧No.</param>
    ''' <returns>�ݒ蒆=True ���ݒ�=False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Check_XSTS_WRAPPING_MATERIAL(ByVal FTRK_BUF_NO As String) As Boolean

        Dim blnReturn As Boolean = False    '�Ԃ�l

        Dim intRet As Integer
        Dim objTBL_XSTS_WRAPPING_MATERIAL As New TBL_XSTS_WRAPPING_MATERIAL(gobjOwner, gobjDb, Nothing)
        objTBL_XSTS_WRAPPING_MATERIAL.FTRK_BUF_NO = FTRK_BUF_NO     '�ׯ�ݸ��ޯ̧No.
        intRet = objTBL_XSTS_WRAPPING_MATERIAL.GET_XSTS_WRAPPING_MATERIAL(False)
        If intRet = RetCode.OK Then
            '(�Y������)
            Dim strFHINMEI_CD As String = ""
            strFHINMEI_CD = TO_STRING(objTBL_XSTS_WRAPPING_MATERIAL.FHINMEI_CD)

            If strFHINMEI_CD = "" Then
                '(��ޏo�ɐݒ�Ȃ�)
                blnReturn = False

            Else
                '(��ޏo�ɐݒ肠��)
                blnReturn = True

            End If

        Else
            '(���̑�)
            blnReturn = False
        End If

        Return blnReturn

    End Function
#End Region


#Region "  �ް����̌��i�L���擾               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް����̌��i�L���擾
    ''' </summary>
    ''' <param name="strXBERTH_NO">�Ώ��ް�No.</param>
    ''' <returns>True=���i���� False=���i�Ȃ�</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function BERTH_GetKeppin(ByVal strXBERTH_NO As String) As Boolean
        Dim strSQL As String                'SQL��
        Dim objDataSet As New DataSet       '�ް����
        Dim strDataSetName As String        '�ް���Ė�
        Dim objRow As DataRow               '1ں��ޕ����ް�
        Dim blnReturn As Boolean = False    '�߂�l

        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO XBERTH_NO"                  '�o���ް���.  �ް�No.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XSYUKKA_D XSYUKKA_D"                  '�o���ް���.  �o�ד���
        strSQL &= vbCrLf & "  , XSTS_BERTH.XHENSEI_NO XHENSEI_NO"                '�o���ް���.  �Ґ�No.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XBERTH_STS XBERTH_STS"                '�o���ް���.  �ް��w����

        strSQL &= vbCrLf & "  , XPLN_OUT.XSYARYOU_NO XSYARYOU_NO"                '�o�׎w��.  ���qNo.
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUHOU XTUMI_HOUHOU"              '�o�׎w��.  �ύ����@
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '�o�׎w��.  �ύ�����
        strSQL &= vbCrLf & "  , XPLN_OUT.XOUT_START_DT XOUT_START_DT"            '�o�׎w��.  �o�ɊJ�n����
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS XSYUKKA_STS"                '�o�׎w��.  �o�׏�
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '�o�׎w��.  �e�Ґ�No.

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                                         '�y�o���ް��󋵁z
        strSQL &= vbCrLf & "  , XPLN_OUT "                                           '�y�o�׎w���z

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ð��ٌ���
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XPLN_OUT.XHENSEI_NO_OYA = XSTS_BERTH.XHENSEI_NO"      '�o�׎w���@�Ɓ@�o���ް��󋵁@���@�Ґ�No.�@�Ō���
        strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_D = XSTS_BERTH.XSYUKKA_D"            '�o�׎w���@�Ɓ@�o���ް��󋵁@���@�o�ד��@ �Ō���
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XBERTH_NO = '" & TO_STRING(strXBERTH_NO) & "' "     '�o�׎w��.�ް�No = �u�w�肳�ꂽ�ް�No�v

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XPLN_OUT.XHENSEI_NO"       '�o�׎w��.      �Ґ�No

        '-----------------------
        '���o
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                '************************************************
                ' ���i����
                '************************************************
                If TO_STRING(objRow("XSYUKKA_STS")) = XSYUKKA_STS_JLESS Then
                    blnReturn = True
                    Exit For
                End If
            Next
        End If

        Return blnReturn

    End Function
#End Region
#Region "  �ް����̕Ґ�No.�擾�֐�            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް����̕Ґ�No.�擾�֐�
    ''' </summary>
    ''' <param name="strXBERTH_NO">�Ώ��ް�No.</param>
    ''' <returns>�Ґ�No.(�ő�4��)</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function BERTH_GetHENSEI_NO(ByVal strXBERTH_NO As String) As String()

        Dim strSQL As String                            'SQL��
        Dim objRow As DataRow                           '1ں��ޕ����ް�
        Dim strDataSetName As String                    '�ް���Ė�
        Dim objDataSet As New DataSet                   '�ް���āi�ް��擾�p�j

        Dim strHENSEI_NO(3) As String                   '�Ґ�No.(�ő�4��)
        Dim jj As Integer = 0

        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT "
        strSQL &= vbCrLf & "    XPLN_OUT.XHENSEI_NO "                                      '�o�׎w��.          �Ґ�No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XKINKYU_LEVEL "                                   '�o�׎w��.          �ً}�x
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                                               '�y�o���ް��󋵁z
        strSQL &= vbCrLf & "  , XPLN_OUT "                                                 '�y�o�׎w���z
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XSTS_BERTH.XSYUKKA_D = XPLN_OUT.XSYUKKA_D(+) "         '�o���ް��󋵁@�Ɓ@�o�׎w���@���@�o�ד��@�@ �Ō���
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XHENSEI_NO = XPLN_OUT.XHENSEI_NO_OYA(+) "   '�o���ް��󋵁@�Ɓ@�o�׎w���@���@�Ґ�No.�@�@�Ō���
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XBERTH_NO = '" & strXBERTH_NO & "' "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XPLN_OUT.XKINKYU_LEVEL "

        '-----------------------
        '���o
        '-----------------------
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        strDataSetName = "PLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                strHENSEI_NO(jj) = TO_STRING(objRow("XHENSEI_NO"))
                jj = jj + 1
            Next
        End If

        Return strHENSEI_NO

    End Function
#End Region
#Region "  �ް����̎cPL�� �擾                "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ް����̎cPL�� �擾
    ''' </summary>
    ''' <param name="strXBERTH_NO">�Ώ��ް�No</param>
    ''' <returns>�cPL��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function BERTH_GetPLCount(ByVal strXBERTH_NO As String) As Integer

        Dim intReturn As Integer = 0                    '�cPL��

        Dim strSQL As String                            'SQL��
        Dim objRow As DataRow                           '1ں��ޕ����ް�
        Dim strDataSetName As String                    '�ް���Ė�
        Dim objDataSet As New DataSet                   '�ް���āi�ް��擾�p�j

        '�o�׎w���ڍ�.�o�ח\�荫���ƕi��Ͻ�.�W���ϕt���������گĐ��Z�o
        Dim intPal As Integer = 0                   '��گĐ�
        Dim intPal_mod As Double

        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO XBERTH_NO"                             '�o���ް���.     �ް�No.
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD FHINMEI_CD"                         '�o�׎w���ڍ�.     �i�ں���
        strSQL &= vbCrLf & "  , TMST_ITEM.FNUM_IN_PALLET FNUM_IN_PALLET"                    '�i��Ͻ�.          PL���ύڐ�"
        strSQL &= vbCrLf & "  , (NVL(XPLN_OUT_DTL.XSYUKKA_KON_PLAN, 0) - NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESULT, 0)) XSYUKKA_KON_PLAN"  '�o�׎w���ڍ�.  �o�ח\�荫��
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                                                       '�y�o���ް��󋵁z
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "                                                     '�y�o�׎w���ڍׁz
        strSQL &= vbCrLf & "  , TMST_ITEM "                                                        '�y�i��Ͻ��z
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XSTS_BERTH.XSYUKKA_D = XPLN_OUT_DTL.XSYUKKA_D(+) "             '�o���ް��󋵁@�Ɓ@�o�׎w���ڍׁ@���@�o�ד��@�@ �Ō���
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XHENSEI_NO = XPLN_OUT_DTL.XHENSEI_NO_OYA(+) "       '�o���ް��󋵁@�Ɓ@�o�׎w���ڍׁ@���@�Ґ�No.�@�@�Ō���
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "            '�o�׎w���ڍׁ@�Ɓ@�i��Ͻ�       ���@�i�ں���   �Ō���
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XBERTH_NO = '" & strXBERTH_NO & "' "

        '-----------------------
        '���o
        '-----------------------
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT_DTL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                If TO_STRING(objRow("FHINMEI_CD")) <> "" Then
                    '(�i�ڃR�[�h�����݂���ꍇ)
                    If TO_NUMBER(objRow("XSYUKKA_KON_PLAN")) = 0 Then
                        '(�\�萔��0�̏ꍇ)
                        intPal = 0
                    ElseIf TO_NUMBER(objRow("XSYUKKA_KON_PLAN")) Mod TO_NUMBER(objRow("FNUM_IN_PALLET")) = 0 Then

                        intPal = (TO_NUMBER(objRow("XSYUKKA_KON_PLAN")) / TO_NUMBER(objRow("FNUM_IN_PALLET")))
                    Else
                        intPal_mod = 1 + (TO_NUMBER(objRow("XSYUKKA_KON_PLAN")) \ TO_NUMBER(objRow("FNUM_IN_PALLET")))
                        intPal = TO_NUMBER(intPal_mod)
                    End If
                End If

                intReturn = intReturn + intPal
            Next
        End If

        BERTH_GetPLCount = intReturn

    End Function
#End Region
#Region "  �ް����̏o�ɒ�PL�� �擾          �@"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް����̏o�ɒ�PL�� �擾
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function COUNT_SYUKKO(ByVal strXBERTH_NO As String) As Long

        Dim strSQL As String                            'SQL��
        Dim RetCount As Long                            '�Ԃ�l

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL.XSYUKKA_STS_DTL XSYUKKA_STS_DTL"             '�o�׎w���ڍ�.  �@�@�o�׏󋵏ڍ�(���)
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "             '�y�o���ް��󋵁z
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "           '�y�o�׎w���ڍׁz
        strSQL &= vbCrLf & "  , TSTS_HIKIATE "           '�y�݌Ɉ������z
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "           '�y�ׯ�ݸ��ޯ̧�z

        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "         XPLN_OUT_DTL.XSYUKKA_D = XSTS_BERTH.XSYUKKA_D "                '�o�׎w���ڍ� �� �o���ް��� �� �o�ד� �Ō���
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = XSTS_BERTH.XHENSEI_NO "          '�o�׎w���ڍ� �� �o���ް��� �� �e�Ґ�No. �Ō���
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FSAGYOU_KIND = XPLN_OUT_DTL.FSAGYOU_KIND "        '�݌Ɉ������ �� �o�׎w���ڍ� �� ��Ǝ�� �Ō���
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = XPLN_OUT_DTL.FPLAN_KEY "              '�݌Ɉ������ �� �o�׎w���ڍ� �� �v�淰 �Ō���
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID = TSTS_HIKIATE.FPALLET_ID "            '�ׯ�ݸ��ޯ̧ �� �o�׎w���ڍ� �� ��گ�ID �Ō���
        strSQL &= vbCrLf & "     AND XSTS_BERTH.XBERTH_NO = '" & strXBERTH_NO & "' "                '�o���ް��� �� �ް�No �Ō���
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & FTRK_BUF_NO_J3201 & "' "       '�o�ɒ�

        '********************************************************************
        '�ް��擾
        '********************************************************************
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�

        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT_DTL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        '********************************************************************
        '�o�ɒ����v
        '********************************************************************
        RetCount = objDataSet.Tables(strDataSetName).Rows.Count

        Return RetCount

    End Function

#End Region
#Region "  �ް����̔�����PL�� �擾          �@"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ������PL�� �擾
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function COUNT_HANSOUTYUU(ByVal strXBERTH_NO As String) As Long

        Dim strSQL As String                            'SQL��
        Dim RetCount As Long                            '�Ԃ�l

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL.XSYUKKA_STS_DTL XSYUKKA_STS_DTL"             '�o�׎w���ڍ�.  �@�@�o�׏󋵏ڍ�(���)
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "             '�y�o���ް��󋵁z
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "           '�y�o�׎w���ڍׁz
        strSQL &= vbCrLf & "  , TSTS_HIKIATE "           '�y�݌Ɉ������z
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "           '�y�ׯ�ݸ��ޯ̧�z

        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "         XPLN_OUT_DTL.XSYUKKA_D = XSTS_BERTH.XSYUKKA_D "                '�o�׎w���ڍ� �� �o���ް��� �� �o�ד� �Ō���
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = XSTS_BERTH.XHENSEI_NO "          '�o�׎w���ڍ� �� �o���ް��� �� �e�Ґ�No. �Ō���
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FSAGYOU_KIND = XPLN_OUT_DTL.FSAGYOU_KIND "        '�݌Ɉ������ �� �o�׎w���ڍ� �� ��Ǝ�� �Ō���
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = XPLN_OUT_DTL.FPLAN_KEY "              '�݌Ɉ������ �� �o�׎w���ڍ� �� �v�淰 �Ō���
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID = TSTS_HIKIATE.FPALLET_ID "            '�ׯ�ݸ��ޯ̧ �� �o�׎w���ڍ� �� ��گ�ID �Ō���
        strSQL &= vbCrLf & "     AND XSTS_BERTH.XBERTH_NO = '" & strXBERTH_NO & "' "                '�o���ް��� �� �ް�No �Ō���
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & FTRK_BUF_NO_J3401 & "' "       '������

        '********************************************************************
        '�ް��擾
        '********************************************************************
        Dim objDataSet As New DataSet           '�ް����
        Dim strDataSetName As String            '�ް���Ė�

        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT_DTL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        '********************************************************************
        '���������v
        '********************************************************************
        RetCount = objDataSet.Tables(strDataSetName).Rows.Count

        Return RetCount

    End Function

#End Region

#Region "  �ް���ٰ�ߖ��̺���ԗp�r�擾        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���ٰ�ߖ��̺���ԗp�r�擾
    ''' </summary>
    ''' <param name="strXBERTH_GROUP">�ް���ٰ��</param>
    ''' <returns>����ԗp�r</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetXCONVEYOR_YOUTO(ByVal strXBERTH_GROUP As String) As String

        Dim strSQL As String                            'SQL��
        'Dim objRow As DataRow                           '1ں��ޕ����ް�
        Dim strDataSetName As String                    '�ް���Ė�
        Dim objDataSet As New DataSet                   '�ް���āi�ް��擾�p�j

        Dim strXCONVEYOR_YOUTO As String = ""           '����ԗp�r

        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT "
        strSQL &= vbCrLf & "    XSTS_CONVEYOR.XCONVEYOR_YOUTO "                             '�o�׺���ԏ�.          ����ԗp�r
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_CONVEYOR "                                             '�y�o�׺���ԏ󋵁z
        strSQL &= vbCrLf & "  , XSTS_BERTH "                                                '�y�o���ް��󋵁z
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XSTS_CONVEYOR.XBERTH_GROUP = XSTS_BERTH.XBERTH_GROUP "  '�o�׺���ԏ󋵁@�Ɓ@�o���ް��󋵁@���@�ް���ٰ�߁@�@ �Ō���
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XBERTH_GROUP = '" & strXBERTH_GROUP & "' "   '

        '-----------------------
        '���o
        '-----------------------
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        strDataSetName = "XSTS_CONVEYOR"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            strXCONVEYOR_YOUTO = TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XCONVEYOR_YOUTO")))
        End If

        Select Case strXCONVEYOR_YOUTO
            Case XCONVEYOR_YOUTO_JPALLET
                '(��گĂ̂Ƃ�)
                strXCONVEYOR_YOUTO = "�p��"

            Case XCONVEYOR_YOUTO_JBARA
                '(��ׂ̂Ƃ�)
                strXCONVEYOR_YOUTO = "�o��"

            Case XCONVEYOR_YOUTO_JINOUT
                '(�ݒ���o�ɂ̂Ƃ�)
                strXCONVEYOR_YOUTO = "�ݒ�"

            Case XCONVEYOR_YOUTO_JDOWN
                '(�޳݂̂Ƃ�)
                strXCONVEYOR_YOUTO = "�ؗ�"
        End Select

        Return strXCONVEYOR_YOUTO

    End Function
#End Region

#Region "  ����ST ���ɗv���E�[���׸�����        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����ST ���ɗv���E�[���׸�����
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO">�ׯ�ݸ��ޯ̧No.</param>
    ''' <param name="intPattern">���������</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Check_IN_HASU_FLAG(ByVal strFTRK_BUF_NO As String, ByVal intPattern As Integer) As Boolean

        Dim intRet As Integer
        Dim strMsg As String
        Dim strSQL As String                            'SQL��
        'Dim objRow As DataRow                           '1ں��ޕ����ް�
        Dim strDataSetName As String                    '�ް���Ė�
        Dim objDataSet As New DataSet                   '�ް���āi�ް��擾�p�j

        Dim strXEQ_ID_IN_FR As String = ""              '���ɗv���O�ݔ�ID
        Dim strXEQ_ID_IN_BK As String = ""              '���ɗv����ݔ�ID
        Dim strXEQ_ID_HASU_FR As String = ""            '�[���O�ݔ�ID
        Dim strXEQ_ID_HASU_BK As String = ""            '�[����ݔ�ID

        Dim intXEQ_ID_IN_FR_STS As Integer              '���ɗv���O�ݔ�ID
        Dim intXEQ_ID_IN_BK_STS As Integer              '���ɗv����ݔ�ID
        Dim intXEQ_ID_HASU_FR_STS As Integer            '�[���O�ݔ�ID
        Dim intXEQ_ID_HASU_BK_STS As Integer            '�[����ݔ�ID

        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    FTRK_BUF_NO "                                               '�ׯ�ݸ��ޯ̧Ͻ�.          �ׯ�ݸ��ޯ̧No
        strSQL &= vbCrLf & "  , XEQ_ID_IN_FR "                                              '�ׯ�ݸ��ޯ̧Ͻ�.          ���ɗv���O�ݔ�ID
        strSQL &= vbCrLf & "  , XEQ_ID_IN_BK "                                              '�ׯ�ݸ��ޯ̧Ͻ�.          ���ɗv����ݔ�ID
        strSQL &= vbCrLf & "  , XEQ_ID_HASU_FR "                                            '�ׯ�ݸ��ޯ̧Ͻ�.          �[���O�ݔ�ID
        strSQL &= vbCrLf & "  , XEQ_ID_HASU_BK "                                            '�ׯ�ݸ��ޯ̧Ͻ�.          �[����ݔ�ID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TMST_TRK "                                                  '�y�ׯ�ݸ��ޯ̧Ͻ��z
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        TMST_TRK.FTRK_BUF_NO = " & strFTRK_BUF_NO               '�ׯ�ݸ��ޯ̧No�œ���

        '-----------------------
        '���o
        '-----------------------
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        strDataSetName = "TMST_TRK"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            strXEQ_ID_IN_FR = (TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XEQ_ID_IN_FR"))))
            strXEQ_ID_IN_BK = (TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XEQ_ID_IN_BK"))))
            strXEQ_ID_HASU_FR = (TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XEQ_ID_HASU_FR"))))
            strXEQ_ID_HASU_BK = (TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XEQ_ID_HASU_BK"))))
        Else
            '(������Ȃ��ꍇ)
            strMsg = ERRMSG_NOTFOUND_TMST_BUF & "[�ׯ�ݸ��ޯ̧No:" & strFTRK_BUF_NO & "]"
            Throw New System.Exception(strMsg)
        End If


        If strXEQ_ID_HASU_FR <> "" And strXEQ_ID_HASU_BK <> "" Then
            '(�[�������L��)

            Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)

            '���ɗv���O�ݔ�ID
            objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_IN_FR
            objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
                Throw New System.Exception(strMsg)
            End If

            intXEQ_ID_IN_FR_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            objTBL_TSTS_EQ_CTRL.Close()

            '���ɗv����ݔ�ID
            objTBL_TSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
            objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_IN_BK
            objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
                Throw New System.Exception(strMsg)
            End If

            intXEQ_ID_IN_BK_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            objTBL_TSTS_EQ_CTRL.Close()

            '�[���O�ݔ�ID
            objTBL_TSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
            objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_HASU_FR
            objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
                Throw New System.Exception(strMsg)
            End If

            intXEQ_ID_HASU_FR_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            objTBL_TSTS_EQ_CTRL.Close()

            '�[����ݔ�ID
            objTBL_TSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
            objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_HASU_BK
            objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
                Throw New System.Exception(strMsg)
            End If

            intXEQ_ID_HASU_BK_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            objTBL_TSTS_EQ_CTRL.Close()



            '��������݂ƐM������v���Ă��邩�m�F
            Select Case intPattern
                Case 1
                    '(��PL��2����)
                    If intXEQ_ID_IN_FR_STS = 1 And _
                       intXEQ_ID_IN_BK_STS = 1 And _
                       intXEQ_ID_HASU_FR_STS = 0 And _
                       intXEQ_ID_HASU_BK_STS = 0 Then

                        Check_IN_HASU_FLAG = True
                    End If

                Case 2
                    '(��PL�ƒ[��PL�̓���)
                    If intXEQ_ID_IN_FR_STS = 1 And _
                       intXEQ_ID_IN_BK_STS = 1 And _
                       intXEQ_ID_HASU_FR_STS = 0 And _
                       intXEQ_ID_HASU_BK_STS = 1 Then

                        Check_IN_HASU_FLAG = True
                    End If

                Case 3
                    '(��PL��1����)
                    If intXEQ_ID_IN_FR_STS = 0 And _
                       intXEQ_ID_IN_BK_STS = 1 And _
                       intXEQ_ID_HASU_FR_STS = 0 And _
                       intXEQ_ID_HASU_BK_STS = 0 Then

                        Check_IN_HASU_FLAG = True
                    End If

                Case 4
                    '(�[��PL��1����)
                    If intXEQ_ID_IN_FR_STS = 0 And _
                       intXEQ_ID_IN_BK_STS = 1 And _
                       intXEQ_ID_HASU_FR_STS = 0 And _
                       intXEQ_ID_HASU_BK_STS = 1 Then

                        Check_IN_HASU_FLAG = True
                    End If

            End Select

        Else
            '(�[�������Ȃ�)

            Check_IN_HASU_FLAG = True

            '' ''Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)

            ' '' ''���ɗv���O�ݔ�ID
            '' ''objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_IN_FR
            '' ''objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            '' ''If intRet = RetCode.NotFound Then
            '' ''    '(������Ȃ��ꍇ)
            '' ''    strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
            '' ''    Throw New System.Exception(strMsg)
            '' ''End If

            '' ''intXEQ_ID_IN_FR_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            '' ''objTBL_TSTS_EQ_CTRL.Close()

            ' '' ''���ɗv����ݔ�ID
            '' ''objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_IN_BK
            '' ''objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            '' ''If intRet = RetCode.NotFound Then
            '' ''    '(������Ȃ��ꍇ)
            '' ''    strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
            '' ''    Throw New System.Exception(strMsg)
            '' ''End If

            '' ''intXEQ_ID_IN_BK_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            '' ''objTBL_TSTS_EQ_CTRL.Close()

        End If

        Return Check_IN_HASU_FLAG

    End Function
#End Region


    '���������ьŗL
    '**********************************************************************************************



End Class
