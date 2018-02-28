'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】物流業者ﾏｽﾀﾒﾝﾃﾅﾝｽ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_306031

#Region "  共通変数　                           "

    Private mFlag_Form_Load As Boolean = True       '画面展開ﾌﾗｸﾞ

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjXMST_GYOUSYA As TBL_XMST_GYOUSYA        '業者ﾏｽﾀ

    'ﾌﾟﾛﾊﾟﾃｨ
    Dim mintButtonMode As Integer                   'ﾎﾞﾀﾝﾓｰﾄﾞ
    Private mstrXGYOUSYA_CD As String               '物流業者ｺｰﾄﾞ

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

    '物流業者ｺｰﾄﾞ
    Public Property userXGYOUSYA_CD() As String
        Get
            Return mstrXGYOUSYA_CD
        End Get
        Set(ByVal value As String)
            mstrXGYOUSYA_CD = value
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
    Private Sub FRM_306031_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Private Sub FRM_306031_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        ' 業者ﾏｽﾀ情報の特定
        '**********************************************************
        mobjXMST_GYOUSYA = New TBL_XMST_GYOUSYA(gobjOwner, gobjDb, Nothing)
        If IsNull(mstrXGYOUSYA_CD) = False Then
            mobjXMST_GYOUSYA.XGYOUSYA_CD = mstrXGYOUSYA_CD               '業者ｺｰﾄﾞ
            mobjXMST_GYOUSYA.GET_XMST_GYOUSYA(False)
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
        txtXGYOUSYA_CD.Text = TO_STRING(mstrXGYOUSYA_CD)                                '物流業者ｺｰﾄﾞ
        txtXGYOUSYA_NAME.Text = TO_STRING(mobjXMST_GYOUSYA.XGYOUSYA_NAME)               '物流業者名称
        txtXGYOUSYA_RYAKU.Text = TO_STRING(mobjXMST_GYOUSYA.XGYOUSYA_RYAKU)             '略称
        txtXADDRESS.Text = TO_STRING(mobjXMST_GYOUSYA.XADDRESS)                         '住所
        txtXTELEPHONE.Text = TO_STRING(mobjXMST_GYOUSYA.XTELEPHONE)                     '電話番号
        txtXPOSTAL_CODE.Text = TO_STRING(mobjXMST_GYOUSYA.XPOSTAL_CODE)                 '郵便番号

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
        txtXGYOUSYA_CD.Dispose()
        txtXGYOUSYA_NAME.Dispose()
        txtXGYOUSYA_RYAKU.Dispose()

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
                '物流業者ｺｰﾄﾞ
                '========================================
                If txtXGYOUSYA_CD.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306031_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '物流業者ｺｰﾄﾞ重複ﾁｪｯｸ
                '========================================
                Dim objXMST_GYOUSYA As New TBL_XMST_GYOUSYA(gobjOwner, gobjDb, Nothing)         '業者ﾏｽﾀ
                Dim intRet As Integer
                objXMST_GYOUSYA.XGYOUSYA_CD = txtXGYOUSYA_CD.Text                               '物流業者ｺｰﾄﾞ
                intRet = objXMST_GYOUSYA.GET_XMST_GYOUSYA(False)                              '特定
                If intRet = RetCode.OK Then
                    '(入力された物流業者ｺｰﾄﾞが登録されている場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XGYOUSYA_CD_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '物流業者名称
                '========================================
                If txtXGYOUSYA_NAME.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306031_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '略称
                '========================================
                If txtXGYOUSYA_RYAKU.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306031_03, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False


            Case BUTTONMODE_UPDATE
                '(変更の場合)

                '========================================
                '物流業者名称
                '========================================
                If txtXGYOUSYA_NAME.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306031_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '略称
                '========================================
                If txtXGYOUSYA_RYAKU.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306031_03, _
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

                txtXGYOUSYA_CD.Enabled = True                       '物流業者ｺｰﾄﾞ
                txtXGYOUSYA_NAME.Enabled = True                     '物流業者名称
                txtXGYOUSYA_RYAKU.Enabled = True                    '略称
                txtXADDRESS.Enabled = True                          '住所
                txtXTELEPHONE.Enabled = True                        '電話番号
                txtXPOSTAL_CODE.Enabled = True                      '郵便番号

                Exit Select

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                txtXGYOUSYA_CD.Enabled = False                      '物流業者ｺｰﾄﾞ
                txtXGYOUSYA_NAME.Enabled = True                     '物流業者名称
                txtXGYOUSYA_RYAKU.Enabled = True                    '略称
                txtXADDRESS.Enabled = True                          '住所
                txtXTELEPHONE.Enabled = True                        '電話番号
                txtXPOSTAL_CODE.Enabled = True                      '郵便番号

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)

                txtXGYOUSYA_CD.Enabled = False                      '物流業者ｺｰﾄﾞ
                txtXGYOUSYA_NAME.Enabled = False                    '物流業者名称
                txtXGYOUSYA_RYAKU.Enabled = False                   '略称
                txtXADDRESS.Enabled = False                          '住所
                txtXTELEPHONE.Enabled = False                        '電話番号
                txtXPOSTAL_CODE.Enabled = False                      '郵便番号

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
        Dim strXGYOUSYA_CD As String = ""               '物流業者ｺｰﾄﾞ
        Dim strXGYOUSYA_NAME As String = ""             '物流業者名称
        Dim strXGYOUSYA_RYAKU As String = ""            '略称
        Dim strXADDRESS As String = ""                  '住所
        Dim strXTELEPHONE As String = ""                '電話番号
        Dim strXPOSTAL_CODE As String = ""              '郵便番号

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400602              'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strXGYOUSYA_CD = TO_STRING(txtXGYOUSYA_CD.Text)                         '物流業者ｺｰﾄﾞ
        strXGYOUSYA_NAME = TO_STRING(txtXGYOUSYA_NAME.Text)                     '物流業者名称
        strXGYOUSYA_RYAKU = TO_STRING(txtXGYOUSYA_RYAKU.Text)                   '略称
        strXADDRESS = TO_STRING(txtXADDRESS.Text)                               '住所
        strXTELEPHONE = TO_STRING(txtXTELEPHONE.Text)                           '電話番号
        strXPOSTAL_CODE = TO_STRING(txtXPOSTAL_CODE.Text)                       '郵便番号

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

        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                    '指示区分
        objTelegram.SETIN_DATA("XDSPGYOUSYA_CD", strXGYOUSYA_CD)                '物流業者ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPGYOUSYA_NAME", strXGYOUSYA_NAME)            '物流業者名称
        objTelegram.SETIN_DATA("XDSPGYOUSYA_RYAKU", strXGYOUSYA_RYAKU)          '略称
        objTelegram.SETIN_DATA("XDSPADDRESS", strXADDRESS)                      '住所
        objTelegram.SETIN_DATA("XDSPTELEPHONE", strXTELEPHONE)                  '電話番号
        objTelegram.SETIN_DATA("XDSPPOSTAL_CODE", strXPOSTAL_CODE)              '郵便番号


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode        'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                        'ｴﾗｰﾒｯｾｰｼﾞ

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
