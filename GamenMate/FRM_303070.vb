'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産入庫設定画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_303070

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mstrFHINMEI_CD_KARA(2) As String            '空ﾊﾟﾚｯﾄ品名ｺｰﾄﾞ

    Private mintXKANRI_KUBUN As Integer                 '管理区分

    Private mstrFPALLET_ID As String = ""               'ﾊﾟﾚｯﾄID
    Private mstrFLOT_NO_STOCK As String = ""            '在庫ﾛｯﾄ№

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        NyukoBtn_Click              '入庫
        BCYomitoriBtn_Click         'BC読取
        TeNyuryoku_Click            '手入力
        STModeBtn_Click             'ﾓｰﾄﾞ切替ﾎﾞﾀﾝｸﾘｯｸ時
        BC_READ                     'ﾊﾞｰｺｰﾄﾞ読取
    End Enum

#End Region
#Region "  構造体定義                               "
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.TextChanged
        Try

            If mFlag_Form_Load = False Then


                Dim intRet As RetCode
                Dim objTMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)       '品名ﾏｽﾀ
                If cboFHINMEI_CD.Text <> "" Then
                    '(品名ｺｰﾄﾞの入力ありの時)
                    objTMST_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                            '品名ｺｰﾄﾞ
                    intRet = objTMST_ITEM.GET_TMST_ITEM(False)                              '特定
                    If intRet = RetCode.OK Then
                        '(読めた時)

                        mintXKANRI_KUBUN = objTMST_ITEM.XKANRI_KUBUN                    '管理区分

                        'If objTMST_ITEM.XKANRI_KUBUN = XKANRI_KUBUN_JMATEST Then
                        ''(物流管理品の時)
                        If (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(0)) Or _
                           (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(1)) Or _
                           (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(2)) Then
                            '(空ﾊﾟﾚｯﾄ(ﾚﾝﾀﾙ用)、天板、空ﾊﾟﾚｯﾄ(天板用)の時)
                            'dtpXSEIZOU_DT.cmpMDateTimePicker_D.Value = Now
                            'txtXLINE_NO.Text = "000000"
                            'txtXPALLET_NO.Text = "0000"
                            'txtFTR_VOL.Text = TO_STRING(TO_INTEGER(objTMST_ITEM.FNUM_IN_PALLET))
                            'cboXKENSA_KUBUN.SelectedIndex = -1
                            'txtXAB_KUBUN.Text = ""

                            'dtpXSEIZOU_DT.Enabled = False
                            'txtFTR_VOL.Enabled = False
                            'txtXLINE_NO.Enabled = False
                            'txtXPALLET_NO.Enabled = False
                            'cboXKENSA_KUBUN.Enabled = False
                            'txtXAB_KUBUN.Enabled = False

                        Else
                            '(ﾎｽﾄ管理品の時)
                            dtpXSEIZOU_DT.cmpMDateTimePicker_D.Value = Now      '製造年月日
                            txtXLINE_NO.Text = ""                               'ﾗｲﾝ№
                            txtXPALLET_NO.Text = ""                             'ﾊﾟﾚｯﾄ№
                            txtFTR_VOL.Text = ""                                '積数
                            cboXKENSA_KUBUN.SelectedIndex = -1                  '検査区分
                            txtXAB_KUBUN.Text = ""                              'AB区分

                            If txtBC.Enabled = True Then
                                '(BC読取の時)
                                dtpXSEIZOU_DT.Enabled = False
                                txtFTR_VOL.Enabled = False
                                txtXLINE_NO.Enabled = False
                                txtXPALLET_NO.Enabled = False
                                cboXKENSA_KUBUN.Enabled = False
                                txtXAB_KUBUN.Enabled = False

                            Else
                                '(手入力の時)
                                dtpXSEIZOU_DT.Enabled = True
                                txtFTR_VOL.Enabled = True
                                txtXLINE_NO.Enabled = True
                                txtXPALLET_NO.Enabled = True
                                cboXKENSA_KUBUN.Enabled = True
                                txtXAB_KUBUN.Enabled = True
                            End If

                        End If
                    Else
                        '(読めない時)
                    End If

                Else
                    '(品名ｺｰﾄﾞ入力なしの時
                    dtpXSEIZOU_DT.cmpMDateTimePicker_D.Value = Now      '製造年月日
                    txtXLINE_NO.Text = ""                               'ﾗｲﾝ№
                    txtXPALLET_NO.Text = ""                             'ﾊﾟﾚｯﾄ№
                    txtFTR_VOL.Text = ""                                '積数
                    cboXKENSA_KUBUN.SelectedIndex = -1                  '検査区分
                    txtXAB_KUBUN.Text = ""                              'AB区分

                    If txtBC.Enabled = True Then
                        '(BC読取の時)
                        dtpXSEIZOU_DT.Enabled = False
                        txtFTR_VOL.Enabled = False
                        txtXLINE_NO.Enabled = False
                        txtXPALLET_NO.Enabled = False
                        cboXKENSA_KUBUN.Enabled = False
                        txtXAB_KUBUN.Enabled = False

                    Else
                        '(手入力の時)
                        dtpXSEIZOU_DT.Enabled = True
                        txtFTR_VOL.Enabled = True
                        txtXLINE_NO.Enabled = True
                        txtXPALLET_NO.Enabled = True
                        cboXKENSA_KUBUN.Enabled = True
                        txtXAB_KUBUN.Enabled = True
                    End If

                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　STｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' STｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFTRK_BUF_NO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                If cboFTRK_BUF_NO.Enabled = False Then
                    '(STｺﾝﾎﾞ無効の時）
                    btnSTMode.Text = ""                        '台車・状態
                    btnSTMode.BackColor = gcModeColor_Black
                Else
                    '(STｺﾝﾎﾞ有効の時）
                    '**********************************************************
                    ' ﾗﾍﾞﾙ設定
                    '**********************************************************
                    tmr303070.Enabled = False
                    Call gobjComFuncFRM.AlterButtonColorMOD(btnSTMode, TO_STRING(cboFTRK_BUF_NO.SelectedValue), LBL_DSPTYPE.STSNAME)
                    tmr303070.Enabled = True
                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ﾓｰﾄﾞ更新    ﾀｲﾏ　                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾓｰﾄﾞ更新    ﾀｲﾏ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr303070_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr303070.Tick
        Try

            tmr303070.Enabled = False

            '**************************************************
            ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
            '**************************************************
            Call tmr303070_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr303070.Enabled = True

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


        '**********************************************************
        ' 開発者用ﾎﾞﾀﾝ設定
        '**********************************************************
        If TO_NUMBER(gcstrDEGUB_FLG) = 9 Then
            Me.btnBC.Size = New Size(32, 24)
            Me.txtBC.Size = New Size(56, 27)
        Else
            Me.btnBC.Size = New Size(0, 24)
            Me.txtBC.Size = New Size(0, 27)
        End If

        '**********************************************************
        ' 空ﾊﾟﾚｯﾄ品名ｺｰﾄﾞ取得
        '**********************************************************
        mstrFHINMEI_CD_KARA(0) = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JSJ000000_011))
        mstrFHINMEI_CD_KARA(1) = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JSJ000000_012))
        mstrFHINMEI_CD_KARA(2) = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JSJ000000_013))


        '===================================
        '入庫ST ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/10/28 ﾃﾞﾌｫﾙﾄをﾊﾞｰｽ8右に変更
        Dim intFTRK_BUF_NO As Integer = FTRK_BUF_NO_J174
        'Dim intFTRK_BUF_NO As Integer = FTRK_BUF_NO_J169
        '↑↑↑↑↑↑************************************************************************************************************
        Select Case gcintFTERM_KBN          '端末区分
            Case FTERM_KUBUN_JKARAPAL
                '(空ﾊﾟﾚｯﾄ入庫STの時)
                intFTRK_BUF_NO = FTRK_BUF_NO_J174
            Case FTERM_KUBUN_JINOUT1F
                '(1F入出庫STの時)
                intFTRK_BUF_NO = FTRK_BUF_NO_J187
            Case FTERM_KUBUN_JINOUT3F
                '(3F入出庫STの時)
                intFTRK_BUF_NO = FTRK_BUF_NO_J382
            Case FTERM_KUBUN_JPET
                '(ﾍﾟｯﾄﾗｲﾝの時)
                intFTRK_BUF_NO = FTRK_BUF_NO_J384
            Case FTERM_KUBUN_JKAN
                '(缶ﾗｲﾝの時)
                intFTRK_BUF_NO = FTRK_BUF_NO_J389
            Case FTERM_KUBUN_JMUGI
                '(麦茶ﾗｲﾝの時)
                intFTRK_BUF_NO = FTRK_BUF_NO_J394
            Case FTERM_KUBUN_JKAMI
                '(紙ﾗｲﾝの時)
                intFTRK_BUF_NO = FTRK_BUF_NO_J399
        End Select

        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO, False, intFTRK_BUF_NO)

        btnSTMode.Text = ""                          '入庫ST・状態
        btnSTMode.BackColor = gcModeColor_Black


        '===================================
        '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.XKANRI_KUBUN = TO_STRING(XKANRI_KUBUN_JHOST)
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)



        '===================================
        '検索区分ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboXKENSA_KUBUN, True)




        ''**********************************************************
        '' ｺﾝﾄﾛｰﾙ初期化
        ''**********************************************************
        'Call Clear_DTL(2)               '明細初期表示
        'btnBC.Enabled = False          'BC入力無効
        'txtBC.Enabled = False
        'cboFTRK_BUF_NO.Focus()         '入庫ST ﾌｫｰｶｽ






        '**************************************************
        ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
        '**************************************************
        Call tmr303070_TickProcess()

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr303070.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS303070_001))
        tmr303070.Enabled = True


        mFlag_Form_Load = False


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/10/28 ﾃﾞﾌｫﾙﾄをBC読取りに変更
        btnBC.Enabled = True
        txtBC.Enabled = True
        txtBC.Focus()                   'BC入力ﾌｫｰｶｽ

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        Call Clear_DTL(1)               '明細初期表示

        lblINPUT_MODE.Text = "BC読取"
        '↑↑↑↑↑↑************************************************************************************************************


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
        cboFTRK_BUF_NO.Dispose()           '入庫ST
        dtpXSEIZOU_DT.Dispose()            '製造年月日
        txtXLINE_NO.Dispose()              'ﾗｲﾝ№
        cboXKENSA_KUBUN.Dispose()          '検索区分
        txtXPALLET_NO.Dispose()            'ﾊﾟﾚｯﾄ№
        txtFTR_VOL.Dispose()               '積数
        txtXAB_KUBUN.Dispose()             'AB区分

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
        If SendSocket01_TE() = False Then
            Exit Sub
        End If


        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        If txtBC.Enabled = True Then
            '(BC読取の時)
            Call Clear_DTL(1)               '明細初期表示
        Else
            '(手入力の時)
            Call Clear_DTL(2)               '明細初期表示
        End If


    End Sub
#End Region
#Region "  F5(BC読取)       ﾎﾞﾀﾝ押下処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(BC読取)     ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()

        btnBC.Enabled = True
        txtBC.Enabled = True
        txtBC.Focus()                   'BC入力ﾌｫｰｶｽ

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        Call Clear_DTL(1)               '明細初期表示

        lblINPUT_MODE.Text = "BC読取"

    End Sub
#End Region
#Region "  F6(手入力)       ﾎﾞﾀﾝ押下処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(手入力)     ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F6Process()

        btnBC.Enabled = False
        txtBC.Enabled = False
        cboFTRK_BUF_NO.Focus()         '入庫ST ﾌｫｰｶｽ

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        Call Clear_DTL(2)               '明細初期表示

        lblINPUT_MODE.Text = "手入力"

    End Sub
#End Region
#Region "  F8(戻る)         ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る)         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_203000, Me)

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

        Dim intRet As RetCode
        Dim strMsg As String = ""

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.NyukoBtn_Click
                '(入庫ﾎﾞﾀﾝｸﾘｯｸ時)

                '========================================
                '品名ｺｰﾄﾞ
                '========================================
                If cboFHINMEI_CD.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_07, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                Dim decFNUM_IN_PALLET As Decimal = 0        'PL毎積載数

                Dim objTMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)       '品名ﾏｽﾀ
                objTMST_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                            '品名ｺｰﾄﾞ
                intRet = objTMST_ITEM.GET_TMST_ITEM(False)                              '特定
                If intRet <> RetCode.OK Then
                    '(読めなかった時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_19, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                Else
                    '(読めた時)
                    decFNUM_IN_PALLET = objTMST_ITEM.FNUM_IN_PALLET
                End If


                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:A.Noto 2012/11/29 生産入庫設定画面追加
                If objTMST_ITEM.XKANRI_KUBUN <> XKANRI_KUBUN_JHOST Then
                    '(管理区分が物流管理のとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_21, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                '↑↑↑↑↑↑************************************************************************************************************


                ''==================================
                '' 製造年月日ﾃｷｽﾄﾎﾞｯｸｽ
                ''==================================
                'If dtpXSEIZOU_DT.Value.HasValue = False Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_08, _
                '                      PopupFormType.Ok, _
                '                      PopupIconType.Information)
                '    Exit Select
                'End If

                '========================================
                'ﾗｲﾝ№
                '========================================
                If txtXLINE_NO.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_09, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                If Len(txtXLINE_NO.Text) <> 6 Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_15, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾊﾟﾚｯﾄ№
                '========================================
                If txtXPALLET_NO.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_10, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '積数
                '========================================
                If (txtFTR_VOL.Value = "") Or (TO_DECIMAL(txtFTR_VOL.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_11, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                If IsNumeric(txtFTR_VOL.Value) = False Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM200000_13 & vbCrLf & FRM_MSG_FTR_VOL_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If


                If TO_DECIMAL(txtFTR_VOL.Value) > decFNUM_IN_PALLET Then
                    '(PL毎積載数より大きい時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_20, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '検査区分
                '========================================
                If (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(0)) Or _
                   (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(1)) Or _
                   (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(2)) Or _
                   (mintXKANRI_KUBUN = XKANRI_KUBUN_JMATEST) Then
                    '(空ﾊﾟﾚｯﾄの時 又は、物流管理品の時)
                Else
                    '(通常ﾊﾟﾚｯﾄの時)
                    If cboXKENSA_KUBUN.Text = "" Then
                        '（入力無しの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_12, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If
                End If

                '========================================
                'AB区分
                '========================================
                Dim strFTRK_BUF_NO As String = TO_STRING(cboFTRK_BUF_NO.SelectedValue)
                If (strFTRK_BUF_NO = FTRK_BUF_NO_J382) Or _
                   (strFTRK_BUF_NO = FTRK_BUF_NO_J384) Or _
                   (strFTRK_BUF_NO = FTRK_BUF_NO_J389) Or _
                   (strFTRK_BUF_NO = FTRK_BUF_NO_J394) Or _
                   (strFTRK_BUF_NO = FTRK_BUF_NO_J399) Then
                    '(生産入庫ﾗｲﾝの時)
                    If (txtXAB_KUBUN.Text <> "") And _
                       (txtXAB_KUBUN.Text <> " ") Then
                        '（入力ありの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_13, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If
                End If


                '==============================================================
                '在庫情報取得  重複ﾁｪｯｸ (品名ｺｰﾄﾞ、製造年月日、ﾗｲﾝ№、ﾊﾟﾚｯﾄ№
                '==============================================================
                If (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(0)) Or _
                   (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(1)) Or _
                   (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(2)) Or _
                   (mintXKANRI_KUBUN = XKANRI_KUBUN_JMATEST) Then
                    '(空ﾊﾟﾚｯﾄの時 又は、物流管理品の時)
                    mstrFPALLET_ID = ""
                    mstrFLOT_NO_STOCK = ""
                Else
                    '(通常ﾊﾟﾚｯﾄの時)
                    Dim objTRST_STOCK As TBL_TRST_STOCK        '在庫情報
                    objTRST_STOCK = New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)

                    objTRST_STOCK.FHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)           '品名ｺｰﾄﾞ
                    objTRST_STOCK.XSEIZOU_DT = TO_DATE(Mid(dtpXSEIZOU_DT.userDateTimeText, 1, 10) & " 00:00:00")  '製造年月日
                    objTRST_STOCK.XLINE_NO = txtXLINE_NO.Text                          'ﾗｲﾝ№
                    objTRST_STOCK.XPALLET_NO = txtXPALLET_NO.Text                      'ﾊﾟﾚｯﾄ№
                    intRet = objTRST_STOCK.GET_TRST_STOCK(False)
                    If intRet = RetCode.OK Then
                        '(在庫情報があるとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_17, PopupFormType.Ok, PopupIconType.Information)
                        Exit Select
                    Else
                        '(在庫情報が無い時)
                        mstrFPALLET_ID = ""
                        mstrFLOT_NO_STOCK = ""
                    End If

                End If

                '*TODO* ｶｺﾞﾒ ｻｰﾊﾞｰ側でﾁｪｯｸするから不要!?
                ''========================================
                ''空棚ﾁｪｯｸ
                ''========================================
                'Dim objTemplateServer As New clsTemplateServer(gobjOwner, gobjDb, Nothing)      'ｻｰﾊﾞｰﾌﾟﾛｾｽ用ﾃﾝﾌﾟﾚｰﾄｸﾗｽ
                'Dim intXRACK_RESERVED_CD As Integer = TO_DECIMAL_NULLABLE(cboXRACK_RESERVED_CD.SelectedValue)
                'Dim intFRAC_FORM_Stock As Integer = objTemplateServer.GetFRAC_FORMFromXRACK_RESERVED_CD(intXRACK_RESERVED_CD)

                ''************************************************
                ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ特定
                ''************************************************
                'Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
                'objTMST_TRK.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                'intRet = objTMST_TRK.GET_TMST_TRK()                                   '取得

                ''************************************************
                ''空棚ﾁｪｯｸ     (配替用の空棚があるかどうかﾁｪｯｸ)
                ''************************************************
                'intRet = objTemplateServer.CheckAkiTana(objTMST_TRK.XEQ_ID_CRANE, intFRAC_FORM_Stock)
                'If intRet <> RetCode.OK Then
                '    strMsg = "配替用棚を確保する為、これ以上入庫する事が出来ません。"
                '    Call gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok, PopupIconType.Information)
                '    Exit Select
                'End If


                '==========================
                '設備状態ﾁｪｯｸ(今回設備状態の更新を知ることができないので不要だったはずだが復活)
                '==========================
                If gobjComFuncFRM.CheckFEQ_STS(TO_STRING(cboFTRK_BUF_NO.SelectedValue), FEQ_STS_JINOUTMODE_IN, FRM_MSG_SYS_ERROR_30, FEQ_STS_JINOUTMODE_IN) = False Then
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False


            Case menmCheckCase.STModeBtn_Click
                '(ﾓｰﾄﾞ切替ﾎﾞﾀﾝｸﾘｯｸ時)

                'Dim strSTMode As String = ""        '設備状態
                Dim intST_RtnCd As Integer = gobjComFuncFRM.GetFEQ_STS(TO_STRING(cboFTRK_BUF_NO.SelectedValue), True, False, True)
                If (intST_RtnCd <> 1) And (intST_RtnCd <> 2) Then
                    '(設備状態が変更できないとき)
                    blnCheckErr = True
                    Exit Select
                End If

                'If strSTMode = "" Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_04, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If

                blnCheckErr = False


            Case menmCheckCase.BC_READ
                '(ﾊﾞｰｺｰﾄﾞ読み取り時)

                Dim intXKANRI_KUBUN As Integer = 0                                      '管理区分
                Dim objTMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)       '品名ﾏｽﾀ
                If Mid(txtBC.Text, 1, 6) <> "" Then
                    '(品名ｺｰﾄﾞの入力ありの時)
                    objTMST_ITEM.FHINMEI_CD = Mid(txtBC.Text, 1, 6)                     '品名ｺｰﾄﾞ
                    intRet = objTMST_ITEM.GET_TMST_ITEM(False)                          '特定
                    If intRet = RetCode.OK Then
                        '(読めた時)
                        intXKANRI_KUBUN = objTMST_ITEM.XKANRI_KUBUN                     '管理区分
                    End If
                End If

                If (Mid(txtBC.Text, 1, 6) = mstrFHINMEI_CD_KARA(0)) Or _
                   (Mid(txtBC.Text, 1, 6) = mstrFHINMEI_CD_KARA(1)) Or _
                   (Mid(txtBC.Text, 1, 6) = mstrFHINMEI_CD_KARA(2)) Or _
                   (intXKANRI_KUBUN = XKANRI_KUBUN_JMATEST) Then
                    '(空ﾊﾟﾚｯﾄの時 又は、物流管理品の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_22, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                Else
                '(以外の時)
                If Len(txtBC.Text) <> 30 Then
                    '(入庫BCでない時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303070_14, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
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
#Region "  ｿｹｯﾄ送信01  手入力                       "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket01_TE() As Boolean

        Dim blnRet As Boolean = False
        Dim strMsg As String = ""

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= FRM_MSG_FRM303070_05
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '********************************************************************
        '日付文字列作成
        '********************************************************************
        Dim strXSEIZOU_DTDate As String                             '製造年月日
        strXSEIZOU_DTDate = Mid(dtpXSEIZOU_DT.userDateTimeText, 1, 10) & " 00:00:00"


        ''********************************************************************
        '' ﾊﾞｰｺｰﾄﾞ情報ｾｯﾄ
        ''********************************************************************
        Dim strBC_DATA As String = ""                          'ﾊﾞｰｺｰﾄﾞ情報

        Dim strBCR01HINMEI_CD As String = ""                    '品名ｺｰﾄﾞ
        Dim strBCR01SEIZOU_DT As String = ""                    '製造年月日
        Dim strBCR01KOUJYO_NO As String = ""                    '工場№
        Dim strBCR01LINE_CD As String = ""                      'ﾗｲﾝｺｰﾄﾞ
        Dim strBCR01PALLET_NO As String = ""                    'ﾊﾟﾚｯﾄ№
        Dim strBCR01VOL As String = ""                          '積数
        Dim strBCR01KENSA_KUBUN As String = ""                  '検査区分
        Dim strBCR01AB_KUBUN As String = ""                     'AB区分

        strBCR01HINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)                          '品名ｺｰﾄﾞ
        '製造年月日
        strBCR01SEIZOU_DT = Mid(strXSEIZOU_DTDate, 1, 4) & _
                           Mid(strXSEIZOU_DTDate, 6, 2) & _
                           Mid(strXSEIZOU_DTDate, 9, 2)
        strBCR01KOUJYO_NO = Mid(txtXLINE_NO.Text, 1, 3)                            '工場№
        strBCR01LINE_CD = Mid(txtXLINE_NO.Text, 4, 3)                              'ﾗｲﾝｺｰﾄﾞ
        strBCR01PALLET_NO = txtXPALLET_NO.Text                                     'ﾊﾟﾚｯﾄ№
        strBCR01VOL = TO_STRING(TO_INTEGER(txtFTR_VOL.Text))                       '積数
        strBCR01KENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue)             '検査区分
        strBCR01AB_KUBUN = txtXAB_KUBUN.Text                                       'AB区分

        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_BCR)        '送信用電文

        objTelegramSub.FORMAT_ID = FORMAT_BCR_01                      'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegramSub.SETIN_DATA("BCR01HINMEI_CD", strBCR01HINMEI_CD)       '品名ｺｰﾄﾞ
        objTelegramSub.SETIN_DATA("BCR01SEIZOU_DT", strBCR01SEIZOU_DT)       '製造年月日
        objTelegramSub.SETIN_DATA("BCR01KOUJYO_NO", strBCR01KOUJYO_NO)       '工場№
        objTelegramSub.SETIN_DATA("BCR01LINE_CD", strBCR01LINE_CD)           'ﾗｲﾝｺｰﾄﾞ
        objTelegramSub.SETIN_DATA("BCR01PALLET_NO", strBCR01PALLET_NO)       'ﾊﾟﾚｯﾄ№
        objTelegramSub.SETIN_DATA("BCR01VOL", strBCR01VOL)                   '積み数
        objTelegramSub.SETIN_DATA("BCR01KENSA_KUBUN", strBCR01KENSA_KUBUN)   '検査区分
        objTelegramSub.SETIN_DATA("BCR01AB_KUBUN", strBCR01AB_KUBUN)         'AB区分

        objTelegramSub.MAKE_TELEGRAM()                                     '電文作成
        strBC_DATA = objTelegramSub.TELEGRAM_MAKED                         'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strDSPST_FM As String = ""            '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        Dim strDSPST_TO As String = ""            '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        Dim strDSPPALLET_ID As String = ""        'ﾊﾟﾚｯﾄID
        Dim strDSPLOT_NO_STOCK As String = ""     '在庫ﾛｯﾄ№
        Dim strDSPSAGYOU_KIND As String = ""      '作業種別
        Dim strDSPHINMEI_CD As String = ""        '品名ｺｰﾄﾞ
        Dim strXDSPSEIZOU_DT As String = ""       '製造年月日
        Dim strXDSPLINE_NO As String = ""         'ﾗｲﾝ№
        Dim strXDSPPALLET_NO As String = ""       'ﾊﾟﾚｯﾄ№
        Dim strDSPTR_VOL As String = ""           '搬送管理量
        Dim strXDSPKENSA_KUBUN As String = ""     '検索区分
        Dim strXDSPAB_KUBUN As String = ""        'AB区分
        Dim strXDSPBC_DATA As String = ""         'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ
        Dim strXDSPSEISAN_FLAG As String = ""     '生産入庫ﾌﾗｸﾞ


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strDSPST_FM = TO_STRING(cboFTRK_BUF_NO.SelectedValue)            '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strDSPST_TO = ""                                                 '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№

        '**********************************************************
        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀの特定  (搬送先ST特定)
        '**********************************************************
        Dim intRet As RetCode
        Dim objTMST_TRK As TBL_TMST_TRK                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        objTMST_TRK.FTRK_BUF_NO = strDSPST_FM               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        intRet = objTMST_TRK.GET_TMST_TRK(False)
        If intRet = RetCode.OK Then
            '(読めたとき)
            If IsNull(objTMST_TRK.XTRK_BUF_NO_CON) = False Then
                '(値がある時)
                strDSPST_TO = objTMST_TRK.XTRK_BUF_NO_CON
            Else
                '(値がない時)
                strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀに、搬送先STが見つかりませんでした。" & _
                         "[搬送元ST:" & strDSPST_FM & "]"
                Throw New System.Exception(strMsg)
            End If
        Else
            '(読めなかった時)
            strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀに、搬送先STが見つかりませんでした。" & _
                     "[搬送元ST:" & strDSPST_FM & "]"
            Throw New System.Exception(strMsg)
        End If


        '***搬送元ST ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№変換  ちょっと保留 8/20
        'If (strDSPST_FM = FTRK_BUF_NO_J185) Or _
        '   (strDSPST_FM = FTRK_BUF_NO_J187) Or _
        '   (strDSPST_FM = FTRK_BUF_NO_J169) Or _
        '   (strDSPST_FM = FTRK_BUF_NO_J174) Or _
        '   (strDSPST_FM = FTRK_BUF_NO_J382) Then
        '    '(1F入出庫ST1・2、ﾊﾞｰｽST8-1・２、ﾘｼﾞｪｸﾄﾗｲﾝSTの時)
        '    '**********************************************************
        '    ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀの特定
        '    '**********************************************************
        '    Dim intRet As RetCode
        '    Dim objTMST_TRK As TBL_TMST_TRK                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        '    objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        '    objTMST_TRK.FTRK_BUF_NO = strDSPST_FM               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        '    intRet = objTMST_TRK.GET_TMST_TRK(False)
        '    If intRet = RetCode.OK Then
        '        '(読めたとき)
        '        If IsNull(objTMST_TRK.XTRK_BUF_NO_IN_HIRA) = False Then
        '            '(値がある時)
        '            strDSPST_FM = objTMST_TRK.XTRK_BUF_NO_IN_HIRA
        '        End If
        '    End If
        'End If

        strDSPPALLET_ID = mstrFPALLET_ID                                 'ﾊﾟﾚｯﾄID
        strDSPLOT_NO_STOCK = mstrFLOT_NO_STOCK                           '在庫ﾛｯﾄ№

        strDSPSAGYOU_KIND = FSAGYOU_KIND_SIN                             '作業種別

        strDSPHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)                  '品名ｺｰﾄﾞ
        strXDSPSEIZOU_DT = strXSEIZOU_DTDate                             '製造年月日
        strXDSPLINE_NO = txtXLINE_NO.Text                                'ﾗｲﾝ№
        strXDSPPALLET_NO = txtXPALLET_NO.Text                            'ﾊﾟﾚｯﾄ№

        strDSPTR_VOL = TO_STRING(TO_INTEGER(txtFTR_VOL.Text))            '搬送管理量
        strXDSPKENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue)    '検索区分
        strXDSPAB_KUBUN = txtXAB_KUBUN.Text                              'AB区分
        strXDSPBC_DATA = strBC_DATA                                      'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ
        strXDSPSEISAN_FLAG = FLAG_ON                                     '生産入庫ﾌﾗｸﾞ


        objTelegram.SETIN_DATA("DSPST_FM", strDSPST_FM)                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        objTelegram.SETIN_DATA("DSPST_TO", strDSPST_TO)                  '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        objTelegram.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID
        objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strDSPLOT_NO_STOCK)    '在庫ﾛｯﾄ№
        objTelegram.SETIN_DATA("DSPSAGYOU_KIND", strDSPSAGYOU_KIND)      '作業種別
        objTelegram.SETIN_DATA("DSPHINMEI_CD", strDSPHINMEI_CD)          '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPSEIZOU_DT", strXDSPSEIZOU_DT)        '製造年月日
        objTelegram.SETIN_DATA("XDSPLINE_NO", strXDSPLINE_NO)            'ﾗｲﾝ№
        objTelegram.SETIN_DATA("XDSPPALLET_NO", strXDSPPALLET_NO)        'ﾊﾟﾚｯﾄ№
        objTelegram.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)                '搬送管理量
        objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", strXDSPKENSA_KUBUN)    '検索区分
        objTelegram.SETIN_DATA("XDSPAB_KUBUN", strXDSPAB_KUBUN)          'AB区分
        objTelegram.SETIN_DATA("XDSPBC_DATA", strXDSPBC_DATA)            'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ
        objTelegram.SETIN_DATA("XDSPSEISAN_FLAG", strXDSPSEISAN_FLAG)    '生産入庫ﾌﾗｸﾞ


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode                            'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = FRM_MSG_FRM303070_06
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            End If
        End If

        Return blnRet

    End Function
#End Region
#Region "  明細初期表示処理　                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 明細初期表示処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Clear_DTL(ByVal intMode As Integer)

        'If (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(0)) Or _
        '   (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(1)) Or _
        '   (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(2)) Then
        '    '(空ﾊﾟﾚｯﾄ(ﾚﾝﾀﾙ用)、天板、空ﾊﾟﾚｯﾄ(天板用)の時)
        'Else
        '(ﾎｽﾄ管理品の時)
        cboFHINMEI_CD.Text = ""                             '品名ｺｰﾄﾞ
        lblFHINMEI.Text = ""                                '品名
        dtpXSEIZOU_DT.cmpMDateTimePicker_D.Value = Now      '製造年月日
        txtXLINE_NO.Text = ""                               'ﾗｲﾝ№
        txtXPALLET_NO.Text = ""                             'ﾊﾟﾚｯﾄ№
        txtFTR_VOL.Text = ""                                '積数
        cboXKENSA_KUBUN.SelectedIndex = -1                  '検査区分
        txtXAB_KUBUN.Text = ""                              'AB区分
        'End If

        If intMode = 1 Then
            '(BC読取)
            cboFHINMEI_CD.Enabled = False
            dtpXSEIZOU_DT.Enabled = False
            txtXLINE_NO.Enabled = False
            txtXPALLET_NO.Enabled = False
            txtFTR_VOL.Enabled = False
            cboXKENSA_KUBUN.Enabled = False
            txtXAB_KUBUN.Enabled = False

        Else
            '(手入力)
            cboFHINMEI_CD.Enabled = True

            'If (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(0)) Or _
            '   (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(1)) Or _
            '   (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(2)) Then
            '    '(空ﾊﾟﾚｯﾄ(ﾚﾝﾀﾙ用)、天板、空ﾊﾟﾚｯﾄ(天板用)の時)
            '    dtpXSEIZOU_DT.Enabled = False
            '    txtXLINE_NO.Enabled = False
            '    txtXPALLET_NO.Enabled = False
            '    txtFTR_VOL.Enabled = False
            '    cboXKENSA_KUBUN.Enabled = False
            '    txtXAB_KUBUN.Enabled = False
            'Else
            '(ﾎｽﾄ管理品の時)
            dtpXSEIZOU_DT.Enabled = True
            txtXLINE_NO.Enabled = True
            txtXPALLET_NO.Enabled = True
            txtFTR_VOL.Enabled = True
            cboXKENSA_KUBUN.Enabled = True
            txtXAB_KUBUN.Enabled = True

        End If

    End Sub
#End Region

#Region "  ﾓｰﾄﾞ取得ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態取得ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr303070_TickProcess()

        '**********************************************************
        ' ﾗﾍﾞﾙ背景色変更処理
        '**********************************************************
        Call gobjComFuncFRM.AlterButtonColorMOD(btnSTMode, TO_STRING(cboFTRK_BUF_NO.SelectedValue), LBL_DSPTYPE.STSNAME)

    End Sub
#End Region
#Region "  ﾓｰﾄﾞ切替ﾎﾞﾀﾝ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾓｰﾄﾞ切替ﾎﾞﾀﾝ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub btnSTMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTMode.Click

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.STModeBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If gobjComFuncFRM.STModeChange(TO_STRING(cboFTRK_BUF_NO.SelectedValue)) = False Then
            Exit Sub
        End If

    End Sub
#End Region

#Region "  BC読取 明細表示                          "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' BC読取 明細表示
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub Display_BC_DTL()

        cboFHINMEI_CD.Text = Mid(txtBC.Text, 1, 6)                                                   '品名ｺｰﾄﾞ

        If (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(0)) Or _
           (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(1)) Or _
           (cboFHINMEI_CD.Text = mstrFHINMEI_CD_KARA(2)) Or _
           (mintXKANRI_KUBUN = XKANRI_KUBUN_JMATEST) Then
            '(空ﾊﾟﾚｯﾄの時 又は、物流管理品の時)

        Else
            '(以外の時)
            '製造年月日
            dtpXSEIZOU_DT.cmpMDateTimePicker_D.Value = TO_DATE(Mid(txtBC.Text, 7, 4) & "/" & _
                                                               Mid(txtBC.Text, 11, 2) & "/" & _
                                                               Mid(txtBC.Text, 13, 2) & " 00:00:00")
            txtXLINE_NO.Text = Mid(txtBC.Text, 15, 6)                                                    'ﾗｲﾝ№
            txtXPALLET_NO.Text = Mid(txtBC.Text, 21, 4)                                                  'ﾊﾟﾚｯﾄ№
            txtFTR_VOL.Text = TO_DECIMAL(Mid(txtBC.Text, 25, 4))                                         '積数
            cboXKENSA_KUBUN.Text = Mid(txtBC.Text, 29, 1)                                                '検査区分
            txtXAB_KUBUN.Text = Mid(txtBC.Text, 30, 1)                                                   'AB区分

        End If

    End Sub
#End Region
#Region "  ﾊﾞｰｺｰﾄﾞ受信処理　                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｺｰﾄﾞ受信処理
    ''' </summary>
    ''' <param name="strBarcode">読み取ったﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ReadBarcode(ByVal strBarcode As String)


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.BC_READ) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If


        '********************************************************************
        'BC読取 明細表示
        '********************************************************************
        Display_BC_DTL()

    End Sub
#End Region
#Region "　ﾌｫｰﾑ表示後ｲﾍﾞﾝﾄ                          "
    Private Sub FRM_303070_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try


            '*********************************************************
            'ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽにﾌｫｰｶｽを当てる
            '*********************************************************
            Call cmdF5.Focus()
            Call F5Process()


            ' ''*********************************************************
            ' ''ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽ
            ' ''*********************************************************
            ''btnBC.Enabled = True
            ''txtBC.Enabled = True
            ''txtBC.Focus()

            '' ''*********************************************************
            '' ''手入力 ﾃﾞﾌｫﾙﾄ
            '' ''*********************************************************
            ' ''btnBC.Enabled = False          'BC入力無効
            ' ''txtBC.Enabled = False
            ' ''cboFTRK_BUF_NO.Focus()         '入庫ST ﾌｫｰｶｽ


            ''*********************************************************
            ''ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽ
            ''*********************************************************
            ''***txtBC.Focus()

            ''*********************************************************
            ''手入力 ﾃﾞﾌｫﾙﾄ
            ''*********************************************************
            'btnBC.Enabled = False          'BC入力無効
            'txtBC.Enabled = False
            'cboFTRK_BUF_NO.Focus()         '入庫ST ﾌｫｰｶｽ


        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽﾛｽﾄｲﾍﾞﾝﾄ            "
    Private Sub txtBC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBC.LostFocus
        Try
            txtBC.Focus()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽｷｰﾀﾞｳﾝｲﾍﾞﾝﾄ              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽｷｰﾀﾞｳﾝｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtBC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBC.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.SelectNextControl(Me.ActiveControl, False, False, False, False)
            End Select

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽの入力確定ｲﾍﾞﾝﾄ          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽの入力確定ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtBC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBC.Enter
        Try

            If txtBC.Text.Length > 0 Then
                ''If TextBox1.Text.Length = 20 Then
                Call ReadBarcode(txtBC.Text)
            End If

        Catch ex As Exception
            ComError(ex)
        Finally
            txtBC.Text = ""
        End Try
    End Sub
#End Region
#Region "  ﾃｽﾄ用  BC入力ﾎﾞﾀﾝ処理                    "
    Private Sub btnBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBC.Click
        Try

            '**********************************************************
            ' ｺﾝﾄﾛｰﾙ初期化
            '**********************************************************
            Call Clear_DTL(1)               '明細初期表示

            Call ReadBarcode(txtBC.Text)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

End Class
