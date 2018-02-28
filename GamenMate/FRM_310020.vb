'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】端数生産入庫設定画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_310020
#Region "　共通変数　                               "

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFTRK_BUF_NO As String                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    Protected mblnMenuFlg As Boolean = True             'ﾒﾆｭｰ呼び出しﾌﾗｸﾞ

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mstrFHINMEI_CD As String = ""               '品名ｺｰﾄﾞ
    Private mstrXHINMEI_CD As String = ""               '品名記号
    Private mstrFHINMEI As String = ""                  '品名
    Private mstrFARRIVE_DT As String = ""               '在庫発生日時
    Private mstrXPROD_LINE As String = ""               '生産ﾗｲﾝNo.
    Private mstrXPROD_LINE_Disp As String = ""          '生産ﾗｲﾝNo.(表示用)
    Private mstrXMAKER_CD As String = ""                'ﾒｰｶｰｺｰﾄﾞ
    Private mstrXKENSA_KUBUN As String = ""             '検査区分
    Private mstrXKENSA_KUBUN_Disp As String = ""        '検査区分(表示用)
    Private mstrFHORYU_KUBUN As String = ""             '保留区分
    Private mstrFHORYU_KUBUN_Disp As String = ""        '保留区分(表示用)
    Private mstrFIN_KUBUN As String = ""                '入庫区分
    Private mstrFIN_KUBUN_Disp As String = ""           '入庫区分(表示用)
    Private mstrXKENPIN_KUBUN As String = ""            '検品区分
    Private mstrXKENPIN_KUBUN_Disp As String = ""       '検品区分(表示用)

    Private mintFNUM_IN_PL As Integer                   'PL毎積載量

    Private mintXPROGRESS As Integer = -1               '進捗状況

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        NyukoBtn_Click              '入庫設定
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

    ''' =======================================
    ''' <summary>ﾒﾆｭｰ呼び出しﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userMenuFlg() As Boolean
        Get
            Return mblnMenuFlg
        End Get
        Set(ByVal value As Boolean)
            mblnMenuFlg = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFTRK_BUF_NO() As String
        Get
            Return mstrFTRK_BUF_NO
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO = value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　入庫STｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_NYUUKO.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                '**********************************************************
                ' ﾗﾍﾞﾙ 初期化
                '**********************************************************
                lblFHINMEI_CD.Text = ""
                lblXHINMEI_CD.Text = ""
                lblFHINMEI.Text = ""
                lblFARRIVE_DT.Text = ""
                lblXPROD_LINE.Text = ""
                lblXMAKER_CD.Text = ""
                lblXKENSA_KUBUN.Text = ""
                lblFHORYU_KUBUN.Text = ""
                lblFIN_KUBUN.Text = ""
                lblXKENPIN_KUBUN.Text = ""
                txtHasuu_VOL.Text = ""
                cboFULL_PL.SelectedIndex = 0

                If cboFTRK_BUF_NO_NYUUKO.Text <> "" Then

                    '**********************************************************
                    ' ﾃﾞｰﾀ取得
                    '**********************************************************
                    Call Get_XSTS_PRODUCT_IN_Value(cboFTRK_BUF_NO_NYUUKO.SelectedValue)

                    '**********************************************************
                    ' 品目ｺｰﾄﾞﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblFHINMEI_CD.Text = mstrFHINMEI_CD

                    '**********************************************************
                    ' 品目記号ﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblXHINMEI_CD.Text = mstrXHINMEI_CD

                    '**********************************************************
                    ' 品名ﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblFHINMEI.Text = mstrFHINMEI

                    '**********************************************************
                    ' 在庫発生日時ﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblFARRIVE_DT.Text = mstrFARRIVE_DT

                    '**********************************************************
                    ' 生産ﾗｲﾝNo.ﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblXPROD_LINE.Text = mstrXPROD_LINE_Disp

                    '**********************************************************
                    ' ﾒｰｶｰｺｰﾄﾞﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblXMAKER_CD.Text = mstrXMAKER_CD

                    '**********************************************************
                    ' 検査区分ﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblXKENSA_KUBUN.Text = mstrXKENSA_KUBUN_Disp

                    '**********************************************************
                    ' 保留区分ﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblFHORYU_KUBUN.Text = mstrFHORYU_KUBUN_Disp

                    '**********************************************************
                    ' 入庫区分ﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblFIN_KUBUN.Text = mstrFIN_KUBUN_Disp

                    '**********************************************************
                    ' 検品区分ﾗﾍﾞﾙ ｾｯﾄ
                    '**********************************************************
                    lblXKENPIN_KUBUN.Text = mstrXKENPIN_KUBUN_Disp

                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '===================================
        ' 入庫ST ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call MakeSeisanNyuukoST()

        '===================================
        ' ﾌﾙﾊﾟﾚｯﾄ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFULL_PL, True, 0)

        '**********************************************************
        ' ﾗﾍﾞﾙ 初期化
        '**********************************************************
        lblFHINMEI_CD.Text = ""
        lblXHINMEI_CD.Text = ""
        lblFHINMEI.Text = ""
        lblFARRIVE_DT.Text = ""
        lblXPROD_LINE.Text = ""
        lblXMAKER_CD.Text = ""
        lblXKENSA_KUBUN.Text = ""
        lblFHORYU_KUBUN.Text = ""
        lblFIN_KUBUN.Text = ""
        lblXKENPIN_KUBUN.Text = ""
        txtHasuu_VOL.Text = ""
        cboFULL_PL.SelectedIndex = 0


        If mblnMenuFlg = True Then
            '(ﾒﾆｭｰから呼出しの場合)
            Call CmdEnabledChange(cmdF4, False)                     '戻るﾎﾞﾀﾝ
        Else
            '(子画面として呼出された場合)
            Call CmdEnabledChange(cmdF4, True)                     '戻るﾎﾞﾀﾝ
            Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般


            '**********************************************************
            ' ﾃﾞｰﾀ取得
            '**********************************************************
            Call Get_XSTS_PRODUCT_IN_Value(mstrFTRK_BUF_NO)

            '**********************************************************
            ' 入庫ST ｾｯﾄ
            '**********************************************************
            cboFTRK_BUF_NO_NYUUKO.SelectedValue = mstrFTRK_BUF_NO

            '**********************************************************
            ' 品目ｺｰﾄﾞﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblFHINMEI_CD.Text = mstrFHINMEI_CD

            '**********************************************************
            ' 品目記号ﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblXHINMEI_CD.Text = mstrXHINMEI_CD

            '**********************************************************
            ' 品名ﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblFHINMEI.Text = mstrFHINMEI

            '**********************************************************
            ' 在庫発生日時ﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblFARRIVE_DT.Text = mstrFARRIVE_DT

            '**********************************************************
            ' 生産ﾗｲﾝNo.ﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblXPROD_LINE.Text = mstrXPROD_LINE_Disp

            '**********************************************************
            ' ﾒｰｶｰｺｰﾄﾞﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblXMAKER_CD.Text = mstrXMAKER_CD

            '**********************************************************
            ' 検査区分ﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblXKENSA_KUBUN.Text = mstrXKENSA_KUBUN_Disp

            '**********************************************************
            ' 保留区分ﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblFHORYU_KUBUN.Text = mstrFHORYU_KUBUN_Disp

            '**********************************************************
            ' 入庫区分ﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblFIN_KUBUN.Text = mstrFIN_KUBUN_Disp

            '**********************************************************
            ' 検品区分ﾗﾍﾞﾙ ｾｯﾄ
            '**********************************************************
            lblXKENPIN_KUBUN.Text = mstrXKENPIN_KUBUN_Disp
        End If


        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        cboFTRK_BUF_NO_NYUUKO.Dispose()
        lblFHINMEI_CD.Dispose()
        lblXHINMEI_CD.Dispose()
        lblFHINMEI.Dispose()
        lblFARRIVE_DT.Dispose()
        lblXPROD_LINE.Dispose()
        lblXMAKER_CD.Dispose()
        lblXKENSA_KUBUN.Dispose()
        lblFHORYU_KUBUN.Dispose()
        lblFIN_KUBUN.Dispose()
        lblXKENPIN_KUBUN.Dispose()
        txtHasuu_VOL.Dispose()
        cboFULL_PL.Dispose()

    End Sub
#End Region
#Region "  F1(入庫)         ﾎﾞﾀﾝ押下処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(入庫)     ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.NyukoBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket02_TE() = False Then
            Exit Sub
        End If

    End Sub
#End Region
#Region "  F4(戻る)  ﾎﾞﾀﾝ押下処理         　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(戻る) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '画面遷移
        '********************************************************************
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
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        ' ''Dim intRet As RetCode
        Dim strMsg As String = ""

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.NyukoBtn_Click
                '(入庫ﾎﾞﾀﾝｸﾘｯｸ時)

                '========================================
                '入庫ST
                '========================================
                If cboFTRK_BUF_NO_NYUUKO.Text = "" Then
                    '(未選択の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FTRK_BUF_NO_NYUUKO, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '進捗状況
                '========================================
                If mintXPROGRESS <> XPROGRESS_START Then
                    '(開始状態以外の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM310020_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '数量
                '========================================
                If txtHasuu_VOL.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM310020_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                If TO_DECIMAL(txtHasuu_VOL.Value) > mintFNUM_IN_PL Then
                    '(PL毎積載数より大きい時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM310020_09, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾌﾙﾊﾟﾚｯﾄ
                '========================================
                If cboFULL_PL.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM310020_08, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '搬送ﾊﾟﾚｯﾄ数
                '========================================
                If TO_INTEGER(txtHasuu_VOL.Text) = 0 And _
                    cboFULL_PL.SelectedIndex = 2 Then
                    '(端数0、ﾊﾟﾚｯﾄ無しの場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM310020_05, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '************************************************
                'ﾄﾗｯｷﾝｸﾞ            ﾁｪｯｸ
                '************************************************

                Dim intCountZaiko As Integer = 0
                Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)

                '=======================================
                '入庫ST ﾄﾗｯｷﾝｸﾞ
                '=======================================
                objTPRG_TRK_BUF.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue)    '入庫ST ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intCountZaiko = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT_ZAIKO()      '取得
                If intCountZaiko <> 0 Then
                    '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM310020_06, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Information)
                    Exit Select
                End If

                '=======================================
                'ｺﾝﾍﾞﾔ関連付け ﾄﾗｯｷﾝｸﾞ
                '=======================================
                Dim strST_FM As String                                      '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                Dim intRet As RetCode
                Dim objTMST_TRK As TBL_TMST_TRK                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
                objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
                objTMST_TRK.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue.ToString)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objTMST_TRK.GET_TMST_TRK(False)
                If intRet = RetCode.OK Then
                    '(読めたとき)
                    If IsNull(objTMST_TRK.XTRK_BUF_NO_CONV) = False Then
                        '(値がある時)
                        strST_FM = objTMST_TRK.XTRK_BUF_NO_CONV          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                    Else
                        '(値がない時)
                        strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                                 "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue.ToString) & "]"
                        Throw New System.Exception(strMsg)
                    End If
                Else
                    '(読めなかった時)
                    strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                             "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue.ToString) & "]"
                    Throw New System.Exception(strMsg)
                End If

                intCountZaiko = 0
                objTPRG_TRK_BUF.CLEAR_PROPERTY()
                objTPRG_TRK_BUF.FTRK_BUF_NO = strST_FM                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intCountZaiko = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT_ZAIKO()      '取得
                If intCountZaiko <> 0 Then
                    '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM310020_06, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Information)
                    Exit Select
                End If






                '************************************************
                ' 入庫要求           ﾁｪｯｸ
                '************************************************
                Dim intPattern As Integer   'ﾊﾟﾀｰﾝ

                If TO_INTEGER(txtHasuu_VOL.Text) > 0 And _
                    cboFULL_PL.SelectedValue = 0 Then
                    '(端数あり、満PLあり)
                    intPattern = 2

                ElseIf TO_INTEGER(txtHasuu_VOL.Text) = 0 And _
                    cboFULL_PL.SelectedValue = 0 Then
                    '(端数なし、満PLあり)
                    intPattern = 3

                ElseIf TO_INTEGER(txtHasuu_VOL.Text) > 0 And _
                    cboFULL_PL.SelectedValue = 1 Then
                    '(端数あり、満PLなし)
                    intPattern = 4

                End If

                If gobjComFuncFRM.Check_IN_HASU_FLAG(cboFTRK_BUF_NO_NYUUKO.SelectedValue, intPattern) = False Then
                    '(入庫要求がある場合)
                    strMsg = "選択された入庫STの入庫要求設定と" & vbCrLf & _
                             "搬送PLに誤りがあります。" & vbCrLf & _
                             "入庫設定してもよろしいですか？"
                    If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                        Exit Select
                    End If

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

#Region "  ｿｹｯﾄ送信02 (自動倉庫)                  "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket02_TE() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Dim strMsg As String = ""

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        strMsg = ""
        strMsg &= FRM_MSG_FRM310020_03
        udtRet = gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If

        '********************************************************************
        ' 入庫設定ﾃﾞｰﾀ
        '********************************************************************
        Dim strSndTlgrm() As String = Nothing               '送信電文文字列
        Dim intHairetu As Integer = 0                       '配列数

        Dim strDSPST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        Dim strDSPST_TO = ""                                '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        Dim strDSPPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
        Dim strDSPLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
        Dim strDSPHINMEI_CD = ""                            '品名ｺｰﾄﾞ
        Dim strDSPTR_VOL = ""                               '搬送管理量
        Dim strXDSPIN_KIND = ""                             '入庫種別
        Dim strXDSPIN_SITEI = ""                            '入庫指定
        Dim strDSPARRIVE_DT = ""                            '在庫発生日時
        Dim strXDSPPROD_LINE = ""                           '生産ﾗｲﾝ№
        Dim strXMAKER_CD = ""                               'ﾒｰｶｰｺｰﾄﾞ
        Dim strXDSPKENSA_KUBUN = ""                         '検査区分
        Dim strDSPHORYU_KUBUN = ""                          '保留区分
        Dim strDSPIN_KUBUN = ""                             '入庫区分
        Dim strXDSPKENPIN_KUBUN = ""                        '検品区分
        Dim strXDSPTANA_BLOCK = ""                          '棚ﾌﾞﾛｯｸ

        Dim strDSPTR_VOL_HASUU = ""                         '端数
        Dim blnHASUUFlag As Boolean = False                 '端数ﾌﾗｸﾞ

        Dim blnPareFlag As Boolean = False                  'ﾍﾟｱ入庫ﾌﾗｸﾞ

        Dim intALL_PL_Count As Integer = 0                  '搬送ﾊﾟﾚｯﾄ数

        Dim intPL_VOL As Integer
        Dim intHASUU_VOL As Integer

        '********************************************************************
        ' ﾊﾟﾚｯﾄ+端数ﾃﾞｰﾀｾｯﾄ 
        '********************************************************************
        If cboFULL_PL.SelectedValue = 0 Then
            intPL_VOL = 1
        Else
            intPL_VOL = 0
        End If

        intHASUU_VOL = TO_INTEGER(txtHasuu_VOL.Text)

        If intHASUU_VOL = 0 Then
            blnHASUUFlag = False        '端数無
            intALL_PL_Count = intPL_VOL
        Else
            blnHASUUFlag = True         '端数有
            intALL_PL_Count = intPL_VOL + 1
        End If

        '**********************************************************
        ' 搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№の特定
        '**********************************************************
        Dim strXTRK_BUF_NO_CONV As String
        Dim intRet As RetCode
        Dim objTMST_TRK As TBL_TMST_TRK                                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        objTMST_TRK.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue)        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        intRet = objTMST_TRK.GET_TMST_TRK(False)
        If intRet = RetCode.OK Then
            '(読めたとき)
            If IsNull(objTMST_TRK.XTRK_BUF_NO_CONV) = False Then
                '(値がある時)
                strXTRK_BUF_NO_CONV = objTMST_TRK.XTRK_BUF_NO_CONV          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            Else
                '(値がない時)
                strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                         "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue) & "]"
                Throw New System.Exception(strMsg)
            End If
        Else
            '(読めなかった時)
            strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                     "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue) & "]"
            Throw New System.Exception(strMsg)
        End If

        '**********************************************************
        ' 緊急入庫設定の確認
        '**********************************************************
        Dim objTBL_XSTS_PRODUCT_IN As TBL_XSTS_PRODUCT_IN                                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        objTBL_XSTS_PRODUCT_IN = New TBL_XSTS_PRODUCT_IN(gobjOwner, gobjDb, Nothing)
        objTBL_XSTS_PRODUCT_IN.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue)
        intRet = objTBL_XSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)
        If intRet = RetCode.OK Then
            '(読めたとき)
            If TO_STRING(objTBL_XSTS_PRODUCT_IN.XKINKYU_BUF_TO) = "" Then
                '(緊急入庫設定なし)
                strDSPST_TO = FTRK_BUF_NO_J9000                                 '自動倉庫
            Else
                '(緊急入庫設定)
                strDSPST_TO = TO_STRING(objTBL_XSTS_PRODUCT_IN.XKINKYU_BUF_TO)  '設定ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
            End If
        Else
            '(読めなかった時)
            strMsg = "生産入庫設定状態に、入庫STが見つかりませんでした。" & _
                     "[入庫ST:" & TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue) & "]"
            Throw New System.Exception(strMsg)
        End If



        '**********************************************************
        ' 共通入庫設定ﾃﾞｰﾀｾｯﾄ
        '**********************************************************
        strDSPST_FM = strXTRK_BUF_NO_CONV                   '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strDSPPALLET_ID = ""                                'ﾊﾟﾚｯﾄID
        strDSPLOT_NO_STOCK = ""                             '在庫ﾛｯﾄ№
        strDSPHINMEI_CD = mstrFHINMEI_CD                    '品名ｺｰﾄﾞ
        strXDSPIN_SITEI = TO_STRING(XDSPIN_SITEI_NON)       '棚ﾌﾞﾛｯｸ指定
        strDSPARRIVE_DT = mstrFARRIVE_DT                    '在庫発生日時
        strXDSPPROD_LINE = mstrXPROD_LINE                   '生産ﾗｲﾝ№
        strXMAKER_CD = mstrXMAKER_CD                        'ﾒｰｶｰｺｰﾄﾞ
        strXDSPKENSA_KUBUN = mstrXKENSA_KUBUN               '検査区分
        strDSPHORYU_KUBUN = mstrFHORYU_KUBUN                '保留区分
        strDSPIN_KUBUN = mstrFIN_KUBUN                      '入庫区分
        strXDSPKENPIN_KUBUN = mstrXKENPIN_KUBUN             '検品区分
        strDSPTR_VOL_HASUU = intHASUU_VOL                   '端量梱数

        '**********************************************************
        ' 搬送管理量の特定
        '**********************************************************
        Dim intRet3 As RetCode
        Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
        objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        objTBL_TMST_ITEM.FHINMEI_CD = strDSPHINMEI_CD        '品名ｺｰﾄﾞ
        intRet3 = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
        If intRet3 = RetCode.OK Then
            '(値がある時)
            strDSPTR_VOL = objTBL_TMST_ITEM.FNUM_IN_PALLET        'PL毎積載数
        Else
            '(読めなかった時)
            strMsg = "品目ﾏｽﾀに、PL毎積載数が見つかりませんでした。" & _
                     "[品目ｺｰﾄﾞ:" & strDSPHINMEI_CD & "]"
            Throw New System.Exception(strMsg)
        End If


        '********************************************************************
        ' 入庫設定用 電文作成
        '********************************************************************
        '送信電文
        ReDim strSndTlgrm(0)

        For ii As Integer = 1 To intALL_PL_Count Step 2
            '(ﾊﾟﾚｯﾄ数分ﾙｰﾌﾟ)
            If ii + 1 <= intALL_PL_Count Then
                blnPareFlag = True
            Else
                blnPareFlag = False
            End If


            '配列再定義
            ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列

            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001

            objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6)) 'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

            objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPST_TO", strDSPST_TO)                  '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID
            objTelegramSub.SETIN_DATA("DSPLOT_NO_STOCK", strDSPLOT_NO_STOCK)    '在庫ﾛｯﾄ№

            If blnPareFlag = True Then
                objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J53))      '作業種別 ﾛｰｶﾙ入庫(ﾍﾟｱ)
            Else
                objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J54))      '作業種別 ﾛｰｶﾙ入庫(ｼﾝｸﾞﾙ)
            End If
            objTelegramSub.SETIN_DATA("DSPHINMEI_CD", strDSPHINMEI_CD)          '品名ｺｰﾄﾞ

            If blnHASUUFlag = True Then
                '(端数がある場合)
                If ii <> intALL_PL_Count Then
                    objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)        '搬送管理量
                Else
                    objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL_HASUU)  '搬送管理量 端数
                End If

            Else
                objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)            '搬送管理量

            End If


            If blnPareFlag = True Then
                objTelegramSub.SETIN_DATA("XDSPIN_KIND", 1)                     '入庫種別
            Else
                objTelegramSub.SETIN_DATA("XDSPIN_KIND", 0)                     '入庫種別
            End If

            objTelegramSub.SETIN_DATA("XDSPIN_SITEI", strXDSPIN_SITEI)          '入庫指定

            objTelegramSub.SETIN_DATA("DSPARRIVE_DT", strDSPARRIVE_DT)          '在庫発生日時
            objTelegramSub.SETIN_DATA("XDSPPROD_LINE", strXDSPPROD_LINE)        '生産ﾗｲﾝ№
            objTelegramSub.SETIN_DATA("XDSPMAKER_CD", strXMAKER_CD)             'ﾒｰｶｰｺｰﾄﾞ
            objTelegramSub.SETIN_DATA("XDSPKENSA_KUBUN", strXDSPKENSA_KUBUN)    '検査区分
            objTelegramSub.SETIN_DATA("DSPHORYU_KUBUN", strDSPHORYU_KUBUN)      '保留区分
            objTelegramSub.SETIN_DATA("DSPIN_KUBUN", strDSPIN_KUBUN)            '入庫区分
            objTelegramSub.SETIN_DATA("XDSPKENPIN_KUBUN", strXDSPKENPIN_KUBUN)  '検品区分

            If blnPareFlag = True Then
                '(ﾍﾟｱ入庫の場合)
                If blnHASUUFlag = True Then
                    '(端数がある場合)
                    If ii + 1 <> intALL_PL_Count Then
                        objTelegramSub.SETIN_DATA("XDSPTR_VOL_KO", strDSPTR_VOL)        '搬送管理量(子)
                    Else
                        objTelegramSub.SETIN_DATA("XDSPTR_VOL_KO", strDSPTR_VOL_HASUU)  '搬送管理量(子) 端数
                    End If

                Else
                    objTelegramSub.SETIN_DATA("XDSPTR_VOL_KO", strDSPTR_VOL)            '搬送管理量(子)

                End If


            End If

            objTelegramSub.SETIN_DATA("XDSPTANA_BLOCK", strXDSPTANA_BLOCK)      '棚ﾌﾞﾛｯｸ


            objTelegramSub.MAKE_TELEGRAM()
            strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED             '送信電文

            intHairetu = intHairetu + 1
        Next


        '********************************************************************
        ' ｿｹｯﾄ送信処理
        '********************************************************************
        Dim strRetState() As String = Nothing               '出庫処理戻りｽﾃｰﾀｽ
        Dim strErrMsg As String = ""                        'ｴﾗｰﾒｯｾｰｼﾞ
        Dim udtSckSendRET As clsSocketClient.RetCode        'ｿｹｯﾄ送信戻り値
        Dim strRET_STATE As String = ""

        Dim objTelegramNull As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegramNull.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001

        '=====================================
        '複数ｿｹｯﾄ処理
        '=====================================
        strErrMsg = FRM_MSG_FRM310020_04
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegramNull, strSndTlgrm, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnCheckErr = False
            End If
        End If

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

#Region "   品名・生産ﾗｲﾝNo.取得                    "
    '''''' *******************************************************************************************************************
    '''''' <summary>
    '''''' 品名・生産ﾗｲﾝNo.取得
    '''''' </summary>
    '''''' <remarks></remarks>
    '''''' *******************************************************************************************************************
    ' ''Private Sub GetHASUUData()

    ' ''    Dim strFHINMEI_CD As String = ""            '品名ｺｰﾄﾞ
    ' ''    Dim strFHINMEI As String = ""               '品名
    ' ''    Dim strXPROD_LINE As String = ""            '生産ﾗｲﾝNo.
    ' ''    Dim strXPROGRESS As String = ""             '進捗状況

    ' ''    '**********************************************************
    ' ''    ' 生産入庫設定状態からﾃﾞｰﾀを取得
    ' ''    '**********************************************************
    ' ''    Dim strMsg As String = ""
    ' ''    Dim intRet As RetCode
    ' ''    Dim objTBL_XSTS_PRODUCT_IN As TBL_XSTS_PRODUCT_IN                                       '生産入庫設定状態
    ' ''    objTBL_XSTS_PRODUCT_IN = New TBL_XSTS_PRODUCT_IN(gobjOwner, gobjDb, Nothing)
    ' ''    objTBL_XSTS_PRODUCT_IN.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ' ''    intRet = objTBL_XSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)
    ' ''    If intRet = RetCode.OK Then
    ' ''        '(読めたとき)
    ' ''        mstrFHINMEI_CD = objTBL_XSTS_PRODUCT_IN.FHINMEI_CD                                  '品名ｺｰﾄﾞ
    ' ''        mstrXPROD_LINE = objTBL_XSTS_PRODUCT_IN.XPROD_LINE                                  '生産ﾗｲﾝNo.
    ' ''        mintXPROGRESS = TO_INTEGER(objTBL_XSTS_PRODUCT_IN.XPROGRESS)                        '進捗状況
    ' ''    Else
    ' ''        '(読めなかった時)
    ' ''        strMsg = "生産入庫設定状態に、ﾃﾞｰﾀが見つかりませんでした。" & _
    ' ''                 "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue) & "]"
    ' ''        Throw New System.Exception(strMsg)
    ' ''        Exit Sub
    ' ''    End If

    ' ''    '**********************************************************
    ' ''    ' 進捗状況の確認
    ' ''    '**********************************************************
    ' ''    If mintXPROGRESS <> XPROGRESS_START Then
    ' ''        '(開始状態以外の場合)
    ' ''        '品目が設定されていないので終了
    ' ''        Exit Sub

    ' ''    End If

    ' ''    '**********************************************************
    ' ''    ' 品目ﾏｽﾀから品名、積載量を取得
    ' ''    '**********************************************************
    ' ''    intRet = Nothing
    ' ''    Dim objTBL_TMST_ITEM As TBL_TMST_ITEM                                                   '品目ﾏｽﾀ
    ' ''    objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
    ' ''    objTBL_TMST_ITEM.FHINMEI_CD = mstrFHINMEI_CD                                             '品名ｺｰﾄﾞ
    ' ''    intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
    ' ''    If intRet = RetCode.OK Then
    ' ''        '(読めたとき)
    ' ''        mstrFHINMEI = objTBL_TMST_ITEM.FHINMEI                                              '品名
    ' ''        mintFNUM_IN_PL = objTBL_TMST_ITEM.FNUM_IN_PALLET                                    'PL毎積載量
    ' ''    Else
    ' ''        '(読めなかった時)
    ' ''        strMsg = "品目ﾏｽﾀに、ﾃﾞｰﾀが見つかりませんでした。" & _
    ' ''                 "[品目ｺｰﾄﾞ:" & strFHINMEI_CD & "]"
    ' ''        Throw New System.Exception(strMsg)
    ' ''        Exit Sub
    ' ''    End If

    ' ''    '**********************************************************
    ' ''    ' 生産ﾗｲﾝﾏｽﾀから生産ﾗｲﾝ名を取得
    ' ''    '**********************************************************
    ' ''    intRet = Nothing
    ' ''    Dim objTBL_XMST_PROD_LINE As TBL_XMST_PROD_LINE                                         '生産ﾗｲﾝﾏｽﾀ
    ' ''    objTBL_XMST_PROD_LINE = New TBL_XMST_PROD_LINE(gobjOwner, gobjDb, Nothing)
    ' ''    objTBL_XMST_PROD_LINE.XPROD_LINE = mstrXPROD_LINE                                       '生産ﾗｲﾝNo.
    ' ''    intRet = objTBL_XMST_PROD_LINE.GET_XMST_PROD_LINE(False)
    ' ''    If intRet = RetCode.OK Then
    ' ''        '(読めたとき)
    ' ''        mstrXPROD_LINE_Disp = objTBL_XMST_PROD_LINE.XPROD_LINE_NAME                         '生産ﾗｲﾝ名称
    ' ''    Else
    ' ''        '(読めなかった時)
    ' ''        strMsg = "生産ﾗｲﾝﾏｽﾀに、ﾃﾞｰﾀが見つかりませんでした。" & _
    ' ''                 "[生産ﾗｲﾝNo.:" & strFHINMEI_CD & "]"
    ' ''        Throw New System.Exception(strMsg)
    ' ''        Exit Sub
    ' ''    End If

    ' ''End Sub
#End Region

#Region "   生産入庫ST ｺﾝﾎﾞﾎﾞｯｸｽ 作成          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 生産入庫ST ｺﾝﾎﾞﾎﾞｯｸｽ 作成
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeSeisanNyuukoST()
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))

        ' 初期値
        Dim defaultrow As DataRow = objComboTable.NewRow()
        defaultrow("NAME") = ""
        defaultrow("ID") = ""
        '　DataTableに行を追加
        objComboTable.Rows.Add(defaultrow)

        cboFTRK_BUF_NO_NYUUKO.DataSource = Nothing
        cboFTRK_BUF_NO_NYUUKO.Items.Clear()

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【生産入庫設定】
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "        TMST_TRK.FBUF_NAME AS NAME  "
        strSQL &= vbCrLf & "   ,    XSTS_PRODUCT_IN.FTRK_BUF_NO AS VALUE "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "        XSTS_PRODUCT_IN "
        strSQL &= vbCrLf & "   ,    TMST_TRK "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "  AND   XSTS_PRODUCT_IN.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "        XSTS_PRODUCT_IN.FGRID_DISPLAYINDEX "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_PRODUCT_IN"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("NAME"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("VALUE"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboFTRK_BUF_NO_NYUUKO.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboFTRK_BUF_NO_NYUUKO.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboFTRK_BUF_NO_NYUUKO.ValueMember = "ID"

    End Sub
#End Region
#Region "   生産入庫設定状態     取得          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 生産入庫設定状態 取得
    ''' </summary>
    ''' <param name="FTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Get_XSTS_PRODUCT_IN_Value(ByVal FTRK_BUF_NO As String)

        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strSQL As String = ""

        '********************************************************************
        ' ｺﾈｸｼｮﾝの確認
        '********************************************************************
        If IsNull(gobjDb) = True Then
            'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
            Return
        End If

        '********************************************************************
        ' SQL文
        '********************************************************************
        '(Select句)
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       XSTS_PRODUCT_IN.FHINMEI_CD "                  '生産入庫設定状態      .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                        '品目ﾏｽﾀ               .品名記号
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                           '品目ﾏｽﾀ               .品名
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FARRIVE_DT "                  '生産入庫設定状態      .在庫発生日時
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XPROD_LINE"                   '生産入庫設定状態      .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , XMST_PROD_LINE.XPROD_LINE_NAME"               '生産ﾗｲﾝﾏｽﾀ            .生産ﾗｲﾝ名称
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XMAKER_CD "                   '生産入庫設定状態      .ﾒｰｶｰｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XKENSA_KUBUN "                '生産入庫設定状態      .検査区分
        strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "      '生産入庫設定状態      .検査区分(表示用)
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FHORYU_KUBUN "                '生産入庫設定状態      .保留区分
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS FHORYU_KUBUN_DSP "      '生産入庫設定状態      .保留区分(表示用)
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FIN_KUBUN "                   '生産入庫設定状態      .入庫区分
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS FIN_KUBUN_DSP "         '生産入庫設定状態      .入庫区分(表示用)
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XKENPIN_KUBUN "               '生産入庫設定状態      .検品区分
        strSQL &= vbCrLf & "     , HASH04.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "     '生産入庫設定状態      .検品区分(表示用)
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "                    '品目ﾏｽﾀ               .PL毎積載量

        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FEQ_ID "                      '生産入庫設定状態      .設備ID
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XPROGRESS "                   '生産入庫設定状態      .進捗状態
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FGRID_DISPLAYINDEX "          '生産入庫設定状態      .ｸﾞﾘｯﾄﾞ列表示順序

        '(From句)
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "       XSTS_PRODUCT_IN "               '【生産入庫設定状態】
        strSQL &= vbCrLf & "     , TMST_TRK "                      '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "     , TMST_ITEM "                     '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "     , XMST_PROD_LINE "                '【生産ﾗｲﾝﾏｽﾀ】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XSTS_PRODUCT_IN", "FIN_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XSTS_PRODUCT_IN", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "XSTS_PRODUCT_IN", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "XSTS_PRODUCT_IN", "XKENPIN_KUBUN")

        '(Where句)
        strSQL &= vbCrLf & " WHERE  "
        strSQL &= vbCrLf & "        XSTS_PRODUCT_IN.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.XPROD_LINE = XMST_PROD_LINE.XPROD_LINE(+) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XSTS_PRODUCT_IN", "FIN_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XSTS_PRODUCT_IN", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "XSTS_PRODUCT_IN", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "XSTS_PRODUCT_IN", "XKENPIN_KUBUN")
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FTRK_BUF_NO = '" & FTRK_BUF_NO & "' "

        '********************************************************************
        ' 実行
        '********************************************************************
        gobjDb.SQL = strSQL

        objDataSet.Clear()
        gobjDb.GetDataSet("XSTS_PRODUCT_IN", objDataSet)

        If objDataSet.Tables("XSTS_PRODUCT_IN").Rows.Count >= 0 Then
            '(値が取得できた場合)
            mstrFHINMEI_CD = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("FHINMEI_CD"))
            mstrXHINMEI_CD = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("XHINMEI_CD"))
            mstrFHINMEI = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("FHINMEI"))
            mstrFARRIVE_DT = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("FARRIVE_DT"))
            mstrXPROD_LINE = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("XPROD_LINE"))
            mstrXPROD_LINE_Disp = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("XPROD_LINE_NAME"))
            mstrXMAKER_CD = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("XMAKER_CD"))
            mstrXKENSA_KUBUN = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("XKENSA_KUBUN"))
            mstrXKENSA_KUBUN_Disp = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("XKENSA_KUBUN_DSP"))
            mstrFHORYU_KUBUN = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("FHORYU_KUBUN"))
            mstrFHORYU_KUBUN_Disp = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("FHORYU_KUBUN_DSP"))
            mstrFIN_KUBUN = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("FIN_KUBUN"))
            mstrFIN_KUBUN_Disp = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("FIN_KUBUN_DSP"))
            mstrXKENPIN_KUBUN = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("XKENPIN_KUBUN"))
            mstrXKENPIN_KUBUN_Disp = TO_STRING(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("XKENPIN_KUBUN_DSP"))

            mintXPROGRESS = TO_INTEGER(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("XPROGRESS"))

            mintFNUM_IN_PL = TO_INTEGER(objDataSet.Tables("XSTS_PRODUCT_IN").Rows(0).Item("FNUM_IN_PALLET"))
        End If

    End Sub

#End Region

#Region "　連続入庫設定確認                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 連続入庫設定確認
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function CheckContinueState(ByVal strFTRK_BUF_NO As String) As Boolean

        Dim blnReturn As Boolean                 '値有無ﾌﾗｸﾞ
        blnReturn = False

        '**********************************************************
        ' 生産入庫設定を取得
        '**********************************************************
        Dim intRet As RetCode
        Dim objTBL_XSTS_PRODUCT_IN As TBL_XSTS_PRODUCT_IN                               '生産入庫設定状態
        objTBL_XSTS_PRODUCT_IN = New TBL_XSTS_PRODUCT_IN(gobjOwner, gobjDb, Nothing)
        objTBL_XSTS_PRODUCT_IN.FTRK_BUF_NO = strFTRK_BUF_NO                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        intRet = objTBL_XSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)
        If intRet = RetCode.OK Then
            '(ﾃﾞｰﾀ有り)
            If IsNull(objTBL_XSTS_PRODUCT_IN.FHINMEI_CD) = False Then
                '(品名ｺｰﾄﾞ設定時)
                blnReturn = True      '連続入庫中
            End If
        End If

        CheckContinueState = blnReturn

    End Function
#End Region

End Class
