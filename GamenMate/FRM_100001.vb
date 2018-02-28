'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾛｸﾞｲﾝ画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports      "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100001

#Region "  共通変数         "
    Private mobjThread As System.Threading.Thread
#End Region
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
    Private Sub frmCR2001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
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
    Private Sub frmCR2001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try

            Select Case e.KeyCode
                Case Windows.Forms.Keys.F1
                    cmdF1_Proc()
                Case Windows.Forms.Keys.F8
                    cmdF8_Proc()
            End Select

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

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
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub


    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF8.Click
        Try

            cmdF8_Proc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ﾕｰｻﾞｰID変更           Validated   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾕｰｻﾞｰID変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtFLOGIN_ID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFLOGIN_ID.Validated
        Try

            Call Change_EmpCd()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ﾕｰｻﾞｰID変更           KeyDown     "
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
            gobjComFuncFRM.ComError_frm(ex)

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
                If txtReFPASS_WORD.Enabled = False Then
                    cmdF1.Focus()
                Else
                    txtReFPASS_WORD.Focus()
                End If
            End If
        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ﾊﾟｽﾜｰﾄﾞ再入力            KeyDown     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ再入力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtReFPASS_WORD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReFPASS_WORD.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                cmdF1.Focus()
            End If
        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  変更ﾎﾞﾀﾝ押下処理                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 変更ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPassChng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPassChng.Click
        Try

            Call Change_Pass()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

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
            'ﾀｲﾏｰ用
            gcinttmrTime_Interval = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_002))             '時刻表示                 ﾀｲﾏｰ
            gcinttmrBlink_Interval = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_003))            'ﾎﾞﾀﾝ点滅用               ﾀｲﾏｰ
            gcinttmrOpeMsg_Interval = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_004))           'ｵﾍﾟﾚｰｼｮﾝﾒｯｾｰｼﾞ取得       ﾀｲﾏｰ
            gcinttmrTest_1_Interval = TO_NUMBER(gobjComFuncFRM.GET_CONFIG_INFO(GKEY_tmrTest_1_Interval))   '画面遷移ﾃｽﾄ用            ﾀｲﾏｰ

            '画面ﾛｸﾞ用
            gcstrLOG_FILE_NAME = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_005)                           'ﾌｧｲﾙ名
            gcstrLOG_FILE_NAME_OLD = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_006)                       'ﾌｧｲﾙ名(古い)
            gcstrLOG_FILE_SIZE = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_007)                           '最大ﾌｧｲﾙｻｲｽﾞ
            gcstrLOG_FILE_SIZE = TO_NUMBER(gcstrLOG_FILE_SIZE) * 1000000                                    'Byte → MByte
            gcstrLOG_FILE_PATH = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_031)                           'ﾌｧｲﾙ格納場所

            'ｿｹｯﾄ用
            gcstrSOCK_SEND_ADDRESS = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_SOCK_SEND_ADDRESS)                '送信先ｱﾄﾞﾚｽ
            gcstrSOCK_SEND_PORT = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_SOCK_SEND_PORT)                      '送信先ﾎﾟｰﾄNo
            gcstrSOCK_SEND_TIME_OUT = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_SOCK_SEND_TIME_OUT)              '応答ｿｹｯﾄ待機時間

            'その他
            gcintDisp_INTMSG_LEVEL = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_010))            '表示するﾒｯｾｰｼﾞﾚﾍﾞﾙ
            gcstrTMRTEST_1 = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_TMRTEST_1_FLG)                            '画面遷移ﾃｽﾄ用            ﾀｲﾏｰﾌﾗｸﾞ
            gcstrPRINT_FLG = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_PRINT_FLG)                                '印字                     ﾌﾗｸﾞ
            gcstrDEGUB_FLG = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_DEGUB_FLG)                                'ﾃﾞﾊﾞｯｸﾞ                  ﾌﾗｸﾞ
            gcintDSPLOGIN_FLG = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_013))                 'ﾛｸﾞｲﾝ画面表示ﾌﾗｸﾞ        ﾌﾗｸﾞ
            gcintDSPLOGOFF = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_014))                    'ﾛｸﾞｵﾌﾀｲﾑｱｳﾄ(sec)
            gcintOPE_FLG = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_015))
            gcintLOGIN_SVR_USE_FLG = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_019))            'ﾛｸﾞｲﾝ時ｻｰﾊﾞﾌﾟﾛｾｽ使用       ﾌﾗｸﾞ
            gcintAfkFlg = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_024))                       '離席処理有効               ﾌﾗｸﾞ
            gcintPASSWORD_KETA = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_025))                'ﾊﾟｽﾜｰﾄﾞ最小桁数
            gcintPASSWORD_ENG = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_026))                 'ﾊﾟｽﾜｰﾄﾞ英字ﾁｪｯｸﾌﾗｸﾞ
            gcintPASSWORD_NUM = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_027))                 'ﾊﾟｽﾜｰﾄﾞ数値ﾁｪｯｸﾌﾗｸﾞ
            gcintPASSWORD_KIGO = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_028))                'ﾊﾟｽﾜｰﾄﾞ記号ﾁｪｯｸﾌﾗｸﾞ
            gcintPASSWORD_DAISHO = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_029))              'ﾊﾟｽﾜｰﾄﾞ大文字小文字ﾁｪｯｸﾌﾗｸﾞ


            '*******************************************************
            ' 端末名取得
            '*******************************************************
            Dim udtRet As RetCode

            If gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_023) = 0 Then
                gcstrFTERM_ID = System.Net.Dns.GetHostName      'ｺﾝﾋﾟｭｰﾀ名取得
            Else
                gcstrFTERM_ID = System.Environment.UserName     'ﾕｰｻﾞｰ名取得(ﾘﾓｰﾄ端末用)
            End If

            Dim TDSP_TERM As New TBL_TDSP_TERM(gobjOwner, gobjDb, Nothing)
            TDSP_TERM.FTERM_ID = gcstrFTERM_ID                          '端末ID     ｾｯﾄ
            udtRet = TDSP_TERM.GET_TDSP_TERM(False)                     '情報取得
            If udtRet = RetCode.NotFound Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_03, PopupFormType.Ok, PopupIconType.Err)
                Me.Close()
            End If
            If TDSP_TERM.FTERM_CUT_STS = FTERM_CUT_STS_SON Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_11, PopupFormType.Ok, PopupIconType.Err)
                Me.Close()
            End If
            gcintFTERM_KBN = TO_INTEGER(TDSP_TERM.FTERM_KUBUN)                      '端末区分   ｾｯﾄ
            gcstrFTERM_NAME = TDSP_TERM.FTERM_NAME                      '端末名称   ｾｯﾄ


            '*******************************************************
            ' 起動ﾛｸﾞ書込み
            '*******************************************************
            gobjComFuncFRM.AddToLog_frm(Application.ExecutablePath & "  起動")


            '*******************************************************
            ' 画面用ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ作成
            '*******************************************************
            gobjOwner = New GamenCommon.clsOwner                 ' 画面用ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ


            '*******************************************************
            ' 起動日付取得
            '*******************************************************
            gcdtmStart = Now


            '*******************************************************
            ' 色々初期化
            '*******************************************************
            gobjGridDataTable05 = New GamenCommon.clsGridDataTable05    'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ
            gobjLocation = New Point(0, 0)                  '画面位置


            '*******************************************************
            ' 画面設備状態表示ﾏｽﾀ　の色設定
            '*******************************************************
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2012/07/03 色変更

            'gcLabelColor_Blue = Color.Blue                           ' DSP_EQ_STS の INTCOLOR = 0 の時の色（青）
            'gcLabelColor_Red = Color.LawnGreen                       ' DSP_EQ_STS の INTCOLOR = 1 の時の色（赤）
            'gcLabelColor_Yellow = Color.Yellow                       ' DSP_EQ_STS の INTCOLOR = 2 の時の色（黄）
            'gcLabelColor_Purple = Color.Purple                       ' DSP_EQ_STS の INTCOLOR = 3 の時の色（紫）
            'gcLabelColor_White = Color.White                         ' DSP_EQ_STS の INTCOLOR = 4 の時の色（白）
            'gcLabelColor_Green = Color.Green                         ' DSP_EQ_STS の INTCOLOR = 5 の時の色（緑）
            'gcLabelColor_LightGreen = Color.Salmon                ' DSP_EQ_STS の INTCOLOR = 6 の時の色（薄緑）
            'gcLabelColor_Orange = Color.DarkOrange                   ' DSP_EQ_STS の INTCOLOR = 7 の時の色（橙）
            'gcLabelColor_Black = Color.Gray                          ' ｴﾗｰ時の色（黒）

            gcLabelColor_Blue = Color.Blue                           ' DSP_EQ_STS の INTCOLOR = 0 の時の色（青）
            gcLabelColor_Red = Color.Red                             ' DSP_EQ_STS の INTCOLOR = 1 の時の色（赤）
            gcLabelColor_Yellow = Color.Yellow                       ' DSP_EQ_STS の INTCOLOR = 2 の時の色（黄）
            gcLabelColor_Purple = Color.Purple                       ' DSP_EQ_STS の INTCOLOR = 3 の時の色（紫）
            gcLabelColor_White = Color.White                         ' DSP_EQ_STS の INTCOLOR = 4 の時の色（白）
            gcLabelColor_Green = Color.Green                         ' DSP_EQ_STS の INTCOLOR = 5 の時の色（緑）
            gcLabelColor_LightGreen = Color.LawnGreen                ' DSP_EQ_STS の INTCOLOR = 6 の時の色（薄緑）
            gcLabelColor_Orange = Color.DarkOrange                   ' DSP_EQ_STS の INTCOLOR = 7 の時の色（橙）
            gcLabelColor_Black = Color.Gray                          ' ｴﾗｰ時の色（黒）
            '↑↑↑↑↑↑************************************************************************************************************

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2012/07/03 入出庫ﾓｰﾄﾞの色設定
            '*******************************************************
            ' 入出庫ﾓｰﾄﾞの色設定
            '*******************************************************
            gcModeColor_IN = Color.LightGreen               ' (緑　)入庫ﾓｰﾄﾞ
            'gcModeColor_OUT = Color.LightPink               ' (桃　)出庫ﾓｰﾄﾞ
            gcModeColor_OUT = Color.Blue                    ' (青　)出庫ﾓｰﾄﾞ
            gcModeColor_Black = Color.LightGray             ' (黒　)

            gcModeColor_CUS_IN = Color.LightGreen           ' (緑　)ｶｽﾀﾑ色 入庫ﾓｰﾄﾞ
            gcModeColor_CUS_OUT = Color.LightBlue           ' (青　)ｶｽﾀﾑ色 出庫ﾓｰﾄﾞ
            gcModeColor_CUS_FUITHI = Color.Red              ' (赤　)ｶｽﾀﾑ色 ﾓｰﾄﾞ不一致
            '↑↑↑↑↑↑************************************************************************************************************

            '*******************************************************
            ' ﾊﾟｽﾜｰﾄﾞ再入力ﾃｷｽﾄﾎﾞｯｸｽEnabled
            '*******************************************************
            txtReFPASS_WORD.Enabled = False

            Call gobjComFuncFRM.AddToLog_frm("LoadCRｽﾚｯﾄﾞ開始。")
            mobjThread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf LoadCR))
            mobjThread.IsBackground = True      'ﾊﾞｯｸｸﾞﾗｳﾝﾄﾞ･ｽﾚｯﾄﾞとする
            mobjThread.Start()                  'ｽﾚｯﾄﾞ開始


            '*******************************************************
            ' 自動ﾛｸﾞｲﾝ
            '*******************************************************
            If gcintDSPLOGIN_FLG = FLAG_OFF Then
                '(ﾛｸﾞｲﾝ画面不要の場合)

                Try
                    '==================================
                    ' ｺﾝﾄﾛｰﾙにﾃﾞｰﾀｾｯﾄ
                    '==================================
                    txtFLOGIN_ID.Text = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_016)         'ﾕｰｻﾞｰID
                    lblFUSER_NAME.Text = ""                                                     'ﾕｰｻﾞｰ名
                    txtFPASS_WORD.Text = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_017)        'ﾊﾟｽﾜｰﾄﾞ
                    txtFLOGIN_ID.Select()
                    cmdF1.Select()
                    Call cmdF1_Proc()

                Catch ex As Exception
                Finally
                    Me.Close()
                    Me.Dispose()
                End Try

            End If


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region
#Region "  F1 (OK)          ﾎﾞﾀﾝ押下処理        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1 (OK) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF1_Proc()
        Try

            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(gobjOwner, gobjDb, Nothing)     'ｼｽﾃﾑ変数

            '**********************************************************
            ' ﾕｰｻﾞｰID入力ﾁｪｯｸ
            '**********************************************************
            If txtFLOGIN_ID.Text = "" Then
                '(ﾊﾟｽﾜｰﾄﾞがﾌﾞﾗﾝｸのとき)
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_10, _
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

                    '**********************************************************
                    ' 新規ﾕｰｻﾞﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
                    '**********************************************************
                    If txtReFPASS_WORD.Enabled = True Then
                        '(新規ﾕｰｻﾞのとき)
                        If txtFPASS_WORD.Text <> txtReFPASS_WORD.Text Then
                            '(ﾊﾟｽﾜｰﾄﾞとﾊﾟｽﾜｰﾄﾞ再入力の入力値が異なるとき)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_06, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Err)
                            txtFPASS_WORD.Focus()
                            Exit Sub
                        End If

                        If txtFPASS_WORD.Text = "" Then
                            '(ﾊﾟｽﾜｰﾄﾞがﾌﾞﾗﾝｸのとき)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Err)
                            txtFPASS_WORD.Focus()
                            Exit Sub
                        End If

                        If txtReFPASS_WORD.Text = "" Then
                            '(ﾊﾟｽﾜｰﾄﾞ再入力がﾌﾞﾗﾝｸのとき)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Err)
                            Exit Sub
                            txtReFPASS_WORD.Focus()
                        End If

                        If txtReFPASS_WORD.Text = txtFLOGIN_ID.Text _
                       And objTPRG_SYS_HEN.SS000000_014 = FLAG_ON _
                       Then
                            '(ﾊﾟｽﾜｰﾄﾞとﾕｰｻﾞIDが同じとき)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_16, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Err)
                            txtFPASS_WORD.Focus()
                            Exit Sub
                        End If

                        If gcintPASSWORD_KETA > 0 Then
                            '(ﾊﾟｽﾜｰﾄﾞ最小桁数が0より大きいとき)
                            If (txtFPASS_WORD.Text).Length < gcintPASSWORD_KETA Then
                                '(ﾊﾟｽﾜｰﾄﾞが6文字より小さいとき)
                                Call gobjComFuncFRM.DisplayPopup(String.Format(FRM_MSG_FRM100001_12, gcintPASSWORD_KETA), _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                        If gcintPASSWORD_ENG = FLAG_ON Then
                            '(ﾊﾟｽﾜｰﾄﾞ英字ﾁｪｯｸﾌﾗｸﾞがONのとき)
                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[A-Za-z]") = False Then
                                '(ﾊﾟｽﾜｰﾄﾞに英字が含まれていないとき)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_13, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                        If gcintPASSWORD_NUM = FLAG_ON Then
                            '(ﾊﾟｽﾜｰﾄﾞ数字ﾁｪｯｸﾌﾗｸﾞがONのとき)
                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[0-9]") = False Then
                                '(ﾊﾟｽﾜｰﾄﾞに数字が含まれていないとき)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_14, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                        If gcintPASSWORD_KIGO = FLAG_ON Then
                            '(ﾊﾟｽﾜｰﾄﾞ記号ﾁｪｯｸﾌﾗｸﾞがONのとき)
                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[^a-zA-Z0-9]") = False Then
                                '(ﾊﾟｽﾜｰﾄﾞに記号が含まれていないとき)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_15, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                        If gcintPASSWORD_DAISHO = FLAG_ON Then
                            '(ﾊﾟｽﾜｰﾄﾞ大文字小文字ﾁｪｯｸﾌﾗｸﾞがONのとき)
                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[A-Z]") = False Then
                                '(ﾊﾟｽﾜｰﾄﾞに大文字が含まれていないとき)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_17, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If

                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[a-z]") = False Then
                                '(ﾊﾟｽﾜｰﾄﾞに小文字が含まれていないとき)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_18, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                    End If

                    '********************************************************************
                    'ｿｹｯﾄ送信処理(ﾊﾟｽﾜｰﾄﾞ登録処理)
                    '********************************************************************
                    Call SendSocket01()


                Case FLAG_OFF
                    '(ｻｰﾊﾞﾌﾟﾛｾｽを使用しないでﾛｸﾞｲﾝする場合)
                    Call LogInProcess()    'ﾛｸﾞｲﾝ処理へ

            End Select


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  F8 (Close)       ﾎﾞﾀﾝ押下処理        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8 押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8_Proc()
        Try

            Dim udeRet As RetPopup

            '*******************************************************
            '確認ﾒｯｾｰｼﾞ
            '*******************************************************
            udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_SHUTDOWN, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            If udeRet <> RetPopup.OK Then
                Exit Sub
            End If


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
                If IsNull(gobjFRM_100001) = False Then
                    gobjFRM_100001.Close()
                    gobjFRM_100001.Dispose()
                    gobjFRM_100001 = Nothing
                End If
                Me.Close()
                Me.Dispose()

            End If


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ﾕｰｻﾞｰ名表示処理                      "
    ''' ------------------------------------------------------------------------
    ''' <summary>
    ''' ﾕｰｻﾞｰ名表示処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' ------------------------------------------------------------------------
    Private Sub Change_EmpCd()
        Try

            Dim intRet As Integer       '戻値用
            Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)


            '**********************************************************
            ' ﾕｰｻﾞｰID    ﾁｪｯｸ
            '**********************************************************
            If Trim(txtFLOGIN_ID.Text) = "" Then
                lblFUSER_NAME.Text = ""
                txtReFPASS_WORD.Text = ""
                txtReFPASS_WORD.Enabled = False
                cmdPassChng.Enabled = True
                Exit Sub
            End If

            '**********************************************************
            ' ﾕｰｻﾞｰ名      表示
            '**********************************************************
            objTMST_USER.FUSER_ID = txtFLOGIN_ID.Text           'ﾕｰｻﾞID
            intRet = objTMST_USER.GET_TMST_USER(False)          '情報取得

            If intRet <> RetCode.OK Then
                lblFUSER_NAME.Text = ""                    'ﾕｰｻﾞｰ名
                txtReFPASS_WORD.Text = ""
                txtReFPASS_WORD.Enabled = False
                cmdPassChng.Enabled = False
                txtFPASS_WORD.Focus()                      'ﾊﾟｽﾜｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽ  選択
                Exit Sub
            End If

            lblFUSER_NAME.Text = objTMST_USER.FUSER_NAME    'ﾕｰｻﾞｰ名
            txtFPASS_WORD.Focus()                          'ﾊﾟｽﾜｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽ  選択


            '==================================
            ' ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '==================================
            If IsNull(objTMST_USER.FPASS_WORD) <> False Then
                '(ﾊﾟｽﾜｰﾄﾞがNULLの場合、新規ﾕｰｻﾞ)
                txtReFPASS_WORD.Enabled = True
                cmdPassChng.Enabled = False
            Else
                txtReFPASS_WORD.Text = ""
                txtReFPASS_WORD.Enabled = False
                cmdPassChng.Enabled = True
            End If


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ﾊﾟｽﾜｰﾄﾞ変更処理                      "
    ''' ------------------------------------------------------------------------
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ変更処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' ------------------------------------------------------------------------
    Private Sub Change_Pass()
        Try

            '**********************************************************
            ' ﾕｰｻﾞｰID入力ﾁｪｯｸ
            '**********************************************************
            If txtFLOGIN_ID.Text = "" Then
                '(ﾊﾟｽﾜｰﾄﾞがﾌﾞﾗﾝｸのとき)
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_10, _
                                PopupFormType.Ok, _
                                PopupIconType.Err)
                Exit Sub
            End If

            Dim intRet As Integer       '戻値用
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
            intRet = objTMST_USER_CHANGE.GET_TMST_USER(False)           '特定
            If intRet = RetCode.OK Then
                '==================================
                ' ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
                '==================================
                If txtFPASS_WORD.Text <> objTMST_USER_CHANGE.FPASS_WORD Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Err)
                    Exit Sub
                End If
            Else
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_02, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
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
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
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
            objTMST_USER.GET_TMST_USER(False)               '情報取得
            If intRet <> RetCode.OK Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_02, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If

            '==================================
            ' ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '==================================
            If txtFPASS_WORD.Text <> objTMST_USER.FPASS_WORD Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_01, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                txtFPASS_WORD.Focus()
                Exit Sub
            End If

            '==================================
            ' ﾕｰｻﾞ認証状況ﾁｪｯｸ
            '==================================
            If objTMST_USER.FUSER_ATEST <> FUSER_ATEST_SNORMAL Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_05, _
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
            objTMST_USER_DSP.USER_SQL = strSQL                  'SQL文
            intRet = objTMST_USER_DSP.GET_TMST_USER_DSP_USER()  '取得
            If intRet <> RetCode.OK Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_04, _
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
            ' 画面起動
            '**********************************************************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(gobjOwner, gobjDb, Nothing)
            objTDSP_TERM.FTERM_ID = gcstrFTERM_ID       '端末ID     ｾｯﾄ
            objTDSP_TERM.GET_TDSP_TERM(False)           '情報取得

            Dim strPara As String = objTDSP_TERM.FDISP_ID
            Call gobjComFuncFRM.FormMoveSelect(strPara, Me)

            '**********************************************************
            ' ﾛｸﾞｵﾌﾌﾗｸﾞFalse
            '**********************************************************
            gblnLogoff = False          'ﾛｸﾞｵﾝ状態


            Me.Close()
            Me.Dispose()


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try

    End Sub
#End Region
#Region "  ﾊﾟｽﾜｰﾄﾞ変更画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ変更画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()

        gobjFRM_100006.userFUSER_ID = TO_STRING(txtFLOGIN_ID.Text)                  'ﾕｰｻﾞｰID
        gobjFRM_100006.userFUSER_NAME = TO_STRING(lblFUSER_NAME.Text)               'ﾕｰｻﾞｰ名

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
        intRet = objTMST_USER.GET_TMST_USER(False)          '情報取得
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
        udtSckSendRET = gobjComFuncFRM.SendSockLogin(txtFLOGIN_ID.Text _
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
                txtReFPASS_WORD.Text = ""
                txtFPASS_WORD.Focus()
            End If
        Else
            txtFPASS_WORD.Text = ""
            txtReFPASS_WORD.Text = ""
            txtFPASS_WORD.Focus()
        End If

    End Sub
#End Region
#Region "  ｸﾘｽﾀﾙﾚﾎﾟｰﾄﾗﾝﾀｲﾑ読込                  "
    ''' <summary>
    ''' ｸﾘｽﾀﾙﾚﾎﾟｰﾄﾗﾝﾀｲﾑ読込
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCR()


        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_000001          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
        Try


            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))         '発行日時

            Dim objDataRow As clsPrintDataSet.DataTable01Row
            objDataRow = objDataSet.DataTable01.NewRow
            objDataRow.BeginEdit()
            objDataRow.Data00 = "1"
            objDataRow.EndEdit()
            objDataSet.DataTable01.Rows.Add(objDataRow)


            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)
            'objCR.PrintToPrinter(0, False, 0, 0)    ' 印字


            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄのﾀﾞﾐｰ印字処理
            '***********************************************
            Dim objetc1201 As New FRM_100003
            If IsNull(objetc1201) = False Then
                objetc1201.Close()
                objetc1201.Dispose()
                objetc1201 = Nothing
            End If
            objetc1201 = FRM_100003
            objetc1201.CrystalReportViewer1.ReportSource = objCR
            objetc1201.Opacity = 0
            objetc1201.Show()
            objetc1201.Close()
            objetc1201.Dispose()
            objetc1201 = Nothing


        Catch ex As Exception
            Throw ex

        Finally
            Try
                'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
                objCR.Dispose()
                objCR = Nothing
                'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
                objDataSet.Dispose()
                objDataSet = Nothing
                Call gobjComFuncFRM.AddToLog_frm("LoadCRｽﾚｯﾄﾞ終了。")
            Catch ex As Exception
                Throw ex
            End Try
        End Try

    End Sub
#End Region

End Class