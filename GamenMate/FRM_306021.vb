'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】車輌ﾏｽﾀ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_306021

#Region "  共通変数　                           "

    Private mFlag_Form_Load As Boolean = True       '画面展開ﾌﾗｸﾞ

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjXMST_SYARYOU As TBL_XMST_SYARYOU        '車輌ﾏｽﾀ

    'ﾌﾟﾛﾊﾟﾃｨ
    Dim mintButtonMode As Integer                   'ﾎﾞﾀﾝﾓｰﾄﾞ
    Private mstrXSYARYOU_NO As String               '車輌番号
    ' ''Private mstrXTUMI_HOUKOU As String              '積込方向
    ' ''Private mstrXTUMI_HOUHOU As String              '積込方法
    ' ''Private mstrXNOT_USER As String                 '未使用区分
    ' ''Private mstrXCARD_NO As String                  'ｶｰﾄﾞNo.
    ' ''Private mstrXSYASYU_KBN As String               '車種区分
    ' ''Private mstrXSYASYU_COMMENT As String           '車輌ｺﾒﾝﾄ
    ' ''Private mstrXGYOUSYA_CD As String               '業者ｺｰﾄﾞ
    ' ''Private mstrXLOADER_POSSIBLE As String          'ﾛｰﾀﾞ対応可否
    ' ''Private mstrXSYARYOU_MODE As String             'ﾛｰﾀﾞﾓｰﾄﾞ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                        "
    ' ﾎﾞﾀﾝﾓｰﾄﾞ
    Public Property userButtonMode() As Integer
        Get
            Return mintButtonMode
        End Get
        Set(ByVal Value As Integer)
            mintButtonMode = Value
        End Set
    End Property

    '車輌番号
    Public Property userXSYARYOU_NO() As String
        Get
            Return mstrXSYARYOU_NO
        End Get
        Set(ByVal value As String)
            mstrXSYARYOU_NO = value
        End Set
    End Property

    '' ''積込方向
    ' ''Public Property userXTUMI_HOUKOU() As String
    ' ''    Get
    ' ''        Return mstrXTUMI_HOUKOU
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXTUMI_HOUKOU = value
    ' ''    End Set
    ' ''End Property

    '' ''積込方法
    ' ''Public Property userXTUMI_HOUHOU() As String
    ' ''    Get
    ' ''        Return mstrXTUMI_HOUHOU
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXTUMI_HOUHOU = value
    ' ''    End Set
    ' ''End Property

    '' ''未使用区分
    ' ''Public Property userXNOT_USER() As String
    ' ''    Get
    ' ''        Return mstrXNOT_USER
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXNOT_USER = value
    ' ''    End Set
    ' ''End Property

    '' ''ｶｰﾄﾞNo.
    ' ''Public Property userXCARD_NO() As String
    ' ''    Get
    ' ''        Return mstrXCARD_NO
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXCARD_NO = value
    ' ''    End Set
    ' ''End Property

    '' ''車種区分
    ' ''Public Property userXSYASYU_KBN() As String
    ' ''    Get
    ' ''        Return mstrXSYASYU_KBN
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXSYASYU_KBN = value
    ' ''    End Set
    ' ''End Property

    '' ''車種ｺﾒﾝﾄ
    ' ''Public Property userXSYASYU_COMMENT() As String
    ' ''    Get
    ' ''        Return mstrXSYASYU_COMMENT
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXSYASYU_COMMENT = value
    ' ''    End Set
    ' ''End Property

    '' ''業者ｺｰﾄﾞ
    ' ''Public Property userXGYOUSYA_CD() As String
    ' ''    Get
    ' ''        Return mstrXGYOUSYA_CD
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXGYOUSYA_CD = value
    ' ''    End Set
    ' ''End Property

    '' ''ﾛｰﾀﾞ対応可否
    ' ''Public Property userXLOADER_POSSIBLE() As String
    ' ''    Get
    ' ''        Return mstrXLOADER_POSSIBLE
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXLOADER_POSSIBLE = value
    ' ''    End Set
    ' ''End Property

    '' ''ﾛｰﾀﾞﾓｰﾄﾞ
    ' ''Public Property userXSYARYOU_MODE() As String
    ' ''    Get
    ' ''        Return mstrXSYARYOU_MODE
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXSYARYOU_MODE = value
    ' ''    End Set
    ' ''End Property

#End Region
#Region "  ｲﾍﾞﾝﾄ                                "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_306021_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ﾌｫｰﾑｱﾝﾛｰﾄﾞ                            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_306021_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  実行ﾎﾞﾀﾝｸﾘｯｸ                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                   "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾛｰﾀﾞ対応　ｺﾝﾎﾞﾎﾞｯｸｽ変更              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cboXLOADER_POSSIBLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboXLOADER_POSSIBLE.SelectedIndexChanged
        Try
            If mFlag_Form_Load = False Then
                If cboXLOADER_POSSIBLE.SelectedIndex <> 2 Then
                    '(未対応選択時)
                    txtXSYARYOU_MODE.Text = ""
                    txtXSYARYOU_MODE.Enabled = False
                Else
                    txtXSYARYOU_MODE.Enabled = True
                End If


            End If

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub LoadProcess()


        '**********************************************************
        ' 車輌ﾏｽﾀ情報の特定
        '**********************************************************
        mobjXMST_SYARYOU = New TBL_XMST_SYARYOU(gobjOwner, gobjDb, Nothing)
        If IsNull(mstrXSYARYOU_NO) = False Then
            mobjXMST_SYARYOU.XSYARYOU_NO = mstrXSYARYOU_NO                      '車輌番号
            mobjXMST_SYARYOU.GET_XMST_SYARYOU(False)
        End If


        '**********************************************************
        ' 実行ﾎﾞﾀﾝ                  ｾｯﾄ
        '**********************************************************
        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                cmdZikkou.Text = "追加"
            Case BUTTONMODE_UPDATE
                '(変更の場合)
                cmdZikkou.Text = "変更"
            Case BUTTONMODE_DELETE
                '(削除の場合)
                cmdZikkou.Text = "削除"
        End Select

        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        ' 積込方向ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXTUMI_HOUKOU, True, mobjXMST_SYARYOU.XTUMI_HOUKOU)
        ' 積込方法ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXTUMI_HOUHOU, True, mobjXMST_SYARYOU.XTUMI_HOUHOU)
        ' 未使用区分ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXNOT_USER, True, mobjXMST_SYARYOU.XNOT_USER)
        ' 車種区分ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        Call gobjComFuncFRM.cboMsterSetup("XMST_SYASYU", "XSYASYU_KBN", "XSYASYU_NAME", "XSYASYU_KBN", cboXSYASYU_KBN, True, mobjXMST_SYARYOU.XSYASYU_KBN)
        ' 業者区分ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        Call gobjComFuncFRM.cboMsterSetup("XMST_GYOUSYA", "XGYOUSYA_CD", "XGYOUSYA_NAME", "XGYOUSYA_CD", cboXGYOUSYA_CD, True, mobjXMST_SYARYOU.XGYOUSYA_CD)
        ' ﾛｰﾀﾞ対応ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXLOADER_POSSIBLE, True, mobjXMST_SYARYOU.XLOADER_POSSIBLE)

        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        txtXSYARYOU_NO.Text = TO_STRING(mstrXSYARYOU_NO)                        '車輌番号
        txtXCARD_NO.Text = TO_STRING(mobjXMST_SYARYOU.XCARD_NO)                 'ｶｰﾄﾞNo.
        txtXSYASYU_COMMENT.Text = TO_STRING(mobjXMST_SYARYOU.XSYASYU_COMMENT)   '車種ｺﾒﾝﾄ
        txtXSYARYOU_MODE.Text = TO_STRING(mobjXMST_SYARYOU.XSYARYOU_MODE)       'ﾛｰﾀﾞﾓｰﾄﾞ

        '===================================
        ' ｺﾝﾄﾛｰﾙﾏｽｸ処理
        '===================================
        Call ControlEnable()


        mFlag_Form_Load = False


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        txtXSYARYOU_NO.Dispose()
        cboXTUMI_HOUKOU.Dispose()
        cboXTUMI_HOUHOU.Dispose()
        cboXNOT_USER.Dispose()

    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck() = False Then

            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01()


    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                           "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ
        Dim intRet As Integer

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                '========================================
                '車輌番号
                '========================================
                If txtXSYARYOU_NO.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '車輌番号重複ﾁｪｯｸ
                '========================================
                Dim objXMST_SYARYOU As New TBL_XMST_SYARYOU(gobjOwner, gobjDb, Nothing)         '車輌ﾏｽﾀ
                objXMST_SYARYOU.XSYARYOU_NO = txtXSYARYOU_NO.Text                               '車輌番号
                intRet = objXMST_SYARYOU.GET_XMST_SYARYOU(False)                        '特定
                If intRet = RetCode.OK Then
                    '(入力された車輌番号が登録されている場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_05, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '積込方向
                '========================================
                If cboXTUMI_HOUKOU.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_02, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '積込方法
                '========================================
                If cboXTUMI_HOUHOU.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_03, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '未使用区分
                '========================================
                If cboXNOT_USER.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_04, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ｶｰﾄﾞNo.
                '========================================
                If txtXCARD_NO.Text <> "" Then
                    '(入力がある場合)
                    Dim objTBL_XMST_SYARYOU As New TBL_XMST_SYARYOU(gobjOwner, gobjDb, Nothing)         '車輌ﾏｽﾀ
                    objTBL_XMST_SYARYOU.XCARD_NO = txtXCARD_NO.Text                                     'ｶｰﾄﾞNo.
                    intRet = objTBL_XMST_SYARYOU.GET_XMST_SYARYOU(False)
                    If intRet = RetCode.OK Then
                        '(重複した場合)
                        If objTBL_XMST_SYARYOU.XSYARYOU_NO <> txtXSYARYOU_NO.Text Then
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_10, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Information)
                            Exit Select
                        End If
                    End If
                End If

                '========================================
                '車種区分
                '========================================
                If cboXSYASYU_KBN.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_06, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '業者
                '========================================
                If cboXGYOUSYA_CD.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_07, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾛｰﾀﾞ対応
                '========================================
                If cboXLOADER_POSSIBLE.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_08, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾛｰﾀﾞﾓｰﾄﾞ
                '========================================
                If cboXLOADER_POSSIBLE.SelectedIndex = 2 Then
                    '(ﾛｰﾀﾞ対応の場合)
                    If txtXSYARYOU_MODE.Text = "" Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_09, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select
                    End If
                End If

                blnCheckErr = False

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                '========================================
                '積込方向
                '========================================
                If cboXTUMI_HOUKOU.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_02, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '積込方法
                '========================================
                If cboXTUMI_HOUHOU.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_03, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '未使用区分
                '========================================
                If cboXNOT_USER.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_04, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ｶｰﾄﾞNo.
                '========================================
                If txtXCARD_NO.Text <> "" Then
                    '(入力がある場合)
                    Dim objTBL_XMST_SYARYOU As New TBL_XMST_SYARYOU(gobjOwner, gobjDb, Nothing)         '車輌ﾏｽﾀ
                    objTBL_XMST_SYARYOU.XCARD_NO = txtXCARD_NO.Text                                     'ｶｰﾄﾞNo.
                    intRet = objTBL_XMST_SYARYOU.GET_XMST_SYARYOU(False)
                    If intRet = RetCode.OK Then
                        '(重複した場合)
                        If objTBL_XMST_SYARYOU.XSYARYOU_NO <> txtXSYARYOU_NO.Text Then
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_10, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Information)
                            Exit Select
                        End If
                    End If
                End If

                '========================================
                '車種区分
                '========================================
                If cboXSYASYU_KBN.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_06, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '業者
                '========================================
                If cboXGYOUSYA_CD.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_07, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾛｰﾀﾞ対応
                '========================================
                If cboXLOADER_POSSIBLE.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_08, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾛｰﾀﾞﾓｰﾄﾞ
                '========================================
                If cboXLOADER_POSSIBLE.SelectedIndex = 2 Then
                    '(ﾛｰﾀﾞ対応の場合)
                    If txtXSYARYOU_MODE.Text = "" Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306021_09, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select
                    End If
                End If

                blnCheckErr = False


            Case BUTTONMODE_DELETE
                '(削除の場合)


                blnCheckErr = False

        End Select


        If blnCheckErr = True Then
            '(ﾁｪｯｸに引っかかった時)
            blnReturn = False
        Else
            '(ﾁｪｯｸに引っかからなかった時)
            blnReturn = True
        End If

        Return blnReturn

    End Function
#End Region
#Region "　ｺﾝﾄﾛｰﾙﾏｽｸ処理　                      "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub ControlEnable()

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)

                txtXSYARYOU_NO.Enabled = True                   '車輌番号
                cboXTUMI_HOUKOU.Enabled = True                  '積込方向
                cboXTUMI_HOUHOU.Enabled = True                  '積込方法
                cboXNOT_USER.Enabled = True                     '未使用区分
                txtXCARD_NO.Enabled = True                      'ｶｰﾄﾞNo.
                cboXSYASYU_KBN.Enabled = True                   '車種区分
                txtXSYASYU_COMMENT.Enabled = True               '車種ｺﾒﾝﾄ
                cboXGYOUSYA_CD.Enabled = True                   '業者ｺｰﾄﾞ
                cboXLOADER_POSSIBLE.Enabled = True              'ﾛｰﾀﾞ対応
                txtXSYARYOU_MODE.Enabled = False                'ﾛｰﾀﾞﾓｰﾄﾞ

                Exit Select

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                txtXSYARYOU_NO.Enabled = False                  '車輌番号
                cboXTUMI_HOUKOU.Enabled = True                  '積込方向
                cboXTUMI_HOUHOU.Enabled = True                  '積込方法
                cboXNOT_USER.Enabled = True                     '未使用区分
                txtXCARD_NO.Enabled = True                      'ｶｰﾄﾞNo.
                cboXSYASYU_KBN.Enabled = True                   '車種区分
                txtXSYASYU_COMMENT.Enabled = True               '車種ｺﾒﾝﾄ
                cboXGYOUSYA_CD.Enabled = True                   '業者ｺｰﾄﾞ
                cboXLOADER_POSSIBLE.Enabled = True              'ﾛｰﾀﾞ対応
                If cboXLOADER_POSSIBLE.SelectedIndex = 2 Then   'ﾛｰﾀﾞﾓｰﾄﾞ
                    txtXSYARYOU_MODE.Enabled = True
                Else
                    txtXSYARYOU_MODE.Enabled = False
                End If

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)

                txtXSYARYOU_NO.Enabled = False                  '車輌番号
                cboXTUMI_HOUKOU.Enabled = False                 '積込方向
                cboXTUMI_HOUHOU.Enabled = False                 '積込方法
                cboXNOT_USER.Enabled = False                    '未使用区分
                txtXCARD_NO.Enabled = False                     'ｶｰﾄﾞNo.
                cboXSYASYU_KBN.Enabled = False                  '車種区分
                txtXSYASYU_COMMENT.Enabled = False              '車種ｺﾒﾝﾄ
                cboXGYOUSYA_CD.Enabled = False                  '業者ｺｰﾄﾞ
                cboXLOADER_POSSIBLE.Enabled = False             'ﾛｰﾀﾞ対応
                txtXSYARYOU_MODE.Enabled = False                'ﾛｰﾀﾞﾓｰﾄﾞ

                Exit Select

        End Select

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信                             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub SendSocket01()

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= cmdZikkou.Text & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strDIR_KUBUN As String = ""                 '処理区分
        Dim strXSYARYOU_NO As String = ""               '車輌番号
        Dim strXTUMI_HOUKOU As String = ""              '積込方向
        Dim strXTUMI_HOUHOU As String = ""              '積込方法
        Dim strXNOT_USER As String = ""                 '未使用区分
        Dim strXCARD_NO As String = ""                  'ｶｰﾄﾞNo.
        Dim strXSYASYU_KUBUN As String = ""             '車種区分
        Dim strXSYASYU_COMMENT As String = ""           '車種ｺﾒﾝﾄ
        Dim strXGYOUSYA_CD As String = ""               '業者ｺｰﾄﾞ
        Dim strXLOADER_POSSIBLE As String = ""          'ﾛｰﾀﾞ可否
        Dim strXSYARYOU_MODE As String = ""             'ﾛｰﾀﾞﾓｰﾄﾞ

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400601                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strXSYARYOU_NO = TO_STRING(txtXSYARYOU_NO.Text)                             '車輌番号
        strXTUMI_HOUKOU = TO_STRING(cboXTUMI_HOUKOU.SelectedValue)                  '積込方向
        strXTUMI_HOUHOU = TO_STRING(cboXTUMI_HOUHOU.SelectedValue)                  '積込方法
        strXNOT_USER = TO_STRING(cboXNOT_USER.SelectedValue)                        '未使用区分
        strXCARD_NO = TO_STRING(txtXCARD_NO.Text)                                   'ｶｰﾄﾞNo.
        strXSYASYU_KUBUN = TO_STRING(cboXSYASYU_KBN.SelectedValue)                  '車種区分
        strXSYASYU_COMMENT = TO_STRING(txtXSYASYU_COMMENT.Text)                     '車種ｺﾒﾝﾄ
        strXGYOUSYA_CD = TO_STRING(cboXGYOUSYA_CD.SelectedValue)                    '業者ｺｰﾄﾞ
        strXLOADER_POSSIBLE = TO_STRING(cboXLOADER_POSSIBLE.SelectedValue)          'ﾛｰﾀﾞ可否
        strXSYARYOU_MODE = TO_STRING(txtXSYARYOU_MODE.Text)                         'ﾛｰﾀﾞﾓｰﾄﾞ

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_ADD)            '指示区分
            Case BUTTONMODE_UPDATE
                '(変更の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_UPDATE)         '指示区分
            Case BUTTONMODE_DELETE
                '(削除の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_DELETE)         '指示区分
        End Select

        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                        '指示区分
        objTelegram.SETIN_DATA("XDSPSYARYOU_NO", strXSYARYOU_NO)                    '車輌番号
        objTelegram.SETIN_DATA("XDSPTUMI_HOUKOU", strXTUMI_HOUKOU)                  '積込方向
        objTelegram.SETIN_DATA("XDSPTUMI_HOUHOU", strXTUMI_HOUHOU)                  '積込方法
        objTelegram.SETIN_DATA("XDSPNOT_USER", strXNOT_USER)                        '未使用区分
        objTelegram.SETIN_DATA("XDSPCARD_NO", strXCARD_NO)                          'ｶｰﾄﾞNo.
        objTelegram.SETIN_DATA("XDSPSYASYU_KBN", strXSYASYU_KUBUN)                  '車種区分
        objTelegram.SETIN_DATA("XDSPSYASYU_COMMENT", strXSYASYU_COMMENT)            '車種ｺﾒﾝﾄ
        objTelegram.SETIN_DATA("XDSPGYOUSYA_CD", strXGYOUSYA_CD)                    '業者ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPLOADER_POSSIBLE", strXLOADER_POSSIBLE)          'ﾛｰﾀﾞ可否
        objTelegram.SETIN_DATA("XDSPSYARYOU_MODE", strXSYARYOU_MODE)                'ﾛｰﾀﾞﾓｰﾄﾞ



        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                   'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = cmdZikkou.Text & FRM_MSG_FRM200000_14
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()

            End If
        End If

    End Sub
#End Region

End Class
