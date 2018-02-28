'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】倉替入庫設定子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_303031
#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFTRK_BUF_NO As String                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    Protected mstrFTRK_BUF_NO_Disp As String            '入庫ST
    Protected mstrFHINMEI_CD As String                  '品名記号
    Protected mstrFHINMEI As String                     '品名
    Protected mstrXKENPIN_KUBUN As String               '検品区分
    Protected mstrXKENPIN_KUBUN_Disp As String          '検品区分(表示用)
    Protected mblnXKENPIN_Flag As Boolean               '検品ｴﾘｱ ﾌﾗｸﾞ
    Protected mstrFIN_KUBUN As String                   '入庫区分

    Protected mstrFPALLET_ID() As String                'ﾊﾟﾚｯﾄID

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        KurakaeSet_Click                '倉替設定
        CancelBtn_Click                 'ｷｬﾝｾﾙ
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

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

    ''' =======================================
    ''' <summary>入庫ST</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFTRK_BUF_NO_Disp() As String
        Get
            Return mstrFTRK_BUF_NO_Disp
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO_Disp = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI() As String
        Get
            Return mstrFHINMEI
        End Get
        Set(ByVal value As String)
            mstrFHINMEI = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検品区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXKENPIN_KUBUN() As String
        Get
            Return mstrXKENPIN_KUBUN
        End Get
        Set(ByVal value As String)
            mstrXKENPIN_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検品区分(表示用)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXKENPIN_KUBUN_Disp() As String
        Get
            Return mstrXKENPIN_KUBUN_Disp
        End Get
        Set(ByVal value As String)
            mstrXKENPIN_KUBUN_Disp = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検品ｴﾘｱ ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXKENPIN_Flag() As Boolean
        Get
            Return mblnXKENPIN_Flag
        End Get
        Set(ByVal value As Boolean)
            mblnXKENPIN_Flag = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFIN_KUBUN() As String
        Get
            Return mstrFIN_KUBUN
        End Get
        Set(ByVal value As String)
            mstrFIN_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFPALLET_ID() As String()
        Get
            Return mstrFPALLET_ID
        End Get
        Set(ByVal value As String())
            mstrFPALLET_ID = value
        End Set
    End Property

#End Region

#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_310011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_310011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　倉替設定   　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdKurakaeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKurakaeSet.Click
        Try

            Call cmdKurakaeSet_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_303031_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region

#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()

        '===================================
        '入庫ST ｾｯﾄ
        '===================================
        lblIN_ST.Text = mstrFTRK_BUF_NO_Disp

        '===================================
        '品名 ｾｯﾄ
        '===================================
        lblFHINMEI.Text = mstrFHINMEI

        '===================================
        '入庫区分ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFIN_KUBUN, False, mstrFIN_KUBUN)

        '===================================
        '検品区分ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENPIN_KUBUN, False, mstrXKENPIN_KUBUN)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumrua 2013/06/26 品名ｺｰﾄﾞ、記号の両方に対応
        '' ''===================================
        '' ''検品ｴﾘｱの確認
        '' ''===================================
        ' ''If mblnXKENPIN_Flag = True Then
        ' ''    '(検品ｴﾘｱの場合)

        ' ''    '===================================
        ' ''    '検品区分ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        ' ''    '===================================
        ' ''    cboXKENPIN_KUBUN.Enabled = True
        ' ''    Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENPIN_KUBUN, False, -1)

        ' ''Else
        ' ''    '(検品ｴﾘｱではない場合)

        ' ''    '===================================
        ' ''    '検品区分ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        ' ''    '===================================
        ' ''    cboXKENPIN_KUBUN.Enabled = False
        ' ''    ' ''cboXKENPIN_KUBUN.Items.Add(mstrXKENPIN_KUBUN_Disp)
        ' ''    ' ''cboXKENPIN_KUBUN.SelectedIndex = 0

        ' ''End If
        '↑↑↑↑↑↑************************************************************************************************************

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        lblIN_ST.Dispose()
        lblFHINMEI.Dispose()
        cboXKENPIN_KUBUN.Dispose()

    End Sub
#End Region
#Region "　倉替設定        ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 倉替設定 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdKurakaeSet_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.KurakaeSet_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket02() = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ           ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.CancelBtn_Click) = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
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
        Dim strMsg As String = ""

        Select Case udtCheck_Case
            Case menmCheckCase.KurakaeSet_Click
                '(倉替設定の場合)

                '========================================
                '入庫区分
                '========================================
                If cboFIN_KUBUN.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FIN_KUBUN, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '検品区分
                '========================================
                If cboXKENPIN_KUBUN.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XKENPIN_KUBUN, _
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
                objTPRG_TRK_BUF.FTRK_BUF_NO = TO_STRING(mstrFTRK_BUF_NO)            '入庫ST ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intCountZaiko = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT_ZAIKO()      '取得
                If intCountZaiko <> 0 Then
                    '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303031_01, _
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
                objTMST_TRK.FTRK_BUF_NO = TO_STRING(mstrFTRK_BUF_NO)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objTMST_TRK.GET_TMST_TRK(False)
                If intRet = RetCode.OK Then
                    '(読めたとき)
                    If IsNull(objTMST_TRK.XTRK_BUF_NO_CONV) = False Then
                        '(値がある時)
                        strST_FM = objTMST_TRK.XTRK_BUF_NO_CONV          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                    Else
                        '(値がない時)
                        strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                                 "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & mstrFTRK_BUF_NO & "]"
                        Throw New System.Exception(strMsg)
                    End If
                Else
                    '(読めなかった時)
                    strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                             "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & mstrFTRK_BUF_NO & "]"
                    Throw New System.Exception(strMsg)
                End If

                intCountZaiko = 0
                objTPRG_TRK_BUF.CLEAR_PROPERTY()
                objTPRG_TRK_BUF.FTRK_BUF_NO = strST_FM                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intCountZaiko = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT_ZAIKO()      '取得
                If intCountZaiko <> 0 Then
                    '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303031_01, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Information)
                    Exit Select
                End If

                '************************************************
                ' 連続入庫設定        ﾁｪｯｸ
                '************************************************
                If CheckContinueState(mstrFTRK_BUF_NO) = True Then
                    '(連続入庫設定中の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303031_02, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False

            Case menmCheckCase.CancelBtn_Click
                '(ｷｬﾝｾﾙの場合)

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

#Region "  ｿｹｯﾄ送信(倉替設定)                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(倉替設定)
    ''' </summary>
    ''' <returns>True :送信成功 False:送信失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket02() As Boolean

        Dim blnReturn As Boolean = False    '自関数戻値
        Dim blnCheckErr As Boolean = True   'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "倉替設定を開始" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
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
        Dim strXDSPKENPIN_KUBUN = ""                        '検品区分
        Dim strXDSPPALLET_ID_KO = ""                        'ﾊﾟﾚｯﾄID(子)
        Dim strDSPIN_KUBUN = ""                             '入庫区分

        Dim blnPareFlag As Boolean = False                  'ﾍﾟｱ入庫ﾌﾗｸﾞ

        Dim intALL_PL_Count As Integer = 0                  '搬送ﾊﾟﾚｯﾄ数

        '********************************************************************
        ' ﾊﾟﾚｯﾄ数
        '********************************************************************
        intALL_PL_Count = mstrFPALLET_ID.Length

        '**********************************************************
        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀの特定  (搬送元ST特定)
        '**********************************************************
        Dim strMsg As String
        Dim intRet As RetCode
        Dim objTMST_TRK As TBL_TMST_TRK                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        objTMST_TRK.FTRK_BUF_NO = mstrFTRK_BUF_NO                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        intRet = objTMST_TRK.GET_TMST_TRK(False)
        If intRet = RetCode.OK Then
            '(読めたとき)
            If IsNull(objTMST_TRK.XTRK_BUF_NO_CONV) = False Then
                '(値がある時)
                strDSPST_FM = objTMST_TRK.XTRK_BUF_NO_CONV          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            Else
                '(値がない時)
                strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                         "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & mstrFTRK_BUF_NO & "]"
                Throw New System.Exception(strMsg)
            End If
        Else
            '(読めなかった時)
            strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                     "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & mstrFTRK_BUF_NO & "]"
            Throw New System.Exception(strMsg)
        End If

        strDSPST_TO = FTRK_BUF_NO_J9000         '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№


        strXDSPKENPIN_KUBUN = TO_STRING(cboXKENPIN_KUBUN.SelectedValue.ToString)    '検品区分
        'If mblnXKENPIN_Flag = True Then                 '検品区分
        '    '(検品ｴﾘｱの場合)
        '    strXDSPKENPIN_KUBUN = TO_STRING(cboXKENPIN_KUBUN.SelectedValue.ToString)
        'Else
        '    '(それ以外)
        '    strXDSPKENPIN_KUBUN = ""
        'End If
        strDSPIN_KUBUN = TO_STRING(cboFIN_KUBUN.SelectedValue.ToString)             '入庫区分

        '********************************************************************
        ' 入庫設定用 電文作成
        '********************************************************************
        '送信電文
        ReDim strSndTlgrm(0)

        For ii As Integer = 1 To intALL_PL_Count Step 2
            '(ﾊﾟﾚｯﾄ数分ﾙｰﾌﾟ)
            If ii + 1 <= intALL_PL_Count Then
                blnPareFlag = True

                strDSPPALLET_ID = mstrFPALLET_ID(ii - 1)
                strXDSPPALLET_ID_KO = mstrFPALLET_ID(ii)
            Else
                blnPareFlag = False

                strDSPPALLET_ID = mstrFPALLET_ID(ii - 1)
            End If


            '配列再定義
            ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列

            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400502

            objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6)) 'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

            objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPST_TO", strDSPST_TO)                  '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
            '' ''If blnPareFlag = True Then
            '' ''    objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J53))    '作業種別 ﾛｰｶﾙ入庫(ﾍﾟｱ)
            '' ''    objTelegramSub.SETIN_DATA("XDSPIN_KIND", 1)                                 '入庫種別(ﾍﾟｱ)
            '' ''Else
            '' ''    objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J54))    '作業種別 ﾛｰｶﾙ入庫(ｼﾝｸﾞﾙ)
            '' ''    objTelegramSub.SETIN_DATA("XDSPIN_KIND", 0)                                 '入庫種別((ｼﾝｸﾞﾙ)
            '' ''End If
            If blnPareFlag = True Then
                objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J75))    '作業種別 ﾛｰｶﾙ入庫(ﾍﾟｱ)
                objTelegramSub.SETIN_DATA("XDSPIN_KIND", 1)                                 '入庫種別(ﾍﾟｱ)
            Else
                objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J76))    '作業種別 ﾛｰｶﾙ入庫(ｼﾝｸﾞﾙ)
                objTelegramSub.SETIN_DATA("XDSPIN_KIND", 0)                                 '入庫種別((ｼﾝｸﾞﾙ)
            End If
            'JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
            '↑↑↑↑↑↑************************************************************************************************************

            objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", strXDSPPALLET_ID_KO)      'ﾊﾟﾚｯﾄID(子)
            objTelegramSub.SETIN_DATA("XDSPKENPIN_KUBUN", strXDSPKENPIN_KUBUN)  '検品区分
            objTelegramSub.SETIN_DATA("DSPIN_KUBUN", strDSPIN_KUBUN)            '入庫区分

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
        objTelegramNull.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400502

        '=====================================
        '複数ｿｹｯﾄ処理
        '=====================================
        strErrMsg = "倉替設定に失敗しました。"
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
