'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾊﾟｽﾜｰﾄﾞ確認画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports      "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100007

#Region "  共通変数　                               "

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mudtFormRet As RetPopup         'ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ    戻値

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' =======================================
    ''' <summary>ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ戻値</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property userRet() As RetPopup
        Get
            Return mudtFormRet
        End Get
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_100006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "　変更ﾎﾞﾀﾝ押下                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 変更ﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙﾎﾞﾀﾝ押下                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙﾎﾞﾀﾝ押下 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ﾊﾟｽﾜｰﾄﾞ KeyDownｲﾍﾞﾝﾄ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ KeyDownｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtFPASS_WORD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPASS_WORD.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                cmdZikkou.Focus()
            End If

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmLoad()


        '*******************************************************
        ' ﾕｰｻﾞｰﾏｽﾀ取得
        '*******************************************************
        Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
        objTMST_USER.FUSER_ID = gcstrFUSER_ID
        objTMST_USER.GET_TMST_USER(False)


        '*******************************************************
        ' 初期設定
        '*******************************************************
        txtFLOGIN_ID.Enabled = False
        txtFLOGIN_ID.Text = objTMST_USER.FUSER_ID           'ﾕｰｻﾞｺｰﾄﾞ
        lblFUSER_NAME.Text = objTMST_USER.FUSER_NAME        'ﾕｰｻﾞ名


    End Sub
#End Region
#Region "  確認         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 確認 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck() = False Then

            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信
        '********************************************************************
        Call SendSock01()


    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        mudtFormRet = RetPopup.Cancel
        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <returns>入力ﾁｪｯｸ判別</returns>
    ''' <remarks>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case ""
            Case Else

                If txtFPASS_WORD.Text = "" Then
                    '(ﾊﾟｽﾜｰﾄﾞがﾌﾞﾗﾝｸのとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
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
#Region "  ｿｹｯﾄ送信                                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub SendSock01()


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim strRET_STATE As String = ""                 '応答ｽﾃｰﾀｽ
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        udtSckSendRET = gobjComFuncFRM.SendSockLogin(txtFLOGIN_ID.Text _
                                     , txtFPASS_WORD.Text _
                                     , strRET_STATE _
                                     )
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                mudtFormRet = RetPopup.OK

                Me.Close()
                '' ''Me.Dispose()

            Else
                '(処理が異常終了した場合)
                txtFPASS_WORD.Text = ""
                txtFPASS_WORD.Focus()
            End If
        ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
            '(ﾀｲﾑｱｳﾄの場合)
        Else
            '(その他の場合)
            txtFPASS_WORD.Text = ""
            txtFPASS_WORD.Focus()
        End If


    End Sub
#End Region

End Class
