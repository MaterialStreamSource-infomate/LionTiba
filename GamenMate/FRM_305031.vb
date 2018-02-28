'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】保留設定子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_305031

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Public mstrFPALLET_ID() As String       'ﾊﾟﾚｯﾄID
    Public mstrFLOT_NO_STOCK() As String    '在庫ﾛｯﾄ№

#End Region
#Region "  構造体定義                               "
    ''ｿｹｯﾄ送信情報
    'Private Structure STOCK_DATA
    '    Dim DSPPALLET_ID As String      'ﾊﾟﾚｯﾄID
    '    Dim DSPLOT_NO_STOCK As String   'ﾛｯﾄ№
    '    Dim DSPHORYU_KUBUN As String    '保留区分
    '    Dim DSPHORYU_NO As String       '保留№
    '    Dim DSPHORYU_REASON As String   '保留理由
    'End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' ======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userPALLET_ID() As String()
        Get
            Return mstrFPALLET_ID
        End Get
        Set(ByVal value As String())
            mstrFPALLET_ID = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>在庫ﾛｯﾄ№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFLOT_NO_STOCK() As String()
        Get
            Return mstrFLOT_NO_STOCK
        End Get
        Set(ByVal value As String())
            mstrFLOT_NO_STOCK = value
        End Set
    End Property
#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_305031_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_305031_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " 実行ﾎﾞﾀﾝｸﾘｯｸ                              "
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
#Region " ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                        "
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
#Region "　保留区分ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ     ｲﾍﾞﾝﾄ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 保留区分ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFHORYU_KUBUN_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHORYU_KUBUN.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                Select Case TO_STRING(cboFHORYU_KUBUN.SelectedValue)
                    Case FHORYU_KUBUN_SNORMAL
                        '(通常の時)
                        lblXHORYU_NO.Visible = False            '保留№
                        lblXHORYU_REASON.Visible = False        '保留理由
                        txtXHORYU_NO.Visible = False
                        txtXHORYU_REASON.Visible = False
                        txtXHORYU_NO.Text = ""
                        txtXHORYU_REASON.Text = ""
                    Case FHORYU_KUBUN_SHORYU
                        '(保留の時)
                        lblXHORYU_NO.Visible = True             '保留№
                        lblXHORYU_REASON.Visible = True         '保留理由
                        txtXHORYU_NO.Visible = True
                        txtXHORYU_REASON.Visible = True
                        txtXHORYU_NO.Text = ""
                        txtXHORYU_REASON.Text = ""
                    Case FHORYU_KUBUN_JKINSHI
                        '(禁止の時)
                        lblXHORYU_NO.Visible = False            '保留№
                        lblXHORYU_REASON.Visible = False        '保留理由
                        txtXHORYU_NO.Visible = False
                        txtXHORYU_REASON.Visible = False
                        txtXHORYU_NO.Text = ""
                        txtXHORYU_REASON.Text = ""
                    Case Else
                        '(以外の時)
                        lblXHORYU_NO.Visible = False            '保留№
                        lblXHORYU_REASON.Visible = False        '保留理由
                        txtXHORYU_NO.Visible = False
                        txtXHORYU_REASON.Visible = False
                        txtXHORYU_NO.Text = ""
                        txtXHORYU_REASON.Text = ""
                End Select

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()

        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, True)     '保留区分


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblXHORYU_NO.Visible = False            '保留№
        lblXHORYU_REASON.Visible = False        '保留理由
        txtXHORYU_NO.Visible = False
        txtXHORYU_REASON.Visible = False
        txtXHORYU_NO.Text = ""
        txtXHORYU_REASON.Text = ""


        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        cboFHORYU_KUBUN.Dispose()
        txtXHORYU_NO.Dispose()
        txtXHORYU_REASON.Dispose()

    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理                "
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
        If SendSocket02() = False Then
            Exit Sub
        End If

        Me.Close()

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case "a"
            Case "a"

                '==========================
                '保留区分  選択ﾁｪｯｸ
                '==========================
                If TO_STRING(cboFHORYU_KUBUN.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboFHORYU_KUBUN.SelectedValue.ToString)) = True Then
                    '(保留区分が選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305031_03, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                '=====================================
                '保留区分=「保留」の時の必須入力ﾁｪｯｸ
                '=====================================
                If TO_STRING(cboFHORYU_KUBUN.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboFHORYU_KUBUN.SelectedValue.ToString)) = True Then
                    '(選択無い時)
                Else
                    '(選択ある時)
                    If TO_STRING(cboFHORYU_KUBUN.SelectedValue) = FHORYU_KUBUN_SHORYU Then
                        '(「保留」の時)
                        If txtXHORYU_REASON.Text = "" Then
                            '(保留理由に入力無い時)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305031_05, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                        If txtXHORYU_NO.Text = "" Then
                            '(保留№に入力無い時)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305031_04, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                    End If
                End If



                '**********************************************************
                ' 引当処理中確認
                '**********************************************************
                If gobjComFuncFRM.KariHikiate_Syukko_Chk() = False Then
                    '(仮引当処理中の時)
                    blnCheckErr = True
                    Exit Select
                End If


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

#Region "  ｿｹｯﾄ送信02                             　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSocket02() As Boolean

        Dim blnReturn As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305031_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Return blnReturn
        End If


        Dim strFHORYU_KUBUN As String = TO_STRING(cboFHORYU_KUBUN.SelectedValue)    '保留区分
        Dim strXHORYU_NO As String = txtXHORYU_NO.Text                              '保留№
        Dim strXHORYU_REASON As String = txtXHORYU_REASON.Text                      '保留理由
        Dim strXHORYU_DT = Format(Now, "yyyy/MM/dd")                                '保留年月日


        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing

        For ii As Integer = LBound(mstrFPALLET_ID) To UBound(mstrFPALLET_ID)
            '(展開元画面の行分ﾙｰﾌﾟ)

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            '*******************************************************
            ' 電文作成
            '*******************************************************
            '========================================
            ' 変数宣言
            '========================================
            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
            Dim strDSPPALLET_ID As String = ""               'ﾊﾟﾚｯﾄID
            Dim strDSPLOT_NO_STOCK As String = ""            '在庫ﾛｯﾄ№
       

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400402       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            strDSPPALLET_ID = mstrFPALLET_ID(ii)                                'ﾊﾟﾚｯﾄID
            strDSPLOT_NO_STOCK = mstrFLOT_NO_STOCK(ii)                          '在庫ﾛｯﾄ№

            objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID
            objTelegramSub.SETIN_DATA("DSPLOT_NO_STOCK", strDSPLOT_NO_STOCK)    '在庫ﾛｯﾄ№

            objTelegramSub.MAKE_TELEGRAM()

            strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED

        Next


        '*******************************************************
        ' 電文作成
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strPARA_ID As String = ""

        Dim strDSPHORYU_KUBUN As String = ""             '保留区分
        Dim strXDSPHORYU_NO As String = ""               '保留№
        Dim strXDSPHORYU_REASON As String = ""           '保留理由
        Dim strXDSPHORYU_DT As String = ""               '保留年月日

        strDSPHORYU_KUBUN = strFHORYU_KUBUN                              '保留区分

        If strFHORYU_KUBUN = FHORYU_KUBUN_SHORYU Then
            '(保留品の時)
            strXDSPHORYU_NO = strXHORYU_NO                                   '保留№
            strXDSPHORYU_REASON = strXHORYU_REASON                           '保留理由
            strXDSPHORYU_DT = strXHORYU_DT                                   '保留年月日
        Else
            '(以外の時)
            strXDSPHORYU_NO = ""                                             '保留№
            strXDSPHORYU_REASON = ""                                         '保留理由
            strXDSPHORYU_DT = ""                                             '保留年月日
        End If

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400402       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPHINSHITU_STS", "")                   '品質ｽﾃｰﾀｽ
        objTelegram.SETIN_DATA("XDSPSYUKKA_KAHI", "")                    '出荷可否
        objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strDSPHORYU_KUBUN)      '保留区分
        objTelegram.SETIN_DATA("XDSPHORYU_NO", strXDSPHORYU_NO)          '保留№
        objTelegram.SETIN_DATA("XDSPHORYU_REASON", strXDSPHORYU_REASON)  '保留理由
        objTelegram.SETIN_DATA("XDSPHORYU_DT", strXDSPHORYU_DT)          '保留年月日

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM305031_02
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnReturn = True
            End If
        End If

        Return blnReturn

    End Function
#End Region

End Class
