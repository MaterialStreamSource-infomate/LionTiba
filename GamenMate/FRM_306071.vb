'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産ﾗｲﾝﾏｽﾀ(D45)ﾒﾝﾃﾅﾝｽ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_306071

#Region "  共通変数　                           "

    Private mFlag_Form_Load As Boolean = True       '画面展開ﾌﾗｸﾞ

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjXMST_PROD_LINE_D45 As TBL_XMST_PROD_LINE_D45              '生産ﾗｲﾝ(D45)ﾏｽﾀ

    'ﾌﾟﾛﾊﾟﾃｨ
    Dim mintButtonMode As Integer                   'ﾎﾞﾀﾝﾓｰﾄﾞ
    Private mstrXPROD_LINE As String                '生産ﾗｲﾝ№

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

    '生産ﾗｲﾝ№
    Public Property userXPROD_LINE() As String
        Get
            Return mstrXPROD_LINE
        End Get
        Set(ByVal value As String)
            mstrXPROD_LINE = value
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
    Private Sub FRM_306071_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Private Sub FRM_306071_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        ' 生産ﾗｲﾝﾏｽﾀ情報の特定
        '**********************************************************
        mobjXMST_PROD_LINE_D45 = New TBL_XMST_PROD_LINE_D45(gobjOwner, gobjDb, Nothing)
        If IsNull(mstrXPROD_LINE) = False Then
            mobjXMST_PROD_LINE_D45.XPROD_LINE = mstrXPROD_LINE               '生産ﾗｲﾝ№
            mobjXMST_PROD_LINE_D45.GET_XMST_PROD_LINE_D45(False)
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
        txtXPROD_LINE.Text = TO_STRING(mstrXPROD_LINE)                                  '生産ﾗｲﾝ№
        txtXPROD_LINE_NAME.Text = TO_STRING(mobjXMST_PROD_LINE_D45.XPROD_LINE_NAME)         '生産ﾗｲﾝ名称

        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        '===================================
        ' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = mobjXMST_PROD_LINE_D45.FHINMEI_CD
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

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
        txtXPROD_LINE.Dispose()
        txtXPROD_LINE_NAME.Dispose()
        cboFHINMEI_CD.Dispose()

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
                '生産ﾗｲﾝ№
                '========================================
                If txtXPROD_LINE.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XPROD_LINE, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '生産ﾗｲﾝ№重複ﾁｪｯｸ
                '========================================
                Dim objXMST_PROD_LINE_D45 As New TBL_XMST_PROD_LINE_D45(gobjOwner, gobjDb, Nothing)         '生産ﾗｲﾝﾏｽﾀ
                Dim intRet As Integer
                objXMST_PROD_LINE_D45.XPROD_LINE = txtXPROD_LINE.Text                                       '生産ﾗｲﾝ№
                intRet = objXMST_PROD_LINE_D45.GET_XMST_PROD_LINE_D45(False)                            '特定
                If intRet = RetCode.OK Then
                    '(入力された生産ﾗｲﾝ№が登録されている場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XPROD_LINE_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '生産ﾗｲﾝ名称
                '========================================
                If txtXPROD_LINE_NAME.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XPROD_LINE_NAME_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False


            Case BUTTONMODE_UPDATE
                '(変更の場合)

                '========================================
                '生産ﾗｲﾝ名称
                '========================================
                If txtXPROD_LINE_NAME.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XPROD_LINE_NAME_01, _
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

                txtXPROD_LINE.Enabled = True                    '生産ﾗｲﾝ№
                txtXPROD_LINE_NAME.Enabled = True               '生産ﾗｲﾝ名称
                cboFHINMEI_CD.Enabled = True                    '品名ｺｰﾄﾞ

                Exit Select

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                txtXPROD_LINE.Enabled = False                   '生産ﾗｲﾝ№
                txtXPROD_LINE_NAME.Enabled = True               '生産ﾗｲﾝ名称
                cboFHINMEI_CD.Enabled = True                    '品名ｺｰﾄﾞ

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)

                txtXPROD_LINE.Enabled = False                   '生産ﾗｲﾝ№
                txtXPROD_LINE_NAME.Enabled = False              '生産ﾗｲﾝ名称
                cboFHINMEI_CD.Enabled = False                   '品名ｺｰﾄﾞ

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
        Dim strDIR_KUBUN As String = ""             '処理区分
        Dim strXPROD_LINE As String = ""            '生産ﾗｲﾝ№
        Dim strXPROD_LINE_NAME As String = ""       '生産ﾗｲﾝ名称
        Dim strFHINMEI_CD As String = ""            '品目ｺｰﾄﾞ

        '********************************************************************
        ' 品名記号取得
        '********************************************************************
        If cboFHINMEI_CD.Text = "" Then
            '(空の場合)

        ElseIf IsNumeric(cboFHINMEI_CD.Text.Substring(0, 1)) Then
            '(品名ｺｰﾄﾞの場合)
            Dim intRet As Integer
            Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            objTBL_TMST_ITEM.XHINMEI_CD = cboFHINMEI_CD.Text
            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                strFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
            End If

        Else
            '(品名記号の場合)
            strFHINMEI_CD = cboFHINMEI_CD.Text
        End If

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400606                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strXPROD_LINE = TO_STRING(txtXPROD_LINE.Text)                               '生産ﾗｲﾝ№
        strXPROD_LINE_NAME = TO_STRING(txtXPROD_LINE_NAME.Text)                     '生産ﾗｲﾝ名称

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
        objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)                      '生産ﾗｲﾝ№
        objTelegram.SETIN_DATA("XDSPPROD_LINE_NAME", strXPROD_LINE_NAME)            '生産ﾗｲﾝ名称
        objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)                       '品目ｺｰﾄﾞ

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
