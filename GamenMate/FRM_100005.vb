'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】離席ﾛｸﾞｲﾝ設定画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports      "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100005

#Region "　共通変数                         "

    'ﾌﾟﾛﾊﾟﾃｨ用
    Private mudtAfkRet As AFKFrmRetType             'ﾛｸﾞｵﾝ/ﾛｸﾞｵﾌ

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        OK_Click                'OKﾎﾞﾀﾝｸﾘｯｸ
        PASS_CHANGE_Click       'ﾊﾟｽﾜｰﾄﾞ変更ﾎﾞﾀﾝｸﾘｯｸ
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
    Private Sub FRM_100005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
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
            gobjComFuncFRM.ComError_frm(ex)

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
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　変更ﾎﾞﾀﾝ押下                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 変更ﾎﾞﾀﾝ押下 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPassChng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPassChng.Click
        Try

            cmdPassChng_Proc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾊﾟｽﾜｰﾄﾞ入力              KeyDown "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ入力 KeyDown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtPassCd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPASS_WORD.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                cmdLogin.Focus()
            End If

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

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
    Private Sub FRM_100005_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
            gobjComFuncFRM.ComError_frm(ex)

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
        intRet = objTMST_USER.GET_TMST_USER(True)           '取得


        '*******************************************************
        ' 初期設定
        '*******************************************************
        txtFLOGIN_ID.Enabled = False
        txtFLOGIN_ID.Text = objTMST_USER.FUSER_ID       'ユーザコード
        lblEmpName.Text = gcstrFUSER_NAME               'ユーザ名
        mblnClose = False                               'ｸﾛｰｽﾞ許可ﾌﾗｸﾞ

        cmdPassChng.Enabled = False
        cmdPassChng.Visible = False



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
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_SHUTDOWN, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200006           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        Call gobjComFuncFRM.SockSendServer01(objTelegram)                                  'ｿｹｯﾄ送信


        'ﾛｸﾞｵﾌをｾｯﾄ
        mudtAfkRet = AFKFrmRetType.LogOff

        '画面ｸﾛｰｽﾞ
        mblnClose = True
        Me.Close()

    End Sub
#End Region
#Region "　変更             ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 変更 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPassChng_Proc()

        Try

            '****************************************************
            '入力ﾁｪｯｸ
            '****************************************************
            If InputCheck(menmCheckCase.PASS_CHANGE_Click) = False Then
                Exit Try
            End If


            '****************************************************
            'ﾊﾟｽﾜｰﾄﾞ変更画面表示
            '****************************************************
            gobjFRM_100006 = Nothing
            gobjFRM_100006 = New FRM_100006     'ﾊﾟｽﾜｰﾄﾞ変更画面

            Call SetProperty()                                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ


            '****************************************************
            '変更/ｷｬﾝｾﾙﾁｪｯｸ
            '****************************************************
            Dim intRtn As DialogResult

            gobjFRM_100006.ShowDialog()

            If intRtn = System.Windows.Forms.DialogResult.Cancel = True Then
                '(ｷｬﾝｾﾙ時)
                Exit Sub
            End If

            txtFPASS_WORD.Text = ""

        Catch ex As Exception
            gobjFRM_100006.Dispose()
            gobjFRM_100006 = Nothing
            Throw ex

        End Try

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

        Dim intRet As Integer       '戻値用
        Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)

        Select Case udtCheck_Case
            Case menmCheckCase.OK_Click
                '(OKﾎﾞﾀﾝｸﾘｯｸ時)

                If txtFPASS_WORD.Text = "" Then
                    '(ﾊﾟｽﾜｰﾄﾞがﾌﾞﾗﾝｸのとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    Exit Function
                End If

                blnCheckErr = False

            Case menmCheckCase.PASS_CHANGE_Click
                '(ﾊﾟｽﾜｰﾄﾞ変更ﾎﾞﾀﾝｸﾘｯｸ時)

                '**********************************************************
                ' ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
                ' ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ取得
                '   【ﾕｰｻﾞｰﾏｽﾀ】
                '**********************************************************
                '==================================
                ' ﾊﾟｽﾜｰﾄﾞｹﾞｯﾄ
                '==================================
                Dim objTMST_USER_CHANGE As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
                objTMST_USER_CHANGE.FUSER_ID = txtFLOGIN_ID.Text            'ﾕｰｻﾞID
                intRet = objTMST_USER_CHANGE.GET_TMST_USER_FLOGIN_ID()      '情報取得
                If intRet = RetCode.OK Then
                    '==================================
                    ' ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
                    '==================================
                    If txtFPASS_WORD.Text <> objTMST_USER_CHANGE.FPASS_WORD Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_01, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Err)
                        Exit Select
                    End If
                    '==================================
                    ' ﾛｯｸ日時ﾁｪｯｸ
                    '==================================
                    If IsNull(objTMST_USER_CHANGE.FLOCK_DT) = False Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_05, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Err)
                        Exit Select
                    End If
                Else
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Err)
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
#Region "  ﾊﾟｽﾜｰﾄﾞ変更画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ変更画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()

        gobjFRM_100006.userFUSER_ID = TO_STRING(txtFLOGIN_ID.Text)                   'ﾕｰｻﾞｰID
        gobjFRM_100006.userFUSER_NAME = TO_STRING(lblEmpName.Text)               'ﾕｰｻﾞｰ名

    End Sub

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

        strDSPLOGIN_ID = TO_STRING(txtFLOGIN_ID.Text)       'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        strPASSWORD = TO_STRING(txtFPASS_WORD.Text)         'ﾊﾟｽﾜｰﾄﾞ

        objTelegram.SETIN_DATA("DSPLOGIN_ID", strDSPLOGIN_ID)       'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        objTelegram.SETIN_DATA("DSPPASS_WORD", strPASSWORD)         'ﾊﾟｽﾜｰﾄﾞ


        Dim strRET_STATE As String = ""                 '応答ｽﾃｰﾀｽ
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値

        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE)   'ｿｹｯﾄ送信
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
                txtFPASS_WORD.Text = ""
                txtFPASS_WORD.Focus()
            End If
        Else
            txtFPASS_WORD.Text = ""
            txtFPASS_WORD.Focus()
        End If

    End Sub
#End Region

End Class