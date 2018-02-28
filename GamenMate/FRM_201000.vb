'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾒｲﾝﾒﾆｭｰ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_201000

#Region "　共通変数　                           "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

#End Region
#Region "  ｲﾍﾞﾝﾄ　                              "
#Region "  ｼｬｯﾄﾀﾞｳﾝ  ﾎﾞﾀﾝ押下 ｲﾍﾞﾝﾄ             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｬｯﾄﾀﾞｳﾝ  ﾎﾞﾀﾝ押下 ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call cmdClose_ClickProccess()

    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾎﾞﾀﾝ名取得
        '**********************************************************
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      'ｼｽﾃﾑﾓﾆﾀ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      'ﾒﾝﾃﾅﾝｽﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '入出庫業務ﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      'ｼｽﾃﾑﾒﾝﾃﾅﾝｽﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      '問合せﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd06)      'ﾊﾞｯｸｱｯﾌﾟﾒﾆｭｰ


        '**********************************************************
        ' 開発者用ﾎﾞﾀﾝ設定
        '**********************************************************
        If TO_NUMBER(gcstrDEGUB_FLG) = 9 Then
            cmdDevelopment.Visible = True
        Else
            cmdDevelopment.Visible = False
        End If

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ｼｽﾃﾑﾓﾆﾀｸﾘｯｸ                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｽﾃﾑﾓﾆﾀｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_202000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾒﾝﾃﾅﾝｽﾒﾆｭｰｸﾘｯｸ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽﾒﾆｭｰｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　入出庫業務ﾒﾆｭｰｸﾘｯｸ                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入出庫業務ﾒﾆｭｰｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_203000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ｼｽﾃﾑﾒﾝﾃﾅﾝｽﾒﾆｭｰｸﾘｯｸ                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｽﾃﾑﾒﾝﾃﾅﾝｽﾒﾆｭｰｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207000, Me)
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　問合せﾒﾆｭｰｸﾘｯｸ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 問合せﾒﾆｭｰｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾊﾞｯｸｱｯﾌﾟﾒﾆｭｰｸﾘｯｸ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｯｸｱｯﾌﾟﾒﾆｭｰｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*ｶｺﾞﾒﾅｼ* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ｼｬｯﾄﾀﾞｳﾝ  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｬｯﾄﾀﾞｳﾝ  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProccess()

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
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200004           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        Call gobjComFuncFRM.SockSendServer01(objTelegram)                                  'ｿｹｯﾄ送信

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/06/13 ｼｬｯﾄﾀﾞｳﾝ処理追加

        ''*******************************************************
        ''ｼｬｯﾄﾀﾞｳﾝor画面ｸﾛｰｽﾞ処理
        ''*******************************************************
        'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_100001, Me)

        '*******************************************************
        'ｼｬｯﾄﾀﾞｳﾝor画面ｸﾛｰｽﾞ処理
        '*******************************************************
        Dim intShutDownFlg As Integer
        Try
            intShutDownFlg = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS200000_001))
        Catch ex As Exception
            '(ｼｽﾃﾑ変数取得でｴﾗｰが出た場合)
            gobjComFuncFRM.ComError_frm(ex)
            intShutDownFlg = FLAG_OFF
        End Try

        If intShutDownFlg = FLAG_ON Then
            '(ｼｬｯﾄﾀﾞｳﾝﾌﾗｸﾞがONの場合)

            '----------------------------------------
            ' ｼｬｯﾄﾀﾞｳﾝ
            '----------------------------------------
            Call PubF_ShutDown()            ' ｼｬｯﾄﾀﾞｳﾝ

        Else
            '(ｼｬｯﾄﾀﾞｳﾝﾌﾗｸﾞがON以外の場合)

            '----------------------------------------
            ' 画面ｸﾛｰｽﾞ
            '----------------------------------------
            If IsNull(gobjFRM_201000) = False Then
                gobjFRM_201000.Close()
                gobjFRM_201000.Dispose()
                gobjFRM_201000 = Nothing
            End If
            Me.Close()
            Me.Dispose()

        End If
        '↑↑↑↑↑↑************************************************************************************************************

    End Sub
#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:A.Noto 2012/06/13 ｼｬｯﾄﾀﾞｳﾝ処理追加
#Region "  ｼｬｯﾄﾀﾞｳﾝ         処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｬｯﾄﾀﾞｳﾝ処理
    ''' </summary>
    ''' <returns>正常：True     異常：False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function PubF_ShutDown() As Boolean
        Dim flags As Shutdown.ShutdownFlag

        PubF_ShutDown = False

        Try

            flags = Shutdown.ShutdownFlag.Shutdown

            ' EWX_FORCEIFHUNG
            'ハングアップしたプログラムも終了
            flags = flags Or _
                        Shutdown.ShutdownFlag.ForceIfHung

            ' シャットダウンを実行
            Shutdown.ExitWindows(flags)

            PubF_ShutDown = True

        Catch ex As Exception
            Throw ex
        Finally
            If IsNull(flags) = False Then
                flags = Nothing
            End If
            If IsNull(flags) = False Then
                flags = Nothing
            End If
        End Try
    End Function
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

#Region "　開発者ﾂｰﾙｸﾘｯｸ                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 開発者ﾂｰﾙｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDevelopment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim objFRM_299000 As FRM_299000
            objFRM_299000 = New FRM_299000
            objFRM_299000.Show()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

End Class
