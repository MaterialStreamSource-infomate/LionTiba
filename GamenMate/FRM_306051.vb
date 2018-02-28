'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】包装材料ﾒｰｶ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_306051
#Region "  共通変数　                           "

    Private mFlag_Form_Load As Boolean = True       '画面展開ﾌﾗｸﾞ

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjXMST_WRAPPING_MAKER As TBL_XMST_WRAPPING_MAKER          '包装材料ﾒｰｶ

    'ﾌﾟﾛﾊﾟﾃｨ
    Dim mintButtonMode As Integer                   'ﾎﾞﾀﾝﾓｰﾄﾞ
    Private mstrXMAKER_CD As String                 'ﾒｰｶ-ｺｰﾄﾞ

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

    'ﾒｰｶ-ｺｰﾄﾞ
    Public Property userXMAKER_CD() As String
        Get
            Return mstrXMAKER_CD
        End Get
        Set(ByVal value As String)
            mstrXMAKER_CD = value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_306051_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Private Sub FRM_306051_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        ' 包装材料ﾒｰｶ情報の特定
        '**********************************************************
        mobjXMST_WRAPPING_MAKER = New TBL_XMST_WRAPPING_MAKER(gobjOwner, gobjDb, Nothing)
        If IsNull(mstrXMAKER_CD) = False Then
            mobjXMST_WRAPPING_MAKER.XMAKER_CD = mstrXMAKER_CD               'ﾒｰｶ-ｺｰﾄﾞ
            mobjXMST_WRAPPING_MAKER.GET_XMST_WRAPPING_MAKER(False)
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
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        txtXMAKER_CD.Text = TO_STRING(mstrXMAKER_CD)                                    'ﾒｰｶ-ｺｰﾄﾞ
        txtXMAKER_NAME.Text = TO_STRING(mobjXMST_WRAPPING_MAKER.XMAKER_NAME)            'ﾒｰｶ-名


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
        txtXMAKER_CD.Dispose()
        txtXMAKER_NAME.Dispose()

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
                'ﾒｰｶ-ｺｰﾄﾞ
                '========================================
                If txtXMAKER_CD.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306051_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾒｰｶ-ｺｰﾄﾞ重複ﾁｪｯｸ
                '========================================
                Dim objXMST_WRAPPING_MAKER As New TBL_XMST_WRAPPING_MAKER(gobjOwner, gobjDb, Nothing)       '包装材料ﾒｰｶ
                Dim intRet As Integer
                objXMST_WRAPPING_MAKER.XMAKER_CD = txtXMAKER_CD.Text                            'ﾒｰｶ-ｺｰﾄﾞ
                intRet = objXMST_WRAPPING_MAKER.GET_XMST_WRAPPING_MAKER(False)                  '特定
                If intRet = RetCode.OK Then
                    '(入力されたﾒｰｶ-ｺｰﾄﾞが登録されている場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XMAKER_CD_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾒｰｶ-名
                '========================================
                If txtXMAKER_NAME.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306051_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                '========================================
                'ﾒｰｶ-名
                '========================================
                If txtXMAKER_NAME.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306051_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
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

                txtXMAKER_CD.Enabled = True                     'ﾒｰｶ-ｺｰﾄﾞ
                txtXMAKER_NAME.Enabled = True                   'ﾒｰｶ-名

                Exit Select

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                txtXMAKER_CD.Enabled = False                    'ﾒｰｶ-ｺｰﾄﾞ
                txtXMAKER_NAME.Enabled = True                   'ﾒｰｶ-名

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)

                txtXMAKER_CD.Enabled = False                    'ﾒｰｶ-ｺｰﾄﾞ
                txtXMAKER_NAME.Enabled = False                  'ﾒｰｶ-名

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
        Dim strXMAKER_CD As String = ""                 'ﾒｰｶ-ｺｰﾄﾞ
        Dim strXMAKER_NAME As String = ""               'ﾒｰｶ-名

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400604                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strXMAKER_CD = TO_STRING(txtXMAKER_CD.Text)                         'ﾒｰｶ-ｺｰﾄﾞ
        strXMAKER_NAME = TO_STRING(txtXMAKER_NAME.Text)                     'ﾒｰｶ-名

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
        objTelegram.SETIN_DATA("XDSPMAKER_CD", strXMAKER_CD)                        'ﾒｰｶ-ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPMAKER_NAME", strXMAKER_NAME)                    'ﾒｰｶ-名

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
