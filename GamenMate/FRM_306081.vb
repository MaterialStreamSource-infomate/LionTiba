'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産ﾗｲﾝﾏｽﾀﾒﾝﾃﾅﾝｽ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_306081

#Region "  共通変数　                           "

    Private mFlag_Form_Load As Boolean = True       '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Dim mintButtonMode As Integer                   'ﾎﾞﾀﾝﾓｰﾄﾞ
    Private mstrXDPL_PL_NO As String                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    Private mstrXDPL_PL_NAME As String              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
    Private mstrXPROD_LINE As String                '生産ﾗｲﾝ名称
    Private mstrFTRK_BUF_NO As Nullable(Of Integer) '入出庫ST

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

    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    Public Property userXDPL_PL_NO() As String
        Get
            Return mstrXDPL_PL_NO
        End Get
        Set(ByVal value As String)
            mstrXDPL_PL_NO = value
        End Set
    End Property

    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
    Public Property userXDPL_PL_NAME() As String
        Get
            Return mstrXDPL_PL_NAME
        End Get
        Set(ByVal value As String)
            mstrXDPL_PL_NAME = value
        End Set
    End Property

    '生産ﾗｲﾝ名称
    Public Property userXPROD_LINE() As String
        Get
            Return mstrXPROD_LINE
        End Get
        Set(ByVal value As String)
            mstrXPROD_LINE = value
        End Set
    End Property

    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Public Property userFTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mstrFTRK_BUF_NO
        End Get
        Set(ByVal value As Nullable(Of Integer))
            mstrFTRK_BUF_NO = value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                              "
        '*******************************************************************************************************************
        '【機能】同上
        '【引数】
        '【戻値】

    Private Sub FRM_306081_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Private Sub FRM_306081_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        txtXDPL_PL_NO.Text = TO_STRING(mstrXDPL_PL_NO)                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        txtXDPL_PL_NAME.Text = TO_STRING(mstrXDPL_PL_NAME)              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称

        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        '===================================
        '生産ﾗｲﾝNo.ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE, True, mstrXPROD_LINE, "")

        '===================================
        ' 入出庫STｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_JFRM_306080, Me.cboFTRK_BUF_NO, True, mstrFTRK_BUF_NO, "")

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
        txtXDPL_PL_NO.Dispose()
        txtXDPL_PL_NAME.Dispose()
        cboXPROD_LINE.Dispose()
        cboFTRK_BUF_NO.Dispose()

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

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                '========================================
                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
                '========================================
                If txtXDPL_PL_NO.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306081_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号重複ﾁｪｯｸ
                '========================================
                Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(gobjOwner, gobjDb, Nothing)       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
                Dim intRet As Integer
                objXMST_DPL_PL.XDPL_PL_NO = TO_INTEGER(txtXDPL_PL_NO.Text)                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
                intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)                              '特定
                If intRet = RetCode.OK Then
                    '(入力されたﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号が登録されている場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306081_03, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '設備名称
                '========================================
                If txtXDPL_PL_NAME.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306081_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '入出庫ST
                '========================================
                If cboFTRK_BUF_NO.Text = "" Then
                    '未入力を許可する
                End If

                blnCheckErr = False


            Case BUTTONMODE_UPDATE
                '(変更の場合)

                '========================================
                '設備名称
                '========================================
                If txtXDPL_PL_NAME.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306081_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '入出庫ST
                '========================================
                If cboFTRK_BUF_NO.Text = "" Then
                    '未入力を許可する
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

                txtXDPL_PL_NO.Enabled = True                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
                txtXDPL_PL_NAME.Enabled = True              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
                cboXPROD_LINE.Enabled = True                '生産ﾗｲﾝ名称
                cboFTRK_BUF_NO.Enabled = True               '入出庫ST

                Exit Select

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                txtXDPL_PL_NO.Enabled = False               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
                txtXDPL_PL_NAME.Enabled = True              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
                cboXPROD_LINE.Enabled = True                '生産ﾗｲﾝ名称
                cboFTRK_BUF_NO.Enabled = True               '入出庫ST

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)

                txtXDPL_PL_NO.Enabled = False               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
                txtXDPL_PL_NAME.Enabled = False             'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
                cboXPROD_LINE.Enabled = False               '生産ﾗｲﾝ名称
                cboFTRK_BUF_NO.Enabled = False              '入出庫ST

                Exit Select

        End Select

        '入出庫STは変更不可にする
        cboFTRK_BUF_NO.Enabled = False

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
        Dim strDIR_KUBUN As String = ""             '処理区分
        Dim strXDPL_PL_NO As String                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        Dim strXDPL_PL_NAME As String               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
        Dim strXPROD_LINE As String                 '生産ﾗｲﾝ名称
        Dim strFTRK_BUF_NO As String                '入出庫ST


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400607          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strXDPL_PL_NO = TO_STRING(txtXDPL_PL_NO.Text)                       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        strXDPL_PL_NAME = TO_STRING(txtXDPL_PL_NAME.Text)                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
        strXPROD_LINE = TO_STRING(cboXPROD_LINE.SelectedValue)              '生産ﾗｲﾝ名称
        strFTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)            '入出庫ST

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_ADD)                    '指示区分
            Case BUTTONMODE_UPDATE
                '(変更の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_UPDATE)                 '指示区分
            Case BUTTONMODE_DELETE
                '(削除の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_DELETE)                 '指示区分
        End Select

        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '指示区分
        objTelegram.SETIN_DATA("XDSPDPL_PL_NO", strXDPL_PL_NO)              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        objTelegram.SETIN_DATA("XDSPDPL_PL_NAME", strXDPL_PL_NAME)          'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
        objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)              '生産ﾗｲﾝ名称
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFTRK_BUF_NO)             '入出庫ST

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
