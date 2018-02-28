'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】画面親ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************


#Region "  Imports      "

Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMate.clsComFuncFRM

#End Region

Public Class FRM_000002

#Region "　共通変数、共通定数"
    '***********************************************************************************************
    ' 共通変数
    '***********************************************************************************************
    Private mblnFKey(12) As Boolean     '(1): F1 ～　(11): F12
    Private mintBlink As Integer        '点滅用ｶｳﾝﾀｰ
    Protected mblnClose As Boolean      'ｸﾛｰｽﾞ許可ﾌﾗｸﾞ
    Private mobjMsgColor As Color       'ﾒｯｾｰｼﾞ確認点滅表示色

    '表示色
    Private mobjMsgColorLevel00 As Color = Color.DarkGray  '点滅なし
    Private mobjMsgColorLevel01 As Color = Color.Green     'ﾚﾍﾞﾙ1色
    Private mobjMsgColorLevel02 As Color = Color.Blue      'ﾚﾍﾞﾙ2色
    Private mobjMsgColorLevel03 As Color = Color.Red       'ﾚﾍﾞﾙ3色


    '-------------------------------------------------------
    ' 列挙体
    '-------------------------------------------------------
    Enum cmd
        F1
        F2
        F3
        F4
        F5
        F6
        F7
        F8
        F10
        F11
    End Enum

#End Region


    '************************************************************************************************************************
    '************************************************************************************************************************
    '
    'ｵｰﾊﾞｰﾗｲﾄﾞ  可
    '
    '************************************************************************************************************************
    '************************************************************************************************************************
#Region "  F1  ﾎﾞﾀﾝ押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F1Process()



    End Sub
#End Region
#Region "  F2  ﾎﾞﾀﾝ押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2  ﾎﾞﾀﾝ押下処
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F2Process()



    End Sub
#End Region
#Region "  F3  ﾎﾞﾀﾝ押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F3Process()



    End Sub
#End Region
#Region "  F4  ﾎﾞﾀﾝ押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F4Process()



    End Sub
#End Region
#Region "  F5  ﾎﾞﾀﾝ押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F5Process()



    End Sub
#End Region
#Region "  F6  ﾎﾞﾀﾝ押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F6Process()



    End Sub
#End Region
#Region "  F7  ﾎﾞﾀﾝ押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F7  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub F7Process()



    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ押下処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overridable Sub F8Process()



    End Sub
#End Region
#Region "  画面ｵｰﾌﾟﾝ処理    (各画面処理)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面ｵｰﾌﾟﾝ処理(各画面処理)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()



    End Sub
#End Region
#Region "  画面ｸﾛｰｽﾞ処理    (各画面処理)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面ｸﾛｰｽﾞ処理(各画面処理)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub CloseChild()



    End Sub
#End Region
#Region "  画面遷移ﾃｽﾄ      ﾀｲﾏｰ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  画面遷移ﾃｽﾄ ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub FormMoveTest()



    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示処理1          "
    '''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示処理1
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub grdListDisplayChild()



    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示処理2          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示処理2
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub grdListDisplayChild2()



    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示処理3          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示処理3
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub grdListDisplayChild3()



    End Sub
#End Region

    '************************************************************************************************************************
    '************************************************************************************************************************
    '
    'ｵｰﾊﾞｰﾗｲﾄﾞ  不可
    '
    '************************************************************************************************************************
    '************************************************************************************************************************
#Region "  画面初期化                   (全画面共通)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面初期化(全画面共通)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Initialize_Template()
        Dim intRet As Integer                   '戻り値

        '**********************************************************
        'ﾃﾞｻﾞｲﾝﾓｰﾄﾞ時は処理回避
        '**********************************************************
        If Me.DesignMode = True Then Exit Sub 'ﾃﾞｻﾞｲﾝﾓｰﾄﾞの時はﾌﾟﾛｸﾞﾗﾑを実行しない
        If IsNull(gobjDb) Then Exit Sub 'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄがない時は、ﾌﾟﾛｸﾞﾗﾑを実行しない


        '**********************************************************
        '共通変数初期化
        '**********************************************************
        mblnClose = False                        ' ｸﾛｰｽﾞ許可ﾌﾗｸﾞ


        '**********************************************************
        'ﾗﾍﾞﾙ初期化
        '**********************************************************
        lblErrMsg.Text = ""                         ' ｴﾗｰﾒｯｾｰｼﾞ初期化
        lblTermName.Text = gcstrFTERM_NAME          ' 端末名表示
        lblUserName.Text = gcstrFUSER_NAME           ' ユーザ名表示
        Call Set_Time()                             ' 時刻表示


        '**********************************************************
        ' ﾎﾞﾀﾝ初期化
        '**********************************************************
        ' ﾌｧﾝｸｼｮﾝｷｰ
        For ii As cmd = cmd.F1 To cmd.F11
            mblnFKey(ii) = False
        Next
        mblnFKey(cmd.F10) = True        'F10
        mblnFKey(cmd.F11) = True        'F11だけ有効にする

        '**********************************************************
        ' ｵﾍﾟﾚｰｼｮﾝﾒｯｾｰｼﾞ初期化
        '**********************************************************
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:A.Noto 2012/09/19 ｱﾅｼｴｰﾀﾎﾞﾀﾝ表示変更
        'cmdMsgChk.ForeColor = Color.DarkGray
        cmdMsgChk.BackgroundImage = Nothing
        '↑↑↑↑↑↑************************************************************************************************************

        '**********************************************************
        ' ﾀｲﾏｰ値取得・設定
        '**********************************************************
        tmrTime.Interval = gcinttmrTime_Interval
        tmrBlink.Interval = gcinttmrBlink_Interval
        tmrOpeMsg.Interval = gcinttmrOpeMsg_Interval
        tmrTest_1.Interval = gcinttmrTest_1_Interval
        tmrTime.Enabled = True
        tmrOpeMsg.Enabled = True
        tmrTest_1.Enabled = True


        '**********************************************************
        ' ﾒﾆｭｰﾎﾞﾀﾝ名取得
        '**********************************************************
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd01)      'ｼｽﾃﾑﾓﾆﾀ
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd02)      '入出庫業務ﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd03)      '生産操業ﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd04)      '検査結果登録
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd05)      '出荷業務ﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd06)      '問合せﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd08)      'ﾒﾝﾃﾅﾝｽﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd09)      'ﾏｽﾀﾒﾝﾃﾅﾝｽﾒﾆｭｰ
        Call gobjComFuncFRM.ButtonTextSet(FDISP_ID_SKOTEI, cmd10)      'ｼｽﾃﾑﾒﾝﾃﾅﾝｽﾒﾆｭｰ

        '**********************************************************
        ' ﾒﾆｭｰﾎﾞﾀﾝ名取得
        '**********************************************************
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu02_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu02_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu02_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu02_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_03)
        'Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_04)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:YAMAMOTO 2017/04/01 1F包材出庫登録 
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu03_05)
        '↑↑↑↑↑↑************************************************************************************************************

        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_06)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_07)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_08)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu05_09)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_06)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:N.Nakada 2013/11/01 棚卸リスト
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu06_07)
        '↑↑↑↑↑↑************************************************************************************************************
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_06)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu08_07)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_06)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu09_07)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_01)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_02)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_03)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_04)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_05)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_06)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_07)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_08)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_09)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_10)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_11)
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_12)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:YAMAMOTO 2017/04/01 1F包材出庫登録 
        Call gobjComFuncFRM.ToolStripMenuItemSet(FDISP_ID_SKOTEI, Menu10_13)
        '↑↑↑↑↑↑************************************************************************************************************


        '**********************************************************
        ' ﾌｫｰﾑ名取得
        '**********************************************************
        Dim objTDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)

        objTDSP_NAME.FDISP_ID = Me.Name                 '画面ID     ｾｯﾄ
        objTDSP_NAME.FCTRL_ID = FCTRL_ID_SKOTEI          'ｺﾝﾄﾛｰﾙID     ｾｯﾄ
        intRet = objTDSP_NAME.GET_TDSP_NAME(False)      '情報取得
        If intRet <> RetCode.OK Then
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_BUTTONTEXTSET_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Err, _
                              "ID　：" & objTDSP_NAME.FDISP_ID)
            Exit Sub
        End If

        '###と改行を消去
        Dim strTitle As String
        strTitle = Replace(objTDSP_NAME.FOBJECT_NAME, REPLACE_STRING_01, "")
        strTitle = Replace(strTitle, vbCrLf, "")

        lblTitle.Text = " " & strTitle          'ﾀｲﾄﾙ   を表示
        Call gobjComFuncFRM.AddToLog_frm(lblTitle.Text & "に展開")


        '**********************************************************
        ' ﾎﾞﾀﾝ設定
        '**********************************************************
        Call CmdEnabledChangeButton(cmdF1, Me.Name, True)                  'F1ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF2, Me.Name, True)                  'F2ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF3, Me.Name, True)                  'F3ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF4, Me.Name, True)                  'F4ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF5, Me.Name, True)                  'F5ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF6, Me.Name, True)                  'F6ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF7, Me.Name, True)                  'F7ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF8, Me.Name, True)                  'F8ﾎﾞﾀﾝ

        ' ''**********************************************************
        ' '' ﾒﾆｭｰﾎﾞﾀﾝ設定
        ' ''**********************************************************
        ''Call CmdEnabledChangeMenu()


        '**********************************************************
        ' ﾒｯｾｰｼﾞﾛｸﾞ検索
        '**********************************************************
        Call GetLogMessage()
        tmrOpeMsg.Enabled = True


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
            Me.Size = New Size(1366, 768)               '画面ｻｲｽﾞ
            Me.MaximumSize = New Size(1366, 768)        '画面ｻｲｽﾞ
            Me.MinimumSize = New Size(1366, 768)        '画面ｻｲｽﾞ
            'Me.ShowInTaskbar = True                     'ﾀｽｸﾊﾞｰ表示(これを有効にすると画面が落ちる)
            Me.Location = gobjLocation                  '画面位置


        Else
            '=================================================
            '操業ﾓｰﾄﾞ
            '=================================================
            '何もしない

        End If


        '**********************************************************
        ' 画面遷移ﾃｽﾄﾀｲﾏｰﾌﾗｸﾞﾁｪｯｸ
        '**********************************************************
        Select Case gcstrTMRTEST_1
            Case FLAG_ON
                tmrTest_1.Enabled = True
            Case Else
                tmrTest_1.Enabled = False
        End Select

        '*************************************************
        ' 離席ﾎﾞﾀﾝ設定
        '*************************************************
        If gcintAfkFlg = FLAG_OFF Then
            Me.btnAFK.Text = ""
            Me.btnAFK.Visible = False
        End If


        '**********************************************************
        ' 開発者用ﾎﾞﾀﾝ設定
        '**********************************************************
        If TO_NUMBER(gcstrDEGUB_FLG) = 9 Then
            cmdDevelopment.Visible = True
        Else
            cmdDevelopment.Visible = False
        End If


    End Sub
#End Region
#Region "　ﾒｯｾｰｼﾞ取得処理               (定周期)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞ取得処理(定周期)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub GetLogMessage()

        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim udtRet As RetCode


        '****************************************************************
        ' 未確認の最新ﾛｸﾞﾒｯｾｰｼﾞを取得
        '       【TLOG_MESSAGE】
        '       【TMST_MESSAGE】
        '       【TDSP_TERM_MSG】
        '****************************************************************
        Dim strMSG_ID As String = ""        'ﾒｯｾｰｼﾞﾛｸﾞ. ﾒｯｾｰｼﾞID
        Dim intMSG_LEVEL As Integer         'ﾒｯｾｰｼﾞﾏｽﾀ. ﾒｯｾｰｼﾞﾚﾍﾞﾙ
        Dim strMSG_NAIYOU As String = ""    'ﾒｯｾｰｼﾞﾏｽﾀ. ﾒｯｾｰｼﾞ内容

        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TLOG_MESSAGE.FLOG_CHECK_FLAG FLOG_CHECK_FLAG "      'ﾒｯｾｰｼﾞﾛｸﾞ. 確認済みﾌﾗｸﾞ
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FHASSEI_DT FHASSEI_DT "                'ﾒｯｾｰｼﾞﾛｸﾞ. 発生日時
        strSQL &= vbCrLf & "  , TMST_MESSAGE.FMSG_NAIYOU FMSG_NAIYOU "              'ﾒｯｾｰｼﾞﾏｽﾀ. ﾒｯｾｰｼﾞﾏｽﾀ. 名称
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM1 FMSG_PRM1 "                  'ﾒｯｾｰｼﾞﾛｸﾞ. ﾊﾟﾗﾒｰﾀ1
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM2 FMSG_PRM2 "                  'ﾒｯｾｰｼﾞﾛｸﾞ. ﾊﾟﾗﾒｰﾀ2
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM3 FMSG_PRM3 "                  'ﾒｯｾｰｼﾞﾛｸﾞ. ﾊﾟﾗﾒｰﾀ3
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM4 FMSG_PRM4 "                  'ﾒｯｾｰｼﾞﾛｸﾞ. ﾊﾟﾗﾒｰﾀ4
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM5 FMSG_PRM5 "                  'ﾒｯｾｰｼﾞﾛｸﾞ. ﾊﾟﾗﾒｰﾀ5
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FLOG_NO FLOG_NO "                      'ﾒｯｾｰｼﾞﾛｸﾞ. ﾛｸﾞNo
        strSQL &= vbCrLf & "  , TMST_MESSAGE.FMSG_LEVEL FMSG_LEVEL "                'ﾒｯｾｰｼﾞﾏｽﾀ. ﾒｯｾｰｼﾞﾚﾍﾞﾙ
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_ID FMSG_ID "                      'ﾒｯｾｰｼﾞﾛｸﾞ.ﾒｯｾｰｼﾞID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TLOG_MESSAGE TLOG_MESSAGE LEFT OUTER JOIN"          'ﾒｯｾｰｼﾞﾛｸﾞ     (外部結合)
        strSQL &= vbCrLf & "    TMST_MESSAGE TMST_MESSAGE ON "                      'ﾒｯｾｰｼﾞﾏｽﾀ     (外部結合)
        strSQL &= vbCrLf & "       TLOG_MESSAGE.FMSG_ID = TMST_MESSAGE.FMSG_ID "    'ﾒｯｾｰｼﾞﾛｸﾞとﾒｯｾｰｼﾞﾏｽﾀを外部結合
        strSQL &= vbCrLf & "  , TDSP_TERM_MSG "                                     '端末別ﾒｯｾｰｼﾞ出力ﾏｽﾀ
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        TLOG_MESSAGE.FLOG_CHECK_FLAG = " & TO_STRING(FLAG_OFF)              '確認済みﾌﾗｸﾞ
        strSQL &= vbCrLf & "    AND TMST_MESSAGE.FMSG_LEVEL >= " & TO_STRING(gcintDisp_INTMSG_LEVEL)    'ﾒｯｾｰｼﾞﾚﾍﾞﾙ
        strSQL &= vbCrLf & "    AND TMST_MESSAGE.FMSG_ID = TDSP_TERM_MSG.FMSG_ID"                       '結合
        strSQL &= vbCrLf & "    AND (TDSP_TERM_MSG.FTERM_ID = '" & gcstrFTERM_ID & "'"                  '端末ID
        strSQL &= vbCrLf & "     OR  TDSP_TERM_MSG.FTERM_ID = '" & FTERM_ID_SKOTEI & "')"
        strSQL &= vbCrLf & "    AND TDSP_TERM_MSG.FMSG_OUT_FLAG = " & FLAG_ON                           'ﾒｯｾｰｼﾞ出力有無
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    TMST_MESSAGE.FMSG_LEVEL DESC"          'ﾒｯｾｰｼﾞﾏｽﾀ. ﾒｯｾｰｼﾞﾚﾍﾞﾙ   (降順)
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FLOG_NO DESC"             'ﾒｯｾｰｼﾞﾛｸﾞ. ﾛｸﾞNo        (降順)
        strSQL &= vbCrLf

        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TLOG_MESSAGE"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            strMSG_ID = TO_STRING(objRow("FMSG_ID"))            'ﾒｯｾｰｼﾞﾛｸﾞ. ﾒｯｾｰｼﾞID
            intMSG_LEVEL = TO_NUMBER(objRow("FMSG_LEVEL"))      'ﾒｯｾｰｼﾞﾏｽﾀ. ﾒｯｾｰｼﾞﾚﾍﾞﾙ
            strMSG_NAIYOU = TO_STRING(objRow("FMSG_NAIYOU"))    'ﾒｯｾｰｼﾞﾏｽﾀ. ﾒｯｾｰｼﾞ内容

            udtRet = RetCode.OK
        Else
            udtRet = RetCode.NotFound
        End If


        '****************************************************************
        ' 画面に表示
        '****************************************************************
        If udtRet = RetCode.NotFound Then
            '======================================
            ' 未確認ﾒｯｾｰｼﾞが存在しない時
            '======================================
            tmrBlink.Enabled = False                    '点滅なし
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:A.Noto 2012/09/19 ｱﾅｼｴｰﾀﾎﾞﾀﾝ表示変更
            'Me.cmdMsgChk.ForeColor = Color.DarkGray     '点滅なし
            cmdMsgChk.BackgroundImage = Nothing
            '↑↑↑↑↑↑************************************************************************************************************

        ElseIf udtRet = RetCode.OK Then
            '======================================
            ' 未確認ﾒｯｾｰｼﾞが存在する時
            '======================================
            Dim objTTMST_MESSAGE As TBL_TMST_MESSAGE
            objTTMST_MESSAGE = New TBL_TMST_MESSAGE(gobjOwner, gobjDb, Nothing)

            objTTMST_MESSAGE.FMSG_ID = strMSG_ID         'ﾒｯｾｰｼﾞID   ｾｯﾄ
            objTTMST_MESSAGE.GET_TMST_MESSAGE(False)     '情報取得

            'ﾎﾞﾀﾝ点滅色指定
            Select Case intMSG_LEVEL
                Case 1
                    mobjMsgColor = mobjMsgColorLevel01
                Case 2
                    mobjMsgColor = mobjMsgColorLevel02
                Case 3
                    mobjMsgColor = mobjMsgColorLevel03
                Case Else
                    mobjMsgColor = mobjMsgColorLevel01
            End Select

            tmrBlink.Enabled = True                     '点滅

        End If

    End Sub
#End Region
#Region "　ﾎﾞﾀﾝ点滅処理                 (定周期)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾞﾀﾝ点滅処理(定周期)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Blink_Proc()

        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:A.Noto 2012/09/19 ｱﾅｼｴｰﾀﾎﾞﾀﾝ表示変更
        If cmdMsgChk.Enabled = True Then
            If mintBlink = 0 Then
                '----------------------------------------------
                ' 表示　出
                '----------------------------------------------
                cmdMsgChk.BackgroundImageLayout = ImageLayout.Center
                cmdMsgChk.BackgroundImage = System.Drawing.Image.FromFile("..\JPEG\warning.gif")
                mintBlink = 1
            ElseIf mintBlink = 1 Then
                '----------------------------------------------
                ' 表示　消
                '----------------------------------------------
                cmdMsgChk.BackgroundImage = Nothing
                mintBlink = 0
            End If
        End If


        'If mintBlink = 0 Then
        '    '----------------------------------------------
        '    ' 赤色表示
        '    '----------------------------------------------
        '    Me.cmdMsgChk.ForeColor = mobjMsgColor
        '    mintBlink = 1

        'ElseIf mintBlink = 1 Then
        '    '----------------------------------------------
        '    ' 灰色表示（●消）
        '    '----------------------------------------------
        '    Me.cmdMsgChk.ForeColor = mobjMsgColorLevel00
        '    mintBlink = 0

        'End If
        '↑↑↑↑↑↑************************************************************************************************************


    End Sub
#End Region
#Region "  時刻表示処理                 (定周期)"
    ''' <summary>
    ''' 時刻表示処理(定周期)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Set_Time()

        Me.lblTime.Text = Format(Now, GAMEN_DATE_FORMAT_01)

    End Sub
#End Region
#Region "  ﾛｺﾞﾎﾞﾀﾝ                      押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｺﾞﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub F11Process()

        '*****************************************
        ' ﾂﾘｰ画面表示処理
        '*****************************************
        'Call ShowfrmTree()

    End Sub
#End Region
#Region "　ｱﾅｼｴｰﾀｰﾎﾞﾀﾝ                  押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱﾅｼｴｰﾀｰﾎﾞﾀﾝ 押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub btnMsgChkProc()
        '*************************************************
        'ﾒｯｾｰｼﾞ初期化
        '*************************************************
        tmrOpeMsg.Enabled = False               '取得用用ﾀｲﾏｰ開始
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:A.Noto 2012/09/19 ｱﾅｼｴｰﾀﾎﾞﾀﾝ表示変更
        'cmdMsgChk.ForeColor = Color.DarkGray    'ｵﾍﾟﾚｰｼｮﾝﾒｯｾｰｼﾞ初期化
        cmdMsgChk.BackgroundImage = Nothing
        '↑↑↑↑↑↑************************************************************************************************************

        '*************************************************
        'ﾌｫｰﾑの遷移
        '*************************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_209000, Me)


        '*************************************************
        'ｵﾍﾟﾚｰｼｮﾝﾒｯｾｰｼﾞ取得
        '*************************************************
        tmrOpeMsg.Enabled = True       '取得用用ﾀｲﾏｰ開始
        Call GetLogMessage()


    End Sub
#End Region
#Region "　離席ﾎﾞﾀﾝ                     押下処理"
    Protected Sub btnAFKProc()

        '***************************************************************
        '離席処理
        '***************************************************************
        Call gobjComFuncFRM.AfkProc(Me)

    End Sub
#End Region
#Region "  ﾌｧﾝｸｼｮﾝｷｰ                    押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｧﾝｸｼｮﾝｷｰ                    押下処理
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub KeyDownProc(ByVal e As System.Windows.Forms.KeyEventArgs)

        '**************************************************
        'Alt ｷｰが押下されたか判断
        '**************************************************
        If e.Alt = True Then Exit Sub
        If e.Shift = True Then Exit Sub
        If e.Control = True Then Exit Sub


        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:A.Noto 2012/09/13 ﾌｧﾝｸｼｮﾝｷｰを無効にする 

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/29 包材出庫登録 ﾌｧﾝｸｼｮﾝｷｰの無効化
        ' '' ''↓↓↓↓↓↓************************************************************************************************************
        ' '' ''JobMate:H.Okumura 2013/04/17 特定の画面のときﾌｧﾝｸｼｮﾝｷｰを有効にする 
        '' ''Select Case Me.Name
        '' ''    Case FDISP_ID_JFRM_310030
        '' ''        '(包材出庫登録のとき)

        '' ''        ''**************************************************
        '' ''        ''押下されたｷｰﾎﾞｰﾄﾞ判断
        '' ''        ''**************************************************
        '' ''        Select Case e.KeyCode
        '' ''            Case Windows.Forms.Keys.F1
        '' ''                If cmdF1.Enabled = True And _
        '' ''                   mblnFKey(cmd.F1) = True Then
        '' ''                    Call cmdF1_Click(Nothing, Nothing)
        '' ''                End If

        '' ''            Case Windows.Forms.Keys.F2
        '' ''                If cmdF2.Enabled = True And _
        '' ''                   mblnFKey(cmd.F2) = True Then
        '' ''                    Call cmdF2_Click(Nothing, Nothing)
        '' ''                End If
        '' ''        End Select

        '' ''    Case FDISP_ID_JFRM_310040
        '' ''        '(包材出庫登録(D45)のとき)

        '' ''        ''**************************************************
        '' ''        ''押下されたｷｰﾎﾞｰﾄﾞ判断
        '' ''        ''**************************************************
        '' ''        Select Case e.KeyCode
        '' ''            Case Windows.Forms.Keys.F1
        '' ''                If cmdF1.Enabled = True And _
        '' ''                   mblnFKey(cmd.F1) = True Then
        '' ''                    Call cmdF1_Click(Nothing, Nothing)
        '' ''                End If

        '' ''            Case Windows.Forms.Keys.F2
        '' ''                If cmdF2.Enabled = True And _
        '' ''                   mblnFKey(cmd.F2) = True Then
        '' ''                    Call cmdF2_Click(Nothing, Nothing)
        '' ''                End If
        '' ''        End Select

        '' ''    Case Else

        '' ''End Select
        'JobMate:S.Ouchi 2013/10/29 包材出庫登録 ﾌｧﾝｸｼｮﾝｷｰの無効化
        '↑↑↑↑↑↑************************************************************************************************************


        ' ''**************************************************
        ' ''押下されたｷｰﾎﾞｰﾄﾞ判断
        ' ''**************************************************
        'Select e.KeyCode
        '    Case Windows.Forms.Keys.F1
        '        If cmdF1.Enabled = True And _
        '           mblnFKey(cmd.F1) = True Then
        '            Call cmdF1_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F2
        '        If cmdF2.Enabled = True And _
        '           mblnFKey(cmd.F2) = True Then
        '            Call cmdF2_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F3
        '        If cmdF3.Enabled = True And _
        '           mblnFKey(cmd.F3) = True Then
        '            Call cmdF3_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F4
        '        If cmdF4.Enabled = True And _
        '           mblnFKey(cmd.F4) = True Then
        '            Call cmdF4_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F5
        '        If cmdF5.Enabled = True And _
        '           mblnFKey(cmd.F5) = True Then
        '            Call cmdF5_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F6
        '        If cmdF6.Enabled = True And _
        '           mblnFKey(cmd.F6) = True Then
        '            Call cmdF6_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F7
        '        If cmdF7.Enabled = True And _
        '           mblnFKey(cmd.F7) = True Then
        '            Call cmdF7_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F8
        '        If cmdF8.Enabled = True And _
        '           mblnFKey(cmd.F8) = True Then
        '            Call cmdF8_Click(Nothing, Nothing)
        '        End If

        '    Case Windows.Forms.Keys.F10
        '        If mblnFKey(cmd.F10) = True Then
        '            Call btnMsgChkProc()
        '        End If

        '    Case Windows.Forms.Keys.F11
        '        If mblnFKey(cmd.F11) = True Then
        '            Call F11Process()
        '        End If

        'End Select
        '↑↑↑↑↑↑************************************************************************************************************

    End Sub
#End Region
#Region "  ｲﾍﾞﾝﾄ　　　　　　　　                "
#Region "  Visible          変更"
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  Visible 変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmTemplate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        Try
            '***********************************************************
            '初期化判定
            '***********************************************************
            If Me.Visible = False Then Exit Sub


            '***********************************************************
            '画面初期化（全画面共通処理）
            '***********************************************************
            Call Initialize_Template()


            '***********************************************************
            '画面初期化（各画面処理）
            '***********************************************************
            Call InitializeChild()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  Menu01  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu01  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd01.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↓↓↓↓↓↓
            '' ''Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_202000, Me)
            Me.cmsMenu01.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu01.Show(Me, cmsMenu01.Location)
            'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd02.Click
        Try
            Me.cmsMenu02.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu02.Show(Me, cmsMenu02.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd03.Click
        Try
            Me.cmsMenu03.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu03.Show(Me, cmsMenu03.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd04.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd05.Click
        Try

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2012/12/04 棚卸しﾒﾆｭｰ追加
            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305010, Me)

            Me.cmsMenu05.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu05.Show(Me, cmsMenu05.Location)
            '↑↑↑↑↑↑************************************************************************************************************

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd06.Click
        Try
            Me.cmsMenu06.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu06.Show(Me, cmsMenu06.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu07  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu07  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd07.Click
        Try

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd08.Click
        Try
            Me.cmsMenu08.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu08.Show(Me, cmsMenu08.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd09.Click
        Try
            Me.cmsMenu09.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu09.Show(Me, cmsMenu09.Location)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10  ﾎﾞﾀﾝ     ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd10.Click
        Try
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/04/05 ﾒﾆｭｰが画面外で展開されないよう修正
            If (sender.Location.Y + cmsMenu10.Height) > Me.Height Then
                Me.cmsMenu10.Location = New Point(sender.Location.X + sender.Size.Width, (Me.Height - cmsMenu10.Height - 1))
            Else
                Me.cmsMenu10.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            End If

            'Me.cmsMenu10.Location = New Point(sender.Location.X + sender.Size.Width, sender.Location.Y)
            cmsMenu10.Show(Me, cmsMenu10.Location)
            '↑↑↑↑↑↑************************************************************************************************************
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↓↓↓↓↓↓
#Region "  Menu01_01        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu01_01     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu01_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu01_01.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_202000, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu01_02        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu01_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu01_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu01_02.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_302010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

#Region "  Menu02_01        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_01     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu02_01.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_02        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu02_02.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_03        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_03     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu02_03.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_04        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_04     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu02_04.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_05        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_05     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_06        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_06     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_07        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_07     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308110, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu02_08        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu02_08     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu02_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308100, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_01        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_01     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_01.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_02        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_02.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_03        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_03     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_03.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_04        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_04     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_05        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_05     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_05.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310050, Me)


        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_06        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_06     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu03_06.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303060, Me)

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:IKEDA 2017/07/06 生産入庫登録(BCR)対応 ↓↓↓↓↓↓
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307140, Me)
            'JobMate:IKEDA 2017/07/06 生産入庫登録(BCR)対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_07        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_07     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu03_07        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu03_07     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu03_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_01        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_01     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_02        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_03        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_03     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_04        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_04     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_05        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_05     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_06        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_06     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_07        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_07     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_08        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_08     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu04_09        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu04_09     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu04_09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308120, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_01        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_01     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_01.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_02        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_02.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311015, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_03        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_03     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_03.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_04        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_04     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_04.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_05        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_05     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_05.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_06        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_06     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_06.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_07        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_07     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_07.Click
        Try

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/07/25 ﾊﾞｰｽ状況ﾓﾆﾀのみ遷移ではなく新規表示

            gobjFRM_311090 = New FRM_311090
            gobjFRM_311090.ShowDialog()            '展開

            ' '' ''******************************************
            ' '' '' 画面遷移
            ' '' ''******************************************
            ' ''Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311090, Me)
            '↑↑↑↑↑↑************************************************************************************************************

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_08        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_08     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_08.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu05_09        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu05_09     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu05_09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu05_09.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_311060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  Menu06_01        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_01     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_01.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_02        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_02.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_03        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_03     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_03.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_04        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_04     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_04.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_05        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_05     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_05.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu06_06        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_06     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_06.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Nakada 2013/11/01 棚卸リスト
#Region "  Menu06_07        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu06_07     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu06_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu06_07.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_304080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

#Region "  Menu08_01        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_01     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_01.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_02        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_02.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_03        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_03     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_03.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_04        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_04     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_04.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_05        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_05     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_05.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_06        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_06     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_06.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu08_07        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu08_07     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu08_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu08_07.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_01        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_01     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_01.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_206010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_02        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_02.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_03        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_03     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_03.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_04        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_04     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_04.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_05        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_05     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_05.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_06        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_06     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_06.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_07        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_07     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_07.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↓↓↓↓↓↓
#Region "  Menu09_08        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_08     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_08.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu09_09        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu09_09     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu09_09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu09_09.Click
        Try

            ''******************************************
            '' 画面遷移
            ''******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_306090, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

#Region "  Menu10_01        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_01     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_01.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207010, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_02        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_02.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207020, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_03        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_02     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_03.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207030, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_04        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_04     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_04.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207040, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_05        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_05     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_05.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207050, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_06        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_06     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_06.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207060, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_07        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_07     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_07.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307070, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_08        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_08     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_08.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307080, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_09        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_09     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_09.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307090, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_10        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_10     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_10.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307100, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_11        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_11     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_11.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307120, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_12        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_12     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_12.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307110, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Menu10_13        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_13     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_13.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307130, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:IKEDA 2017/07/06 PLCメンテナンス(BCR)対応 ↓↓↓↓↓↓
#Region "  Menu10_14        ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menu10_14     ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu10_14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu10_14.Click
        Try

            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_307150, Me)

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    'JobMate:IKEDA 2017/07/06 PLCメンテナンス(BCR)対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************
#Region "  F1  ﾎﾞﾀﾝ         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF1.Click
        Try
            lblErrMsg.Text = ""


            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF1.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '処理実行
            '********************************************
            Call F1Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F2  ﾎﾞﾀﾝ         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF2.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF2.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '処理実行
            '********************************************
            Call F2Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F3  ﾎﾞﾀﾝ         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF3.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF3.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '処理実行
            '********************************************
            Call F3Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F4  ﾎﾞﾀﾝ         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF4.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF4.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '処理実行
            '********************************************
            Call F4Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F5  ﾎﾞﾀﾝ         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF5.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF5.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '処理実行
            '********************************************
            Call F5Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F6  ﾎﾞﾀﾝ         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF6.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF6.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '処理実行
            '********************************************
            Call F6Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F7  ﾎﾞﾀﾝ         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F7  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF7.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF7.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '処理実行
            '********************************************
            Call F7Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8  ﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF8.Click
        Try

            lblErrMsg.Text = ""


            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncFRM.PassWordCheck(Me.Name, cmdF8.Name)
            If blnRet = False Then Exit Sub


            '********************************************
            '処理実行
            '********************************************
            Call F8Process()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region " 「ｱﾅｼｴｰﾀｰ」ﾎﾞﾀﾝ   ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「ｱﾅｼｴｰﾀｰ」ﾎﾞﾀﾝ   ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub btnMsgChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMsgChk.Click
        Try

            btnMsgChkProc()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region " 「離席」ﾎﾞﾀﾝ      ｸﾘｯｸ"
    Private Sub btnAFK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFK.Click
        Try

            btnAFKProc()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region " 「ﾛｸﾞｵﾌ」ﾎﾞﾀﾝ      ｸﾘｯｸ"
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Call cmdClose_ClickProccess()

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  時刻表示                 ﾀｲﾏｰ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 時刻表示 ﾀｲﾏｰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTime.Tick
        Try
            tmrTime.Enabled = False

            Call Set_Time()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmrTime.Enabled = True

        End Try
    End Sub
#End Region
#Region "  ﾎﾞﾀﾝ点滅用               ﾀｲﾏｰ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾞﾀﾝ点滅用 ﾀｲﾏｰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlink.Tick
        Try

            Call Blink_Proc()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ｵﾍﾟﾚｰｼｮﾝﾒｯｾｰｼﾞ取得       ﾀｲﾏｰ"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub tmrOpeMsg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrOpeMsg.Tick
        Try
            tmrOpeMsg.Enabled = False

            Call GetLogMessage()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmrOpeMsg.Enabled = True

        End Try
    End Sub
#End Region
#Region "  画面遷移ﾃｽﾄ              ﾀｲﾏｰ"
    Private Sub tmrTest_1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTest_1.Tick
        Try

            Call FormMoveTest()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｰﾎﾞｰﾄﾞ押下              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｰﾎﾞｰﾄﾞ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmTemplate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try

            Call KeyDownProc(e)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾌｫｰﾑｸﾛｰｽﾞ        ｲﾍﾞﾝﾄ"
    Private Sub FRM_000002_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            '****************************************
            'ｸﾛｰｽﾞ許可ﾌﾗｸﾞ = ON
            '****************************************
            If FLAG_ON = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_001) Then
                mblnClose = True
            End If


            '****************************************
            'ｸﾛｰｽﾞ処理
            '****************************************
            If mblnClose = False Then
                '=================================
                'ｸﾛｰｽﾞしない
                '=================================
                e.Cancel = True

            Else
                '=================================
                'ｸﾛｰｽﾞ処理
                '=================================
                Call MeClose()


            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾛｹｰｼｮﾝﾁｪﾝｼﾞ      ｲﾍﾞﾝﾄ"
    Private Sub FRM_000002_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        Try

            '*************************************************
            ' 色々判断
            '*************************************************
            If Me.Name = "FRM_000002" Then Exit Sub


            '*************************************************
            ' ﾛｹｰｼｮﾝ記憶
            '*************************************************
            Dim intX = Me.Location.X                '表示位置X
            Dim intY = Me.Location.Y                '表示位置Y
            If 1 <= intX And 1 <= intX Then
                gobjLocation = Nothing                  '表示位置初期化
                gobjLocation = New Point(intX, intY)    '表示位置記憶
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                              "
    Public Sub New()

        '************************************************************************************************************************
        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        '************************************************************************************************************************
        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        '************************************************************************************************************************


        Try

            '***********************************************************
            ' 画面位置設定
            '***********************************************************
            Me.Location = gobjLocation                  '画面位置


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾂﾘｰ画面                      表示処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾂﾘｰ画面 表示処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ShowfrmTree()
        '****************************************************
        ' ﾂﾘｰ表示
        '****************************************************
        If IsNull(gobjFRM_100002) = False Then
            gobjFRM_100002.Close()
            gobjFRM_100002.Dispose()
            gobjFRM_100002 = Nothing
        End If
        gobjFRM_100002 = New FRM_100002
        gobjFRM_100002.NowDispID = Me.Name                                             '画面ID         ｾｯﾄ
        gobjFRM_100002.Location = New Point(Me.Location.X + 3, Me.Location.Y + 50)     'ﾛｹｰｼｮﾝ         ｾｯﾄ
        gobjFRM_100002.ShowDialog()                                                    '表示

        '----------------------------------
        ' 「戻る」ﾎﾞﾀﾝｸﾘｯｸされた時
        '----------------------------------
        If gobjFRM_100002.CANCEL = True Then

            '何もしない

        Else

            '****************************************************
            ' 画面遷移
            '****************************************************
            Call gobjComFuncFRM.FormMoveSelect(gobjFRM_100002.NextDISP_ID, Me)

        End If

        'ﾂﾘｰｵﾌﾞｼﾞｪｸﾄ削除
        gobjFRM_100002.Close()
        gobjFRM_100002.Dispose()
        gobjFRM_100002 = Nothing

    End Sub
#End Region

    '************************************************************************************************************************
    '************************************************************************************************************************
    '
    'ﾌｫｰﾑ用共通関数
    '
    '************************************************************************************************************************
    '************************************************************************************************************************
#Region "  ｴﾗｰ処理                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub ComError(ByVal ex As Exception)
        Try

            gobjComFuncFRM.ComError_frm(ex, lblErrMsg)

        Catch ex2 As Exception
            MsgBox("ComError関数でｴﾗｰ発生")

        End Try
    End Sub
#End Region
#Region "  ﾎﾞﾀﾝ         のEnabled、Text "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾞﾀﾝの「Enabled」、「Text」を変更する
    ''' </summary>
    ''' <param name="cmdButton">変更するﾎﾞﾀﾝｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="blnEnabled">ﾎﾞﾀﾝの「Enabled」の設定</param>
    ''' <param name="strText">ﾎﾞﾀﾝの「Text」の設定</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub CmdEnabledChange(ByVal cmdButton As System.Windows.Forms.Button, _
                                   Optional ByVal blnEnabled As Boolean = False, _
                                   Optional ByVal strText As String = Nothing)
        Dim intRet As RetCode                   '戻り値
        Dim blnResult As Boolean


        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ
        '**********************************************************
        '==================================
        '【端末別許可ﾏｽﾀ】
        '==================================
        Dim intFOPE_FLAG_Term As Integer = 0        '操作ﾌﾗｸﾞ(端末別許可ﾏｽﾀ用)
        Dim objTDSP_PMT_TERM As New TBL_TDSP_PMT_TERM(gobjOwner, gobjDb, Nothing)
        objTDSP_PMT_TERM.FTERM_KUBUN = gcintFTERM_KBN               '端末区分   ｾｯﾄ
        objTDSP_PMT_TERM.FDISP_ID = Me.Name                         '画面ID     ｾｯﾄ
        objTDSP_PMT_TERM.FCTRL_ID = cmdButton.Name                  'ｺﾝﾄﾛｰﾙID   ｾｯﾄ
        intRet = objTDSP_PMT_TERM.GET_TDSP_PMT_TERM(False)          '情報取得
        If intRet = RetCode.OK Then
            intFOPE_FLAG_Term = objTDSP_PMT_TERM.FOPE_FLAG
        Else
            intFOPE_FLAG_Term = gcintOPE_FLG
        End If

        '==================================
        '【ﾕｰｻﾞ別許可ﾏｽﾀ】
        '==================================
        Dim intFOPE_FLAG_User As Integer = 0        '操作ﾌﾗｸﾞ(ﾕｰｻﾞ別許可ﾏｽﾀ用)
        For jj As Integer = LBound(gcintFUSER_LEVEL) To UBound(gcintFUSER_LEVEL)
            '(ﾙｰﾌﾟ:与えられたﾕｰｻﾞﾚﾍﾞﾙ数)

            Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)
            objTDSP_PMT_USER.FUSER_DSP_LEVEL = gcintFUSER_LEVEL(jj)     'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
            objTDSP_PMT_USER.FDISP_ID = Me.Name                         '画面ID
            objTDSP_PMT_USER.FCTRL_ID = cmdButton.Name                  'ｺﾝﾄﾛｰﾙID
            intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)          '取得
            If intRet = RetCode.OK Then
                intFOPE_FLAG_User = objTDSP_PMT_USER.FOPE_FLAG
            Else
                intFOPE_FLAG_User = gcintOPE_FLG
            End If
            If intFOPE_FLAG_User = FOPE_FLAG_SON Then Exit For

        Next

        '==================================
        'ﾎﾞﾀﾝﾏｽｸ
        '==================================
        If intFOPE_FLAG_Term = FOPE_FLAG_SON And intFOPE_FLAG_User = FOPE_FLAG_SON And blnEnabled = True Then
            blnResult = True
        Else
            blnResult = False
        End If


        '**********************************************
        'ﾌｧﾝｸｼｮﾝｷｰのEnabled
        '**********************************************
        Select Case cmdButton.Name
            Case Me.cmdF1.Name
                mblnFKey(cmd.F1) = blnResult
            Case Me.cmdF2.Name
                mblnFKey(cmd.F2) = blnResult
            Case Me.cmdF3.Name
                mblnFKey(cmd.F3) = blnResult
            Case Me.cmdF4.Name
                mblnFKey(cmd.F4) = blnResult
            Case Me.cmdF5.Name
                mblnFKey(cmd.F5) = blnResult
            Case Me.cmdF6.Name
                mblnFKey(cmd.F6) = blnResult
            Case Me.cmdF7.Name
                mblnFKey(cmd.F7) = blnResult
            Case Me.cmdF8.Name
                mblnFKey(cmd.F8) = blnResult
            Case Me.cmdMsgChk.Name
                mblnFKey(cmd.F10) = blnResult
        End Select


        '**********************************************
        'ｺﾝﾄﾛｰﾙﾎﾞﾀﾝのEnabled
        '**********************************************
        cmdButton.Enabled = blnResult                   'ｺﾝﾄﾛｰﾙﾎﾞﾀﾝ         のEnabled
        If Not IsNull(strText) Then
            cmdButton.Text = strText                    'ｺﾝﾄﾛｰﾙﾎﾞﾀﾝ         のText
        End If


    End Sub
#End Region
#Region "  Menuﾎﾞﾀﾝ全般Enabled False "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Menuﾎﾞﾀﾝ全般Enabled Falseにする
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub CmdEnabledChangeMenu()
 
        Call CmdEnabledChange(cmd01, False)         'Menu01ﾎﾞﾀﾝ
        Call CmdEnabledChange(cmd02, False)         'Menu02ﾎﾞﾀﾝ
        Call CmdEnabledChange(cmd03, False)         'Menu03ﾎﾞﾀﾝ
        Call CmdEnabledChange(cmd04, False)         'Menu04ﾎﾞﾀﾝ
        Call CmdEnabledChange(cmd05, False)         'Menu05ﾎﾞﾀﾝ
        Call CmdEnabledChange(cmd06, False)         'Menu06ﾎﾞﾀﾝ
        Call CmdEnabledChange(cmd07, False)         'Menu07ﾎﾞﾀﾝ
        Call CmdEnabledChange(cmd08, False)         'Menu08ﾎﾞﾀﾝ
        Call CmdEnabledChange(cmd09, False)         'Menu09ﾎﾞﾀﾝ
        Call CmdEnabledChange(cmd10, False)         'Menu10ﾎﾞﾀﾝ

    End Sub
#End Region
#Region "  ﾎﾞﾀﾝ         のEnabled、Text "

    '*******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾞﾀﾝの「Enabled」、「Text」を変更する
    ''' </summary>
    ''' <param name="cmdButton">変更するﾎﾞﾀﾝｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="strDisp_ID">画面名</param>
    ''' <param name="blnEnabled">ﾎﾞﾀﾝの「Enabled」の設定</param>
    ''' <remarks>引数blnEnabledがtrueの場合、DBがFalseだったら表示しない引数blnEnabledがFalseの場合、DBがtrueだったら表示しない</remarks>
    ''' *******************************************************************************************************************
    Protected Sub CmdEnabledChangeButton(ByVal cmdButton As System.Windows.Forms.Button, _
                                         ByVal strDisp_ID As String, _
                                         ByVal blnEnabled As Boolean _
                                         )
        Dim intRet As RetCode                   '戻り値
        Dim blnResult As Boolean
        Dim strText As String



        '**********************************************************
        ' ﾎﾞﾀﾝ名取得
        '   【画面表示ﾏｽﾀ】
        '**********************************************************
        Dim objDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)
        objDSP_NAME.FDISP_ID = strDisp_ID               '画面ID     ｾｯﾄ
        objDSP_NAME.FCTRL_ID = cmdButton.Name           'ｺﾝﾄﾛｰﾙID   ｾｯﾄ
        intRet = objDSP_NAME.GET_TDSP_NAME(False)       '情報取得
        If intRet <> RetCode.OK Then
            'Call DisplayPopup(FRM_MSG_gobjComFuncFRM.ButtonTextSet_01, _
            '                  PopupFormType.Ok, _
            '                  PopupIconType.Err, _
            '                  "ID　：" & objDSP_NAME.FDISP_ID)
            Exit Sub
        End If
        strText = gobjComFuncFRM.StrIsChanged(objDSP_NAME.FOBJECT_NAME)        'ﾎﾞﾀﾝ名


        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ
        '**********************************************************
        '==================================
        '【端末別許可ﾏｽﾀ】
        '==================================
        Dim intFOPE_FLAG_Term As Integer = 0        '操作ﾌﾗｸﾞ(端末別許可ﾏｽﾀ用)
        Dim objTDSP_PMT_TERM As New TBL_TDSP_PMT_TERM(gobjOwner, gobjDb, Nothing)
        objTDSP_PMT_TERM.FTERM_KUBUN = gcintFTERM_KBN               '端末区分   ｾｯﾄ
        objTDSP_PMT_TERM.FDISP_ID = Me.Name                         '画面ID     ｾｯﾄ
        objTDSP_PMT_TERM.FCTRL_ID = cmdButton.Name                  'ｺﾝﾄﾛｰﾙID   ｾｯﾄ
        intRet = objTDSP_PMT_TERM.GET_TDSP_PMT_TERM(False)          '情報取得
        If intRet = RetCode.OK Then
            intFOPE_FLAG_Term = objTDSP_PMT_TERM.FOPE_FLAG
        Else
            intFOPE_FLAG_Term = gcintOPE_FLG
        End If

        '==================================
        '【ﾕｰｻﾞ別許可ﾏｽﾀ】
        '==================================
        Dim intFOPE_FLAG_User As Integer = 0        '操作ﾌﾗｸﾞ(ﾕｰｻﾞ別許可ﾏｽﾀ用)
        For jj As Integer = LBound(gcintFUSER_LEVEL) To UBound(gcintFUSER_LEVEL)
            '(ﾙｰﾌﾟ:与えられたﾕｰｻﾞﾚﾍﾞﾙ数)

            Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)
            objTDSP_PMT_USER.FUSER_DSP_LEVEL = gcintFUSER_LEVEL(jj)     'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
            objTDSP_PMT_USER.FDISP_ID = Me.Name                         '画面ID
            objTDSP_PMT_USER.FCTRL_ID = cmdButton.Name                  'ｺﾝﾄﾛｰﾙID
            intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)          '取得
            If intRet = RetCode.OK Then
                intFOPE_FLAG_User = objTDSP_PMT_USER.FOPE_FLAG
            Else
                intFOPE_FLAG_User = gcintOPE_FLG
            End If
            If intFOPE_FLAG_User = FOPE_FLAG_SON Then Exit For

        Next

        '==================================
        'ﾎﾞﾀﾝﾏｽｸ
        '==================================
        If intFOPE_FLAG_Term = FOPE_FLAG_SON And intFOPE_FLAG_User = FOPE_FLAG_SON And blnEnabled = True Then
            blnResult = True
        Else
            blnResult = False
        End If


        '**********************************************
        'ﾌｧﾝｸｼｮﾝｷｰのEnabled
        '**********************************************
        Select Case cmdButton.Name
            Case Me.cmdF1.Name
                mblnFKey(cmd.F1) = blnResult
            Case Me.cmdF2.Name
                mblnFKey(cmd.F2) = blnResult
            Case Me.cmdF3.Name
                mblnFKey(cmd.F3) = blnResult
            Case Me.cmdF4.Name
                mblnFKey(cmd.F4) = blnResult
            Case Me.cmdF5.Name
                mblnFKey(cmd.F5) = blnResult
            Case Me.cmdF6.Name
                mblnFKey(cmd.F6) = blnResult
            Case Me.cmdF7.Name
                mblnFKey(cmd.F7) = blnResult
            Case Me.cmdF8.Name
                mblnFKey(cmd.F8) = blnResult
            Case Me.cmdMsgChk.Name
                mblnFKey(cmd.F10) = blnResult
        End Select


        '**********************************************
        'ｺﾝﾄﾛｰﾙﾎﾞﾀﾝのVisible
        '**********************************************
        cmdButton.Visible = blnResult                       'ｺﾝﾄﾛｰﾙﾎﾞﾀﾝ         のVisible
        If Not IsNull(strText) Then
            cmdButton.Text = strText                        'ｺﾝﾄﾛｰﾙﾎﾞﾀﾝ         のText
        End If


    End Sub
#End Region
#Region "  自身ｵｰﾌﾟﾝ処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 自身ｵｰﾌﾟﾝ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeShow()


        '*************************************************
        ' ﾀｲﾏｰ有効
        '*************************************************
        tmrTime.Enabled = True
        tmrOpeMsg.Enabled = True
        tmrTest_1.Enabled = True

        '*************************************************
        ' 見える
        '*************************************************
        Me.Visible = True


    End Sub
#End Region
#Region "  自身ｸﾛｰｽﾞ処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 自身ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeClose()


        '*************************************************
        ' ﾀｲﾏｰ無効
        '*************************************************
        tmrTime.Enabled = False
        tmrOpeMsg.Enabled = False
        tmrBlink.Enabled = False
        tmrTest_1.Enabled = False


        '*************************************************
        ' 各画面ｸﾛｰｽﾞ処理
        '*************************************************
        Call CloseChild()


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


        If gcintDSPLOGIN_FLG = FLAG_OFF Then
            '(ﾛｸﾞｲﾝ画面不要の場合)
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
                Me.Close()
                Me.Dispose()
            End If


        Else
            '(ﾛｸﾞｲﾝ画面要の場合)
            '*******************************************************
            'ｼｬｯﾄﾀﾞｳﾝor画面ｸﾛｰｽﾞ処理
            '*******************************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_100001, Me)

        End If

    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓FlexGrid→DataGridView移行

#Region "  ｸﾞﾘｯﾄﾞ表示処理1                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示処理1
    ''' </summary>
    ''' <param name="objGrid"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub grdListDisplaySub(ByRef objGrid As GamenCommon.cmpMDataGrid)

        Call grdListDisplayChild()

    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示処理2                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示処理2
    ''' </summary>
    ''' <param name="objGrid"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub grdListDisplaySub2(ByRef objGrid As GamenCommon.cmpMDataGrid)

        Call grdListDisplayChild2()

    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示処理3                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示処理3
    ''' </summary>
    ''' <param name="objGrid"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub grdListDisplaySub3(ByRef objGrid As GamenCommon.cmpMDataGrid)

        Call grdListDisplayChild3()

    End Sub
#End Region

    '↑↑↑FlexGrid→DataGridView移行
    '**********************************************************************************************
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
#Region "　開発者ﾂｰﾙｸﾘｯｸ                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 開発者ﾂｰﾙｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDevelopment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDevelopment.Click
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