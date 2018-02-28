'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】離席ﾛｸﾞｲﾝ設定画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                          "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMatePDA.clsComFuncPDA
#End Region

Public Class PDA_100005

#Region "　共通変数                         "

    'ﾌﾟﾛﾊﾟﾃｨ用
    Private mudtAfkRet As AFKFrmRetType             'ﾛｸﾞｵﾝ/ﾛｸﾞｵﾌ

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        OK_Click                'OKﾎﾞﾀﾝｸﾘｯｸ
    End Enum

    Protected mblnClose As Boolean      'ｸﾛｰｽﾞ許可ﾌﾗｸﾞ

#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨ                          "
    ''' <summary>画面戻値(ﾛｸﾞｵﾝ/強制ﾛｸﾞｵﾌ)</summary>
    Public ReadOnly Property AFKFORMRET() As AFKFrmRetType
        Get
            Return mudtAfkRet
        End Get
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                            "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PDA_100005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞｲﾝﾎﾞﾀﾝ押下                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞｲﾝﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        Try

            cmdLogin_Proc()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　強制ﾛｸﾞｱｳﾄﾎﾞﾀﾝ押下               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 強制ﾛｸﾞｱｳﾄﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogoff.Click
        Try

            cmdLogoff_Proc()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾊﾟｽﾜｰﾄﾞ入力              KeyDown     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ入力 KeyDown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtPassCd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassCd.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                cmdLogin.Focus()
            End If

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ﾌｫｰﾑｸﾛｰｽﾞ                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｸﾛｰｽﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PDA_100005_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try


            '****************************************
            'ｸﾛｰｽﾞ処理
            '****************************************
            If mblnClose = False Then
                '=================================
                'ｸﾛｰｽﾞしない
                '=================================
                e.Cancel = True

            End If


        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmLoad()
        Dim intRet As RetCode           '戻値用


        '*******************************************************
        'ﾕｰｻﾞｰID取得
        '*******************************************************
        Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
        objTMST_USER.FUSER_ID = gcstrFUSER_ID               'ﾕｰｻﾞｰID
        intRet = objTMST_USER.GET_TMST_USER(False)          '取得


        '*******************************************************
        ' 初期設定
        '*******************************************************
        lblUserCd.Text = gcstrFUSER_ID                  '担当者ｺｰﾄﾞ
        lblUserName.Text = gcstrFUSER_NAME              '担当者名
        mblnClose = False                               'ｸﾛｰｽﾞ許可ﾌﾗｸﾞ


    End Sub
#End Region
#Region "  ﾛｸﾞｲﾝ            ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞｲﾝ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogin_Proc()


        '****************************************************
        '入力ﾁｪｯｸ
        '****************************************************
        If InputCheck(menmCheckCase.OK_Click) = False Then
            Exit Sub

        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理(ﾊﾟｽﾜｰﾄﾞ登録処理)
        '********************************************************************
        Call SendSocket01()


    End Sub
#End Region
#Region "　強制ﾛｸﾞｵﾌ        ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 強制ﾛｸﾞｵﾌ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogoff_Proc()

        Dim udeRet As RetPopup

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        udeRet = gobjComFuncPDA.DisplayPopup(FRM_MSG_SHUTDOWN, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200006           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        Call gobjComFuncPDA.SockSendServer01(objTelegram)                                  'ｿｹｯﾄ送信


        'ﾛｸﾞｵﾌをｾｯﾄ
        mudtAfkRet = AFKFrmRetType.LogOff

        '画面ｸﾛｰｽﾞ
        mblnClose = True
        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">入力ﾁｪｯｸ判別</param>
    ''' <returns>True:入力ﾁｪｯｸ成功  False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)

        Select Case udtCheck_Case
            Case menmCheckCase.OK_Click
                '(OKﾎﾞﾀﾝｸﾘｯｸ時)

                If txtPassCd.Text = "" Then
                    '(ﾊﾟｽﾜｰﾄﾞがﾌﾞﾗﾝｸのとき)
                    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_07, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    Exit Function
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
#Region "  ｿｹｯﾄ送信                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strDSPLOGIN_ID As String = ""           'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        Dim strPASSWORD As String = ""              'ﾊﾟｽﾜｰﾄﾞ


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200002              'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strDSPLOGIN_ID = TO_STRING(lblUserCd.Text)          'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        strPASSWORD = TO_STRING(txtPassCd.Text)             'ﾊﾟｽﾜｰﾄﾞ

        objTelegram.SETIN_DATA("DSPLOGIN_ID", strDSPLOGIN_ID)       'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        objTelegram.SETIN_DATA("DSPPASS_WORD", strPASSWORD)         'ﾊﾟｽﾜｰﾄﾞ


        Dim strRET_STATE As String = ""                 '応答ｽﾃｰﾀｽ
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値

        udtSckSendRET = gobjComFuncPDA.SockSendServer01(objTelegram, strRET_STATE)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

                'ﾛｸﾞｵﾝをｾｯﾄ
                mudtAfkRet = AFKFrmRetType.LogOn

                '画面ｸﾛｰｽﾞ
                mblnClose = True
                Me.Close()

            Else
                txtPassCd.Text = ""
                txtPassCd.Focus()
            End If
        Else
            txtPassCd.Text = ""
            txtPassCd.Focus()
        End If

    End Sub
#End Region

End Class
