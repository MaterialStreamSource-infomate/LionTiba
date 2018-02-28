'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑｼｽﾃﾑ固有機能
' 【機能】二重格納対応操作画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_202001

#Region "　共通変数　                               "

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrFEQ_ID As String        'ｸﾚｰﾝID
    Private mstrFPALLET_ID As String    'ﾊﾟﾚｯﾄID
    Private mintFTRK_BUF_NO As Integer  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mintGamenMode As Integer    '画面ﾓｰﾄﾞ

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        ToChange_Click                  '
        Manual_Click                    '詳細表示ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum


#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' ======================================
    ''' <summary>ｸﾚｰﾝID</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFEQ_ID() As String
        Get
            Return mstrFEQ_ID
        End Get
        Set(ByVal value As String)
            mstrFEQ_ID = value
        End Set
    End Property
    ''' ======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFPALLET_ID() As String
        Get
            Return mstrFPALLET_ID
        End Get
        Set(ByVal value As String)
            mstrFPALLET_ID = value
        End Set
    End Property
    ''' ======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFTRK_BUF_NO() As Integer
        Get
            Return mintFTRK_BUF_NO
        End Get
        Set(ByVal value As Integer)
            mintFTRK_BUF_NO = value
        End Set
    End Property
    ''' =======================================
    ''' <summary>画面ﾓｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userGamenMode() As Integer
        Get
            Return mintGamenMode
        End Get
        Set(ByVal Value As Integer)
            mintGamenMode = Value
        End Set
    End Property

#End Region
#Region "　ｲﾍﾞﾝﾄ　                                  "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_202001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_202001_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　行先変更指令ﾎﾞﾀﾝｸﾘｯｸ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 行先変更指令ﾎﾞﾀﾝｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdToChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToChange.Click
        Try

            Call cmdToChange_ClickProcess()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　手動払い出しﾎﾞﾀﾝｸﾘｯｸ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 手動払い出しﾎﾞﾀﾝｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdManual.Click
        Try

            Call cmdManual_ClickProcess()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()


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
    Private Sub LoadProcess()

        Dim udtRet As RetPopup                  '戻り値
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Dim strFEQ_ID_CRANE(0) As String        'ｸﾚｰﾝIDｾｯﾄ
        strFEQ_ID_CRANE(0) = mstrFEQ_ID         'ｸﾚｰﾝIDｾｯﾄ


        '**********************************************************
        ' 画面初期化
        '**********************************************************
        If mintGamenMode = GAMENMODE_NIJYU Then
            '(二重格納対応操作画面のとき)
            Me.Text = "二重格納対応操作"
        Else
            '(荷姿不一致対応操作画面のとき)
            Me.Text = "荷姿不一致対応操作"
        End If

        '======================================
        'ﾃｷｽﾄﾎﾞｯｸｽ初期化
        '======================================
        txtRAC_RETU_TO.Text = ""
        txtRAC_REN_TO.Text = ""
        txtRAC_DAN_TO.Text = ""

        '**********************************************************
        ' ｸﾚｰﾝﾏｽﾀ情報取得
        '**********************************************************
        Dim objTBL_TMST_CRANE As New TBL_TMST_CRANE(gobjOwner, gobjDb, Nothing)
        objTBL_TMST_CRANE.FEQ_ID = mstrFEQ_ID       'ｸﾚｰﾝID
        Call objTBL_TMST_CRANE.GET_TMST_CRANE(False) 'ｸﾚｰﾝ情報取得

        '**********************************************************
        ' 在庫情報取得
        '**********************************************************
        Dim objTBL_TRST_STOCK As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
        objTBL_TRST_STOCK.FPALLET_ID = mstrFPALLET_ID           'ﾊﾟﾚｯﾄID
        Call objTBL_TRST_STOCK.GET_TRST_STOCK_KONSAI(False)     '取得

        '************************************************
        '引当ﾀｲﾌﾟ特定ﾏｽﾀ        取得
        '************************************************
        Dim objTMST_SP_RES_TYPE As New TBL_TMST_SP_RES_TYPE(Owner, gobjDb, Nothing)
        Dim objTemplateServer As New clsTemplateServer(gobjOwner, gobjDb, Nothing)
        '↓↓↓↓↓↓************************************************************************************************************
        'CommentMate:A.Noto 2012/06/26 とりあえずｺﾒﾝﾄｱｳﾄ
        ''objTMST_SP_RES_TYPE.FCONDITION01 = objTemplateServer.GetFRAC_FORMFromXRACK_RESERVED_CD(objTBL_TRST_STOCK.ARYME(0).XRACK_RESERVED_CD)    '条件01(棚形状種別)
        ''objTMST_SP_RES_TYPE.FCONDITION02 = XRAC_PRIORITY_JPRIORITY                                                                              '条件02(棚優先)
        '↑↑↑↑↑↑************************************************************************************************************
        objTMST_SP_RES_TYPE.GET_TMST_SP_RES_TYPE()

        '**********************************************************
        ' 移動先ﾊﾞｯﾌｧの空棚引当
        '**********************************************************
        Dim objSVR_100201 As New SVR_100201(Owner, gobjDb, Nothing)         '空棚引当ｸﾗｽ
        objSVR_100201.FTRK_BUF_NO = objTBL_TMST_CRANE.FTRK_BUF_NO           'ﾊﾞｯﾌｧ№
        ''objSVR_100201.FRAC_FORM = intFRAC_FORM                              '棚形状種別
        objSVR_100201.FRES_TYPE = objTMST_SP_RES_TYPE.FRES_TYPE     '引当ﾀｲﾌﾟ
        objSVR_100201.FPALLET_ID = mstrFPALLET_ID                           'ﾊﾟﾚｯﾄID
        objSVR_100201.FEQ_ID_CRANE = strFEQ_ID_CRANE                        'ｸﾚｰﾝID
        intRet = objSVR_100201.FIND_TANA_AKI            '特定
        If intRet = RetCode.NotFound Then
            '(見つからない場合)

            '*******************************************************
            '確認ﾒｯｾｰｼﾞ
            '*******************************************************
            Dim strMessage As String
            strMessage = ""
            strMessage &= FRM_MSG_FRM202001_03
            udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok, PopupIconType.Quest)

            txtRAC_RETU_TO.Text = ""
            txtRAC_REN_TO.Text = ""
            txtRAC_DAN_TO.Text = ""

            cmdCancel_ClickProcess()    '画面を閉じる
            Exit Sub

        End If

        '**********************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
        '**********************************************************
        Dim objTPRG_TRK_BUF_SOUKO As New TBL_TPRG_TRK_BUF(Owner, gobjDb, Nothing)           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙ
        objTPRG_TRK_BUF_SOUKO.FTRK_BUF_NO = objSVR_100201.FTRK_BUF_NO                       'ﾊﾞｯﾌｧ№
        objTPRG_TRK_BUF_SOUKO.FTRK_BUF_ARRAY = objSVR_100201.FTRK_BUF_ARRAY                 '配列№
        intRet = objTPRG_TRK_BUF_SOUKO.GET_TPRG_TRK_BUF(False)                              '特定
        If intRet = RetCode.NotFound Then
            '(見つからない場合)
            strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_SOUKO.FTRK_BUF_NO) & "  ,配列№:" & TO_STRING(objTPRG_TRK_BUF_SOUKO.FTRK_BUF_ARRAY) & "]"
            Throw New UserException(strMsg)
        End If

        '**********************************************************
        '変更ｱﾄﾞﾚｽ設定
        '**********************************************************
        txtRAC_RETU_TO.Text = objTPRG_TRK_BUF_SOUKO.FRAC_RETU
        txtRAC_REN_TO.Text = objTPRG_TRK_BUF_SOUKO.FRAC_REN
        txtRAC_DAN_TO.Text = objTPRG_TRK_BUF_SOUKO.FRAC_DAN



    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ開放
        '**********************************************************


    End Sub
#End Region
#Region "  行先変更指令 ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 行先変更指令 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdToChange_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.ToChange_Click) = False Then
            Exit Sub
        End If


        '********************************************************************
        '電文送信
        '********************************************************************
        Call SendSocket01(menmCheckCase.ToChange_Click)


    End Sub
#End Region
#Region "  手動払い出し ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 手動払い出し ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdManual_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Manual_Click) = False Then
            Exit Sub
        End If


        '********************************************************************
        '電文送信
        '********************************************************************
        Call SendSocket01(menmCheckCase.Manual_Click)


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

        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.ToChange_Click
                '(行先変更指令ｸﾘｯｸ時)

                '======================================
                '入力ﾁｪｯｸ
                '======================================
                If txtRAC_RETU_TO.Text = "" Then
                    '(列が入力されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRAC_RETU_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If
                If txtRAC_REN_TO.Text = "" Then
                    '(連が入力されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRAC_REN_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If
                If txtRAC_DAN_TO.Text = "" Then
                    '(段が入力されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRAC_DAN_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '======================================
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
                '======================================
                Dim intRet As RetCode                   '戻り値
                Dim strMessage As String = ""           'ﾒｯｾｰｼﾞ
                Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, gobjDb, Nothing)             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙ
                objTPRG_TRK_BUF.FTRK_BUF_NO = mintFTRK_BUF_NO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF.FRAC_RETU = txtRAC_RETU_TO.Text         '列
                objTPRG_TRK_BUF.FRAC_REN = txtRAC_REN_TO.Text           '連
                objTPRG_TRK_BUF.FRAC_DAN = txtRAC_DAN_TO.Text           '段
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_TANA()        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [棚番から]
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM202001_04, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If
                '-------------------------------
                '空棚ﾁｪｯｸ
                '-------------------------------
                If objTPRG_TRK_BUF.FRES_KIND <> FRES_KIND_SAKI Then
                    '(空棚以外の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM202001_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                '----------------------------
                '禁止棚ﾁｪｯｸ
                '----------------------------
                If objTPRG_TRK_BUF.FREMOVE_KIND <> FREMOVE_KIND_SNORMAL Then
                    '(空棚以外の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM202001_07, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                '----------------------------
                'ｸﾚｰﾝﾁｪｯｸ
                '----------------------------
                Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, gobjDb, Nothing)             'ｸﾚｰﾝﾏｽﾀ
                objTMST_CRANE.FEQ_ID = mstrFEQ_ID
                intRet = objTMST_CRANE.GET_TMST_CRANE(False)
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    Throw New UserException(ERRMSG_NOTFOUND_TMST_CRANE & "[設備ID:" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]")
                End If
                If Not (objTMST_CRANE.FCRANE_ROW1 <= objTPRG_TRK_BUF.FRAC_RETU And objTPRG_TRK_BUF.FRAC_RETU <= objTMST_CRANE.FCRANE_ROW2) Then
                    '(ｸﾚｰﾝが違う場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM202001_05, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.Manual_Click
                '(手動払い出しｸﾘｯｸ時)

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
    Private Sub SendSocket01(ByVal udtCheck_Case As menmCheckCase)

        '※画面ﾗﾍﾞﾙに確認ﾒｯｾｰｼﾞが表示されているため不要
        ' ''*******************************************************
        ' ''確認ﾒｯｾｰｼﾞ
        ' ''*******************************************************
        ''Dim udtRet As RetPopup
        ''Dim strMessage As String
        ''strMessage = ""
        ''strMessage &= $$$$$$$$$$$$$$$$$$$$$
        ''udtRet = DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        ''If udtRet <> RetPopup.OK Then
        ''    Exit Sub
        ''End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strXSIZI_KUBUN As String = ""       '指示区分(行先変更"01"、手動払い出し"03"、空出庫"12")
        Dim strFTRK_BUF_NO As String = ""       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim strFTRK_BUF_ARRAY As String = ""    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列
        Dim strST_OUT As String = ""            '出庫先ST(未使用)
        Dim strFEQ_ID As String = ""            '設備ID
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200202           'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        '**********************************************************
        ' ｸﾚｰﾝﾏｽﾀ情報取得
        '**********************************************************
        Dim objTBL_TMST_CRANE As New TBL_TMST_CRANE(gobjOwner, gobjDb, Nothing)
        objTBL_TMST_CRANE.FEQ_ID = mstrFEQ_ID       'ｸﾚｰﾝID
        Call objTBL_TMST_CRANE.GET_TMST_CRANE(False) 'ｸﾚｰﾝ情報取得

        Select Case udtCheck_Case
            Case menmCheckCase.ToChange_Click
                '(行先変更指令の場合)
                If mintGamenMode = GAMENMODE_NIJYU Then
                    '(二重格納対応操作画面のとき)
                    strXSIZI_KUBUN = TO_STRING(FORMAT_DSP_DSPSIZI_KUBUN_TOCHANGE)          '指示区分
                Else
                    '(荷姿不一致対応操作画面のとき)
                    strXSIZI_KUBUN = TO_STRING(FORMAT_DSP_DSPSIZI_KUBUN_TOCHANGE_FUICCHI)          '指示区分
                End If

                '**********************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
                '**********************************************************
                Dim intRet As RetCode                   '戻り値
                Dim udtRet As RetPopup                  'ﾒｯｾｰｼﾞ戻り値
                Dim strMessage As String = ""           'ﾒｯｾｰｼﾞ
                Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, gobjDb, Nothing)             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙ
                objTPRG_TRK_BUF.FTRK_BUF_NO = objTBL_TMST_CRANE.FTRK_BUF_NO                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF.FRAC_RETU = txtRAC_RETU_TO.Text         '列
                objTPRG_TRK_BUF.FRAC_REN = txtRAC_REN_TO.Text           '連
                objTPRG_TRK_BUF.FRAC_DAN = txtRAC_DAN_TO.Text           '段
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_TANA()        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [棚番から]
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMessage = ""
                    strMessage &= FRM_MSG_FRM202001_04
                    udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok, PopupIconType.Quest)
                    Exit Sub
                End If

                strFTRK_BUF_NO = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                strFTRK_BUF_ARRAY = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列

            Case menmCheckCase.Manual_Click
                '(手動払い出しの場合)
                If mintGamenMode = GAMENMODE_NIJYU Then
                    '(二重格納対応操作画面のとき)
                    strXSIZI_KUBUN = TO_STRING(FORMAT_DSP_DSPSIZI_KUBUN_MANUAL)                     '指示区分
                Else
                    '(荷姿不一致対応操作画面のとき)
                    strXSIZI_KUBUN = TO_STRING(FORMAT_DSP_DSPSIZI_KUBUN_MANUAL_FUICCHI)            '指示区分
                End If

                strFTRK_BUF_NO = ""                                                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                strFTRK_BUF_ARRAY = ""                                                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列

        End Select

        strFEQ_ID = TO_STRING(mstrFEQ_ID)                                               'ｸﾚｰﾝID

        objTelegram.SETIN_DATA("DSPSIZI_KUBUN", strXSIZI_KUBUN)         '指示区分
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFTRK_BUF_NO)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFTRK_BUF_ARRAY)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列
        objTelegram.SETIN_DATA("DSPST_OUT", strST_OUT)                  '出庫ST
        objTelegram.SETIN_DATA("DSPEQ_ID", strFEQ_ID)                   '設備ID
        objTelegram.SETIN_DATA("DSPPALLET_ID", mstrFPALLET_ID)          'ﾊﾟﾚｯﾄID

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

        'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = ""
        If udtCheck_Case = menmCheckCase.ToChange_Click Then
            strErrMsg = FRM_MSG_FRM202001_01
        ElseIf udtCheck_Case = menmCheckCase.Manual_Click Then
            strErrMsg = FRM_MSG_FRM202001_02
        End If
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