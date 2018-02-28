'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PDAﾛｸﾞｲﾝ画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMatePDA.clsComFuncPDA
#End Region

Public Class PDA_100001

#Region "  ｲﾍﾞﾝﾄ                                "
#Region "  ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PDA_100001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  ﾌｧﾝｸｼｮﾝｷｰ押下            KeyDown     "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ﾌｧﾝｸｼｮﾝｷｰ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PDA_100001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try

            Select Case e.KeyCode
                Case Windows.Forms.Keys.F1
                    cmdF1_Proc()
                Case Windows.Forms.Keys.F4
                    cmdF4_Proc()
            End Select

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ｺﾝﾄﾛｰﾙﾎﾞﾀﾝ押下                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF1.Click
        Try

            cmdF1_Proc()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub


    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF4.Click
        Try

            cmdF4_Proc()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ﾕｰｻﾞｰID変更           KeyDown        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾕｰｻﾞｰID変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtFLOGIN_ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFLOGIN_ID.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                txtFPASS_WORD.Focus()
            End If

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾊﾟｽﾜｰﾄﾞ入力              KeyDown     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ入力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtFPASS_WORD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPASS_WORD.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                cmdF4.Focus()
            End If
        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                         "
    Private Sub frmLoad()
        Try

            '**********************************************************
            ' ﾛｸﾞｵﾌﾌﾗｸﾞTrue
            '**********************************************************
            gblnLogoff = True           'ﾛｸﾞｵﾌ状態


            '**************************************************************************
            ' ｵﾗｸﾙ接続
            '**************************************************************************
            '==========================================
            'Config取得
            '==========================================
            Dim objSystem As clsConnectConfig
            objSystem = New clsConnectConfig(CONFIG_FILE)                ' Configﾌｧｲﾙ接続ｸﾗｽ（画面用Config）

            '==========================================
            'DB接続
            '==========================================
            Dim blnRet As Boolean
            gobjDb = New clsConn
            gobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            blnRet = gobjDb.Connect()     '接続
            If blnRet = False Then
                Throw New Exception("DB接続に失敗しました。")
            End If


            '**********************************************************
            'Config & ｼｽﾃﾑ変数  ﾃﾞｰﾀ取得
            '**********************************************************
            '画面ﾛｸﾞ用
            gcstrLOG_FILE_NAME = gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_005)                           'ﾌｧｲﾙ名
            gcstrLOG_FILE_NAME_OLD = gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_006)                       'ﾌｧｲﾙ名(古い)
            gcstrLOG_FILE_SIZE = gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_007)                           '最大ﾌｧｲﾙｻｲｽﾞ
            gcstrLOG_FILE_SIZE = TO_NUMBER(gcstrLOG_FILE_SIZE) * 1000000                    'Byte → MByte
            gcstrLOG_FILE_PATH = gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_031)                           'ﾌｧｲﾙ格納場所

            'ｿｹｯﾄ用
            gcstrSOCK_SEND_ADDRESS = gobjComFuncPDA.GET_CONFIG_INFO(GKEY_SOCK_SEND_ADDRESS)                '送信先ｱﾄﾞﾚｽ
            gcstrSOCK_SEND_PORT = gobjComFuncPDA.GET_CONFIG_INFO(GKEY_SOCK_SEND_PORT)                      '送信先ﾎﾟｰﾄNo
            gcstrSOCK_SEND_TIME_OUT = gobjComFuncPDA.GET_CONFIG_INFO(GKEY_SOCK_SEND_TIME_OUT)              '応答ｿｹｯﾄ待機時間

            'その他
            gcintDSPLOGIN_FLG = TO_NUMBER(gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_013))                 'ﾛｸﾞｲﾝ画面表示ﾌﾗｸﾞ        ﾌﾗｸﾞ
            gcintDSPLOGOFF = TO_NUMBER(gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SPS000000_003))                    'ﾛｸﾞｵﾌﾀｲﾑｱｳﾄ(sec)
            gcintOPE_FLG = TO_NUMBER(gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_015))
            gcintLOGIN_SVR_USE_FLG = TO_NUMBER(gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_019))            'ﾛｸﾞｲﾝ時ｻｰﾊﾞﾌﾟﾛｾｽ使用       ﾌﾗｸﾞ
            gcintAfkFlg = TO_NUMBER(gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SPS000000_004))                       '離席ﾎﾞﾀﾝ有効               ﾌﾗｸﾞ
            gcintAfkAutoFlg = TO_NUMBER(gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SPS000000_005))                   '自動離席処理有効           ﾌﾗｸﾞ
            gcstrDEGUB_FLG = gobjComFuncPDA.GET_CONFIG_INFO(GKEY_DEGUB_FLG)                                   'ﾃﾞﾊﾞｯｸﾞ                    ﾌﾗｸﾞ

            '*******************************************************
            ' 画面用ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ作成
            '*******************************************************
            gobjOwner = New GamenCommon.clsOwner                 ' 画面用ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ


            '*******************************************************
            ' 端末名取得
            '*******************************************************
            gcstrFTERM_ID = System.Environment.UserName     'ﾕｰｻﾞｰ名取得(ﾘﾓｰﾄ端末用)

            Dim udtRet As RetCode
            Dim TDSP_TERM As New TBL_TDSP_TERM(gobjOwner, gobjDb, Nothing)
            TDSP_TERM.FTERM_ID = gcstrFTERM_ID                          '端末ID     ｾｯﾄ
            udtRet = TDSP_TERM.GET_TDSP_TERM(False)                     '情報取得
            If udtRet = RetCode.NotFound Then
                Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_03, PopupFormType.Ok, PopupIconType.Err)
                Me.Close()
            End If
            If TDSP_TERM.FTERM_CUT_STS = FTERM_CUT_STS_SON Then
                Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_11, PopupFormType.Ok, PopupIconType.Err)
                Me.Close()
            End If
            gcintFTERM_KBN = TDSP_TERM.FTERM_KUBUN                      '端末区分   ｾｯﾄ


            '*******************************************************
            ' 自動ﾛｸﾞｲﾝ
            '*******************************************************
            If gcintDSPLOGIN_FLG = FLAG_OFF Then
                '(ﾛｸﾞｲﾝ画面不要の場合)
                Try
                    '==================================
                    ' ｺﾝﾄﾛｰﾙにﾃﾞｰﾀｾｯﾄ
                    '==================================
                    txtFLOGIN_ID.Text = gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_016)       'ﾕｰｻﾞｰID
                    txtFPASS_WORD.Text = gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_017)      'ﾊﾟｽﾜｰﾄﾞ
                    txtFLOGIN_ID.Select()
                    cmdF1.Select()
                    Call cmdF4_Proc()

                Catch ex As Exception
                Finally
                    Me.Close()
                    Me.Dispose()
                End Try
            End If


            '**********************************************************
            ' ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞﾁｪｯｸ
            '**********************************************************
            If TO_NUMBER(gcstrDEGUB_FLG) = FLAG_ON Then
                '=================================================
                'ﾃﾞﾊﾞｯｸﾞﾓｰﾄﾞ
                '=================================================
                'Me.Text = "ﾃﾞﾊﾞｯｸﾞﾓｰﾄﾞ"                     '上のﾊﾞｰを出す為
                Me.Text = "MaterialStream"                  '上のﾊﾞｰを出す為
                Me.ControlBox = True                        '最小化ﾎﾞﾀﾝ有効
                Me.MinimizeBox = True                       '最小化ﾎﾞﾀﾝ有効
                Me.MaximizeBox = True                       '最大化ﾎﾞﾀﾝ有効
                Me.WindowState = FormWindowState.Normal     '画面ｻｲｽﾞ
                Me.Size = New Size(480, 660)                '画面ｻｲｽﾞ
                Me.MaximumSize = New Size(480, 660)         '画面ｻｲｽﾞ
                Me.MinimumSize = New Size(480, 660)         '画面ｻｲｽﾞ
                'Me.ShowInTaskbar = True                     'ﾀｽｸﾊﾞｰ表示(これを有効にすると画面が落ちる)
                Me.Location = gobjLocation                  '画面位置


            Else
                '=================================================
                '操業ﾓｰﾄﾞ
                '=================================================
                '何もしない

            End If



        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region
#Region "  F1 (終了)           ﾎﾞﾀﾝ押下処理     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1 (終了) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF1_Proc()
        Try

            Dim udeRet As RetPopup

            '*******************************************************
            '確認ﾒｯｾｰｼﾞ
            '*******************************************************
            udeRet = gobjComFuncPDA.DisplayPopup(FRM_MSG_SHUTDOWN, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            If udeRet <> RetPopup.OK Then
                Exit Sub
            End If


            '*******************************************************
            'ｼｬｯﾄﾀﾞｳﾝor画面ｸﾛｰｽﾞ処理
            '*******************************************************
            Dim intShutDownFlg As Integer
            Try
                intShutDownFlg = TO_INTEGER(gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SPS000000_001))
            Catch ex As Exception
                '(ｼｽﾃﾑ変数取得でｴﾗｰが出た場合)
                gobjComFuncPDA.ComError_frm(ex)
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
                If IsNull(gobjPDA_100001) = False Then
                    gobjPDA_100001.Close()
                    gobjPDA_100001.Dispose()
                    gobjPDA_100001 = Nothing
                End If
                Me.Close()
                Me.Dispose()

            End If

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  F4 (ﾛｸﾞｲﾝ)          ﾎﾞﾀﾝ押下処理     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4 (ﾛｸﾞｲﾝ) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF4_Proc()
        Try

            '**********************************************************
            ' ﾕｰｻﾞｰID入力ﾁｪｯｸ
            '**********************************************************
            If txtFLOGIN_ID.Text = "" Then
                '(ﾊﾟｽﾜｰﾄﾞがﾌﾞﾗﾝｸのとき)
                Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_10, _
                                PopupFormType.Ok, _
                                PopupIconType.Err)
                Exit Sub
            End If


            '**********************************************************
            ' ﾛｸﾞｲﾝ処理
            '**********************************************************
            Select Case gcintLOGIN_SVR_USE_FLG      'ﾛｸﾞｲﾝ時ｻｰﾊﾞﾌﾟﾛｾｽ使用ﾌﾗｸﾞ
                Case FLAG_ON
                    '(ｻｰﾊﾞﾌﾟﾛｾｽを使用してﾛｸﾞｲﾝする場合)

                    '********************************************************************
                    'ｿｹｯﾄ送信処理(ﾊﾟｽﾜｰﾄﾞ登録処理)
                    '********************************************************************
                    Call SendSocket01()

                Case FLAG_OFF
                    '(ｻｰﾊﾞﾌﾟﾛｾｽを使用しないでﾛｸﾞｲﾝする場合)
                    Call LogInProcess()    'ﾛｸﾞｲﾝ処理へ

            End Select


        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞｲﾝ処理                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞｲﾝ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LogInProcess()

        Try
            Dim intRet As RetCode       '戻値用


            '*******************************************************
            'ﾕｰｻﾞｰID取得
            '*******************************************************
            Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
            objTMST_USER.FUSER_ID = txtFLOGIN_ID.Text         'ﾛｸﾞｲﾝID
            objTMST_USER.GET_TMST_USER(False)                 '情報取得
            If intRet <> RetCode.OK Then
                Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_02, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If

            '==================================
            ' ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '==================================
            If txtFPASS_WORD.Text <> objTMST_USER.FPASS_WORD Then
                Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_01, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                txtFPASS_WORD.Focus()
                Exit Sub
            End If

            '==================================
            ' ﾕｰｻﾞ認証状況ﾁｪｯｸ
            '==================================
            If objTMST_USER.FUSER_ATEST <> FUSER_ATEST_SNORMAL Then
                Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_05, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If

            '==================================
            ' ﾕｰｻﾞｰ情報取得
            '================================== 
            gcstrFUSER_ID = objTMST_USER.FUSER_ID           'ﾕｰｻﾞｰID
            gcstrFUSER_NAME = objTMST_USER.FUSER_NAME       'ﾕｰｻﾞｰ名

            '=======================================
            'ﾕｰｻﾞｰ操作ﾏｽﾀの特定
            '=======================================
            Dim strSQL As String
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    * "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TMST_USER_DSP "
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "         FUSER_ID = '" & gcstrFUSER_ID & "'"
            Dim objTMST_USER_DSP As New TBL_TMST_USER_DSP(gobjOwner, gobjDb, Nothing)   'ﾕｰｻﾞｰ操作ﾏｽﾀ
            objTMST_USER_DSP.USER_SQL = strSQL                      'SQL文
            intRet = objTMST_USER_DSP.GET_TMST_USER_DSP_USER()      '取得
            If intRet <> RetCode.OK Then
                Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_04, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If
            For ii As Integer = LBound(objTMST_USER_DSP.ARYME) To UBound(objTMST_USER_DSP.ARYME)
                '(ﾙｰﾌﾟ:取得した権限の数)
                ReDim Preserve gcintFUSER_LEVEL(ii)
                gcintFUSER_LEVEL(ii) = objTMST_USER_DSP.ARYME(ii).FUSER_DSP_LEVEL       'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
            Next


            '**********************************************************
            ' 画面ID取得
            '**********************************************************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(gobjOwner, gobjDb, Nothing)
            objTDSP_TERM.FTERM_ID = gcstrFTERM_ID       '端末ID     ｾｯﾄ
            objTDSP_TERM.GET_TDSP_TERM(False)           '情報取得

            '↓↓↓↓↓↓ 2012.10.01 H.Morita KAGOME
            '=======================================
            'ﾕｰｻﾞｰ別許可ﾏｽﾀの特定
            '=======================================
            Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)   'ﾕｰｻﾞｰ別許可ﾏｽﾀ
            objTDSP_PMT_USER.FUSER_DSP_LEVEL = gcintFUSER_LEVEL(0)                      'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
            objTDSP_PMT_USER.FDISP_ID = objTDSP_TERM.FDISP_ID                           '画面ID
            objTDSP_PMT_USER.FCTRL_ID = FCTRL_ID_SKOTEI                                 'ｺﾝﾄﾛｰﾙID
            intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)                          '取得
            If intRet <> RetCode.OK Then
                '(取得できなかったとき)
                Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_04, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If

            If objTDSP_PMT_USER.FOPE_FLAG = FOPE_FLAG_SOFF Then
                '(画面展開不可のとき)
                Call gobjComFuncPDA.DisplayPopup(FRM_MSG_FRM100001_04, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If
            '↑↑↑↑↑↑ 2012.10.01 H.Morita KAGOME


            '**********************************************************
            ' 画面起動
            '**********************************************************
            Dim strPara As String = objTDSP_TERM.FDISP_ID
            Call gobjComFuncPDA.FormMoveSelect(strPara, Me)

            '**********************************************************
            ' ﾛｸﾞｵﾌﾌﾗｸﾞFalse
            '**********************************************************
            gblnLogoff = False          'ﾛｸﾞｵﾝ状態


            Me.Close()
            Me.Dispose()


        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信01                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信01
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()
        Dim intRet As RetCode           '戻値用


        '*******************************************************
        'ﾕｰｻﾞｰID取得
        '*******************************************************
        Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
        objTMST_USER.FUSER_ID = txtFLOGIN_ID.Text             'ﾛｸﾞｲﾝID
        intRet = objTMST_USER.GET_TMST_USER(False)            '情報取得
        If intRet = RetCode.OK Then
            gcstrFUSER_ID = objTMST_USER.FUSER_ID           'ﾕｰｻﾞｰID
        Else
            gcstrFUSER_ID = ""                              'ﾕｰｻﾞｰID
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim strRET_STATE As String = ""                 '応答ｽﾃｰﾀｽ
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        udtSckSendRET = gobjComFuncPDA.SendSockLogin(txtFLOGIN_ID.Text _
                                    , txtFPASS_WORD.Text _
                                    , strRET_STATE _
                                    , FSYORI_ID_S200002 _
                                    )
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

                Call LogInProcess()    'ﾛｸﾞｲﾝ処理へ

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
#Region "  ｼｬｯﾄﾀﾞｳﾝ         処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｬｯﾄﾀﾞｳﾝ処理
    ''' </summary>
    ''' <returns>正常：True     異常：False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function PubF_ShutDown() As Boolean
        Dim flags As PDA_logoff.ShutdownFlag

        PubF_ShutDown = False

        Try

            flags = PDA_logoff.ShutdownFlag.LogOff

            '' EWX_FORCEIFHUNG
            ''ハングアップしたプログラムも終了
            'flags = flags Or _
            '            Shutdown.ShutdownFlag.ForceIfHung

            ' ﾛｸﾞｵﾌを実行
            PDA_logoff.ExitWindows(flags)

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

End Class
