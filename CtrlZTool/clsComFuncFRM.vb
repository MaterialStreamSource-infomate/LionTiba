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
#End Region

Public Class clsComFuncFRM

    '**********************************************************************************************
    '���������ы���


    '**********************************************************************************************
    ' ��۰��ٕϐ�
    '**********************************************************************************************
    Public Shared gobjDb As clsConnZTool                        'DB�ڑ���޼ު��
    Public Shared gobjOwner As clsOwner                         '��ʗp��Ű��޼ު��
    Public Shared gblnFirst As Boolean = True                   '�ŏ���̫�т��ۂ�


    Public Shared gobjFRM_100004 As FRM_100004          'Wait���

    '�擾�ް�
    Public Shared gcstrFUSER_ID As String                    'հ�ްID
    Public Shared gcstrFTERM_ID As String                    '�[��ID

    '=======================================================================
    ' Config    �擾�ް�
    '=======================================================================
    '��ʴװ۸ޗp
    Public Shared gcstrLOG_FILE_PATH As String              '̧�يi�[�ꏊ
    Public Shared gcstrLOG_FILE_NAME As String              '̧�ٖ�         
    Public Shared gcstrLOG_FILE_NAME_OLD As String          '̧�ٖ�(�Â�)   
    Public Shared gcstrLOG_FILE_SIZE As String              '�ő�̧�ٻ���   


    '**********************************************************************************************
    ' ��۰��ْ萔
    '**********************************************************************************************
    'Config��
    Public Const GKEY_G000000_005 As String = "G000000_005"           '���۸�̧�ٖ�
    Public Const GKEY_G000000_006 As String = "G000000_006"           '���۸�̧�ٖ�(�Â���)
    Public Const GKEY_G000000_007 As String = "G000000_007"           '���۸�̧�ق̍ő廲��
    Public Const GKEY_G000000_020 As String = "G000000_020"           '�����Ȱ�
    Public Const GKEY_G000000_021 As String = "G000000_021"           '�s���Ȱ�
    Public Const GKEY_G000000_022 As String = "G000000_022"           'PDF�o�͐�i�J���җp�j
    Public Const GKEY_G000000_031 As String = "G000000_031"           '���۸�̧�يi�[�ꏊ
    Public Const GKEY_G000000_041 As String = "G000000_041"           '°��د��÷���ޯ��������ٸد��������ɐݒ肷��Now�����̍���(Min)
    Public Const GKEY_G000000_042 As String = "G000000_042"           '��۸��ъJ�n����̫�я��    0:ɰ��   1:�ő剻
    Public Const GKEY_G000000_043 As String = "G000000_043"           '��د�ޕ\���̍ہA�x��ү���ނ�\�������ƂȂ�s��   (�����Őݒ肳�ꂽ�s���𒴂���ƌx��ү���ނ��o�͂���)
    Public Const GKEY_G000000_044 As String = "G000000_044"           '1�b�ŕ\���\�ȍs��(�s/sec)                          (�x��ү���ނŎg�p)
    Public Const GKEY_G000000_051 As String = "G000000_051"           '��۸��ъJ�n���ɕ\������ð��وꗗ
    Public Const GKEY_G000000_061 As String = "G000000_061"           '۸�ð��ٕ\����`   �yð��ٖ��z@@@�y̨���ޖ��z
    Public Const GKEY_G000000_062 As String = "G000000_062"           '۸�ð��ٕ\����`���������`
    '���̑�
    Public Const CONFIG_ZTOOL As String = "..\Config\xmlZTool.config"               'Confiģ�ٖ�(ZTool)
    Public Const DATE_FORMAT_02 As String = "yyyy/MM/dd"                            '���t̫�ϯ�
    Public Const DATE_FORMAT_03 As String = "yyyy/MM/dd HH:mm:ss"                   '���t̫�ϯ�



#Region "  Confiģ�ق���A���擾             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Confiģ�ق�����擾
    ''' </summary>
    ''' <param name="sKey">�������鷰</param>
    ''' <returns>Confiģ�ق���擾����������</returns>
    ''' <remarks>�����ɂĎw�����ꂽ����Confiģ�ق��擾����</remarks>
    ''' *******************************************************************************************************************
    Public Shared Function GET_CONFIG_INFO(ByVal sKey As String) As String
        Dim strRet As String = ""                               '�ߒl
        Dim objSystem As New clsConnectConfig(CONFIG_ZTOOL)     'Confiģ�ِڑ��׽�i��ʗpConfig�j

        strRet = TO_STRING(objSystem.GET_INFO(sKey))

        Return (strRet)
    End Function
#End Region
#Region "  ۸ޏ�������                          "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ۸ޏ�������
    ''' </summary>
    ''' <param name="strMsg_1">ү����1</param>
    ''' <param name="intErrorType">�װ����</param>
    ''' <param name="strMsg_3">ү����3</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Shared Sub AddToLog_frm(ByVal strMsg_1 As String, _
                                   Optional ByVal intErrorType As AddToLog_D_ErrorType = AddToLog_D_ErrorType.USER_LOG, _
                                   Optional ByVal strMsg_3 As String = "")
        Try
            Dim strMsg_2 As String = ""

            '***************************************
            '���O�o��
            '***************************************
            Dim objLogWrite As clsWriteLog
            objLogWrite = New clsWriteLog
            objLogWrite.clspFileName = gcstrLOG_FILE_PATH & gcstrLOG_FILE_NAME       '̧�ٖ�         ���
            objLogWrite.clspCopyFile = gcstrLOG_FILE_PATH & gcstrLOG_FILE_NAME_OLD   '̧�ٖ�(�Â�)   ���
            objLogWrite.clspMaxSize = gcstrLOG_FILE_SIZE        '�ő�̧�ٻ���   ���


            Select Case intErrorType
                Case AddToLog_D_ErrorType.PROGRAM_ERROR
                    strMsg_2 = FRM_ERR_COMERROR_TITLE
                Case AddToLog_D_ErrorType.USER_ERROR
                    strMsg_2 = FRM_ERR_USERERRO_TITLE
                Case AddToLog_D_ErrorType.USER_LOG
                    strMsg_2 = FRM_ERR_USERLOG_TITLE
            End Select


            objLogWrite.WriteLog(strMsg_1, strMsg_2, strMsg_3)              '۸ޏ���

        Catch ex2 As Exception
            MsgBox("AddToLog_frm�֐��Ŵװ����")

        End Try
    End Sub
#End Region
#Region "  �װ����      (�p����ʗp)            "
    ''' ****************************************************************************************
    ''' <summary>
    ''' �װ����(�p����ʗp)
    ''' </summary>
    ''' <param name="objException">�װ�� Exception</param>
    ''' <param name="lblError">�װ��\������������</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Shared Sub ComError_frm(ByVal objException As Exception, _
                                   Optional ByVal lblError As Windows.Forms.Label = Nothing)
        Try


            '***************************************
            'Wait��ʂ������I�ɸ۰��
            '  ����Ĵװ�̎��AWait��ʂ��c�����܂܂ɂȂ��
            '  �ǂ����Ȃ�A�װ�������������ɂ́A�����l����Wait��ʂ��폜����悤��
            '***************************************
            Call WaitFormClose()


            '***************************************
            '÷�Đ���
            '***************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(objException.StackTrace, ",", "�C")       '���p��ς�S�p��ςɕϊ�
            strStackTrace = Split(strTemp, vbCrLf)


            '****************************************
            ' ۸ޏ�����
            '****************************************
            For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
                AddToLog_frm(objException.Message, _
                             AddToLog_D_ErrorType.PROGRAM_ERROR, _
                             strStackTrace(ii))
            Next


            '***************************************
            '���ُo��
            '***************************************
            If Not (IsNull(lblError)) Then
                lblError.Text = FRM_ERR_COMERROR_TITLE & objException.Message
            Else

                MsgBox(objException.Message, _
                       MsgBoxStyle.Exclamation, _
                       FRM_ERR_COMERROR_TITLE)

            End If


        Catch ex2 As Exception
            MsgBox("ComError_frm�֐��Ŵװ����")

        End Try
    End Sub
#End Region
#Region "  Wait̫��         Show�AClose����     "
    Public Shared Sub WaitFormShow()

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

    Public Shared Sub WaitFormClose()

        '***************************************************
        ' ү���ލ폜
        '***************************************************
        If IsNull(gobjFRM_100004) = False Then
            gobjFRM_100004.Close()
            gobjFRM_100004.Dispose()
            gobjFRM_100004 = Nothing
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
    Public Shared Sub CRPrintKaihatu(ByVal grdControl As System.Windows.Forms.DataGridView _
                                   , ByVal strTableName As String _
                                   , ByVal strText01 As String _
                                   , ByVal strText02 As String _
                                   , ByVal strText05 As String _
                                   , ByVal strText06 As String _
                                   , ByVal strText07 As String _
                                   , ByVal strFooter01 As String _
                                   )

        Call WaitFormShow()                     ' Wait̫�ѕ\��


        '***********************************************
        ' �e��޼ު�Ă̲ݽ�ݽ
        '***********************************************
        Dim objCR As New PRT_000001             '�ؽ����߰ĵ�޼ު��
        Dim objDataSet As New clsPrintDataSet   '�ް�ð��ٵ�޼ު��
        Dim strColTerminator As String = GET_CONFIG_INFO(GKEY_G000000_020)
        Dim strRowTerminator As String = GET_CONFIG_INFO(GKEY_G000000_021)

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
                Call DivStringToArray(strData, strDataArray)

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
            Dim strPathPDF As String = GET_CONFIG_INFO(GKEY_G000000_022)
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

            Call WaitFormClose()                    ' Wait̫�э폜

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
    Public Shared Sub ChangeCRText(ByVal objCR As Object, _
                            ByVal strObjectName As String, _
                            ByVal strText As String)

        CType(objCR.ReportDefinition.ReportObjects(strObjectName),  _
              CrystalDecisions.CrystalReports.Engine.TextObject). _
              Text = strText

    End Sub
#End Region
#Region "  �������x�������������āA�z��ɑ}��    "
    '''****************************************************************************************
    ''' <summary>
    ''' �������x�������������āA�z��ɑ}��
    ''' </summary>
    ''' <param name="strString">�������镶����</param>
    ''' <param name="strArray">������̔z��</param>
    ''' <param name="intDivLength">�������镶����</param>
    ''' <remarks></remarks>
    '''****************************************************************************************
    Public Shared Sub DivStringToArray(ByVal strString As String _
                                     , ByRef strArray() As String _
                                     , Optional ByVal intDivLength As Integer = 180 _
                                     )
        Dim strWork As String = strString
        Dim ii As Integer = 0


        While True
            Dim strTemp As String = MID_SJIS(strWork, 1, intDivLength)
            If strTemp = "" Then Exit While
            ReDim Preserve strArray(ii)
            strArray(ii) = strTemp
            ii += 1
            strWork = Replace(strWork, strTemp, "")
        End While


    End Sub
#End Region

    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL


    '���������ьŗL
    '**********************************************************************************************





End Class
