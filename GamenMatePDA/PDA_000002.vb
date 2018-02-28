'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PDA画面親ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************


#Region "  Imports                          "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMatePDA.clsComFuncPDA
#End Region

Public Class PDA_000002

#Region "　共通変数、共通定数"
    '***********************************************************************************************
    ' 共通変数
    '***********************************************************************************************
    Private mblnFKey(4) As Boolean     '(1): F1 ～　(4): F4
    Protected mblnClose As Boolean      'ｸﾛｰｽﾞ許可ﾌﾗｸﾞ

    '-------------------------------------------------------
    ' 列挙体
    '-------------------------------------------------------
    Enum cmd
        F1
        F2
        F3
        F4
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
        'ﾗﾍﾞﾙ初期化
        '**********************************************************
        lblUserName.Text = gcstrFUSER_NAME          'ﾕｰｻﾞ名表示
        lblPlaceName.Text = gcstrFTERM_NAME         '作業場所表示


        '**********************************************************
        '共通変数初期化
        '**********************************************************
        mblnClose = False                        ' ｸﾛｰｽﾞ許可ﾌﾗｸﾞ


        '**********************************************************
        ' ﾎﾞﾀﾝ初期化
        '**********************************************************
        ' ﾌｧﾝｸｼｮﾝｷｰ
        For ii As cmd = cmd.F1 To cmd.F4
            mblnFKey(ii) = False
        Next

        ' ﾎﾞﾀﾝ位置（念の為）
        cmdF1.Location = New Point(10, 592)
        cmdF2.Location = New Point(117, 592)
        cmdF3.Location = New Point(260, 592)
        cmdF4.Location = New Point(367, 592)


        '**********************************************************
        ' ﾌｫｰﾑ名取得
        '**********************************************************
        Dim objTDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)

        objTDSP_NAME.FDISP_ID = Me.Name                 '画面ID     ｾｯﾄ
        objTDSP_NAME.FCTRL_ID = FCTRL_ID_SKOTEI          'ｺﾝﾄﾛｰﾙID     ｾｯﾄ
        intRet = objTDSP_NAME.GET_TDSP_NAME(False)       '情報取得
        If intRet <> RetCode.OK Then
            Call gobjComFuncPDA.DisplayPopup(FRM_MSG_BUTTONTEXTSET_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Err, _
                              "ID　：" & objTDSP_NAME.FDISP_ID)
            Exit Sub
        End If

        '###と改行を消去
        Dim strTitle As String
        strTitle = Replace(objTDSP_NAME.FOBJECT_NAME, REPLACE_STRING_01, "")
        strTitle = Replace(strTitle, vbCrLf, "")

        lblTitle.Text = strTitle                        'ﾀｲﾄﾙ   を表示
        Call gobjComFuncPDA.AddToLog_frm(lblTitle.Text & "に展開")


        '**********************************************************
        ' ﾎﾞﾀﾝ設定
        '**********************************************************
        Call CmdEnabledChangeButton(cmdF1, Me.Name, True)                  'F1ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF2, Me.Name, True)                  'F2ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF3, Me.Name, True)                  'F3ﾎﾞﾀﾝ
        Call CmdEnabledChangeButton(cmdF4, Me.Name, True)                  'F4ﾎﾞﾀﾝ


        '*************************************************
        ' 離席ﾎﾞﾀﾝ設定
        '*************************************************
        If gcintAfkFlg = FLAG_OFF Then
            Me.btnAFK.Text = ""
            Me.btnAFK.Visible = False
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


    End Sub
#End Region
#Region "　離席ﾎﾞﾀﾝ                     押下処理"
    Protected Sub btnAFKProc()

        '***************************************************************
        '離席処理
        '***************************************************************
        Call gobjComFuncPDA.AfkProc(Me)

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
    Private Sub KeyDownProc(ByVal e As System.Windows.Forms.KeyEventArgs)

        '**************************************************
        'Alt ｷｰが押下されたか判断
        '**************************************************
        If e.Alt = True Then Exit Sub
        If e.Shift = True Then Exit Sub
        If e.Control = True Then Exit Sub


        '**************************************************
        '押下されたｷｰﾎﾞｰﾄﾞ判断
        '**************************************************
        Select Case e.KeyCode
            Case Windows.Forms.Keys.F1
                If cmdF1.Enabled = True And _
                   mblnFKey(cmd.F1) = True Then
                    Call cmdF1_Click(Nothing, Nothing)
                End If

            Case Windows.Forms.Keys.F2
                If cmdF2.Enabled = True And _
                   mblnFKey(cmd.F2) = True Then
                    Call cmdF2_Click(Nothing, Nothing)
                End If

            Case Windows.Forms.Keys.F3
                If cmdF3.Enabled = True And _
                   mblnFKey(cmd.F3) = True Then
                    Call cmdF3_Click(Nothing, Nothing)
                End If

            Case Windows.Forms.Keys.F4
                If cmdF4.Enabled = True And _
                   mblnFKey(cmd.F4) = True Then
                    Call cmdF4_Click(Nothing, Nothing)
                End If

        End Select

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

            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncPDA.PassWordCheck(Me.Name, cmdF1.Name)
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

            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncPDA.PassWordCheck(Me.Name, cmdF2.Name)
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

            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncPDA.PassWordCheck(Me.Name, cmdF3.Name)
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

            '********************************************
            'ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
            '********************************************
            Dim blnRet As Boolean
            blnRet = gobjComFuncPDA.PassWordCheck(Me.Name, cmdF4.Name)
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
#Region " 「離席」ﾎﾞﾀﾝ      ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「離席」ﾎﾞﾀﾝ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub btnAFK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFK.Click
        Try

            btnAFKProc()

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
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｸﾛｰｽﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PDA_000002_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            '****************************************
            'ｸﾛｰｽﾞ許可ﾌﾗｸﾞ = ON
            '****************************************
            If FLAG_ON = gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SGS000000_001) Then
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
    Private Sub PDA_000002_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        Try

            '*************************************************
            ' 色々判断
            '*************************************************
            If Me.Name = "PDA_000002" Then Exit Sub


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

            gobjComFuncPDA.ComError_frm(ex)

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
        objDSP_NAME.FCTRL_ID = cmdButton.Name         'ｺﾝﾄﾛｰﾙID   ｾｯﾄ
        intRet = objDSP_NAME.GET_TDSP_NAME(False)     '情報取得
        If intRet <> RetCode.OK Then
            'Call gobjComFuncPDA.DisplayPopup(FRM_MSG_BUTTONTEXTSET_01, _
            '                  PopupFormType.Ok, _
            '                  PopupIconType.Err, _
            '                  "ID　：" & objDSP_NAME.FDISP_ID)
            Exit Sub
        End If
        strText = gobjComFuncPDA.StrIsChanged(objDSP_NAME.FOBJECT_NAME)        'ﾎﾞﾀﾝ名


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
#Region "  自身ｵｰﾌﾟﾝ処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 自身ｵｰﾌﾟﾝ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeShow()

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
        ' 各画面ｸﾛｰｽﾞ処理
        '*************************************************
        Call CloseChild()

    End Sub
#End Region

End Class
